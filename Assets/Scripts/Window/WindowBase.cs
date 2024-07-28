using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WindowBase : MonoBehaviour
{
    public readonly WindowConstrast.WindowIndex index;

    public virtual void Open()
    {

    }

    public virtual void Close()
    {
        Destroy(gameObject);
    }


}
