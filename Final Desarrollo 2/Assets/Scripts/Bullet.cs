using UnityEngine;

public class Bullet : MonoBehaviour
{
 
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
