//-----------------------------------------------------------------------
// <copyright file="DynamicDnsProfile.cs" company="Michael Kourlas">
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
    using System.Net;

    /// <summary>
    /// Represents a period of time between dynamic DNS updates.
    /// </summary>
    public enum UpdateInterval
    {
        /// <summary>
        /// 1 minute.
        /// </summary>
        OneMinute,

        /// <summary>
        /// 5 minutes.
        /// </summary>
        FiveMinutes,

        /// <summary>
        /// 15 minutes.
        /// </summary>
        FifteenMinutes,

        /// <summary>
        /// 30 minutes.
        /// </summary>
        ThirtyMinutes,

        /// <summary>
        /// 1 hour.
        /// </summary>
        OneHour,

        /// <summary>
        /// 3 hours.
        /// </summary>
        ThreeHours,

        /// <summary>
        /// 6 hours.
        /// </summary>
        SixHours,

        /// <summary>
        /// 12 hours.
        /// </summary>
        TwelveHours,

        /// <summary>
        /// 24 hours.
        /// </summary>
        TwentyFourHours,
    }

    /// <summary>
    /// Represents a Namecheap dynamic DNS update profile.
    /// </summary>
    [Serializable]
    public class DynamicDnsProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicDnsProfile"/> 
        /// class.
        /// </summary>
        public DynamicDnsProfile()
        {
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the ID of this profile.
        /// </summary>
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the host or subdomain associated with this profile.
        /// </summary>
        public string Host
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the domain associated with this profile.
        /// </summary>
        public string Domain
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the dynamic DNS password associated with this profile.
        /// </summary>
        public string DynamicDnsPassword
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the frequency at which updates occur with this 
        /// profile.
        /// </summary>
        public UpdateInterval Interval
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the IP address to use for updates. This is not used
        /// if <see cref="AutoDetectIPAddress"/> is true.
        /// </summary>
        public string UpdateIPAddress
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets a value indicating whether the current public IP 
        /// address should be used for updates.
        /// </summary>
        public bool AutoDetectIPAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a label that represents this profile in the list of profiles
        /// and in the status list.
        /// </summary>
        public string Label
        {
            get
            {
                return this.Host + "." + this.Domain;
            }
        }

        /// <summary>
        /// Returns the frequency at which updates occur with this profile
        /// in milliseconds.
        /// </summary>
        /// <returns>
        /// The frequency at which updates occur with this profile
        /// in milliseconds.
        /// </returns>
        public int GetUpdateIntervalInMilliseconds()
        {
            switch (this.Interval)
            {
                case UpdateInterval.OneMinute:
                    return (int)new TimeSpan(0, 1, 0).TotalMilliseconds;
                case UpdateInterval.FiveMinutes:
                    return (int)new TimeSpan(0, 5, 0).TotalMilliseconds;
                case UpdateInterval.FifteenMinutes:
                    return (int)new TimeSpan(0, 15, 0).TotalMilliseconds;
                case UpdateInterval.ThirtyMinutes:
                    return (int)new TimeSpan(0, 30, 0).TotalMilliseconds;
                case UpdateInterval.OneHour:
                    return (int)new TimeSpan(1, 0, 0).TotalMilliseconds;
                case UpdateInterval.ThreeHours:
                    return (int)new TimeSpan(3, 0, 0).TotalMilliseconds;
                case UpdateInterval.SixHours:
                    return (int)new TimeSpan(6, 0, 0).TotalMilliseconds;
                case UpdateInterval.TwelveHours:
                    return (int)new TimeSpan(12, 0, 0).TotalMilliseconds;
                case UpdateInterval.TwentyFourHours:
                    return (int)new TimeSpan(24, 0, 0).TotalMilliseconds;
                default:
                    throw new DynamicDnsException("Unrecognized update interval");
            }
        }
    }
}
