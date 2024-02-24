using Cysharp.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OpenMod.Core.Commands;
using OpenMod.Extensions.Games.Abstractions.Items;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Users;
using SDG.Unturned;
using SimplyKits;
using System;
using static SDG.Provider.SteamGetInventoryResponse;


namespace Lirantick.SimplyKits.Commands {

    // Metadata para la clase, acá definimos cómo llamar al comando, shortcuts para llamarlos, descripcion e información de la sintaxis entre otras coas

    [Command("kits")] // The primary name for the command. Usually, it is defined as lowercase. 
    [CommandDescription("Command to get a list of kits")] // Description. Try to keep it short and simple.

    internal class KitList : UnturnedCommand {
        IConfiguration _configuration;
        ILogger<CorePlugin> _logger;
        IStringLocalizer _stringLocalizer;
        String kitList;




        IServiceProvider _serviceProvider;
        public KitList(IStringLocalizer stringLocalizer, ILogger<CorePlugin> logger, IConfiguration configuration, IServiceProvider serviceProvider) : base(serviceProvider) {
            _configuration = configuration;
            _logger = logger;
            _stringLocalizer = stringLocalizer;

        }



        protected override async UniTask OnExecuteAsync() {
            
            var player = Context.Actor as UnturnedUser;

            var kitSection = _configuration.GetSection("kits");

            foreach (var kit in kitSection.GetChildren()) {
                kitList = kitList + ", " + kit.Key;


            }

            await player.PrintMessageAsync(_stringLocalizer ["kit_events:kit_list"] + kitList);
        }
    }
}
