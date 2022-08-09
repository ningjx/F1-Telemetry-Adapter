using F1_Telemetry_Adapter.Enums;
using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter.F1_22_Packets
{
    /// <summary>
    /// This packet details the players currently in a multiplayer lobby. It details each player’s selected car, any AI involved in the game and also the ready status of each of the participants.
    /// Frequency: Two every second when in the lobby
    /// Size: 1191 bytes
    /// Version: 1
    /// </summary>
    public class LobbyInfoPacket : F1Packet
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

        public LobbyInfoPacket(HeaderPacket header) : base(header) { }

        public LobbyInfoPacket() { }

        public override ItemList PacketItems => new ItemList
        {
            new PacketItem {Name = "NumPlayers",Type = typeof(byte)},
            new PacketItem {
                Name = "LobbyInfoData",
                Type = typeof(LobbyInfoData),
                Count = 22,
                Children = new PacketItem[]
                {
                    new PacketItem {ClassName="LobbyInfoData",Name="AiControlled",Type = typeof(byte)},
                    new PacketItem {ClassName="LobbyInfoData",Name="TeamId",Type = typeof(byte)},
                    new PacketItem {ClassName="LobbyInfoData",Name="Nationality",Type = typeof(byte)},
                    new PacketItem {ClassName="LobbyInfoData",Name="Name",Type = typeof(char),Count = 48  },
                    new PacketItem {ClassName="LobbyInfoData",Name="CarNumber",Type = typeof(byte)},
                    new PacketItem {ClassName="LobbyInfoData",Name="ReadyStatus",Type = typeof(byte)}
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
