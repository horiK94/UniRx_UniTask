using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


//非同期のためのIObservable
//AsyncObject<T>はOnCompleted()が呼ばれるまで結果を出力しない
//OnCompleted()のときに最後にOnNext()されていたものを出力する
public class AsyncSubjectSample : MonoBehaviour
{
    private AsyncSubject<Texture> playerTextureAsyncSubject = new AsyncSubject<Texture>();

    public IObservable<Texture> PlayerTextureAsync => playerTextureAsyncSubject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadTexture());
    }

    private IEnumerator loadTexture()
    {
        var resource = Resources.LoadAsync<Texture>("Textures/player");

        yield return resource;

        //読み込み終了時に結果を通知
        playerTextureAsyncSubject.OnNext(resource.asset as Texture);
        playerTextureAsyncSubject.OnCompleted();
    }
}
