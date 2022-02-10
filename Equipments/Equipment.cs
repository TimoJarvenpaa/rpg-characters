using RPGCharacters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Equipments
{
    internal class Equipment
    {
        private Dictionary<Slot, Item> CharacterEquipment;

        public Equipment()
        {
            CharacterEquipment = new Dictionary<Slot, Item>();
            InitializeEquipment();
        }

        private void InitializeEquipment()
        {
            CharacterEquipment.Add(Slot.WEAPON_SLOT, null);
            CharacterEquipment.Add(Slot.HEAD_SLOT, null);
            CharacterEquipment.Add(Slot.BODY_SLOT, null);
            CharacterEquipment.Add(Slot.LEGS_SLOT, null);
        }
    }
}
