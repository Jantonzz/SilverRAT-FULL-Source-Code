using System;
using System.IO;

namespace SilverRAT.MessagePack;

internal class WriteTools
{
    public static void WriteNull(Stream ms)
    {
        ms.WriteByte(192);
    }

    public static void WriteString(Stream ms, string strVal)
    {
        byte[] utf8Bytes;
        utf8Bytes = BytesTools.GetUtf8Bytes(strVal);
        byte[] array;
        array = null;
        int num;
        num = utf8Bytes.Length;
        byte b;
        b = 0;
        if (num <= 31)
        {
            ms.WriteByte((byte)(160 + (byte)num));
        }
        else if (num <= 255)
        {
            b = 217;
            ms.WriteByte(217);
            ms.WriteByte((byte)num);
        }
        else if (num <= 65535)
        {
            b = 218;
            ms.WriteByte(218);
            array = BytesTools.SwapBytes(BitConverter.GetBytes((short)num));
            ms.Write(array, 0, array.Length);
        }
        else
        {
            b = 219;
            ms.WriteByte(219);
            array = BytesTools.SwapBytes(BitConverter.GetBytes(num));
            ms.Write(array, 0, array.Length);
        }
        ms.Write(utf8Bytes, 0, utf8Bytes.Length);
    }

    public static void WriteBinary(Stream ms, byte[] rawBytes)
    {
        byte[] array;
        array = null;
        int num;
        num = rawBytes.Length;
        byte b;
        b = 0;
        if (num <= 255)
        {
            b = 196;
            ms.WriteByte(196);
            ms.WriteByte((byte)num);
        }
        else if (num <= 65535)
        {
            b = 197;
            ms.WriteByte(197);
            array = BytesTools.SwapBytes(BitConverter.GetBytes((short)num));
            ms.Write(array, 0, array.Length);
        }
        else
        {
            b = 198;
            ms.WriteByte(198);
            array = BytesTools.SwapBytes(BitConverter.GetBytes(num));
            ms.Write(array, 0, array.Length);
        }
        ms.Write(rawBytes, 0, rawBytes.Length);
    }

    public static void WriteFloat(Stream ms, double fVal)
    {
        ms.WriteByte(203);
        ms.Write(BytesTools.SwapDouble(fVal), 0, 8);
    }

    public static void WriteSingle(Stream ms, float fVal)
    {
        ms.WriteByte(202);
        ms.Write(BytesTools.SwapBytes(BitConverter.GetBytes(fVal)), 0, 4);
    }

    public static void WriteBoolean(Stream ms, bool bVal)
    {
        if (bVal)
        {
            ms.WriteByte(195);
        }
        else
        {
            ms.WriteByte(194);
        }
    }

    public static void WriteUInt64(Stream ms, ulong iVal)
    {
        ms.WriteByte(207);
        ms.Write(BytesTools.SwapBytes(BitConverter.GetBytes(iVal)), 0, 8);
    }

    public static void WriteInteger(Stream ms, long iVal)
    {
        if (iVal >= 0L)
        {
            if (iVal <= 127L)
            {
                ms.WriteByte((byte)iVal);
            }
            else if (iVal <= 255L)
            {
                ms.WriteByte(204);
                ms.WriteByte((byte)iVal);
            }
            else if (iVal <= 65535L)
            {
                ms.WriteByte(205);
                ms.Write(BytesTools.SwapInt16((short)iVal), 0, 2);
            }
            else if (iVal <= 4294967295L)
            {
                ms.WriteByte(206);
                ms.Write(BytesTools.SwapInt32((int)iVal), 0, 4);
            }
            else
            {
                ms.WriteByte(211);
                ms.Write(BytesTools.SwapInt64(iVal), 0, 8);
            }
        }
        else if (iVal <= -2147483648L)
        {
            ms.WriteByte(211);
            ms.Write(BytesTools.SwapInt64(iVal), 0, 8);
        }
        else if (iVal <= -32768L)
        {
            ms.WriteByte(210);
            ms.Write(BytesTools.SwapInt32((int)iVal), 0, 4);
        }
        else if (iVal <= -128L)
        {
            ms.WriteByte(209);
            ms.Write(BytesTools.SwapInt16((short)iVal), 0, 2);
        }
        else if (iVal <= -32L)
        {
            ms.WriteByte(208);
            ms.WriteByte((byte)iVal);
        }
        else
        {
            ms.WriteByte((byte)iVal);
        }
    }
}

