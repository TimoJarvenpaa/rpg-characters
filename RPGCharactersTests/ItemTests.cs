using RPGCharacters.Attributes;
using RPGCharacters.Characters;
using RPGCharacters.Items;
using System;
using System.Text;
using Xunit;

namespace RPGCharactersTests
{
    public class ItemTests
    {
        #region Insufficient level requirement
        [Fact]
        public void Equip_WeaponLevelHigherThanCharacterLevel_ShouldThrowInvalidWeaponException()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            WeaponAttributes weaponAttributes = new WeaponAttributes(7, 1.1);
            Weapon testAxe = new Weapon("Common axe", 2, Slot.WEAPON_SLOT, WeaponType.WEAPON_AXE, weaponAttributes);
            // Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.equip(testAxe));
        }
        [Fact]
        public void Equip_ArmorLevelHigherThanCharacterLevel_ShouldThrowInvalidArmorException()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            PrimaryAttributes armorAttributes = new PrimaryAttributes(1, 0, 0);
            Armor testPlateBody = new Armor("Common plate body armor", 2, Slot.BODY_SLOT, ArmorType.ARMOR_PLATE, armorAttributes);
            // Act & Assert
            Assert.Throws<InvalidArmorException>(() => warrior.equip(testPlateBody));
        }
        #endregion

        #region Wrong item type for a specific class
        [Fact]
        public void Equip_WrongWeaponType_ShouldThrowInvalidWeaponException()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            WeaponAttributes weaponAttributes = new WeaponAttributes(12, 0.8);
            Weapon testBow = new Weapon("Common bow", 1, Slot.WEAPON_SLOT, WeaponType.WEAPON_BOW, weaponAttributes);
            // Act & Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.equip(testBow));
        }

        [Fact]
        public void Equip_WrongArmorType_ShouldThrowInvalidArmorException()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            PrimaryAttributes armorAttributes = new PrimaryAttributes(0, 0, 5);
            Armor testClothHead = new Armor("Common cloth head armor", 1, Slot.HEAD_SLOT, ArmorType.ARMOR_CLOTH, armorAttributes);
            // Act & Assert
            Assert.Throws<InvalidArmorException>(() => warrior.equip(testClothHead));
        }
        #endregion

        #region Valid item equipped
        [Fact]
        public void Equip_ValidWeapon_ShouldReturnSuccessMessage()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            WeaponAttributes weaponAttributes = new WeaponAttributes(7, 1.1);
            Weapon testAxe = new Weapon("Common axe", 1, Slot.WEAPON_SLOT, WeaponType.WEAPON_AXE, weaponAttributes);
            string expected = "New weapon equipped!";
            // Act
            string actual = warrior.equip(testAxe);
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Equip_ValidArmor_ShouldReturnSucceessMessage()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            PrimaryAttributes armorAttributes = new PrimaryAttributes(1, 0, 0);
            Armor testPlateBody = new Armor("Common plate body armor", 1, Slot.BODY_SLOT, ArmorType.ARMOR_PLATE, armorAttributes);
            string expected = "New armor equipped!";
            // Act
            string actual = warrior.equip(testPlateBody);
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Damage calculations
        [Fact]
        public void Damage_WithoutWeapon_ShouldBeCorrect()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            double expected = Math.Round(1.00 * (1 + (5 / 100.00)), 2);
            // Act
            double actual = warrior.Damage();
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_WithValidWeapon_ShouldBeCorrect()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            WeaponAttributes weaponAttributes = new WeaponAttributes(7, 1.1);
            Weapon testAxe = new Weapon("Common axe", 1, Slot.WEAPON_SLOT, WeaponType.WEAPON_AXE, weaponAttributes);
            warrior.equip(testAxe);
            double expected = Math.Round((7 * 1.1) * (1 + (5 / 100.00)), 2);
            // Act
            double actual = warrior.Damage();
            // Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_WithValidWeaponAndArmor_ShouldBeCorrect()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            WeaponAttributes weaponAttributes = new WeaponAttributes(7, 1.1);
            Weapon testAxe = new Weapon("Common axe", 1, Slot.WEAPON_SLOT, WeaponType.WEAPON_AXE, weaponAttributes);
            PrimaryAttributes armorAttributes = new PrimaryAttributes(1, 0, 0);
            Armor testPlateBody = new Armor("Common plate body armor", 1, Slot.BODY_SLOT, ArmorType.ARMOR_PLATE, armorAttributes);
            warrior.equip(testAxe);
            warrior.equip(testPlateBody);
            double expected = Math.Round((7 * 1.1) * (1 + ((5 + 1) / 100.00)), 2);
            // Act
            double actual = warrior.Damage();
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Stats display
        [Fact]
        public void DisplayStats_Level2WarriorWithWeaponAndArmor_ShouldDisplayCorrectStats()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            warrior.LevelUp();
            WeaponAttributes weaponAttributes = new WeaponAttributes(7, 1.1);
            Weapon testAxe = new Weapon("Common axe", 1, Slot.WEAPON_SLOT, WeaponType.WEAPON_AXE, weaponAttributes);
            PrimaryAttributes armorAttributes = new PrimaryAttributes(1, 0, 0);
            Armor testPlateBody = new Armor("Common plate body armor", 1, Slot.BODY_SLOT, ArmorType.ARMOR_PLATE, armorAttributes);
            warrior.equip(testAxe);
            warrior.equip(testPlateBody);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: TestWarrior");
            sb.AppendLine("Level: 2");
            sb.AppendLine("Strength: 9");
            sb.AppendLine("Dexterity: 4");
            sb.AppendLine("Intelligence: 2");
            sb.AppendLine("Damage: 8,39");
            string expected = sb.ToString();

            // Act
            string actual = warrior.DisplayStats();
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

    }
}
