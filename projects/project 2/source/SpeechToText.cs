using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using Android.Views;
using Android.Widget;

namespace MultiFuncApp
{
    [Activity(Label = "SpeechToText")]
    public class SpeechToText : Activity
    {
        private bool isRecording;
        private readonly int VOICE = 10;
        private TextView textBox;
        private Button recButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            isRecording = false;
            SetContentView(Resource.Layout.Main);

            recButton = FindViewById<Button>(Resource.Id.btnRecord);
            textBox = FindViewById<TextView>(Resource.Id.speechText);

            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec != "android.hardware.microphone")
            {
                var alert = new AlertDialog.Builder(recButton.Context);
                alert.SetTitle("Microphone not detected");
                alert.SetPositiveButton("Ok", (sender, e) =>
                {
                    textBox.Text = "No microphone present";
                    recButton.Enabled = false;
                    return;
                });

                alert.Show();
            }
            else
                recButton.Click += delegate
                {
                    recButton.Text = "End Recording";
                    isRecording = !isRecording;
                    if (isRecording)
                    {
                        var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                        voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

                        voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, Application.Context.GetString(Resource.String.messageSpeakNow));

                        voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
                        voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
                        voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
                        voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);

                        voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
                        StartActivityForResult(voiceIntent, VOICE);
                    }

                };
        }
        protected override void OnActivityResult(int requestCode, Result resultVal, Intent data)
        {
            if (requestCode == VOICE)
            {
                if (resultVal == Result.Ok)
                {
                    var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                    if (matches.Count != 0)
                    {
                        string textInput = textBox.Text + matches[0];
                        if (textInput.Length > 500)
                        {
                            textInput = textInput.Substring(0, 500);
                            textBox.Text = textInput;
                        }
                        else
                            textBox.Text = "No speech recognized";
                        recButton.Text = "Start Recording";
                    }
                }
                base.OnActivityResult(requestCode, resultVal, data);
            }
        }
    }
}