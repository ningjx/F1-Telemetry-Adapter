using NingSoft.F1TelemetryAdapter.F1_19_packets;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_20_packets
{
    public class HeaderPacket20 : HeaderPacket19
    {
        public override int PacketSize => 24;

        /// <summary>
        /// Index of secondary player's car in the array (splitscreen).
        /// 255 if no second player
        /// </summary>
        public byte SecondaryPlayerCarIndex;

        public HeaderPacket20(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name="PacketFormat",TypeName = "uint16"},
            new PacketItem {Name="GameMajorVersion",TypeName = "uint8"},
            new PacketItem {Name="GameMinorVersion",TypeName = "uint8"},
            new PacketItem {Name="PacketVersion",TypeName = "uint8"},
            new PacketItem {Name="PacketId",TypeName = "uint8"},
            new PacketItem {Name="SessionUID",TypeName = "uint64"},
            new PacketItem {Name="SessionTime",TypeName = "float"},
            new PacketItem {Name="FrameIdentifier",TypeName = "uint32"},
            new PacketItem {Name="PlayerCarIndex",TypeName = "uint8"},
            new PacketItem {Name="SecondaryPlayerCarIndex",TypeName = "uint8"}
        };
    }
}
