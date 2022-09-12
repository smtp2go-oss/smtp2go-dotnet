using System;
using System.Collections.Generic;
using System.Text;

namespace Smtp2Go.Api.Models
{
    /// <summary>
    /// The root contract all objects that interact with the <see cref="Smtp2GoApiClient">Smtp2Go Api Client</see> must adhere to.
    /// </summary>
    public interface IApiRequest
    {
        /// <summary>
        /// The API Key that all interactions with the Smtp2Go API must contain.
        /// </summary>
        string? ApiKey { get; set; }
    }
}
