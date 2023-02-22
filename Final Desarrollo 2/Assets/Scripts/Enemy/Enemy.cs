using UnityEngine;

namespace TankGame
{
    public class Enemy : MonoBehaviour
    {

        protected float speed;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private EnemyScriptableObject enemyScriptableObject;
        private IEnemyMovementStrategy movementStrategy;
        private void Start()
        {
            speed = enemyScriptableObject.Speed;
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
                movementStrategy.Move(transform, playerTransform, speed);
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