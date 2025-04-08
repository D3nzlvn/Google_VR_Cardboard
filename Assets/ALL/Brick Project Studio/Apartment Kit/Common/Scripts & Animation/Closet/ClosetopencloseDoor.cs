using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; // New Input System Support

namespace SojaExiles
{
    public class ClosetopencloseDoor : MonoBehaviour
    {
        public Animator Closetopenandclose;
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
                if (dist < 1.5 && isLooking && CheckInput())
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
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Submit"))
                return true;

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
            print("You are opening the closet door");
            Closetopenandclose.Play("ClosetOpening");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("You are closing the closet door");
            Closetopenandclose.Play("ClosetClosing");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}
