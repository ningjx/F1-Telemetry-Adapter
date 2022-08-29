using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_22_Packets
{
    /// <summary>
    /// This packet details car damage parameters for all the cars in the race.
    /// Frequency: 2 per second
    /// Size: 882 bytes
    /// Version: 1
    /// </summary>
    public class CarDamagePacket21 : F1Packet
    {
        public override int Length => 882;

        public CarDamageData21[] CarDamageDatas;

        public CarDamagePacket21(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override FieldList Fields => new FieldList
        {
            new PacketField
            {
                Name = "CarDamageDatas",
                Type = typeof(CarDamageData21),
                Count = 22,
                Children = new PacketField[]
                {
                    new PacketField {Name="TyresWear",TypeName = "float",Count = 4  },
                    new PacketField {Name="TyresDamage",TypeName = "uint8",Count = 4  },
                    new PacketField {Name="BrakesDamage",TypeName = "uint8",Count = 4  },
                    new PacketField {Name="FrontLeftWingDamage",TypeName = "uint8" },
                    new PacketField {Name="FrontRightWingDamage",TypeName = "uint8" },
                    new PacketField {Name="RearWingDamage",TypeName = "uint8"},
                    new PacketField {Name="FloorDamage",TypeName = "uint8" },
                    new PacketField {Name="DiffuserDamage",TypeName = "uint8"},
                    new PacketField {Name="SidepodDamage",TypeName = "uint8" },
                    new PacketField {Name="DrsFault",TypeName = "uint8" },
                    new PacketField {Name="GearBoxDamage",TypeName = "uint8" },
                    new PacketField {Name="EngineDamage",TypeName = "uint8"},
                    new PacketField {Name="EngineMGUHWear",TypeName = "uint8"},
                    new PacketField {Name="EngineESWear",TypeName = "uint8" },
                    new PacketField {Name="EngineCEWear",TypeName = "uint8" },
                    new PacketField {Name="EngineICEWear",TypeName = "uint8" },
                    new PacketField {Name="EngineMGUKWear",TypeName = "uint8" },
                    new PacketField {Name="EngineTCWear",TypeName = "uint8"}
                }
            }
        };
    }

    public class CarDamageData21
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
    }
}
