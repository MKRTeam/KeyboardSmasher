using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace KeyboardSmasher
{
    static class KeyboardHelper {
        /// <summary>
        /// Метод получения русской буквы в верхнем регистре по коду клавиши.
        /// Если клавише не соответствует русская буква, вернётся '\0'
        /// </summary>
        /// <param name="keyCode">Код клавиши</param>
        /// <returns></returns>
        public static char GetUpperRusCharForKey(Keys keyCode) {
            switch (keyCode) {
                case Keys.Space: return ' ';
                case Keys.Q: return 'Й';
                case Keys.W: return 'Ц';
                case Keys.E: return 'У';
                case Keys.R: return 'К';
                case Keys.T: return 'Е';
                case Keys.Y: return 'Н';
                case Keys.U: return 'Г';
                case Keys.I: return 'Ш';
                case Keys.O: return 'Щ';
                case Keys.P: return 'З';
                case Keys.Oem4: return 'Х'; // Клавиша {
                case Keys.Oem6: return 'Ъ'; // Клавиша }
                case Keys.A: return 'Ф';
                case Keys.S: return 'Ы';
                case Keys.D: return 'В';
                case Keys.F: return 'А';
                case Keys.G: return 'П';
                case Keys.H: return 'Р';
                case Keys.J: return 'О';
                case Keys.K: return 'Л';
                case Keys.L: return 'Д';
                case Keys.Oem1: return 'Ж'; // Клавиша ;
                case Keys.Oem7: return 'Э'; // Клавиша '
                case Keys.Z: return 'Я';
                case Keys.X: return 'Ч';
                case Keys.C: return 'С';
                case Keys.V: return 'М';
                case Keys.B: return 'И';
                case Keys.N: return 'Т';
                case Keys.M: return 'Ь';
                case Keys.Oemcomma: return 'Б'; // Клавиша <
                case Keys.OemPeriod: return 'Ю'; // Клавиша >
                default: return '\0';
            }
        }

        /// <summary>
        /// Метод получения английской буквы в верхнем регистре по коду клавиши.
        /// Если клавише не соответствует английская буква, вернётся '\0'
        /// </summary>
        /// <param name="keyCode">Код клавиши</param>
        /// <returns></returns>
        public static char GetUpperEngCharForKey(Keys keyCode) {
            switch (keyCode) {
                case Keys.Space: return ' ';
                case Keys.Q: return 'Q';
                case Keys.W: return 'W';
                case Keys.E: return 'E';
                case Keys.R: return 'R';
                case Keys.T: return 'T';
                case Keys.Y: return 'Y';
                case Keys.U: return 'U';
                case Keys.I: return 'I';
                case Keys.O: return 'O';
                case Keys.P: return 'P';
                case Keys.A: return 'A';
                case Keys.S: return 'S';
                case Keys.D: return 'D';
                case Keys.F: return 'F';
                case Keys.G: return 'G';
                case Keys.H: return 'H';
                case Keys.J: return 'J';
                case Keys.K: return 'K';
                case Keys.L: return 'L';
                case Keys.Z: return 'Z';
                case Keys.X: return 'X';
                case Keys.C: return 'C';
                case Keys.V: return 'V';
                case Keys.B: return 'B';
                case Keys.N: return 'N';
                case Keys.M: return 'M';
                default: return '\0';
            }
        }


        /// <summary>
        /// Цвета, используемые при раскраске букв
        /// </summary>
        public static readonly Color[] Colors = new Color[] {
            Color.FromArgb(255, 238, 51, 67), // Клавиши Q, A, Z - красный
            Color.FromArgb(255, 250, 166, 29), // Клавиши W, S, X - оранжевый
            Color.FromArgb(255, 112, 230, 123), // Клавиши E, D, C - зелёный
            Color.FromArgb(255, 0, 176, 236), // Клавиши R, F, V, T, G, B - голубой
            Color.FromArgb(255, 89, 133, 193), // Клавиши Y, H, N, U, J, M - тёмно-синий
            Color.FromArgb(255, 151, 215, 246), // Клавиши I, K, < - светло-голубой
            Color.FromArgb(255, 235, 200, 160),  // Клавиши O, L, > - кремовый
            Color.FromArgb(255, 192, 225, 191), // Клавиши P, :, ?, [, ], ' - светло-зелёный
            Color.Black // Остальные клавиши - чёрный
        };

        /// <summary>
        /// Метод для получения цвета русской или английской буквы (в верхнем регистре)
        /// в соответствии с изображением раскрашенной клавиатуры в цвет определённых пальцев
        /// </summary>
        /// <param name="c">Английская или русская буква в верхнем регистре</param>
        /// <returns></returns>
        public static Color GetKeyColorForChar(char c) {
            if (c == 'Й' || c == 'Ф' || c == 'Я'
                || c == 'Q' || c == 'A' || c == 'Z')
                return Colors[0];
            else if (c == 'Ц' || c == 'Ы' || c == 'Ч'
                || c == 'W' || c == 'S' || c == 'X')
                return Colors[1];
            else if (c == 'У' || c == 'В' || c == 'С'
                || c == 'E' || c == 'D' || c == 'C')
                return Colors[2];
            else if (c == 'К' || c == 'А' || c == 'М' || c == 'Е' || c == 'П' || c == 'И'
                || c == 'R' || c == 'F' || c == 'V' || c == 'T' || c == 'G' || c == 'B')
                return Colors[3];
            else if (c == 'Н' || c == 'Р' || c == 'Т' || c == 'Г' || c == 'О' || c == 'Ь'
                || c == 'Y' || c == 'H' || c == 'N' || c == 'U' || c == 'J' || c == 'M')
                return Colors[4];
            else if (c == 'Ш' || c == 'Л' || c == 'Б'
                || c == 'I' || c == 'K')
                return Colors[5];
            else if (c == 'Щ' || c == 'Д' || c == 'Ю'
                || c == 'O' || c == 'L')
                return Colors[6];
            else if (c == 'З' || c == 'Ж' || c == 'Х' || c == 'Э' || c == 'Ъ'
                || c == 'P')
                return Colors[7];
            else
                return Colors[8];
        }
    }
}
