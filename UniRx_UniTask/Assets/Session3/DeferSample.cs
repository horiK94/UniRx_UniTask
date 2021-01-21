using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DeferSample : MonoBehaviour
{
    private void Start()
    {
        //Deferは作成されるたびにデリゲート実行 → Observableを実行する
        var intObservable = Observable.Defer<int>(() =>
       {
           int r = UnityEngine.Random.Range(0, 100);
           //Return: OnNextとOnCompletedを返す
           return Observable.Return(r);
       });

        intObservable.Subscribe(x => Debug.Log(x));
        intObservable.Subscribe(x => Debug.Log(x));
        intObservable.Subscribe(x => Debug.Log(x));
    }
}
