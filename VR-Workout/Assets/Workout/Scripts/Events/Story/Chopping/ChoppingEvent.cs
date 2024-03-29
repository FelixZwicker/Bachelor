using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingEvent : EventHandling
{
    private GameObject axe;
    private Transform axePosition;

    private bool hasFinished = false;

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("ChoppingWood").Length == 0 && !hasFinished)
        {
            hasFinished = true;
            EndActivity();
        }
    }

    protected override void StartActivity()
    {
        axe = GameObject.Find("Axe");
        axePosition = axe.transform;
    }

    protected override void EndActivity()
    {
        ActivityOver(1);
        enabled = false;
    }

    protected override IEnumerator WaitForInstructions()
    {
        Destroy(triggerCollider);
        instructions.PlayVoiceline(Instructions.Voiceline.ChoppingEvent);
        yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.ChoppingEvent));
        StartActivity();
    }
}
