using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;

public class TimerSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThread)
            .Subscribe(x => Debug.Log("1秒後に実行されたUpdate()と同じタイミング"))
            .AddTo(this);

        //指定なしの場合はMainThreadSchdularと同様 = Scheduler.MainThreadを指定したときと同様 = 1秒後に実行されたUpdate()と同じタイミング
        Observable.Timer(TimeSpan.FromSeconds(1))
            .Subscribe(x => Debug.Log("1秒後に実行されたScheduler.MainThreadを指定したときと同じタイミング"))
            .AddTo(this);

        //MainThreadEndOfFrameの場合は yield WaitForEndOfFrame(edn of frame)の時 = レンダリング終了後
        Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThreadEndOfFrame)
            .Subscribe(x => Debug.Log("1秒後のレンダリング終了後と同じタイミング"))
            .AddTo(this);

        //main thread以外でAddTo関数で指定したcomponentのgameObjectは取得でないため、エラー吐く
        new Thread(() =>
        {
            //現在のスレッドで処理を実行する
            //つまり、新しく作ったスレッド上でタイマーのカウントを実行
            Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.CurrentThread)
                .Subscribe(x => Debug.Log(x))
                .AddTo(this);
        }).Start();

    }
}
