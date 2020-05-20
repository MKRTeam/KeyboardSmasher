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
        public SDK()
        {
            InitializeComponent();
        }

        private void btnCreateBiom_Click(object sender, EventArgs e)
        {
            Biom biom = null;
            EditBiomForm editBiomForm = new EditBiomForm();
            if (editBiomForm.ShowDialog() == DialogResult.OK)
            {
                biom = editBiomForm.GetBiom();
                listboxBioms.Items.Add(biom);
            }
        }

        private void btnEditBiom_Click(object sender, EventArgs e)
        {
            EditBiomForm editBiomForm = new EditBiomForm();
            editBiomForm.SetBiom((Biom)listboxBioms.SelectedItem);
            if (editBiomForm.ShowDialog() == DialogResult.OK)
            {
                // 
            }
        }

        private void btnDeleteBiom_Click(object sender, EventArgs e)
        {
            if (listboxBioms.SelectedItem != null)
            {
                listboxBioms.Items.Remove(listboxBioms.SelectedItem);
            }
        }
    }
}
