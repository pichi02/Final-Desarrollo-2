using UnityEngine;
namespace TankGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Tank tank;
        [SerializeField] private Countdown countdown;
        [SerializeField] private ShootBehaviour shootBehaviour;
        [SerializeField] private DataSaver dataSaver;
        [SerializeField] private Pauser pauser;
        private void Start()
        {
            tank.OnWin += countdown.DisableCanUpdateTime;
            tank.OnWin += shootBehaviour.DisableCanShoot;
            Enemy.OnTankKill += shootBehaviour.DisableCanShoot;
            tank.OnSaveData += dataSaver.SaveNewData;
            countdown.OnTimeFinish += tank.DisableCanMove;
            countdown.OnTimeFinish += shootBehaviour.DisableCanShoot;
            Bullet.OnEnemyKill += tank.IncreaseKilledEnemies;
            tank.OnNameEditFinish += pauser.EnableTimeScale;
        }
        private void OnDestroy()
        {
            tank.OnWin -= countdown.DisableCanUpdateTime;
            tank.OnWin -= shootBehaviour.DisableCanShoot;
            Enemy.OnTankKill -= shootBehaviour.DisableCanShoot;
            tank.OnSaveData -= dataSaver.SaveNewData;
            countdown.OnTimeFinish -= tank.DisableCanMove;
            countdown.OnTimeFinish -= shootBehaviour.DisableCanShoot;
            Bullet.OnEnemyKill -= tank.IncreaseKilledEnemies;
            tank.OnNameEditFinish -= pauser.EnableTimeScale;
        }
    }
}