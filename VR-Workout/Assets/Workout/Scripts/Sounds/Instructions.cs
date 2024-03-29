using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public AudioSource audioSource;

    public VoicelineClip[] audioClips;
    [System.Serializable]
    public class VoicelineClip
    {
        public Voiceline voiceline;
        public AudioClip audioClip;
    }

    //enum to define different types of voicelines
    public enum Voiceline{
        StoryIntroduction,
        ChoppingEvent,
        BlockEvent,
        StoryFinish,
        StoryNotComplete,
        Breathing,
        Introduction,
        MeditationEnd,
        CoolDown,
    }

    //play a voiceline associated with a specific Voiceline enum
    public void PlayVoiceline(Voiceline voiceline)
    {
        foreach(VoicelineClip voicelineClip in audioClips)
        {
            if(voiceline == voicelineClip.voiceline)
            {
                audioSource.PlayOneShot(voicelineClip.audioClip);
            }
        }
    }

    //get the length of a voiceline associated with a specific Voiceline enum
    public float GetVoicelineLength(Voiceline voiceline)
    {
        foreach(VoicelineClip voicelineClip in audioClips)
        {
            if(voiceline == voicelineClip.voiceline)
            {
                return voicelineClip.audioClip.length;
            }
        }
        return 0;
    }
}
