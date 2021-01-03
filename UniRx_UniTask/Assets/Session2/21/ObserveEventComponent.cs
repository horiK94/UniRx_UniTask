using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObserveEventComponent : MonoBehaviour
{
    [SerializeField] private CountDownEventProvider countDownEventProvider = null;

    private PrintLogObserver<int> _printLogObserver = null;

    private IDisposable _disposable = null;

    private void Start()
    {
        //IObserverを実装したPrintLogObserverを作成
        _printLogObserver = new PrintLogObserver<int>();

        //CountDownEventProviderのcountDownObservable(IObservable)に_printLogObserverを登録
        //_disposable = countDownEventProvider.countDownObservable.Subscribe(_printLogObserver);
        _disposable = countDownEventProvider.countDownObservable.Subscribe(
            _onNext =>
            {
                Debug.Log("onNext");
            }, _error =>
            {
                Debug.Log("onError");

            }, () =>
            {
                Debug.Log("OnCompleted");
            });
    }

    private void OnDestroy()
    {
        _disposable?.Dispose();
    }
}
