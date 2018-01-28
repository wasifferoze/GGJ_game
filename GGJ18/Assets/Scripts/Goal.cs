using AssemblyCSharp.Scripts.SerialValue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    public class Goal : MonoBehaviour, ICollidable
    {
        [SerializeField] public CollisionManager CollisionManager;
        [SerializeField] public SerialEvent WinEvent;

        public float GetAngle()
        {
            return 0;
        }

        public Vector2 GetPosition()
        {
            var pos = transform.position;
            return new Vector2(pos.x, pos.z);
        }

        public float GetRadius()
        {
            return 0.5f;
        }

        public bool IsCollide(ICollidable collidable, out Vector2 delta)
        {
            delta = GetPosition() - collidable.GetPosition();
            float sumRad = GetRadius() + collidable.GetRadius();
            return delta.sqrMagnitude < sumRad * sumRad;
        }

        public void OnCollide(ICollidable collidable, Vector2 delta)
        {
            PlayerPawn player = collidable as PlayerPawn;
            if (player == null) { return; }

            WinEvent.Invoke();
            gameObject.SetActive(false);
        }

        public void SetAngle(float angle)
        {
            return;
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = new Vector3(position.x, 0, position.y);
        }

        private void Start()
        {
            CollisionManager.ReportCollidable(this);
        }
    }
}