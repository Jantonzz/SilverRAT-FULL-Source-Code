using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Windows.Forms;

namespace authguard;

public static class security
{
    public static bool started;

    public static bool breached;

    public static string Signature(string filename)
    {
        using MD5 mD = MD5.Create();
        using FileStream inputStream = File.OpenRead(filename);
        byte[] array = mD.ComputeHash(inputStream);
        return BitConverter.ToString(array).Replace("-", "").ToLowerInvariant();
    }

    public static void Start()
    {
        string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
        if (started)
        {
            MessageBox.Show("A session has already been started, please end the previous one!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Process.GetCurrentProcess().Kill();
            return;
        }
        using (StreamReader streamReader = new StreamReader(pathRoot + "Windows\\System32\\drivers\\etc\\hosts"))
        {
            string text = streamReader.ReadToEnd();
            if (text.Contains("api.authguard.net"))
            {
                breached = true;
                MessageBox.Show("DNS redirecting has been detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Process.GetCurrentProcess().Kill();
            }
        }
        started = true;
    }

    public static void End()
    {
        if (!started)
        {
            MessageBox.Show("No session has been started, closing for security reasons!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Process.GetCurrentProcess().Kill();
        }
        else
        {
            started = false;
        }
    }

    public static bool MaliciousCheck(string date)
    {
        DateTime dateTime = DateTime.Parse(date);
        DateTime now = DateTime.Now;
        TimeSpan timeSpan = dateTime - now;
        if (Convert.ToInt32(timeSpan.Seconds.ToString().Replace("-", "")) >= 5 || Convert.ToInt32(timeSpan.Minutes.ToString().Replace("-", "")) >= 1)
        {
            breached = true;
            return true;
        }
        return false;
    }

    public static string HWID()
    {
        return WindowsIdentity.GetCurrent().User.Value;
    }
}
