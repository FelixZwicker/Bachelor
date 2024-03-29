using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPosePalm : MonoBehaviour
{
    public bool isPosePalmR = false;
    public bool isPosePalmL = false;

    public void LPoseState(bool isPosePalmL)
    {
        if (isPosePalmL)
        {
            this.isPosePalmL = true;
        }
        else
        {
            this.isPosePalmL = false;
        }
    }

    public void RPoseState(bool isPosePalmR)
    {
        if (isPosePalmR)
        {
            this.isPosePalmR = true;
        }
        else
        {
            this.isPosePalmR = false;
        }
    }
}
