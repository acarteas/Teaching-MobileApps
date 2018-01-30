using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace PA1
{
    [Activity(Label = "PA1", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button b1 = FindViewById<Button>(Resource.Id.onebutton);
            Button b2 = FindViewById<Button>(Resource.Id.twobutton);
            Button b3 = FindViewById<Button>(Resource.Id.threebutton);
            Button b4 = FindViewById<Button>(Resource.Id.fourbutton);
            Button b5 = FindViewById<Button>(Resource.Id.fivebutton);
            Button b6 = FindViewById<Button>(Resource.Id.sixbutton);
            Button b7 = FindViewById<Button>(Resource.Id.sevenbutton);
            Button b8 = FindViewById<Button>(Resource.Id.eightbutton);
            Button b9 = FindViewById<Button>(Resource.Id.ninebutton);
            Button b0 = FindViewById<Button>(Resource.Id.zerobutton);


            b1.Click += AddNum;
            // Get our button from the layout resource,
            // and attach an event to it
            /*
               Button button = FindViewById<Button>(Resource.Id.myButton);

               button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            */
           
        }

        public void AddNum(object sender, EventArgs e)
        {
            Button the_button = sender as Button;
            TextView to_edit = FindViewById<TextView>(Resource.Id.IOtext);
            to_edit.Text = to_edit.Text + the_button.Text;
        }

    }
    
}   
  

