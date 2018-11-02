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
using System.Speech.Synthesis;

namespace Speech_Recognition
{
    public partial class SpeechToTextForm : Form
    {
        SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

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
            commands.Add(new string[] { "say hello", "print my name", "speak selected text" });
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
                    PromptBuilder builder = new PromptBuilder();
                    PromptStyle promptStyle = new PromptStyle(PromptRate.Fast);

                    builder.StartStyle(promptStyle);
                    builder.StartSentence();
                    builder.AppendText("Hello LuckyCat!");
                    builder.EndSentence();

                    builder.StartSentence();
                    builder.AppendText("How are you?");
                    builder.EndSentence();
                    builder.EndStyle();
                    
                   // synthesizer.SelectVoiceByHints(VoiceGender.Female);
                    
                    synthesizer.SpeakAsync(builder);
                    break;
                case "print my name":
                    richTextBox.Text += "\nLuckyCat1101";
                    break;
                case "speak selected text":
                    synthesizer.SpeakAsync(richTextBox.SelectedText);
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
