using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections;
using System.Linq;

namespace App1
{
    [Activity(Label = "Postfix Calculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Stack stack = new Stack();
       // string str_input = null;
        //string str_output = null;
        private Vibrator myVib;
        private int enter_count;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            myVib = (Vibrator)GetSystemService(VibratorService);
            // Get our button from the layout resource,
            // and attach an event to it
            Button button1 = FindViewById<Button>(Resource.Id.Button1);
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
            Button buttonEnter = FindViewById<Button>(Resource.Id.ButtonEqual);
            var input_box = FindViewById<TextView>(Resource.Id.calculatorbox);

            //button1.Click += delegate
            //{
            //   // myVib.Vibrate(25);
            //    this.str_input += '1';
            //    this.str_output += '1';
            //    input_box.Text = this.str_output;
            //};

            //button2.Click += delegate
            //{
            //    //myVib.Vibrate(25);
            //    this.str_input += '2';
            //    this.str_output += '2';
            //    input_box.Text = this.str_output;
            //};

            //button3.Click += delegate
            //{
            //   // myVib.Vibrate(25);
            //    this.str_input += '3';
            //    this.str_output += '3';
            //    input_box.Text = this.str_output;
            //};

            //button4.Click += delegate
            //{
            //    //myVib.Vibrate(25);
            //    this.str_input += '4';
            //    this.str_output += '4';
            //    input_box.Text = this.str_output;
            //};

            //button5.Click += delegate
            //{
            //   // myVib.Vibrate(25);
            //    this.str_input += '5';
            //    this.str_output += '5';
            //    input_box.Text = this.str_output;
            //};

            //button6.Click += delegate
            //{
            //    //myVib.Vibrate(25);
            //    this.str_input += '6';
            //    this.str_output += '6';
            //    input_box.Text = this.str_output;
            //};

            //button7.Click += delegate
            //{
            //    //myVib.Vibrate(25);
            //    this.str_input += '7';
            //    this.str_output += '7';
            //    input_box.Text = this.str_output;
            //};

            //button8.Click += delegate
            //{
            //    //myVib.Vibrate(25);
            //    this.str_input += '8';
            //    this.str_output += '8';
            //    input_box.Text = this.str_output;
            //};
            //button9.Click += delegate
            //{
            //    //myVib.Vibrate(25);
            //    this.str_input += '9';
            //    this.str_output += '9';
            //    input_box.Text = this.str_output;
            //};

            //button0.Click += delegate
            //{
            //    //myVib.Vibrate(25);
            //    this.str_input += '0';
            //    this.str_output += '0';
            //    input_box.Text = this.str_output;
            //};

            //buttonClear.Click += delegate
            //{
            //   // myVib.Vibrate(25);
            //    input_box.Text = null;
            //};

            //buttonADD.Click += delegate
            //{
            //    //myVib.Vibrate(25);
            //    this.str_input += '+';
            //    this.str_output += '+';
            //    input_box.Text = this.str_output;
            //};

            //buttonSubtract.Click += delegate
            //{
            //   // myVib.Vibrate(25);
            //    this.str_input += '-';
            //    this.str_output += '-';
            //    input_box.Text = this.str_output;
            //};

            //buttonDivide.Click += delegate
            //{
            //   // myVib.Vibrate(25);
            //    this.str_input += '/';
            //    this.str_output += '/';
            //    input_box.Text = this.str_output;
            //};



            button1.Click += button_click;
            button2.Click += button_click;
            button3.Click += button_click;
            button4.Click += button_click;
            button5.Click += button_click;
            button6.Click += button_click;
            button7.Click += button_click;
            button8.Click += button_click;
            button9.Click += button_click;
            button0.Click += button_click;

            //operations
            buttonMultiply.Click += button_click;
            buttonDivide.Click += button_click;
            buttonADD.Click += button_click;
            buttonSubtract.Click += button_click;


            //clear, delete, clear entry
            buttonClear.Click += all_clear_button;


            //enter click
            buttonEnter.Click += button_click;
        }

        //Adds the button clicked onto the TextView and the Stack
        private void button_click(object sender, System.EventArgs e)
        {
            Button the_button = sender as Button;
            TextView results = FindViewById<TextView>(Resource.Id.calculatorbox);
            results.Text += the_button.Text;
           // string Text = stack.Pop();
            //results.Text = stack.Pop(); 
            enter_count = 0;
        }


        //Clears the TextView and the Stack
        private void all_clear_button(object sender, System.EventArgs e)
        {
            Button a_button = sender as Button;
            TextView results = FindViewById<TextView>(Resource.Id.calculatorbox);
            results.Text = " ";
            //int enter_button = 0;
            stack.Clear();
        }

        //Enter button, sends 
        public void enter_button(object sender, System.EventArgs e)
        {
            TextView results = FindViewById<TextView>(Resource.Id.calculatorbox);
            double output;
            double num1 = 0;
            double num2 = 0;

            enter_count += 1;

            if (enter_count > 1)
            {
                double.TryParse(results.Text, out output);
                {
                    if (results.Text == "+")
                    {
                        results.Text = (num1 + num2).ToString();
                    }
                    else if (results.Text == "-")
                    {
                        results.Text = (num1 - num2).ToString();
                    }
                    else if (results.Text == "*")
                    {
                        results.Text = (num1 * num2).ToString();
                    }
                    else if (results.Text == "/")
                    {
                        results.Text = (num1 / num2).ToString();
                    }
                    else
                    {
                        stack.Push(System.Convert.ToDouble(results.Text));

                  
  }

                }
            }

        }
    }
}