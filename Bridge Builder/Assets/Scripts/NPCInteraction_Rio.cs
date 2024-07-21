using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction_Rio : MonoBehaviour
{
    public GameObject interactionPromptUI;
    private bool isPlayerNearby = false;
    private const string InteractionKey = "NPCInteraction_Rio";

    private void Start()
    {
        interactionPromptUI.SetActive(false);

        if (PlayerPrefs.GetInt(InteractionKey, 0) == 1)
        {
            interactionPromptUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !HasInteractedBefore())
        {
            interactionPromptUI.SetActive(true);
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPromptUI.SetActive(false);
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F) && !HasInteractedBefore())
        {
            interactionPromptUI.SetActive(false);
            PlayerPrefs.SetInt(InteractionKey, 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Dialogue_Rio");
        }
    }

    private bool HasInteractedBefore()
    {
        return PlayerPrefs.GetInt(InteractionKey, 0) == 1;
    }
}
