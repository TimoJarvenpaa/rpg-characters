using RPGCharacters.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Characters
{
    public enum characterClass
    {
        Mage,
        Ranger,
        Rogue,
        Warrior
    }
    abstract class Character
    {
        protected string Name { get; set; }
        protected int Level { get; set; }
        protected characterClass CharacterClass { get; set; }
        protected PrimaryAttribute BasePrimaryAttributes;

        public Character()
        {
            Level = 1;
        }

        public abstract void levelUp();

    }
}
