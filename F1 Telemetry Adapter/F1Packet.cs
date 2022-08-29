using NingSoft.F1TelemetryAdapter.Exceptions;
using NingSoft.F1TelemetryAdapter.F1_Base_packets;
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
            {
                if (bys.byteData.Length != Length)
                    throw new F1_Exception($"输入字节长度{bys.byteData.Length}小于数据包要求长度{Length}。数据包名称{this.GetType().Name}");
                Fields?.LoadBytes(bys, this);
            }
        }

        public F1Packet() { }

        internal virtual void LoadPacket(Bytes bytes) { }

        public void CheckPacket()
        {
            var bys = new Bytes(new byte[0]);
            bys.MoveIndex(24);
            this.Fields?.MoveIndexToEnd(bys, this);
            if (bys.Index != Length)
                throw new F1_Exception($"字节长度{bys.Index}不等于数据包要求长度{Length}。数据包名称{this.GetType().Name}");
        }
    }
}
