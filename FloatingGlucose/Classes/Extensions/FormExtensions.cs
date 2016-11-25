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
        public static void ShowDialogIfNonVisible(this FormGlucoseSettings form)
        {
            if(form.Visible)
            {
                return;
            }
            AppShared.IsShowingSettings = true;
            form.ShowDialog();
            
        }
    }
}
