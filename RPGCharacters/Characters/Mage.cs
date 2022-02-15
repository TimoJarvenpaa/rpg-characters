using RPGCharacters.Attributes;

namespace RPGCharacters.Characters
{
    public class Mage : Character
    {
        public Mage(string name) : base(name)
        {
            CharacterClass = characterClass.MAGE;
            BasePrimaryAttributes = new PrimaryAttributes(1, 1, 8);
            TotalPrimaryAttributes = BasePrimaryAttributes;
        }

        public override void LevelUp()
        {
            IncrementLevelByOne();
            BasePrimaryAttributes.IncrementStrengthBy(1);
            BasePrimaryAttributes.IncrementDexterityBy(1);
            BasePrimaryAttributes.IncrementIntelligenceBy(5);
        }
    }
}
