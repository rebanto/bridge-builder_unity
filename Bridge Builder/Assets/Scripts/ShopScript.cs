using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject model1;
    public GameObject model2;
    public GameObject additionalGameObject;
    public TextMeshProUGUI additionalTextUI;

    private bool isPlayerInShop = false;

    private const string CoinsKey = "PlayerCoins";
    private const string BridgeBuiltKey = "BridgeBuilt";
    private const string AnotherModelBuiltKey = "AnotherModelBuilt";

    private void Start()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }

        if (model1 != null)
        {
            model1.SetActive(PlayerPrefs.GetInt(BridgeBuiltKey, 0) == 1);
        }

        if (model2 != null)
        {
            model2.SetActive(PlayerPrefs.GetInt(AnotherModelBuiltKey, 0) == 1);
        }

        if (additionalGameObject != null)
        {
            additionalGameObject.SetActive(false);
        }

        if (additionalTextUI != null)
        {
            additionalTextUI.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (infoPanel != null)
            {
                infoPanel.SetActive(true);
            }
            isPlayerInShop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (infoPanel != null)
            {
                infoPanel.SetActive(false);
            }
            isPlayerInShop = false;
        }
    }

    private void Update()
    {
        if (isPlayerInShop)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PurchaseItem(75, model1, BridgeBuiltKey);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PurchaseItem(100, model2, AnotherModelBuiltKey);
            }
        }
    }

    private void PurchaseItem(int cost, GameObject model, string modelBuiltKey)
    {
        int coins = PlayerPrefs.GetInt(CoinsKey, 0);

        if (coins >= cost)
        {
            coins -= cost;
            PlayerPrefs.SetInt(CoinsKey, coins);
            PlayerPrefs.Save();

            if (model != null)
            {
                model.SetActive(true);
                PlayerPrefs.SetInt(modelBuiltKey, 1);
                PlayerPrefs.Save();
            }

            if (additionalGameObject != null)
            {
                additionalGameObject.SetActive(true);
            }

            if (additionalTextUI != null)
            {
                additionalTextUI.gameObject.SetActive(true);
            }

            Debug.Log("Purchase successful! Remaining coins: " + coins);
        }
        else
        {
            Debug.Log("Not enough coins to make the purchase.");
        }
    }
}
