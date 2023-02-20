using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankMovement : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 10f;
    private float horizontal;
    private float vertical;
    private bool canMove = true;


    private void Update()
    {
        if (canMove)
        {
            Move();
        }
    }
    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.position += transform.forward * vertical * speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * horizontal * Time.deltaTime, Vector3.up);
    }

    public void DisableCanMove()
    {
        canMove = false;
    }
}

