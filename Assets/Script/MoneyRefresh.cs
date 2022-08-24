using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyRefresh : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public GameManager _GameManager;
    void Start()
    {
        _GameManager = GameManager.gameManager;
        textUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textUI.text = $""+_GameManager.playerMoney;
    }
}
