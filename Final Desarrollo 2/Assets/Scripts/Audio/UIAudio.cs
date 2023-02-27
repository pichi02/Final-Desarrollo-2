using UnityEngine;
using UnityEngine.UI;
using System;
namespace TankGame
{
    public class UIAudio : MonoBehaviour
    {
        public Action<float> OnChangeMuteToggle;
        bool isMuted;
        float volume;
        [SerializeField] Toggle mute;
        private void Start()
        {

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
        public void SetVolume(float volume)
        {
            this.volume = volume;
        }



    }
}