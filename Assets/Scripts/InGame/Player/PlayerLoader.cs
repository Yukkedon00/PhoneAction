using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


public sealed class PlayerLoader : MonoBehaviour
{
    [SerializeField] private Transform parent;

    public async UniTask<GameObject> LoadPlayableCharacter(string loadAddress)
    {
        var obj = await Addressables.LoadAssetAsync<GameObject>(loadAddress);

        if (obj == null)
        {
            return null;
        }
        await InstantiateAsync(obj, parent);
        return obj;
    }
}
