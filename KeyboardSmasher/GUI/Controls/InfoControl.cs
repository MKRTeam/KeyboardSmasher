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

        private const string ABOUT_PROGRAMM = "Программа KeySmasher предназначена в качестве тренажера для обучения слепой печати в игровой форме.";
        public InfoControl(InfoControlResultProc result_handler)
        {
            InitializeComponent();
            InitTree();
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
                case 0: rtbInfo.Text = ABOUT_PROGRAMM; break;
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
