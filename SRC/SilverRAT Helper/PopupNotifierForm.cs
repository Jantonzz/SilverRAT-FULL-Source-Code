using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SilverRAT.Helper;

internal class PopupNotifierForm : Form
{
    private bool mouseOnClose = false;

    private bool mouseOnLink = false;

    private int heightOfTitle;

    private bool gdiInitialized = false;

    private Rectangle rcBody;

    private Rectangle rcHeader;

    private LinearGradientBrush brushBody;

    private LinearGradientBrush brushHeader;

    private Brush brushButtonHover;

    private Pen penButtonBorder;

    private Pen penContent;

    private Brush brushForeColor;

    private Brush brushLinkHover;

    private Brush brushContent;

    private Brush brushTitle;

    public new PopupNotifier Parent { get; set; }

    private RectangleF RectContentText
    {
        get
        {
            if (Parent.Image != null)
            {
                return new RectangleF(Parent.ImagePadding.Left + Parent.ImageSize.Width + Parent.ImagePadding.Right + Parent.ContentPadding.Left, Parent.HeaderHeight + Parent.TitlePadding.Top + heightOfTitle + Parent.TitlePadding.Bottom + Parent.ContentPadding.Top, base.Width - Parent.ImagePadding.Left - Parent.ImageSize.Width - Parent.ImagePadding.Right - Parent.ContentPadding.Left - Parent.ContentPadding.Right - 16 - 5, base.Height - Parent.HeaderHeight - Parent.TitlePadding.Top - heightOfTitle - Parent.TitlePadding.Bottom - Parent.ContentPadding.Top - Parent.ContentPadding.Bottom - 1);
            }
            return new RectangleF(Parent.ContentPadding.Left, Parent.HeaderHeight + Parent.TitlePadding.Top + heightOfTitle + Parent.TitlePadding.Bottom + Parent.ContentPadding.Top, base.Width - Parent.ContentPadding.Left - Parent.ContentPadding.Right - 16 - 5, base.Height - Parent.HeaderHeight - Parent.TitlePadding.Top - heightOfTitle - Parent.TitlePadding.Bottom - Parent.ContentPadding.Top - Parent.ContentPadding.Bottom - 1);
        }
    }

    private Rectangle RectClose => new Rectangle(base.Width - 5 - 16, Parent.HeaderHeight + 3, 16, 16);

    private Rectangle RectOptions => new Rectangle(base.Width - 5 - 16, Parent.HeaderHeight + 3 + 16 + 5, 16, 16);

    public event EventHandler LinkClick;

    public event EventHandler CloseClick;

    internal event EventHandler ContextMenuOpened;

    internal event EventHandler ContextMenuClosed;

    public PopupNotifierForm(PopupNotifier parent)
    {
        Parent = parent;
        Methods.SetDoubleBuffered(this);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
        SetStyle(ControlStyles.ResizeRedraw, value: true);
        SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
        base.ShowInTaskbar = false;
        base.VisibleChanged += PopupNotifierForm_VisibleChanged;
        base.MouseMove += PopupNotifierForm_MouseMove;
        base.MouseUp += PopupNotifierForm_MouseUp;
        base.Paint += PopupNotifierForm_Paint;
    }

    private void PopupNotifierForm_VisibleChanged(object sender, EventArgs e)
    {
        if (base.Visible)
        {
            mouseOnClose = false;
            mouseOnLink = false;
        }
    }

    private Color GetFormTopColor()
    {
        return Parent.GetFormTopColor;
    }

    private Color GetFormBotomColor()
    {
        return Parent.GetFormBotomColor;
    }

    private void PopupNotifierForm_MouseMove(object sender, MouseEventArgs e)
    {
        if (Parent.ShowCloseButton)
        {
            mouseOnClose = RectClose.Contains(e.X, e.Y);
        }
        mouseOnLink = RectContentText.Contains(e.X, e.Y);
        Invalidate();
    }

    private void PopupNotifierForm_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (RectClose.Contains(e.X, e.Y) && this.CloseClick != null)
            {
                this.CloseClick(this, EventArgs.Empty);
            }
            if (RectContentText.Contains(e.X, e.Y) && this.LinkClick != null)
            {
                this.LinkClick(this, EventArgs.Empty);
            }
            if (RectOptions.Contains(e.X, e.Y) && Parent.OptionsMenu != null)
            {
                this.ContextMenuOpened?.Invoke(this, EventArgs.Empty);
                Parent.OptionsMenu.Show(this, new Point(RectOptions.Right - Parent.OptionsMenu.Width, RectOptions.Bottom));
                Parent.OptionsMenu.Closed += OptionsMenu_Closed;
            }
        }
    }

    private void OptionsMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
    {
        Parent.OptionsMenu.Closed -= OptionsMenu_Closed;
        this.ContextMenuClosed?.Invoke(this, EventArgs.Empty);
    }

    private void method_0()
    {
        rcBody = new Rectangle(0, 0, base.Width, base.Height);
        rcHeader = new Rectangle(0, 0, base.Width, Parent.HeaderHeight);
        brushBody = new LinearGradientBrush(rcBody, Parent.GetFormBotomColor, GetFormBotomColor(), LinearGradientMode.Vertical);
        brushHeader = new LinearGradientBrush(rcHeader, Parent.GetFormTopColor, GetFormTopColor(), LinearGradientMode.Vertical);
        brushButtonHover = new SolidBrush(Parent.ButtonHoverColor);
        penButtonBorder = new Pen(Parent.ButtonBorderColor);
        penContent = new Pen(Parent.ContentColor, 2f);
        brushForeColor = new SolidBrush(ForeColor);
        brushLinkHover = new SolidBrush(Parent.ContentHoverColor);
        brushContent = new SolidBrush(Parent.ContentColor);
        brushTitle = new SolidBrush(Parent.TitleColor);
        gdiInitialized = true;
    }

    private void DisposeGDIObjects()
    {
        if (gdiInitialized)
        {
            brushBody.Dispose();
            brushHeader.Dispose();
            brushButtonHover.Dispose();
            penButtonBorder.Dispose();
            penContent.Dispose();
            brushForeColor.Dispose();
            brushLinkHover.Dispose();
            brushContent.Dispose();
            brushTitle.Dispose();
        }
    }

    public static Bitmap ResizeImage(Image image, int width, int height)
    {
        Rectangle destRect = new Rectangle(0, 0, width, height);
        Bitmap bitmap = new Bitmap(width, height);
        bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            using ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
        }
        return bitmap;
    }

    private void PopupNotifierForm_Paint(object sender, PaintEventArgs e)
    {
        if (!gdiInitialized)
        {
            method_0();
        }
        e.Graphics.FillRectangle(brushBody, rcBody);
        e.Graphics.FillRectangle(brushHeader, rcHeader);
        if (Parent.ShowCloseButton)
        {
            if (mouseOnClose)
            {
                e.Graphics.FillRectangle(brushButtonHover, RectClose);
                e.Graphics.DrawRectangle(penButtonBorder, RectClose);
            }
            e.Graphics.DrawLine(penContent, RectClose.Left + 4, RectClose.Top + 4, RectClose.Right - 4, RectClose.Bottom - 4);
            e.Graphics.DrawLine(penContent, RectClose.Left + 4, RectClose.Bottom - 4, RectClose.Right - 4, RectClose.Top + 4);
        }
        if (Parent.Image != null)
        {
            e.Graphics.DrawImage(ResizeImage(Parent.Image, 38, 38), Parent.ImagePadding.Left + 5, Parent.HeaderHeight + 3, ResizeImage(Parent.Image, 38, 38).Width, ResizeImage(Parent.Image, 38, 38).Height);
        }
        if (Parent.IsRightToLeft)
        {
            heightOfTitle = (int)e.Graphics.MeasureString("A", Parent.TitleFont).Height;
            int num = base.Width - 30;
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            e.Graphics.DrawString(Parent.TitleText, Parent.TitleFont, brushTitle, num, Parent.HeaderHeight + Parent.TitlePadding.Top, format);
            Cursor = (mouseOnLink ? Cursors.Hand : Cursors.Default);
            Brush brush = (mouseOnLink ? brushLinkHover : brushContent);
            StringFormat format2 = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            e.Graphics.DrawString(Parent.ContentText, Parent.ContentFont, brush, RectContentText, format2);
            return;
        }
        heightOfTitle = (int)e.Graphics.MeasureString("A", Parent.TitleFont).Height;
        int num2 = Parent.TitlePadding.Left;
        if (Parent.Image != null)
        {
            num2 += Parent.ImagePadding.Left + Parent.ImageSize.Width + Parent.ImagePadding.Right;
        }
        e.Graphics.DrawString(Parent.TitleText, Parent.TitleFont, brushTitle, num2, Parent.HeaderHeight + Parent.TitlePadding.Top);
        Cursor = (mouseOnLink ? Cursors.Hand : Cursors.Default);
        Brush brush2 = (mouseOnLink ? brushLinkHover : brushContent);
        e.Graphics.DrawString(Parent.ContentText, Parent.ContentFont, brush2, RectContentText);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            DisposeGDIObjects();
        }
        base.Dispose(disposing);
    }

    private void PopupNotifierForm_Load(object sender, EventArgs e)
    {
    }
}
