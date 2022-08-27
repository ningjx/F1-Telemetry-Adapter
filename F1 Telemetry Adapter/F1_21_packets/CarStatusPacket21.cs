using F1_Telemetry_Adapter.F1_Base_packets;
using F1_Telemetry_Adapter.Models;
using System;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// This packet details car statuses for all the cars in the race.
    /// Frequency: Rate as specified in menus
    /// Size: 1058 bytes
    /// Version: 1
    /// </summary>
    public class CarStatusPacket21 : F1Packet
    {
        public override int PacketSize => 1058;

        public CarStatusData21[] CarStatusDatas;

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {
                Name="CarStatusDatas",
                Type = typeof(CarStatusData21),
                Count=22,
                Children = new PacketItem[]
                {
                    new PacketItem {Name="TractionControl",TypeName = "uint8"},
                    new PacketItem {Name="AntiLockBrakes",TypeName = "uint8"},
                    new PacketItem {Name="FuelMix",TypeName = "uint8"},
                    new PacketItem {Name="FrontBrakeBias",TypeName = "uint8"},
                    new PacketItem {Name="PitLimiterStatus",TypeName = "uint8"},
                    new PacketItem {Name="FuelInTank",TypeName = "float"},
                    new PacketItem {Name="FuelCapacity",TypeName = "float"},
                    new PacketItem {Name="FuelRemainingLaps",TypeName = "float"},
                    new PacketItem {Name="MaxRPM",TypeName = "uint16"},
                    new PacketItem {Name="IdleRPM",TypeName = "uint16"},
                    new PacketItem {Name="MaxGears",TypeName = "uint8"},
                    new PacketItem {Name="DrsAllowed",TypeName = "uint8"},
                    new PacketItem {Name="DrsActivationDistance",TypeName = "uint16"},
                    new PacketItem {Name="ActualTyreCompound",TypeName = "uint8"},
                    new PacketItem {Name="VisualTyreCompound",TypeName = "uint8"},
                    new PacketItem {Name="TyresAgeLaps",TypeName = "uint8"},
                    new PacketItem {Name="VehicleFiaFlags",TypeName = "int8"},
                    new PacketItem {Name="ErsStoreEnergy",TypeName = "float"},
                    new PacketItem {Name="ErsDeployMode",TypeName = "uint8"},
                    new PacketItem {Name="ErsHarvestedThisLapMGUK",TypeName = "float"},
                    new PacketItem {Name="ErsHarvestedThisLapMGUH",TypeName = "float"},
                    new PacketItem {Name="ErsDeployedThisLap",TypeName = "float"},
                    new PacketItem {Name="NetworkPaused",TypeName = "uint8"}
                }
            }
        };
    }

    public class CarStatusData21
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
        /// Fuel remaining in terms of laps (value on MFD)
        /// </summary>
        public float FuelRemainingLaps;
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
        /// <summary>
        /// 0 = DRS not available, non-zero - DRS will be available in [X] metres
        /// </summary>
        public ushort DrsActivationDistance;
        /// <summary>
        /// F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1
        /// 7 = inter, 8 = wet
        /// F1 Classic - 9 = dry, 10 = wet
        /// F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard
        /// 15 = wet
        /// </summary>
        public byte ActualTyreCompound;
        /// <summary>
        /// F1 visual (can be different from actual compound)
        /// 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet
        /// F1 Classic – same as above
        /// F2 ‘19, 15 = wet, 19 – super soft, 20 = soft
        /// 21 = medium , 22 = hard
        /// </summary>
        public byte VisualTyreCompound;
        /// <summary>
        /// Age in laps of the current set of tyres
        /// </summary>
        public byte TyresAgeLaps;
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
        /// <summary>
        /// Whether the car is paused in a network game
        /// </summary>
        public byte NetworkPaused;
    }
}
