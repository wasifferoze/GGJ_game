using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AssemblyCSharp.Scripts.SerialValue
{
    [CreateAssetMenu()]
    public class SerialEvent : ScriptableObject
    {
        private List<UnityEvent> Events = new List<UnityEvent>();

        public void Invoke()
        {
            Events.ForEach((unityEvent) => unityEvent.Invoke());
        }
        public void AddListener(UnityEvent callback)
        {
            if (!Events.Contains(callback))
            {
                Events.Add(callback);
            }
        }
    }
}
