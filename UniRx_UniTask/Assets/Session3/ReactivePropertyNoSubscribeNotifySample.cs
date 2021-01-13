using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactivePropertyNoSubscribeNotifySample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReactiveProperty<int> helath = new ReactiveProperty<int>(100);

        //SkipLatestValueOnSubscribe()を呼ぶと、Subscribe(購読)時に、現在の設定値でOnNextメッセージを通知しない
        helath.SkipLatestValueOnSubscribe()
            .Subscribe(val => Debug.Log("通知された値: " + val));

        helath.Dispose();
    }
}
