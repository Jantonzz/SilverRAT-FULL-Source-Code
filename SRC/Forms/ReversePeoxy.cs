using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.Helper;
using SilverRAT.Helper.ReverseProxy;
using SilverRAT.MessagePack;
using SilverRAT.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class ReversePeoxy : Form
{
    public ProxyListener item;

    public Random RandomNumber = new Random();

    private IContainer components = null;

    private Panel panelForm;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    private PictureBox ImageLogo;

    private BunifuLabel UserIdInfo;

    private BunifuLabel bunifuLabel1;

    private BunifuElipse bunifuElipse1;

    private BunifuFormDrag bunifuFormDrag1;

    private BunifuShadowPanel bunifuShadowPanel_0;

    private BunifuLabel bunifuLabel21;

    public System.Windows.Forms.Timer timer1;

    public Guna2GradientButton ConectAndDisconnect;

    public BunifuLoader LoaderConnect;

    public BunifuLabel LabelPort;

    private ContextMenuStrip contextMenuStrip1;

    private ToolStripMenuItem CopyPort;

    private ToolStripMenuItem CopyAll;

    private BunifuLabel bunifuLabel3;

    public BunifuLabel TargetPort;

    public BunifuLabel TargetServer;

    private BunifuToolTip bunifuToolTip1;

    private BunifuPanel panelTitle;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    public Bitmap Logo { get; set; }

    public ProxyListener Listener { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public ReversePeoxy()
    {
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
    }

    private void ReverseProxy_Load(object sender, EventArgs e)
    {
        try
        {
            UserIdInfo.Text = Packet.GetUserIDClient(ParentClient.DGV);
        }
        catch
        {
            UserIdInfo.Text = "Not Found!";
        }
        try
        {
            bunifuElipse1.ElipseRadius = Settings.CurvatureForm;
            if (Settings.EnableEdgecurvatureForm)
            {
                PanelLeft.BackgroundColor = Settings.ColorCurvatureForm;
                PanelTOP.BackgroundColor = Settings.ColorCurvatureForm;
                PanelBottom.BackgroundColor = Settings.ColorCurvatureForm;
                PanelRight.BackgroundColor = Settings.ColorCurvatureForm;
            }
            else
            {
                PanelLeft.Visible = false;
                PanelTOP.Visible = false;
                PanelBottom.Visible = false;
                PanelRight.Visible = false;
            }
            if (Logo != null)
            {
                ImageLogo.Image = Logo;
            }
        }
        catch
        {
        }
    }

    private void ReverseProxy_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void ConectAndDisconnect_Click(object sender, EventArgs e)
    {
        int portTcpProxy = Settings.PortTcpProxy;
        if (portTcpProxy <= 0)
        {
            return;
        }
        try
        {
            if (ConectAndDisconnect.Text == "Connect")
            {
                int localport = RandomNumber.Next(40000, 60000);
                _ = Client.ID;
                Listener = new ProxyListener(localport, Client.Ip, Client.ID, 0);
                ConectAndDisconnect.Enabled = false;
                ConectAndDisconnect.Text = "Connect...";
                LabelPort.Text = " Connection...";
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Connect";
                msgPack.ForcePathObject("Port").AsString = localport.ToString();
                msgPack.ForcePathObject("PortTCP").AsString = portTcpProxy.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                LabelPort.ContextMenuStrip = contextMenuStrip1;
                return;
            }
            Listener.StopServer();
            ConectAndDisconnect.Enabled = false;
            ConectAndDisconnect.Text = "Disconnect...";
            ConectAndDisconnect.Text = "Disconnecting...";
            MsgPack msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Packet").AsString = "Disconnect";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            CloseListener();
            try
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    Client?.Disconnected();
                });
            }
            catch
            {
            }
            Close();
        }
        catch (Exception ex)
        {
            Notifiecation.Show("Reverse Proxy!", ex.Message, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private void CloseListener()
    {
        try
        {
            if (Listener.TcpClient_0 != null)
            {
                Listener.TcpClient_0.GetStream().Close();
                Listener.TcpClient_0.Close();
            }
        }
        catch
        {
        }
        try
        {
            if (Listener.TcpClient_1 != null)
            {
                Listener.TcpClient_1.GetStream().Close();
                Listener.TcpClient_1.Close();
            }
        }
        catch
        {
        }
        try
        {
            Listener.StopServer();
        }
        catch
        {
        }
    }

    private void CopyPort_Click(object sender, EventArgs e)
    {
        if (LabelPort.Text.Length > 10)
        {
            string[] array = LabelPort.Text.Split(':');
            Clipboard.SetText(array[1]);
        }
    }

    private void CopyAll_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(LabelPort.Text);
    }

    private void ButtClose_Click_1(object sender, EventArgs e)
    {
        Close();
    }

    private void ReversePeoxy_FormClosing(object sender, FormClosingEventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(panelForm);
        try
        {
            if (ConectAndDisconnect.Text != "Connect")
            {
                CloseListener();
            }
            ThreadPool.QueueUserWorkItem(delegate
            {
                Client?.Disconnected();
            });
        }
        catch
        {
        }
    }

    private void ButtionMinimized_Click(object sender, EventArgs e)
    {
        if (base.WindowState != FormWindowState.Minimized)
        {
            base.WindowState = FormWindowState.Minimized;
        }
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (ParentClient.TcpClient.Connected && Client.TcpClient.Connected)
            {
                return;
            }
            if (ConectAndDisconnect.Text != "Connect")
            {
                CloseListener();
            }
            try
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    Client?.Disconnected();
                });
            }
            catch
            {
            }
            Close();
        }
        catch
        {
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.ReversePeoxy));
        this.panelForm = new System.Windows.Forms.Panel();
        this.panelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.LoaderConnect = new Bunifu.UI.WinForms.BunifuLoader();
        this.ImageLogo = new System.Windows.Forms.PictureBox();
        this.UserIdInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.ConectAndDisconnect = new Guna.UI2.WinForms.Guna2GradientButton();
        this.bunifuShadowPanel_0 = new Bunifu.UI.WinForms.BunifuShadowPanel();
        this.TargetPort = new Bunifu.UI.WinForms.BunifuLabel();
        this.TargetServer = new Bunifu.UI.WinForms.BunifuLabel();
        this.LabelPort = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel21 = new Bunifu.UI.WinForms.BunifuLabel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.CopyPort = new System.Windows.Forms.ToolStripMenuItem();
        this.CopyAll = new System.Windows.Forms.ToolStripMenuItem();
        this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.bunifuFormDrag1 = new Bunifu.UI.WinForms.BunifuFormDrag();
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
        this.panelForm.SuspendLayout();
        this.panelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        this.bunifuShadowPanel_0.SuspendLayout();
        this.contextMenuStrip1.SuspendLayout();
        base.SuspendLayout();
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.panelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.ConectAndDisconnect);
        this.panelForm.Controls.Add(this.bunifuShadowPanel_0);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(666, 387);
        this.panelForm.TabIndex = 571;
        this.bunifuToolTip1.SetToolTip(this.panelForm, "");
        this.bunifuToolTip1.SetToolTipIcon(this.panelForm, null);
        this.bunifuToolTip1.SetToolTipTitle(this.panelForm, "");
        this.panelForm.Visible = false;
        this.panelTitle.BackgroundColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.panelTitle.BackgroundImage = (System.Drawing.Image)resources.GetObject("panelTitle.BackgroundImage");
        this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.panelTitle.BorderColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.panelTitle.BorderRadius = 22;
        this.panelTitle.BorderThickness = 1;
        this.panelTitle.Controls.Add(this.ButtClose);
        this.panelTitle.Controls.Add(this.ButtionMinimized);
        this.panelTitle.Controls.Add(this.LoaderConnect);
        this.panelTitle.Controls.Add(this.ImageLogo);
        this.panelTitle.Controls.Add(this.UserIdInfo);
        this.panelTitle.Controls.Add(this.bunifuLabel1);
        this.panelTitle.Location = new System.Drawing.Point(12, 21);
        this.panelTitle.Name = "panelTitle";
        this.panelTitle.ShowBorders = true;
        this.panelTitle.Size = new System.Drawing.Size(639, 77);
        this.panelTitle.TabIndex = 596;
        this.bunifuToolTip1.SetToolTip(this.panelTitle, "");
        this.bunifuToolTip1.SetToolTipIcon(this.panelTitle, null);
        this.bunifuToolTip1.SetToolTipTitle(this.panelTitle, "");
        this.ButtClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.ButtClose.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButtClose.CheckedState.Parent = this.ButtClose;
        this.ButtClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtClose.CustomImages.Parent = this.ButtClose;
        this.ButtClose.FillColor = System.Drawing.Color.FromArgb(237, 107, 96);
        this.ButtClose.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButtClose.ForeColor = System.Drawing.Color.White;
        this.ButtClose.HoverState.BorderColor = System.Drawing.Color.FromArgb(237, 107, 96);
        this.ButtClose.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(237, 107, 96);
        this.ButtClose.HoverState.FillColor = System.Drawing.Color.FromArgb(237, 107, 96);
        this.ButtClose.HoverState.Parent = this.ButtClose;
        this.ButtClose.Location = new System.Drawing.Point(607, 11);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 597;
        this.bunifuToolTip1.SetToolTip(this.ButtClose, "");
        this.bunifuToolTip1.SetToolTipIcon(this.ButtClose, null);
        this.bunifuToolTip1.SetToolTipTitle(this.ButtClose, "");
        this.ButtClose.Click += new System.EventHandler(ButtClose_Click_1);
        this.ButtionMinimized.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.ButtionMinimized.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButtionMinimized.CheckedState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtionMinimized.CustomImages.Parent = this.ButtionMinimized;
        this.ButtionMinimized.FillColor = System.Drawing.Color.FromArgb(97, 196, 83);
        this.ButtionMinimized.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButtionMinimized.ForeColor = System.Drawing.Color.White;
        this.ButtionMinimized.HoverState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Location = new System.Drawing.Point(584, 11);
        this.ButtionMinimized.Name = "ButtionMinimized";
        this.ButtionMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtionMinimized.ShadowDecoration.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Size = new System.Drawing.Size(17, 17);
        this.ButtionMinimized.TabIndex = 599;
        this.bunifuToolTip1.SetToolTip(this.ButtionMinimized, "");
        this.bunifuToolTip1.SetToolTipIcon(this.ButtionMinimized, null);
        this.bunifuToolTip1.SetToolTipTitle(this.ButtionMinimized, "");
        this.ButtionMinimized.Click += new System.EventHandler(ButtionMinimized_Click);
        this.LoaderConnect.AllowStylePresets = true;
        this.LoaderConnect.BackColor = System.Drawing.Color.Transparent;
        this.LoaderConnect.CapStyle = Bunifu.UI.WinForms.BunifuLoader.CapStyles.Flat;
        this.LoaderConnect.Color = System.Drawing.Color.FromArgb(87, 59, 255);
        this.LoaderConnect.Colors = new Bunifu.UI.WinForms.Bloom[0];
        this.LoaderConnect.Customization = "";
        this.LoaderConnect.DashWidth = 0.5f;
        this.LoaderConnect.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.LoaderConnect.Image = null;
        this.LoaderConnect.Location = new System.Drawing.Point(15, 13);
        this.LoaderConnect.Name = "LoaderConnect";
        this.LoaderConnect.NoRounding = false;
        this.LoaderConnect.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Dashed;
        this.LoaderConnect.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Dashed;
        this.LoaderConnect.ShowText = false;
        this.LoaderConnect.Size = new System.Drawing.Size(55, 50);
        this.LoaderConnect.Speed = 7;
        this.LoaderConnect.TabIndex = 596;
        this.LoaderConnect.Text = "bunifuLoader1";
        this.LoaderConnect.TextPadding = new System.Windows.Forms.Padding(0);
        this.LoaderConnect.Thickness = 6;
        this.bunifuToolTip1.SetToolTip(this.LoaderConnect, "");
        this.bunifuToolTip1.SetToolTipIcon(this.LoaderConnect, null);
        this.bunifuToolTip1.SetToolTipTitle(this.LoaderConnect, "");
        this.LoaderConnect.Transparent = true;
        this.ImageLogo.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ImageLogo.Image = (System.Drawing.Image)resources.GetObject("ImageLogo.Image");
        this.ImageLogo.Location = new System.Drawing.Point(13, 13);
        this.ImageLogo.Name = "ImageLogo";
        this.ImageLogo.Size = new System.Drawing.Size(59, 50);
        this.ImageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageLogo.TabIndex = 570;
        this.ImageLogo.TabStop = false;
        this.bunifuToolTip1.SetToolTip(this.ImageLogo, "");
        this.bunifuToolTip1.SetToolTipIcon(this.ImageLogo, null);
        this.bunifuToolTip1.SetToolTipTitle(this.ImageLogo, "");
        this.UserIdInfo.AllowParentOverrides = false;
        this.UserIdInfo.AutoEllipsis = false;
        this.UserIdInfo.Cursor = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.CursorType = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.UserIdInfo.ForeColor = System.Drawing.Color.DarkGray;
        this.UserIdInfo.Location = new System.Drawing.Point(80, 41);
        this.UserIdInfo.Name = "UserIdInfo";
        this.UserIdInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.UserIdInfo.Size = new System.Drawing.Size(9, 15);
        this.UserIdInfo.TabIndex = 569;
        this.UserIdInfo.Text = "...";
        this.UserIdInfo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.UserIdInfo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuToolTip1.SetToolTip(this.UserIdInfo, "");
        this.bunifuToolTip1.SetToolTipIcon(this.UserIdInfo, null);
        this.bunifuToolTip1.SetToolTipTitle(this.UserIdInfo, "");
        this.bunifuLabel1.AllowParentOverrides = false;
        this.bunifuLabel1.AutoEllipsis = false;
        this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.bunifuLabel1.ForeColor = System.Drawing.Color.Black;
        this.bunifuLabel1.Location = new System.Drawing.Point(76, 18);
        this.bunifuLabel1.Name = "bunifuLabel1";
        this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel1.Size = new System.Drawing.Size(86, 17);
        this.bunifuLabel1.TabIndex = 568;
        this.bunifuLabel1.Text = "Reverse Proxy";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuToolTip1.SetToolTip(this.bunifuLabel1, "");
        this.bunifuToolTip1.SetToolTipIcon(this.bunifuLabel1, null);
        this.bunifuToolTip1.SetToolTipTitle(this.bunifuLabel1, "");
        this.PanelBottom.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelBottom.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelBottom.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelBottom.BackgroundImage");
        this.PanelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelBottom.BorderColor = System.Drawing.Color.White;
        this.PanelBottom.BorderRadius = 30;
        this.PanelBottom.BorderThickness = 1;
        this.PanelBottom.Location = new System.Drawing.Point(170, 376);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(333, 25);
        this.PanelBottom.TabIndex = 594;
        this.bunifuToolTip1.SetToolTip(this.PanelBottom, "");
        this.bunifuToolTip1.SetToolTipIcon(this.PanelBottom, null);
        this.bunifuToolTip1.SetToolTipTitle(this.PanelBottom, "");
        this.PanelTOP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTOP.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelTOP.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTOP.BackgroundImage");
        this.PanelTOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTOP.BorderColor = System.Drawing.Color.White;
        this.PanelTOP.BorderRadius = 30;
        this.PanelTOP.BorderThickness = 1;
        this.PanelTOP.Location = new System.Drawing.Point(170, -15);
        this.PanelTOP.Name = "PanelTOP";
        this.PanelTOP.ShowBorders = true;
        this.PanelTOP.Size = new System.Drawing.Size(333, 25);
        this.PanelTOP.TabIndex = 592;
        this.bunifuToolTip1.SetToolTip(this.PanelTOP, "");
        this.bunifuToolTip1.SetToolTipIcon(this.PanelTOP, null);
        this.bunifuToolTip1.SetToolTipTitle(this.PanelTOP, "");
        this.PanelLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PanelLeft.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelLeft.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelLeft.BackgroundImage");
        this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelLeft.BorderColor = System.Drawing.Color.White;
        this.PanelLeft.BorderRadius = 30;
        this.PanelLeft.BorderThickness = 1;
        this.PanelLeft.Location = new System.Drawing.Point(-16, 108);
        this.PanelLeft.Name = "PanelLeft";
        this.PanelLeft.ShowBorders = true;
        this.PanelLeft.Size = new System.Drawing.Size(25, 168);
        this.PanelLeft.TabIndex = 593;
        this.bunifuToolTip1.SetToolTip(this.PanelLeft, "");
        this.bunifuToolTip1.SetToolTipIcon(this.PanelLeft, null);
        this.bunifuToolTip1.SetToolTipTitle(this.PanelLeft, "");
        this.ConectAndDisconnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.ConectAndDisconnect.Animated = true;
        this.ConectAndDisconnect.BackColor = System.Drawing.Color.White;
        this.ConectAndDisconnect.BorderRadius = 8;
        this.ConectAndDisconnect.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ConectAndDisconnect.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ConectAndDisconnect.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ConectAndDisconnect.CheckedState.Parent = this.ConectAndDisconnect;
        this.ConectAndDisconnect.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ConectAndDisconnect.CustomImages.Parent = this.ConectAndDisconnect;
        this.ConectAndDisconnect.Enabled = false;
        this.ConectAndDisconnect.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ConectAndDisconnect.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ConectAndDisconnect.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.ConectAndDisconnect.ForeColor = System.Drawing.Color.White;
        this.ConectAndDisconnect.HoverState.Parent = this.ConectAndDisconnect;
        this.ConectAndDisconnect.Location = new System.Drawing.Point(527, 339);
        this.ConectAndDisconnect.Name = "ConectAndDisconnect";
        this.ConectAndDisconnect.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.ConectAndDisconnect.PressedDepth = 50;
        this.ConectAndDisconnect.ShadowDecoration.Parent = this.ConectAndDisconnect;
        this.ConectAndDisconnect.Size = new System.Drawing.Size(103, 30);
        this.ConectAndDisconnect.TabIndex = 574;
        this.ConectAndDisconnect.Text = "Connect";
        this.bunifuToolTip1.SetToolTip(this.ConectAndDisconnect, "");
        this.bunifuToolTip1.SetToolTipIcon(this.ConectAndDisconnect, null);
        this.bunifuToolTip1.SetToolTipTitle(this.ConectAndDisconnect, "");
        this.ConectAndDisconnect.Click += new System.EventHandler(ConectAndDisconnect_Click);
        this.bunifuShadowPanel_0.BackColor = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.BorderColor = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.BorderRadius = 20;
        this.bunifuShadowPanel_0.BorderThickness = 1;
        this.bunifuShadowPanel_0.Controls.Add(this.TargetPort);
        this.bunifuShadowPanel_0.Controls.Add(this.TargetServer);
        this.bunifuShadowPanel_0.Controls.Add(this.LabelPort);
        this.bunifuShadowPanel_0.Controls.Add(this.bunifuLabel21);
        this.bunifuShadowPanel_0.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
        this.bunifuShadowPanel_0.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
        this.bunifuShadowPanel_0.Location = new System.Drawing.Point(31, 108);
        this.bunifuShadowPanel_0.Name = "bunifuShadowPanel19";
        this.bunifuShadowPanel_0.PanelColor = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.PanelColor2 = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.ShadowColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.bunifuShadowPanel_0.ShadowDept = 2;
        this.bunifuShadowPanel_0.ShadowDepth = 5;
        this.bunifuShadowPanel_0.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
        this.bunifuShadowPanel_0.ShadowTopLeftVisible = false;
        this.bunifuShadowPanel_0.Size = new System.Drawing.Size(599, 203);
        this.bunifuShadowPanel_0.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
        this.bunifuShadowPanel_0.TabIndex = 595;
        this.bunifuToolTip1.SetToolTip(this.bunifuShadowPanel_0, "");
        this.bunifuToolTip1.SetToolTipIcon(this.bunifuShadowPanel_0, null);
        this.bunifuToolTip1.SetToolTipTitle(this.bunifuShadowPanel_0, "");
        this.TargetPort.AllowParentOverrides = false;
        this.TargetPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.TargetPort.AutoEllipsis = false;
        this.TargetPort.AutoSize = false;
        this.TargetPort.Cursor = System.Windows.Forms.Cursors.Default;
        this.TargetPort.CursorType = System.Windows.Forms.Cursors.Default;
        this.TargetPort.Font = new System.Drawing.Font("Segoe UI", 9.75f);
        this.TargetPort.ForeColor = System.Drawing.Color.Gray;
        this.TargetPort.Location = new System.Drawing.Point(16, 151);
        this.TargetPort.Name = "TargetPort";
        this.TargetPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TargetPort.Size = new System.Drawing.Size(568, 22);
        this.TargetPort.TabIndex = 571;
        this.TargetPort.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.TargetPort.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuToolTip1.SetToolTip(this.TargetPort, "Target Port");
        this.bunifuToolTip1.SetToolTipIcon(this.TargetPort, Properties.Resources.InfoNotif);
        this.bunifuToolTip1.SetToolTipTitle(this.TargetPort, "Info");
        this.TargetServer.AllowParentOverrides = false;
        this.TargetServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.TargetServer.AutoEllipsis = false;
        this.TargetServer.AutoSize = false;
        this.TargetServer.Cursor = System.Windows.Forms.Cursors.Default;
        this.TargetServer.CursorType = System.Windows.Forms.Cursors.Default;
        this.TargetServer.Font = new System.Drawing.Font("Segoe UI", 10.75f);
        this.TargetServer.ForeColor = System.Drawing.Color.Gray;
        this.TargetServer.Location = new System.Drawing.Point(16, 123);
        this.TargetServer.Name = "TargetServer";
        this.TargetServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TargetServer.Size = new System.Drawing.Size(568, 22);
        this.TargetServer.TabIndex = 570;
        this.TargetServer.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.TargetServer.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuToolTip1.SetToolTip(this.TargetServer, "Target Server");
        this.bunifuToolTip1.SetToolTipIcon(this.TargetServer, Properties.Resources.InfoNotif);
        this.bunifuToolTip1.SetToolTipTitle(this.TargetServer, "Info");
        this.LabelPort.AllowParentOverrides = false;
        this.LabelPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.LabelPort.AutoEllipsis = false;
        this.LabelPort.AutoSize = false;
        this.LabelPort.Cursor = System.Windows.Forms.Cursors.Default;
        this.LabelPort.CursorType = System.Windows.Forms.Cursors.Default;
        this.LabelPort.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
        this.LabelPort.ForeColor = System.Drawing.Color.DarkRed;
        this.LabelPort.Location = new System.Drawing.Point(16, 67);
        this.LabelPort.Name = "LabelPort";
        this.LabelPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LabelPort.Size = new System.Drawing.Size(568, 50);
        this.LabelPort.TabIndex = 569;
        this.LabelPort.Text = "0.0.0.0.0";
        this.LabelPort.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.LabelPort.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuToolTip1.SetToolTip(this.LabelPort, "");
        this.bunifuToolTip1.SetToolTipIcon(this.LabelPort, null);
        this.bunifuToolTip1.SetToolTipTitle(this.LabelPort, "");
        this.bunifuLabel21.AllowParentOverrides = false;
        this.bunifuLabel21.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.bunifuLabel21.AutoEllipsis = false;
        this.bunifuLabel21.AutoSize = false;
        this.bunifuLabel21.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel21.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel21.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.bunifuLabel21.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel21.Location = new System.Drawing.Point(16, 17);
        this.bunifuLabel21.Name = "bunifuLabel21";
        this.bunifuLabel21.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel21.Size = new System.Drawing.Size(568, 17);
        this.bunifuLabel21.TabIndex = 568;
        this.bunifuLabel21.Text = "Additional settings panel";
        this.bunifuLabel21.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel21.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuToolTip1.SetToolTip(this.bunifuLabel21, "");
        this.bunifuToolTip1.SetToolTipIcon(this.bunifuLabel21, null);
        this.bunifuToolTip1.SetToolTipTitle(this.bunifuLabel21, "");
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(656, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 168);
        this.PanelRight.TabIndex = 591;
        this.bunifuToolTip1.SetToolTip(this.PanelRight, "");
        this.bunifuToolTip1.SetToolTipIcon(this.PanelRight, null);
        this.bunifuToolTip1.SetToolTipTitle(this.PanelRight, "");
        this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.CopyPort, this.CopyAll });
        this.contextMenuStrip1.Name = "contextMenuStrip1";
        this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        this.contextMenuStrip1.Size = new System.Drawing.Size(141, 48);
        this.bunifuToolTip1.SetToolTip(this.contextMenuStrip1, "");
        this.bunifuToolTip1.SetToolTipIcon(this.contextMenuStrip1, null);
        this.bunifuToolTip1.SetToolTipTitle(this.contextMenuStrip1, "");
        this.CopyPort.BackColor = System.Drawing.Color.White;
        this.CopyPort.Image = (System.Drawing.Image)resources.GetObject("CopyPort.Image");
        this.CopyPort.Name = "CopyPort";
        this.CopyPort.Size = new System.Drawing.Size(140, 22);
        this.CopyPort.Text = "Copy Port";
        this.CopyPort.Click += new System.EventHandler(CopyPort_Click);
        this.CopyAll.BackColor = System.Drawing.Color.White;
        this.CopyAll.Image = (System.Drawing.Image)resources.GetObject("CopyAll.Image");
        this.CopyAll.Name = "CopyAll";
        this.CopyAll.Size = new System.Drawing.Size(140, 22);
        this.CopyAll.Text = "Copy IP:Port";
        this.CopyAll.Click += new System.EventHandler(CopyAll_Click);
        this.bunifuElipse1.ElipseRadius = 40;
        this.bunifuElipse1.TargetControl = this.panelForm;
        this.bunifuFormDrag1.AllowOpacityChangesWhileDragging = false;
        this.bunifuFormDrag1.ContainerControl = this;
        this.bunifuFormDrag1.DockIndicatorsOpacity = 0.5;
        this.bunifuFormDrag1.DockingIndicatorsColor = System.Drawing.Color.FromArgb(202, 215, 233);
        this.bunifuFormDrag1.DockingOptions.DockAll = false;
        this.bunifuFormDrag1.DockingOptions.DockBottomLeft = false;
        this.bunifuFormDrag1.DockingOptions.DockBottomRight = false;
        this.bunifuFormDrag1.DockingOptions.DockFullScreen = false;
        this.bunifuFormDrag1.DockingOptions.DockLeft = false;
        this.bunifuFormDrag1.DockingOptions.DockRight = false;
        this.bunifuFormDrag1.DockingOptions.DockTopLeft = false;
        this.bunifuFormDrag1.DockingOptions.DockTopRight = false;
        this.bunifuFormDrag1.DragOpacity = 0.9;
        this.bunifuFormDrag1.Enabled = true;
        this.bunifuFormDrag1.ParentForm = this;
        this.bunifuFormDrag1.ShowCursorChanges = true;
        this.bunifuFormDrag1.ShowDockingIndicators = true;
        this.bunifuFormDrag1.TitleBarOptions.BunifuFormDrag = this.bunifuFormDrag1;
        this.bunifuFormDrag1.TitleBarOptions.DoubleClickToExpandWindow = true;
        this.bunifuFormDrag1.TitleBarOptions.Enabled = true;
        this.bunifuFormDrag1.TitleBarOptions.TitleBarControl = this.panelTitle;
        this.bunifuFormDrag1.TitleBarOptions.UseBackColorOnDockingIndicators = false;
        this.timer1.Interval = 2000;
        this.timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.bunifuLabel3.AllowParentOverrides = false;
        this.bunifuLabel3.AutoEllipsis = false;
        this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel3.ForeColor = System.Drawing.Color.FromArgb(26, 26, 26);
        this.bunifuLabel3.Location = new System.Drawing.Point(36, 16);
        this.bunifuLabel3.Name = "bunifuLabel3";
        this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel3.Size = new System.Drawing.Size(541, 15);
        this.bunifuLabel3.TabIndex = 577;
        this.bunifuLabel3.Text = "It is recommended that you select a picture in pixel size 67 x 67 in order to give you an excellent quality";
        this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuToolTip1.SetToolTip(this.bunifuLabel3, "");
        this.bunifuToolTip1.SetToolTipIcon(this.bunifuLabel3, null);
        this.bunifuToolTip1.SetToolTipTitle(this.bunifuLabel3, "");
        this.bunifuToolTip1.Active = true;
        this.bunifuToolTip1.AlignTextWithTitle = false;
        this.bunifuToolTip1.AllowAutoClose = false;
        this.bunifuToolTip1.AllowFading = true;
        this.bunifuToolTip1.AutoCloseDuration = 5000;
        this.bunifuToolTip1.BackColor = System.Drawing.SystemColors.Control;
        this.bunifuToolTip1.BorderColor = System.Drawing.Color.Gainsboro;
        this.bunifuToolTip1.ClickToShowDisplayControl = false;
        this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
        this.bunifuToolTip1.DisplayControl = null;
        this.bunifuToolTip1.EntryAnimationSpeed = 350;
        this.bunifuToolTip1.ExitAnimationSpeed = 200;
        this.bunifuToolTip1.GenerateAutoCloseDuration = false;
        this.bunifuToolTip1.IconMargin = 6;
        this.bunifuToolTip1.InitialDelay = 0;
        this.bunifuToolTip1.Name = "bunifuToolTip1";
        this.bunifuToolTip1.Opacity = 1.0;
        this.bunifuToolTip1.OverrideToolTipTitles = false;
        this.bunifuToolTip1.Padding = new System.Windows.Forms.Padding(10);
        this.bunifuToolTip1.ReshowDelay = 100;
        this.bunifuToolTip1.ShowAlways = true;
        this.bunifuToolTip1.ShowBorders = false;
        this.bunifuToolTip1.ShowIcons = true;
        this.bunifuToolTip1.ShowShadows = true;
        this.bunifuToolTip1.Tag = null;
        this.bunifuToolTip1.TextFont = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuToolTip1.TextForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.bunifuToolTip1.TextMargin = 2;
        this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
        this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.Black;
        this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
        this.bunifuToolTip1.ToolTipTitle = null;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(690, 411);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "ReversePeoxy";
        base.ShowIcon = false;
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "ReverseProxy";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ReversePeoxy_FormClosing);
        base.Load += new System.EventHandler(ReverseProxy_Load);
        base.Shown += new System.EventHandler(ReverseProxy_Shown);
        this.panelForm.ResumeLayout(false);
        this.panelTitle.ResumeLayout(false);
        this.panelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        this.bunifuShadowPanel_0.ResumeLayout(false);
        this.contextMenuStrip1.ResumeLayout(false);
        base.ResumeLayout(false);
    }
}
