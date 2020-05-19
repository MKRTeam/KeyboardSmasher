using System;
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
        string name_image;
        string[] action;
        string textScene;

        private EventControlResult Result
        {
            get { return Result; }
            set
            {
                Result = value;
                OnControlResultChanged(value);
            }
        }
        public delegate void EventControlResultProc(EventControlResult result);
        event EventControlResultProc OnControlResultChanged;

        public EventControl(string image_path, 
                            string[] actions, 
                            string textScene, 
                            EventControlResultProc result_handler)
        {
            InitializeComponent();
            rTBTextActionScene.Text = textScene;
            pictureBoxScene.Image = new System.Drawing.Bitmap(image_path);
            tLPActionButton.RowCount = action.Length;
            OnControlResultChanged += result_handler;
            for (int i = 0; i < action.Length; i++)
            {
                Button button = new Button();
                button.Dock = DockStyle.Fill;
                button.Text = actions[i];
                button.Tag = i;//в тег заносим порядковый номер варианта действия
                button.Click += OnClickButton_Action;
                tLPActionButton.SetRow(button, i);
            }
        }
        void OnClickButton_Action(object sender, EventArgs e)
        {
            Result = EventControlResult.ACTION0 + (int)((Button)sender).Tag;
        }

        private void EventControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Result = EventControlResult.EXIT_TO_PAUSE_MENU;
            if (e.KeyCode == Keys.Enter)
                Result = EventControlResult.SKIP_EVENT;
        }
    }
}
