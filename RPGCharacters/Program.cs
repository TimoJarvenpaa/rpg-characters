using RPGCharacters.Characters;
using System;

namespace RPGCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // No UI or interactive functionality due to the scope of the project
            Mage mage = new Mage("Gandalf");
            Ranger ranger = new Ranger("Legolas");
            Rogue rogue = new Rogue("Aragorn");
            Warrior warrior = new Warrior("Gimli");
        }
    }
}
