using System;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace InGame.Player.Actions
{
    public class RollingAction : IAction
    {
        private const float speed = 5f;

        private const float baseRadius = 3f;
        private const float maxLoopCount = 4;
        private const float oneLoop = 2 * Mathf.PI;
        
        public async UniTask PlayAction(Transform baseTransform)
        {
            var basePos = baseTransform.position;
            var position = baseTransform.position;
            var phase = 0.0f;

            var radius = 0.0f;
            var maxCount = oneLoop * maxLoopCount;
            
            //for (float i = 0; i < 3; i += Time.deltaTime)

            await UniTask.WaitWhile(RollingCalc);

            baseTransform.position = basePos;

            bool RollingCalc()
            {
                // OriginalPosに戻る
                if (phase > oneLoop * (maxLoopCount - 1))
                {
                    radius = baseRadius * maxCount % phase / oneLoop;
                }
                // Baseの半径まで広げる
                else if (phase < oneLoop)
                {
                    radius = baseRadius * (phase / oneLoop);
                }
                
                var rotationPos = new Vector3(position.x + radius * Mathf.Cos(phase), position.y, position.z + radius * Mathf.Sin(phase));
                baseTransform.position = rotationPos;

                phase += speed * Time.deltaTime * Mathf.PI;

                return phase < maxCount;
            }
        }

        private Vector3 calcRollingPos()
        {
            return Vector3.zero;
        }
    }
}