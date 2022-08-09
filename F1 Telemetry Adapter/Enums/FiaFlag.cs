using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Telemetry_Adapter.Enums
{
    public enum FiaFlag : sbyte
    {
        Invalid = -1,
        None = 0, Green, Blue, Yellow, Red
    }
}
