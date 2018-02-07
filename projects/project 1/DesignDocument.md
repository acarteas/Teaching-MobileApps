# NOTE
I created 2 applications. First, I created a character counter app to introduce me to C# and Xamarin. This app while being very simple, functions flawlessly. I then developed my calculator app. This app demonstrates my abilities to make apps but lacks correct functionality. The calculator app shows my aptitude, not my skills. The character counter app shows my current skills and aptitude to learn and develop more.
# Calculator
Simple Postfix calculator. This calculator accepts single digit numbers and performs as a Reverse Polish simple four function calculator. It must be used strictly correctly otherwise it will error. This application serves scientists and other users of post fix notation who can adhere to rigid standards. 

## System Design 
Target: Android 7.1
Minimum: Android 5.0
Approx Size: 125 MB
Notes: System designed to fail with faulty input. Proper input is required for proper functionality.

## Usage
This calculator may only be used with single digit values (0-9). 
Furthermore, given invalid input (incorrectly formatted or wrong number of operands), application will fail.
Example: 5 3 2 * + should result in 11
Example: 3 2 - should result in 1

# Character Counter
A simple character counter that counts the number of characters entered into the text box. I made this application as a warm up for the calculator app. This program functions very cleanly and may be of use to someone wanting to know how long their text is in characters.

## System Design
Target: Android 7.1
Minimum: Android 5.0
Approx Size: 113 MB

## Usage
Enter text into the box to generate a message saying how long in characters the supplied text is.
Press clear to clear all characters from the text entry box.
Example - input of: four
	  should return 4
Example - input of: this many
	  should return 9