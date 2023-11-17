using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TestItemSystem : MonoBehaviour
{
    [SerializeField] private string itemsFilename;

    [Header("Equipment UI")]
    [SerializeField] private TextMeshProUGUI headTxt;
    [SerializeField] private TextMeshProUGUI neckTxt;
    [SerializeField] private TextMeshProUGUI chestTxt;
    [SerializeField] private TextMeshProUGUI handsTxt;
    [SerializeField] private TextMeshProUGUI legsTxt;
    [SerializeField] private TextMeshProUGUI feetTxt;
    [SerializeField] private TextMeshProUGUI acc1Txt;
    [SerializeField] private TextMeshProUGUI acc2Txt;

    void LoadItemsFromFile()
    {
        if (itemsFilename == null || itemsFilename == string.Empty)
        {
            return;
        }
        //ItemDatabase.TestItemsToJson();
        ItemDatabase db = ItemDatabase.TestJsonToItems(File.ReadAllText(itemsFilename));

        for (int i=0;i<db.equipments.Count; i++)
        {
            Debug.Log($"I{i} ===> {db.equipments[i].Name},{db.equipments[i].Description}");
            Equipment prev;
            EquipmentManager.Instance.AddEquipment(db.equipments[i], out prev);
        }
    }


    private void Start()
    {
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged;
        LoadItemsFromFile();
    }

    private void OnEquipmentChanged(EquipmentManager.EquipmentChangeEvent data)
    {
        switch (data.equipType)
        {
            case EquipType.HEAD:
                headTxt.text = data.newEquipment.Name;
                break;
            case EquipType.NECK:
                neckTxt.text = data.newEquipment.Name;
                break;
            case EquipType.CHEST:
                chestTxt.text = data.newEquipment.Name;
                break;
            case EquipType.HAND:
                handsTxt.text = data.newEquipment.Name;
                break;
            case EquipType.LEGS:
                legsTxt.text = data.newEquipment.Name;
                break;
            case EquipType.FEET:
                feetTxt.text = data.newEquipment.Name;
                break;
            case EquipType.ACCESSORY1:
                acc1Txt.text = data.newEquipment.Name;
                break;
            case EquipType.ACCESSORY2:
                acc2Txt.text = data.newEquipment.Name;
                break;
            default:
                throw new Exception($"Invalid equipment type: {data.equipType}");

        }
    }
}
