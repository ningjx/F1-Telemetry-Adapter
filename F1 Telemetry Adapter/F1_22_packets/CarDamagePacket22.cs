using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_22_Packets
{
    /// <summary>
    /// This packet details car damage parameters for all the cars in the race.
    /// Frequency: 2 per second
    /// Size: 941 bytes
    /// Version: 1
    /// </summary>
    public class CarDamagePacket22 : CarDamagePacket21
    {
        public override int PacketSize => 941;

        public CarDamageData22[] CarDamageDatas;

        public CarDamagePacket22(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem
            {
                Name = "CarDamageDatas",
                Type = typeof(CarDamageData22),
                Count = 22,
                Children = new PacketItem[]
                {
                    new PacketItem {Name="TyresWear",TypeName = "float",Count = 4  },
                    new PacketItem {Name="TyresDamage",TypeName = "uint8",Count = 4  },
                    new PacketItem {Name="BrakesDamage",TypeName = "uint8",Count = 4  },
                    new PacketItem {Name="FrontLeftWingDamage",TypeName = "uint8" },
                    new PacketItem {Name="FrontRightWingDamage",TypeName = "uint8" },
                    new PacketItem {Name="RearWingDamage",TypeName = "uint8"},
                    new PacketItem {Name="FloorDamage",TypeName = "uint8" },
                    new PacketItem {Name="DiffuserDamage",TypeName = "uint8"},
                    new PacketItem {Name="SidepodDamage",TypeName = "uint8" },
                    new PacketItem {Name="DrsFault",TypeName = "uint8" },
                    new PacketItem {Name="ErsFault",TypeName = "uint8"},
                    new PacketItem {Name="GearBoxDamage",TypeName = "uint8" },
                    new PacketItem {Name="EngineDamage",TypeName = "uint8"},
                    new PacketItem {Name="EngineMGUHWear",TypeName = "uint8"},
                    new PacketItem {Name="EngineESWear",TypeName = "uint8" },
                    new PacketItem {Name="EngineCEWear",TypeName = "uint8" },
                    new PacketItem {Name="EngineICEWear",TypeName = "uint8" },
                    new PacketItem {Name="EngineMGUKWear",TypeName = "uint8" },
                    new PacketItem {Name="EngineTCWear",TypeName = "uint8"},
                    new PacketItem {Name="EngineBlown",TypeName = "uint8"},
                    new PacketItem {Name="EngineSeized",TypeName = "uint8"}
                }
            }
        };
    }

    public class CarDamageData22
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
