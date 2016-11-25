using System;
using System.Collections.Generic;
using System.IO;
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
        public static bool IsShowingSettings = false;
        public static readonly string AppName = typeof(Program).Assembly.GetName().Name;
        public static string AppVersion {
            get
            {
                try
                {
                    using (var reader = File.OpenText(Path.Combine(AppShared.ExecutableDir, "version.txt")))
                    {
                        return reader.ReadToEnd();
                    }
                } catch (IOException) {
                    return "unknown";
                }
            }

        }
        public static string ExecutableDir => Path.GetDirectoryName(Application.ExecutablePath);

        public static bool SettingsFormShouldFocusAdvancedSettings = false;
        public static bool SettingsUpdatedSuccessfully = false;

        private static Func<bool> callback;

        public static void RegisterSettingsChangedCallback(Func<bool> lambda) {
            AppShared.callback = lambda;
        }
        public static void NotifyFormSettingsHaveChanged() => callback?.Invoke();
            
        
    }
}
