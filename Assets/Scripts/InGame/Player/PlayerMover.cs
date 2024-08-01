using Cysharp.Threading.Tasks;
using InGame.Player.Actions;
using R3;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private ScreenPad screenPad;
    [SerializeField] private Transform moveParent;
    [SerializeField] private Transform cameraFocus;

    private const float defultSpeed = 5f;
    private bool canAction;

    private IAction _action = new RollingAction();

    private void Awake()
    {
        screenPad.OnClickActionButton
            .Where(_ => canAction)
            .Subscribe(_ =>
            {
                _action.PlayAction(moveParent).Forget();
            }).AddTo(this);
    }

    // Update is called once per frame
    public void MoveUpdate()
    {
        if (moveParent == null)
        {
            return;
        }
        moveParent.position += new Vector3(Time.deltaTime * defultSpeed * screenPad.InputDt.x, 0, Time.deltaTime * defultSpeed * screenPad.InputDt.y);
    }
    
    public void SetCanAction()
    {
        canAction = true;
    }
}
