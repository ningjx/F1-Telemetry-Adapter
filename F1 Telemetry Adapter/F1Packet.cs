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
        internal virtual FieldList Fields { get; } = new FieldList();

        /// <summary>
        /// 该数据包需要的字节长度
        /// </summary>
        public virtual int Length { get; }

        public F1Packet(HeaderPacket header, Bytes bys)
        {
            Header = header;

            if (bys != null)
            {
                Fields?.LoadBytes(bys, this);
                if (bys.Index != Length)
                    throw new F1_Exception($"Fields定义所需长度{bys.Index}不等于数据包要求长度{Length}。数据包名称{this.GetType().Name}");
            }
        }

        internal virtual void LoadPacket(Bytes bytes) { }

        public void CheckPacket()
        {
            var bys = new Bytes(new byte[0]);
            //跳过当前数据包header所需要的字节数
            bys.MoveIndex(Header.Length);
            this.Fields.MoveIndexToEnd(bys, this);
            if (bys.Index != Length)
                //Console.WriteLine($"定义错误 Fields定义长度:{bys.Index} 数据包定义Length:{Length} 数据包类型{this.GetType().Name}");
                throw new F1_Exception($"Fields定义所需长度{bys.Index}不等于数据包要求长度{Length}。数据包名称{this.GetType().Name}");
        }
    }
}
