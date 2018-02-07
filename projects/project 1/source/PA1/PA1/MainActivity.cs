using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
//Needed for  CultureInfo so I can parse floats using . instead of ,
using System.Globalization;



namespace PA1
{
    
    [Activity(Label = "PA1", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        char cur_math_expr = ' ';
        float last_num = 0;
        bool decimal_present = false;
       
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
            Button bdot = FindViewById<Button>(Resource.Id.dotbutton);

            Button bclear = FindViewById<Button>(Resource.Id.clearbutton);

            Button badd = FindViewById<Button>(Resource.Id.plusbutton);
            Button bsub = FindViewById<Button>(Resource.Id.minusbutton);
            Button bdivide = FindViewById<Button>(Resource.Id.dividebutton);
            Button bmultiply = FindViewById<Button>(Resource.Id.multiplybutton);

            Button bnegate = FindViewById<Button>(Resource.Id.negatebutton);
            Button bback = FindViewById<Button>(Resource.Id.backbutton);

            Button bequal = FindViewById<Button>(Resource.Id.equalbutton);
            
            

            b1.Click += AddNum;
            b2.Click += AddNum;
            b3.Click += AddNum;
            b4.Click += AddNum;
            b5.Click += AddNum;
            b6.Click += AddNum;
            b7.Click += AddNum;
            b8.Click += AddNum;
            b9.Click += AddNum;
            b0.Click += AddNum;
            bdot.Click += DotAdd;


            bclear.Click += ClearText;

            badd.Click += StoreMathExpr;
            bsub.Click += StoreMathExpr;
            bdivide.Click += StoreMathExpr;
            bmultiply.Click += StoreMathExpr;

            bequal.Click += EqualTime;

            bnegate.Click += Negate;

            bback.Click += Backspace;

            // Get our button from the layout resource,
            // and attach an event to it
            /*
               Button button = FindViewById<Button>(Resource.Id.myButton);

               button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            */

        }

        public void Negate(object sender, EventArgs e)
        {
            TextView to_edit = FindViewById<TextView>(Resource.Id.IOtext);
            if(to_edit.Text[0] != '0')
            {
                if (to_edit.Text[0] != '-')
                {
                    to_edit.Text = "-" + to_edit.Text;
                    
                }
                else
                {
                    to_edit.Text = to_edit.Text.Substring(1);
                }
            }
            
            
        }

        public void AddNum(object sender, EventArgs e)
        {
            Button the_button = sender as Button;
            TextView to_edit = FindViewById<TextView>(Resource.Id.IOtext);
            if(cur_math_expr == '=')
            {
                to_edit.Text = the_button.Text;
                cur_math_expr = ' ';
            }
            else
            {
                if (to_edit.Text[0] == '0')
                {
                    to_edit.Text = the_button.Text;
                }
                else
                {
                    to_edit.Text = to_edit.Text + the_button.Text;
                }
                
            }
            
           
        }

        public void DotAdd(object sender, EventArgs e)
        {
            TextView to_edit = FindViewById<TextView>(Resource.Id.IOtext);
            if (to_edit.Text.Contains(".") == false)
            {
                AddNum(sender, e);
            }
        }

        public void Backspace(object sender, EventArgs e)
        {
            TextView to_edit = FindViewById<TextView>(Resource.Id.IOtext);
            if(to_edit.Text[0] != '0')
            {
                if(to_edit.Text[to_edit.Text.Length - 1] == '.')
                {
                    decimal_present = false;
                }
                to_edit.Text = to_edit.Text.Substring(0, (to_edit.Text.Length - 1));
            }
           
        }

        public void ClearText(object sender, EventArgs e)
        {
            Button the_button = sender as Button;
            TextView to_edit = FindViewById<TextView>(Resource.Id.IOtext);
            to_edit.Text = "0";
        }

        public void EqualTime(object sender, EventArgs e)
        {
            TextView to_edit = FindViewById<TextView>(Resource.Id.IOtext);
            float cur_num = float.Parse(to_edit.Text, CultureInfo.InvariantCulture.NumberFormat);
            float calc;

            calc = Calculation(last_num, cur_num, cur_math_expr);

            to_edit.Text = calc.ToString();
            cur_math_expr = '=';
        }

        public void StoreMathExpr(object sender, EventArgs e)
        {
            Button expr_button = sender as Button;
            TextView to_edit = FindViewById<TextView>(Resource.Id.IOtext);
            Char button_expr = expr_button.Text[0];
            float cur_num = float.Parse(to_edit.Text, CultureInfo.InvariantCulture.NumberFormat);
            
            if (cur_math_expr == button_expr)
            {
                float temp = Calculation(last_num, cur_num, cur_math_expr);
                to_edit.Text = temp.ToString();
                cur_math_expr = '=';
            }
            else
            {
                last_num = cur_num;
                to_edit.Text = "0";
                //store the cur_math_expr
                cur_math_expr = button_expr;
            }
            
        }

        public float Calculation(float num1, float num2, char op)
        {
            float num_to_return = num2;
            switch (op)
            {
                case '+':
                    num_to_return = num1 + num2;
                    break;
                case '-':
                    num_to_return = num1 - num2;
                    break;
                case '/':
                    num_to_return = num1 / num2;
                    break;
                case '*':
                    num_to_return = num1 * num2;
                    break;
                default:
                    break;

            }
            return num_to_return;

            
        }

    }
    
}   
  

