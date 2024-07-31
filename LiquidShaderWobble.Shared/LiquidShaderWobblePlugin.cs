using BepInEx;
using BepInEx.Logging;

namespace LiquidShaderWobblePlugin
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class LiquidShaderWobblePlugin : BaseUnityPlugin
    {
        internal const string PLUGIN_GUID = "RSkoi.LiquidShaderWobblePlugin";
        internal const string PLUGIN_NAME = "LiquidShaderWobblePlugin";
        internal const string PLUGIN_VERSION = "1.0.0";

        internal static LiquidShaderWobblePlugin _instance;
        internal static ManualLogSource _logger;

        internal void Awake()
        {
            _instance = this;
            _logger = Logger;
        }
    }
}
