using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace InputSystem
{
    public class KeyboadInput : MonoBehaviour
    {


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var current = Keyboard.current;

            if (current == null)
            {
                return;
            }


        }
    }
}