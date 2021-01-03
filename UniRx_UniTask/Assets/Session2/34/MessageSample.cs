using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MessageSample : MonoBehaviour
{
    [SerializeField] private float time = 30f;

    //時間切れを知らせる
    public IObservable<Unit> OnTimeUpAsyncSubject => onTimeUpAsyncSubject;

    private readonly AsyncSubject<Unit> onTimeUpAsyncSubject = new AsyncSubject<Unit>();

    private IDisposable disposable = null;

    void Start()
    {
        //指定した時間経過したら通知する
        disposable = Observable.Timer(TimeSpan.FromSeconds(time))
            .Subscribe(_ =>
            {
                onTimeUpAsyncSubject.OnNext(Unit.Default);
                onTimeUpAsyncSubject.OnCompleted();
            });
    }

    void Destroy()
    {
        disposable?.Dispose();
        onTimeUpAsyncSubject.Dispose();
    }
}
