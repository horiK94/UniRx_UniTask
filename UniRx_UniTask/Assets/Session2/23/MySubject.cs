using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MySubject<T> : ISubject<T>, IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    public bool isStopped { get; } = false;

    /// <summary>
    /// 解除済みか
    /// </summary>
    public bool isDisposed { get; } = false;

    private readonly object lockObject = new object();

    /// <summary>
    /// 発生したエラー
    /// </summary>
    private Exception error;

    /// <summary>
    /// 購読リスト
    /// </summary>
    private List<IObserver<T>> observers;

    public MySubject()
    {
        //購読リストのインスタンス作成
        observers = new List<IObserver<T>>();
    }

    public void OnNext(T value)
    {
        if (isStopped) return;

        //lock とは?　→ 排他的制御
        //先にlockした処理が終わるまで次にlockした処理は待たれる
        /*
        // 排他制御に使用するオブジェクト
        private Object lockObject = new Object();

         private void Start()
         {
            // func1の処理を行うスレッドを生成し、処理を開始します。
            var thread1 = new Thread(new ThreadStart(program.func1));
            thread1.Start();

            // func2の処理を行うスレッドを生成し、処理を開始します。
            var thread2 = new Thread(new ThreadStart(program.func2));
            thread2.Start();
        }

        private void func1()
        {
            lock(lockObject)
            {
                //先にlockした処理(func1)が終わるまで次にlockした処理(func2)は待たれる
            }
        }

        private void func2()
        {
            lock(lockObject)
            {
                //先にlockした処理(func1)が終わるまで次にlockした処理(func2)は待たれる
            }
        }
         */
        lock (observers)
        {
            //破棄しているものに対しOnNext()を呼んだときにエラーを投げる
            ThrowIfDisposed();

            //自身を購読中の全員に送る
            foreach (var observer in observers)
            {
                observer.OnNext(value);
            }
        }
    }

    public void Dispose()
    {
        lock (lockObject)
        {
            if (isDisposed) return;

            observers.Clear();
            observers = null;
            error = null;
        }
    }

    public void OnError(Exception error)
    {
        lock (lockObject)
        {
            //破棄しているものに対しOnError()を呼んだときにエラーを投げる
            ThrowIfDisposed();

            if (isStopped) return;

            this.error = error;

            try
            {
                foreach (var observer in observers)
                {
                    observer.OnError(error);
                }
            }
            catch (Exception e)
            {
                //Exceptionのエラーが発生したときに行う文
            }
            finally
            {
                //  例外が発生するしないに関わらず実行する文;
                Dispose();
            }
        }
    }

    public void OnCompleted()
    {
        lock (lockObject)
        {
            ThrowIfDisposed();

            if (isStopped) return;

            try
            {
                foreach (var observer in observers)
                {
                    observer.OnCompleted();
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                Dispose();
            }
        }
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
        lock (lockObject)
        {
            if (isStopped)
            {
                if (this.error != null)
                {
                    observer.OnError(this.error);
                }
                else
                {
                    observer.OnCompleted();
                }

                return Disposable.Empty;
            }
            
            observers.Add(observer);
            return new Subscription(this, observer);
        }
    }

    //破棄したものを投げたとき
    private void ThrowIfDisposed()
    {
        if (isDisposed)
        {
            //ObjectDisposedException: 破棄されたオブジェクトで操作が実行されるとスローされる例外
            throw new ObjectDisposedException(nameof(MySubject<T>));
        }
    }

    private sealed class Subscription : IDisposable
    {
        private readonly IObserver<T> observer;
        private readonly MySubject<T> mySubject;

        public Subscription(MySubject<T> parent, IObserver<T> observer)
        {
            this.mySubject = parent;
            this.observer = observer;
        }

        /// <summary>
        /// 解約
        /// </summary>
        public void Dispose()
        {
            mySubject.observers.Remove(observer);
        }
    }
}
