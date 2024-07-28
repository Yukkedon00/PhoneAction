using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSky : MonoBehaviour
{
    private const float oneRotation = 360.0f;
    private float anglePerFrame = 0.004f;
    private float rot;



    // Update is called once per frame
    void Update()
    {
        rot += anglePerFrame;
        if (rot >= oneRotation)
        {
            rot -= oneRotation;
        }

        RenderSettings.skybox.SetFloat("_Rotation", rot);
    }
}
