using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    private static EquipmentManager _instance;
    public static EquipmentManager Instance { get { return _instance; } }

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

    #region EquipmentChangeEvent
    public struct EquipmentChangeEvent
    {
        public EquipType equipType;
        public Equipment oldEquipment;
        public Equipment newEquipment;

        public EquipmentChangeEvent(EquipType equipType, Equipment oldEquipment, Equipment newEquipment)
        {
            this.equipType = equipType;
            this.oldEquipment = oldEquipment;
            this.newEquipment = newEquipment;
        }
    }
    #endregion

    //// Max equipmenet numbers (static or dynamic?)
    


    //// Data
    // List is preferred to dictionary with EquipTypes as keys because it can be serialized in editor.
    // Unfortunately, checking the number of equipped items of a certain type becomes O(n) instead of O(1) with dicts.
    public List<Equipment> equipment = new List<Equipment>();

    // Callback when the equipment gets changed
    //public delegate void OnEquipmentChanged(EquipmentChangeEvent data);
    public Action<EquipmentChangeEvent> onEquipmentChanged;

    public bool AddEquipment(Equipment item, out Equipment previousItem)
    {
        for (int i = 0; i < equipment.Count; i++)
        {
            if (equipment[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (Equipment)equipment[i];
                equipment[i] = item;
                onEquipmentChanged?.Invoke(new EquipmentChangeEvent(item.EquipmentType, previousItem, item));
                return true;
            }
        }
        previousItem = null;
        onEquipmentChanged?.Invoke(new EquipmentChangeEvent(item.EquipmentType, null, item));
        return false;
    }

    public bool RemoveEquipment(Equipment item)
    {
        for (int i = 0; i < equipment.Count; i++)
        {
            if (equipment[i] == item)
            {
                equipment[i] = null;
                return true;
            }
        }
        return false;
    }


    public bool HasEquipped(EquipType equipType)
    {
        return equipment.Any(e => e.EquipmentType == equipType);
    }

    public Equipment GetEquipmentByType(EquipType equipType)
    {
        return equipment.FirstOrDefault(e => e.EquipmentType == equipType);
    }
}
