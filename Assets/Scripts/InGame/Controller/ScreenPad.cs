using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public sealed class ScreenPad : MonoBehaviour
{
    [SerializeField] private Button actionButton;
    [SerializeField] private GameObject basePosition;
    [SerializeField] private GameObject circlePoint;
    float radius;
    Vector2 stickPos;
    Vector2 inputDt;
    Vector2 dir;
    private Vector2 returnPoint;

    public Vector2 InputDt => inputDt;

    public IObservable<Unit> OnClickActionButton => actionButton.OnClickAsObservable();

    private void Start()
    {
        radius = circlePoint.GetComponent<RectTransform>().sizeDelta.x / 2;
        returnPoint = basePosition.GetComponent<RectTransform>().position;
    }

    public void OnDragScreenPad()
    {
        circlePoint.transform.position = Input.mousePosition;
        stickPos = Input.mousePosition;

        // 絶対値に変換してから半径より大きい場合に1にして　1未満であれば今いる場所から見て割合を求める
        if (Mathf.Abs(circlePoint.transform.position.x - returnPoint.x) < radius)
        {
            inputDt.x = (stickPos.x - returnPoint.x) / radius;
        }
        else
        {
            inputDt.x = Mathf.Abs(stickPos.x - returnPoint.x) / (stickPos.x - returnPoint.x);
        }

        if (Mathf.Abs(circlePoint.transform.position.y - returnPoint.y) < radius)
        {
            inputDt.y = (stickPos.y - returnPoint.y) / radius;
        }
        else
        {
            inputDt.y = Mathf.Abs(stickPos.y - returnPoint.y) / (stickPos.y - returnPoint.y);
        }


        //JoyStick の座標を決めるコード
        if (Vector2.Distance(returnPoint, stickPos) < radius)    //stickPos がFrame内に位置していたら
        {
            circlePoint.transform.position = returnPoint + inputDt * radius;    //JoyStickの座標はマウスの位置
        }
        else           //stickPos がFrameの外にはみ出していたら
        {
            dir = stickPos - returnPoint;     //中心から見たstickPosの方向を dir に代入
                                                 //JoyStickの座標は dir の方向にradius 分だけ進んだ位置
            circlePoint.transform.position = returnPoint + dir / Vector2.Distance(returnPoint, stickPos) * radius;
        }

    }

    public void ReleaseStick()
    {
        inputDt = new Vector2 (0, 0);
        circlePoint.transform.position = new Vector3(returnPoint.x, returnPoint.y, 0.0f);      //座標を startPos に戻す
    }
}