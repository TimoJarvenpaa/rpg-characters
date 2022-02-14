using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Items
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message = "The piece of armor cannot be equipped.") : base(message)
        {

        }
    }
}
