using NingSoft.F1TelemetryAdapter.F1_18_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_19_packets
{
    public class HeaderPacket19 : HeaderPacket18
    {
        public override int PacketSize => 23;

        /// <summary>
        /// Game major version - "X.00"
        /// </summary>
        public byte GameMajorVersion;
        /// <summary>
        /// Game minor version - "1.XX"
        /// </summary>
        public byte GameMinorVersion;

        public string _GameMajorVersion => GameMajorVersion.ToString("F0") + ".00";
        public string _GameMinorVersion => "1." + GameMinorVersion.ToString("F0");

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name="PacketFormat",TypeName = "uint16"},
            new PacketItem {Name="GameMajorVersion",TypeName = "uint8"},
            new PacketItem {Name="GameMinorVersion",TypeName = "uint8"},
            new PacketItem {Name="PacketVersion",TypeName = "uint8"},
            new PacketItem {Name="PacketId",TypeName = "uint8"},
            new PacketItem {Name="SessionUID",TypeName = "uint64"},
            new PacketItem {Name="SessionTime",TypeName = "float"},
            new PacketItem {Name="FrameIdentifier",TypeName = "uint"},
            new PacketItem {Name="PlayerCarIndex",TypeName = "uint8"}
        };
    }
}
