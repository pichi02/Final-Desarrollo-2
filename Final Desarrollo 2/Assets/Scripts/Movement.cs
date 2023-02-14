using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 10f;
    float horizontal;
    float vertical;


    private void Update()
    {
        Move();
    }
    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.position += transform.forward * vertical * speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * horizontal * Time.deltaTime, Vector3.up);
    }
}

