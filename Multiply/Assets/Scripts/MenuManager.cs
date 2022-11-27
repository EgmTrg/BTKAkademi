using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("MAIN MENU OBJECTS")]
    [Header("Buttons")]
    [SerializeField] private Button play_btn;
    [SerializeField] private Button settings_btn;
    [SerializeField] private Button detailedSettings_btn;
    [SerializeField] private Button quit_btn;

    [Header("Panels")]
    [SerializeField] private GameObject multiply_Text;

    [Header("Ropes")]
    [SerializeField] private GameObject rope_one;
    [SerializeField] private GameObject rope_two;
    [SerializeField] private GameObject rope_three;

    private void Start() {
        MenuFadeAnimation();
    }

    #region Menu Animations
    private void MenuFadeAnimation() {
        multiply_Text.GetComponent<CanvasGroup>().DOFade(1f, 0.2f);
        rope_one.GetComponent<CanvasGroup>().DOFade(1f, 0.2f);
        rope_two.GetComponent<CanvasGroup>().DOFade(1f, 0.2f);
        play_btn.GetComponent<CanvasGroup>().DOFade(1f, 0.2f).SetDelay(0.2f);
        rope_three.GetComponent<CanvasGroup>().DOFade(1f, 0.2f).SetDelay(0.2f);
        settings_btn.GetComponent<CanvasGroup>().DOFade(1f, 0.2f).SetDelay(0.4f);
        quit_btn.GetComponent<CanvasGroup>().DOFade(1f, 0.2f).SetDelay(0.6f);
    }
    #endregion

    #region Button Methods
    public void PlayButton_Event() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //public void SettingsButton_Event() => detailedSettings_btn.GetComponent<RectTransform>().DOMoveY(-20, 1f);
    public void QuitButton_Event() => Application.Quit();
    #endregion
}
