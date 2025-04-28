using System;
using System.IO;

namespace SilverRAT.MessagePack;

internal class ReadTools
{
    public static string ReadString(Stream ms, int len)
    {
        byte[] array;
        array = new byte[len];
        ms.Read(array, 0, len);
        return BytesTools.GetString(array);
    }

    public static string ReadString(Stream ms)
    {
        return ReadTools.ReadString((byte)ms.ReadByte(), ms);
    }

    public static string ReadString(byte strFlag, Stream ms)
    {
        byte[] array;
        array = null;
        int num;
        num = 0;
        if (strFlag >= 160 && strFlag <= 191)
        {
            num = strFlag - 160;
        }
        else
        {
            switch (strFlag)
            {
                case 217:
                    num = ms.ReadByte();
                    break;
                case 218:
                    array = new byte[2];
                    ms.Read(array, 0, 2);
                    num = BitConverter.ToUInt16(BytesTools.SwapBytes(array), 0);
                    break;
                case 219:
                    array = new byte[4];
                    ms.Read(array, 0, 4);
                    num = BitConverter.ToInt32(BytesTools.SwapBytes(array), 0);
                    break;
            }
        }
        array = new byte[num];
        ms.Read(array, 0, num);
        return BytesTools.GetString(array);
    }
}


