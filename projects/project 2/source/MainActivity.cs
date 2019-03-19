using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Provider;
using Android.Speech;

namespace MultiFuncApp
{
    [Activity(Label = "MultiFuncApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        /// <summary>
        /// Used to track the file that we're manipulating between functions
        /// </summary>
        public static Java.IO.File _file;

        /// <summary>
        /// Used to track the directory that we'll be writing to between functions
        /// </summary>
        public static Java.IO.File _dir;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            if (IsThereAnAppToTakePictures() == true)
            {
                CreateDirectoryForPictures();
                FindViewById<Button>(Resource.Id.launchCameraButton).Click += TakePicture;
            }
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
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        /// <summary>
        /// Creates a directory on the phone that we can place our images
        /// </summary>
        private void CreateDirectoryForPictures()
        {
            _dir = new Java.IO.File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "MultiFuncApp");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }

        private void TakePicture(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new Java.IO.File(_dir, string.Format("myPhoto_{0}.jpg", System.Guid.NewGuid()));
            //android.support.v4.content.FileProvider
            //getUriForFile(getContext(), "com.mydomain.fileprovider", newFile);
            //FileProvider.GetUriForFile;

            //The line is a problem line for Android 7+ development
            //intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));
            StartActivityForResult(intent, 0);
        }

        // <summary>
        // Called automatically whenever an activity finishes
        // </summary>
        // <param name = "requestCode" ></ param >
        // < param name="resultCode"></param>
        // <param name="data"> </param>
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            //Make image available in the gallery
            /*
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            var contentUri = Android.Net.Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);
            */

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume too much memory
            // and cause the application to crash.
            ImageView imageView = FindViewById<ImageView>(Resource.Id.takenPictureImageView);
            int height = Resources.DisplayMetrics.HeightPixels;
            int width = imageView.Height;

            Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            // AC: workaround for not passing actual files
            //Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
            Android.Graphics.Bitmap copyBitmap = bitmap.Copy(Android.Graphics.Bitmap.Config.Argb8888, true);

            // removes all red from the picture
            for (int i = 0; i < bitmap.Width; i++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    int p = bitmap.GetPixel(i, j);
                    Android.Graphics.Color c = new Android.Graphics.Color(p);
                    c.R = 0;
                    copyBitmap.SetPixel(i, j, c);
                }
            }
            if (copyBitmap != null)
            {
                imageView.SetImageBitmap(copyBitmap);
                imageView.Visibility = Android.Views.ViewStates.Visible;
                bitmap = null;
                copyBitmap = null;
            }

            // removes all blue from the picture 
            for (int i = 0; i < bitmap.Width; i++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    int p = bitmap.GetPixel(i, j);
                    Android.Graphics.Color c = new Android.Graphics.Color(p);
                    c.B = 0;
                    copyBitmap.SetPixel(i, j, c);
                }
            }
            if (copyBitmap != null)
            {
                imageView.SetImageBitmap(copyBitmap);
                imageView.Visibility = Android.Views.ViewStates.Visible;
                bitmap = null;
                copyBitmap = null;
            }

            // removes all green from the picture
            for (int i = 0; i < bitmap.Width; i++)
            {
                for(int j = 0; j < bitmap.Height; j++)
                {
                    int p = bitmap.GetPixel(i, j);
                    Android.Graphics.Color c = new Android.Graphics.Color(p);
                    c.G = 0;
                    copyBitmap.SetPixel(i, j, c);
                }
            }

            if(copyBitmap != null)
            {
                imageView.SetImageBitmap(copyBitmap);
                imageView.Visibility = Android.Views.ViewStates.Visible;
                bitmap = null;
                copyBitmap = null;
            }

            // changes all the colors in the picture to high contrast
            for(int i = 0; i < bitmap.Height; i++)
            {
                for(int j = 0; j < bitmap.Width; j++)
                {
                    int p = bitmap.GetPixel(i, j);
                    Android.Graphics.Color c = new Android.Graphics.Color(p);

                    int red_pixel = c.R;
                    int green_pixel = c.B;
                    int blue_pixel = c.G;

                    if (red_pixel > (255 / 2) || green_pixel > (255 / 2) || blue_pixel > (255 / 2))
                    {
                        int r = bitmap.GetPixel(i, j);
                        c.R = 255;
                        c.G = 255;
                        c.B = 255;
                    }
                    else
                    {
                        int s = bitmap.GetPixel(i, j);
                        c.R = 0;
                        c.G = 0;
                        c.B = 0;
                    }
                }
            }

            // changes all the colors in the picture to grayscale

            for(int i = 0; i < bitmap.Height; i++)
            {
                for(int j = 0; j < bitmap.Width; j++)
                {
                    int p = bitmap.GetPixel(i, j);
                    Android.Graphics.Color c = new Android.Graphics.Color(p);
                    int red_pixel = c.R;
                    int green_pixel = c.G;
                    int blue_pixel = c.B;
                    red_pixel = (red_pixel + green_pixel + blue_pixel) / 3;
                    green_pixel = (red_pixel + green_pixel + blue_pixel) / 3;
                    blue_pixel = (red_pixel + green_pixel + blue_pixel) / 3;
                }
            }

            // adds random noise to all of the colors in the pictures

           /* for(int i = 0; i < bitmap.Height; i++)
            {
                for(int j = 0; j < bitmap.Width; j++)
                {
                    int random_pixel = rand % 21 + -10;
                    int random_red = 0, random_green = 0, random_blue = 0;
                }
            }
            */

            // Dispose of the Java side bitmap
            System.GC.Collect();
        }
    }
}


