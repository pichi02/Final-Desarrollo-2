using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TankMovement tankMovement;
    [SerializeField] private Countdown countdown;
    [SerializeField] private ShootBehaviour shootBehaviour;

    private void Start()
    {
        countdown.OnTimeFinish += tankMovement.DisableCanMove;
        countdown.OnTimeFinish += shootBehaviour.DisableCanShoot;
        Bullet.OnEnemyKill += tankMovement.IncreaseKilledEnemies;
    }
    private void OnDestroy()
    {
        countdown.OnTimeFinish -= tankMovement.DisableCanMove;
        countdown.OnTimeFinish -= shootBehaviour.DisableCanShoot;
        Bullet.OnEnemyKill -= tankMovement.IncreaseKilledEnemies;
    }
}
