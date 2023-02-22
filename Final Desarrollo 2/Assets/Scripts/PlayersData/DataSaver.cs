using UnityEngine;

namespace TankGame
{
    public class DataSaver : MonoBehaviour
    {
        private GameOverData data;
        private const string pathName = "Data";
        private const string fileName = "data";

        public void SaveNewData(float lastTime, string newName, int killedEnemies)
        {

            var dataFound = SaveLoadPlayersDataSystem.LoadData<GameOverData>(pathName, fileName);
            if (dataFound != null)
            {
                data = dataFound;
                SetNewData(lastTime, newName, killedEnemies);
            }
            else
            {
                data = new GameOverData()
                {
                    bestPlayerName = newName,
                    secondBestPlayerName = "empty",
                    thirdBestPlayerName = "empty",
                    bestPlayerScore = lastTime,
                    thirdBestPlayerScore = 50,
                    secondBestPlayerScore = 50,
                    lastGameTime = lastTime,
                    lastGameKilledEnemies = killedEnemies,

                };

            }
            SaveData();
        }
        private void SaveData()
        {
            SaveLoadPlayersDataSystem.SaveData(data, pathName, fileName);
        }

        private void SetNewData(float lastGameTime, string newName, int killedEnemies)
        {
            data.lastGameKilledEnemies = killedEnemies;
            data.lastGameTime = lastGameTime;
            if (lastGameTime < data.bestPlayerScore)
            {
                data.thirdBestPlayerScore = data.secondBestPlayerScore;
                data.thirdBestPlayerName = data.secondBestPlayerName;
                data.secondBestPlayerScore = data.bestPlayerScore;
                data.secondBestPlayerName = data.bestPlayerName;
                data.bestPlayerScore = lastGameTime;
                data.bestPlayerName = newName;

            }
            else if (lastGameTime < data.secondBestPlayerScore)
            {
                data.thirdBestPlayerScore = data.secondBestPlayerScore;
                data.thirdBestPlayerName = data.secondBestPlayerName;
                data.secondBestPlayerScore = lastGameTime;
                data.secondBestPlayerName = newName;
            }
            else if (lastGameTime < data.thirdBestPlayerScore)
            {
                data.thirdBestPlayerScore = lastGameTime;
                data.thirdBestPlayerName = newName;
            }
        }
    }
}