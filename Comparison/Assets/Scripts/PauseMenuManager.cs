using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu_Panel;

    private void OnEnable() {
        Time.timeScale = 0.1f;
    }

    private void OnDisable() {
        Time.timeScale = 1f;
    }

    public void Resume() => pauseMenu_Panel.SetActive(false);

    public void BackToMenu() => SceneManager.LoadScene(0);

    public void Quit() => Application.Quit();
}
