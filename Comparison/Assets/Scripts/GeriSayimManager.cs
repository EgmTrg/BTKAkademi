using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeriSayimManager : MonoBehaviour
{
    [SerializeField] private GameObject geriSayim_Object;
    [SerializeField] private Text geriSayim_Text;

    [SerializeField] private GameManager gameManager;


    private void Awake() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    IEnumerator GeriSayRoutine() {
        geriSayim_Text.text = "3";
        yield return new WaitForSeconds(0.5f);
        geriSayim_Object.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        geriSayim_Object.GetComponent<RectTransform>().DOScale(0, 0.2f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.3f);

        geriSayim_Text.text = "2";
        yield return new WaitForSeconds(0.5f);
        geriSayim_Object.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        geriSayim_Object.GetComponent<RectTransform>().DOScale(0, 0.2f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.3f);

        geriSayim_Text.text = "1";
        yield return new WaitForSeconds(0.5f);
        geriSayim_Object.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        geriSayim_Object.GetComponent<RectTransform>().DOScale(0, 0.2f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.3f);
        StopAllCoroutines();

        gameManager.OyunaBasla();
    }
}
