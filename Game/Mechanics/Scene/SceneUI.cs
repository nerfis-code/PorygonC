using Godot;
using PorygonC.Domain;

public static class SceneUi
{
    public static void Load(Scene scene, Node3D node, int index = 0)
    {
        if (index >= scene.PokemonsPlayerGroup.Count){

            var existingOverlay = node.GetNode("OverlayFight");
            node.RemoveChild(existingOverlay);
            existingOverlay.QueueFree();

            scene.EndTurn += () => Load(scene,node,0);
            scene.InitializeTurn();
            return;
        }
        var pkm = scene.PokemonsPlayerGroup[index];

        Control menu = (Control)GD.Load<PackedScene>("res://Game/Mechanics/Menus/OverlayFight.tscn").Instantiate();
        menu.Name = "OverlayFight";
        
        int n = 0;
        foreach (Button button in menu.GetNode("Action").GetChildren())
        {
            var currMove = pkm.Moves[n];
            button.Text = pkm.Moves[n].Name;
            button.Pressed += () => {
                pkm.CurrMove = currMove;
                SceneUi.Load(scene, node, index + 1);
            };

            n++;
        }

        // Verificar si el nodo "OverlayFight" ya existe y eliminarlo adecuadamente
        if (node.HasNode("OverlayFight"))
        {
            var existingOverlay = node.GetNode("OverlayFight");
            node.RemoveChild(existingOverlay);
            existingOverlay.QueueFree();
        }
        node.AddChild(menu);
    }
}
