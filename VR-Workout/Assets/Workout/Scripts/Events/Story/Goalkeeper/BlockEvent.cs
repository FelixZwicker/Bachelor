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

    protected override void StartActivity()
    {
        userInterface.SetActive(true);
        for(int i = 0; i < blockSpawners.Length; i++)
        {
            blockSpawners[i].enabled = true;
        }
    }

    protected override void EndActivity()
    {
        for (int i = 0; i < blockSpawners.Length; i++)
        {
            blockSpawners[i].enabled = false;
        }
        ActivityOver(2);
        enabled = false;
    }

    protected override IEnumerator WaitForInstructions()
    {
        Destroy(triggerCollider);
        instructions.PlayVoiceline(Instructions.Voiceline.BlockEvent);
        yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.BlockEvent));
        StartActivity();
    }
}
