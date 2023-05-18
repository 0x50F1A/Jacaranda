using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;

namespace Jacaranda
{
    public sealed class JacarandaPlugin : IDalamudPlugin
    {
        public string Name => "Jacaranda";
        private const string CommandName = "/jacaranda";

        private DalamudPluginInterface PluginInterface { get; init; }
        private CommandManager CommandManager { get; init; }
        private static Dalamud.Interface.Windowing.WindowSystem Windows = new("Jacaranda");

        private MainWindow MainWindow { get; init; }

        public JacarandaPlugin(
            [RequiredVersion("1.0")] DalamudPluginInterface pluginInterface,
            [RequiredVersion("1.0")] CommandManager commandManager
        )
        {
            this.PluginInterface = pluginInterface;
            this.CommandManager = commandManager;

            this.CommandManager.AddHandler(
                CommandName,
                new CommandInfo(OnCommand)
                {
                    HelpMessage = "Jacaranda plugin commands.",
                    ShowInHelp = true
                }
            );

            MainWindow = new MainWindow(this);
            Windows.AddWindow(MainWindow);

            this.PluginInterface.UiBuilder.Draw += DrawUI;
        }

        private void OnCommand(string command, string arguments)
        {
            MainWindow.IsOpen = true;
        }

        private void DrawUI()
        {
            Windows.Draw();
        }

        public void Dispose()
        {
            Windows.RemoveAllWindows();

            MainWindow.Dispose();

            this.CommandManager?.RemoveHandler(CommandName);
        }
    }
}
