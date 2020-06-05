using System;
using System.Drawing;
using System.Windows.Forms;
using Gameplay;
using Gameplay.ExerciseMachine;

namespace KeyboardSmasher.ExerciseMachine.GUI
{
    // exercise results
    public enum WordsOnReactionControlResult {
        NO_RESULT,
        PAUSE,
        RESUME,
        EXIT
    }
    public partial class WordsOnReactionControl : UserControl {
        public delegate void WordsOnReactionControlResultProc(WordsOnReactionControlResult result);
        event WordsOnReactionControlResultProc OnControlResultChanged;
        private WordsOnReactionControlResult result;

        private WordsOnReactionControlResult Result {
            get { return result; }
            set {
                result = value;
                OnControlResultChanged(result);
            }
        }

        /// <summary>
        /// Exercise control modes
        /// </summary>
        private enum ControlMode {
            ControlStarted,
            TypingStarted,
            TypingStoped,
            TypingFinished
        }
        private ControlMode currentControlMode { get; set; }
        private WordsOnReaction wordsOnReaction;
        private WordsOnReactionStatistic statistic;
        private Language m_lang;
        private static string[] welcome_text = {"Напечатайте "+
          "как можно быстрее в нижнем поле текст, который появится здесь! " +
          "Нажмите СТАРТ чтобы начать",
          "Type the appearing here text in the bottom text box, do it " +
          "as fast as you can. Press START to begin"
          };
        private int seconds;

        public WordsOnReactionControl(Language lang, Difficulty difficulty, WordsOnReactionControlResultProc handler) {
            InitializeComponent();
            m_lang = lang;
            tB_Reading.Text = welcome_text[(int)lang];

            tB_Reading.BackColor = Color.FromArgb(198, 178, 153);
            buttonStartEnd.FlatAppearance.BorderColor = Color.FromArgb(198, 178, 153);
            buttonStartEnd.ForeColor = Color.FromArgb(153, 134, 117);
            buttonStartEnd.BackColor = Color.WhiteSmoke;
            labelResults.BackColor = Color.FromArgb(153, 134, 117);
            labelResults.Visible = false;
            labelTimer.BackColor = Color.FromArgb(198, 178, 153);
            labelTimer.ForeColor = Color.FromArgb(153, 134, 117);

            currentControlMode = ControlMode.ControlStarted;
            statistic = new WordsOnReactionStatistic();
            wordsOnReaction = new WordsOnReaction(lang, difficulty);
            seconds = Convert.ToInt32(wordsOnReaction.Time.TotalSeconds);
            timerForExercise.Interval = Convert.ToInt32(wordsOnReaction.Time.TotalMilliseconds);
            labelTimer.Text = seconds.ToString();
            OnControlResultChanged += handler;
        }
        private void buttonStartEnd_MouseLeave(object sender, EventArgs e) {
            buttonStartEnd.FlatAppearance.BorderColor = Color.FromArgb(198, 178, 153);
            buttonStartEnd.BackColor = Color.WhiteSmoke;
        }

        private void buttonStartEnd_MouseMove(object sender, MouseEventArgs e) {
            buttonStartEnd.FlatAppearance.BorderColor = Color.FromArgb(153, 134, 117);
            buttonStartEnd.BackColor = Color.White;
        }
        private void buttonStartEnd_Click(object sender, EventArgs e)
        {
            if (currentControlMode == ControlMode.ControlStarted) {
                currentControlMode = ControlMode.TypingStarted;
                Result = WordsOnReactionControlResult.NO_RESULT;
                
                writingMode(1);
                tB_Reading.Text = wordsOnReaction.Text;
                tB_writing.Text = "";
                labelResults.Text = "";
                buttonStartEnd.Enabled = false;
                buttonStartEnd.BackColor = Color.FromArgb(198, 178, 153);

                // no need in mouse events anymore
                buttonStartEnd.MouseMove -= buttonStartEnd_MouseMove;
                buttonStartEnd.MouseLeave -= buttonStartEnd_MouseLeave;
                
                timerForExercise.Start();
                timerToDisplay.Start();
            }
            else if (currentControlMode == ControlMode.TypingFinished) {
                Result = WordsOnReactionControlResult.EXIT;
            }
        }

        private void writingMode (int mode)
        {
            if (mode == 0) {
                tB_writing.ReadOnly = true;
                tB_writing.Enabled = false;
            }
            else {
                tB_writing.ReadOnly = false;
                tB_writing.Enabled = true;
            }
        }

        private void WordsOnReactionControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (currentControlMode == ControlMode.TypingFinished && e.KeyCode == Keys.Enter)
                Result = WordsOnReactionControlResult.EXIT;
        }

        private void timerToDisplay_Tick(object sender, EventArgs e)
        {
            seconds--;
            labelTimer.Text = seconds.ToString();
        }

        private void timerForExercise_Tick(object sender, EventArgs e)
        {
            timerForExercise.Stop();
            timerToDisplay.Stop();
            labelTimer.Text = "0";
            currentControlMode = ControlMode.TypingFinished;
            writingMode(0);

            string text_to_show = m_lang == Language.RUSSIAN ? "Время вышло!" : "Time is up!";
            MessageBox.Show(text_to_show);
            
            buttonStartEnd.Enabled = true;
            buttonStartEnd.Text = m_lang == Language.RUSSIAN ? "ДАЛЬШЕ" : "MOVE ON";
            buttonStartEnd.BackColor = Color.WhiteSmoke;
            buttonStartEnd.MouseMove += buttonStartEnd_MouseMove;
            buttonStartEnd.MouseLeave += buttonStartEnd_MouseLeave;

            int mistakes = WordsOnReaction.LDistance(tB_Reading.Text, tB_writing.Text);
            statistic.identity_percents = 100 - Convert.ToInt32(100.0 * mistakes / tB_Reading.Text.Length);

            labelResults.Text = m_lang == Language.RUSSIAN ? "Ваш текст на " + statistic.identity_percents +
                "% совпадает с оригиналом. Нажмите ENTER или кнопку чтобы двигаться дальше" :
                "Your text is " + statistic.identity_percents + "% like the original one. Press ENTER or " +
                "the button to move on.";
            labelResults.Visible = true;
        }
    }
}
