using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public enum Fruits
{
    Apple,
    Banana,
    Peach,
    Melon,
    Orange,
}

[Serializable]      //Inspectorに表示できるようになる
public class FruitsEnumReactiveProperty : ReactiveProperty<Fruits>
{
    public FruitsEnumReactiveProperty()
    {
        
    }

    public FruitsEnumReactiveProperty(Fruits init) : base(init)
    {
        
    }
}

//どの型に対して直接弄れるようにさせるかここで設定
[UnityEditor.CustomPropertyDrawer(typeof(FruitsEnumReactiveProperty))]
public class ExtendInspectorDisplayDrawer : InspectorDisplayDrawer
{
    //InspectorDisplayDrawerを継承すると、ReactiveProeprtyのジェネリック型を、直接弄れるようになるみたい
}