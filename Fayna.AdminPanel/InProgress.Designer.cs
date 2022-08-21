namespace Fayna.AdminPanel
{
    partial class InProgress
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
            this.InProgressLabel = new System.Windows.Forms.Label();
            this.InProgressProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // InProgressLabel
            // 
            this.InProgressLabel.AutoSize = true;
            this.InProgressLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InProgressLabel.Location = new System.Drawing.Point(85, 9);
            this.InProgressLabel.Name = "InProgressLabel";
            this.InProgressLabel.Size = new System.Drawing.Size(128, 25);
            this.InProgressLabel.TabIndex = 0;
            this.InProgressLabel.Text = "In Progress...";
            this.InProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InProgressProgressBar
            // 
            this.InProgressProgressBar.Location = new System.Drawing.Point(6, 37);
            this.InProgressProgressBar.Name = "InProgressProgressBar";
            this.InProgressProgressBar.Size = new System.Drawing.Size(297, 16);
            this.InProgressProgressBar.TabIndex = 1;
            // 
            // InProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 65);
            this.ControlBox = false;
            this.Controls.Add(this.InProgressProgressBar);
            this.Controls.Add(this.InProgressLabel);
            this.Name = "InProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InProgress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label InProgressLabel;
        private ProgressBar InProgressProgressBar;
    }
}