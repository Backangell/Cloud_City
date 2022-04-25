using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;

    public void Button_Start(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));

    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (progress > 1) progress = 1;

            slider.value = progress;
            progress = Mathf.Round(progress * 100f);
            progressText.text = progress + "%";

            yield return null;
        }
    }
}
