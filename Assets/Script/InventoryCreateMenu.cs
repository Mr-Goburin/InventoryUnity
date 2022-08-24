using System.Collections.Generic;
using UnityEngine;

public class InventoryCreateMenu : MonoBehaviour
{
    public ItemReference element;
    private List<ItemData> _inventory;

    private void OnEnable()
    {
        CallInventory();
    }

    private void InstatiateElements()
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (isRepeated(i))
            {
                continue;
            }
            
            (Instantiate(element, transform) as ItemReference).SetValues(_inventory[i]);
        }
    }

    bool isRepeated(int i)
    {
        if (i == 0)
        {
            return false;
        }
        return _inventory[i].ID == _inventory[i - 1].ID;
    }
    
    public void CallInventory()
    {
        foreach (Transform child in transform) 
        {
            GameObject.Destroy(child.gameObject);
        }
        _inventory = new List<ItemData>();
        _inventory = FindObjectOfType<PlayerInventory>()._Inventory;
        InstatiateElements();
    }
}
