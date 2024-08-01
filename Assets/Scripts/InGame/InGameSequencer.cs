using UnityEngine;
using UnityEngine.SceneManagement;
using R3;

public class InGameSequencer : MonoBehaviour
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
