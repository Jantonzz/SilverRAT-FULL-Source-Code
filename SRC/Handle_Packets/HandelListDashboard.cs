using System;
using System.Drawing;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

internal class HandelListDashboard
{
    public void Addmsg(Bitmap logo, string Nackname, string IP, string state, Color color)
    {
        try
        {
            DataGridViewRow item = new DataGridViewRow
            {
                Height = 38
            };
            item.Cells.Add(new DataGridViewImageCell
            {
                Value = logo,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = Nackname
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = IP
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = state
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = DateTime.Now.ToLongTimeString()
            });
            DataGridViewCell dataGridViewCell = item.Cells[3];
            dataGridViewCell.Style.ForeColor = color;
            dataGridViewCell.Style.SelectionForeColor = color;
            if (Program.Silver.InvokeRequired)
            {
                Program.Silver.Invoke((MethodInvoker)delegate
                {
                    lock (Settings.LockListDasboard)
                    {
                        Program.Silver.ListDashboard.Rows.Insert(0, item);
                    }
                });
                return;
            }
            lock (Settings.LockListDasboard)
            {
                Program.Silver.ListDashboard.Rows.Insert(0, item);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
}
