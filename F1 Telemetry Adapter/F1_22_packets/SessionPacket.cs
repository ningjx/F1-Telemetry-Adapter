using F1_Telemetry_Adapter.Enums;
using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// The session packet includes details about the current session in progress.
    /// Frequency: 2 per second
    /// Size: 632 bytes
    /// Version: 1
    /// </summary>
    public class SessionPacket : F1Packet
    {
        public override int PacketSize => 632;

        /// <summary>
        /// Weather - 0 = clear, 1 = light cloud, 2 = overcast,
        /// 3 = light rain, 4 = heavy rain, 5 = storm
        /// </summary>
        public byte Weather;
        /// <summary>
        /// Track temp. in degrees celsius
        /// </summary>
        public sbyte TrackTemperature;
        /// <summary>
        /// Air temp. in degrees celsius
        /// </summary>
        public sbyte AirTemperature;
        /// <summary>
        /// Total number of laps in this race
        /// </summary>
        public byte TotalLaps;
        /// <summary>
        /// Track length in metres
        /// </summary>
        public ushort TrackLength;
        /// <summary>
        /// 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P,
        /// 5 = Q1, 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ,
        /// 10 = R, 11 = R2, 12 = R3, 13 = Time Trial
        /// </summary>
        public byte SessionType;
        /// <summary>
        /// -1 for unknown, see appendix
        /// </summary>
        public sbyte TrackId;
        /// <summary>
        ///  Formula, 0 = F1 Modern, 1 = F1 Classic, 2 = F2,
        ///  3 = F1 Generic, 4 = Beta, 5 = Supercars
        ///  6 = Esports, 7 = F2 2021
        /// </summary>
        public byte Formula;
        /// <summary>
        /// Time left in session in seconds
        /// </summary>
        public ushort SessionTimeLeft;
        /// <summary>
        /// Session duration in seconds
        /// </summary>
        public ushort SessionDuration;
        /// <summary>
        /// Pit speed limit in kilometres per hour
        /// </summary>
        public byte PitSpeedLimit;
        /// <summary>
        /// Whether the game is paused – network game only
        /// </summary>
        public byte GamePaused;
        /// <summary>
        /// Whether the player is spectating 
        /// </summary>
        public byte IsSpectating;
        /// <summary>
        /// Index of the car being spectated
        /// </summary>
        public byte SpectatorCarIndex;
        /// <summary>
        /// SLI Pro support, 0 = inactive, 1 = active
        /// </summary>
        public byte SliProNativeSupport;
        /// <summary>
        /// Number of marshal zones to follow
        /// </summary>
        public byte NumMarshalZones;
        /// <summary>
        /// List of marshal zones – max 21
        /// </summary>
        public MarshalZone[] MarshalZones;
        /// <summary>
        /// 0 = no safety car, 1 = full, 2 = virtual, 3 = formation lap
        /// </summary>
        public byte SafetyCarStatus;
        /// <summary>
        /// 0 = offline, 1 = online
        /// </summary>
        public byte NetworkGame;
        /// <summary>
        /// Number of weather samples to follow
        /// </summary>
        public byte NumWeatherForecastSamples;
        /// <summary>
        /// Array of weather forecast samples
        /// </summary>
        public WeatherForecastSample[] WeatherForecastSamples;
        /// <summary>
        /// 0 = Perfect, 1 = Approximate
        /// </summary>
        public byte ForecastAccuracy;
        /// <summary>
        /// AI Difficulty rating – 0-110
        /// </summary>
        public byte AiDifficulty;
        /// <summary>
        /// Identifier for season - persists across saves
        /// </summary>
        public uint SeasonLinkIdentifier;
        /// <summary>
        /// Identifier for weekend - persists across saves
        /// </summary>
        public uint WeekendLinkIdentifier;
        /// <summary>
        /// Identifier for session - persists across saves
        /// </summary>
        public uint SessionLinkIdentifier;
        /// <summary>
        /// Ideal lap to pit on for current strategy (player)
        /// </summary>
        public byte PitStopWindowIdealLap;
        /// <summary>
        /// Latest lap to pit on for current strategy (player)
        /// </summary>
        public byte PitStopWindowLatestLap;
        /// <summary>
        /// Predicted position to rejoin at (player)
        /// </summary>
        public byte PitStopRejoinPosition;
        /// <summary>
        /// 0 = off, 1 = on
        /// </summary>
        public byte SteeringAssist;
        /// <summary>
        /// 0 = off, 1 = low, 2 = medium, 3 = high
        /// </summary>
        public byte BrakingAssist;
        /// <summary>
        /// 1 = manual, 2 = manual & suggested gear, 3 = auto
        /// </summary>
        public byte GearboxAssist;
        /// <summary>
        /// 0 = off, 1 = on
        /// </summary>
        public byte PitAssist;
        /// <summary>
        /// 0 = off, 1 = on
        /// </summary>
        public byte PitReleaseAssist;
        /// <summary>
        /// 0 = off, 1 = on
        /// </summary>
        public byte ERSAssist;
        /// <summary>
        /// 0 = off, 1 = on
        /// </summary>
        public byte DRSAssist;
        /// <summary>
        /// 0 = off, 1 = corners only, 2 = full
        /// </summary>
        public byte DynamicRacingLine;
        /// <summary>
        /// 0 = 2D, 1 = 3D
        /// </summary>
        public byte DynamicRacingLineType;
        /// <summary>
        /// Game mode id - see appendix
        /// </summary>
        public byte GameMode;
        /// <summary>
        /// Ruleset - see appendix
        /// </summary>
        public byte RuleSet;
        /// <summary>
        /// Local time of day - minutes since midnight
        /// </summary>
        public uint TimeOfDay;
        /// <summary>
        /// 0 = None, 2 = Very Short, 3 = Short, 4 = Medium, 5 = Medium Long, 6 = Long, 7 = Full
        /// </summary>
        public byte SessionLength;

        public SessionType _SessionType => (SessionType)SessionType;

        public SessionPacket(HeaderPacket header) : base(header) { }

        public SessionPacket() { }

        public override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name="Weather",Type = typeof(byte)},
            new PacketItem {Name="TrackTemperature",Type = typeof(sbyte)},
            new PacketItem {Name="AirTemperature",Type = typeof(sbyte)},
            new PacketItem {Name="TotalLaps",Type = typeof(byte)},
            new PacketItem {Name="TrackLength",Type = typeof(ushort)},
            new PacketItem {Name="SessionType",Type = typeof(byte)},
            new PacketItem {Name="TrackId",Type = typeof(sbyte)},
            new PacketItem {Name="Formula",Type = typeof(byte)},
            new PacketItem {Name="SessionTimeLeft",Type = typeof(ushort)},
            new PacketItem {Name="SessionDuration",Type = typeof(ushort)},
            new PacketItem {Name="PitSpeedLimit",Type = typeof(byte)},
            new PacketItem {Name="GamePaused",Type = typeof(byte)},
            new PacketItem {Name="IsSpectating",Type = typeof(byte)},
            new PacketItem {Name="SpectatorCarIndex",Type = typeof(byte)},
            new PacketItem {Name="SliProNativeSupport",Type = typeof(byte)},
            new PacketItem {Name="NumMarshalZones",Type = typeof(byte)},
            new PacketItem {
                Name="MarshalZones",
                Type = typeof(MarshalZone),
                Count=21,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="MarshalZone", Name="ZoneStart",Type = typeof(float)},
                    new PacketItem {ClassName="MarshalZone",Name="ZoneFlag",Type = typeof(sbyte)}
                }
            },
            new PacketItem {Name="SafetyCarStatus",Type = typeof(byte)},
            new PacketItem {Name="NetworkGame",Type = typeof(byte)},
            new PacketItem {Name="NumWeatherForecastSamples",Type = typeof(byte)},
            new PacketItem {
                Name="WeatherForecastSamples",
                Type = typeof(WeatherForecastSample),
                Count= 56,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="WeatherForecastSample", Name="SessionType",Type = typeof(byte)},
                    new PacketItem {ClassName="WeatherForecastSample",Name="TimeOffset",Type = typeof(byte)},
                    new PacketItem {ClassName="WeatherForecastSample",Name="Weather",Type = typeof(byte)},
                    new PacketItem {ClassName="WeatherForecastSample",Name="TrackTemperature",Type = typeof(sbyte)},
                    new PacketItem {ClassName="WeatherForecastSample",Name="TrackTemperatureChange",Type = typeof(sbyte)},
                    new PacketItem {ClassName="WeatherForecastSample",Name="AirTemperature",Type = typeof(sbyte)},
                    new PacketItem {ClassName="WeatherForecastSample",Name="AirTemperatureChange",Type = typeof(sbyte)},
                    new PacketItem {ClassName="WeatherForecastSample",Name="RainPercentage",Type = typeof(byte)}
                }
            },
            new PacketItem {Name="ForecastAccuracy",Type = typeof(byte)},
            new PacketItem {Name="AiDifficulty",Type = typeof(byte)},
            new PacketItem {Name="SeasonLinkIdentifier",Type = typeof(uint)},
            new PacketItem {Name="WeekendLinkIdentifier",Type = typeof(uint)},
            new PacketItem {Name="SessionLinkIdentifier",Type = typeof(uint)},
            new PacketItem {Name="PitStopWindowIdealLap",Type = typeof(byte)},
            new PacketItem {Name="PitStopWindowLatestLap",Type = typeof(byte)},
            new PacketItem {Name="PitStopRejoinPosition",Type = typeof(byte)},
            new PacketItem {Name="SteeringAssist",Type = typeof(byte)},
            new PacketItem {Name="BrakingAssist",Type = typeof(byte)},
            new PacketItem {Name="GearboxAssist",Type = typeof(byte)},
            new PacketItem {Name="PitAssist",Type = typeof(byte)},
            new PacketItem {Name="PitReleaseAssist",Type = typeof(byte)},
            new PacketItem {Name="ERSAssist",Type = typeof(byte)},
            new PacketItem {Name="DRSAssist",Type = typeof(byte)},
            new PacketItem {Name="DynamicRacingLine",Type = typeof(byte)},
            new PacketItem {Name="DynamicRacingLineType",Type = typeof(byte)},
            new PacketItem {Name="GameMode",Type = typeof(byte)},
            new PacketItem {Name="RuleSet",Type = typeof(byte)},
            new PacketItem {Name="TimeOfDay",Type = typeof(uint)},
            new PacketItem {Name="SessionLength",Type = typeof(byte)}
            };
    }

    public class MarshalZone
    {
        /// <summary>
        /// Fraction (0..1) of way through the lap the marshal zone starts
        /// </summary>
        public float ZoneStart;
        /// <summary>
        /// -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
        /// </summary>
        public sbyte ZoneFlag;
    }

    public class WeatherForecastSample
    {
        /// <summary>
        /// 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 5 = Q1,
        /// 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ, 10 = R, 11 = R2,
        /// 12 = R3, 13 = Time Trial
        /// </summary>
        public byte SessionType;
        /// <summary>
        /// Time in minutes the forecast is for
        /// </summary>
        public byte TimeOffset;
        /// <summary>
        /// Weather - 0 = clear, 1 = light cloud, 2 = overcast, 3 = light rain, 4 = heavy rain, 5 = storm
        /// </summary>
        public byte Weather;
        /// <summary>
        /// Track temp. in degrees Celsius
        /// </summary>
        public sbyte TrackTemperature;
        /// <summary>
        /// Track temp. change – 0 = up, 1 = down, 2 = no change
        /// </summary>
        public sbyte TrackTemperatureChange;
        /// <summary>
        /// Air temp. in degrees celsius
        /// </summary>
        public sbyte AirTemperature;
        /// <summary>
        /// Air temp. change – 0 = up, 1 = down, 2 = no change
        /// </summary>
        public sbyte AirTemperatureChange;
        /// <summary>
        /// Rain percentage (0-100)
        /// </summary>
        public byte RainPercentage;

        public SessionType _SessionType => (SessionType)SessionType;
    }
}
