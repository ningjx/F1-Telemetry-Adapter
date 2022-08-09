using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// Frequency: Rate as specified in menus
    /// Size: 1347 bytes
    /// Version: 1
    /// </summary>
    public class CarTelemetryPacket : F1Packet
    {
        public override int PacketSize => 1347;

        public CarTelemetryData[] CarTelemetryData;
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

        public CarTelemetryPacket(HeaderPacket header) : base(header) { }

        public CarTelemetryPacket() { }

        public override ItemList PacketItems => new ItemList
        {
            new PacketItem {
                Name="CarTelemetryData",
                Type = typeof(CarTelemetryData),
                Count=22,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="CarTelemetryData",Name="Speed",Type = typeof(ushort)},
                    new PacketItem {ClassName="CarTelemetryData",Name="Throttle",Type = typeof(float)},
                    new PacketItem {ClassName="CarTelemetryData",Name="Steer",Type = typeof(float)},
                    new PacketItem {ClassName="CarTelemetryData",Name="Brake",Type = typeof(float)},
                    new PacketItem {ClassName="CarTelemetryData",Name="Clutch",Type = typeof(byte)},
                    new PacketItem {ClassName="CarTelemetryData",Name="Gear",Type = typeof(sbyte)},
                    new PacketItem {ClassName="CarTelemetryData",Name="EngineRPM",Type = typeof(ushort)},
                    new PacketItem {ClassName="CarTelemetryData",Name="Drs",Type = typeof(byte)},
                    new PacketItem {ClassName="CarTelemetryData",Name="RevLightsPercent",Type = typeof(byte)},
                    new PacketItem {ClassName="CarTelemetryData",Name="RevLightsBitValue",Type = typeof(ushort)},
                    new PacketItem {ClassName="CarTelemetryData",Name="BrakesTemperature",Type = typeof(ushort),Count = 4  },
                    new PacketItem {ClassName="CarTelemetryData",Name="TyresSurfaceTemperature",Type = typeof(byte),Count = 4  },
                    new PacketItem {ClassName="CarTelemetryData",Name="TyresInnerTemperature",Type = typeof(byte),Count = 4  },
                    new PacketItem {ClassName="CarTelemetryData",Name="EngineTemperature",Type = typeof(ushort)},
                    new PacketItem {ClassName="CarTelemetryData",Name="TyresPressure",Type = typeof(float),Count = 4  },
                    new PacketItem {ClassName="CarTelemetryData",Name="SurfaceType",Type = typeof(byte),Count = 4  }
                }
            },
            new PacketItem {Name="MfdPanelIndex",Type = typeof(byte)},
            new PacketItem {Name="MFDPanelIndexSecondaryPlayer",Type = typeof(byte)},
            new PacketItem {Name="SuggestedGear",Type = typeof(sbyte)}
        };
    }

    public class CarTelemetryData
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
        /// Rev lights (bit 0 = leftmost LED, bit 14 = rightmost LED)
        /// </summary>
        public ushort RevLightsBitValue;
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
