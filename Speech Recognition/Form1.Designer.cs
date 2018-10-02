namespace Speech_Recognition
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.enableVoiceBttn = new System.Windows.Forms.Button();
            this.disableVoiceBttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(12, 33);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(776, 348);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "-Log-";
            // 
            // enableVoiceBttn
            // 
            this.enableVoiceBttn.Location = new System.Drawing.Point(310, 415);
            this.enableVoiceBttn.Name = "enableVoiceBttn";
            this.enableVoiceBttn.Size = new System.Drawing.Size(75, 23);
            this.enableVoiceBttn.TabIndex = 1;
            this.enableVoiceBttn.Text = "Enable";
            this.enableVoiceBttn.UseVisualStyleBackColor = true;
            this.enableVoiceBttn.Click += new System.EventHandler(this.enableVoiceBttn_Click);
            // 
            // disableVoiceBttn
            // 
            this.disableVoiceBttn.Enabled = false;
            this.disableVoiceBttn.Location = new System.Drawing.Point(415, 415);
            this.disableVoiceBttn.Name = "disableVoiceBttn";
            this.disableVoiceBttn.Size = new System.Drawing.Size(75, 23);
            this.disableVoiceBttn.TabIndex = 2;
            this.disableVoiceBttn.Text = "Disable";
            this.disableVoiceBttn.UseVisualStyleBackColor = true;
            this.disableVoiceBttn.Click += new System.EventHandler(this.disableVoiceBttn_Click);
            // 
            // SpeechToTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.disableVoiceBttn);
            this.Controls.Add(this.enableVoiceBttn);
            this.Controls.Add(this.richTextBox);
            this.Name = "SpeechToTextForm";
            this.Text = "Speech to Text ";
            this.Load += new System.EventHandler(this.SpeechToTextForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button enableVoiceBttn;
        private System.Windows.Forms.Button disableVoiceBttn;
    }
}

