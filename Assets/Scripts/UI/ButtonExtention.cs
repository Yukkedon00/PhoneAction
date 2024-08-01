using R3;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public static class ButtonExtention
    {
        static public void SetClickAction(this Button self, UnityEngine.Events.UnityAction _onAction)
        {
            self.OnClickAsObservable().Subscribe(_ => { _onAction.Invoke(); });
        }
    }
}
