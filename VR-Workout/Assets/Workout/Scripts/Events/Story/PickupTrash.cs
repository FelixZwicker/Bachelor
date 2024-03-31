using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrash : MonoBehaviour
{
    public void Grabed()
    {
        Destroy(gameObject);
    }
}
