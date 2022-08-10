using F1_Telemetry_Adapter.Enums;
using F1_Telemetry_Adapter.F1_18_packets;
using F1_Telemetry_Adapter.Models;
using System;

namespace F1_Telemetry_Adapter.F1_21_packets
{
    public class HeaderPacket21 : HeaderPacket18
    {
        public byte GameMajorVersion;         //Game major version - "X.00"
        public byte GameMinorVersion;         // Game minor version - "1.XX"
        public byte SecondaryPlayerCarIndex;  // Index of secondary player's car in the array (splitscreen).255 if no second player
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
            new PacketItem {Name="FrameIdentifier",TypeName = "uint32"},
            new PacketItem {Name="PlayerCarIndex",TypeName = "uint8"},
            new PacketItem {Name="SecondaryPlayerCarIndex",TypeName = "uint8"}
        };
    }
}
