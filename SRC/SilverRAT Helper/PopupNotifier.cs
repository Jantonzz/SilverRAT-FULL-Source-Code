#define DEBUG
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SilverRAT.Helper;

[ToolboxBitmap(typeof(PopupNotifier), "Icon.ico")]
[DefaultEvent("Click")]
public class PopupNotifier : Component
{
    private const int SW_SHOWNOACTIVATE = 4;

    private const int HWND_TOPMOST = -1;

    private const uint SWP_NOACTIVATE = 16u;

    private bool disposed = false;

    private PopupNotifierForm frmPopup;

    private Timer tmrAnimation;

    private Timer tmrWait;

    private bool isAppearing = true;

    private bool markedForDisposed = false;

    private bool mouseIsOn = false;

    private int maxPosition;

    private double maxOpacity;

    private int posStart;

    private int posStop;

    private double opacityStart;

    private double opacityStop;

    private int realAnimationDuration;

    private Stopwatch sw;

    private Size imageSize = new Size(0, 0);

    [Description("Color of the title text.")]
    [Category("Title")]
    [DefaultValue(typeof(Color), "Black")]
    public Color TitleColor { get; set; }

    [Category("Content")]
    [Description("Color of the content text.")]
    [DefaultValue(typeof(Color), "ControlText")]
    public Color ContentColor { get; set; }

    [Description("Color of the window border.")]
    [DefaultValue(typeof(Color), "WindowFrame")]
    [Category("Appearance")]
    public Color BorderColor { get; set; }

    [Category("Buttons")]
    [Description("Border color of the close and options buttons when the mouse is over them.")]
    [DefaultValue(typeof(Color), "WindowFrame")]
    public Color ButtonBorderColor { get; set; }

    [DefaultValue(typeof(Color), "Highlight")]
    [Description("Background color of the close and options buttons when the mouse is over them.")]
    [Category("Buttons")]
    public Color ButtonHoverColor { get; set; }

    [Description("Color of the content text when the mouse is hovering over it.")]
    [DefaultValue(typeof(Color), "HotTrack")]
    [Category("Content")]
    public Color ContentHoverColor { get; set; }

    public Color GetFormTopColor { get; set; }

    public Color GetFormBotomColor { get; set; }

    [Description("Font of the content text.")]
    [Category("Content")]
    public Font ContentFont { get; set; }

    [Description("Font of the title.")]
    [Category("Title")]
    public Font TitleFont { get; set; }

    [Description("Size of the icon image.")]
    [Category("Image")]
    public Size ImageSize
    {
        get
        {
            if (imageSize.Width == 0)
            {
                if (Image != null)
                {
                    return Image.Size;
                }
                return new Size(0, 0);
            }
            return imageSize;
        }
        set
        {
            imageSize = value;
        }
    }

    [Description("Icon image to display.")]
    [Category("Image")]
    public Image Image { get; set; }

    [Category("Header")]
    [Description("Whether to show a 'grip' image within the window header.")]
    [DefaultValue(true)]
    public bool ShowGrip { get; set; }

    [Category("Behavior")]
    [DefaultValue(true)]
    [Description("Whether to scroll the window or only fade it.")]
    public bool Scroll { get; set; }

    [Category("Content")]
    [Description("Content text to display.")]
    public string ContentText { get; set; }

    [Category("Title")]
    [Description("Title text to display.")]
    public string TitleText { get; set; }

    [Description("Padding of title text.")]
    [Category("Title")]
    public Padding TitlePadding { get; set; }

    [Description("Padding of content text.")]
    [Category("Content")]
    public Padding ContentPadding { get; set; }

    [Description("Padding of icon image.")]
    [Category("Image")]
    public Padding ImagePadding { get; set; }

    [Category("Header")]
    [Description("Height of window header.")]
    [DefaultValue(9)]
    public int HeaderHeight { get; set; }

    [Description("Whether to show the close button.")]
    [DefaultValue(true)]
    [Category("Buttons")]
    public bool ShowCloseButton { get; set; }

    [Description("Whether to show the options button.")]
    [DefaultValue(false)]
    [Category("Buttons")]
    public bool ShowOptionsButton { get; set; }

    [Description("Context menu to open when clicking on the options button.")]
    [Category("Behavior")]
    public ContextMenuStrip OptionsMenu { get; set; }

    [Description("Time in milliseconds the window is displayed.")]
    [DefaultValue(3000)]
    [Category("Behavior")]
    public int Delay { get; set; }

    [DefaultValue(1000)]
    [Description("Time in milliseconds needed to make the window appear or disappear.")]
    [Category("Behavior")]
    public int AnimationDuration { get; set; }

    [DefaultValue(10)]
    [Description("Interval in milliseconds used to draw the animation.")]
    [Category("Behavior")]
    public int AnimationInterval { get; set; }

    [Category("Appearance")]
    [Description("Size of the window.")]
    public Size Size { get; set; }

    [Category("Content")]
    [Description("Show Content Right To Left,نمایش پیغام چپ به راست فعال شود")]
    public bool IsRightToLeft { get; set; }

    public event EventHandler Click;

    public event EventHandler Close;

    public event EventHandler Appear;

    public event EventHandler Disappear;

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    private static void ShowInactiveTopmost(Form frm)
    {
        ShowWindow(frm.Handle, 4);
        SetWindowPos(frm.Handle.ToInt32(), -1, frm.Left, frm.Top, frm.Width, frm.Height, 16u);
    }

    public void ResetImageSize()
    {
        imageSize = Size.Empty;
    }

    private bool ShouldSerializeImageSize()
    {
        return !imageSize.Equals(Size.Empty);
    }

    private void ResetTitlePadding()
    {
        TitlePadding = Padding.Empty;
    }

    private bool ShouldSerializeTitlePadding()
    {
        return !TitlePadding.Equals(Padding.Empty);
    }

    private void ResetContentPadding()
    {
        ContentPadding = Padding.Empty;
    }

    private bool ShouldSerializeContentPadding()
    {
        return !ContentPadding.Equals(Padding.Empty);
    }

    private void ResetImagePadding()
    {
        ImagePadding = Padding.Empty;
    }

    private bool ShouldSerializeImagePadding()
    {
        return !ImagePadding.Equals(Padding.Empty);
    }

    public PopupNotifier()
    {
        ContentHoverColor = Color.Black;
        TitleFont = new Font("Segoe UI", 8f, FontStyle.Bold);
        TitleColor = Color.Black;
        ContentFont = SystemFonts.DialogFont;
        ContentColor = Color.Black;
        ShowGrip = true;
        Scroll = true;
        TitlePadding = new Padding(0);
        ContentPadding = new Padding(0);
        ImagePadding = new Padding(0);
        HeaderHeight = 9;
        ShowCloseButton = true;
        ShowOptionsButton = false;
        Delay = 3000;
        AnimationInterval = 10;
        AnimationDuration = 1000;
        Size = new Size(375, 59);
        frmPopup = new PopupNotifierForm(this);
        Guna2Elipse guna2Elipse = new Guna2Elipse
        {
            BorderRadius = 12
        };
        guna2Elipse.SetElipse(frmPopup);
        frmPopup.FormBorderStyle = FormBorderStyle.None;
        frmPopup.StartPosition = FormStartPosition.Manual;
        frmPopup.FormBorderStyle = FormBorderStyle.None;
        frmPopup.MouseEnter += frmPopup_MouseEnter;
        frmPopup.MouseLeave += frmPopup_MouseLeave;
        frmPopup.CloseClick += frmPopup_CloseClick;
        frmPopup.LinkClick += frmPopup_LinkClick;
        frmPopup.ContextMenuOpened += frmPopup_ContextMenuOpened;
        frmPopup.ContextMenuClosed += frmPopup_ContextMenuClosed;
        frmPopup.VisibleChanged += frmPopup_VisibleChanged;
        tmrAnimation = new Timer();
        tmrAnimation.Tick += tmAnimation_Tick;
        tmrWait = new Timer();
        tmrWait.Tick += tmWait_Tick;
    }

    public void Popup()
    {
        if (disposed)
        {
            return;
        }
        if (!frmPopup.Visible)
        {
            frmPopup.Size = Size;
            if (Scroll)
            {
                posStart = Screen.PrimaryScreen.WorkingArea.Bottom;
                posStop = Screen.PrimaryScreen.WorkingArea.Bottom - frmPopup.Height;
            }
            else
            {
                posStart = Screen.PrimaryScreen.WorkingArea.Bottom - frmPopup.Height;
                posStop = Screen.PrimaryScreen.WorkingArea.Bottom - frmPopup.Height;
            }
            opacityStart = 0.0;
            opacityStop = 1.0;
            frmPopup.Opacity = opacityStart;
            frmPopup.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - frmPopup.Size.Width - 1, posStart);
            ShowInactiveTopmost(frmPopup);
            isAppearing = true;
            tmrWait.Interval = Delay;
            tmrAnimation.Interval = AnimationInterval;
            realAnimationDuration = AnimationDuration;
            tmrAnimation.Start();
            sw = Stopwatch.StartNew();
            Debug.WriteLine("Animation started.");
            return;
        }
        if (!isAppearing)
        {
            frmPopup.Size = Size;
            if (Scroll)
            {
                posStart = frmPopup.Top;
                posStop = Screen.PrimaryScreen.WorkingArea.Bottom - frmPopup.Height;
            }
            else
            {
                posStart = Screen.PrimaryScreen.WorkingArea.Bottom - frmPopup.Height;
                posStop = Screen.PrimaryScreen.WorkingArea.Bottom - frmPopup.Height;
            }
            opacityStart = frmPopup.Opacity;
            opacityStop = 1.0;
            isAppearing = true;
            realAnimationDuration = Math.Max((int)sw.ElapsedMilliseconds, 1);
            sw.Restart();
            Debug.WriteLine("Animation direction changed.");
        }
        frmPopup.Invalidate();
    }

    public void Hide()
    {
        Debug.WriteLine("Animation stopped.");
        Debug.WriteLine("Wait timer stopped.");
        tmrAnimation.Stop();
        tmrWait.Stop();
        frmPopup.Hide();
        if (markedForDisposed)
        {
            Dispose();
        }
    }

    private void frmPopup_ContextMenuClosed(object sender, EventArgs e)
    {
        Debug.WriteLine("Menu closed.");
        if (!mouseIsOn)
        {
            tmrWait.Interval = Delay;
            tmrWait.Start();
            Debug.WriteLine("Wait timer started.");
        }
    }

    private void frmPopup_ContextMenuOpened(object sender, EventArgs e)
    {
        Debug.WriteLine("Menu opened.");
        tmrWait.Stop();
        Debug.WriteLine("Wait timer stopped.");
    }

    private void frmPopup_LinkClick(object sender, EventArgs e)
    {
        if (this.Click != null)
        {
            this.Click(this, EventArgs.Empty);
        }
    }

    private void frmPopup_CloseClick(object sender, EventArgs e)
    {
        Hide();
        if (this.Close != null)
        {
            this.Close(this, EventArgs.Empty);
        }
    }

    private void frmPopup_VisibleChanged(object sender, EventArgs e)
    {
        if (frmPopup.Visible)
        {
            if (this.Appear != null)
            {
                this.Appear(this, EventArgs.Empty);
            }
        }
        else if (this.Disappear != null)
        {
            this.Disappear(this, EventArgs.Empty);
        }
    }

    private void tmAnimation_Tick(object sender, EventArgs e)
    {
        long elapsedMilliseconds = sw.ElapsedMilliseconds;
        int num = (int)(posStart + (posStop - posStart) * elapsedMilliseconds / realAnimationDuration);
        bool flag;
        if (((flag = posStop - posStart < 0) && num < posStop) || (!flag && num > posStop))
        {
            num = posStop;
        }
        double num2 = opacityStart + (opacityStop - opacityStart) * (double)elapsedMilliseconds / (double)realAnimationDuration;
        if (((flag = opacityStop - opacityStart < 0.0) && !(num2 >= opacityStop)) || (!flag && num2 > opacityStop))
        {
            num2 = opacityStop;
        }
        frmPopup.Top = num;
        frmPopup.Opacity = num2;
        if (elapsedMilliseconds <= realAnimationDuration)
        {
            return;
        }
        sw.Reset();
        tmrAnimation.Stop();
        Debug.WriteLine("Animation stopped.");
        if (isAppearing)
        {
            if (Scroll)
            {
                posStart = Screen.PrimaryScreen.WorkingArea.Bottom - frmPopup.Height;
                posStop = Screen.PrimaryScreen.WorkingArea.Bottom;
            }
            else
            {
                posStart = Screen.PrimaryScreen.WorkingArea.Bottom - frmPopup.Height;
                posStop = Screen.PrimaryScreen.WorkingArea.Bottom - frmPopup.Height;
            }
            opacityStart = 1.0;
            opacityStop = 0.0;
            realAnimationDuration = AnimationDuration;
            isAppearing = false;
            maxPosition = frmPopup.Top;
            maxOpacity = frmPopup.Opacity;
            if (!mouseIsOn)
            {
                tmrWait.Stop();
                tmrWait.Start();
                Debug.WriteLine("Wait timer started.");
            }
        }
        else
        {
            frmPopup.Hide();
            if (markedForDisposed)
            {
                Dispose();
            }
        }
    }

    private void tmWait_Tick(object sender, EventArgs e)
    {
        Debug.WriteLine("Wait timer elapsed.");
        tmrWait.Stop();
        tmrAnimation.Interval = AnimationInterval;
        tmrAnimation.Start();
        sw.Restart();
        Debug.WriteLine("Animation started.");
    }

    private void frmPopup_MouseLeave(object sender, EventArgs e)
    {
        Debug.WriteLine("MouseLeave");
        if (frmPopup.Visible && (OptionsMenu == null || !OptionsMenu.Visible))
        {
            tmrWait.Interval = Delay;
            tmrWait.Start();
            Debug.WriteLine("Wait timer started.");
        }
        mouseIsOn = false;
    }

    private void frmPopup_MouseEnter(object sender, EventArgs e)
    {
        Debug.WriteLine("MouseEnter");
        if (!isAppearing)
        {
            frmPopup.Top = maxPosition;
            frmPopup.Opacity = maxOpacity;
            tmrAnimation.Stop();
            Debug.WriteLine("Animation stopped.");
        }
        tmrWait.Stop();
        Debug.WriteLine("Wait timer stopped.");
        mouseIsOn = true;
    }

    protected override void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (isAppearing)
            {
                markedForDisposed = true;
                return;
            }
            if (disposing)
            {
                if (frmPopup != null)
                {
                    frmPopup.Dispose();
                }
                tmrAnimation.Tick -= tmAnimation_Tick;
                tmrWait.Tick -= tmWait_Tick;
                tmrAnimation.Dispose();
                tmrWait.Dispose();
            }
            disposed = true;
        }
        base.Dispose(disposing);
    }
}
