using NingSoft.F1TelemetryAdapter.F1_21_packets;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_22_packets
{
    public class HeaderPacket22 : HeaderPacket21
    {
        public HeaderPacket22(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }
    }
}
