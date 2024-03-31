using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class EventHandling : MonoBehaviour
{
    public SwingingArmsMotion swingingArmsMotion;
    public Instructions instructions;
    public StoryManager storyManager;
    public Transform player;
    public Transform rigCamera;
    public Transform eventPlayerPosition;
    public GameObject eventIndicator;
    public Collider triggerCollider;

    //start event on collision
    void OnTriggerEnter(Collider collider) 
    {
        if (collider.CompareTag("Player"))
        {
            eventIndicator.SetActive(false);
            SetPlayerPosition();
            StartCoroutine(WaitForInstructions());
        }
    }

    protected abstract void StartActivity();

    protected abstract void EndActivity();

    // Methode to track solved workouts
    public void ActivityOver(int eventID)
    {
        if(eventID == 1)
        {
            SoundManager.PlaySounds(SoundManager.Sound.Success);
            swingingArmsMotion.enabled = true;
            storyManager.eventCounter += 1;
        }
        else if(eventID == 2)
        {
            SoundManager.PlaySounds(SoundManager.Sound.Success);
            swingingArmsMotion.enabled = true;
            storyManager.eventCounter += 1;
        }
        else if(eventID == 3)
        {
            SoundManager.PlaySounds(SoundManager.Sound.Success);
            swingingArmsMotion.enabled = true;
            eventIndicator.SetActive(true);
        }
        else if(eventID == 4)
        {
            storyManager.FinishedWorkout();
        }
    }

    // Methode to set player position and deactivate moving script
    public void SetPlayerPosition()
    {
        swingingArmsMotion.enabled = false;
        player.position = eventPlayerPosition.position;
        rigCamera.rotation = eventPlayerPosition.rotation;
    }

    protected abstract IEnumerator WaitForInstructions();
}
