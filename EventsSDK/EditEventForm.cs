﻿using System;
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
            textBoxImage.Text = selectedItem.FileNameImage;
            textBoxMusic.Text = selectedItem.FileNameMusic;
        }

        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            try { 
                EventAction[] eventActions = new EventAction[listBoxActions.Items.Count];
                for (int i = 0; i < listBoxActions.Items.Count; i++)
                    eventActions[i] = (EventAction)listBoxActions.Items[i];

                @event = new Event(textBoxEventDescription.Text, eventActions);
                @event.FileNameImage = textBoxImage.Text;
                @event.FileNameMusic = textBoxImage.Text;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            editActionForm.SetAction((EventAction)listBoxActions.SelectedItem);
            if (editActionForm.ShowDialog() == DialogResult.OK)
            {
                listBoxActions.Items.Remove(listBoxActions.SelectedItem);
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
