using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ErrorSample : MonoBehaviour
{
    void Start()
    {
        var subject = new Subject<string>();

        subject
            .Select(str => int.Parse(str))
            .Subscribe(_x => Debug.Log(_x),
                ex =>
                {
                    Debug.LogError("例外が発生しました: " + ex.Message);
                }, () =>
                {
                    Debug.Log("OnCompleted");
                });

        subject.OnNext("1");
        subject.OnNext("2");
        //例外発生. SelectオペレーターからErrorメッセージが発行される
        //購読が終了
        subject.OnNext("Three");
        subject.OnNext("4");

        //subject自体がエラーを出したわけではないのでsubjectは稼働中。
        //再講読すれば利用できる
        subject
            .Subscribe(_x => Debug.Log(_x),
                ex =>
                {
                    Debug.LogError("例外が発生しました: " + ex.Message);
                }, () =>
                {
                    Debug.Log("OnCompleted");
                });
        subject.OnNext("Hello");
        subject.OnCompleted();
        subject.Dispose();
    }
}
