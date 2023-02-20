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
        movementStrategy = new JumpEnemyMovement();
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
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Debug.Log("murio el jugador");
        }
        else if (col.transform.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

}
