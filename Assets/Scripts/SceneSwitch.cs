using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public float switchTime = 30f; // Time before switching scenes
    public int sceneIndex = 1; // Scene to switch to
    public Image fadeImage; // Assign the black UI Image in the Inspector
    public float fadeDuration = 2f; // Time to fully fade out

    void Start()
    {
        // Ensure the fade image is fully transparent at the start
        if (fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = 0f;
            fadeImage.color = color;
        }

        StartCoroutine(SwitchSceneAfterDelay());
    }

    IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSeconds(switchTime);
        yield return StartCoroutine(FadeToBlack());
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
    }
}
