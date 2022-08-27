using F1_Telemetry_Adapter.Enums;
using F1_Telemetry_Adapter.Models;
using System;

namespace F1_Telemetry_Adapter.Helpers
{
    internal static class Helper
    {
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
                case "uint":
                    return typeof(uint);
                case "int":
                    return typeof(int);

                default: return null;
            }
        }

        public static GameSeries GetGameVersion(this Bytes bytes)
        {
            return (GameSeries)BitConverter.ToUInt16(bytes.byteData, 0);
        }
    }
}
