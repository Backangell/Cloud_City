using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI tipstext;
    public CanvasGroup alphaCanvas;
    public List<string> tips;

    void Start ()
    {
        Tipsf();
    }

    
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

    void Tipsf()
    {
        Debug.Log("oui");
        tipstext.text = tips[Random.Range(0, tips.Count)];
    }

}
