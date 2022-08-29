using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_18_Packets
{
    /// <summary>
    /// This packet details the car setups for each vehicle in the session. Note that in multiplayer games, other player cars will appear as blank, you will only be able to see your car setup and AI cars.
    /// Frequency: 2 per second
    /// Size: 841 bytes
    /// </summary>
    public class CarSetupsPacket18 : F1Packet
    {
        public override int Length => 841;

        public CarSetupData18[] CarSetupDatas;

        public CarSetupsPacket18(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="CarSetupDatas",
                Type = typeof(CarSetupData18),
                Count = 20,
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
                    new PacketField {Name="FrontTyrePressure",TypeName = "float"},
                    new PacketField {Name="RearTyrePressure",TypeName = "float"},
                    new PacketField {Name="Ballast",TypeName = "uint8"},
                    new PacketField {Name="FuelLoad",TypeName = "float"}
                }
            }
        };
    }

    public class CarSetupData18
    {
        /// <summary>
        /// Front wing aero
        /// </summary>
        public byte FrontWing;
        /// <summary>
        /// Rear wing aero
        /// </summary>
        public byte RearWing;
        /// <summary>
        /// Differential adjustment on throttle (percentage)
        /// </summary>
        public byte OnThrottle;
        /// <summary>
        /// Differential adjustment off throttle (percentage)
        /// </summary>
        public byte OffThrottle;
        /// <summary>
        /// Front camber angle (suspension geometry)
        /// </summary>
        public float FrontCamber;
        /// <summary>
        /// Rear camber angle (suspension geometry)
        /// </summary>
        public float RearCamber;
        /// <summary>
        /// Front toe angle (suspension geometry)
        /// </summary>
        public float FrontToe;
        /// <summary>
        /// Rear toe angle (suspension geometry)
        /// </summary>
        public float RearToe;
        /// <summary>
        /// Front suspension
        /// </summary>
        public byte FrontSuspension;
        /// <summary>
        /// Rear suspension
        /// </summary>
        public byte RearSuspension;
        /// <summary>
        /// Front anti-roll bar
        /// </summary>
        public byte FrontAntiRollBar;
        /// <summary>
        /// Front anti-roll bar
        /// </summary>
        public byte RearAntiRollBar;
        /// <summary>
        /// Front ride height
        /// </summary>
        public byte FrontSuspensionHeight;
        /// <summary>
        /// Rear ride height
        /// </summary>
        public byte RearSuspensionHeight;
        /// <summary>
        /// Brake pressure (percentage)
        /// </summary>
        public byte BrakePressure;
        /// <summary>
        /// Brake bias (percentage)
        /// </summary>
        public byte BrakeBias;
        /// <summary>
        /// Front tyre pressure (PSI)
        /// </summary>
        public float FrontTyrePressure;
        /// <summary>
        /// Rear tyre pressure (PSI)
        /// </summary>
        public float RearTyrePressure;
        /// <summary>
        /// Ballast
        /// </summary>
        public byte Ballast;
        /// <summary>
        /// Fuel load
        /// </summary>
        public float FuelLoad;
    }
}