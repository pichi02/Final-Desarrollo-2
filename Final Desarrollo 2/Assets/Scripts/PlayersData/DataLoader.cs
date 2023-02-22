using TMPro;
using UnityEngine;

namespace TankGame
{
    public class DataLoader : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bestPlayerName;
        [SerializeField] private TextMeshProUGUI secondBestPlayerName;
        [SerializeField] private TextMeshProUGUI thirdBestPlayerName;
        [SerializeField] private TextMeshProUGUI bestPlayerScore;
        [SerializeField] private TextMeshProUGUI secondBestPlayerScore;
        [SerializeField] private TextMeshProUGUI thirdBestPlayerScore;
        [SerializeField] private TextMeshProUGUI lastGameTime;
        [SerializeField] private TextMeshProUGUI lastGameKilledEnemies;

        private GameOverData data;

        private const string pathName = "Data";
        private const string fileName = "data";

        private void Start()
        {
            data = SaveLoadPlayersDataSystem.LoadData<GameOverData>(pathName, fileName);
            GiveDataToUI();
        }

        private void GiveDataToUI()
        {
            bestPlayerName.text = "1." + data.bestPlayerName;
            secondBestPlayerName.text = "2." + data.secondBestPlayerName;
            thirdBestPlayerName.text = "3." + data.thirdBestPlayerName;
            bestPlayerScore.text = data.bestPlayerScore.ToString();
            secondBestPlayerScore.text = data.secondBestPlayerScore.ToString();
            thirdBestPlayerScore.text = data.thirdBestPlayerScore.ToString();
            lastGameTime.text = "Time: " + data.lastGameTime.ToString();
            lastGameKilledEnemies.text = "Killed enemies: " + data.lastGameKilledEnemies.ToString();
        }
    }
}