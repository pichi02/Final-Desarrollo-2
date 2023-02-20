using Unity.VisualScripting;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public static Action OnEnemyKill;
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            OnEnemyKill?.Invoke();
            Destroy(gameObject);
        }
    }
}
