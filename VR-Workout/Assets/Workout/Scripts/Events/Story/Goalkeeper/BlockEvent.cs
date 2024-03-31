using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEvent : EventHandling
{
    public BlockSpawner[] blockSpawners;
    public GameObject userInterface;
    public HitCounter hitCounter;

    private bool hasFinished = false;

    private void Update()
    {
        if (hitCounter.totalScore == 20 && !hasFinished)
        {
            hasFinished = true;
            EndActivity();
        }
    }

    // Method to start the block event activity
    protected override void StartActivity()
    {
        userInterface.SetActive(true);
        for(int i = 0; i < blockSpawners.Length; i++)
        {
            blockSpawners[i].enabled = true;
        }
    }

    // Method to end the block event activity
    protected override void EndActivity()
    {
        for (int i = 0; i < blockSpawners.Length; i++)
        {
            blockSpawners[i].enabled = false;
        }
        // Notify the base class that the activity is over
        ActivityOver(2);
        enabled = false;
    }

    // Coroutine to wait for instructions before starting the activity
    protected override IEnumerator WaitForInstructions()
    {
        Destroy(triggerCollider);
        instructions.PlayVoiceline(Instructions.Voiceline.BlockEvent);
        yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.BlockEvent));
        StartActivity();
    }
}
