using System.Collections;
using System.Collections.Generic;

namespace SilverRAT.MessagePack;

public class MsgPackEnum : IEnumerator
{
    private List<MsgPack> children;

    private int position = -1;

    object IEnumerator.Current => this.children[this.position];

    public MsgPackEnum(List<MsgPack> obj)
    {
        this.children = obj;
    }

    bool IEnumerator.MoveNext()
    {
        this.position++;
        return this.position < this.children.Count;
    }

    void IEnumerator.Reset()
    {
        this.position = -1;
    }
}

