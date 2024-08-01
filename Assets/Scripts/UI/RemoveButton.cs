using UnityEngine;

using R3;
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
