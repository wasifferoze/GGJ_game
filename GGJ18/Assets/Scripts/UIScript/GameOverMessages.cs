using AssemblyCSharp.Scripts.SerialValue;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AssemblyCSharp.Scripts
{
    public class GameOverMessages : MonoBehaviour
    {
        [SerializeField] public SerialEvent WinEvent;
        [SerializeField] public SerialEvent DefeatEvent;

        [SerializeField] public GameObject WinMessage;
        [SerializeField] public GameObject DefeatMessage;

        private void Start()
        {
            UnityEvent OnWinEvent = new UnityEvent();
            OnWinEvent.AddListener(new UnityAction(OnWin));
            WinEvent.AddListener(OnWinEvent);

            UnityEvent OnDefeatEvent = new UnityEvent();
            OnDefeatEvent.AddListener(new UnityAction(OnDefeat));
            DefeatEvent.AddListener(OnDefeatEvent);
        }

        private void OnDefeat()
        {
            DefeatMessage.SetActive(true);
        }

        private void OnWin()
        {
            WinMessage.SetActive(true);
        }
    }
}