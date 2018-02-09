using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Provider;
using Android.Graphics;
using System.IO;

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

        public static Bitmap bitmap;
        public static Bitmap copy_bitmap;

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

           //Starts the function imageEdit
           FindViewById<Button>(Resource.Id.btn_editor).Click += imageEdit;
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
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "CameraExample");
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
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));
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

            ////Make image available in the gallery
            //Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            //var contentUri = Android.Net.Uri.FromFile(_file);
            //mediaScanIntent.SetData(contentUri);
            //SendBroadcast(mediaScanIntent);

            
            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume too much memory
            // and cause the application to crash.
            ImageView imageView = FindViewById<ImageView>(Resource.Id.takenPictureImageView);
            int height = Resources.DisplayMetrics.HeightPixels;
            int width = imageView.Height;
            //bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            //copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);



           
                //AC: workaround for not passing actual files
                bitmap = (Bitmap)data.Extras.Get("data");
                Bitmap copyBitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
            

            //this code removes all red from a picture

            //for (int i = 0; i < bitmap.Width; i++)
            //{
            //    for (int j = 0; j < bitmap.Height; j++)
            //    {
            //        int p = bitmap.GetPixel(i, j);
            //        Color c = new Color(p);
            //        c.R = 0;
            //        copyBitmap.SetPixel(i, j, c);
            //    }
            //}

            SetContentView(Resource.Layout.Editor);

            ImageView editView = FindViewById<ImageView>(Resource.Id.editImage);
            int height2 = Resources.DisplayMetrics.HeightPixels;
            int width2 = editView.Height;

            // Bitmap copyBitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
            // Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            if (copy_bitmap != null)
            {
                editView.SetImageBitmap(copy_bitmap);
                // editView.Visibility = Android.Views.ViewStates.Visible;
            }

            //if (copy_bitmap != null)
            //{
            //    imageView.SetImageBitmap(copy_bitmap);
            //    imageView.Visibility = Android.Views.ViewStates.Visible;
            //    bitmap = null;
            //    copy_bitmap = null;
            //}

            // Dispose of the Java side bitmap.
            System.GC.Collect();
        }
        

        //This function changes our layout to the Editor and opens our image there for editing
        private void imageEdit(object sender, System.EventArgs e)
        {
            SetContentView(Resource.Layout.Editor);

            ImageView editView = FindViewById<ImageView>(Resource.Id.editImage);
            int height = Resources.DisplayMetrics.HeightPixels;
            int width = editView.Height;

            // Bitmap copyBitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
            // Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            if (copy_bitmap != null)
            {
                editView.SetImageBitmap(copy_bitmap);
                // editView.Visibility = Android.Views.ViewStates.Visible;
            }

        }

        private void removeRed()
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int p = bitmap.GetPixel(i, j);
                    Color c = new Color(p);
                    c.R = 0;
                    copy_bitmap.SetPixel(i, j, c);
                }
            }
        }

        private void removeBlue()
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int p = bitmap.GetPixel(i, j);
                    Color c = new Color(p);
                    c.B = 0;
                    copy_bitmap.SetPixel(i, j, c);
                }
            }
        }

        private void removeGreen()
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int p = bitmap.GetPixel(i, j);
                    Color c = new Color(p);
                    c.G = 0;
                    copy_bitmap.SetPixel(i, j, c);
                }
            }
        }

        private void negateRed()
        {

        }
        private void negateBlue()
        {

        }
        private void negateGreen()
        {

        }

        private void grayScale()
        {

        }

        private void highContrast()
        {

        }

        private void addNoise()
        {

        }

    }
}

