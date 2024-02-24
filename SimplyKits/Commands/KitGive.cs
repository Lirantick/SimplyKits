using Cysharp.Threading.Tasks;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Commands;
using SDG.Unturned;
using System;
using OpenMod.Unturned.Users;
using OpenMod.Extensions.Games.Abstractions.Items;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.Extensions.Localization;


namespace SimplyKits {

    // Metadata para la clase, acá definimos cómo llamar al comando, shortcuts para llamarlos, descripcion e información de la sintaxis entre otras coas

    [Command("kit")] // The primary name for the command. Usually, it is defined as lowercase. 
    [CommandAlias("k")] // Add "awsm" as alias.
    [CommandDescription("Command to get a kit")] // Description. Try to keep it short and simple.
    [CommandSyntax("<kitName>")] // Describe the syntax/usage. Use <> for required arguments and [] for optional arguments.


    public class KitGive : UnturnedCommand
    {
        
        IItemSpawner _itemSpawner;
        IConfiguration _configuration;
        ILogger<CorePlugin> _logger;
        IStringLocalizer _stringLocalizer;

        // Constructor de la clase, toma como entrada serviceProvider que es una instancia de una interface y con :base lo manda a la clase padre, la verdad ni idea que hace esto, pero se llama inyección de dependencias.

        // Acá tambien inyecte la dependencia UnturnedPlayer, que nos da métodos para interactuar con el player y traernos info.
        public KitGive(IStringLocalizer stringLocalizer,ILogger<CorePlugin> logger, IConfiguration configuration, IItemSpawner itemSpawner, IServiceProvider serviceProvider) : base(serviceProvider) {
            _itemSpawner = itemSpawner;
            _configuration = configuration;
            _logger = logger;
            _stringLocalizer = stringLocalizer;

        }

        // Él código que ejecutará el plugin, acá está la magia.
        protected override async UniTask OnExecuteAsync() {

            // Cargamos al usuario que ejecuta el comando dentro de player
            var player = Context.Actor as UnturnedUser;

            // Cargamos al inventario del jugador que ejecuto el comando dentro de playerInventory
            var playerInventory = player.Player.Inventory;

            // Leemos el flag del espacio uno que puso el usuario, en este caso el flag seria kit1 si usara /kit kit1.
            var kitName = await Context.Parameters.GetAsync<string>(0);

            var kitSection = _configuration.GetSection("kits:" + kitName);

            if (!kitSection.Exists() || kitSection.GetChildren().Count() == 0) {
                await player.PrintMessageAsync(_stringLocalizer ["kit_events:kit_unknown"]);
            }else { 
            
            foreach (var childSection in kitSection.GetChildren()) {

                var kitKey = childSection.Key;
                var itemId = childSection["id"];
                var itemQty = int.Parse(childSection ["qty"]);


                    for (var i = 0; i < itemQty; i++) {

                        await _itemSpawner.GiveItemAsync(playerInventory, itemId);
                    } 

                }

            await player.PrintMessageAsync(_stringLocalizer["kit_events:kit_given"]);

            }


        }

    }
}
