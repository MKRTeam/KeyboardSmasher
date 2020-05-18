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
    public enum PauseMenuResult
        {
            NO_RESULT,
            CONTINUE_GAME,
            SETTINGS,
            EXIT_TO_MENU,
            EXIT
        }

    public partial class PauseMenu : UserControl
    {
        PauseMenuResult result = PauseMenuResult.NO_RESULT;
        public delegate void PauseMenuResultProc(PauseMenuResult new_result);
        event PauseMenuResultProc OnControlResultChanged;
        public PauseMenu(PauseMenuResultProc result_handler)
        {
            InitializeComponent();
            OnControlResultChanged += result_handler;
        }
        private PauseMenuResult Result
        {
            get { return result; }
            set
            {
                result = value;
                OnControlResultChanged(value);
            }
        }

        private void btnContinueGame_Click(object sender, EventArgs e)
        {
            Result = PauseMenuResult.CONTINUE_GAME;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Result = PauseMenuResult.SETTINGS;
        }



        private void btnExitToMenu_Click(object sender, EventArgs e)
        {
            Result = PauseMenuResult.EXIT_TO_MENU;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Result = PauseMenuResult.EXIT;
        }
    }
}
