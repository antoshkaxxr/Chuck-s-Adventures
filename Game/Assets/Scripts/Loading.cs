using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Slider loadSlider;

    public float loadingTime = 0.5f;

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(loadingTime);

        AsyncOperation oper = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!oper.isDone)
        {
            float progress = oper.progress / 0.9f;
            loadSlider.value = progress;
            yield return null;
        }
    }
}