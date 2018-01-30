using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;


namespace PostFix
{
    [Activity(Label = "PostFix", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Connecting buttons so user can give input

            //here are the digits
            Button num1 = (Button)FindViewById(Resource.Id.button_one);
            Button num2 = (Button)FindViewById(Resource.Id.button_two);
            Button num3 = (Button)FindViewById(Resource.Id.button_three);
            Button num4 = (Button)FindViewById(Resource.Id.button_four);
            Button num5 = (Button)FindViewById(Resource.Id.button_five);
            Button num6 = (Button)FindViewById(Resource.Id.button_six);
            Button num7 = (Button)FindViewById(Resource.Id.button_seven);
            Button num8 = (Button)FindViewById(Resource.Id.button_eight);
            Button num9 = (Button)FindViewById(Resource.Id.button_nine);
            Button num0 = (Button)FindViewById(Resource.Id.button_zero);

            //next are the operators
            Button op_div = (Button)FindViewById(Resource.Id.button_div);
            Button op_mult = (Button)FindViewById(Resource.Id.button_mult);
            Button op_sub = (Button)FindViewById(Resource.Id.button_sub);
            Button op_add = (Button)FindViewById(Resource.Id.button_plus);
            Button op_equal = (Button)FindViewById(Resource.Id.button_equal);

            //next is space, clear, and decimal
            Button op_space = (Button)FindViewById(Resource.Id.button_space);
            Button op_clear = (Button)FindViewById(Resource.Id.button_clear);
            Button op_dot = (Button)FindViewById(Resource.Id.button_dec);

            //text to recieve and display the button input
            TextView result = (TextView)FindViewById(Resource.Id.textView1);
            
            


            num1.Click += delegate { result.Text = result.Text + num1.Text.ToString(); };
            num2.Click += delegate { result.Text = result.Text + num2.Text.ToString(); };
            num3.Click += delegate { result.Text = result.Text + num3.Text.ToString(); };
            num4.Click += delegate { result.Text = result.Text + num4.Text.ToString(); };
            num5.Click += delegate { result.Text = result.Text + num5.Text.ToString(); };
            num6.Click += delegate { result.Text = result.Text + num6.Text.ToString(); };
            num7.Click += delegate { result.Text = result.Text + num7.Text.ToString(); };
            num8.Click += delegate { result.Text = result.Text + num8.Text.ToString(); };
            num9.Click += delegate { result.Text = result.Text + num9.Text.ToString(); };
            num0.Click += delegate { result.Text = result.Text + num0.Text.ToString(); };

            op_div.Click += delegate { result.Text = result.Text + op_div.Text.ToString(); };
            op_mult.Click += delegate { result.Text = result.Text + op_mult.Text.ToString(); };
            op_sub.Click += delegate { result.Text = result.Text + op_sub.Text.ToString(); };
            op_add.Click += delegate { result.Text = result.Text + op_add.Text.ToString(); };
            //op_equal.Click += delegate { result.Text = result.Text + op_equal.Text.ToString(); };

            op_space.Click += delegate { result.Text = result.Text + op_space.Text.ToString(); };
            op_clear.Click += delegate { result.Text = result.Text + op_clear.Text.ToString(); };
            op_dot.Click += delegate { result.Text = result.Text + op_dot.Text.ToString(); };

            double Calculate(Stack<string> ToCalculate)
            {
                double number1, number2;
                string[] ToCalc = ToCalculate.ToArray();

                number1 = double(ToCalculate.ElementAt(0));
                number2 = double.Parse(ToCalculate.ElementAt(1));

                //number1 = double.Parse(ToCalc[0]);
               // number2 = double.Parse(ToCalc[1]);

                if (ToCalculate.ElementAt(2) == "/")
                {
                    return (number1 / number2);
                }

                if (ToCalculate.ElementAt(2) == "*")
                {
                    return (number1 * number2);
                }

                if (ToCalculate.ElementAt(2) == "+")
                {
                    return (number1 + number2);
                }

                if (ToCalculate.ElementAt(2) == "-")
                {
                    return (number1 - number2);
                }

                else return 0;

            };

            op_equal.Click += delegate
            {
                string ToParse = result.ToString();
                Stack<string> ToAdd = new Stack<string>();
                double answer;

                //Use a dilemeter to separate integer values from operator values

                char delimiter = ' ';
                string[] substrings = ToParse.Split(delimiter);
                foreach (var substring in substrings)
                {
                        ToAdd.Push(substring);
                }

                answer = Calculate(ToAdd);

                result = (TextView)answer;
            };


        }
    }
}

