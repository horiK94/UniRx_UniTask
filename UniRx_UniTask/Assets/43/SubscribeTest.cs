using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SubscribeTest : MonoBehaviour
{
    void Start()
    {
        var subject = new Subject<string>();

        IObservable<string> appendStringObservable =
            subject
                //Scan: Nextの結果を保存し、次の処理に引き継げる関数
                .Scan((previous, current) => previous + " " + current)
                .Last();

        //連結されていないので実行できない
        subject.OnNext("I");
        subject.OnNext("have");

        //連結される
        appendStringObservable.Subscribe(x => Debug.Log(x));

        //subject.OnNext("I");
        //subject.OnNext("have");
        subject.OnNext("a");
        subject.OnNext("pen");
        subject.OnCompleted();

        subject.Dispose();
    }
}
