using R3;
using UnityEngine;

public class BodyController : MonoBehaviour
{

    public readonly ReactiveProperty<bool> IsDeadPlayer = new ReactiveProperty<bool>(false);

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ball")
        {
            IsDeadPlayer.Value = true;
        }
    }
}
