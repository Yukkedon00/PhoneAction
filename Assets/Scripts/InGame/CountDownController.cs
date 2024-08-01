using System.Collections;
using TMPro;
using R3;
using UnityEngine;

public class CountDownController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;

    private float currentTimer;

    private Subject<Unit> onEndTimerSubject = new Subject<Unit>();
    public Observable<Unit> OnEndTImerAsObservable => onEndTimerSubject;
    
    public IEnumerator CountDownCoroutine()
    {
        countDownText.text = InGameConst.CountDownTimer3;
        yield return new WaitForSeconds(1.0f);
        countDownText.text = InGameConst.CountDownTimer2;
        yield return new WaitForSeconds(1.0f);
        countDownText.text = InGameConst.CountDownTimer1;
        yield return new WaitForSeconds(1.0f);
        countDownText.text = InGameConst.CountDownTimerGo;
        yield return new WaitForSeconds(1.0f);
        onEndTimerSubject.OnNext(Unit.Default);
        countDownText.gameObject.SetActive(false);
    }
    
}
