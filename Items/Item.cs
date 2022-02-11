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
    public abstract class Item
    {
        private string itemName;
        private int itemLevel;
        private Slot itemSlot;

        public Item()
        {
        
        }

        protected string ItemName { get => itemName; set => itemName = value; }
        protected int ItemLevel { get => itemLevel; set => itemLevel = value; }
        protected Slot ItemSlot { get => itemSlot; set => itemSlot = value; }


    }
}
