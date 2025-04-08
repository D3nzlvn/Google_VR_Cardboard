using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; // New Input System Support

namespace SojaExiles
{
    public class Drawer_Pull_Zopp : MonoBehaviour
    {
        public Animator pull;
        public bool open;
        public Transform Player;

        private PlayerInput playerInput;
        private bool isLooking = false;

        void Awake()
        {
            // Check if PlayerInput component exists (for new Input System)
            playerInput = GetComponent<PlayerInput>();
        }

        void Start()
        {
            open = false;
        }

        void Update()
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);

                // Ensure drawer interaction only works when looking at it and within range
                if (dist < 2 && isLooking && CheckInput())
                {
                    if (!open)
                        StartCoroutine(opening());
                    else
                        StartCoroutine(closing());
                }
            }
        }

        bool CheckInput()
        {
            // Old Input System (Mouse and Gamepad)
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Submit"))
                return true;

            // New Input System (for Android + Gamepad Support)
            if (playerInput != null && playerInput.actions["Interact"].WasPressedThisFrame())
                return true;

            return false;
        }

        // Called when looking at the drawer
        public void OnPointerEnter()
        {
            isLooking = true;
        }

        // Called when looking away from the drawer
        public void OnPointerExit()
        {
            isLooking = false;
        }

        IEnumerator opening()
        {
            print("You are opening the drawer");
            pull.Play("openpullopp");
            open = true;
            yield return new WaitForSeconds(0.5f);
        }

        IEnumerator closing()
        {
            print("You are closing the drawer");
            pull.Play("closepushopp");
            open = false;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
