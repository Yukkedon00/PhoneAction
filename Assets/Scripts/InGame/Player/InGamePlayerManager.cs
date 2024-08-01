using Cysharp.Threading.Tasks;
using System;
using InGame.Player.Actions;
using InGame.Player.Model;
using R3;
using UnityEngine;

public class InGamePlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerLoader playerLoader;
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private CountDownController countDownController;

    private PlayerEntity _playerEntity;

    private Subject<GameObject> ready = new Subject<GameObject>();
    public Observable<GameObject> readyObservable => ready;
    
    bool isCompleteLoad = false;
    

    private void Awake()
    {
        countDownController.OnEndTImerAsObservable.Subscribe
            (_ =>
            {
                isCompleteLoad = true;
                playerMover.SetCanAction();
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
