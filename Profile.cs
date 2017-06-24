//-----------------------------------------------------------------------
// <copyright file="Profile.cs" company="Michael Kourlas">
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

    /// <summary>
    /// Represents a period of time between dynamic DNS updates.
    /// </summary>
    public enum UpdateIntervalEnum
    {
        /// <summary>
        /// 1 minute.
        /// </summary>
        ONE_MINUTE,

        /// <summary>
        /// 5 minutes.
        /// </summary>
        FIVE_MINUTES,

        /// <summary>
        /// 15 minutes.
        /// </summary>
        FIFTEEN_MINUTES,

        /// <summary>
        /// 30 minutes.
        /// </summary>
        THIRTY_MINUTES,

        /// <summary>
        /// 1 hour.
        /// </summary>
        ONE_HOUR,

        /// <summary>
        /// 3 hours.
        /// </summary>
        THREE_HOURS,

        /// <summary>
        /// 6 hours.
        /// </summary>
        SIX_HOURS,

        /// <summary>
        /// 12 hours.
        /// </summary>
        TWELVE_HOURS,

        /// <summary>
        /// 24 hours.
        /// </summary>
        TWENTY_FOUR_HOURS,
    }

    /// <summary>
    /// Represents a Namecheap dynamic DNS update profile.
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Profile"/> class.
        /// </summary>
        public Profile()
        {
            this.LastSyncTime = DateTime.MinValue;
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
        public UpdateIntervalEnum UpdateInterval
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the IP address to use for updates. This is not used
        /// if <see cref="AutoDetectIpAddress"/> is true.
        /// </summary>
        public string IpAddress
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets a value indicating whether the current public IP 
        /// address should be used for updates.
        /// </summary>
        public bool AutoDetectIpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last time an update occurred using this profile.
        /// </summary>
        public DateTime LastSyncTime
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
        /// Gets a <see cref="TimeSpan"/> object representing the specified
        /// update interval.
        /// </summary>
        /// <param name="updateInterval">The specified update interval.</param>
        /// <returns>A <see cref="TimeSpan"/> object representing the specified
        /// update interval.</returns>
        public static TimeSpan GetTimeSpanForUpdateInterval(
            UpdateIntervalEnum updateInterval)
        {
            switch (updateInterval)
            {
                case UpdateIntervalEnum.ONE_MINUTE:
                    return new TimeSpan(0, 1, 0);
                case UpdateIntervalEnum.FIVE_MINUTES:
                    return new TimeSpan(0, 5, 0);
                case UpdateIntervalEnum.FIFTEEN_MINUTES:
                    return new TimeSpan(0, 15, 0);
                case UpdateIntervalEnum.THIRTY_MINUTES:
                    return new TimeSpan(0, 30, 0);
                case UpdateIntervalEnum.ONE_HOUR:
                    return new TimeSpan(1, 0, 0);
                case UpdateIntervalEnum.THREE_HOURS:
                    return new TimeSpan(3, 0, 0);
                case UpdateIntervalEnum.SIX_HOURS:
                    return new TimeSpan(6, 0, 0);
                case UpdateIntervalEnum.TWELVE_HOURS:
                    return new TimeSpan(12, 0, 0);
                case UpdateIntervalEnum.TWENTY_FOUR_HOURS:
                    return new TimeSpan(24, 0, 0);
                default:
                    throw new Exception("Unrecognized update interval");
            }
        }
    }
}
