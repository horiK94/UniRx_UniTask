using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PrintLogObserver<T> : IObserver<T>
{
    // Start is called before the first frame update
    public void OnCompleted()
    {
        Debug.Log("OnCompleted");
    }

    public void OnError(Exception error)
    {
        Debug.Log("OnError");
    }

    public void OnNext(T value)
    {
        Debug.Log("OnNext");
    }
}
