using RPGCharacters.Attributes;

namespace RPGCharacters.Characters
{
    public class Rogue : Character
    {
        public Rogue(string name) : base(name)
        {
            CharacterClass = characterClass.Rogue;
            BasePrimaryAttributes = new PrimaryAttributes(2, 6, 1);
            TotalPrimaryAttributes = BasePrimaryAttributes;
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
