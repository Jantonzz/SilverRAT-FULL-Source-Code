#define DEBUG
using SilverRAT.Connection;
using SilverRAT.MessagePack;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

public class HandlePing
{
    public void Ping(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").SetAsString("pong");
            ThreadPool.QueueUserWorkItem(client.Send, msgPack.Encode2Bytes());
            lock (Settings.LockListviewClients)
            {
                if (client.DGV != null)
                {
                    client.DGV.Cells[13].Value = unpack_msgpack.ForcePathObject("Message").AsString;
                }
                else
                {
                    Debug.WriteLine("Temp socket pinged server");
                }
            }
        }
        catch
        {
        }
    }

    public void Pong(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            lock (Settings.LockListviewClients)
            {
                if (client.DGV != null)
                {
                    int num = (int)unpack_msgpack.ForcePathObject("Message").AsInteger;
                    DataGridViewCell dataGridViewCell = client.DGV.Cells[12];
                    client.DGV.Cells[12].Value = num + " MS";
                    if (num > 400)
                    {
                        dataGridViewCell.Style.ForeColor = Color.Red;
                    }
                    else if (num > 200)
                    {
                        dataGridViewCell.Style.ForeColor = Color.Orange;
                    }
                    else
                    {
                        dataGridViewCell.Style.ForeColor = Color.Green;
                    }
                }
            }
        }
        catch
        {
        }
    }
}
