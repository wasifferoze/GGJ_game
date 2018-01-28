using System.Collections;
using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    public sealed class EnemyPawn : Pawn
    {
        protected override void Init()
        {
            IsInfected = Random.value < 0.5f;
            StartCoroutine(Wandering());
        }

        private IEnumerator Wandering()
        {
            float nextRotate = Time.time + Random.Range(0.1f, 0.5f);
            SetAngle(Random.value * Mathf.PI - Mathf.PI * 2.0f);

            CurrentVelocity = Random.value * MaxSpeed.Value;
            while (true)
            {
                if (Time.time > nextRotate)
                {
                    nextRotate = Time.time + Random.Range(3.5f, 5.0f);
                    SetAngle(GetAngle() + Random.Range(-25.0f, 25.0f) * Mathf.Deg2Rad);
                    CurrentVelocity = Random.value * MaxSpeed.Value;
                }

                yield return null;
            }
        }
    }
}