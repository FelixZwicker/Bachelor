using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meditation : MonoBehaviour
{
    public Instructions instructions;
    public GameObject breathingCanvas;
    public GameObject continueButton;

    private float mountainViewTime = 5f;

    private void Start()
    {
        instructions.PlayVoiceline(Instructions.Voiceline.Introduction);
        StartCoroutine(StartingPause());
    }

    IEnumerator StartingPause()
    {
        yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.Introduction) + mountainViewTime);
        BreathingExercise();
    }

    private void BreathingExercise()
    {
        breathingCanvas.SetActive(true);
        instructions.PlayVoiceline(Instructions.Voiceline.Breathing);
        StartCoroutine(WaitForBreathingExercise());
    }

    IEnumerator WaitForBreathingExercise()
    {
        yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.Breathing));
        breathingCanvas.SetActive(false);
        instructions.PlayVoiceline(Instructions.Voiceline.MeditationEnd);
        continueButton.SetActive(true);
    }
}
