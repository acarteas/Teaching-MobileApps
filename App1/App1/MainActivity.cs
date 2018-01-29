using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        void start(object sender, System.EventArgs e)
        {

            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);
            count = 0;
  

            Button clicked = sender as Button;

            if (clicked != null)
            {
                Question.Text = string.Format("Who Lives In A Pineapple Under The Sea?");
                AnswerA.Text = string.Format("Gary");
                AnswerB.Text = string.Format("Patrick");
                AnswerC.Text = string.Format("Gingy");
                AnswerD.Text = string.Format("Non of the Above");

                AnswerA.Click += delegate { Score.Text = string.Format("{0} Points", count++); };
                AnswerA.Click += questionSet2;
                AnswerB.Click += questionSet2;
                AnswerC.Click += questionSet2;
                AnswerD.Click += questionSet2;

                
            }



        }




        void questionSet2(object sender, System.EventArgs e)
        {
            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);

            Question.Text = string.Format("How many calories do you burn an hour banging your head against a wall?");
            AnswerA.Text = string.Format("200");
            AnswerB.Text = string.Format("75");
            AnswerC.Text = string.Format("150");
            AnswerD.Text = string.Format("30");

            AnswerA.Click += questionSet3;
            AnswerB.Click += questionSet3;
            AnswerC.Click += delegate { Score.Text = string.Format("{0} Points", count++); };
            AnswerC.Click += questionSet3;
            AnswerD.Click += questionSet3;

        }

        void questionSet3(object sender, System.EventArgs e)
        {
            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);

            Question.Text = string.Format("What is a flock of crows called?");
            AnswerA.Text = string.Format("flock");
            AnswerB.Text = string.Format("murder");
            AnswerC.Text = string.Format("wisp");
            AnswerD.Text = string.Format("regatta");

            AnswerA.Click += questionSet4;
            AnswerB.Click += delegate { Score.Text = string.Format("{0} Points", count++); };
            AnswerB.Click += questionSet4;
            AnswerC.Click += questionSet4;
            AnswerD.Click += questionSet4;

        }


        void questionSet4(object sender, System.EventArgs e)
        {
            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);

            Question.Text = string.Format("which of these are an island in Canada?");
            AnswerA.Text = string.Format("La Isla de las Muñecas");
            AnswerB.Text = string.Format("Ramree Island");
            AnswerC.Text = string.Format("Howland Island");
            AnswerD.Text = string.Format("Dildo Island");

            AnswerA.Click += ending;
            AnswerB.Click += ending;
            AnswerC.Click += ending;
            AnswerD.Click += delegate { Score.Text = string.Format("{0} Points", count++); };
            AnswerD.Click += ending;

        }

        void ending(object sender, System.EventArgs e)
        {
            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);

            Question.Text = string.Format("You got {0} Points", count);
            AnswerA.Text = string.Format("Click me I'm also pointless");
            AnswerB.Text = string.Format("Click me for a random string of letters");
            AnswerC.Text = string.Format("Click me i'm even more pointless than the Last one");
            AnswerD.Text = string.Format("I ran out of ideas but you can still click me");

            AnswerA.Click += delegate { AnswerA.Text = string.Format("Gotcha you thouhgt i was gonna do the same thing as before"); };
            AnswerB.Click += delegate { AnswerB.Text = string.Format("a;lvnrblkbnxigslkbg"); };
            AnswerC.Click += delegate { AnswerC.Text = string.Format("¯\\_(ツ)_/¯"); };
            AnswerD.Click += delegate { AnswerD.Text = string.Format("(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧"); };
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //named and retrieved the 4 buttons and both text boxes id #'s and gave them a variable name
            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);

            //start the questions when the a button is clicked
            AnswerA.Click +=  start; 

            //just changes the pointless button's text once and keeps it to this like a bad joke
            AnswerB.Click += delegate { AnswerB.Text = string.Format("Told you."); };

            //these at first should add 1-2 points to the score box below them each time the buttons are clicked
            AnswerC.Click += delegate { Score.Text = string.Format("{0} Points", count += 1); };
            AnswerD.Click += delegate { Score.Text = string.Format("{0} Points", count += 2); };
                 
            }
        }
}

