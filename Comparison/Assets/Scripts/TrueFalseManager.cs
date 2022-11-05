using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField] private GameObject trueIcon, falseIcon;

    private void Start() {
        ScaleDegeriniKapat();
    }

    public void TrueFalseScaleAc(bool dogrumuYanlismi) {
        if (dogrumuYanlismi) {
            trueIcon.GetComponent<RectTransform>().DOScale(1f, 0.2f).SetEase(Ease.OutBack);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
            Invoke("ScaleDegeriniKapat", 0.5f);
            ScaleDegeriniKapat();
        }
        else {
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
            falseIcon.GetComponent<RectTransform>().DOScale(1f, 0.2f).SetEase(Ease.OutBack);
            Invoke("ScaleDegeriniKapat", 0.5f);
            ScaleDegeriniKapat();
        }
    }

    private void ScaleDegeriniKapat() {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
