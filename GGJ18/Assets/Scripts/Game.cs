using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] public CollisionManager CollisionManager;
        [SerializeField] public LevelGenerationManager LevelGenerationManager;
        [SerializeField] public PawnSpawnManager PawnSpawnManager;
        [SerializeField] public int SpawnCount = 30;

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
            PawnSpawnManager.Spawn(SpawnCount);
        }
    }
}