using AssemblyCSharp.Scripts.SerialValue;
using UnityEngine.Events;
using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    public sealed class PlayerPawn : Pawn
    {
        [SerializeField] public SerialEvent SlingShootEvent;
        [SerializeField] public SerialEvent EnergyDepleted;

        [SerializeField] public SerialVector2 SlingShootValue;
        [SerializeField] public SerialFloat SlingShootPower;
        [SerializeField] public Animator Animator;

        private bool IsAlive = true;

        protected override void Init()
        {
            var slingShootUnityEvent = new UnityEvent();
            slingShootUnityEvent.AddListener(new UnityAction(OnSlingShoot));
            SlingShootEvent.AddListener(slingShootUnityEvent);

            var energyDepletedUnityEvent = new UnityEvent();
            energyDepletedUnityEvent.AddListener(new UnityAction(OnEnergyDepleted));
            EnergyDepleted.AddListener(energyDepletedUnityEvent);
        }

        private void OnSlingShoot()
        {
            if (!IsAlive) { return; }

            Vector2 sling = SlingShootValue.Value;
            SetAngle(Mathf.Atan2(sling.y, sling.x) - 0.5f * Mathf.PI);
            CurrentVelocity += sling.magnitude * Mathf.Min(SlingShootPower.Value, MaxSpeed.Value);
            Animator.Play("PlayerPush");
        }

        private void OnEnergyDepleted()
        {
            if (!IsAlive) { return; }

            Animator.Play("EnergyDepletedDie");
            IsAlive = false;
            enabled = false;
        }

        public override void OnCollide(ICollidable collidable, Vector2 delta)
        {
            return;
        }
    }
}

