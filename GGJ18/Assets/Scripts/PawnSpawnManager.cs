﻿using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AssemblyCSharp.Scripts
{
    [CreateAssetMenu()]
    public class PawnSpawnManager : ScriptableObject
    {
        private Stack<Pawn> ObjectPool = new Stack<Pawn>();

        [SerializeField] public CollisionManager CollisionManager;
        [SerializeField] public Pawn PawnPrefabToSpawn;
        [SerializeField] public Rect SpawnArea;

        public void InitializePool(int poolSize = 30)
        {
            Spawn(poolSize).ForEach(Return);
        }

        public Pawn Get()
        {
            Pawn result = null;
            if (ObjectPool.Count <= 0)
            {
                result = Instantiate(PawnPrefabToSpawn);
            }
            else
            {
                result = ObjectPool.Pop();
                result.gameObject.SetActive(true);
            }

            result.transform.position = GetRandomSpawnPosition();
            return result;
        }

        public Vector3 GetRandomSpawnPosition()
        {
            var x = Random.Range(SpawnArea.xMin, SpawnArea.xMax);
            var z = Random.Range(SpawnArea.yMin, SpawnArea.yMax);
            return new Vector3(x, 0, z);
        }

        public void Return(Pawn pawn)
        {
            ObjectPool.Push(pawn);
            pawn.gameObject.SetActive(false);
        }

        public List<Pawn> Spawn(int count = 1)
        {
            List<Pawn> spawned = new List<Pawn>();
            for (int i = 0; i < count; i++)
            {
                spawned.Add(Get());
            }
            return spawned;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(PawnSpawnManager))]
    public class PawnSpawnManagerEditor : Editor
    {
        public void OnDrawGizmos()
        {
            var manager = target as PawnSpawnManager;
            Gizmos.color = Color.red;
            Gizmos.DrawCube(manager.SpawnArea.center, manager.SpawnArea.size);
        }
    }
#endif
}