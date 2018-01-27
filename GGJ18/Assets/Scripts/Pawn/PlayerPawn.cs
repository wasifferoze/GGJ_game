using UnityEngine;

namespace AssemblyCSharp.Scripts
{
	public sealed class PlayerPawn : Pawn
	{
		protected override void Init ()
		{
			CurrentSpeed = Random.Range (-1.0F, 1.0F) * 5.0f;
			CurrentAngle = Random.Range (-Mathf.PI, Mathf.PI);
		}
	}
}

