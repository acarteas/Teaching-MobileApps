# Post Mortem
When working on project three I had the idea to make this application. I wasn’t sure it would work out so it was kind of an experiment. I’m happy it works somewhat, though I would have really liked to draw graphics to the screen highlighting the word after it was found. Unfortunately I have no idea how I could do that and have no idea where to start. Still, the app is functional. It seems to find text faster than I can with my eyes so it is useful.

In the future I’d like to optimize the code that trims the block of detected text into your found word, and some surrounding text. The faster this code is the better the program is. I’m sure there is a much faster way to do this that I have not figured out. The app would run better with less delay.

The biggest struggle was working through the documentation. It was much better than the Cloud Vision API documentation, but still I struggle with it. Here is a link to the documentation I used:
https://developers.google.com/android/reference/com/google/android/gms/vision/package-summary

I was able to mostly go through and implement each method if it was necessary. The camerasource.builder had directions showing everything that was needed, so I just had to work from there. There were some strange requirements like a SparseArray and TextBlock that I made work, but they seemed unnecessary.

Overall the Mobile Vision API was a lot easier to work with than the Cloud Vision API. I actually developed this application first using the Cloud Vision API but you had to take a picture and upload it. When looking for documentation for the Cloud Vision API I found the Mobile Vision API documentation and found the CameraSource object, and really wanted to experiment with it.

This is my second project with Android Studio and I am definitely sticking with it. There are less bugs and less problems. The documentation is also better. It also does a lot of autocompletion and suggestions that are very useful. My code looks a lot more professional and handles errors better thanks to these suggestions.

It was fun to pick a project or expand on another one. I’m glad I was able to start this project early and put a lot of time into it. With spring break and the next project it would have been hard to get this done if I hadn’t gotten ahead.
