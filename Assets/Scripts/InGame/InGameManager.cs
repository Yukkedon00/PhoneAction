using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private BodyController bodyController;


    private void Awake()
    {
        bodyController.IsDeadPlayer.Subscribe(x =>
        {
            if (x) 
            {
                SceneManager.LoadScene("Home");
            }
        }).AddTo(this);
    }
}
