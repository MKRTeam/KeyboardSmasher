using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gameplay;
using System.IO;

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
            if (listboxBioms.SelectedItem == null) return;
            EditBiomForm editBiomForm = new EditBiomForm();
            if(listboxBioms.SelectedItem!=null)
            editBiomForm.SetBiom((Biom)listboxBioms.SelectedItem);
            if (editBiomForm.ShowDialog() == DialogResult.OK)
            {
                Biom biom = editBiomForm.GetBiom();
                listboxBioms.Items[listboxBioms.SelectedIndex] = biom;
            }
        }

        private void btnDeleteBiom_Click(object sender, EventArgs e)
        {
            if (listboxBioms.SelectedItem != null)
            {
                listboxBioms.Items.Remove(listboxBioms.SelectedItem);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Biom[] bioms = new Biom[listboxBioms.Items.Count];
            for (int i = 0; i < bioms.Length; i++)
                bioms[i] = (Biom)listboxBioms.Items[i];
            string json = JsonConvert.SerializeObject(bioms, Formatting.Indented);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("../Gamedata.json");
            streamWriter.Write(json);
            streamWriter.Close();
            MessageBox.Show("Сохранение завершенно");
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText("../Gamedata.json");
            Biom[] bioms = JsonConvert.DeserializeObject<Biom[]>(json);
            listboxBioms.Items.AddRange(bioms);
        }
    }
}
