using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gameplay;

namespace KeyboardSmasher.GUI.Controls
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
        public UserControl LastControl { get; set; }

        public SettingsControl(SettingsControlResultProc result_handler)
        {
            InitializeComponent();
            comboBoxDifficulty.SelectedIndex = 0;
            comboBoxLanguage.SelectedIndex = 0;
            OnControlResultChanged += result_handler;
            LastControl = null;
            errorProvider.Clear();
        }

        private SettingsControlResult Result
        {
            get { return result; }
            set { result = value;
                if (OnControlResultChanged != null)
                OnControlResultChanged(result);
            }
        }

        // метод на время отсутсвия английского языка
        public void SetInitialLanguage()
        {
            if (comboBoxLanguage.SelectedIndex != 0)
            {
                comboBoxLanguage.SelectedIndex = 0; 
                errorProvider.SetError(comboBoxLanguage, "Данная функция находится в разработке");
            }
        }

        public Difficulty Difficulty
        {
            get
            {
                return Difficulty.EASY + comboBoxDifficulty.SelectedIndex;
            }
        }

        public Language Language
        {
            get
            {
                return Language.RUSSIAN + comboBoxLanguage.SelectedIndex;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Result = SettingsControlResult.BACK;
            errorProvider.Clear();
        }

        private void comboBoxDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Result = SettingsControlResult.CHANGE_DIFFICULTY;
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Result = SettingsControlResult.CHANGE_LANGUAGE;
        }
    }
}
