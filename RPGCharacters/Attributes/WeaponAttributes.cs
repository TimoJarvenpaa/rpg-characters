using System;

namespace RPGCharacters.Attributes
{
    public class WeaponAttributes
    {
        private int BaseDamage;
        private double AttackSpeed;

        public WeaponAttributes(int baseDamage, double attackSpeed)
        {
            BaseDamage = baseDamage;
            AttackSpeed = attackSpeed;
        }

        /// <summary>
        /// Calculates the weapon's damage per second
        /// </summary>
        /// <returns>DPS of the weapon</returns>
        public double CalculateWeaponDPS()
        {
            return BaseDamage * AttackSpeed;
        }
    }
}
