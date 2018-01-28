using AssemblyCSharp.Scripts.SerialValue;
using UnityEngine.Events;
using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    public sealed class PlayerPawn : Pawn
    {
        [SerializeField] public SerialEvent SlingShootEvent;
        [SerializeField] public SerialVector2 SlingShootValue;
        [SerializeField] public SerialFloat SlingShootPower;

        protected override void Init()
        {
            var slingShootUnityEvent = new UnityEvent();
            slingShootUnityEvent.AddListener(new UnityAction(OnSlingShoot));
            SlingShootEvent.AddListener(slingShootUnityEvent);
        }

        private void OnSlingShoot()
        {
            Vector2 sling = SlingShootValue.Value;
            SetAngle(Mathf.Atan2(sling.y, sling.x) - 0.5f * Mathf.PI);
            CurrentVelocity += sling.magnitude * Mathf.Min(SlingShootPower.Value, MaxSpeed.Value);
        }

        protected override void Update()
        {
            Vector3 speed = new Vector3(
                                x: CurrentVelocity * Mathf.Cos(CurrentAngle),
                                y: 0.0f,
                                z: CurrentVelocity * Mathf.Sin(CurrentAngle)
                            );
            transform.position += speed * Time.deltaTime;
            if (speed.sqrMagnitude > 0.1f)
            {
                transform.forward = speed.normalized;
            }
            CurrentVelocity *= SpeedDecay.Value / (Time.deltaTime * 60.0f);
        }

        public override void OnCollide(ICollidable collidable, Vector2 delta)
        {
            return;
        }
    }
}

