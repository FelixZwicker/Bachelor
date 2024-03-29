using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocks : MonoBehaviour
{
    public float movingSpeed = 4;

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * movingSpeed;
    }
}
