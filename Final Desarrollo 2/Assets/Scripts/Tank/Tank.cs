using System;
using UnityEngine;


public class Tank : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 10f;
    private float horizontal;
    private float vertical;
    private bool canMove = true;
    private int killedEnemies = 0;
    private const int enemies = 1;
    public Action<int> OnIncreaseKilledEnemies;
    public Action OnWin;
    public Action<float, string, int> OnSaveData;
    [SerializeField] private string name;
    private float time = 0f;

    private void Update()
    {
        time += Time.deltaTime;
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

    public void IncreaseKilledEnemies()
    {
        killedEnemies++;
        OnIncreaseKilledEnemies?.Invoke(killedEnemies);
        CheckWin();
    }
    private void CheckWin()
    {
        if (killedEnemies == enemies)
        {
            OnWin?.Invoke();
            OnSaveData(time, name, killedEnemies);
        }
    }
}

