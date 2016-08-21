using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloatingGlucose.Classes
{
    class AppShared
    {
        public static string appName = typeof(Program).Assembly.GetName().Name;
        public static bool settingsFormShouldFocusAdvancedSettings = false;

        public static Func<bool> callback;

        public static void RegisterSettingsChangedCallback(Func<bool> lambda) {
            AppShared.callback = lambda;
        }
        public static void notifyFormSettingsHaveChanged() => callback?.Invoke();
            
        
    }
}
