using Smtp2Go.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smtp2Go.Api
{
    public interface IApiClient
    {
        public Task<T> SendReceive<X, T>(X request, T response, string endpoint) where T : IApiResponse where X : IApiRequest;
    }
}
