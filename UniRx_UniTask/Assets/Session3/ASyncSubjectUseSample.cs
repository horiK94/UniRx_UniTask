using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ASyncSubjectUseSample : MonoBehaviour
{
    [SerializeField] private AsyncSubjectSample asyncSubjectSample;

    // Start is called before the first frame update
    void Start()
    {
        asyncSubjectSample.PlayerTextureAsync
                //AsyncSubjectはSubscrbe()のタイミングによらず、OnNext()を通知する
            .Subscribe(SetMyTexture)
            .AddTo(this);
    }

    void SetMyTexture(Texture newTexture)
    {
        var r = GetComponent<Renderer>();
        r.sharedMaterial.mainTexture = newTexture;
    }
}
