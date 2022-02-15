using RPGCharacters.Attributes;
using RPGCharacters.Equipments;
using RPGCharacters.Items;
using System;
using System.Text;

namespace RPGCharacters.Characters
{
    public enum characterClass
    {
        MAGE,
        RANGER,
        ROGUE,
        WARRIOR
    }

    public abstract class Character
    {
        private string characterName;
        private int characterLevel;
        private characterClass characterClass;
        private PrimaryAttributes basePrimaryAttributes;
        private PrimaryAttributes totalPrimaryAttributes;
        private Equipment equipment;

        public Character(string name)
        {
            characterName = name;
            characterLevel = 1;
            equipment = new Equipment();
        }

        #region Getters and Setters
        public int CharacterLevel { get => characterLevel; protected set => characterLevel = value; }
        protected characterClass CharacterClass { get => characterClass; set => characterClass = value; }
        protected string CharacterName { get => characterName; }
        public PrimaryAttributes BasePrimaryAttributes { get => basePrimaryAttributes; protected set => basePrimaryAttributes = value; }
        protected Equipment Equipment { get => equipment; }
        protected PrimaryAttributes TotalPrimaryAttributes { get => totalPrimaryAttributes; set => totalPrimaryAttributes = value; }
        #endregion

        /// <summary>
        /// A private method encapsulating the equipping of weapons and 
        /// the various restrictions regarding weapon types and level requirements.
        /// </summary>
        /// <param name="weapon">Weapon object the character is trying to equip</param>
        /// <exception cref="InvalidWeaponException">When a weapon can't be equipped</exception>
        private void EquipWeapon(Weapon weapon)
        {
            try
            {
                if (this.characterClass == characterClass.MAGE && weapon.WeaponType != WeaponType.WEAPON_STAFF && weapon.WeaponType != WeaponType.WEAPON_WAND)
                    throw new InvalidWeaponException("Mages can only equip staffs or wands.");
                if (this.characterClass == characterClass.RANGER && weapon.WeaponType != WeaponType.WEAPON_BOW)
                    throw new InvalidWeaponException("Rangers can only equip bows.");
                if (this.characterClass == characterClass.ROGUE && weapon.WeaponType != WeaponType.WEAPON_DAGGER && weapon.WeaponType != WeaponType.WEAPON_SWORD)
                    throw new InvalidWeaponException("Rogues can only equip daggers or swords.");
                if (this.characterClass == characterClass.WARRIOR && weapon.WeaponType != WeaponType.WEAPON_AXE && weapon.WeaponType != WeaponType.WEAPON_HAMMER && weapon.WeaponType != WeaponType.WEAPON_SWORD)
                    throw new InvalidWeaponException("Warriors can only equip axes, hammers or swords.");
                if (weapon.ItemLevel > characterLevel)
                    throw new InvalidWeaponException("The character does not meet the level requirement to equip this weapon.");
                this.equipment.PutItemToSlot(weapon, Slot.WEAPON_SLOT);

            }
            catch (InvalidWeaponException ex)
            {
                throw new InvalidWeaponException(ex.Message);
            }
        
        }

        /// <summary>
        /// A private method encapsulating the equipping of armor and
        /// the various restrictions regarding armor types and level requirements.
        /// </summary>
        /// <param name="armor">Armor object the character is trying to equip</param>
        /// <exception cref="InvalidArmorException">When an armor can't be equipped</exception>
        private void EquipArmor(Armor armor)
        {
            try
            {
                if (this.characterClass == characterClass.MAGE && armor.ArmorType != ArmorType.ARMOR_CLOTH)
                    throw new InvalidArmorException("Mages can only equip cloth armor.");
                if (this.characterClass == characterClass.RANGER && armor.ArmorType != ArmorType.ARMOR_LEATHER && armor.ArmorType != ArmorType.ARMOR_MAIL)
                    throw new InvalidArmorException("Rangers can only equip leather or mail armor.");
                if (this.characterClass == characterClass.ROGUE && armor.ArmorType != ArmorType.ARMOR_LEATHER && armor.ArmorType != ArmorType.ARMOR_MAIL)
                    throw new InvalidArmorException("Rogues can only equip leather or mail armor.");
                if (this.characterClass == characterClass.WARRIOR && armor.ArmorType != ArmorType.ARMOR_MAIL && armor.ArmorType != ArmorType.ARMOR_PLATE)
                    throw new InvalidArmorException("Warriors can only equip mail or plate armor.");
                if (armor.ItemLevel > characterLevel)
                    throw new InvalidArmorException("The character does not meet the level requirement to equip this armor.");
                this.equipment.PutItemToSlot(armor, armor.ItemSlot);

            }
            catch (InvalidArmorException ex)
            {
                throw new InvalidArmorException(ex.Message);
            }

        }

        /// <summary>
        /// Tries to equip the character with a given item. In case of armor,
        /// updates the total primary attributes of a character accordingly.
        /// </summary>
        /// <param name="item">Item to equip. Can be of type Weapon or Armor</param>
        /// <returns>A success message if the item was equipped</returns>
        /// <exception cref="InvalidWeaponException">When a weapon can't be equipped</exception>
        /// <exception cref="InvalidArmorException">When an armor can't be equipped</exception>
        public string Equip(Item item)
        {
            try
            {
                if (item.ItemSlot == Slot.WEAPON_SLOT)
                {
                    EquipWeapon((item as Weapon));
                    return "New weapon equipped!";
                }
                else
                {
                    EquipArmor((item as Armor));
                    this.totalPrimaryAttributes = this.basePrimaryAttributes + this.equipment.CalculateArmorAttributes();
                    return "New armor equipped!";
                }
            }
            catch (InvalidWeaponException ex)
            {
                throw new InvalidWeaponException(ex.Message);
            }
            catch (InvalidArmorException ex)
            {
                throw new InvalidArmorException(ex.Message);
            }
        }

        /// <summary>
        /// Increments the character's level by one.
        /// </summary>
        protected void IncrementLevelByOne()
        {
            this.characterLevel++;
        }

        /// <summary>
        /// Calculates the damage value of a character.
        /// </summary>
        /// <returns>Character's damage value rounded to two decimals</returns>
        public double Damage()
        {
            double weaponDPS = Equipment.GetWeaponDPS();

            switch (characterClass)
            {
                case characterClass.MAGE:
                    return Math.Round(weaponDPS * (1 + TotalPrimaryAttributes.Intelligence / 100.00), 2);
                case characterClass.RANGER:
                    return Math.Round(weaponDPS * (1 + TotalPrimaryAttributes.Dexterity / 100.00), 2);
                case characterClass.ROGUE:
                    return Math.Round(weaponDPS * (1 + TotalPrimaryAttributes.Dexterity / 100.00), 2);
                case characterClass.WARRIOR:
                    return Math.Round(weaponDPS * (1  + TotalPrimaryAttributes.Strength / 100.00), 2);
                default:
                    return 1.00;
            }
        }

        /// <summary>
        /// Prints and returns a summary of the character information.
        /// </summary>
        /// <returns>A multiline summary of the character information</returns>
        public string DisplayStats()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + this.characterName);
            sb.AppendLine("Level: " + this.characterLevel);
            sb.AppendLine("Strength: " +  this.totalPrimaryAttributes.Strength);
            sb.AppendLine("Dexterity: " + this.totalPrimaryAttributes.Dexterity);
            sb.AppendLine("Intelligence: " + this.totalPrimaryAttributes.Intelligence);
            sb.AppendLine("Damage: " + Damage());

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Increases charater's level and base primary attributes. Implementation is class specific.
        /// </summary>
        public abstract void LevelUp();

    }
}
