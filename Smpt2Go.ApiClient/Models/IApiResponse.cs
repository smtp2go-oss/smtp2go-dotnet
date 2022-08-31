using System;
using System.Collections.Generic;
using System.Text;

namespace Smtp2Go.Api.Models
{
    public interface IApiResponse
    {
        string ResponseStatus { get; set; }

        string RequestId { get; set; }
    }
}
