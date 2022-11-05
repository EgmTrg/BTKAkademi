using DG.Tweening;
using UnityEngine;

public class DairelerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] daireler;

    private void Start() {
        DairelerScaleKapat();
    }

    public void DairelerScaleKapat() {
        foreach (GameObject daire in daireler) {
            daire.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    public void DairelerScaleAc(int hangiDaire) {
        daireler[hangiDaire].GetComponent<RectTransform>().DOScale(0.4f, 0.3f);
        if (hangiDaire%5==0) {
            DairelerScaleKapat();
        }
    }
}
