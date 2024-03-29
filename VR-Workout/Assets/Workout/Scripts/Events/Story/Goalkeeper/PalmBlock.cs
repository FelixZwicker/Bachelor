using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmBlock : BlockPoses
{
    public IsPosePalm isPosePalm;

    private bool leftHandCollided = false;
    private bool rightHandCollided = false;
    private bool countedHit = false;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            rightHandCollided = true;
        }
        if (other.CompareTag("LeftHand"))
        {
            leftHandCollided = true;
        }
        if (other.CompareTag("Goal") && !leftHandCollided && !rightHandCollided)
        {
            Miss();
        }

        CheckHandsCollision();
    }

    private void OnTriggerExit(Collider other)
    {
        leftHandCollided = false;
        rightHandCollided = false;
        countedHit = false;
    }

    //check both hand collision before one exits the collider
    private void CheckHandsCollision()
    {
        if (!countedHit && leftHandCollided && rightHandCollided && (isPosePalm.isPosePalmL || isPosePalm.isPosePalmR))
        {
            countedHit = true;
            Hit();
        }
    }
}
