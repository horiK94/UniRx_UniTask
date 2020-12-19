using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Model : MonoBehaviour
{
    [SerializeField] private ReactiveProperty<int> num = new ReactiveProperty<int>(0);

    public IReadOnlyReactiveProperty<int> Num => num;

    public void UpdateNum(int _val)
    {
        num.Value = Mathf.Clamp(_val, 0, 100);
    }
}
