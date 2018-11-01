using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.Wave;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Grpc.Auth;

namespace BuiltInSpeechRecognition
{
    public partial class SpeechToTextForm : Form
    {
        private BufferedWaveProvider bwp;

        WaveIn waveIn;
        WaveOut waveOut;
        WaveFileWriter writer;
        WaveFileReader reader;
        string output = "audio.raw";

        public SpeechToTextForm()
        {
            InitializeComponent();

            waveOut = new WaveOut();
            waveIn = new WaveIn();

            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            bwp.DiscardOnBufferOverflow = true;
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);

        }

        private void SpeechToTextForm_Load(object sender, EventArgs e)
        {
            
        }

        private void stopBttn_Click(object sender, EventArgs e)
        {
            
            stopBttn.Enabled = false;
            enableVoiceBttn.Enabled = true;
        }

        private void enableVoiceBttn_Click(object sender, EventArgs e)
        {
            if (NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                Console.WriteLine("No microphone!");
                return;
            }

            waveIn.StartRecording();

            stopBttn.Enabled = true;
            enableVoiceBttn.Enabled = false;
        }
    }

}
