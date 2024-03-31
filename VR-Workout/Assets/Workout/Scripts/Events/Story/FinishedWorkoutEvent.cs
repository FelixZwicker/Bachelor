using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedWorkoutEvent : EventHandling
{
    protected override void StartActivity()
    {
         EndActivity();
    }

    protected override void EndActivity()
    {
        ActivityOver(4);
    }

    protected override IEnumerator WaitForInstructions()
    {
        // player did all workouts
        if(storyManager.eventCounter == 2)
        {
            instructions.PlayVoiceline(Instructions.Voiceline.StoryFinish);
            yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.StoryFinish));
            StartActivity();
        }
        // player hasnt done all workouts
        else
        {
            instructions.PlayVoiceline(Instructions.Voiceline.StoryNotComplete);
            yield return new WaitForSeconds(instructions.GetVoicelineLength(Instructions.Voiceline.StoryNotComplete));
            ActivityOver(3);
        }
    }
}
