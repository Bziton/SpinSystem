using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using SDG.Unturned;

namespace SpinSystem
{
    public class Plugin : RocketPlugin<Config>
    {
        public static Plugin Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("SpinSystem Loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("SpinSystem Unloaded.");
        }
    }
}
