using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Provider;

namespace Image_Manipulator
{
    [Activity(Label = "Image_Manipulator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        string filepath;
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
                FindViewById<Button>(Resource.Id.btn_take_picture).Click += TakePicture;
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
            filepath = _file.AbsolutePath;
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
            Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
           // Android.Graphics.Bitmap copyBitmap =
             //   bitmap.Copy(Android.Graphics.Bitmap.Config.Argb8888, true);






            var to_send = new Intent(this, typeof(ViewImage));

            to_send.PutExtra("image", bitmap);
            StartActivity(to_send);



            //Make image available in the gallery
            /*
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            var contentUri = Android.Net.Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);
            */


        }
    }
}

