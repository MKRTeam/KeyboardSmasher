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
        InfoControl info_control;
        SettingsControl setting_control;
        //видимый контрол
        UserControl currentVisibleControl = null;
        EventControl currentEventControl = null;
        Event currentEvent = null;
        SymbolStreamControl currentSymbolStreamControl = null;

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
            main_menu.Location = new Point(Size.Width / 2 - main_menu.Size.Width / 2,
                                            Size.Height / 2 - main_menu.Size.Height / 2);
            this.Controls.Add(main_menu);
            #endregion
            #region setting_control
            setting_control = new SettingsControl(OnSettingsConrolResultChanged);
            setting_control.Visible = false;
            //setting_control.Dock = DockStyle.Fill;
            setting_control.Location = new Point(Size.Width / 2 - setting_control.Size.Width / 2,
                                            Size.Height / 2 - setting_control.Size.Height / 2);
            this.Controls.Add(setting_control);
            #endregion
            #region info_control
            info_control = new InfoControl(OnInfoControlResultChanged);
            info_control.Visible = false;
            //info_control.Dock = DockStyle.Fill;
            info_control.Location = new Point(Size.Width / 2 - info_control.Size.Width / 2,
                                            Size.Height / 2 - info_control.Size.Height / 2);
            this.Controls.Add(info_control);
            #endregion
            #region pause_menu
            pause_menu = new PauseMenu(OnPauseMenuResultChanged);
            pause_menu.Visible = false;
            //pause_menu.Dock = DockStyle.Fill;
            pause_menu.Location = new Point(Size.Width / 2 - pause_menu.Size.Width / 2,
                                            Size.Height / 2 - pause_menu.Size.Height / 2);
            this.Controls.Add(pause_menu);
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
            currentVisibleControl.Focus();
            //currentVisibleControl.Dock = DockStyle.Top;
            //currentVisibleControl.Anchor = AnchorStyles.
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
            currentEventControl = new EventControl(currentEvent.FileNameImage, currentEvent.getActions(), currentEvent.Description, OnEventControlResultChanged);
            currentEventControl.Dock = DockStyle.Fill;
            this.Controls.Add(currentEventControl);
            showControl(currentEventControl);
            
        }

        private void showSymbolStreamControl()
        {
            if (currentSymbolStreamControl != null)
            {
                this.Controls.Remove(currentSymbolStreamControl);
                currentSymbolStreamControl.Dispose();
            }
            currentSymbolStreamControl = new SymbolStreamControl(lang, difficulty, OnSymbolStreamControlChanged);
            this.Controls.Add(currentSymbolStreamControl);
            currentSymbolStreamControl.Dock = DockStyle.Fill;
            showControl(currentSymbolStreamControl);
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
                case MainMenuResult.INFO:
                    {
                        info_control.LastControl = main_menu;
                        showControl(info_control);
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
        private void OnInfoControlResultChanged(InfoControlResult new_result)
        {
            switch (new_result)
            {
                case InfoControlResult.BACK:
                    {
                        showControl(info_control.LastControl);
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
                case PauseMenuResult.INFO:
                    {
                        info_control.LastControl = pause_menu;
                        showControl(info_control);
                    }break;
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
                        if (type == ExerciseType.SYMBOL_STREAM)
                            difficulty = Difficulty.EASY;
                        else if (type == ExerciseType.WORDS_ON_REACTION)
                            difficulty = Difficulty.NORMAL;
                        else if (type == ExerciseType.MISTAKE_COUNT)
                            difficulty = Difficulty.HARD;
                        //создаем соответствующий тренажер
                        showSymbolStreamControl();
                    }
                    break;

            }
        }

        private void OnSymbolStreamControlChanged(SymbolStreamControlResult new_result)
        {
            switch(new_result)
            {
                case SymbolStreamControlResult.EXIT:
                    {
                        showNewEventControl();
                    } break;
                case SymbolStreamControlResult.PAUSE:
                    {
                        currentSymbolStreamControl.Pause();
                    } break;
                case SymbolStreamControlResult.RESUME:
                    {
                        currentSymbolStreamControl.Resume();
                    } break;
                default: { } break;
            }

        }

        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            currentVisibleControl.Control_KeyDown(sender, e);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            currentVisibleControl.Control_KeyPress(sender, e);
        }
    }
}
