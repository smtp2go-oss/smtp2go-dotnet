using System;
using System.Collections.Generic;
using System.Text;

namespace Smtp2Go.Api.Models
{
    /// <summary>
    /// The root contract all objects that are returned from the <see cref="Smtp2GoApiClient">Smtp2Go Api Client</see> must adhere to.
    /// </summary>
    public interface IApiResponse
    {
        /// <summary>
        /// The HTTP status message returned by the API Client.
        /// </summary>
        string ResponseStatus { get; set; }

        /// <summary>
        /// A Unique ID for this request.
        /// </summary>
        string RequestId { get; set; }
    }
}
