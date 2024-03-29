using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] points;
    public Transform centerSpawnpoint;

    public int spawnIntervall;

    private float timer;
  
    void Update()
    {
        if (timer > spawnIntervall)
        {
            GameObject spawnObject = spawnObjects[Random.Range(0, spawnObjects.Length)];
            if(spawnObject.name != "cube")
            {
                GameObject target = Instantiate(spawnObject, points[Random.Range(0, points.Length)]);
                target.transform.localPosition = Vector3.zero;
            }
            else
            {
                GameObject evasionBlock = Instantiate(spawnObject, centerSpawnpoint);
                evasionBlock.transform.localPosition = Vector3.zero;
            }
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
