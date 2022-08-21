
using Fayna.AdminPanel.Models;
using Fayna.AdminPanel.UploadSticker;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Windows.Forms;

namespace Fayna.AdminPanel
{
    public partial class Form1 : Form
    {
        private VerbumDbContext _dbContext;

        public Form1()
        {
            InitializeComponent();
           _dbContext = new VerbumDbContext();
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
            if (StickersGroupsListBox.SelectedItem != null)
            {
                StickersOpenFileDialog.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Choose a group first");
            }
            
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
            InProgress progress = new InProgress(0);

            progress.Show();
            await Task.Run(async () =>
            {
                stickersGroups = await _dbContext.StickersGroups.ToListAsync();

            });

            foreach (var item in stickersGroups)
            {
                StickersGroupsListBox.Items.Add(item.Name);
            }

            progress.Close();
        }

        private async void StickersGroupsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            ListBox listbox = (ListBox)sender;
            List<Sticker> stickers; 
           
            string selectedName = listbox.SelectedItem.ToString()!;

            var group = stickersGroups.FirstOrDefault(x => x.Name == selectedName);
            stickers = await _dbContext.Stickers.Where(x => x.StickerGroupId == group!.Id).ToListAsync();

            

            if (stickers != null) 
            {
                foreach (var item in stickers) 
                {
                    StickersDataGridView.Rows.Add(item.Id, item.Name, item.Path);
                }
            }
        }

        private void StickerDeleteGroupButton_Click(object sender, EventArgs e)
        {

        }

        private void StickersOpenFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OpenFileDialog dialog = (OpenFileDialog)sender;
            string[] files = dialog.FileNames;

            StickersDataGridView.DataSource = null;

            foreach (string file in files) 
            {
                StickersDataGridView.Rows.Add(Guid.NewGuid(), "", file);
            }
        }

        private async void StickersApplyButton_Click(object sender, EventArgs e)
        {
            int RowCount = StickersDataGridView.RowCount - 1;

            Upload _upload = new Upload();
            InProgress progress = new InProgress(RowCount);

            progress.Show();

            var groupName = StickersGroupsListBox.SelectedItem.ToString();
            var group = stickersGroups.FirstOrDefault(g => g.Name == groupName);

            if (group != null) 
            {
                string uriString = String.Format("https://localhost:7251/api/UploadFiles/sticker/{0}", groupName);

                await Task.Run(async () =>
                {
                   

                    for (int i = 0; i < RowCount; i++)
                    {
                        string Id = StickersDataGridView[0, i].Value.ToString()!;
                        string Name = StickersDataGridView[1, i].Value.ToString()!;
                        string path = StickersDataGridView[2, i].Value.ToString()!;

                        var id = Guid.Parse(Id);
                        var sticker = await _upload.UploadStickerFile(path, id, Name, uriString, group.Id);

                        await _dbContext.Stickers.AddAsync(sticker);

                        progress.ProgressStep(i);

                    }

                    await _dbContext.SaveChangesAsync();

                    
                });

                progress.Close();
            }

           

        }
    }
}