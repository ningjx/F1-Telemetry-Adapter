using Microsoft.VisualStudio.TestTools.UnitTesting;
using NingSoft.F1TelemetryAdapter.F1_18_packets;
using NingSoft.F1TelemetryAdapter.F1_19_packets;
using NingSoft.F1TelemetryAdapter.F1_20_packets;
using NingSoft.F1TelemetryAdapter.F1_21_packets;
using NingSoft.F1TelemetryAdapter.F1_22_packets;

namespace UnitTest
{
    [TestClass]
    public class CheckPacketFieldsFormat
    {
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

        [TestCategory("检查数据包定义")]
        [TestMethod]
        public void CheckPacket20Format()
        {
            var h = new HeaderPacket20(null, null);

            new CarSetupsPacket20(h, null).CheckPacket();
            new CarTelemetryPacket20(h, null).CheckPacket();
            new CarStatusPacket20(h, null).CheckPacket();
            new FinalClassificationPacket20(h, null).CheckPacket();
            new LapDataPacket20(h, null).CheckPacket();
            new LobbyInfoPacket20(h, null).CheckPacket();
            new MotionPacket20(h, null).CheckPacket();
            new ParticipantsPacket20(h, null).CheckPacket();
            new SessionPacket20(h, null).CheckPacket();
        }

        [TestCategory("检查数据包定义")]
        [TestMethod]
        public void CheckPacket19Format()
        {
            var h = new HeaderPacket19(null, null);

            new CarTelemetryPacket19(h, null).CheckPacket();
            new CarSetupsPacket19(h, null).CheckPacket();
            new CarStatusPacket19(h, null).CheckPacket();
            new LapDataPacket19(h, null).CheckPacket();
            new MotionPacket19(h, null).CheckPacket();
            new ParticipantsPacket19(h, null).CheckPacket();
            new SessionPacket19(h, null).CheckPacket();
        }

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
