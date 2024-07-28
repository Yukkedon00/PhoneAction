using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject ballObject;
    [SerializeField] private CountDownController countDownController;


    private const int maxCount = 10;
    private bool canCreateBall => ballList.Count != maxCount;
    private List<BallController> ballList = new List<BallController>();

    private IDisposable disposable;

    private int count = 0;
    private int borderCount = 10;

    private void Awake()
    {
        countDownController.OnEndTImerAsObservable.Subscribe(_ =>
        {
            AddCreateBall();
        }).AddTo(this);
    }

    private void AddCreateBall()
    {
        var instance = Instantiate(ballObject);
        var component = instance.GetComponent<BallController>();
        component.Initialize(playerTransform);
        ballList.Add(component);
    }

// Update is called once per frame
    void Update()
    {
        if (PlayerManager.instance.Count == borderCount)
        {
            borderCount += borderCount;
            AddCreateBall();
        }
    }
}
