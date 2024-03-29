using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPoseFist : MonoBehaviour
{
    public bool isPoseFistR = false;
    public bool isPoseFistL = false;
    
    public void LPoseState(bool isPoseFistL)
    {
        if (isPoseFistL)
        {
            this.isPoseFistL = true;
        }
        else
        {
            this.isPoseFistL = false;
        }
    } 

    public void RPoseState(bool isPoseFistR)
    {
        if (isPoseFistR)
        {
            this.isPoseFistR = true;
        }
        else
        {
            this.isPoseFistR = false;
        }
    }
}
