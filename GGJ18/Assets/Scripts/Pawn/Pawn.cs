using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AssemblyCSharp.Scripts
{
	public abstract class Pawn : MonoBehaviour, ICollidable
	{
		public CollisionManager CollisionManager;

		public SerialFloat Radius;
		public SerialFloat MaxSpeed;
		public SerialFloat Friction;

		public float CurrentSpeed;
		public float CurrentAngle;

		public float DEBUGANGLE;

		public System.Action OnSpawnEvent;
		public System.Action OnCollideEvent;

		public float GetRadius ()
		{
			return Radius.Value;
		}

		public Vector2 GetPosition ()
		{
			Vector3 pos = transform.position;
			return new Vector2 (pos.x, pos.z);
		}

		public float GetAngle ()
		{
			return CurrentAngle;
		}

		public void SetAngle (float angle)
		{
			CurrentAngle = angle;
			DEBUGANGLE = CurrentAngle * Mathf.Rad2Deg;
		}

		public void SetPosition (Vector2 pos)
		{
			transform.position = new Vector3 (
				x: pos.x,
				y: 0.0f,
				z: pos.y
			);
		}

		public bool IsCollide (ICollidable collidable, out Vector2 delta)
		{
			delta = GetPosition () - collidable.GetPosition ();
			float sumRad = GetRadius () + collidable.GetRadius ();
			return delta.sqrMagnitude < sumRad * sumRad;
		}

		public void OnCollide (ICollidable collidable, Vector2 delta)
		{
			CurrentSpeed *= Friction.Value;

			float otherAngle = Mathf.Atan2 (-delta.y, delta.x);

			SetAngle (Mathf.Atan2 (delta.y, delta.x));
			collidable.SetAngle (otherAngle);

			float targetDistance = GetRadius () + collidable.GetRadius () + 0.01f;
			Vector2 shift = new Vector2 (
				                x: Mathf.Cos (CurrentAngle) * targetDistance,
				                y: Mathf.Sin (CurrentAngle) * targetDistance
			                );

			SetPosition (collidable.GetPosition () + shift);
			collidable.SetPosition (GetPosition () - shift);

			if (OnCollideEvent != null)
			{
				OnCollideEvent.Invoke ();
			}
		}

		private void Start ()
		{
			if (CollisionManager != null &&
			    !CollisionManager.Collidables.Contains (this))
			{
				CollisionManager.Collidables.Add (this);
			}

			if (OnSpawnEvent != null)
			{
				OnSpawnEvent.Invoke ();
			}

			Init ();
		}

		protected virtual void Update ()
		{
			Vector3 speed = new Vector3 (
				                x: CurrentSpeed * Mathf.Cos (CurrentAngle),
				                y: 0.0f,
				                z: CurrentSpeed * Mathf.Sin (CurrentAngle)
			                );
			transform.position += speed * Time.deltaTime;
			transform.forward = speed;
		}

		protected virtual void Init ()
		{
			// Do nothing
		}

		protected virtual void Die ()
		{
			if (CollisionManager != null &&
			    CollisionManager.Collidables.Contains (this))
			{
				CollisionManager.Collidables.Remove (this);
			}
		}
	}
}
