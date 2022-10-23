using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject kare_Prefab;
    [SerializeField] private Transform kareler_Panel;
    [SerializeField] private Transform soru_Panel;
    [SerializeField] private GameObject hakPanel;
    [SerializeField] private Text soru_Text;
    [SerializeField] private Sprite[] kareSprites;

    private GameObject[] kareler = new GameObject[25];
    private GameObject seciliKare;
    private List<int> degerler = new List<int>();
    private int bolenSayi, bolunenSayi, kacinciSoru = 0, dogruSonuc;
    private int butonDegeri;
    private bool karelereBasilsinmi = false;
    private int kalanHak = 3;

    private PuanManager puanManager;
    private string soruZorlukDerecesi;

    private void Start() {
        puanManager = GameObject.FindObjectOfType<PuanManager>();
        soru_Panel.GetComponent<RectTransform>().localScale = Vector3.zero;
        KareleriOlustur();
    }

    private void KareleriOlustur() {
        for (int i = 0; i < 25; i++) {
            GameObject kare = Instantiate(kare_Prefab, kareler_Panel);
            kare.GetComponent<Button>().onClick.AddListener(() => ClickEvent());
            kare.transform.GetChild(1).GetComponent<Image>().sprite = kareSprites[Random.Range(0, kareSprites.Length)];
            kareler[i] = kare;
        }
        DegerleriKarelereYaz();
        StartCoroutine(DoFadeRoutine());
        Invoke("SoruPaneliniAc", 2f);
    }

    private void ClickEvent() {
        if (karelereBasilsinmi) {
            seciliKare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            butonDegeri = int.Parse(seciliKare.transform.GetChild(0).GetComponent<Text>().text);
            SonucuKontrolEt();
        }
    }

    #region Animation
    private IEnumerator DoFadeRoutine() {
        foreach (var kare in kareler) {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    #endregion

    #region SquareMathField
    private void DegerleriKarelereYaz() {
        foreach (var kare in kareler) {
            var deger = Random.Range(1, 12);
            degerler.Add(deger);
            kare.transform.GetChild(0).GetComponent<Text>().text = deger.ToString();
        }
    }

    private void SonucuKontrolEt() {
        if (butonDegeri == dogruSonuc) {
            seciliKare.transform.GetChild(0).GetComponent<Text>().text = "";
            seciliKare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            seciliKare.GetComponent<Button>().interactable = false;
            puanManager.PuanArttir(soruZorlukDerecesi);
            degerler.RemoveAt(kacinciSoru);
            if (degerler.Count < 0)
                SoruPaneliniAc();
            else
                OyunBitti();
        }
        else {
            kalanHak--;
            hakPanel.GetComponent<KalpManager>().HakSorgula(kalanHak);
        }

        if (kalanHak <= 0) {
            OyunBitti();
        }
    }
    #endregion

    #region Question Field
    private void OyunBitti() => Debug.Log("Oyun Bitti");

    private void SoruPaneliniAc() {
        SoruSor();
        karelereBasilsinmi = true;
        soru_Panel.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    private void SoruSor() {
        bolenSayi = Random.Range(2, 11);
        kacinciSoru = Random.Range(0, degerler.Count);
        dogruSonuc = degerler[kacinciSoru];
        bolunenSayi = bolenSayi * dogruSonuc;
        soru_Text.text = bolunenSayi.ToString() + " : " + bolenSayi.ToString();

        if (bolunenSayi >= 40) {
            soruZorlukDerecesi = "Zor";
        }
        else if (bolunenSayi >= 80) {
            soruZorlukDerecesi = "Orta";
        }
        else {
            soruZorlukDerecesi = "Kolay";
        }
    }
    #endregion
}
