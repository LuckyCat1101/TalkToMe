namespace BuiltInSpeechRecognition
{
    partial class SpeechToTextForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.enableVoiceBttn = new System.Windows.Forms.Button();
            this.disableBttn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // enableVoiceBttn
            // 
            this.enableVoiceBttn.Location = new System.Drawing.Point(36, 417);
            this.enableVoiceBttn.Name = "enableVoiceBttn";
            this.enableVoiceBttn.Size = new System.Drawing.Size(184, 30);
            this.enableVoiceBttn.TabIndex = 0;
            this.enableVoiceBttn.Text = "Enable Voice Recording";
            this.enableVoiceBttn.UseVisualStyleBackColor = true;
            // 
            // disableBttn
            // 
            this.disableBttn.Location = new System.Drawing.Point(237, 417);
            this.disableBttn.Name = "disableBttn";
            this.disableBttn.Size = new System.Drawing.Size(184, 30);
            this.disableBttn.TabIndex = 1;
            this.disableBttn.Text = "Disable Voice Recording";
            this.disableBttn.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(438, 380);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // SpeechToTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 459);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.disableBttn);
            this.Controls.Add(this.enableVoiceBttn);
            this.Name = "SpeechToTextForm";
            this.Text = "STT Text";
            this.Load += new System.EventHandler(this.SpeechToTextForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button enableVoiceBttn;
        private System.Windows.Forms.Button disableBttn;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

