using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Models;
using System.Text;

namespace NingSoft.F1TelemetryAdapter.F1_19_packets
{
    /// <summary>
    /// This is a list of participants in the race. If the vehicle is controlled by AI, then the name will be the driver name. If this is a multiplayer game, the names will be the Steam Id on PC, or the LAN name if appropriate.
    /// N.B.on Xbox One, the names will always be the driver name, on PS4 the name will be the LAN name if playing a LAN game, otherwise it will be the driver name.
    /// The array should be indexed by vehicle index.
    /// Frequency: Every 5 seconds
    /// Size: 1104 bytes
    /// Version: 1
    /// </summary>
    public class ParticipantsPacket19 : F1Packet
    {
        public override int Length => 1104;

        /// <summary>
        /// Number of active cars in the data – should match number of cars on HUD
        /// </summary>
        public byte NumActiveCars;

        public ParticipantData19[] Participants;

        public ParticipantsPacket19(HeaderPacket header, Bytes bys) : base(header, bys) { }

        internal override FieldList Fields => new FieldList
        {
            new PacketField {Name="NumActiveCars",TypeName = "uint8"},
            new PacketField
            {
                Name = "Participants",
                Type = typeof(ParticipantData19),
                Count = 20,
                Children = new PacketField[]
                {
                    new PacketField {Name="AiControlled",TypeName = "uint8"},
                    new PacketField {Name="DriverId",TypeName = "uint8"},
                    new PacketField {Name="TeamId",TypeName = "uint8"},
                    new PacketField {Name="RaceNumber",TypeName = "uint8"},
                    new PacketField {Name="Nationality",TypeName = "uint8"},
                    new PacketField {Name="Name",TypeName = "uint8",Count = 48},
                    new PacketField {Name="YourTelemetry",TypeName = "uint8"}
                }
            }
        };
    }

    public class ParticipantData19
    {
        /// <summary>
        /// Whether the vehicle is AI (1) or Human (0) controlled
        /// </summary>
        public byte AiControlled;
        /// <summary>
        /// Driver id - see appendix, 255 if network human
        /// </summary>
        public byte DriverId;
        /// <summary>
        /// Team id - see appendix
        /// </summary>
        public byte TeamId;
        /// <summary>
        /// Race number of the car
        /// </summary>
        public byte RaceNumber;
        /// <summary>
        /// Nationality of the driver
        /// </summary>
        public byte Nationality;
        /// <summary>
        /// Name of participant in UTF-8 format – null terminated. Will be truncated with … (U+2026) if too long
        /// </summary>
        public byte[] Name;
        /// <summary>
        /// The player's UDP setting, 0 = restricted, 1 = public
        /// </summary>
        public byte YourTelemetry;

        public string _Name => Encoding.UTF8.GetString(Name);
        public Driver _Driver => (Driver)DriverId;
    }
}
