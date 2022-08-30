using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_22_packets
{
    public class HeaderPacket22 : HeaderPacket
    {
        public override int Length => 24;

        /// <summary>
        /// Game major version - "X.00"
        /// </summary>
        public byte GameMajorVersion;
        /// <summary>
        /// Game minor version - "1.XX"
        /// </summary>
        public byte GameMinorVersion;
        /// <summary>
        /// Index of secondary player's car in the array (splitscreen).
        /// 255 if no second player
        /// </summary>
        public byte SecondaryPlayerCarIndex;

        public string _GameMajorVersion => GameMajorVersion.ToString("F0") + ".00";

        public string _GameMinorVersion => "1." + GameMinorVersion.ToString("F0");

        public HeaderPacket22(HeaderPacket header, Bytes bys) : base(header, bys) { }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {Name="PacketFormat",TypeName = "uint16"},
            new PacketField {Name="GameMajorVersion",TypeName = "uint8"},
            new PacketField {Name="GameMinorVersion",TypeName = "uint8"},
            new PacketField {Name="PacketVersion",TypeName = "uint8"},
            new PacketField {Name="PacketId",TypeName = "uint8"},
            new PacketField {Name="SessionUID",TypeName = "uint64"},
            new PacketField {Name="SessionTime",TypeName = "float"},
            new PacketField {Name="FrameIdentifier",TypeName = "uint32"},
            new PacketField {Name="PlayerCarIndex",TypeName = "uint8"},
            new PacketField {Name="SecondaryPlayerCarIndex",TypeName = "uint8"}
        };
    }
}
