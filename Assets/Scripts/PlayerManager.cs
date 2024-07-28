using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public readonly string PlayableAddress = "PRB_unitychan";

    public int MaxBreakBall = 0;

    public int Count = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int CurrentMaxBreakBall()
    {
        if (MaxBreakBall < Count)
        {
            MaxBreakBall = Count;
            Count = 0;
        }

        return MaxBreakBall;
    }

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
