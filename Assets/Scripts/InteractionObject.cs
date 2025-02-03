
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] private string interactionText = "I'm object";
    AudioSource Playsound;

    private void Start()
    {
        Playsound = GetComponent<AudioSource>();
    }

    public string GetInteractionText()
    {
        return interactionText;
    }
    public void Interact()
    {
        print("I've been interacted with!");
        Playsound.Play();
    }
}
