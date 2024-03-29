using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public Instructions instructions;
    public SwingingArmsMotion swingingArmsMotion;
    public GameObject continueButton;

    public int eventCounter = 0;

    private void Start()
    {
        instructions.PlayVoiceline(Instructions.Voiceline.StoryIntroduction);
        StartCoroutine(WaitForInstruction());
    }

    public void FinishedWorkout()
    {
        continueButton.SetActive(true);
    }

    IEnumerator WaitForInstruction()
    {
        yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.StoryIntroduction));
        swingingArmsMotion.enabled = true;
    }
}
