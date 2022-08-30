using Microsoft.VisualStudio.TestTools.UnitTesting;
using NingSoft.F1TelemetryAdapter.F1_18_packets;
using NingSoft.F1TelemetryAdapter.F1_18_Packets;
using NingSoft.F1TelemetryAdapter.F1_21_packets;
using NingSoft.F1TelemetryAdapter.F1_21_Packets;
using NingSoft.F1TelemetryAdapter.F1_22_packets;
using NingSoft.F1TelemetryAdapter.F1_22_Packets;

namespace UnitTest
{
    public class CheckPacketFieldsFormat
    {/// <summary>
     /// 检测数据包定义是否正确
     /// </summary>
        [TestCategory("检查数据包定义")]
        [TestMethod]
        public void CheckPacket22Format()
        {
            var h = new HeaderPacket22(null, null);

            new CarSetupsPacket22(h, null).CheckPacket();
            new CarTelemetryPacket22(h, null).CheckPacket();
            new CarStatusPacket22(h, null).CheckPacket();
            new FinalClassificationPacket22(h, null).CheckPacket();
            new LapDataPacket22(h, null).CheckPacket();
            new LobbyInfoPacket22(h, null).CheckPacket();
            new MotionPacket22(h, null).CheckPacket();
            new ParticipantsPacket22(h, null).CheckPacket();
            new SessionHistoryPacket22(h, null).CheckPacket();
            new SessionPacket22(h, null).CheckPacket();
            new CarDamagePacket22(h, null).CheckPacket();
        }

        /// <summary>
        /// 检测数据包定义是否正确
        /// </summary>
        [TestCategory("检查数据包定义")]
        [TestMethod]
        public void CheckPacket21Format()
        {
            var h = new HeaderPacket21(null, null);

            new CarSetupsPacket21(h, null).CheckPacket();
            new CarTelemetryPacket21(h, null).CheckPacket();
            new CarStatusPacket21(h, null).CheckPacket();
            new FinalClassificationPacket21(h, null).CheckPacket();
            new LapDataPacket21(h, null).CheckPacket();
            new LobbyInfoPacket21(h, null).CheckPacket();
            new MotionPacket21(h, null).CheckPacket();
            new ParticipantsPacket21(h, null).CheckPacket();
            new SessionHistoryPacket21(h, null).CheckPacket();
            new SessionPacket21(h, null).CheckPacket();
            new CarDamagePacket21(h, null).CheckPacket();
        }

        /// <summary>
        /// 检测数据包定义是否正确
        /// </summary>
        [TestCategory("检查数据包定义")]
        [TestMethod]
        public void CheckPacket18Format()
        {
            var h = new HeaderPacket18(null, null);

            new CarSetupsPacket18(h, null).CheckPacket();
            new CarTelemetryPacket18(h, null).CheckPacket();
            new CarStatusPacket18(h, null).CheckPacket();
            new LapDataPacket18(h, null).CheckPacket();
            new MotionPacket18(h, null).CheckPacket();
            new ParticipantsPacket18(h, null).CheckPacket();
            new SessionPacket18(h, null).CheckPacket();
        }
    }
}
