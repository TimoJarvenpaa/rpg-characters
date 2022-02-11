using RPGCharacters.Attributes;
using RPGCharacters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void InitializeEquipment()
        {
            characterEquipment.Add(Slot.WEAPON_SLOT, null);
            characterEquipment.Add(Slot.HEAD_SLOT, null);
            characterEquipment.Add(Slot.BODY_SLOT, null);
            characterEquipment.Add(Slot.LEGS_SLOT, null);
        }

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

            characterEquipment.Add(targetSlot, item);
        }

        public PrimaryAttributes CalculateArmorAttributes()
        {
            PrimaryAttributes total = new PrimaryAttributes();
            if (characterEquipment[Slot.HEAD_SLOT] != null)
                total += (characterEquipment[Slot.HEAD_SLOT] as Armor).Attributes;
            if (characterEquipment[Slot.BODY_SLOT] != null)
                total += (characterEquipment[Slot.HEAD_SLOT] as Armor).Attributes;
            if (characterEquipment[Slot.LEGS_SLOT] != null)
                total += (characterEquipment[Slot.HEAD_SLOT] as Armor).Attributes;
            return total;
        }

        public double GetWeaponDPS()
        {
            if (characterEquipment[Slot.WEAPON_SLOT] == null)
                return 1;
            return (characterEquipment[Slot.WEAPON_SLOT] as Weapon).DPS;
        }
    }
}
