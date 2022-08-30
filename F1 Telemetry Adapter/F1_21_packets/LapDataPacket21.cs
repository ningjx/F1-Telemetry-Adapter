using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_21_Packets
{
    /// <summary>
    /// The lap data packet gives details of all the cars in the session.
    /// Frequency: Rate as specified in menus
    /// Size: 972 bytes
    /// Version: 1
    /// </summary>
    public class LapDataPacket21 : F1Packet
    {
        public override int Length => 972;

        /// <summary>
        /// Lap data for all cars on track
        /// </summary>
        public LapData21[] LapData;
        /// <summary>
        /// Index of Personal Best car in time trial (255 if invalid)
        /// </summary>
        public byte TimeTrialPBCarIdx;
        /// <summary>
        /// Index of Rival car in time trial (255 if invalid)
        /// </summary>
        public byte TimeTrialRivalCarIdx;

        public LapDataPacket21(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="LapData",
                Type = typeof(LapData21),
                Count=22,
                Children = new PacketField[]
                {
                    new PacketField {Name="LastLapTimeInMS",TypeName = "uint32"},
                    new PacketField {Name="CurrentLapTimeInMS",TypeName = "uint32"},
                    new PacketField {Name="Sector1TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="Sector2TimeInMS",TypeName = "uint16"},
                    new PacketField {Name="LapDistance",TypeName = "float"},
                    new PacketField {Name="TotalDistance",TypeName = "float"},
                    new PacketField {Name="SafetyCarDelta",TypeName = "float"},
                    new PacketField {Name="CarPosition",TypeName = "uint8"},
                    new PacketField {Name="CurrentLapNum",TypeName = "uint8"},
                    new PacketField {Name="PitStatus",TypeName = "uint8"},
                    new PacketField {Name="NumPitStops",TypeName = "uint8"},
                    new PacketField {Name="Sector",TypeName = "uint8"},
                    new PacketField {Name="CurrentLapInvalid",TypeName = "uint8"},
                    new PacketField {Name="Penalties",TypeName = "uint8"},
                    new PacketField {Name="Warnings",TypeName = "uint8"},
                    new PacketField {Name="NumUnservedDriveThroughPens",TypeName = "uint8"},
                    new PacketField {Name="NumUnservedStopGoPens",TypeName = "uint8"},
                    new PacketField {Name="GridPosition",TypeName = "uint8"},
                    new PacketField {Name="DriverStatus",TypeName = "uint8"},
                    new PacketField {Name="ResultStatus",TypeName = "uint8"},
                    new PacketField {Name="PitLaneTimerActive",TypeName = "uint8"},
                    new PacketField {Name="PitLaneTimeInLaneInMS",TypeName = "uint16"},
                    new PacketField {Name="PitStopTimerInMS",TypeName = "uint16"},
                    new PacketField {Name="PitStopShouldServePen",TypeName = "uint8"}
                }
            },
            new PacketField {Name="TimeTrialPBCarIdx",TypeName = "uint8"},
            new PacketField {Name="TimeTrialRivalCarIdx",TypeName = "uint8"}
        };
    }

    public class LapData21
    {
        /// <summary>
        /// Last lap time in milliseconds
        /// </summary>
        public uint LastLapTimeInMS;
        /// <summary>
        /// Current time around the lap in milliseconds
        /// </summary>
        public uint CurrentLapTimeInMS;
        /// <summary>
        /// Sector 1 time in milliseconds
        /// </summary>
        public ushort Sector1TimeInMS;
        /// <summary>
        /// Sector 2 time in milliseconds
        /// </summary>
        public ushort Sector2TimeInMS;
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
        /// Number of pit stops taken in this race
        /// </summary>
        public byte NumPitStops;
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
        /// Accumulated number of warnings issued
        /// </summary>
        public byte Warnings;
        /// <summary>
        /// Num drive through pens left to serve
        /// </summary>
        public byte NumUnservedDriveThroughPens;
        /// <summary>
        /// Num stop go pens left to serve
        /// </summary>
        public byte NumUnservedStopGoPens;
        /// <summary>
        /// Grid position the vehicle started the race in
        /// </summary>
        public byte GridPosition;        /// <summary>
                                         /// Status of driver - 0 = in garage, 1 = flying lap, 2 = in lap, 3 = out lap, 4 = on track
                                         /// </summary>
        public byte DriverStatus;
        /// <summary>
        /// Result status - 0 = invalid, 1 = inactive, 2 = active
        /// 3 = finished, 4 = didnotfinish, 5 = disqualified
        /// 6 = not classified, 7 = retired
        /// </summary>
        public byte ResultStatus;
        /// <summary>
        /// Pit lane timing, 0 = inactive, 1 = active
        /// </summary>
        public byte PitLaneTimerActive;
        /// <summary>
        /// If active, the current time spent in the pit lane in ms
        /// </summary>
        public ushort PitLaneTimeInLaneInMS;
        /// <summary>
        /// Time of the actual pit stop in ms
        /// </summary>
        public ushort PitStopTimerInMS;
        /// <summary>
        /// Whether the car should serve a penalty at this stop
        /// </summary>
        public byte PitStopShouldServePen;
    }
}
