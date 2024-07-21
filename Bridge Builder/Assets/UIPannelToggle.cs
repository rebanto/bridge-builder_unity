using UnityEngine;
using UnityEngine.UI; // Use this if you're using Unity's standard UI Text component
using TMPro; // Use this if you're using TextMeshPro

public class UIPanelToggle : MonoBehaviour
{
    public GameObject infoPanel; // The UI panel to be toggled
    private bool isPanelVisible = false; // Tracks the visibility state

    private void Start()
    {
        // Ensure the panel is initially hidden
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }

    private void Update()
    {
        // Check for input to toggle the panel
        if (Input.GetKeyDown(KeyCode.B))
        {
            TogglePanel();
        }
    }

    private void TogglePanel()
    {
        if (infoPanel != null)
        {
            isPanelVisible = !isPanelVisible; // Toggle the state
            infoPanel.SetActive(isPanelVisible); // Set the panel's visibility
        }
    }
}
