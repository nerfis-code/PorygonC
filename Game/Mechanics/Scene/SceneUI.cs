using System.Threading.Tasks;
using Godot;
using PorygonC.Domain;

public class SceneUI
{
    public SceneNode Identity;
    private TaskCompletionSource<bool> _keyPressCompletionSource;

    public async Task Party()
    {
        Control menu = (Control)GD.Load<PackedScene>("res://Game/Mechanics/Menus/Party/Party.tscn").Instantiate();
        Identity.AddChild(menu);

        var col = 0;
        foreach (var pokemon in Identity.Identity.Player.Team)
        {
            TextureButton Panel = (TextureButton)GD.Load<PackedScene>("res://Game/Mechanics/Menus/Party/Panel.tscn").Instantiate();
            Panel.GetNode<Label>("Label").Text = pokemon.Name + (pokemon.IsDefeated ? " Dead" : "");

            if(col == 0){
                menu.GetNode<VBoxContainer>("Column1").AddChild(Panel);
                col++;
            }else{
                menu.GetNode<VBoxContainer>("Column2").AddChild(Panel);
                col--;
            }
            if(Identity.Identity.Where(pokemon) != null){
                continue;
            }
            if(pokemon.IsDefeated){
                continue;
            }
            
            Panel.Pressed += ()=>{
                Identity.RemoveChild(menu);
                menu.QueueFree();
                Identity.Identity.AssigGroup([pokemon],Identity.Identity.Group0);
                _keyPressCompletionSource?.TrySetResult(true);
            };
        }
        _keyPressCompletionSource = new TaskCompletionSource<bool>();
		await _keyPressCompletionSource.Task;
    }
    public void Action(int index = 0)
    {
        if (index >= Identity.Identity.Group0.Count){

            var existingOverlay = Identity.GetNode("OverlayFight");
            Identity.RemoveChild(existingOverlay);
            existingOverlay.QueueFree();

            Identity.Identity.EndTurn += () => Action(0);
            Identity.Identity.InitializeTurn();
            return;
        }
        var pkm = Identity.Identity.Group0[index];
        if (pkm == null){
            Action(index + 1);
        }

        Control menu = (Control)GD.Load<PackedScene>("res://Game/Mechanics/Menus/OverlayFight.tscn").Instantiate();
        menu.Name = "OverlayFight";
        
        int n = 0;
        foreach (Button button in menu.GetNode("Action").GetChildren())
        {
            var currMove = pkm.Moves[n];
            button.Text = pkm.Moves[n].Name;
            button.Pressed += () => {
                pkm.CurrMove = currMove;
                Action(index + 1);
            };

            n++;
        }

        // Verificar si el nodo "OverlayFight" ya existe y eliminarlo adecuadamente
        if (Identity.HasNode("OverlayFight"))
        {
            var existingOverlay = Identity.GetNode("OverlayFight");
            Identity.RemoveChild(existingOverlay);
            existingOverlay.QueueFree();
        }
        Identity.AddChild(menu);
    }
}
