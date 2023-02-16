using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Transform playerTransform;

    private IEnemyMovementStrategy movementStrategy;
    private void Awake()
    {
        movementStrategy = new ChasePlayerEnemyMovement();
    }
    public void SetMovementStrategy(IEnemyMovementStrategy strategy)
    {
        movementStrategy = strategy;
    }

    private void Update()
    {
        if (movementStrategy != null)
        {
            movementStrategy.Move(transform, playerTransform, movementSpeed);
        }
    }
}
