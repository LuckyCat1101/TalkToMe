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

namespace Speech_Recognition
{
    public partial class SpeechToTextForm : Form
    {
        SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
        
        public SpeechToTextForm()
        {
            InitializeComponent();
        }

        private void enableVoiceBttn_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            disableVoiceBttn.Enabled = true;
        }

        private void SpeechToTextForm_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "say hello", "print my name" });
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(commands);
            Grammar grammar = new Grammar(grammarBuilder);

            recognitionEngine.LoadGrammarAsync(grammar);
            recognitionEngine.SetInputToDefaultAudioDevice();
            recognitionEngine.SpeechRecognized += RecognitionEngine_SpeechRecognized;
        }

        private void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "say hello":
                    MessageBox.Show("Hello, how are you?");
                    break;
                case "print my name":
                    richTextBox.Text += "\nVanesa";
                    break;
                default:
                    richTextBox.Text += "\nSorry, I didn't understand that command.";
                    break;
                    

            }
        }

        private void disableVoiceBttn_Click(object sender, EventArgs e)
        {
            recognitionEngine.RecognizeAsyncStop();
            disableVoiceBttn.Enabled = false;
        }
    }
}
