using RPGCharacters.Attributes;
using RPGCharacters.Items;
using System.Collections.Generic;

namespace RPGCharacters.Equipments
{
    public class Equipment
    {
        private Dictionary<Slot, Item> characterEquipment;

        public Equipment()
        {
            characterEquipment = new Dictionary<Slot, Item>();
            InitializeEquipment();
        }

        /// <summary>
        /// Initializes a dictionary depicting a character's equipment with null values.
        /// </summary>
        private void InitializeEquipment()
        {
            characterEquipment.Add(Slot.WEAPON_SLOT, null);
            characterEquipment.Add(Slot.HEAD_SLOT, null);
            characterEquipment.Add(Slot.BODY_SLOT, null);
            characterEquipment.Add(Slot.LEGS_SLOT, null);
        }

        /// <summary>
        /// Overwrites a value in the equipment dictionary with the given item 
        /// using the target slot as the key.
        /// </summary>
        /// <param name="item">Item to equip. Can be of type Weapon or Armor.</param>
        /// <param name="targetSlot">The equipment slot where the item is supposed to be equipped in.</param>
        /// <exception cref="InvalidWeaponException">When trying to equip a weapon in the wrong slot</exception>
        /// <exception cref="InvalidArmorException">When trying to equip an armor in the wrong slot</exception>
        public void PutItemToSlot(Item item, Slot targetSlot)
        {
            if (item.ItemSlot == Slot.WEAPON_SLOT && item.ItemSlot != targetSlot)
            {
                throw new InvalidWeaponException("A weapon can only be equipped in the weapon slot.");
            }

            if (item.ItemSlot != Slot.WEAPON_SLOT && item.ItemSlot != targetSlot)
            {
                throw new InvalidArmorException("Armor can only be equipped in the correct armor slot.");
            }

            characterEquipment[targetSlot] = item;
        }

        /// <summary>
        /// Calculates the total primary attributes of a character's equipped armor.
        /// </summary>
        /// <returns>PrimaryAttributes object containing the total primary attributes 
        /// of a character's equipped armor
        /// </returns>
        public PrimaryAttributes CalculateArmorAttributes()
        {
            PrimaryAttributes total = new PrimaryAttributes();
            if (characterEquipment[Slot.HEAD_SLOT] != null)
                total += (characterEquipment[Slot.HEAD_SLOT] as Armor).ArmorAttributes;
            if (characterEquipment[Slot.BODY_SLOT] != null)
                total += (characterEquipment[Slot.BODY_SLOT] as Armor).ArmorAttributes;
            if (characterEquipment[Slot.LEGS_SLOT] != null)
                total += (characterEquipment[Slot.LEGS_SLOT] as Armor).ArmorAttributes;
            return total;
        }

        /// <summary>
        /// Returns the damage per second of the character's currently equipped weapon
        /// or 1.00 if no weapon is equipped.
        /// </summary>
        /// <returns>DPS of the character's weapon or 1.00 if no weapon is equipped</returns>
        public double GetWeaponDPS()
        {
            if (characterEquipment[Slot.WEAPON_SLOT] == null)
                return 1.00;
            return (characterEquipment[Slot.WEAPON_SLOT] as Weapon).DPS;
        }
    }
}
