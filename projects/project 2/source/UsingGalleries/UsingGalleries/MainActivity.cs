using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Provider;

// https://developer.xamarin.com/recipes/android/data/files/selecting_a_gallery_image/

// For getting bitmaps from imageviews https://stackoverflow.com/questions/8306623/get-bitmap-attached-to-imageview

// Galleries implement works
// Lock screen rotation to prevent removal of images from view

namespace UsingGalleries
{
    [Activity(Label = "UsingGalleries", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button gb = FindViewById<Button>(Resource.Id.gallerybutton);
            Button dr = FindViewById<Button>(Resource.Id.redremove);

            gb.Click += delegate { var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                var imageView =
                    FindViewById<ImageView>(Resource.Id.myImageView);
                imageView.SetImageURI(data.Data);
            }
        }

    }

}

