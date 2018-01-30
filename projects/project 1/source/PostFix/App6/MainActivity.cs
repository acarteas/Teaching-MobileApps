using Android.App;
using Android.Widget;
using Android.OS;

namespace App6
{
    [Activity(Label = "App6", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string _display = "0.00";
        string _num1, _num2, _temp = "";
        double numb1, numb2, int_display = 0.0;
        bool clear_clicked, num_press, dot_pressed = false;
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
            Button clicked_ = sender as Button;
            string clicked = clicked_.Id.ToString();
            //_display = clicked_.Id.ToString();
            if (clicked == null)
            {
                return;
            }
            if (clicked == "2130968587")
            {
                _temp += "1";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968588")
            {
                _temp += "2";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968589")
            {
                _temp += "3";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968583")
            {
                _temp += "4";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968584")
            {
                _temp += "5";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968585")
            {
                _temp += "6";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968579")
            {
                _temp += "7";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968580")
            {
                _temp += "8";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968581")
            {
                _temp += "9";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968594")
            {
                _temp += "0";
                _display = _temp;
                num_press = true;
            }
            if (clicked == "2130968591" & dot_pressed == false)
            {
               if(num_press == false)
                {
                    _temp += "0.";
                    _display = _temp;
                    dot_pressed = true;
                }
                else
                {
                    _temp += ".";
                    _display = _temp;
                    num_press = false;
                    dot_pressed = true;
                }
            }
            if (clicked == "2130968593" & clear_clicked == true)
            {
                _num2 = _temp;
                numb1 = double.Parse(_num1);
                numb2 = double.Parse(_num2);
                int_display = numb1 + numb2;
                _temp = int_display.ToString();
                //_num2 = "";
                _display = int_display.ToString();
                clear_clicked = false;

            }
            if (clicked == "2130968590" & clear_clicked == true)
            {
                _num2 = _temp;
                numb1 = double.Parse(_num1);
                numb2 = double.Parse(_num2);
                int_display = numb1 - numb2;
                _temp = int_display.ToString();
                //_num2 = "";
                _display = int_display.ToString();
                clear_clicked = false;

            }
            if (clicked == "2130968586" & clear_clicked == true)
            {
                _num2 = _temp;
                numb1 = double.Parse(_num1);
                numb2 = double.Parse(_num2);
                int_display = numb1 * numb2;
                _temp = int_display.ToString();
                //_num2 = "";
                _display = int_display.ToString();
               clear_clicked = false;

            }
            if (clicked == "2130968582" & clear_clicked == true)
            {
                _num2 = _temp;
                numb1 = double.Parse(_num1);
                numb2 = double.Parse(_num2);
                int_display = numb1 / numb2;
                _temp = int_display.ToString();
                //_num2 = "";
                _display = int_display.ToString();
                clear_clicked = false;

            }
            if (clicked == "2130968596")
            {
                _num1 = "";
                _num2 = "";
                _display = "0.00";
                _temp = "";
                clear_clicked = false;
                num_press = false;
                dot_pressed = false;
            }
            if (clicked == "2130968592" & clear_clicked == false)
            {
                _num1 = _temp;
                _temp = "";
                clear_clicked = true;
                dot_pressed = false;
            }
            var display_text = FindViewById<TextView>(Resource.Id.calculatorAccumulator);
            display_text.Text = _display;
        }
    }
}

