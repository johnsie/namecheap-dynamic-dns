//-----------------------------------------------------------------------
// <copyright file="DynamicDnsUpdateEventargs.cs" company="Michael Kourlas">
//   namecheap-dynamic-dns
//   Copyright (C) 2017-2019 Michael Kourlas
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
    /// Information about dynamic DNS update attempts.
    /// </summary>
    public class DynamicDnsUpdateEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="DynamicDnsUpdateEventArgs"/> class.
        /// </summary>
        /// <param name="profile">The profile associated with the update
        /// attempt.</param>
        /// <param name="success">Whether the update succeeded.</param>
        /// <param name="ip">The IP associated with the update attempt.</param>
        /// <param name="dateTime">The date and time when the update attempt
        /// occurred.</param>
        /// <param name="response">The response from Namecheap following the
        /// update attempt.</param>
        /// <param name="exception">The exception associated with the update
        /// attempt, if any.</param>
        public DynamicDnsUpdateEventArgs(
            DynamicDnsProfile profile, 
            bool success, 
            IPAddress ip, 
            DateTime dateTime, 
            string response, 
            DynamicDnsException exception)
        {
            this.UpdateProfile = profile;
            this.Success = success;
            this.Ip = ip;
            this.UpdateDateTime = dateTime;
            this.Response = response;
            this.UpdateException = exception;
        }

        /// <summary>
        /// Gets the profile associated with the update attempt.
        /// </summary>
        public DynamicDnsProfile UpdateProfile
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the update succeeded.
        /// </summary>
        public bool Success
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the IP associated with the update attempt.
        /// </summary>
        public IPAddress Ip
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the date and time when the update attempt occurred.
        /// </summary>
        public DateTime UpdateDateTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the response from Namecheap following the update attempt.
        /// </summary>
        public string Response
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the exception associated with the update attempt, if any.
        /// </summary>
        public DynamicDnsException UpdateException
        {
            get;
            private set;
        }
    }
}
