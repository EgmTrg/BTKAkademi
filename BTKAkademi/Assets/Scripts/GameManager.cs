using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject kare_Prefab;
    [SerializeField] private Transform kareler_Panel;
    [SerializeField] private Transform soru_Panel;
    [SerializeField] private Text soru_Text;

    private GameObject[] kareler = new GameObject[25];
    private List<int> degerler = new List<int>();
    private int bolenSayi, bolunenSayi, kacinciSoru = 0;


    private void Start() {
        soru_Panel.GetComponent<RectTransform>().localScale = Vector3.zero;
        KareleriOlustur();
    }


    private void KareleriOlustur() {
        for (int i = 0; i < 25; i++) {
            GameObject kare = Instantiate(kare_Prefab, kareler_Panel);
            kareler[i] = kare;
        }
        DegerleriKarelereYaz();
        StartCoroutine(DoFadeRoutine());
        Invoke("SoruPaneliniAc", 2f);
    }

    private IEnumerator DoFadeRoutine() {
        foreach (var kare in kareler) {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void DegerleriKarelereYaz() {
        foreach (var kare in kareler) {
            var deger = Random.Range(1, 12);
            degerler.Add(deger);
            kare.transform.GetChild(0).GetComponent<Text>().text = deger.ToString();
        }
    }

    private void SoruPaneliniAc() {
        SoruSor();
        soru_Panel.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
    }

    private void SoruSor() {
        bolenSayi = Random.Range(2, 11);
        kacinciSoru = Random.Range(0, degerler.Count);
        bolunenSayi = bolenSayi * degerler[kacinciSoru];
        soru_Text.text = bolunenSayi.ToString() + " : " + bolenSayi.ToString();
    }
}
