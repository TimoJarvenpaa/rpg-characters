using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Attributes
{
    public class PrimaryAttributes
    {
        private int strength { get; set; }
        private int dexterity { get; set; }
        private int intelligence { get; set; }

        public PrimaryAttributes(int strength = 0, int dexterity = 0, int intelligence = 0)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
        }

        public int Strength { get => strength; }
        public int Dexterity { get => dexterity; }
        public int Intelligence { get => intelligence; }

        public static PrimaryAttributes operator +(PrimaryAttributes lhs, PrimaryAttributes rhs)
        {
            return new PrimaryAttributes(
                lhs.strength + rhs.strength, 
                lhs.dexterity + rhs.dexterity,
                lhs.intelligence + rhs.intelligence
            );
        }

        public void IncrementStrengthBy(int amount)
        {
            strength += amount;
        }

        public void IncrementDexterityBy(int amount)
        {
            dexterity += amount;
        }

        public void IncrementIntelligenceBy(int amount)
        {
            intelligence += amount;
        }

        public override bool Equals(object obj)
        {
            return obj is PrimaryAttributes attributes &&
                   strength == attributes.strength &&
                   dexterity == attributes.dexterity &&
                   intelligence == attributes.intelligence;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
