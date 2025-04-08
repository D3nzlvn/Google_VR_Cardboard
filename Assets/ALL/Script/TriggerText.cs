using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class TriggerText : MonoBehaviour
{
    public Text messageText; // Reference to the UI Text

    private void Start()
    {
        if (messageText != null)
            messageText.text = ""; // Hide text initially
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            messageText.text = "Press A";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Hide text when player leaves
        {
            messageText.text = "";
        }
    }
}
