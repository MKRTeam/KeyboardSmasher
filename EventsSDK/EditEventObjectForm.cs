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
        EventObject eventObject;
        public EventObject GetEventObject()
        {
            return eventObject;
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if(listBoxEvents.SelectedItem!=null)
            listBoxEvents.Items.Remove(listBoxEvents.SelectedItem);
        }

        public void SetEventObject(EventObject selectedItem)
        {
            eventObject = selectedItem;
            textBoxObjectName.Text = eventObject.Name;
            textBoxObjectDescription.Text = eventObject.Description;
            listBoxEvents.Items.AddRange(eventObject.Events);
        }

        private void btnSaveObject_Click(object sender, EventArgs e)
        {
            Event[] events = new Event[listBoxEvents.Items.Count];
            for (int i = 0; i < listBoxEvents.Items.Count; i++)
                events[i] = (Event)listBoxEvents.Items[i];
            eventObject = new EventObject(textBoxObjectName.Text, textBoxObjectDescription.Text, events);

            DialogResult = DialogResult.OK;
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            Event _event = null;
            EditEventForm editEventForm = new EditEventForm();
            if (editEventForm.ShowDialog() == DialogResult.OK)
            {
                _event = editEventForm.GetEvent();
                listBoxEvents.Items.Add(_event);
            }
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem == null) return;
            Event _event = null;
            EditEventForm editEventForm = new EditEventForm();

            if (listBoxEvents.SelectedItem != null)
                editEventForm.SetEvent((Event)listBoxEvents.SelectedItem);

            if (editEventForm.ShowDialog() == DialogResult.OK)
            {
                _event = editEventForm.GetEvent();
                listBoxEvents.Items[listBoxEvents.SelectedIndex] = _event;
            }
        }
    }
}
