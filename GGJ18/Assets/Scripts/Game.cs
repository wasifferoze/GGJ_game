using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Game : MonoBehaviour
	{
		#region DEBUG_COLLISION_MANAGER

		public CollisionManager CollisionManager;

		public GameObject EnemyPrefab;

		void Start ()
		{
			CollisionManager.Collidables.Clear ();

			for (int i = 0; i < 15; i++)
			{
				Spawn ();
			}

			StartCoroutine (CollisionManager.FindCollision ());
		}

		private void Spawn ()
		{
			GameObject newEnemy = Instantiate<GameObject> (EnemyPrefab);
			newEnemy.transform.position = new Vector3 (
				x: Random.Range (-4.0f, 4.0f),
				y: 0.0f,
				z: Random.Range (-4.0f, 4.0f)
			);
		}

		void Update ()
		{
			if (Random.value < 0.05f)
			{
				for (int i = 0; i < 3; i++)
				{
					Spawn ();
				}
			}
		}

		#endregion
	}
}