using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher.GUI
{
    public partial class MainMenu : UserControl
    {
        MainForm parentForm;
        public MainMenu(MainForm parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentForm.showSettingsMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
