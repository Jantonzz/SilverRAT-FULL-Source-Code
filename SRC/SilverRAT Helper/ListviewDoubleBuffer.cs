using System.Reflection;
using System.Windows.Forms;

namespace SilverRAT.Helper;

public static class ListviewDoubleBuffer
{
    public class DoubleBufferedTableLayoutPanel : TableLayoutPanel
    {
        public DoubleBufferedTableLayoutPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
        }
    }

    public static void EnableDataGridView(DataGridView LV)
    {
        typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, null, LV, new object[1] { true });
    }

    public static void EnableListView(ListView LV)
    {
        PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        property.SetValue(LV, true, null);
    }
}
