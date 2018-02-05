using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

namespace CameraApp
{   
    //creating a new static class with variables
    //do no forget to give permission to app to access external memory
    //and camera in manifest
    public static class App
    {
        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;

    }
    [Activity(Label = "CameraApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;


        //after class is created and permissions are given we need to update this OnCreate
        //function 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };


            
            //Good and helpful references to help with camera app.
            //https://developer.xamarin.com/api/type/Android.Hardware.Camera/
            //http://www.c-sharpcorner.com/article/creating-a-camera-app-in-xamarin-android-app-using-visual-studio-2015/

        }
    }
}

