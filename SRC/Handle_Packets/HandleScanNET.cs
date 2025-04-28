using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.MessagePack;
using System.Drawing;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

internal class HandleScanNET
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "Error":
                    {
                        ScanNET scanNET3 = (ScanNET)Application.OpenForms["ScanNET:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (scanNET3 != null)
                        {
                            scanNET3.InfoSpeed.Text = unpack_msgpack.ForcePathObject("Value").AsString;
                            scanNET3.InfoSpeed.ForeColor = Color.Red;
                            scanNET3.ScanInternet.Enabled = true;
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Scan":
                    {
                        ScanNET scanNET2 = (ScanNET)Application.OpenForms["ScanNET:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (scanNET2 != null)
                        {
                            scanNET2.InfoSpeed.Text = unpack_msgpack.ForcePathObject("Value").AsString;
                            scanNET2.InfoSpeed.ForeColor = Color.Green;
                            scanNET2.ScanInternet.Enabled = true;
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Actived":
                    {
                        ScanNET scanNET = (ScanNET)Application.OpenForms["ScanNET:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (scanNET != null)
                        {
                            if (scanNET.Client == null)
                            {
                                scanNET.Client = client;
                                scanNET.LoaderConnect.Visible = false;
                                scanNET.Timer1.Start();
                                scanNET.ScanInternet.Enabled = true;
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
