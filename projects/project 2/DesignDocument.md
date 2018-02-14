#Jack Kinne Project 2 - Cameras and Effects

Photo manipulation!  Two activities have been made, with six different full photo manipulation options on sliders.  Saving to external harddrive, and reverting to the orignal picture are enabled on the second activity.  Toasts are added on save, all known bugs have been removed.  Mutliple effects can be engaged at the same time.  Picture will not be lost!  Default picture is visible.

I wrote this application twice; once in Xamarin, and I wasn't happy with it.  So I made it again in Android Studio, and I'm pleased with the result.

#System Design
FIRST ACTIVITY PAGE:
the two buttons are:
1. "take photo" take a photo with the camera
2. "edit photo" pass a photo into the second activity

SECOND ACTIVITY PAGE: 
1. "apply effects" with apply any currently chosen switches.  
2. "revert photo" which returns the image to its original format.
3. "save" which saves photo to external storage.

Six switches are:
1. Highlight effect
2. Grayscale effect
3. Gamma effect
4. Sepia effect
5. Flip vertical
6. Flip horizontal

#Usage
In the first activity, we see a default image and two buttons.
The first button, "take picture" takes a picture with the camera.  You can view the results before you continue.  The second button, "edit Photo" takes you (and transfers the picture) to the second activity.

In the second activity we see the transfered photo, six switches with multiple image effects on the bottom of the screen, and three buttons.

apply any effects you wish by clicking the appropriate switch.  

It is possible to select and apply multiple effects at the same time--they are independently applied in a casscade from top to bottom.

press the "apply effects" button to apply.

If you wish to go back to a clean copy of hte photo, press the "revert photo" button.  All switches will revert to off, and the photo will be restored.

to save your modified photo to external storage, press the "save" button.  A toast will trigger that displays this save success.