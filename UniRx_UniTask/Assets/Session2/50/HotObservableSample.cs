using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HotObservableSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var originalSubject = new Subject<string>();

        ////OnNextの内容をスペース区切りで連結、最後に出力 (今の状態だとCold Observable)
        //IObservable<string> appendObservable = originalSubject
        //    .Scan((previous, current) => previous + " " + current)
        //    .Last();

        ////連結用のSubject
        //var publishSubject = new Subject<string>();

        ////Hot Observableになる
        //appendObservable.Subscribe(publishSubject);
        ////originalSubject.Subscribe(publishSubject);

        //originalSubject.OnNext("I");
        //originalSubject.OnNext("have");

        //publishSubject.Subscribe(x => Debug.Log(x));
        ////originalSubject.Subscribe(x => Debug.Log(x));

        //originalSubject.OnNext("a");
        //originalSubject.OnNext("pen");

        //originalSubject.OnCompleted();

        var subject = new Subject<int>();
        var subSubject = new Subject<int>();

        IObservable<int> doObservable = subject.Do(x => Debug.Log(x));

        subject.OnNext(0);
        doObservable.Subscribe(subSubject);
        subject.OnNext(1);
        subSubject.Subscribe(x => Debug.Log("Sub; " + x));
        subject.OnNext(2);
        subSubject.OnNext(3);
    }
}
