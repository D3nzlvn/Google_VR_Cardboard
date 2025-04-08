using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // For new input system

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 120.0f;
    public GameObject mainMenu;

    private static int lastSceneIndex = -1;

    void Update()
    {
        // Scene Switching with Escape or Y button on Xbox Controller
        if (Input.GetKeyDown(KeyCode.Escape) || (Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            int sceneIndex = currentScene.buildIndex;

            if (sceneIndex == 0 && lastSceneIndex >= 1 && lastSceneIndex <= 3)
            {
                SceneManager.LoadScene(lastSceneIndex);
            }
            else if (sceneIndex >= 1 && sceneIndex <= 3)
            {
                lastSceneIndex = sceneIndex;
                SceneManager.LoadScene(0);
            }
        }
    }
}
