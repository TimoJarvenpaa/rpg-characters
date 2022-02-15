using RPGCharacters.Attributes;

namespace RPGCharacters.Characters
{
    public class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            CharacterClass = characterClass.WARRIOR;
            BasePrimaryAttributes = new PrimaryAttributes(5, 2, 1);
            TotalPrimaryAttributes = BasePrimaryAttributes;
        }

        public override void LevelUp()
        {
            IncrementLevelByOne();
            BasePrimaryAttributes.IncrementStrengthBy(3);
            BasePrimaryAttributes.IncrementDexterityBy(2);
            BasePrimaryAttributes.IncrementIntelligenceBy(1);
        }
    }
}
