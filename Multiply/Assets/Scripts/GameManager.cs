using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject start_image;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetString("multipliedBy"));

        StartCoroutine(StartRoutine());
    }

    IEnumerator StartRoutine()
    {
        start_image.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        start_image.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        start_image.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);
        StartGame();
    }

    private void StartGame()
    {
        Debug.Log("Oyun Basladi!");
    }
}
