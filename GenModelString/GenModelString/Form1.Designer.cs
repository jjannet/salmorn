namespace GenModelString
{
    partial class Form1
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
            this.tbInput = new System.Windows.Forms.RichTextBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(12, 41);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(530, 491);
            this.tbInput.TabIndex = 0;
            this.tbInput.Text = "";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(12, 12);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 1;
            this.btnGen.Text = "Generate";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(548, 41);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(530, 491);
            this.tbOutput.TabIndex = 0;
            this.tbOutput.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 547);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbInput;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.RichTextBox tbOutput;
    }
}

