using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Helpers;
using NingSoft.F1TelemetryAdapter.Models;
using System.Text;

namespace NingSoft.F1TelemetryAdapter.F1_20_packets
{
    /// <summary>
    /// This packet gives details of events that happen during the course of a session.
    /// Frequency: When the event occurs
    /// Size: 35 bytes
    /// Version: 1
    /// </summary>
    public class EventPacket20 : F1Packet
    {
        public override int Length => 35;

        /// <summary>
        /// Event string code,
        /// see <see cref="EventCodes"/>
        /// </summary>
        public string EventStringCode;
        /// <summary>
        /// Event details - should be interpreted differently for each typ
        /// </summary>
        public EventDataDetail20 EventDetail;

        public EventPacket20(HeaderPacket header, Bytes bys) : base(header, null)
        {
            if (bys == null) return;

            var codeBytes = bys.GetBytes(bys.Index, 4);
            EventStringCode = Encoding.UTF8.GetString(codeBytes);

            var packetItem = new PacketField { Name = "EventDetail" };
            switch (EventStringCode)
            {
                case EventCodes.FastestLap:
                    packetItem.Type = typeof(FastestLap20);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"},
                        new PacketField {Name="lapTime",TypeName = "float"}
                    };
                    break;
                case EventCodes.Retirement:
                    packetItem.Type = typeof(Retirement20);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.TeammateInPits:
                    packetItem.Type = typeof(TeamMateInPits20);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.RaceWinner:
                    packetItem.Type = typeof(RaceWinner20);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.PenaltyIssued:
                    packetItem.Type = typeof(Penalty20);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="PenaltyType",TypeName = "uint8"},
                        new PacketField {Name="InfringementType",TypeName = "uint8"},
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"},
                        new PacketField {Name="OtherVehicleIdx",TypeName = "uint8"},
                        new PacketField {Name="Time",TypeName = "uint8"},
                        new PacketField {Name="LapNum",TypeName = "uint8"},
                        new PacketField {Name="PlacesGained",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.SpeedTrapTriggered:
                    packetItem.Type = typeof(SpeedTrap20);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"},
                        new PacketField {Name="Speed",TypeName = "float"}
                    };
                    break;
                default:
                    break;
            }

            if (packetItem.Type != null)
                new FieldList { packetItem }.LoadBytes(bys, this);
        }

        internal override FieldList Fields => new FieldList { };
    }

    public class EventDataDetail20 { }


    public class FastestLap20 : EventDataDetail20
    {
        /// <summary>
        /// Vehicle index of car achieving fastest lap
        /// </summary>
        public byte VehicleIdx;
        /// <summary>
        /// Lap time is in seconds
        /// </summary>
        public float lapTime;
    }

    public class Retirement20 : EventDataDetail20
    {
        /// <summary>
        /// Vehicle index of car retiring
        /// </summary>
        public byte VehicleIdx;
    }

    public class TeamMateInPits20 : EventDataDetail20
    {
        /// <summary>
        /// Vehicle index of team mate
        /// </summary>
        public byte VehicleIdx;
    }


    public class RaceWinner20 : EventDataDetail20
    {
        /// <summary>
        /// Vehicle index of the race winner
        /// </summary>
        public byte VehicleIdx;
    }

    public class Penalty20 : EventDataDetail20
    {
        /// <summary>
        /// Penalty type – see Appendices
        /// </summary>
        public byte PenaltyType;
        /// <summary>
        /// Infringement type – see Appendices
        /// </summary>
        public byte InfringementType;
        /// <summary>
        /// Vehicle index of the car the penalty is applied to
        /// </summary>
        public byte VehicleIdx;
        /// <summary>
        /// Vehicle index of the other car involved
        /// </summary>
        public byte OtherVehicleIdx;
        /// <summary>
        /// Time gained, or time spent doing action in seconds
        /// </summary>
        public byte Time;
        /// <summary>
        /// Lap the penalty occurred on
        /// </summary>
        public byte LapNum;
        /// <summary>
        /// Number of places gained by this
        /// </summary>
        public byte PlacesGained;
    }

    public class SpeedTrap20 : EventDataDetail20
    {
        /// <summary>
        /// Vehicle index of the Vehicle triggering speed trap
        /// </summary>
        public byte VehicleIdx;
        /// <summary>
        /// Top speed achieved in kilometres per hour
        /// </summary>
        public float Speed;
    }
}
