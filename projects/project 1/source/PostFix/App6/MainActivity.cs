using Android.App;
using Android.Widget;
using Android.OS;

namespace App6
{
    [Activity(Label = "App6", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string _display = "0.00";
        string _num1, _num2 = "";
        int numb1, numb2, int_display = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button a = FindViewById<Button>(Resource.Id.one);
            Button b = FindViewById<Button>(Resource.Id.two);
            Button c = FindViewById<Button>(Resource.Id.three);
            Button d = FindViewById<Button>(Resource.Id.four);
            Button e = FindViewById<Button>(Resource.Id.five);
            Button f = FindViewById<Button>(Resource.Id.six);
            Button g = FindViewById<Button>(Resource.Id.seven);
            Button h = FindViewById<Button>(Resource.Id.eight);
            Button i = FindViewById<Button>(Resource.Id.nine);
            Button j = FindViewById<Button>(Resource.Id.zero);
            Button _dot = FindViewById<Button>(Resource.Id.dot);
            Button _space = FindViewById<Button>(Resource.Id.space);
            Button _minus = FindViewById<Button>(Resource.Id.minus);
            Button _addition = FindViewById<Button>(Resource.Id.addition);
            Button _div = FindViewById<Button>(Resource.Id.div);
            Button _mult = FindViewById<Button>(Resource.Id.mult);
            Button _clear = FindViewById<Button>(Resource.Id.clear);

            //string _num2 = "";

            a.Click += _clicked;
            b.Click += _clicked;
            c.Click += _clicked;
            d.Click += _clicked;
            e.Click += _clicked;
            f.Click += _clicked;
            g.Click += _clicked;
            h.Click += _clicked;
            i.Click += _clicked;
            j.Click += _clicked;
            _dot.Click += _clicked;
            _space.Click += _clicked;
            _minus.Click += _clicked;
            _addition.Click += _clicked;
            _div.Click += _clicked;
            _mult.Click += _clicked;
            _clear.Click += _clicked;

        }

        private void _clicked(object sender, System.EventArgs e)
        {
            Button _clicked = sender as Button;
            string _temp = "";
            string clicked = _clicked.Id.ToString();
            if (clicked == null)
            {
                return;
            }
            if (clicked == "one")
            {
                _temp += "1";
            }
            if (clicked == "two")
            {
                _temp += "2";
            }
            if (clicked == "three")
            {
                _temp += "3";
            }
            if (clicked == "four")
            {
                _temp += "4";
            }
            if (clicked == "five")
            {
                _temp += "5";
            }
            if (clicked == "six")
            {
                _temp += "6";
            }
            if (clicked == "seven")
            {
                _temp += "7";
            }
            if (clicked == "eight")
            {
                _temp += "8";
            }
            if (clicked == "nine")
            {
                _temp += "9";
            }
            if (clicked == "zero")
            {
                _temp += "0";
            }
            if (clicked == "dot")
            {
                _temp += ".";
            }
            if (clicked == "plus")
            {
                numb1 = int.Parse(_num1);
                numb2 = int.Parse(_num2);
                int_display = numb1 + numb2;
                _num1 = int_display.ToString();
                _num2 = "";
                _display = int_display.ToString();
            }
            if (clicked == "minus")
            {
                numb1 = int.Parse(_num1);
                numb2 = int.Parse(_num2);
                int_display = numb1 - numb2;
                _num1 = int_display.ToString();
                _num2 = "";
                _display = int_display.ToString();
            }
            if (clicked == "mult")
            {
                numb1 = int.Parse(_num1);
                numb2 = int.Parse(_num2);
                int_display = numb1 * numb2;
                _num1 = int_display.ToString();
                _num2 = "";
                _display = int_display.ToString();
            }
            if (clicked == "div")
            {
                numb1 = int.Parse(_num1);
                numb2 = int.Parse(_num2);
                int_display = numb1 / numb2;
                _num1 = int_display.ToString();
                _num2 = "";
                _display = int_display.ToString();
            }
            if (clicked == "clear")
            {
                _num1 = "";
                _num2 = "";
                _display = "0.00";
            }
            if (clicked == "space")
            {
                _num1 = _temp;
            }
            else
            {
                _num2 = _temp;
            }
            var display_text = FindViewById<TextView>(Resource.Id.calculatorAccumulator);
            display_text.Text = _display;
        }
    }
}

