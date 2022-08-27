using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.Exceptions;
using NingSoft.F1TelemetryAdapter.F1_18_packets;
using NingSoft.F1TelemetryAdapter.F1_19_packets;
using NingSoft.F1TelemetryAdapter.F1_20_packets;
using NingSoft.F1TelemetryAdapter.F1_21_packets;
using NingSoft.F1TelemetryAdapter.F1_22_packets;
using NingSoft.F1TelemetryAdapter.F1_22_Packets;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Helpers;
using NingSoft.F1TelemetryAdapter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NingSoft.F1TelemetryAdapter
{
    public static class F1Adapter
    {
        /// <summary>
        /// 获取字节流中的信息头
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static HeaderPacket GetHeaderPacket(byte[] bytes)
        {
            var byteData = new Bytes(bytes);
            var version = byteData.GetGameVersion();
            HeaderPacket header;

            switch (version)
            {
                case GameSeries.G_2018:
                    header = new HeaderPacket18();
                    header.PacketItems.LoadBytes(byteData, header);
                    return header;

                case GameSeries.G_2019:
                    header = new HeaderPacket19();
                    header.PacketItems.LoadBytes(byteData, header);
                    return header;

                case GameSeries.G_2020:
                    header = new HeaderPacket20();
                    header.PacketItems.LoadBytes(byteData, header);
                    return header;

                case GameSeries.G_2021:
                    header = new HeaderPacket21();
                    header.PacketItems.LoadBytes(byteData, header);
                    return header;

                case GameSeries.G_2022:
                    header = new HeaderPacket22();
                    header.PacketItems.LoadBytes(byteData, header);
                    return header;

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
            var byteData = new Bytes(bytes);
            var version = byteData.GetGameVersion();

            switch (version)
            {
                case GameSeries.G_2022:
                    return GetPacket22(byteData);

                default: throw new F1_Exception("不支持的游戏版本");
            }
        }

        private static F1Packet GetPacket22(Bytes bytes)
        {
            var header = new HeaderPacket22();
            header.PacketItems.LoadBytes(bytes, header);

            if (header._PacketType == PacketType.Event)
            {
                var packet = new EventPacket22
                {
                    PacketHeader = header
                };
                packet.LoadPacket(bytes);
                return packet;
            }

            switch (header._PacketType)
            {
                case PacketType.CarTelemetry:
                    return LoadPacketByType<CarTelemetryPacket22>(header, bytes);
                case PacketType.CarStatus:
                    return LoadPacketByType<CarStatusPacket22>(header, bytes);
                case PacketType.CarSetups:
                    return LoadPacketByType<CarSetupsPacket22>(header, bytes);
                case PacketType.CarDamage:
                    return LoadPacketByType<CarDamagePacket22>(header, bytes);
                case PacketType.SessionHistory:
                    return LoadPacketByType<SessionHistoryPacket22>(header, bytes);
                case PacketType.LapData:
                    return LoadPacketByType<LapDataPacket22>(header, bytes);
                case PacketType.FinalClassification:
                    return LoadPacketByType<FinalClassificationPacket22>(header, bytes);
                case PacketType.LobbyInfo:
                    return LoadPacketByType<LobbyInfoPacket22>(header, bytes);
                case PacketType.Session:
                    return LoadPacketByType<SessionPacket21>(header, bytes);
                case PacketType.Participants:
                    return LoadPacketByType<ParticipantsPacket22>(header, bytes);
                case PacketType.Motion:
                    return LoadPacketByType<MotionPacket22>(header, bytes);
                default: return null;
            }
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
