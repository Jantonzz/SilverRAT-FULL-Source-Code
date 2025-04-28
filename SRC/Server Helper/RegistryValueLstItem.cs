using System.Windows.Forms;

namespace Server.Helper;

public class RegistryValueLstItem : ListViewItem
{
    private string _type { get; set; }

    private string _data { get; set; }

    public string RegName
    {
        get
        {
            return base.Name;
        }
        set
        {
            base.Name = value;
            base.Text = RegValueHelper.GetName(value);
        }
    }

    public string Type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
            if (base.SubItems.Count < 2)
            {
                base.SubItems.Add(_type);
            }
            else
            {
                base.SubItems[1].Text = _type;
            }
            base.ImageIndex = GetRegistryValueImgIndex(_type);
        }
    }

    public string Data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
            if (base.SubItems.Count < 3)
            {
                base.SubItems.Add(_data);
            }
            else
            {
                base.SubItems[2].Text = _data;
            }
        }
    }

    public RegistryValueLstItem(RegistrySeeker.RegValueData value)
    {
        RegName = value.Name;
        Type = value.Kind.RegistryTypeToString();
        Data = RegValueHelper.RegistryValueToString(value);
    }

    private int GetRegistryValueImgIndex(string type)
    {
        switch (type)
        {
            default:
                return 1;
            case "REG_MULTI_SZ":
            case "REG_SZ":
            case "REG_EXPAND_SZ":
                return 0;
        }
    }
}
