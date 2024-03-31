using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meditation : MonoBehaviour
{
    public Instructions instructions;
    public GameObject breathingCanvas;
    public GameObject continueButton;

    private float mountainViewTime = 5f;
    private float breathingExtraTime = 2f;

    private void Start()
    {
        // Plays the introduction voice line and then starts the delay before the breathing exercise
        instructions.PlayVoiceline(Instructions.Voiceline.Introduction);
        StartCoroutine(StartingPause());
    }

    // Coroutine for the delay before the breathing exercise
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

    // Coroutine for waiting for the end of the breathing exercise
    IEnumerator WaitForBreathingExercise()
    {
        yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.Breathing) + breathingExtraTime);
        breathingCanvas.SetActive(false);
        instructions.PlayVoiceline(Instructions.Voiceline.MeditationEnd);
        continueButton.SetActive(true);
    }
}
