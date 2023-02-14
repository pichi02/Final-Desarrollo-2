using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 10f;
    float horizontal;
    float vertical;


    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (vertical == 0)
            horizontal = Input.GetAxis("Horizontal");

        if (horizontal == 0)
            vertical = Input.GetAxis("Vertical");

        Debug.Log(vertical);
        transform.position += transform.forward * vertical * speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * horizontal * Time.deltaTime, Vector3.up);
    }
}

