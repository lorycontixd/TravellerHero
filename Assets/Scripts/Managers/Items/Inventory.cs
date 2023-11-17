using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    private static Inventory _instance;
    public static Inventory Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public int InventoryMaxSize = 12;
    public List<Item> items = new List<Item>();
    public bool IsFull => items.Count >= InventoryMaxSize;

    public bool AddItem(Item item)
    {
        if (items.Count >= InventoryMaxSize)
        {
            return false;
        }
        items.Add(item);
        return true;
    }
    public bool RemoveItem(Item item)
    {
        return items.Remove(item);
    }
}
