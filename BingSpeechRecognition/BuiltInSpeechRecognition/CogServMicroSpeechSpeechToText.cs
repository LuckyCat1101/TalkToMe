using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.CognitiveServices.Speech;
using System.Diagnostics;

namespace BuiltInSpeechRecognition
{

    public partial class SpeechToTextForm : Form
    {
        private string primaryKey;
        private string secondaryKey;
        private string azureKey;
        bool stopBttnn = false;
        bool startBttnn = false;

        public SpeechToTextForm()
        {
            InitializeComponent();

            primaryKey = "7b228d8320c54b24b550e2bdd2197ac0";
            secondaryKey = "3e3ac2c7945c4dcc92df8bea25fa379b";
            azureKey = "8dca42f9-2366-421b-8b8f-f2fa58b2457c";
        }

        private void SpeechToTextForm_Load(object sender, EventArgs e)
        {
            var speechConfig = SpeechConfig.FromSubscription(primaryKey, "eastus");
        }

        private void enableVoiceBttn_Click(object sender, EventArgs e)
        {
             startBttnn = true;
             stopBttnn = false;

            this.stopBttn.Enabled = true;

            this.enableVoiceBttn.Enabled = false;
        }

        private void stopBttn_Click(object sender, EventArgs e)
        {
             stopBttnn = true;
             startBttnn = false;


            this.enableVoiceBttn.Enabled = true;

            this.stopBttn.Enabled = false;
        }

        public async Task SpeechContinuousRecognitionAsync()
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription(primaryKey, "eastus");

            // Creates a speech recognizer from microphone.
            using (var recognizer = new SpeechRecognizer(config))
            {
                // Subscribes to events.
                recognizer.Recognizing += (s, e) => {
                    Console.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
                };

                recognizer.Recognized += (s, e) => {
                    var result = e.Result;
                    Console.WriteLine($"Reason: {result.Reason.ToString()}");
                    if (result.Reason == ResultReason.RecognizedSpeech)
                    {
                        richTextBox.Text = result.Text;
                    }
                };

                recognizer.Canceled += (s, e) => {
                    Console.WriteLine($"\n    Recognition Canceled. Reason: {e.Reason.ToString()}, CanceledReason: {e.Reason}");
                };

                recognizer.SessionStarted += (s, e) => {
                    richTextBox.Text = "\n    Session started event.";
                };

                recognizer.SessionStopped += (s, e) => {
                    richTextBox.Text = "\n    Session stopped event.";
                };

                //if (enableVoiceBttn.Enabled == true)
                // Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.
                    await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

               // while (stopBttn.Enabled != false);
                    // Stops recognition.
                    //await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
            }
        }


    }   

    
}
