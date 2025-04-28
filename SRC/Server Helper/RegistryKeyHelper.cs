using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Helper;

public static class RegistryKeyHelper
{
    private static string DEFAULT_VALUE = string.Empty;

    public static bool AddRegistryKeyValue(RegistryHive hive, string path, string name, string value, bool addQuotes = false)
    {
        try
        {
            using RegistryKey registryKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenWritableSubKeySafe(path);
            if (registryKey == null)
            {
                return false;
            }
            if (addQuotes && !value.StartsWith("\"") && !value.EndsWith("\""))
            {
                value = "\"" + value + "\"";
            }
            registryKey.SetValue(name, value);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static RegistryKey OpenReadonlySubKey(RegistryHive hive, string path)
    {
        try
        {
            return RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenSubKey(path, writable: false);
        }
        catch
        {
            return null;
        }
    }

    public static bool DeleteRegistryKeyValue(RegistryHive hive, string path, string name)
    {
        try
        {
            using RegistryKey registryKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64).OpenWritableSubKeySafe(path);
            if (registryKey == null)
            {
                return false;
            }
            registryKey.DeleteValue(name, throwOnMissingValue: true);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static bool IsDefaultValue(string valueName)
    {
        return string.IsNullOrEmpty(valueName);
    }

    public static RegistrySeeker.RegValueData[] AddDefaultValue(List<RegistrySeeker.RegValueData> values)
    {
        if (!values.Any((RegistrySeeker.RegValueData value) => IsDefaultValue(value.Name)))
        {
            values.Add(GetDefaultValue());
        }
        return values.ToArray();
    }

    public static RegistrySeeker.RegValueData[] GetDefaultValues()
    {
        return new RegistrySeeker.RegValueData[1] { GetDefaultValue() };
    }

    public static RegistrySeeker.RegValueData CreateRegValueData(string name, RegistryValueKind kind, object value = null)
    {
        RegistrySeeker.RegValueData regValueData = new RegistrySeeker.RegValueData
        {
            Name = name,
            Kind = kind
        };
        if (value == null)
        {
            regValueData.Data = new byte[0];
        }
        else
        {
            switch (regValueData.Kind)
            {
                case RegistryValueKind.String:
                case RegistryValueKind.ExpandString:
                    regValueData.Data = ByteConverter.GetBytes((string)value);
                    break;
                case RegistryValueKind.Binary:
                    regValueData.Data = (byte[])value;
                    break;
                case RegistryValueKind.DWord:
                    regValueData.Data = ByteConverter.GetBytes((uint)(int)value);
                    break;
                case RegistryValueKind.MultiString:
                    regValueData.Data = ByteConverter.GetBytes((string[])value);
                    break;
                case RegistryValueKind.QWord:
                    regValueData.Data = ByteConverter.GetBytes((ulong)(long)value);
                    break;
            }
        }
        return regValueData;
    }

    private static RegistrySeeker.RegValueData GetDefaultValue()
    {
        return CreateRegValueData(DEFAULT_VALUE, RegistryValueKind.String);
    }
}
