using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Helpers;
using NingSoft.F1TelemetryAdapter.Models;
using System.Text;

namespace NingSoft.F1TelemetryAdapter.F1_21_packets
{
    /// <summary>
    /// This packet gives details of events that happen during the course of a session.
    /// Frequency: When the event occurs
    /// Size: 36 bytes
    /// Version: 1
    /// </summary>
    public class EventPacket21 : F1Packet
    {
        public override int Length => 36;

        /// <summary>
        /// Event string code,
        /// see <see cref="EventCodes"/>
        /// </summary>
        public string EventStringCode;
        /// <summary>
        /// Event details - should be interpreted differently for each typ
        /// </summary>
        public EventDataDetail21 EventDetail;

        public EventPacket21(HeaderPacket header, Bytes bys) : base(header, null)
        {
            if (bys == null) return;

            var codeBytes = bys.GetBytes(bys.Index, 4);
            EventStringCode = Encoding.UTF8.GetString(codeBytes);

            var packetItem = new PacketField { Name = "EventDetail" };
            switch (EventStringCode)
            {
                case EventCodes.FastestLap:
                    packetItem.Type = typeof(FastestLap21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"},
                        new PacketField {Name="lapTime",TypeName = "float"}
                    };
                    break;
                case EventCodes.Retirement:
                    packetItem.Type = typeof(Retirement21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.TeammateInPits:
                    packetItem.Type = typeof(TeamMateInPits21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.RaceWinner:
                    packetItem.Type = typeof(RaceWinner21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.PenaltyIssued:
                    packetItem.Type = typeof(Penalty21);
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
                    packetItem.Type = typeof(SpeedTrap21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"},
                        new PacketField {Name="Speed",TypeName = "float"},
                        new PacketField {Name="OverallFastestInSession",TypeName = "uint8"},
                        new PacketField {Name="DriverFastestInSession",TypeName = "uint8"}
                    };
                    break;

                case EventCodes.StartLights:
                    packetItem.Type = typeof(StartLights21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="NumLights",TypeName = "uint8"},
                    };
                    break;
                case EventCodes.DriveThroughServed:
                    packetItem.Type = typeof(DriveThroughPenaltyServed21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.StopGoServed:
                    packetItem.Type = typeof(StopGoPenaltyServed21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes.Flashback:
                    packetItem.Type = typeof(Flashback21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="FlashbackFrameIdentifier",TypeName = "uint32"},
                        new PacketField {Name="FlashbackSessionTime",TypeName = "float"},
                    };
                    break;
                case EventCodes.ButtonStatus:
                    packetItem.Type = typeof(Buttons21);
                    packetItem.Children = new PacketField[]
                    {
                        new PacketField {Name="ButtonStatus",TypeName = "uint32"}
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

    public class EventDataDetail21 { }


    public class FastestLap21 : EventDataDetail21
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

    public class Retirement21 : EventDataDetail21
    {
        /// <summary>
        /// Vehicle index of car retiring
        /// </summary>
        public byte VehicleIdx;
    }


    public class TeamMateInPits21 : EventDataDetail21
    {
        /// <summary>
        /// Vehicle index of team mate
        /// </summary>
        public byte VehicleIdx;
    }


    public class RaceWinner21 : EventDataDetail21
    {
        /// <summary>
        /// Vehicle index of the race winner
        /// </summary>
        public byte VehicleIdx;
    }

    public class Penalty21 : EventDataDetail21
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

    public class SpeedTrap21 : EventDataDetail21
    {
        /// <summary>
        /// Vehicle index of the Vehicle triggering speed trap
        /// </summary>
        public byte VehicleIdx;
        /// <summary>
        /// Top speed achieved in kilometres per hour
        /// </summary>
        public float Speed;
        /// <summary>
        /// Vehicle index of the Vehicle that is the fastest in this session
        /// </summary>
        public byte OverallFastestInSession;
        /// <summary>
        /// Speed of the Vehicle that is the fastest in this session
        /// </summary>
        public float DriverFastestInSession;
    }

    public class StartLights21 : EventDataDetail21
    {
        /// <summary>
        /// Number of lights showing
        /// </summary>
        public byte NumLights;
    }

    public class DriveThroughPenaltyServed21 : EventDataDetail21
    {
        /// <summary>
        /// Vehicle index of the Vehicle serving drive through
        /// </summary>
        public byte VehicleIdx;
    }

    public class StopGoPenaltyServed21 : EventDataDetail21
    {
        /// <summary>
        /// Vehicle index of the Vehicle serving stop go
        /// </summary>
        public byte VehicleIdx;
    }

    public class Flashback21 : EventDataDetail21
    {
        /// <summary>
        /// Frame identifier flashed back to
        /// </summary>
        public uint FlashbackFrameIdentifier;
        /// <summary>
        /// Session time flashed back to
        /// </summary>
        public float FlashbackSessionTime;
    }

    public class Buttons21 : EventDataDetail21
    {
        /// <summary>
        /// Bit flags specifying which buttons are being pressed currently - see appendices
        /// </summary>
        public uint ButtonStatus;
        public ButtonFlag _PressedButton => (ButtonFlag)ButtonStatus;
    }
}
