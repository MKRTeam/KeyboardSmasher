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

        private static string[] welcome_text = {"Напечатайте"+
          "как можно быстрее в нижнем поле текст, который появится здесь!" +
          "Нажмите СТАРТ чтобы начать",
          "Type the appearing here text in the bottom text box, do it" +
          "as fast as you can. Press START to begin"
          };

        public WordsOnReactionControl(Language lang, Difficulty difficulty, WordsOnReactionControlResultProc handler) {
            InitializeComponent();
            m_lang = lang;
            tB_Reading.Text = welcome_text[(int)lang];

            tB_Reading.BackColor = Color.FromArgb(198, 178, 153);
            buttonStartPause.FlatAppearance.BorderColor = Color.FromArgb(198, 178, 153);
            buttonStartPause.ForeColor = Color.FromArgb(153, 134, 117);
            buttonStartPause.BackColor = Color.WhiteSmoke;
            labelResults.BackColor = Color.FromArgb(153, 134, 117);
            labelResults.Visible = false;

            currentControlMode = ControlMode.ControlStarted;
            statistic = new WordsOnReactionStatistic();
            wordsOnReaction = new WordsOnReaction(lang, difficulty);
            timer.Interval = Convert.ToInt32(wordsOnReaction.Time.TotalMilliseconds);
            OnControlResultChanged += handler;
        }

        private void buttonStartPause_MouseMove(object sender, MouseEventArgs e) {
            buttonStartPause.FlatAppearance.BorderColor = Color.FromArgb(153, 134, 117);
            buttonStartPause.BackColor = Color.White;
        }

        private void buttonStartPause_MouseLeave(object sender, EventArgs e) {
            buttonStartPause.FlatAppearance.BorderColor = Color.FromArgb(198, 178, 153);
            buttonStartPause.BackColor = Color.WhiteSmoke;
        }

        private void buttonStartPause_Click(object sender, EventArgs e)
        {
            if (currentControlMode == ControlMode.ControlStarted || 
                currentControlMode == ControlMode.TypingFinished) {
                
                currentControlMode = ControlMode.TypingStarted;
                Result = WordsOnReactionControlResult.NO_RESULT;
                writingMode(1);
                tB_Reading.Text = wordsOnReaction.Text;
                tB_writing.Text = "";
                labelResults.Text = "";
                buttonStartPause.Enabled = false;
                labelResults.Visible = false;
                timer.Start();
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
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            string text_to_show = m_lang == Language.RUSSIAN ? "Время вышло!" : "Time is up!";
            MessageBox.Show(text_to_show);
            writingMode(0);
            buttonStartPause.Enabled = true;
            currentControlMode = ControlMode.TypingFinished;
            buttonStartPause.Text = m_lang == Language.RUSSIAN ? "ЗАНОВО" : "TRY AGAIN";

            int mistakes = WordsOnReaction.LDistance(tB_Reading.Text, tB_writing.Text);
            statistic.identity_percents = 100 - Convert.ToInt32(100.0 * mistakes / tB_Reading.Text.Length);
            
            labelResults.Text = m_lang == Language.RUSSIAN ? "Вы допустили " + statistic.identity_percents + 
                "% ошибок. Нажмите ENTER чтобы двигаться дальше" :
                "You have made "+statistic.identity_percents+"% mistakes. Press ENTER to move on.";
            labelResults.Visible = true;
        }

        private void WordsOnReactionControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (currentControlMode == ControlMode.TypingFinished && e.KeyCode == Keys.Enter)
                Result = WordsOnReactionControlResult.EXIT;
        }
    }
}
