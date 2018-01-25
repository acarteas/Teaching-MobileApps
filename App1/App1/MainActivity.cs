using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        int correct = 0;

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

            AnswerC.Click += delegate { Score.Text = string.Format("{0} Points", count++); correct++; };
        }

        void start(object sender, System.EventArgs e)
        {

            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);
            count = 0;
            Score.Text = string.Format("{0} Points");

            Button clicked = sender as Button;

            if (clicked != null)
            {
                Question.Text = string.Format("Who Lives In A Pineapple Under The Sea?");
                AnswerA.Text = string.Format("Gary");
                AnswerB.Text = string.Format("Patrick");
                AnswerC.Text = string.Format("Gingy");
                AnswerD.Text = string.Format("Non of the Above");

                AnswerA.Click += delegate { Score.Text = string.Format("{0} Points", count++); correct++; };

            }



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

            AnswerB.Click += delegate { Score.Text = string.Format("{0} Points", count++); correct++; };
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
            AnswerB.Text = string.Format("Dildo Island");
            AnswerC.Text = string.Format("Howland Island");
            AnswerD.Text = string.Format("Ramree Island");

            AnswerB.Click += delegate { Score.Text = string.Format("{0} Points", count++); correct++; };
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

            if(correct == 1)
            {
                questionSet2();
            }
            else if(correct == 2)
            {
                questionSet3();
            }  
            else if(correct == 3)
            {
                questionSet4();
            }
            else if(correct == 4)
            {
                questionSet5();
            }
                 
            }
        }

    }
}

