using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Image_Manipulator
{
    [Activity(Label = "ViewImage")]
    public class ViewImage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view);
            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume too much memory
            // and cause the application to crash.
            ImageView imageView = FindViewById<ImageView>(Resource.Id.view_image);
            //int height = Resources.DisplayMetrics.HeightPixels;
            //int width = imageView.Height;

            //AC: workaround for not passing actual files
            //Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
            //Android.Graphics.Bitmap copyBitmap =
            //    bitmap.Copy(Android.Graphics.Bitmap.Config.Argb8888, true);

            //this code removes all red from a picture

            Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)Intent.GetParcelableExtra("image");

            imageView.SetImageBitmap(bitmap);
            /*
            Android.Graphics.Bitmap copyBitmap =
                bitmap.Copy(Android.Graphics.Bitmap.Config.Argb8888, true);


            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
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
            */
            // Dispose of the Java side bitmap.
            System.GC.Collect();
        }
    }
}