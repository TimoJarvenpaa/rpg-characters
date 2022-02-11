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

    public abstract class Character
    {
        private string characterName;
        private int characterLevel;
        private characterClass characterClass;
        private PrimaryAttributes basePrimaryAttributes;
        private Equipment equipment;



        public Character()
        {
            characterLevel = 1;
            equipment = new Equipment();
        }

        protected int CharacterLevel { get => characterLevel; set => characterLevel = value; }
        protected characterClass CharacterClass { get => characterClass; set => characterClass = value; }
        protected string CharacterName { get => characterName; set => characterName = value; }
        protected PrimaryAttributes BasePrimaryAttributes { get => basePrimaryAttributes; set => basePrimaryAttributes = value; }
        protected Equipment Equipment { get => equipment; }

        public abstract void LevelUp();

    }
}
