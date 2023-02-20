using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class JumpEnemyMovement : IEnemyMovementStrategy
{
    public void Move(Transform enemyTransform, Transform playerTransform, float speed)
    {

        Vector3 pointB = new Vector3(enemyTransform.position.x, enemyTransform.position.y + 5f, enemyTransform.position.z);
        RaycastHit hit;
        float raycastDistance = 1.1f;
        Debug.DrawRay(enemyTransform.position, Vector3.down);
        if (Physics.Raycast(enemyTransform.position, Vector3.down, out hit, raycastDistance))
        {
            enemyTransform.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 0);
            enemyTransform.position = Vector3.Lerp(enemyTransform.position, pointB, 1);
        }
    }
}
