using System;
using Godot;
using PorygonC.Domain;

public static class CollisionShapeHelper
{
	public static void AdjustCollisionShapeToSprite(PokemonNode node)
	{	
		var image = node.GetNode<Sprite3D>("PokemonSprite3D").Texture.GetImage();
		int box = image.GetHeight();
		int minX = box;
		int minY = box;
		int maxX = 0;
		int maxY = 0;
		for (int y = 0; y < box; y++)
			{
				for (int x = 0; x < box; x++)
				{
					var color = image.GetPixel(x, y);
					if (color.A > 0) // Considerar solo píxeles no transparentes
					{
						minX = Math.Min(minX, x);
						minY = Math.Min(minY, y);
						maxX = Math.Max(maxX, x);
						maxY = Math.Max(maxY, y);
					}
				}
			}
			var width = (maxX - minX + 1) / 100f;
			var height = (maxY - minY + 1 ) / 100f;

			var boxShape = new BoxShape3D
			{
				Size = new Vector3(width, height, 0.1f) // El tercer valor es la profundidad del box
			};

			// Asignar la forma de colisión al CollisionShape3D
			var collisionShape = node.GetNode<CollisionShape3D>("CollisionShape3D");
			collisionShape.Shape = boxShape;

			var Y = (minY / 100f) + (height / 2) - (box / 100f / 2);
			var X = (minX / 100f) + (width / 2) - (box / 100f / 2);
			collisionShape.Position = new Vector3(-X , -Y, 0);
			
	}
}
