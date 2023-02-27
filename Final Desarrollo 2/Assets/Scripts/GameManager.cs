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
            countdown.OnTimeFinish += tank.SaveData;
            tank.OnWin += countdown.DisableCanUpdateTime;
            tank.OnWin += shootBehaviour.DisableCanShoot;
            Enemy.OnTankKill += tank.SaveData;
            Enemy.OnTankKill += shootBehaviour.DisableCanShoot;
            tank.OnSaveData += dataSaver.SaveNewData;
            countdown.OnTimeFinish += tank.DisableCanMove;
            countdown.OnTimeFinish += shootBehaviour.DisableCanShoot;
            Bullet.OnEnemyKill += tank.IncreaseKilledEnemies;
            tank.OnNameEditFinish += pauser.EnableTimeScale;
        }
        private void OnDestroy()
        {
            countdown.OnTimeFinish -= tank.SaveData;
            tank.OnWin -= countdown.DisableCanUpdateTime;
            tank.OnWin -= shootBehaviour.DisableCanShoot;
            Enemy.OnTankKill -= tank.SaveData;
            Enemy.OnTankKill -= shootBehaviour.DisableCanShoot;
            tank.OnSaveData -= dataSaver.SaveNewData;
            countdown.OnTimeFinish -= tank.DisableCanMove;
            countdown.OnTimeFinish -= shootBehaviour.DisableCanShoot;
            Bullet.OnEnemyKill -= tank.IncreaseKilledEnemies;
            tank.OnNameEditFinish -= pauser.EnableTimeScale;
        }
    }
}