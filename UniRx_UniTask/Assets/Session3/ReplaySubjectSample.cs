using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReplaySubjectSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new ReplaySubject<int>(bufferSize: 3);

        for (int i = 0; i < 10; i++)
        {
            subject.OnNext(i);
        }

        subject.OnCompleted();
        //2回目のOnCompletedは通常通り呼ばれない
        subject.OnCompleted();

        //subject.OnError(new Exception("Error!"));

        subject.Subscribe(
            x => Debug.Log(x),
            ex => Debug.Log("Error" + ex),
            () => Debug.Log("OnCompleted"));
    }
}
