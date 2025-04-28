using SilverRAT.Connection;
using SilverRAT.Helper.ReverseProxy;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;


namespace SilverRAT;

public static class Settings
{
    public static List<ProxyListener> list_4 = new List<ProxyListener>();

    public static readonly string Version = "SilverRAT 0.0.1";

    public static readonly string PathLogo = Application.StartupPath + "\\Resources\\Logo";

    public static List<string> Blocked = new List<string>();

    public static object LockBlocked = new object();

    public static object LockReceivedSendValue = new object();



    public static object LockListviewClients = new object();

    public static object LockListviewLogs = new object();

    public static object LockListDasboard = new object();

    public static object LockNotif = new object();

    public static bool ReportWindow = false;

    public static List<Clients> ReportWindowClients = new List<Clients>();

    public static object LockReportWindowClients = new object();

    public static bool ShowIconNotif = true;



    public static bool CloseButtonNotif = true;

    public static bool ScrollToOutNotif = true;

    public static bool EffectNotif = true;

    public static string DelayNotif = "2000";

    public static string SpeedNotif = "500";

    public static X509Certificate2 ServerCertificate;
    public static string CertificatePath = Application.StartupPath + "\\Usrs.p12";
    public static int CountMonitor { get; set; }

    public static int CountGrabber { get; set; }

    public static bool IsConnectedProxy { get; set; }

    public static int PortTcpProxy { get; set; }

    public static int CurvatureForm { get; set; }

    public static bool EnableEdgecurvatureForm { get; set; }

    public static Color ColorCurvatureForm { get; set; }

    public static long SentValue { get; set; }

    public static long ReceivedValue { get; set; }

    public static int DashboardDisconnect { get; set; }

    public static string Value { get; set; }
}
