using UnityEngine;
using UnityEngine.UI;
using System;
namespace TankGame
{
    public class UIAudio : MonoBehaviour
    {
        public Action OnEnableMuteToggle;
        public Action OnDisableMuteToggle;
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
                OnEnableMuteToggle.Invoke();
                isMuted = true;
                Debug.Log(isMuted);
            }
            else
            {
                OnDisableMuteToggle.Invoke();
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