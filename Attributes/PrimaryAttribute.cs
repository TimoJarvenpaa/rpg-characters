using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Attributes
{
    internal class PrimaryAttribute
    {
        private int Strength { get; set; }
        private int Dexterity { get; set; }
        private int Intelligence { get; set; }

        public PrimaryAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public static PrimaryAttribute operator +(PrimaryAttribute lhs, PrimaryAttribute rhs)
        {
            return new PrimaryAttribute(
                lhs.Strength + rhs.Strength, 
                lhs.Dexterity + rhs.Dexterity,
                lhs.Intelligence + rhs.Intelligence
            );
        }

        public void incrementStrengthBy(int amount)
        {
            Strength += amount;
        }

        public void incrementDexterityBy(int amount)
        {
            Dexterity += amount;
        }

        public void incrementIntelligenceBy(int amount)
        {
            Intelligence += amount;
        }
    }
}
