using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DisposeSample : MonoBehaviour
{
    void Start()
    {
        var subject = new Subject<int>();

        IDisposable disposableA = subject.Subscribe(_x => Debug.Log("A:" + _x));
        IDisposable disposableB = subject.Subscribe(_x => Debug.Log("B:" + _x));
        IDisposable disposableC = subject.Subscribe(_x => Debug.Log("C:" + _x));

        subject.OnNext(100);

        Debug.Log("----------------");

        disposableA.Dispose();

        subject.OnNext(200);

        subject.OnCompleted();

        subject.Dispose();
    }
}
