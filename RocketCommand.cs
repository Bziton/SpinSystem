using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;

namespace SpinSystem
{
    public class SpinSystem : IRocketCommand
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
                UnturnedChat.Say(player, "Введіть /spin <сума>");
                return;
            }

            // Логіка для парсингу кількості
            if (!uint.TryParse(command[0], out uint amount) || amount == 0)
            {
                UnturnedChat.Say(player, "Введіть правильну кількість.");
                return;
            }

        }
    }
}