using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform;
    public Terrain terrain;

    public float playerHeightOffset;

    private const float zMin = -29.5f;
    private const float zMax = 468.56f;
    private const float xMin = -139.8f;
    private const float xMax = 145.7f;

    void Update()
    {
        Vector3 playerPosition = playerTransform.position;

        //keep Player on ground level
        float terrainHeight = terrain.SampleHeight(playerTransform.position);
        playerPosition.y = terrainHeight + playerHeightOffset;
        playerTransform.position = playerPosition;

        //keep Player in level
        if(playerPosition.z > zMax)
        {
            playerPosition.z = zMax;
            playerTransform.position = playerPosition;
        }
        if(playerPosition.z < zMin)
        {
            playerPosition.z = zMin;
            playerTransform.position = playerPosition;
        }
        if(playerPosition.x > xMax)
        {
            playerPosition.x = xMax;
            playerTransform.position = playerPosition;
        }
        if(playerPosition.x < xMin)
        {
            playerPosition.x = xMin;
            playerTransform.position = playerPosition;
        }

    }
}
