using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Provider;
using Android.Views;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;
using Google.Apis.Services;
using System;


// TODO: have the choose image from gallery working, but have to get the chosen image to the actual image view without crashing??
//       Also, how is the Google Vision API authenticated (called upon?)

namespace ImageGuess
{
    [Activity(Label = "ImageGuess", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        //Button correctResultBtn;

        public static Java.IO.File _file;
        public static Java.IO.File _dir;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build()); 
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            if (IsThereAnAppToTakePictures() == true)
            {
                FindViewById<Button>(Resource.Id.launchCameraButton).Click += TakePicture;
            }

            var gallery_button = FindViewById<Button>(Resource.Id.imageGallery);

            // asks user whether they would like to choose an image from their gallery
            gallery_button.Click += delegate
            {
                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };

            // displays a successful toast if the image was guessed correctly
            Button ackYesButton = (Button)FindViewById(Resource.Id.ackYesButton);
            
            ackYesButton.Click += delegate
            {
                Toast.MakeText(this, "Success! The image was guessed successfully!", ToastLength.Long).Show();
            };

            // correctResultBtn = (Button)FindViewById(Resource.Id.ackNoButton);
            Button correctResultBtn = FindViewById<Button>(Resource.Id.ackNoButton);
            correctResultBtn.Click += CorrectResultBtn_Click;
        }

        // Once the "No" button is clicked, this should navigate us to the next Activity
        private void CorrectResultBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CorrectAnswer));
            StartActivity(intent);
        }

        /// <summary>
        /// Apparently, some android devices do not have a camera.  To guard against this,
        /// we need to make sure that we can take pictures before we actually try to take a picture.
        /// </summary>
        /// <returns></returns>
        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities
                (intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }


        // creates a directory for images that have been taken
        private void CreateDirectoryForPictures()
        {
            _dir = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures), "ImageGuess");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }

        // accesses the device camera to take a picture 
        private void TakePicture(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new Java.IO.File(_dir, string.Format("myPhoto_{0}.jpg", System.Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));
            StartActivityForResult(intent, 0);
        }

        // <summary>
        // Called automatically whenever an activity finishes
        // </summary>
        // <param name = "requestCode" ></ param >
        // < param name="resultCode"></param>
        // <param name="data"></param>
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // send to image gallery
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            var contentUri = Android.Net.Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume too much memory
            // and cause the application to crash.

                ImageView imageView = FindViewById<ImageView>(Resource.Id.takenPictureImageView);
                int height = Resources.DisplayMetrics.HeightPixels;
                int width = imageView.Height;

            Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);

            if (resultCode == Result.Ok)
            {
                // var imageView = FindViewById<ImageView>(Resource.Id.takenPictureImageView);
                imageView.SetImageURI(data.Data);
            }
            

            //AC: workaround for not passing actual files
            //Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");

            //convert bitmap into stream to be sent to Google API
            string bitmapString = "";
            using (var stream = new System.IO.MemoryStream())
            {
                bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, stream);

                var bytes = stream.ToArray();
                bitmapString = System.Convert.ToBase64String(bytes);
            } 

            //credential is stored in "assets" folder
            string credPath = "CS 480 Project 3-4902c188226f.json";
            Google.Apis.Auth.OAuth2.GoogleCredential cred;

            //Load credentials into object form
            using (var stream = Assets.Open(credPath))
            {
                cred = Google.Apis.Auth.OAuth2.GoogleCredential.FromStream(stream);
            }
            cred = cred.CreateScoped(Google.Apis.Vision.v1.VisionService.Scope.CloudPlatform);

            // By default, the library client will authenticate 
            // using the service account file (created in the Google Developers 
            // Console) specified by the GOOGLE_APPLICATION_CREDENTIALS 
            // environment variable. We are specifying our own credentials via json file.
            var client = new Google.Apis.Vision.v1.VisionService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                ApplicationName = "cs-480-project-3",
                HttpClientInitializer = cred
            });

            //set up request
            var request = new Google.Apis.Vision.v1.Data.AnnotateImageRequest();
            request.Image = new Google.Apis.Vision.v1.Data.Image();
            request.Image.Content = bitmapString;

            //tell google that we want to perform label detection
            request.Features = new List<Google.Apis.Vision.v1.Data.Feature>();
            request.Features.Add(new Google.Apis.Vision.v1.Data.Feature() { Type = "LABEL_DETECTION" });
            var batch = new Google.Apis.Vision.v1.Data.BatchAnnotateImagesRequest();
            batch.Requests = new List<Google.Apis.Vision.v1.Data.AnnotateImageRequest>();
            batch.Requests.Add(request);

            //send request.  Note that I'm calling execute() here, but you might want to use
            //ExecuteAsync instead
            var apiResult = client.Images.Annotate(batch).ExecuteAsync();

            if (bitmap != null)
            {
                imageView.SetImageBitmap(bitmap);
                imageView.Visibility = Android.Views.ViewStates.Visible;
                bitmap = null;
            }

            // Dispose of the Java side bitmap.
            System.GC.Collect();
        }
    }
}