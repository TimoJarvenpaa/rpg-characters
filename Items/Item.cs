using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Items
{
    public enum Slot
    {
        WEAPON_SLOT,
        HEAD_SLOT,
        BODY_SLOT,
        LEGS_SLOT
    }
    abstract class Item
    {
        protected string ItemName { get; set; }
        protected int ItemLevel { get; set; }
        protected Slot ItemSlot { get; set; }

        public Item()
        {
        
        }


    }
}
