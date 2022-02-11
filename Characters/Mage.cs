using RPGCharacters.Attributes;
using RPGCharacters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Characters
{
    public class Mage : Character
    {
        public Mage(string name) : base(name)
        {
            CharacterClass = characterClass.Mage;
            BasePrimaryAttributes = new PrimaryAttributes(1, 1, 8);
        }

        protected override void LevelUp()
        {
            IncrementLevelByOne();
            BasePrimaryAttributes.IncrementStrengthBy(1);
            BasePrimaryAttributes.IncrementDexterityBy(1);
            BasePrimaryAttributes.IncrementIntelligenceBy(5);
        }

        protected override double Damage()
        {
            double weaponDPS = Equipment.GetWeaponDPS();
            if (weaponDPS == 1)
                return 1;
            return weaponDPS * (1 + TotalPrimaryAttributes.Intelligence / 100);
        }
    }
}
