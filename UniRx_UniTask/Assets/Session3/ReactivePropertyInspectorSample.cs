using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactivePropertyInspectorSample : MonoBehaviour
{
    public ReactiveProperty<int> genericType = new ReactiveProperty<int>();

    public IntReactiveProperty intReactiveProperty = new IntReactiveProperty();

    public FruitsEnumReactiveProperty fruits = new FruitsEnumReactiveProperty();
} 
