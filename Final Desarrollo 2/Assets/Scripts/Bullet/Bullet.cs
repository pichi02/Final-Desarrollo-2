using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
