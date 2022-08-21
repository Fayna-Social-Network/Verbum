using Fayna.AdminPanel.Models;

namespace Fayna.AdminPanel
{
    public partial class AddStickerGroup : Form
    {

        private List<StickersGroup> groups;
        private ListBox listBox;

        public AddStickerGroup(List<StickersGroup> groups, ListBox listBox)
        {
            InitializeComponent();
            this.groups = groups;
            this.listBox = listBox;
        }

        private void AddStickerGroupCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void AddStickerGroupAddButton_Click(object sender, EventArgs e)
        {
            char[] charsToTrim = {' '};
            string result = AddStickerGroupTextBox.Text.Trim(charsToTrim);

            if (!String.IsNullOrEmpty(result))
            {
                VerbumDbContext _dbContext = new VerbumDbContext();
                //InProgress progress = new InProgress();

                string GroupName = AddStickerGroupTextBox.Text;

                AddStickersGroupPanel.Visible = false;
               // progress.ShowDialog();

                try
                {
                    var stickersGroup = new StickersGroup
                    {
                        Id = Guid.NewGuid(),
                        Name = GroupName,
                    };

                    await _dbContext.StickersGroups.AddAsync(stickersGroup);
                    await _dbContext.SaveChangesAsync();
                    groups.Add(stickersGroup);
                    listBox.Items.Add(stickersGroup.Name);
                    //progress.Close();
                    MessageBox.Show("Sticker Group Saved Successfully!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch
                {
                    MessageBox.Show("Sticker Group Saved Error!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }


            }
            else 
            {
                MessageBox.Show("Please enter correct group name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
