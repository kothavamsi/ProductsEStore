using System.Collections.Generic;

namespace ProductsEStore.LogHandler.LogSettingsHandler
{
    public class Listener
    {
        public ListenerType ListenerType { get; set; }
        public string Path { get; set; }
    }

    public enum ListenerType
    {
        html,
        xml
    }

    public static class LogSettings
    {
        public static int SnoCounter { get; set; }
        public static bool Enable { get; set; }
        public static bool Overwrite { get; set; }
        public static List<Listener> Listeners { get; set; }

        static LogSettings()
        {
            Listeners = new List<Listener>();
        }
    }
}

