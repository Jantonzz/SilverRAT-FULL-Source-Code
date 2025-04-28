using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class ScanNET : Form
{
    private IContainer components = null;

    private BunifuElipse bunifuElipse1;

    private BunifuFormDrag bunifuFormDrag1;

    public System.Windows.Forms.Timer Timer1;

    private Panel panelForm;

    private BunifuPanel panelTitle;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    public BunifuLoader LoaderConnect;

    private PictureBox ImageLogo;

    private BunifuLabel UserIdInfo;

    private BunifuLabel bunifuLabel1;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelLeft;

    public Guna2GradientButton ScanInternet;

    private BunifuShadowPanel bunifuShadowPanel_0;

    public BunifuLabel InfoSpeed;

    private BunifuLabel bunifuLabel21;

    private BunifuPanel PanelRight;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public ScanNET()
    {
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
    }

    private void ScanNET_Load(object sender, EventArgs e)
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

    private void ScanNET_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void ScanInternet_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Scan";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            ScanInternet.Enabled = false;
            InfoSpeed.ForeColor = Color.Black;
            InfoSpeed.Text = "Internet speed is being checked...";
        }
        catch
        {
        }
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void ButtionMinimized_Click(object sender, EventArgs e)
    {
        if (base.WindowState != FormWindowState.Minimized)
        {
            base.WindowState = FormWindowState.Minimized;
        }
    }

    private void ScanNET_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            Program.Silver.TransitionHiddeng.HideSync(panelForm);
            ThreadPool.QueueUserWorkItem(delegate
            {
                Client?.Disconnected();
            });
        }
        catch
        {
        }
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!ParentClient.TcpClient.Connected || !Client.TcpClient.Connected)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    Client?.Disconnected();
                });
                Close();
            }
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.ScanNET));
        this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
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
        this.ScanInternet = new Guna.UI2.WinForms.Guna2GradientButton();
        this.bunifuShadowPanel_0 = new Bunifu.UI.WinForms.BunifuShadowPanel();
        this.InfoSpeed = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel21 = new Bunifu.UI.WinForms.BunifuLabel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.bunifuFormDrag1 = new Bunifu.UI.WinForms.BunifuFormDrag();
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.panelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        this.bunifuShadowPanel_0.SuspendLayout();
        base.SuspendLayout();
        this.bunifuElipse1.ElipseRadius = 4;
        this.bunifuElipse1.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.panelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.ScanInternet);
        this.panelForm.Controls.Add(this.bunifuShadowPanel_0);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(666, 387);
        this.panelForm.TabIndex = 572;
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
        this.ButtClose.Click += new System.EventHandler(ButtClose_Click);
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
        this.LoaderConnect.Transparent = true;
        this.ImageLogo.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ImageLogo.Image = (System.Drawing.Image)resources.GetObject("ImageLogo.Image");
        this.ImageLogo.Location = new System.Drawing.Point(13, 13);
        this.ImageLogo.Name = "ImageLogo";
        this.ImageLogo.Size = new System.Drawing.Size(59, 50);
        this.ImageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageLogo.TabIndex = 570;
        this.ImageLogo.TabStop = false;
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
        this.bunifuLabel1.AllowParentOverrides = false;
        this.bunifuLabel1.AutoEllipsis = false;
        this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.bunifuLabel1.ForeColor = System.Drawing.Color.Black;
        this.bunifuLabel1.Location = new System.Drawing.Point(76, 18);
        this.bunifuLabel1.Name = "bunifuLabel1";
        this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel1.Size = new System.Drawing.Size(89, 17);
        this.bunifuLabel1.TabIndex = 568;
        this.bunifuLabel1.Text = "Internet speed";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
        this.ScanInternet.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.ScanInternet.Animated = true;
        this.ScanInternet.BackColor = System.Drawing.Color.White;
        this.ScanInternet.BorderRadius = 8;
        this.ScanInternet.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ScanInternet.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ScanInternet.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ScanInternet.CheckedState.Parent = this.ScanInternet;
        this.ScanInternet.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ScanInternet.CustomImages.Parent = this.ScanInternet;
        this.ScanInternet.Enabled = false;
        this.ScanInternet.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ScanInternet.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ScanInternet.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.ScanInternet.ForeColor = System.Drawing.Color.White;
        this.ScanInternet.HoverState.Parent = this.ScanInternet;
        this.ScanInternet.Location = new System.Drawing.Point(527, 339);
        this.ScanInternet.Name = "ScanInternet";
        this.ScanInternet.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.ScanInternet.PressedDepth = 50;
        this.ScanInternet.ShadowDecoration.Parent = this.ScanInternet;
        this.ScanInternet.Size = new System.Drawing.Size(103, 30);
        this.ScanInternet.TabIndex = 574;
        this.ScanInternet.Text = "Scan";
        this.ScanInternet.Click += new System.EventHandler(ScanInternet_Click);
        this.bunifuShadowPanel_0.BackColor = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.BorderColor = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.BorderRadius = 20;
        this.bunifuShadowPanel_0.BorderThickness = 1;
        this.bunifuShadowPanel_0.Controls.Add(this.InfoSpeed);
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
        this.InfoSpeed.AllowParentOverrides = false;
        this.InfoSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.InfoSpeed.AutoEllipsis = false;
        this.InfoSpeed.AutoSize = false;
        this.InfoSpeed.Cursor = System.Windows.Forms.Cursors.Default;
        this.InfoSpeed.CursorType = System.Windows.Forms.Cursors.Default;
        this.InfoSpeed.Font = new System.Drawing.Font("Segoe UI Black", 26.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.InfoSpeed.ForeColor = System.Drawing.Color.Black;
        this.InfoSpeed.Location = new System.Drawing.Point(16, 66);
        this.InfoSpeed.Name = "InfoSpeed";
        this.InfoSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.InfoSpeed.Size = new System.Drawing.Size(568, 92);
        this.InfoSpeed.TabIndex = 569;
        this.InfoSpeed.Text = "0MB";
        this.InfoSpeed.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.InfoSpeed.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
        this.bunifuLabel21.Text = "NET speed";
        this.bunifuLabel21.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel21.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(690, 411);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "ScanNET";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "ScanNET";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ScanNET_FormClosing);
        base.Load += new System.EventHandler(ScanNET_Load);
        base.Shown += new System.EventHandler(ScanNET_Shown);
        this.panelForm.ResumeLayout(false);
        this.panelTitle.ResumeLayout(false);
        this.panelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        this.bunifuShadowPanel_0.ResumeLayout(false);
        base.ResumeLayout(false);
    }
}
