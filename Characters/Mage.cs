using RPGCharacters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Characters
{
    internal class Mage : Character
    {
        public Mage(string name)
        {
            CharacterName = name;
            CharacterClass = characterClass.Mage;
            BasePrimaryAttributes = new PrimaryAttributes(1, 1, 8);
        }
        public override void LevelUp()
        {
            BasePrimaryAttributes.IncrementStrengthBy(1);
            BasePrimaryAttributes.IncrementDexterityBy(1);
            BasePrimaryAttributes.IncrementIntelligenceBy(5);
        }
    }
}
