using AssemblyCSharp.Scripts.SerialValue;
using UnityEngine.Events;
using UnityEngine;

namespace AssemblyCSharp.Scripts
{
    public sealed class PlayerPawn : Pawn
    {
        [SerializeField] public SerialEvent SlingShootEvent;
        [SerializeField] public SerialEvent EnergyDepletedEvent;
        [SerializeField] public SerialEvent WinEvent;

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
            EnergyDepletedEvent.AddListener(energyDepletedUnityEvent);

            var winUnitytEvent = new UnityEvent();
            winUnitytEvent.AddListener(new UnityAction(OnWin));
            WinEvent.AddListener(winUnitytEvent);
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

        private void OnWin()
        {
            if (!IsAlive) { return; }

            Animator.Play("PlayerWin");
            IsAlive = false;
            enabled = false;
        }

        public override void OnCollide(ICollidable collidable, Vector2 delta)
        {
            return;
        }
    }
}

