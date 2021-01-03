using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SubjectSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
        var subject = new Subject<int>();

        subject.OnNext(1);

        //購読開始
        subject.Subscribe(
            x => Debug.Log("OnNext: " + x),
            error => Debug.Log("OnError: " + error),
            () => Debug.Log("OnCompleted"));

        subject.OnNext(2);
        subject.OnNext(3);

        subject.OnCompleted();
        subject.Dispose();
    }
}
