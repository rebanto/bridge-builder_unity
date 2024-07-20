using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text coinsText;
    int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = "Coins " + coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
