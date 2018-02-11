using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Provider;
using Android.Graphics;
using System;

namespace CameraExample
{
    [Activity(Label = "CameraExample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        /// <summary>
        /// Used to track the file that we're manipulating between functions
        /// </summary>
        public static Java.IO.File _file;        /// <summary>
        /// Used to track the directory that we'll be writing to between functions
        /// </summary>
        public static Java.IO.File _dir;

        public static Bitmap bitmap;
        public static Bitmap copy_bitmap;

        bool box_checked = false;
        bool box_checked2 = false;
        bool box_checked3 = false;
        bool box_checked4 = false;
        bool box_checked5 = false;
        bool box_checked7 = false;
        bool box_checked8 = false;
        bool box_checked9 = false;
        bool box_checked6 = false;


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
            int height = imageView.Height;
            int width = imageView.Width;
            bitmap = _file.Path.LoadAndResizeBitmap(width, height);
            copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);

           
                //AC: workaround for not passing actual files
               // bitmap = (Bitmap)data.Extras.Get("data");
               // copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
            

            //this code removes all red from a picture

            //for (int i = 0; i < bitmap.Width; i++)n 
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

            FindViewById<Button>(Resource.Id.remRed).Click += removeRed;
            FindViewById<Button>(Resource.Id.remBlue).Click += removeBlue;
            FindViewById<Button>(Resource.Id.remGreen).Click += removeGreen;
            FindViewById<Button>(Resource.Id.negRed).Click += negateRed;
            FindViewById<Button>(Resource.Id.negBlue).Click += negateBlue;
            FindViewById<Button>(Resource.Id.negGreen).Click += negateGreen;
        }
        

        //This function changes our layout to the Editor and opens our image there for editing
        //private void imageEdit(object sender, System.EventArgs e)
        //{
        //    SetContentView(Resource.Layout.Editor);

        //    ImageView editView = FindViewById<ImageView>(Resource.Id.editImage);
        //    int height = Resources.DisplayMetrics.HeightPixels;
        //    int width = editView.Height;

        //    // Bitmap copyBitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
        //    // Android.Graphics.Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height);
        //    if (copy_bitmap != null)
        //    {
        //        editView.SetImageBitmap(copy_bitmap);
        //        // editView.Visibility = Android.Views.ViewStates.Visible;
        //    }

        //}
        private void removeRed(object sender, System.EventArgs e)
        {           
            if (box_checked == false)
            {
                box_checked = true;
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
            else
            {
                copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
                box_checked = false;
            }
        }

        private void removeBlue(object sender, System.EventArgs e)
        {
            if (box_checked2 == false)
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
            else
            {
                copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
                box_checked2 = false;
            }
        }

        private void removeGreen(object sender, System.EventArgs e)
        {
            if (box_checked3 == false)
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
            else
            {
                copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
                box_checked3 = false;
            }
        }

        private void negateRed(object sender, System.EventArgs e)
        {
            if (box_checked4 == false)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        int p = bitmap.GetPixel(i, j);
                        Color c = new Color(p);
                        c.R = Convert.ToByte(255 - c.R);
                        copy_bitmap.SetPixel(i, j, c);
                    }
                }
            }
            else
            {
                copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
                box_checked4 = false;
            }
        }
        private void negateBlue(object sender, System.EventArgs e)
        {
            if (box_checked5 == false)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        int p = bitmap.GetPixel(i, j);
                        Color c = new Color(p);
                        c.B = Convert.ToByte(255 - c.B);
                        copy_bitmap.SetPixel(i, j, c);
                    }
                }
            }
            else
            {
                copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
                box_checked5 = false;
            }
        }
        private void negateGreen(object sender, System.EventArgs e)
        {
            if (box_checked6 == false)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        int p = bitmap.GetPixel(i, j);
                        Color c = new Color(p);
                        c.G = Convert.ToByte(255 - c.G);
                        copy_bitmap.SetPixel(i, j, c);
                    }
                }
            }
            else
            {
                copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
                box_checked6 = false;
            }
        }

        private void grayScale(object sender, System.EventArgs e)
        {
            if (box_checked7 == false)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        int p = bitmap.GetPixel(i, j);
                        Color c = new Color(p);
                        int clr_gray = (c.R + c.G + c.B) / 3;
                        c.R = Convert.ToByte(clr_gray);
                        c.B = Convert.ToByte(clr_gray);
                        c.G = Convert.ToByte(clr_gray);
                        copy_bitmap.SetPixel(i, j, c);
                    }
                }
            }
            else
            {
                copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
                box_checked7 = false;
            }
        }

        private void highContrast(object sender, System.EventArgs e)
        {
            if (box_checked8 == false)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        int p = bitmap.GetPixel(i, j);
                        Color c = new Color(p);
                        
                        if(c.R > 150)
                        {
                            c.R = 255;
                        }
                        else
                        {
                            c.R = 0;
                        }
                        if (c.B > 150)
                        {
                            c.B = 255;
                        }
                        else
                        {
                            c.B = 0;
                        }
                        if (c.G > 150)
                        {
                            c.G = 255;
                        }
                        else
                        {
                            c.G = 0;
                        }

                        copy_bitmap.SetPixel(i, j, c);
                    }
                }
            }
            else
            {
                copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
                box_checked8 = false;
            }
        }

        private void addNoise(object sender, System.EventArgs e)
        {
            if (box_checked9 == false)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        int p = bitmap.GetPixel(i, j);
                        Color c = new Color(p);
                        Random add_to_color = new Random();
                        c.R = Convert.ToByte(add_to_color.Next(-10, 10) + c.R);
                        c.B = Convert.ToByte(add_to_color.Next(-10, 10) + c.B);
                        c.G = Convert.ToByte(add_to_color.Next(-10, 10) + c.G);

                        if (c.R > 255)
                        {
                            c.R = 255;
                        }
                        else if(c.R < 0)
                        {
                            c.R = 0;
                        }
                        if (c.B > 255)
                        {
                            c.B = 255;
                        }
                        else if (c.B < 0)
                        {
                            c.B = 0;
                        }
                        if (c.G > 255)
                        {
                            c.G = 255;
                        }
                        else if (c.G < 0)
                        {
                            c.G = 0;
                        }
                        copy_bitmap.SetPixel(i, j, c);
                    }
                }
            }
            else
            {
                copy_bitmap = bitmap.Copy(Bitmap.Config.Argb8888, true);
                box_checked9 = false;
            }
        }

    }
}

