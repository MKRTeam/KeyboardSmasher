using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardSmasher
{
    public class UserControl : System.Windows.Forms.UserControl
    {
        public virtual void Control_KeyPress(object sender, KeyPressEventArgs e)
        { }
        public virtual void Control_KeyDown(object sender, KeyEventArgs e)
        { }
    }
}
