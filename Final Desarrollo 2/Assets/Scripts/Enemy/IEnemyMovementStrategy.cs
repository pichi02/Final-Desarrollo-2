using UnityEngine;

public interface IEnemyMovementStrategy
{
    void Move(Transform enemyTransform, Transform playerTransform, float speed);
}