using UnityEngine;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    public void OyunaYenidenBasla() { 
        SceneManager.LoadScene(1);
    }

    public void AnaMenuyeDon() {
        SceneManager.LoadScene(0);
    }
}
