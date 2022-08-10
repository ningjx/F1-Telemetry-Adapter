using F1_Telemetry_Adapter.Enums;
using F1_Telemetry_Adapter.F1_Base_packets;
using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// This packet details the players currently in a multiplayer lobby. It details each player’s selected car, any AI involved in the game and also the ready status of each of the participants.
    /// Frequency: Two every second when in the lobby
    /// Size: 1191 bytes
    /// Version: 1
    /// </summary>
    public class LobbyInfoPacket22 : F1Packet
    {
        public override int PacketSize => 1191;

        /// <summary>
        /// Packet specific data
        /// </summary>
        public byte NumPlayers;
        /// <summary>
        /// Number of players in the lobby data
        /// </summary>
        public LobbyInfoData[] LobbyInfoData;

        public LobbyInfoPacket22(HeaderPacket header) : base(header) { }

        public LobbyInfoPacket22() { }

        internal override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name = "NumPlayers",TypeName = "uint8"},
            new PacketItem {
                Name = "LobbyInfoData",
                Type = typeof(LobbyInfoData),
                Count = 22,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="LobbyInfoData",Name="AiControlled",TypeName = "uint8"},
                    new PacketItem {ClassName="LobbyInfoData",Name="TeamId",TypeName = "uint8"},
                    new PacketItem {ClassName="LobbyInfoData",Name="Nationality",TypeName = "uint8"},
                    new PacketItem {ClassName="LobbyInfoData",Name="Name",TypeName = "char",Count = 48  },
                    new PacketItem {ClassName="LobbyInfoData",Name="CarNumber",TypeName = "uint8"},
                    new PacketItem {ClassName="LobbyInfoData",Name="ReadyStatus",TypeName = "uint8"}
                }
            }
        };
    }
    public class LobbyInfoData
    {
        /// <summary>
        /// Whether the vehicle is AI (1) or Human (0) controlled
        /// </summary>
        public byte AiControlled;
        /// <summary>
        /// Team id - see appendix (255 if no team currently selected)
        /// </summary>
        public byte TeamId;
        /// <summary>
        /// Nationality of the driver
        /// </summary>
        public byte Nationality;
        /// <summary>
        /// Name of participant in UTF-8 format – null terminated. Will be truncated with ... (U+2026) if too long
        /// </summary>
        public char[] Name;
        /// <summary>
        /// Car number of the player
        /// </summary>
        public byte CarNumber;
        /// <summary>
        /// 0 = not ready, 1 = ready, 2 = spectating
        /// </summary>
        public byte ReadyStatus;

        public Team _TeamID => (Team)TeamId;
        public Nationality _Nationality => (Nationality)Nationality;
        public ReadyStatus _ReadyStatus => (ReadyStatus)ReadyStatus;
    }

}
