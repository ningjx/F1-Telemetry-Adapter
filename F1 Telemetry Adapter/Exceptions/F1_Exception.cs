using System;
using System.Collections.Generic;
using System.Text;

namespace F1_Telemetry_Adapter.Exceptions
{
    public class F1_Exception : Exception
    {
        public F1_Exception(string message) : base(message) { }

    }
}
