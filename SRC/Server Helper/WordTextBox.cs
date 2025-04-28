using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Server.Helper;

public class WordTextBox : TextBox
{
    public enum WordType
    {
        DWORD,
        QWORD
    }

    private bool isHexNumber;

    private WordType type;

    private IContainer components = null;

    public override int MaxLength
    {
        get
        {
            return base.MaxLength;
        }
        set
        {
        }
    }

    public bool IsHexNumber
    {
        get
        {
            return isHexNumber;
        }
        set
        {
            if (isHexNumber == value)
            {
                return;
            }
            if (value)
            {
                if (Type == WordType.DWORD)
                {
                    Text = UInt32_0.ToString("x");
                }
                else
                {
                    Text = UInt64_0.ToString("x");
                }
            }
            else if (Type == WordType.DWORD)
            {
                Text = UInt32_0.ToString();
            }
            else
            {
                Text = UInt64_0.ToString();
            }
            isHexNumber = value;
            UpdateMaxLength();
        }
    }

    public WordType Type
    {
        get
        {
            return type;
        }
        set
        {
            if (type != value)
            {
                type = value;
                UpdateMaxLength();
            }
        }
    }

    public uint UInt32_0
    {
        get
        {
            try
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return 0u;
                }
                if (IsHexNumber)
                {
                    return uint.Parse(Text, NumberStyles.HexNumber);
                }
                return uint.Parse(Text);
            }
            catch (Exception)
            {
                return uint.MaxValue;
            }
        }
    }

    public ulong UInt64_0
    {
        get
        {
            try
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return 0uL;
                }
                if (IsHexNumber)
                {
                    return ulong.Parse(Text, NumberStyles.HexNumber);
                }
                return ulong.Parse(Text);
            }
            catch (Exception)
            {
                return ulong.MaxValue;
            }
        }
    }

    public bool IsConversionValid()
    {
        if (string.IsNullOrEmpty(Text))
        {
            return true;
        }
        if (!IsHexNumber)
        {
            return ConvertToHex();
        }
        return true;
    }

    public WordTextBox()
    {
        InitializeComponent();
        base.MaxLength = 8;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        base.OnKeyPress(e);
        e.Handled = !IsValidChar(e.KeyChar);
    }

    private bool IsValidChar(char ch)
    {
        return char.IsControl(ch) || char.IsDigit(ch) || (IsHexNumber && char.IsLetter(ch) && char.ToLower(ch) <= 'f');
    }

    private void UpdateMaxLength()
    {
        if (Type == WordType.DWORD)
        {
            if (IsHexNumber)
            {
                base.MaxLength = 8;
            }
            else
            {
                base.MaxLength = 10;
            }
        }
        else if (IsHexNumber)
        {
            base.MaxLength = 16;
        }
        else
        {
            base.MaxLength = 20;
        }
    }

    private bool ConvertToHex()
    {
        try
        {
            if (Type == WordType.DWORD)
            {
                uint.Parse(Text);
            }
            else
            {
                ulong.Parse(Text);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
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
    }
}
