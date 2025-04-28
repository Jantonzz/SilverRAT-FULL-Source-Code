using System.Windows.Forms;

namespace Server.Helper;

public class RegistryTreeView : TreeView
{
    public RegistryTreeView()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
    }
}
