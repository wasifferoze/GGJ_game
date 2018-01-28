using UnityEngine;
using AssemblyCSharp.Scripts.SerialValue;

namespace AssemblyCSharp.Scripts
{
    public abstract class Pawn : MonoBehaviour, ICollidable
    {
        public CollisionManager CollisionManager;

        [SerializeField] public SerialFloat Radius;
        [SerializeField] public SerialFloat MaxSpeed;
        [SerializeField] public SerialFloat Friction;
        [SerializeField] public SerialFloat SpeedDecay;

        [SerializeField] public GameObject InfectedFX;

        [HideInInspector] public float CurrentVelocity;
        [HideInInspector] public float CurrentAngle;

        public System.Action OnSpawnedEvent;
        public System.Action OnCollideEvent;
        public System.Action<bool> OnInfectiousChange;

        private bool _isInfected = false;
        public bool IsInfected
        {
            get
            {
                return _isInfected;
            }
            set
            {
                _isInfected = value;
                InfectedFX.SetActive(value);

                if (OnInfectiousChange != null)
                {
                    OnInfectiousChange.Invoke(value);
                }
            }
        }

        public float GetRadius()
        {
            return Radius.Value;
        }

        public Vector2 GetPosition()
        {
            Vector3 pos = transform.position;
            return new Vector2(pos.x, pos.z);
        }

        public float GetAngle()
        {
            return CurrentAngle;
        }

        public void SetAngle(float angle)
        {
            CurrentAngle = angle;
        }

        public void SetPosition(Vector2 pos)
        {
            transform.position = new Vector3(
                x: pos.x,
                y: 0.0f,
                z: pos.y
            );
        }

        public bool IsCollide(ICollidable collidable, out Vector2 delta)
        {
            delta = GetPosition() - collidable.GetPosition();
            float sumRad = GetRadius() + collidable.GetRadius();
            return delta.sqrMagnitude < sumRad * sumRad;
        }

        public virtual void OnCollide(ICollidable collidable, Vector2 delta)
        {
            CurrentVelocity *= Friction.Value;
            SetAngle(Mathf.Atan2(delta.y, delta.x));
            float targetDistance = GetRadius() + collidable.GetRadius() + 0.01f;
            Vector2 shift = new Vector2(
                                x: Mathf.Cos(CurrentAngle) * targetDistance,
                                y: Mathf.Sin(CurrentAngle) * targetDistance
                            );

            SetPosition(collidable.GetPosition() + shift);

            if (OnCollideEvent != null)
            {
                OnCollideEvent.Invoke();
            }

            // Pawn to pawn collision
            if (collidable is Pawn)
            {
                Pawn otherPawn = collidable as Pawn;
                float _velocity = CurrentVelocity;
                CurrentVelocity = otherPawn.CurrentVelocity;
                otherPawn.CurrentVelocity = _velocity;

                bool _infections = IsInfected;
                IsInfected = otherPawn.IsInfected;
                otherPawn.IsInfected = _infections;
            }
        }

        private void Start()
        {
            CollisionManager.ReportCollidable(this);
            transform.forward = new Vector3(
                x: Mathf.Cos(CurrentAngle),
                y: 0.0f,
                z: Mathf.Sin(CurrentAngle)
            ).normalized;

            Init();

            if (OnSpawnedEvent != null)
            {
                OnSpawnedEvent.Invoke();
            }
        }

        protected virtual void Update()
        {
            if (CurrentVelocity < Mathf.Epsilon) { return; }

            Vector3 speed = new Vector3(
                            x: CurrentVelocity * Mathf.Cos(CurrentAngle),
                            y: 0.0f,
                            z: CurrentVelocity * Mathf.Sin(CurrentAngle)
                        );

            transform.position += speed * Time.deltaTime;
            transform.forward = speed.normalized;
            CurrentVelocity *= SpeedDecay.Value / (Time.deltaTime * 60.0f);
        }

        protected virtual void Init()
        {
            // Do nothing
        }
    }
}
