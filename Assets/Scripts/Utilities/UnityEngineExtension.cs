using System.Collections;
using UnityEngine;

public static class UnityEngineExtension 
{

    public delegate void CallBack();

   
    public static void InvokeNextFrame(this MonoBehaviour _mb, CallBack callback)
    {
        _mb.StartCoroutine(ProcessNextFrame(callback));
    }

    private static IEnumerator ProcessNextFrame(CallBack callback)
    {
        yield return null;
        callback();
    }


}
