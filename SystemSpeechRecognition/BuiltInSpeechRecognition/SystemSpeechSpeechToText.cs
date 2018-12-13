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
using System.Diagnostics;

namespace BuiltInSpeechRecognition
{
    public partial class SpeechToTextForm : Form
    {
        SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
        Stopwatch stopWatch;

        public SpeechToTextForm()
        {
            InitializeComponent();
        }

        private void SpeechToTextForm_Load(object sender, EventArgs e)
        {
            // Create a default dictation grammar.  
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.AppendDictation();

            Grammar grammar = new Grammar(gBuilder);

            // Create the spelling dictation grammar.  
            DictationGrammar spellingDictationGrammar =
              new DictationGrammar("grammar:dictation#spelling");
            spellingDictationGrammar.Name = "spelling dictation";
            spellingDictationGrammar.Enabled = true;

            recognitionEngine.LoadGrammar(grammar);
            recognitionEngine.LoadGrammar(spellingDictationGrammar);
            recognitionEngine.SetInputToDefaultAudioDevice();
            recognitionEngine.SpeechRecognized += RecognitionEngine_SpeechRecognized;

            // stopwatch
            stopWatch = new Stopwatch();
        }

        private void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //stopWatch.Start();
            DateTime start = DateTime.Now;
            richTextBox.Text += string.Format("{0:ss: ffff}", start);
            richTextBox.Text += "\n " + e.Result.Text + " : \n";
            DateTime end = DateTime.Now;
            richTextBox.Text += string.Format("{0:ss:ffff} \n", end);
            //stopWatch.Reset();
            // date time now start minus end
        }

        private void stopBttn_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsyncStop();
            stopWatch.Stop();
            stopBttn.Enabled = false;
            enableVoiceBttn.Enabled = true;
        }

        private void enableVoiceBttn_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            enableVoiceBttn.Enabled = false;
            stopBttn.Enabled = true;
            richTextBox.Clear();
        }

    }

}
