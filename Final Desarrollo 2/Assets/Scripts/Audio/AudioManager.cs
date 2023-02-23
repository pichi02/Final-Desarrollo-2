using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private UIAudio uiAudio;
        [SerializeField] private AudioPlayerPrefs playerPrefs;
        [SerializeField] private AudioSourcesManager sourcesManager;
        private void Awake()
        {
            //uiAudio = GetComponent<UIAudio>();
            //playerPrefs = GetComponent<AudioPlayerPrefs>();
            //sourcesManager = GetComponent<AudioSourcesManager>();
        }
        void Start()
        {
            uiAudio.OnChangeMuteToggle += playerPrefs.SetAudioSettings;
            playerPrefs.OnSetAudioSettings += sourcesManager.SetSourcesVolume;
        }

        private void OnDestroy()
        {
            uiAudio.OnChangeMuteToggle -= playerPrefs.SetAudioSettings;
            playerPrefs.OnSetAudioSettings -= sourcesManager.SetSourcesVolume;
        }
    }
}