using UnityEngine;
using System;

namespace TankGame
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionParticle;
        public static Action OnEnemyKill;
        private void Start()
        {
            Destroy(gameObject, 3f);
        }
        void OnCollisionEnter(Collision col)
        {
            if (col.transform.CompareTag("Enemy"))
            {
                ParticleSystem explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity);
                explosion.Play();
                OnEnemyKill?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
