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
        }

        private void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox.Text += " " + e.Result.Text;

        }

        private void stopBttn_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsyncStop();
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
