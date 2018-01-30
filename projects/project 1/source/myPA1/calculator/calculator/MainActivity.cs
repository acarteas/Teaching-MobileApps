using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace calculator
{
    [Activity(Label = "Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Stack<double> mystack = new Stack<double>();
        double op2, op1;
        double answer;
        double result;
        int count = 0;

       



        double myfunct(string thing)
        {
            double num;
            if(count >= 2)
            {

                if ((thing == "+") || (thing == "-") || (thing == "X") || (thing == "/"))
                {
                    op2 = mystack.Pop();
                    op1 = mystack.Pop();
                    if (thing == "+")
                    {
                        result = op1 + op2;
                    }

                    if (thing == "-")
                    {
                        result = op1 - op2;
                    }

                    if (thing == "X")
                    {
                        result = op1 * op2;
                    }

                    if (thing == "/")
                    {
                        result = op1 / op2;
                    }

                    mystack.Push(result);
                    count--;
                    count--;
                    return result;
                }
            }

            else if ((thing == "0") || (thing == "1") || (thing == "2") || (thing == "3") || (thing == "4") || (thing == "5") || (thing == "6") || (thing == "7") || (thing == "8") || (thing == "9"))
            {
                num = int.Parse(thing);
                mystack.Push(num);
                count++;
                return num;
            }
            return 0;
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
            TextView myans = FindViewById<TextView>(Resource.Id.result);

            pressed0.Click += delegate
            {
                myans.Text = myfunct("0").ToString();
            };
            pressed1.Click += delegate
            {
                myans.Text = myfunct("1").ToString();
            };
            pressed2.Click += delegate
            {
                myans.Text = myfunct("2").ToString();
            };
            pressed3.Click += delegate
            {
                myans.Text = myfunct("3").ToString();

            };
            pressed4.Click += delegate
            {
                myans.Text = myfunct("4").ToString();
            };
            pressed5.Click += delegate
            {
                myans.Text = myfunct("5").ToString();
            };
            pressed6.Click += delegate
            {
                myans.Text = myfunct("6").ToString();
            };
            pressed7.Click += delegate
            {
                myans.Text = myfunct("7").ToString();
            };
            pressed8.Click += delegate
            {
                myans.Text = myfunct("8").ToString();
            };
            pressed9.Click += delegate
            {
                myans.Text = myfunct("9").ToString();
            };
            pressedplus.Click += delegate
            {
                myans.Text = myfunct("+").ToString();
            };
            pressedsub.Click += delegate
            {
                myans.Text = myfunct("-").ToString();
            };
            pressedmult.Click += delegate
            {
                myans.Text = myfunct("X").ToString();
            };
            presseddiv.Click += delegate
            {
                myans.Text = myfunct("/").ToString();
            };
        }
    }
}