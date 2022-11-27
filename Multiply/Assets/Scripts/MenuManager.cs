using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("MAIN MENU OBJECTS")]
    [Header("Buttons")]
    [SerializeField] private Button play_btn;
    [SerializeField] private Button settings_btn;
    [SerializeField] private GameObject soundSettings_Image; // Children are button.
    [SerializeField] private Button quit_btn;

    [Header("Panels")]
    [SerializeField] private GameObject UI_Panel;
    [SerializeField] private GameObject multiply_Text;

    [Header("Ropes")]
    [SerializeField] private GameObject rope_one;
    [SerializeField] private GameObject rope_two;
    [SerializeField] private GameObject rope_three;

    private bool settings_Pressed = false;

    private void Start()
    {
        MenuFadeAnimation();
    }

    #region Menu Animations
    private void MenuFadeAnimation()
    {
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
    public void PlayButton_Event() => UI_Panel.GetComponent<RectTransform>().DOLocalMoveX(618, 1f).SetEase(Ease.InOutCirc);
    public void SettingsButton_Event() => SoundSettingsStatus();
    public void QuitButton_Event() => Application.Quit();
    public void SoundOn_Event() => Debug.Log("Sound are muted!");
    public void SoundOff_Event() => Debug.Log("Sound are unmuted!");
    public void Back_Event() => UI_Panel.GetComponent<RectTransform>().DOLocalMoveX(0, 1f).SetEase(Ease.OutSine);
    public void LevelButtons_Event(int multipliedByWhat) => test(multipliedByWhat);
    #endregion

    private void SoundSettingsStatus()
    {
        if (!settings_Pressed)
        {
            soundSettings_Image.GetComponent<RectTransform>().DOMoveY(245, 1.5f).SetDelay(0.2f);
            settings_Pressed = true;
        }
        else
        {
            soundSettings_Image.GetComponent<RectTransform>().DOMoveY(310, 1.5f).SetDelay(0.2f);
            settings_Pressed = false;
        }
    }

    private void test(int multipliedByWhat)
    {
        PlayerPrefs.SetString("multipliedBy", multipliedByWhat.ToString());
        Debug.Log(PlayerPrefs.GetString("multipliedBy"));
    }
}
