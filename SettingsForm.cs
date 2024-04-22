using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocalConnect
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.kHZoomCode = kHZoomCodeTextbox.Text;
            Properties.Settings.Default.kHZoomID = kHZoomIDTextbox.Text;
            Properties.Settings.Default.ministryZoomCode = ministryZoomCodeTextbox.Text;
            Properties.Settings.Default.ministryZoomID = ministryZoomIDTextbox.Text;
            Properties.Settings.Default.groupZoomCode = groupZoomCodeTextbox.Text;
            Properties.Settings.Default.groupZoomID = groupZoomIDTextbox.Text;

            Properties.Settings.Default.Save();
        }
    }
}
