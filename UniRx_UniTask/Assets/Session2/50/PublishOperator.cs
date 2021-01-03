using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PublishOperator : MonoBehaviour
{
    void Start()
    {
        //var originalSubject = new Subject<string>();

        //IConnectableObservable<string> appendStringObservable = originalSubject
        //    .Scan((previous, current) => previous + " " + current)
        //    .Last()
        //    //Hot変換する
        //    .Publish();

        //// IConnectableObservable.Connect()を呼ぶと、Subscribe()実行される　(Hot変換実行)
        //var disposable = appendStringObservable.Connect();

        //originalSubject.OnNext("I");
        //originalSubject.OnNext("have");

        //appendStringObservable.Subscribe(x => Debug.Log(x));

        //originalSubject.OnNext("a");
        //originalSubject.OnNext("pen");
        //originalSubject.OnCompleted();

        //originalSubject.Dispose();

        var subject = new Subject<int>();
        var subSubject = new Subject<int>();

        IConnectableObservable<int> doObservable = subject
            .Do(x => Debug.Log(x))
            //Hot変換
            .Publish();

        //Hot変換実行
        doObservable.Connect();

        subject.OnNext(0);
        doObservable.Subscribe(subSubject);
        subject.OnNext(1);
        subSubject.Subscribe(x => Debug.Log("Sub; " + x));
        subject.OnNext(2);
        subSubject.OnNext(3);
    }
}
