using AssemblyCSharp.Scripts.SerialValue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
    public class EnergyBar : MonoBehaviour
    {
        [SerializeField] public SerialFloat Energy;
        [SerializeField] public Slider Slider;
        [SerializeField] public int GameTimeInSeconds;

        private void Start()
        {
            Energy.Value = 1.0f;
            StartCoroutine(UpdateEnergyValue());
        }

        private void Update()
        {
            Slider.value = Mathf.Lerp(Slider.value, Energy.Value, 0.1f);
        }

        public IEnumerator UpdateEnergyValue()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f);
                Energy.Value -= 1.0f / GameTimeInSeconds;
            }
        }
    }
}