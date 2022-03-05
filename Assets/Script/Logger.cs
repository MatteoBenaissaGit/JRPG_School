using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Logger : MonoBehaviour
{
    [Header("--- Settings ---")]
    [SerializeField] private bool _showLogs;
    [SerializeField] private string _prefix;
    public enum ColorChoice
    {
        red,
        green,
        yellow,
        blue,
        purple,
        orange,
        grey,
        white,
        cyan
    }
    [SerializeField] private ColorChoice _prefixColor;


    public void Log(object message, Object sender)
    {
        if (!_showLogs) return;
        Debug.Log($"<color={_prefixColor}>{_prefix} : {message}</color>", sender);
    }
}
