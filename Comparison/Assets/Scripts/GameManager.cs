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

    TimerManager timerManager;
    int oyunSayac;
    int kacinciOyun;
    int ustDeger, altDeger, buyukDeger;

    private void Awake() {
        timerManager = GameObject.FindObjectOfType<TimerManager>();
    }

    private void Start() {
        ust_Text.text = "0";
        alt_Text.text = "0";
        oyunSayac = 0;
        kacinciOyun = 0;
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
        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(0f, 0.2f);
        KacinciOyun();
        timerManager.SureyiBaslat();
    }

    private void KacinciOyun() {
        if (oyunSayac<5) {
            kacinciOyun = 1;
        }

        switch (kacinciOyun) {
            case 1:
                BirinciFonksiyon();
                break;
            default:
                break;
        }
    }

    private void BirinciFonksiyon() {
        int rastgele = Random.Range(0, 50);
        if (rastgele<=25) {
            ustDeger = Random.Range(2, 50);
            altDeger = ustDeger + Random.Range(1, 10);
        }
        else {
            ustDeger = Random.Range(2, 50);
            altDeger = ustDeger + Random.Range(1, 10);
        }

        if (ustDeger>altDeger) {
            buyukDeger = ustDeger;
        }
        else {
            buyukDeger = altDeger;
        }

        ust_Text.text = ustDeger.ToString();
        alt_Text.text = altDeger.ToString();

        Debug.Log($"Buyuk: {buyukDeger}, altDeger: {altDeger}");
    }
}
