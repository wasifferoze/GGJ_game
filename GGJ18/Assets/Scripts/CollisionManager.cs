using UnityEngine;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[CreateAssetMenu ()]
	public class CollisionManager : Manager
	{
		public readonly List<ICollidable> Collidables = new List<ICollidable> ();

		// Collision checking coroutine
		public IEnumerator FindCollision ()
		{
			while (true)
			{
				yield return null;

				const int PROCESS_PER_FRAME = 250;
				int process = PROCESS_PER_FRAME;
				int count = Collidables.Count;
				for (int i = 0; i < count - 2; i++)
				{
					for (int j = i + 1; j < count - 1; j++)
					{
						if (process-- <= 0)
						{
							process = PROCESS_PER_FRAME;
							yield return null;
						}

						ICollidable A = Collidables [i];
						ICollidable B = Collidables [j];

						Vector2 delta;
						if (A.IsCollide (B, out delta))
						{
							A.OnCollide (B, delta);
							B.OnCollide (A, -delta);
						}
					}
				}
			}
		}
	}
}
