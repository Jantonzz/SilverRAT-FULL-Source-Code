using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Server.Helper.HexEditor;

public class Caret
{
    private int _startIndex;

    private int _endIndex;

    private bool _isCaretActive;

    private bool _isCaretHidden;

    private Point _location;

    private HexEditor _editor;

    public int SelectionStart
    {
        get
        {
            if (_endIndex < _startIndex)
            {
                return _endIndex;
            }
            return _startIndex;
        }
    }

    public int SelectionLength
    {
        get
        {
            if (_endIndex < _startIndex)
            {
                return _startIndex - _endIndex;
            }
            return _endIndex - _startIndex;
        }
    }

    public bool Focused => _isCaretActive;

    public int CurrentIndex => _endIndex;

    public Point Location => _location;

    public event EventHandler SelectionStartChanged;

    public event EventHandler SelectionLengthChanged;

    public Caret(HexEditor editor)
    {
        _editor = editor;
        _isCaretActive = false;
        _startIndex = 0;
        _endIndex = 0;
        _isCaretHidden = true;
        _location = new Point(0, 0);
    }

    private bool Create(IntPtr intptr_0)
    {
        if (!_isCaretActive)
        {
            _isCaretActive = true;
            return CreateCaret(intptr_0, IntPtr.Zero, 0, (int)_editor.CharSize.Height - 2);
        }
        return false;
    }

    private bool Show(IntPtr hWnd)
    {
        if (_isCaretActive)
        {
            _isCaretHidden = false;
            return ShowCaret(hWnd);
        }
        return false;
    }

    public bool Hide(IntPtr hWnd)
    {
        if (_isCaretActive && !_isCaretHidden)
        {
            _isCaretHidden = true;
            return HideCaret(hWnd);
        }
        return false;
    }

    public bool Destroy()
    {
        if (_isCaretActive)
        {
            _isCaretActive = false;
            DeSelect();
            DestroyCaret();
        }
        return false;
    }

    public void SetStartIndex(int index)
    {
        _startIndex = index;
        _endIndex = _startIndex;
        if (this.SelectionStartChanged != null)
        {
            this.SelectionStartChanged(this, EventArgs.Empty);
        }
        if (this.SelectionLengthChanged != null)
        {
            this.SelectionLengthChanged(this, EventArgs.Empty);
        }
    }

    public void SetEndIndex(int index)
    {
        _endIndex = index;
        if (this.SelectionStartChanged != null)
        {
            this.SelectionStartChanged(this, EventArgs.Empty);
        }
        if (this.SelectionLengthChanged != null)
        {
            this.SelectionLengthChanged(this, EventArgs.Empty);
        }
    }

    public void SetCaretLocation(Point start)
    {
        Create(_editor.Handle);
        _location = start;
        SetCaretPos(_location.X, _location.Y);
        Show(_editor.Handle);
    }

    public bool IsSelected(int byteIndex)
    {
        return SelectionStart <= byteIndex && byteIndex < SelectionStart + SelectionLength;
    }

    private void DeSelect()
    {
        if (_endIndex < _startIndex)
        {
            _startIndex = _endIndex;
        }
        else
        {
            _endIndex = _startIndex;
        }
        if (this.SelectionStartChanged != null)
        {
            this.SelectionStartChanged(this, EventArgs.Empty);
        }
        if (this.SelectionLengthChanged != null)
        {
            this.SelectionLengthChanged(this, EventArgs.Empty);
        }
    }

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool DestroyCaret();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool SetCaretPos(int x, int y);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool ShowCaret(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool HideCaret(IntPtr hWnd);
}
