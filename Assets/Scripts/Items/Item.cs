using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item
{
    public int Id;
    public string Name;
    public string Description;
    public float Cost;
    public Sprite icon;
    public abstract ItemType type { get; }

    public virtual bool Use() { return true; }
    public virtual bool Drop() { return true; }

    public virtual string ToJson() { return JsonConvert.SerializeObject(this); }


}
