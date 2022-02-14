﻿using RPGCharacters.Attributes;
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
        private PrimaryAttributes totalPrimaryAttributes;
        private Equipment equipment;



        public Character(string name)
        {
            characterName = name;
            characterLevel = 1;
            equipment = new Equipment();
        }

        public int CharacterLevel { get => characterLevel; protected set => characterLevel = value; }
        protected characterClass CharacterClass { get => characterClass; set => characterClass = value; }
        protected string CharacterName { get => characterName; }
        public PrimaryAttributes BasePrimaryAttributes { get => basePrimaryAttributes; protected set => basePrimaryAttributes = value; }
        protected Equipment Equipment { get => equipment; }
        protected PrimaryAttributes TotalPrimaryAttributes { get => totalPrimaryAttributes; set => totalPrimaryAttributes = value; }

        private void equipWeapon(Weapon weapon)
        {
            try
            {
                if (this.characterClass == characterClass.Mage && weapon.WeaponType != WeaponType.WEAPON_STAFF && weapon.WeaponType != WeaponType.WEAPON_WAND)
                    throw new InvalidWeaponException("Mages can only equip staffs or wands.");
                if (this.characterClass == characterClass.Ranger && weapon.WeaponType != WeaponType.WEAPON_BOW)
                    throw new InvalidWeaponException("Rangers can only equip bows.");
                if (this.characterClass == characterClass.Rogue && weapon.WeaponType != WeaponType.WEAPON_DAGGER && weapon.WeaponType != WeaponType.WEAPON_SWORD)
                    throw new InvalidWeaponException("Rogues can only equip daggers or swords.");
                if (this.characterClass == characterClass.Warrior && weapon.WeaponType != WeaponType.WEAPON_AXE && weapon.WeaponType != WeaponType.WEAPON_HAMMER && weapon.WeaponType != WeaponType.WEAPON_SWORD)
                    throw new InvalidWeaponException("Warriors can only equip axes, hammers or swords.");
                if (weapon.ItemLevel > characterLevel)
                    throw new InvalidWeaponException("The character does not meet the level requirement to equip this weapon.");
                this.equipment.PutItemToSlot(weapon, Slot.WEAPON_SLOT);

            }
            catch (InvalidWeaponException ex)
            {
                throw new InvalidWeaponException(ex.Message);
            }
        
        }

        private void equipArmor(Armor armor)
        {
            try
            {
                if (this.characterClass == characterClass.Mage && armor.ArmorType != ArmorType.ARMOR_CLOTH)
                    throw new InvalidArmorException("Mages can only equip cloth armor.");
                if (this.characterClass == characterClass.Ranger && armor.ArmorType != ArmorType.ARMOR_LEATHER && armor.ArmorType != ArmorType.ARMOR_MAIL)
                    throw new InvalidArmorException("Rangers can only equip leather or mail armor.");
                if (this.characterClass == characterClass.Rogue && armor.ArmorType != ArmorType.ARMOR_LEATHER && armor.ArmorType != ArmorType.ARMOR_MAIL)
                    throw new InvalidArmorException("Rogues can only equip leather or mail armor.");
                if (this.characterClass == characterClass.Warrior && armor.ArmorType != ArmorType.ARMOR_MAIL && armor.ArmorType != ArmorType.ARMOR_PLATE)
                    throw new InvalidArmorException("Warriors can only equip mail or plate armor.");
                if (armor.ItemLevel > characterLevel)
                    throw new InvalidArmorException("The character does not meet the level requirement to equip this armor.");
                this.equipment.PutItemToSlot(armor, armor.ItemSlot);

            }
            catch (InvalidArmorException ex)
            {
                throw new InvalidArmorException(ex.Message);
            }

        }

        public string equip(Item item)
        {
            try
            {
                if (item.ItemSlot == Slot.WEAPON_SLOT)
                {
                    equipWeapon((item as Weapon));
                    return "New weapon equipped!";
                }
                else
                {
                    equipArmor((item as Armor));
                    this.totalPrimaryAttributes = this.basePrimaryAttributes + this.equipment.CalculateArmorAttributes();
                    return "New armor equipped!";
                }
            }
            catch (InvalidWeaponException ex)
            {
                throw new InvalidWeaponException(ex.Message);
            }
            catch (InvalidArmorException ex)
            {
                throw new InvalidArmorException(ex.Message);
            }
        }

        protected void IncrementLevelByOne()
        {
            this.characterLevel++;
        }

        public double Damage()
        {
            double weaponDPS = Equipment.GetWeaponDPS();

            switch (characterClass)
            {
                case characterClass.Mage:
                    return Math.Round(weaponDPS * (1 + TotalPrimaryAttributes.Intelligence / 100.00), 2);
                case characterClass.Ranger:
                    return Math.Round(weaponDPS * (1 + TotalPrimaryAttributes.Dexterity / 100.00), 2);
                case characterClass.Rogue:
                    return Math.Round(weaponDPS * (1 + TotalPrimaryAttributes.Dexterity / 100.00), 2);
                case characterClass.Warrior:
                    return Math.Round(weaponDPS * (1  + TotalPrimaryAttributes.Strength / 100.00), 2);
                default:
                    return 1.00;
            }
        }



        public string DisplayStats()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + this.characterName);
            sb.AppendLine("Level: " + this.characterLevel);
            sb.AppendLine("Strength: " +  this.totalPrimaryAttributes.Strength);
            sb.AppendLine("Dexterity: " + this.totalPrimaryAttributes.Dexterity);
            sb.AppendLine("Intelligence: " + this.totalPrimaryAttributes.Intelligence);
            sb.AppendLine("Damage: " + Damage());

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        public abstract void LevelUp();

    }
}