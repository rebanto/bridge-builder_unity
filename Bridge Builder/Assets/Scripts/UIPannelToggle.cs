using UnityEngine;
using UnityEngine.UI; // Use this if you're using Unity's standard UI Text component
using TMPro; // Use this if you're using TextMeshPro

public class UIPanelToggle : MonoBehaviour
{
    public GameObject infoPanel;
    private bool isPanelVisible = false;

    private void Start()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            TogglePanel();
        }
    }

    private void TogglePanel()
    {
        if (infoPanel != null)
        {
            isPanelVisible = !isPanelVisible;
            infoPanel.SetActive(isPanelVisible);
        }
    }
}
