//-----------------------------------------------------------------------
// <copyright file="DynamicDns.cs" company="Michael Kourlas">
//   namecheap-dynamic-dns
//   Copyright (C) 2017 Michael Kourlas
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Kourlas.NamecheapDynamicDns
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// Handles the performance and scheduling of dynamic DNS updates and 
    /// informs the UI when they are complete using an event handler.
    /// </summary>
    public class DynamicDns
    {
        /// <summary>
        /// The dynamic DNS profiles used by the application.
        /// </summary>
        private readonly Dictionary<Guid, DynamicDnsProfile> profiles;

        /// <summary>
        /// The update interval timers for each of the profiles.
        /// </summary>
        private readonly Dictionary<Guid, Timer> timers;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicDns"/> class.
        /// </summary>
        public DynamicDns()
        {
            this.profiles = new Dictionary<Guid, DynamicDnsProfile>();
            this.timers = new Dictionary<Guid, Timer>();
            this.DynamicDnsUpdateEventHandler = delegate { };
        }

        /// <summary>
        /// Event triggered when a DNS update occurs.
        /// </summary>
        public event EventHandler<DynamicDnsUpdateEventArgs>
            DynamicDnsUpdateEventHandler;

        /// <summary>
        /// Gets the profiles that are currently configured.
        /// </summary>
        public Dictionary<Guid, DynamicDnsProfile> Profiles => this.profiles;

        /// <summary>
        /// Gets the profile with the specified ID.
        /// </summary>
        /// <param name="id">The specified ID.</param>
        /// <returns>The profile with the specified ID, or null if no such 
        /// profile exists.</returns>
        public DynamicDnsProfile GetProfile(Guid id)
        {
            this.profiles.TryGetValue(id, out DynamicDnsProfile profile);
            return profile;
        }

        /// <summary>
        /// Adds the specified profile to the profiles list.
        /// </summary>
        /// <param name="profile">The specified profile.</param>
        /// <returns>A task which completes when the process is 
        /// complete.</returns>
        public async Task AddProfile(DynamicDnsProfile profile)
        {
            this.profiles[profile.Id] = profile;
            await this.PerformUpdate(profile);
        }

        /// <summary>
        /// Deletes the profile with the specified ID.
        /// </summary>
        /// <param name="id">The specified ID.</param>
        public void DeleteProfile(Guid id)
        {
            if (this.timers.ContainsKey(id))
            {
                this.timers[id].Stop();
                this.timers.Remove(id);
            }

            if (this.profiles.ContainsKey(id))
            {
                this.profiles.Remove(id);
            }
        }

        /// <summary>
        /// Performs an update for all profiles.
        /// </summary>
        /// <returns>A task which completes when the process is 
        /// complete.</returns>
        public async Task PerformUpdateAll()
        {
            foreach (var profile in this.profiles.Values)
            {
                await this.PerformUpdate(profile);
            }
        }

        /// <summary>
        /// Performs an update for the specified profile.
        /// </summary>
        /// <param name="profile">The specified profile.</param>
        /// <returns>A task which completes when the process is 
        /// complete.</returns>
        public async Task PerformUpdate(DynamicDnsProfile profile)
        {
            try
            {
                var response = await GetUpdateResponse(profile);
                this.DynamicDnsUpdateEventHandler.Invoke(
                    this,
                    new DynamicDnsUpdateEventArgs(
                        profile, 
                        true, 
                        response.Item2, 
                        DateTime.Now,
                        response.Item1, 
                        null));
            }
            catch (DynamicDnsException ex)
            {
                this.DynamicDnsUpdateEventHandler.Invoke(
                    this,
                    new DynamicDnsUpdateEventArgs(
                        profile, 
                        false, 
                        null, 
                        DateTime.Now,
                        ex.Response,
                        ex));
            }
            catch (Exception ex)
            {
                this.DynamicDnsUpdateEventHandler.Invoke(
                    this,
                    new DynamicDnsUpdateEventArgs(
                        profile, 
                        false, 
                        null, 
                        DateTime.Now, 
                        null,
                        new DynamicDnsException("Unknown error", ex)));
            }

            this.timers.TryGetValue(profile.Id, out Timer timer);
            timer?.Stop();
            this.timers[profile.Id] = this.CreateTimer(profile);
        }

        /// <summary>
        /// Performs a dynamic DNS update with Namecheap servers using the 
        /// specified profile.
        /// </summary>
        /// <param name="profile">The specified profile, which contains 
        /// information about the domain to update and the IP address to 
        /// use.</param>
        /// <returns>The string containing the update response.</returns>
        private static async Task<Tuple<string, IPAddress>> GetUpdateResponse(
            DynamicDnsProfile profile)
        {
            try
            {
                // Use current machine's IPv4 address if requested
                var ip = IPAddress.Parse(profile.UpdateIPAddress);
                if (profile.AutoDetectIPAddress)
                {
                    ip = await GetIp();
                }

                // Get response and parse as XML
                HttpWebRequest request = WebRequest.CreateHttp(
                    "https://dynamicdns.park-your-domain.com/update?" +
                    "host=" + WebUtility.UrlEncode(profile.Host) +
                    "&domain=" + WebUtility.UrlEncode(profile.Domain) +
                    "&password=" + WebUtility.UrlEncode(
                        profile.DynamicDnsPassword) +
                    "&ip=" + WebUtility.UrlEncode(ip.ToString()));
                var response = new XmlDocument();
                response.LoadXml(new StreamReader(
                    request.GetResponse().GetResponseStream()).ReadToEnd());

                ValidateUpdateResponse(ip, response);

                return new Tuple<string, IPAddress>(response.OuterXml, ip);
            }
            catch (WebException ex)
            {
                throw new DynamicDnsException(
                    "Dynamic DNS update response network error", ex);
            }
            catch (XmlException ex)
            {
                throw new DynamicDnsException(
                    "Failed to parse dynamic DNS update response as XML", ex);
            }
            catch (DynamicDnsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new DynamicDnsException("Unknown error", ex);
            }
        }

        /// <summary>
        /// Validates the response retrieved during the dynamic DNS update.
        /// </summary>
        /// <param name="ip">The IP address specified in the request.</param>
        /// <param name="response">The response received for the 
        /// request.</param>
        private static void ValidateUpdateResponse(
            IPAddress ip, XmlDocument response)
        {
            // Validate that Command is equal to SETDNSHOST
            var commandTag = response.GetElementsByTagName("Command");
            if (commandTag.Count == 1)
            {
                if (commandTag[0].InnerText != "SETDNSHOST")
                {
                    throw new DynamicDnsException(
                        "Command tag not equal to SETDNSHOST", 
                        response.OuterXml);
                }
            }
            else
            {
                throw new DynamicDnsException(
                    "Command tag missing", response.OuterXml);
            }

            // Validate that IP matches the IP we specified in the request
            var ipTag = response.GetElementsByTagName("IP");
            if (ipTag.Count == 1)
            {
                try
                {
                    var responseIp = IPAddress.Parse(ipTag[0].InnerText);
                    if (responseIp.ToString() != ip.ToString())
                    {
                        throw new DynamicDnsException(
                            $"IP in IP tag ('{responseIp.ToString()}')" +
                            $" does not match IP in" +
                            $" request ('{ip.ToString()}')", 
                            response.OuterXml);
                    }
                }
                catch (FormatException ex)
                {
                    throw new DynamicDnsException(
                        $"IP tag value ('{ipTag[0].InnerText}')" +
                        $" could not be parsed as IP address", 
                        response.OuterXml, 
                        ex);
                }
            }
            else
            {
                throw new DynamicDnsException(
                    "IP tag missing", response.OuterXml);
            }

            // Validate that ErrCount is equal to 0
            var errCountTag = response.GetElementsByTagName("ErrCount");
            if (errCountTag.Count == 1)
            {
                if (errCountTag[0].InnerText != "0")
                {
                    throw new DynamicDnsException(
                        $"ErrCount tag value ('{errCountTag[0].InnerText}')" +
                        $" not equal to '0'", 
                        response.OuterXml);
                }
            }
            else
            {
                throw new DynamicDnsException(
                    "ErrCount tag missing", 
                    response.OuterXml);
            }

            // Validate that Done is equal to true
            var doneTag = response.GetElementsByTagName("Done");
            if (doneTag.Count == 1)
            {
                if (doneTag[0].InnerText != "true")
                {
                    throw new DynamicDnsException(
                        $"Done tag value ('{doneTag[0].InnerText}') not" +
                        $" equal to 'true'", 
                        response.OuterXml);
                }
            }
            else
            {
                throw new DynamicDnsException(
                    "Done tag missing", response.OuterXml);
            }
        }

        /// <summary>
        /// Retrieves the public IPv4 address of the machine that this 
        /// application is running on from Namecheap.
        /// </summary>
        /// <returns>The machine's public IPv4 address.</returns>
        private static async Task<IPAddress> GetIp()
        {
            var request = WebRequest.CreateHttp(
                "https://dynamicdns.park-your-domain.com/getip");
            try
            {
                var response = await request.GetResponseAsync();
                var rawIp = new StreamReader(
                    response.GetResponseStream()).ReadToEnd();
                try
                {
                    return IPAddress.Parse(rawIp);
                }
                catch (FormatException ex)
                {
                    throw new DynamicDnsException(
                        "Auto-detect IP address response could not be parsed" +
                        " as IP address", 
                        rawIp,
                        ex);
                }
            }
            catch (WebException ex)
            {
                throw new DynamicDnsException(
                    "Auto-detect IP address network error", 
                    ex);
            }
            catch (Exception ex)
            {
                throw new DynamicDnsException("Unknown error", ex);
            }
        }

        /// <summary>
        /// Creates a timer to perform scheduled updates for the specified
        /// profile.
        /// </summary>
        /// <param name="profile">The specified profile.</param>
        /// <returns>The created timer.</returns>
        private Timer CreateTimer(DynamicDnsProfile profile)
        {
            var timer = new Timer();
            timer.Tick += this.OnTimerTick;
            timer.Interval = profile.GetUpdateIntervalInMilliseconds();
            timer.Start();
            timer.Tag = profile.Id;
            return timer;
        }

        /// <summary>
        /// Called when the timer for one of the profiles ticks.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnTimerTick(object sender, EventArgs e)
        {
            var timer = (Timer)sender;
            var id = (Guid)timer.Tag;

            if (this.profiles.ContainsKey(id))
            {
                await this.PerformUpdate(this.profiles[id]);
            }
        }
    }
}
