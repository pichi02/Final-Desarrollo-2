using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TankGame
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI killedEnemiesText;
        [SerializeField] private Countdown countdown;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Tank tank;
        [SerializeField] private Pauser pauser;
        [SerializeField] private Button pauseButton;
        [SerializeField] private GameObject winPanel;

        private void Start()
        {
            Enemy.OnTankKill += EnableGameOverPanel;
            Enemy.OnTankKill += DisableGameplayUI;
            Enemy.OnTankKill += tank.DisableCanMove;
            countdown.OnTimeChange += UpdateTimeText;
            countdown.OnTimeFinish += EnableGameOverPanel;
            tank.OnWin += EnableWinPanel;
            tank.OnIncreaseKilledEnemies += UpdateKilledEnemiesText;
            tank.OnNameEditFinish += EnableGameplayUI;
            pauser.OnResume += EnableGameplayUI;
            pauser.OnPause += DisableGameplayUI;
        }

        private void OnDestroy()
        {
            Enemy.OnTankKill -= EnableGameOverPanel;
            Enemy.OnTankKill -= DisableGameplayUI;
            Enemy.OnTankKill -= tank.DisableCanMove;
            countdown.OnTimeChange -= UpdateTimeText;
            countdown.OnTimeFinish -= EnableGameOverPanel;
            tank.OnIncreaseKilledEnemies -= UpdateKilledEnemiesText;
            tank.OnWin -= EnableWinPanel;
            tank.OnNameEditFinish -= EnableGameplayUI;
            pauser.OnResume -= EnableGameplayUI;
            pauser.OnPause -= DisableGameplayUI;
        }
        private void UpdateTimeText(float time)
        {
            timeText.text = time.ToString();
        }
        private void UpdateKilledEnemiesText(int killedEnemies)
        {
            killedEnemiesText.text = killedEnemies.ToString();
        }

        private void EnableGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }
        private void EnableWinPanel()
        {
            winPanel.SetActive(true);
        }
        private void EnableGameplayUI()
        {
            timeText.gameObject.SetActive(true);
            killedEnemiesText.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(true);
        }
        private void DisableGameplayUI()
        {
            timeText.gameObject.SetActive(false);
            killedEnemiesText.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(false);
        }

    }
}