using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AssemblyCSharp.Scripts
{
    [CreateAssetMenu()]
    public class LevelGenerationManager : ScriptableObject
    {
        [SerializeField] public List<GameObject> LevelModulesPool = new List<GameObject>();
        [SerializeField] public float UnitPerPlatform = 12.0f;
        [SerializeField] public GeneratingDirection GeneratingDirection;
        [SerializeField] public GeneratingRule GeneratingRule;
        [SerializeField] public GeneratingFlipRule FlipRule;
        [SerializeField] public int ModulesToKeepLoaded;

        private List<GameObject> GeneratedModules = new List<GameObject>();

        public void Generate()
        {
            Vector3 step = Vector3.zero;

            // Dir <-> Vector map
            switch (GeneratingDirection)
            {
                case GeneratingDirection.X:
                    step = Vector3.right * UnitPerPlatform;
                    break;

                case GeneratingDirection.Y:
                    step = Vector3.up * UnitPerPlatform;
                    break;

                case GeneratingDirection.Z:
                    step = Vector3.forward * UnitPerPlatform;
                    break;
            }

            // Rule <-> Generator map
            var generator = new Dictionary<GeneratingRule, Func<IEnumerator<GameObject>>>()
            {
                { GeneratingRule.Random, GenerationRule_Random },
                { GeneratingRule.Ordered, GenerationRule_Ordered },
            }[GeneratingRule]();

            Generate(step, generator);
        }

        public void Purge()
        {
            GeneratedModules.ForEach((module) =>
            {
                if (module == null) { return; }
                DestroyImmediate(module);
            });

            GeneratedModules.Clear();
        }

        private IEnumerator<GameObject> GenerationRule_Random()
        {
            while (true)
            {
                int nextIdx = (int)(UnityEngine.Random.value * LevelModulesPool.Count);
                yield return LevelModulesPool[nextIdx];
            }
        }

        private IEnumerator<GameObject> GenerationRule_Ordered()
        {
            int nextIdx = 0;
            while (true)
            {
                nextIdx = (nextIdx++) % LevelModulesPool.Count;
                yield return LevelModulesPool[nextIdx];
            }
        }

        /// Actually generate level modules to the level
        private void Generate(Vector3 step, IEnumerator<GameObject> generator)
        {
            int targetCount = ModulesToKeepLoaded - (GeneratedModules.Count / 2);
            for (int i = 0; i < targetCount; i++)
            {
                generator.MoveNext();

                GameObject genModuleLeft = Instantiate(generator.Current);
                genModuleLeft.transform.position = step * i;
                GeneratedModules.Add(genModuleLeft);

                if (FlipRule == GeneratingFlipRule.Regenerate)
                {
                    generator.MoveNext();
                }

                GameObject genModuleRight = Instantiate(generator.Current);
                genModuleRight.transform.position = step * i;
                genModuleRight.transform.rotation = Quaternion.Euler(0, 180, 0);
                GeneratedModules.Add(genModuleRight);
            }
        }

        public IEnumerator UpdatePosition()
        {
            while (true)
            {
                yield return null;


            }
        }
    }

    public enum GeneratingDirection
    {
        X,
        Y,
        Z
    }

    public enum GeneratingRule
    {
        Random,
        Ordered,
    }

    public enum GeneratingFlipRule
    {
        Same,
        Regenerate,
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(LevelGenerationManager))]
    public class LevelGenerationMangerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Generate"))
            {
                var castedTarget = target as LevelGenerationManager;
                if (castedTarget == default(LevelGenerationManager))
                {
                    Debug.LogError("Cast failed");
                    return;
                }

                castedTarget.Purge();
                castedTarget.Generate();
            }
        }
    }
#endif
}
