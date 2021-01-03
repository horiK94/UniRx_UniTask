using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class OperatorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        //そのまま登録した
        subject.Subscribe(_val => Debug.Log("raw: " + _val));

        //0以下を除外して登録した
        subject.Where(_val => _val > 0)
            .Subscribe(_val => Debug.Log("filter: " + _val));

        //イベント発行
        subject.OnNext(1);
        subject.OnNext(-1);
        subject.OnNext(3);
        subject.OnNext(0);

        //終了
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
