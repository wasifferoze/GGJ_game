using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    public class Game : MonoBehaviour
    {
        public CollisionManager CollisionManager;
        public LevelGenerationManager LevelGenerationManager;
        public PawnSpawnManager PawnSpawnManager;

        void Start()
        {
            InitCollisionManager();
            InitLevelGenerationManager();
            InitializePawnSpawnManager();
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

        private void InitializePawnSpawnManager()
        {
            PawnSpawnManager.InitializePool();
            PawnSpawnManager.Spawn(10);
        }
    }
}