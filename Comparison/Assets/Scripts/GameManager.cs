using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject puanSurePaneli;
    [SerializeField] private GameObject puaniKapYazisi;

    [Header("Questions")]
    [SerializeField] private Transform ustDikdortgen;
    [SerializeField] private Transform altDikdortgen;

    [Header("Texts")]
    [SerializeField] private Text ust_Text;
    [SerializeField] private Text alt_Text;


    private void Start() {
        ust_Text.text = "0";
        alt_Text.text = "0";

        SahneEkraniniGuncelle();
    }

    private void SahneEkraniniGuncelle() {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(1f, 1f);

        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
    }


    public void OyunaBasla() {
        Debug.Log("Oyun Basladi.");
    }
}
