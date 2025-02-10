using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionObject : MonoBehaviour
{
    public string interactionText = "I'm an object"; // Interaction text, public
    public int sceneToLoad; // Scene index to load
    public bool canChangeScene = true; // Toggle for enabling/disabling scene change
    public bool persistAcrossScenes = true; // Flag to persist the object across scenes

    private void Awake()
    {
        // Prevent the object from being destroyed when loading a new scene if persistAcrossScenes is true
        if (persistAcrossScenes)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public string GetInteractionText()
    {
        return interactionText;
    }

    public void Interact()
    {
        Debug.Log("I've been interacted with!");

        // Only allow scene change if canChangeScene is true
        if (canChangeScene)
        {
            // Check if scene index is valid
            if (sceneToLoad >= 0 && sceneToLoad < SceneManager.sceneCountInBuildSettings)
            {
                // Load the new scene
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogWarning("Invalid scene index assigned!");
            }
        }
        else
        {
            Debug.Log("Scene change is disabled for this object.");
        }
    }
}
