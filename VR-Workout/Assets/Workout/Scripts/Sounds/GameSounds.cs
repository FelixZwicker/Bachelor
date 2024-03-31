using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameSounds : MonoBehaviour
{
    // Singleton instance of the GameSounds class
    private static GameSounds _i;

    // Property to access the singleton instance
    public static GameSounds i
    {
        get
        {
            if (_i == null)
            {
                _i = (Instantiate(Resources.Load("GameSounds")) as GameObject).GetComponent<GameSounds>();
            }
            return _i;
        }
    }

    public AudioMixerGroup mixer;
    public SoundAudioClip[] soundAudioClipArray;

    // Serializable class representing a sound and its associated audio clip
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
