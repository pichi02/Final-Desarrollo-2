using TMPro;
using UnityEngine;

namespace TankGame
{
    public class DataLoader : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bestPlayerName;
        [SerializeField] private TextMeshProUGUI secondBestPlayerName;
        [SerializeField] private TextMeshProUGUI thirdBestPlayerName;
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
            bestPlayerName.text = "1. " + data.bestPlayerName + ":  " + data.bestPlayerScore + " seconds";
            secondBestPlayerName.text = "2. " + data.secondBestPlayerName + ":  " + data.secondBestPlayerScore + " seconds";
            thirdBestPlayerName.text = "3. " + data.thirdBestPlayerName + ":  " + data.thirdBestPlayerScore + " seconds";
            lastGameTime.text = "Time: " + data.lastGameTime.ToString();
            lastGameKilledEnemies.text = "Killed enemies: " + data.lastGameKilledEnemies.ToString();
        }
    }
}