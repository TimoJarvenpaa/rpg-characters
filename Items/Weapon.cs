using RPGCharacters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Items
{
    public enum WeaponType
    {
        WEAPON_AXE,
        WEAPON_BOW,
        WEAPON_DAGGER,
        WEAPON_HAMMER,
        WEAPON_STAFF,
        WEAPON_SWORD,
        WEAPON_WAND
    }
    internal class Weapon : Item
    {
        private WeaponType WeaponType { get; }
        private WeaponAttributes WeaponAttributes;
        private double DPS { get; }

        public Weapon(string name, int level, Slot slot, WeaponType weaponType, WeaponAttributes weaponAttributes)
        {
            ItemName = name;
            ItemLevel = level;
            ItemSlot = slot;
            WeaponType = weaponType;
            WeaponAttributes = weaponAttributes;
            DPS = WeaponAttributes.CalculateWeaponDPS();
        }

        public WeaponType GetWeaponType()
        { 
            return WeaponType;
        }

        public double GetDPS()
        {
            return DPS;
        }
    }
}
