using System;

namespace NingSoft.F1TelemetryAdapter.Models
{
    public class Bytes
    {
        public readonly byte[] byteData;
        private int index;
        public int Index => index;

        public Bytes(byte[] byteData, int index = 0)
        {
            this.byteData = byteData;
            this.index = index;
        }

        public void MoveIndex(int offset)
        {
            index += offset;
        }

        public object ConvertValue(string type)
        {
            object res = null;
            switch (type)
            {
                case "char":
                    res = byteData[index]; index += 1; break;
                case "uint8":
                    res = byteData[index]; index += 1; break;
                case "int8":
                    res = (sbyte)byteData[index]; index += 1; break;
                case "uint16":
                    res = BitConverter.ToUInt16(byteData, index); index += 2; break;
                case "int16":
                    res = BitConverter.ToInt16(byteData, index); index += 2; break;
                case "uint":
                case "uint32":
                    res = BitConverter.ToUInt32(byteData, index); index += 4; break;
                case "int":
                case "int32":
                    res = BitConverter.ToInt32(byteData, index); index += 4; break;
                case "float":
                    res = BitConverter.ToSingle(byteData, index); index += 4; break;
                case "double":
                    res = BitConverter.ToDouble(byteData, index); index += 8; break;
                case "uint64":
                    res = BitConverter.ToUInt64(byteData, index); index += 8; break;
                case "int64":
                    res = BitConverter.ToInt64(byteData, index); index += 8; break;
                default:
                    index += 0; return null;
            }

            return res;
        }

        public void MoveIndexByType(string type)
        {
            switch (type)
            {
                case "char":
                    index += 1; break;
                case "uint8":
                    index += 1; break;
                case "int8":
                    index += 1; break;
                case "uint16":
                    index += 2; break;
                case "int16":
                    index += 2; break;
                case "uint32":
                    index += 4; break;
                case "int32":
                    index += 4; break;
                case "float":
                    index += 4; break;
                case "double":
                    index += 8; break;
                case "uint64":
                    index += 8; break;
                case "int64":
                    index += 8; break;
                default:
                    index += 0; break;
            }
        }

        public object ConvertValue(Type type)
        {
            //"Single Double SByte Byte Int16 UInt16 UInt32 UInt64 Char"
            object res = null;
            switch (type.Name)
            {
                case "Single":
                    res = BitConverter.ToSingle(byteData, index); index += 4; break;
                case "Double":
                    res = BitConverter.ToDouble(byteData, index); index += 8; break;
                case "SByte":
                    res = (sbyte)byteData[index]; index += 1; break;
                case "Byte":
                    res = byteData[index]; index += 1; break;
                case "Int16":
                    res = BitConverter.ToInt16(byteData, index); index += 2; break;
                case "UInt16":
                    res = BitConverter.ToUInt16(byteData, index); index += 2; break;
                case "UInt32":
                    res = BitConverter.ToUInt32(byteData, index); index += 4; break;
                case "UInt64":
                    res = BitConverter.ToUInt64(byteData, index); index += 8; break;
                case "Char":
                    res = byteData[index]; index += 1; break;
                default:
                    index += 0; return null;
            }

            return res;
        }
    }

}
