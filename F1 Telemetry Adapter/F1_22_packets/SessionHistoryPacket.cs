using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// This packet contains lap times and tyre usage for the session. This packet works slightly differently to other packets. To reduce CPU and bandwidth, each packet relates to a specific vehicle and is sent every 1/20 s, and the vehicle being sent is cycled through. Therefore in a 20 car race you should receive an update for each vehicle at least once per second.
    /// Note that at the end of the race, after the final classification packet has been sent, a final bulk update of all the session histories for the vehicles in that session will be sent.
    /// Frequency: 20 per second but cycling through cars
    /// Size: 1155 bytes
    /// Version: 1
    /// </summary>
    public class SessionHistoryPacket : F1Packet
    {
        public override int PacketSize => 1155;

        /// <summary>
        /// Index of the car this lap data relates to
        /// </summary>
        public byte CarIdx;
        /// <summary>
        /// Num laps in the data (including current partial lap)
        /// </summary>
        public byte NumLaps;
        /// <summary>
        /// Number of tyre stints in the data
        /// </summary>
        public byte NumTyreStints;
        /// <summary>
        /// Lap the best lap time was achieved on
        /// </summary>
        public byte BestLapTimeLapNum;
        /// <summary>
        /// Lap the best Sector 1 time was achieved on
        /// </summary>
        public byte BestSector1LapNum;
        /// <summary>
        /// Lap the best Sector 2 time was achieved on
        /// </summary>
        public byte BestSector2LapNum;
        /// <summary>
        /// Lap the best Sector 3 time was achieved on
        /// </summary>
        public byte BestSector3LapNum;
        /// <summary>
        /// 100 laps of data max
        /// </summary>
        public LapHistoryData[] LapHistoryDatas;

        public TyreStintHistoryData[] TyreStintHistoryDatas;

        public SessionHistoryPacket(HeaderPacket header) : base(header) { }

        public SessionHistoryPacket() { }

        public override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name="CarIdx",Type = typeof(byte)},
            new PacketItem {Name="NumLaps",Type = typeof(byte)},
            new PacketItem {Name="NumTyreStints",Type = typeof(byte)},
            new PacketItem {Name="BestLapTimeLapNum",Type = typeof(byte)},
            new PacketItem {Name="BestSector1LapNum",Type = typeof(byte)},
            new PacketItem {Name="BestSector2LapNum",Type = typeof(byte)},
            new PacketItem {Name="BestSector3LapNum",Type = typeof(byte)},
            new PacketItem
            {
                Name="LapHistoryDatas",
                Type = typeof(LapHistoryData),
                Count=100,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="LapHistoryData",Name="LapTimeInMS",Type = typeof(uint)},
                    new PacketItem {ClassName="LapHistoryData",Name="Sector1TimeInMS",Type = typeof(ushort)},
                    new PacketItem {ClassName="LapHistoryData",Name="Sector2TimeInMS",Type = typeof(ushort)},
                    new PacketItem {ClassName="LapHistoryData",Name="Sector3TimeInMS",Type = typeof(ushort)},
                    new PacketItem {ClassName="LapHistoryData",Name="LapValidBitFlags",Type = typeof(byte)}
                }
            },
            new PacketItem
            {
                Name="TyreStintHistoryDatas",
                Type = typeof(TyreStintHistoryData),
                Count=8,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="TyreStintHistoryData",Name="EndLap",Type = typeof(byte)},
                    new PacketItem {ClassName="TyreStintHistoryData",Name="TyreActualCompound",Type = typeof(byte)},
                    new PacketItem {ClassName="TyreStintHistoryData",Name="TyreVisualCompound",Type = typeof(byte)}
                }
            }
        };
    }

    public class LapHistoryData
    {
        /// <summary>
        /// Lap time in milliseconds
        /// </summary>
        public uint LapTimeInMS;
        /// <summary>
        /// Sector 1 time in milliseconds
        /// </summary>
        public ushort Sector1TimeInMS;
        /// <summary>
        /// Sector 2 time in milliseconds
        /// </summary>
        public ushort Sector2TimeInMS;
        /// <summary>
        /// Sector 3 time in milliseconds
        /// </summary>
        public ushort Sector3TimeInMS;
        /// <summary>
        /// 0x01 bit set-lap valid, 0x02 bit set-sector 1 valid, 0x04 bit set-sector 2 valid, 0x08 bit set-sector 3 valid
        /// </summary>
        public byte LapValidBitFlags;
    }

    public class TyreStintHistoryData
    {
        /// <summary>
        /// Lap the tyre usage ends on (255 of current tyre)
        /// </summary>
        public byte EndLap;
        /// <summary>
        /// Actual tyres used by this driver
        /// </summary>
        public byte TyreActualCompound;
        /// <summary>
        /// Visual tyres used by this driver
        /// </summary>
        public byte TyreVisualCompound;
    }
}
