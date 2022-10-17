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
    private GameObject[] kareler = new GameObject[25];

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
            kare.transform.GetChild(0).GetComponent<Text>().text = Random.Range(1, 12).ToString();
        }
    }

    private void SoruPaneliniAc() => soru_Panel.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
}
