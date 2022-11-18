using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject puanSurePaneli;
    [SerializeField] private GameObject puaniKapYazisi;
    [SerializeField] private GameObject buyukOlaniSecYazisi;
    [SerializeField] private GameObject pauseMenu_Panel;

    [Header("Questions")]
    [SerializeField] private Transform ustDikdortgen;
    [SerializeField] private Transform altDikdortgen;

    [Header("Texts")]
    [SerializeField] private Text ust_Text;
    [SerializeField] private Text alt_Text;

    TimerManager timerManager;
    DairelerManager dairelerManager;
    TrueFalseManager trueFalseManager;

    int oyunSayac;
    int kacinciOyun;
    int ustDeger, altDeger, buyukDeger;
    int butonDegeri;

    private void Awake() {
        timerManager = GameObject.FindObjectOfType<TimerManager>();
        dairelerManager = GameObject.FindObjectOfType<DairelerManager>();
        trueFalseManager = GameObject.FindObjectOfType<TrueFalseManager>();
        ust_Text.text = "0";
        alt_Text.text = "0";
        oyunSayac = 0;
        kacinciOyun = 0;
    }

    private void Start() {
        SahneEkraniniGuncelle();
        OyunaBasla();
    }

    public void PauseMenuState() => pauseMenu_Panel.SetActive(true);


    #region Level
    private void KacinciOyun() {
        if (oyunSayac < 5) {
            kacinciOyun = 1;
        }
        else if (oyunSayac >= 5 && oyunSayac < 10) {
            kacinciOyun = 2;
        }
        else if (oyunSayac >= 10 && oyunSayac < 15) {
            kacinciOyun = 3;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20) {
            kacinciOyun = 4;
        }

        switch (kacinciOyun) {
            case 1:
                BirinciFonksiyon();
                break;
            case 2:
                IkinciFonksiyon();
                break;
            case 3:
                UcuncuFonksiyon();
                break;
            case 4:
                DorduncuFonksiyon();
                break;
            default:
                break;
        }
    }

    private void DorduncuFonksiyon() {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 10);
        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 10);

        ustDeger = birinciSayi * ikinciSayi;
        altDeger = ucuncuSayi * dorduncuSayi;

        if (ustDeger > altDeger) {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger) {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger) {
            DorduncuFonksiyon();
            return;
        }

        ust_Text.text = birinciSayi + "x" + ikinciSayi;
        alt_Text.text = ucuncuSayi + "x" + dorduncuSayi;
    }

    private void UcuncuFonksiyon() {
        int birinciSayi = Random.Range(11, 30);
        int ikinciSayi = Random.Range(1, 11);
        int ucuncuSayi = Random.Range(11, 40);
        int dorduncuSayi = Random.Range(1, 11);

        ustDeger = birinciSayi - ikinciSayi;
        altDeger = ucuncuSayi - dorduncuSayi;

        if (ustDeger > altDeger) {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger) {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger) {
            UcuncuFonksiyon();
            return;
        }

        ust_Text.text = birinciSayi + "-" + ikinciSayi;
        alt_Text.text = ucuncuSayi + "-" + dorduncuSayi;
    }

    private void IkinciFonksiyon() {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 20);
        int ucuncuSayi = Random.Range(1, 20);
        int dorduncuSayi = Random.Range(1, 20);

        ustDeger = birinciSayi + ikinciSayi;
        altDeger = ucuncuSayi + dorduncuSayi;

        if (ustDeger > altDeger) {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger) {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger) {
            IkinciFonksiyon();
            return;
        }

        ust_Text.text = birinciSayi + "+" + ikinciSayi;
        alt_Text.text = ucuncuSayi + "+" + dorduncuSayi;
    }

    private void BirinciFonksiyon() {
        int rastgele = Random.Range(0, 50);
        if (rastgele <= 25) {
            ustDeger = Random.Range(2, 50);
            altDeger = ustDeger + Random.Range(1, 15);
        }
        else {
            ustDeger = Random.Range(2, 50);
            altDeger = Mathf.Abs(ustDeger - Random.Range(1, 10));
        }

        if (ustDeger > altDeger) {
            buyukDeger = ustDeger;
        }
        else {
            buyukDeger = altDeger;
        }

        ust_Text.text = ustDeger.ToString();
        alt_Text.text = altDeger.ToString();
    }

    public void ButonDegeriBelirle(string butonAdi) {
        if (butonAdi == "ustButon") {
            butonDegeri = ustDeger;
        }
        else if (butonAdi == "altButon") {
            butonDegeri = altDeger;
        }

        if (butonDegeri == buyukDeger) {
            trueFalseManager.TrueFalseScaleAc(true, 10);
            dairelerManager.DairelerScaleAc(oyunSayac % 5);
            oyunSayac++;
            KacinciOyun();
        }
        else {
            trueFalseManager.TrueFalseScaleAc(false);
            HatayaGoreSayaciAzalt();
            KacinciOyun();
        }
    }
    #endregion

    public void OyunaBasla() {
        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(0f, 1f).SetDelay(2f);
        buyukOlaniSecYazisi.GetComponent<CanvasGroup>().DOFade(1f, 1f).SetDelay(2f);
        KacinciOyun();
        timerManager.SureyiBaslat();
    }

    private void SahneEkraniniGuncelle() {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(1f, 1f);

        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
    }

    private void HatayaGoreSayaciAzalt() {
        oyunSayac -= (oyunSayac % 5 + 5);

        if (oyunSayac < 0) {
            oyunSayac = 0;
        }
        dairelerManager.DairelerScaleKapat();
    }

}
