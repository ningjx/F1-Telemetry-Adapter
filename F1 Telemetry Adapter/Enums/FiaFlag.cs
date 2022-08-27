using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NingSoft.F1TelemetryAdapter.Enums
{
    public enum FiaFlag : sbyte
    {
        Invalid = -1,
        None = 0, Green, Blue, Yellow, Red
    }
}
