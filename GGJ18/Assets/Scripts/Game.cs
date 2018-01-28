using AssemblyCSharp.Scripts.SerialValue;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace AssemblyCSharp.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] public CollisionManager CollisionManager;
        [SerializeField] public LevelGenerationManager LevelGenerationManager;
        [SerializeField] public PawnSpawnManager PawnSpawnManager;
        [SerializeField] public int SpawnCount = 30;

        [SerializeField] public SerialEvent OnWin;
        [SerializeField] public SerialEvent OnDie;

        void Awake()
        {
            InitCollisionManager();
            InitLevelGenerationManager();
            InitializePawnSpawnManager();

            var winUnityEvent = new UnityEvent();
            winUnityEvent.AddListener(new UnityAction(OnWinCallback));
            OnWin.AddListener(winUnityEvent);

            var dieUnityEvent = new UnityEvent();
            dieUnityEvent.AddListener(new UnityAction(OnDieCallback));
            OnWin.AddListener(dieUnityEvent);
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

        private void OnWinCallback()
        {
            StartCoroutine(DelayedSceneLoad("win", 2.5f));
        }

        private void OnDieCallback()
        {
            StartCoroutine(DelayedSceneLoad("die", 2.5f));
        }

        private IEnumerator DelayedSceneLoad(string sceneName, float time)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(sceneName);
        }
    }
}