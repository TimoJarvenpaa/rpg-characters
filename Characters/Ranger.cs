using RPGCharacters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Characters
{
    public class Ranger : Character
    {
        public Ranger(string name) : base(name)
        {
            CharacterClass = characterClass.Ranger;
            BasePrimaryAttributes = new PrimaryAttributes(1, 7, 1);
            TotalPrimaryAttributes = BasePrimaryAttributes;
        }

        public override void LevelUp()
        {
            IncrementLevelByOne();
            BasePrimaryAttributes.IncrementStrengthBy(1);
            BasePrimaryAttributes.IncrementDexterityBy(5);
            BasePrimaryAttributes.IncrementIntelligenceBy(1);
        }
    }
}
