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
        private const string ABOUT_EDUCATION = @"{\rtf1\ansi Главная идея слепой печати в том, что за каждым пальцем закреплена своя зона клавиш. Это позволяет печатать не глядя на клавиатуру. Регулярно тренируйся и, благодаря мышечной памяти, все твои десять пальцев будут знать, куда нажать. \line \line" +
            @"\b Поза при печати текста \b0 \line" +
            @"  1) Сиди ровно и держи спину прямой. \line" +
            @"  2) Локти держи согнутыми под прямым углом. \line" +
            @"  3) Голова должна быть немного наклонена вперед. \line" +
            @"  4) Расстояние от глаз до экрана должно быть 45-70 см. \line" +
            @"  5) Расслабь мышцы плеч, рук и кистей. Кисти могут немного касаться стола в нижней части клавиатуры, но не переноси вес тела на руки, чтобы не перенапрягать кисти. \line \line" +
            @"\b Исходная позиция пальцев \b0 \line" +
            @"Немного согни пальцы и положи их на клавиши ФЫВА и ОЛДЖ, которые находятся в среднем ряду. Эта строка называется ОСНОВНОЙ СТРОКОЙ, потому что ты всегда будешь начинать с этих клавиш и возвращаться к ним. На клавишах А и О, под указательными пальцами, находятся небольшие выступы. Они позволяют ориентироваться на клавиатуре вслепую. \line \line" +
            @"\b Схема клавиатуры \b0 \line" +
            @"Цвет клавиш на клавиатуре в тренажерах поможет тебе понять и запомнить, каким пальцем на какую клавишу нужно нажимать. \line" +
            @"  1) Нажимай клавиши только тем пальцем, который для них предназначен. \line" +
            @"  2) Всегда возвращай пальцы в исходную позицию «ФЫВА – ОЛДЖ». \line" +
            @"  3) Когда набираешь текст, представляй расположение клавиш. \line" +
            @"  4) Установи ритм и соблюдай его, пока печатаешь. Нажимай на клавиши с одинаковым интервалом. \line" +
            @"  5) Клавишу SHIFT всегда нажимает мизинец с противоположной стороны от нужной буквы. \line" +
            @"  6) Пробел отбивай большим пальцем левой или правой руки, как тебе удобнее. \line" +
            @"Сначала такой метод печати может показаться неудобным. Но не останавливайся. Со временем все будет получаться быстро, легко и удобно) \line \line" +
            @"\b Движение пальцев \b0 \line" +
            @"Не подглядывай на клавиатуру во время печати. Просто скользи пальцами по клавишам, пока не найдешь основную строку. Ограничь движение кистей и пальцев до минимума, только чтобы нажимать нужные клавиши. Держи руки и пальцы как можно ближе к исходной позиции. Это увеличит скорость набора текста и снизит нагрузку на кисти. Следи за безымянными пальцами и мизинцами, так как они часто остаются незадействованными. \line \line" +
            @"\b Скорость печати \b0 \line" +
            @"  1) Не пытайся сразу печатать со скоростью света. Начинай ускоряться, только когда все 10 пальцев привыкнут нажимать правильные клавиши. \line" +
            @"  2) Не торопись когда печатаешь, чтобы избежать ошибок. Скорость будет возрастать постепенно. \line" +
            @"  3) Всегда просматривай текст на одно-два слова вперед. \line" +
            @"  4) Переходи на следующий уровень, когда почувствуешь, что запомнил расположение клавиш текущего уровня. Если начинаешь совершать много ошибок, вернись на предыдущий уровень. Тише едешь, дальше будешь. \line \line" +
            @"\b Береги себя \b0 \line" +
            @"Сделай паузу, если чувствуешь, что сбиваешься и делаешь много ошибок. Небольшой перерыв вернет силы и внимательность." +
            @"\line \line \line}";
        private const string ABOUT_AUTHORS= @"{\rtf1\ansi Создателем данного приложения является команда студентов. Надеемся, вам понравилось. \line" +
            @"Связаться с нами можно в группе в вк #название: \line"+
            @"\u #ссылка на группу \u0"+
            @"}";


        public InfoControl(InfoControlResultProc result_handler)
        {
            InitializeComponent();
            InitTree();
            rtbInfo.RightMargin = rtbInfo.Size.Width - 30;
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
                case 1: rtbInfo.Rtf = ABOUT_EDUCATION; break;
                case 2: rtbInfo.Rtf = ABOUT_AUTHORS; break;
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
