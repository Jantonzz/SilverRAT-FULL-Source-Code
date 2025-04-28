using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SilverRAT.Helper;

public static class Methods
{
    public static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct LVITEM
        {
            public uint mask;

            public int iItem;

            public int iSubItem;

            public int state;

            public int stateMask;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;

            public int cchTextMax;

            public int iImage;

            public IntPtr lParam;

            public int iIndent;

            public int iGroupId;

            public uint cColumns;

            public IntPtr puColumns;

            public IntPtr piColFmt;

            public int iGroup;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        internal static extern IntPtr SendMessage_1(IntPtr hWnd, uint msg, IntPtr wParam, ref LVITEM lParam);

        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, int vk);

        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        internal static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
    }

    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public static Random Random = new Random();

    public static readonly char[] GetInvalidPathChars = Path.GetInvalidPathChars().Union(Path.GetInvalidFileNameChars()).ToArray();

    public static string result;

    public static int Error = 0;

    public static int Info = 1;

    public static int Success = 2;

    [DllImport("wininet.dll")]
    private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

    public static bool InternetState()
    {
        int Description;
        return InternetGetConnectedState(out Description, 0);
    }

    public static string GetLoad(string url)
    {
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string text;
            using (WebClient webClient = new WebClient())
            {
                text = webClient.DownloadString(url);
            }
            return text;
        }
        catch
        {
            return null;
        }
    }

    public static string FilesType(string Type)
    {
        if (Type == ".vb")
        {
            return "Visual Basic Source File";
        }
        if (Type == ".tmp")
        {
            return "TMP File";
        }
        try
        {
            RegistryKey classesRoot = Registry.ClassesRoot;
            RegistryKey registryKey = classesRoot.OpenSubKey(Type, writable: false);
            string name = registryKey.GetValue("", "").ToString();
            RegistryKey registryKey2 = classesRoot.OpenSubKey(name);
            string text = registryKey2.GetValue("", "").ToString();
            registryKey2.Close();
            registryKey.Close();
            classesRoot.Close();
            return text;
        }
        catch
        {
            return null;
        }
    }

    public static void SetDoubleBuffered(Control c)
    {
        if (!SystemInformation.TerminalServerSession)
        {
            PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(c, true, null);
        }
    }

    [DllImport("psapi.dll")]
    private static extern int EmptyWorkingSet(IntPtr hwProc);

    public static void MinimizeFootprint()
    {
        EmptyWorkingSet(Process.GetCurrentProcess().Handle);
    }

    public static int GetSizeValue(long SourceByte, long SizeByte)
    {
        if (SourceByte == 0L)
        {
            return 0;
        }
        long value = Math.Abs(SourceByte);
        return Math.Sign(value) * 100 / Math.Sign(SizeByte);
    }

    public static string BytesToString(long byteCount)
    {
        string[] array = new string[7] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
        if (byteCount == 0L)
        {
            return "0" + array[0];
        }
        long num = Math.Abs(byteCount);
        int num2 = Convert.ToInt32(Math.Floor(Math.Log(num, 1024.0)));
        double num3 = Math.Round((double)num / Math.Pow(1024.0, num2), 1);
        return (double)Math.Sign(byteCount) * num3 + array[num2];
    }

    public static string GetSizeSentAndReverse(long byteCount)
    {
        string[] array = new string[7] { "BT", "KB", "MB", "GB", "TB", "PB", "EB" };
        if (byteCount == 0L)
        {
            return array[0];
        }
        long num = Math.Abs(byteCount);
        int num2 = Convert.ToInt32(Math.Floor(Math.Log(num, 1024.0)));
        return array[num2];
    }

    public static string GetSizeValueSentAndReverse(long byteCount)
    {
        if (byteCount == 0L)
        {
            return "0";
        }
        long num = Math.Abs(byteCount);
        int num2 = Convert.ToInt32(Math.Floor(Math.Log(num, 1024.0)));
        double num3 = Math.Round((double)num / Math.Pow(1024.0, num2), 1);
        return ((double)Math.Sign(byteCount) * num3).ToString();
    }

    public static async Task FadeIn(Form o, int interval = 80)
    {
        while (o.Opacity < 1.0)
        {
            await Task.Delay(interval);
            o.Opacity += 0.05;
        }
    }

    public static string GetRandomString(int length)
    {
        StringBuilder stringBuilder = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[Random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)]);
        }
        return stringBuilder.ToString();
    }

    public static bool CheckPathChard(string Path)
    {
        return Path.Any((char c) => GetInvalidPathChars.Contains(c));
    }

    public static void SelectedFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string arguments = "/select, \"" + filePath + "\"";
                Process.Start("explorer.exe", arguments);
            }
        }
        catch
        {
        }
    }

    public static string GetLocalIPAddress()
    {
        string text = "127.0.0.1";
        try
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addressList = hostEntry.AddressList;
            foreach (IPAddress iPAddress in addressList)
            {
                if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return iPAddress.ToString();
                }
            }
        }
        catch
        {
            return text;
        }
        return text;
    }

    public static string AsyncUpload(string Filename)
    {
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (WebClient webClient = new WebClient())
            {
                byte[] bytes = webClient.UploadFile("https://transfer.sh/", Filename);
                result = Encoding.UTF8.GetString(bytes);
            }
            return result;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public static void DateModified(string Filename, DateTimePicker Value)
    {
        File.SetCreationTime(Filename, Value.Value);
        File.SetLastWriteTime(Filename, Value.Value);
        File.SetLastAccessTime(Filename, Value.Value);
    }

    public static bool IsConnectedToInternet()
    {
        string hostNameOrAddress = "www.google.com";
        bool flag = false;
        Ping ping = new Ping();
        try
        {
            PingReply pingReply = ping.Send(hostNameOrAddress, 3000);
            if (pingReply.Status == IPStatus.Success)
            {
                return true;
            }
        }
        catch
        {
        }
        return flag;
    }

    public static Guna2DataGridView ThemeDataGridView(Guna2DataGridView DGV, int value)
    {
        switch (value)
        {
            case 0:
                DGV.Theme = DataGridViewPresetThemes.Light;
                break;
            case 1:
                DGV.Theme = DataGridViewPresetThemes.Alizarin;
                break;
            case 2:
                DGV.Theme = DataGridViewPresetThemes.Carrot;
                break;
            case 3:
                DGV.Theme = DataGridViewPresetThemes.SunFlower;
                break;
            case 4:
                DGV.Theme = DataGridViewPresetThemes.Amethyst;
                break;
            case 5:
                DGV.Theme = DataGridViewPresetThemes.FeterRiver;
                break;
            case 6:
                DGV.Theme = DataGridViewPresetThemes.Emerald;
                break;
            case 7:
                DGV.Theme = DataGridViewPresetThemes.GreenSea;
                break;
            case 8:
                DGV.Theme = DataGridViewPresetThemes.Turquoise;
                break;
            case 9:
                DGV.Theme = DataGridViewPresetThemes.WetAsphalt;
                break;
            case 10:
                DGV.Theme = DataGridViewPresetThemes.Red;
                break;
            case 11:
                DGV.Theme = DataGridViewPresetThemes.Pink;
                break;
            case 12:
                DGV.Theme = DataGridViewPresetThemes.Indigo;
                break;
            case 13:
                DGV.Theme = DataGridViewPresetThemes.Blue;
                break;
            case 14:
                DGV.Theme = DataGridViewPresetThemes.LightBlue;
                break;
            case 15:
                DGV.Theme = DataGridViewPresetThemes.Cyan;
                break;
            case 16:
                DGV.Theme = DataGridViewPresetThemes.Purple;
                break;
            case 17:
                DGV.Theme = DataGridViewPresetThemes.DeepPurple;
                break;
            case 18:
                DGV.Theme = DataGridViewPresetThemes.Teal;
                break;
            case 19:
                DGV.Theme = DataGridViewPresetThemes.Green;
                break;
            case 20:
                DGV.Theme = DataGridViewPresetThemes.LightGreen;
                break;
            case 21:
                DGV.Theme = DataGridViewPresetThemes.Lime;
                break;
            case 22:
                DGV.Theme = DataGridViewPresetThemes.Orange;
                break;
            case 23:
                DGV.Theme = DataGridViewPresetThemes.DeepOrange;
                break;
            case 24:
                DGV.Theme = DataGridViewPresetThemes.White;
                break;
            case 25:
                DGV.Theme = DataGridViewPresetThemes.Default;
                DGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
                break;
            case 26:
                DGV.Theme = DataGridViewPresetThemes.Dark;
                break;
        }
        return DGV;
    }

    public static int GetCpuUsage()
    {
        PerformanceCounter performanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", Environment.MachineName);
        performanceCounter.NextValue();
        return (int)performanceCounter.NextValue();
    }
}
