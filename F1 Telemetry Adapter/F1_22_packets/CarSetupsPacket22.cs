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
    public class CarSetupsPacket22 : F1Packet
    {
        public override int Length => 1102;

        public CarSetupData22[] CarSetupDatas;

        public CarSetupsPacket22(HeaderPacket header, Bytes bys) : base(header, bys) { }

        public CarSetupsPacket22() { }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="CarSetupDatas",
                Type = typeof(CarSetupData22),
                Count=22,
                Children = new PacketField[]
                {
                    new PacketField {Name="FrontWing",TypeName = "uint8"},
                    new PacketField {Name="RearWing",TypeName = "uint8"},
                    new PacketField {Name="OnThrottle",TypeName = "uint8"},
                    new PacketField {Name="OffThrottle",TypeName = "uint8"},
                    new PacketField {Name="FrontCamber",TypeName = "float"},
                    new PacketField {Name="RearCamber",TypeName = "float"},
                    new PacketField {Name="FrontToe",TypeName = "float"},
                    new PacketField {Name="RearToe",TypeName = "float"},
                    new PacketField {Name="FrontSuspension",TypeName = "uint8"},
                    new PacketField {Name="RearSuspension",TypeName = "uint8"},
                    new PacketField {Name="FrontAntiRollBar",TypeName = "uint8"},
                    new PacketField {Name="RearAntiRollBar",TypeName = "uint8"},
                    new PacketField {Name="FrontSuspensionHeight",TypeName = "uint8"},
                    new PacketField {Name="RearSuspensionHeight",TypeName = "uint8"},
                    new PacketField {Name="BrakePressure",TypeName = "uint8"},
                    new PacketField {Name="BrakeBias",TypeName = "uint8"},
                    new PacketField {Name="RearLeftTyrePressure",TypeName = "float"},
                    new PacketField {Name="RearRightTyrePressure",TypeName = "float"},
                    new PacketField {Name="FrontLeftTyrePressure",TypeName = "float"},
                    new PacketField {Name="FrontRightTyrePressure",TypeName = "float"},
                    new PacketField {Name="Ballast",TypeName = "uint8"},
                    new PacketField {Name="FuelLoad",TypeName = "float"}
                }
            }
        };
    }

    public class CarSetupData22 : CarSetupData21
    {

    }
}