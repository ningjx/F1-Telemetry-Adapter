using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_20_packets
{
    /// <summary>
    /// Frequency: Rate as specified in menus
    /// Size: 1307 bytes
    /// Version: 1
    /// </summary>
    public class CarTelemetryPacket20 : F1Packet
    {
        public override int Length => 1307;

        public CarTelemetryData20[] CarTelemetryData;
        public uint ButtonStatus;
        /// <summary>
        /// Index of MFD panel open - 255 = MFD closed.
        /// Single player, race – 0 = Car setup, 1 = Pits.
        /// 2 = Damage, 3 =  Engine, 4 = Temperatures.
        /// May vary depending on game mode.
        /// </summary>
        public byte MfdPanelIndex;
        /// <summary>
        /// Index of MFD panel open - 255 = MFD closed.
        /// Single player, race – 0 = Car setup, 1 = Pits.
        /// 2 = Damage, 3 =  Engine, 4 = Temperatures.
        /// May vary depending on game mode.
        /// </summary>
        public byte MFDPanelIndexSecondaryPlayer;
        /// <summary>
        /// Suggested gear for the player (1-8).
        /// 0 if no gear suggested
        /// </summary>
        public sbyte SuggestedGear;

        public CarTelemetryPacket20(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="CarTelemetryData",
                Type = typeof(CarTelemetryData20),
                Count=22,
                Children = new PacketField[]
                {
                    new PacketField {Name="Speed",TypeName = "uint16"},
                    new PacketField {Name="Throttle",TypeName = "float"},
                    new PacketField {Name="Steer",TypeName = "float"},
                    new PacketField {Name="Brake",TypeName = "float"},
                    new PacketField {Name="Clutch",TypeName = "uint8"},
                    new PacketField {Name="Gear",TypeName = "int8"},
                    new PacketField {Name="EngineRPM",TypeName = "uint16"},
                    new PacketField {Name="Drs",TypeName = "uint8"},
                    new PacketField {Name="RevLightsPercent",TypeName = "uint8"},
                    new PacketField {Name="BrakesTemperature",TypeName = "uint16",Count = 4  },
                    new PacketField {Name="TyresSurfaceTemperature",TypeName = "uint8",Count = 4  },
                    new PacketField {Name="TyresInnerTemperature",TypeName = "uint8",Count = 4  },
                    new PacketField {Name="EngineTemperature",TypeName = "uint16"},
                    new PacketField {Name="TyresPressure",TypeName = "float",Count = 4  },
                    new PacketField {Name="SurfaceType",TypeName = "uint8",Count = 4  }
                }
            },
            new PacketField {Name="ButtonStatus",TypeName = "uint32"},
            new PacketField {Name="MfdPanelIndex",TypeName = "uint8"},
            new PacketField {Name="MFDPanelIndexSecondaryPlayer",TypeName = "uint8"},
            new PacketField {Name="SuggestedGear",TypeName = "int8"}
        };
    }

    public class CarTelemetryData20
    {
        /// <summary>
        /// Speed of car in kilometres per hour
        /// </summary>
        public ushort Speed;
        /// <summary>
        /// Amount of throttle applied (0.0 to 1.0)
        /// </summary>
        public float Throttle;
        /// <summary>
        /// Steering (-1.0 (full lock left) to 1.0 (full lock right))
        /// </summary>
        public float Steer;
        /// <summary>
        /// Amount of brake applied (0.0 to 1.0)
        /// </summary>
        public float Brake;
        /// <summary>
        /// Amount of clutch applied (0 to 100)
        /// </summary>
        public byte Clutch;
        /// <summary>
        /// Gear selected (1-8, N=0, R= -1)
        /// </summary>
        public sbyte Gear;
        /// <summary>
        /// Engine RPM
        /// </summary>
        public ushort EngineRPM;
        /// <summary>
        /// 0 = off, 1 = on
        /// </summary>
        public byte Drs;
        /// <summary>
        /// Rev lights indicator (percentage)
        /// </summary>
        public byte RevLightsPercent;
        /// <summary>
        /// Brakes temperature (celsius)
        /// </summary>
        public ushort[] BrakesTemperature;
        /// <summary>
        /// Tyres surface temperature (celsius)
        /// </summary>
        public byte[] TyresSurfaceTemperature;
        /// <summary>
        /// Tyres inner temperature (celsius)
        /// </summary>
        public byte[] TyresInnerTemperature;
        /// <summary>
        /// Engine temperature (celsius)
        /// </summary>
        public ushort EngineTemperature;
        /// <summary>
        /// Tyres pressure (PSI)
        /// </summary>
        public float[] TyresPressure;
        /// <summary>
        /// Driving surface, see appendices
        /// </summary>
        public byte[] SurfaceType;
    }
}
