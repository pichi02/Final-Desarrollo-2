using UnityEngine;

namespace TankGame
{
    public class Enemy : MonoBehaviour
    {

        protected float speed;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private EnemyScriptableObject enemyScriptableObject;
        [SerializeField] private AudioSource explosionSfx;
        private IEnemyMovementStrategy movementStrategy;
        Vector3 firstPos;
        public static System.Action OnTankKill;

        private void Start()
        {
            firstPos = transform.position;
            speed = enemyScriptableObject.Speed;
            int random = Random.Range(0, 2);
            if (random == 0)
                movementStrategy = new JumpEnemyMovement();
            else
                movementStrategy = new ChasePlayerEnemyMovement();

        }

        private void Update()
        {
            if (movementStrategy != null)
            {
                movementStrategy.Move(transform, playerTransform, speed, firstPos);
            }
        }
        private void OnCollisionEnter(Collision col)
        {
            if (col.transform.CompareTag("Player"))
            {
                OnTankKill?.Invoke();
                Debug.Log("murio el jugador");
            }
            else if (col.transform.CompareTag("Bullet"))
            {
                explosionSfx.Play();
                Destroy(gameObject);
            }
        }

    }
}