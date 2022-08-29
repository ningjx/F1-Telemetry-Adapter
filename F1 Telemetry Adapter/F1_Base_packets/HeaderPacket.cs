using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.Models;
using System;

namespace NingSoft.F1TelemetryAdapter.F1_Base_packets
{
    public class HeaderPacket : F1Packet
    {
        public override int PacketSize => 21;

        /// <summary>
        /// 2018/2019/2020/2021/2022
        /// </summary>
        public ushort PacketFormat;
        /// <summary>
        /// Identifier for the packet type, see below
        /// </summary>
        public byte PacketId;
        /// <summary>
        /// Version of this packet type, all start from 1
        /// </summary>
        public byte PacketVersion;
        /// <summary>
        /// Unique identifier for the session
        /// </summary>
        public ulong SessionUID;
        /// <summary>
        /// Session timestamp
        /// </summary>
        public float SessionTime;
        /// <summary>
        /// Identifier for the frame the data was retrieved on
        /// </summary>
        public uint FrameIdentifier;
        /// <summary>
        /// Index of player's car in the array
        /// </summary>
        public byte PlayerCarIndex;

        public HeaderPacket(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        public PacketType _PacketType => (PacketType)PacketId;
        public GameSeries _GameSeries => (GameSeries)PacketFormat;
        public TimeSpan _SessionTime => TimeSpan.FromSeconds(SessionTime);

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
