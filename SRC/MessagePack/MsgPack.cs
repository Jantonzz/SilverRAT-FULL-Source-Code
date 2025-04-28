using SilverRAT.Algorithm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SilverRAT.MessagePack;

public class MsgPack : IEnumerable
{
    private string name;

    private string lowerName;

    private object innerValue;

    private MsgPackType valueType;

    private MsgPack parent;

    private List<MsgPack> children = new List<MsgPack>();

    private MsgPackArray refAsArray;

    public string AsString
    {
        get
        {
            return this.GetAsString();
        }
        set
        {
            this.SetAsString(value);
        }
    }

    public long AsInteger
    {
        get
        {
            return this.GetAsInteger();
        }
        set
        {
            this.SetAsInteger(value);
        }
    }

    public double AsFloat
    {
        get
        {
            return this.GetAsFloat();
        }
        set
        {
            this.SetAsFloat(value);
        }
    }

    public MsgPackArray AsArray
    {
        get
        {
            lock (this)
            {
                if (this.refAsArray == null)
                {
                    this.refAsArray = new MsgPackArray(this, this.children);
                }
            }
            return this.refAsArray;
        }
    }

    public MsgPackType ValueType => this.valueType;

    private void SetName(string value)
    {
        this.name = value;
        this.lowerName = this.name.ToLower();
    }

    private void Clear()
    {
        for (int i = 0; i < this.children.Count; i++)
        {
            this.children[i].Clear();
        }
        this.children.Clear();
    }

    private MsgPack InnerAdd()
    {
        MsgPack msgPack;
        msgPack = new MsgPack();
        msgPack.parent = this;
        this.children.Add(msgPack);
        return msgPack;
    }

    private int IndexOf(string name)
    {
        int num;
        num = -1;
        int result;
        result = -1;
        string text;
        text = name.ToLower();
        foreach (MsgPack child in this.children)
        {
            num++;
            if (text.Equals(child.lowerName))
            {
                return num;
            }
        }
        return result;
    }

    public MsgPack FindObject(string name)
    {
        int num;
        num = this.IndexOf(name);
        if (num == -1)
        {
            return null;
        }
        return this.children[num];
    }

    private MsgPack InnerAddMapChild()
    {
        if (this.valueType != MsgPackType.Map)
        {
            this.Clear();
            this.valueType = MsgPackType.Map;
        }
        return this.InnerAdd();
    }

    private MsgPack InnerAddArrayChild()
    {
        if (this.valueType != MsgPackType.Array)
        {
            this.Clear();
            this.valueType = MsgPackType.Array;
        }
        return this.InnerAdd();
    }

    public MsgPack AddArrayChild()
    {
        return this.InnerAddArrayChild();
    }

    private void WriteMap(Stream ms)
    {
        int count;
        count = this.children.Count;
        if (count <= 15)
        {
            ms.WriteByte((byte)(128 + (byte)count));
        }
        else if (count <= 65535)
        {
            byte b;
            b = 222;
            ms.WriteByte(222);
            byte[] array;
            array = BytesTools.SwapBytes(BitConverter.GetBytes((short)count));
            ms.Write(array, 0, array.Length);
        }
        else
        {
            byte b;
            b = 223;
            ms.WriteByte(223);
            byte[] array;
            array = BytesTools.SwapBytes(BitConverter.GetBytes(count));
            ms.Write(array, 0, array.Length);
        }
        for (int i = 0; i < count; i++)
        {
            WriteTools.WriteString(ms, this.children[i].name);
            this.children[i].Encode2Stream(ms);
        }
    }

    private void WirteArray(Stream ms)
    {
        int count;
        count = this.children.Count;
        if (count <= 15)
        {
            ms.WriteByte((byte)(144 + (byte)count));
        }
        else if (count <= 65535)
        {
            byte b;
            b = 220;
            ms.WriteByte(220);
            byte[] array;
            array = BytesTools.SwapBytes(BitConverter.GetBytes((short)count));
            ms.Write(array, 0, array.Length);
        }
        else
        {
            byte b;
            b = 221;
            ms.WriteByte(221);
            byte[] array;
            array = BytesTools.SwapBytes(BitConverter.GetBytes(count));
            ms.Write(array, 0, array.Length);
        }
        for (int i = 0; i < count; i++)
        {
            this.children[i].Encode2Stream(ms);
        }
    }

    public void SetAsInteger(long value)
    {
        this.innerValue = value;
        this.valueType = MsgPackType.Integer;
    }

    public void SetAsUInt64(ulong value)
    {
        this.innerValue = value;
        this.valueType = MsgPackType.UInt64;
    }

    public ulong GetAsUInt64()
    {
        return this.valueType switch
        {
            MsgPackType.String => ulong.Parse(this.innerValue.ToString().Trim()),
            MsgPackType.Integer => Convert.ToUInt64((long)this.innerValue),
            MsgPackType.UInt64 => (ulong)this.innerValue,
            MsgPackType.Float => Convert.ToUInt64((double)this.innerValue),
            MsgPackType.Single => Convert.ToUInt64((float)this.innerValue),
            MsgPackType.DateTime => Convert.ToUInt64((DateTime)this.innerValue),
            _ => 0uL,
        };
    }

    public long GetAsInteger()
    {
        return this.valueType switch
        {
            MsgPackType.String => long.Parse(this.innerValue.ToString().Trim()),
            MsgPackType.Integer => (long)this.innerValue,
            MsgPackType.UInt64 => Convert.ToInt64((long)this.innerValue),
            MsgPackType.Float => Convert.ToInt64((double)this.innerValue),
            MsgPackType.Single => Convert.ToInt64((float)this.innerValue),
            MsgPackType.DateTime => Convert.ToInt64((DateTime)this.innerValue),
            _ => 0L,
        };
    }

    public double GetAsFloat()
    {
        return this.valueType switch
        {
            MsgPackType.String => double.Parse((string)this.innerValue),
            MsgPackType.Integer => Convert.ToDouble((long)this.innerValue),
            MsgPackType.Float => (double)this.innerValue,
            MsgPackType.Single => (float)this.innerValue,
            MsgPackType.DateTime => Convert.ToInt64((DateTime)this.innerValue),
            _ => 0.0,
        };
    }

    public void SetAsBytes(byte[] value)
    {
        this.innerValue = value;
        this.valueType = MsgPackType.Binary;
    }

    public byte[] GetAsBytes()
    {
        return this.valueType switch
        {
            MsgPackType.String => BytesTools.GetUtf8Bytes(this.innerValue.ToString()),
            MsgPackType.Integer => BitConverter.GetBytes((long)this.innerValue),
            MsgPackType.Float => BitConverter.GetBytes((double)this.innerValue),
            MsgPackType.Single => BitConverter.GetBytes((float)this.innerValue),
            MsgPackType.DateTime => BitConverter.GetBytes(((DateTime)this.innerValue).ToBinary()),
            MsgPackType.Binary => (byte[])this.innerValue,
            _ => new byte[0],
        };
    }

    public void Add(string key, string value)
    {
        MsgPack msgPack;
        msgPack = this.InnerAddArrayChild();
        msgPack.name = key;
        msgPack.SetAsString(value);
    }

    public void Add(string key, int value)
    {
        MsgPack msgPack;
        msgPack = this.InnerAddArrayChild();
        msgPack.name = key;
        msgPack.SetAsInteger(value);
    }

    public async Task<bool> LoadFileAsBytes(string fileName)
    {
        if (File.Exists(fileName))
        {
            FileStream fs;
            fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] value;
            value = new byte[fs.Length];
            await fs.ReadAsync(value, 0, (int)fs.Length);
            await fs.FlushAsync();
            fs.Close();
            fs.Dispose();
            this.SetAsBytes(value);
            return true;
        }
        return false;
    }

    public async Task<bool> SaveBytesToFile(string fileName)
    {
        if (this.innerValue != null)
        {
            FileStream fs;
            fs = new FileStream(fileName, FileMode.Append);
            await fs.WriteAsync((byte[])this.innerValue, 0, ((byte[])this.innerValue).Length);
            await fs.FlushAsync();
            fs.Close();
            fs.Dispose();
            return true;
        }
        return false;
    }

    public MsgPack ForcePathObject(string path)
    {
        MsgPack msgPack;
        msgPack = this;
        string[] array;
        array = path.Trim().Split('.', '/', '\\');
        string text;
        text = null;
        if (array.Length == 0)
        {
            return null;
        }
        if (array.Length > 1)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                text = array[i];
                MsgPack msgPack2;
                msgPack2 = msgPack.FindObject(text);
                if (msgPack2 == null)
                {
                    msgPack = msgPack.InnerAddMapChild();
                    msgPack.SetName(text);
                }
                else
                {
                    msgPack = msgPack2;
                }
            }
        }
        text = array[array.Length - 1];
        int num;
        num = msgPack.IndexOf(text);
        if (num > -1)
        {
            return msgPack.children[num];
        }
        msgPack = msgPack.InnerAddMapChild();
        msgPack.SetName(text);
        return msgPack;
    }

    public void SetAsNull()
    {
        this.Clear();
        this.innerValue = null;
        this.valueType = MsgPackType.Null;
    }

    public void SetAsString(string value)
    {
        this.innerValue = value;
        this.valueType = MsgPackType.String;
    }

    public string GetAsString()
    {
        if (this.innerValue == null)
        {
            return "";
        }
        return this.innerValue.ToString();
    }

    public void SetAsBoolean(bool bVal)
    {
        this.valueType = MsgPackType.Boolean;
        this.innerValue = bVal;
    }

    public void SetAsSingle(float fVal)
    {
        this.valueType = MsgPackType.Single;
        this.innerValue = fVal;
    }

    public void SetAsFloat(double fVal)
    {
        this.valueType = MsgPackType.Float;
        this.innerValue = fVal;
    }

    public void DecodeFromBytes(byte[] bytes)
    {
        using MemoryStream memoryStream = new MemoryStream();
        bytes = Zip.Decompress(bytes);
        memoryStream.Write(bytes, 0, bytes.Length);
        memoryStream.Position = 0L;
        this.DecodeFromStream(memoryStream);
    }

    public void DecodeFromFile(string fileName)
    {
        FileStream fileStream;
        fileStream = new FileStream(fileName, FileMode.Open);
        this.DecodeFromStream(fileStream);
        fileStream.Dispose();
    }

    public void DecodeFromStream(Stream ms)
    {
        byte b;
        b = (byte)ms.ReadByte();
        byte[] array;
        array = null;
        int num;
        num = 0;
        int num2;
        num2 = 0;
        if (b <= 127)
        {
            this.SetAsInteger(b);
            return;
        }
        if (b >= 128 && b <= 143)
        {
            this.Clear();
            this.valueType = MsgPackType.Map;
            num = b - 128;
            for (num2 = 0; num2 < num; num2++)
            {
                MsgPack msgPack;
                msgPack = this.InnerAdd();
                msgPack.SetName(ReadTools.ReadString(ms));
                msgPack.DecodeFromStream(ms);
            }
            return;
        }
        if (b >= 144 && b <= 159)
        {
            this.Clear();
            this.valueType = MsgPackType.Array;
            num = b - 144;
            for (num2 = 0; num2 < num; num2++)
            {
                this.InnerAdd().DecodeFromStream(ms);
            }
            return;
        }
        if (b >= 160 && b <= 191)
        {
            this.SetAsString(ReadTools.ReadString(ms, b - 160));
            return;
        }
        if (b >= 224 && b <= byte.MaxValue)
        {
            this.SetAsInteger((sbyte)b);
            return;
        }
        switch (b)
        {
            case 192:
                this.SetAsNull();
                return;
            case 193:
                throw new Exception("(never used) type $c1");
            case 194:
                this.SetAsBoolean(bVal: false);
                return;
            case 195:
                this.SetAsBoolean(bVal: true);
                return;
            case 196:
                num = ms.ReadByte();
                array = new byte[num];
                ms.Read(array, 0, num);
                this.SetAsBytes(array);
                return;
            case 197:
                array = new byte[2];
                ms.Read(array, 0, 2);
                num = BitConverter.ToUInt16(BytesTools.SwapBytes(array), 0);
                array = new byte[num];
                ms.Read(array, 0, num);
                this.SetAsBytes(array);
                return;
            case 198:
                array = new byte[4];
                ms.Read(array, 0, 4);
                num = BitConverter.ToInt32(BytesTools.SwapBytes(array), 0);
                array = new byte[num];
                ms.Read(array, 0, num);
                this.SetAsBytes(array);
                return;
            case 202:
                array = new byte[4];
                ms.Read(array, 0, 4);
                this.SetAsSingle(BitConverter.ToSingle(BytesTools.SwapBytes(array), 0));
                return;
            case 203:
                array = new byte[8];
                ms.Read(array, 0, 8);
                this.SetAsFloat(BitConverter.ToDouble(BytesTools.SwapBytes(array), 0));
                return;
            case 204:
                this.SetAsInteger((byte)ms.ReadByte());
                return;
            case 205:
                array = new byte[2];
                ms.Read(array, 0, 2);
                this.SetAsInteger(BitConverter.ToUInt16(BytesTools.SwapBytes(array), 0));
                return;
            case 206:
                array = new byte[4];
                ms.Read(array, 0, 4);
                this.SetAsInteger(BitConverter.ToUInt32(BytesTools.SwapBytes(array), 0));
                return;
            case 207:
                array = new byte[8];
                ms.Read(array, 0, 8);
                this.SetAsUInt64(BitConverter.ToUInt64(BytesTools.SwapBytes(array), 0));
                return;
            case 220:
                array = new byte[2];
                ms.Read(array, 0, 2);
                num = BitConverter.ToInt16(BytesTools.SwapBytes(array), 0);
                this.Clear();
                this.valueType = MsgPackType.Array;
                for (num2 = 0; num2 < num; num2++)
                {
                    this.InnerAdd().DecodeFromStream(ms);
                }
                return;
            case 221:
                array = new byte[4];
                ms.Read(array, 0, 4);
                num = BitConverter.ToInt16(BytesTools.SwapBytes(array), 0);
                this.Clear();
                this.valueType = MsgPackType.Array;
                for (num2 = 0; num2 < num; num2++)
                {
                    this.InnerAdd().DecodeFromStream(ms);
                }
                return;
            case 217:
                this.SetAsString(ReadTools.ReadString(b, ms));
                return;
            case 222:
                array = new byte[2];
                ms.Read(array, 0, 2);
                num = BitConverter.ToInt16(BytesTools.SwapBytes(array), 0);
                this.Clear();
                this.valueType = MsgPackType.Map;
                for (num2 = 0; num2 < num; num2++)
                {
                    MsgPack msgPack2;
                    msgPack2 = this.InnerAdd();
                    msgPack2.SetName(ReadTools.ReadString(ms));
                    msgPack2.DecodeFromStream(ms);
                }
                return;
            case 199:
            case 200:
            case 201:
                throw new Exception("(ext8,ext16,ex32) type $c7,$c8,$c9");
        }
        switch (b)
        {
            case 222:
                array = new byte[2];
                ms.Read(array, 0, 2);
                num = BitConverter.ToInt16(BytesTools.SwapBytes(array), 0);
                this.Clear();
                this.valueType = MsgPackType.Map;
                for (num2 = 0; num2 < num; num2++)
                {
                    MsgPack msgPack4;
                    msgPack4 = this.InnerAdd();
                    msgPack4.SetName(ReadTools.ReadString(ms));
                    msgPack4.DecodeFromStream(ms);
                }
                break;
            case 223:
                array = new byte[4];
                ms.Read(array, 0, 4);
                num = BitConverter.ToInt32(BytesTools.SwapBytes(array), 0);
                this.Clear();
                this.valueType = MsgPackType.Map;
                for (num2 = 0; num2 < num; num2++)
                {
                    MsgPack msgPack3;
                    msgPack3 = this.InnerAdd();
                    msgPack3.SetName(ReadTools.ReadString(ms));
                    msgPack3.DecodeFromStream(ms);
                }
                break;
            case 218:
                this.SetAsString(ReadTools.ReadString(b, ms));
                break;
            case 219:
                this.SetAsString(ReadTools.ReadString(b, ms));
                break;
            case 208:
                this.SetAsInteger((sbyte)ms.ReadByte());
                break;
            case 209:
                array = new byte[2];
                ms.Read(array, 0, 2);
                this.SetAsInteger(BitConverter.ToInt16(BytesTools.SwapBytes(array), 0));
                break;
            case 210:
                array = new byte[4];
                ms.Read(array, 0, 4);
                this.SetAsInteger(BitConverter.ToInt32(BytesTools.SwapBytes(array), 0));
                break;
            case 211:
                array = new byte[8];
                ms.Read(array, 0, 8);
                this.SetAsInteger(BitConverter.ToInt64(BytesTools.SwapBytes(array), 0));
                break;
        }
    }

    public byte[] Encode2Bytes()
    {
        using MemoryStream memoryStream = new MemoryStream();
        this.Encode2Stream(memoryStream);
        byte[] array;
        array = new byte[memoryStream.Length];
        memoryStream.Position = 0L;
        memoryStream.Read(array, 0, (int)memoryStream.Length);
        return Zip.Compress(array);
    }

    public void Encode2Stream(Stream ms)
    {
        switch (this.valueType)
        {
            default:
                WriteTools.WriteNull(ms);
                break;
            case MsgPackType.Unknown:
            case MsgPackType.Null:
                WriteTools.WriteNull(ms);
                break;
            case MsgPackType.Map:
                this.WriteMap(ms);
                break;
            case MsgPackType.Array:
                this.WirteArray(ms);
                break;
            case MsgPackType.String:
                WriteTools.WriteString(ms, (string)this.innerValue);
                break;
            case MsgPackType.Integer:
                WriteTools.WriteInteger(ms, (long)this.innerValue);
                break;
            case MsgPackType.UInt64:
                WriteTools.WriteUInt64(ms, (ulong)this.innerValue);
                break;
            case MsgPackType.Boolean:
                WriteTools.WriteBoolean(ms, (bool)this.innerValue);
                break;
            case MsgPackType.Float:
                WriteTools.WriteFloat(ms, (double)this.innerValue);
                break;
            case MsgPackType.Single:
                WriteTools.WriteFloat(ms, (float)this.innerValue);
                break;
            case MsgPackType.DateTime:
                WriteTools.WriteInteger(ms, this.GetAsInteger());
                break;
            case MsgPackType.Binary:
                WriteTools.WriteBinary(ms, (byte[])this.innerValue);
                break;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new MsgPackEnum(this.children);
    }
}

