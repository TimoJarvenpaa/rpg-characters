using RPGCharacters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Characters
{
    public class Rogue : Character
    {
        public Rogue(string name) : base(name)
        {
            CharacterClass = characterClass.Rogue;
            BasePrimaryAttributes = new PrimaryAttributes(2, 6, 1);
        }

        public override void LevelUp()
        {
            IncrementLevelByOne();
            BasePrimaryAttributes.IncrementStrengthBy(1);
            BasePrimaryAttributes.IncrementDexterityBy(4);
            BasePrimaryAttributes.IncrementIntelligenceBy(1);
        }
    }
}
