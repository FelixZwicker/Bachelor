using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;

public class PickupTrash : MonoBehaviour
{
    public void Grabed()
    {
        Destroy(gameObject);
    }
}
