using System.Collections;
using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    public sealed class EnemyPawn : Pawn
    {
        protected override void Init()
        {
            StartCoroutine(Wandering());
        }

        private IEnumerator Wandering()
        {
            float nextRotate = Time.time + Random.Range(0.1f, 0.5f);
            SetAngle(Random.value * Mathf.PI - Mathf.PI * 2.0f);

            CurrentSpeed = Random.value * 0.5f + 2.5f;
            while (true)
            {
                if (Time.time > nextRotate)
                {
                    nextRotate = Time.time + Random.Range(1.5f, 2.0f);
                    SetAngle(GetAngle() + Random.Range(-25.0f, 25.0f) * Mathf.Deg2Rad);
                }

                yield return null;
            }
        }
    }
}