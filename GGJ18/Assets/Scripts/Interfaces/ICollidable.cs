using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public interface ICollidable
	{
		float GetRadius ();


		float GetAngle ();

		void SetAngle (float angle);


		Vector2 GetPosition ();

		void SetPosition (Vector2 position);


		bool IsCollide (ICollidable collidable, out Vector2 delta);

		void OnCollide (ICollidable collidable, Vector2 delta);
	}
}
