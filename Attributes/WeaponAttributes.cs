using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Attributes
{
    internal class WeaponAttributes
    {
        private int BaseDamage;
        private int AttackSpeed;

        public WeaponAttributes(int baseDamage, int attackSpeed)
        {
            BaseDamage = baseDamage;
            AttackSpeed = attackSpeed;
        }

        public double CalculateWeaponDPS()
        {
            return BaseDamage * AttackSpeed;
        }
    }
}
