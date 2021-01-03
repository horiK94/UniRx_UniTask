using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CompletedSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        var subject = new Subject<int>();

        subject.Subscribe(
            _x => Debug.Log(_x),
            () =>
            {
                Debug.Log("OnCompleted");
            });

        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnCompleted();
        subject.OnNext(4);


        subject.Dispose();
    }
}
