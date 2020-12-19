using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UniRx;

public class Preseter : MonoBehaviour
{
    //Modelへの参照
    [SerializeField] private Model model;

    //Viewへの参照
    [SerializeField] private InputField inputField = null;
    [SerializeField] private Slider slider = null;
    [SerializeField] private Button upButton = null;
    [SerializeField] private Button downButton = null;

    private void Start()
    {
        // Model → View(生徒たち)
        model.Num.Subscribe(_num =>
        {
            inputField.text = _num.ToString();
            slider.value = _num;
        }).AddTo(this);

        //View → Model(先生たち)
        inputField.OnValueChangedAsObservable()
            .Select(_numString =>
            {
                bool isSucceed = int.TryParse(_numString, out int num);
                return (isSucceed, num);
            })
            .Where(_val => _val.isSucceed)
            .Subscribe(_val => model.UpdateNum(_val.num));

        slider.OnValueChangedAsObservable()
            .Subscribe(_value => model.UpdateNum((int) _value));

        Observable.Merge(
            upButton.OnClickAsObservable().Select(_ => +1),
            downButton.OnClickAsObservable().Select(_ => -1)
        ).Subscribe(_val => model.UpdateNum(_val + model.Num.Value));
    }
}
