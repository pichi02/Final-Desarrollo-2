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
            float volume = PlayerPrefs.GetFloat("volume", 1f);
            if (volume == 0)
            {
                mute.isOn = true;
            }
            else
            {
                mute.isOn = false;
            }
        }

        public void SetIsMuted()
        {
            if (mute.isOn)
            {
                OnChangeMuteToggle.Invoke(0f);
                isMuted = true;
            }
            else
            {
                OnChangeMuteToggle.Invoke(1f);
                isMuted = false;
            }
        }
        public bool GetIsMuted()
        {
            return isMuted;
        }

    }
}