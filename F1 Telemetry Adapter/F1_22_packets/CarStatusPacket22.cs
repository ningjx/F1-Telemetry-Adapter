using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;
using System;

namespace NingSoft.F1TelemetryAdapter.F1_22_Packets
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

        public CarStatusPacket22(HeaderPacket header, Bytes bys) : base(header, bys)
        {
        }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {
                Name="CarStatusDatas",
                Type = typeof(CarStatusData22),
                Count=22,
                Children = new PacketField[]
                {
                    new PacketField {Name="TractionControl",TypeName = "uint8"},
                    new PacketField {Name="AntiLockBrakes",TypeName = "uint8"},
                    new PacketField {Name="FuelMix",TypeName = "uint8"},
                    new PacketField {Name="FrontBrakeBias",TypeName = "uint8"},
                    new PacketField {Name="PitLimiterStatus",TypeName = "uint8"},
                    new PacketField {Name="FuelInTank",TypeName = "float"},
                    new PacketField {Name="FuelCapacity",TypeName = "float"},
                    new PacketField {Name="FuelRemainingLaps",TypeName = "float"},
                    new PacketField {Name="MaxRPM",TypeName = "uint16"},
                    new PacketField {Name="IdleRPM",TypeName = "uint16"},
                    new PacketField {Name="MaxGears",TypeName = "uint8"},
                    new PacketField {Name="DrsAllowed",TypeName = "uint8"},
                    new PacketField {Name="DrsActivationDistance",TypeName = "uint16"},
                    new PacketField {Name="ActualTyreCompound",TypeName = "uint8"},
                    new PacketField {Name="VisualTyreCompound",TypeName = "uint8"},
                    new PacketField {Name="TyresAgeLaps",TypeName = "uint8"},
                    new PacketField {Name="VehicleFiaFlags",TypeName = "int8"},
                    new PacketField {Name="ErsStoreEnergy",TypeName = "float"},
                    new PacketField {Name="ErsDeployMode",TypeName = "uint8"},
                    new PacketField {Name="ErsHarvestedThisLapMGUK",TypeName = "float"},
                    new PacketField {Name="ErsHarvestedThisLapMGUH",TypeName = "float"},
                    new PacketField {Name="ErsDeployedThisLap",TypeName = "float"},
                    new PacketField {Name="NetworkPaused",TypeName = "uint8"}
                }
            }
        };
    }

    public class CarStatusData22 : CarStatusData21
    {
    }
}
