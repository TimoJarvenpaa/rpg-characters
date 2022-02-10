using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Attributes
{
    internal class PrimaryAttributes
    {
        private int Strength { get; set; }
        private int Dexterity { get; set; }
        private int Intelligence { get; set; }

        public PrimaryAttributes(int strength = 0, int dexterity = 0, int intelligence = 0)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public static PrimaryAttributes operator +(PrimaryAttributes lhs, PrimaryAttributes rhs)
        {
            return new PrimaryAttributes(
                lhs.Strength + rhs.Strength, 
                lhs.Dexterity + rhs.Dexterity,
                lhs.Intelligence + rhs.Intelligence
            );
        }

        public void IncrementStrengthBy(int amount)
        {
            Strength += amount;
        }

        public void IncrementDexterityBy(int amount)
        {
            Dexterity += amount;
        }

        public void IncrementIntelligenceBy(int amount)
        {
            Intelligence += amount;
        }

        public int GetIntelligence()
        {
            return Intelligence;
        }
    }
}
