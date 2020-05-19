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
    public partial class SDK : Form
    {
        Biom biom = null;
        public SDK()
        {
            
            InitializeComponent();
        }
<<<<<<< Updated upstream

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
=======
        
        private void btnCreateBiom_Click(object sender, EventArgs e)
        {
            EditBiomForm editBiomForm = new EditBiomForm();
            if (editBiomForm.ShowDialog() == DialogResult.OK)
            {
                
            }
>>>>>>> Stashed changes

        }
    }
}
