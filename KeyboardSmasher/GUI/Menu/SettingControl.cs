using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher.GUI.Menu
{
    public partial class SettingControl : UserControl
    {
        MainForm parentForm;
        public SettingControl(MainForm form)
        {
            
            InitializeComponent();
            parentForm = form;
            comboBoxDifficult.SelectedIndex = 0;
            comboBoxLanguage.SelectedIndex = 0;

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            parentForm.showMainMenu();

        }
    }
}
