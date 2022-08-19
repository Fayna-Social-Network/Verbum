
using Fayna.AdminPanel.Models;
using Microsoft.EntityFrameworkCore;

namespace Fayna.AdminPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        List<StickersGroup> stickersGroups = new List<StickersGroup>();

        private void SettingsDbSaveButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();

            try 
            {
                settings.SaveDbConnection(SettingHostTextBox.Text, SettingsDbPortTextBox.Text,
                    SettingsDbNameTextBox.Text, SettingsDbUsernameTextBox.Text, SettingsDbPasswordTextBox.Text);
                MessageBox.Show("Settings Saved Successfuly!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {

                MessageBox.Show("Settings Save Error!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void StickersAddImageButton_Click(object sender, EventArgs e)
        {
            StickersOpenFileDialog.ShowDialog();
        }

        private void StickersAddGroupButton_Click(object sender, EventArgs e)
        {

            AddStickerGroup addStickerGroup = new AddStickerGroup(this.stickersGroups, this.StickersGroupsListBox);
            addStickerGroup.ShowDialog();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings settings = new Settings();

            List<string> DbData = settings.GetDbSettings();

            if (DbData.Count > 0) 
            {
                SettingHostTextBox.Text = DbData[0];
                SettingsDbPortTextBox.Text = DbData[1];
                SettingsDbNameTextBox.Text = DbData[2];
                SettingsDbUsernameTextBox.Text = DbData[3];
                SettingsDbPasswordTextBox.Text = DbData[4];
            }
        }

        private async void SettingsDbConnectButton_Click(object sender, EventArgs e)
        {
            VerbumDbContext _dbContext = new VerbumDbContext();

            stickersGroups = await _dbContext.StickersGroups.ToListAsync();

            foreach (var item in stickersGroups) 
            {
                StickersGroupsListBox.Items.Add(item.Name);
            }
        }

       
    
    }
}