using RPGCharacters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Characters
{
    internal class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            CharacterClass = characterClass.Mage;
            BasePrimaryAttributes = new PrimaryAttributes(5, 2, 1);
        }

        protected override void LevelUp()
        {
            IncrementLevelByOne();
            BasePrimaryAttributes.IncrementStrengthBy(3);
            BasePrimaryAttributes.IncrementDexterityBy(2);
            BasePrimaryAttributes.IncrementIntelligenceBy(1);
        }
    }
}
