using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class AudioPlayerPrefs : MonoBehaviour
    {
        public Action <float>OnSetAudioSettings;

        public void SetAudioSettings(float volume)
        {
            PlayerPrefs.SetFloat("volume", volume);
            OnSetAudioSettings?.Invoke(volume);
        }
    }
}
