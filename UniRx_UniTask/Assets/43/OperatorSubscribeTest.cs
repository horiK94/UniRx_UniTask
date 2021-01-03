using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class OperatorSubscribeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var subject = new Subject<int>();

        //IObservable<int> intObservable = subject.Do(x => Debug.Log("Do!"));

        //intObservable.Subscribe(x => Debug.Log("First: " + x));
        //intObservable.Subscribe(x => Debug.Log("Second: " + x));

        //subject.OnNext(1);

        //subject.OnCompleted();
        //subject.Dispose();

        var subject = new Subject<Unit>();

        IObservable<Unit> observer = subject
            .Do(_ => Debug.Log("Base"))
            .Do(_ => Debug.Log("Common"));

        observer.Do(_ => Debug.Log("First")).Subscribe();
        observer.Do(_ => Debug.Log("Second")).Subscribe();

        subject.OnNext(Unit.Default);
        subject.OnCompleted();
        subject.Dispose();
    }
}
