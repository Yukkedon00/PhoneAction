using InGame.Player.Actions;
using UnityEngine;

namespace InGame.Player.Model
{
    public class PlayerEntity
    {
        public Vector3 OriginalPos { get; private set; }
        public Vector3 AddActionPos { get; private set; }

        public IAction Action;
        
        public PlayerEntity(Vector3 originalPos, IAction action)
        {
            OriginalPos = originalPos;
            Action = action;
        }

        public void AddPosition(Vector3 position)
        {
            OriginalPos += position;
        }
        
    }
}