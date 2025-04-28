using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Helper.HexEditor;

public class HexViewHandler
{
    private bool _isEditing;

    private string _hexType = "X2";

    private Rectangle _recHexValue;

    private StringFormat _stringFormat;

    private HexEditor _editor;

    public int MaxWidth => _recHexValue.X + _recHexValue.Width * _editor.BytesPerLine;

    public HexViewHandler(HexEditor editor)
    {
        _editor = editor;
        _stringFormat = new StringFormat(StringFormat.GenericTypographic);
        _stringFormat.Alignment = StringAlignment.Center;
        _stringFormat.LineAlignment = StringAlignment.Center;
    }

    public void OnKeyPress(KeyPressEventArgs e)
    {
        if (IsHex(e.KeyChar))
        {
            HandleUserInput(e.KeyChar);
        }
    }

    public void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
        {
            if (_editor.SelectionLength > 0)
            {
                HandleUserRemove();
                int caretIndex = _editor.CaretIndex;
                Point caretLocation = GetCaretLocation(caretIndex);
                _editor.SetCaretStart(caretIndex, caretLocation);
            }
            else if (_editor.CaretIndex < _editor.LastVisibleByte && e.KeyCode == Keys.Delete)
            {
                _editor.RemoveByteAt(_editor.CaretIndex);
                Point caretLocation2 = GetCaretLocation(_editor.CaretIndex);
                _editor.SetCaretStart(_editor.CaretIndex, caretLocation2);
            }
            else if (_editor.CaretIndex > 0 && e.KeyCode == Keys.Back)
            {
                int index = _editor.CaretIndex - 1;
                if (_isEditing)
                {
                    index = _editor.CaretIndex;
                }
                _editor.RemoveByteAt(index);
                Point caretLocation3 = GetCaretLocation(index);
                _editor.SetCaretStart(index, caretLocation3);
            }
            _isEditing = false;
        }
        else if (e.KeyCode == Keys.Up && _editor.CaretIndex - _editor.BytesPerLine >= 0)
        {
            int num = _editor.CaretIndex - _editor.BytesPerLine;
            if (num % _editor.BytesPerLine == 0 && _editor.CaretPosX >= _recHexValue.X + _recHexValue.Width * _editor.BytesPerLine)
            {
                Point location = new Point(_editor.CaretPosX, _editor.CaretPosY - _recHexValue.Height);
                if (num == 0)
                {
                    location = new Point(_editor.CaretPosX, _editor.CaretPosY);
                    num = _editor.BytesPerLine;
                }
                if (e.Shift)
                {
                    _editor.SetCaretEnd(num, location);
                }
                else
                {
                    _editor.SetCaretStart(num, location);
                }
                _isEditing = false;
            }
            else
            {
                HandleArrowKeys(num, e.Shift);
            }
        }
        else if (e.KeyCode == Keys.Down && (_editor.CaretIndex - 1) / _editor.BytesPerLine < _editor.HexTableLength / _editor.BytesPerLine)
        {
            int num2 = _editor.CaretIndex + _editor.BytesPerLine;
            if (num2 > _editor.HexTableLength)
            {
                num2 = _editor.HexTableLength;
                HandleArrowKeys(num2, e.Shift);
                return;
            }
            Point location2 = new Point(_editor.CaretPosX, _editor.CaretPosY + _recHexValue.Height);
            if (e.Shift)
            {
                _editor.SetCaretEnd(num2, location2);
            }
            else
            {
                _editor.SetCaretStart(num2, location2);
            }
            _isEditing = false;
        }
        else if (e.KeyCode == Keys.Left && _editor.CaretIndex - 1 >= 0)
        {
            int index2 = _editor.CaretIndex - 1;
            HandleArrowKeys(index2, e.Shift);
        }
        else if (e.KeyCode == Keys.Right && _editor.CaretIndex + 1 <= _editor.HexTableLength)
        {
            int index3 = _editor.CaretIndex + 1;
            HandleArrowKeys(index3, e.Shift);
        }
    }

    public void HandleArrowKeys(int index, bool isShiftDown)
    {
        Point caretLocation = GetCaretLocation(index);
        if (isShiftDown)
        {
            _editor.SetCaretEnd(index, caretLocation);
        }
        else
        {
            _editor.SetCaretStart(index, caretLocation);
        }
        _isEditing = false;
    }

    public void OnMouseDown(int x, int y)
    {
        int num = (x - _recHexValue.X) / _recHexValue.Width;
        int num2 = (y - _recHexValue.Y) / _recHexValue.Height;
        num = ((num > _editor.BytesPerLine) ? _editor.BytesPerLine : num);
        num = ((num >= 0) ? num : 0);
        num2 = ((num2 > _editor.MaxBytesV) ? _editor.MaxBytesV : num2);
        num2 = ((num2 >= 0) ? num2 : 0);
        if ((_editor.LastVisibleByte - _editor.FirstVisibleByte) / _editor.BytesPerLine <= num2)
        {
            if ((_editor.LastVisibleByte - _editor.FirstVisibleByte) % _editor.BytesPerLine <= num)
            {
                num = (_editor.LastVisibleByte - _editor.FirstVisibleByte) % _editor.BytesPerLine;
            }
            num2 = (_editor.LastVisibleByte - _editor.FirstVisibleByte) / _editor.BytesPerLine;
        }
        int index = Math.Min(_editor.LastVisibleByte, _editor.FirstVisibleByte + num + num2 * _editor.BytesPerLine);
        int x2 = num * _recHexValue.Width + _recHexValue.X;
        int y2 = num2 * _recHexValue.Height + _recHexValue.Y;
        _editor.SetCaretStart(index, new Point(x2, y2));
        _isEditing = false;
    }

    public void OnMouseDragged(int x, int y)
    {
        int num = (x - _recHexValue.X) / _recHexValue.Width;
        int num2 = (y - _recHexValue.Y) / _recHexValue.Height;
        num = ((num > _editor.BytesPerLine) ? _editor.BytesPerLine : num);
        num = ((num >= 0) ? num : 0);
        num2 = ((num2 > _editor.MaxBytesV) ? _editor.MaxBytesV : num2);
        num2 = ((_editor.FirstVisibleByte <= 0) ? ((num2 >= 0) ? num2 : 0) : ((num2 < 0) ? (-1) : num2));
        if ((_editor.LastVisibleByte - _editor.FirstVisibleByte) / _editor.BytesPerLine <= num2)
        {
            if ((_editor.LastVisibleByte - _editor.FirstVisibleByte) % _editor.BytesPerLine <= num)
            {
                num = (_editor.LastVisibleByte - _editor.FirstVisibleByte) % _editor.BytesPerLine;
            }
            num2 = (_editor.LastVisibleByte - _editor.FirstVisibleByte) / _editor.BytesPerLine;
        }
        int index = Math.Min(_editor.LastVisibleByte, _editor.FirstVisibleByte + num + num2 * _editor.BytesPerLine);
        int x2 = num * _recHexValue.Width + _recHexValue.X;
        int y2 = num2 * _recHexValue.Height + _recHexValue.Y;
        _editor.SetCaretEnd(index, new Point(x2, y2));
    }

    public void OnMouseDoubleClick()
    {
        if (_editor.CaretIndex < _editor.LastVisibleByte)
        {
            int index = _editor.CaretIndex + 1;
            Point caretLocation = GetCaretLocation(index);
            _editor.SetCaretEnd(index, caretLocation);
        }
    }

    public void Update(int startPositionX, Rectangle area)
    {
        _recHexValue = new Rectangle(startPositionX, area.Y, (int)(_editor.CharSize.Width * 3f), (int)_editor.CharSize.Height - 2);
        _recHexValue.X += _editor.EntityMargin;
    }

    public void Paint(Graphics g, int index, int startIndex)
    {
        Point byteColumnAndRow = GetByteColumnAndRow(index);
        if (_editor.IsSelected(index + startIndex))
        {
            PaintByteAsSelected(g, byteColumnAndRow, index + startIndex);
        }
        else
        {
            PaintByte(g, byteColumnAndRow, index + startIndex);
        }
    }

    private void PaintByteAsSelected(Graphics g, Point point, int index)
    {
        SolidBrush brush = new SolidBrush(_editor.SelectionBackColor);
        SolidBrush brush2 = new SolidBrush(_editor.SelectionForeColor);
        RectangleF bound = GetBound(point);
        string s = _editor.GetByte(index).ToString(_hexType);
        g.FillRectangle(brush, bound);
        g.DrawString(s, _editor.Font, brush2, bound, _stringFormat);
    }

    private void PaintByte(Graphics g, Point point, int index)
    {
        SolidBrush brush = new SolidBrush(_editor.ForeColor);
        RectangleF bound = GetBound(point);
        string s = _editor.GetByte(index).ToString(_hexType);
        g.DrawString(s, _editor.Font, brush, bound, _stringFormat);
    }

    public void SetLowerCase()
    {
        _hexType = "x2";
    }

    public void SetUpperCase()
    {
        _hexType = "X2";
    }

    public void Focus()
    {
        int caretIndex = _editor.CaretIndex;
        Point caretLocation = GetCaretLocation(caretIndex);
        _editor.SetCaretStart(caretIndex, caretLocation);
    }

    private Point GetCaretLocation(int index)
    {
        int x = _recHexValue.X + _recHexValue.Width * (index % _editor.BytesPerLine);
        int y = _recHexValue.Y + _recHexValue.Height * ((index - (_editor.FirstVisibleByte + index % _editor.BytesPerLine)) / _editor.BytesPerLine);
        return new Point(x, y);
    }

    private void HandleUserRemove()
    {
        int selectionStart = _editor.SelectionStart;
        Point caretLocation = GetCaretLocation(selectionStart);
        _editor.RemoveSelectedBytes();
        _editor.SetCaretStart(selectionStart, caretLocation);
    }

    private void HandleUserInput(char key)
    {
        if (!_editor.CaretFocused)
        {
            return;
        }
        HandleUserRemove();
        if (_isEditing)
        {
            _isEditing = false;
            byte @byte = _editor.GetByte(_editor.CaretIndex);
            @byte += Convert.ToByte(key.ToString(), 16);
            _editor.SetByte(_editor.CaretIndex, @byte);
            int index = _editor.CaretIndex + 1;
            Point caretLocation = GetCaretLocation(index);
            _editor.SetCaretStart(index, caretLocation);
            return;
        }
        _isEditing = true;
        string value = key + "0";
        byte item = Convert.ToByte(value, 16);
        if (_editor.HexTable.Length == 0)
        {
            _editor.AppendByte(item);
        }
        else
        {
            _editor.InsertByte(_editor.CaretIndex, item);
        }
        int x = _recHexValue.X + _recHexValue.Width * (_editor.CaretIndex % _editor.BytesPerLine) + _recHexValue.Width / 2;
        int y = _recHexValue.Y + _recHexValue.Height * ((_editor.CaretIndex - (_editor.FirstVisibleByte + _editor.CaretIndex % _editor.BytesPerLine)) / _editor.BytesPerLine);
        _editor.SetCaretStart(_editor.CaretIndex, new Point(x, y));
    }

    private Point GetByteColumnAndRow(int index)
    {
        int x = index % _editor.BytesPerLine;
        int y = index / _editor.BytesPerLine;
        return new Point(x, y);
    }

    private RectangleF GetBound(Point point)
    {
        return new RectangleF(_recHexValue.X + point.X * _recHexValue.Width, _recHexValue.Y + point.Y * _recHexValue.Height, _recHexValue.Width, _recHexValue.Height);
    }

    private bool IsHex(char c)
    {
        return (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F') || char.IsDigit(c);
    }
}
