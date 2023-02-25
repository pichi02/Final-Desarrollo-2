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
        private void Awake()
        {
            uiAudio = GetComponent<UIAudio>();
            playerPrefs = GetComponent<AudioPlayerPrefs>();
            sourcesManager = GetComponent<AudioSourcesManager>();
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