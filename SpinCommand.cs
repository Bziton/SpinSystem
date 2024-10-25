using System;
using System.Collections.Generic;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;

namespace SpinSystem
{
    public class SpinCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "spin";
        public string Help => "Try your luck to double or lose your experience!";
        public string Syntax => "<amount>";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string> { "spin.use" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            if (command.Length == 0)
            {
                UnturnedChat.Say(player, "Використання: /spin <сума>");
                return;
            }

            if (!uint.TryParse(command[0], out uint amount) || amount == 0)
            {
                UnturnedChat.Say(player, "Будь ласка, введіть правильну кількість досвіду для ставки.");
                return;
            }

            if (player.Experience < amount)
            {
                UnturnedChat.Say(player, "У вас недостатньо досвіду для ставки.");
                return;
            }

            player.Experience -= amount;

            Random rand = new Random();
            int luck = rand.Next(0, 100);

            if (luck < 30)
            {
                uint reward = amount * 2;
                player.Experience += reward;
                UnturnedChat.Say(player, $"Вітаємо! Ви виграли {reward} досвіду.");
            }
            else
            {
                UnturnedChat.Say(player, $"Ви втратили свою ставку в {amount} досвіду. Удача не на вашому боці.");
            }
        }
    }
}