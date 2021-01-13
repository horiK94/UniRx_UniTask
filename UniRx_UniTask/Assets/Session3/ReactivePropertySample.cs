using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactivePropertySample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //値が変わるとOnNext()を通知するObservable
        //var reactiveProperty = new ReactiveProperty<int>();       //初期化なしも可能
        var reactiveProperty = new ReactiveProperty<int>(100);

        Debug.Log("現在の値: " + reactiveProperty.Value);

        reactiveProperty
            .Subscribe(
                //購読時に現在の値をOnNextメッセージで通知する
                val => Debug.Log("通知された値: " + val),
                () => Debug.Log("OnCompleted"));

        reactiveProperty.Value = 50;

        Debug.Log("現在の値: " + reactiveProperty.Value);

        Debug.Log("再度50を設定する");
        //直前の値と同時のため、OnNext()は通知されない
        reactiveProperty.Value = 50;

        Debug.Log("強制的に通知を飛ばす");
        reactiveProperty.SetValueAndForceNotify(50);

        //Dispose()を呼ぶとOnCompletedメッセージが発行される
        reactiveProperty.Dispose();
    }
}
