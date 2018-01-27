using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp.Scripts
{
	public sealed class EnemyPawn : Pawn
	{
		protected override void Init ()
		{
			CurrentSpeed = Random.Range (0.2F, 2.75F);
			CurrentAngle = Random.Range (-Mathf.PI * 2.0F, Mathf.PI * 2.0F);
		}
	}
}