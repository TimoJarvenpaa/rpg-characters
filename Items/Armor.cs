using RPGCharacters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Items
{
    public enum ArmorType
    {
        ARMOR_CLOTH,
        ARMOR_LEATHER,
        ARMOR_MAIL,
        ARMOR_PLATE
    }
    internal class Armor : Item
    {
        private ArmorType ArmorType { get; }
        private PrimaryAttributes Attributes;

        public Armor(string name, int level, Slot slot, ArmorType armorType, PrimaryAttributes attributes)
        {
            ItemName = name;
            ItemLevel = level;
            ItemSlot = slot;
            ArmorType = armorType;
            Attributes = attributes;
        }
    }
}
