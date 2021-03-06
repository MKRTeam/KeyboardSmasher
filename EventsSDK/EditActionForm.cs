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
using Gameplay.ExerciseMachine;
namespace EventsSDK
{
    public partial class EditActionForm : Form
    {
        public EditActionForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(ExerciseType));
        }
        EventAction eventAction = null;
        public EventAction GetAction()
        {
            return eventAction;
        }

        public void SetAction(EventAction selectedItem)
        {
            textBox1.Text = selectedItem.Description;
            comboBox1.SelectedIndex = (int)selectedItem.ExerciseCode;
        }

        private void btnSaveAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (eventAction == null)
                {
                    eventAction = new EventAction(textBox1.Text, (ExerciseType)comboBox1.SelectedIndex);
                }
                else
                {
                    eventAction.Description = textBox1.Text;
                    eventAction.ExerciseCode = (ExerciseType)comboBox1.SelectedIndex;
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
