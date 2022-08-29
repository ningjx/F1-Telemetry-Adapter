using NingSoft.F1TelemetryAdapter.F1_20_packets;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_21_packets
{
    public class HeaderPacket21 : HeaderPacket20
    {
        public HeaderPacket21(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }
    }
}
