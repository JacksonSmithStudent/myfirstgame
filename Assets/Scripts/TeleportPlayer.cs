using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    // List of teleport positions
    public Vector3[] teleportPositions;

    // Array of delays for each teleport position (should match the length of teleportPositions)
    public float[] teleportDelays;

    // Private timer counter
    private float timer = 0f;

    // Array to track which teleport positions have been used
    private bool[] teleportUsed;

    // Index to keep track of which teleport position to go to
    private int currentTeleportIndex = 0;

    // Reference to the CharacterController component
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController component if available
        characterController = GetComponent<CharacterController>();

        // Initialize the teleportUsed array with the same length as teleportPositions
        teleportUsed = new bool[teleportPositions.Length];
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure both arrays are not empty, otherwise exit
        if (teleportPositions.Length == 0 || teleportDelays.Length == 0)
            return;

        // Make sure the teleportDelays array is at least as long as teleportPositions array
        if (teleportDelays.Length < teleportPositions.Length)
        {
            Debug.LogWarning("teleportDelays array is smaller than teleportPositions array. Padding delays with default value.");
            System.Array.Resize(ref teleportDelays, teleportPositions.Length);
            for (int i = teleportDelays.Length - 1; i < teleportPositions.Length; i++)
            {
                teleportDelays[i] = 5f; // Default delay for missing positions
            }
        }

        // Check if the timer for the current teleport has reached its delay
        if (currentTeleportIndex < teleportPositions.Length && !teleportUsed[currentTeleportIndex])
        {
            timer += Time.deltaTime;

            // If the current timer has passed the delay for the current teleport position, teleport
            if (timer >= teleportDelays[currentTeleportIndex])
            {
                TeleportToNextLocation();
                timer = 0f; // Reset the timer for the next teleport
            }
        }
    }

    // Function to teleport the player to the current teleport position
    void TeleportToNextLocation()
    {
        // Ensure the currentTeleportIndex is within bounds and teleport position has not been used
        if (currentTeleportIndex < teleportPositions.Length && !teleportUsed[currentTeleportIndex])
        {
            Vector3 targetPosition = teleportPositions[currentTeleportIndex];

            if (characterController != null)
            {
                // Move the player to the teleport position using CharacterController
                characterController.enabled = false;  // Temporarily disable CharacterController
                transform.position = targetPosition;  // Set new position
                characterController.enabled = true;   // Re-enable CharacterController
            }
            else
            {
                // If no CharacterController, just use transform to teleport
                transform.position = targetPosition;
            }

            // Mark this teleport position as used
            teleportUsed[currentTeleportIndex] = true;

            // Move to the next teleport location
            currentTeleportIndex++;

            // If all teleport locations are used, stop teleporting
            if (currentTeleportIndex >= teleportPositions.Length)
            {
                currentTeleportIndex = teleportPositions.Length; // Ensure we stay out of bounds
            }
        }
    }
}
