using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher.Gameplay.GUI
{
   
    

    public partial class EventControl : UserControl
    {
        string name_image;
        string[] action;
        string textScene;

        private int Result
        {
            get { return Result; }
            set
            {
                Result = value;
                OnControlResultChanged(value);
            }
        }

        public delegate void EventControlResultProc(int result);
        event EventControlResultProc OnControlResultChanged;
        

        public EventControl(string name_image,string[] actions,string textScene, EventControlResultProc result_handler)
        {
            InitializeComponent();
            rTBTextActionScene.Text = textScene;
            pictureBoxScene.Image = new System.Drawing.Bitmap(name_image);
            tLPActionButton.RowCount = action.Length;
            OnControlResultChanged += result_handler;
            for (int i = 0; i < action.Length; i++)
            {
                Button button = new Button();
                button.Dock = DockStyle.Fill;
                button.Text = actions[i];
                button.Tag = i;
                button.Click += OnClickButton_Action;
                tLPActionButton.SetRow(button, i);
            }
        }
        void OnClickButton_Action(object sender, EventArgs e)
        {
            Result = (int)((Button)sender).Tag;
        }
        
    }
}
