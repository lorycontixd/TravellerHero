using UnityEngine;
using Lore.Stats;

namespace Lore.Characters
{
	public class Character : MonoBehaviour
	{
		[Header("Physical Stats")]
		public CharacterStat Strength;
		public CharacterStat Agility;
		public CharacterStat Resistance;
		public CharacterStat Recovery;

		[Header("Mental Stats")]
        public CharacterStat Intelligence;
		public CharacterStat Luck;
		public CharacterStat Charism;

        [SerializeField] Inventory inventory;
		//[SerializeField] EquipmentPanel equipmentPanel;
		//[SerializeField] StatPanel statPanel;

		private void Awake()
		{
			//statPanel.SetStats(Strength, Agility, Intelligence, Vitality);
			//statPanel.UpdateStatValues();

			//inventory.OnItemRightClickedEvent += EquipFromInventory;
			//equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
		}

		private void EquipFromInventory(Item item)
		{
			/*if (item is EquippableItem)
			{
				Equip((EquippableItem)item);
			}*/
		}

		private void UnequipFromEquipPanel(Item item)
		{
			/*if (item is EquippableItem)
			{
				Unequip((EquippableItem)item);
			}*/
		}

		public void Equip(Equipment item)
		{
			/*if (inventory.RemoveItem(item))
			{
				EquippableItem previousItem;
				if (equipmentPanel.AddItem(item, out previousItem))
				{
					if (previousItem != null)
					{
						inventory.AddItem(previousItem);
						previousItem.Unequip(this);
						statPanel.UpdateStatValues();
					}
					item.Equip(this);
					statPanel.UpdateStatValues();
				}
				else
				{
					inventory.AddItem(item);
				}
			}*/
		}

		public void Unequip(Equipment item)
		{
			/*if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
			{
				item.Unequip(this);
				statPanel.UpdateStatValues();
				inventory.AddItem(item);
			}*/
		}
	}
}
