using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu{
    public class ExtraLinks : MonoBehaviour{
        public void CCP(){
            Application.OpenURL("http://u3d.as/1JZG");
        }

        public void SciFi(){
            Application.OpenURL("http://u3d.as/1AaR");
        }

        public void Clean1(){
            Application.OpenURL("http://u3d.as/1hTi");
        }

        public void Essence(){
            Application.OpenURL("http://u3d.as/1t11");
        }

        public int room;
        public void GoToFloor(int room)
        {
            SceneManager.LoadScene(room);
        }
    }
}
