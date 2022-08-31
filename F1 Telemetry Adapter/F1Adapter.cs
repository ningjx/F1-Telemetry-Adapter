using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.Exceptions;
using NingSoft.F1TelemetryAdapter.F1_18_packets;
using NingSoft.F1TelemetryAdapter.F1_19_packets;
using NingSoft.F1TelemetryAdapter.F1_20_packets;
using NingSoft.F1TelemetryAdapter.F1_21_packets;
using NingSoft.F1TelemetryAdapter.F1_22_packets;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Helpers;
using NingSoft.F1TelemetryAdapter.Models;

namespace NingSoft.F1TelemetryAdapter
{
    public static class F1Adapter
    {
        /// <summary>
        /// 获取字节流中的信息头
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static HeaderPacket GetHeaderPacket(byte[] bytes, out Bytes bys)
        {
            bys = new Bytes(bytes);
            var version = bys.GetGameVersion();

            switch (version)
            {
                case GameSeries.G_2018: return new HeaderPacket18(null, bys);

                case GameSeries.G_2019: return new HeaderPacket19(null, bys);

                case GameSeries.G_2020: return new HeaderPacket20(null, bys);

                case GameSeries.G_2021: return new HeaderPacket21(null, bys);

                case GameSeries.G_2022: return new HeaderPacket22(null, bys);

                default: throw new F1_Exception("不支持的游戏版本");
            }
        }

        /// <summary>
        /// 根据字节流自动生成对应的数据包
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static F1Packet GetF1Packet(byte[] bytes)
        {
            var header = GetHeaderPacket(bytes, out Bytes bys);

            switch (header._GameSeries)
            {
                case GameSeries.G_2018:
                    return GetPacket18(header, bys);
                case GameSeries.G_2019:
                    return GetPacket19(header, bys);
                case GameSeries.G_2020:
                    return GetPacket20(header, bys);
                case GameSeries.G_2021:
                    return GetPacket21(header, bys);
                case GameSeries.G_2022:
                    return GetPacket22(header, bys);

                default: throw new F1_Exception("不支持的游戏版本");
            }
        }

        private static F1Packet GetPacket22(HeaderPacket header, Bytes bytes)
        {
            switch (header._PacketType)
            {
                case PacketType.CarTelemetry:
                    return new CarTelemetryPacket22(header, bytes);
                case PacketType.CarStatus:
                    return new CarStatusPacket22(header, bytes);
                case PacketType.CarSetups:
                    return new CarSetupsPacket22(header, bytes);
                case PacketType.CarDamage:
                    return new CarDamagePacket22(header, bytes);
                case PacketType.SessionHistory:
                    return new SessionHistoryPacket22(header, bytes);
                case PacketType.LapData:
                    return new LapDataPacket22(header, bytes);
                case PacketType.FinalClassification:
                    return new FinalClassificationPacket22(header, bytes);
                case PacketType.LobbyInfo:
                    return new LobbyInfoPacket22(header, bytes);
                case PacketType.Session:
                    return new SessionPacket22(header, bytes);
                case PacketType.Participants:
                    return new ParticipantsPacket22(header, bytes);
                case PacketType.Motion:
                    return new MotionPacket22(header, bytes);
                case PacketType.Event:
                    return new EventPacket22(header, bytes);
                default: return null;
            }
        }
        private static F1Packet GetPacket21(HeaderPacket header, Bytes bytes)
        {
            switch (header._PacketType)
            {
                case PacketType.CarTelemetry:
                    return new CarTelemetryPacket21(header, bytes);
                case PacketType.CarStatus:
                    return new CarStatusPacket21(header, bytes);
                case PacketType.CarSetups:
                    return new CarSetupsPacket21(header, bytes);
                case PacketType.CarDamage:
                    return new CarDamagePacket21(header, bytes);
                case PacketType.SessionHistory:
                    return new SessionHistoryPacket21(header, bytes);
                case PacketType.LapData:
                    return new LapDataPacket21(header, bytes);
                case PacketType.FinalClassification:
                    return new FinalClassificationPacket21(header, bytes);
                case PacketType.LobbyInfo:
                    return new LobbyInfoPacket21(header, bytes);
                case PacketType.Session:
                    return new SessionPacket21(header, bytes);
                case PacketType.Participants:
                    return new ParticipantsPacket21(header, bytes);
                case PacketType.Motion:
                    return new MotionPacket21(header, bytes);
                case PacketType.Event:
                    return new EventPacket21(header, bytes);
                default: return null;
            }
        }
        private static F1Packet GetPacket20(HeaderPacket header, Bytes bytes)
        {
            switch (header._PacketType)
            {
                case PacketType.CarTelemetry:
                    return new CarTelemetryPacket20(header, bytes);
                case PacketType.CarStatus:
                    return new CarStatusPacket20(header, bytes);
                case PacketType.CarSetups:
                    return new CarSetupsPacket20(header, bytes);
                case PacketType.LapData:
                    return new LapDataPacket20(header, bytes);
                case PacketType.FinalClassification:
                    return new FinalClassificationPacket20(header, bytes);
                case PacketType.LobbyInfo:
                    return new LobbyInfoPacket20(header, bytes);
                case PacketType.Session:
                    return new SessionPacket20(header, bytes);
                case PacketType.Participants:
                    return new ParticipantsPacket20(header, bytes);
                case PacketType.Motion:
                    return new MotionPacket20(header, bytes);
                case PacketType.Event:
                    return new EventPacket20(header, bytes);
                default: return null;
            }
        }
        private static F1Packet GetPacket19(HeaderPacket header, Bytes bytes)
        {
            switch (header._PacketType)
            {
                case PacketType.CarTelemetry:
                    return new CarTelemetryPacket19(header, bytes);
                case PacketType.CarStatus:
                    return new CarStatusPacket19(header, bytes);
                case PacketType.CarSetups:
                    return new CarSetupsPacket19(header, bytes);
                case PacketType.LapData:
                    return new LapDataPacket19(header, bytes);
                case PacketType.Session:
                    return new SessionPacket19(header, bytes);
                case PacketType.Participants:
                    return new ParticipantsPacket19(header, bytes);
                case PacketType.Motion:
                    return new MotionPacket19(header, bytes);
                case PacketType.Event:
                    return new EventPacket19(header, bytes);
                default: return null;
            }
        }
        private static F1Packet GetPacket18(HeaderPacket header, Bytes bytes)
        {
            switch (header._PacketType)
            {
                case PacketType.CarTelemetry:
                    return new CarTelemetryPacket18(header, bytes);
                case PacketType.CarStatus:
                    return new CarStatusPacket18(header, bytes);
                case PacketType.CarSetups:
                    return new CarSetupsPacket18(header, bytes);
                case PacketType.LapData:
                    return new LapDataPacket18(header, bytes);
                case PacketType.Session:
                    return new SessionPacket18(header, bytes);
                case PacketType.Participants:
                    return new ParticipantsPacket18(header, bytes);
                case PacketType.Motion:
                    return new MotionPacket18(header, bytes);
                case PacketType.Event:
                    return new EventPacket18(header, bytes);
                default: return null;
            }
        }
    }
}
