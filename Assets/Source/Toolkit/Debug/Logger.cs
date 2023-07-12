using UnityEngine;

// For comfort
// if you use Debug.Log() and remove it then 'using UnityEngine' will not be removed
// and you can't do that - Debug.Log(); only - Debug.Log("log");
public static class Logger
{
    private static string _space => " , ";
    private static string _defaultValue => "log";

    public static void Log(params object[] obj)
    {
        var value = string.Join(_space, obj);
        if (string.IsNullOrEmpty(value))
            value = _defaultValue;

        Debug.Log(value);
    }
}