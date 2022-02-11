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
    public class Armor : Item
    {
        private ArmorType armorType;
        private PrimaryAttributes attributes;

        public Armor(string name, int level, Slot slot, ArmorType armorType, PrimaryAttributes attributes)
        {
            ItemName = name;
            ItemLevel = level;
            ItemSlot = slot;
            this.armorType = armorType;
            this.attributes = attributes;
        }

        public ArmorType ArmorType { get => this.armorType; }
        public PrimaryAttributes Attributes { get => this.attributes; }
    }
}
