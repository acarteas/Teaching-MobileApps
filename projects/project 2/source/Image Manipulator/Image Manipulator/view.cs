﻿using Android.Graphics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Image_Manipulator
{
    [Activity(Label = "ViewImage")]
    public class ViewImage : Activity
    {
        void copy_bitmap(Bitmap original, Bitmap copy)
        {
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    int p = original.GetPixel(i, j);
                    Color c = new Color(p);
                    copy.SetPixel(i, j, c);
                }
            }
        }

        Bitmap remove_red (Bitmap image)
        {
            Bitmap mutable_copy = Bitmap.CreateBitmap(image.Width, image.Height, image.GetConfig());
            copy_bitmap(image, mutable_copy);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    int p = image.GetPixel(i, j);
                    Color c = new Color(p);
                    c.R = 0;
                    mutable_copy.SetPixel(i, j, c);
                }
            }
            return mutable_copy;
        }

        void remove_green(Bitmap image)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    int p = image.GetPixel(i, j);
                    Color c = new Color(p);
                    c.G = 0;
                    image.SetPixel(i, j, c);
                }
            }
        }

        void remove_blue(Bitmap image)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    int p = image.GetPixel(i, j);
                    Color c = new Color(p);
                    c.B = 0;
                    image.SetPixel(i, j, c);
                }
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view);

            //set up image input and make a copy
            ImageView imageView = FindViewById<ImageView>(Resource.Id.view_image);
            Bitmap bitmap = (Bitmap)Intent.GetParcelableExtra("image");
            imageView.SetImageBitmap(bitmap);
            Bitmap original_copy = Bitmap.CreateBitmap(bitmap.Width, bitmap.Height, bitmap.GetConfig());
            copy_bitmap(bitmap, original_copy);

            //buttons
            ImageButton btn_no_effect = FindViewById<ImageButton>(Resource.Id.button_no_effect);
            ImageButton btn_remove_red = FindViewById<ImageButton>(Resource.Id.button_remove_red);
            ImageButton btn_remove_green = FindViewById<ImageButton>(Resource.Id.button_remove_green);
            ImageButton btn_remove_blue = FindViewById<ImageButton>(Resource.Id.button_remove_blue);
            Button btn_apply = FindViewById<Button>(Resource.Id.btn_apply);

            btn_no_effect.Click += delegate
            {
                copy_bitmap(original_copy, bitmap);
                imageView.SetImageBitmap(bitmap);
            };

            btn_remove_red.Click += delegate
            {
                bitmap = remove_red(bitmap);
                imageView.SetImageBitmap(bitmap);
            };

            btn_remove_green.Click += delegate
            {
                remove_green(bitmap);
                imageView.SetImageBitmap(bitmap);
            };

            btn_remove_blue.Click += delegate
            {
                remove_blue(bitmap);
                imageView.SetImageBitmap(bitmap);
            };

            System.GC.Collect();
        }
    }
}