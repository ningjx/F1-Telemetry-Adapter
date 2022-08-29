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
    public class CarSetupsPacket21 : F1Packet
    {
        public override int Length => 1102;

        public CarSetupData21[] CarSetupDatas;

        public CarSetupsPacket21(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="CarSetupDatas",
                Type = typeof(CarSetupData21),
                Count=22,
                Children = new PacketField[]
                {
                    new PacketField {Name="FrontWing",TypeName = "uint8"},
                    new PacketField {Name="RearWing",TypeName = "uint8"},
                    new PacketField {Name="OnThrottle",TypeName = "uint8"},
                    new PacketField {Name="OffThrottle",TypeName = "uint8"},
                    new PacketField {Name="FrontCamber",TypeName = "float"},
                    new PacketField {Name="TearCamber",TypeName = "float"},
                    new PacketField {Name="FrontToe",TypeName = "float"},
                    new PacketField {Name="RearToe",TypeName = "float"},
                    new PacketField {Name="FrontSuspension",TypeName = "uint8"},
                    new PacketField {Name="TearSuspension",TypeName = "uint8"},
                    new PacketField {Name="FrontAntiRollBar",TypeName = "uint8"},
                    new PacketField {Name="TearAntiRollBar",TypeName = "uint8"},
                    new PacketField {Name="FrontSuspensionHeight",TypeName = "uint8"},
                    new PacketField {Name="TearSuspensionHeight",TypeName = "uint8"},
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

    public class CarSetupData21
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
        public float TearCamber;
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
        public byte TearSuspension;
        /// <summary>
        /// Front anti-roll bar
        /// </summary>
        public byte FrontAntiRollBar;
        /// <summary>
        /// Front anti-roll bar
        /// </summary>
        public byte TearAntiRollBar;
        /// <summary>
        /// Front ride height
        /// </summary>
        public byte FrontSuspensionHeight;
        /// <summary>
        /// Rear ride height
        /// </summary>
        public byte TearSuspensionHeight;
        /// <summary>
        /// Brake pressure (percentage)
        /// </summary>
        public byte BrakePressure;
        /// <summary>
        /// Brake bias (percentage)
        /// </summary>
        public byte BrakeBias;
        /// <summary>
        /// Rear left tyre pressure (PSI)
        /// </summary>
        public float RearLeftTyrePressure;
        /// <summary>
        /// Rear right tyre pressure (PSI)
        /// </summary>
        public float RearRightTyrePressure;
        /// <summary>
        /// Front left tyre pressure (PSI)
        /// </summary>
        public float FrontLeftTyrePressure;
        /// <summary>
        /// Front right tyre pressure (PSI)
        /// </summary>
        public float FrontRightTyrePressure;
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