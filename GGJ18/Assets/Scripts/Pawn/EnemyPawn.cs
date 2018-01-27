using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AssemblyCSharp.Scripts
{
    public sealed class EnemyPawn : Pawn
    {
        private NavMeshAgent NavMeshAgentCache;

        protected override void Init()
        {
            NavMeshAgentCache = GetComponent<NavMeshAgent>();

            NavMeshAgentCache.Move(new Vector3(
                x: Random.Range(-1.0f, 1.0f),
                y: 0.0f,
                z: Random.Range(-1.0f, 1.0f)
            ));
        }
    }
}