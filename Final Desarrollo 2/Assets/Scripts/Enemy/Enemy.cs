using UnityEngine;

namespace TankGame
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private Transform playerTransform;

        private IEnemyMovementStrategy movementStrategy;
        private void Awake()
        {
            int random = Random.Range(0, 2);
            if (random == 0)
                movementStrategy = new JumpEnemyMovement();
            else
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
}