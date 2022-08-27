using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Helpers;
using NingSoft.F1TelemetryAdapter.Models;
using System.Text;

namespace NingSoft.F1TelemetryAdapter.F1_22_Packets
{
    /// <summary>
    /// This packet gives details of events that happen during the course of a session.
    /// Frequency: When the event occurs
    /// Size: 40 bytes
    /// Version: 1
    /// </summary>
    public class EventPacket21 : F1Packet
    {
        public override int PacketSize => 36;

        /// <summary>
        /// Event string code,
        /// see <see cref="EventCodes"/>
        /// </summary>
        public string EventStringCode;
        /// <summary>
        /// Event details - should be interpreted differently for each typ
        /// </summary>
        public EventDataDetail21 EventDetail;

        internal override void LoadPacket(Bytes bytes)
        {
            var codeBytes = bytes.GetBytes(bytes.Index, 4);
            EventStringCode = Encoding.UTF8.GetString(codeBytes);
            bytes.MoveIndex(4);

            var packetItem = new PacketItem { Name = "EventDetail" };
            switch (EventStringCode)
            {
                case EventCodes21.FastestLap:
                    packetItem.Type = typeof(FastestLap21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",TypeName = "uint8"},
                        new PacketItem {Name="lapTime",TypeName = "float"}
                    };
                    break;
                case EventCodes21.Retirement:
                    packetItem.Type = typeof(Retirement21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes21.TeammateInPits:
                    packetItem.Type = typeof(TeamMateInPits21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes21.RaceWinner:
                    packetItem.Type = typeof(RaceWinner21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes21.PenaltyIssued:
                    packetItem.Type = typeof(Penalty21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="PenaltyType",TypeName = "uint8"},
                        new PacketItem {Name="InfringementType",TypeName = "uint8"},
                        new PacketItem {Name="VehicleIdx",TypeName = "uint8"},
                        new PacketItem {Name="OtherVehicleIdx",TypeName = "uint8"},
                        new PacketItem {Name="Time",TypeName = "uint8"},
                        new PacketItem {Name="LapNum",TypeName = "uint8"},
                        new PacketItem {Name="PlacesGained",TypeName = "uint8"}
                    };
                    break;
                case EventCodes21.SpeedTrapTriggered:
                    packetItem.Type = typeof(SpeedTrap21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",TypeName = "uint8"},
                        new PacketItem {Name="Speed",TypeName = "float"},
                        new PacketItem {Name="IsOverallFastestInSession",TypeName = "uint8"},
                        new PacketItem {Name="IsDriverFastestInSession",TypeName = "uint8"},
                        new PacketItem {Name="FastestVehicleIdxInSession",TypeName = "uint8"},
                        new PacketItem {Name="FastestSpeedInSession",TypeName = "float"}
                    };
                    break;

                case EventCodes21.StartLights:
                    packetItem.Type = typeof(StartLights21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="NumLights",TypeName = "uint8"},
                    };
                    break;
                case EventCodes21.DriveThroughServed:
                    packetItem.Type = typeof(DriveThroughPenaltyServed21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes21.StopGoServed:
                    packetItem.Type = typeof(StopGoPenaltyServed21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",TypeName = "uint8"}
                    };
                    break;
                case EventCodes21.Flashback:
                    packetItem.Type = typeof(Flashback21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="FlashbackFrameIdentifier",TypeName = "uint32"},
                        new PacketItem {Name="FlashbackSessionTime",TypeName = "float"},
                    };
                    break;
                case EventCodes21.ButtonStatus:
                    packetItem.Type = typeof(Buttons21);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="ButtonStatus",TypeName = "uint32"}
                    };
                    break;
                default:
                    break;
            }

            if (packetItem.Type != null)
                new ItemList { packetItem }.LoadBytes(bytes, this);
        }

        internal override ItemList PacketItems => new ItemList { };
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
        /// Overall fastest speed in session = 1, otherwise 0
        /// </summary>
        //public byte IsOverallFastestInSession;
        /// <summary>
        /// Fastest speed for driver in session = 1, otherwise 0
        /// </summary>
        //public byte IsDriverFastestInSession;
        /// <summary>
        /// Vehicle index of the Vehicle that is the fastest in this session
        /// </summary>
        public byte FastestVehicleIdxInSession;
        /// <summary>
        /// Speed of the Vehicle that is the fastest in this session
        /// </summary>
        public float FastestSpeedInSession;
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

    public class EventCodes21
    {
        public const string SessionStarted = "SSTA";
        public const string SessionEnded = "SEND";
        public const string FastestLap = "FTLP";
        public const string Retirement = "RTMT";
        public const string DRSEnabled = "DRSE";
        public const string DRSFisabled = "DRSD";
        public const string TeammateInPits = "TMPT";
        public const string ChequeredFlag = "CHQF";
        public const string RaceWinner = "RCWN";
        public const string PenaltyIssued = "PENA";
        public const string SpeedTrapTriggered = "SPTP";
        public const string StartLights = "STLG";
        public const string LightsOut = "LGOT";
        public const string DriveThroughServed = "DTSV";
        public const string StopGoServed = "SGSV";
        public const string Flashback = "FLBK";
        public const string ButtonStatus = "BUTN";
    }
}
