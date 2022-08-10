using F1_Telemetry_Adapter.Enums;
using F1_Telemetry_Adapter.Models;
using System;

namespace F1_Telemetry_Adapter
{
    internal static class Helper
    {
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

        internal static byte[] GetBytes(this Bytes bytes, int start, int length)
        {
            var res = new byte[length];
            for (int i = 0; i < length; i++)
            {
                res[i] = bytes.byteData[i + start];
            }
            return res;
        }

        internal static Type ToType(this string typeStr)
        {
            if (string.IsNullOrEmpty(typeStr))
                return null;
            switch (typeStr)
            {
                case "uint8":
                    return typeof(byte);
                case "int8":
                    return typeof(sbyte);
                case "uint16":
                    return typeof(ushort);
                case "int16":
                    return typeof(short);
                case "uint32":
                    return typeof(uint);
                case "int32":
                    return typeof(int);
                case "float":
                    return typeof(float);
                case "double":
                    return typeof(double);
                case "uint64":
                    return typeof(ulong);
                case "int64":
                    return typeof(long);
                case "char":
                    return typeof(byte);

                default: return null;
            }
        }

        public static GameSeries GetGameVersion(this Bytes bytes)
        {
            return (GameSeries)BitConverter.ToUInt16(bytes.byteData, 0);
        }
    }
}
