using Microsoft.Win32;
using System;

namespace Server.Helper;

public class RegValueHelper
{
    private static string DEFAULT_REG_VALUE = "(Default)";

    public static bool IsDefaultValue(string valueName)
    {
        return string.IsNullOrEmpty(valueName);
    }

    public static string GetName(string valueName)
    {
        return string.IsNullOrEmpty(valueName) ? DEFAULT_REG_VALUE : valueName;
    }

    public static string RegistryValueToString(RegistrySeeker.RegValueData value)
    {
        switch (value.Kind)
        {
            case RegistryValueKind.String:
            case RegistryValueKind.ExpandString:
                return ByteConverter.ToString(value.Data);
            case RegistryValueKind.Binary:
                return (value.Data.Length != 0) ? BitConverter.ToString(value.Data).Replace("-", " ").ToLower() : "(zero-length binary value)";
            case RegistryValueKind.DWord:
                {
                    uint num2 = ByteConverter.ToUInt32(value.Data);
                    return $"0x{num2:x8} ({num2})";
                }
            case RegistryValueKind.MultiString:
                return string.Join(" ", ByteConverter.ToStringArray(value.Data));
            default:
                return string.Empty;
            case RegistryValueKind.QWord:
                {
                    ulong num = ByteConverter.ToUInt64(value.Data);
                    return $"0x{num:x8} ({num})";
                }
        }
    }
}
