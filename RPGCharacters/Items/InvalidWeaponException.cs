using System;

namespace RPGCharacters.Items
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message = "The weapon cannot be equipped.") : base(message)
        {

        }
    }
}
