namespace WinFormTest.DialogForm
{
    partial class DialogTest
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
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.cbListBox = new System.Windows.Forms.ComboBox();
            this.bwLoad = new System.ComponentModel.BackgroundWorker();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbResult
            // 
            this.rtbResult.Enabled = false;
            this.rtbResult.Location = new System.Drawing.Point(0, 0);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(506, 446);
            this.rtbResult.TabIndex = 0;
            this.rtbResult.Text = "";
            // 
            // cbListBox
            // 
            this.cbListBox.FormattingEnabled = true;
            this.cbListBox.Location = new System.Drawing.Point(512, 12);
            this.cbListBox.Name = "cbListBox";
            this.cbListBox.Size = new System.Drawing.Size(134, 20);
            this.cbListBox.TabIndex = 1;
            this.cbListBox.SelectedIndexChanged += new System.EventHandler(this.CbListBox_SelectedIndexChanged);
            // 
            // bwLoad
            // 
            this.bwLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwLoad_DoWork);
            this.bwLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwLoad_RunWorkerCompleted);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(571, 411);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Close";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // DialogTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(658, 446);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.cbListBox);
            this.Controls.Add(this.rtbResult);
            this.Name = "DialogTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DialogTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.ComboBox cbListBox;
        private System.ComponentModel.BackgroundWorker bwLoad;
        private System.Windows.Forms.Button Cancel;
    }
}