using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Camera playerCamera;
        public float speed = 5f;
        public float gravity = -15f;

        private Vector3 velocity;
        private bool isGrounded;

        void Update()
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // Prevents sticking to slopes
            }

            // Get movement input
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            // Make movement relative to the camera
            Vector3 forward = playerCamera.transform.forward;
            Vector3 right = playerCamera.transform.right;
            forward.y = 0; // Ignore vertical influence
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            Vector3 move = (right * x + forward * z).normalized;
            controller.Move(move * speed * Time.deltaTime);

            // Apply Gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
