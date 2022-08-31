using System;
using System.Collections.Generic;
using System.Text;

namespace Smtp2Go.Api.Models
{
    public interface IApiRequest
    {
        string? ApiKey { get; set; }
    }
}
