using Gameplay;
using Gameplay.ExerciseMachine;
using KeyboardSmasher.ExerciseMachine.GUI;
using KeyboardSmasher.GUI.Controls;
using KeyboardSmasher.GUI.ExerciseMachine;
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
        //контролы, которые всегда хранятся в памяти
        Controls.MainMenu main_menu;
        PauseMenu pause_menu;
        SettingsControl setting_control;
        //видимый контрол
        UserControl currentVisibleControl = null;
        EventControl currentEventControl = null;
        Event currentEvent = null;

        //игровые данные
        Difficulty difficulty;
        Language lang;
        Dictionary<Language, string> localization_paths;
        Localization.Localization localization = null;
        Biom[] bioms;
        Biom current_biom = null;

        public MainForm(Dictionary<Language,string> localization_paths, Biom[] bioms)
        {
            InitializeComponent();
            InitControls();
            this.bioms = bioms;
            current_biom = this.bioms[0];
        }

        private void InitControls()
        {
            #region main_menu
            main_menu = new Controls.MainMenu(OnMainMenuResultChanged);
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
            pause_menu = new PauseMenu(OnPauseMenuResultChanged);
            pause_menu.Visible = false;
            pause_menu.Dock = DockStyle.Fill;
            this.Controls.Add(pause_menu);
            #endregion
            #region event_control
            //event_control = new EventControl();
            //event_control.Visible = false;
            //event_control.Dock = DockStyle.Fill;
            //this.Controls.Add(event_control);
            #endregion
        }

        private void SetLanguage(Language language)
        {
            this.lang = language;
            localization = Localization.Localization.Deserialize(localization_paths[language]);
            if (currentVisibleControl != null)
                translateControl(currentVisibleControl, localization);
        }

        private void showControl(UserControl control)
        {
            if (currentVisibleControl != null)
                currentVisibleControl.Visible = false;
            if (control != null)
                control.Visible = true;
            else throw new Exception("Визуализируемый контрол был null");
            currentVisibleControl = control;
            currentVisibleControl.Dock = DockStyle.Fill;
            translateControl(control, localization);
        }

        private void translateControl(UserControl control, Localization.Localization localization)
        {
            
        }

        private void showNewEventControl()
        {
            if (currentEventControl != null)
            {
                this.Controls.Remove(currentEventControl);
                currentEventControl.Dispose();
            }
            currentEvent = current_biom.getRandomEventObject().getRandomEvent();
            currentEventControl = new EventControl("", currentEvent.getActions(), currentEvent.Description, OnEventControlResultChanged);
            currentEventControl.Dock = DockStyle.Fill;
            this.Controls.Add(currentEventControl);
            showControl(currentEventControl);
            
        }

        public void showMainMenu()
        {
            showControl(main_menu);
        }

        #region result_handlers
        private void OnMainMenuResultChanged(MainMenuResult new_result)
        {
            switch(new_result)
            {
                case MainMenuResult.START_GAME:
                    {
                        showNewEventControl();
                    }
                    break;
                case MainMenuResult.OPEN_SETTINGS:
                    {
                        setting_control.LastControl = main_menu;
                        showControl(setting_control);
                    }
                    break;
                case MainMenuResult.EXIT: this.Close(); break;
                default: { } break;
            }
        }

        private void OnSettingsConrolResultChanged(SettingsControlResult new_result)
        {
            switch(new_result)
            {
                case SettingsControlResult.BACK:
                    {
                        showControl(setting_control.LastControl);
                    } break;
                case SettingsControlResult.CHANGE_DIFFICULTY:
                    {
                        difficulty = setting_control.Difficulty;
                    }
                    break;
                case SettingsControlResult.CHANGE_LANGUAGE:
                    {
                        SetLanguage(setting_control.Language);
                    }
                    break;
                default: { } break;
            }
        }

        private void OnPauseMenuResultChanged(PauseMenuResult new_result)
        {
            switch(new_result)
            {
                case PauseMenuResult.CONTINUE_GAME: { showControl(pause_menu.LastControl); } break;
                case PauseMenuResult.EXIT: { Close(); } break;
                case PauseMenuResult.EXIT_TO_MENU: { showMainMenu(); } break;
                case PauseMenuResult.SETTINGS:
                    {
                        setting_control.LastControl = pause_menu;
                        showControl(setting_control);
                    } break;
                case PauseMenuResult.NO_RESULT: { } break;
            }
        }

        private void OnEventControlResultChanged(EventControlResult new_result)
        {
            switch(new_result)
            {
                case EventControlResult.EXIT_TO_PAUSE_MENU:
                    {
                        pause_menu.LastControl = currentVisibleControl;
                        showControl(pause_menu);
                    }
                    break;
                case EventControlResult.SKIP_EVENT:
                    {
                        showNewEventControl();
                    }
                    break;
                default:
                    {
                        ExerciseType type = currentEvent.getActionResult((uint)(new_result - EventControlResult.ACTION0));
                        //создаем соответствующий тренажер
                        SymbolStreamControl symbolStreamControl = new SymbolStreamControl(lang, difficulty);
                        showControl(symbolStreamControl);   
                    }
                    break;

            }
        }

        //private void OnSymbolStreamControlChanged();

        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //КОСТЫЛЬНО!!! Но по другому только переделывать класс UserControl
            currentVisibleControl.Control_KeyDown(sender, e);
            //if (currentVisibleControl.GetType().Name == "EventControl")
            //    ((EventControl)currentVisibleControl).EventControl_KeyDown(sender, e);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            currentVisibleControl.Control_KeyPress(sender, e);
            //if (currentVisibleControl.GetType().Name == "EventControl")
            //    ((EventControl)currentVisibleControl).EventControl_KeyPress(sender, e);
        }
    }
}
