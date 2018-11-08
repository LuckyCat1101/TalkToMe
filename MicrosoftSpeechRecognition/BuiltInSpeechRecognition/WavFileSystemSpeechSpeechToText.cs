using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace BuiltInSpeechRecognition
{
    public partial class SpeechToTextForm : Form
    {
        SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();

        public SpeechToTextForm()
        {
            InitializeComponent();
        }

        private void SpeechToTextForm_Load(object sender, EventArgs e)
        {
            /*//Choices help_ = new Choices(new string[] { "lovely", "girlfriend", "blue" });

            Choices choicesStartStop = new Choices();
            choicesStartStop.Add("lovely");
            choicesStartStop.Add("cute");
            choicesStartStop.Add("Hi");
            choicesStartStop.Add("I'm");
            choicesStartStop.Add("testing");

            GrammarBuilder gb_StartStop =
              new GrammarBuilder(choicesStartStop);
              */

            // Create a default dictation grammar.  
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.AppendDictation();
            //gBuilder.Append(help_);

            Grammar grammar = new Grammar(gBuilder);

           // Grammar g_StartStop = new Grammar(gb_StartStop);

            // Create the spelling dictation grammar.  
            DictationGrammar spellingDictationGrammar =
              new DictationGrammar("grammar:dictation#spelling");
            spellingDictationGrammar.Name = "spelling dictation";
            spellingDictationGrammar.Enabled = true;

            recognitionEngine.LoadGrammar(grammar);
            recognitionEngine.LoadGrammar(spellingDictationGrammar);
            //recognitionEngine.LoadGrammar(g_StartStop);
            recognitionEngine.SpeechRecognized += RecognitionEngine_SpeechRecognized;
            recognitionEngine.RecognizeCompleted += RecognitionEngine_RecognizeCompleted;
        }

        private void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox.Text += " " + e.Result.Text;
        }

        private void stopBttn_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsyncStop();
            stopBttn.Enabled = false;
            startAudioBttn.Enabled = true;
        }

        private void enableVoiceBttn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openAudio = new OpenFileDialog();
            if (openAudio.ShowDialog(this) == DialogResult.OK)
            {
                // gets name for saving
                string audio = openAudio.FileName;

                // reset audio input device
                recognitionEngine.SetInputToWaveFile(audio);
                recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
                startAudioBttn.Enabled = false;
                stopBttn.Enabled = true;
                richTextBox.Clear();
            }
            else
                return;

        }

        private void RecognitionEngine_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                richTextBox.Text += "\n \n An Error occurred: " + e.Error.GetType().Name +  e.Error.Message.ToString();
                stopBttn.Enabled = false;
                startAudioBttn.Enabled = true;
            }
            if (e.Cancelled)
            {
                richTextBox.Text += "\n \nOperation cancelled.";
                stopBttn.Enabled = false;
                startAudioBttn.Enabled = true;
            }
            if (e.InputStreamEnded)
            {
                richTextBox.Text += "\n \nEnd of audio file encountered.";
                recognitionEngine.RecognizeAsyncStop();
                stopBttn.Enabled = false;
                startAudioBttn.Enabled = true;
            }
        }
        
    }
}
