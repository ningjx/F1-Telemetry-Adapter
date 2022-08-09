using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// This packet details the car setups for each vehicle in the session. Note that in multiplayer games, other player cars will appear as blank, you will only be able to see your car setup and AI cars.
    /// Frequency: 2 per second
    /// Size: 1102 bytes
    /// Version: 1
    /// </summary>
    public class CarSetupsPacket : F1Packet
    {
        public override int PacketSize => 1102;

        public CarSetupData[] CarSetupDatas;

        public CarSetupsPacket(HeaderPacket header) : base(header) { }

        public CarSetupsPacket() { }

        public override ItemList PacketItems => new ItemList
        {
            new PacketItem {
                Name="CarSetupDatas",
                Type = typeof(CarSetupData),
                Count=22,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="CarSetupData",Name="FrontWing",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="RearWing",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="OnThrottle",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="OffThrottle",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="FrontCamber",Type = typeof(float)},
                    new PacketItem {ClassName="CarSetupData",Name="TearCamber",Type = typeof(float)},
                    new PacketItem {ClassName="CarSetupData",Name="FrontToe",Type = typeof(float)},
                    new PacketItem {ClassName="CarSetupData",Name="RearToe",Type = typeof(float)},
                    new PacketItem {ClassName="CarSetupData",Name="FrontSuspension",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="TearSuspension",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="FrontAntiRollBar",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="TearAntiRollBar",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="FrontSuspensionHeight",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="TearSuspensionHeight",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="BrakePressure",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="BrakeBias",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="RearLeftTyrePressure",Type = typeof(float)},
                    new PacketItem {ClassName="CarSetupData",Name="RearRightTyrePressure",Type = typeof(float)},
                    new PacketItem {ClassName="CarSetupData",Name="FrontLeftTyrePressure",Type = typeof(float)},
                    new PacketItem {ClassName="CarSetupData",Name="FrontRightTyrePressure",Type = typeof(float)},
                    new PacketItem {ClassName="CarSetupData",Name="Ballast",Type = typeof(byte)},
                    new PacketItem {ClassName="CarSetupData",Name="FuelLoad",Type = typeof(float)}
                }
            }
        };
    }

    public class CarSetupData
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