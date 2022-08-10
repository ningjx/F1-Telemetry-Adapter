using F1_Telemetry_Adapter.Enums;
using F1_Telemetry_Adapter.Models;
using System;

namespace F1_Telemetry_Adapter.F1_Base_packets
{
    public class HeaderPacket : F1Packet
    {
        public override int PacketSize => 24;

        public ushort PacketFormat;          // 2018/2019/2020/2021/2022
        public byte PacketVersion;           // Version of this packet type, all start from 1
        public byte PacketId;                // Identifier for the packet type, see below
        public ulong SessionUID;             // Unique identifier for the session
        public float SessionTime;            // Session timestamp
        public uint FrameIdentifier;         // Identifier for the frame the data was retrieved on
        public byte PlayerCarIndex;          // Index of player's car in the array
        public GameSeries _GameSeries => (GameSeries)PacketFormat;
        public PacketType _PacketType => (PacketType)PacketId;
        public TimeSpan _SessionTime => TimeSpan.FromSeconds(SessionTime);

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name="PacketFormat",TypeName = "uint16"},
            new PacketItem {Name="PacketVersion",TypeName = "uint8"},
            new PacketItem {Name="PacketId",TypeName = "uint8"},
            new PacketItem {Name="SessionUID",TypeName = "uint64"},
            new PacketItem {Name="SessionTime",TypeName = "float"},
            new PacketItem {Name="FrameIdentifier",TypeName = "uint32"},
            new PacketItem {Name="PlayerCarIndex",TypeName = "uint8"}
        };
    }
}
