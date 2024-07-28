using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InGame.Player.Actions
{
    public interface IAction
    {
        UniTask PlayAction(Transform baseTransform);
    }
}