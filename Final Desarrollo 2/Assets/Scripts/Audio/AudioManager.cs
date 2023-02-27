using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class AudioManager : MonoBehaviour
    {
        private UIAudio uiAudio;
        private AudioPlayerPrefs playerPrefs;
        private AudioSourcesManager sourcesManager;
        [SerializeField] private AudioSource buttonSfx;
        private void Awake()
        {

            uiAudio = GetComponent<UIAudio>();
            playerPrefs = GetComponent<AudioPlayerPrefs>();
            sourcesManager = GetComponent<AudioSourcesManager>();
            uiAudio.OnChangeMuteToggle += playerPrefs.SetAudioSettings;
            playerPrefs.OnReturnAudioSettings += uiAudio.SetVolume;
            playerPrefs.OnSetAudioSettings += sourcesManager.SetSourcesVolume;
            playerPrefs.OnReturnAudioSettings += sourcesManager.SetSourcesVolume;
        }

        private void OnDestroy()
        {
            uiAudio.OnChangeMuteToggle -= playerPrefs.SetAudioSettings;
            playerPrefs.OnSetAudioSettings -= sourcesManager.SetSourcesVolume;
            playerPrefs.OnReturnAudioSettings -= uiAudio.SetVolume;
            playerPrefs.OnReturnAudioSettings -= sourcesManager.SetSourcesVolume;
        }
        public void PLayButtonSfx()
        {
            buttonSfx.Play();
        }
    }
}