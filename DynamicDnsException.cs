//-----------------------------------------------------------------------
// <copyright file="DynamicDnsException.cs" company="Michael Kourlas">
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

    /// <summary>
    /// Primary exception thrown by this application.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Usage", 
        "CA2237:MarkISerializableTypesWithSerializable", 
        Justification = "No need to serialize this object.")]
    public class DynamicDnsException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicDnsException"/>
        /// class.
        /// </summary>
        /// <param name="message">The message associated with the
        /// exception.</param>
        public DynamicDnsException(
            string message) : base(message)
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicDnsException"/>
        /// class.
        /// </summary>
        /// <param name="message">The message associated with the 
        /// exception.</param>
        /// <param name="innerException">The exception associated with the 
        /// exception.</param>
        public DynamicDnsException(
            string message,
            Exception innerException) : base(message, innerException)
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicDnsException"/>
        /// class.
        /// </summary>
        /// <param name="message">The message associated with the 
        /// exception.</param>
        /// <param name="response">The response associated with the 
        /// exception.</param>
        public DynamicDnsException(
            string message, string response) : base(message)
        {
            this.Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicDnsException"/>
        /// class.
        /// </summary>
        /// <param name="message">The message associated with the 
        /// exception.</param>
        /// <param name="response">The response associated with the 
        /// exception.</param>
        /// <param name="innerException">The exception associated with the 
        /// exception.</param>
        public DynamicDnsException(
            string message, 
            string response, 
            Exception innerException) : base(message, innerException)
        {
            this.Response = response;
        }

        /// <summary>
        /// Gets the response associated with the exception.
        /// </summary>
        public string Response
        {
            get;
            private set;
        }
    }
}
