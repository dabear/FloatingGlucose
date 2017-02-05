using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine("Stopping refresh timer as we are showing settings");
            AppShared.refreshGlucoseTimer?.Stop();

            AppShared.IsShowingSettings = true;
            form.ShowDialog();
            
        }
    }
}
