using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "Postfix Calculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        string str_input = null;
        string str_output = null;
        string input_box; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button1  = FindViewById<Button>(Resource.Id.Button1);
            Button button2 = FindViewById<Button>(Resource.Id.Button2);
            Button button3 = FindViewById<Button>(Resource.Id.Button3);
            Button button4 = FindViewById<Button>(Resource.Id.Button4);
            Button button5 = FindViewById<Button>(Resource.Id.Button5);
            Button button6 = FindViewById<Button>(Resource.Id.Button6);
            Button button7 = FindViewById<Button>(Resource.Id.Button7);
            Button button8 = FindViewById<Button>(Resource.Id.Button8);
            Button button9 = FindViewById<Button>(Resource.Id.Button9);
            Button button0 = FindViewById<Button>(Resource.Id.Button0);
            Button buttonClear = FindViewById<Button>(Resource.Id.ButtonClear);
            Button buttonADD = FindViewById<Button>(Resource.Id.ButtonPlus);
            Button buttonSubtract = FindViewById<Button>(Resource.Id.ButtonMinus);
            Button buttonMultiply = FindViewById<Button>(Resource.Id.ButtonMultiply);
            Button buttonDivide = FindViewById<Button>(Resource.Id.ButtonDivide);
            Button buttonInvert = FindViewById<Button>(Resource.Id.ButtonInvert);
            
            var input_box = FindViewById(Resource.Id.calculatorbox);


            button1.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '1';
                this.str_output += '1';
                input_box.Text = this.str_output; 
            };

            button2.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '2';
                this.str_output += '2';
                input_box.Text = this.str_output;
            };

            button3.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '3';
                this.str_output += '3';
                input_box.Text = this.str_output;
            };

            button4.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '4';
                this.str_output += '4';
                input_box.Text = this.str_output;
            };

            button5.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '5';
                this.str_output += '5';
                input_box.Text = this.str_output;
            };

            button6.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '6';
                this.str_output += '6';
                input_box.Text = this.str_output;
            };

            button7.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '7';
                this.str_output += '7';
                input_box.Text = this.str_output;
            };

            button8.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '8';
                this.str_output += '8';
                input_box.Text = this.str_output;
            };

            button9.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '9';
                this.str_output += '9';
                input_box.Text = this.str_output;
            };

            button0.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '0';
                this.str_output += '0';
                input_box.Text = this.str_output;
            };

            buttonClear.Click += delegate
            {
                myVib.Vibrate(25);
                input_box.Text = null;
            };

            buttonADD.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '1';
                this.str_output += '1';
                input_box.Text = this.str_output;
            };

            buttonSubtract.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '1';
                this.str_output += '1';
                input_box.Text = this.str_output;
            };

            buttonDivide.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '1';
                this.str_output += '1';
                input_box.Text = this.str_output;
            };

            buttonInvert.Click += delegate
            {
                myVib.Vibrate(25);
                this.str_input += '1';
                this.str_output += '1';
                input_box.Text = this.str_output;
            };


        }
    }
}

