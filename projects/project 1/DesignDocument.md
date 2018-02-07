# APPLICATION NAME - JACK KINNE, P1, CEASAR CIPHER
This application was written to translate either plain text into text that has been encoded with a ceasar cipher, or unencrypt ceasar cipher text that you know the offset too.  It allows you to set your own offset value.  This translated text can be copied to other applications.  
I wrote this application specifically because, at first, everyone was making a calculator and I wanted something different that I could actually use.  And with this Cipher app, I can send encoded texts!
And if I give the app to a few friends, well that's just kind of cool.
It's not as secure as a one time pad, or different cipher schema, but I felt that this project was of the appropriate size and complexity while still offering practical utility.

## System Design 

Requires permission from user for VIBRATE function ; for haptic feedback.
uses the Theme.Material.Light.DarkActionBar ; for GUI awesomeness.
Emulated on Android_Accellerated_x86_Nougat (Android 7.1 API 25).

Four Functions have been written.
BacktoEnglish() : Takes text, harvests the selected offset, encodes and replaces text, as well as sending a toast and vibrating phone.

translateMe() : Takes text, harvests the selected offset and REVERSES IT, decodes and replaces text, as well as sending a toast and vibrating phone.

chiper() : contains the logic to apply the cipher.  private, skips spaces and periods.  limited to two characters long for entry.  

harvestOffset() : Grabs offset value from entry, tests for null, returns 0 if it has not be set, returns value if it has.

Screenshots attached!

## Usage
Usage of the app is simple.  Type the text you want translated into the application.  Enter your Cipher Offset Value.  
You can encrypt and then immediately decrypt with accuracy.  
You can flip back and forth between buttons with no errors; from decrypted to encrypted text.  
You can encrypt multiple times with different offset values.
You can select all text and copy.

