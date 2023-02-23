using UnityEngine;
using UnityEngine.UI;
namespace TankGame
{
    public class UIAudio : MonoBehaviour
    {
        bool isMuted;
        Toggle mute;

        private void Awake()
        {
            mute = GetComponent<Toggle>();
        }
        private void Start()
        {
            isMuted = false;
        }

        public void SetIsMuted()
        {
            if (mute.isOn)
            {
                isMuted = true;
                Debug.Log(isMuted);
            }
            else
            {
                isMuted = false;
                Debug.Log(isMuted);
            }
        }
        public bool GetIsMuted()
        {
            return isMuted;
        }

    }
}