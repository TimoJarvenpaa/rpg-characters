# RPG Characters

![GitHub repo size](https://img.shields.io/github/repo-size/TimoJarvenpaa/rpg-characters)

[Class Diagram](Documentation/ClassDiagram.png)

## Table of Contents

- [General Information](#general-information)

- [Technologies](#technologies)

- [Installation and Usage](#installation-and-usage)

- [Contributors](#contributors)

## General Information

The project provides a [class structure](Documentation/ClassDiagram.png) that can be used to create and interact with basic RPG character classes including Mages, Rangers, Rogues and Warriors. The characters have attributes i.e. strength, dexterity and intelligence that will increase when the characters gain levels and which in turn will affect the damage the characters can deal.

The characters can also equip various types of weapons and armor depending on their class. Equipping weapons will significantly increase their damage output while armor provides additional attribute bonuses. Trying to equip items that the character can't use will result in a custom exception being thrown.

The project contains 20 unit tests that cover the public methods available to the character object. Full branch coverage wasn't achieved, however since the basic method functionality remains the same, it didn't feel worthwhile to e.g. test equipping every single weapon type on every single character class etc.

## Technologies

- C#
- .NET 5
- xUnit
- Visual Studio Class Designer

## Installation and Usage

The project doesn't contain a UI or any interactive features, but if you want to to experiment with it or run the unit tests, you can do the following:

1.) Clone the project ```git clone git@github.com:TimoJarvenpaa/rpg-characters.git```

2.) Open Visual Studio > Select 'Open a project or solution' > Find the project directory and select the **RPGCharacters.sln** file

3.) The project should load and be ready for use. You might need to clean/build the solution once to get it working.


## Contributors

[Timo Järvenpää (@TimoJarvenpaa)](https://github.com/TimoJarvenpaa)
