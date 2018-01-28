using AssemblyCSharp.Scripts.SerialValue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AssemblyCSharp
{
    public class EnergyBar : MonoBehaviour
    {
        [SerializeField] public SerialFloat Energy;
        [SerializeField] public SerialEvent EnergyDepleted;
        [SerializeField] public SerialEvent WinEvent;
        [SerializeField] public SerialEvent InfectedEvent;
        [SerializeField] public SerialEvent DeinfectedEvent;

        [SerializeField] public Slider Slider;
        [SerializeField] public int GameTimeInSeconds;

        private bool IsInfected = false;

        private void Start()
        {
            UnityEvent OnWinEvent = new UnityEvent();
            OnWinEvent.AddListener(new UnityAction(OnWin));
            WinEvent.AddListener(OnWinEvent);

            UnityEvent OnInfectedEvent = new UnityEvent();
            OnInfectedEvent.AddListener(new UnityAction(OnInfected));
            InfectedEvent.AddListener(OnInfectedEvent);

            UnityEvent OnDeinfectedEvent = new UnityEvent();
            OnDeinfectedEvent.AddListener(new UnityAction(OnDeinfected));
            DeinfectedEvent.AddListener(OnDeinfectedEvent);

            Energy.Value = 1.0f;
            StartCoroutine(UpdateEnergyValue());
        }

        private void Update()
        {
            Slider.value = Mathf.Lerp(Slider.value, Energy.Value, 0.1f);
        }

        private void OnWin()
        {
            enabled = false;
        }

        private void OnInfected()
        {
            IsInfected = true;
        }

        private void OnDeinfected()
        {
            IsInfected = false;
        }

        public IEnumerator UpdateEnergyValue()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f);
                Energy.Value -= (IsInfected ? 2.0f : 1.0f) / GameTimeInSeconds;
                if (Energy.Value <= 0)
                {
                    break;
                }
            }

            EnergyDepleted.Invoke();
        }
    }
}