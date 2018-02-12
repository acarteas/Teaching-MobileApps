using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Provider;

namespace CameraExample
{
    [Activity(Label = "CameraExample", MainLauncher = true, Icon = "@mipmap/icon")]
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
                PackageManager.QueryIntentActivities
                (intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        /// <summary>
        /// Creates a directory on the phone that we can place our images
        /// </summary>
        private void CreateDirectoryForPictures()
        {
            _dir = new Java.IO.File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "CameraExample");
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
            //FileProvider.GetUriForFile

            //The line is a problem line for Android 7+ development
            //intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));
            StartActivityForResult(intent, 0);
        }

        // <summary>
        // Called automatically whenever an activity finishes
        // </summary>
        // <param name = "requestCode" ></ param >
        // < param name="resultCode"></param>
        /// <param name="data"></param>
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
            SetContentView(Resource.Layout.layout1);
            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume too much memory
            // and cause the application to crash.
            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageToAlter);
            int height = Resources.DisplayMetrics.HeightPixels;
            int width = imageView.Height;

            //AC: workaround for not passing actual files
            Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
            //Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            Android.Graphics.Bitmap copyBitmap = bitmap.Copy(Android.Graphics.Bitmap.Config.Argb8888, true);

            CheckBox redRemoval = FindViewById<CheckBox>(Resource.Id.redRemoval);
            CheckBox greenRemoval = FindViewById<CheckBox>(Resource.Id.greenRemoval);
            CheckBox blueRemoval = FindViewById<CheckBox>(Resource.Id.blueRemoval);
            CheckBox negativeCheck = FindViewById<CheckBox>(Resource.Id.negative);

            redRemoval.CheckedChange += negateRed();
            greenRemoval.CheckedChange += negateGreen();
            blueRemoval.CheckedChange += negateBlue();
            negativeCheck.CheckedChange += negateImage();

        }

       private void negateRed(object sender, System.EventArgs e)
        {
            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageToAlter);
            //AC: workaround for not passing actual files
            Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
            //Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            Android.Graphics.Bitmap copyBitmap = bitmap.Copy(Android.Graphics.Bitmap.Config.Argb8888, true);

            for (int i = 0; i < copyBitmap.Width; i++)
            {
                for (int j = 0; j < copyBitmap.Height; j++)
                {
                    int p = copyBitmap.GetPixel(i, j);
                    
                    Android.Graphics.Color c = new Android.Graphics.Color(p);
                    
                    c.R = 0;
                    copyBitmap.SetPixel(i, j, c);
                }
            }
            if (bitmap != null)
            {
                imageView.SetImageBitmap(bitmap);
                imageView.Visibility = Android.Views.ViewStates.Visible;
                bitmap = null;
            }

            // Dispose of the Java side bitmap.
            System.GC.Collect();
        }

        private void negateGreen(object sender, System.EventArgs e)
        {
            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageToAlter);
            //AC: workaround for not passing actual files
            Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
            //Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            Android.Graphics.Bitmap copyBitmap = bitmap.Copy(Android.Graphics.Bitmap.Config.Argb8888, true);

            for (int i = 0; i < copyBitmap.Width; i++)
            {
                for (int j = 0; j < copyBitmap.Height; j++)
                {
                    int p = copyBitmap.GetPixel(i, j);

                    Android.Graphics.Color c = new Android.Graphics.Color(p);

                    c.G = 0;
                    copyBitmap.SetPixel(i, j, c);
                }
            }
            if (bitmap != null)
            {
                imageView.SetImageBitmap(bitmap);
                imageView.Visibility = Android.Views.ViewStates.Visible;
                bitmap = null;
            }

            // Dispose of the Java side bitmap.
            System.GC.Collect();
        }

        private void negateBlue(object sender, System.EventArgs e)
        {
            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageToAlter);
            //AC: workaround for not passing actual files
            Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
            //Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            Android.Graphics.Bitmap copyBitmap = bitmap.Copy(Android.Graphics.Bitmap.Config.Argb8888, true);

            for (int i = 0; i < copyBitmap.Width; i++)
            {
                for (int j = 0; j < copyBitmap.Height; j++)
                {
                    int p = copyBitmap.GetPixel(i, j);

                    Android.Graphics.Color c = new Android.Graphics.Color(p);

                    c.B = 0;
                    copyBitmap.SetPixel(i, j, c);
                }
            }
            if (bitmap != null)
            {
                imageView.SetImageBitmap(bitmap);
                imageView.Visibility = Android.Views.ViewStates.Visible;
                bitmap = null;
            }

            // Dispose of the Java side bitmap.
            System.GC.Collect();
        }

        private void negateImage(object sender, System.EventArgs e)
        {
            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageToAlter);
            //AC: workaround for not passing actual files
            Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
            //Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            Android.Graphics.Bitmap copyBitmap = bitmap.Copy(Android.Graphics.Bitmap.Config.Argb8888, true);

            int r, g, b;
            //code found here: https://www.dyclassroom.com/csharp-project/how-to-convert-a-color-image-into-a-negative-image-in-csharp-using-visual-studio
            //needed to refresh memory on negating an image
            for (int i = 0; i < copyBitmap.Width; i++)
            {
                for (int j = 0; j < copyBitmap.Height; j++)
                {
                    int p = copyBitmap.GetPixel(i, j);

                    Android.Graphics.Color c = new Android.Graphics.Color(p);

                    r = c.R;
                    g = c.G;
                    b = c.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    copyBitmap.SetPixel(i, j, c.FromArgb(a, r, g, b));
                }
            }
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

