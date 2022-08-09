﻿using F1_Telemetry_Adapter.Enums;
using F1_Telemetry_Adapter.Models;
using System.Text;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// This packet gives details of events that happen during the course of a session.
    /// Frequency: When the event occurs
    /// Size: 40 bytes
    /// Version: 1
    /// </summary>
    public class EventPacket : F1Packet
    {
        public override int PacketSize => 40;

        /// <summary>
        /// Event string code,
        /// see <see cref="EventCodes"/>
        /// </summary>
        public string EventStringCode;
        /// <summary>
        /// Event details - should be interpreted differently for each typ
        /// </summary>
        public EventDataDetail EventDetail;

        public EventPacket(HeaderPacket header) : base(header) { }

        public EventPacket() { }

        internal override void LoadPacket(Bytes bytes)
        {
            var codeBytes = bytes.ByteData.GetBytes(bytes.Index, 4);
            EventStringCode = Encoding.UTF8.GetString(codeBytes);
            bytes.Index += 4;

            var packetItem = new PacketItem { Name = "EventDetail" };
            switch (EventStringCode)
            {
                case EventCodes.FastestLap:
                    packetItem.Type = typeof(FastestLap);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",Type = typeof(byte)},
                        new PacketItem {Name="lapTime",Type = typeof(float)}
                    };
                    break;
                case EventCodes.Retirement:
                    packetItem.Type = typeof(Retirement);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",Type = typeof(byte)}
                    };
                    break;
                case EventCodes.TeammateInPits:
                    packetItem.Type = typeof(TeamMateInPits);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",Type = typeof(byte)}
                    };
                    break;
                case EventCodes.RaceWinner:
                    packetItem.Type = typeof(RaceWinner);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",Type = typeof(byte)}
                    };
                    break;
                case EventCodes.PenaltyIssued:
                    packetItem.Type = typeof(Penalty);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="PenaltyType",Type = typeof(byte)},
                        new PacketItem {Name="InfringementType",Type = typeof(byte)},
                        new PacketItem {Name="VehicleIdx",Type = typeof(byte)},
                        new PacketItem {Name="OtherVehicleIdx",Type = typeof(byte)},
                        new PacketItem {Name="Time",Type = typeof(byte)},
                        new PacketItem {Name="LapNum",Type = typeof(byte)},
                        new PacketItem {Name="PlacesGained",Type = typeof(byte)}
                    };
                    break;
                case EventCodes.SpeedTrapTriggered:
                    packetItem.Type = typeof(SpeedTrap);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",Type = typeof(byte)},
                        new PacketItem {Name="Speed",Type = typeof(float)},
                        new PacketItem {Name="IsOverallFastestInSession",Type = typeof(byte)},
                        new PacketItem {Name="IsDriverFastestInSession",Type = typeof(byte)},
                        new PacketItem {Name="FastestVehicleIdxInSession",Type = typeof(byte)},
                        new PacketItem {Name="FastestSpeedInSession",Type = typeof(float)}
                    };
                    break;

                case EventCodes.StartLights:
                    packetItem.Type = typeof(StartLights);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="NumLights",Type = typeof(byte)},
                    };
                    break;
                case EventCodes.DriveThroughServed:
                    packetItem.Type = typeof(DriveThroughPenaltyServed);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",Type = typeof(byte)}
                    };
                    break;
                case EventCodes.StopGoServed:
                    packetItem.Type = typeof(StopGoPenaltyServed);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="VehicleIdx",Type = typeof(byte)}
                    };
                    break;
                case EventCodes.Flashback:
                    packetItem.Type = typeof(Flashback);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="FlashbackFrameIdentifier",Type = typeof(uint)},
                        new PacketItem {Name="FlashbackSessionTime",Type = typeof(float)},
                    };
                    break;
                case EventCodes.ButtonStatus:
                    packetItem.Type = typeof(Buttons);
                    packetItem.Children = new PacketItem[]
                    {
                        new PacketItem {Name="ButtonStatus",Type = typeof(uint)}
                    };
                    break;
                default:
                    break;
            }

            if (packetItem.Type != null)
                new ItemList { packetItem }.LoadBytes(bytes, this);
        }

        public override ItemList PacketItems => new ItemList { };
    }

    public class EventDataDetail { }


    public class FastestLap : EventDataDetail
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

    public class Retirement : EventDataDetail
    {
        /// <summary>
        /// Vehicle index of car retiring
        /// </summary>
        public byte VehicleIdx;
    }


    public class TeamMateInPits : EventDataDetail
    {
        /// <summary>
        /// Vehicle index of team mate
        /// </summary>
        public byte VehicleIdx;
    }


    public class RaceWinner : EventDataDetail
    {
        /// <summary>
        /// Vehicle index of the race winner
        /// </summary>
        public byte VehicleIdx;
    }

    public class Penalty : EventDataDetail
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

    public class SpeedTrap : EventDataDetail
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
        public byte IsOverallFastestInSession;
        /// <summary>
        /// Fastest speed for driver in session = 1, otherwise 0
        /// </summary>
        public byte IsDriverFastestInSession;
        /// <summary>
        /// Vehicle index of the Vehicle that is the fastest in this session
        /// </summary>
        public byte FastestVehicleIdxInSession;
        /// <summary>
        /// Speed of the Vehicle that is the fastest in this session
        /// </summary>
        public float FastestSpeedInSession;
    }

    public class StartLights : EventDataDetail
    {
        /// <summary>
        /// Number of lights showing
        /// </summary>
        public byte NumLights;
    }

    public class DriveThroughPenaltyServed : EventDataDetail
    {
        /// <summary>
        /// Vehicle index of the Vehicle serving drive through
        /// </summary>
        public byte VehicleIdx;
    }

    public class StopGoPenaltyServed : EventDataDetail
    {
        /// <summary>
        /// Vehicle index of the Vehicle serving stop go
        /// </summary>
        public byte VehicleIdx;
    }

    public class Flashback : EventDataDetail
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

    public class Buttons : EventDataDetail
    {
        /// <summary>
        /// Bit flags specifying which buttons are being pressed currently - see appendices
        /// </summary>
        public uint ButtonStatus;
        public ButtonFlag _PressedButton => (ButtonFlag)ButtonStatus;
    }

    public class EventCodes
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
