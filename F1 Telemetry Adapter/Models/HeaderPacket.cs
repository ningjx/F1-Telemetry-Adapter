using F1_Telemetry_Adapter.Enums;
using System;

namespace F1_Telemetry_Adapter.Models
{
    public class HeaderPacket : F1Packet
    {
        public override int PacketSize => 24;

        public ushort PacketFormat;          // 2022
        public uint GameMajorVersion;        // Game major version - "X.00"
        public uint GameMinorVersion;        // Game minor version - "1.XX"
        public uint PacketVersion;           // Version of this packet type, all start from 1
        public uint PacketId;                // Identifier for the packet type, see below
        public ulong SessionUID;            // Unique identifier for the session
        public float SessionTime;            // Session timestamp
        public uint FrameIdentifier;       // Identifier for the frame the data was retrieved on
        public uint PlayerCarIndex;          // Index of player's car in the array
        public uint SecondaryPlayerCarIndex; // Index of secondary player's car in the array (splitscreen).255 if no second player

        public PacketType _PacketType => (PacketType)PacketId;

        public string _GameMajorVersion => GameMajorVersion.ToString("F0") + ".00";

        public string _GameMinorVersion => "1." + GameMinorVersion.ToString("F0");

        public TimeSpan _SessionTime => TimeSpan.FromSeconds(SessionTime);

        public override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name="PacketFormat",Type = typeof(ushort)},
            new PacketItem {Name="GameMajorVersion",Type = typeof(byte)},
            new PacketItem {Name="GameMinorVersion",Type = typeof(byte)},
            new PacketItem {Name="PacketVersion",Type = typeof(byte)},
            new PacketItem {Name="PacketId",Type = typeof(byte)},
            new PacketItem {Name="SessionUID",Type = typeof(ulong)},
            new PacketItem {Name="SessionTime",Type = typeof(float)},
            new PacketItem {Name="FrameIdentifier",Type = typeof(uint)},
            new PacketItem {Name="PlayerCarIndex",Type = typeof(byte)},
            new PacketItem {Name="SecondaryPlayerCarIndex",Type = typeof(byte)}
        };
    }
}
