using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Helpers;
using NingSoft.F1TelemetryAdapter.Models;
using System.Text;

namespace NingSoft.F1TelemetryAdapter.F1_19_packets
{
    /// <summary>
    /// This packet gives details of events that happen during the course of a session.
    /// Frequency: When the event occurs
    /// Size: 32 bytes
    /// </summary>
    public class EventPacket19 : F1Packet
    {
        public override int Length => 32;

        /// <summary>
        /// Event string code,
        /// see <see cref="EventCodes"/>
        /// </summary>
        public string EventStringCode;


        public EventPacket19(HeaderPacket header, Bytes bys) : base(header, null)
        {
            if (bys == null) return;

            var codeBytes = bys.GetBytes(bys.Index, 4);
            EventStringCode = Encoding.UTF8.GetString(codeBytes);

            var packetItem = new PacketField { Name = "EventDetail" };
            switch (EventStringCode)
            {
                case EventCodes.FastestLap:
                    packetItem.Type = typeof(FastestLap19);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"},
                        new PacketField {Name="lapTime",TypeName = "float"}
                    };
                    break;
                case EventCodes.TeammateInPits:
                    packetItem.Type = typeof(TeamMateInPits19);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.RaceWinner:
                    packetItem.Type = typeof(RaceWinner19);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.Retirement:
                    packetItem.Type = typeof(Retirement19);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                default:
                    break;
            }

            if (packetItem.Type != null)
                new FieldList { packetItem }.LoadBytes(bys, this);
        }

        public class EventDataDetail19 { }


        public class FastestLap19 : EventDataDetail19
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

        public class Retirement19 : EventDataDetail19
        {
            /// <summary>
            /// Vehicle index of car retiring
            /// </summary>
            public byte VehicleIdx;
        }

        public class TeamMateInPits19 : EventDataDetail19
        {
            /// <summary>
            /// Vehicle index of team mate
            /// </summary>
            public byte VehicleIdx;
        }

        public class RaceWinner19 : EventDataDetail19
        {
            /// <summary>
            /// Vehicle index of the race winner
            /// </summary>
            public byte VehicleIdx;
        }
    }
}
