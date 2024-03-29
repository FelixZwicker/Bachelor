using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownManager : MonoBehaviour
{
    public Instructions instructions;
    public GameObject continueButton;

    private float extraTime = 5f;

    void Start()
    {
        instructions.PlayVoiceline(Instructions.Voiceline.CoolDown);
        StartCoroutine(WaitForVoicline());
    }

    IEnumerator WaitForVoicline()
    {
        yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.CoolDown) + extraTime);
        continueButton.SetActive(true);
    }
}
