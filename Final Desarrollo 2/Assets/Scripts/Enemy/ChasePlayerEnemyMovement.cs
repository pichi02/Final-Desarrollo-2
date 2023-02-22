using UnityEngine;

namespace TankGame
{
    public class ChasePlayerEnemyMovement : IEnemyMovementStrategy
    {
        public void Move(Transform enemyTransform, Transform playerTransform, float speed)
        {
            Vector3 direction = (playerTransform.position - enemyTransform.position).normalized;
            enemyTransform.position += direction * speed * Time.deltaTime;
        }
    }
}