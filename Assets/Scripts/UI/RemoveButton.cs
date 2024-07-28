using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx.Triggers;
using UniRx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RemoveButton : MonoBehaviour
{
    [SerializeField] private Button button;

    void Awake()
    {

        button.OnClickAsObservable()
            .Subscribe(_ =>
        {
            WindowManager.instance.RemoveLastWindow();
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
