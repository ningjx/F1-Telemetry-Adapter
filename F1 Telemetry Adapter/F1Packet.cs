using F1_Telemetry_Adapter.Enums;
using F1_Telemetry_Adapter.F1_22_Packets;
using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter
{
    public class F1Packet
    {
        /// <summary>
        /// 每个数据包都含有一个信息头
        /// </summary>
        public HeaderPacket PacketHeader { get; set; }

        public F1Packet(HeaderPacket header)
        {
            PacketHeader = header;
        }

        public F1Packet() { }

        /// <summary>
        /// 数据包格式
        /// </summary>
        public virtual ItemList PacketItems { get; }

        /// <summary>
        /// 该数据包需要的字节长度
        /// </summary>
        public virtual int PacketSize { get; }

        internal virtual void LoadPacket(Bytes bytes) { }

        /// <summary>
        /// 根据字节流自动生成对应的数据包
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static F1Packet GetPacket(byte[] bytes)
        {
            var byteData = new Bytes(bytes);

            var header = new HeaderPacket();
            header.PacketItems.LoadBytes(byteData, header);

            if (header._PacketType == PacketType.Event)
            {
                var packet = new EventPacket(header);
                packet.LoadPacket(byteData);
                return packet;
            }

            switch (header._PacketType)
            {
                case PacketType.CarTelemetry:
                    return LoadPacketByType<CarTelemetryPacket>(header, byteData);
                case PacketType.CarStatus:
                    return LoadPacketByType<CarStatusPacket>(header, byteData);
                case PacketType.CarSetups:
                    return LoadPacketByType<CarSetupsPacket>(header, byteData);
                case PacketType.CarDamage:
                    return LoadPacketByType<CarDamagePacket>(header, byteData);
                case PacketType.SessionHistory:
                    return LoadPacketByType<SessionHistoryPacket>(header, byteData);
                case PacketType.LapData:
                    return LoadPacketByType<LapDataPacket>(header, byteData);
                case PacketType.FinalClassification:
                    return LoadPacketByType<FinalClassificationPacket>(header, byteData);
                case PacketType.LobbyInfo:
                    return LoadPacketByType<LobbyInfoPacket>(header, byteData);
                case PacketType.Session:
                    return LoadPacketByType<SessionPacket>(header, byteData);
                case PacketType.Participants:
                    return LoadPacketByType<ParticipantsPacket>(header, byteData);
                case PacketType.Motion:
                    return LoadPacketByType<MotionPacket>(header, byteData);
                default: return null;
            }
        }

        /// <summary>
        /// 获取字节流中的信息头
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static HeaderPacket GetHeaderPacket(byte[] bytes)
        {
            HeaderPacket header = new HeaderPacket();
            header.PacketItems.LoadBytes(new Bytes(bytes), header);
            return header;
        }

        private static F1Packet LoadPacketByType<T>(HeaderPacket header, Bytes byteData) where T : F1Packet, new()
        {
            var packet = new T
            {
                PacketHeader = header
            };
            packet.PacketItems.LoadBytes(byteData, packet);
            return packet;
        }
    }
}
