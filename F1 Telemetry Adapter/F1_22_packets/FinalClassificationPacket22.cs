using F1_Telemetry_Adapter.F1_Base_packets;
using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// This packet details the final classification at the end of the race, and the data will match with the post race results screen. This is especially useful for multiplayer games where it is not always possible to send lap times on the final frame because of network delay.
    /// Frequency: Once at the end of a race
    /// Size: 1015 bytes
    /// Version: 1
    /// </summary>
    public class FinalClassificationPacket22 : F1Packet
    {
        public override int PacketSize => 1015;

        /// <summary>
        /// Number of cars in the final classification
        /// </summary>
        public byte NumCars;

        public FinalClassificationData[] FinalClassificationData;

        public FinalClassificationPacket22(HeaderPacket header) : base(header) { }

        public FinalClassificationPacket22() { }

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name="NumCars",TypeName = "uint8"},
            new PacketItem {
                Name="FinalClassificationData",
                Type = typeof(FinalClassificationData),
                Count=22,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="FinalClassificationData",Name="Position",TypeName = "uint8"},
                    new PacketItem {ClassName="FinalClassificationData",Name="NumLaps",TypeName = "uint8"},
                    new PacketItem {ClassName="FinalClassificationData",Name="GridPosition",TypeName = "uint8"},
                    new PacketItem {ClassName="FinalClassificationData",Name="Points",TypeName = "uint8"},
                    new PacketItem {ClassName="FinalClassificationData",Name="NumPitStops",TypeName = "uint8"},
                    new PacketItem {ClassName="FinalClassificationData",Name="ResultStatus",TypeName = "uint8"},
                    new PacketItem {ClassName="FinalClassificationData",Name="BestLapTimeInMS",TypeName = "uint32"},
                    new PacketItem {ClassName="FinalClassificationData",Name="TotalRaceTime",TypeName = "double"},
                    new PacketItem {ClassName="FinalClassificationData",Name="PenaltiesTime",TypeName = "uint8"},
                    new PacketItem {ClassName="FinalClassificationData",Name="NumPenalties",TypeName = "uint8"},
                    new PacketItem {ClassName="FinalClassificationData",Name="NumTyreStints",TypeName = "uint8"},
                    new PacketItem {ClassName="FinalClassificationData",Name="TyreStintsActual",TypeName = "uint8",Count = 8  },
                    new PacketItem {ClassName="FinalClassificationData",Name="TyreStintsVisual",TypeName = "uint8",Count = 8  },
                    new PacketItem {ClassName="FinalClassificationData",Name="TyreStintsEndLaps",TypeName = "uint8",Count = 8  }
                }
            }
        };
    }

    public class FinalClassificationData
    {
        /// <summary>
        /// Finishing position
        /// </summary>
        public byte Position;
        /// <summary>
        /// Number of laps completed
        /// </summary>
        public byte NumLaps;
        /// <summary>
        /// Grid position of the car
        /// </summary>
        public byte GridPosition;
        /// <summary>
        /// Number of points scored
        /// </summary>
        public byte Points;
        /// <summary>
        /// Number of pit stops made
        /// </summary>
        public byte NumPitStops;
        /// <summary>
        /// Result status - 0 = invalid, 1 = inactive, 2 = active,
        /// 3 = finished, 4 = didnotfinish, 5 = disqualified,
        /// 6 = not classified, 7 = retired
        /// </summary>
        public byte ResultStatus;
        /// <summary>
        /// Best lap time of the session in milliseconds
        /// </summary>
        public uint BestLapTimeInMS;
        /// <summary>
        /// Total race time in seconds without penalties
        /// </summary>
        public double TotalRaceTime;
        /// <summary>
        /// Total penalties accumulated in seconds
        /// </summary>
        public byte PenaltiesTime;
        /// <summary>
        /// Number of penalties applied to this driver
        /// </summary>
        public byte NumPenalties;
        /// <summary>
        /// Number of tyres stints up to maximum
        /// </summary>
        public byte NumTyreStints;
        /// <summary>
        /// Actual tyres used by this driver
        /// </summary>
        public byte[] TyreStintsActual;
        /// <summary>
        /// Visual tyres used by this driver
        /// </summary>
        public byte[] TyreStintsVisual;
        /// <summary>
        /// The lap number stints end on
        /// </summary>
        public byte[] TyreStintsEndLaps;
    }
}
