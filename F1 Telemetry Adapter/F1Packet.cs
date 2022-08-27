using F1_Telemetry_Adapter.F1_Base_packets;
using F1_Telemetry_Adapter.Models;

namespace F1_Telemetry_Adapter
{
    public class F1Packet
    {
        /// <summary>
        /// 每个数据包都含有一个信息头
        /// </summary>
        public HeaderPacket PacketHeader { get; set; }

        /// <summary>
        /// 数据包格式
        /// </summary>
        internal virtual ItemList PacketItems { get; }

        /// <summary>
        /// 该数据包需要的字节长度
        /// </summary>
        public virtual int PacketSize { get; }

        internal virtual void LoadPacket(Bytes bytes) { }
    }
}
