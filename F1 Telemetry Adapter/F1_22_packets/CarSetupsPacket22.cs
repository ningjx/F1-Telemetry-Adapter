using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_22_Packets
{
    /// <summary>
    /// This packet details the car setups for each vehicle in the session. Note that in multiplayer games, other player cars will appear as blank, you will only be able to see your car setup and AI cars.
    /// Frequency: 2 per second
    /// Size: 1102 bytes
    /// Version: 1
    /// </summary>
    public class CarSetupsPacket22 : CarSetupsPacket21
    {
        //public override int PacketSize => 1102;

        public CarSetupData22[] CarSetupDatas;

        public CarSetupsPacket22(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {
                Name="CarSetupDatas",
                Type = typeof(CarSetupData22),
                Count=22,
                Children = new PacketItem[]
                {
                    new PacketItem {Name="FrontWing",TypeName = "uint8"},
                    new PacketItem {Name="RearWing",TypeName = "uint8"},
                    new PacketItem {Name="OnThrottle",TypeName = "uint8"},
                    new PacketItem {Name="OffThrottle",TypeName = "uint8"},
                    new PacketItem {Name="FrontCamber",TypeName = "float"},
                    new PacketItem {Name="TearCamber",TypeName = "float"},
                    new PacketItem {Name="FrontToe",TypeName = "float"},
                    new PacketItem {Name="RearToe",TypeName = "float"},
                    new PacketItem {Name="FrontSuspension",TypeName = "uint8"},
                    new PacketItem {Name="TearSuspension",TypeName = "uint8"},
                    new PacketItem {Name="FrontAntiRollBar",TypeName = "uint8"},
                    new PacketItem {Name="TearAntiRollBar",TypeName = "uint8"},
                    new PacketItem {Name="FrontSuspensionHeight",TypeName = "uint8"},
                    new PacketItem {Name="TearSuspensionHeight",TypeName = "uint8"},
                    new PacketItem {Name="BrakePressure",TypeName = "uint8"},
                    new PacketItem {Name="BrakeBias",TypeName = "uint8"},
                    new PacketItem {Name="RearLeftTyrePressure",TypeName = "float"},
                    new PacketItem {Name="RearRightTyrePressure",TypeName = "float"},
                    new PacketItem {Name="FrontLeftTyrePressure",TypeName = "float"},
                    new PacketItem {Name="FrontRightTyrePressure",TypeName = "float"},
                    new PacketItem {Name="Ballast",TypeName = "uint8"},
                    new PacketItem {Name="FuelLoad",TypeName = "float"}
                }
            }
        };
    }

    public class CarSetupData22 : CarSetupData21
    {

    }
}