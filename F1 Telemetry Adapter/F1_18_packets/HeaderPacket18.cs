using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_18_packets
{
    public class HeaderPacket18 : HeaderPacket
    {
        public override int Length => 21;

        public HeaderPacket18(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {Name="PacketFormat",TypeName = "uint16"},
            new PacketField {Name="PacketVersion",TypeName = "uint8"},
            new PacketField {Name="PacketId",TypeName = "uint8"},
            new PacketField {Name="SessionUID",TypeName = "uint64"},
            new PacketField {Name="SessionTime",TypeName = "float"},
            new PacketField {Name="FrameIdentifier",TypeName = "uint"},
            new PacketField {Name="PlayerCarIndex",TypeName = "uint8"}
        };
    }
}
