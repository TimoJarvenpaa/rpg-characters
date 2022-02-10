using RPGCharacters.Attributes;
using RPGCharacters.Equipments;
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
        protected string CharacterName { get; set; }
        protected int CharacterLevel { get; set; }
        protected characterClass CharacterClass { get; set; }
        protected PrimaryAttributes BasePrimaryAttributes { get; set; }
        protected Equipment Equipment;

        public Character()
        {
            CharacterLevel = 1;
            Equipment = new Equipment();
        }

        public abstract void LevelUp();

    }
}
