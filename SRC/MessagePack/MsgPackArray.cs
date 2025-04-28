using System.Collections.Generic;

namespace SilverRAT.MessagePack;

public class MsgPackArray
{
    private List<MsgPack> children;

    private MsgPack owner;

    public MsgPack this[int index] => this.children[index];

    public int Length => this.children.Count;

    public MsgPackArray(MsgPack msgpackObj, List<MsgPack> listObj)
    {
        this.owner = msgpackObj;
        this.children = listObj;
    }

    public MsgPack Add()
    {
        return this.owner.AddArrayChild();
    }

    public MsgPack Add(string value)
    {
        MsgPack msgPack;
        msgPack = this.owner.AddArrayChild();
        msgPack.AsString = value;
        return msgPack;
    }

    public MsgPack Add(long value)
    {
        MsgPack msgPack;
        msgPack = this.owner.AddArrayChild();
        msgPack.SetAsInteger(value);
        return msgPack;
    }

    public MsgPack Add(double value)
    {
        MsgPack msgPack;
        msgPack = this.owner.AddArrayChild();
        msgPack.SetAsFloat(value);
        return msgPack;
    }
}

