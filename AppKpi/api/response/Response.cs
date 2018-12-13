using System;
using System.Collections.Generic;
using System.Text;

namespace AppKpi.api.response
{
    public class Response<T> : EmptyResponse
    {
        public T Data { get; set; }
    }
}
