using NingSoft.F1TelemetryAdapter.F1_Base_packets;
using NingSoft.F1TelemetryAdapter.Helpers;
using NingSoft.F1TelemetryAdapter.Models;
using System.Text;

namespace NingSoft.F1TelemetryAdapter.F1_18_packets
{
    /// <summary>
    /// This packet gives details of events that happen during the course of a session.
    /// Frequency: When the event occurs
    /// Size: 25 bytes
    /// </summary>
    public class EventPacket18 : F1Packet
    {
        public override int Length => 25;

        /// <summary>
        /// Event string code,
        /// see <see cref="EventCodes"/>
        /// </summary>
        public string EventStringCode;


        public EventPacket18(HeaderPacket header, Bytes bys) : base(header, null)
        {
            if (bys == null) return;

            var codeBytes = bys.GetBytes(bys.Index, 4);
            EventStringCode = Encoding.UTF8.GetString(codeBytes);
        }
    }
}
