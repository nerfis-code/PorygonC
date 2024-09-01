using Godot;
using PorygonC.Scenes.Domain;

public static class SceneUi
{
    public static void Load(Scene scene, Node3D node, int index = 0)
    {
        if (index >= scene.PokemonsPlayerGroup.Count){

            var existingOverlay = node.GetNode("overlay_fight");
            node.RemoveChild(existingOverlay);
            existingOverlay.QueueFree();

            scene.EndTurn += () => Load(scene,node,0);
            scene.InitializeTurn();
            return;
        }
        var pkm = scene.PokemonsPlayerGroup[index];

        Control menu = (Control)GD.Load<PackedScene>("res://Game/Mechanics/Menus/overlay_fight.tscn").Instantiate();
        menu.Name = "overlay_fight";
        
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

        // Verificar si el nodo "overlay_fight" ya existe y eliminarlo adecuadamente
        if (node.HasNode("overlay_fight"))
        {
            var existingOverlay = node.GetNode("overlay_fight");
            node.RemoveChild(existingOverlay);
            existingOverlay.QueueFree();
        }
        node.AddChild(menu);
    }
}
