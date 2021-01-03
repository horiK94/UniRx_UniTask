using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

public class ThreadSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Unit Main Thread ID: " + Thread.CurrentThread.ManagedThreadId);

        var subject = new Subject<Unit>();
        subject.AddTo(this);

        subject.ObserveOn(Scheduler.Immediate)
            .Subscribe(_ =>
            {
                Debug.Log("Thread ID: " + Thread.CurrentThread.ManagedThreadId);
            });

        subject.OnNext(Unit.Default);

        Task.Run(() => subject.OnNext(Unit.Default));

        //subject.OnCompleted();
    }
}
