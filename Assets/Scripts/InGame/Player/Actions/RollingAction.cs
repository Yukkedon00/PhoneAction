using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace InGame.Player.Actions
{
    public class RollingAction : IAction
    {
        private const int length = 1;
        private const float speed = 10f;

        private const float oneLoop = 360.0f;
        
        public async UniTask PlayAction(Transform baseTransform)
        {
            var basePos = baseTransform.position;
            var position = baseTransform.position;
            var rad = 0.0f;
            
            //for (float i = 0; i < 3; i += Time.deltaTime)
            while (rad < oneLoop)
            {
                var rotationPos = new Vector3(position.x + length * Mathf.Cos(rad * speed), position.y, position.z + length * Mathf.Sin(rad * speed));
                Debug.Log(rad);
                baseTransform.position = rotationPos;

                await UniTask.DelayFrame(1);
                rad += speed * Time.deltaTime;
            }

            baseTransform.position = basePos;
        }

        private Vector3 calcRollingPos()
        {
            return Vector3.zero;
        }
    }
}