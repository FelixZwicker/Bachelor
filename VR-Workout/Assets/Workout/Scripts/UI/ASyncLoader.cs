using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ASyncLoader : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;

    private bool isLoading = false;

    private void Update()
    {
        if(Time.timeSinceLevelLoad > 2f && !isLoading)
        {
            isLoading = true;
            StartCoroutine(LoadLevelAsync("Story"));
        }
    }

    //coroutine to load a level asynchronously
    private IEnumerator LoadLevelAsync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        //wait until the loading operation is complete and update the slider
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }
}
