using UnityEngine;
using UnityEngine.SceneManagement;


public class NaviUIHandler : MonoBehaviour
{
    public int room;
    public void GoToFloor(int room)
    {
        SceneManager.LoadScene(room);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
