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
    public enum SettingsControlResult
    {
        NO_RESULT,
        BACK,
        CHANGE_DIFFICULTY,
        CHANGE_LANGUAGE
    }

    public partial class SettingsControl : UserControl
    {
        SettingsControlResult result = SettingsControlResult.NO_RESULT;
        public delegate void SettingsControlResultProc(SettingsControlResult new_result);
        event SettingsControlResultProc OnControlResultChanged;
        public Control LastControl { get; set; }

        public SettingsControl(SettingsControlResultProc result_handler)
        {
            InitializeComponent();
            comboBoxDifficulty.SelectedIndex = 0;
            comboBoxLanguage.SelectedIndex = 0;
            OnControlResultChanged += result_handler;
            LastControl = null;
        }

        private SettingsControlResult Result
        {
            get { return result; }
            set { result = value;
                OnControlResultChanged(result);
            }
        }

        public Difficulty Difficulty
        {
            get
            {
                switch (comboBoxDifficulty.SelectedIndex)
                {
                    case 0: return Difficulty.EASY;
                    case 1: return Difficulty.NORMAL;
                    case 2: return Difficulty.HARD;
                    default: return Difficulty.EASY;
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Result = SettingsControlResult.BACK;
        }
    }
}
