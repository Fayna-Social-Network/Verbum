using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fayna.AdminPanel
{
    public partial class InProgress : Form
    {
        private int count;
       
        public InProgress(int count)
        {
            InitializeComponent();
            this.count = count;
        }

        
        public void ProgressStep(int step) 
        {
            int value;

            if (step != 0)
            {
                value = step / count * 100;
            }
            else {
                value = 0; 
            }
            InProgressProgressBar.Value = value;
        }
    }
}
