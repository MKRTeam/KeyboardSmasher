using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsSDK
{
    public partial class EditEventForm : Form
    {
        public EditEventForm()
        {
            InitializeComponent();
        }

        private void btnCreateAction_Click(object sender, EventArgs e)
        {
            EditActionForm editActionForm = new EditActionForm();
            editActionForm.ShowDialog();
        }

        private void btnEditAction_Click(object sender, EventArgs e)
        {

        }
    }
}
