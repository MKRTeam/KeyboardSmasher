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
    public enum MainMenuResult
    {
        NO_RESULT,
        START_GAME,
        OPEN_SETTINGS,
        EXIT
    }

    public partial class MainMenu : UserControl
    {
        MainMenuResult result = MainMenuResult.NO_RESULT;
        public delegate void MainMenuResultProc(MainMenuResult new_result);
        event MainMenuResultProc OnControlResultChanged;

        public MainMenu(MainMenuResultProc result_handler)
        {
            InitializeComponent();
            OnControlResultChanged += result_handler;
        }

        private MainMenuResult Result
        {
            get{ return result; }
            set { result = value;
                OnControlResultChanged(value);
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Result = MainMenuResult.START_GAME;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Result = MainMenuResult.OPEN_SETTINGS;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Result = MainMenuResult.EXIT;
        }
    }
}
