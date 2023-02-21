using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Tank tank;
    [SerializeField] private Countdown countdown;
    [SerializeField] private ShootBehaviour shootBehaviour;
    [SerializeField] private DataSaver dataSaver;

    private void Start()
    {
        tank.OnSaveData += dataSaver.SaveNewData;
        countdown.OnTimeFinish += tank.DisableCanMove;
        countdown.OnTimeFinish += shootBehaviour.DisableCanShoot;
        Bullet.OnEnemyKill += tank.IncreaseKilledEnemies;
    }
    private void OnDestroy()
    {
        tank.OnSaveData -= dataSaver.SaveNewData;
        countdown.OnTimeFinish -= tank.DisableCanMove;
        countdown.OnTimeFinish -= shootBehaviour.DisableCanShoot;
        Bullet.OnEnemyKill -= tank.IncreaseKilledEnemies;
    }
}
