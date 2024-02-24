using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Plugins;
using OpenMod.API.Plugins;

// For more, visit https://openmod.github.io/openmod-docs/devdoc/guides/getting-started.html

[assembly: PluginMetadata("Lirantick.SimplyKits", DisplayName = "A easy way to add kits to your server")]
namespace SimplyKits
{
    public class CorePlugin : OpenModUnturnedPlugin {
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly ILogger<CorePlugin> m_Logger;


        // Incializamos un constructor con configuraciones hechas previamente

        public CorePlugin(IConfiguration configuration,IStringLocalizer stringLocalizer,ILogger<CorePlugin> logger,IServiceProvider serviceProvider) : base(serviceProvider) {
            m_StringLocalizer = stringLocalizer;
            m_Logger = logger;
        }

        // Método llamado OnLoadAsync, propio de OpenMod, dentro de él se codifican las operaciones que queremos que haga el mod al ser cargado.

        protected override async UniTask OnLoadAsync() {
            // await UniTask.SwitchToMainThread(); uncomment if you have to access Unturned or UnityEngine APIs
            m_Logger.LogInformation("Lirantick.SimplyKits loaded successfully");

            m_Logger.LogInformation("Package version: 1.0.0");


            // await UniTask.SwitchToThreadPool(); // you can switch back to a different thread
        }

        // Método llamado OnUnloadAsync, propio de OpenMod, dentro de él se codifican las operaciones que queremos que haga el mod al ser descargado.

        protected override async UniTask OnUnloadAsync() {
            // await UniTask.SwitchToMainThread(); uncomment if you have to access Unturned or UnityEngine APIs
            m_Logger.LogInformation(m_StringLocalizer["plugin_events:plugin_stop"]);

            m_Logger.LogInformation("Lirantick.SimplyKits unloaded :(");
        }
    }
}
