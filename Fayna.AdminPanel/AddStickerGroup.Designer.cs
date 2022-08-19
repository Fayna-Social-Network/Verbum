namespace Fayna.AdminPanel
{
    partial class AddStickerGroup
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
            this.AddStickerGroupLabel = new System.Windows.Forms.Label();
            this.AddStickerGroupTextBox = new System.Windows.Forms.TextBox();
            this.AddStickerGroupAddButton = new System.Windows.Forms.Button();
            this.AddStickerGroupCancelButton = new System.Windows.Forms.Button();
            this.AddStickersGroupWaitLabel = new System.Windows.Forms.Label();
            this.AddStickersGroupPanel = new System.Windows.Forms.Panel();
            this.AddStickersGroupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddStickerGroupLabel
            // 
            this.AddStickerGroupLabel.AutoSize = true;
            this.AddStickerGroupLabel.Location = new System.Drawing.Point(12, 21);
            this.AddStickerGroupLabel.Name = "AddStickerGroupLabel";
            this.AddStickerGroupLabel.Size = new System.Drawing.Size(78, 15);
            this.AddStickerGroupLabel.TabIndex = 0;
            this.AddStickerGroupLabel.Text = "Group Name:";
            // 
            // AddStickerGroupTextBox
            // 
            this.AddStickerGroupTextBox.Location = new System.Drawing.Point(12, 50);
            this.AddStickerGroupTextBox.Name = "AddStickerGroupTextBox";
            this.AddStickerGroupTextBox.Size = new System.Drawing.Size(318, 23);
            this.AddStickerGroupTextBox.TabIndex = 1;
            // 
            // AddStickerGroupAddButton
            // 
            this.AddStickerGroupAddButton.Location = new System.Drawing.Point(144, 89);
            this.AddStickerGroupAddButton.Name = "AddStickerGroupAddButton";
            this.AddStickerGroupAddButton.Size = new System.Drawing.Size(75, 23);
            this.AddStickerGroupAddButton.TabIndex = 2;
            this.AddStickerGroupAddButton.Text = "Add";
            this.AddStickerGroupAddButton.UseVisualStyleBackColor = true;
            this.AddStickerGroupAddButton.Click += new System.EventHandler(this.AddStickerGroupAddButton_Click);
            // 
            // AddStickerGroupCancelButton
            // 
            this.AddStickerGroupCancelButton.Location = new System.Drawing.Point(236, 89);
            this.AddStickerGroupCancelButton.Name = "AddStickerGroupCancelButton";
            this.AddStickerGroupCancelButton.Size = new System.Drawing.Size(75, 23);
            this.AddStickerGroupCancelButton.TabIndex = 3;
            this.AddStickerGroupCancelButton.Text = "Cancel";
            this.AddStickerGroupCancelButton.UseVisualStyleBackColor = true;
            this.AddStickerGroupCancelButton.Click += new System.EventHandler(this.AddStickerGroupCancelButton_Click);
            // 
            // AddStickersGroupWaitLabel
            // 
            this.AddStickersGroupWaitLabel.AutoSize = true;
            this.AddStickersGroupWaitLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddStickersGroupWaitLabel.Location = new System.Drawing.Point(108, 57);
            this.AddStickersGroupWaitLabel.Name = "AddStickersGroupWaitLabel";
            this.AddStickersGroupWaitLabel.Size = new System.Drawing.Size(91, 17);
            this.AddStickersGroupWaitLabel.TabIndex = 4;
            this.AddStickersGroupWaitLabel.Text = "Please Wait...";
            // 
            // AddStickersGroupPanel
            // 
            this.AddStickersGroupPanel.Controls.Add(this.AddStickerGroupTextBox);
            this.AddStickersGroupPanel.Controls.Add(this.AddStickerGroupLabel);
            this.AddStickersGroupPanel.Controls.Add(this.AddStickerGroupCancelButton);
            this.AddStickersGroupPanel.Controls.Add(this.AddStickerGroupAddButton);
            this.AddStickersGroupPanel.Location = new System.Drawing.Point(0, 1);
            this.AddStickersGroupPanel.Name = "AddStickersGroupPanel";
            this.AddStickersGroupPanel.Size = new System.Drawing.Size(354, 164);
            this.AddStickersGroupPanel.TabIndex = 5;
            // 
            // AddStickerGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 125);
            this.Controls.Add(this.AddStickersGroupPanel);
            this.Controls.Add(this.AddStickersGroupWaitLabel);
            this.MaximumSize = new System.Drawing.Size(354, 164);
            this.MinimumSize = new System.Drawing.Size(354, 164);
            this.Name = "AddStickerGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Sticker Group";
            this.AddStickersGroupPanel.ResumeLayout(false);
            this.AddStickersGroupPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label AddStickerGroupLabel;
        private TextBox AddStickerGroupTextBox;
        private Button AddStickerGroupAddButton;
        private Button AddStickerGroupCancelButton;
        private Label AddStickersGroupWaitLabel;
        private Panel AddStickersGroupPanel;
    }
}