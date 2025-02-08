using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionObject : MonoBehaviour
{
    public string interactionText = "I'm an object"; // Now public
    public int sceneToLoad; // Scene index instead of name

    public string GetInteractionText()
    {
        return interactionText;
    }

    public void Interact()
    {
        Debug.Log("I've been interacted with!");

        if (sceneToLoad >= 0 && sceneToLoad < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Invalid scene index assigned!");
        }
    }
}
