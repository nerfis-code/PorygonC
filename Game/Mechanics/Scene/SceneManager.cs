using System.Linq;
using System.Threading.Tasks;
using Godot;
using PorygonC.Domain;
using PorygonC.Infrastructure;

public static class SceneNodeManager
{
	public static void InitializeSceneNode(Node3D node,Trainer player, Trainer opponent)
	{
		SceneManager.InitializeScene(player,opponent);
		
		
		SceneNode scene = (SceneNode)GD.Load<PackedScene>("res://Game/Mechanics/Scene/SceneNode.tscn").Instantiate();
		scene.Identity = SceneManager.Scene;
		node.AddChild(scene);
		scene.Position += new Vector3 (0,2,0);
		

	}
	
}
