using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gameplay;
namespace EventsSDK
{
    public partial class EditEventObjectForm : Form
    {
        
        public EditEventObjectForm()
        {
            InitializeComponent();
                
        }
        public EventObject[] EventObjects { get; set; }
        private void btnSaveObject_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            EditEventForm editEventForm = new EditEventForm();
            editEventForm.ShowDialog();
        }
    }
}
