using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_18_Packets
{
    /// <summary>
    /// The session packet includes details about the current session in progress.
    /// Frequency: 2 per second
    /// Size: 147 bytes
    /// </summary>
    public class SessionPacket18 : F1Packet
    {
        public override int Length => 147;

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
        ///  Era, 0 = F1 Modern, 1 = F1 Classic
        /// </summary>
        public byte Era;
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
        public MarshalZone18[] MarshalZones;
        /// <summary>
        /// 0 = no safety car, 1 = full, 2 = virtual, 3 = formation lap
        /// </summary>
        public byte SafetyCarStatus;
        /// <summary>
        /// 0 = offline, 1 = online
        /// </summary>
        public byte NetworkGame;

        public SessionPacket18(HeaderPacket header, Bytes bys) : base(header, bys) { }

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
            new PacketField {Name="Era",TypeName = "uint8"},
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
                Type = typeof(MarshalZone18),
                Count = 21,
                Children = new PacketField[]
                {
                    new PacketField {Name="ZoneStart",TypeName = "float"},
                    new PacketField {Name="ZoneFlag",TypeName = "int8"}
                }
            },
            new PacketField {Name="SafetyCarStatus",TypeName = "uint8"},
            new PacketField {Name="NetworkGame",TypeName = "uint8"}
            };
    }

    public class MarshalZone18
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
}
