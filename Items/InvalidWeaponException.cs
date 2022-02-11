using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Items
{
    internal class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message)
        {

        }

        public override string Message => "The weapon cannot be equipped.";
    }
}
