using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    public class Game : MonoBehaviour
    {
        public CollisionManager CollisionManager;
        public LevelGenerationManager LevelGenerationManager;

        void Start()
        {
            InitCollisionManager();
            InitLevelGenerationManager();
        }

        private void InitCollisionManager()
        {
            CollisionManager.Init();
            StartCoroutine(CollisionManager.FindCollision());
        }

        private void InitLevelGenerationManager()
        {
            LevelGenerationManager.Generate();
        }
    }
}