using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatingGlucose.Classes
{
    class AppShared
    {
        public static string appName = "FloatingGlucose";
        public static bool settingsFormShouldFocusAdvancedSettings = false;

  
        public static Func<bool> callbacks;

        public static void RegisterSettingsChangedCallback(Func<bool> lambda) {
            callbacks = lambda;
        }
        public static void notifyFormSettingsHaveChanged() {
            if (callbacks != null) {
                callbacks.Invoke();
            }
        }
    }
}
