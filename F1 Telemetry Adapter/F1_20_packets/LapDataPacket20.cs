using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_20_packets
{
    /// <summary>
    /// The lap data packet gives details of all the cars in the session.
    /// Frequency: Rate as specified in menus
    /// Size: 1190 bytes
    /// Version: 1
    /// </summary>
    public class LapDataPacket20 : F1Packet
    {
        public override int Length => 1190;

        /// <summary>
        /// Lap data for all cars on track
        /// </summary>
        public LapData20[] LapData;

        public LapDataPacket20(HeaderPacket header, Bytes bys) : base(header, bys) { }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="LapData",
                Type = typeof(LapData20),
                Count = 22,
                Children = new PacketField[]
                {
                    new PacketField {Name="LastLapTime",TypeName = "float"},
                    new PacketField {Name="CurrentLapTime",TypeName = "float"},
                    new PacketField {Name="Sector1TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="Sector2TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="BestLapTime",TypeName = "float"},
                    new PacketField {Name="BestLapNum",TypeName = "uint8"},
                    new PacketField {Name="BestLapSector1TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="BestLapSector2TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="BestLapSector3TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="BestOverallSector1TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="BestOverallSector1LapNum",TypeName = "uint8"},
                    new PacketField {Name="BestOverallSector2TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="BestOverallSector2LapNum",TypeName = "uint8"},
                    new PacketField {Name="BestOverallSector3TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="BestOverallSector3LapNum",TypeName = "uint8"},
                    new PacketField {Name="LapDistance",TypeName = "float"},
                    new PacketField {Name="TotalDistance",TypeName = "float"},
                    new PacketField {Name="SafetyCarDelta",TypeName = "float"},
                    new PacketField {Name="CarPosition",TypeName = "uint8"},
                    new PacketField {Name="CurrentLapNum",TypeName = "uint8"},
                    new PacketField {Name="PitStatus",TypeName = "uint8"},
                    new PacketField {Name="Sector",TypeName = "uint8"},
                    new PacketField {Name="CurrentLapInvalid",TypeName = "uint8"},
                    new PacketField {Name="Penalties",TypeName = "uint8"},
                    new PacketField {Name="GridPosition",TypeName = "uint8"},
                    new PacketField {Name="DriverStatus",TypeName = "uint8"},
                    new PacketField {Name="ResultStatus",TypeName = "uint8"}
                }
            }
        };
    }

    public class LapData20
    {
        /// <summary>
        /// Last lap time in seconds
        /// </summary>
        public float LastLapTime;
        /// <summary>
        /// Current time around the lap in seconds
        /// </summary>
        public float CurrentLapTime;
        /// <summary>
        /// Sector 1 time in milliseconds
        /// </summary>
        public ushort Sector1TimeInMS;
        /// <summary>
        /// Sector 2 time in milliseconds
        /// </summary>
        public ushort Sector2TimeInMS;
        /// <summary>
        /// Best lap time of the session in seconds
        /// </summary>
        public float BestLapTime;
        public byte BestLapNum;
        public ushort BestLapSector1TimeInMS;
        public ushort BestLapSector2TimeInMS;
        public ushort BestLapSector3TimeInMS;
        public ushort BestOverallSector1TimeInMS;
        public byte BestOverallSector1LapNum;
        public ushort BestOverallSector2TimeInMS;
        public byte BestOverallSector2LapNum;
        public ushort BestOverallSector3TimeInMS;
        public byte BestOverallSector3LapNum;
        /// <summary>
        /// Distance vehicle is around current lap in metres – could be negative if line hasn’t been crossed yet
        /// </summary>
        public float LapDistance;
        /// <summary>
        /// Total distance travelled in session in metres – could be negative if line hasn’t been crossed yet
        /// </summary>
        public float TotalDistance;
        /// <summary>
        /// Delta in seconds for safety car
        /// </summary>
        public float SafetyCarDelta;
        /// <summary>
        /// Car race position
        /// </summary>
        public byte CarPosition;
        /// <summary>
        /// Current lap number
        /// </summary>
        public byte CurrentLapNum;
        /// <summary>
        /// 0 = none, 1 = pitting, 2 = in pit area
        /// </summary>
        public byte PitStatus;
        /// <summary>
        /// 0 = sector1, 1 = sector2, 2 = sector3
        /// </summary>
        public byte Sector;
        /// <summary>
        /// Current lap invalid - 0 = valid, 1 = invalid
        /// </summary>
        public byte CurrentLapInvalid;
        /// <summary>
        /// Accumulated time penalties in seconds to be added
        /// </summary>
        public byte Penalties;
        /// <summary>
        /// Grid position the vehicle started the race in
        /// </summary>
        public byte GridPosition;
        /// <summary>                            
        /// Status of driver - 0 = in garage, 1 = flying lap, 2 = in lap, 3 = out lap, 4 = on trac                              
        /// </summary>
        public byte DriverStatus;
        /// <summary>
        /// Result status - 0 = invalid, 1 = inactive, 2 = active
        /// 3 = finished, 4 = didnotfinish, 5 = disqualified
        /// 6 = not classified, 7 = retired
        /// </summary>
        public byte ResultStatus;
    }
}
