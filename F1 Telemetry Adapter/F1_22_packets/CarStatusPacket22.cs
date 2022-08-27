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
    public class CarStatusPacket22 : CarStatusPacket21
    {
        //public override int PacketSize => 1058;

        public CarStatusData22[] CarStatusDatas;

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {
                Name="CarStatusDatas",
                Type = typeof(CarStatusData22),
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

    public class CarStatusData22 : CarStatusData21
    {
    }
}
