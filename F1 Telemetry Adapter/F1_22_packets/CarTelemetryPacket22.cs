using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_22_Packets
{
    /// <summary>
    /// Frequency: Rate as specified in menus
    /// Size: 1347 bytes
    /// Version: 1
    /// </summary>
    public class CarTelemetryPacket22 : CarTelemetryPacket21
    {
        //public override int PacketSize => 1347;

        public CarTelemetryData22[] CarTelemetryData;

        public CarTelemetryPacket22(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        /// <summary>
        /// Index of MFD panel open - 255 = MFD closed.
        /// Single player, race – 0 = Car setup, 1 = Pits.
        /// 2 = Damage, 3 =  Engine, 4 = Temperatures.
        /// May vary depending on game mode.
        /// </summary>
        //public byte MfdPanelIndex;
        /// <summary>
        /// Index of MFD panel open - 255 = MFD closed.
        /// Single player, race – 0 = Car setup, 1 = Pits.
        /// 2 = Damage, 3 =  Engine, 4 = Temperatures.
        /// May vary depending on game mode.
        /// </summary>
        //public byte MFDPanelIndexSecondaryPlayer;
        /// <summary>
        /// Suggested gear for the player (1-8).
        /// 0 if no gear suggested
        /// </summary>
        //public sbyte SuggestedGear;


        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="CarTelemetryData",
                Type = typeof(CarTelemetryData22),
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
                    new PacketField {Name="RevLightsBitValue",TypeName = "uint16"},
                    new PacketField {Name="BrakesTemperature",TypeName = "uint16",Count = 4  },
                    new PacketField {Name="TyresSurfaceTemperature",TypeName = "uint8",Count = 4  },
                    new PacketField {Name="TyresInnerTemperature",TypeName = "uint8",Count = 4  },
                    new PacketField {Name="EngineTemperature",TypeName = "uint16"},
                    new PacketField {Name="TyresPressure",TypeName = "float",Count = 4  },
                    new PacketField {Name="SurfaceType",TypeName = "uint8",Count = 4  }
                }
            },
            new PacketField {Name="MfdPanelIndex",TypeName = "uint8"},
            new PacketField {Name="MFDPanelIndexSecondaryPlayer",TypeName = "uint8"},
            new PacketField {Name="SuggestedGear",TypeName = "int8"}
        };
    }

    public class CarTelemetryData22 : CarTelemetryData21
    {

    }
}
