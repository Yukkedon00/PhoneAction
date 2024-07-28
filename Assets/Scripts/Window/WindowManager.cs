using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

using System.Linq;

public class WindowManager : MonoSingleton<WindowManager>
{
    public Stack<WindowBase> OpenedWindows { get;  set; } = new();
    [SerializeField] private Transform _canvasParent;


    public override void OnInitialize()
    {
        base.OnInitialize();
    }

    public override void OnFinalize()
    {
        base.OnFinalize();
    }

    public void OpenWindow(WindowConstrast.WindowIndex index)
    {
        var isConcat = OpenedWindows.Where(x => x.index == index);

        if (isConcat != null)
        {

            Addressables.LoadAssetAsync<GameObject>("PRF_ItemList")
                .Completed += op =>
                {
                    Instantiate(op.Result, _canvasParent);
                    OpenedWindows.Push(op.Result.GetComponent<WindowBase>());
                };
            
        }
    }

    public void RemoveLastWindow()
    {
        if (OpenedWindows.Count > 1)
        {
            return;
        }
        OpenedWindows.Pop().Close();
    }


}
