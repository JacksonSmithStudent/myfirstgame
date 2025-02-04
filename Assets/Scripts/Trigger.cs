using System;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] bool hideOnTriggerEnter;
    [SerializeField] string tagFilter;
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    private bool hasTriggered = false; // Prevents multiple activations

    void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return; // If already triggered, exit immediately
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;

        hasTriggered = true; // Mark as triggered
        onTriggerEnter.Invoke();

        if (hideOnTriggerEnter && gameObject.name == "Mesh_protective suit")
        {
            Invoke(nameof(HideObject), 2f); // Hides the object after 2 seconds
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!string.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
        onTriggerExit.Invoke();
    }

    void HideObject()
    {
        gameObject.SetActive(false); // Fully hides the GameObject
    }
}
