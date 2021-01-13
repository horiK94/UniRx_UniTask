using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BehaviorSubjectSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var behaviourSubject = new BehaviorSubject<int>(0);

        behaviourSubject.OnNext(0);
        behaviourSubject.OnNext(1);

        behaviourSubject.Subscribe(
            x => Debug.Log("OnNext: " + x),
            error => Debug.Log("OnError: " + error),
            () => Debug.Log("OnCompleted"));

        Debug.Log("購読後");

        behaviourSubject.OnNext(2);


        behaviourSubject.Subscribe(
            x => Debug.Log("OnNext2: " + x),
            error => Debug.Log("OnError2: " + error),
            () => Debug.Log("OnCompleted2"));

        Debug.Log("現在の値" + behaviourSubject.Value);
        behaviourSubject.OnNext(3);

        Debug.Log("Completedを呼ぶ直前");

        behaviourSubject.OnCompleted();
    }
}
