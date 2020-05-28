using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher.GUI.Controls
{
    public enum InfoControlResult
    {
        NO_RESULT,
        BACK
    }
    public partial class InfoControl : UserControl
    {
        InfoControlResult result = InfoControlResult.NO_RESULT;
        public delegate void InfoControlResultProc(InfoControlResult new_result);
        event InfoControlResultProc OnControlResultChanged;
        public UserControl LastControl { get; set; }
        private const string ABOUT_PROGRAMM = @"{\rtf1\ansi Программа \i KeySmasher  \i0 предназначена в качестве тренажера для обучения слепой печати в игровой форме. \line \line" +
                                                @"\b Язык \b0 \line" +
                                                @" В данной версии имеется поддержка лишь русского языка \line \line" +
                                                @"\b Тренажеры \b0 \line" +
                                                @"В игре имеется 3 типа тренажеров, которые зависят от выбранного варианта действия пользователем. После прохождения тренажера вы сможете посмотреть статистику выполнения. \line \line" +
                                                @"\b Уровни \b0 \line" +
                                                @"Имеется система сложности (4 уровня). При увеличении уровня расширяется набор используемых символов. Так на первом уровне используются сиволы «фывапролджэ», на 2-м - «йцукенгшщзхъ», на 3-м - «ячсмитьбю», на 4-м - «.,-!;()?:.» \line"+
                                                @"}";

        public InfoControl(InfoControlResultProc result_handler)
        {
            InitializeComponent();
            InitTree();
            rtbInfo.RightMargin = rtbInfo.Size.Width - 10;
            rtbInfo.SelectionIndent = 10;
            rtbInfo.ReadOnly = true;
            rtbInfo.BackColor = Color.White;
            rtbInfo.Rtf = ABOUT_PROGRAMM;
            OnControlResultChanged += result_handler;
            LastControl = null;
        }


        private void InitTree()
        {
            tvInfo.Nodes.Add("О программе");
            tvInfo.Nodes.Add("Рекомендации по обучению");
            tvInfo.Nodes.Add("Авторы");
        }

        private void TvInfo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (tvInfo.SelectedNode.Index)
            {
                case 0: rtbInfo.Rtf = ABOUT_PROGRAMM; break;
                case 1: rtbInfo.Text = ""; break;
                case 2: rtbInfo.Text = ""; break;
                case 3: rtbInfo.Text = ""; break;
            }
        }

        private InfoControlResult Result
        {
            get { return result; }
            set
            {
                result = value;
                if (OnControlResultChanged != null)
                    OnControlResultChanged(result);
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Result = InfoControlResult.BACK;
        }
    }
}
