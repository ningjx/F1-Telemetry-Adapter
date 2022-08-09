using F1_Telemetry_Adapter.Models;
using System;

namespace F1_Telemetry_Adapter
{
    internal static class Helper
    {
        internal static object ConvertValue(this Bytes bytes, string type)
        {
            //"Single Double SByte Byte Int16 UInt16 UInt32 UInt64 Char"
            object res = null;
            switch (type)
            {
                case "Single":
                    res = BitConverter.ToSingle(bytes.ByteData, bytes.Index); bytes.Index += 4; break;
                case "Double":
                    res = BitConverter.ToDouble(bytes.ByteData, bytes.Index); bytes.Index += 8; break;
                case "SByte":
                    res = (sbyte)bytes.ByteData[bytes.Index]; bytes.Index += 1; break;
                case "Byte":
                    res = bytes.ByteData[bytes.Index]; bytes.Index += 1; break;
                case "Int16":
                    res = BitConverter.ToInt16(bytes.ByteData, bytes.Index); bytes.Index += 2; break;
                case "UInt16":
                    res = BitConverter.ToUInt16(bytes.ByteData, bytes.Index); bytes.Index += 2; break;
                case "UInt32":
                    res = BitConverter.ToUInt32(bytes.ByteData, bytes.Index); bytes.Index += 4; break;
                case "UInt64":
                    res = BitConverter.ToUInt64(bytes.ByteData, bytes.Index); bytes.Index += 8; break;
                case "Char":
                    res = bytes.ByteData[bytes.Index]; bytes.Index += 1; break;
                default:
                    bytes.Index += 0; return null;
            }

            return res;
        }

        internal static int GetTypeSize(string type)
        {
            switch (type)
            {
                case "Single":
                    return 4;
                case "Double":
                    return 8;
                case "SByte":
                    return 1;
                case "Byte":
                    return 1;
                case "Int16":
                    return 2;
                case "UInt16":
                    return 2;
                case "UInt32":
                    return 4;
                case "UInt64":
                    return 8;
                default: return 0;
            }
        }

        internal static byte[] GetBytes(this byte[] bytes, int start, int length)
        {
            var res = new byte[length];
            for (int i = 0; i < length; i++)
            {
                res[i] = bytes[i + start];
            }
            return res;
        }
    }
}
