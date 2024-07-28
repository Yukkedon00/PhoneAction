using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerParentTrasnform;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void PositionUpdate()
    {
        this.gameObject.transform.position = playerParentTrasnform.transform.position - (Vector3.back * -10 + Vector3.down * 4);
    }
}
