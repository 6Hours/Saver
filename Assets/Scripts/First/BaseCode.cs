using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCode : MonoBehaviour
{
    public static string Encode(string data)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(data);
        return System.Convert.ToBase64String(bytes);
    }
    public static string Decode(string base64data)
    {
        var bytes = System.Convert.FromBase64String(base64data);
        return System.Text.Encoding.UTF8.GetString(bytes);
    }
}
