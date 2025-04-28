using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Connection;
using SilverRAT.MessagePack;
using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class FormNote : Form
{
    public bool Complete = false;

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

    private PictureBox pictureBox1;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    private Guna2ResizeBox FormResizeBox1;

    private BunifuLabel bunifuLabel6;

    private BunifuLabel bunifuLabel5;

    private BunifuLabel bunifuLabel4;

    private BunifuLabel bunifuLabel3;

    private BunifuTextBox LabelDate;

    private BunifuTextBox LabelType;

    private BunifuTextBox labelsize;

    private BunifuTextBox labelfile;

    private System.Windows.Forms.Timer Timer1;

    public RichTextBox TextBox1;

    public BunifuLoader LoaderConnect;

    public Guna2GradientButton Save;

    internal Clients Client { get; set; }

    public string Info { get; set; }

    public string PathsFile { get; set; }

    public string SizeFile { get; set; }

    public string TypeFile { get; set; }

    public string DateFile { get; set; }

    public FormNote()
    {
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
    }

    private void FormNote_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void FormNote_Load(object sender, EventArgs e)
    {
        UserIdInfo.Text = Info;
        labelfile.Text = PathsFile;
        labelsize.Text = SizeFile;
        LabelType.Text = TypeFile;
        LabelDate.Text = DateFile;
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

    private void Save_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "EditorSave";
            msgPack.ForcePathObject("File").AsString = labelfile.Text;
            msgPack.ForcePathObject("TXT").AsString = Convert.ToBase64String(Encoding.UTF8.GetBytes(TextBox1.Text));
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            Close();
        }
        catch
        {
            Close();
        }
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void FormNote_FormClosing(object sender, FormClosingEventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(panelForm);
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.FormNote));
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
        this.LoaderConnect = new Bunifu.UI.WinForms.BunifuLoader();
        this.bunifuLabel6 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel5 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
        this.LabelDate = new Bunifu.UI.WinForms.BunifuTextBox();
        this.LabelType = new Bunifu.UI.WinForms.BunifuTextBox();
        this.labelsize = new Bunifu.UI.WinForms.BunifuTextBox();
        this.labelfile = new Bunifu.UI.WinForms.BunifuTextBox();
        this.TextBox1 = new System.Windows.Forms.RichTextBox();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtonMaximized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.UserIdInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.Save = new Guna.UI2.WinForms.Guna2GradientButton();
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.LoaderConnect);
        this.panelForm.Controls.Add(this.bunifuLabel6);
        this.panelForm.Controls.Add(this.bunifuLabel5);
        this.panelForm.Controls.Add(this.bunifuLabel4);
        this.panelForm.Controls.Add(this.bunifuLabel3);
        this.panelForm.Controls.Add(this.LabelDate);
        this.panelForm.Controls.Add(this.LabelType);
        this.panelForm.Controls.Add(this.labelsize);
        this.panelForm.Controls.Add(this.labelfile);
        this.panelForm.Controls.Add(this.TextBox1);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Controls.Add(this.Save);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(626, 475);
        this.panelForm.TabIndex = 571;
        this.panelForm.Visible = false;
        this.LoaderConnect.AllowStylePresets = true;
        this.LoaderConnect.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.LoaderConnect.BackColor = System.Drawing.Color.Transparent;
        this.LoaderConnect.CapStyle = Bunifu.UI.WinForms.BunifuLoader.CapStyles.Flat;
        this.LoaderConnect.Color = System.Drawing.Color.FromArgb(87, 59, 255);
        this.LoaderConnect.Colors = new Bunifu.UI.WinForms.Bloom[0];
        this.LoaderConnect.Cursor = System.Windows.Forms.Cursors.Arrow;
        this.LoaderConnect.Customization = "";
        this.LoaderConnect.DashWidth = 0.5f;
        this.LoaderConnect.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.LoaderConnect.Image = null;
        this.LoaderConnect.Location = new System.Drawing.Point(268, 243);
        this.LoaderConnect.Name = "LoaderConnect";
        this.LoaderConnect.NoRounding = false;
        this.LoaderConnect.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Dashed;
        this.LoaderConnect.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Dashed;
        this.LoaderConnect.ShowText = false;
        this.LoaderConnect.Size = new System.Drawing.Size(103, 100);
        this.LoaderConnect.Speed = 7;
        this.LoaderConnect.TabIndex = 610;
        this.LoaderConnect.Text = "bunifuLoader1";
        this.LoaderConnect.TextPadding = new System.Windows.Forms.Padding(0);
        this.LoaderConnect.Thickness = 6;
        this.LoaderConnect.Transparent = true;
        this.bunifuLabel6.AllowParentOverrides = false;
        this.bunifuLabel6.AutoEllipsis = false;
        this.bunifuLabel6.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel6.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel6.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel6.ForeColor = System.Drawing.Color.DarkGray;
        this.bunifuLabel6.Location = new System.Drawing.Point(434, 112);
        this.bunifuLabel6.Name = "bunifuLabel6";
        this.bunifuLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel6.Size = new System.Drawing.Size(30, 15);
        this.bunifuLabel6.TabIndex = 609;
        this.bunifuLabel6.Text = "Date :";
        this.bunifuLabel6.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel6.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuLabel5.AllowParentOverrides = false;
        this.bunifuLabel5.AutoEllipsis = false;
        this.bunifuLabel5.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel5.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel5.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel5.ForeColor = System.Drawing.Color.DarkGray;
        this.bunifuLabel5.Location = new System.Drawing.Point(295, 112);
        this.bunifuLabel5.Name = "bunifuLabel5";
        this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel5.Size = new System.Drawing.Size(31, 15);
        this.bunifuLabel5.TabIndex = 608;
        this.bunifuLabel5.Text = "Type :";
        this.bunifuLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuLabel4.AllowParentOverrides = false;
        this.bunifuLabel4.AutoEllipsis = false;
        this.bunifuLabel4.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel4.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel4.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel4.ForeColor = System.Drawing.Color.DarkGray;
        this.bunifuLabel4.Location = new System.Drawing.Point(155, 112);
        this.bunifuLabel4.Name = "bunifuLabel4";
        this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel4.Size = new System.Drawing.Size(26, 15);
        this.bunifuLabel4.TabIndex = 607;
        this.bunifuLabel4.Text = "Size :";
        this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuLabel3.AllowParentOverrides = false;
        this.bunifuLabel3.AutoEllipsis = false;
        this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel3.ForeColor = System.Drawing.Color.DarkGray;
        this.bunifuLabel3.Location = new System.Drawing.Point(19, 112);
        this.bunifuLabel3.Name = "bunifuLabel3";
        this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel3.Size = new System.Drawing.Size(24, 15);
        this.bunifuLabel3.TabIndex = 606;
        this.bunifuLabel3.Text = "File :";
        this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.LabelDate.AcceptsReturn = false;
        this.LabelDate.AcceptsTab = false;
        this.LabelDate.AnimationSpeed = 200;
        this.LabelDate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.LabelDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.LabelDate.AutoSizeHeight = true;
        this.LabelDate.BackColor = System.Drawing.Color.Transparent;
        this.LabelDate.BackgroundImage = (System.Drawing.Image)resources.GetObject("LabelDate.BackgroundImage");
        this.LabelDate.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.LabelDate.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.LabelDate.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.LabelDate.BorderColorIdle = System.Drawing.Color.Silver;
        this.LabelDate.BorderRadius = 2;
        this.LabelDate.BorderThickness = 1;
        this.LabelDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.LabelDate.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.LabelDate.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.LabelDate.DefaultText = "";
        this.LabelDate.FillColor = System.Drawing.Color.White;
        this.LabelDate.HideSelection = true;
        this.LabelDate.IconLeft = null;
        this.LabelDate.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.LabelDate.IconPadding = 10;
        this.LabelDate.IconRight = null;
        this.LabelDate.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.LabelDate.Lines = new string[0];
        this.LabelDate.Location = new System.Drawing.Point(434, 133);
        this.LabelDate.MaxLength = 32767;
        this.LabelDate.MinimumSize = new System.Drawing.Size(1, 1);
        this.LabelDate.Modified = false;
        this.LabelDate.Multiline = false;
        this.LabelDate.Name = "LabelDate";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.LabelDate.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.LabelDate.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.LabelDate.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.LabelDate.OnIdleState = stateProperties4;
        this.LabelDate.Padding = new System.Windows.Forms.Padding(3);
        this.LabelDate.PasswordChar = '\0';
        this.LabelDate.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.LabelDate.PlaceholderText = "Date";
        this.LabelDate.ReadOnly = true;
        this.LabelDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.LabelDate.SelectedText = "";
        this.LabelDate.SelectionLength = 0;
        this.LabelDate.SelectionStart = 0;
        this.LabelDate.ShortcutsEnabled = true;
        this.LabelDate.Size = new System.Drawing.Size(134, 28);
        this.LabelDate.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.LabelDate.TabIndex = 605;
        this.LabelDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.LabelDate.TextMarginBottom = 0;
        this.LabelDate.TextMarginLeft = 3;
        this.LabelDate.TextMarginTop = 1;
        this.LabelDate.TextPlaceholder = "Date";
        this.LabelDate.UseSystemPasswordChar = false;
        this.LabelDate.WordWrap = true;
        this.LabelType.AcceptsReturn = false;
        this.LabelType.AcceptsTab = false;
        this.LabelType.AnimationSpeed = 200;
        this.LabelType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.LabelType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.LabelType.AutoSizeHeight = true;
        this.LabelType.BackColor = System.Drawing.Color.Transparent;
        this.LabelType.BackgroundImage = (System.Drawing.Image)resources.GetObject("LabelType.BackgroundImage");
        this.LabelType.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.LabelType.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.LabelType.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.LabelType.BorderColorIdle = System.Drawing.Color.Silver;
        this.LabelType.BorderRadius = 2;
        this.LabelType.BorderThickness = 1;
        this.LabelType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.LabelType.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.LabelType.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.LabelType.DefaultText = "";
        this.LabelType.FillColor = System.Drawing.Color.White;
        this.LabelType.HideSelection = true;
        this.LabelType.IconLeft = null;
        this.LabelType.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.LabelType.IconPadding = 10;
        this.LabelType.IconRight = null;
        this.LabelType.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.LabelType.Lines = new string[0];
        this.LabelType.Location = new System.Drawing.Point(295, 133);
        this.LabelType.MaxLength = 32767;
        this.LabelType.MinimumSize = new System.Drawing.Size(1, 1);
        this.LabelType.Modified = false;
        this.LabelType.Multiline = false;
        this.LabelType.Name = "LabelType";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.LabelType.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.LabelType.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.LabelType.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.LabelType.OnIdleState = stateProperties8;
        this.LabelType.Padding = new System.Windows.Forms.Padding(3);
        this.LabelType.PasswordChar = '\0';
        this.LabelType.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.LabelType.PlaceholderText = "Type";
        this.LabelType.ReadOnly = true;
        this.LabelType.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.LabelType.SelectedText = "";
        this.LabelType.SelectionLength = 0;
        this.LabelType.SelectionStart = 0;
        this.LabelType.ShortcutsEnabled = true;
        this.LabelType.Size = new System.Drawing.Size(133, 28);
        this.LabelType.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.LabelType.TabIndex = 604;
        this.LabelType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.LabelType.TextMarginBottom = 0;
        this.LabelType.TextMarginLeft = 3;
        this.LabelType.TextMarginTop = 1;
        this.LabelType.TextPlaceholder = "Type";
        this.LabelType.UseSystemPasswordChar = false;
        this.LabelType.WordWrap = true;
        this.labelsize.AcceptsReturn = false;
        this.labelsize.AcceptsTab = false;
        this.labelsize.AnimationSpeed = 200;
        this.labelsize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.labelsize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.labelsize.AutoSizeHeight = true;
        this.labelsize.BackColor = System.Drawing.Color.Transparent;
        this.labelsize.BackgroundImage = (System.Drawing.Image)resources.GetObject("labelsize.BackgroundImage");
        this.labelsize.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.labelsize.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.labelsize.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.labelsize.BorderColorIdle = System.Drawing.Color.Silver;
        this.labelsize.BorderRadius = 2;
        this.labelsize.BorderThickness = 1;
        this.labelsize.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.labelsize.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.labelsize.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.labelsize.DefaultText = "";
        this.labelsize.FillColor = System.Drawing.Color.White;
        this.labelsize.HideSelection = true;
        this.labelsize.IconLeft = null;
        this.labelsize.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.labelsize.IconPadding = 10;
        this.labelsize.IconRight = null;
        this.labelsize.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.labelsize.Lines = new string[0];
        this.labelsize.Location = new System.Drawing.Point(155, 133);
        this.labelsize.MaxLength = 32767;
        this.labelsize.MinimumSize = new System.Drawing.Size(1, 1);
        this.labelsize.Modified = false;
        this.labelsize.Multiline = false;
        this.labelsize.Name = "labelsize";
        stateProperties9.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties9.FillColor = System.Drawing.Color.Empty;
        stateProperties9.ForeColor = System.Drawing.Color.Empty;
        stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.labelsize.OnActiveState = stateProperties9;
        stateProperties10.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties10.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties10.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.labelsize.OnDisabledState = stateProperties10;
        stateProperties11.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties11.FillColor = System.Drawing.Color.Empty;
        stateProperties11.ForeColor = System.Drawing.Color.Empty;
        stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.labelsize.OnHoverState = stateProperties11;
        stateProperties12.BorderColor = System.Drawing.Color.Silver;
        stateProperties12.FillColor = System.Drawing.Color.White;
        stateProperties12.ForeColor = System.Drawing.Color.Empty;
        stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.labelsize.OnIdleState = stateProperties12;
        this.labelsize.Padding = new System.Windows.Forms.Padding(3);
        this.labelsize.PasswordChar = '\0';
        this.labelsize.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.labelsize.PlaceholderText = "Size";
        this.labelsize.ReadOnly = true;
        this.labelsize.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.labelsize.SelectedText = "";
        this.labelsize.SelectionLength = 0;
        this.labelsize.SelectionStart = 0;
        this.labelsize.ShortcutsEnabled = true;
        this.labelsize.Size = new System.Drawing.Size(134, 28);
        this.labelsize.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.labelsize.TabIndex = 603;
        this.labelsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.labelsize.TextMarginBottom = 0;
        this.labelsize.TextMarginLeft = 3;
        this.labelsize.TextMarginTop = 1;
        this.labelsize.TextPlaceholder = "Size";
        this.labelsize.UseSystemPasswordChar = false;
        this.labelsize.WordWrap = true;
        this.labelfile.AcceptsReturn = false;
        this.labelfile.AcceptsTab = false;
        this.labelfile.AnimationSpeed = 200;
        this.labelfile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.labelfile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.labelfile.AutoSizeHeight = true;
        this.labelfile.BackColor = System.Drawing.Color.Transparent;
        this.labelfile.BackgroundImage = (System.Drawing.Image)resources.GetObject("labelfile.BackgroundImage");
        this.labelfile.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.labelfile.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.labelfile.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.labelfile.BorderColorIdle = System.Drawing.Color.Silver;
        this.labelfile.BorderRadius = 2;
        this.labelfile.BorderThickness = 1;
        this.labelfile.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.labelfile.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.labelfile.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.labelfile.DefaultText = "";
        this.labelfile.FillColor = System.Drawing.Color.White;
        this.labelfile.HideSelection = true;
        this.labelfile.IconLeft = null;
        this.labelfile.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.labelfile.IconPadding = 10;
        this.labelfile.IconRight = null;
        this.labelfile.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.labelfile.Lines = new string[0];
        this.labelfile.Location = new System.Drawing.Point(16, 133);
        this.labelfile.MaxLength = 32767;
        this.labelfile.MinimumSize = new System.Drawing.Size(1, 1);
        this.labelfile.Modified = false;
        this.labelfile.Multiline = false;
        this.labelfile.Name = "labelfile";
        stateProperties13.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties13.FillColor = System.Drawing.Color.Empty;
        stateProperties13.ForeColor = System.Drawing.Color.Empty;
        stateProperties13.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.labelfile.OnActiveState = stateProperties13;
        stateProperties14.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties14.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties14.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties14.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.labelfile.OnDisabledState = stateProperties14;
        stateProperties15.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties15.FillColor = System.Drawing.Color.Empty;
        stateProperties15.ForeColor = System.Drawing.Color.Empty;
        stateProperties15.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.labelfile.OnHoverState = stateProperties15;
        stateProperties16.BorderColor = System.Drawing.Color.Silver;
        stateProperties16.FillColor = System.Drawing.Color.White;
        stateProperties16.ForeColor = System.Drawing.Color.Empty;
        stateProperties16.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.labelfile.OnIdleState = stateProperties16;
        this.labelfile.Padding = new System.Windows.Forms.Padding(3);
        this.labelfile.PasswordChar = '\0';
        this.labelfile.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.labelfile.PlaceholderText = "File";
        this.labelfile.ReadOnly = true;
        this.labelfile.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.labelfile.SelectedText = "";
        this.labelfile.SelectionLength = 0;
        this.labelfile.SelectionStart = 0;
        this.labelfile.ShortcutsEnabled = true;
        this.labelfile.Size = new System.Drawing.Size(133, 28);
        this.labelfile.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.labelfile.TabIndex = 602;
        this.labelfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.labelfile.TextMarginBottom = 0;
        this.labelfile.TextMarginLeft = 3;
        this.labelfile.TextMarginTop = 1;
        this.labelfile.TextPlaceholder = "File";
        this.labelfile.UseSystemPasswordChar = false;
        this.labelfile.WordWrap = true;
        this.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.TextBox1.Location = new System.Drawing.Point(15, 167);
        this.TextBox1.Name = "TextBox1";
        this.TextBox1.Size = new System.Drawing.Size(595, 237);
        this.TextBox1.TabIndex = 601;
        this.TextBox1.Text = "";
        this.FormResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(599, 448);
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
        this.PanelTitle.Controls.Add(this.ButtClose);
        this.PanelTitle.Controls.Add(this.ButtionMinimized);
        this.PanelTitle.Controls.Add(this.ButtonMaximized);
        this.PanelTitle.Controls.Add(this.UserIdInfo);
        this.PanelTitle.Controls.Add(this.bunifuLabel1);
        this.PanelTitle.Controls.Add(this.pictureBox1);
        this.PanelTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
        this.PanelTitle.Location = new System.Drawing.Point(16, 22);
        this.PanelTitle.Name = "PanelTitle";
        this.PanelTitle.ShowBorders = true;
        this.PanelTitle.Size = new System.Drawing.Size(596, 77);
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
        this.ButtClose.Location = new System.Drawing.Point(566, 13);
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
        this.ButtionMinimized.Location = new System.Drawing.Point(518, 13);
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
        this.ButtonMaximized.Location = new System.Drawing.Point(542, 13);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(36, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Editor";
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
        this.PanelBottom.Location = new System.Drawing.Point(170, 464);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(293, 25);
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
        this.PanelLeft.Size = new System.Drawing.Size(25, 256);
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
        this.PanelTOP.Size = new System.Drawing.Size(293, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(616, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 256);
        this.PanelRight.TabIndex = 591;
        this.Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.Save.Animated = true;
        this.Save.BackColor = System.Drawing.Color.White;
        this.Save.BorderRadius = 1;
        this.Save.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Save.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Save.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Save.CheckedState.Parent = this.Save;
        this.Save.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Save.CustomImages.Parent = this.Save;
        this.Save.Enabled = false;
        this.Save.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Save.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Save.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.Save.ForeColor = System.Drawing.Color.White;
        this.Save.HoverState.Parent = this.Save;
        this.Save.Location = new System.Drawing.Point(513, 410);
        this.Save.Name = "Save";
        this.Save.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.Save.PressedDepth = 50;
        this.Save.ShadowDecoration.Parent = this.Save;
        this.Save.Size = new System.Drawing.Size(97, 25);
        this.Save.TabIndex = 574;
        this.Save.Text = "Save";
        this.Save.Click += new System.EventHandler(Save_Click);
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(650, 499);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "FormNote";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FormNote";
        base.TopMost = true;
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormNote_FormClosing);
        base.Load += new System.EventHandler(FormNote_Load);
        base.Shown += new System.EventHandler(FormNote_Shown);
        this.panelForm.ResumeLayout(false);
        this.panelForm.PerformLayout();
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        base.ResumeLayout(false);
    }
}
