using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseXSensitivity = 100f;
        public float controllerXSensitivity = 50f; // Lower sensitivity for joysticks
        public float controllerYSensitivity = 50f;

        public Transform playerBody;

        float xRotation = 0f;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            // Mouse input
            float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

            // Controller input (Right Stick)
            float controllerX = Input.GetAxis("RightStickX") * controllerXSensitivity * Time.deltaTime;
            float controllerY = Input.GetAxis("RightStickY") * controllerYSensitivity * Time.deltaTime;

            // Combine inputs (Use either mouse or controller)
            float finalX = mouseX + controllerX;
            float finalY = mouseY + controllerY;

            // Apply rotation
            xRotation -= finalY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * finalX);
        }
    }
}
