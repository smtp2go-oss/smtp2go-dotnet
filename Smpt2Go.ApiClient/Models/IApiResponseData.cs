using System;
using System.Collections.Generic;
using System.Text;

namespace Smtp2Go.Api.Models
{
    public interface IApiResponseData
    {
        string Error { get; set; }

        string ErrorCode { get; set; }
    }
}
