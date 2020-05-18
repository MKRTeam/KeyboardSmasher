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
        public string Result;
        public EventControl(string name_image,string[] actions,string textScene)
        {
            InitializeComponent();
            tableLayoutPanel1.RowCount = action.Length;
            for (int i = 0; i < action.Length; i++)
            {
                Button button = new Button();
                button.Dock = DockStyle.Fill;
                button.Text = actions[i];
                button.Click += OnClickButton_Action;
                tableLayoutPanel1.SetRow(button, i);
            }
        }
        void OnClickButton_Action(object sender, EventArgs e)
        {
             
        }
        
    }
}
