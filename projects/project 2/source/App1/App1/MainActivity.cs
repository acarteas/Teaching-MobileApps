using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Provider;
//using App1;

namespace Camera_app
{
    [Activity(Label = "Camera_app", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        public static Java.IO.File _file;
        public static Java.IO.File _dir;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            if (Canwetakeapic() == true)
            {
                Dir_for_pics();
                FindViewById<Button>(Resource.Id.button1).Click += Takingpic;
            }

        }

        private bool Canwetakeapic()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities
                (intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void Dir_for_pics()
        {
            _dir = new Java.IO.File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "Picture");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }

        private void Takingpic(object sender, System.EventArgs e)
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

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            ImageView _thePic = FindViewById<ImageView>(Resource.Id.PictureTaken);
            //int height = Resource.
            int height = Resources.DisplayMetrics.HeightPixels;
            //int height = Resources.DisplayMetrics.HeightPixels;
            //int height = (Resource.DisplayMetrics as Android.Util.DisplayMetrics).HeightPixels;
            int width = _thePic.Height;

            Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
            Android.Graphics.Bitmap copyBitmap = bitmap.Copy(Android.Graphics.Bitmap.Config.Alpha8, true);

            for(int i = 0; i < copyBitmap.Width; i++)
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
                _thePic.SetImageBitmap(bitmap);
                _thePic.Visibility = Android.Views.ViewStates.Visible;
                bitmap = null;
            }
            System.GC.Collect();
        }
    }
}

