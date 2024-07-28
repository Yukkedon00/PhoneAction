using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using UniRx.Triggers;

using UnityEngine.SceneManagement;

public class HomeButtons : MonoBehaviour
{
    [SerializeField] private Button _battle;
    [SerializeField] private Button _gacha;
    [SerializeField] private Button _unit;

    [SerializeField] private LoadingScene _loadingScene;

    private void Awake()
    {
        this._battle.OnClickAsObservable()
            .Subscribe(_ =>
            {
                _loadingScene.LoadNextScene();
            }).AddTo(this);
        this._gacha.OnClickAsObservable()
            .Subscribe(_ =>
            {
                WindowManager.instance.OpenWindow(WindowConstrast.WindowIndex.Menu);
            }).AddTo(this);
        this._unit.OnClickAsObservable()
            .Subscribe(_ =>
            {

            }).AddTo(this);

    }
}
