﻿using NingSoft.F1TelemetryAdapter;
using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.F1_22_Packets;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;

namespace Templet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //this is the UDP packet data from F1 22
            var bytes = new byte[] { 230, 7, 1, 8, 1, 6, 238, 39, 24, 54, 168, 117, 184, 232, 223, 38, 190, 65, 166, 5, 0, 0, 19, 255, 88, 0, 0, 0, 0, 63, 177, 196, 105, 62, 0, 0, 0, 0, 0, 1, 17, 40, 0, 0, 0, 0, 217, 0, 216, 0, 62, 1, 62, 1, 74, 68, 69, 69, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 1, 0, 0, 85, 0, 152, 187, 184, 61, 28, 221, 77, 62, 0, 0, 0, 0, 0, 1, 85, 37, 0, 0, 0, 0, 83, 1, 83, 1, 236, 1, 236, 1, 68, 66, 68, 67, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 227, 0, 208, 242, 199, 61, 225, 143, 156, 188, 0, 0, 0, 0, 0, 6, 248, 41, 0, 0, 0, 0, 15, 1, 13, 1, 252, 0, 251, 0, 81, 88, 80, 82, 73, 73, 71, 71, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 124, 0, 0, 0, 0, 0, 0, 0, 0, 128, 0, 0, 0, 0, 0, 2, 82, 43, 0, 12, 0, 0, 205, 0, 203, 0, 37, 1, 35, 1, 81, 76, 70, 68, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 87, 0, 64, 226, 151, 62, 248, 42, 112, 62, 0, 0, 0, 0, 0, 1, 9, 39, 0, 0, 0, 0, 5, 1, 5, 1, 121, 1, 121, 1, 70, 66, 68, 67, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 84, 0, 0, 0, 0, 0, 99, 232, 160, 61, 0, 0, 0, 0, 0, 1, 22, 37, 0, 0, 0, 0, 123, 1, 123, 1, 33, 2, 33, 2, 67, 67, 68, 68, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 1, 0, 1, 0, 104, 0, 0, 0, 0, 63, 0, 0, 0, 128, 0, 0, 0, 0, 0, 1, 133, 46, 0, 100, 224, 127, 235, 0, 234, 0, 66, 1, 65, 1, 74, 69, 70, 68, 69, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 114, 0, 215, 182, 129, 61, 141, 168, 136, 187, 0, 0, 0, 0, 0, 2, 221, 39, 0, 0, 0, 0, 255, 0, 253, 0, 107, 1, 103, 1, 77, 74, 70, 69, 69, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 1, 0, 1, 0, 106, 0, 62, 47, 161, 62, 91, 206, 215, 60, 0, 0, 0, 0, 0, 2, 113, 37, 0, 0, 0, 0, 214, 0, 213, 0, 40, 1, 39, 1, 72, 69, 69, 68, 69, 69, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 85, 0, 49, 83, 190, 62, 65, 109, 101, 62, 0, 0, 0, 0, 0, 1, 53, 38, 0, 0, 0, 0, 37, 1, 37, 1, 170, 1, 170, 1, 68, 66, 67, 67, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 100, 0, 94, 249, 1, 63, 225, 10, 62, 62, 0, 0, 0, 0, 0, 1, 79, 46, 0, 97, 224, 127, 176, 0, 175, 0, 251, 0, 250, 0, 76, 72, 69, 68, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 84, 0, 80, 169, 133, 62, 169, 34, 194, 189, 0, 0, 0, 0, 0, 1, 155, 37, 0, 0, 0, 0, 177, 1, 177, 1, 105, 2, 105, 2, 69, 68, 69, 69, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 1, 0, 1, 0, 232, 0, 0, 0, 0, 0, 106, 200, 158, 188, 0, 0, 128, 63, 0, 6, 69, 40, 0, 0, 0, 0, 40, 1, 39, 1, 30, 1, 29, 1, 83, 90, 83, 84, 73, 73, 71, 71, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 168, 179, 21, 187, 0, 0, 0, 0, 0, 2, 105, 38, 0, 0, 0, 0, 206, 0, 205, 0, 28, 1, 26, 1, 72, 68, 69, 68, 69, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 229, 0, 0, 0, 0, 0, 13, 182, 107, 188, 10, 215, 35, 60, 0, 6, 103, 40, 0, 0, 0, 0, 233, 0, 231, 0, 208, 0, 206, 0, 82, 88, 82, 83, 73, 73, 71, 71, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 108, 0, 140, 22, 163, 62, 95, 221, 12, 61, 0, 0, 0, 0, 0, 2, 54, 38, 0, 0, 0, 0, 142, 0, 141, 0, 217, 0, 216, 0, 71, 69, 70, 68, 69, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 243, 0, 136, 55, 28, 63, 121, 165, 25, 189, 0, 0, 0, 0, 0, 6, 103, 43, 0, 14, 0, 0, 37, 1, 35, 1, 16, 1, 15, 1, 86, 94, 85, 86, 73, 73, 71, 71, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 0, 0, 85, 0, 60, 83, 129, 60, 137, 240, 244, 60, 0, 0, 0, 0, 0, 1, 80, 37, 0, 0, 0, 0, 202, 1, 202, 1, 147, 2, 147, 2, 70, 69, 71, 71, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 1, 0, 1, 0, 112, 0, 252, 195, 2, 63, 57, 194, 33, 62, 0, 0, 0, 0, 0, 2, 151, 40, 0, 0, 0, 0, 180, 0, 179, 0, 255, 0, 254, 0, 79, 74, 69, 68, 68, 68, 68, 68, 110, 0, 0, 0, 180, 65, 0, 0, 180, 65, 0, 0, 190, 65, 0, 0, 190, 65, 0, 0, 1, 0, 110, 0, 157, 156, 156, 62, 0, 0, 0, 128, 0, 0, 0, 0, 0, 2, 227, 38, 0, 0, 0, 0, 30, 0, 30, 0, 30, 0, 30, 0, 68, 67, 70, 69, 69, 68, 68, 68, 110, 0, 239, 75, 159, 65, 57, 6, 159, 65, 13, 253, 173, 65, 42, 230, 173, 65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0 };

            var pack = F1Adapter.GetF1Packet(bytes);
            //If your program works in different version of F1game like "F1 2020/F1 2021/F1 22",you need to parse the packet like below first,
            switch (pack.PacketHeader._GameSeries)
            {
                case GameSeries.G_2022:
                    //ba la ba la
                    break;
            }
            //or you don't care about the shit of GameSeries,just want some basic data fields,parse the packet to someone in namespace "NingSoft.F1TelemetryAdapter.F1_Base_packets" directly.
            switch (pack.PacketHeader._PacketType)
            {
                case PacketType.CarTelemetry:
                    var newPack = pack as CarTelemetryPacket22;
                    //float playerThrottle = newPack.CarTelemetryData[pack.PacketHeader.PlayerCarIndex].Throttle;
                    break;
            }

        }
    }
}
