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
    public partial class EditBiomForm : Form
    {
        public EditBiomForm()
        {
            InitializeComponent();
        }
        public Biom Biom{ set; get; }
        EventObject[] eventObjects;
        private void btnCreateObject_Click(object sender, EventArgs e)
        {
            EditEventObjectForm editEventObjectForm = new EditEventObjectForm();
            if (editEventObjectForm.ShowDialog()==DialogResult.OK)
            {
                eventObjects = editEventObjectForm.EventObjects;       
            }
        }

        private void btnSaveBiom_Click(object sender, EventArgs e)
        {
            
        }
    }
}
