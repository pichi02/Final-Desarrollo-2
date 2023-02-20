using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Countdown countdown;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        countdown.OnTimeChange += UpdateTimeText;
        countdown.OnTimeFinish += EnableGameOverPanel;
    }

    private void OnDestroy()
    {
        countdown.OnTimeChange -= UpdateTimeText;
        countdown.OnTimeFinish += EnableGameOverPanel;
    }
    private void UpdateTimeText(float time)
    {
        timeText.text = time.ToString();
    }

    private void EnableGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
