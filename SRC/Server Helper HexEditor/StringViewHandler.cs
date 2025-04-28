using System;
using System.Drawing;
using System.Windows.Forms;

namespace Server.Helper.HexEditor;

public class StringViewHandler
{
    private Rectangle _recStringView;

    private StringFormat _stringFormat;

    private HexEditor _editor;

    public int MaxWidth => _recStringView.X + _recStringView.Width;

    public StringViewHandler(HexEditor editor)
    {
        _editor = editor;
        _stringFormat = new StringFormat(StringFormat.GenericTypographic);
        _stringFormat.Alignment = StringAlignment.Center;
        _stringFormat.LineAlignment = StringAlignment.Center;
    }

    public void OnKeyPress(KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar))
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
                _editor.RemoveByteAt(index);
                Point caretLocation3 = GetCaretLocation(index);
                _editor.SetCaretStart(index, caretLocation3);
            }
        }
        else if (e.KeyCode == Keys.Up && _editor.CaretIndex - _editor.BytesPerLine >= 0)
        {
            int num = _editor.CaretIndex - _editor.BytesPerLine;
            if (num % _editor.BytesPerLine == 0 && _editor.CaretPosX >= _recStringView.X + _recStringView.Width)
            {
                Point location = new Point(_editor.CaretPosX, _editor.CaretPosY - _recStringView.Height);
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
            Point location2 = new Point(_editor.CaretPosX, _editor.CaretPosY + _recStringView.Height);
            if (e.Shift)
            {
                _editor.SetCaretEnd(num2, location2);
            }
            else
            {
                _editor.SetCaretStart(num2, location2);
            }
        }
        else if (e.KeyCode == Keys.Left && _editor.CaretIndex - 1 >= 0)
        {
            int index2 = _editor.CaretIndex - 1;
            HandleArrowKeys(index2, e.Shift);
        }
        else if (e.KeyCode == Keys.Right && _editor.CaretIndex + 1 <= _editor.LastVisibleByte)
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
    }

    public void OnMouseDown(int x, int y)
    {
        int num = (x - _recStringView.X) / (int)_editor.CharSize.Width;
        int num2 = (y - _recStringView.Y) / _recStringView.Height;
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
        int x2 = num * (int)_editor.CharSize.Width + _recStringView.X;
        int y2 = num2 * _recStringView.Height + _recStringView.Y;
        _editor.SetCaretStart(index, new Point(x2, y2));
    }

    public void OnMouseDragged(int x, int y)
    {
        int num = (x - _recStringView.X) / (int)_editor.CharSize.Width;
        int num2 = (y - _recStringView.Y) / _recStringView.Height;
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
        int x2 = num * (int)_editor.CharSize.Width + _recStringView.X;
        int y2 = num2 * _recStringView.Height + _recStringView.Y;
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

    public void Focus()
    {
        int caretIndex = _editor.CaretIndex;
        Point caretLocation = GetCaretLocation(caretIndex);
        _editor.SetCaretStart(caretIndex, caretLocation);
    }

    public void Update(int startPositionX, Rectangle area)
    {
        _recStringView = new Rectangle(startPositionX, area.Y, (int)(_editor.CharSize.Width * (float)_editor.BytesPerLine), (int)_editor.CharSize.Height - 2);
        _recStringView.X += _editor.EntityMargin;
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
        char byteAsChar = _editor.GetByteAsChar(index);
        string s = (char.IsControl(byteAsChar) ? "." : byteAsChar.ToString());
        g.FillRectangle(brush, bound);
        g.DrawString(s, _editor.Font, brush2, bound, _stringFormat);
    }

    private void PaintByte(Graphics g, Point point, int index)
    {
        SolidBrush brush = new SolidBrush(_editor.ForeColor);
        RectangleF bound = GetBound(point);
        char byteAsChar = _editor.GetByteAsChar(index);
        string s = (char.IsControl(byteAsChar) ? "." : byteAsChar.ToString());
        g.DrawString(s, _editor.Font, brush, bound, _stringFormat);
    }

    private Point GetCaretLocation(int index)
    {
        int x = _recStringView.X + (int)_editor.CharSize.Width * (index % _editor.BytesPerLine);
        int y = _recStringView.Y + _recStringView.Height * ((index - (_editor.FirstVisibleByte + index % _editor.BytesPerLine)) / _editor.BytesPerLine);
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
        if (_editor.CaretFocused)
        {
            HandleUserRemove();
            byte item = Convert.ToByte(key);
            if (_editor.HexTableLength <= 0)
            {
                _editor.AppendByte(item);
            }
            else
            {
                _editor.InsertByte(_editor.CaretIndex, item);
            }
            int index = _editor.CaretIndex + 1;
            Point caretLocation = GetCaretLocation(index);
            _editor.SetCaretStart(index, caretLocation);
        }
    }

    private Point GetByteColumnAndRow(int index)
    {
        int x = index % _editor.BytesPerLine;
        int y = index / _editor.BytesPerLine;
        return new Point(x, y);
    }

    private RectangleF GetBound(Point point)
    {
        RectangleF result = new RectangleF(_recStringView.X + point.X * (int)_editor.CharSize.Width, _recStringView.Y + point.Y * _recStringView.Height, _editor.CharSize.Width, _recStringView.Height);
        return result;
    }
}
