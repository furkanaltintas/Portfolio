namespace Portfolio.Core.Helpers;

public static class EnumToStringHelper
{
    public static string EnumToString<TEnum>(TEnum @enum) where TEnum : Enum
    {
        string enumName = Enum.GetName(typeof(TEnum), @enum)!;
        return enumName;
    }
}