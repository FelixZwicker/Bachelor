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
        // Check if it's time to spawn a new block
        if (timer > spawnIntervall)
        {
            GameObject spawnObject = spawnObjects[Random.Range(0, spawnObjects.Length)];
            // Spawn a regular block if it's not a cube
            if (spawnObject.name != "cube")
            {
                GameObject target = Instantiate(spawnObject, points[Random.Range(0, points.Length)]);
                target.transform.localPosition = Vector3.zero;
            }
            // Spawn an evasion block if it's a cube
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
