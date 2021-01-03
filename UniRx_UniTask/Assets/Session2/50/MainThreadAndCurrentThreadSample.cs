using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MainThreadAndCurrentThreadSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //メインスレッドを止めない → コルーチンのwaitForSeconds()を使用しているため
        Observable.Timer(TimeSpan.FromSeconds(10), Scheduler.MainThread)
            .Subscribe(_ => Debug.Log("MainThread"))
            .AddTo(this);

        //メインスレッドを止める → 時間計測に Thread.Sleep()を用いているため
        Observable.Timer(TimeSpan.FromSeconds(10), Scheduler.CurrentThread)
            .Subscribe(_ => Debug.Log("CurrentThread"))
            .AddTo(this);
    }

}
