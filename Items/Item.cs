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

        public Item(string name, int level, Slot slot)
        {
            this.itemName = name;
            this.itemLevel = level;
            this.itemSlot = slot;
        }

        public string ItemName { get => itemName; }
        public int ItemLevel { get => itemLevel; }
        public Slot ItemSlot { get => itemSlot; }


    }
}
