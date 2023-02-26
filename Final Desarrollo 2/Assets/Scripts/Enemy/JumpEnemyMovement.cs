
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace TankGame
{
    public class JumpEnemyMovement : IEnemyMovementStrategy
    {


        public void Move(Transform enemyTransform, Transform playerTransform, float speed, Vector3 firtPos)
        {
            Vector3 pointB = new Vector3(firtPos.x, firtPos.y + 5f * speed, firtPos.z);
            enemyTransform.position = Vector3.Lerp(firtPos, pointB, Mathf.PingPong(Time.time, 1));
        }

    }
}
