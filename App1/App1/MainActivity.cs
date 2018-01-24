using Android.App;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        /*void objectIdNumbers()
        {
            // Get our button from the layout resource,
            // and attach an event to it
            //named and retrieved the 4 buttons and both text boxes id #'s and gave them a variable name
            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);
        }*/
            
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
            AnswerA.Click += start;
            
            //just changes the pointless button's text once and keeps it to this like a bad joke
            AnswerB.Click += delegate { AnswerB.Text = string.Format("Told you."); };

            //these at first should add 1-2 points to the score box below them each time the buttons are clicked
            AnswerC.Click += delegate { Score.Text = string.Format("{0} Points", count += 1); };
            AnswerD.Click += delegate { Score.Text = string.Format("{0} Points", count += 2); };
        }
        
        
        private void start(object sender, System.EventArgs e)
        {

            Button AnswerA = FindViewById<Button>(Resource.Id.PossibleAnswerA);
            Button AnswerB = FindViewById<Button>(Resource.Id.PossibleAnswerB);
            Button AnswerC = FindViewById<Button>(Resource.Id.PossibleAnswerC);
            Button AnswerD = FindViewById<Button>(Resource.Id.PossibleAnswerD);
            TextView Question = FindViewById<TextView>(Resource.Id.QuestionText);
            TextView Score = FindViewById<TextView>(Resource.Id.ScoreBoard);
            count = 0;


            //set object as a button 


            if (clicked != null)
            {
                Question.Text = string.Format("Who Lives In A Pineapple Under The Sea?");
                AnswerA.Text = string.Format("Gary");
                AnswerB.Text = string.Format("Patrick");
                AnswerC.Text = string.Format("Gingy");
                AnswerD.Text = string.Format("Non of the Above");

                if(AnswerA.)
                {
                    Score.Text = string.Format("{0} Points", count++);
                }
                
                AnswerA.Click += questionTwo;
                AnswerB.Click += questionTwo;
                AnswerC.Click += questionTwo;
                AnswerD.Click += questionTwo;
            }

            private void questionTwo(object sender, System.EventArgs e)
            {
                
            }
        }
    }
}

