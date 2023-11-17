using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemDatabase
{
    public List<Equipment> equipments;
    public List<Consumable> consumables;

    public ItemDatabase() { }

    public ItemDatabase(List<Equipment> equipments, List<Consumable> consumables)
    {
        this.equipments = equipments;
        this.consumables = consumables;
    }

    public static void TestItemsToJson()
    {
        List<Equipment> eq = new List<Equipment>
        {
            new Equipment(10,1,0,0,0,0,0,EquipType.HAND),
            new Equipment(1,0,9,1,1,0,0,EquipType.CHEST)
        };
        List<Consumable> cons = new List<Consumable>
        {
            new Consumable(new Consumable.Effects(10, 0)),
            new Consumable(new Consumable.Effects(1, 20))
        };

        ItemDatabase db = new ItemDatabase(eq, cons);
        string json = JsonConvert.SerializeObject(db);
        Debug.Log(json);
    }

    public static ItemDatabase TestJsonToItems(string json)
    {
        ItemDatabase ic = JsonConvert.DeserializeObject<ItemDatabase>(json);
        Debug.Log($"Equiments: {ic.equipments.Count}, Consumables: {ic.consumables.Count}");
        return ic;
    }
}
