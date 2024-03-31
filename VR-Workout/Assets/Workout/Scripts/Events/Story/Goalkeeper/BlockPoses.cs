using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class BlockPoses : MonoBehaviour
{
    public HitCounter hitCounter;

    //check collision with hands
    protected abstract void OnTriggerEnter(Collider other);

    // Method called when the block is hit
    public void Hit()
    {
        hitCounter.targetsHit += 1;
        hitCounter.totalScore += 1;
        hitCounter.UpdateGUI();
        SoundManager.PlaySounds(SoundManager.Sound.BallBlock);
        Destroy(gameObject);
    }

    // Method called when the block is missed
    public void Miss()
    {
        StartCoroutine(WaitForDestruction());
        hitCounter.targetsMissed += 1;
        hitCounter.totalScore -= 1;
        hitCounter.UpdateGUI();
        SoundManager.PlaySounds(SoundManager.Sound.Miss);
    }

    // Coroutine to destroy missed targets
    IEnumerator WaitForDestruction()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
