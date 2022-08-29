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


        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {
                Name="CarTelemetryData",
                Type = typeof(CarTelemetryData22),
                Count=22,
                Children = new PacketItem[]
                {
                    new PacketItem {Name="Speed",TypeName = "uint16"},
                    new PacketItem {Name="Throttle",TypeName = "float"},
                    new PacketItem {Name="Steer",TypeName = "float"},
                    new PacketItem {Name="Brake",TypeName = "float"},
                    new PacketItem {Name="Clutch",TypeName = "uint8"},
                    new PacketItem {Name="Gear",TypeName = "int8"},
                    new PacketItem {Name="EngineRPM",TypeName = "uint16"},
                    new PacketItem {Name="Drs",TypeName = "uint8"},
                    new PacketItem {Name="RevLightsPercent",TypeName = "uint8"},
                    new PacketItem {Name="RevLightsBitValue",TypeName = "uint16"},
                    new PacketItem {Name="BrakesTemperature",TypeName = "uint16",Count = 4  },
                    new PacketItem {Name="TyresSurfaceTemperature",TypeName = "uint8",Count = 4  },
                    new PacketItem {Name="TyresInnerTemperature",TypeName = "uint8",Count = 4  },
                    new PacketItem {Name="EngineTemperature",TypeName = "uint16"},
                    new PacketItem {Name="TyresPressure",TypeName = "float",Count = 4  },
                    new PacketItem {Name="SurfaceType",TypeName = "uint8",Count = 4  }
                }
            },
            new PacketItem {Name="MfdPanelIndex",TypeName = "uint8"},
            new PacketItem {Name="MFDPanelIndexSecondaryPlayer",TypeName = "uint8"},
            new PacketItem {Name="SuggestedGear",TypeName = "int8"}
        };
    }

    public class CarTelemetryData22 : CarTelemetryData21
    {

    }
}
