using Android.App;
using Android.Widget;
using Android.OS;
namespace calculator
{
    [Activity(Label = "Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        char op;
        bool is_num = false;
        

        void handler()
        {
            is_num = true;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
 
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button pressed0 = FindViewById<Button>(Resource.Id.Button0);
            Button pressed1 = FindViewById<Button>(Resource.Id.Button1);
            Button pressed2 = FindViewById<Button>(Resource.Id.Button2);
            Button pressed3 = FindViewById<Button>(Resource.Id.Button3);
            Button pressed4 = FindViewById<Button>(Resource.Id.Button4);
            Button pressed5 = FindViewById<Button>(Resource.Id.Button5);
            Button pressed6 = FindViewById<Button>(Resource.Id.Button6);
            Button pressed7 = FindViewById<Button>(Resource.Id.Button7);
            Button pressed8 = FindViewById<Button>(Resource.Id.Button8);
            Button pressed9 = FindViewById<Button>(Resource.Id.Button9);
            Button pressedplus = FindViewById<Button>(Resource.Id.Buttonplus);
            Button pressedsub = FindViewById<Button>(Resource.Id.Buttonsub);
            Button pressedmult = FindViewById<Button>(Resource.Id.Buttonmult);
            Button presseddiv = FindViewById<Button>(Resource.Id.Buttondiv);

            pressed0.Click += delegate
            {
                handler();
            };
            pressed1.Click += delegate
            {
                handler();
            };
            pressed2.Click += delegate
            {
                handler();
            };
            pressed3.Click += delegate
            {
                handler();
            };
            pressed4.Click += delegate
            {
                handler();
            };
            pressed5.Click += delegate
            {
                handler();
            };
            pressed6.Click += delegate
            {
                handler();
            };
            pressed7.Click += delegate
            {
                handler();
            };
            pressed8.Click += delegate
            {
                handler();
            };
            pressed9.Click += delegate
            {
                handler();
            };
        }
    }
}