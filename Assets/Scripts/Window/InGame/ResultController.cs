using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Subject<Unit> onStartResultAnimationSubject = new Subject<Unit>();
    public Observable<Unit> OnStartResultAnimation => onStartResultAnimationSubject;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
}
