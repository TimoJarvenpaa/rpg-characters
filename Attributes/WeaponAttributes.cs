using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public double CalculateWeaponDPS()
        {
            return BaseDamage * AttackSpeed;
        }
    }
}
