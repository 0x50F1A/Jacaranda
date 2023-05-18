using Dalamud.Configuration;
using Dalamud.Plugin;
using System;

namespace Jacaranda
{
    [Serializable]
    public class JacarandaConfiguration : IPluginConfiguration
    {
        public int Version { get; set; }

        // the below exist just to make saving less cumbersome
        [NonSerialized]
        private DalamudPluginInterface? PluginInterface;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.PluginInterface = pluginInterface;
        }

        public void Save()
        {
            this.PluginInterface!.SavePluginConfig(this);
        }
    }
}
