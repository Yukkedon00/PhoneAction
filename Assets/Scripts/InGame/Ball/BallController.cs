using System;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    private const float offsetRadius = 5.0f;
    private float speed = 1.0f;
    private Vector3 toPosition = Vector3.zero;

    private Subject<Unit> onBreakBallSubject = new Subject<Unit>();
    public Observable<Unit> OnBreakBall => onBreakBallSubject;

    public void Initialize(Transform player)
    {
        toPosition = player.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, toPosition, speed * Time.deltaTime);
    }

    public void SpeedUp()
    {
        speed *= 1.5f;
    }

    private void ResetPosition()
    {
        var angle = Random.Range(0,360);
        var rad = angle * Mathf.Deg2Rad;  
        var px = Mathf.Cos(rad) * offsetRadius;
        var pz = Mathf.Sin(rad) * offsetRadius;
        transform.position = new Vector3(px, 1.3f, pz);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Face")
        {
            ResetPosition();
            onBreakBallSubject.OnNext(Unit.Default);
            PlayerManager.instance.Count++;
        }
    }
}
