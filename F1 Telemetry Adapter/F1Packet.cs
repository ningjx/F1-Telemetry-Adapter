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
    public class F1Packet
    {
        /// <summary>
        /// 每个数据包都含有一个信息头
        /// </summary>
        public HeaderPacket Header { get; set; }

        /// <summary>
        /// 数据包格式
        /// </summary>
        internal virtual FieldList Fields { get; }

        /// <summary>
        /// 该数据包需要的字节长度
        /// </summary>
        public virtual int Length { get; }

        public F1Packet(HeaderPacket header, Bytes bys)
        {
            //PacketHeader = F1Adapter.GetHeaderPacket(bytes, out Bytes bys);
            Header = header;

            if (bys != null)
                Fields?.LoadBytes(bys, this);
        }

        internal virtual void LoadPacket(Bytes bytes) { }
    }
}
