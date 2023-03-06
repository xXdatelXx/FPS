using UnityEngine;

public static class Logger
{
    private static string _space => " , ";
    private static string _defaultValue => "log";

    public static void Log(params object[] obj)
    {
        var value = string.Join(_space, obj);
        if (value.Length == 0)
            value = _defaultValue;

        Debug.Log(value);
    }
}