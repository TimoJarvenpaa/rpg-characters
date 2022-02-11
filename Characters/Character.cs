using RPGCharacters.Attributes;
using RPGCharacters.Equipments;
using RPGCharacters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Characters
{
    public enum characterClass
    {
        Mage,
        Ranger,
        Rogue,
        Warrior
    }

    public abstract class Character
    {
        private string characterName;
        private int characterLevel;
        private characterClass characterClass;
        private PrimaryAttributes basePrimaryAttributes;
        private Equipment equipment;



        public Character(string name)
        {
            characterName = name;
            characterLevel = 1;
            equipment = new Equipment();
        }

        protected int CharacterLevel { get => characterLevel; set => characterLevel = value; }
        protected characterClass CharacterClass { get => characterClass; set => characterClass = value; }
        protected string CharacterName { get => characterName; }
        protected PrimaryAttributes BasePrimaryAttributes { get => basePrimaryAttributes; set => basePrimaryAttributes = value; }
        protected Equipment Equipment { get => equipment; }

        protected void equipWeapon(Weapon weapon)
        {
            try
            {
                if (this.characterClass == characterClass.Mage && (weapon.WeaponType != WeaponType.WEAPON_STAFF || weapon.WeaponType != WeaponType.WEAPON_WAND))
                    throw new InvalidWeaponException("Mages can only equip staffs or wands.");
                if (this.characterClass == characterClass.Ranger && weapon.WeaponType != WeaponType.WEAPON_BOW)
                    throw new InvalidWeaponException("Rangers can only equip bows.");
                if (this.characterClass == characterClass.Rogue && (weapon.WeaponType != WeaponType.WEAPON_DAGGER || weapon.WeaponType != WeaponType.WEAPON_SWORD))
                    throw new InvalidWeaponException("Rogues can only equip daggers or swords.");
                if (this.characterClass == characterClass.Warrior && (weapon.WeaponType != WeaponType.WEAPON_AXE || weapon.WeaponType != WeaponType.WEAPON_HAMMER || weapon.WeaponType != WeaponType.WEAPON_SWORD))
                    throw new InvalidWeaponException("Warriors can only equip axes, hammers or swords.");
                if (weapon.ItemLevel > characterLevel)
                    throw new InvalidWeaponException("The character does not meet the level requirement to equip this weapon.");
                this.equipment.putItemToSlot(weapon, Slot.WEAPON_SLOT);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        
        }

        protected void equipArmor(Armor armor)
        {
            try
            {
                if (this.characterClass == characterClass.Mage && armor.ArmorType != ArmorType.ARMOR_CLOTH)
                    throw new InvalidArmorException("Mages can only equip cloth armor.");
                if (this.characterClass == characterClass.Ranger && (armor.ArmorType != ArmorType.ARMOR_LEATHER || armor.ArmorType != ArmorType.ARMOR_MAIL))
                    throw new InvalidWeaponException("Rangers can only equip leather or mail armor.");
                if (this.characterClass == characterClass.Rogue && (armor.ArmorType != ArmorType.ARMOR_LEATHER || armor.ArmorType != ArmorType.ARMOR_MAIL))
                    throw new InvalidWeaponException("Rogues can only equip leather or mail armor.");
                if (this.characterClass == characterClass.Warrior && (armor.ArmorType != ArmorType.ARMOR_MAIL || armor.ArmorType != ArmorType.ARMOR_PLATE))
                    throw new InvalidWeaponException("Warriors can only equip mail or plate armor.");
                if (armor.ItemLevel > characterLevel)
                    throw new InvalidArmorException("The character does not meet the level requirement to equip this armor.");
                this.equipment.putItemToSlot(armor, armor.ItemSlot);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        protected void IncrementLevelByOne()
        {
            this.characterLevel++;
        }

        protected abstract void LevelUp();

    }
}
