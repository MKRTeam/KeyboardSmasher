using KeyboardSmasher.ExerciseMachine.GUI;
using KeyboardSmasher.Gameplay.GUI;
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
        Control currentVisibleControl = null;

        public MainForm()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            main_menu = new MainMenu();
            main_menu.Visible = false;
            this.Controls.Add(main_menu);
            pause_menu = new PauseMenu();
            pause_menu.Visible = false;
            this.Controls.Add(pause_menu);
            symbol_stream_control = new SymbolStreamControl();
            symbol_stream_control.Visible = false;
            this.Controls.Add(symbol_stream_control);
            event_control = new EventControl();
            event_control.Visible = false;
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
    }
}
