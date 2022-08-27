using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;
using System;

namespace NingSoft.F1TelemetryAdapter.F1_18_packets
{
    public class HeaderPacket18 : HeaderPacket
    {
        public override int PacketSize => 21;

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name="PacketFormat",TypeName = "uint16"},
            new PacketItem {Name="PacketVersion",TypeName = "uint8"},
            new PacketItem {Name="PacketId",TypeName = "uint8"},
            new PacketItem {Name="SessionUID",TypeName = "uint64"},
            new PacketItem {Name="SessionTime",TypeName = "float"},
            new PacketItem {Name="FrameIdentifier",TypeName = "uint"},
            new PacketItem {Name="PlayerCarIndex",TypeName = "uint8"}
        };
    }
}
