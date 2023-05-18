using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using ImGuiScene;

namespace Jacaranda
{
    internal sealed class MainWindow : Window, IDisposable
    {
        private JacarandaPlugin JacarandaPlugin;

        public MainWindow(JacarandaPlugin plugin)
            : base(
                "My Amazing Window",
                ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse
            )
        {
            this.SizeConstraints = new WindowSizeConstraints
            {
                MinimumSize = new Vector2(375, 330),
                MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
            };

            this.JacarandaPlugin = plugin;
        }

        public void Dispose() { }

        public override void Draw()
        {
            // ImGui.Text(
            //     $"The random config bool is {this.Jacaranda.Configuration.SomePropertyToBeSavedAndWithADefault}"
            // );

            // if (ImGui.Button("Show Settings"))
            // {
            //     this.Jacaranda.DrawConfigUI();
            // }

            // ImGui.Spacing();

            // ImGui.Text("Have a goat:");
            // ImGui.Indent(55);
            // ImGui.Image(
            //     this.GoatImage.ImGuiHandle,
            //     new Vector2(this.GoatImage.Width, this.GoatImage.Height)
            // );
            // ImGui.Unindent(55);
        }
    }
}
