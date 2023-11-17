

using Lore.Characters;
using UnityEngine;
using Lore.Stats;
using Newtonsoft.Json;

/// <summary>
/// Item that can be equipped on a character's part of the body.
/// 
/// </summary>
[System.Serializable]
public class Equipment : Item
{
    public override ItemType type => ItemType.EQUIPMENT;
    public int StrengthBonus;
    public int AgilityBonus;
    public int ResistanceBonus;
    public int RecoveryBonus;
    [Space]
    public int IntelligenceBonus;
    public int LuckBonus;
    public int CharismBonus;
    [Space]
    public EquipType EquipmentType;
    
    public Equipment()
    {
    }
    public Equipment(string jsonText)
    {
        Equipment e = JsonConvert.DeserializeObject<Equipment>(jsonText);
        this.StrengthBonus = e.StrengthBonus;
        this.AgilityBonus = e.AgilityBonus;
        this.ResistanceBonus = e.ResistanceBonus;
        this.RecoveryBonus = e.RecoveryBonus;
        this.IntelligenceBonus = e.IntelligenceBonus;
        this.LuckBonus = e.LuckBonus;
        this.CharismBonus = e.CharismBonus;
    }

    public Equipment(int strengthBonus, int agilityBonus, int resistanceBonus, int recoveryBonus, int intelligenceBonus, int luckBonus, int charismBonus, EquipType equipmentType)
    {
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        ResistanceBonus = resistanceBonus;
        RecoveryBonus = recoveryBonus;
        IntelligenceBonus = intelligenceBonus;
        LuckBonus = luckBonus;
        CharismBonus = charismBonus;
        EquipmentType = equipmentType;
    }

    public void Equip(Character c)
    {
        if (StrengthBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));
        if (AgilityBonus != 0)
            c.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));
        if (ResistanceBonus != 0)
            c.Resistance.AddModifier(new StatModifier(ResistanceBonus, StatModType.Flat, this));
        if (RecoveryBonus != 0)
            c.Recovery.AddModifier(new StatModifier(RecoveryBonus, StatModType.Flat, this));

        if (IntelligenceBonus != 0)
            c.Intelligence.AddModifier(new StatModifier(IntelligenceBonus, StatModType.Flat, this));

        /*
        if (VitalityBonus != 0)
            c.Resistance.AddModifier(new StatModifier(VitalityBonus, StatModType.Flat, this));

        if (StrengthPercentBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthPercentBonus, StatModType.PercentMult, this));
        if (AgilityPercentBonus != 0)
            c.Agility.AddModifier(new StatModifier(AgilityPercentBonus, StatModType.PercentMult, this));
        if (IntelligencePercentBonus != 0)
            c.Intelligence.AddModifier(new StatModifier(IntelligencePercentBonus, StatModType.PercentMult, this));
        if (VitalityPercentBonus != 0)
            c.Resistance.AddModifier(new StatModifier(VitalityPercentBonus, StatModType.PercentMult, this));
        */
    }

    public void Unequip(Character c)
    {
        /*
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
        c.Intelligence.RemoveAllModifiersFromSource(this);
        c.Resistance.RemoveAllModifiersFromSource(this);
        */
    }

}
