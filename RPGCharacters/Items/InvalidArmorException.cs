using System;

namespace RPGCharacters.Items
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message = "The piece of armor cannot be equipped.") : base(message)
        {

        }
    }
}
