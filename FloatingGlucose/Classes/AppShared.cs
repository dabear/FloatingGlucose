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
        public static bool IsWorkStationLocked = false;
        public static readonly string AppName = typeof(Program).Assembly.GetName().Name;
        public static bool SettingsFormShouldFocusAdvancedSettings = false;

        private static Func<bool> callback;

        public static void RegisterSettingsChangedCallback(Func<bool> lambda) {
            AppShared.callback = lambda;
        }
        public static void NotifyFormSettingsHaveChanged() => callback?.Invoke();
            
        
    }
}
