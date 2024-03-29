using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingManager : MonoBehaviour
{
    public BlockSpawner[] spawners;
    public GameObject gameUI;
    public GameObject instructionUI;

    public void StartBlocking()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].enabled = true;
        }
        instructionUI.SetActive(false);
        gameUI.SetActive(true);
    }
}
