using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour
{
    public Text messageText; // Assign a UI Text element in the inspector
    public Camera mainCamera; // Assign the player's camera in the inspector

    void Start()
    {
        if (messageText != null && mainCamera != null)
        {
            messageText.enabled = true; // Show the text
            messageText.transform.position = mainCamera.transform.position + mainCamera.transform.forward * 2f;
            messageText.transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
            StartCoroutine(HideTextAfterDelay(10f)); // Hide it after 10 seconds
        }
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.enabled = false; // Hide the text
    }
}
