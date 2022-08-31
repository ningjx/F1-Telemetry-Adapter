using NingSoft.F1TelemetryAdapter.Enums;
using NingSoft.F1TelemetryAdapter.Exceptions;
using NingSoft.F1TelemetryAdapter.Models;
using System;
using System.Collections.Generic;

namespace NingSoft.F1TelemetryAdapter.Helpers
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
            bytes.MoveIndex(length);
            return res;
        }

        private static Dictionary<string, Type> TypeDic = new Dictionary<string, Type>
        {
            {"uint8",  typeof(byte)},
            {"int8",   typeof(sbyte)},
            {"uint16", typeof(ushort)},
            {"int16",  typeof(short)},
            {"uint32", typeof(uint)},
            {"int32",  typeof(int)},
            {"float",  typeof(float)},
            {"double", typeof(double)},
            {"uint64", typeof(ulong)},
            {"int64",  typeof(long)},
            {"char",   typeof(byte)},
            {"uint",   typeof(uint)},
            {"int",    typeof(int)},

        };

        internal static Type ToType(this string typeStr)
        {
            if (string.IsNullOrEmpty(typeStr))
                return null;
            else
            {
                if (!TypeDic.ContainsKey(typeStr))
                    throw new F1_Exception($"Undefine type in F1 data.typeStr={typeStr}");
                return TypeDic[typeStr];
            }
        }

        internal static GameSeries GetGameVersion(this Bytes bytes)
        {
            return (GameSeries)BitConverter.ToUInt16(bytes.byteData, 0);
        }
    }
}
