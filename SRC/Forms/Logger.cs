using authguard;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Helper;
using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class Logger : Form
{
    public static API auth_sample = new API("1.0", "WmHrSzb69eeRpaXmEbGNziuVawnbStajthb", "2875a74413b7970bca1e31aaf619d562");

    private IContainer components = null;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    private Guna2GradientButton Login;

    private BunifuLabel bunifuLabel1;

    private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;

    private BunifuTextBox password;

    private BunifuTextBox username;

    private Label label2;

    private BunifuLabel losg;

    private BunifuLabel bunifuLabel17;

    private Panel panel1;

    private BunifuDragControl bunifuDragControl1;

    public Utilities.BunifuPages.BunifuTransition TransitionShowng;

    private BunifuCheckBox RememberMeTolgo;

    private Label Rememberme;

    public Logger()
    {
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
    }

    private void Logger_Load(object sender, EventArgs e)
    {
        if (!Methods.InternetState())
        {
            MessageBox.Show(this, "Please check internet connection!", "SilverRAT!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Close();
        }
        else
        {
            auth_sample.init();
            ReadProfil();
        }
        Settings.ServerCertificate = new X509Certificate2(Settings.CertificatePath);
    }

    private void Login_Click(object sender, EventArgs e)
    {
        Login.Enabled = false;
        losg.Text = "Please wait logging in ...";
        if (auth_sample.login(username.Text, password.Text))
        {
            if (RememberMeTolgo.Checked)
            {
                SaveProfil();
            }
            losg.Text = "Wait a moment for the program to initialize...";
            Program.Silver = new FormSilver();
            TransitionShowng.HideSync(panel1);
            Hide();
            Program.Silver.Show();
        }
        losg.Text = "";
        Login.Enabled = true;

    }

    private void Logger_Shown(object sender, EventArgs e)
    {
        TransitionShowng.ShowSync(panel1);
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        TransitionShowng.HideSync(panel1);
        Close();
    }

    private void ButtionMinimized_Click(object sender, EventArgs e)
    {
        if (base.WindowState != FormWindowState.Minimized)
        {
            base.WindowState = FormWindowState.Minimized;
        }
    }

    private void Logger_FormClosing(object sender, FormClosingEventArgs e)
    {
        Application.Exit();
    }

    private void ReadProfil()
    {
        try
        {
            Profile profile = new Profile("UserData");
            username.Text = profile.UsernameLogin;
            password.Text = profile.PasswordLogin;
        }
        catch
        {
        }
    }

    private void SaveProfil()
    {
        try
        {
            new Profile("UserData")
            {
                UsernameLogin = username.Text,
                PasswordLogin = password.Text
            };
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.Logger));
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.Login = new Guna.UI2.WinForms.Guna2GradientButton();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.username = new Bunifu.UI.WinForms.BunifuTextBox();
        this.password = new Bunifu.UI.WinForms.BunifuTextBox();
        this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
        this.label2 = new System.Windows.Forms.Label();
        this.bunifuLabel17 = new Bunifu.UI.WinForms.BunifuLabel();
        this.losg = new Bunifu.UI.WinForms.BunifuLabel();
        this.panel1 = new System.Windows.Forms.Panel();
        this.RememberMeTolgo = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.Rememberme = new System.Windows.Forms.Label();
        this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.TransitionShowng = new Utilities.BunifuPages.BunifuTransition(this.components);
        this.panel1.SuspendLayout();
        base.SuspendLayout();
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
        this.ButtClose.Location = new System.Drawing.Point(342, 4);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 579;
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
        this.ButtionMinimized.Location = new System.Drawing.Point(319, 4);
        this.ButtionMinimized.Name = "ButtionMinimized";
        this.ButtionMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtionMinimized.ShadowDecoration.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Size = new System.Drawing.Size(17, 17);
        this.ButtionMinimized.TabIndex = 580;
        this.ButtionMinimized.Click += new System.EventHandler(ButtionMinimized_Click);
        this.Login.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.Login.Animated = true;
        this.Login.BackColor = System.Drawing.Color.Transparent;
        this.Login.BorderRadius = 15;
        this.Login.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Login.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Login.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Login.CheckedState.Parent = this.Login;
        this.Login.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Login.CustomImages.Parent = this.Login;
        this.Login.FillColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.Login.FillColor2 = System.Drawing.Color.Black;
        this.Login.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.Login.ForeColor = System.Drawing.Color.White;
        this.Login.HoverState.Parent = this.Login;
        this.Login.Location = new System.Drawing.Point(222, 265);
        this.Login.Name = "Login";
        this.Login.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.Login.PressedDepth = 50;
        this.Login.ShadowDecoration.Parent = this.Login;
        this.Login.Size = new System.Drawing.Size(103, 30);
        this.Login.TabIndex = 581;
        this.Login.Text = "Login";
        this.Login.Click += new System.EventHandler(Login_Click);
        this.bunifuLabel1.AllowParentOverrides = false;
        this.bunifuLabel1.AutoEllipsis = false;
        this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.bunifuLabel1.Location = new System.Drawing.Point(7, 5);
        this.bunifuLabel1.Name = "bunifuLabel1";
        this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel1.Size = new System.Drawing.Size(91, 15);
        this.bunifuLabel1.TabIndex = 611;
        this.bunifuLabel1.Text = "Silver RAT | Login ";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.username.AcceptsReturn = false;
        this.username.AcceptsTab = false;
        this.username.AnimationSpeed = 200;
        this.username.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.username.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.username.AutoSizeHeight = true;
        this.username.BackColor = System.Drawing.Color.Transparent;
        this.username.BackgroundImage = (System.Drawing.Image)resources.GetObject("username.BackgroundImage");
        this.username.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.username.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.username.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.username.BorderColorIdle = System.Drawing.Color.Silver;
        this.username.BorderRadius = 2;
        this.username.BorderThickness = 1;
        this.username.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.username.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.username.DefaultText = "";
        this.username.FillColor = System.Drawing.Color.White;
        this.username.HideSelection = true;
        this.username.IconLeft = (System.Drawing.Image)resources.GetObject("username.IconLeft");
        this.username.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.username.IconPadding = 5;
        this.username.IconRight = null;
        this.username.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.username.Lines = new string[0];
        this.username.Location = new System.Drawing.Point(41, 171);
        this.username.MaxLength = 32767;
        this.username.MinimumSize = new System.Drawing.Size(1, 1);
        this.username.Modified = false;
        this.username.Multiline = false;
        this.username.Name = "username";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.username.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.username.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.username.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.username.OnIdleState = stateProperties4;
        this.username.Padding = new System.Windows.Forms.Padding(3);
        this.username.PasswordChar = '\0';
        this.username.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.username.PlaceholderText = "Username";
        this.username.ReadOnly = false;
        this.username.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.username.SelectedText = "";
        this.username.SelectionLength = 0;
        this.username.SelectionStart = 0;
        this.username.ShortcutsEnabled = true;
        this.username.Size = new System.Drawing.Size(284, 28);
        this.username.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.username.TabIndex = 601;
        this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.username.TextMarginBottom = 0;
        this.username.TextMarginLeft = 3;
        this.username.TextMarginTop = 1;
        this.username.TextPlaceholder = "Username";
        this.username.UseSystemPasswordChar = false;
        this.username.WordWrap = true;
        this.password.AcceptsReturn = false;
        this.password.AcceptsTab = false;
        this.password.AnimationSpeed = 200;
        this.password.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.password.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.password.AutoSizeHeight = true;
        this.password.BackColor = System.Drawing.Color.Transparent;
        this.password.BackgroundImage = (System.Drawing.Image)resources.GetObject("password.BackgroundImage");
        this.password.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.password.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.password.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.password.BorderColorIdle = System.Drawing.Color.Silver;
        this.password.BorderRadius = 2;
        this.password.BorderThickness = 1;
        this.password.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.password.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.password.DefaultText = "";
        this.password.FillColor = System.Drawing.Color.White;
        this.password.HideSelection = true;
        this.password.IconLeft = (System.Drawing.Image)resources.GetObject("password.IconLeft");
        this.password.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.password.IconPadding = 5;
        this.password.IconRight = null;
        this.password.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.password.Lines = new string[0];
        this.password.Location = new System.Drawing.Point(41, 219);
        this.password.MaxLength = 32767;
        this.password.MinimumSize = new System.Drawing.Size(1, 1);
        this.password.Modified = false;
        this.password.Multiline = false;
        this.password.Name = "password";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.password.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.password.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.password.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.password.OnIdleState = stateProperties8;
        this.password.Padding = new System.Windows.Forms.Padding(3);
        this.password.PasswordChar = '\0';
        this.password.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.password.PlaceholderText = "Password";
        this.password.ReadOnly = false;
        this.password.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.password.SelectedText = "";
        this.password.SelectionLength = 0;
        this.password.SelectionStart = 0;
        this.password.ShortcutsEnabled = true;
        this.password.Size = new System.Drawing.Size(284, 28);
        this.password.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.password.TabIndex = 602;
        this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.password.TextMarginBottom = 0;
        this.password.TextMarginLeft = 3;
        this.password.TextMarginTop = 1;
        this.password.TextPlaceholder = "Password";
        this.password.UseSystemPasswordChar = true;
        this.password.WordWrap = true;
        this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
        this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
        this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
        this.bunifuSeparator1.LineColor = System.Drawing.Color.Silver;
        this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
        this.bunifuSeparator1.LineThickness = 1;
        this.bunifuSeparator1.Location = new System.Drawing.Point(63, 94);
        this.bunifuSeparator1.Name = "bunifuSeparator1";
        this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
        this.bunifuSeparator1.Size = new System.Drawing.Size(225, 14);
        this.bunifuSeparator1.TabIndex = 603;
        this.label2.AutoSize = true;
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Font = new System.Drawing.Font("Segoe UI", 22.25f, System.Drawing.FontStyle.Bold);
        this.label2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.label2.Location = new System.Drawing.Point(121, 50);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(117, 41);
        this.label2.TabIndex = 604;
        this.label2.Text = "Sign In";
        this.bunifuLabel17.AllowParentOverrides = false;
        this.bunifuLabel17.AutoEllipsis = false;
        this.bunifuLabel17.AutoSize = false;
        this.bunifuLabel17.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.bunifuLabel17.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel17.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel17.Location = new System.Drawing.Point(0, 362);
        this.bunifuLabel17.Name = "bunifuLabel17";
        this.bunifuLabel17.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel17.Size = new System.Drawing.Size(366, 22);
        this.bunifuLabel17.TabIndex = 605;
        this.bunifuLabel17.Text = "© Copyright Silver RAT. All Rights Reserved";
        this.bunifuLabel17.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel17.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.losg.AllowParentOverrides = false;
        this.losg.AutoEllipsis = false;
        this.losg.CursorType = null;
        this.losg.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.losg.ForeColor = System.Drawing.SystemColors.WindowText;
        this.losg.Location = new System.Drawing.Point(63, 104);
        this.losg.Name = "losg";
        this.losg.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.losg.Size = new System.Drawing.Size(0, 0);
        this.losg.TabIndex = 612;
        this.losg.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.losg.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panel1.BackColor = System.Drawing.Color.FromArgb(244, 244, 243);
        this.panel1.Controls.Add(this.RememberMeTolgo);
        this.panel1.Controls.Add(this.Rememberme);
        this.panel1.Controls.Add(this.label2);
        this.panel1.Controls.Add(this.bunifuLabel17);
        this.panel1.Controls.Add(this.bunifuLabel1);
        this.panel1.Controls.Add(this.username);
        this.panel1.Controls.Add(this.losg);
        this.panel1.Controls.Add(this.ButtClose);
        this.panel1.Controls.Add(this.ButtionMinimized);
        this.panel1.Controls.Add(this.Login);
        this.panel1.Controls.Add(this.password);
        this.panel1.Controls.Add(this.bunifuSeparator1);
        this.panel1.Location = new System.Drawing.Point(12, 12);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(366, 384);
        this.panel1.TabIndex = 613;
        this.panel1.Visible = false;
        this.RememberMeTolgo.AllowBindingControlAnimation = true;
        this.RememberMeTolgo.AllowBindingControlColorChanges = false;
        this.RememberMeTolgo.AllowBindingControlLocation = true;
        this.RememberMeTolgo.AllowCheckBoxAnimation = true;
        this.RememberMeTolgo.AllowCheckmarkAnimation = true;
        this.RememberMeTolgo.AllowOnHoverStates = true;
        this.RememberMeTolgo.AutoCheck = true;
        this.RememberMeTolgo.BackColor = System.Drawing.Color.Transparent;
        this.RememberMeTolgo.BackgroundImage = (System.Drawing.Image)resources.GetObject("RememberMeTolgo.BackgroundImage");
        this.RememberMeTolgo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.RememberMeTolgo.BindingControl = this.Rememberme;
        this.RememberMeTolgo.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.RememberMeTolgo.BorderRadius = 6;
        this.RememberMeTolgo.Checked = false;
        this.RememberMeTolgo.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.RememberMeTolgo.Cursor = System.Windows.Forms.Cursors.Hand;
        this.RememberMeTolgo.CustomCheckmarkImage = null;
        this.RememberMeTolgo.Location = new System.Drawing.Point(42, 253);
        this.RememberMeTolgo.MinimumSize = new System.Drawing.Size(17, 17);
        this.RememberMeTolgo.Name = "RememberMeTolgo";
        this.RememberMeTolgo.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.RememberMeTolgo.OnCheck.BorderRadius = 6;
        this.RememberMeTolgo.OnCheck.BorderThickness = 2;
        this.RememberMeTolgo.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.RememberMeTolgo.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.RememberMeTolgo.OnCheck.CheckmarkThickness = 2;
        this.RememberMeTolgo.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.RememberMeTolgo.OnDisable.BorderRadius = 6;
        this.RememberMeTolgo.OnDisable.BorderThickness = 2;
        this.RememberMeTolgo.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.RememberMeTolgo.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.RememberMeTolgo.OnDisable.CheckmarkThickness = 2;
        this.RememberMeTolgo.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.RememberMeTolgo.OnHoverChecked.BorderRadius = 6;
        this.RememberMeTolgo.OnHoverChecked.BorderThickness = 2;
        this.RememberMeTolgo.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.RememberMeTolgo.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.RememberMeTolgo.OnHoverChecked.CheckmarkThickness = 2;
        this.RememberMeTolgo.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.RememberMeTolgo.OnHoverUnchecked.BorderRadius = 6;
        this.RememberMeTolgo.OnHoverUnchecked.BorderThickness = 1;
        this.RememberMeTolgo.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.RememberMeTolgo.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.RememberMeTolgo.OnUncheck.BorderRadius = 6;
        this.RememberMeTolgo.OnUncheck.BorderThickness = 1;
        this.RememberMeTolgo.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.RememberMeTolgo.Size = new System.Drawing.Size(21, 21);
        this.RememberMeTolgo.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.RememberMeTolgo.TabIndex = 614;
        this.RememberMeTolgo.ThreeState = false;
        this.RememberMeTolgo.ToolTipText = null;
        this.Rememberme.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.Rememberme.AutoSize = true;
        this.Rememberme.BackColor = System.Drawing.Color.Transparent;
        this.Rememberme.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Rememberme.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.Rememberme.ForeColor = System.Drawing.Color.Black;
        this.Rememberme.Location = new System.Drawing.Point(66, 257);
        this.Rememberme.Name = "Rememberme";
        this.Rememberme.Size = new System.Drawing.Size(85, 15);
        this.Rememberme.TabIndex = 613;
        this.Rememberme.Text = "Remember me";
        this.bunifuDragControl1.Fixed = true;
        this.bunifuDragControl1.Horizontal = true;
        this.bunifuDragControl1.TargetControl = this.panel1;
        this.bunifuDragControl1.Vertical = true;
        this.TransitionShowng.AnimationType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Scale;
        this.TransitionShowng.Cursor = null;
        animation.AnimateOnlyDifferences = true;
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
        this.TransitionShowng.DefaultAnimation = animation;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(390, 408);
        base.Controls.Add(this.panel1);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "Logger";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Silver Rat | Login";
        base.TopMost = true;
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Logger_FormClosing);
        base.Load += new System.EventHandler(Logger_Load);
        base.Shown += new System.EventHandler(Logger_Shown);
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        base.ResumeLayout(false);
    }
}
