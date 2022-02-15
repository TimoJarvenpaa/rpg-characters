using RPGCharacters.Attributes;
using RPGCharacters.Characters;
using System;
using Xunit;

namespace RPGCharactersTests
{
    public class CharacterTests
    {
        #region Character level
        [Fact]
        public void Creation_CreateNewCharacter_ShouldBeLevel1()
        {
            // Arrange
            Mage mage = new Mage("TestMage");
            int expected = 1;
            // Act
            int actual = mage.CharacterLevel;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelUp_NewCharacterLevelsUp_ShouldBeLevel2()
        {
            // Arrange
            Mage mage = new Mage("TestMage");
            mage.LevelUp();
            int expected = 2;
            // Act
            int actual = mage.CharacterLevel;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Default primary attributes
        [Fact]
        public void DefaultAttributes_NewMageAttributes_ShouldBeCorrect()
        {
            // Arrange
            Mage mage = new Mage("TestMage");
            PrimaryAttributes expected = new PrimaryAttributes(1, 1, 8);
            // Act
            PrimaryAttributes actual = mage.BasePrimaryAttributes;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DefaultAttributes_NewRangerAttributes_ShouldBeCorrect()
        {
            // Arrange
            Ranger ranger = new Ranger("TestRanger");
            PrimaryAttributes expected = new PrimaryAttributes(1, 7, 1);
            // Act
            PrimaryAttributes actual = ranger.BasePrimaryAttributes;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DefaultAttributes_NewRogueAttributes_ShouldBeCorrect()
        {
            // Arrange
            Rogue rogue = new Rogue("TestRogue");
            PrimaryAttributes expected = new PrimaryAttributes(2, 6, 1);
            // Act
            PrimaryAttributes actual = rogue.BasePrimaryAttributes;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DefaultAttributes_NewWarriorAttributes_ShouldBeCorrect()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            PrimaryAttributes expected = new PrimaryAttributes(5, 2, 1);
            // Act
            PrimaryAttributes actual = warrior.BasePrimaryAttributes;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Base primary attributes after a level up
        [Fact]
        public void BasePrimaryAttributes_AfterMageLevelsUp_ShouldBeCorrect()
        {
            // Arrange
            Mage mage = new Mage("TestMage");
            mage.LevelUp();
            PrimaryAttributes expected = new PrimaryAttributes(2, 2, 13);
            // Act
            PrimaryAttributes actual = mage.BasePrimaryAttributes;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BasePrimaryAttributes_AfterRangerLevelsUp_ShouldBeCorrect()
        {
            // Arrange
            Ranger ranger = new Ranger("TestRanger");
            ranger.LevelUp();
            PrimaryAttributes expected = new PrimaryAttributes(2, 12, 2);
            // Act
            PrimaryAttributes actual = ranger.BasePrimaryAttributes;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BasePrimaryAttributes_AfterRogueLevelsUp_ShouldBeCorrect()
        {
            // Arrange
            Rogue rogue = new Rogue("TestRogue");
            rogue.LevelUp();
            PrimaryAttributes expected = new PrimaryAttributes(3, 10, 2);
            // Act
            PrimaryAttributes actual = rogue.BasePrimaryAttributes;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BasePrimaryAttributes_AfterWarriorLevelsUp_ShouldBeCorrect()
        {
            // Arrange
            Warrior warrior = new Warrior("TestWarrior");
            warrior.LevelUp();
            PrimaryAttributes expected = new PrimaryAttributes(8, 4, 2);
            // Act
            PrimaryAttributes actual = warrior.BasePrimaryAttributes;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
