using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Consumable : Item
{
    public class Effects
    {
        public float Heal;
        public float MoveSpeedBoost;

        public Effects() { }
        public Effects(float heal, float moveSpeedBoost)
        {
            Heal = heal;
            MoveSpeedBoost = moveSpeedBoost;
        }
    }
    public Effects effects;
    public override ItemType type => ItemType.CONSUMABLE;

    public Consumable() { }

    public Consumable(Effects effects)
    {
        this.effects = effects;
    }
}
