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
    public partial class EditEventForm : Form
    {
        public EditEventForm()
        {
            InitializeComponent();
        }

        Event @event = null;

        public Event GetEvent()
        {
            return @event;
        }

        public void SetEvent(Event selectedItem)
        {
            textBoxEventDescription.Text = selectedItem.Description;
            listBoxActions.Items.AddRange(selectedItem.Actions);
        }

        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            EventAction[] eventActions = new EventAction[listBoxActions.Items.Count];
            for (int i = 0; i < listBoxActions.Items.Count; i++)
                eventActions[i] = (EventAction)listBoxActions.Items[i];

            @event = new Event(textBoxEventDescription.Text, eventActions);
            DialogResult = DialogResult.OK;
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            if(listBoxActions.SelectedItem!=null)
            listBoxActions.Items.Remove(listBoxActions.SelectedItem);
        }

        private void btnEditAction_Click(object sender, EventArgs e)
        {
            if (listBoxActions.SelectedItem == null) return;
            EditActionForm editActionForm = new EditActionForm();
            if(listBoxActions.SelectedItem!=null)
                editActionForm.SetAction((EventAction)listBoxActions.SelectedItem);
            if (editActionForm.ShowDialog() == DialogResult.OK)
            {
                EventAction eventAction = editActionForm.GetAction();
                listBoxActions.Items.Add(eventAction);
            }
        }

        private void btnCreateAction_Click(object sender, EventArgs e)
        {
            EditActionForm editActionForm = new EditActionForm();
            if (editActionForm.ShowDialog() == DialogResult.OK)
            {
                EventAction eventAction = editActionForm.GetAction();
                listBoxActions.Items.Add(eventAction);
            }
        }
    }
}
