using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UseMessage : MonoBehaviour
{
    [SerializeField] 
    private MessageSample observable = null;

    // Start is called before the first frame update
    void Start()
    {
        observable.OnTimeUpAsyncSubject.Subscribe(_ =>
        {
            Debug.Log("時間になりました");
        }, () =>
        {
            Debug.Log("完了です");
        });
    }
}
