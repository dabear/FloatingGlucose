using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FloatingGlucose.Classes.Extensions
{
    internal static class FormExtensions
    {
        public static void ShowDialogIfNonVisible(this FormGlucoseSettings form)
        {
            if (form.Visible)
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