using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher.ExerciseMachine.GUI
{
    public partial class WordsOnReactionControl : UserControl
    {
        public WordsOnReactionControl()
        {
            InitializeComponent();
            tB_Reading.BackColor = System.Drawing.Color.FromArgb(198, 178, 153);
            tB_Reading.ForeColor = System.Drawing.Color.FromArgb(153, 134, 117);
        }
    }
}
