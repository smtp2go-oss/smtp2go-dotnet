using System;
using System.Collections.Generic;
using System.Text;

namespace Smtp2Go.Api.Models
{
    /// <summary>
    /// The root contract all response objects that are returned from the <see cref="Smtp2GoApiClient">Smtp2Go Api Client</see> contain.
    /// </summary>
    public interface IApiResponseData
    {
        /// <summary>
        /// An error string.
        /// </summary>
        string Error { get; set; }

        /// <summary>
        /// An API Error Code string.
        /// </summary>
        string ErrorCode { get; set; }
    }
}
