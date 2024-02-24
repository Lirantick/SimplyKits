# SimplyKits
[![Steam Badge](https://img.shields.io/badge/steam-blue)](https://steamcommunity.com/id/lirantick/)
[![Donation Badge](https://img.shields.io/badge/donate-yellow)](https://www.paypal.com/donate/?hosted_button_id=P6K7NMBQY28EA)



A simple way to add plugins to your Unturned server.

## Features 👁️

- Configurable kits using a single yaml file.
- Customizable messages related to kits.
- A command to list the kits configured in the configuration file.

## Commands 🙀

### /kit

- **Name:** kit
- **Description:** Give a kit to a player.
- **Aliases:** k
- **Usage:** /kit [kitName]
- **Permissions:**
  - SimplyKits:commands.kit

 ### /kits

- **Name:** kits
- **Description:** Display a list of kits.
- **Usage:** /kits 
- **Permissions:**
  - SimplyKits:commands.kits


## How to configure kits 😼


In this case i want two kits called kit1 and kit2, these kits will give some special items but we need two things to configure these kits, first, the ID of the item (you can found the items ID [here](https://unturnedhub.com/items)) and second, the quantity. Let's see an example of a configuration.yaml file:


```yaml
kits:
  kit1:
    item1:
      id: 50
      qty: 1
    item2: 
      id: 120
      qty: 5
  kit2:
    item1:
      id: 10
      qty: 1
```

Of course you can change the name of the kits replacing kit1 for thief, for example. 

## How translate the messages 😼

This plugin has three messages and can be customizable throught the translations.yaml file, these are:

- **kit_given:** A message when a player receive a kit.
- **kit_unknown:** A message when a player try to receive a inexistent kit.
- **kit_list:** A message when a player use /kits, for example: "The kits are:"


## Thank you 😸

This is my first plugin, so there may be improvements in the future. Any stars or donations will be appreciated!
