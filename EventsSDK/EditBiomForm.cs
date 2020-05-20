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
        Biom biom;
        internal Biom GetBiom()
        {
            return biom;
        }
        internal void SetBiom(Biom selectedItem)
        {
            biom = selectedItem;
            textBoxBiomName.Text = biom.Name;
            textBoxBiomDescription.Text = biom.Description;
            listBoxObjects.Items.AddRange(biom.Objects);
        }
        private void btnSaveBiom_Click(object sender, EventArgs e)
        {
            EventObject[] eventObjects = new EventObject[listBoxObjects.Items.Count];
            for (int i = 0; i < listBoxObjects.Items.Count; i++)
                eventObjects[i] = (EventObject)listBoxObjects.Items[i];
            biom = new Biom(textBoxBiomName.Text, textBoxBiomDescription.Text, eventObjects);
            DialogResult = DialogResult.OK;
        }
        private void btnCreateObject_Click(object sender, EventArgs e)
        {
            EventObject eventObject;
            EditEventObjectForm editEventObject = new EditEventObjectForm();
            if (editEventObject.ShowDialog() == DialogResult.OK)
            {
                eventObject = editEventObject.GetEventObject();
                listBoxObjects.Items.Add(eventObject);
            }
        }
        private void btnEditObject_Click(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedItem != null)
            {
                EditEventObjectForm editEventObject = new EditEventObjectForm();
                if(listBoxObjects.SelectedItem!=null)
                    editEventObject.SetEventObject((EventObject)listBoxObjects.SelectedItem);

                if (editEventObject.ShowDialog() == DialogResult.OK)
                {
                    EventObject eventObject = editEventObject.GetEventObject();
                    listBoxObjects.Items[listBoxObjects.SelectedIndex] = eventObject;
                }
            }
        }
    }
}
