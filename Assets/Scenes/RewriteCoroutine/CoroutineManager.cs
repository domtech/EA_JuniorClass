using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager _inst;
    public static CoroutineManager Inst => _inst;

    private void Awake()
    {
        _inst = this;
    }

    private LinkedList<IEnumerator> coroutineList = new LinkedList<IEnumerator>();

    public void MyStartCoroutine(IEnumerator ie)
    {
        coroutineList.AddLast(ie);
    }

    public void MyStopCoroutine (IEnumerator ie)
    {
        try
        {
            coroutineList.Remove(ie);
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    public void UpdateCoroutine()
    {
        var node = coroutineList.First;
        while(node != null)
        {
            IEnumerator ie = node.Value;
            bool ret = true;
            if(ie.Current is IWait)
            {
                var iwait = (IWait)ie.Current;
                if(iwait.Tick())
                {
                    ret = ie.MoveNext();
                }
            }
            else
            {
                ret = ie.MoveNext();
            }

            if(!ret)
            {
                coroutineList.Remove(node);
            }

            node = node.Next;

        }
    }



}
