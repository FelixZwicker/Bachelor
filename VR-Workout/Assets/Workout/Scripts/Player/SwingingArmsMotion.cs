using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingArmsMotion : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject mainCamera;
    public GameObject forwardDirection;
    public AudioSource jogging;

    private Vector3 positionPreviousFrameLeftHand;
    private Vector3 positionPreviousFrameRightHand;
    private Vector3 positionCurrentFrameLeftHand;
    private Vector3 positionCurrentFrameRightHand;

    private float speed = 4;
    private float leftHandDistance;
    private float rightHandDistance;
    private float leftHandMovement;
    private float rightHandMovement;
    private float minDistanceThreshold = 0.01f;

    void Start()
    {
        positionPreviousFrameLeftHand = leftHand.transform.position;
        positionPreviousFrameRightHand = rightHand.transform.position;
    }

    void Update()
    {
        // get forward direction from the center eye camera and set it to the forward direction object
        float yRotation = mainCamera.transform.eulerAngles.y;
        forwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        positionCurrentFrameLeftHand = leftHand.transform.position;
        positionCurrentFrameRightHand = rightHand.transform.position;

        leftHandMovement = positionCurrentFrameLeftHand.y - positionPreviousFrameLeftHand.y;
        rightHandMovement = positionCurrentFrameRightHand.y - positionPreviousFrameRightHand.y;

        // calculate distances moved by each hand
        leftHandDistance = Vector3.Distance(positionPreviousFrameLeftHand, leftHand.transform.position);
        rightHandDistance = Vector3.Distance(positionPreviousFrameRightHand, rightHand.transform.position);

        // update previous positions
        positionPreviousFrameLeftHand = leftHand.transform.position;
        positionPreviousFrameRightHand = rightHand.transform.position;

        // check if one hand moved upwards and the other downwards, and if the minimum distance threshold is met
        if (((leftHandMovement > 0 && rightHandMovement < 0) ||
            (leftHandMovement < 0 && rightHandMovement > 0)) && (leftHandDistance >= minDistanceThreshold && rightHandDistance >= minDistanceThreshold))
        {
            // aggregate to get hand speed only on the y-axis
            // could be used for controlling the movement speed
                // float HandSpeed = (leftHandMovement + rightHandMovement) * 0.5f;

            if (Time.timeSinceLevelLoad > 1f)
            {
                transform.position += forwardDirection.transform.forward * speed * Time.deltaTime;
            }
        }
    }
}