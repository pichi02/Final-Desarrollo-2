using UnityEngine.SceneManagement;
using UnityEngine;

namespace TankGame
{
    public class SceneLoader : MonoBehaviour
    {

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}