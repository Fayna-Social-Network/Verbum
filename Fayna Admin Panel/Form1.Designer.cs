namespace Fayna_Admin_Panel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SettingsConnectionStringLabel = new System.Windows.Forms.Label();
            this.SettingsDatabaseConnectionGroupBox = new System.Windows.Forms.GroupBox();
            this.SettingsConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.SettingsDatabasePasswordLabel = new System.Windows.Forms.Label();
            this.SettingsDatabasePasswordTextBox = new System.Windows.Forms.TextBox();
            this.SettingsDatabaseSaveButton = new System.Windows.Forms.Button();
            this.StickersSelectGroupLabel = new System.Windows.Forms.Label();
            this.StickersSelectGroupListBox = new System.Windows.Forms.ListBox();
            this.StickersAddGroupButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SettingsDatabaseConnectionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.StickersAddGroupButton);
            this.tabPage1.Controls.Add(this.StickersSelectGroupListBox);
            this.tabPage1.Controls.Add(this.StickersSelectGroupLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "stickers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SettingsDatabaseConnectionGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SettingsConnectionStringLabel
            // 
            this.SettingsConnectionStringLabel.AutoSize = true;
            this.SettingsConnectionStringLabel.Location = new System.Drawing.Point(6, 21);
            this.SettingsConnectionStringLabel.Name = "SettingsConnectionStringLabel";
            this.SettingsConnectionStringLabel.Size = new System.Drawing.Size(106, 15);
            this.SettingsConnectionStringLabel.TabIndex = 0;
            this.SettingsConnectionStringLabel.Text = "Connection String:";
            // 
            // SettingsDatabaseConnectionGroupBox
            // 
            this.SettingsDatabaseConnectionGroupBox.Controls.Add(this.SettingsDatabaseSaveButton);
            this.SettingsDatabaseConnectionGroupBox.Controls.Add(this.SettingsDatabasePasswordTextBox);
            this.SettingsDatabaseConnectionGroupBox.Controls.Add(this.SettingsDatabasePasswordLabel);
            this.SettingsDatabaseConnectionGroupBox.Controls.Add(this.SettingsConnectionStringTextBox);
            this.SettingsDatabaseConnectionGroupBox.Controls.Add(this.SettingsConnectionStringLabel);
            this.SettingsDatabaseConnectionGroupBox.Location = new System.Drawing.Point(27, 21);
            this.SettingsDatabaseConnectionGroupBox.Name = "SettingsDatabaseConnectionGroupBox";
            this.SettingsDatabaseConnectionGroupBox.Size = new System.Drawing.Size(319, 190);
            this.SettingsDatabaseConnectionGroupBox.TabIndex = 1;
            this.SettingsDatabaseConnectionGroupBox.TabStop = false;
            this.SettingsDatabaseConnectionGroupBox.Text = "Database Connection";
            // 
            // SettingsConnectionStringTextBox
            // 
            this.SettingsConnectionStringTextBox.Location = new System.Drawing.Point(8, 46);
            this.SettingsConnectionStringTextBox.Name = "SettingsConnectionStringTextBox";
            this.SettingsConnectionStringTextBox.Size = new System.Drawing.Size(288, 23);
            this.SettingsConnectionStringTextBox.TabIndex = 1;
            // 
            // SettingsDatabasePasswordLabel
            // 
            this.SettingsDatabasePasswordLabel.AutoSize = true;
            this.SettingsDatabasePasswordLabel.Location = new System.Drawing.Point(6, 86);
            this.SettingsDatabasePasswordLabel.Name = "SettingsDatabasePasswordLabel";
            this.SettingsDatabasePasswordLabel.Size = new System.Drawing.Size(111, 15);
            this.SettingsDatabasePasswordLabel.TabIndex = 2;
            this.SettingsDatabasePasswordLabel.Text = "Database Password:";
            // 
            // SettingsDatabasePasswordTextBox
            // 
            this.SettingsDatabasePasswordTextBox.Location = new System.Drawing.Point(6, 114);
            this.SettingsDatabasePasswordTextBox.Name = "SettingsDatabasePasswordTextBox";
            this.SettingsDatabasePasswordTextBox.Size = new System.Drawing.Size(288, 23);
            this.SettingsDatabasePasswordTextBox.TabIndex = 3;
            // 
            // SettingsDatabaseSaveButton
            // 
            this.SettingsDatabaseSaveButton.Location = new System.Drawing.Point(188, 155);
            this.SettingsDatabaseSaveButton.Name = "SettingsDatabaseSaveButton";
            this.SettingsDatabaseSaveButton.Size = new System.Drawing.Size(106, 23);
            this.SettingsDatabaseSaveButton.TabIndex = 2;
            this.SettingsDatabaseSaveButton.Text = "Save";
            this.SettingsDatabaseSaveButton.UseVisualStyleBackColor = true;
            // 
            // StickersSelectGroupLabel
            // 
            this.StickersSelectGroupLabel.AutoSize = true;
            this.StickersSelectGroupLabel.Location = new System.Drawing.Point(17, 18);
            this.StickersSelectGroupLabel.Name = "StickersSelectGroupLabel";
            this.StickersSelectGroupLabel.Size = new System.Drawing.Size(74, 15);
            this.StickersSelectGroupLabel.TabIndex = 0;
            this.StickersSelectGroupLabel.Text = "Select Group";
            // 
            // StickersSelectGroupListBox
            // 
            this.StickersSelectGroupListBox.FormattingEnabled = true;
            this.StickersSelectGroupListBox.ItemHeight = 15;
            this.StickersSelectGroupListBox.Location = new System.Drawing.Point(17, 48);
            this.StickersSelectGroupListBox.Name = "StickersSelectGroupListBox";
            this.StickersSelectGroupListBox.Size = new System.Drawing.Size(204, 304);
            this.StickersSelectGroupListBox.TabIndex = 1;
            // 
            // StickersAddGroupButton
            // 
            this.StickersAddGroupButton.Location = new System.Drawing.Point(116, 6);
            this.StickersAddGroupButton.Name = "StickersAddGroupButton";
            this.StickersAddGroupButton.Size = new System.Drawing.Size(105, 36);
            this.StickersAddGroupButton.TabIndex = 2;
            this.StickersAddGroupButton.Text = "Add Group";
            this.StickersAddGroupButton.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(306, 48);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Fayna Admin Panel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.SettingsDatabaseConnectionGroupBox.ResumeLayout(false);
            this.SettingsDatabaseConnectionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button StickersAddGroupButton;
        private ListBox StickersSelectGroupListBox;
        private Label StickersSelectGroupLabel;
        private TabPage tabPage2;
        private GroupBox SettingsDatabaseConnectionGroupBox;
        private Button SettingsDatabaseSaveButton;
        private TextBox SettingsDatabasePasswordTextBox;
        private Label SettingsDatabasePasswordLabel;
        private TextBox SettingsConnectionStringTextBox;
        private Label SettingsConnectionStringLabel;
        private ListView listView1;
    }
}