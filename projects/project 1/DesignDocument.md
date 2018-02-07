# Dice Roller
This application is designed to roll multiple (up to 20 at a time) dice of any number of sides. The primary use case I imagined while making it is during tabletop rpgs such as Dungeons and Dragons or Dark Heresy (a game that I dm). I intend to actually use this app in cases where I've forgotten where I left my dice.

## System Design 
I chose Android 7.1 as my target version of Android mostly arbitrarily. The actual layout of the app and input is based on the common (among tabletop rpgs) abreviation of dice rolls that follows the format "x dy", in which x and y are any two numbers. The first number, x, is the number of dice. The second number, y, is the number of sides on each of the dice. (ex. two ten-sided dice = 2 d10 or just 2d10)

## Usage
The app should be mostly self explanatory but I don't actually know much about ux design. There are two sets of number input buttons. The first decides the number of dice and the second the number of sides on each of them. When you click the button labeled roll the dice inputted will be rolled and you will be shown both the individual rolls and the total of all the rolls. The button below the roll button is the last roll button. This will show the results of the last roll you made.
