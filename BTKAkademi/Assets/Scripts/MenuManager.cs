using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button start_button, quit_button;
    [SerializeField]
    private GameObject alpha_Panel;

    void Start() {
        FadeOut();
    }

    private void FadeOut() {
        start_button.GetComponent<CanvasGroup>().DOFade(1, 0.8f);
        quit_button.GetComponent<CanvasGroup>().DOFade(1, 0.8f).SetDelay(0.5f);
    }

    #region ButtonEvents
    public void StartButton() {
        /*alpha_Panel.SetActive(true);
        alpha_Panel.GetComponent<CanvasGroup>().DOFade(1, 2f);*/
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButton() {
        Debug.Log("Application Quitted!");
        Application.Quit();
    }
    #endregion
}
