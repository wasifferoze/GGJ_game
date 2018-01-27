using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    [CreateAssetMenu()]
    public class LevelGenerationManager : ScriptableObject
    {
        [SerializeField] public List<GameObject> LevelModules = new List<GameObject>();

        public void Generate()
        {

        }
    }
}
