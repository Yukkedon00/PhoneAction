using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using InGame.Player.Actions;
using InGame.Player.Model;
using UniRx;
using UnityEngine;

public class InGamePlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerLoader playerLoader;
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private CountDownController countDownController;

    private PlayerEntity _playerEntity;

    private Subject<GameObject> ready = new Subject<GameObject>();
    public IObservable<GameObject> readyObservable => ready;

    bool isCompleteLoad = false;
    

    private void Awake()
    {
        countDownController.OnEndTImerAsObservable.Subscribe
            (_ =>
            {
                isCompleteLoad = true;
            });

        _playerEntity = new PlayerEntity(new Vector3(0, 0, 0), new RollingAction());
    }

    private void Start()
    {
        LoadGameObjects().Forget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCompleteLoad )
        {
            return;
        }

        playerMover.MoveUpdate();
    }


    private async UniTask LoadGameObjects()
    {
        var isLoadComplete = await playerLoader.LoadPlayableCharacter(PlayerManager.instance.PlayableAddress);

        if (isLoadComplete)
        {
            ready.OnNext(isLoadComplete);
        }

        StartCoroutine(countDownController.CountDownCoroutine());
    }
}
