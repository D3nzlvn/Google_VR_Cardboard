using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; // New Input System Support

namespace SojaExiles
{
    public class opencloseDoor1 : MonoBehaviour
    {
        public Animator openandclose;
        public bool open;
        public Transform Player;
        private PlayerInput playerInput;
        private bool isLooking = false;

        void Awake()
        {
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
                
                // Ensure door interaction only works when looking at it and within range
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

        // Called when looking at the door
        public void OnPointerEnter()
        {
            isLooking = true;
        }

        // Called when looking away from the door
        public void OnPointerExit()
        {
            isLooking = false;
        }

        IEnumerator opening()
        {
            print("You are opening the door");
            openandclose.Play("Opening");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("You are closing the door");
            openandclose.Play("Closing");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}
