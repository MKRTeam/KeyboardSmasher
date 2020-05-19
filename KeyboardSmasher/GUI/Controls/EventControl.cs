﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher.GUI.Controls
{  
    public enum EventControlResult
    {
        EXIT_TO_PAUSE_MENU,
        SKIP_EVENT,
        ACTION0,
        ACTION1,
        ACTION2,
        ACTION3,
        ACTION4
    }

    public partial class EventControl : UserControl
    {
        string image_path;
        string[] actions;
        string textScene;

        private EventControlResult Result
        {
            get { return result; }
            set
            {
                result = value;
                OnControlResultChanged(value);
            }
        }

        EventControlResult result;
        public delegate void EventControlResultProc(EventControlResult new_result);
        event EventControlResultProc OnControlResultChanged;

        public EventControl(string image_path, 
                            string[] actions, 
                            string textScene, 
                            EventControlResultProc result_handler)
        {
            InitializeComponent();
            this.actions = actions;
            this.textScene = textScene;
            this.image_path = image_path;
            rTBTextActionScene.Text = textScene;
            //pictureBoxScene.Image = new System.Drawing.Bitmap(image_path);
            tLPActionButton.RowCount = actions.Length;
            OnControlResultChanged += result_handler;
            for (int i = 0; i < actions.Length; i++)
            {
                Button button = new Button();
                button.Dock = DockStyle.Fill;
                button.Text = actions[i];
                button.Tag = i;//в тег заносим порядковый номер варианта действия
                button.Click += OnClickButton_Action;
                tLPActionButton.Controls.Add(button, 0, i);
                //ПОПРАВИТЬ СТИЛЬ ОТОБРАЖЕНИЯ КНОПОК
                tLPActionButton.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            }
            tLPActionButton.Refresh();
        }
        void OnClickButton_Action(object sender, EventArgs e)
        {
            Result = EventControlResult.ACTION0 + (int)((Button)sender).Tag;
        }

        public void EventControl_KeyDown(object sender, KeyEventArgs e)
        {
            //не работает событие. Событие не вызывается при нажатии кнопки ПОЧЕМУ?
            if (e.KeyCode == Keys.Escape)
                Result = EventControlResult.EXIT_TO_PAUSE_MENU;
            if (e.KeyCode == Keys.Enter)
                Result = EventControlResult.SKIP_EVENT;
        }

        public void EventControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("нажалось");
        }
    }
}
