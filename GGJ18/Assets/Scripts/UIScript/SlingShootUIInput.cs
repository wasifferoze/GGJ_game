using AssemblyCSharp.Scripts.SerialValue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp.Scripts
{
    public class SlingShootUIInput : MonoBehaviour
    {
        [SerializeField] public SerialEvent OnSlingShootEvent;
        [SerializeField] public SerialVector2 SlingShootValue;
        [SerializeField] public SerialFloat SlingShootDelay;
        [SerializeField] public Image Hook;
        [SerializeField] public ControlMode ControlMode;

        private Vector3 InitialZonePosition;
        private Vector3 InitialHookPosition;
        private Vector2 DragStartPosition;
        private bool IsMouseDragging = false;
        private float AvailableTime;

        private void Start()
        {
            InitialZonePosition = transform.position;
            InitialHookPosition = Hook.transform.position;
        }

        private void Update()
        {
            if (Time.time < AvailableTime) { return; }

            if (ControlMode == ControlMode.Mouse)
            {
                HandleMouse();
            }
            else
            {
                // Untested code
                HandleTouch();
            }
        }

        private void HandleTouch()
        {
            if (Input.touchCount != 1) { return; }

            var touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                DragStartPosition = touch.position;

                transform.position = DragStartPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Hook.transform.position = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 delta = touch.position - DragStartPosition;
                SlingShootValue.Value = new Vector2(
                    x: delta.x,
                    y: delta.y
                );
                OnSlingShootEvent.Invoke();

                transform.position = InitialZonePosition;
                Hook.transform.position = InitialHookPosition;

                AvailableTime = Time.time + SlingShootDelay.Value;
            }
        }

        private void HandleMouse()
        {
            if (Input.GetMouseButtonDown(0))
            {
                DragStartPosition = Input.mousePosition;
                IsMouseDragging = true;

                transform.position = DragStartPosition;
                return;
            }

            Vector2 delta = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - DragStartPosition;
            if (Input.GetMouseButtonUp(0))
            {
                IsMouseDragging = false;
                SlingShootValue.Value = new Vector2(
                    x: delta.x,
                    y: delta.y
                );
                OnSlingShootEvent.Invoke();

                transform.position = InitialZonePosition;
                Hook.transform.position = InitialHookPosition;

                AvailableTime = Time.time + SlingShootDelay.Value;
                return;
            }

            if (!IsMouseDragging) { return; }
            Hook.transform.position = Input.mousePosition;
        }
    }

    public enum ControlMode
    {
        Touch,
        Mouse,
    }
}