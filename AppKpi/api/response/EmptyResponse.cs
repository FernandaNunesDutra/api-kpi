using System;
using System.Collections.Generic;
using System.Text;

namespace AppKpi.api.response
{
    public class EmptyResponse
    {
        public bool Success { get; set; }
        public string ErrorDescription { get; set; }
        public bool LoginAgain { get; set; }
    }
}
