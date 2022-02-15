using System;

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

        /// <summary>
        /// Allows the summation of PrimaryAttributes objects
        /// </summary>
        /// <param name="lhs">The left hand side operand</param>
        /// <param name="rhs">The right hand side operand</param>
        /// <returns>A new PrimaryAttributes object with the combined STR, DEX and INT values of the arguments</returns>
        public static PrimaryAttributes operator +(PrimaryAttributes lhs, PrimaryAttributes rhs)
        {
            return new PrimaryAttributes(
                lhs.strength + rhs.strength, 
                lhs.dexterity + rhs.dexterity,
                lhs.intelligence + rhs.intelligence
            );
        }

        /// <summary>
        /// Increases the strength attribute by a given amount
        /// </summary>
        /// <param name="amount">An integer representing the amount to increment</param>
        public void IncrementStrengthBy(int amount)
        {
            strength += amount;
        }

        /// <summary>
        /// Increases the dexterity attribute by a given amount
        /// </summary>
        /// <param name="amount">An integer representing the amount to increment</param>
        public void IncrementDexterityBy(int amount)
        {
            dexterity += amount;
        }

        /// <summary>
        /// Increases the intelligence attribute by a given amount
        /// </summary>
        /// <param name="amount">An integer representing the amount to increment</param>
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
