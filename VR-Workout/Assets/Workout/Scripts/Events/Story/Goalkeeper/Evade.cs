using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : BlockPoses
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Miss();
        }
        if (other.CompareTag("Goal"))
        {
            Destroy(gameObject);
        }
    }
}
