using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace KeyboardSmasher
{
    static class KeyboardHelper
    {
        /// <summary>
        /// Метод получения русской буквы в верхнем регистре по коду клавиши.
        /// Если клавише не соответствует русская буква, вернётся '\0'
        /// </summary>
        /// <param name="keyCode">Код клавиши</param>
        /// <returns></returns>
        public static char GetUpperRusCharForKey(Keys keyCode)
        {
            switch (keyCode)
            {
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
        public static char GetUpperEngCharForKey(Keys keyCode)
        {
            switch (keyCode)
            {
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
        /// Метод для получения цвета русской буквы в соответствии с изображением
        /// раскрашенной клавиатуры в цвет определённых пальцев
        /// </summary>
        /// <param name="rusChar">Русская буква</param>
        /// <returns></returns>
        public static Color GetKeyColorForRusChar(char rusChar) {
            if (rusChar == 'Й' || rusChar == 'Ф' || rusChar == 'Я')
                return Color.Red;
            else if (rusChar == 'Ц' || rusChar == 'Ы' || rusChar == 'Ч')
                return Color.Orange;
            else if (rusChar == 'У' || rusChar == 'В' || rusChar == 'С')
                return Color.Green;
            else if (rusChar == 'К' || rusChar == 'А' || rusChar == 'М' || rusChar == 'Е' || rusChar == 'П' || rusChar == 'И')
                return Color.Blue;
            else if (rusChar == 'Н' || rusChar == 'Р' || rusChar == 'Т' || rusChar == 'Г' || rusChar == 'О' || rusChar == 'Ь')
                return Color.Violet;
            else if (rusChar == 'Ш' || rusChar == 'Л' || rusChar == 'Б')
                return Color.LightBlue;
            else if (rusChar == 'Щ' || rusChar == 'Д' || rusChar == 'Ю')
                return Color.MintCream;
            else if (rusChar == 'З' || rusChar == 'Ж' || rusChar == 'Х' || rusChar == 'Э' || rusChar == 'Ъ')
                return Color.Gray;
            else
                return Color.Black;
        }


        /// <summary>
        /// Метод для получения цвета английской буквы в соответствии с изображением
        /// раскрашенной клавиатуры в цвет определённых пальцев
        /// </summary>
        /// <param name="rusChar">Английская буква</param>
        /// <returns></returns>
        public static Color GetKeyColorForEngChar(char rusChar) {
            if (rusChar == 'Q' || rusChar == 'A' || rusChar == 'Z')
                return Color.Red;
            else if (rusChar == 'W' || rusChar == 'S' || rusChar == 'X')
                return Color.Orange;
            else if (rusChar == 'E' || rusChar == 'D' || rusChar == 'C')
                return Color.Green;
            else if (rusChar == 'R' || rusChar == 'F' || rusChar == 'V' || rusChar == 'T' || rusChar == 'G' || rusChar == 'B')
                return Color.Blue;
            else if (rusChar == 'Y' || rusChar == 'H' || rusChar == 'N' || rusChar == 'U' || rusChar == 'J' || rusChar == 'M')
                return Color.Violet;
            else if (rusChar == 'I' || rusChar == 'K')
                return Color.LightBlue;
            else if (rusChar == 'O' || rusChar == 'L')
                return Color.MintCream;
            else if (rusChar == 'P')
                return Color.Gray;
            else
                return Color.Black;
        }
    }
}
