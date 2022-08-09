using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// The lap data packet gives details of all the cars in the session.
    /// Frequency: Rate as specified in menus
    /// Size: 972 bytes
    /// Version: 1
    /// </summary>
    public class LapDataPacket : F1Packet
    {
        public override int PacketSize => 972;

        /// <summary>
        /// Lap data for all cars on track
        /// </summary>
        public LapData[] LapData;
        /// <summary>
        /// Index of Personal Best car in time trial (255 if invalid)
        /// </summary>
        public byte TimeTrialPBCarIdx;
        /// <summary>
        /// Index of Rival car in time trial (255 if invalid)
        /// </summary>
        public byte TimeTrialRivalCarIdx;

        public LapDataPacket(HeaderPacket header) : base(header) { }

        public LapDataPacket() { }

        public override ItemList PacketItems => new ItemList
        {
            new PacketItem {
                Name="LapData",
                Type = typeof(LapData),
                Count=22,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="LapData",Name="LastLapTimeInMS",Type = typeof(uint)},
                    new PacketItem {ClassName="LapData",Name="CurrentLapTimeInMS",Type = typeof(uint)},
                    new PacketItem {ClassName="LapData",Name="Sector1TimeInMS",Type = typeof(ushort)},
                    new PacketItem {ClassName="LapData",Name="Sector2TimeInMS",Type = typeof(ushort)},
                    new PacketItem {ClassName="LapData",Name="LapDistance",Type = typeof(float)},
                    new PacketItem {ClassName="LapData",Name="TotalDistance",Type = typeof(float)},
                    new PacketItem {ClassName="LapData",Name="SafetyCarDelta",Type = typeof(float)},
                    new PacketItem {ClassName="LapData",Name="CarPosition",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="CurrentLapNum",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="PitStatus",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="NumPitStops",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="Sector",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="CurrentLapInvalid",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="Penalties",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="Warnings",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="NumUnservedDriveThroughPens",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="NumUnservedStopGoPens",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="GridPosition",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="DriverStatus",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="ResultStatus",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="PitLaneTimerActive",Type = typeof(byte)},
                    new PacketItem {ClassName="LapData",Name="PitLaneTimeInLaneInMS",Type = typeof(ushort)},
                    new PacketItem {ClassName="LapData",Name="PitStopTimerInMS",Type = typeof(ushort)},
                    new PacketItem {ClassName="LapData",Name="PitStopShouldServePen",Type = typeof(byte)}
                }
            },
            new PacketItem {Name="TimeTrialPBCarIdx",Type = typeof(byte)},
            new PacketItem {Name="TimeTrialRivalCarIdx",Type = typeof(byte)}
        };
    }

    public class LapData
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
