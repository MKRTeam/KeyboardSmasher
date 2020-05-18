using KeyboardSmasher.ExerciseMachine.GUI;
using KeyboardSmasher.Gameplay.GUI;
using KeyboardSmasher.GUI.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher.GUI
{
    public partial class MainForm : Form
    {
        MainMenu main_menu;
        PauseMenu pause_menu;
        SymbolStreamControl symbol_stream_control;
        EventControl event_control;
        SettingsControl setting_control;
        Control currentVisibleControl = null;

        public MainForm()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            #region main_menu
            main_menu = new MainMenu(OnMainMenuResultChanged);
            main_menu.Visible = false;
            main_menu.Dock = DockStyle.Fill;
            this.Controls.Add(main_menu);
            #endregion
            #region setting_control
            setting_control = new SettingsControl(OnSettingsConrolResultChanged);
            setting_control.Visible = false;
            setting_control.Dock = DockStyle.Fill;
            this.Controls.Add(setting_control);
            #endregion
            #region pause_menu
            pause_menu = new PauseMenu();
            pause_menu.Visible = false;
            pause_menu.Dock = DockStyle.Fill;
            this.Controls.Add(pause_menu);
            #endregion
            #region symbol_stream_comtrol
            symbol_stream_control = new SymbolStreamControl();
            symbol_stream_control.Visible = false;
            symbol_stream_control.Dock = DockStyle.Fill;
            this.Controls.Add(symbol_stream_control);
            #endregion
            #region event_control
            event_control = new EventControl();
            event_control.Visible = false;
            event_control.Dock = DockStyle.Fill;
            this.Controls.Add(event_control);
            #endregion
        }

        private void showControl(Control control)
        {
            if (currentVisibleControl != null)
                currentVisibleControl.Visible = false;
            if (control != null)
                control.Visible = true;
            else throw new Exception("Визуализируемый контрол был null");
            currentVisibleControl = control;
        }

        public void showMainMenu()
        {
            showControl(main_menu);
        }

        private void OnMainMenuResultChanged(MainMenuResult new_result)
        {
            switch(new_result)
            {
                case MainMenuResult.START_GAME: { MessageBox.Show("Игра начинается"); } break;
                case MainMenuResult.OPEN_SETTINGS: {
                        setting_control.LastControl = main_menu;
                        showControl(setting_control);
                    }break;
                case MainMenuResult.EXIT: this.Close(); break;
                default: { } break;
            }
        }

        private void OnSettingsConrolResultChanged(SettingsControlResult new_result)
        {
            switch(new_result)
            {
                case SettingsControlResult.BACK: {
                        showControl(setting_control.LastControl); 
                    } break;
                default: { } break;
            }
        }
    }
}
