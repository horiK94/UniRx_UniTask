using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class AddToSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.IntervalFrame(5)
            .Subscribe(_ => Debug.Log("Do!"))
            //OnDestory関数が呼ばれたらDipose()が呼ばれる
            .AddTo(this);
    }
}
