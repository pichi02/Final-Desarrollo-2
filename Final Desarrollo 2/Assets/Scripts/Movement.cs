using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private GameObject tankBase;
    private GameObject tankBarrel;
    // Update is called once per frame
    private void Start()
    {
        tankBase = transform.GetChild(0).gameObject;
        tankBarrel = transform.GetChild(1).gameObject;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += tankBase.transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= tankBase.transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            tankBase.transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            tankBase.transform.Rotate(new Vector3(0, -20, 0) * Time.deltaTime);
        }
        else if (Input.GetMouseButton(0))
        {
            //tankBarrel.transform.rotation = Quaternion.Lerp(tankBarrel.transform.rotation, tankBase.transform.rotation, 5f * 0.001f);
            float rotationDiff = tankBase.transform.rotation.y - tankBarrel.transform.rotation.y;
            tankBarrel.transform.RotateAround(tankBase.transform.position, Vector3.up, rotationDiff * 10);
        }
    }
}
