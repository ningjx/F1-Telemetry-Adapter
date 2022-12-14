using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_22_packets
{
    /// <summary>
    /// The session packet includes details about the current session in progress.
    /// Frequency: 2 per second
    /// Size: 632 bytes
    /// Version: 1
    /// </summary>
    public class SessionPacket22 : F1Packet
    {
        public override int Length => 632;

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
        public MarshalZone22[] MarshalZones;
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
        public WeatherForecastSample22[] WeatherForecastSamples;
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

        public SessionPacket22(HeaderPacket header, Bytes bys) : base(header, bys) { }

        public SessionType _SessionType => (SessionType)SessionType;

        internal override FieldList Fields => new FieldList
        {
            new PacketField {Name="Weather",TypeName = "uint8"},
            new PacketField {Name="TrackTemperature",TypeName = "int8"},
            new PacketField {Name="AirTemperature",TypeName = "int8"},
            new PacketField {Name="TotalLaps",TypeName = "uint8"},
            new PacketField {Name="TrackLength",TypeName = "uint16"},
            new PacketField {Name="SessionType",TypeName = "uint8"},
            new PacketField {Name="TrackId",TypeName = "int8"},
            new PacketField {Name="Formula",TypeName = "uint8"},
            new PacketField {Name="SessionTimeLeft",TypeName = "uint16"},
            new PacketField {Name="SessionDuration",TypeName = "uint16"},
            new PacketField {Name="PitSpeedLimit",TypeName = "uint8"},
            new PacketField {Name="GamePaused",TypeName = "uint8"},
            new PacketField {Name="IsSpectating",TypeName = "uint8"},
            new PacketField {Name="SpectatorCarIndex",TypeName = "uint8"},
            new PacketField {Name="SliProNativeSupport",TypeName = "uint8"},
            new PacketField {Name="NumMarshalZones",TypeName = "uint8"},
            new PacketField {
                Name="MarshalZones",
                Type = typeof(MarshalZone22),
                Count=21,
                Children = new PacketField[]
                {
                    new PacketField {Name="ZoneStart",TypeName = "float"},
                    new PacketField {Name="ZoneFlag",TypeName = "int8"}
                }
            },
            new PacketField {Name="SafetyCarStatus",TypeName = "uint8"},
            new PacketField {Name="NetworkGame",TypeName = "uint8"},
            new PacketField {Name="NumWeatherForecastSamples",TypeName = "uint8"},
            new PacketField {
                Name="WeatherForecastSamples",
                Type = typeof(WeatherForecastSample22),
                Count= 56,
                Children = new PacketField[]
                {
                    new PacketField { Name="SessionType",TypeName = "uint8"},
                    new PacketField {Name="TimeOffset",TypeName = "uint8"},
                    new PacketField {Name="Weather",TypeName = "uint8"},
                    new PacketField {Name="TrackTemperature",TypeName = "int8"},
                    new PacketField {Name="TrackTemperatureChange",TypeName = "int8"},
                    new PacketField {Name="AirTemperature",TypeName = "int8"},
                    new PacketField {Name="AirTemperatureChange",TypeName = "int8"},
                    new PacketField {Name="RainPercentage",TypeName = "uint8"}
                }
            },
            new PacketField {Name="ForecastAccuracy",TypeName = "uint8"},
            new PacketField {Name="AiDifficulty",TypeName = "uint8"},
            new PacketField {Name="SeasonLinkIdentifier",TypeName = "uint32"},
            new PacketField {Name="WeekendLinkIdentifier",TypeName = "uint32"},
            new PacketField {Name="SessionLinkIdentifier",TypeName = "uint32"},
            new PacketField {Name="PitStopWindowIdealLap",TypeName = "uint8"},
            new PacketField {Name="PitStopWindowLatestLap",TypeName = "uint8"},
            new PacketField {Name="PitStopRejoinPosition",TypeName = "uint8"},
            new PacketField {Name="SteeringAssist",TypeName = "uint8"},
            new PacketField {Name="BrakingAssist",TypeName = "uint8"},
            new PacketField {Name="GearboxAssist",TypeName = "uint8"},
            new PacketField {Name="PitAssist",TypeName = "uint8"},
            new PacketField {Name="PitReleaseAssist",TypeName = "uint8"},
            new PacketField {Name="ERSAssist",TypeName = "uint8"},
            new PacketField {Name="DRSAssist",TypeName = "uint8"},
            new PacketField {Name="DynamicRacingLine",TypeName = "uint8"},
            new PacketField {Name="DynamicRacingLineType",TypeName = "uint8"},
            new PacketField {Name="GameMode",TypeName = "uint8"},
            new PacketField {Name="RuleSet",TypeName = "uint8"},
            new PacketField {Name="TimeOfDay",TypeName = "uint32"},
            new PacketField {Name="SessionLength",TypeName = "uint8"}
            };
    }

    public class MarshalZone22
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

    public class WeatherForecastSample22
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
