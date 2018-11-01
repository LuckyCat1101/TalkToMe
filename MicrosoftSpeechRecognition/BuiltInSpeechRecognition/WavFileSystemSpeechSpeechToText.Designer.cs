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
            this.stopBttn = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // enableVoiceBttn
            // 
            this.enableVoiceBttn.Location = new System.Drawing.Point(36, 417);
            this.enableVoiceBttn.Name = "enableVoiceBttn";
            this.enableVoiceBttn.Size = new System.Drawing.Size(184, 30);
            this.enableVoiceBttn.TabIndex = 0;
            this.enableVoiceBttn.Text = "Start Voice Recording";
            this.enableVoiceBttn.UseVisualStyleBackColor = true;
            this.enableVoiceBttn.Click += new System.EventHandler(this.enableVoiceBttn_Click);
            // 
            // stopBttn
            // 
            this.stopBttn.Enabled = false;
            this.stopBttn.Location = new System.Drawing.Point(237, 417);
            this.stopBttn.Name = "stopBttn";
            this.stopBttn.Size = new System.Drawing.Size(184, 30);
            this.stopBttn.TabIndex = 1;
            this.stopBttn.Text = "Stop Voice Recording";
            this.stopBttn.UseVisualStyleBackColor = true;
            this.stopBttn.Click += new System.EventHandler(this.stopBttn_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(12, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(438, 380);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            // 
            // SpeechToTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 459);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.stopBttn);
            this.Controls.Add(this.enableVoiceBttn);
            this.Name = "SpeechToTextForm";
            this.Text = "Microsoft Speech: Speech To Text";
            this.Load += new System.EventHandler(this.SpeechToTextForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button enableVoiceBttn;
        private System.Windows.Forms.Button stopBttn;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}

