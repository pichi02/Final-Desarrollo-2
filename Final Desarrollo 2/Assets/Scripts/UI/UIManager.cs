using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI killedEnemiesText;
    [SerializeField] private Countdown countdown;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TankMovement tankMovement;

    private void Start()
    {
        countdown.OnTimeChange += UpdateTimeText;
        countdown.OnTimeFinish += EnableGameOverPanel;
        tankMovement.OnIncreaseKilledEnemies += UpdateKilledEnemiesText;
    }

    private void OnDestroy()
    {
        countdown.OnTimeChange -= UpdateTimeText;
        countdown.OnTimeFinish -= EnableGameOverPanel;
        tankMovement.OnIncreaseKilledEnemies -= UpdateKilledEnemiesText;
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

}
