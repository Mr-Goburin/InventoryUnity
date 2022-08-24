using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create Item")]
public class ItemData : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public int BuyValue;
    public int SellValue;
    public string Type;
    public int Clothes;
    //0 = green, 1 = red, 2 = blue

    public int Count
    {
        get
        {
            return
                FindObjectOfType<PlayerInventory>()._Inventory.FindAll(x => x.ID == this.ID).Count;
        }
    }

    public int ID { get; private set; }

    private void OnEnable() =>
        ID = this.GetInstanceID();

}

    
