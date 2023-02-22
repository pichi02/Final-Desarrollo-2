using UnityEngine.SceneManagement;
using UnityEngine;

namespace TankGame
{
    public class SceneLoader : MonoBehaviour
    {

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}