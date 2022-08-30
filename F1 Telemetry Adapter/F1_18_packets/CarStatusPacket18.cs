using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter.F1_18_Packets
{
    /// <summary>
    /// This packet details car statuses for all the cars in the race.
    /// Frequency: Rate as specified in menus
    /// Size: 1061 bytes
    /// Version: 1
    /// </summary>
    public class CarStatusPacket18 : F1Packet
    {
        public override int Length => 1061;

        public CarStatusData18[] CarStatusDatas;

        public CarStatusPacket18(HeaderPacket header, Bytes bys) : base(header, bys) { }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="CarStatusDatas",
                Type = typeof(CarStatusData18),
                Count = 20,
                Children = new PacketField[]
                {
                    new PacketField {Name="TractionControl",TypeName = "uint8"},
                    new PacketField {Name="AntiLockBrakes",TypeName = "uint8"},
                    new PacketField {Name="FuelMix",TypeName = "uint8"},
                    new PacketField {Name="FrontBrakeBias",TypeName = "uint8"},
                    new PacketField {Name="PitLimiterStatus",TypeName = "uint8"},
                    new PacketField {Name="FuelInTank",TypeName = "float"},
                    new PacketField {Name="FuelCapacity",TypeName = "float"},
                    new PacketField {Name="MaxRPM",TypeName = "uint16"},
                    new PacketField {Name="IdleRPM",TypeName = "uint16"},
                    new PacketField {Name="MaxGears",TypeName = "uint8"},
                    new PacketField {Name="DrsAllowed",TypeName = "uint8"},
                    new PacketField {Name="TyresWear",TypeName = "uint8",Count = 4},
                    new PacketField {Name="TyreCompound",TypeName = "uint8"},
                    new PacketField {Name="TyresDamage",TypeName = "uint8",Count = 4},
                    new PacketField {Name="FrontLeftWingDamage",TypeName = "uint8"},
                    new PacketField {Name="FrontRightWingDamage",TypeName = "uint8"},
                    new PacketField {Name="RearWingDamage",TypeName = "uint8"},
                    new PacketField {Name="EngineDamage",TypeName = "uint8"},
                    new PacketField {Name="GearboxDamage",TypeName = "uint8"},
                    new PacketField {Name="ExhaustDamage",TypeName = "uint8"},
                    new PacketField {Name="VehicleFiaFlags",TypeName = "int8"},
                    new PacketField {Name="ErsStoreEnergy",TypeName = "float"},
                    new PacketField {Name="ErsDeployMode",TypeName = "uint8"},
                    new PacketField {Name="ErsHarvestedThisLapMGUK",TypeName = "float"},
                    new PacketField {Name="ErsHarvestedThisLapMGUH",TypeName = "float"},
                    new PacketField {Name="ErsDeployedThisLap",TypeName = "float"}
                }
            }
        };
    }

    public class CarStatusData18
    {
        /// <summary>
        /// Traction control - 0 = off, 1 = medium, 2 = full
        /// </summary>
        public byte TractionControl;
        /// <summary>
        /// 0 (off) - 1 (on)
        /// </summary>
        public byte AntiLockBrakes;
        /// <summary>
        /// Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
        /// </summary>
        public byte FuelMix;
        /// <summary>
        /// Front brake bias (percentage)
        /// </summary>
        public byte FrontBrakeBias;
        /// <summary>
        /// Pit limiter status - 0 = off, 1 = on
        /// </summary>
        public byte PitLimiterStatus;
        /// <summary>
        /// Current fuel mass
        /// </summary>
        public float FuelInTank;
        /// <summary>
        /// Fuel capacity
        /// </summary>
        public float FuelCapacity;
        /// <summary>
        /// Cars max RPM, point of rev limiter
        /// </summary>
        public ushort MaxRPM;
        /// <summary>
        /// Cars idle RPM
        /// </summary>
        public ushort IdleRPM;
        /// <summary>
        /// Maximum number of gears
        /// </summary>
        public byte MaxGears;
        /// <summary>
        /// 0 = not allowed, 1 = allowed
        /// </summary>
        public byte DrsAllowed;

        public byte[] TyresWear;
        /// <summary>
        /// F1 Modern - 0 = hyper soft,1 = ultra soft,2 = super soft,3 = soft,4 = medium,5 = hard
        /// ,6 = super hard,7 = inter,8 = wet
        /// Classic 0-6 = dry,7-8 = wet
        /// </summary>
        public byte TyreCompound;
        /// <summary>
        /// Tyres Damage(%)
        /// </summary>
        public byte[] TyresDamage;
        public byte FrontLeftWingDamage;
        public byte FrontRightWingDamage;
        public byte RearWingDamage;
        public byte EngineDamage;
        public byte GearboxDamage;
        public byte ExhaustDamage;
        /// <summary>
        /// -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
        /// </summary>
        public sbyte VehicleFiaFlags;
        /// <summary>
        /// ERS energy store in Joules
        /// </summary>
        public float ErsStoreEnergy;
        /// <summary>
        /// ERS deployment mode, 0 = none, 1 = medium, 2 = hotlap, 3 = overtake
        /// </summary>
        public byte ErsDeployMode;
        /// <summary>
        /// ERS energy harvested this lap by MGU-K
        /// </summary>
        public float ErsHarvestedThisLapMGUK;
        /// <summary>
        /// ERS energy harvested this lap by MGU-H
        /// </summary>
        public float ErsHarvestedThisLapMGUH;
        /// <summary>
        /// ERS energy deployed this lap
        /// </summary>
        public float ErsDeployedThisLap;
    }
}
