﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Items
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message = "The weapon cannot be equipped.") : base(message)
        {

        }
    }
}
