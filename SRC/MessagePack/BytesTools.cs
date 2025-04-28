using System;
using System.Text;

namespace SilverRAT.MessagePack;

public class BytesTools
{
    private static UTF8Encoding utf8Encode = new UTF8Encoding();

    public static byte[] GetUtf8Bytes(string s)
    {
        return BytesTools.utf8Encode.GetBytes(s);
    }

    public static string GetString(byte[] utf8Bytes)
    {
        return BytesTools.utf8Encode.GetString(utf8Bytes);
    }

    public static string BytesAsString(byte[] bytes)
    {
        StringBuilder stringBuilder;
        stringBuilder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            stringBuilder.Append($"{bytes[i]:D3} ");
        }
        return stringBuilder.ToString();
    }

    public static string BytesAsHexString(byte[] bytes)
    {
        StringBuilder stringBuilder;
        stringBuilder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            stringBuilder.Append($"{bytes[i]:X2} ");
        }
        return stringBuilder.ToString();
    }

    public static byte[] SwapBytes(byte[] v)
    {
        byte[] array;
        array = new byte[v.Length];
        int num;
        num = v.Length - 1;
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = v[num];
            num--;
        }
        return array;
    }

    public static byte[] SwapInt64(long v)
    {
        return BytesTools.SwapBytes(BitConverter.GetBytes(v));
    }

    public static byte[] SwapInt32(int v)
    {
        byte[] array;
        array = new byte[4];
        array[3] = (byte)v;
        array[2] = (byte)(v >> 8);
        array[1] = (byte)(v >> 16);
        array[0] = (byte)(v >> 24);
        return array;
    }

    public static byte[] SwapInt16(short v)
    {
        byte[] array;
        array = new byte[2];
        array[1] = (byte)v;
        array[0] = (byte)(v >> 8);
        return array;
    }

    public static byte[] SwapDouble(double v)
    {
        return BytesTools.SwapBytes(BitConverter.GetBytes(v));
    }
}

