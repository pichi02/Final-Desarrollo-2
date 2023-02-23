using UnityEngine;
using UnityEngine.UI;
using System;
namespace TankGame
{
    public class UIAudio : MonoBehaviour
    {
        public Action<float> OnChangeMuteToggle;
        bool isMuted;
        [SerializeField] Toggle mute;
        private void Start()
        {
            float volume = PlayerPrefs.GetFloat("volume");
            mute.isOn = volume == 0;

        }

        public void SetIsMuted()
        {
            if (mute.isOn)
            {
                isMuted = true;
                Debug.Log(isMuted);
                OnChangeMuteToggle.Invoke(0f);
            }
            else
            {
                isMuted = false;
                Debug.Log(isMuted);
                OnChangeMuteToggle.Invoke(1f);
            }
        }
        public bool GetIsMuted()
        {
            return isMuted;
        }

    }
}