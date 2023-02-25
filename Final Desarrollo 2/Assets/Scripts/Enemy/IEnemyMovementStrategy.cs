using UnityEngine;

namespace TankGame
{
    public interface IEnemyMovementStrategy
    {
        void Move(Transform enemyTransform, Transform playerTransform, float speed, Vector3 firtsPos = default);
    }
}