using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Helper.HexEditor;

public class HexEditor : Control
{
    public enum CaseStyle
    {
        LowerCase,
        UpperCase
    }

    private object _caretLock = new object();

    private object _hexTableLock = new object();

    private IKeyMouseEventHandler _handler;

    private EditView _editView;

    private ByteCollection _hexTable;

    private string _lineCountCaps = "X";

    private int _nrCharsLineCount = 4;

    private Caret _caret;

    private Rectangle _recContent;

    private Rectangle _recLineCount;

    private StringFormat _stringFormat;

    private int _firstByte;

    private int _lastByte;

    private int _maxBytesH;

    private int _maxBytesV;

    private int _maxBytes;

    private int _maxVisibleBytesV;

    private VScrollBar _vScrollBar;

    private int _vScrollBarWidth = 20;

    private int _vScrollPos;

    private int _vScrollMax;

    private int _vScrollMin;

    private int _vScrollSmall;

    private int _vScrollLarge;

    private SizeF _charSize;

    private bool _isVScrollHidden = true;

    private int _bytesPerLine = 8;

    private int _entityMargin = 10;

    private BorderStyle _borderStyle = BorderStyle.Fixed3D;

    private Color _borderColor = Color.Empty;

    private Color _selectionBackColor = Color.Blue;

    private Color _selectionForeColor = Color.White;

    private CaseStyle _lineCountCaseStyle = CaseStyle.UpperCase;

    private CaseStyle _hexViewCaseStyle = CaseStyle.UpperCase;

    private bool _isVScrollVisible = false;

    private bool _dragging;

    public override Font Font
    {
        set
        {
            base.Font = value;
            UpdateRectanglePositioning();
            Invalidate();
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string Text
    {
        get
        {
            return base.Text;
        }
        set
        {
            base.Text = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public byte[] HexTable
    {
        get
        {
            lock (_hexTableLock)
            {
                return _hexTable.ToArray();
            }
        }
        set
        {
            lock (_hexTableLock)
            {
                if (value == _hexTable.ToArray())
                {
                    return;
                }
                _hexTable = new ByteCollection(value);
            }
            UpdateRectanglePositioning();
            Invalidate();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SizeF CharSize
    {
        get
        {
            return _charSize;
        }
        private set
        {
            if (!(_charSize == value))
            {
                _charSize = value;
                if (this.CharSizeChanged != null)
                {
                    this.CharSizeChanged(this, EventArgs.Empty);
                }
            }
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int MaxBytesV => _maxBytesV;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int FirstVisibleByte => _firstByte;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int LastVisibleByte => _lastByte;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool VScrollBarHidden
    {
        get
        {
            return _isVScrollHidden;
        }
        set
        {
            if (_isVScrollHidden != value)
            {
                _isVScrollHidden = value;
                if (!_isVScrollHidden)
                {
                    base.Controls.Add(_vScrollBar);
                }
                else
                {
                    base.Controls.Remove(_vScrollBar);
                }
                UpdateRectanglePositioning();
                Invalidate();
            }
        }
    }

    [Category("Hex")]
    [Description("Property that specifies the number of bytes to display per line.")]
    [DefaultValue(8)]
    public int BytesPerLine
    {
        get
        {
            return _bytesPerLine;
        }
        set
        {
            if (_bytesPerLine != value)
            {
                _bytesPerLine = value;
                UpdateRectanglePositioning();
                Invalidate();
            }
        }
    }

    [DefaultValue(10)]
    [Description("Property that specifies the margin between each of the entitys in the control.")]
    [Category("Hex")]
    public int EntityMargin
    {
        get
        {
            return _entityMargin;
        }
        set
        {
            if (_entityMargin != value)
            {
                _entityMargin = value;
                UpdateRectanglePositioning();
                Invalidate();
            }
        }
    }

    [Description("Indicates where the control should have a border.")]
    [Category("Appearance")]
    [DefaultValue(BorderStyle.Fixed3D)]
    public BorderStyle BorderStyle
    {
        get
        {
            return _borderStyle;
        }
        set
        {
            if (_borderStyle != value)
            {
                if (value != BorderStyle.FixedSingle)
                {
                    _borderColor = Color.Empty;
                }
                _borderStyle = value;
                UpdateRectanglePositioning();
                Invalidate();
            }
        }
    }

    [Description("Indicates the color to be used when displaying a FixedSingle border.")]
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Empty")]
    public Color BorderColor
    {
        get
        {
            return _borderColor;
        }
        set
        {
            if (BorderStyle == BorderStyle.FixedSingle && !(_borderColor == value))
            {
                _borderColor = value;
                Invalidate();
            }
        }
    }

    [DefaultValue(typeof(Color), "Blue")]
    [Category("Hex")]
    [Description("Property for the background color of the selected text areas.")]
    public Color SelectionBackColor
    {
        get
        {
            return _selectionBackColor;
        }
        set
        {
            if (!(_selectionBackColor == value))
            {
                _selectionBackColor = value;
            }
        }
    }

    [DefaultValue(typeof(Color), "White")]
    [Category("Hex")]
    [Description("Property for the foreground color of the selected text areas.")]
    public Color SelectionForeColor
    {
        get
        {
            return _selectionForeColor;
        }
        set
        {
            if (!(_selectionForeColor == value))
            {
                _selectionForeColor = value;
            }
        }
    }

    [Description("Property for the case type to use on the line counter.")]
    [DefaultValue(CaseStyle.UpperCase)]
    [Category("Hex")]
    public CaseStyle LineCountCaseStyle
    {
        get
        {
            return _lineCountCaseStyle;
        }
        set
        {
            if (_lineCountCaseStyle != value)
            {
                _lineCountCaseStyle = value;
                if (_lineCountCaseStyle == CaseStyle.LowerCase)
                {
                    _lineCountCaps = "x";
                }
                else
                {
                    _lineCountCaps = "X";
                }
                Invalidate();
            }
        }
    }

    [DefaultValue(CaseStyle.UpperCase)]
    [Category("Hex")]
    [Description("Property for the case type to use for the hexadecimal values view.")]
    public CaseStyle HexViewCaseStyle
    {
        get
        {
            return _hexViewCaseStyle;
        }
        set
        {
            if (_hexViewCaseStyle != value)
            {
                _hexViewCaseStyle = value;
                if (_hexViewCaseStyle == CaseStyle.LowerCase)
                {
                    _editView.SetLowerCase();
                }
                else
                {
                    _editView.SetUpperCase();
                }
                Invalidate();
            }
        }
    }

    [DefaultValue(false)]
    [Category("Hex")]
    [Description("Property for the visibility of the vertical scrollbar.")]
    public bool Boolean_0
    {
        get
        {
            return _isVScrollVisible;
        }
        set
        {
            if (_isVScrollVisible != value)
            {
                _isVScrollVisible = value;
                UpdateRectanglePositioning();
                Invalidate();
            }
        }
    }

    public int CaretPosX
    {
        get
        {
            lock (_caretLock)
            {
                return _caret.Location.X;
            }
        }
    }

    public int CaretPosY
    {
        get
        {
            lock (_caretLock)
            {
                return _caret.Location.Y;
            }
        }
    }

    public int SelectionStart
    {
        get
        {
            lock (_caretLock)
            {
                return _caret.SelectionStart;
            }
        }
    }

    public int SelectionLength
    {
        get
        {
            lock (_caretLock)
            {
                return _caret.SelectionLength;
            }
        }
    }

    public int CaretIndex
    {
        get
        {
            lock (_caretLock)
            {
                return _caret.CurrentIndex;
            }
        }
    }

    public bool CaretFocused
    {
        get
        {
            lock (_caretLock)
            {
                return _caret.Focused;
            }
        }
    }

    public int HexTableLength
    {
        get
        {
            lock (_hexTableLock)
            {
                return _hexTable.Length;
            }
        }
    }

    [Description("Event that is triggered whenever the hextable has been changed.")]
    public event EventHandler HexTableChanged;

    [Description("Event that is triggered whenever the SelectionStart value is changed.")]
    public event EventHandler SelectionStartChanged;

    [Description("Event that is triggered whenever the SelectionLength value is changed.")]
    public event EventHandler SelectionLengthChanged;

    [Description("Event that is triggered whenever the size of the char is changed.")]
    public event EventHandler CharSizeChanged;

    protected void _vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
        switch (e.Type)
        {
            case ScrollEventType.SmallDecrement:
                ScrollLineUp(1);
                break;
            case ScrollEventType.SmallIncrement:
                ScrollLineDown(1);
                break;
            case ScrollEventType.LargeDecrement:
                ScrollLineUp(_vScrollLarge);
                break;
            case ScrollEventType.LargeIncrement:
                ScrollLineDown(_vScrollLarge);
                break;
            case ScrollEventType.ThumbTrack:
                ScrollThumbTrack(e.NewValue - e.OldValue);
                break;
        }
        Invalidate();
    }

    protected void CaretSelectionStartChanged(object sender, EventArgs e)
    {
        if (this.SelectionStartChanged != null)
        {
            this.SelectionStartChanged(this, e);
        }
    }

    protected void CaretSelectionLengthChanged(object sender, EventArgs e)
    {
        if (this.SelectionLengthChanged != null)
        {
            this.SelectionLengthChanged(this, e);
        }
    }

    protected override void OnMarginChanged(EventArgs e)
    {
        base.OnMarginChanged(e);
        UpdateRectanglePositioning();
        Invalidate();
    }

    protected override void OnGotFocus(EventArgs e)
    {
        if (_handler != null)
        {
            _handler.OnGotFocus(e);
        }
        UpdateRectanglePositioning();
        Invalidate();
        base.OnGotFocus(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
        _dragging = false;
        DestroyCaret();
        base.OnLostFocus(e);
    }

    protected override bool IsInputKey(Keys keyData)
    {
        if ((uint)(keyData - 37) > 3u && (uint)(keyData - 65573) > 3u)
        {
            return base.IsInputKey(keyData);
        }
        return true;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (_handler != null)
        {
            _handler.OnKeyPress(e);
        }
        base.OnKeyPress(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Next)
        {
            if (!_isVScrollHidden)
            {
                ScrollLineDown(_vScrollLarge);
                Invalidate();
            }
        }
        else if (e.KeyCode == Keys.Prior)
        {
            if (!_isVScrollHidden)
            {
                ScrollLineUp(_vScrollLarge);
                Invalidate();
            }
        }
        else if (_handler != null)
        {
            _handler.OnKeyDown(e);
        }
        base.OnKeyDown(e);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        if (_handler != null)
        {
            _handler.OnKeyUp(e);
        }
        base.OnKeyUp(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (Focused)
        {
            if (_handler != null)
            {
                _handler.OnMouseDown(e);
            }
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                Invalidate();
            }
        }
        else
        {
            Focus();
        }
        base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (Focused && _dragging)
        {
            if (_handler != null)
            {
                _handler.OnMouseDragged(e);
            }
            Invalidate();
        }
        base.OnMouseMove(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        _dragging = false;
        if (Focused && _handler != null)
        {
            _handler.OnMouseUp(e);
        }
        base.OnMouseUp(e);
    }

    protected override void OnMouseDoubleClick(MouseEventArgs e)
    {
        if (Focused && _handler != null)
        {
            _handler.OnMouseDoubleClick(e);
        }
        base.OnMouseDoubleClick(e);
    }

    public void SetCaretStart(int index, Point location)
    {
        location = ScrollToCaret(index, location);
        lock (_caretLock)
        {
            _caret.SetStartIndex(index);
            _caret.SetCaretLocation(location);
        }
        Invalidate();
    }

    public void SetCaretEnd(int index, Point location)
    {
        location = ScrollToCaret(index, location);
        lock (_caretLock)
        {
            _caret.SetEndIndex(index);
            _caret.SetCaretLocation(location);
        }
        Invalidate();
    }

    public bool IsSelected(int byteIndex)
    {
        lock (_caretLock)
        {
            return _caret.IsSelected(byteIndex);
        }
    }

    public void DestroyCaret()
    {
        lock (_caretLock)
        {
            _caret.Destroy();
        }
    }

    public void RemoveSelectedBytes()
    {
        int selectionStart = SelectionStart;
        int selectionLength = SelectionLength;
        if (selectionLength > 0)
        {
            lock (_hexTableLock)
            {
                _hexTable.RemoveRange(selectionStart, selectionLength);
            }
            UpdateRectanglePositioning();
            Invalidate();
            if (this.HexTableChanged != null)
            {
                this.HexTableChanged(this, EventArgs.Empty);
            }
        }
    }

    public void RemoveByteAt(int index)
    {
        lock (_hexTableLock)
        {
            _hexTable.RemoveAt(index);
        }
        UpdateRectanglePositioning();
        Invalidate();
        if (this.HexTableChanged != null)
        {
            this.HexTableChanged(this, EventArgs.Empty);
        }
    }

    public void AppendByte(byte item)
    {
        lock (_hexTableLock)
        {
            _hexTable.Add(item);
        }
        UpdateRectanglePositioning();
        Invalidate();
        if (this.HexTableChanged != null)
        {
            this.HexTableChanged(this, EventArgs.Empty);
        }
    }

    public void InsertByte(int index, byte item)
    {
        lock (_hexTableLock)
        {
            _hexTable.Insert(index, item);
        }
        UpdateRectanglePositioning();
        Invalidate();
        if (this.HexTableChanged != null)
        {
            this.HexTableChanged(this, EventArgs.Empty);
        }
    }

    public char GetByteAsChar(int index)
    {
        lock (_hexTableLock)
        {
            return _hexTable.GetCharAt(index);
        }
    }

    public byte GetByte(int index)
    {
        lock (_hexTableLock)
        {
            return _hexTable.GetAt(index);
        }
    }

    public void SetByte(int index, byte item)
    {
        lock (_hexTableLock)
        {
            _hexTable.SetAt(index, item);
        }
        Invalidate();
        if (this.HexTableChanged != null)
        {
            this.HexTableChanged(this, EventArgs.Empty);
        }
    }

    public void ScrollLineUp(int lines)
    {
        if (_firstByte <= 0)
        {
            return;
        }
        lines = ((lines > _vScrollPos) ? _vScrollPos : lines);
        _vScrollPos -= _vScrollSmall * lines;
        UpdateVisibleByteIndex();
        UpdateScrollValues();
        if (CaretFocused)
        {
            Point caretLocation = new Point(CaretPosX, CaretPosY);
            caretLocation.Y += _recLineCount.Height * lines;
            lock (_caretLock)
            {
                _caret.SetCaretLocation(caretLocation);
            }
        }
    }

    public void ScrollLineDown(int lines)
    {
        if (_vScrollPos > _vScrollMax - _vScrollLarge)
        {
            return;
        }
        lines = ((lines + _vScrollPos > _vScrollMax - _vScrollLarge) ? (_vScrollMax - _vScrollLarge - _vScrollPos + 1) : lines);
        _vScrollPos += _vScrollSmall * lines;
        UpdateVisibleByteIndex();
        UpdateScrollValues();
        if (!CaretFocused)
        {
            return;
        }
        Point caretLocation = new Point(CaretPosX, CaretPosY);
        caretLocation.Y -= _recLineCount.Height * lines;
        lock (_caretLock)
        {
            _caret.SetCaretLocation(caretLocation);
            if (caretLocation.Y < _recContent.Y)
            {
                _caret.Hide(base.Handle);
            }
        }
    }

    public void ScrollThumbTrack(int lines)
    {
        if (lines != 0)
        {
            if (lines < 0)
            {
                ScrollLineUp(-1 * lines);
            }
            else
            {
                ScrollLineDown(lines);
            }
        }
    }

    public Point ScrollToCaret(int caretIndex, Point position)
    {
        if (position.Y < 0)
        {
            _vScrollPos -= Math.Abs((position.Y - _recContent.Y) / _recLineCount.Height) * _vScrollSmall;
            UpdateVisibleByteIndex();
            UpdateScrollValues();
            if (CaretFocused)
            {
                position.Y = _recContent.Y;
            }
        }
        else if (position.Y > _maxVisibleBytesV * _recLineCount.Height)
        {
            _vScrollPos += (position.Y / _recLineCount.Height - (_maxVisibleBytesV - 1)) * _vScrollSmall;
            if (_vScrollPos > _vScrollMax - (_vScrollLarge - 1))
            {
                _vScrollPos = _vScrollMax - (_vScrollLarge - 1);
            }
            UpdateVisibleByteIndex();
            UpdateScrollValues();
            if (CaretFocused)
            {
                position.Y = (_maxVisibleBytesV - 1) * _recLineCount.Height + _recContent.Y;
            }
        }
        return position;
    }

    private void UpdateRectanglePositioning()
    {
        if (base.ClientRectangle.Width != 0)
        {
            SizeF sizeF;
            using (Graphics graphics = CreateGraphics())
            {
                sizeF = graphics.MeasureString("D", Font, 100, _stringFormat);
            }
            CharSize = new SizeF((float)Math.Ceiling(sizeF.Width), (float)Math.Ceiling(sizeF.Height));
            _recContent = base.ClientRectangle;
            _recContent.X += base.Margin.Left;
            _recContent.Y += base.Margin.Top;
            _recContent.Width -= base.Margin.Right;
            _recContent.Height -= base.Margin.Bottom;
            if (BorderStyle == BorderStyle.Fixed3D)
            {
                _recContent.X += 2;
                _recContent.Y += 2;
                _recContent.Width--;
                _recContent.Height--;
            }
            else if (BorderStyle == BorderStyle.FixedSingle)
            {
                _recContent.X++;
                _recContent.Y++;
                _recContent.Width--;
                _recContent.Height--;
            }
            if (!VScrollBarHidden)
            {
                _recContent.Width -= _vScrollBarWidth;
                _vScrollBar.Left = _recContent.X + _recContent.Width - base.Margin.Left;
                _vScrollBar.Top = _recContent.Y - base.Margin.Top;
                _vScrollBar.Width = _vScrollBarWidth;
                _vScrollBar.Height = _recContent.Height;
            }
            _recLineCount = new Rectangle(_recContent.X, _recContent.Y, (int)(_charSize.Width * 4f), (int)_charSize.Height - 2);
            _editView.Update(_recLineCount.X + _recLineCount.Width + _entityMargin / 2, _recContent);
            _maxBytesH = _bytesPerLine;
            _maxBytesV = (int)Math.Ceiling((float)_recContent.Height / (float)_recLineCount.Height);
            _maxBytes = _maxBytesH * _maxBytesV;
            _maxVisibleBytesV = (int)Math.Floor((float)_recContent.Height / (float)_recLineCount.Height);
            UpdateScrollBarSize();
        }
    }

    private void UpdateVisibleByteIndex()
    {
        if (_hexTable.Length == 0)
        {
            _firstByte = 0;
            _lastByte = 0;
        }
        else
        {
            _firstByte = _vScrollPos * _maxBytesH;
            _lastByte = Math.Min(HexTableLength, _firstByte + _maxBytes);
        }
    }

    private void UpdateScrollValues()
    {
        if (!_isVScrollHidden)
        {
            _vScrollBar.Minimum = _vScrollMin;
            _vScrollBar.Maximum = _vScrollMax;
            _vScrollBar.Value = _vScrollPos;
            _vScrollBar.SmallChange = _vScrollSmall;
            _vScrollBar.LargeChange = _vScrollLarge;
            _vScrollBar.Visible = true;
        }
        else
        {
            _vScrollBar.Visible = false;
        }
    }

    private void UpdateScrollBarSize()
    {
        if (Boolean_0 && _maxVisibleBytesV > 0 && _maxBytesH > 0)
        {
            int maxVisibleBytesV = _maxVisibleBytesV;
            int num = 1;
            int vScrollMin = 0;
            int num2 = HexTableLength / _maxBytesH;
            int num3 = _firstByte / _maxBytesH;
            if (maxVisibleBytesV != _vScrollLarge || num != _vScrollSmall)
            {
                _vScrollLarge = maxVisibleBytesV;
                _vScrollSmall = num;
            }
            if (num2 >= maxVisibleBytesV)
            {
                if (num2 != _vScrollMax || num3 != _vScrollPos)
                {
                    _vScrollMin = vScrollMin;
                    _vScrollMax = num2;
                    _vScrollPos = num3;
                }
                VScrollBarHidden = false;
                UpdateScrollValues();
            }
            else
            {
                VScrollBarHidden = true;
            }
        }
        else
        {
            VScrollBarHidden = true;
        }
    }

    public HexEditor()
        : this(new ByteCollection())
    {
    }

    public HexEditor(ByteCollection collection)
    {
        _stringFormat = new StringFormat(StringFormat.GenericTypographic);
        _stringFormat.Alignment = StringAlignment.Center;
        _stringFormat.LineAlignment = StringAlignment.Center;
        _hexTable = collection;
        _vScrollBar = new VScrollBar();
        _vScrollBar.Scroll += _vScrollBar_Scroll;
        SetStyle(ControlStyles.ResizeRedraw, value: true);
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
        SetStyle(ControlStyles.Selectable, value: true);
        _caret = new Caret(this);
        _caret.SelectionStartChanged += CaretSelectionStartChanged;
        _caret.SelectionLengthChanged += CaretSelectionLengthChanged;
        _editView = new EditView(this);
        _handler = _editView;
        Cursor = Cursors.IBeam;
    }

    private RectangleF GetLineCountBound(int index)
    {
        return new RectangleF(_recLineCount.X, _recLineCount.Y + _recLineCount.Height * index, _recLineCount.Width, _recLineCount.Height);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        if (BorderStyle == BorderStyle.Fixed3D)
        {
            SolidBrush brush = new SolidBrush(BackColor);
            Rectangle clientRectangle = base.ClientRectangle;
            pevent.Graphics.FillRectangle(brush, clientRectangle);
            ControlPaint.DrawBorder3D(pevent.Graphics, base.ClientRectangle, Border3DStyle.Sunken);
        }
        else if (BorderStyle == BorderStyle.FixedSingle)
        {
            SolidBrush brush2 = new SolidBrush(BackColor);
            Rectangle clientRectangle2 = base.ClientRectangle;
            pevent.Graphics.FillRectangle(brush2, clientRectangle2);
            ControlPaint.DrawBorder(pevent.Graphics, base.ClientRectangle, BorderColor, ButtonBorderStyle.Solid);
        }
        else
        {
            base.OnPaintBackground(pevent);
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Region region = new Region(base.ClientRectangle);
        region.Exclude(_recContent);
        e.Graphics.ExcludeClip(region);
        UpdateVisibleByteIndex();
        PaintLineCount(e.Graphics, _firstByte, _lastByte);
        _editView.Paint(e.Graphics, _firstByte, _lastByte);
    }

    private void PaintLineCount(Graphics g, int startIndex, int lastIndex)
    {
        SolidBrush brush = new SolidBrush(ForeColor);
        for (int i = 0; i * _maxBytesH + startIndex <= lastIndex; i++)
        {
            RectangleF lineCountBound = GetLineCountBound(i);
            string text = (startIndex + i * _maxBytesH).ToString(_lineCountCaps);
            int num = _nrCharsLineCount - text.Length;
            string s = ((num <= -1) ? new string('~', _nrCharsLineCount) : (new string('0', num) + text));
            g.DrawString(s, Font, brush, lineCountBound, _stringFormat);
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateRectanglePositioning();
        Invalidate();
    }
}
