using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    public TextMeshProUGUI coinsText;
    private int coins;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCoins();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoinsText();
    }

    public void AddCoins(int num)
    {
        coins += num;
        SaveCoins();
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + coins.ToString();
        }
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("PlayerCoins", coins);
        PlayerPrefs.Save();
    }

    private void LoadCoins()
    {
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            coins = PlayerPrefs.GetInt("PlayerCoins");
        }
        else
        {
            coins = 0;
        }
    }
}
