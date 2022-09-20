using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_21_packets
{
    /// <summary>
    /// This packet details the final classification at the end of the race, and the data will match with the post race results screen. This is especially useful for multiplayer games where it is not always possible to send lap times on the final frame because of network delay.
    /// Frequency: Once at the end of a race
    /// Size: 839 bytes
    /// Version: 1
    /// </summary>
    public class FinalClassificationPacket21 : F1Packet
    {
        public override int Length => 839;

        /// <summary>
        /// Number of cars in the final classification
        /// </summary>
        public byte NumCars;

        public FinalClassificationData21[] FinalClassificationData;

        public FinalClassificationPacket21(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {Name="NumCars",TypeName = "uint8"},
            new PacketField {
                Name="FinalClassificationData",
                Type = typeof(FinalClassificationData21),
                Count=22,
                Children = new PacketField[]
                {
                    new PacketField {Name="Position",TypeName = "uint8"},
                    new PacketField {Name="NumLaps",TypeName = "uint8"},
                    new PacketField {Name="GridPosition",TypeName = "uint8"},
                    new PacketField {Name="Points",TypeName = "uint8"},
                    new PacketField {Name="NumPitStops",TypeName = "uint8"},
                    new PacketField {Name="ResultStatus",TypeName = "uint8"},
                    new PacketField {Name="BestLapTimeInMS",TypeName = "uint32"},
                    new PacketField {Name="TotalRaceTime",TypeName = "double"},
                    new PacketField {Name="PenaltiesTime",TypeName = "uint8"},
                    new PacketField {Name="NumPenalties",TypeName = "uint8"},
                    new PacketField {Name="NumTyreStints",TypeName = "uint8"},
                    new PacketField {Name="TyreStintsActual",TypeName = "uint8",Count = 8  },
                    new PacketField {Name="TyreStintsVisual",TypeName = "uint8",Count = 8  }
                }
            }
        };
    }

    public class FinalClassificationData21
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
    }
}
