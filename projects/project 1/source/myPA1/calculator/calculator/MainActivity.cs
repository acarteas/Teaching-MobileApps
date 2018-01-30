using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace calculator
{
    [Activity(Label = "Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Stack<string> initstack = new Stack<string>();
        Stack<double> numstack = new Stack<double>();
        Stack<string> operstack = new Stack<string>();
        double op2, op1;
        double result;


       void myfunct(string the_char)
        {
            switch (the_char)
            {
                case "0":
                    initstack.Push("0");
                    numstack.Push(0);
                    break;
                case "1":
                    initstack.Push("1");
                    numstack.Push(1);
                    break;
                case "2":
                    initstack.Push("2");
                    numstack.Push(2);
                    break;
                case "3":
                    initstack.Push("3");
                    numstack.Push(3);
                    break;
                case "4":
                    initstack.Push("4");
                    numstack.Push(4);
                    break;
                case "5":
                    initstack.Push("5");
                    numstack.Push(5);
                    break;
                case "6":
                    initstack.Push("6");
                    numstack.Push(6);
                    break;
                case "7":
                    initstack.Push("7");
                    numstack.Push(7);
                    break;
                case "8":
                    initstack.Push("8");
                    numstack.Push(8);
                    break;
                case "9":
                    initstack.Push("9");
                    numstack.Push(9);
                    break;
                case "+":
                    initstack.Push("+");
                    operstack.Push("+");
                    break;
                case "-":
                    initstack.Push("-");
                    operstack.Push("-");
                    break;
                case "X":
                    initstack.Push("X");
                    operstack.Push("X");
                    break;
                case "/":
                    initstack.Push("/");
                    operstack.Push("/");
                    break;
            }
        }


        double thefunct(Stack<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string item = list.Pop();
                if (item == "+" || item == "-" || item == "/" || item == "X")
                {
                    if (numstack.Count > 1)
                    {
                        op2 = numstack.Pop();
                    }

                    if (numstack.Count > 1)
                    {
                        op1 = numstack.Pop();
                    }

                    if(item == "+")
                    {
                        result = op1 + op2;
                    }
                    if (item == "-")
                    {
                        result = op1 - op2;
                    }
                    if (item == "/")
                    {
                        result = op1 / op2;
                    }
                    if (item == "X")
                    {
                        result = op1 * op2;
                    }
                    numstack.Push(result);
                }
            }
            if (list.Count != 0)
            {
                return numstack.Pop();
            }
            else
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
            Button pressedeq = FindViewById<Button>(Resource.Id.Buttoneq);
            Button pressedclear = FindViewById<Button>(Resource.Id.ButtonClear);

            pressed0.Click += delegate
            {
                myans.Text = "0";
                myfunct("0");
            };
            pressed1.Click += delegate
            {
                myans.Text = "1";
                myfunct("1") ;
            };
            pressed2.Click += delegate
            {
                myans.Text = "2";
                myfunct("2");
            };
            pressed3.Click += delegate
            {
                myans.Text = "3";
                myfunct("3");

            };
            pressed4.Click += delegate
            {
                myans.Text = "4";
                myfunct("4");
            };
            pressed5.Click += delegate
            {
                myans.Text = "5";
                myfunct("5");
            };
            pressed6.Click += delegate
            {
                myans.Text = "6";
                myfunct("6");
            };
            pressed7.Click += delegate
            {
                myans.Text = "7";
                myfunct("7");
            };
            pressed8.Click += delegate
            {
                myans.Text = "8";
                myfunct("8");
            };
            pressed9.Click += delegate
            {
                myans.Text = "9";
                myfunct("9");
            };
            pressedplus.Click += delegate
            {
                myfunct("+");
            };
            pressedsub.Click += delegate
            {
                myfunct("-");
            };
            pressedmult.Click += delegate
            {
                myfunct("X");
            };
            presseddiv.Click += delegate
            {
                myfunct("/");
            };
            pressedeq.Click += delegate
            {
                myans.Text = thefunct(initstack).ToString();
            };

            pressedclear.Click += delegate
            {
                initstack.Clear();
                numstack.Clear();
                operstack.Clear();
                myans.Text = "0";
            };
        }
    }
}