using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CountDownEventProvider : MonoBehaviour
{

    [SerializeField] private int countSeconds = 10;

    private Subject<int> _subject;

    public IObservable<int> countDownObservable => _subject;
    
    // Start is called before the first frame update
    void Start()
    {
        _subject = new Subject<int>();

        //カウントダウンコルーチン起動
        StartCoroutine(countDownCoroutine());
    }

    private IEnumerator countDownCoroutine()
    {
        int current = countSeconds;

        while (current > 0)
        {
            _subject.OnNext(current);
            current -= 1;
            yield return new WaitForSeconds(1.0f);
        }

        _subject.OnNext(0);
        _subject.OnCompleted();
    }

    private void OnDestroy()
    {
        //開放時に、登録を解除する
        _subject.Dispose();
    }
}
