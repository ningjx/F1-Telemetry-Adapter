using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// This packet details car damage parameters for all the cars in the race.
    /// Frequency: 2 per second
    /// Size: 941 bytes
    /// Version: 1
    /// </summary>
    public class CarDamagePacket : F1Packet
    {
        public override int PacketSize => 941;

        public CarDamageData[] CarDamageDatas;

        public CarDamagePacket(HeaderPacket header) : base(header) { }

        public CarDamagePacket() { }

        public override ItemList PacketItems => new ItemList
        {
            new PacketItem
            {
                Name="CarDamageDatas",
                Type = typeof(CarDamageData),
                Count=22,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="CarDamageData",Name="TyresWear",Type = typeof(float),Count = 4  },
                    new PacketItem {ClassName="CarDamageData",Name="TyresDamage",Type = typeof(byte),Count = 4  },
                    new PacketItem {ClassName="CarDamageData",Name="BrakesDamage",Type = typeof(byte),Count = 4  },
                    new PacketItem {ClassName="CarDamageData",Name="FrontLeftWingDamage",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="FrontRightWingDamage",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="RearWingDamage",Type = typeof(byte)},
                    new PacketItem {ClassName="CarDamageData",Name="FloorDamage",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="DiffuserDamage",Type = typeof(byte)},
                    new PacketItem {ClassName="CarDamageData",Name="SidepodDamage",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="DrsFault",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="ErsFault",Type = typeof(byte)},
                    new PacketItem {ClassName="CarDamageData",Name="GearBoxDamage",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="EngineDamage",Type = typeof(byte)},
                    new PacketItem {ClassName="CarDamageData",Name="EngineMGUHWear",Type = typeof(byte)},
                    new PacketItem {ClassName="CarDamageData",Name="EngineESWear",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="EngineCEWear",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="EngineICEWear",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="EngineMGUKWear",Type = typeof(byte) },
                    new PacketItem {ClassName="CarDamageData",Name="EngineTCWear",Type = typeof(byte)},
                    new PacketItem {ClassName="CarDamageData",Name="EngineBlown",Type = typeof(byte)},
                    new PacketItem {ClassName="CarDamageData",Name="EngineSeized",Type = typeof(byte)}
                }
            }
        };
    }

    public class CarDamageData
    {
        /// <summary>
        /// Tyre wear (percentage)
        /// 0 – Rear Left (RL)
        /// 1 – Rear Right(RR)
        /// 2 – Front Left(FL)
        /// 3 – Front Right(FR)
        /// </summary>
        public float[] TyresWear;
        /// <summary>
        /// Tyre damage (percentage)
        /// 0 – Rear Left (RL)
        /// 1 – Rear Right(RR)
        /// 2 – Front Left(FL)
        /// 3 – Front Right(FR)
        /// </summary>
        public byte[] TyresDamage;
        /// <summary>
        /// Brakes damage (percentage)
        /// 0 – Rear Left (RL)
        /// 1 – Rear Right(RR)
        /// 2 – Front Left(FL)
        /// 3 – Front Right(FR)
        /// </summary>
        public byte[] BrakesDamage;
        /// <summary>
        /// Front left wing damage (percentage)
        /// </summary>
        public byte FrontLeftWingDamage;
        /// <summary>
        /// Front right wing damage (percentage)
        /// </summary>
        public byte FrontRightWingDamage;

        /// <summary>
        /// Rear wing damage (percentage)
        /// </summary>
        public byte RearWingDamage;
        /// <summary>
        /// Floor damage (percentage)
        /// </summary>
        public byte FloorDamage;
        /// <summary>
        /// Diffuser damage (percentage)
        /// </summary>
        public byte DiffuserDamage;
        /// <summary>
        /// Sidepod damage (percentage)
        /// </summary>
        public byte SidepodDamage;
        /// <summary>
        /// Indicator for DRS fault, 0 = OK, 1 = fault
        /// </summary>
        public byte DrsFault;
        /// <summary>
        /// Indicator for ERS fault, 0 = OK, 1 = fault
        /// </summary>
        public byte ErsFault;
        /// <summary>
        /// Gear box damage (percentage)
        /// </summary>
        public byte GearBoxDamage;
        /// <summary>
        /// Engine damage (percentage)
        /// </summary>
        public byte EngineDamage;
        /// <summary>
        /// Engine wear MGU-H (percentage)
        /// </summary>
        public byte EngineMGUHWear;
        /// <summary>
        /// Engine wear ES (percentage)
        /// </summary>
        public byte EngineESWear;
        /// <summary>
        /// Engine wear CE (percentage)
        /// </summary>
        public byte EngineCEWear;
        /// <summary>
        /// Engine wear ICE (percentage)
        /// </summary>
        public byte EngineICEWear;
        /// <summary>
        /// Engine wear MGU-K (percentage)
        /// </summary>
        public byte EngineMGUKWear;
        /// <summary>
        /// Engine wear TC (percentage)
        /// </summary>
        public byte EngineTCWear;
        /// <summary>
        /// Engine blown, 0 = OK, 1 = fault
        /// </summary>
        public byte EngineBlown;
        /// <summary>
        /// Engine seized, 0 = OK, 1 = fault
        /// </summary>
        public byte EngineSeized;
    }
}
