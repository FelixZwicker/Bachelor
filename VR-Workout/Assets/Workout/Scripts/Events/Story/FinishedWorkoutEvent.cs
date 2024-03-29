using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedWorkoutEvent : EventHandling
{
    protected override void StartActivity()
    {
         //Menu or Something to interact and then EndActivity();
         EndActivity();
    }

    protected override void EndActivity()
    {
        ActivityOver(4);
    }

    protected override IEnumerator WaitForInstructions()
    {
        if(storyManager.eventCounter == 2)
        {
            instructions.PlayVoiceline(Instructions.Voiceline.StoryFinish);
            yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.StoryFinish));
            StartActivity();
        }
        else
        {
            instructions.PlayVoiceline(Instructions.Voiceline.StoryNotComplete);
            yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.StoryNotComplete));
            ActivityOver(3);
        }
    }
}
