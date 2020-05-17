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
        SettingControl setting_control;
        Control currentVisibleControl = null;

        public MainForm()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            //main_menu
            main_menu = new MainMenu(this);
            main_menu.Visible = false;
            main_menu.Dock = DockStyle.Fill;
            this.Controls.Add(main_menu);
            //settingControl
            setting_control = new SettingControl(this);
            setting_control.Visible = false;
            setting_control.Dock = DockStyle.Fill;
            this.Controls.Add(setting_control);
            //pause_menu
            pause_menu = new PauseMenu();
            pause_menu.Visible = false;
            pause_menu.Dock = DockStyle.Fill;
            this.Controls.Add(pause_menu);
            //symbol_stream_comtrol
            symbol_stream_control = new SymbolStreamControl();
            symbol_stream_control.Visible = false;
            symbol_stream_control.Dock = DockStyle.Fill;
            this.Controls.Add(symbol_stream_control);
            //event_control
            event_control = new EventControl();
            event_control.Visible = false;
            event_control.Dock = DockStyle.Fill;
            this.Controls.Add(event_control);
        }

        private void showControl(Control control)
        {
            if (currentVisibleControl != null)
                currentVisibleControl.Visible = false;
            control.Visible = true;
            currentVisibleControl = control;
        }

        public void showMainMenu()
        {
            showControl(main_menu);
        }

        public void showSettingsMenu()
        {
            showControl(setting_control);
        }

        public void showPauseMenu()
        {
            showControl(pause_menu);
        }

        public void showEventControl(string event_text)
        {
            showControl(event_control);
            //здесь настройка контрола
        }

        public void showSymbolStreamControl()
        {
            showControl(symbol_stream_control);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
