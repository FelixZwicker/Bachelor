using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistBlock : BlockPoses
{
    public IsPoseFist isPoseFist;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            if (isPoseFist.isPoseFistR)
            {
                Hit();
            }
            else
            {
                Miss();
            }
            
        }
        else if (other.CompareTag("LeftHand"))
        {
            if (isPoseFist.isPoseFistL)
            {
                Hit();
            }
            else
            {
                Miss();
            }
        }
        else if (other.CompareTag("Goal"))
        {
            Miss();
        }
    }
}
