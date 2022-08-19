namespace Fayna.AdminPanel
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("cat", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.StickersApplyButton = new System.Windows.Forms.Button();
            this.StickersDeleteImageButton = new System.Windows.Forms.Button();
            this.StickersAddImageButton = new System.Windows.Forms.Button();
            this.StickerDeleteGroupButton = new System.Windows.Forms.Button();
            this.StickersAddGroupButton = new System.Windows.Forms.Button();
            this.StickersImagesLabel = new System.Windows.Forms.Label();
            this.StickersGroupsLabel = new System.Windows.Forms.Label();
            this.StikersPictureListView = new System.Windows.Forms.ListView();
            this.StickersImageList = new System.Windows.Forms.ImageList(this.components);
            this.StickersGroupsListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DatabaseConnectionGroupBox = new System.Windows.Forms.GroupBox();
            this.SettingsDbConnectButton = new System.Windows.Forms.Button();
            this.SettingsDbPasswordTextBox = new System.Windows.Forms.TextBox();
            this.SettingsDbPasswordLabel = new System.Windows.Forms.Label();
            this.SettingsDbUsernameTextBox = new System.Windows.Forms.TextBox();
            this.SettingsDbUsernameLabel = new System.Windows.Forms.Label();
            this.SettingsDbNameTextBox = new System.Windows.Forms.TextBox();
            this.SettingsDbNameLabel = new System.Windows.Forms.Label();
            this.SettingsDbSaveButton = new System.Windows.Forms.Button();
            this.SettingsDbPortTextBox = new System.Windows.Forms.TextBox();
            this.SettingsDbPortLabel = new System.Windows.Forms.Label();
            this.SettingHostTextBox = new System.Windows.Forms.TextBox();
            this.SettingDbHostLabel = new System.Windows.Forms.Label();
            this.StickersOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.DatabaseConnectionGroupBox.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.StickersApplyButton);
            this.tabPage1.Controls.Add(this.StickersDeleteImageButton);
            this.tabPage1.Controls.Add(this.StickersAddImageButton);
            this.tabPage1.Controls.Add(this.StickerDeleteGroupButton);
            this.tabPage1.Controls.Add(this.StickersAddGroupButton);
            this.tabPage1.Controls.Add(this.StickersImagesLabel);
            this.tabPage1.Controls.Add(this.StickersGroupsLabel);
            this.tabPage1.Controls.Add(this.StikersPictureListView);
            this.tabPage1.Controls.Add(this.StickersGroupsListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stickers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // StickersApplyButton
            // 
            this.StickersApplyButton.Location = new System.Drawing.Point(632, 6);
            this.StickersApplyButton.Name = "StickersApplyButton";
            this.StickersApplyButton.Size = new System.Drawing.Size(101, 28);
            this.StickersApplyButton.TabIndex = 8;
            this.StickersApplyButton.Text = "Apply";
            this.StickersApplyButton.UseVisualStyleBackColor = true;
            // 
            // StickersDeleteImageButton
            // 
            this.StickersDeleteImageButton.Location = new System.Drawing.Point(412, 13);
            this.StickersDeleteImageButton.Name = "StickersDeleteImageButton";
            this.StickersDeleteImageButton.Size = new System.Drawing.Size(54, 21);
            this.StickersDeleteImageButton.TabIndex = 7;
            this.StickersDeleteImageButton.Text = "Del";
            this.StickersDeleteImageButton.UseVisualStyleBackColor = true;
            // 
            // StickersAddImageButton
            // 
            this.StickersAddImageButton.Location = new System.Drawing.Point(352, 13);
            this.StickersAddImageButton.Name = "StickersAddImageButton";
            this.StickersAddImageButton.Size = new System.Drawing.Size(54, 21);
            this.StickersAddImageButton.TabIndex = 6;
            this.StickersAddImageButton.Text = "Add";
            this.StickersAddImageButton.UseVisualStyleBackColor = true;
            this.StickersAddImageButton.Click += new System.EventHandler(this.StickersAddImageButton_Click);
            // 
            // StickerDeleteGroupButton
            // 
            this.StickerDeleteGroupButton.Location = new System.Drawing.Point(217, 13);
            this.StickerDeleteGroupButton.Name = "StickerDeleteGroupButton";
            this.StickerDeleteGroupButton.Size = new System.Drawing.Size(54, 21);
            this.StickerDeleteGroupButton.TabIndex = 5;
            this.StickerDeleteGroupButton.Text = "Del";
            this.StickerDeleteGroupButton.UseVisualStyleBackColor = true;
            // 
            // StickersAddGroupButton
            // 
            this.StickersAddGroupButton.Location = new System.Drawing.Point(157, 13);
            this.StickersAddGroupButton.Name = "StickersAddGroupButton";
            this.StickersAddGroupButton.Size = new System.Drawing.Size(54, 21);
            this.StickersAddGroupButton.TabIndex = 4;
            this.StickersAddGroupButton.Text = "Add";
            this.StickersAddGroupButton.UseVisualStyleBackColor = true;
            this.StickersAddGroupButton.Click += new System.EventHandler(this.StickersAddGroupButton_Click);
            // 
            // StickersImagesLabel
            // 
            this.StickersImagesLabel.AutoSize = true;
            this.StickersImagesLabel.Location = new System.Drawing.Point(291, 17);
            this.StickersImagesLabel.Name = "StickersImagesLabel";
            this.StickersImagesLabel.Size = new System.Drawing.Size(44, 15);
            this.StickersImagesLabel.TabIndex = 3;
            this.StickersImagesLabel.Text = "Stikers:";
            // 
            // StickersGroupsLabel
            // 
            this.StickersGroupsLabel.AutoSize = true;
            this.StickersGroupsLabel.Location = new System.Drawing.Point(14, 17);
            this.StickersGroupsLabel.Name = "StickersGroupsLabel";
            this.StickersGroupsLabel.Size = new System.Drawing.Size(48, 15);
            this.StickersGroupsLabel.TabIndex = 2;
            this.StickersGroupsLabel.Text = "Groups:";
            // 
            // StikersPictureListView
            // 
            this.StikersPictureListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.StikersPictureListView.LargeImageList = this.StickersImageList;
            this.StikersPictureListView.Location = new System.Drawing.Point(291, 40);
            this.StikersPictureListView.Name = "StikersPictureListView";
            this.StikersPictureListView.Size = new System.Drawing.Size(457, 334);
            this.StikersPictureListView.SmallImageList = this.StickersImageList;
            this.StikersPictureListView.TabIndex = 1;
            this.StikersPictureListView.UseCompatibleStateImageBehavior = false;
            // 
            // StickersImageList
            // 
            this.StickersImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.StickersImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StickersImageList.ImageStream")));
            this.StickersImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.StickersImageList.Images.SetKeyName(0, "1.gif");
            this.StickersImageList.Images.SetKeyName(1, "2.gif");
            this.StickersImageList.Images.SetKeyName(2, "3.gif");
            this.StickersImageList.Images.SetKeyName(3, "4.gif");
            // 
            // StickersGroupsListBox
            // 
            this.StickersGroupsListBox.FormattingEnabled = true;
            this.StickersGroupsListBox.ItemHeight = 15;
            this.StickersGroupsListBox.Location = new System.Drawing.Point(15, 40);
            this.StickersGroupsListBox.Name = "StickersGroupsListBox";
            this.StickersGroupsListBox.Size = new System.Drawing.Size(256, 334);
            this.StickersGroupsListBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DatabaseConnectionGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DatabaseConnectionGroupBox
            // 
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbConnectButton);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbPasswordTextBox);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbPasswordLabel);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbUsernameTextBox);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbUsernameLabel);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbNameTextBox);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbNameLabel);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbSaveButton);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbPortTextBox);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingsDbPortLabel);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingHostTextBox);
            this.DatabaseConnectionGroupBox.Controls.Add(this.SettingDbHostLabel);
            this.DatabaseConnectionGroupBox.Location = new System.Drawing.Point(6, 6);
            this.DatabaseConnectionGroupBox.Name = "DatabaseConnectionGroupBox";
            this.DatabaseConnectionGroupBox.Size = new System.Drawing.Size(302, 368);
            this.DatabaseConnectionGroupBox.TabIndex = 0;
            this.DatabaseConnectionGroupBox.TabStop = false;
            this.DatabaseConnectionGroupBox.Text = "Database Connection";
            // 
            // SettingsDbConnectButton
            // 
            this.SettingsDbConnectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsDbConnectButton.Location = new System.Drawing.Point(14, 324);
            this.SettingsDbConnectButton.Name = "SettingsDbConnectButton";
            this.SettingsDbConnectButton.Size = new System.Drawing.Size(97, 28);
            this.SettingsDbConnectButton.TabIndex = 10;
            this.SettingsDbConnectButton.Text = "Connect";
            this.SettingsDbConnectButton.UseVisualStyleBackColor = true;
            this.SettingsDbConnectButton.Click += new System.EventHandler(this.SettingsDbConnectButton_Click);
            // 
            // SettingsDbPasswordTextBox
            // 
            this.SettingsDbPasswordTextBox.Location = new System.Drawing.Point(14, 274);
            this.SettingsDbPasswordTextBox.Name = "SettingsDbPasswordTextBox";
            this.SettingsDbPasswordTextBox.Size = new System.Drawing.Size(276, 23);
            this.SettingsDbPasswordTextBox.TabIndex = 9;
            // 
            // SettingsDbPasswordLabel
            // 
            this.SettingsDbPasswordLabel.AutoSize = true;
            this.SettingsDbPasswordLabel.Location = new System.Drawing.Point(12, 250);
            this.SettingsDbPasswordLabel.Name = "SettingsDbPasswordLabel";
            this.SettingsDbPasswordLabel.Size = new System.Drawing.Size(60, 15);
            this.SettingsDbPasswordLabel.TabIndex = 8;
            this.SettingsDbPasswordLabel.Text = "Password:";
            // 
            // SettingsDbUsernameTextBox
            // 
            this.SettingsDbUsernameTextBox.Location = new System.Drawing.Point(14, 219);
            this.SettingsDbUsernameTextBox.Name = "SettingsDbUsernameTextBox";
            this.SettingsDbUsernameTextBox.Size = new System.Drawing.Size(276, 23);
            this.SettingsDbUsernameTextBox.TabIndex = 7;
            // 
            // SettingsDbUsernameLabel
            // 
            this.SettingsDbUsernameLabel.AutoSize = true;
            this.SettingsDbUsernameLabel.Location = new System.Drawing.Point(12, 195);
            this.SettingsDbUsernameLabel.Name = "SettingsDbUsernameLabel";
            this.SettingsDbUsernameLabel.Size = new System.Drawing.Size(63, 15);
            this.SettingsDbUsernameLabel.TabIndex = 6;
            this.SettingsDbUsernameLabel.Text = "Username:";
            // 
            // SettingsDbNameTextBox
            // 
            this.SettingsDbNameTextBox.Location = new System.Drawing.Point(14, 166);
            this.SettingsDbNameTextBox.Name = "SettingsDbNameTextBox";
            this.SettingsDbNameTextBox.Size = new System.Drawing.Size(276, 23);
            this.SettingsDbNameTextBox.TabIndex = 5;
            // 
            // SettingsDbNameLabel
            // 
            this.SettingsDbNameLabel.AutoSize = true;
            this.SettingsDbNameLabel.Location = new System.Drawing.Point(12, 142);
            this.SettingsDbNameLabel.Name = "SettingsDbNameLabel";
            this.SettingsDbNameLabel.Size = new System.Drawing.Size(58, 15);
            this.SettingsDbNameLabel.TabIndex = 4;
            this.SettingsDbNameLabel.Text = "Database:";
            // 
            // SettingsDbSaveButton
            // 
            this.SettingsDbSaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsDbSaveButton.Location = new System.Drawing.Point(191, 324);
            this.SettingsDbSaveButton.Name = "SettingsDbSaveButton";
            this.SettingsDbSaveButton.Size = new System.Drawing.Size(97, 28);
            this.SettingsDbSaveButton.TabIndex = 1;
            this.SettingsDbSaveButton.Text = "Save";
            this.SettingsDbSaveButton.UseVisualStyleBackColor = true;
            this.SettingsDbSaveButton.Click += new System.EventHandler(this.SettingsDbSaveButton_Click);
            // 
            // SettingsDbPortTextBox
            // 
            this.SettingsDbPortTextBox.Location = new System.Drawing.Point(12, 109);
            this.SettingsDbPortTextBox.Name = "SettingsDbPortTextBox";
            this.SettingsDbPortTextBox.Size = new System.Drawing.Size(276, 23);
            this.SettingsDbPortTextBox.TabIndex = 3;
            // 
            // SettingsDbPortLabel
            // 
            this.SettingsDbPortLabel.AutoSize = true;
            this.SettingsDbPortLabel.Location = new System.Drawing.Point(10, 85);
            this.SettingsDbPortLabel.Name = "SettingsDbPortLabel";
            this.SettingsDbPortLabel.Size = new System.Drawing.Size(32, 15);
            this.SettingsDbPortLabel.TabIndex = 2;
            this.SettingsDbPortLabel.Text = "Port:";
            // 
            // SettingHostTextBox
            // 
            this.SettingHostTextBox.Location = new System.Drawing.Point(12, 53);
            this.SettingHostTextBox.Name = "SettingHostTextBox";
            this.SettingHostTextBox.Size = new System.Drawing.Size(276, 23);
            this.SettingHostTextBox.TabIndex = 1;
            // 
            // SettingDbHostLabel
            // 
            this.SettingDbHostLabel.AutoSize = true;
            this.SettingDbHostLabel.Location = new System.Drawing.Point(10, 30);
            this.SettingDbHostLabel.Name = "SettingDbHostLabel";
            this.SettingDbHostLabel.Size = new System.Drawing.Size(35, 15);
            this.SettingDbHostLabel.TabIndex = 0;
            this.SettingDbHostLabel.Text = "Host:";
            // 
            // StickersOpenFileDialog
            // 
            this.StickersOpenFileDialog.FileName = "*.gif";
            this.StickersOpenFileDialog.Multiselect = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Fayna Admin Panel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.DatabaseConnectionGroupBox.ResumeLayout(false);
            this.DatabaseConnectionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox DatabaseConnectionGroupBox;
        private Label SettingsDbPortLabel;
        private TextBox SettingHostTextBox;
        private Label SettingDbHostLabel;
        private Button SettingsDbSaveButton;
        private TextBox SettingsDbPortTextBox;
        private TextBox SettingsDbPasswordTextBox;
        private Label SettingsDbPasswordLabel;
        private TextBox SettingsDbUsernameTextBox;
        private Label SettingsDbUsernameLabel;
        private TextBox SettingsDbNameTextBox;
        private Label SettingsDbNameLabel;
        private Button StickersApplyButton;
        private Button StickersDeleteImageButton;
        private Button StickersAddImageButton;
        private Button StickerDeleteGroupButton;
        private Button StickersAddGroupButton;
        private Label StickersImagesLabel;
        private Label StickersGroupsLabel;
        private ListView StikersPictureListView;
        private ListBox StickersGroupsListBox;
        private ImageList StickersImageList;
        private OpenFileDialog StickersOpenFileDialog;
        private Button SettingsDbConnectButton;
        private Label label1;
    }
}