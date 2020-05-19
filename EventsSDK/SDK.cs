using Gameplay;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EventsSDK
{
    public partial class SDK : Form
    {
        string gamedata_path;
        Biom currentBiom;
        EventObject currentObject;
        List<Biom> bioms;

        public SDK()
        { 
            InitializeComponent();
        }

        private void buttonAddBiom_Click(object sender, EventArgs e)
        {
            string biom_name = textBoxNameBiom.Text.Trim();
            string biom_description = textBoxDescriptionBiom.Text.Trim();  
        }

        private void buttonDeleteBiom_Click(object sender, EventArgs e)
        {
            bioms.Remove(currentBiom);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Biom[]));
            using (Stream reader = new FileStream(gamedata_path, FileMode.Create))
            {
                serializer.Serialize(reader, bioms.ToArray());
            }
        }
    }
}
