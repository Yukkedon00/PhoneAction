using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class HomeCharacter : MonoBehaviour
{
    [SerializeField] private Transform playerMarcker;
    
    // Start is called before the first frame update
    void Start()
    {
        Addressables.LoadAssetAsync<GameObject>(PlayerManager.instance.PlayableAddress)
            .Completed += ob => {
                Instantiate(ob.Result, playerMarcker);
            };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
