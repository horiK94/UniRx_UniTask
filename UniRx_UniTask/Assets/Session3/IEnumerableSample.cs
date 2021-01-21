using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

public class IEnumerableSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] strArray = new string[] { "apple", "orange", "banana" };
        IObservable<string> strObservable =  strArray.ToObservable();

        strObservable.Subscribe(text => Debug.Log(text));

        string hoge = "hogehoge";
        hoge.ToObservable()
            .Subscribe(_ch => Debug.Log("文字: " + _ch));

        hoge.ToObservable(scheduler: Scheduler.MainThread)
            .Subscribe(x => Debug.Log("MainThread frame: " + Time.frameCount + ", 出力: " + x));

        hoge.ToObservable(scheduler: Scheduler.CurrentThread)
            .Subscribe(x => Debug.Log("CurrentThread frame: " + Time.frameCount + ", 出力: " + x));
    }
}
