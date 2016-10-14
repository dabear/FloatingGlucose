using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatingGlucose.Classes.Extensions
{
    static class FormExtensions
    {
        public static void ShowDialogIfNonVisible(this Form form)
        {
            if(form.Visible)
            {
                return;
            }
            form.ShowDialog();
            
        }
    }
}
