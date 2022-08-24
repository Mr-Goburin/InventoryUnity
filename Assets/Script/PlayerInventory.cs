using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] 
    public ItemData[] arrayInventory;

    [SerializeField] 
    public List<ItemData> _Inventory { get; private set; }

    private GameManager _GameManager;


    private void Awake()
    {
        _GameManager = GameManager.gameManager;
        _Inventory = arrayInventory.OrderBy(i => i.SellValue).ToList();
        MouseSensitive.IsCliked += CallClick;
    }



    public void CallClick(ItemData item)
    {
        if (_GameManager.modeItens == 0)
        {
            if (item.Type == "Clothes")
            {
                Animator Player;
                Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
                Player.SetInteger("Clothes Active",item.Clothes);
            }
        }
        
        else if (_GameManager.modeItens == 1)
        {
            if (item != null)
            {
                if (_GameManager.playerMoney >= item.BuyValue)
                {
                    _GameManager.playerMoney = _GameManager.playerMoney - item.BuyValue;
                    _Inventory.Add(item);
                    _Inventory = _Inventory.OrderBy(i => i.SellValue).ToList();
                }
            }
        }
        
        else if (_GameManager.modeItens == 2)
        {
            if (item != null)
            {
                if (item.Type != "Clothes")
                {
                    _GameManager.playerMoney = _GameManager.playerMoney + item.SellValue;
                    _Inventory.Remove(item);
                }
            }
        }
    }
    
    private void OnDestroy()
    {
        MouseSensitive.IsCliked -= CallClick;
    }
}
