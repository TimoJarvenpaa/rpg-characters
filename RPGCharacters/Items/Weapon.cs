using RPGCharacters.Attributes;

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
    public class Weapon : Item
    {
        private WeaponType weaponType;
        private WeaponAttributes weaponAttributes;
        private double dPS;

        public Weapon(string name, int level, Slot slot, WeaponType weaponType, WeaponAttributes weaponAttributes) : base(name, level, slot)
        {
            this.weaponType = weaponType;
            this.weaponAttributes = weaponAttributes;
            dPS = this.WeaponAttributes.CalculateWeaponDPS();
        }

        public WeaponType WeaponType { get => this.weaponType; }
        public WeaponAttributes WeaponAttributes { get => this.weaponAttributes; }
        public double DPS { get => dPS; }
    }
}
